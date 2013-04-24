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
using GoBot.Ponderations;

namespace GoBot
{
    public class Plateau
    {
        public static Balise Balise1 { get; set; }
        public static Balise Balise2 { get; set; }
        public static Balise Balise3 { get; set; }
        public static InterpreteurBalise InterpreteurBalise { get; set; }

        public static Poids PoidActions { get; set; }

        private static List<IForme> ObstaclesFixes { get; set; }
        private static List<IForme> ObstaclesTemporaires { get; set; }

        public static Color NotreCouleur { get; set; }

        public static bool Simulation { get; set; }

        public static Color[] CouleursBougies { get; set; }

        public static PointReel[] PositionsBougies { get; set; }
        public static bool[] BougiesEnfoncees { get; set; }
        public static PointReel[] PositionsCadeaux { get; set; }
        public static bool[] CadeauxActives { get; set; }

        private static int score;
        public static int Score
        {
            get { return score; }
            set { score = value; if (ScoreChange != null) ScoreChange(null, null); }
        }
        public static event EventHandler ScoreChange;

        /// <summary>
        /// Sémaphore à verrouiller pendant la manipulation du graph du pathfinding pour éviter les modification pendant énumération entre autres
        /// </summary>
        public static Semaphore SemaphoreGraph { get; private set; }

        public static Color CouleurJ1 { get { return Color.FromArgb(165, 32, 25); } }
        public static Color CouleurJ2 { get { return Color.FromArgb(6, 57, 113); } }

        /// <summary>
        /// Longueur de la table (mm)
        /// </summary>
        public static int LongueurPlateau { get { return 3000; } }

        /// <summary>
        /// Largeur de la table (mm)
        /// </summary>
        public static int LargeurPlateau { get { return 2000; } }

        /// <summary>
        /// Liste complète des obstacles fixes et temporaires
        /// </summary>
        public List<IForme> ListeObstacles
        {
            get
            {
                List<IForme> toutObstacles = new List<IForme>();
                toutObstacles.AddRange(ObstaclesFixes);
                toutObstacles.AddRange(ObstaclesTemporaires);
                return toutObstacles;
            }
        }

        /// <summary>
        /// Graph des noeuds et arcs pour le pathfinding
        /// </summary>
        public Graph Graph { get; private set; }

        /// <summary>
        /// Liste des noeuds du chemin en cours de parcours
        /// </summary>
        public List<Node> CheminEnCoursNoeuds { get; set; }

        /// <summary>
        /// Liste des arcs du chemin en cours de parcours
        /// </summary>
        public List<Arc> CheminEnCoursArcs { get; set; }

        public Plateau()
        {
            if (!Config.DesignMode)
            {
                Plateau.SemaphoreGraph = new Semaphore(1, 1);

                //CreerSommets(150);
                ChargerGraph();
                ChargerObstacles();

                ObstaclesTemporaires = new List<IForme>();

                InterpreteurBalise = new InterpreteurBalise();
                InterpreteurBalise.PositionEnnemisActualisee += new GoBot.InterpreteurBalise.PositionEnnemisDelegate(interpreteBalise_PositionEnnemisActualisee);

                CheminTrouve = new List<Arc>();
                CheminEnCoursArcs = new List<Arc>();
                NodeTrouve = new List<Node>();

                if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
                    Simulation = false;
                else
                    Simulation = true;

                CouleursBougies = new Color[20];
                for (int i = 0; i < 20; i++)
                    CouleursBougies[i] = Color.White;

                NotreCouleur = Color.Red;

                PositionsBougies = new PointReel[20];

                PositionsBougies[0] = new PointReel(1845, 68);
                PositionsBougies[1] = new PointReel(1946, 59);
                PositionsBougies[2] = new PointReel(1791, 194);
                PositionsBougies[3] = new PointReel(1916, 172);
                PositionsBougies[4] = new PointReel(1694, 291);
                PositionsBougies[5] = new PointReel(1857, 274);
                PositionsBougies[6] = new PointReel(1774, 357);
                PositionsBougies[7] = new PointReel(1672, 416);
                PositionsBougies[8] = new PointReel(1568, 343);
                PositionsBougies[9] = new PointReel(1559, 446);

                PositionsBougies[10] = new PointReel(1157, 68);
                PositionsBougies[11] = new PointReel(1054, 59);
                PositionsBougies[12] = new PointReel(1209, 194);
                PositionsBougies[13] = new PointReel(1084, 172);
                PositionsBougies[14] = new PointReel(1306, 291);
                PositionsBougies[15] = new PointReel(1143, 274);
                PositionsBougies[16] = new PointReel(1226, 357);
                PositionsBougies[17] = new PointReel(1328, 416);
                PositionsBougies[18] = new PointReel(1432, 343);
                PositionsBougies[19] = new PointReel(1441, 446);

                BougiesEnfoncees = new bool[20];
                for (int i = 0; i < 20; i++)
                    BougiesEnfoncees[i] = false;

                PositionsCadeaux = new PointReel[8];
                PositionsCadeaux[0] = new PointReel(600 - 86, 2000);
                PositionsCadeaux[1] = new PointReel(600 + 86, 2000);
                PositionsCadeaux[2] = new PointReel(1200 - 86, 2000);
                PositionsCadeaux[3] = new PointReel(1200 + 86, 2000);
                PositionsCadeaux[4] = new PointReel(1800 - 86, 2000);
                PositionsCadeaux[5] = new PointReel(1800 + 86, 2000);
                PositionsCadeaux[6] = new PointReel(2400 - 86, 2000);
                PositionsCadeaux[7] = new PointReel(2400 + 86, 2000);

                CadeauxActives = new bool[8];
                for (int i = 0; i < 8; i++)
                    CadeauxActives[i] = false;
            }
        }

