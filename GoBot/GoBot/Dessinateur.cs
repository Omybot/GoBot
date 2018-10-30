using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using Geometry.Shapes;
using AStarFolder;
using GoBot.Strategies;
using Geometry;
using GoBot.Beacons;
using GoBot.Actionneurs;
using GoBot.GameElements;
using GoBot.Movements;
using GoBot.PathFinding;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using GoBot.Threading;

namespace GoBot
{
    static class Dessinateur
    {

        private static ThreadLink _linkDisplay;

        #region Conversion coordonnées réelles / écran
        
        /// <summary>
        /// Nombre de pixels par mm du terrain
        /// </summary>
        private const double RAPPORT_SCREEN_REAL = (3.488372093023256 + 3.496503496503497) / 2;

        /// <summary>
        /// Position en pixel sur l'image de l'abscisse 0 de la table
        /// </summary>
        private const int OFFSET_IMAGE_X = 8;

        /// <summary>
        /// Position en pixel sur l'image de l'ordonnée 0 de la table
        /// </summary>
        private const int OFFSET_IMAGE_Y = 8;

        #endregion

        //Déclaration du délégué pour l’évènement détection de positions
        public delegate void TableDessineeDelegate(Image img);
        //Déclaration de l’évènement utilisant le délégué
        public static event TableDessineeDelegate TableDessinee;
        
        private static RealPoint positionCurseur;
        public static RealPoint PositionCurseurTable { get; set; }
        public static RealPoint positionDepart;

        public static List<Point> trajectoirePolaireScreen;
        private static List<Point> pointsPolaireScreen;
        public static bool MouseClicked { get; set; }
        
        public static bool AfficheGraphArretes { get; set; } = false;
        public static bool AfficheGraph { get; set; } = false;
        public static bool AfficheObstacles { get; set; } = false;
        public static bool AfficheTable { get; set; } = true;
        public static bool AfficheTableRelief { get; set; } = false;
        public static bool AfficheHistoriqueCoordonnees { get; set; } = false;
        public static bool AfficheCoutsMouvements { get; set; } = false;
        public static bool AfficheLigneDetections { get; set; } = false;
        public static bool AfficheElementsJeu { get; set; } = true;

        public static MouseMode modeCourant;

        private static Pen penRougePointille = new Pen(Color.Red),
                            penNoirPointille = new Pen(Color.Black),
                            penBleuClairPointille = new Pen(Color.LightBlue),

                            penBlancTransparent = new Pen(Color.FromArgb(40, Color.Black)),
                            penBlancFleche = new Pen(Color.White, 3),
                            penCouleurGauche = new Pen(Plateau.CouleurGaucheJaune),
                            penCouleurGaucheFleche = new Pen(Plateau.CouleurGaucheJaune, 3),
                            penCouleurGaucheEpais = new Pen(Color.FromArgb(35, Plateau.CouleurGaucheJaune), 3),
                            penCouleurDroite = new Pen(Plateau.CouleurDroiteViolet),
                            penCouleurDroiteFleche = new Pen(Plateau.CouleurDroiteViolet, 3),
                            penCouleurDroiteEpais = new Pen(Color.FromArgb(35, Plateau.CouleurDroiteViolet), 3),

                            penRougeEpais = new Pen(Color.Red, 3),
                            penBleuEpais = new Pen(Plateau.CouleurDroiteViolet, 3),
                            penVertEpais = new Pen(Color.Green, 3);

        private static SolidBrush brushNoir = new SolidBrush(Color.Black),
                                    brushNoirTresTransparent = new SolidBrush(Color.FromArgb(35, Color.Black)),
                                    brushCouleurGauche = new SolidBrush(Plateau.CouleurGaucheJaune),
                                    brushCouleurGaucheTransparent = new SolidBrush(Color.FromArgb(110, Plateau.CouleurGaucheJaune)),
                                    brushCouleurGaucheTresTransparent = new SolidBrush(Color.FromArgb(35, Plateau.CouleurGaucheJaune)),
                                    brushCouleurDroite = new SolidBrush(Plateau.CouleurDroiteViolet),
                                    brushCouleurDroiteTransparent = new SolidBrush(Color.FromArgb(110, Plateau.CouleurDroiteViolet)),
                                    brushCouleurDroiteTresTransparent = new SolidBrush(Color.FromArgb(35, Plateau.CouleurDroiteViolet));

