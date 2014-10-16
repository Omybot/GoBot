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

namespace GoBot
{
    static class Dessinateur
    {
        #region Conversion coordonnées réelles / écran

        private const double RAPPORT_SCREEN_REAL = 3.3975;
        private const int OFFSET_IMAGE_X = 31;
        private const int OFFSET_IMAGE_Y = 31;

        // Ecran vers réel

        public static int ScreenToRealDistance(double valeur)
        {
            return (int)(valeur * RAPPORT_SCREEN_REAL);
        }

        public static PointReel ScreenToRealPosition(Point valeur)
        {
            return new PointReel(ScreenToRealDistance(valeur.X - OFFSET_IMAGE_X), ScreenToRealDistance(valeur.Y - OFFSET_IMAGE_Y));
        }

        public static Point ScreenToRealPosition(double valeurX, double valeurY)
        {
            return new Point(ScreenToRealDistance(valeurX - OFFSET_IMAGE_X), ScreenToRealDistance(valeurY - OFFSET_IMAGE_Y));
        }

        // Réel vers écran

        public static int RealToScreenDistance(double valeur)
        {
            return (int)(valeur / RAPPORT_SCREEN_REAL);
        }

        public static Point RealToScreenPosition(Point valeur)
        {
            return new Point(RealToScreenDistance(valeur.X) + OFFSET_IMAGE_X, RealToScreenDistance(valeur.Y) + OFFSET_IMAGE_Y);
        }

        public static Point RealToScreenPosition(double valeurX, double valeurY)
        {
            return new Point(RealToScreenDistance(valeurX) + OFFSET_IMAGE_X, RealToScreenDistance(valeurY) + OFFSET_IMAGE_Y);
        }

        #endregion
         
        //Déclaration du délégué pour l’évènement détection de positions
        public delegate void TableDessineeDelegate(Image img);
        //Déclaration de l’évènement utilisant le délégué
        public static event TableDessineeDelegate TableDessinee;

        private static PointReel positionCurseur; 
        public static PointReel PositionCurseur 
        { 
            get
            {
                return positionCurseur;
            }
            set
            {
                positionCurseur = value;
                PositionCurseurTable = ScreenToRealPosition(value);
            }
        }
        public static PointReel PositionCurseurTable { get; set; }
        public static PointReel positionDepart;
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

        public static List<Arc> cheminArcs;
        public static List<Node> cheminNodes;

        public static Mode modeCourant;

        private static Pen  penRougePointille = new Pen(Color.Red),
                            penBleuPointille = new Pen(Color.Blue),
                            penNoirPointille = new Pen(Color.Black),
                            penBleuClairPointille = new Pen(Color.LightBlue),

                            penBlanc = new Pen(Color.White),
                            penBlancFleche = new Pen(Color.White, 3),
                            penNoir = new Pen(Color.Black),
                            penRougeFin = new Pen(Color.Red),
                            penBleuFin = new Pen(Color.Blue),
                            penBleuClairFin = new Pen(Color.LightBlue),
                            penVertFonce = new Pen(Color.Green),
                            penBleuViolet = new Pen(Color.BlueViolet),
                            penCouleurJ1R = new Pen(Plateau.CouleurGaucheRouge),
                            penCouleurJ1RFleche = new Pen(Plateau.CouleurGaucheRouge, 3),
                            penCouleurJ1RTransparent = new Pen(Color.FromArgb(110, Plateau.CouleurGaucheRouge)),
                            penCouleurJ1RTresTransparent = new Pen(Color.FromArgb(35, Plateau.CouleurGaucheRouge)),
                            penCouleurJ1REpais = new Pen(Color.FromArgb(35, Plateau.CouleurGaucheRouge), 3),
                            penCouleurJ2J = new Pen(Plateau.CouleurDroiteJaune),
                            penCouleurJ2JFleche = new Pen(Plateau.CouleurDroiteJaune, 3),
                            penCouleurJ2JTransparent = new Pen(Color.FromArgb(110, Plateau.CouleurDroiteJaune)),
                            penCouleurJ2JTresTransparent = new Pen(Color.FromArgb(35, Plateau.CouleurDroiteJaune)),
                            penCouleurJ2JEpais = new Pen(Color.FromArgb(35, Plateau.CouleurDroiteJaune), 3),