        public static void Init()
        {
            Balise1 = new Balise(Carte.RecBun);
            Balise2 = new Balise(Carte.RecBeu);
            Balise3 = new Balise(Carte.RecBoi);
        }

        public bool PathFinding(Robot robot, double x, double y, int timeOut = 0, bool attendre = false)
        {
            semTrajectoire = new Semaphore(0, 999);

            bool result = ParcoursPathFinding(robot, x, y, timeOut, attendre);

            if (attendre)
                semTrajectoire.WaitOne();

            return result;
        }

        public bool ParcoursPathFinding(Robot robot, double x, double y, int timeOut = 0, bool attendre = false)
        {
            CheminEnCoursNoeuds = new List<Node>();
            CheminEnCoursArcs = new List<Arc>();

            DateTime debut = DateTime.Now;

            double distance;

            Node debutNode = Graph.ClosestNode(robot.Position.Coordonnees.X, robot.Position.Coordonnees.Y, 0, out distance, false);
            if (distance != 0)
            {
                debutNode = new Node(robot.Position.Coordonnees.X, robot.Position.Coordonnees.Y, 0);
                AddNode(debutNode, 500);
            }
            Node finNode = Graph.ClosestNode(x, y, 0, out distance, false);
            if (distance != 0)
            {
                finNode = new Node(x, y, 0);
                AddNode(finNode, 500);
            }

            // Teste s'il est possible d'aller directement à la fin sans passer par le graph
            bool toutDroit = true;
            Segment segment = new Segment(new PointReel(debutNode.X, debutNode.Y), new PointReel(finNode.X, finNode.Y));
            foreach (IForme forme in ListeObstacles)
            {
                if (TropProche(segment, forme))
                {
                    toutDroit = false;
                    break;
                }
            }

            if (toutDroit)
            {
                CheminEnCoursNoeuds.Add(debutNode);
                CheminEnCoursNoeuds.Add(finNode);

                Arc arcToutDroit = new Arc(debutNode, finNode);
                arcToutDroit.Weight = 99999999;
                CheminEnCoursArcs.Add(arcToutDroit);
            }

            // Sinon on passe par le graph
            else
            {
                AStar aStar = new AStar(Graph);
                aStar.DijkstraHeuristicBalance = 1;
                if (aStar.SearchPath(debutNode, finNode))
                {
                    List<Node> nodes = aStar.PathByNodes.ToList<Node>();
                    List<Arc> arcs = aStar.PathByArcs.ToList<Arc>();

                    CheminEnCoursNoeuds = new List<Node>();
                    CheminEnCoursArcs = new List<Arc>();

                    CheminTrouve = new List<Arc>(arcs);
                    NodeTrouve = new List<Node>(nodes);

                    // Simplification du chemin
                    // On part du début et on essaie d'aller au point du plus éloigné au moins éloigné en testant si le passage est possible
                    // Si c'est possible on zappe tous les points entre les deux
                    for (int iNodeDepart = 0; iNodeDepart < nodes.Count - 1; iNodeDepart++)
                    {
                        CheminEnCoursNoeuds.Add(nodes[iNodeDepart]);

                        bool raccourciPossible = true;
                        for (int iNodeArrivee = nodes.Count - 1; iNodeArrivee > iNodeDepart; iNodeArrivee--)
                        {
                            raccourciPossible = true;

                            Segment racourci = new Segment(new PointReel(nodes[iNodeDepart].X, nodes[iNodeDepart].Y), new PointReel(nodes[iNodeArrivee].X, nodes[iNodeArrivee].Y));
                            Arc arcRacourci = new Arc(nodes[iNodeDepart], nodes[iNodeArrivee]);
                            CheminTest = arcRacourci;
                            arcRacourci.Passable = false;
                            for (int i = ListeObstacles.Count - 1; i >= 4; i--)
                            {
                                IForme forme = ListeObstacles[i];
                                ObstacleTeste = forme;
                                ObstacleProbleme = null;

                                if (TropProche(racourci, forme))
                                {
                                    ObstacleProbleme = forme;
                                    //Thread.Sleep(500);
                                    raccourciPossible = false;
                                    break;
                                }
                                //else 
                                //Thread.Sleep(500);
                            }
                            ObstacleTeste = null;
                            if (raccourciPossible)
                            {
                                /*Arc arcRacourci = new Arc(nodes[iNodeDepart], nodes[iNodeArrivee]);
                                arcRacourci.Passable = false;*/
                                CheminEnCoursArcs.Add(arcRacourci);
                                iNodeDepart = iNodeArrivee - 1;
                                break;
                            }
                        }
                        CheminTest = null;
                        if (!raccourciPossible)
                        {
                            Arc arc = new Arc(nodes[iNodeDepart], nodes[iNodeDepart + 1]);
                            CheminEnCoursArcs.Add(arc);
                        }
                    }

                    CheminEnCoursNoeuds.Add(nodes[nodes.Count - 1]);
                }
            }

            ObstacleProbleme = null;
            ObstacleTeste = null;
            NodeTrouve = new List<Node>();
            CheminTrouve = new List<Arc>();
            ChargerGraph();

            if (CheminEnCoursArcs.Count == 0)
            {
                semTrajectoire.Release();
                return false;
            }
            else
            {
                // Execution du parcours

                th = new Thread(ThreadChemin);
                th.Start(robot);

                return true;
            }
        }
        Thread th;
        Semaphore[] semTrajectoire;

