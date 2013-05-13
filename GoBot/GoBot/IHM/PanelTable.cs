﻿using System;
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
            Pen crayonNoir = new Pen(Color.Black);
            Pen crayonRougePointille = new Pen(Color.Red);
            crayonRougePointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            Pen crayonBleuPointille = new Pen(Color.Blue);
            crayonBleuPointille.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            Pen crayonRougeFin = new Pen(Color.Red);
            Pen crayonBleuFin = new Pen(Color.Blue);
            Pen crayonRouge = new Pen(Color.Red, 3);
            Pen crayonBleu = new Pen(Color.Blue, 3);
            SolidBrush brush = new SolidBrush(Color.Black);

            while (continuerAffichage)
            {
                try
                {
                    Bitmap bmp = new Bitmap(750, 500);
                    Graphics g = Graphics.FromImage(bmp);
                    g.FillRectangle(new SolidBrush(Color.White), 0, 0, 750, 500);

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

                            g.FillEllipse(new SolidBrush(Plateau.CouleurJ1R), RealToScreen(p.X - Robots.GrosRobot.Rayon), RealToScreen(p.Y - Robots.GrosRobot.Rayon), RealToScreen(Robots.GrosRobot.Rayon * 2), RealToScreen(Robots.GrosRobot.Rayon * 2));
                            g.DrawLine(crayonRouge, new Point(RealToScreen(p.X) - 7, RealToScreen(p.Y) - 7), new Point(RealToScreen(p.X) + 7, RealToScreen(p.Y) + 7));
                            g.DrawLine(crayonRouge, new Point(RealToScreen(p.X) - 7, RealToScreen(p.Y) + 7), new Point(RealToScreen(p.X) + 7, RealToScreen(p.Y) - 7));
                        }
                        /*foreach (PointReel p in interprete.PositionsAlliees)
                        {
                            if (p != null)
                            {
                                g.DrawLine(crayonBleu, new Point(RealToScreen(p.X) - 7, RealToScreen(p.Y) - 7), new Point(RealToScreen(p.X) + 7, RealToScreen(p.Y) + 7));
                                g.DrawLine(crayonBleu, new Point(RealToScreen(p.X) - 7, RealToScreen(p.Y) + 7), new Point(RealToScreen(p.X) + 7, RealToScreen(p.Y) - 7));
                            }
                        }*/

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
                                g.DrawLine(crayonRougePointille,
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

                                g.DrawPolygon(crayonRougeFin, points.ToArray());
                                g.DrawLine(crayonRougeFin, new Point(RealToScreen(detection.Position.X) - 4, RealToScreen(detection.Position.Y) - 4), new Point(RealToScreen(detection.Position.X) + 4, RealToScreen(detection.Position.Y) + 4));
                                g.DrawLine(crayonRougeFin, new Point(RealToScreen(detection.Position.X) - 4, RealToScreen(detection.Position.Y) + 4), new Point(RealToScreen(detection.Position.X) + 4, RealToScreen(detection.Position.Y) - 4));
                            }

                            foreach (PointReelGenere p in Plateau.InterpreteurBalise.Intersections)
                            {
                                g.FillEllipse(new SolidBrush(Color.DarkGreen), RealToScreen(p.Point.X) - 2, RealToScreen(p.Point.Y) - 2, 4, 4);
                            }

                            /*foreach (PointReel p in interprete.MoyennesDistance)
                            {
                                g.FillEllipse(new SolidBrush(Color.Red), RealToScreen(p.X) - 4, RealToScreen(p.Y) - 4, 6, 6);
                            }*/

                            foreach (PointReelGenere p in Plateau.InterpreteurBalise.MoyennesIntersections)
                            {
                                g.FillEllipse(new SolidBrush(Color.DarkGreen), RealToScreen(p.Point.X) - 4, RealToScreen(p.Point.Y) - 4, 8, 8);
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
                                g.DrawLine(new Pen(Color.DarkGreen), new Point(RealToScreen(liste[0].X), RealToScreen(liste[0].Y)), new Point(RealToScreen(liste[1].X), RealToScreen(liste[1].Y)));
                            }
                        }
                    }

                    // Dessin des obstacles
                    if (boxObstacles.Checked)
                    {
                        g.FillRectangle(new SolidBrush(Color.White), 0, 0, 3000, 2000);

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
                                Pen pen = new Pen(new SolidBrush(Color.White));
                                Pen penDot = new Pen(new SolidBrush(Color.Black));
                                penDot.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                                if (a.Passable != false)
                                {
                                    //pen = new Pen(new SolidBrush(Color.Red));

                                    g.DrawLine(pen, new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                                    g.DrawLine(penDot, new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                                }
                            }
                        }

                        // Dessin des noeuds
                        foreach (Node n in Plateau.Graph.Nodes)
                        {
                            Pen pen = new Pen(new SolidBrush(Color.White));
                            if (n.Passable == false)
                                pen = new Pen(new SolidBrush(Color.Red));
                            g.FillEllipse(brush, new Rectangle(RealToScreen(n.X) - 3, RealToScreen(n.Y) - 3, 6, 6));
                            g.DrawEllipse(pen, new Rectangle(RealToScreen(n.X) - 3, RealToScreen(n.Y) - 3, 6, 6));
                        }

                        Plateau.SemaphoreGraph.Release();
                    }

                    // Dessin de la trajectoire en cours de recherche
                    if (modeCourant == Mode.FinTrajectoire && cheminArcs != null)
                    {
                        foreach (Arc a in cheminArcs)
                        {
                            g.DrawLine(new Pen(new SolidBrush(Color.BlueViolet)), new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                        }
                        foreach (Node n in cheminNodes)
                        {
                            g.DrawEllipse(new Pen(new SolidBrush(Color.BlueViolet)), new Rectangle(RealToScreen(n.Position.X) - 3, RealToScreen(n.Position.Y) - 3, 6, 6));
                        }
                    }
                    /*// Dessin  de la trajectoire en cours de parcours
                    else if (Plateau.CheminEnCoursNoeuds != null && Plateau.CheminEnCoursNoeuds.Count > 1)
                    {
                        foreach (Arc a in Plateau.CheminEnCoursArcs)
                        {
                            g.DrawLine(new Pen(Color.Firebrick, 3), new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                        }
                        foreach (Node n in Plateau.CheminEnCoursNoeuds)
                        {
                            g.FillEllipse(new SolidBrush(Color.Firebrick), new Rectangle(RealToScreen(n.Position.X) - 4, RealToScreen(n.Position.Y) - 4, 8, 8));
                        }
                    }*/
                    if (boxSourisObstacle.Checked)
                    {
                        g.DrawEllipse(crayonRougeFin,
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
                            if(!Plateau.AssiettesVidees[i])
                                g.DrawImage(rotateImage(Properties.Resources.AssiettePleineBleu, Plateau.PositionsAssiettes[i].Angle.AngleDegres), RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.X) - 61 / 2, RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.Y) - 61 / 2, 61, 61);
                            else
                                g.DrawImage(rotateImage(Properties.Resources.AssietteVide, Plateau.PositionsAssiettes[i].Angle.AngleDegres), RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.X) - 61 / 2, RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.Y) - 61 / 2, 61, 61);

                    }
                    for (int i = 5; i < 10; i++)
                    {
                        if (Plateau.AssiettesExiste[i])
                            if(!Plateau.AssiettesVidees[i])
                                g.DrawImage(rotateImage(Properties.Resources.AssiettePleineRouge, Plateau.PositionsAssiettes[i].Angle.AngleDegres), RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.X) - 61 / 2, RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.Y) - 61 / 2, 61, 61);
                            else
                                g.DrawImage(rotateImage(Properties.Resources.AssietteVide, Plateau.PositionsAssiettes[i].Angle.AngleDegres), RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.X) - 61 / 2, RealToScreen(Plateau.PositionsAssiettes[i].Coordonnees.Y) - 61 / 2, 61, 61);
                    }
                    /*
                    double[,] valeurs = new double[pictureBoxTable.Width, pictureBoxTable.Height];
                    double min = double.MaxValue, max = double.MinValue;
                    for (int i = 0; i < pictureBoxTable.Width; i++)
                    {
                        for (int j = 0; j < pictureBoxTable.Height; j++)
                        {
                            double valeur = 0;

                            PointReel point20 = new PointReel(ScreenToReal(i), ScreenToReal(j));
                            double distance = Robots.GrosRobot.Position.Coordonnees.Distance(point20) / 10;
                            valeur = distance * distance * distance;

                            Plateau.SemaphoreGraph.WaitOne();
                            foreach (Cercle c in Plateau.ObstaclesTemporaires)
                            {
                                double distanceAdv = point20.Distance(c.Centre) / 10;
                                    valeur /= (distanceAdv * distanceAdv * distanceAdv);
                            }
                            Plateau.SemaphoreGraph.Release();

                            valeurs[i, j] = valeur;
                        }
                    }

                    for (int i = 0; i < pictureBoxTable.Width; i++)
                    {
                        for (int j = 0; j < pictureBoxTable.Height; j++)
                        {
                            valeurs[i, j] = Math.Log10(valeurs[i, j]);
                            if (valeurs[i, j] < 0)
                                valeurs[i, j] = 0;
                        }
                    }

                    for (int i = 0; i < pictureBoxTable.Width; i++)
                    {
                        for (int j = 0; j < pictureBoxTable.Height; j++)
                        {
                            min = Math.Min(min, valeurs[i, j]);
                            max = Math.Max(max, valeurs[i, j]);
                        }
                    }

                    for (int i = 0; i < pictureBoxTable.Width; i++)
                    {
                        for (int j = 0; j < pictureBoxTable.Height; j++)
                        {
                            if (valeurs[i, j] == 0)
                                valeurs[i, j] = max;
                            int val = (int)((valeurs[i, j] - min) / (max - min) * 255);
                            bmp.SetPixel(i, j, Color.FromArgb(val, val, val));
                        }
                    }*/

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
                        g.DrawPolygon(new Pen(Plateau.CouleurJ2B), tabPoints);

                        double angle = Robots.GrosRobot.Position.Angle.AngleRadians + (-180 * 2 * Math.PI / 360);
                        double cos = Math.Cos(angle);
                        double sin = Math.Sin(angle);
                        Point pointDevant = new Point(Maths.Arrondi(xRobot - cos * RealToScreen(Maths.Arrondi(Robots.GrosRobot.Longueur / 2))), Maths.Arrondi(yRobot - sin * RealToScreen(Maths.Arrondi(Robots.GrosRobot.Longueur / 2))));

                        g.DrawLine(new Pen(Plateau.CouleurJ2B), new Point(xRobot, yRobot), pointDevant);

                        this.Invoke(new EventHandler(delegate
                        {
                            lblPosGrosX.Text = Math.Round(Robots.GrosRobot.Position.Coordonnees.X, 2).ToString();
                            lblPosGrosY.Text = Math.Round(Robots.GrosRobot.Position.Coordonnees.Y, 2).ToString();
                            lblPosGrosTeta.Text = Robots.GrosRobot.Position.Angle.ToString();
                        }));

                        if (Robots.GrosRobot.BallesChargees)
                        {
                            g.DrawImage(rotateImage(Properties.Resources.Balles, Robots.GrosRobot.Position.Angle.AngleDegres), RealToScreen(Robots.GrosRobot.Position.Coordonnees.X) - 61 / 2, RealToScreen(Robots.GrosRobot.Position.Coordonnees.Y) - 61 / 2, 61, 61);
                        }

                        /*
                        // Avant de lancer le match on retire les assiettes
                        if (Plateau.Enchainement == null)
                            for (int i = 0; i < 10; i++)
                            {
                                if (Plateau.PositionsAssiettes[i].Coordonnees.Distance(Robots.GrosRobot.Position.Coordonnees) < 250)
                                    Plateau.AssiettesExiste[i] = false;
                            }*/
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
                        g.DrawPolygon(new Pen(Plateau.CouleurJ2B), tabPoints);

                        double angle = Robots.PetitRobot.Position.Angle.AngleRadians + (-180 * 2 * Math.PI / 360);
                        double cos = Math.Cos(angle);
                        double sin = Math.Sin(angle);
                        Point pointDevant = new Point(Maths.Arrondi(xRobot - cos * RealToScreen(Maths.Arrondi(Robots.PetitRobot.Longueur / 2))), Maths.Arrondi(yRobot - sin * RealToScreen(Maths.Arrondi(Robots.PetitRobot.Longueur / 2))));

                        g.DrawLine(new Pen(Plateau.CouleurJ2B), new Point(xRobot, yRobot), pointDevant);

                        lblPosPetitX.Text = Math.Round(Robots.PetitRobot.Position.Coordonnees.X, 2).ToString();
                        lblPosPetitY.Text = Math.Round(Robots.PetitRobot.Position.Coordonnees.Y, 2).ToString();
                        lblPosPetitTeta.Text = Robots.PetitRobot.Position.Angle.ToString();
                        /*
                        // Avant de lancer le match
                        if (Plateau.Enchainement == null)
                            for (int i = 0; i < 10; i++)
                            {
                                if (Plateau.PositionsAssiettes[i].Coordonnees.Distance(Robots.PetitRobot.Position.Coordonnees) < 250)
                                    Plateau.AssiettesExiste[i] = false;
                            }*/
                    }


                    // Dessin pathfinding

                    Robot[] robots = new Robot[2];
                    robots[0] = Robots.GrosRobot;
                    robots[1] = Robots.PetitRobot;

                    foreach (Robot robot in robots)
                    {
                        foreach (Node n in robot.NodeTrouve)
                            g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(RealToScreen(n.Position.X) - 4, RealToScreen(n.Position.Y) - 4, 8, 8));

                        foreach (Arc a in robot.CheminTrouve)
                        {
                            g.DrawLine(new Pen(Color.Orange, 3), new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                        }

                        if (robot.CheminEnCoursNoeuds != null && robot.CheminEnCoursNoeuds.Count > 1)
                        {
                            Segment seg = new Segment(new PointReel(robot.CheminEnCoursNoeuds[1].X, robot.CheminEnCoursNoeuds[1].Y), robot.Position.Coordonnees);
                            g.DrawLine(new Pen(Color.Green, 3), new Point(RealToScreen(robot.CheminEnCoursNoeuds[1].X), RealToScreen(robot.CheminEnCoursNoeuds[1].Y)), new Point(RealToScreen(robot.Position.Coordonnees.X), RealToScreen(robot.Position.Coordonnees.Y)));
                            for (int i = 1; i < robot.CheminEnCoursArcs.Count; i++)
                            {
                                Arc a = robot.CheminEnCoursArcs[i];
                                g.DrawLine(new Pen(Color.Green, 3), new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                            }
                        }

                        if (robot.CheminTest != null)
                            g.DrawLine(new Pen(Color.Red, 3), new Point(RealToScreen(robot.CheminTest.StartNode.Position.X), RealToScreen(robot.CheminTest.StartNode.Position.Y)), new Point(RealToScreen(robot.CheminTest.EndNode.Position.X), RealToScreen(robot.CheminTest.EndNode.Position.Y)));

                        if (robot.ObstacleTeste != null)
                            DessinerForme(g, Color.Green, robot.ObstacleTeste);

                        if (robot.ObstacleProbleme != null)
                            DessinerForme(g, Color.Red, robot.ObstacleProbleme);

                        if (robot.CheminEnCoursNoeuds != null)
                            foreach (Node n in robot.CheminEnCoursNoeuds)
                                g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(RealToScreen(n.Position.X) - 4, RealToScreen(n.Position.Y) - 4, 8, 8));
                    }
                    // Fin pathfinding

                    // Dessin des bougies

                    PointReel point = new PointReel(xTable, yTable);

                    for (int i = 0; i < 20; i++)
                    {
                        g.FillEllipse(new SolidBrush(Plateau.CouleursBougies[i]), RealToScreen(Plateau.PositionsBougies[i].X - 40), RealToScreen(Plateau.PositionsBougies[i].Y - 40), RealToScreen(80), RealToScreen(80));
                        g.DrawEllipse(new Pen(Color.Black), RealToScreen(Plateau.PositionsBougies[i].X - 40), RealToScreen(Plateau.PositionsBougies[i].Y - 40), RealToScreen(80), RealToScreen(80));

                        if (Plateau.BougiesEnfoncees[i])
                        {
                            g.FillEllipse(new SolidBrush(Color.Black), RealToScreen(Plateau.PositionsBougies[i].X - 20), RealToScreen(Plateau.PositionsBougies[i].Y - 20), RealToScreen(40), RealToScreen(40));
                            g.DrawEllipse(new Pen(Color.White), RealToScreen(Plateau.PositionsBougies[i].X - 20), RealToScreen(Plateau.PositionsBougies[i].Y - 20), RealToScreen(40), RealToScreen(40));
                        }

                        else if (Plateau.PositionsBougies[i].Distance(point) <= 40)
                        {
                            g.DrawEllipse(new Pen(Color.LightGreen, 3), RealToScreen(Plateau.PositionsBougies[i].X - 40), RealToScreen(Plateau.PositionsBougies[i].Y - 40), RealToScreen(80), RealToScreen(80));
                        }
                    }

                    // Dessin des cadeaux

                    for (int i = 0; i < 8; i++)
                    {
                        Color color = i % 2 == 1 ? Plateau.CouleurJ1R : Plateau.CouleurJ2B;
                        if (!Plateau.CadeauxActives[i])
                        {
                            g.FillRectangle(new SolidBrush(color), RealToScreen(Plateau.PositionsCadeaux[i].X - 75), RealToScreen(Plateau.PositionsCadeaux[i].Y - 30), RealToScreen(150), RealToScreen(40));
                            g.DrawRectangle(new Pen(Color.Black), RealToScreen(Plateau.PositionsCadeaux[i].X - 75), RealToScreen(Plateau.PositionsCadeaux[i].Y - 30), RealToScreen(150), RealToScreen(40));
                        }

                        if (!Plateau.CadeauxActives[i] && yTable >= 1970)
                        {
                            if (xTable > Plateau.PositionsCadeaux[i].X - 75 && xTable < Plateau.PositionsCadeaux[i].X + 75)
                                g.DrawRectangle(new Pen(Color.LightGreen, 3), RealToScreen(Plateau.PositionsCadeaux[i].X - 75), RealToScreen(Plateau.PositionsCadeaux[i].Y - 30), RealToScreen(150), RealToScreen(40));
                        }
                    }

                    // Dessin des coûts des mouvements

                    if (Plateau.Enchainement != null)
                    {
                        if (boxCoutGros.Checked)
                        {
                            Font police = new Font("Calibri", 8);
                            SolidBrush brushPolice = new SolidBrush(Color.Red);
                            foreach (Mouvement m in Plateau.Enchainement.ListeMouvementsGros)
                            {
                                if (m.Cout != double.MaxValue)
                                    g.DrawString(Math.Round(m.Cout) + "", police, brushPolice, new PointF(RealToScreen(m.Position.Coordonnees.X), RealToScreen((float)m.Position.Coordonnees.Y)));
                            }
                        }
                        if (boxCoutPetit.Checked)
                        {
                            Font police = new Font("Calibri", 8);
                            SolidBrush brushPolice = new SolidBrush(Color.Blue);
                            foreach (Mouvement m in Plateau.Enchainement.ListeMouvementsPetit)
                            {
                                if (m.Cout != double.MaxValue)
                                    g.DrawString(Math.Round(m.Cout) + "", police, brushPolice, new PointF(RealToScreen(m.Position.Coordonnees.X), RealToScreen((float)m.Position.Coordonnees.Y)));
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
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur pendant le dessin de la table");
                }
            }
        }

        private Bitmap rotateImage(Bitmap b, double angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
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
                graphics.DrawEllipse(new Pen(new SolidBrush(color), 10), new Rectangle(RealToScreen(Cercle.Centre.X) - RealToScreen(Cercle.Rayon), RealToScreen(Cercle.Centre.Y) - RealToScreen(Cercle.Rayon), RealToScreen(Cercle.Rayon * 2), RealToScreen(Cercle.Rayon * 2)));
            else
                graphics.FillEllipse(new SolidBrush(color), new Rectangle(RealToScreen(Cercle.Centre.X) - RealToScreen(Cercle.Rayon), RealToScreen(Cercle.Centre.Y) - RealToScreen(Cercle.Rayon), RealToScreen(Cercle.Rayon * 2), RealToScreen(Cercle.Rayon * 2)));
        }

        private void DessinerForme(Graphics graphics, Color color, Segment segment)
        {
            graphics.DrawLine(new Pen(new SolidBrush(color), 10), RealToScreen(segment.Debut.X), RealToScreen(segment.Debut.Y), RealToScreen(segment.Fin.X), RealToScreen(segment.Fin.Y));
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
                graphics.DrawPolygon(new Pen(new SolidBrush(color), 10), listePoints);
            else
                graphics.FillPolygon(new SolidBrush(color), listePoints, System.Drawing.Drawing2D.FillMode.Winding);
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
