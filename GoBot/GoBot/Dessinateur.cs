using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;
using Geometry.Shapes;
using AStarFolder;
using Geometry;
using GoBot.Beacons;
using GoBot.GameElements;
using GoBot.PathFinding;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using GoBot.Threading;
using GoBot.Devices;
using GoBot.BoardContext;

namespace GoBot
{
    static class Dessinateur
    {

        private static ThreadLink _linkDisplay;

        #region Conversion coordonnées réelles / écran

        /// <summary>
        /// Nombre de pixels par mm du terrain
        /// </summary>
        private const double RAPPORT_SCREEN_REAL = (3000.0 / 805);

        /// <summary>
        /// Position en pixel sur l'image de l'abscisse 0 de la table
        /// </summary>
        private const int OFFSET_IMAGE_X = 35;

        /// <summary>
        /// Position en pixel sur l'image de l'ordonnée 0 de la table
        /// </summary>
        private const int OFFSET_IMAGE_Y = 35;

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
        public static bool AfficheElementsJeu { get; set; } = true;

        public static MouseMode modeCourant;

        private static Pen penRougePointille = new Pen(Color.Red),
                            penNoirPointille = new Pen(Color.Black),
                            penBleuClairPointille = new Pen(Color.LightBlue),

                            penBlancTransparent = new Pen(Color.FromArgb(40, Color.Black)),
                            penBlancFleche = new Pen(Color.White, 3),
                            penCouleurGauche = new Pen(GameBoard.ColorLeftBlue),
                            penCouleurGaucheFleche = new Pen(GameBoard.ColorLeftBlue, 3),
                            penCouleurGaucheEpais = new Pen(Color.FromArgb(35, GameBoard.ColorLeftBlue), 3),
                            penCouleurDroite = new Pen(GameBoard.ColorRightYellow),
                            penCouleurDroiteFleche = new Pen(GameBoard.ColorRightYellow, 3),
                            penCouleurDroiteEpais = new Pen(Color.FromArgb(35, GameBoard.ColorRightYellow), 3),

                            penRougeEpais = new Pen(Color.Red, 3),
                            penBleuEpais = new Pen(GameBoard.ColorRightYellow, 3),
                            penVertEpais = new Pen(Color.Green, 3);

        private static SolidBrush brushNoir = new SolidBrush(Color.Black),
                                    brushNoirTresTransparent = new SolidBrush(Color.FromArgb(35, Color.Black)),
                                    brushCouleurGauche = new SolidBrush(GameBoard.ColorLeftBlue),
                                    brushCouleurGaucheTransparent = new SolidBrush(Color.FromArgb(110, GameBoard.ColorLeftBlue)),
                                    brushCouleurGaucheTresTransparent = new SolidBrush(Color.FromArgb(35, GameBoard.ColorLeftBlue)),
                                    brushCouleurDroite = new SolidBrush(GameBoard.ColorRightYellow),
                                    brushCouleurDroiteTransparent = new SolidBrush(Color.FromArgb(110, GameBoard.ColorRightYellow)),
                                    brushCouleurDroiteTresTransparent = new SolidBrush(Color.FromArgb(35, GameBoard.ColorRightYellow));

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

        public static void Init()
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
            _linkDisplay.Name = "Affichage de la table";
            _linkDisplay.StartThread();
        }

