using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

using Geometry;
using Geometry.Shapes;
using GoBot.GameElements;
using GoBot.PathFinding;

namespace GoBot.Movements
{
    public abstract class Movement
    {
        protected DateTime dateMinimum { get; set; }
        protected DateTime startTime { get; set; }
        protected int minimumOpponentDistance { get; set; }

        /// <summary>
        /// Facteur pour la normalisation du cout de l'action affiché à 1 pour la moins chère de toutes
        /// </summary>
        public double DisplayCostFactor { get; set; }

        /// <summary>
        /// Obtient si le mouvement est réalisable (par exemple stock pas plein)
        /// </summary>
        public abstract bool CanExecute { get; }

        /// <summary>
        /// Obtient le score rapporté par l'execution de l'action
        /// </summary>
        public abstract int Score { get; }

        /// <summary>
        /// Obtient la valeur de l'action, c'est à dire l'interet qu'il existe à la réaliser
        /// </summary>
        public abstract double Value { get; }

        /// <summary>
        /// Obtient la liste des positions à laquelle le mouvement est réalisable
        /// </summary>
        public List<Position> Positions { get; protected set; }

        /// <summary>
        /// Obtient l'élément en relation avec le mouvement (optionnel)
        /// </summary>
        public abstract GameElement Element { get; }

        /// <summary>
        /// Obtient le robot qui doit executer ce mouvement
        /// </summary>
        public abstract Robot Robot { get; }

        /// <summary>
        /// Obtient la couleur d'appartenance de l'action (ou blanc)
        /// </summary>
        public abstract Color Color { get; }
        
        public Movement()
        {
            Positions = new List<Position>();
            DisplayCostFactor = 1;

            dateMinimum = DateTime.Now;
            minimumOpponentDistance = 450;
        }
        
        /// <summary>
        /// Execute le mouvement en enchainant l'action de début de mouvement, le pathfinding vers la position d'approche puis le mouvement lui même
        /// </summary>
        /// <returns>Retourne vrai si le mouvement a pu s'executer intégralement sans problème</returns>
        public bool Execute()
        {
            Robots.GrosRobot.Historique.Log("Début " + this.ToString());

            startTime = DateTime.Now;

            Position position = BestPosition;
            bool ok = true;

            if (position != null)
            {
                Trajectory traj = PathFinder.ChercheTrajectoire(Robot.Graph, Plateau.ListeObstacles, Plateau.ObstaclesOpponents,new Position(Robot.Position), position, Robot.Rayon, Robot.Largeur / 2);

                if (traj != null)
                {
                    MovementBegin();

                    if (Robot.ParcourirTrajectoire(traj))
                    {
                        MovementCore();
                        Robots.GrosRobot.Historique.Log("Fin " + this.ToString() + " en " + (DateTime.Now - startTime).TotalSeconds.ToString("#.#") + "s");
                        ok = true;
                    }
                    else
                    {
                        Robots.GrosRobot.Historique.Log("Annulation " + this.ToString() + ", trajectoire échouée");
                        ok = false;
                    }
                }
                else
                {
                    ok = false;
                }
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation " + this.ToString() + ", trajectoire non trouvée");
                ok = false;
            }

            Robots.GrosRobot.MajGraphFranchissable(Plateau.ListeObstacles);
            return ok;
        }
        
        /// <summary>
        /// Représente les actions à effectuer avant de se rendre à la position d'approche du mouvement
        /// </summary>
        protected abstract void MovementBegin();

        /// <summary>
        /// Représente les actions à effectuer une fois arrivé à la position d'approche du mouvement
        /// </summary>
        protected abstract void MovementCore();

        /// <summary>
        /// Représente les actions à effectuer à la fin du mouvement, qu'il soit réussi ou non
        /// </summary>
        protected abstract void MovementEnd();

        /// <summary>
        /// Retourne vrai si la couleur de l'action correspond à la couleur du robot qui peut la réaliser
        /// </summary>
        /// <returns></returns>
        public bool IsCorrectColor()
        {
            return (Color == null) || (Color == Plateau.NotreCouleur) || (Color == Color.White);
        }

        /// <summary>
        /// Obtient la meilleure position d'approche pour aborder le mouvement.
        /// Cette position est la plus proche de nous tout en étant à laa distance minimale réglementaire de tout adversaire
        /// </summary>
        public Position BestPosition
        {
            get
            {
                if (Positions.Count < 1)
                    return null;
                if (Positions.Count == 1)
                    return Positions[0];

                double distance = double.MaxValue;
                
                Position proche = Positions[0];

                foreach (Position position in Positions)
                {
                    double distancePosition = Robot.Position.Coordinates.Distance(position.Coordinates); 
                    
                    List<IShape> opponents = new List<IShape>(Plateau.ObstaclesOpponents);
                    foreach (Circle c in opponents)
                    {
                        double distanceAdv = position.Coordinates.Distance(c.Center);
                        if (distanceAdv < minimumOpponentDistance)
                            distancePosition = double.PositiveInfinity;
                        else
                            distancePosition -= distanceAdv;
                    }

                    if (distancePosition < distance)
                    {
                        distance = distancePosition;
                        proche = position;
                    }
                }

                return proche;
            }
        }

