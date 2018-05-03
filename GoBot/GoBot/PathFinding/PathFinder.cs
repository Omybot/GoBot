using AStarFolder;
using GoBot.Actions;
using GoBot.Geometry;
using GoBot.Geometry.Shapes;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.PathFinding
{
    static class PathFinder
    {
        private static ThreadLink _linkResetRadius;

        public static List<Arc> CheminTrouve { get; private set; }
        public static List<Node> NodeTrouve { get; private set; }
        public static List<Node> CheminEnCoursNoeuds { get; private set; }
        public static List<Arc> CheminEnCoursArcs { get; private set; }

        public static Arc CheminTest { get; private set; }
        public static IShape ObstacleTeste { get; private set; }
        public static IShape ObstacleProbleme { get; private set; }
        public static List<RealPoint> PointsTrouves { get; private set; }

        public static Trajectory ChercheTrajectoire(Graph graph, List<IShape> obstacles, Position positionActuell, Position destination, double rayonSecurite, double distanceSecuriteCote)
        {
            DateTime debut = DateTime.Now;

            _linkResetRadius = null;

            double distanceRaccordable = 150;
            double distance;
            bool cheminTrouve = false;
            bool raccordable = false;
            Trajectory trajectoire = new Trajectory();
            trajectoire.StartAngle = new Angle(positionActuell.Angle);
            trajectoire.EndAngle = new Angle(destination.Angle);

            PointsTrouves = new List<RealPoint>();
            PointsTrouves.Add(new RealPoint(positionActuell.Coordinates));
            trajectoire.AddPoint(new RealPoint(positionActuell.Coordinates));

            lock (graph)
            {
                int nbPointsDepart = 0;
                int nbPointsArrivee = 0;

                Node debutNode;
                Node nodeProche = graph.ClosestNode(positionActuell.Coordinates.X, positionActuell.Coordinates.Y, 0, out distance, false);
                if (distance != 0)
                {
                    debutNode = new Node(positionActuell.Coordinates.X, positionActuell.Coordinates.Y, 0);
                    nbPointsDepart = graph.AddNode(debutNode, obstacles, rayonSecurite, distanceRaccordable);
                }
                else
                    debutNode = nodeProche;

                //TODO2018 phase d'approche finale pourrie, l'angle final peut se faire à la fin au lieu de à la fin du path finding avant l'approche finale
                if (nbPointsDepart == 0)
                {
                    // On ne peut pas partir de là où on est

                    Position positionTestee = new Position(positionActuell);
                    bool franchissable = true;

                    // Boucle jusqu'à trouver un point qui se connecte au graph jusqu'à 1m devant
                    int i;
                    for (i = 0; i < 100 && !raccordable; i += 1)
                    {
                        positionTestee.Move(10);

                        debutNode = new Node(positionTestee.Coordinates.X, positionTestee.Coordinates.Y, 0);
                        raccordable = graph.Raccordable(debutNode, obstacles, rayonSecurite, distanceRaccordable);
                    }

                    // Le point à i*10 mm devant nous est reliable au graph, on cherche à l'atteindre
                    if (raccordable)
                    {
                        Segment segmentTest = new Segment(new RealPoint(positionTestee.Coordinates), new RealPoint(positionActuell.Coordinates));

                        // Test des obstacles

                        lock (Plateau.ObstaclesBalise)
                        {
                            foreach (IShape obstacle in obstacles)
                            {
                                if (obstacle.Distance(segmentTest) < distanceSecuriteCote)
                                {
                                    franchissable = false;

                                    // Si l'obstacle génant est un adversaire, on diminue petit à petit son rayon pour pouvoir s'échapper au bout d'un moment
                                    if (Plateau.ObstaclesBalise.Contains(obstacle) && Plateau.RayonAdversaire > 50)
                                    {
                                        Robots.GrosRobot.Historique.Log("Adversaire au contact, impossible de s'enfuir, réduction du périmètre adverse", TypeLog.PathFinding);
                                        Plateau.RayonAdversaire -= 10;
                                        _linkResetRadius?.Cancel();
                                    }
                                }
                            }
                        }

                        // Si le semgent entre notre position et le graph relié au graph est parcourable on y va !
                        if (franchissable)
                        {
                            PointsTrouves.Add(new RealPoint(positionTestee.Coordinates));
                            trajectoire.AddPoint(new RealPoint(positionTestee.Coordinates));

                            debutNode = new Node(positionTestee.Coordinates.X, positionTestee.Coordinates.Y, 0);
                            nbPointsDepart = graph.AddNode(debutNode, obstacles, rayonSecurite, distanceRaccordable);
                        }
                    }
                    else
                        franchissable = false;

                    // Si toujours pas, on teste en marche arrière
                    if (!franchissable)
                    {
                        franchissable = true;
                        raccordable = false;
                        nbPointsDepart = 0;
                        positionTestee = new Position(positionActuell);
                        for (i = 0; i > -100 && !raccordable; i--)
                        {
                            positionTestee.Move(-10);

                            debutNode = new Node(positionTestee.Coordinates.X, positionTestee.Coordinates.Y, 0);
                            raccordable = graph.Raccordable(debutNode, obstacles, rayonSecurite, distanceRaccordable);
                        }

                        // Le point à i*10 mm derrière nous est reliable au graph, on cherche à l'atteindre
                        if (raccordable)
                        {
                            Segment segmentTest = new Segment(new RealPoint(positionTestee.Coordinates), new RealPoint(destination.Coordinates));

                            lock (Plateau.ObstaclesBalise)
                            {
                                // Test des obstacles
                                foreach (IShape obstacle in obstacles)
                                {
                                    if (obstacle.Distance(segmentTest) < distanceSecuriteCote)
                                    {
                                        franchissable = false;

                                        // Si l'obstacle génant est un adversaire, on diminue petit à petit son rayon pour pouvoir s'échapper au bout d'un moment
                                        if (Plateau.ObstaclesBalise.Contains(obstacle) && Plateau.RayonAdversaire > 50)
                                        {
                                            Robots.GrosRobot.Historique.Log("Adversaire au contact, impossible de s'enfuir, réduction du périmètre adverse", TypeLog.PathFinding);
                                            Plateau.RayonAdversaire -= 10;
                                            _linkResetRadius?.Cancel();
                                        }
                                    }
                                }
                            }

                            // Si le semgent entre notre position et le graph relié au graph est parcourable on y va !
                            if (franchissable)
                            {
                                PointsTrouves.Add(new RealPoint(positionTestee.Coordinates));
                                trajectoire.AddPoint(new RealPoint(positionTestee.Coordinates));

                                debutNode = new Node(positionTestee.Coordinates.X, positionTestee.Coordinates.Y, 0);
                                nbPointsDepart = graph.AddNode(debutNode, obstacles, rayonSecurite, distanceRaccordable);
                            }
                        }
                    }
                }

                Node finNode = graph.ClosestNode(destination.Coordinates.X, destination.Coordinates.Y, 0, out distance, false);
                if (distance != 0)
                {
                    finNode = new Node(destination.Coordinates.X, destination.Coordinates.Y, 0);
                    nbPointsArrivee = graph.AddNode(finNode, obstacles, rayonSecurite, distanceRaccordable);
                }
                if (nbPointsArrivee == 0)
                {
                    Console.WriteLine("Blocage arrivée : " + (DateTime.Now - debut).TotalMilliseconds + "ms");
                    // On ne peut pas arriver là où on souhaite aller
                    // On teste si on peut faire une approche en ligne 
                    // teta ne doit pas être nul sinon c'est qu'on ne maitrise pas l'angle d'arrivée et on ne connait pas l'angle d'approche

                    Position positionTestee = new Position(destination);
                    bool franchissable = true;
                    raccordable = false;

                    // Boucle jusqu'à trouver un point qui se connecte au graph jusqu'à 1m devant
                    int i;
                    for (i = 0; i < 100 && !raccordable; i++)
                    {
                        positionTestee.Move(10);
                        raccordable = graph.Raccordable(new Node(positionTestee.Coordinates.X, positionTestee.Coordinates.Y, 0), obstacles, rayonSecurite, distanceRaccordable);
                    }

                    // Le point à i*10 mm devant nous est reliable au graph, on cherche à l'atteindre
                    if (raccordable)
                    {
                        Segment segmentTest = new Segment(new RealPoint(positionTestee.Coordinates), new RealPoint(positionActuell.Coordinates));

                        // Test des obstacles
                        foreach (IShape obstacle in obstacles)
                        {
                            if (obstacle.Distance(segmentTest) < distanceSecuriteCote)
                                franchissable = false;
                        }
                    }
                    else
                        franchissable = false;

                    // Si toujours pas, on teste en marche arrière
                    if (!franchissable)
                    {
                        positionTestee = new Position(destination);
                        nbPointsArrivee = 0;

                        for (i = 0; i > -100 && !raccordable; i--)
                        {
                            positionTestee.Move(-10);
                            raccordable = graph.Raccordable(new Node(positionTestee.Coordinates.X, positionTestee.Coordinates.Y, 0), obstacles, rayonSecurite, distanceRaccordable);
                        }

                        if (raccordable)
                        {
                            franchissable = true;
                            Segment segmentTest = new Segment(new RealPoint(positionTestee.Coordinates), new RealPoint(destination.Coordinates));

                            // Test des obstacles
                            foreach (IShape obstacle in obstacles)
                            {
                                if (obstacle.Distance(segmentTest) < distanceSecuriteCote)
                                    franchissable = false;
                            }
                        }
                    }

                    // Si le semgent entre notre position et le node relié au graph est parcourable on y va !
                    if (franchissable)
                    {
                        finNode = new Node(positionTestee.Coordinates.X, positionTestee.Coordinates.Y, 0);
                        nbPointsArrivee = graph.AddNode(finNode, obstacles, rayonSecurite, distanceRaccordable);
                    }
                }

                // Teste s'il est possible d'aller directement à la fin sans passer par le graph
                bool toutDroit = true;
                Segment segment = new Segment(new RealPoint(debutNode.X, debutNode.Y), new RealPoint(finNode.X, finNode.Y));

                foreach (IShape forme in obstacles)
                {
                    if (segment.Distance(forme) < rayonSecurite)
                    {
                        toutDroit = false;
                        break;
                    }
                }

                if (toutDroit)
                {
                    Robots.GrosRobot.Historique.Log("Chemin trouvé : ligne droite", TypeLog.PathFinding);
                    cheminTrouve = true;

                    PointsTrouves.Add(new RealPoint(finNode.X, finNode.Y));
                    trajectoire.AddPoint(new RealPoint(finNode.X, finNode.Y));
                    if (destination.Coordinates.Distance(new RealPoint(finNode.X, finNode.Y)) > 1)
                    {
                        PointsTrouves.Add(new RealPoint(destination.Coordinates));
                        trajectoire.AddPoint(new RealPoint(destination.Coordinates));
                    }
                }

                // Sinon on passe par le graph
                else
                {
                    bool ok = false;

                    AStar aStar = new AStar(graph);
                    aStar.DijkstraHeuristicBalance = 1;

                    //Console.WriteLine("Avant pathFinding : " + (DateTime.Now - debut).TotalMilliseconds + "ms");

                    if (aStar.SearchPath(debutNode, finNode))
                    {
                        //Console.WriteLine("PathFinding trouvé : " + (DateTime.Now - debut).TotalMilliseconds + "ms");

                        List<Node> nodes = aStar.PathByNodes.ToList<Node>();
                        List<Arc> arcs = aStar.PathByArcs.ToList<Arc>();

                        Robots.GrosRobot.Historique.Log("Chemin trouvé : " + (nodes.Count - 2) + " noeud(s) intermédiaire(s)", TypeLog.PathFinding);

                        CheminEnCoursNoeuds = new List<Node>();
                        CheminEnCoursArcs = new List<Arc>();

                        CheminTrouve = new List<Arc>(arcs);
                        NodeTrouve = new List<Node>(nodes);

                        //Console.WriteLine("Début simplification : " + (DateTime.Now - debut).TotalMilliseconds + "ms");

                        // Simplification du chemin
                        // On part du début et on essaie d'aller au point du plus éloigné au moins éloigné en testant si le passage est possible
                        // Si c'est possible on zappe tous les points entre les deux
                        for (int iNodeDepart = 0; iNodeDepart < nodes.Count - 1; iNodeDepart++)
                        {
                            if (iNodeDepart != 0)
                            {
                                PointsTrouves.Add(new RealPoint(nodes[iNodeDepart].X, nodes[iNodeDepart].Y));
                                trajectoire.AddPoint(new RealPoint(nodes[iNodeDepart].X, nodes[iNodeDepart].Y));
                            }

                            CheminEnCoursNoeuds.Add(nodes[iNodeDepart]);

                            bool raccourciPossible = true;
                            for (int iNodeArrivee = nodes.Count - 1; iNodeArrivee > iNodeDepart; iNodeArrivee--)
                            {
                                raccourciPossible = true;

                                Segment racourci = new Segment(new RealPoint(nodes[iNodeDepart].X, nodes[iNodeDepart].Y), new RealPoint(nodes[iNodeArrivee].X, nodes[iNodeArrivee].Y));
                                //Arc arcRacourci = new Arc(nodes[iNodeDepart], nodes[iNodeArrivee]);
                                //CheminTest = arcRacourci;
                                //arcRacourci.Passable = false;

                                for (int i = obstacles.Count - 1; i >= 4; i--) // > 4 pour ne pas tester les bordures
                                {
                                    IShape forme = obstacles[i];
                                    ObstacleTeste = forme;
                                    ObstacleProbleme = null;

                                    if (racourci.Distance(forme) < rayonSecurite)
                                    {
                                        ObstacleProbleme = forme;

                                        // Tempo pour l'affichage détaillé de la recherche de trajectoire (option)
                                        if (Config.CurrentConfig.AfficheDetailTraj > 0)
                                            Thread.Sleep(Config.CurrentConfig.AfficheDetailTraj);

                                        raccourciPossible = false;
                                        break;
                                    }
                                    //else if(Config.CurrentConfig.AfficheDetailTraj > 0)
                                    //    Thread.Sleep(Config.CurrentConfig.AfficheDetailTraj);
                                }
                                if (Config.CurrentConfig.AfficheDetailTraj > 0)
                                    Thread.Sleep(Config.CurrentConfig.AfficheDetailTraj);

                                ObstacleTeste = null;

                                if (raccourciPossible)
                                {
                                    //CheminEnCoursArcs.Add(arcRacourci);
                                    iNodeDepart = iNodeArrivee - 1;
                                    break;
                                }
                            }
                            CheminTest = null;
                            if (!raccourciPossible)
                            {
                                //Arc arc = new Arc(nodes[iNodeDepart], nodes[iNodeDepart + 1]);
                                //CheminEnCoursArcs.Add(arc);
                            }
                        }

                        CheminEnCoursNoeuds.Add(nodes[nodes.Count - 1]);
                        PointsTrouves.Add(new RealPoint(nodes[nodes.Count - 1].X, nodes[nodes.Count - 1].Y));
                        trajectoire.AddPoint(new RealPoint(nodes[nodes.Count - 1].X, nodes[nodes.Count - 1].Y));
                        Robots.GrosRobot.Historique.Log("Chemin optimisé : " + (CheminEnCoursNoeuds.Count - 2) + " noeud(s) intermédiaire(s)", TypeLog.PathFinding);
                        cheminTrouve = true;

                        if (destination.Coordinates.Distance(new RealPoint(finNode.X, finNode.Y)) > 1)
                        {
                            PointsTrouves.Add(new RealPoint(destination.Coordinates));
                            trajectoire.AddPoint(new RealPoint(destination.Coordinates));
                        }
                    }
                    else
                    {
                        CheminEnCoursNoeuds = null;
                        CheminEnCoursArcs = null;
                        cheminTrouve = false;
                    }
                }

                graph.CleanNodesArcsAdd();
            }

            PointsTrouves = null;
            ObstacleProbleme = null;
            ObstacleTeste = null;
            NodeTrouve = new List<Node>();
            CheminTrouve = new List<Arc>();

            //Console.WriteLine("PathFinding en " + (DateTime.Now - debut).TotalMilliseconds + " ms");

            if (!cheminTrouve)
            {
                Robots.GrosRobot.Historique.Log("Chemin non trouvé", TypeLog.PathFinding);
                return null;
            }
            else
            {
                if (Plateau.RayonAdversaire < Plateau.RayonAdversaireInitial)
                {
                    _linkResetRadius = ThreadManager.CreateThread(link => ResetOpponentRadiusLoop());
                    _linkResetRadius.StartThread();
                }

                return trajectoire;
            }
        }

        private static void ResetOpponentRadiusLoop()
        {
            _linkResetRadius.RegisterName();

            Thread.Sleep(1000);
            while (!_linkResetRadius.Cancelled)
            {
                Plateau.RayonAdversaire++;
                Thread.Sleep(50);
            }
        }
    }

}
