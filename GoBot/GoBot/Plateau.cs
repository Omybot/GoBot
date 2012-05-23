using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using AStarFolder;
using GoBot.Calculs.Formes;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using GoBot.Calculs;

namespace GoBot
{
    class Plateau
    {
        public static Balise Balise1 { get; set; }
        public static Balise Balise2 { get; set; }
        public static Balise Balise3 { get; set; }
        public static InterpreteurBalise InterpreteurBalise { get; set; }
        public static Color NotreCouleur { get; set; }

        private static int LONGUEUR_PLATEAU = 3000;
        private static int LARGEUR_PLATEAU = 2000;

        private static Color COULEURJ1 = Color.FromArgb(32, 50, 123);
        private static Color COULEURJ2 = Color.FromArgb(248, 215, 82);

        private static Robot robot;
        private static Robot adversaire;
        private static List<IForme> obstacles;

        private static Graph graph;

        public Plateau()
        {
            robot = new Robot(new Position(new Angle(0, AnglyeType.Degre), new PointReel(220, 220)), Plateau.CouleurJ1);
            adversaire = new Robot(new Position(new Angle(0, AnglyeType.Degre), new PointReel(2400, 200)), Plateau.CouleurJ2);
            creerSommets();

            chargerGraph();
            chargerObstacles();
        }

        public static void Init()
        {
            Balise1 = new Balise(Carte.RecBun);
            Balise2 = new Balise(Carte.RecBeu);
            Balise3 = new Balise(Carte.RecBoi);

            InterpreteurBalise = new InterpreteurBalise();
        }

        public static Balise GetBalise(Carte carte)
        {
            switch (carte)
            {
                case Carte.RecBun:
                    return Balise1;
                case Carte.RecBeu:
                    return Balise2;
                case Carte.RecBoi:
                    return Balise3;
            }

            return null;
        }

        public void ajouterObstacle(IForme obstacle, bool fixe = false)
        {
            obstacles.Add(obstacle);

            for(int i = 0; i < ListeArcs.Count; i++)
            {
                Arc arc = (Arc)ListeArcs[i];

                if (arc.Passable)
                {
                    Segment segment = new Segment(new PointReel(arc.StartNode.X, arc.StartNode.Y), new PointReel(arc.EndNode.X, arc.EndNode.Y));
                    if (obstacle.getDistance(segment) < Robot.Rayon)
                    {
                        if (fixe)
                        {
                            graph.RemoveArc(i);
                            i--;
                        }
                        else
                            arc.Passable = false;
                    }
                }
            }

            for(int i = 0; i < ListeNodes.Count; i++)
            {
                Node n = (Node)ListeNodes[i];

                if (n.Passable)
                {
                    PointReel noeud = new PointReel(n.X, n.Y);
                    if (obstacle.getDistance(noeud) < Robot.Rayon)
                    {
                        if (fixe)
                        {
                            graph.RemoveNode(i);
                            i--;
                        }
                        else
                            n.Passable = false;

                    }
                }
            }
        }


        public Node findCloserNode(Point p, out double distance)
        {
            Node retour = graph.ClosestNode(p.X, p.Y, 0, out distance, true);
            return retour;
        }

        public void sauverGraph()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("graph.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, graph);
            stream.Close();
        }

