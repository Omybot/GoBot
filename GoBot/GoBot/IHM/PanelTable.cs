using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Calculs.Formes;
using GoBot.Calculs;
using AStarFolder;
using System.Threading;
using GoBot.Mouvements;
using GoBot.Enchainements;

namespace GoBot.IHM
{
    public enum Mode
    {
        Visualisation,
        Graph,
        Obstacles,
        Trajectoires,
        Intersection,
        AjoutPolygone,
        DebutTrajectoire,
        FinTrajectoire
    }

    public partial class PanelTable : UserControl
    {
        public static Plateau Plateau { get; set; }

        Mode modeCourant;
        Random rand;

        public PanelTable()
        {
            InitializeComponent();
            Plateau = new Plateau();
            Plateau.ScoreChange += new EventHandler(Plateau_ScoreChange);
        }

        void Plateau_ScoreChange(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(delegate
                {
                    lblScore.Text = Plateau.Score + "";
                }));
        }

        void MAJAffichage()
        {
            using (Pen penRougePointille = new Pen(Color.Red),
                    penBleuPointille = new Pen(Color.Blue),
                    penNoirPointille = new Pen(Color.Black),

                    penBlanc = new Pen(Color.White),
                    penNoir = new Pen(Color.Black),
                    penRougeFin = new Pen(Color.Red),
                    penBleuFin = new Pen(Color.Blue),
                    penVertFonce = new Pen(Color.Blue),
                    penBleuViolet = new Pen(Color.BlueViolet),
                    penCouleurJ1R = new Pen(Plateau.CouleurJ1R),
                    penCouleurJ2B = new Pen(Plateau.CouleurJ2B),

                    penRougeEpais = new Pen(Color.Red, 3),
                    penBleuEpais = new Pen(Color.Blue, 3),
                    penVertClairEpais = new Pen(Color.LightGreen, 3),
                    penOrangeEpais = new Pen(Color.Orange, 3),
                    penVertEpais = new Pen(Color.Green, 3))
            {
                using (SolidBrush brushNoir = new SolidBrush(Color.Black),
                        brushBlanc = new SolidBrush(Color.White),
                        brushCouleurJ1R = new SolidBrush(Plateau.CouleurJ1R),
                        brushCouleurJ2B = new SolidBrush(Plateau.CouleurJ2B),
                        brushVertFonce = new SolidBrush(Color.DarkGreen),
                        brushRouge = new SolidBrush(Color.Red),
                        brushVert = new SolidBrush(Color.Green),
                        brushTransparent = new SolidBrush(Color.Transparent))
                {
                    penRougePointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    penBleuPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    penNoirPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                    int nbBallePrec = 0;
                    List<Point> coordonneesBallesPanier = new List<Point>();
                    rand = new Random(DateTime.Now.Millisecond);
                    List<Point> positionsBallesChargees = new List<Point>();

                    positionsBallesChargees.Add(new Point(10, 10));
                    positionsBallesChargees.Add(new Point(20, 10));
                    positionsBallesChargees.Add(new Point(31, 11));
                    positionsBallesChargees.Add(new Point(27, 20));
                    positionsBallesChargees.Add(new Point(10, 29));
                    positionsBallesChargees.Add(new Point(21, 31));
                    positionsBallesChargees.Add(new Point(31, 31));

                    while (continuerAffichage)
                    {
                        try
                        {
                            Bitmap bmp = new Bitmap(750, 500);
                            {
                                Graphics g = Graphics.FromImage(bmp);
                                g.FillRectangle(brushBlanc, 0, 0, 750, 500);

                                int xTable = ScreenToReal(pictureBoxTable.PointToClient(MousePosition).X);
                                int yTable = ScreenToReal(pictureBoxTable.PointToClient(MousePosition).Y);

                                if (boxTable.Checked)
                                    g.DrawImage(Properties.Resources.table, 0, 0);

                                if (Plateau.InterpreteurBalise.PositionsEnnemies != null)
                                {
                                    foreach (PointReel p in Plateau.InterpreteurBalise.PositionsEnnemies)
                                    {
                                        if (p == null)
                                            continue;

                                        g.FillEllipse(brushCouleurJ1R, RealToScreen(p.X - Robots.GrosRobot.Rayon), RealToScreen(p.Y - Robots.GrosRobot.Rayon), RealToScreen(Robots.GrosRobot.Rayon * 2), RealToScreen(Robots.GrosRobot.Rayon * 2));
                                        g.DrawLine(penRougeEpais, new Point(RealToScreen(p.X) - 7, RealToScreen(p.Y) - 7), new Point(RealToScreen(p.X) + 7, RealToScreen(p.Y) + 7));
                                        g.DrawLine(penRougeEpais, new Point(RealToScreen(p.X) - 7, RealToScreen(p.Y) + 7), new Point(RealToScreen(p.X) + 7, RealToScreen(p.Y) - 7));
                                    }

                                    if (boxDroites.Checked)
                                    {
                                        /*foreach (DetectionBalise detection in interprete.DetectionBalisesBas)
                                        {
                                            // Ligne médiane
                                            g.DrawLine(crayonBleuPointille,
                                                new Point(RealToScreen(detection.Balise.Position.Coordonnees.X), RealToScreen(detection.Balise.Position.Coordonnees.Y)),
                                                new Point(RealToScreen(detection.Position.X), RealToScreen(detection.Position.Y)));

                                            // Dessin du polygone de détection
                                            Polygone polygone = InterpreteurBalise.DetectionToPolygone(detection);
                                            List<Point> points = new List<Point>();

                                            foreach (Segment s in polygone.Cotes)
                                            {
                                                points.Add(new Point(RealToScreen(s.Debut.X), RealToScreen(s.Debut.Y)));
                                                points.Add(new Point(RealToScreen(s.Fin.X), RealToScreen(s.Fin.Y)));
                                            }

                                            g.DrawPolygon(crayonBleuFin, points.ToArray());

                                            g.DrawLine(crayonBleuFin, new Point(RealToScreen(detection.Position.X) - 4, RealToScreen(detection.Position.Y) - 4), new Point(RealToScreen(detection.Position.X) + 4, RealToScreen(detection.Position.Y) + 4));
                                            g.DrawLine(crayonBleuFin, new Point(RealToScreen(detection.Position.X) - 4, RealToScreen(detection.Position.Y) + 4), new Point(RealToScreen(detection.Position.X) + 4, RealToScreen(detection.Position.Y) - 4));
                                        }*/

                                        foreach (DetectionBalise detection in Plateau.InterpreteurBalise.DetectionBalisesHaut)
                                        {
                                            // Ligne médiane
                                            g.DrawLine(penRougePointille,
                                                new Point(RealToScreen(detection.Balise.Position.Coordonnees.X), RealToScreen(detection.Balise.Position.Coordonnees.Y)),
                                                new Point(RealToScreen(detection.Position.X), RealToScreen(detection.Position.Y)));

                                            // Dessin du polygone de détection
                                            Polygone polygone = InterpreteurBalise.DetectionToPolygone(detection);
                                            List<Point> points = new List<Point>();

                                            foreach (Segment s in polygone.Cotes)
                                            {
                                                points.Add(new Point(RealToScreen(s.Debut.X), RealToScreen(s.Debut.Y)));
                                                points.Add(new Point(RealToScreen(s.Fin.X), RealToScreen(s.Fin.Y)));
                                            }

                                            g.DrawPolygon(penRougeFin, points.ToArray());
                                            g.DrawLine(penRougeFin, new Point(RealToScreen(detection.Position.X) - 4, RealToScreen(detection.Position.Y) - 4), new Point(RealToScreen(detection.Position.X) + 4, RealToScreen(detection.Position.Y) + 4));
                                            g.DrawLine(penRougeFin, new Point(RealToScreen(detection.Position.X) - 4, RealToScreen(detection.Position.Y) + 4), new Point(RealToScreen(detection.Position.X) + 4, RealToScreen(detection.Position.Y) - 4));
                                        }

                                        foreach (PointReelGenere p in Plateau.InterpreteurBalise.Intersections)
                                        {
                                            g.FillEllipse(brushVertFonce, RealToScreen(p.Point.X) - 2, RealToScreen(p.Point.Y) - 2, 4, 4);
                                        }

                                        /*foreach (PointReel p in interprete.MoyennesDistance)
                                        {
                                            g.FillEllipse(new SolidBrush(Color.Red), RealToScreen(p.X) - 4, RealToScreen(p.Y) - 4, 6, 6);
                                        }*/

                                        foreach (PointReelGenere p in Plateau.InterpreteurBalise.MoyennesIntersections)
                                        {
                                            g.FillEllipse(brushVertFonce, RealToScreen(p.Point.X) - 4, RealToScreen(p.Point.Y) - 4, 8, 8);
                                        }

                                        /*foreach (List<PointReel> liste in interprete.RegroupementsDistance)
                                        {
                                            if (liste.Count > 1)
                                            {
                                                Point[] points = new Point[liste.Count];
                                                for (int i = 0; i < liste.Count; i++)
                                                {
                                                    points[i] = new Point(RealToScreen(liste[i].X), RealToScreen(liste[i].Y));
                                                }
                                                g.DrawPolygon(new Pen(Color.Red), points);
                                            }
                                        }*/

                                        /*foreach (List<PointReel> liste in interprete.RegroupementsIntersections)
                                        {
                                            if (liste.Count > 1)
                                            {
                                                Point[] points = new Point[liste.Count];
                                                for (int i = 0; i < liste.Count; i++)
                                                {
                                                    points[i] = new Point(RealToScreen(liste[i].X), RealToScreen(liste[i].Y));
                                                }
                                                g.DrawPolygon(new Pen(Color.DarkGreen), points);
                                            }
                                        }*/

                                        foreach (List<PointReel> liste in Plateau.InterpreteurBalise.AssociationPointDistanceIntersection)
                                        {
                                            if (liste[0] == null || liste[1] == null)
                                                continue;
                                            g.DrawLine(penVertFonce, new Point(RealToScreen(liste[0].X), RealToScreen(liste[0].Y)), new Point(RealToScreen(liste[1].X), RealToScreen(liste[1].Y)));
                                        }
                                    }
                                }

                                // Dessin des obstacles
                                if (boxObstacles.Checked)
                                {
                                    g.FillRectangle(brushBlanc, 0, 0, 3000, 2000);

                                    foreach (IForme forme in Plateau.ListeObstacles)
                                        DessinerForme(g, Color.Red, forme);
                                }

                                // Dessin du graph
                                if (boxGraph.Checked)
                                {
                                    Console.WriteLine("Dessine veut prendre");
                                    Plateau.SemaphoreGraph.WaitOne();
                                    Console.WriteLine("Dessine prends");

                                    // Dessin des arcs
                                    if (boxArretes.Checked)
                                    {
                                        foreach (Arc a in Plateau.Graph.Arcs)
                                        {
                                            if (a.Passable != false)
                                            {
                                                //pen = new Pen(new SolidBrush(Color.Red));

                                                g.DrawLine(penBlanc, new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                                                g.DrawLine(penNoirPointille, new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                                            }
                                        }
                                    }

                                    // Dessin des noeuds
                                    foreach (Node n in Plateau.Graph.Nodes)
                                    {
                                        g.FillEllipse(brushNoir, new Rectangle(RealToScreen(n.X) - 3, RealToScreen(n.Y) - 3, 6, 6));
                                        g.DrawEllipse(n.Passable ? penBlanc : penRougeFin, new Rectangle(RealToScreen(n.X) - 3, RealToScreen(n.Y) - 3, 6, 6));
                                    }

                                    Plateau.SemaphoreGraph.Release();
                                    Console.WriteLine("Dessine libere");
                                }

                                // Dessin de la trajectoire en cours de recherche
                                if (modeCourant == Mode.FinTrajectoire && cheminArcs != null)
                                {
                                    foreach (Arc a in cheminArcs)
                                    {
                                        g.DrawLine(penBleuViolet, new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                                    }
                                    foreach (Node n in cheminNodes)
                                    {
                                        g.DrawEllipse(penBleuViolet, new Rectangle(RealToScreen(n.Position.X) - 3, RealToScreen(n.Position.Y) - 3, 6, 6));
                                    }
                                }
                                if (boxSourisObstacle.Checked)
                                {
                                    g.DrawEllipse(penRougeFin,
                                        (int)(xSouris - RealToScreen(Robots.GrosRobot.Rayon) * 2),
                                        (int)(ySouris - RealToScreen(Robots.GrosRobot.Rayon) * 2), RealToScreen(Robots.GrosRobot.Rayon) * 4, RealToScreen(Robots.GrosRobot.Rayon) * 4);
                                }

                                // Dessin des assiettes

                                if (Plateau.AssietteAttrapee != -1)
                                {
                                    Plateau.PositionsAssiettes[Plateau.AssietteAttrapee] = new Position(new Angle(Robots.GrosRobot.Position.Angle.AngleDegres), new PointReel(
                                        Robots.GrosRobot.Position.Coordonnees.X - (170 / 2 + Robots.GrosRobot.Longueur / 2) * Math.Cos(Robots.GrosRobot.Position.Angle.AngleRadians),
                                        Robots.GrosRobot.Position.Coordonnees.Y - (170 / 2 + Robots.GrosRobot.Longueur / 2) * Math.Sin(Robots.GrosRobot.Position.Angle.AngleRadians)));
                                }

                                for (int i = 0; i < 5; i++)
                                {
                                    if (Plateau.AssiettesExiste[i])
                                        if (!Plateau.AssiettesVidees[i])
                                            g.DrawImage(rotateImage(Properties.Resources.AssiettePleineBleu, Plateau.PositionsAssiettes[i].Angle.AngleDegres), RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.X) - 61 / 2, RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.Y) - 61 / 2, 61, 61);
                                        else
                                            g.DrawImage(rotateImage(Properties.Resources.AssietteVide, Plateau.PositionsAssiettes[i].Angle.AngleDegres), RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.X) - 61 / 2, RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.Y) - 61 / 2, 61, 61);

                                }
                                for (int i = 5; i < 10; i++)
                                {
                                    if (Plateau.AssiettesExiste[i])
                                        if (!Plateau.AssiettesVidees[i])
                                            g.DrawImage(rotateImage(Properties.Resources.AssiettePleineRouge, Plateau.PositionsAssiettes[i].Angle.AngleDegres), RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.X) - 61 / 2, RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.Y) - 61 / 2, 61, 61);
                                        else
                                            g.DrawImage(rotateImage(Properties.Resources.AssietteVide, Plateau.PositionsAssiettes[i].Angle.AngleDegres), RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.X) - 61 / 2, RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.Y) - 61 / 2, 61, 61);
                                }

                                // Dessin des bougies

                                PointReel point = new PointReel(xTable, yTable);

                                for (int i = 0; i < 20; i++)
                                {
                                    g.FillEllipse(Plateau.CouleursBougies[i] == Color.White ? brushBlanc : Plateau.CouleursBougies[i] == Plateau.CouleurJ1R ? brushCouleurJ1R : brushCouleurJ2B, RealToScreen(Plateau.PositionsBougies[i].X - 40), RealToScreen(Plateau.PositionsBougies[i].Y - 40), RealToScreen(80), RealToScreen(80));
                                    g.DrawEllipse(penNoir, RealToScreen(Plateau.PositionsBougies[i].X - 40), RealToScreen(Plateau.PositionsBougies[i].Y - 40), RealToScreen(80), RealToScreen(80));

                                    if (Plateau.BougiesEnfoncees[i])
                                    {
                                        g.FillEllipse(brushNoir, RealToScreen(Plateau.PositionsBougies[i].X - 20), RealToScreen(Plateau.PositionsBougies[i].Y - 20), RealToScreen(40), RealToScreen(40));
                                        g.DrawEllipse(penBlanc, RealToScreen(Plateau.PositionsBougies[i].X - 20), RealToScreen(Plateau.PositionsBougies[i].Y - 20), RealToScreen(40), RealToScreen(40));
                                    }

                                    else if (Plateau.PositionsBougies[i].Distance(point) <= 40)
                                    {
                                        g.DrawEllipse(penVertClairEpais, RealToScreen(Plateau.PositionsBougies[i].X - 40), RealToScreen(Plateau.PositionsBougies[i].Y - 40), RealToScreen(80), RealToScreen(80));
                                    }
                                }

                                // Dessin du gros robot

                                if (Robots.GrosRobot != null)
                                {
                                    int xRobot, yRobot;
                                    double angleRobot;
                                    xRobot = RealToScreen(Robots.GrosRobot.Position.Coordonnees.X);
                                    yRobot = RealToScreen(Robots.GrosRobot.Position.Coordonnees.Y);
                                    angleRobot = Robots.GrosRobot.Position.Angle.AngleRadians;// +(90 * Math.PI / 360);

                                    Point p1, p2, p3, p4;
                                    double miDiagonale = RealToScreen((int)Math.Round((Math.Sqrt(Robots.GrosRobot.Largeur * Robots.GrosRobot.Largeur + Robots.GrosRobot.Longueur * Robots.GrosRobot.Longueur)) / 2));

                                    double angle1 = angleRobot + Math.Atan((Robots.GrosRobot.Largeur / 2.0) / (Robots.GrosRobot.Longueur / 2.0));
                                    double angle2 = angleRobot - Math.Atan((Robots.GrosRobot.Largeur / 2.0) / (Robots.GrosRobot.Longueur / 2.0));
                                    double angle3 = angleRobot + Math.Atan((Robots.GrosRobot.Largeur / 2.0) / (Robots.GrosRobot.Longueur / 2.0)) + Math.PI;
                                    double angle4 = angleRobot - Math.Atan((Robots.GrosRobot.Largeur / 2.0) / (Robots.GrosRobot.Longueur / 2.0)) + Math.PI;

                                    p1 = new Point((int)Math.Round(xRobot + Math.Cos(angle1) * miDiagonale), (int)Math.Round(yRobot + Math.Sin(angle1) * miDiagonale));
                                    p2 = new Point((int)Math.Round(xRobot + Math.Cos(angle2) * miDiagonale), (int)Math.Round(yRobot + Math.Sin(angle2) * miDiagonale));
                                    p3 = new Point((int)Math.Round(xRobot + Math.Cos(angle3) * miDiagonale), (int)Math.Round(yRobot + Math.Sin(angle3) * miDiagonale));
                                    p4 = new Point((int)Math.Round(xRobot + Math.Cos(angle4) * miDiagonale), (int)Math.Round(yRobot + Math.Sin(angle4) * miDiagonale));

                                    Point[] tabPoints = new Point[4];
                                    tabPoints[0] = p1;
                                    tabPoints[1] = p2;
                                    tabPoints[2] = p3;
                                    tabPoints[3] = p4;

                                    g.FillPolygon(new SolidBrush(Color.FromArgb(152, 199, 250)), tabPoints);
                                    g.DrawPolygon(penCouleurJ2B, tabPoints);

                                    double angle = Robots.GrosRobot.Position.Angle.AngleRadians + (-180 * 2 * Math.PI / 360);
                                    double cos = Math.Cos(angle);
                                    double sin = Math.Sin(angle);
                                    Point pointDevant = new Point(Maths.Arrondi(xRobot - cos * RealToScreen(Maths.Arrondi(Robots.GrosRobot.Longueur / 2))), Maths.Arrondi(yRobot - sin * RealToScreen(Maths.Arrondi(Robots.GrosRobot.Longueur / 2))));

                                    g.DrawLine(penCouleurJ2B, new Point(xRobot, yRobot), pointDevant);

                                    this.Invoke(new EventHandler(delegate
                                    {
                                        lblPosGrosX.Text = Math.Round(Robots.GrosRobot.Position.Coordonnees.X, 2).ToString();
                                        lblPosGrosY.Text = Math.Round(Robots.GrosRobot.Position.Coordonnees.Y, 2).ToString();
                                        lblPosGrosTeta.Text = Robots.GrosRobot.Position.Angle.ToString();
                                    }));

                                    // Dessin des balles dans le robot
                                    if (Robots.GrosRobot.NbBallesBlanchesCharges > 0 || Robots.GrosRobot.BalleCouleurChargee)
                                    {
                                        Bitmap bmpBalles = new Bitmap(52, 52);
                                        Graphics gBalles = Graphics.FromImage(bmpBalles);
                                        g.FillRectangle(brushTransparent, 0, 0, 52, 52);

                                        for (int i = 0; i < Robots.GrosRobot.NbBallesBlanchesCharges; i++)
                                        {
                                            gBalles.DrawImage(Properties.Resources.Balle, positionsBallesChargees[i].X, positionsBallesChargees[i].Y, 10, 10);
                                        }
                                        if (Robots.GrosRobot.BalleCouleurChargee)
                                        {
                                            Bitmap imageBalle = Properties.Resources.BalleBleue;
                                            if (Robots.GrosRobot.CouleurBalleChargee == Plateau.CouleurJ1R)
                                                imageBalle = Properties.Resources.BalleRouge;

                                            gBalles.DrawImage(imageBalle, 16, 20, 10, 10);
                                        }

                                        g.DrawImage(rotateImage(bmpBalles, Robots.GrosRobot.Position.Angle.AngleDegres), RealToScreen(Robots.GrosRobot.Position.Coordonnees.X) - 52 / 2, RealToScreen(Robots.GrosRobot.Position.Coordonnees.Y) - 52 / 2, 52, 52);
                                    }

                                    foreach (Point balleRentree in coordonneesBallesPanier)
                                        g.DrawImage(Properties.Resources.Balle, balleRentree.X, balleRentree.Y, 10, 10);

                                    // Test lancement de balle
                                    if (Robots.GrosRobot.LancementBalles)
                                    {
                                        int yBalle = 0;
                                        int xBalle = 0;
                                        Bitmap img;

                                        if (Plateau.CouleurBalleLancee == Color.White)
                                        {
                                            if (Plateau.NotreCouleur == Plateau.CouleurJ2B)
                                                xBalle = 1400;
                                            else
                                                xBalle = 1600;

                                            img = Properties.Resources.Balle;
                                        }
                                        else
                                        {
                                            if (Plateau.NotreCouleur == Plateau.CouleurJ2B)
                                                xBalle = 1000;
                                            else
                                                xBalle = 1100;

                                            if (Robots.GrosRobot.CouleurBalleChargee == Plateau.CouleurJ1R)
                                                img = Properties.Resources.BalleRouge;
                                            else
                                                img = Properties.Resources.BalleBleue;
                                        }

                                        if (nbBallePrec + 1 < Plateau.NbBallesMarquees ||
                                            (nbBallePrec < Plateau.NbBallesMarquees && (DateTime.Now - Plateau.DateBalle).TotalMilliseconds > 900) ||
                                            nbBallePrec < Plateau.NbBallesMarquees && Plateau.CouleurBalleLancee != Color.White)
                                        {
                                            nbBallePrec++;
                                            // Nouvelle balle
                                            int xBalleRentree = RealToScreen(rand.Next(150) + 1340);
                                            if (Plateau.NotreCouleur == Plateau.CouleurJ1R)
                                                xBalleRentree = RealToScreen(rand.Next(150) + 1510);

                                            int yBalleRentree = RealToScreen(rand.Next(150));

                                            coordonneesBallesPanier.Add(new Point(xBalleRentree, yBalleRentree));
                                        }

                                        xBalle = RealToScreen(xBalle - (xBalle - Robots.GrosRobot.Position.Coordonnees.X) / 800.0 * (800 - (DateTime.Now - Plateau.DateBalle).TotalMilliseconds));
                                        yBalle = RealToScreen(100 - (100 - Robots.GrosRobot.Position.Coordonnees.Y) / 800.0 * (800 - (DateTime.Now - Plateau.DateBalle).TotalMilliseconds));

                                        g.DrawImage(img, xBalle - 5, yBalle - 5, 10, 10);
                                    }
                                }

                                // Fin dessin robot

                                // Dessin du petit robot
                                if (Robots.PetitRobot != null)
                                {
                                    int xRobot, yRobot;
                                    double angleRobot;
                                    xRobot = RealToScreen(Robots.PetitRobot.Position.Coordonnees.X);
                                    yRobot = RealToScreen(Robots.PetitRobot.Position.Coordonnees.Y);
                                    angleRobot = Robots.PetitRobot.Position.Angle.AngleRadians;// +(90 * Math.PI / 360);

                                    Point p1, p2, p3, p4;
                                    double miDiagonale = RealToScreen((int)Math.Round((Math.Sqrt(Robots.PetitRobot.Largeur * Robots.PetitRobot.Largeur + Robots.PetitRobot.Longueur * Robots.GrosRobot.Longueur)) / 2));

                                    double angle1 = angleRobot + Math.Atan((Robots.PetitRobot.Largeur / 2.0) / (Robots.PetitRobot.Longueur / 2.0));
                                    double angle2 = angleRobot - Math.Atan((Robots.PetitRobot.Largeur / 2.0) / (Robots.PetitRobot.Longueur / 2.0));
                                    double angle3 = angleRobot + Math.Atan((Robots.PetitRobot.Largeur / 2.0) / (Robots.PetitRobot.Longueur / 2.0)) + Math.PI;
                                    double angle4 = angleRobot - Math.Atan((Robots.PetitRobot.Largeur / 2.0) / (Robots.PetitRobot.Longueur / 2.0)) + Math.PI;

                                    p1 = new Point((int)Math.Round(xRobot + Math.Cos(angle1) * miDiagonale), (int)Math.Round(yRobot + Math.Sin(angle1) * miDiagonale));
                                    p2 = new Point((int)Math.Round(xRobot + Math.Cos(angle2) * miDiagonale), (int)Math.Round(yRobot + Math.Sin(angle2) * miDiagonale));
                                    p3 = new Point((int)Math.Round(xRobot + Math.Cos(angle3) * miDiagonale), (int)Math.Round(yRobot + Math.Sin(angle3) * miDiagonale));
                                    p4 = new Point((int)Math.Round(xRobot + Math.Cos(angle4) * miDiagonale), (int)Math.Round(yRobot + Math.Sin(angle4) * miDiagonale));

                                    Point[] tabPoints = new Point[4];
                                    tabPoints[0] = p1;
                                    tabPoints[1] = p2;
                                    tabPoints[2] = p3;
                                    tabPoints[3] = p4;

                                    g.FillPolygon(new SolidBrush(Color.FromArgb(152, 199, 250)), tabPoints);
                                    g.DrawPolygon(penCouleurJ2B, tabPoints);

                                    double angle = Robots.PetitRobot.Position.Angle.AngleRadians + (-180 * 2 * Math.PI / 360);
                                    double cos = Math.Cos(angle);
                                    double sin = Math.Sin(angle);
                                    Point pointDevant = new Point(Maths.Arrondi(xRobot - cos * RealToScreen(Maths.Arrondi(Robots.PetitRobot.Longueur / 2))), Maths.Arrondi(yRobot - sin * RealToScreen(Maths.Arrondi(Robots.PetitRobot.Longueur / 2))));

                                    g.DrawLine(penCouleurJ2B, new Point(xRobot, yRobot), pointDevant);

                                    lblPosPetitX.Text = Math.Round(Robots.PetitRobot.Position.Coordonnees.X, 2).ToString();
                                    lblPosPetitY.Text = Math.Round(Robots.PetitRobot.Position.Coordonnees.Y, 2).ToString();
                                    lblPosPetitTeta.Text = Robots.PetitRobot.Position.Angle.ToString();
                                }


                                // Dessin pathfinding

                                Robot[] robots = new Robot[2];
                                robots[0] = Robots.GrosRobot;
                                robots[1] = Robots.PetitRobot;

                                foreach (Robot robot in robots)
                                {
                                    foreach (Node n in robot.NodeTrouve)
                                        g.FillEllipse(brushRouge, new Rectangle(RealToScreen(n.Position.X) - 4, RealToScreen(n.Position.Y) - 4, 8, 8));

                                    foreach (Arc a in robot.CheminTrouve)
                                        g.DrawLine(penOrangeEpais, new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));


                                    if (robot.CheminEnCoursNoeuds != null && robot.CheminEnCoursNoeuds.Count > 1)
                                    {
                                        Segment seg = new Segment(new PointReel(robot.CheminEnCoursNoeuds[1].X, robot.CheminEnCoursNoeuds[1].Y), robot.Position.Coordonnees);
                                        g.DrawLine(penVertEpais, new Point(RealToScreen(robot.CheminEnCoursNoeuds[1].X), RealToScreen(robot.CheminEnCoursNoeuds[1].Y)), new Point(RealToScreen(robot.Position.Coordonnees.X), RealToScreen(robot.Position.Coordonnees.Y)));
                                        for (int i = 1; i < robot.CheminEnCoursArcs.Count; i++)
                                        {
                                            Arc a = robot.CheminEnCoursArcs[i];
                                            g.DrawLine(penVertEpais, new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                                        }
                                    }

                                    if (robot.CheminTest != null)
                                        g.DrawLine(penRougeEpais, new Point(RealToScreen(robot.CheminTest.StartNode.Position.X), RealToScreen(robot.CheminTest.StartNode.Position.Y)), new Point(RealToScreen(robot.CheminTest.EndNode.Position.X), RealToScreen(robot.CheminTest.EndNode.Position.Y)));

                                    if (robot.ObstacleTeste != null)
                                        DessinerForme(g, Color.Green, robot.ObstacleTeste);

                                    if (robot.ObstacleProbleme != null)
                                        DessinerForme(g, Color.Red, robot.ObstacleProbleme);

                                    if (robot.CheminEnCoursNoeuds != null)
                                        foreach (Node n in robot.CheminEnCoursNoeuds)
                                            g.FillEllipse(brushVert, new Rectangle(RealToScreen(n.Position.X) - 4, RealToScreen(n.Position.Y) - 4, 8, 8));
                                }
                                // Fin pathfinding


                                // Dessin des cadeaux

                                for (int i = 0; i < 8; i++)
                                {
                                    Color color = i % 2 == 1 ? Plateau.CouleurJ1R : Plateau.CouleurJ2B;
                                    if (!Plateau.CadeauxActives[i])
                                    {
                                        g.FillRectangle(i % 2 == 1 ? brushCouleurJ1R : brushCouleurJ2B, RealToScreen(Plateau.PositionsCadeaux[i].X - 75), RealToScreen(Plateau.PositionsCadeaux[i].Y - 30), RealToScreen(150), RealToScreen(40));
                                        g.DrawRectangle(penNoir, RealToScreen(Plateau.PositionsCadeaux[i].X - 75), RealToScreen(Plateau.PositionsCadeaux[i].Y - 30), RealToScreen(150), RealToScreen(40));
                                    }

                                    if (!Plateau.CadeauxActives[i] && yTable >= 1970)
                                    {
                                        if (xTable > Plateau.PositionsCadeaux[i].X - 75 && xTable < Plateau.PositionsCadeaux[i].X + 75)
                                            g.DrawRectangle(penVertClairEpais, RealToScreen(Plateau.PositionsCadeaux[i].X - 75), RealToScreen(Plateau.PositionsCadeaux[i].Y - 30), RealToScreen(150), RealToScreen(40));
                                    }
                                }

                                // Dessin des coûts des mouvements

                                if (Plateau.Enchainement != null)
                                {
                                    if (boxCoutGros.Checked)
                                    {
                                        Font police = new Font("Calibri", 8);
                                        foreach (Mouvement m in Plateau.Enchainement.ListeMouvementsGros)
                                        {
                                            if (m.Cout != double.MaxValue)
                                                g.DrawString(Math.Round(m.Cout) + "", police, brushRouge, new PointF(RealToScreen(m.Position.Coordonnees.X), RealToScreen((float)m.Position.Coordonnees.Y)));
                                        }
                                    }
                                    if (boxCoutPetit.Checked)
                                    {
                                        Font police = new Font("Calibri", 8);
                                        foreach (Mouvement m in Plateau.Enchainement.ListeMouvementsPetit)
                                        {
                                            if (m.Cout != double.MaxValue)
                                                g.DrawString(Math.Round(m.Cout) + "", police, brushVert, new PointF(RealToScreen(m.Position.Coordonnees.X), RealToScreen((float)m.Position.Coordonnees.Y)));
                                        }
                                    }

                                    TimeSpan tempsRestant = Plateau.Enchainement.TempsRestant;
                                    if (tempsRestant.TotalMilliseconds <= 0)
                                        tempsRestant = new TimeSpan(0);

                                    lblSecondes.Text = (int)tempsRestant.TotalSeconds + "";
                                    lblMilli.Text = tempsRestant.Milliseconds + "";

                                    Color couleur;
                                    if (tempsRestant.TotalSeconds > Enchainement.DureeMatch.TotalSeconds / 2)
                                        couleur = Color.FromArgb((int)((Enchainement.DureeMatch.TotalSeconds - tempsRestant.TotalSeconds) * (150.0 / (Enchainement.DureeMatch.TotalSeconds / 2.0))), 150, 0);
                                    else
                                        couleur = Color.FromArgb(150, 150 - (int)((Enchainement.DureeMatch.TotalSeconds / 2.0 - tempsRestant.TotalSeconds) * (150.0 / (Enchainement.DureeMatch.TotalSeconds / 2.0))), 0);

                                    lblSecondes.ForeColor = couleur;
                                    lblMilli.ForeColor = couleur;
                                }

                                pictureBoxTable.Image = bmp;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Erreur pendant le dessin de la table " + ex.Message);
                        }
                    }
                }
            }
        }

        private Bitmap rotateImage(Bitmap b, double angle)
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

        public void DessinerForme(Graphics graphics, Color color, IForme inconnue, bool plein = false)
        {
            Type typeForme = inconnue.GetType();

            if (typeForme.IsAssignableFrom(typeof(Segment)))
                DessinerForme(graphics, color, (Segment)inconnue);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                DessinerForme(graphics, color, (Cercle)inconnue, plein);
            else if (typeForme.IsAssignableFrom(typeof(Polygone)))
                DessinerForme(graphics, color, (Polygone)inconnue);
            else
                throw new NotImplementedException("Je ne sais pas dessiner cette forme : " + inconnue.GetType().ToString());
        }

        private void DessinerForme(Graphics graphics, Color color, Cercle Cercle, bool plein = false)
        {
            if (!plein)
                using (Pen pen = new Pen(color, 10))
                    graphics.DrawEllipse(pen, new Rectangle(RealToScreen(Cercle.Centre.X) - RealToScreen(Cercle.Rayon), RealToScreen(Cercle.Centre.Y) - RealToScreen(Cercle.Rayon), RealToScreen(Cercle.Rayon * 2), RealToScreen(Cercle.Rayon * 2)));
            else
                using (SolidBrush brush = new SolidBrush(color))
                    graphics.FillEllipse(brush, new Rectangle(RealToScreen(Cercle.Centre.X) - RealToScreen(Cercle.Rayon), RealToScreen(Cercle.Centre.Y) - RealToScreen(Cercle.Rayon), RealToScreen(Cercle.Rayon * 2), RealToScreen(Cercle.Rayon * 2)));
        }

        private void DessinerForme(Graphics graphics, Color color, Segment segment)
        {
            using (Pen pen = new Pen(color, 10))
                graphics.DrawLine(pen, RealToScreen(segment.Debut.X), RealToScreen(segment.Debut.Y), RealToScreen(segment.Fin.X), RealToScreen(segment.Fin.Y));
        }

        private void DessinerForme(Graphics graphics, Color color, Polygone polygone, bool plein = false)
        {
            if (polygone.Cotes.Count == 0)
                return;

            Point[] listePoints = new Point[polygone.Cotes.Count + 1];

            listePoints[0] = new Point(RealToScreen(polygone.Cotes[0].Debut.X), RealToScreen(polygone.Cotes[0].Debut.Y));

            for (int i = 0; i < polygone.Cotes.Count; i++)
            {
                Segment s = polygone.Cotes[i];
                listePoints[i] = new Point(RealToScreen(s.Fin.X), RealToScreen(s.Fin.Y));
            }

            listePoints[listePoints.Length - 1] = listePoints[0];

            if (!plein)
                using (Pen pen = new Pen(color, 10))
                    graphics.DrawPolygon(pen, listePoints);
            else
                using (SolidBrush brush = new SolidBrush(color))
                    graphics.FillPolygon(brush, listePoints, System.Drawing.Drawing2D.FillMode.Winding);
        }

        #endregion

        private void btnAffichage_Click(object sender, EventArgs e)
        {
            btnAffichage.Enabled = false;
            Thread thAffichage = new Thread(MAJAffichage);
            thAffichage.Start();
        }

        private void btnSaveGraph_Click(object sender, EventArgs e)
        {
            Plateau.SauverGraph();
            MessageBox.Show("Graph sauvegardé", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        List<Node> cheminNodes;
        List<Arc> cheminArcs;

        int xSouris = 0, ySouris = 0;
        private void pictureBoxTable_MouseMove(object sender, MouseEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
                {
                    if (modeCourant == Mode.FinTrajectoire)
                    {
                        double distance;
                        Node finNode = Plateau.Graph.ClosestNode(ScreenToReal(pictureBoxTable.PointToClient(MousePosition).X), ScreenToReal(pictureBoxTable.PointToClient(MousePosition).Y), 0, out distance, false);

                        AStar aStar = new AStar(Plateau.Graph);
                        if (aStar.SearchPath(debutNode, finNode))
                        {
                            cheminNodes = aStar.PathByNodes.ToList<Node>();
                            cheminArcs = aStar.PathByArcs.ToList<Arc>();
                        }
                    }
                    else if (boxSourisObstacle.Checked)
                    {
                        Plateau.ObstacleTest(ScreenToReal(pictureBoxTable.PointToClient(MousePosition).X), ScreenToReal(pictureBoxTable.PointToClient(MousePosition).Y));

                        xSouris = pictureBoxTable.PointToClient(MousePosition).X;
                        ySouris = pictureBoxTable.PointToClient(MousePosition).Y;
                    }

                    lblPos.Text = ScreenToReal(pictureBoxTable.PointToClient(MousePosition).X) + " : " + ScreenToReal(pictureBoxTable.PointToClient(MousePosition).Y);
                }));
        }

        private int ScreenToReal(double valeur)
        {
            return (int)(valeur * 4.0);
        }

        private int RealToScreen(double valeur)
        {
            return (int)(valeur / 4.0);
        }

        Node debutNode;
        private void btnAllerA_Click(object sender, EventArgs e)
        {
            modeCourant = Mode.FinTrajectoire;
            double distance;
            //debutNode = Plateau.Graph.ClosestNode(0, 0, 0, out distance, false);
            debutNode = Plateau.Graph.ClosestNode(Robots.GrosRobot.Position.Coordonnees.X, Robots.GrosRobot.Position.Coordonnees.Y, 0, out distance, false);
        }

        public void ThreadAction()
        {
            if (!move.Executer())
                MessageBox.Show("Echec");
            move = null;
        }

        Mouvement move;
        Thread th;

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
                Plateau.BougiesEnfoncees[i] = false;
            for (int i = 0; i < 8; i++)
                Plateau.CadeauxActives[i] = false;

            Plateau.Score = 0;
        }

        private bool continuerAffichage = true;
        public void Stop()
        {
            continuerAffichage = false;
        }

        private void PathFinding()
        {
            if (modeCourant == Mode.FinTrajectoire)
            {
                if (ev.Button == System.Windows.Forms.MouseButtons.Left)
                    Robots.GrosRobot.PathFinding(ScreenToReal(pictureBoxTable.PointToClient(MousePosition).X), ScreenToReal(pictureBoxTable.PointToClient(MousePosition).Y));
                else
                    Robots.PetitRobot.PathFinding(ScreenToReal(pictureBoxTable.PointToClient(MousePosition).X), ScreenToReal(pictureBoxTable.PointToClient(MousePosition).Y));

                modeCourant = Mode.Visualisation;
            }
            else
            {

                int xTable = ScreenToReal(pictureBoxTable.PointToClient(MousePosition).X);
                int yTable = ScreenToReal(pictureBoxTable.PointToClient(MousePosition).Y);

                PointReel point = new PointReel(xTable, yTable);

                for (int i = 0; i < 20; i++)
                {
                    if (Plateau.PositionsBougies[i].Distance(point) <= 40)
                    {
                        if (ev.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            if (PositionsMouvements.PositionPetitBougie.ContainsKey(i))
                                move = new MovePetitBougie(i);
                        }
                        else
                            move = new MoveGrosBougie(i);

                        if (move != null)
                        {
                            th = new Thread(ThreadAction);
                            th.Start();
                            break;
                        }
                    }
                }

                for (int i = 0; i < 8; i++)
                {
                    if (yTable >= 1970)
                    {
                        if (xTable > Plateau.PositionsCadeaux[i].X - 75 && xTable < Plateau.PositionsCadeaux[i].X + 75)
                        {
                            if (ev.Button == System.Windows.Forms.MouseButtons.Left)
                                move = new MovePetitCadeau(i);
                            else
                                move = new MoveGrosCadeau(i);

                            if (move != null)
                            {
                                th = new Thread(ThreadAction);
                                th.Start();
                            }
                            break;
                        }
                    }
                }
            }
        }

        Thread thPath;
        MouseEventArgs ev;
        private void pictureBoxTable_MouseClick(object sender, MouseEventArgs e)
        {
            ev = e;
            thPath = new Thread(PathFinding);
            thPath.Start();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Plateau.Enchainement = new Enchainement();
            Plateau.Enchainement.Executer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Plateau.AssietteAttrapee == -1)
                Plateau.AssietteAttrapee = 1;
            else
                Plateau.AssietteAttrapee = -1;
        }
    }
}
