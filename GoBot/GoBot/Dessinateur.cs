using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using GoBot.Calculs.Formes;
using AStarFolder;
using GoBot.Enchainements;
using GoBot.Calculs;
using GoBot.Balises;
using GoBot.Actionneurs;
using GoBot.ElementsJeu;
using GoBot.Mouvements;
using GoBot.PathFinding;
using System.Drawing.Drawing2D;

namespace GoBot
{
    static class Dessinateur
    {
        //Déclaration du délégué pour l’évènement détection de positions
        public delegate void TableDessineeDelegate(Image img);
        //Déclaration de l’évènement utilisant le délégué
        public static event TableDessineeDelegate TableDessinee;

        private static Thread threadDessin;

        private static PointReel positionCurseur;
        public static PointReel PositionCurseurTable { get; set; }
        public static PointReel positionDepart;

        public static List<Point> trajectoirePolaireScreen;
        private static List<Point> pointsPolaireScreen;
        public static bool sourisClic;

        public static bool AfficheGraphPetit;
        public static bool AfficheGraphArretesGros;
        public static bool AfficheGraphArretesPetit;
        public static bool AfficheGraphGros;
        public static bool AfficheObstacles;
        public static bool AfficheTable;
        public static bool AfficheTableRelief;
        public static bool AfficheHistoriqueCoordonneesGros;
        public static bool AfficheHistoriqueCoordonneesPetit;
        public static bool AfficheCoutsMouvementsGros;
        public static bool AfficheCoutsMouvementsPetit;
        public static bool AfficheLigneDetections;
        public static bool AfficheElementsJeu;

        public static List<Trajectoire> Trajectoires;

        public static Mode modeCourant;

        private static Pen penRougePointille = new Pen(Color.Red),
                            penNoirPointille = new Pen(Color.Black),
                            penBleuClairPointille = new Pen(Color.LightBlue),

                            penBlanc = new Pen(Color.White),
                            penBlancTransparent = new Pen(Color.FromArgb(40, Color.Black)),
                            penBlancFleche = new Pen(Color.White, 3),
                            penNoir = new Pen(Color.Black),
                            penRougeFin = new Pen(Color.Red),
                            penBleuFin = new Pen(Color.Blue),
                            penBleuClairFin = new Pen(Color.LightBlue),
                            penCouleurJ1 = new Pen(Plateau.CouleurGaucheBleu),
                            penCouleurJ1Fleche = new Pen(Plateau.CouleurGaucheBleu, 3),
                            penCouleurJ1Epais = new Pen(Color.FromArgb(35, Plateau.CouleurGaucheBleu), 3),
                            penCouleurJ2 = new Pen(Plateau.CouleurDroiteJaune),
                            penCouleurJ2Fleche = new Pen(Plateau.CouleurDroiteJaune, 3),
                            penCouleurJ2Epais = new Pen(Color.FromArgb(35, Plateau.CouleurDroiteJaune), 3),

                            penRougeEpais = new Pen(Color.Red, 3),
                            penBleuEpais = new Pen(Plateau.CouleurDroiteJaune, 3),
                            penVertEpais = new Pen(Color.Green, 3);

        private static SolidBrush brushNoir = new SolidBrush(Color.Black),
                                    brushBlancTransparent = new SolidBrush(Color.FromArgb(40, Color.Black)),
                                    brushNoirTransparent = new SolidBrush(Color.FromArgb(110, Color.Black)),
                                    brushNoirTresTransparent = new SolidBrush(Color.FromArgb(35, Color.Black)),
                                    brushBlanc = new SolidBrush(Color.White),
                                    brushCouleurGaucheJaune = new SolidBrush(Plateau.CouleurGaucheBleu),
                                    brushCouleurGaucheJauneTransparent = new SolidBrush(Color.FromArgb(110, Plateau.CouleurGaucheBleu)),
                                    brushCouleurGaucheJauneTresTransparent = new SolidBrush(Color.FromArgb(35, Plateau.CouleurGaucheBleu)),
                                    brushCouleurDroiteVert = new SolidBrush(Plateau.CouleurDroiteJaune),
                                    brushCouleurDroiteVertTransparent = new SolidBrush(Color.FromArgb(110, Plateau.CouleurDroiteJaune)),
                                    brushCouleurDroiteVertTresTransparent = new SolidBrush(Color.FromArgb(35, Plateau.CouleurDroiteJaune)),
                                    brushVertFonce = new SolidBrush(Color.DarkGreen),
                                    brushRouge = new SolidBrush(Color.Red),
                                    brushVert = new SolidBrush(Color.Green),
                                    brushTransparent = new SolidBrush(Color.Transparent),
                                    brushViolet = new SolidBrush(Color.Purple),
                                    brushBleuClair = new SolidBrush(Color.LightBlue),
                                    brushBleu = new SolidBrush(Color.Blue);