                            penRougeEpais = new Pen(Color.Red, 3),
                            penBleuEpais = new Pen(Plateau.CouleurDroiteJaune, 3),
                            penVertClairEpais = new Pen(Color.LightGreen, 3),
                            penOrangeEpais = new Pen(Color.Orange, 3),
                            penVertEpais = new Pen(Color.Green, 3);
            
        private static SolidBrush   brushNoir = new SolidBrush(Color.Black),
                                    brushNoirTransparent = new SolidBrush(Color.FromArgb(110, Color.Black)),
                                    brushNoirTresTransparent = new SolidBrush(Color.FromArgb(35, Color.Black)),
                                    brushBlanc = new SolidBrush(Color.White),
                                    brushCouleurJ1R = new SolidBrush(Plateau.CouleurGaucheRouge),
                                    brushCouleurJ1RTransparent = new SolidBrush(Color.FromArgb(110, Plateau.CouleurGaucheRouge)),
                                    brushCouleurJ1RTresTransparent = new SolidBrush(Color.FromArgb(35, Plateau.CouleurGaucheRouge)),
                                    brushCouleurJ2J = new SolidBrush(Plateau.CouleurDroiteJaune),
                                    brushCouleurJ2JTransparent = new SolidBrush(Color.FromArgb(110, Plateau.CouleurDroiteJaune)),
                                    brushCouleurJ2JTresTransparent = new SolidBrush(Color.FromArgb(35, Plateau.CouleurDroiteJaune)),
                                    brushVertFonce = new SolidBrush(Color.DarkGreen),
                                    brushRouge = new SolidBrush(Color.Red),
                                    brushVert = new SolidBrush(Color.Green),
                                    brushTransparent = new SolidBrush(Color.Transparent),
                                    brushViolet = new SolidBrush(Color.Purple),
                                    brushBleuClair = new SolidBrush(Color.LightBlue),
                                    brushBleu = new SolidBrush(Color.Blue);
                    

        static Dessinateur()
        {
            penRougePointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            penBleuPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            penBleuClairPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            penNoirPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            penCouleurJ1RFleche.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            penCouleurJ1RFleche.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
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
        }

        private static Thread threadDessin;

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
            TeleportRSFace
        }

        private static DateTime prec = DateTime.Now;

