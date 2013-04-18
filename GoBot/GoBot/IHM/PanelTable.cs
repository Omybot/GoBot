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
        Plateau Plateau { get; set; }

        Mode modeCourant;

        public PanelTable()
        {
            InitializeComponent();
            Plateau = new Plateau();
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

            while (true)
            {
                try
                {
                    Bitmap bmp = new Bitmap(750, 500);
                    Graphics g = Graphics.FromImage(bmp);
                    g.FillRectangle(new SolidBrush(Color.White), 0, 0, 750, 500);

                    if (boxTable.Checked)
                        g.DrawImage(Properties.Resources.table, 0, 0);

                    if (Plateau.InterpreteurBalise.PositionsEnnemies != null)
                    {
                        foreach (PointReel p in Plateau.InterpreteurBalise.PositionsEnnemies)
                        {
                            if (p == null)
                                continue;

                            g.FillEllipse(new SolidBrush(Plateau.CouleurJ1), RealToScreen(p.X - Plateau.GrosRobot.Rayon), RealToScreen(p.Y - Plateau.GrosRobot.Rayon), RealToScreen(Plateau.GrosRobot.Rayon * 2), RealToScreen(Plateau.GrosRobot.Rayon * 2));
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
                    // Dessin  de la trajectoire en cours de parcours
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
                    }
                    if (boxSourisObstacle.Checked)
                    {
                        g.DrawEllipse(crayonRougeFin,
                            (int)(xSouris - RealToScreen(Robots.GrosRobot.Rayon) * 2),
                            (int)(ySouris - RealToScreen(Robots.GrosRobot.Rayon) * 2), RealToScreen(Robots.GrosRobot.Rayon) * 4, RealToScreen(Robots.GrosRobot.Rayon) * 4); 
                    }

                    // Dessin du robot
                    int xRobot, yRobot;
                    double angleRobot;
                    xRobot = RealToScreen(Robots.GrosRobot.Position.Coordonnees.X);
                    yRobot = RealToScreen(Robots.GrosRobot.Position.Coordonnees.Y);
                    angleRobot = Robots.GrosRobot.Position.Angle.AngleRadians + (90 * Math.PI / 360);

                    Point p1, p2, p3, p4;
                    double miDiago = RealToScreen((int)Math.Round((Math.Sqrt(2 * (Robots.GrosRobot.Taille * Robots.GrosRobot.Taille))) / 2));
                    double sinAngle = Math.Sin(angleRobot);
                    double cosAngle = Math.Cos(angleRobot);

                    p1 = new Point((int)Math.Round(xRobot + cosAngle * miDiago), (int)Math.Round(yRobot + sinAngle * miDiago));
                    p2 = new Point((int)Math.Round(xRobot + sinAngle * miDiago), (int)Math.Round(yRobot - cosAngle * miDiago));
                    p3 = new Point((int)Math.Round(xRobot - cosAngle * miDiago), (int)Math.Round(yRobot - sinAngle * miDiago));
                    p4 = new Point((int)Math.Round(xRobot - sinAngle * miDiago), (int)Math.Round(yRobot + cosAngle * miDiago));

                    Point[] tabPoints = new Point[4];
                    tabPoints[0] = p1;
                    tabPoints[1] = p2;
                    tabPoints[2] = p3;
                    tabPoints[3] = p4;

                    g.FillPolygon(new SolidBrush(Plateau.CouleurJ2), tabPoints);
                    g.DrawPolygon(new Pen(Color.Black), tabPoints);

                    //Point pointDevant = new Point(Maths.ArCercleir(xRobot - cosAngle * realToScreen(Maths.ArCercleir(Robot.Taille / 2))), Maths.ArCercleir(yRobot - sinAngle * realToScreen(Maths.ArCercleir(Robot.Taille / 2))));
                    double angle = Robots.GrosRobot.Position.Angle.AngleRadians + (-180 * 2 * Math.PI / 360);
                    double cos = Math.Cos(angle);
                    double sin = Math.Sin(angle);
                    Point pointDevant = new Point(Maths.ArCercleir(xRobot - cos * RealToScreen(Maths.ArCercleir(Robots.GrosRobot.Taille / 2))), Maths.ArCercleir(yRobot - sin * RealToScreen(Maths.ArCercleir(Robots.GrosRobot.Taille / 2))));

                    g.DrawLine(new Pen(Color.Red), new Point(xRobot, yRobot), pointDevant);

                    // Fin dessin robot

                    // Dessin pathfinding

                    foreach (Node n in Plateau.NodeTrouve) 
                        g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(RealToScreen(n.Position.X) - 4, RealToScreen(n.Position.Y) - 4, 8, 8));

                    foreach (Arc a in Plateau.CheminTrouve)
                    {
                        g.DrawLine(new Pen(Color.Orange, 3), new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                    }
                    foreach (Arc a in Plateau.CheminEnCoursArcs)
                    {
                        g.DrawLine(new Pen(Color.Green, 3), new Point(RealToScreen(a.StartNode.Position.X), RealToScreen(a.StartNode.Position.Y)), new Point(RealToScreen(a.EndNode.Position.X), RealToScreen(a.EndNode.Position.Y)));
                    }
                    if (Plateau.CheminTest != null)
                        g.DrawLine(new Pen(Color.Red, 3), new Point(RealToScreen(Plateau.CheminTest.StartNode.Position.X), RealToScreen(Plateau.CheminTest.StartNode.Position.Y)), new Point(RealToScreen(Plateau.CheminTest.EndNode.Position.X), RealToScreen(Plateau.CheminTest.EndNode.Position.Y)));
                    
                    if (Plateau.ObstacleTeste != null)
                        DessinerForme(g, Color.Green, Plateau.ObstacleTeste); 
                    
                    if (Plateau.ObstacleProbleme != null)
                        DessinerForme(g, Color.Red, Plateau.ObstacleProbleme);

                    if( Plateau.CheminEnCoursNoeuds != null)
                    foreach (Node n in Plateau.CheminEnCoursNoeuds)
                        g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(RealToScreen(n.Position.X) - 4, RealToScreen(n.Position.Y) - 4, 8, 8));

                    // Fin pathfinding

                    // Dessin des bougies

                    for (int i = 0; i < 20; i++)
                    {
                        g.FillEllipse(new SolidBrush(Plateau.CouleursBougies[i]), RealToScreen(Plateau.PositionsBougies[i, 0]), RealToScreen(Plateau.PositionsBougies[i, 1]), RealToScreen(80), RealToScreen(80));
                        g.DrawEllipse(new Pen(Color.Black), RealToScreen(Plateau.PositionsBougies[i, 0]), RealToScreen(Plateau.PositionsBougies[i, 1]), RealToScreen(80), RealToScreen(80));
                    }

                    pictureBoxTable.Image = bmp;
                }
                catch (Exception)
                {
                    Console.WriteLine("Erreur pendant le dessin de la table");
                }
            }
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

        int xSouris =0, ySouris=0;
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
                if (Plateau.ObstacleTest(ScreenToReal(pictureBoxTable.PointToClient(MousePosition).X), ScreenToReal(pictureBoxTable.PointToClient(MousePosition).Y)))
                {
                    xSouris = pictureBoxTable.PointToClient(MousePosition).X;
                    ySouris = pictureBoxTable.PointToClient(MousePosition).Y;
                }
            }
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

        private void pictureBoxTable_Click(object sender, EventArgs e)
        {
            if (modeCourant == Mode.FinTrajectoire)
            {
                Plateau.GrosRobotAllerA(ScreenToReal(pictureBoxTable.PointToClient(MousePosition).X), ScreenToReal(pictureBoxTable.PointToClient(MousePosition).Y));
                modeCourant = Mode.Visualisation;
            }
        }
    }
}