        private static Font fontNbPieds = new Font("Calibri", 9);

        public static PaintScale Scale { get; } = new PaintScale();

        public static PointReel PositionCurseur
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
        public static List<PointReel> TrajectoirePolaire
        {
            set
            {
                trajectoirePolaireScreen = new List<Point>();
                for (int i = 0; i < value.Count; i++)
                    trajectoirePolaireScreen.Add(Scale.RealToScreenPosition(value[i]));
            }
        }

        public static List<PointReel> PointsPolaire
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
            penRougePointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            penBleuClairPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            penNoirPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            penCouleurJ1Fleche.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            penCouleurJ1Fleche.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            penBlancFleche.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            penBlancFleche.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            AfficheGraphPetit = false;
            AfficheGraphArretesGros = false;
            AfficheGraphArretesPetit = false;
            AfficheGraphGros = false;
            AfficheObstacles = false;
            AfficheTable = true;
            AfficheTableRelief = false;
            AfficheHistoriqueCoordonneesGros = false;
            AfficheHistoriqueCoordonneesPetit = false;
            AfficheCoutsMouvementsGros = false;
            AfficheCoutsMouvementsPetit = false;
            AfficheLigneDetections = false;
            AfficheElementsJeu = true;
            Trajectoires = new List<Trajectoire>();
        }

        public static void Start()
        {
            threadDessin = new Thread(Dessine);
            threadDessin.Start();
        }

        public static void Stop()
        {
            threadDessin.Abort();
        }

        public enum Mode
        {
            Visualisation,
            Graph,
            Trajectoires,
            Intersection,
            AjoutPolygone,
            DebutTrajectoire,
            FinTrajectoire,
            PositionRPCentre,
            PositionRPFace,
            PositionRSCentre,
            PositionRSFace,
            TeleportRPCentre,
            TeleportRPFace,
            TeleportRSCentre,
            TeleportRSFace,
            TrajectoirePolaire
        }

        public static void Dessine()
        {
            DateTime prec = DateTime.Now;

            PositionCurseur = new PointReel();
            while (Thread.CurrentThread.IsAlive && !Config.Shutdown)
            {
                // Limitation à 30FPS
                int sleep = 33 - (DateTime.Now - prec).Milliseconds - 1;
                if (sleep > 0)
                    Thread.Sleep(sleep);

                prec = DateTime.Now;
                try
                {
                    Bitmap bmp = new Bitmap(Properties.Resources.TablePlan.Width, Properties.Resources.TablePlan.Height);
                    {
                        Graphics g = Graphics.FromImage(bmp);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        if (AfficheTable)
                            DessinePlateau(g);

                        DessineGraph(Robots.GrosRobot, g);

                        //DessineTrajectoire(g);

                        if (Robots.GrosRobot != null)
                            DessineRobot(Robots.GrosRobot, g);

                        if (AfficheHistoriqueCoordonneesGros && Robots.GrosRobot.HistoriqueCoordonnees != null)
                            DessineHistoriqueTrajectoire(Robots.GrosRobot, g);


                        if (AfficheObstacles)
                            DessineObstacles(g);

                        //if (Robots.PetitRobot != null)
                        //    DessineRobot(Robots.PetitRobot, g);

                        if (AfficheElementsJeu)
                            DessineElementsJeu(g);

                        DessinePathFinding(g);

                        DessinePositionEnnemis(g);

                        if (AfficheLigneDetections)
                            DessineLignesDetection(g);

                        if (Robots.GrosRobot.PositionCible != null)
                        {
                            Point p = Scale.RealToScreenPosition(Robots.GrosRobot.PositionCible);
                            g.DrawEllipse(penRougeEpais, p.X - 5, p.Y - 5, 10, 10);
                        }

                        // Dessin des coûts des mouvements

                        if (Plateau.Enchainement != null)
                        {
                            if (AfficheCoutsMouvementsGros)
                                DessineCoutMouvements(Robots.GrosRobot, g);
                        }

                        if ((modeCourant == Mode.PositionRPCentre || modeCourant == Mode.TeleportRPCentre) && positionDepart != null)
                        {
                            Point positionFin = positionCurseur;

                            Bitmap bmpGrosRobot = new Bitmap(Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 3), Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 3));
                            Graphics gGros = Graphics.FromImage(bmpGrosRobot);
                            gGros.FillRectangle(brushTransparent, 0, 0, Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 2), Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 2));

                            Direction traj = Maths.GetDirection(positionDepart, PositionCurseurTable);

                            gGros.FillRectangle(brushNoirTresTransparent, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurGaucheBleu ? penCouleurJ1 : penCouleurJ2, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawLine(Plateau.NotreCouleur == Plateau.CouleurGaucheBleu ? penCouleurJ1 : penCouleurJ2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2));

                            Point pointOrigine = Scale.RealToScreenPosition(positionDepart);
                            g.DrawImage(RotateImage(bmpGrosRobot, 360 - traj.angle.AngleDegres + 90), pointOrigine.X - bmpGrosRobot.Width / 2, pointOrigine.Y - bmpGrosRobot.Height / 2);

                            g.DrawLine(penBlancFleche, (Point)Scale.RealToScreenPosition(positionDepart), positionFin);
                        }