        public static void Stop()
        {
            _linkDisplay?.Cancel();
            _linkDisplay?.WaitEnd();
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
                            DessineElementsJeu(g, GameBoard.Elements);

                        DessinePathFinding(g);

                        DessinePositionEnnemis(g);

                        DessineDetections(g);
                        
                        Robots.GrosRobot.PositionCible?.Paint(g, Color.Red, 5, Color.Red, Scale);

                        if (AfficheCoutsMouvements)
                        {
                            if (GameBoard.Strategy != null && GameBoard.Strategy.Movements != null)
                            {
                                GameBoard.Strategy.Movements.ForEach(mouv => mouv.DisplayCostFactor = GameBoard.Strategy.Movements.Min(m => m.GlobalCost));
                                GameBoard.Strategy.Movements.ForEach(mouv => mouv.Paint(g, Scale));
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
                            gGros.DrawRectangle(GameBoard.MyColor == GameBoard.ColorLeftBlue ? penCouleurGauche : penCouleurDroite, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawLine(GameBoard.MyColor == GameBoard.ColorLeftBlue ? penCouleurGauche : penCouleurDroite, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2));

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
                            Position departRecule = new Position(-traj.angle, pointOrigine);
                            departRecule.Move(Scale.RealToScreenDistance(-Robots.GrosRobot.Longueur / 2));

                            gGros.FillRectangle(brushNoirTresTransparent, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawRectangle(GameBoard.MyColor == GameBoard.ColorLeftBlue ? penCouleurGauche : penCouleurDroite, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawLine(GameBoard.MyColor == GameBoard.ColorLeftBlue ? penCouleurGauche : penCouleurDroite, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2));

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
                                    g.DrawEllipse(Pens.White, p.X - 3, p.Y - 3, 6, 6);
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
                g.FillEllipse(GameBoard.MyColor == GameBoard.ColorRightYellow ? brushCouleurGaucheTransparent : brushCouleurDroiteTransparent, positionEcran.X - Scale.RealToScreenDistance(GameBoard.OpponentRadius), positionEcran.Y - Scale.RealToScreenDistance(GameBoard.OpponentRadius), Scale.RealToScreenDistance(GameBoard.OpponentRadius * 2), Scale.RealToScreenDistance(GameBoard.OpponentRadius * 2));
                g.DrawEllipse(GameBoard.MyColor == GameBoard.ColorRightYellow ? penCouleurGauche : penCouleurDroite, positionEcran.X - Scale.RealToScreenDistance(GameBoard.OpponentRadius), positionEcran.Y - Scale.RealToScreenDistance(GameBoard.OpponentRadius), Scale.RealToScreenDistance(GameBoard.OpponentRadius * 2), Scale.RealToScreenDistance(GameBoard.OpponentRadius * 2));
                g.DrawLine(GameBoard.MyColor == GameBoard.ColorRightYellow ? penCouleurGaucheEpais : penCouleurDroiteEpais, new Point(positionEcran.X - 7, positionEcran.Y - 7), new Point(positionEcran.X + 7, positionEcran.Y + 7));
                g.DrawLine(GameBoard.MyColor == GameBoard.ColorRightYellow ? penCouleurGaucheEpais : penCouleurDroiteEpais, new Point(positionEcran.X - 7, positionEcran.Y + 7), new Point(positionEcran.X + 7, positionEcran.Y - 7));
                g.DrawLine(GameBoard.MyColor == GameBoard.ColorRightYellow ? penCouleurGaucheFleche : penCouleurDroiteFleche, positionEcran.X, positionEcran.Y, positionEcran.X + Scale.RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].X / 3), positionEcran.Y + Scale.RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].Y / 3));
                g.DrawString(i + " - " + vitesse.ToString() + "mm/s", new Font("Calibri", 9, FontStyle.Bold), Brushes.White, positionEcran.X, positionEcran.Y);
            }
        }

        private static void DessineDetections(Graphics g)
        {
            List<IShape> detections = GameBoard.Detections;

            if (detections != null)
            {
                foreach (IShape d in detections)
                {
                    d?.Paint(g, Color.DodgerBlue, 1, Color.LightSkyBlue, Scale);
                }
            }
        }

        private static void DessineRobot(Robot robot, Graphics g)
        {
            Point positionRobot = Scale.RealToScreenPosition(robot.Position.Coordinates);

            g.TranslateTransform(positionRobot.X, positionRobot.Y);
            g.RotateTransform((float)(robot.Position.Angle.InDegrees));
            g.TranslateTransform(-positionRobot.X, -positionRobot.Y);

            Rectangle robotRect = new Rectangle(positionRobot.X - Scale.RealToScreenDistance(robot.Longueur / 2), positionRobot.Y - Scale.RealToScreenDistance(robot.Largeur / 2), Scale.RealToScreenDistance(robot.Longueur), Scale.RealToScreenDistance(robot.Largeur));

            g.FillRectangle(Brushes.White, robotRect);
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, GameBoard.MyColor)))
                g.FillRectangle(brush, robotRect);
            g.DrawRectangle(GameBoard.MyColor == GameBoard.ColorRightYellow ? penCouleurDroite : penCouleurGauche, robotRect);
            g.DrawLine(GameBoard.MyColor == GameBoard.ColorRightYellow ? penCouleurDroite : penCouleurGauche, robotRect.Center(), new Point(robotRect.Right, (int)robotRect.Center().Y));

            // TODOEACHYEAR Dessiner ici les actionneurs pour qu'ils prennent l'inclinaison du robot

            g.ResetTransform();
        }

        private static void DessineObstacles(Graphics g)
        {
            g.SetClip(Scale.RealToScreenRect(new RectangleF(-GameBoard.BorderSize, -GameBoard.BorderSize, GameBoard.Width + GameBoard.BorderSize * 2, GameBoard.Height + GameBoard.BorderSize * 2)));

            foreach (IShape forme in GameBoard.ObstaclesAll)
                forme.Paint(g, Color.Red, 5, Color.Transparent, Scale);

            DessineZoneMorte(g);

            g.ResetClip();
        }

        private static void DessineZoneMorte(Graphics g)
        {
            int farAway = 10000;

            if (AllDevices.LidarAvoid != null)
            {
                AnglePosition debutAngleMort = AllDevices.LidarAvoid.Position.Angle + 180 + new AngleDelta(AllDevices.LidarAvoid.DeadAngle / 2);
                AnglePosition finAngleMort = AllDevices.LidarAvoid.Position.Angle + 180 + new AngleDelta(-AllDevices.LidarAvoid.DeadAngle / 2);

                List<Point> points = new List<Point>();
                points.Add(Scale.RealToScreenPosition(AllDevices.LidarAvoid.Position.Coordinates));
                points.Add(Scale.RealToScreenPosition(new Point((int)(AllDevices.LidarAvoid.Position.Coordinates.X + debutAngleMort.Cos * farAway), (int)(AllDevices.LidarAvoid.Position.Coordinates.Y + debutAngleMort.Sin * farAway))));
                points.Add(Scale.RealToScreenPosition(new Point((int)(AllDevices.LidarAvoid.Position.Coordinates.X + finAngleMort.Cos * farAway), (int)(AllDevices.LidarAvoid.Position.Coordinates.Y + finAngleMort.Sin * farAway))));

                g.IntersectClip(new Rectangle(Scale.RealToScreenPosition(new Point(0, 0)), new Size(Scale.RealToScreenDistance(GameBoard.Width), Scale.RealToScreenDistance(GameBoard.Height))));

                g.DrawLine(Pens.Black, points[0], points[1]);
                g.DrawLine(Pens.Black, points[0], points[2]);
                Brush brush = new SolidBrush(Color.FromArgb(80, Color.Black));
                g.FillPolygon(brush, points.ToArray());
                brush.Dispose();

                g.ResetClip();
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
                            new Segment(a.StartNode.Position, a.EndNode.Position).Paint(g, Color.RoyalBlue, 1, Color.Transparent, Scale);
                    }

                if (graph)
                    //Dessin des noeuds
                    foreach (Node n in robot.Graph.Nodes)
                    {
                        n.Position.Paint(g, n.Passable ? Color.Black : Color.Red, 3, Color.RoyalBlue, Scale);
                    }
            }

            //robot.SemGraph.Release();
        }

        public static Track CurrentTrack;

        private static void DessinePathFinding(Graphics g)
        {
            if (GoBot.Config.CurrentConfig.AfficheDetailTraj > 0)
            {
                if (CurrentTrack != null)
                {
                    Track track = CurrentTrack;

                    Node n1, n2;
                    n1 = track.EndNode;

                    while (track.Queue != null)
                    {
                        track = track.Queue;
                        n2 = track.EndNode;

                        new Segment(n1.Position, n2.Position).Paint(g, Color.White, 4, Color.Yellow, Scale);

                        if (PathFinder.CheminEnCoursNoeuds != null && PathFinder.CheminEnCoursNoeuds.Contains(n2))
                            break;

                        // g.DrawLine(Pens.Red, Scale.RealToScreenPosition(n1.Position), Scale.RealToScreenPosition(n2.Position));
                        n1 = n2;
                    }
                }

                if (PathFinder.CheminTest != null)
                {
                    PathFinder.CheminTest.Paint(g, Color.White, 4, Color.DodgerBlue, Scale);
                }
                //List<RealPoint> points = null;
                //if (PathFinder.PointsTrouves != null)
                //    points = new List<RealPoint>(PathFinder.PointsTrouves);
                //if (points != null && points.Count > 1)
                //{
                //    for (int i = 1; i < points.Count; i++)
                //    {
                //        g.DrawLine(penVertEpais, Scale.RealToScreenPosition(points[i - 1]), Scale.RealToScreenPosition(points[i - 1]));
                //    }
                //}

                //Arc cheminTest = PathFinder.CheminTest;
                //if (cheminTest != null)
                //    g.DrawLine(penRougeEpais, Scale.RealToScreenPosition(new RealPoint(cheminTest.StartNode.Position.X, cheminTest.StartNode.Position.Y)), Scale.RealToScreenPosition(new RealPoint(cheminTest.EndNode.Position.X, cheminTest.EndNode.Position.Y)));

                //if (robot.ObstacleTeste != null)
                //    DessinerForme(g, Color.Green, 10, robot.ObstacleTeste);

                IShape obstacleProbleme = PathFinder.ObstacleProbleme;
                if (obstacleProbleme != null)
                    obstacleProbleme.Paint(g, Color.Red, 10, Color.Transparent, Scale);

                if (PathFinder.CheminEnCoursNoeudsSimplifyed != null && PathFinder.CheminEnCoursNoeudsSimplifyed.Count > 0)
                {
                    Node n1, n2;
                    n1 = PathFinder.CheminEnCoursNoeudsSimplifyed[0];
                    int i = 1;

                    while (i < PathFinder.CheminEnCoursNoeudsSimplifyed?.Count)
                    {
                        n2 = PathFinder.CheminEnCoursNoeudsSimplifyed[i];
                        new Segment(n1.Position, n2.Position).Paint(g, Color.White, 4, Color.Orange, Scale);
                        i++;
                        n1 = n2;
                    }
                }
                if (PathFinder.CheminEnCoursNoeuds != null && PathFinder.CheminEnCoursNoeuds.Count > 0)
                {
                    Node n1, n2;
                    n1 = PathFinder.CheminEnCoursNoeuds[0];
                    int i = 1;

                    while (i < PathFinder.CheminEnCoursNoeuds.Count)
                    {
                        n2 = PathFinder.CheminEnCoursNoeuds[i];
                        new Segment(n1.Position, n2.Position).Paint(g, Color.White, 4, Color.Green, Scale);
                        i++;
                        n1 = n2;
                    }
                }
            }
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