        public static WorldScale Scale { get; } = new WorldScale(RAPPORT_SCREEN_REAL, OFFSET_IMAGE_X, OFFSET_IMAGE_Y);

        public static RealPoint PositionCurseur
        {
            get
            {
                return positionCurseur;
            }
            set
            {
                positionCurseur = value;
                PositionCurseurTable = Scale.ScreenToRealPosition(value);
            }
        }
        public static List<RealPoint> TrajectoirePolaire
        {
            set
            {
                trajectoirePolaireScreen = new List<Point>();
                for (int i = 0; i < value.Count; i++)
                    trajectoirePolaireScreen.Add(Scale.RealToScreenPosition(value[i]));
            }
        }

        public static List<RealPoint> PointsPolaire
        {
            set
            {
                pointsPolaireScreen = new List<Point>();
                for (int i = 0; i < value.Count; i++)
                    pointsPolaireScreen.Add(Scale.RealToScreenPosition(value[i]));
            }
        }

        static Dessinateur()
        {
            penRougePointille.DashStyle = DashStyle.Dot;
            penBleuClairPointille.DashStyle = DashStyle.Dot;
            penNoirPointille.DashStyle = DashStyle.Dot;

            penCouleurGaucheFleche.StartCap = LineCap.Round;
            penCouleurGaucheFleche.EndCap = LineCap.ArrowAnchor;
            penBlancFleche.StartCap = LineCap.Round;
            penBlancFleche.EndCap = LineCap.ArrowAnchor;
        }

        public static void Start()
        {
            PositionCurseur = new RealPoint();

            _linkDisplay = ThreadManager.CreateThread(link => DisplayLoop());
            _linkDisplay.StartThread();
        }

        public static void Stop()
        {
            Console.WriteLine("Arrete stp");
            _linkDisplay?.Cancel();
            if (!(_linkDisplay?.WaitEnd()).Value)
                Console.WriteLine("Niop");
            _linkDisplay = null;
        }

        public enum MouseMode
        {
            None,
            PositionCentre,
            PositionFace,
            TeleportCentre,
            TeleportFace,
            TrajectoirePolaire
        }

        public static void DisplayLoop()
        {
            _linkDisplay.RegisterName();

            Stopwatch sw = Stopwatch.StartNew();
            
            while (!_linkDisplay.Cancelled)
            {
                _linkDisplay.LoopsCount++;

                // Limitation à 20FPS
                long sleep = 50 - sw.ElapsedMilliseconds - 1;
                if (sleep > 0)
                    Thread.Sleep((int)sleep);

                sw.Restart();

                try
                {
                    Bitmap bmp;

                    if (AfficheTable)
                        bmp = new Bitmap(Properties.Resources.TablePlan);
                    else
                        bmp = new Bitmap(Properties.Resources.TablePlan.Width, Properties.Resources.TablePlan.Height);
                    
                    {
                        Graphics g = Graphics.FromImage(bmp);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        
                        if (AfficheGraph || AfficheGraphArretes)
                            DessineGraph(Robots.GrosRobot, g, AfficheGraph, AfficheGraphArretes);

                        if (Robots.GrosRobot != null)
                            DessineRobot(Robots.GrosRobot, g);

                        if (AfficheHistoriqueCoordonnees && Robots.GrosRobot.HistoriqueCoordonnees != null)
                            DessineHistoriqueTrajectoire(Robots.GrosRobot, g);

                        if (AfficheObstacles)
                            DessineObstacles(g);

                        if (AfficheElementsJeu)
                        {
                            DessineElementsJeu(g, Plateau.Elements);
                        }

                        DessinePathFinding(g);

                        DessinePositionEnnemis(g);

                        if (AfficheLigneDetections)
                            DessineLignesDetection(g);

                        Robots.GrosRobot.PositionCible?.Paint(g, Color.Red, 5, Color.Red, Scale);

                        if (AfficheCoutsMouvements)
                        {
                            if (Plateau.Strategy != null && Plateau.Strategy.Movements != null)
                            {
                                Plateau.Strategy.Movements.ForEach(mouv => mouv.DisplayCostFactor = Plateau.Strategy.Movements.Min(m => m.GlobalCost));
                                Plateau.Strategy.Movements.ForEach(mouv => mouv.Paint(g, Scale));
                            }
                        }

                        if ((modeCourant == MouseMode.PositionCentre || modeCourant == MouseMode.TeleportCentre) && positionDepart != null)
                        {
                            Point positionFin = positionCurseur;

                            Bitmap bmpGrosRobot = new Bitmap(Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 3), Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 3));
                            Graphics gGros = Graphics.FromImage(bmpGrosRobot);
                            gGros.FillRectangle(Brushes.Transparent, 0, 0, Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 2), Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 2));

                            Direction traj = Maths.GetDirection(positionDepart, PositionCurseurTable);

                            gGros.FillRectangle(brushNoirTresTransparent, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurGaucheJaune ? penCouleurGauche : penCouleurDroite, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawLine(Plateau.NotreCouleur == Plateau.CouleurGaucheJaune ? penCouleurGauche : penCouleurDroite, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2));

                            Point pointOrigine = Scale.RealToScreenPosition(positionDepart);
                            g.DrawImage(RotateImage(bmpGrosRobot, 360 - traj.angle.InDegrees + 90), pointOrigine.X - bmpGrosRobot.Width / 2, pointOrigine.Y - bmpGrosRobot.Height / 2);

                            g.DrawLine(penBlancFleche, (Point)Scale.RealToScreenPosition(positionDepart), positionFin);
                        }