        public List<Arc> CheminTrouve;
        public List<Node> NodeTrouve;
        public Arc CheminTest;
        public IForme ObstacleTeste;
        public IForme ObstacleProbleme;

        /// <summary>
        /// Parcours le chemin pour arriver au point de destination
        /// </summary>
        private void ThreadChemin(Object o)
        {
            Robot robot = (Robot)o;
            nouvelleTrajectoire = false;
            while (CheminEnCoursNoeuds.Count > 1)
            {
                PointReel c1 = new PointReel(CheminEnCoursNoeuds[0].X, CheminEnCoursNoeuds[0].Y);
                PointReel c2 = new PointReel(CheminEnCoursNoeuds[1].X, CheminEnCoursNoeuds[1].Y);

                Position p = new Position(robot.Position.Angle, c1);
                Direction traj = Maths.GetDirection(p, c2);

                if (traj.angle.AngleDegres < 0)
                    robot.PivotDroite(-traj.angle.AngleDegres);
                else
                    robot.PivotGauche(traj.angle.AngleDegres);

                if (nouvelleTrajectoire)
                    break;
                robot.Avancer((int)traj.distance);

                CheminEnCoursNoeuds.RemoveAt(0);
                CheminEnCoursArcs.RemoveAt(0);

                if (nouvelleTrajectoire)
                    break;
            }
            if (nouvelleTrajectoire)
                ParcoursPathFinding(robot, CheminEnCoursNoeuds[CheminEnCoursNoeuds.Count - 1].X, CheminEnCoursNoeuds[CheminEnCoursNoeuds.Count - 1].Y);
            else
            {
                if (semTrajectoire != null)
                    semTrajectoire.Release();
            }
        }