        public static void Dessine()
        {
            PositionCurseur = new PointReel();
            while (Thread.CurrentThread.IsAlive && !Config.Shutdown)
            {
                // Limitation à 30FPS
                int sleep = 33 - (DateTime.Now - prec).Milliseconds - 1;
                if(sleep > 0)
                    Thread.Sleep(sleep);

                prec = DateTime.Now;
                try
                {
                    Bitmap bmp = new Bitmap(945, 650);
                    {
                        Graphics g = Graphics.FromImage(bmp);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        if (AfficheTable)
                            DessinePlateau(g);

                        if (AfficheObstacles)
                            DessineObstacles(g);

                        DessineGraph(Robots.PetitRobot, g);
                        DessineGraph(Robots.GrosRobot, g);

                        DessineTrajectoire(g);

                        if (AfficheElementsJeu)
                            DessineElementsJeu(g);

                        if (AfficheHistoriqueCoordonneesGros && Robots.GrosRobot.HistoriqueCoordonnees != null)
                            DessineHistoriqueTrajectoire(Robots.GrosRobot, g);
                        if (AfficheHistoriqueCoordonneesPetit && Robots.PetitRobot.HistoriqueCoordonnees != null)
                            DessineHistoriqueTrajectoire(Robots.PetitRobot, g);

                        if (Robots.GrosRobot != null)
                            DessineRobot(Robots.GrosRobot, g);

                        if (Robots.PetitRobot != null)
                            DessineRobot(Robots.PetitRobot, g);

                        DessinePathFinding(Robots.GrosRobot, g);
                        DessinePathFinding(Robots.PetitRobot, g);

                        DessinePositionEnnemis(g);

                        if(AfficheLigneDetections)
                            DessineLignesDetection(g);

                        if (Robots.GrosRobot.PositionCible != null)
                        {
                            Point p = RealToScreenPosition(Robots.GrosRobot.PositionCible);
                            g.DrawEllipse(penRougeEpais, p.X - 5, p.Y - 5, 10, 10);
                        }
                        if (Robots.PetitRobot.PositionCible != null)
                        {
                            Point p = RealToScreenPosition(Robots.PetitRobot.PositionCible);
                            g.DrawEllipse(penBleuEpais, p.X - 5, p.Y - 5, 10, 10);
                        }

                        // Dessin des coûts des mouvements

                        if (Plateau.Enchainement != null)
                        {
                            if (AfficheCoutsMouvementsGros)
                                DessineCoutMouvements(Robots.GrosRobot, g);
                            if (AfficheCoutsMouvementsPetit)
                                DessineCoutMouvements(Robots.PetitRobot, g);
                        }

                        if ((modeCourant == Mode.PositionRPCentre || modeCourant == Mode.TeleportRPCentre) && positionDepart != null)
                        {
                            Point positionFin = positionCurseur;

                            Bitmap bmpGrosRobot = new Bitmap(RealToScreenDistance(Robots.GrosRobot.Taille * 3), RealToScreenDistance(Robots.GrosRobot.Taille * 3));
                            Graphics gGros = Graphics.FromImage(bmpGrosRobot);
                            gGros.FillRectangle(brushTransparent, 0, 0, RealToScreenDistance(Robots.GrosRobot.Taille * 2), RealToScreenDistance(Robots.GrosRobot.Taille * 2));

                            Direction traj = Maths.GetDirection(positionDepart, PositionCurseurTable);

                            gGros.FillRectangle(brushNoirTresTransparent, bmpGrosRobot.Width / 2 - RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2), RealToScreenDistance(Robots.GrosRobot.Largeur), RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge ? penCouleurJ1R : penCouleurJ2J, bmpGrosRobot.Width / 2 - RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2), RealToScreenDistance(Robots.GrosRobot.Largeur), RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawLine(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge ? penCouleurJ1R : penCouleurJ2J, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2));

                            Point pointOrigine = RealToScreenPosition(positionDepart);
                            g.DrawImage(RotateImage(bmpGrosRobot, 360 - traj.angle.AngleDegres + 90), pointOrigine.X - bmpGrosRobot.Width / 2, pointOrigine.Y - bmpGrosRobot.Height / 2);

                            g.DrawLine(penBlancFleche, (Point)RealToScreenPosition(positionDepart), positionFin);
                        }

                        else if ((modeCourant == Mode.PositionRPFace || modeCourant == Mode.TeleportRPFace) && positionDepart != null)
                        {
                            Point positionFin = positionCurseur;

                            Bitmap bmpGrosRobot = new Bitmap(RealToScreenDistance(Robots.GrosRobot.Taille * 3), RealToScreenDistance(Robots.GrosRobot.Taille * 3));
                            Graphics gGros = Graphics.FromImage(bmpGrosRobot);
                            gGros.FillRectangle(brushTransparent, 0, 0, RealToScreenDistance(Robots.GrosRobot.Taille * 2), RealToScreenDistance(Robots.GrosRobot.Taille * 2));

                            Direction traj = Maths.GetDirection(positionDepart, PositionCurseurTable);

                            Point pointOrigine = RealToScreenPosition(positionDepart);
                            Position departRecule = new Position(360 - traj.angle, pointOrigine);
                            departRecule.Avancer(RealToScreenDistance(-Robots.GrosRobot.Longueur / 2));

                            gGros.FillRectangle(brushNoirTresTransparent, bmpGrosRobot.Width / 2 - RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2), RealToScreenDistance(Robots.GrosRobot.Largeur), RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge ? penCouleurJ1R : penCouleurJ2J, bmpGrosRobot.Width / 2 - RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2), RealToScreenDistance(Robots.GrosRobot.Largeur), RealToScreenDistance(Robots.GrosRobot.Longueur));
                            gGros.DrawLine(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge ? penCouleurJ1R : penCouleurJ2J, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2));