        /// <summary>
        /// Coût global de l'action prenant en compte la valeur de l'action mais également le temps de trajectoire pour s'y rendre ou la proximité des adversaires
        /// </summary>
        public double GlobalCost
        {
            get
            {
                if (!IsAvailable || !CanExecute)
                    return double.MaxValue;

                if (Value <= 0 && Positions.Count < 1)
                    return double.MaxValue;

                Position position = BestPosition;

                if (position == null) 
                    return double.MaxValue;

                double distance = Math.Max(50, Robot.Position.Coordinates.Distance(position.Coordinates)); // En dessous de 5cm de distance, tout se vaut
                double cout = (Math.Sqrt(distance)) / Value;
                bool adversairePlusProche = false;

                List<IShape> opponents = new List<IShape>(Plateau.ObstaclesOpponents);
                foreach (Circle c in opponents)
                {
                    double distanceAdv = position.Coordinates.Distance(c.Center);
                    if (distanceAdv < minimumOpponentDistance)
                        cout = double.PositiveInfinity;
                    else
                        cout /= ((distanceAdv / 10) * (distanceAdv / 10));

                    if (distanceAdv < distance)
                        adversairePlusProche = true;
                }

                if (adversairePlusProche)
                    cout *= 2;

                return cout;
            }
        }

        /// <summary>
        /// Peint le mouvement en indiquant les différentes positions d'approche, la meilleure, et l'élément concerné
        /// </summary>
        /// <param name="g">Graphique sur lequel peindre</param>
        /// <param name="scale">Echelle de conversion</param>
        public void Paint(Graphics g, WorldScale scale)
        {
            Font font = new Font("Calibri", 8);

            Pen penRedDot = new Pen(Color.Red);
            penRedDot.DashStyle = DashStyle.Dot;

            Pen penBlackDot = new Pen(Color.Black);
            penBlackDot.DashStyle = DashStyle.Dot;

            Pen penTransparent = new Pen(Color.FromArgb(40, Color.Black));

            Brush brushTransparent = new SolidBrush(Color.FromArgb(40, Color.Black));

            Point point;

            if (Element != null)
            {
                Point pointElement = scale.RealToScreenPosition(Element.Position);

                if (GlobalCost != double.MaxValue && !double.IsInfinity(GlobalCost))
                {
                    Point pointProche = scale.RealToScreenPosition(BestPosition.Coordinates);

                    foreach (Position p in Positions)
                    {
                        point = scale.RealToScreenPosition(p.Coordinates);
                        if (point != pointProche)
                        {
                            g.FillEllipse(Brushes.Red, point.X - 2, point.Y - 2, 4, 4);
                            g.DrawLine(penRedDot, point, pointElement);
                        }
                    }

                    g.FillEllipse(Brushes.White, pointProche.X - 2, pointProche.Y - 2, 4, 4);
                    g.DrawLine(Pens.White, pointProche, pointElement);
                    g.DrawString((GlobalCost / DisplayCostFactor).ToString("0.00"), font, Brushes.White, pointProche);
                }
                else
                {
                    if (!IsCorrectColor())
                    {
                        foreach (Position p in Positions)
                        {
                            point = scale.RealToScreenPosition(p.Coordinates);
                            g.FillEllipse(brushTransparent, point.X - 2, point.Y - 2, 4, 4);
                            g.DrawLine(penTransparent, point, pointElement);
                        }
                    }
                    else
                    {
                        foreach (Position p in Positions)
                        {
                            point = scale.RealToScreenPosition(p.Coordinates);
                            g.FillEllipse(Brushes.Black, point.X - 2, point.Y - 2, 4, 4);
                            g.DrawLine(penBlackDot, point, pointElement);
                        }
                    }
                }
            }

            brushTransparent.Dispose();
            penTransparent.Dispose();
            penBlackDot.Dispose();
            penRedDot.Dispose();
            font.Dispose();
        }

        /// <summary>
        /// Désactive le mouvement pendant une durée determinée.
        /// Le mouvement aura une valeur nulle jusqu'à sa réactivation.
        /// </summary>
        /// <param name="duration">Durée de désactivation du mouvement</param>
        public void Deactivate(TimeSpan duration)
        {
            dateMinimum = DateTime.Now + duration;
        }

        /// <summary>
        /// Réactive le mouvement avant la fin de l'attente de la durée de désactivation
        /// </summary>
        public void Reactivate()
        {
            dateMinimum = DateTime.Now;
        }

        /// <summary>
        /// Retourne vrai si l'action n'est pas désactivée
        /// </summary>
        public Boolean IsAvailable
        {
            get
            {
                // Si il faut attendre avant de faire cette action
                return DateTime.Now >= dateMinimum;
            }
        }
    }
}