        bool nouvelleTrajectoire = false;
        public bool ObstacleTest(int x, int y)
        {
            if (nouvelleTrajectoire)
                return false;

            ViderObstacles();
            AjouterObstacle(new Cercle(new PointReel(x, y), 200));

            try
            {
                // Teste si le chemin en cours de parcous est toujours franchissable
                if (!nouvelleTrajectoire && CheminEnCoursNoeuds != null && CheminEnCoursNoeuds.Count > 0)
                {
                    foreach (Arc a in CheminEnCoursArcs)
                    {
                        Segment segment = new Segment(new PointReel(a.StartNode.X, a.StartNode.Y), new PointReel(a.EndNode.X, a.EndNode.Y));

                        if (segment.getDistance(new PointReel(x, y)) < Robots.GrosRobot.Rayon * 2)
                        //if(!a.Passable)
                        {
                            // Demande de génération d'une nouvelle trajectoire
                            nouvelleTrajectoire = true;
                            if (Robots.GrosRobot.DeplacementLigne)
                                Robots.GrosRobot.Stop();
                            //Thread.Sleep(1500);
                            //GrosRobot.semDeplacement.Release();
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        void interpreteBalise_PositionEnnemisActualisee(InterpreteurBalise interprete)
        {
            ViderObstacles();

            foreach (PointReel p in interprete.PositionsEnnemies)
                AjouterObstacle(new Cercle(p, 200));

            // Teste si le chemin en cours de parcous est toujours franchissable
            if (!nouvelleTrajectoire && CheminEnCoursNoeuds != null && CheminEnCoursNoeuds.Count > 0)
            {
                foreach (Arc a in CheminEnCoursArcs)
                {
                    Segment segment = new Segment(new PointReel(a.StartNode.X, a.StartNode.Y), new PointReel(a.EndNode.X, a.EndNode.Y));
                    foreach (PointReel p in interprete.PositionsEnnemies)
                    {
                        if (segment.getDistance(p) < Robots.GrosRobot.Rayon * 2)
                        {
                            // Demande de génération d'une nouvelle trajectoire
                            nouvelleTrajectoire = true;
                            Robots.GrosRobot.Stop();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Vide les obstacles temporaires et rend tout le graph parcourable
        /// </summary>
        public void ViderObstacles()
        {
            ObstaclesTemporaires.Clear();
            for (int i = 0; i < Graph.Arcs.Count; i++)
                ((Arc)Graph.Arcs[i]).Passable = true;
            for (int i = 0; i < Graph.Nodes.Count; i++)
                ((Node)Graph.Nodes[i]).Passable = true;
        }

        /// <summary>
        /// Ajoute un obstacle et teste les endroits du graph qui ne sont plus franchissables
        /// </summary>
        /// <param name="obstacle">Forme de l'obstacle</param>
        /// <param name="fixe">Si l'obstacle est fixe, on supprime complètement les noeuds et arcs non franchissables. Sinon on les rends non franchissables temporairement.</param>
        public void AjouterObstacle(IForme obstacle, bool fixe = false)
        {
            DateTime debut = DateTime.Now;

            if (fixe)
                ObstaclesFixes.Add(obstacle);
            else
                ObstaclesTemporaires.Add(obstacle);

            // Teste les arcs non franchissables
            for (int i = 0; i < Graph.Arcs.Count; i++)
            {
                Arc arc = (Arc)Graph.Arcs[i];

                if (arc.Passable)
                {
                    Segment segment = new Segment(new PointReel(arc.StartNode.X, arc.StartNode.Y), new PointReel(arc.EndNode.X, arc.EndNode.Y));
                    if (TropProche(obstacle, segment))
                    {
                        if (fixe)
                        {
                            Graph.RemoveArc(i);
                            i--;
                        }
                        else
                            arc.Passable = false;
                    }
                }
            }

            // Teste les noeuds non franchissables
            for (int i = 0; i < Graph.Nodes.Count; i++)
            {
                Node n = (Node)Graph.Nodes[i];

                if (n.Passable)
                {
                    PointReel noeud = new PointReel(n.X, n.Y);
                    if (TropProche(obstacle, noeud))
                    {
                        if (fixe)
                        {
                            Graph.RemoveNode(i);
                            i--;
                        }
                        else
                            n.Passable = false;

                    }
                }
            }
        }

        /// <summary>
        /// Teste si deux formes sont trop proches pour envisager le passage du robot
        /// </summary>
        /// <param name="forme1">Forme 1</param>
        /// <param name="forme2">Forme 2</param>
        /// <returns>Vrai si les deux formes sont trop proches</returns>
        internal bool TropProche(IForme forme1, IForme forme2)
        {
            Type typeForme1 = forme1.GetType();
            Type typeForme2 = forme2.GetType();

            if (typeForme1.IsAssignableFrom(typeof(Segment)))
                if (typeForme2.IsAssignableFrom(typeof(Segment)))
                    return ((Segment)forme1).getDistance((Segment)forme2) < Robots.GrosRobot.Rayon;
                else
                    return ((Segment)forme1).getDistance(forme2) < Robots.GrosRobot.Rayon;
            else
                return forme1.getDistance(forme2) < Robots.GrosRobot.Rayon;
        }

        /// <summary>
        /// Sauve le graph pour une utilisation ultérieure
        /// </summary>
        public void SauverGraph()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("graph.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Graph);
            stream.Close();
        }

        /// <summary>
        /// Charge le dernier graph sauvegardé. Permet de gagner du temps par rapport à une génération du graph à chaque execution.
        /// </summary>
        public void ChargerGraph()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("graph.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Graph = (Graph)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Impossible de charger le graph." + Environment.NewLine + e.Message);
            }
        }

        /// <summary>
        /// Crée le graph du pathfinding.
        /// </summary>
        /// <param name="resolution">Distance (mm) entre chaque noeud du graph en X et Y</param>
        /// <param name="distanceLiaison">Distance (mm) jusqu'à laquelle les noeuds sont reliés par un arc. Par défaut on crée un graph minimal (liaison aux 8 points alentours : N/S/E/O/NE/NO/SE/SO)</param>
        private void CreerSommets(int resolution, double distanceLiaison = -1)
        {
            if (distanceLiaison == -1)
                distanceLiaison = Math.Sqrt((resolution * resolution) * 2) + 1;

            Graph = new Graph();

            // Création des noeuds
            for (int x = 0; x < LongueurPlateau; x += resolution)
                for (int y = 0; y < LargeurPlateau; y += resolution)
                    Graph.AddNode(x, y, 0);

            // Création des arcs
            foreach (Node node1 in Graph.Nodes)
                foreach (Node node2 in Graph.Nodes)
                {
                    if (node1 != node2)
                    {
                        double distance = Math.Sqrt((node1.Position.X - node2.Position.X) * (node1.Position.X - node2.Position.X) + (node1.Position.Y - node2.Position.Y) * (node1.Position.Y - node2.Position.Y));
                        if (distance < distanceLiaison)
                        {
                            Arc b = new Arc(node2, node1);
                            b.Weight = Math.Sqrt(distance);
                            Graph.AddArc(b);
                        }
                    }
                }
        }

        public void ChargerObstacles()
        {
            ObstaclesFixes = new List<IForme>();

            // Contours du plateau
            AjouterObstacle(new Calculs.Formes.Segment(new PointReel(0, 0), new PointReel(LongueurPlateau - 4, 0)), true);
            AjouterObstacle(new Calculs.Formes.Segment(new PointReel(LongueurPlateau - 4, 0), new PointReel(LongueurPlateau - 4, LargeurPlateau - 4)), true);
            AjouterObstacle(new Calculs.Formes.Segment(new PointReel(LongueurPlateau - 4, LargeurPlateau - 4), new PointReel(0, LargeurPlateau - 4)), true);
            AjouterObstacle(new Calculs.Formes.Segment(new PointReel(0, LargeurPlateau - 4), new PointReel(0, 0)), true);

            // Gateau
            AjouterObstacle(new Cercle(new PointReel(1500, 0), 500), true);

            // Coins surélevés
            List<PointReel> points = new List<PointReel>();

            points.Add(new PointReel(0, 0.1));
            points.Add(new PointReel(400, 0));
            points.Add(new PointReel(400, 100));
            points.Add(new PointReel(0, 100));
            AjouterObstacle(new Polygone(points), true);

            points.Clear();
            points.Add(new PointReel(0, 1900));
            points.Add(new PointReel(400, 1900));
            points.Add(new PointReel(400, 2000));
            points.Add(new PointReel(0, 2000));
            AjouterObstacle(new Polygone(points), true);

            points.Clear();
            points.Add(new PointReel(2600, 1900));
            points.Add(new PointReel(3000, 1900));
            points.Add(new PointReel(3000, 2000));
            points.Add(new PointReel(2600, 2000));
            AjouterObstacle(new Polygone(points), true);

            points.Clear();
            points.Add(new PointReel(2600, 0));
            points.Add(new PointReel(3000, 0));
            points.Add(new PointReel(3000, 100));
            points.Add(new PointReel(2600, 100));
            AjouterObstacle(new Polygone(points), true);
        }

        /// <summary>
        /// Ajoute un noeud au graph en reliant tous les points à une distance maximale
        /// </summary>
        /// <param name="node">Noeud à ajouter</param>
        /// <param name="distanceMax">Distance (mm) max de liaison avec les autres noeuds</param>
        public void AddNode(Node node, int distanceMax = 213)
        {
            SemaphoreGraph.WaitOne();

            double distanceNode;

            // Si un noeud est deja présent à cet endroit on ne l'ajoute pas
            Graph.ClosestNode(node.X, node.Y, node.Z, out distanceNode, true);
            if (distanceNode == 0)
                return;

            // Teste si le noeud est franchissable avec la liste des obstacles
            foreach (IForme obstacle in ObstaclesFixes)
            {
                if (obstacle.contient(new PointReel(node.X, node.Y)))
                {
                    node.Passable = false;
                    return;
                }
            }

            Graph.Nodes.Add(node);

            // Liaisons avec les autres noeuds du graph
            foreach (Node no in Graph.Nodes)
            {
                if (node != no)
                {
                    double distance = Math.Sqrt((node.Position.X - no.Position.X) * (node.Position.X - no.Position.X) + (node.Position.Y - no.Position.Y) * (node.Position.Y - no.Position.Y));
                    if (distance < distanceMax)
                    {
                        Arc arc = new Arc(no, node);
                        arc.Weight = Math.Sqrt(distance);
                        Arc arc2 = new Arc(node, no);
                        arc2.Weight = Math.Sqrt(distance);

                        foreach (IForme obstacle in ObstaclesFixes)
                        {
                            if (obstacle.getDistance(new Segment(new PointReel(no.X, no.Y), new PointReel(node.X, node.Y))) < Robots.GrosRobot.Taille / 2)
                            {
                                arc.Passable = false;
                                arc2.Passable = false;
                                break;
                            }
                        }

                        Graph.AddArc(arc);
                        Graph.AddArc(arc2);
                    }
                }
            }

            SemaphoreGraph.Release();
        }

        /// <summary>
        /// Rend traversables tous les noeuds et arcs du graph
        /// </summary>
        internal void SupprimerObstacles()
        {
            for (int i = 0; i < Graph.Nodes.Count; i++)
                ((Node)(Graph.Nodes[i])).Passable = true;

            for (int i = 0; i < Graph.Arcs.Count; i++)
                ((Arc)(Graph.Arcs[i])).Passable = true;
        }

        /// <summary>
        /// Teste si on point est contenu dans la table
        /// </summary>
        /// <param name="croisement">Point à tester</param>
        /// <returns></returns>
        public static bool Contient(PointReel point)
        {
            if (point.X < 0 || point.Y < 0 || point.X > LongueurPlateau || point.Y > LargeurPlateau)
                return false;

            return true;
        }

        /*private static Segment Arc2Segment(Arc arc)
        {
            return new Segment(new PointReel(arc.StartNode.X, arc.StartNode.Y), new PointReel(arc.EndNode.X, arc.EndNode.Y));
        }

        private static Arc Segment2Arc(Segment segment)
        {
        }

        private static Node PointReel2Node(PointReel point)
        {
        }

        private static PointReel Node2PointReel(Node noeud)
        {
        }*/
    }
}
