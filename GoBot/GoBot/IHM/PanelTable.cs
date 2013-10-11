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
using GoBot.Balises;

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

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            thAffichage.Abort();
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
            int cptHelice1 = 1;
            int cptHelice2 = 0;

            using (Pen penRougePointille = new Pen(Color.Red),
                    penBleuPointille = new Pen(Color.Blue),
                    penNoirPointille = new Pen(Color.Black),

                    penBlanc = new Pen(Color.White),
                    penNoir = new Pen(Color.Black),
                    penRougeFin = new Pen(Color.Red),
                    penBleuFin = new Pen(Color.Blue),
                    penVertFonce = new Pen(Color.Green),
                    penBleuViolet = new Pen(Color.BlueViolet),
                    penCouleurJ1R = new Pen(Plateau.CouleurJ1R),
                    penCouleurJ1RFleche = new Pen(Plateau.CouleurJ1R, 3),
                    penCouleurJ2B = new Pen(Plateau.CouleurJ2B),

                    penRougeEpais = new Pen(Color.Red, 3),
                    penBleuEpais = new Pen(Plateau.CouleurJ2B, 3),
                    penVertClairEpais = new Pen(Color.LightGreen, 3),
                    penOrangeEpais = new Pen(Color.Orange, 3),
                    penVertEpais = new Pen(Color.Green, 3))
            {
                using (SolidBrush brushNoir = new SolidBrush(Color.Black),
                        brushBlanc = new SolidBrush(Color.White),
                        brushCouleurJ1R = new SolidBrush(Plateau.CouleurJ1R),
                        brushCouleurJ1RTransparent = new SolidBrush(Color.FromArgb(100, Plateau.CouleurJ1R)),
                        brushCouleurJ1RTresTransparent = new SolidBrush(Color.FromArgb(35, Plateau.CouleurJ1R)),
                        brushCouleurJ2B = new SolidBrush(Plateau.CouleurJ2B),
                        brushVertFonce = new SolidBrush(Color.DarkGreen),
                        brushRouge = new SolidBrush(Color.Red),
                        brushVert = new SolidBrush(Color.Green),
                        brushTransparent = new SolidBrush(Color.Transparent),
                        brushBleuClair = new SolidBrush(Color.FromArgb(152, 199, 250)))
                {
                    penRougePointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    penBleuPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    penNoirPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    penCouleurJ1RFleche.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    penCouleurJ1RFleche.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

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

                    while (Thread.CurrentThread.IsAlive)
                    {
                        try
                        {
                            Bitmap bmp = new Bitmap(947, 645);
                            {
                                Graphics g = Graphics.FromImage(bmp);
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                                if (boxTable.Checked)
                                    if(!boxPerspective.Checked)
                                        g.DrawImage(Properties.Resources.TablePlan, 0, 0, 945, 647);
                                    else
                                        g.DrawImage(Properties.Resources.TablePerspective, 0, 0, 945, 647);


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
                                    Plateau.SemaphoreGraph.WaitOne();

                                    // Dessin des arcs
                                    if (boxArretes.Checked)
                                    {
                                        foreach (Arc a in Plateau.Graph.Arcs)
                                        {
                                            if (a.Passable != false)
                                            {
                                                //pen = new Pen(new SolidBrush(Color.Red));

                                                g.DrawLine(penBlanc, RealToScreenPosition(a.StartNode.X, a.StartNode.Y), RealToScreenPosition(a.EndNode.X, a.EndNode.Y));
                                                g.DrawLine(penNoirPointille, RealToScreenPosition(a.StartNode.X, a.StartNode.Y), RealToScreenPosition(a.EndNode.X,a.EndNode.Y));
                                            }
                                        }
                                    }

                                    // Dessin des noeuds
                                    foreach (Node n in Plateau.Graph.Nodes)
                                    {
                                        Point pointNode = RealToScreenPosition(n.Position);
                                        g.FillEllipse(brushNoir, new Rectangle(pointNode.X - 3, pointNode.Y - 3, 6, 6));
                                        g.DrawEllipse(n.Passable ? penBlanc : penRougeFin, new Rectangle(pointNode.X - 3, pointNode.Y - 3, 6, 6));
                                    }

                                    Plateau.SemaphoreGraph.Release();
                                }

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
                                /*if (boxSourisObstacle.Checked)
                                {
                                    g.DrawEllipse(penRougeFin,
                                        (int)(xSouris - RealToScreen(Robots.GrosRobot.Rayon) * 2),
                                        (int)(ySouris - RealToScreen(Robots.GrosRobot.Rayon) * 2), RealToScreen(Robots.GrosRobot.Rayon) * 4, RealToScreen(Robots.GrosRobot.Rayon) * 4);
                                }*/

                                // ************** Dessin des éléments de jeu *************** //

                                // ************** Dessin du gros robot ************** //

                                if (Robots.GrosRobot != null)
                                {
                                    Point positionRobot = RealToScreenPosition(Robots.GrosRobot.Position.Coordonnees);

                                    Bitmap bmpGrosRobot = new Bitmap(RealToScreenDistance(Robots.GrosRobot.Taille * 3), RealToScreenDistance(Robots.GrosRobot.Taille * 3));
                                    Graphics gGros = Graphics.FromImage(bmpGrosRobot);
                                    gGros.FillRectangle(brushTransparent, 0, 0, RealToScreenDistance(Robots.GrosRobot.Taille * 2), RealToScreenDistance(Robots.GrosRobot.Taille * 2));

                                    gGros.FillRectangle(brushBleuClair, bmpGrosRobot.Width / 2 - RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2), RealToScreenDistance(Robots.GrosRobot.Largeur), RealToScreenDistance(Robots.GrosRobot.Longueur));
                                    gGros.DrawRectangle(penCouleurJ2B, bmpGrosRobot.Width / 2 - RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2), RealToScreenDistance(Robots.GrosRobot.Largeur), RealToScreenDistance(Robots.GrosRobot.Longueur));
                                    gGros.DrawLine(penCouleurJ2B, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2, bmpGrosRobot.Width / 2, bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2));

                                    if (Robots.GrosRobot.ServoSorti[ServomoteurID.GRBrasDroit])
                                    {
                                        List<Point> points = new List<Point>();
                                        points.Add(new Point(bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2)));
                                        points.Add(new Point(bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2) + 4, bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2)));
                                        points.Add(new Point(bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2) + 20, bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2) - 20));
                                        points.Add(new Point(bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2) + 16, bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2) - 20));

                                        gGros.FillPolygon(brushBleuClair, points.ToArray<Point>());
                                        gGros.DrawPolygon(penCouleurJ2B, points.ToArray<Point>());
                                    }

                                    if (Robots.GrosRobot.ServoSorti[ServomoteurID.GRBrasGauche])
                                    {
                                        List<Point> points = new List<Point>();
                                        points.Add(new Point(bmpGrosRobot.Width / 2 - RealToScreenDistance(Robots.GrosRobot.Largeur / 2), bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2)));
                                        points.Add(new Point(bmpGrosRobot.Width / 2 - RealToScreenDistance(Robots.GrosRobot.Largeur / 2) - 4, bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2)));
                                        points.Add(new Point(bmpGrosRobot.Width / 2 - RealToScreenDistance(Robots.GrosRobot.Largeur / 2) - 20, bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2) - 20));
                                        points.Add(new Point(bmpGrosRobot.Width / 2 - RealToScreenDistance(Robots.GrosRobot.Largeur / 2) - 16, bmpGrosRobot.Height / 2 - RealToScreenDistance(Robots.GrosRobot.Longueur / 2) - 20));

                                        gGros.FillPolygon(brushBleuClair, points.ToArray<Point>());
                                        gGros.DrawPolygon(penCouleurJ2B, points.ToArray<Point>());
                                    }

                                    if (Robots.GrosRobot.ServoSorti[ServomoteurID.GRPetitBras])
                                    {
                                        gGros.FillRectangle(brushBleuClair,
                                            bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2),
                                            bmpGrosRobot.Height / 2 - 2,
                                            RealToScreenDistance(140),
                                            4);
                                        gGros.DrawRectangle(penCouleurJ2B,
                                            bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2),
                                            bmpGrosRobot.Height / 2 - 2,
                                            RealToScreenDistance(140),
                                            4);
                                    }
                                    if (Robots.GrosRobot.ServoSorti[ServomoteurID.GRPetitBras])
                                    {
                                        gGros.FillRectangle(brushBleuClair,
                                            bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2),
                                            bmpGrosRobot.Height / 2 - 2,
                                            RealToScreenDistance(140),
                                            4);
                                        gGros.DrawRectangle(penCouleurJ2B,
                                            bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2),
                                            bmpGrosRobot.Height / 2 - 2,
                                            RealToScreenDistance(140),
                                            4);
                                    }

                                    if (Robots.GrosRobot.ServoSorti[ServomoteurID.GRGrandBras])
                                    {
                                        gGros.FillRectangle(brushBleuClair,
                                            bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2),
                                            bmpGrosRobot.Height / 2 + 4,
                                            RealToScreenDistance(220),
                                            4);
                                        gGros.DrawRectangle(penCouleurJ2B,
                                            bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2),
                                            bmpGrosRobot.Height / 2 + 4,
                                            RealToScreenDistance(220),
                                            4);
                                    }

                                    if (Robots.GrosRobot.ServoSorti[ServomoteurID.GRAspirateur])
                                    {
                                        gGros.FillRectangle(brushBleuClair,
                                            bmpGrosRobot.Width / 2 - RealToScreenDistance(130),
                                            bmpGrosRobot.Height / 2 + RealToScreenDistance(Robots.GrosRobot.Longueur / 2),
                                            RealToScreenDistance(200),
                                            RealToScreenDistance(50));
                                        gGros.DrawRectangle(penCouleurJ2B,
                                            bmpGrosRobot.Width / 2 - RealToScreenDistance(130),
                                            bmpGrosRobot.Height / 2 + RealToScreenDistance(Robots.GrosRobot.Longueur / 2),
                                            RealToScreenDistance(200),
                                            RealToScreenDistance(50));
                                    }

                                    if (Robots.GrosRobot.MoteurTourne[MoteurID.GRTurbineAspirateur])
                                    {
                                        switch (cptHelice1)
                                        {
                                            case 0:
                                                gGros.DrawImage(Properties.Resources.Helice1, bmpGrosRobot.Width / 2 - 12, bmpGrosRobot.Height / 2 + RealToScreenDistance(Robots.GrosRobot.Longueur / 2) - 4, 16, 16);
                                                break;
                                            case 1:
                                                gGros.DrawImage(Properties.Resources.Helice2, bmpGrosRobot.Width / 2 - 12, bmpGrosRobot.Height / 2 + RealToScreenDistance(Robots.GrosRobot.Longueur / 2) - 4, 16, 16);
                                                break;
                                            case 2:
                                                gGros.DrawImage(Properties.Resources.Helice3, bmpGrosRobot.Width / 2 - 12, bmpGrosRobot.Height / 2 + RealToScreenDistance(Robots.GrosRobot.Longueur / 2) - 4, 16, 16);
                                                break;
                                        }

                                        cptHelice1++;
                                        if (cptHelice1 > 2)
                                            cptHelice1 = 0;
                                    }

                                    if (Robots.GrosRobot.MoteurTourne[MoteurID.GRCanonTMin])
                                    {
                                        switch (cptHelice2)
                                        {
                                            case 0:
                                                gGros.DrawImage(Properties.Resources.Helice1, bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2) - 15, bmpGrosRobot.Height / 2 - 8, 16, 16);
                                                break;
                                            case 1:
                                                gGros.DrawImage(Properties.Resources.Helice2, bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2) - 15, bmpGrosRobot.Height / 2 - 8, 16, 16);
                                                break;
                                            case 2:
                                                gGros.DrawImage(Properties.Resources.Helice3, bmpGrosRobot.Width / 2 + RealToScreenDistance(Robots.GrosRobot.Largeur / 2) - 15, bmpGrosRobot.Height / 2 - 8, 16, 16);
                                                break;
                                        }

                                        cptHelice2++;
                                        if (cptHelice2 > 2)
                                            cptHelice2 = 0;
                                    }

                                    g.DrawImage(RotateImage(bmpGrosRobot, Robots.GrosRobot.Position.Angle.AngleDegres + 90), positionRobot.X - bmpGrosRobot.Width / 2, positionRobot.Y - bmpGrosRobot.Height / 2);

                                    this.Invoke(new EventHandler(delegate
                                    {
                                        lblPosGrosX.Text = Math.Round(Robots.GrosRobot.Position.Coordonnees.X, 2).ToString();
                                        lblPosGrosY.Text = Math.Round(Robots.GrosRobot.Position.Coordonnees.Y, 2).ToString();
                                        lblPosGrosTeta.Text = Robots.GrosRobot.Position.Angle.ToString();
                                    }));
                                }

                                // Fin dessin robot

                                // Dessin du petit robot
                                if (Robots.PetitRobot != null)
                                {
                                    Point positionRobot = RealToScreenPosition(Robots.PetitRobot.Position.Coordonnees);
                                    double angleRobot;
                                    angleRobot = Robots.PetitRobot.Position.Angle.AngleRadians;

                                    Bitmap bmpPetitRobot = new Bitmap(RealToScreenDistance(Robots.PetitRobot.Taille * 2), RealToScreenDistance(Robots.PetitRobot.Taille * 2));
                                    Graphics gPetit = Graphics.FromImage(bmpPetitRobot);
                                    gPetit.FillRectangle(brushTransparent, 0, 0, RealToScreenDistance(Robots.PetitRobot.Taille * 2), RealToScreenDistance(Robots.PetitRobot.Taille * 2));

                                    gPetit.FillRectangle(brushBleuClair, bmpPetitRobot.Width / 2 - RealToScreenDistance(Robots.PetitRobot.Largeur / 2), bmpPetitRobot.Height / 2 - RealToScreenDistance(Robots.PetitRobot.Longueur / 2), RealToScreenDistance(Robots.PetitRobot.Largeur), RealToScreenDistance(Robots.PetitRobot.Longueur));
                                    gPetit.DrawRectangle(penCouleurJ2B, bmpPetitRobot.Width / 2 - RealToScreenDistance(Robots.PetitRobot.Largeur / 2), bmpPetitRobot.Height / 2 - RealToScreenDistance(Robots.PetitRobot.Longueur / 2), RealToScreenDistance(Robots.PetitRobot.Largeur), RealToScreenDistance(Robots.PetitRobot.Longueur));
                                    gPetit.DrawLine(penCouleurJ2B, bmpPetitRobot.Width / 2, bmpPetitRobot.Height / 2, bmpPetitRobot.Width / 2, bmpPetitRobot.Height / 2 - RealToScreenDistance(Robots.PetitRobot.Longueur / 2));

                                    g.DrawImage(RotateImage(bmpPetitRobot, Robots.PetitRobot.Position.Angle.AngleDegres + 90), positionRobot.X - RealToScreenDistance(Robots.PetitRobot.Taille), positionRobot.Y - RealToScreenDistance(Robots.PetitRobot.Taille));

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

                                    if (robot.ObstacleTeste != null)
                                        DessinerForme(g, Color.Green, robot.ObstacleTeste);

                                    if (robot.ObstacleProbleme != null)
                                        DessinerForme(g, Color.Red, robot.ObstacleProbleme);

                                    if (robot.CheminEnCoursNoeuds != null)
                                        foreach (Node n in robot.CheminEnCoursNoeuds)
                                        {
                                            Point positionNode = RealToScreenPosition(n.Position);
                                            g.FillEllipse(brushVert, new Rectangle(positionNode.X - 4, positionNode.Y - 4, 8, 8));
                                        }
                                }
                                // Fin pathfinding


                                // Dessin de la position des ennemis

                                //if (Plateau.InterpreteurBalise.PositionsEnnemies != null)
                                {
                                    for(int i = 0; i < SuiviBalise.PositionsEnnemies.Count; i++)
                                    {
                                        PointReel p = SuiviBalise.PositionsEnnemies[i];
                                        Point positionEcran = RealToScreenPosition(p);

                                        if (p == null)
                                            continue;

                                        double vitesse = Math.Round(Math.Sqrt(SuiviBalise.VecteursPositionsEnnemies[i].X * SuiviBalise.VecteursPositionsEnnemies[i].X + SuiviBalise.VecteursPositionsEnnemies[i].Y * SuiviBalise.VecteursPositionsEnnemies[i].Y));

                                        if (i == 0)
                                        {
                                            lblXEnnemi1.Text = Math.Round(p.X).ToString();
                                            lblYEnnemi1.Text = Math.Round(p.Y).ToString();
                                            lblVitesseEnnemi1.Text = vitesse + " mm/s";
                                        }

                                        if (vitesse < 50)
                                            g.DrawImage(Properties.Resources.Stop, positionEcran.X - Properties.Resources.Stop.Width / 2, positionEcran.Y - Properties.Resources.Stop.Height / 2, Properties.Resources.Stop.Width, Properties.Resources.Stop.Height);
                                        g.FillEllipse(brushCouleurJ1RTransparent, positionEcran.X - RealToScreenDistance(Robots.GrosRobot.Rayon), positionEcran.Y - RealToScreenDistance(Robots.GrosRobot.Rayon), RealToScreenDistance(Robots.GrosRobot.Rayon * 2), RealToScreenDistance(Robots.GrosRobot.Rayon * 2));
                                        g.DrawEllipse(penCouleurJ1R, positionEcran.X - RealToScreenDistance(Robots.GrosRobot.Rayon), positionEcran.Y - RealToScreenDistance(Robots.GrosRobot.Rayon), RealToScreenDistance(Robots.GrosRobot.Rayon * 2), RealToScreenDistance(Robots.GrosRobot.Rayon * 2));
                                        g.DrawLine(penRougeEpais, new Point(positionEcran.X - 7, positionEcran.Y - 7), new Point(positionEcran.X + 7, positionEcran.Y + 7));
                                        g.DrawLine(penRougeEpais, new Point(positionEcran.X - 7, positionEcran.Y + 7), new Point(positionEcran.X + 7, positionEcran.Y - 7));
                                        g.DrawLine(penCouleurJ1RFleche, positionEcran.X, positionEcran.Y, positionEcran.X + RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].X / 3), positionEcran.Y + RealToScreenDistance(SuiviBalise.VecteursPositionsEnnemies[i].Y / 3));
                                        g.DrawString(i + " - " + vitesse + "mm/s", new Font("Calibri", 9, FontStyle.Bold), brushBlanc, positionEcran.X, positionEcran.Y);
                                    }

                                    if (boxDroites.Checked && Plateau.InterpreteurBalise.PositionsEnnemies != null)
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

                                        foreach (PointReelGenere p in Plateau.InterpreteurBalise.Intersections)
                                        {
                                            Point positionEcran = RealToScreenPosition(p.Point);
                                            g.FillEllipse(brushVertFonce, positionEcran.X - 2, positionEcran.Y - 2, 4, 4);
                                        }

                                        foreach (PointReelGenere p in Plateau.InterpreteurBalise.MoyennesIntersections)
                                        {
                                            Point positionEcran = RealToScreenPosition(p.Point);
                                            g.FillEllipse(brushVertFonce, positionEcran.X - 4, positionEcran.Y - 4, 8, 8);
                                        }

                                        foreach (List<PointReel> liste in Plateau.InterpreteurBalise.AssociationPointDistanceIntersection)
                                        {
                                            if (liste[0] == null || liste[1] == null)
                                                continue;
                                            g.DrawLine(penVertFonce, RealToScreenPosition(liste[0].X, liste[0].Y), RealToScreenPosition(liste[1].X, liste[1].Y));
                                        }
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
                                                g.DrawString(Math.Round(m.Cout) + "", police, brushRouge, RealToScreenPosition(m.Position.Coordonnees));
                                        }
                                    }
                                    if (boxCoutPetit.Checked)
                                    {
                                        Font police = new Font("Calibri", 8);
                                        foreach (Mouvement m in Plateau.Enchainement.ListeMouvementsPetit)
                                        {
                                            if (m.Cout != double.MaxValue)
                                                g.DrawString(Math.Round(m.Cout) + "", police, brushVert, RealToScreenPosition(m.Position.Coordonnees));
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

        private Bitmap RotateImage(Bitmap b, double angle)
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
            Point positionEcran = RealToScreenPosition(Cercle.Centre);
            int rayonEcran = RealToScreenDistance(Cercle.Rayon);

            if (!plein)
                using (Pen pen = new Pen(color, 10))
                    graphics.DrawEllipse(pen, new Rectangle(positionEcran.X - rayonEcran, positionEcran.Y - rayonEcran, rayonEcran * 2, rayonEcran * 2));
            else
                using (SolidBrush brush = new SolidBrush(color))
                    graphics.FillEllipse(brush, new Rectangle(positionEcran.X - rayonEcran, positionEcran.Y - rayonEcran, rayonEcran * 2, rayonEcran * 2));
        }

        private void DessinerForme(Graphics graphics, Color color, Segment segment)
        {
            Point positionEcranDepart = RealToScreenPosition(segment.Debut);
            Point positionEcranFin = RealToScreenPosition(segment.Fin);

            using (Pen pen = new Pen(color, 10))
                graphics.DrawLine(pen, positionEcranDepart.X, positionEcranDepart.Y, positionEcranFin.X, positionEcranFin.Y);
        }

        private void DessinerForme(Graphics graphics, Color color, Polygone polygone, bool plein = false)
        {
            if (polygone.Cotes.Count == 0)
                return;

            Point[] listePoints = new Point[polygone.Cotes.Count + 1];

            listePoints[0] = RealToScreenPosition(polygone.Cotes[0].Debut);

            for (int i = 0; i < polygone.Cotes.Count; i++)
            {
                Segment s = polygone.Cotes[i];
                listePoints[i] = RealToScreenPosition(s.Fin);
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

        Thread thAffichage;
        private void btnAffichage_Click(object sender, EventArgs e)
        {
            btnAffichage.Enabled = false;
            thAffichage = new Thread(MAJAffichage);
            thAffichage.Start();
        }

        private void btnSaveGraph_Click(object sender, EventArgs e)
        {
            Plateau.SauverGraph();
            MessageBox.Show("Graph sauvegardé", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        List<Node> cheminNodes;
        List<Arc> cheminArcs;
        DateTime dateCapture = DateTime.Now;

        private void pictureBoxTable_MouseMove(object sender, MouseEventArgs e)
        {
            int xSouris = 0, ySouris = 0;
            //this.Invoke(new EventHandler(delegate
            //    {
            if (modeCourant == Mode.FinTrajectoire)
            {
                PointReel positionReelle = ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
                double distance;
                Node finNode = Plateau.Graph.ClosestNode(positionReelle.X, positionReelle.Y, 0, out distance, false);

                AStar aStar = new AStar(Plateau.Graph);
                if (aStar.SearchPath(debutNode, finNode))
                {
                    cheminNodes = aStar.PathByNodes.ToList<Node>();
                    cheminArcs = aStar.PathByArcs.ToList<Arc>();
                }
            }
            else if (boxSourisObstacle.Checked)
            {
                if((DateTime.Now - dateCapture).TotalMilliseconds > 50)
                //if (xSouris != pictureBoxTable.PointToClient(MousePosition).X || ySouris != pictureBoxTable.PointToClient(MousePosition).Y)
                {
                    dateCapture = DateTime.Now;
                    xSouris = pictureBoxTable.PointToClient(MousePosition).X;
                    ySouris = pictureBoxTable.PointToClient(MousePosition).Y;
                    List<PointReel> positions = new List<PointReel>();
                    positions.Add(ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition)));
                    SuiviBalise.MajPositions(positions, Plateau.Enchainement == null || Plateau.Enchainement.DebutMatch == null);
                    //Plateau.ObstacleTest(ScreenToReal(pictureBoxTable.PointToClient(MousePosition).X), ScreenToReal(pictureBoxTable.PointToClient(MousePosition).Y));
                }
            }

            Point positionSurTable = ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
            lblPos.Text = positionSurTable.X + " : " + positionSurTable.Y;
        }

        #region Conversion coordonnées réelles / écran

        private const double RAPPORT_SCREEN_REAL = 3.7;
        private const int OFFSET_IMAGE_X = 69;
        private const int OFFSET_IMAGE_Y = 48;

        // Ecran vers réel

        private int ScreenToRealDistance(double valeur)
        {
            return (int)(valeur * RAPPORT_SCREEN_REAL);
        }

        private PointReel ScreenToRealPosition(Point valeur)
        {
            return new PointReel(ScreenToRealDistance(valeur.X - OFFSET_IMAGE_X), ScreenToRealDistance(valeur.Y - OFFSET_IMAGE_Y));
        }

        private Point ScreenToRealPosition(double valeurX, double valeurY)
        {
            return new Point(ScreenToRealDistance(valeurX - OFFSET_IMAGE_X), ScreenToRealDistance(valeurY - OFFSET_IMAGE_Y));
        }

        // Réel vers écran

        private int RealToScreenDistance(double valeur)
        {
            return (int)(valeur / RAPPORT_SCREEN_REAL);
        }

        private Point RealToScreenPosition(Point valeur)
        {
            return new Point(RealToScreenDistance(valeur.X) + OFFSET_IMAGE_X, RealToScreenDistance(valeur.Y) + OFFSET_IMAGE_Y);
        }

        private Point RealToScreenPosition(double valeurX, double valeurY)
        {
            return new Point(RealToScreenDistance(valeurX) + OFFSET_IMAGE_X, RealToScreenDistance(valeurY) + OFFSET_IMAGE_Y);
        }

        #endregion

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

        private void PathFinding()
        {
            PointReel positionReelle = ScreenToRealPosition(pictureBoxTable.PointToClient(MousePosition));
            if (modeCourant == Mode.FinTrajectoire)
            {
                if (ev.Button == System.Windows.Forms.MouseButtons.Left)
                    Robots.GrosRobot.PathFinding(positionReelle.X, positionReelle.Y);
                else
                    Robots.PetitRobot.PathFinding(positionReelle.X, positionReelle.Y);

                modeCourant = Mode.Visualisation;
            }
            else
            {
                PointReel point = new PointReel(positionReelle.X, positionReelle.Y);

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
                    if (positionReelle.Y >= 1970)
                    {
                        if (positionReelle.X > Plateau.PositionsCadeaux[i].X - 75 && positionReelle.X < Plateau.PositionsCadeaux[i].X + 75)
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

        private void PanelTable_Load(object sender, EventArgs e)
        {
            if(!Config.DesignMode)
                ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
        }
    }
}
