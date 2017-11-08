using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Geometry;
using GoBot.Geometry.Shapes;
using GoBot.ElementsJeu;
using System.Drawing;
using GoBot.PathFinding;
using System.Drawing.Drawing2D;

namespace GoBot.Mouvements
{
    public abstract class Mouvement
    {
        public bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début " + this.ToString());

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null)
            {
                ActionAvantDeplacement();

                Trajectory traj = PathFinder.ChercheTrajectoire(Robot.Graph, Plateau.ListeObstacles, new Position(Robot.Position), position, Robot.Rayon, Robot.Largeur / 2);

                if (traj != null && Robot.ParcourirTrajectoire(traj))
                {
                    ActionApresDeplacement();
                    Robots.GrosRobot.Historique.Log("Fin " + this.ToString() + " en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");

                    return true;
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Annulation " + this.ToString() + ", trajectoire échouée");
                    return false;
                }
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation " + this.ToString() + ", trajectoire non trouvée");
                return false;
            }
        }
        
        protected abstract void ActionAvantDeplacement();
        protected abstract void ActionApresDeplacement();


        public abstract double Score { get; }
        public abstract double ValeurAction { get; }
        public List<Position> Positions { get; protected set; }
        public abstract ElementJeu Element { get; }
        public abstract Robot Robot { get; }
        public DateTime DateMinimum { get; set; }
        public abstract Color Couleur { get; }

        public Mouvement()
        {
            Positions = new List<Position>();
        }
        public Mouvement(int i)
        {
            Positions = new List<Position>();
        }

        public bool BonneCouleur()
        {
            if (Couleur == null)
                return true;
            else
                return Couleur == Plateau.NotreCouleur;
        }


        public Position PositionProche
        {
            get
            {
                if (Positions.Count == 1)
                    return Positions[0];

                double distance = double.MaxValue;

                if (Positions.Count < 1)
                    return null;

                Position proche = Positions[0];

                foreach (Position position in Positions)
                {
                    double distancePosition = Robot.Position.Coordinates.Distance(position.Coordinates); 
                    
                    List<IShape> obstacles = new List<IShape>(Plateau.ObstaclesBalise);
                    foreach (Circle c in obstacles)
                    {
                        double distanceAdv = position.Coordinates.Distance(c.Center) / 10;
                        if (distanceAdv < 45)
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

        public double Cout
        {
            get
            {
                // Si il faut attendre avant de faire cette action
                if (DateMinimum != null && DateMinimum > DateTime.Now)
                    return double.MaxValue;

                if (ValeurAction <= 0 && Positions.Count < 1)
                    return double.MaxValue;

                Position position = PositionProche;

                if (position == null) 
                    return double.MaxValue;

                double distance = Robot.Position.Coordinates.Distance(position.Coordinates) / 10;
                double cout = distance / ValeurAction;
                bool adversairePlusProche = false;

                List<IShape> obstacles = new List<IShape>(Plateau.ObstaclesBalise);
                foreach (Circle c in obstacles)
                {
                    double distanceAdv = position.Coordinates.Distance(c.Center) / 10;
                    if (distanceAdv < 45)
                        cout = double.PositiveInfinity;
                    else
                        cout /= (distanceAdv * distanceAdv);

                    if (distanceAdv < distance)
                        adversairePlusProche = true;
                }

                if (adversairePlusProche)
                    cout *= 2;

                return cout * 10000;
            }
        }

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

                if (Cout != double.MaxValue && !double.IsInfinity(Cout))
                {
                    Point pointProche = scale.RealToScreenPosition(PositionProche.Coordinates);

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
                    g.DrawString(Math.Round(Cout) + "", font, Brushes.White, pointProche);
                }
                else
                {
                    if (!BonneCouleur())
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
    }
}