                        else if ((modeCourant == MouseMode.PositionFace || modeCourant == MouseMode.TeleportFace) && positionDepart != null)
                        {
                            Point positionFin = positionCurseur;

                            Bitmap bmpGrosRobot = new Bitmap(Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 3), Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 3));
                            Graphics gGros = Graphics.FromImage(bmpGrosRobot);
                            gGros.FillRectangle(Brushes.Transparent, 0, 0, Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 2), Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 2));

                            Direction traj = Maths.GetDirection(positionDepart, PositionCurseurTable);

                            Point pointOrigine = Scale.RealToScreenPosition(positionDepart);
                            Position departRecule = new Position(- traj.angle, pointOrigine);
                            departRecule.Move(Scale.RealToScreenDistance(-Robots.GrosRobot.Longueur / 2));

                            gGros.FillRectangle(brushNoirTresTransparent, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurGaucheJaune ? penCouleurGauche : penCouleurDroite, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawLine(Plateau.NotreCouleur == Plateau.CouleurGaucheJaune ? penCouleurGauche : penCouleurDroite, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2));

                            g.DrawImage(RotateImage(bmpGrosRobot, 360 - traj.angle.InDegrees + 90), (int)(departRecule.Coordinates.X) - bmpGrosRobot.Width / 2, (int)(departRecule.Coordinates.Y) - bmpGrosRobot.Height / 2);

                            g.DrawLine(penBlancFleche, (Point)Scale.RealToScreenPosition(positionDepart), positionFin);
                        }

                        if (Robots.GrosRobot.TrajectoireEnCours != null)
                        {
                            Trajectory traj = new Trajectory();
                            traj.AddPoint(Robots.GrosRobot.Position.Coordinates);

                            for (int iPoint = 1; iPoint < Robots.GrosRobot.TrajectoireEnCours.Points.Count; iPoint++)
                                traj.AddPoint(Robots.GrosRobot.TrajectoireEnCours.Points[iPoint]);

                            traj.Paint(g, Scale);
                        }

                        // Trajectoire polaire

                        //if (modeCourant == Mode.TrajectoirePolaire)
                        {
                            if (trajectoirePolaireScreen != null)
                                foreach (Point p in trajectoirePolaireScreen)
                                    g.FillEllipse(Brushes.Red, p.X - 1, p.Y - 1, 2, 2);
                            if (pointsPolaireScreen != null)
                                foreach (Point p in pointsPolaireScreen)
                                    g.DrawEllipse(Pens.Black, p.X - 3, p.Y - 3, 6, 6);
                        }
                        
                        TableDessinee?.Invoke(bmp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur pendant le dessin de la table " + ex.Message);
                }
            }
        }

        private static void DessineElementsJeu(Graphics g, IEnumerable<GameElement> elements)
        {
            foreach (GameElement element in elements)
                element.Paint(g, Scale);
        }

        private static void DessinePositionEnnemis(Graphics g)
        {
            for (int i = 0; i < SuiviBalise.PositionsEnnemies.Count; i++)
            {
                RealPoint p = SuiviBalise.PositionsEnnemies[i];
                Point positionEcran = Scale.RealToScreenPosition(p);

                if (p == null)
                    continue;

                int vitesse = (int)Math.Sqrt(SuiviBalise.VecteursPositionsEnnemies[i].X * SuiviBalise.VecteursPositionsEnnemies[i].X + SuiviBalise.VecteursPositionsEnnemies[i].Y * SuiviBalise.VecteursPositionsEnnemies[i].Y);

                //if (vitesse < 50)
                //    g.DrawImage(Properties.Resources.Stop, positionEcran.X - Properties.Resources.Stop.Width / 2, positionEcran.Y - Properties.Resources.Stop.Height / 2, Properties.Resources.Stop.Width, Properties.Resources.Stop.Height);
                g.FillEllipse(Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? brushCouleurGaucheTransparent : brushCouleurDroiteTransparent, positionEcran.X - Scale.RealToScreenDistance(Plateau.RayonAdversaire), positionEcran.Y - Scale.RealToScreenDistance(Plateau.RayonAdversaire), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2));
                g.DrawEllipse(Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? penCouleurGauche : penCouleurDroite, positionEcran.X - Scale.RealToScreenDistance(Plateau.RayonAdversaire), positionEcran.Y - Scale.RealToScreenDistance(Plateau.RayonAdversaire), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2));
                g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? penCouleurGaucheEpais : penCouleurDroiteEpais, new Point(positionEcran.X - 7, positionEcran.Y - 7), new Point(positionEcran.X + 7, positionEcran.Y + 7));
                g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? penCouleurGaucheEpais : penCouleurDroiteEpais, new Point(positionEcran.X - 7, positionEcran.Y + 7), new Point(positionEcran.X + 7, positionEcran.Y - 7));
                g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? penCouleurGaucheFleche : penCouleurDroiteFleche, positionEcran.X, positionEcran.Y, positionEcran.X + Scale.RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].X / 3), positionEcran.Y + Scale.RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].Y / 3));
                g.DrawString(i + " - " + vitesse.ToString() + "mm/s", new Font("Calibri", 9, FontStyle.Bold), Brushes.White, positionEcran.X, positionEcran.Y);
            }

            if (Plateau.Balise != null && Plateau.Balise.PositionsAdverses != null)
            {
                for (int i = 0; i < Plateau.Balise.PositionsAdverses.Count; i++)
                {
                    RealPoint p = Plateau.Balise.PositionsAdverses[i];
                    Point positionEcran = Scale.RealToScreenPosition(p);

                    if (p == null)
                        continue;

                    //if (vitesse < 50)
                    //    g.DrawImage(Properties.Resources.Stop, positionEcran.X - Properties.Resources.Stop.Width / 2, positionEcran.Y - Properties.Resources.Stop.Height / 2, Properties.Resources.Stop.Width, Properties.Resources.Stop.Height);
                    g.FillEllipse(Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? brushCouleurGaucheTransparent : brushCouleurDroiteTransparent, positionEcran.X - Scale.RealToScreenDistance(Plateau.RayonAdversaire), positionEcran.Y - Scale.RealToScreenDistance(Plateau.RayonAdversaire), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2));
                    g.DrawEllipse(Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? penCouleurGauche : penCouleurDroite, positionEcran.X - Scale.RealToScreenDistance(Plateau.RayonAdversaire), positionEcran.Y - Scale.RealToScreenDistance(Plateau.RayonAdversaire), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2));
                    //g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteVert ? penCouleurJ1REpais : penCouleurJ2JEpais, new Point(positionEcran.X - 7, positionEcran.Y - 7), new Point(positionEcran.X + 7, positionEcran.Y + 7));
                    //g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteVert ? penCouleurJ1REpais : penCouleurJ2JEpais, new Point(positionEcran.X - 7, positionEcran.Y + 7), new Point(positionEcran.X + 7, positionEcran.Y - 7));
                    //g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteVert ? penCouleurJ1RFleche : penCouleurJ2JFleche, positionEcran.X, positionEcran.Y, positionEcran.X + scale.RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].X / 3), positionEcran.Y + scale.RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].Y / 3));
                    //g.DrawString(i + " - " + vitesse + "mm/s", new Font("Calibri", 9, FontStyle.Bold), brushBlanc, positionEcran.X, positionEcran.Y);
                }
            }
        }

        private static void DessineLignesDetection(Graphics g)
        {
            if (Plateau.Balise.Detections != null)
            {
                List<BeaconDetection> detections = new List<BeaconDetection>(Plateau.Balise.Detections);

                foreach (BeaconDetection detection in detections)
                {
                    // Ligne médiane
                    g.DrawLine(penBleuClairPointille,
                        Scale.RealToScreenPosition(detection.Balise.Position.Coordinates),
                        (Scale.RealToScreenPosition(detection.Position)));

                    // Dessin du polygone de détection
                    detection.ToPolygone().Paint(g, Color.Red, 1, Color.FromArgb(35, Color.Red), Scale);

                    Point positionEcran = Scale.RealToScreenPosition(detection.Position);
                    
                    g.DrawLine(Pens.Red, new Point(positionEcran.X - 4, positionEcran.Y - 4), new Point(positionEcran.X + 4, positionEcran.Y + 4));
                    g.DrawLine(Pens.Red, new Point(positionEcran.X - 4, positionEcran.Y + 4), new Point(positionEcran.X + 4, positionEcran.Y - 4));
                }
            }

            /*if (Plateau.InterpreteurBalise.DetectionBalises != null)
            {

                foreach (DetectionBalise detection in Plateau.InterpreteurBalise.DetectionBalises)
                {
                    // Ligne médiane
                    g.DrawLine(penRougePointille,
                        scale.RealToScreenPosition(detection.Balise.Position.Coordonnees),
                        (scale.RealToScreenPosition(detection.Position)));

                    // Dessin du polygone de détection
                    Polygone polygone = InterpreteurBalise.DetectionToPolygone(detection);
                    List<Point> points = new List<Point>();

                    foreach (Segment s in polygone.Cotes)
                    {
                        points.Add(scale.RealToScreenPosition(s.Debut));
                        points.Add(scale.RealToScreenPosition(s.Fin));
                    }

                    Point positionEcran = scale.RealToScreenPosition(detection.Position);
                    g.DrawPolygon(penRougeFin, points.ToArray());
                    g.FillPolygon(brushCouleurGaucheJauneTresTransparent, points.ToArray());
                    g.DrawLine(penRougeFin, new Point(positionEcran.X - 4, positionEcran.Y - 4), new Point(positionEcran.X + 4, positionEcran.Y + 4));
                    g.DrawLine(penRougeFin, new Point(positionEcran.X - 4, positionEcran.Y + 4), new Point(positionEcran.X + 4, positionEcran.Y - 4));
                }

                if (Plateau.InterpreteurBalise.Intersections != null)
                {
                    foreach (PointReelGenere p in Plateau.InterpreteurBalise.Intersections)
                    {
                        Point positionEcran = scale.RealToScreenPosition(p.Point);
                        g.FillEllipse(brushVertFonce, positionEcran.X - 2, positionEcran.Y - 2, 4, 4);
                    }
                }

                if (Plateau.InterpreteurBalise.MoyennesIntersections != null)
                {
                    foreach (PointReelGenere p in Plateau.InterpreteurBalise.MoyennesIntersections)
                    {
                        Point positionEcran = scale.RealToScreenPosition(p.Point);
                        g.FillEllipse(brushVertFonce, positionEcran.X - 4, positionEcran.Y - 4, 8, 8);
                    }
                }

                if (Plateau.InterpreteurBalise.AssociationPointDistanceIntersection != null)
                {
                    foreach (List<PointReel> liste in Plateau.InterpreteurBalise.AssociationPointDistanceIntersection)
                    {
                        if (liste[0] == null || liste[1] == null)
                            continue;
                        g.DrawLine(penVertFonce, scale.RealToScreenPosition(liste[0].X, liste[0].Y), scale.RealToScreenPosition(liste[1].X, liste[1].Y));
                    }
                }
            }*/
        }

        private static void DessineRobot(Robot robot, Graphics g)
        {
            Point positionRobot = Scale.RealToScreenPosition(robot.Position.Coordinates);
            
            g.TranslateTransform(positionRobot.X, positionRobot.Y);
            g.RotateTransform((float)(robot.Position.Angle.InDegrees));
            g.TranslateTransform(-positionRobot.X, -positionRobot.Y);

            Rectangle robotRect = new Rectangle(positionRobot.X - Scale.RealToScreenDistance(robot.Longueur / 2), positionRobot.Y - Scale.RealToScreenDistance(robot.Largeur / 2), Scale.RealToScreenDistance(robot.Longueur), Scale.RealToScreenDistance(robot.Largeur));

            g.FillRectangle(Brushes.White, robotRect);
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, Plateau.NotreCouleur)))
                g.FillRectangle(brush, robotRect);
            g.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? penCouleurDroite : penCouleurGauche, robotRect);
            g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? penCouleurDroite : penCouleurGauche, robotRect.Center(), new Point(robotRect.Right, (int)robotRect.Center().Y));

            // TODOEACHYEAR Dessiner ici les actionneurs pour qu'ils prennent l'inclinaison du robot
            
            g.ResetTransform();
        }

        private static void DessineObstacles(Graphics g)
        {
            g.SetClip(Scale.RealToScreenRect(new RectangleF(-Plateau.BorderWidth, -Plateau.BorderWidth, Plateau.Largeur+ Plateau.BorderWidth*2, Plateau.Hauteur+ Plateau.BorderWidth*2)));

            foreach (IShape forme in Plateau.ListeObstacles)
                forme.Paint(g, Color.Red, 5, Color.Transparent, Scale);

            DessineZoneMorte(g);

            g.ResetClip();
        }

        private static void DessineZoneMorte(Graphics g)
        {
            if (Actionneur.Hokuyo != null)
            {
                AnglePosition milieuAngleMort = -180;
                AngleDelta largeurAngleMort = Actionneur.Hokuyo.DeadAngle;

                AnglePosition debutAngleMort = Actionneur.Hokuyo.Position.Angle + Actionneur.Hokuyo.ScanRange / 2;
                AnglePosition finAngleMort = Actionneur.Hokuyo.Position.Angle + Actionneur.Hokuyo.ScanRange / 2 + Actionneur.Hokuyo.DeadAngle;

                List<Point> points = new List<Point>();
                points.Add(Scale.RealToScreenPosition(Actionneur.Hokuyo.Position.Coordinates));
                points.Add(Scale.RealToScreenPosition(new Point((int)(Actionneur.Hokuyo.Position.Coordinates.X + debutAngleMort.Cos * 3000), (int)(Actionneur.Hokuyo.Position.Coordinates.Y + debutAngleMort.Sin * 3000))));
                points.Add(Scale.RealToScreenPosition(new Point((int)(Actionneur.Hokuyo.Position.Coordinates.X + finAngleMort.Sin * 3000), (int)(Actionneur.Hokuyo.Position.Coordinates.Y + finAngleMort.Sin * 3000))));

                Region regionTable = new Region(new Rectangle(Scale.RealToScreenPosition(new Point(0, 0)), new Size(Scale.RealToScreenDistance(Plateau.Largeur), Scale.RealToScreenDistance(Plateau.Hauteur))));
                GraphicsPath pathZoneMorte = new GraphicsPath();
                pathZoneMorte.AddPolygon(points.ToArray());
                Region regionZoneMorte = new Region(pathZoneMorte);
                regionZoneMorte.Intersect(regionTable);

                Brush brush = new SolidBrush(Color.FromArgb(50, Color.Black));
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillRegion(brush, regionZoneMorte);
                brush.Dispose();
                regionTable.Dispose();
                regionZoneMorte.Dispose();
            }
        }

        private static void DessinePlateau(Graphics g)
        {
            g.DrawImage(Properties.Resources.TablePlan, 0, 0, Properties.Resources.TablePlan.Width, Properties.Resources.TablePlan.Height);
        }

        private static void DessineHistoriqueTrajectoire(Robot robot, Graphics g)
        {
            lock (Robots.GrosRobot.HistoriqueCoordonnees)
            {
                for (int i = 1; i < Robots.GrosRobot.HistoriqueCoordonnees.Count; i++)
                {
                    int couleur = (int)(i * 1200 / robot.HistoriqueCoordonnees.Count * 255 / 1200);
                    Color pointColor = Color.FromArgb(couleur, couleur, couleur);

                    RealPoint point = robot.HistoriqueCoordonnees[i].Coordinates;
                    RealPoint pointPrec = robot.HistoriqueCoordonnees[i - 1].Coordinates;

                    new Segment(point, pointPrec).Paint(g, pointColor, 1, Color.Transparent, Scale);
                    point.Paint(g, Color.Black, 3, pointColor, Scale);
                }
            }
        }

        private static void DessineGraph(Robot robot, Graphics g, bool graph, bool arretes)
        {
            // Dessin du graph
            //robot.SemGraph.WaitOne();

            lock (robot.Graph)
            {

                // Dessin des arcs
                if (arretes)
                    foreach (Arc a in robot.Graph.Arcs)
                    {
                        if (a.Passable)
                            new Segment(a.StartNode.Position, a.EndNode.Position).Paint(g, Color.LimeGreen, 1, Color.Transparent, Scale);
                    }

                if (graph)
                    // Dessin des noeuds
                    foreach (Node n in robot.Graph.Nodes)
                        n.Position.Paint(g, n.Passable ? Color.Black : Color.Red, 3, Color.LimeGreen, Scale);
            }

            //robot.SemGraph.Release();
        }

        private static void DessinePathFinding(Graphics g)
        {
            /*foreach (Node n in robot.NodeTrouve)
            {
                Point positionNode = scale.RealToScreenPosition(n.Position);
                g.FillEllipse(brushRouge, new Rectangle(positionNode.X - 4, positionNode.Y - 4, 8, 8));
            }

            foreach (Arc a in robot.CheminTrouve)
            {
                g.DrawLine(penOrangeEpais, scale.RealToScreenPosition(a.StartNode.Position), scale.RealToScreenPosition(a.EndNode.Position));
            }*/

            List<RealPoint> points = null;
            if (PathFinder.PointsTrouves != null)
                points = new List<RealPoint>(PathFinder.PointsTrouves);
            if (points != null && points.Count > 1)
            {
                for (int i = 1; i < points.Count; i++)
                {
                    g.DrawLine(penVertEpais, Scale.RealToScreenPosition(points[i - 1]), Scale.RealToScreenPosition(points[i - 1]));
                }
            }

            Arc cheminTest = PathFinder.CheminTest;
            if (cheminTest != null)
                g.DrawLine(penRougeEpais, Scale.RealToScreenPosition(new RealPoint(cheminTest.StartNode.Position.X, cheminTest.StartNode.Position.Y)), Scale.RealToScreenPosition(new RealPoint(cheminTest.EndNode.Position.X, cheminTest.EndNode.Position.Y)));

            //if (robot.ObstacleTeste != null)
            //    DessinerForme(g, Color.Green, 10, robot.ObstacleTeste);

            IShape obstacleProbleme = PathFinder.ObstacleProbleme;
            if (obstacleProbleme != null)
                obstacleProbleme.Paint(g, Color.Red, 10, Color.Transparent, Scale);

            /*if (robot.CheminEnCoursNoeuds != null)
                foreach (Node n in robot.CheminEnCoursNoeuds)
                {
                    Point positionNode = scale.RealToScreenPosition(n.Position);
                    g.FillEllipse(brushVert, new Rectangle(positionNode.X - 4, positionNode.Y - 4, 8, 8));
                }*/
        }

        private static Bitmap RotateImage(Bitmap b, AnglePosition angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);

            try
            {
                //make a graphics object from the empty bitmap
                Graphics g = Graphics.FromImage(returnBitmap);
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform((float)angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, 0, 0, b.Width, b.Height);
            }
            catch (Exception)
            {
                returnBitmap.Dispose();
                return null;
            }

            return returnBitmap;
        }
    }
}