        public void chargerGraph()
        {

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("graph.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            graph = (Graph)formatter.Deserialize(stream);
            stream.Close();
        }

        private void creerSommets()
        {
            graph = new Graph();

            for (int x = 0; x < 3000; x += 100)
            {
                for (int y = 0; y < 2000; y += 100)
                {
                    graph.AddNode(x, y, 0); 
                }
            }

            Node positionRobot = new Node(220, 220, 0);
            graph.AddNode(positionRobot);

            Node n1 = new Node(1325, 800, 0);
            Node n2 = new Node(1325, 1200, 0);
            Node n3 = new Node(1675, 800, 0);
            Node n4 = new Node(1675, 1200, 0);

            graph.AddNode(n1);
            graph.AddNode(n2);
            graph.AddNode(n3);
            graph.AddNode(n4);

            foreach (Node n in graph.Nodes)
            {
                foreach (Node no in graph.Nodes)
                {
                    if (n != no)
                    {
                        double distance = Math.Sqrt((n.Position.X - no.Position.X) * (n.Position.X - no.Position.X) + (n.Position.Y - no.Position.Y) * (n.Position.Y - no.Position.Y));
                        if (distance < 60000)
                        {
                            Arc b = new Arc(no, n);
                            b.Weight = 5000 - distance;
                            graph.AddArc(b);
                        }
                    }
                }
            }


            graph.AddArc(new Arc(n1, n2));
            graph.AddArc(new Arc(n3, n4));
        }

        public void setConfigStartRobot(float angleDepart, float angleEvit)
        {
            robot.Position.Angle.setAngle(angleDepart, AnglyeType.Degre);
        }

        public void chargerObstacles()
        {
            obstacles = new List<IForme>();

            // Contours du plateau
            ajouterObstacle(new Calculs.Formes.Segment(new PointReel(0, 0), new PointReel(LongueurPlateau - 4, 0)), true);
            ajouterObstacle(new Calculs.Formes.Segment(new PointReel(LongueurPlateau - 4, 0), new PointReel(LongueurPlateau - 4, LargeurPlateau - 4)), true);
            ajouterObstacle(new Calculs.Formes.Segment(new PointReel(LongueurPlateau - 4, LargeurPlateau - 4), new PointReel(0, LargeurPlateau - 4)), true);
            ajouterObstacle(new Calculs.Formes.Segment(new PointReel(0, LargeurPlateau - 4), new PointReel(0, 0)), true);

            // Totem gauche
            List<PointReel> points = new List<PointReel>();

            points.Add(new PointReel(975, 875));
            points.Add(new PointReel(1225, 875));
            points.Add(new PointReel(1225, 1125));
            points.Add(new PointReel(975, 1125));

            ajouterObstacle(new Polygone(points), true);

            // Totem droit

            points.Clear();

            points.Add(new PointReel(1775, 875));
            points.Add(new PointReel(2025, 875));
            points.Add(new PointReel(2025, 1125));
            points.Add(new PointReel(1775, 1125));

            ajouterObstacle(new Polygone(points), true);

            // Arbre

            ajouterObstacle(new Cercle(new PointReel(1500, 1000), 75), true);

            // Bordure cale/depart rouge

            points.Clear();

            points.Add(new PointReel(2600, 500));
            points.Add(new PointReel(3000, 500));
            points.Add(new PointReel(3000, 518));
            points.Add(new PointReel(2600, 518));

            ajouterObstacle(new Polygone(points), true);

            // Bordure cale/depart violet

            points.Clear();

            points.Add(new PointReel(0, 500));
            points.Add(new PointReel(400, 500));
            points.Add(new PointReel(400, 518));
            points.Add(new PointReel(0, 518));

            ajouterObstacle(new Polygone(points), true);

            // Bordure cale violet

            points.Clear();

            points.Add(new PointReel(3000 - 363, 1250));
            points.Add(new PointReel(3000 - 381, 1251));
            points.Add(new PointReel(3000 - 343, 2000));
            points.Add(new PointReel(3000 - 325, 2000));

            ajouterObstacle(new Polygone(points), true);

            // Bordure cale rouge

            points.Clear();

            points.Add(new PointReel(363, 1250));
            points.Add(new PointReel(381, 1251));
            points.Add(new PointReel(343, 2000));
            points.Add(new PointReel(325, 2000));

            ajouterObstacle(new Polygone(points), true);
        }

        public static Color CouleurJ1
        {
            get
            {
                return COULEURJ1;
            }
        }

        public static Color CouleurJ2
        {
            get
            {
                return COULEURJ2;
            }
        }

        public static int LongueurPlateau
        {
            get
            {
                return LONGUEUR_PLATEAU;
            }
        }

        public static int LargeurPlateau
        {
            get
            {
                return LARGEUR_PLATEAU;
            }
        }

        public Robot Robot
        {
            get
            {
                return robot;
            }
        }

        public List<IForme> ListeObstacles
        {
            get
            {
                return obstacles;
            }
        }

        public IList ListeNodes
        {
            get
            {
                return graph.Nodes;
            }
        }

        public IList ListeArcs
        {
            get
            {
                return graph.Arcs;
            }
        }

        public Graph Graph
        {
            get
            {
                return graph;
            }
        }

        public void addNode(Node node)
        {
            foreach (IForme obstacle in obstacles)
            {
                if (obstacle.contient(new PointReel(node.X, node.Y)))
                {
                    node.Passable = false;
                    break;
                }
            }

            graph.Nodes.Add(node);

            foreach (Node no in graph.Nodes)
            {
                if (node != no)
                {
                    double distance = Math.Sqrt((node.Position.X - no.Position.X) * (node.Position.X - no.Position.X) + (node.Position.Y - no.Position.Y) * (node.Position.Y - no.Position.Y));
                    if (distance < 100000)
                    {
                        Arc arc = new Arc(no, node);
                        arc.Weight = 5000 - distance;

                        foreach (IForme obstacle in obstacles)
                        {
                            if (obstacle.croise(new Segment(new PointReel(no.X, no.Y), new PointReel(node.X, node.Y))))
                            {
                                arc.Passable = false;
                                break;
                            }
                        }

                        graph.AddArc(arc);
                    }
                }
            }
        }

        public static bool Contient(PointReel croisement)
        {
            if (croisement.X < 0 || croisement.Y < 0 || croisement.X > LONGUEUR_PLATEAU || croisement.Y > LARGEUR_PLATEAU)
                return false;

            return true;
        }
    }
}