                            g.DrawImage(RotateImage(bmpGrosRobot, 360 - traj.angle.AngleDegres + 90), (int)(departRecule.Coordonnees.X) - bmpGrosRobot.Width / 2, (int)(departRecule.Coordonnees.Y) - bmpGrosRobot.Height / 2);

                            g.DrawLine(penBlancFleche, (Point)RealToScreenPosition(positionDepart), positionFin);
                        }

                        if ((modeCourant == Mode.PositionRSCentre || modeCourant == Mode.TeleportRSCentre) && positionDepart != null)
                        {
                            Point positionFin = positionCurseur;

                            Bitmap bmpPetitRobot = new Bitmap(RealToScreenDistance(Robots.PetitRobot.Taille * 3), RealToScreenDistance(Robots.PetitRobot.Taille * 3));
                            Graphics gPetit = Graphics.FromImage(bmpPetitRobot);
                            gPetit.FillRectangle(brushTransparent, 0, 0, RealToScreenDistance(Robots.PetitRobot.Taille * 2), RealToScreenDistance(Robots.PetitRobot.Taille * 2));

                            Direction traj = Maths.GetDirection(positionDepart, PositionCurseurTable);

                            gPetit.FillRectangle(brushNoirTresTransparent, bmpPetitRobot.Width / 2 - RealToScreenDistance(Robots.PetitRobot.Largeur / 2), bmpPetitRobot.Height / 2 - RealToScreenDistance(Robots.PetitRobot.Longueur / 2), RealToScreenDistance(Robots.PetitRobot.Largeur), RealToScreenDistance(Robots.PetitRobot.Longueur));
                            gPetit.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge ? penCouleurJ1R : penCouleurJ2J, bmpPetitRobot.Width / 2 - RealToScreenDistance(Robots.PetitRobot.Largeur / 2), bmpPetitRobot.Height / 2 - RealToScreenDistance(Robots.PetitRobot.Longueur / 2), RealToScreenDistance(Robots.PetitRobot.Largeur), RealToScreenDistance(Robots.PetitRobot.Longueur));
                            gPetit.DrawLine(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge ? penCouleurJ1R : penCouleurJ2J, bmpPetitRobot.Width / 2, bmpPetitRobot.Height / 2, bmpPetitRobot.Width / 2, bmpPetitRobot.Height / 2 - RealToScreenDistance(Robots.PetitRobot.Longueur / 2));

                            Point pointOrigine = RealToScreenPosition(positionDepart);
                            g.DrawImage(RotateImage(bmpPetitRobot, 360 - traj.angle.AngleDegres + 90), pointOrigine.X - bmpPetitRobot.Width / 2, pointOrigine.Y - bmpPetitRobot.Height / 2);

                            g.DrawLine(penBlancFleche, (Point)RealToScreenPosition(positionDepart), positionFin);
                        }

                        else if ((modeCourant == Mode.PositionRSFace || modeCourant == Mode.TeleportRSFace) && positionDepart != null)
                        {
                            Point positionFin = positionCurseur;

                            Bitmap bmpPetitRobot = new Bitmap(RealToScreenDistance(Robots.PetitRobot.Taille * 3), RealToScreenDistance(Robots.PetitRobot.Taille * 3));
                            Graphics gPetit = Graphics.FromImage(bmpPetitRobot);
                            gPetit.FillRectangle(brushTransparent, 0, 0, RealToScreenDistance(Robots.PetitRobot.Taille * 2), RealToScreenDistance(Robots.PetitRobot.Taille * 2));

                            Direction traj = Maths.GetDirection(positionDepart, PositionCurseurTable);

                            Point pointOrigine = RealToScreenPosition(positionDepart);
                            Position departRecule = new Position(360 - traj.angle, pointOrigine);
                            departRecule.Avancer(RealToScreenDistance(-Robots.PetitRobot.Longueur / 2));

                            gPetit.FillRectangle(brushNoirTresTransparent, bmpPetitRobot.Width / 2 - RealToScreenDistance(Robots.PetitRobot.Largeur / 2), bmpPetitRobot.Height / 2 - RealToScreenDistance(Robots.PetitRobot.Longueur / 2), RealToScreenDistance(Robots.PetitRobot.Largeur), RealToScreenDistance(Robots.PetitRobot.Longueur));
                            gPetit.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge ? penCouleurJ1R : penCouleurJ2J, bmpPetitRobot.Width / 2 - RealToScreenDistance(Robots.PetitRobot.Largeur / 2), bmpPetitRobot.Height / 2 - RealToScreenDistance(Robots.PetitRobot.Longueur / 2), RealToScreenDistance(Robots.PetitRobot.Largeur), RealToScreenDistance(Robots.PetitRobot.Longueur));
                            gPetit.DrawLine(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge ? penCouleurJ1R : penCouleurJ2J, bmpPetitRobot.Width / 2, bmpPetitRobot.Height / 2, bmpPetitRobot.Width / 2, bmpPetitRobot.Height / 2 - RealToScreenDistance(Robots.PetitRobot.Longueur / 2));

                            g.DrawImage(RotateImage(bmpPetitRobot, 360 - traj.angle.AngleDegres + 90), (int)(departRecule.Coordonnees.X) - bmpPetitRobot.Width / 2, (int)(departRecule.Coordonnees.Y) - bmpPetitRobot.Height / 2);

                            g.DrawLine(penBlancFleche, (Point)RealToScreenPosition(positionDepart), positionFin);
                        }

                        bmp.Save("table.jpg");
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
                Point positionEcran = RealToScreenPosition(p);

                if (p == null)
                    continue;

                double vitesse = Math.Round(Math.Sqrt(SuiviBalise.VecteursPositionsEnnemies[i].X * SuiviBalise.VecteursPositionsEnnemies[i].X + SuiviBalise.VecteursPositionsEnnemies[i].Y * SuiviBalise.VecteursPositionsEnnemies[i].Y));

                //if (vitesse < 50)
                //    g.DrawImage(Properties.Resources.Stop, positionEcran.X - Properties.Resources.Stop.Width / 2, positionEcran.Y - Properties.Resources.Stop.Height / 2, Properties.Resources.Stop.Width, Properties.Resources.Stop.Height);
                g.FillEllipse(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? brushCouleurJ1RTransparent : brushCouleurJ2JTransparent, positionEcran.X - RealToScreenDistance(Plateau.RayonAdversaire), positionEcran.Y - RealToScreenDistance(Plateau.RayonAdversaire), RealToScreenDistance(Plateau.RayonAdversaire * 2), RealToScreenDistance(Plateau.RayonAdversaire * 2));
                g.DrawEllipse(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ1R : penCouleurJ2J, positionEcran.X - RealToScreenDistance(Plateau.RayonAdversaire), positionEcran.Y - RealToScreenDistance(Plateau.RayonAdversaire), RealToScreenDistance(Plateau.RayonAdversaire * 2), RealToScreenDistance(Plateau.RayonAdversaire * 2));
                g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ1REpais : penCouleurJ2JEpais, new Point(positionEcran.X - 7, positionEcran.Y - 7), new Point(positionEcran.X + 7, positionEcran.Y + 7));
                g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ1REpais : penCouleurJ2JEpais, new Point(positionEcran.X - 7, positionEcran.Y + 7), new Point(positionEcran.X + 7, positionEcran.Y - 7));
                g.DrawLine(Plateau.NotreCouleur == Plateau.CouleurDroiteJaune ? penCouleurJ1RFleche : penCouleurJ2JFleche, positionEcran.X, positionEcran.Y, positionEcran.X + RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].X / 3), positionEcran.Y + RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].Y / 3));
                g.DrawString(i + " - " + vitesse + "mm/s", new Font("Calibri", 9, FontStyle.Bold), brushBlanc, positionEcran.X, positionEcran.Y);
            }
        }

        private static void DessineLignesDetection(Graphics g)
        {
            if (Plateau.InterpreteurBalise.DetectionBalises != null)
            {
                foreach (DetectionBalise detection in Plateau.InterpreteurBalise.DetectionBalises)
                {
                    // Ligne médiane
                    g.DrawLine(penRougePointille,
                        RealToScreenPosition(detection.Balise.Position.Coordonnees),
                        (RealToScreenPosition(detection.Position)));

                    // Dessin du polygone de détection
                    Polygone polygone = InterpreteurBalise.DetectionToPolygone(detection);
                    List<Point> points = new List<Point>();

                    foreach (Segment s in polygone.Cotes)
                    {
                        points.Add(RealToScreenPosition(s.Debut));
                        points.Add(RealToScreenPosition(s.Fin));
                    }

                    Point positionEcran = RealToScreenPosition(detection.Position);
                    g.DrawPolygon(penRougeFin, points.ToArray());
                    g.FillPolygon(brushCouleurJ1RTresTransparent, points.ToArray());
                    g.DrawLine(penRougeFin, new Point(positionEcran.X - 4, positionEcran.Y - 4), new Point(positionEcran.X + 4, positionEcran.Y + 4));
                    g.DrawLine(penRougeFin, new Point(positionEcran.X - 4, positionEcran.Y + 4), new Point(positionEcran.X + 4, positionEcran.Y - 4));
                }

                if (Plateau.InterpreteurBalise.Intersections != null)
                {
                    foreach (PointReelGenere p in Plateau.InterpreteurBalise.Intersections)
                    {
                        Point positionEcran = RealToScreenPosition(p.Point);
                        g.FillEllipse(brushVertFonce, positionEcran.X - 2, positionEcran.Y - 2, 4, 4);
                    }
                }

                if (Plateau.InterpreteurBalise.MoyennesIntersections != null)
                {
                    foreach (PointReelGenere p in Plateau.InterpreteurBalise.MoyennesIntersections)
                    {
                        Point positionEcran = RealToScreenPosition(p.Point);
                        g.FillEllipse(brushVertFonce, positionEcran.X - 4, positionEcran.Y - 4, 8, 8);
                    }
                }

                if (Plateau.InterpreteurBalise.AssociationPointDistanceIntersection != null)
                {
                    foreach (List<PointReel> liste in Plateau.InterpreteurBalise.AssociationPointDistanceIntersection)
                    {
                        if (liste[0] == null || liste[1] == null)
                            continue;
                        g.DrawLine(penVertFonce, RealToScreenPosition(liste[0].X, liste[0].Y), RealToScreenPosition(liste[1].X, liste[1].Y));
                    }
                }
            }
        }

        private static void DessineRobot(Robot robot, Graphics g)
        {
            Point positionRobot = RealToScreenPosition(robot.Position.Coordonnees);

            Bitmap bmpRobot = new Bitmap(RealToScreenDistance(robot.Taille * 3), RealToScreenDistance(robot.Taille * 3));
            Graphics gGros = Graphics.FromImage(bmpRobot);
            gGros.FillRectangle(brushTransparent, 0, 0, RealToScreenDistance(robot.Taille * 2), RealToScreenDistance(robot.Taille * 2));

            gGros.FillRectangle(brushBlanc, bmpRobot.Width / 2 - RealToScreenDistance(robot.Largeur / 2), bmpRobot.Height / 2 - RealToScreenDistance(robot.Longueur / 2), RealToScreenDistance(robot.Largeur), RealToScreenDistance(robot.Longueur));
            gGros.DrawRectangle(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge ? penCouleurJ1R : penCouleurJ2J, bmpRobot.Width / 2 - RealToScreenDistance(robot.Largeur / 2), bmpRobot.Height / 2 - RealToScreenDistance(robot.Longueur / 2), RealToScreenDistance(robot.Largeur), RealToScreenDistance(robot.Longueur));
            gGros.DrawLine(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge ? penCouleurJ1R : penCouleurJ2J, bmpRobot.Width / 2, bmpRobot.Height / 2, bmpRobot.Width / 2, bmpRobot.Height / 2 - RealToScreenDistance(robot.Longueur / 2));

            // Dessiner les actionneurs ici

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
        }

        private static void DessinePlateau(Graphics g)
        {
            g.DrawImage(Properties.Resources.TablePlan, 0, 0, 945, 650);
        }

        private static void DessineElementsJeu(Graphics g)
        {
            
        }

        private static void DessineTrajectoire(Graphics g)
        {
            // Dessin de la trajectoire en cours de recherche
            if (modeCourant == Mode.FinTrajectoire && cheminArcs != null)
            {
                foreach (Arc a in cheminArcs)
                {
                    g.DrawLine(penBleuViolet, RealToScreenPosition(a.StartNode.X, a.StartNode.Y), RealToScreenPosition(a.EndNode.X, a.EndNode.Position.Y));
                }
                foreach (Node n in cheminNodes)
                {
                    Point pointNode = RealToScreenPosition(n.X, n.Y);
                    g.DrawEllipse(penBleuViolet, new Rectangle(pointNode.X - 3, pointNode.Y - 3, 6, 6));
                }
            }
        }

        private static void DessineHistoriqueTrajectoire(Robot robot, Graphics g)
        {
            for (int i = 1; i < Robots.GrosRobot.HistoriqueCoordonnees.Count; i++)
            {
                int couleur = (int)(i * 1200 / robot.HistoriqueCoordonnees.Count * 255 / 1200);
                PointReel point = RealToScreenPosition(robot.HistoriqueCoordonnees[i].Coordonnees);
                PointReel pointPrec = RealToScreenPosition(robot.HistoriqueCoordonnees[i - 1].Coordonnees);
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
            List<Mouvements.Mouvement> mouvements = robot == Robots.GrosRobot ? Plateau.Enchainement.ListeMouvementsGros : Plateau.Enchainement.ListeMouvementsPetit;
            
            foreach (Mouvement m in mouvements)
            {
                Point point;

                if (m.Cout != double.MaxValue)
                {
                    foreach (Position p in m.Positions)
                    {
                        point = RealToScreenPosition(p.Coordonnees);
                        g.FillEllipse(brushRouge, point.X - 2, point.Y - 2, 4, 4);
                    }

                    point = RealToScreenPosition(m.PositionProche.Coordonnees);
                    g.FillEllipse(brushBlanc, point.X - 2, point.Y - 2, 4, 4);
                    g.DrawString(Math.Round(m.Cout) + "", police, brushBlanc, RealToScreenPosition(m.PositionProche.Coordonnees));
                }
                else
                {
                    foreach (Position p in m.Positions)
                    {
                        point = RealToScreenPosition(p.Coordonnees);
                        g.FillEllipse(brushNoir, point.X - 2, point.Y - 2, 4, 4);
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

            // Dessin des arcs
            if ((robot == Robots.GrosRobot ? AfficheGraphArretesGros : AfficheGraphArretesPetit))
                foreach (Arc a in robot.Graph.Arcs)
                {
                    if (a.Passable != false)
                    {
                        g.DrawLine(pen, RealToScreenPosition(a.StartNode.X, a.StartNode.Y), RealToScreenPosition(a.EndNode.X, a.EndNode.Y));
                    }
                }

            if ((robot == Robots.GrosRobot ? AfficheGraphGros : AfficheGraphPetit))
                // Dessin des noeuds
                foreach (Node n in robot.Graph.Nodes)
                {
                    Point pointNode = RealToScreenPosition(n.Position);
                    g.FillEllipse(brush, new Rectangle(pointNode.X - 3, pointNode.Y - 3, 6, 6));
                    g.DrawEllipse(n.Passable ? penNoir : penRougeFin, new Rectangle(pointNode.X - 3, pointNode.Y - 3, 6, 6));
                }

            //robot.SemGraph.Release();
        }

        private static void DessinePathFinding(Robot robot, Graphics g)
        {
            foreach (Node n in robot.NodeTrouve)
            {
                Point positionNode = RealToScreenPosition(n.Position);
                g.FillEllipse(brushRouge, new Rectangle(positionNode.X - 4, positionNode.Y - 4, 8, 8));
            }

            foreach (Arc a in robot.CheminTrouve)
            {
                g.DrawLine(penOrangeEpais, RealToScreenPosition(a.StartNode.Position), RealToScreenPosition(a.EndNode.Position));
            }

            if (robot.CheminEnCoursNoeuds != null && robot.CheminEnCoursNoeuds.Count > 1)
            {
                Segment seg = new Segment(new PointReel(robot.CheminEnCoursNoeuds[1].X, robot.CheminEnCoursNoeuds[1].Y), robot.Position.Coordonnees);
                g.DrawLine(penVertEpais, RealToScreenPosition(robot.CheminEnCoursNoeuds[1].Position), RealToScreenPosition(robot.Position.Coordonnees));
                for (int i = 1; i < robot.CheminEnCoursArcs.Count; i++)
                {
                    Arc a = robot.CheminEnCoursArcs[i];
                    g.DrawLine(penVertEpais, RealToScreenPosition(a.StartNode.Position), RealToScreenPosition(a.EndNode.Position));
                }
            }

            if (robot.CheminTest != null)
                g.DrawLine(penRougeEpais, RealToScreenPosition(robot.CheminTest.StartNode.Position), RealToScreenPosition(robot.CheminTest.EndNode.Position));

            //if (robot.ObstacleTeste != null)
            //    DessinerForme(g, Color.Green, 10, robot.ObstacleTeste);

            if (robot.ObstacleProbleme != null)
                DessinerForme(g, Color.Red, 10, robot.ObstacleProbleme);

            if (robot.CheminEnCoursNoeuds != null)
                foreach (Node n in robot.CheminEnCoursNoeuds)
                {
                    Point positionNode = RealToScreenPosition(n.Position);
                    g.FillEllipse(brushVert, new Rectangle(positionNode.X - 4, positionNode.Y - 4, 8, 8));
                }
        }

        private static Bitmap RotateImage(Bitmap b, double angle)
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

        #region Dessin des formes

        public static void DessinerForme(Graphics graphics, Color color, int epaisseur, IForme inconnue, bool plein = false)
        {
            Type typeForme = inconnue.GetType();

            if (typeForme.IsAssignableFrom(typeof(Segment)))
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
            Point positionEcran = RealToScreenPosition(Cercle.Centre);
            int rayonEcran = RealToScreenDistance(Cercle.Rayon);

            if (!plein)
                using (Pen pen = new Pen(color, epaisseur))
                    graphics.DrawEllipse(pen, new Rectangle(positionEcran.X - rayonEcran, positionEcran.Y - rayonEcran, rayonEcran * 2, rayonEcran * 2));
            else
                using (SolidBrush brush = new SolidBrush(color))
                    graphics.FillEllipse(brush, new Rectangle(positionEcran.X - rayonEcran, positionEcran.Y - rayonEcran, rayonEcran * 2, rayonEcran * 2));
        }

        private static void DessinerForme(Graphics graphics, Color color, int epaisseur, Segment segment)
        {
            Point positionEcranDepart = RealToScreenPosition(segment.Debut);
            Point positionEcranFin = RealToScreenPosition(segment.Fin);

            using (Pen pen = new Pen(color, epaisseur))
                graphics.DrawLine(pen, positionEcranDepart.X, positionEcranDepart.Y, positionEcranFin.X, positionEcranFin.Y);
        }

        private static void DessinerForme(Graphics graphics, Color color, int epaisseur, Polygone polygone, bool plein = false, bool realToScreen = true)
        {
            if (polygone.Cotes.Count == 0)
                return;

            Point[] listePoints = new Point[polygone.Cotes.Count + 1];

            listePoints[0] = realToScreen ? RealToScreenPosition(polygone.Cotes[0].Debut) : (Point)polygone.Cotes[0].Debut;

            for (int i = 0; i < polygone.Cotes.Count; i++)
            {
                Segment s = polygone.Cotes[i];
                listePoints[i] = realToScreen ? RealToScreenPosition(s.Fin) : (Point)s.Fin;
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