                        else if ((modeCourant == Mode.PositionRPFace || modeCourant == Mode.TeleportRPFace) && positionDepart != null)
                        {
                            Point positionFin = positionCurseur;

                            Bitmap bmpGrosRobot = new Bitmap(Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 3), Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 3));
                            Graphics gGros = Graphics.FromImage(bmpGrosRobot);
                            gGros.FillRectangle(brushTransparent, 0, 0, Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 2), Scale.RealToScreenDistance(Robots.GrosRobot.Taille * 2));

                            Direction traj = Maths.GetDirection(positionDepart, PositionCurseurTable);

                            Point pointOrigine = Scale.RealToScreenPosition(positionDepart);
                            Position departRecule = new Position(360 - traj.angle, pointOrigine);
                            departRecule.Avancer(Scale.RealToScreenDistance(-Robots.GrosRobot.Longueur / 2));

                            gGros.FillRectangle(brushNoirTresTransparent, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurGaucheBleu ? penCouleurJ1 : penCouleurJ2, bmpGrosRobot.Width / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2), Scale.RealToScreenDistance(Robots.GrosRobot.Largeur), Scale.RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawLine(Plateau.NotreCouleur == Plateau.CouleurGaucheBleu ? penCouleurJ1 : penCouleurJ2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2 - Scale.RealToScreenDistance(Robots.GrosRobot.Longueur / 2));

                            g.DrawImage(RotateImage(bmpGrosRobot, 360 - traj.angle.AngleDegres + 90), (int)(departRecule.Coordonnees.X) - bmpGrosRobot.Width / 2, (int)(departRecule.Coordonnees.Y) - bmpGrosRobot.Height / 2);

                            g.DrawLine(penBlancFleche, (Point)Scale.RealToScreenPosition(positionDepart), positionFin);
                        }

                        // Trajectoires

                        foreach (Trajectoire traj in Trajectoires)
                        {
                            DessineTrajectoire(traj, g);
                        }

                        if (Robots.GrosRobot.TrajectoireEnCours != null)
                        {
                            Trajectoire traj = new Trajectoire();
                            traj.AjouterPoint(Robots.GrosRobot.Position.Coordonnees);

                            for (int iPoint = 1; iPoint < Robots.GrosRobot.TrajectoireEnCours.PointsPassage.Count; iPoint++)
                                traj.AjouterPoint(Robots.GrosRobot.TrajectoireEnCours.PointsPassage[iPoint]);

                            DessineTrajectoire(traj, g);
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

                        TableDessinee(bmp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur pendant le dessin de la table " + ex.Message);
                }
            }
        }

        private static void DessinePositionEnnemis(Graphics g)
        {
            for (int i = 0; i < SuiviBalise.PositionsEnnemies.Count; i++)
            {
                PointReel p = SuiviBalise.PositionsEnnemies[i];
                Point positionEcran = Scale.RealToScreenPosition(p);

                if (p == null)
                    continue;

                double vitesse = Math.Round(Math.Sqrt(SuiviBalise.VecteursPositionsEnnemies[i].X * SuiviBalise.VecteursPositionsEnnemies[i].X + SuiviBalise.VecteursPositionsEnnemies[i].Y * SuiviBalise.VecteursPositionsEnnemies[i].Y));

                //if (vitesse < 50)
                //    g.DrawImage(Properties.Resources.Stop, positionEcran.X - Properties.Resources.Stop.Width / 2, positionEcran.Y - Properties.Resources.Stop.Height / 2, Properties.Resources.Stop.Width, Properties.Resources.Stop.Height);
                g.FillEllipse(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? brushCouleurGaucheJauneTransparent : brushCouleurDroiteVertTransparent, positionEcran.X - Scale.RealToScreenDistance(Plateau.RayonAdversaire), positionEcran.Y - Scale.RealToScreenDistance(Plateau.RayonAdversaire), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2));
                g.DrawEllipse(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ1 : penCouleurJ2, positionEcran.X - Scale.RealToScreenDistance(Plateau.RayonAdversaire), positionEcran.Y - Scale.RealToScreenDistance(Plateau.RayonAdversaire), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2));
                g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ1Epais : penCouleurJ2Epais, new Point(positionEcran.X - 7, positionEcran.Y - 7), new Point(positionEcran.X + 7, positionEcran.Y + 7));
                g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ1Epais : penCouleurJ2Epais, new Point(positionEcran.X - 7, positionEcran.Y + 7), new Point(positionEcran.X + 7, positionEcran.Y - 7));
                g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ1Fleche : penCouleurJ2Fleche, positionEcran.X, positionEcran.Y, positionEcran.X + Scale.RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].X / 3), positionEcran.Y + Scale.RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].Y / 3));
                g.DrawString(i + " - " + vitesse + "mm/s", new Font("Calibri", 9, FontStyle.Bold), brushBlanc, positionEcran.X, positionEcran.Y);
            }

            if (Plateau.Balise != null && Plateau.Balise.PositionsAdverses != null)
            {
                for (int i = 0; i < Plateau.Balise.PositionsAdverses.Count; i++)
                {
                    PointReel p = Plateau.Balise.PositionsAdverses[i];
                    Point positionEcran = Scale.RealToScreenPosition(p);

                    if (p == null)
                        continue;

                    //if (vitesse < 50)
                    //    g.DrawImage(Properties.Resources.Stop, positionEcran.X - Properties.Resources.Stop.Width / 2, positionEcran.Y - Properties.Resources.Stop.Height / 2, Properties.Resources.Stop.Width, Properties.Resources.Stop.Height);
                    g.FillEllipse(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? brushCouleurGaucheJauneTransparent : brushCouleurDroiteVertTransparent, positionEcran.X - Scale.RealToScreenDistance(Plateau.RayonAdversaire), positionEcran.Y - Scale.RealToScreenDistance(Plateau.RayonAdversaire), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2));
                    g.DrawEllipse(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ1 : penCouleurJ2, positionEcran.X - Scale.RealToScreenDistance(Plateau.RayonAdversaire), positionEcran.Y - Scale.RealToScreenDistance(Plateau.RayonAdversaire), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2), Scale.RealToScreenDistance(Plateau.RayonAdversaire * 2));
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
                List<DetectionBalise> detections = new List<DetectionBalise>(Plateau.Balise.Detections);

                foreach (DetectionBalise detection in detections)
                {
                    // Ligne médiane
                    g.DrawLine(penBleuClairPointille,
                        Scale.RealToScreenPosition(detection.Balise.Position.Coordonnees),
                        (Scale.RealToScreenPosition(detection.Position)));

                    // Dessin du polygone de détection
                    Polygone polygone = detection.ToPolygone();
                    List<Point> points = new List<Point>();

                    foreach (Segment s in polygone.Cotes)
                    {
                        points.Add(Scale.RealToScreenPosition(s.Debut));
                        points.Add(Scale.RealToScreenPosition(s.Fin));
                    }

                    Point positionEcran = Scale.RealToScreenPosition(detection.Position);
                    g.DrawPolygon(penBleuFin, points.ToArray());
                    g.FillPolygon(brushCouleurGaucheJauneTresTransparent, points.ToArray());
                    g.DrawLine(penRougeFin, new Point(positionEcran.X - 4, positionEcran.Y - 4), new Point(positionEcran.X + 4, positionEcran.Y + 4));
                    g.DrawLine(penRougeFin, new Point(positionEcran.X - 4, positionEcran.Y + 4), new Point(positionEcran.X + 4, positionEcran.Y - 4));
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
            Point positionRobot = Scale.RealToScreenPosition(robot.Position.Coordonnees);

            Bitmap bmpRobot = new Bitmap(Properties.Resources.Capot.Width, Properties.Resources.Capot.Height);
            Graphics gGros = Graphics.FromImage(bmpRobot);
            gGros.FillRectangle(brushTransparent, 0, 0, Scale.RealToScreenDistance(robot.Taille * 2), Scale.RealToScreenDistance(robot.Taille * 2));

            gGros.FillRectangle(brushBlanc, bmpRobot.Width / 2 - Scale.RealToScreenDistance(robot.Largeur / 2), bmpRobot.Height / 2 - Scale.RealToScreenDistance(robot.Longueur / 2), Scale.RealToScreenDistance(robot.Largeur), Scale.RealToScreenDistance(robot.Longueur));
            gGros.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ2 : penCouleurJ1, bmpRobot.Width / 2 - Scale.RealToScreenDistance(robot.Largeur / 2), bmpRobot.Height / 2 - Scale.RealToScreenDistance(robot.Longueur / 2), Scale.RealToScreenDistance(robot.Largeur), Scale.RealToScreenDistance(robot.Longueur));
            gGros.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ2 : penCouleurJ1, bmpRobot.Width / 2, bmpRobot.Height / 2, bmpRobot.Width / 2, bmpRobot.Height / 2 - Scale.RealToScreenDistance(robot.Longueur / 2));

            //gGros.DrawImage(Properties.Resources.Capot, 0, 0, Properties.Resources.Capot.Width, Properties.Resources.Capot.Height);

            // Dessiner les actionneurs ici
            if (robot == Robots.GrosRobot)
            {
                Brush b = new SolidBrush(Plateau.NotreCouleur);
                for (int i = 0; i < Actionneur.Stockeur.ModulesCount; i++)
                {
                    Rectangle rect = new Rectangle(bmpRobot.Width / 2 - Scale.RealToScreenDistance(robot.Largeur / 2) + 5 + i * 10, bmpRobot.Height / 2 - Scale.RealToScreenDistance(robot.Longueur / 2) + 5, 5, 18);
                    gGros.FillRectangle(b, rect);
                    gGros.DrawRectangle(Pens.Black, rect);
                }
                b.Dispose();
            }

            g.DrawImage(RotateImage(bmpRobot, robot.Position.Angle.AngleDegres + 90), positionRobot.X - bmpRobot.Width / 2, positionRobot.Y - bmpRobot.Height / 2);
        }

        private static void DessineObstacles(Graphics g)
        {
            // Dessin des obstacles
            //g.FillRectangle(brushBlanc, 0, 0, 3000, 2000);

            foreach (IForme forme in Plateau.ListeObstacles)
                DessinerForme(g, Color.Red, 5, forme);

            // Efface ce qui sort de la zone
            DessinerForme(g, Color.White, 0, new RectanglePolygone(new PointReel(-1000, -1000), 990, Plateau.LongueurPlateau + 2000), true);
            DessinerForme(g, Color.White, 0, new RectanglePolygone(new PointReel(Plateau.LongueurPlateau, -1000), 1000, Plateau.LongueurPlateau + 2000), true);
            DessinerForme(g, Color.White, 0, new RectanglePolygone(new PointReel(-1000, -1000), Plateau.LargeurPlateau + 2000, 990), true);
            DessinerForme(g, Color.White, 0, new RectanglePolygone(new PointReel(-1000, Plateau.LargeurPlateau), Plateau.LongueurPlateau + 2000, 990), true);

            DessineZoneMorte(g);
        }

        private static void DessineZoneMorte(Graphics g)
        {
            if (Actionneur.Hokuyo != null)
            {
                Angle milieuAngleMort = new Angle(-180);
                Angle largeurAngleMort = Actionneur.Hokuyo.AngleMort;

                Angle debutAngleMort = new Angle(Actionneur.Hokuyo.Position.Angle + milieuAngleMort - largeurAngleMort / 2);
                Angle finAngleMort = new Angle(Robots.GrosRobot.Position.Angle + milieuAngleMort + largeurAngleMort / 2);

                List<Point> points = new List<Point>();
                points.Add(Scale.RealToScreenPosition(Actionneur.Hokuyo.Position.Coordonnees));
                points.Add(Scale.RealToScreenPosition(new Point((int)(Actionneur.Hokuyo.Position.Coordonnees.X + Math.Cos(debutAngleMort.AngleRadians) * 3000), (int)(Actionneur.Hokuyo.Position.Coordonnees.Y + Math.Sin(debutAngleMort.AngleRadians) * 3000))));
                points.Add(Scale.RealToScreenPosition(new Point((int)(Actionneur.Hokuyo.Position.Coordonnees.X + Math.Cos(finAngleMort.AngleRadians) * 3000), (int)(Actionneur.Hokuyo.Position.Coordonnees.Y + Math.Sin(finAngleMort.AngleRadians) * 3000))));

                Region regionTable = new Region(new Rectangle(Scale.RealToScreenPosition(new Point(0, 0)), new Size(Scale.RealToScreenDistance(Plateau.LongueurPlateau), Scale.RealToScreenDistance(Plateau.LargeurPlateau))));
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

        private static void DessineElementsJeu(Graphics g)
        {
            // Todo dessinner les éléments de jeu

            foreach (Fusee fusee in Plateau.Elements.Fusees)
                DessineFusee(g, fusee);
            foreach (Module module in Plateau.Elements.Modules)
                DessineModule(g, module);

        }

        private static void DessineModule(Graphics g, Module module)
        {
            if (!module.Ramasse)
            {
                Point center = Scale.RealToScreenPosition(module.Position);
                Size size = new Size(Scale.RealToScreenDistance(module.RayonHover) * 2, Scale.RealToScreenDistance(module.RayonHover) * 2);
                Rectangle rect = new Rectangle(center.X - size.Width / 2, center.Y - size.Height / 2, size.Width, size.Height);
                Brush b;

                if (module.Couleur == Color.White)
                {
                    g.FillEllipse(Brushes.White, rect);
                    b = new SolidBrush(Plateau.CouleurGaucheBleu);
                    g.FillPie(b, rect, -135, 90);
                    b.Dispose();
                    b = new SolidBrush(Plateau.CouleurDroiteJaune);
                    g.FillPie(b, rect, +45, 90);
                    b.Dispose();
                }
                else
                {
                    b = new SolidBrush(module.Couleur);
                    g.FillEllipse(b, rect);
                    b.Dispose();
                }

                if(module.Hover)
                    g.DrawEllipse(Pens.White, rect);
                else
                    g.DrawEllipse(Pens.Black, rect);
            }
        }

        private static void DessineFusee(Graphics g, Fusee fusee)
        {
            if (fusee.ModulesRestants > 0)
            {
                Point center = Scale.RealToScreenPosition(fusee.Position);
                Size size = new Size(Scale.RealToScreenDistance(fusee.RayonHover) * 2, Scale.RealToScreenDistance(fusee.RayonHover) * 2);
                Rectangle rect = new Rectangle(center.X - size.Width / 2, center.Y - size.Height / 2, size.Width, size.Height);
                Brush b;

                if (fusee.Couleur == Color.White)
                {
                    g.FillEllipse(Brushes.White, rect);
                    b = new SolidBrush(Plateau.CouleurGaucheBleu);
                    g.FillPie(b, rect, -135, 90);
                    b.Dispose();
                    b = new SolidBrush(Plateau.CouleurDroiteJaune);
                    g.FillPie(b, rect, +45, 90);
                    b.Dispose();
                }
                else
                {
                    b = new SolidBrush(fusee.Couleur);
                    g.FillEllipse(b, rect);
                    b.Dispose();
                }

                if (fusee.Hover)
                    g.DrawEllipse(Pens.White, rect);
                else
                    g.DrawEllipse(Pens.Black, rect);
            }
        }

        private static void DessineTrajectoire(Trajectoire traj, Graphics g)
        {
            Point pointNodePrec = traj.PointsPassage[0];

            using (Pen penR = new Pen(Color.Red, 2), penB = new Pen(Color.White, 4))
            {
                for (int i = 0; i < traj.PointsPassage.Count; i++)
                {
                    Point pointNode = Scale.RealToScreenPosition(traj.PointsPassage[i]);
                    if (i >= 1)
                    {
                        g.DrawLine(penB, pointNode, pointNodePrec);
                        g.DrawLine(penR, pointNode, pointNodePrec);
                    }
                    pointNodePrec = pointNode;
                }
                for (int i = 0; i < traj.PointsPassage.Count; i++)
                {
                    Point pointNode = Scale.RealToScreenPosition(traj.PointsPassage[i]);
                    g.FillEllipse(brushRouge, new Rectangle(pointNode.X - 4, pointNode.Y - 4, 8, 8));
                    g.DrawEllipse(penBlanc, new Rectangle(pointNode.X - 4, pointNode.Y - 4, 8, 8));
                }
            }
        }

        private static void DessineHistoriqueTrajectoire(Robot robot, Graphics g)
        {
            for (int i = 1; i < Robots.GrosRobot.HistoriqueCoordonnees.Count; i++)
            {
                int couleur = (int)(i * 1200 / robot.HistoriqueCoordonnees.Count * 255 / 1200);
                PointReel point = Scale.RealToScreenPosition(robot.HistoriqueCoordonnees[i].Coordonnees);
                PointReel pointPrec = Scale.RealToScreenPosition(robot.HistoriqueCoordonnees[i - 1].Coordonnees);
                using (Pen p = new Pen(Color.FromArgb(couleur, couleur, couleur)))
                {
                    g.DrawLine(p, (int)point.X, (int)point.Y, (int)pointPrec.X, (int)pointPrec.Y);
                }
                using (Brush b = new SolidBrush(Color.FromArgb(couleur, couleur, couleur)))
                {
                    g.FillEllipse(b, (int)point.X - 3, (int)point.Y - 3, 6, 6);
                    g.DrawEllipse(penNoir, (int)point.X - 3, (int)point.Y - 3, 6, 6);
                }
            }
        }

        private static void DessineCoutMouvements(Robot robot, Graphics g)
        {
            Font police = new Font("Calibri", 8);
            List<Mouvements.Mouvement> mouvements = Plateau.Enchainement.ListeMouvements;

            foreach (Mouvement m in mouvements)
            {
                Point point;

                if (m.Element != null)
                {
                    Point pointElement = Scale.RealToScreenPosition(m.Element.Position);

                    if (m.Cout != double.MaxValue && !double.IsInfinity(m.Cout))
                    {
                        Point pointProche = Scale.RealToScreenPosition(m.PositionProche.Coordonnees);

                        foreach (Position p in m.Positions)
                        {
                            point = Scale.RealToScreenPosition(p.Coordonnees);
                            if (point != pointProche)
                            {
                                g.FillEllipse(brushRouge, point.X - 2, point.Y - 2, 4, 4);
                                g.DrawLine(penRougePointille, point, pointElement);
                            }
                        }

                        g.FillEllipse(brushBlanc, pointProche.X - 2, pointProche.Y - 2, 4, 4);
                        g.DrawLine(penBlanc, pointProche, pointElement);
                        g.DrawString(Math.Round(m.Cout) + "", police, brushBlanc, pointProche);
                    }
                    else
                    {
                        if (!m.BonneCouleur())
                        {
                            foreach (Position p in m.Positions)
                            {
                                point = Scale.RealToScreenPosition(p.Coordonnees);
                                g.FillEllipse(brushBlancTransparent, point.X - 2, point.Y - 2, 4, 4);
                                g.DrawLine(penBlancTransparent, point, pointElement);
                            }
                        }
                        else
                        {
                            foreach (Position p in m.Positions)
                            {
                                point = Scale.RealToScreenPosition(p.Coordonnees);
                                g.FillEllipse(brushNoir, point.X - 2, point.Y - 2, 4, 4);
                                g.DrawLine(penNoirPointille, point, pointElement);
                            }
                        }
                    }
                }
            }
        }

        private static void DessineGraph(Robot robot, Graphics g)
        {
            // Dessin du graph
            //robot.SemGraph.WaitOne();
            Pen pen = robot == Robots.GrosRobot ? penBleuFin : penBleuClairFin;
            Brush brush = robot == Robots.GrosRobot ? brushBleu : brushBleuClair;

            Synchronizer.Lock(robot.Graph);

            // Dessin des arcs
            if ((robot == Robots.GrosRobot ? AfficheGraphArretesGros : AfficheGraphArretesPetit))
                foreach (Arc a in robot.Graph.Arcs)
                {
                    if (a.Passable != false)
                    {
                        g.DrawLine(pen, Scale.RealToScreenPosition(new PointReel(a.StartNode.X, a.StartNode.Y)), Scale.RealToScreenPosition(new PointReel(a.EndNode.X, a.EndNode.Y)));
                    }
                }

            if ((robot == Robots.GrosRobot ? AfficheGraphGros : AfficheGraphPetit))
                // Dessin des noeuds
                foreach (Node n in robot.Graph.Nodes)
                {
                    Point pointNode = Scale.RealToScreenPosition(new PointReel(n.Position.X, n.Position.Y));
                    g.FillEllipse(brush, new Rectangle(pointNode.X - 3, pointNode.Y - 3, 6, 6));
                    g.DrawEllipse(n.Passable ? penNoir : penRougeFin, new Rectangle(pointNode.X - 3, pointNode.Y - 3, 6, 6));
                }

            Synchronizer.Unlock(robot.Graph);

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

            List<PointReel> points = null;
            if (PathFinder.PointsTrouves != null)
                points = new List<PointReel>(PathFinder.PointsTrouves);
            if (points != null && points.Count > 1)
            {
                for (int i = 1; i < points.Count; i++)
                {
                    g.DrawLine(penVertEpais, Scale.RealToScreenPosition(points[i - 1]), Scale.RealToScreenPosition(points[i - 1]));
                }
            }

            Arc cheminTest = PathFinder.CheminTest;
            if (cheminTest != null)
                g.DrawLine(penRougeEpais, Scale.RealToScreenPosition(new PointReel(cheminTest.StartNode.Position.X, cheminTest.StartNode.Position.Y)), Scale.RealToScreenPosition(new PointReel(cheminTest.EndNode.Position.X, cheminTest.EndNode.Position.Y)));

            //if (robot.ObstacleTeste != null)
            //    DessinerForme(g, Color.Green, 10, robot.ObstacleTeste);

            IForme obstacleProbleme = PathFinder.ObstacleProbleme;
            if (obstacleProbleme != null)
                DessinerForme(g, Color.Red, 10, obstacleProbleme);

            /*if (robot.CheminEnCoursNoeuds != null)
                foreach (Node n in robot.CheminEnCoursNoeuds)
                {
                    Point positionNode = scale.RealToScreenPosition(n.Position);
                    g.FillEllipse(brushVert, new Rectangle(positionNode.X - 4, positionNode.Y - 4, 8, 8));
                }*/
        }

        private static Bitmap RotateImage(Bitmap b, Angle angle)
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
                g.RotateTransform((float)angle.AngleDegres);
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

        #region Dessin des formes

        public static void DessinerForme(Graphics graphics, Color color, int epaisseur, IForme inconnue, bool plein = false)
        {
            Type typeForme = inconnue.GetType();

            if (typeForme.IsAssignableFrom(typeof(Droite)))
                DessinerForme(graphics, color, epaisseur, (Droite)inconnue);
            else if (typeForme.IsAssignableFrom(typeof(Segment)))
                DessinerForme(graphics, color, epaisseur, (Segment)inconnue);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                DessinerForme(graphics, color, epaisseur, (Cercle)inconnue, plein);
            else if (typeForme.IsAssignableFrom(typeof(Polygone)) || typeForme.IsSubclassOf(typeof(Polygone)))
                DessinerForme(graphics, color, epaisseur, (Polygone)inconnue);
            else
                throw new NotImplementedException("Je ne sais pas dessiner cette forme : " + inconnue.GetType().ToString());
        }

        private static void DessinerForme(Graphics graphics, Color color, int epaisseur, Cercle Cercle, bool plein = false)
        {
            Point positionEcran = Scale.RealToScreenPosition(Cercle.Centre);
            int rayonEcran = Scale.RealToScreenDistance(Cercle.Rayon);

            if (!plein)
                using (Pen pen = new Pen(color, epaisseur))
                    graphics.DrawEllipse(pen, new Rectangle(positionEcran.X - rayonEcran, positionEcran.Y - rayonEcran, rayonEcran * 2, rayonEcran * 2));
            else
                using (SolidBrush brush = new SolidBrush(color))
                    graphics.FillEllipse(brush, new Rectangle(positionEcran.X - rayonEcran, positionEcran.Y - rayonEcran, rayonEcran * 2, rayonEcran * 2));
        }

        private static void DessinerForme(Graphics graphics, Color color, int epaisseur, Segment segment)
        {
            Point positionEcranDepart = Scale.RealToScreenPosition(segment.Debut);
            Point positionEcranFin = Scale.RealToScreenPosition(segment.Fin);

            using (Pen pen = new Pen(color, epaisseur))
                graphics.DrawLine(pen, positionEcranDepart.X, positionEcranDepart.Y, positionEcranFin.X, positionEcranFin.Y);
        }

        private static void DessinerForme(Graphics graphics, Color color, int epaisseur, Droite droite)
        {
            // Un peu douteux mais bon
            PointReel p1 = droite.getCroisement(new Droite(new PointReel(-10000, -10000), new PointReel(-10001, 10000)));
            PointReel p2 = droite.getCroisement(new Droite(new PointReel(10000, -10000), new PointReel(10001, 10000)));

            if (p1 == null || p2 == null)
            {
                p1 = droite.getCroisement(new Droite(new PointReel(-10000, -10000), new PointReel(10000, -10001)));
                p2 = droite.getCroisement(new Droite(new PointReel(10000, 10000), new PointReel(-10000, 10001)));
            }

            if (p1 != null && p2 != null)
                DessinerForme(graphics, color, epaisseur, new Segment(p1, p2));
        }

        private static void DessinerForme(Graphics graphics, Color color, int epaisseur, Polygone polygone, bool plein = false, bool realToScreen = true)
        {
            if (polygone.Cotes.Count == 0)
                return;

            Point[] listePoints = new Point[polygone.Cotes.Count + 1];

            listePoints[0] = realToScreen ? Scale.RealToScreenPosition(polygone.Cotes[0].Debut) : (Point)polygone.Cotes[0].Debut;

            for (int i = 0; i < polygone.Cotes.Count; i++)
            {
                Segment s = polygone.Cotes[i];
                listePoints[i] = realToScreen ? Scale.RealToScreenPosition(s.Fin) : (Point)s.Fin;
            }

            listePoints[listePoints.Length - 1] = listePoints[0];

            if (!plein)
                using (Pen pen = new Pen(color, epaisseur))
                    graphics.DrawPolygon(pen, listePoints);
            else
                using (SolidBrush brush = new SolidBrush(color))
                    graphics.FillPolygon(brush, listePoints, System.Drawing.Drawing2D.FillMode.Winding);
        }

        #endregion
    }
}
