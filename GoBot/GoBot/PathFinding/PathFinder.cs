using AStarFolder;
using GoBot.Actions;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.PathFinding
{
    static class PathFinder
    {
        public static List<Arc> CheminTrouve { get; private set; }
        public static List<Node> NodeTrouve { get; private set; }
        public static List<Node> CheminEnCoursNoeuds { get; private set; }
        public static List<Arc> CheminEnCoursArcs { get; private set; }

        public static Arc CheminTest { get; private set; }
        public static IForme ObstacleTeste { get; private set; }
        public static IForme ObstacleProbleme { get; private set; }
        public static List<PointReel> PointsTrouves { get; private set; }

        private static Thread threadRAZRayonAdverse;

        public static Trajectoire ChercheTrajectoire(Graph graph, List<IForme> obstacles, Position positionActuell, Position destination, double rayonSecurite, double distanceSecuriteCote)
        {
            DateTime debut = DateTime.Now;

            double distanceRaccordable = 150;
            double distance;
            bool cheminTrouve = false;
            bool raccordable = false;
            Trajectoire trajectoire = new Trajectoire();
            trajectoire.AngleDepart = new Angle(positionActuell.Angle);
            trajectoire.AngleFinal = new Angle(destination.Angle);

            PointsTrouves = new List<PointReel>();
            PointsTrouves.Add(new PointReel(positionActuell.Coordonnees));
            trajectoire.AjouterPoint(new PointReel(positionActuell.Coordonnees));

            Synchronizer.Lock(graph);

            int nbPointsDepart = 0;
            int nbPointsArrivee = 0;

            Node debutNode;
            Node nodeProche = graph.ClosestNode(positionActuell.Coordonnees.X, positionActuell.Coordonnees.Y, 0, out distance, false);
            if (distance != 0)
            {
                debutNode = new Node(positionActuell.Coordonnees.X, positionActuell.Coordonnees.Y, 0);
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
                    positionTestee.Avancer(10);

                    debutNode = new Node(positionTestee.Coordonnees.X, positionTestee.Coordonnees.Y, 0);
                    raccordable = graph.Raccordable(debutNode, obstacles, rayonSecurite, distanceRaccordable);
                }

                // Le point à i*10 mm devant nous est reliable au graph, on cherche à l'atteindre
                if (raccordable)
                {
                    Segment segmentTest = new Segment(new PointReel(positionTestee.Coordonnees), new PointReel(positionActuell.Coordonnees));

                    // Test des obstacles

                    Synchronizer.Lock(Plateau.ObstaclesBalise);
                    foreach (IForme obstacle in obstacles)
                    {
                        if (obstacle.Distance(segmentTest) < distanceSecuriteCote)
                        {
                            franchissable = false;

                            // Si l'obstacle génant est un adversaire, on diminue petit à petit son rayon pour pouvoir s'échapper au bout d'un moment
                            if (Plateau.ObstaclesBalise.Contains(obstacle) && Plateau.RayonAdversaire > 50)
                            {
                                Robots.GrosRobot.Historique.Log("Adversaire au contact, impossible de s'enfuir, réduction du périmètre adverse", TypeLog.PathFinding);
                                Plateau.RayonAdversaire -= 10;
                            }
                        }
                    }
                    Synchronizer.Unlock(Plateau.ObstaclesBalise);

                    // Si le semgent entre notre position et le graph relié au graph est parcourable on y va !
                    if (franchissable)
                    {
                        PointsTrouves.Add(new PointReel(positionTestee.Coordonnees));
                        trajectoire.AjouterPoint(new PointReel(positionTestee.Coordonnees));

                        debutNode = new Node(positionTestee.Coordonnees.X, positionTestee.Coordonnees.Y, 0);
                        nbPointsDepart = graph.AddNode(debutNode, obstacles, rayonSecurite, distanceRaccordable);
                    }
                }
                else
                    franchissable = false;

                // Si toujours pas, on teste en marche arrière
                if (!franchissable)
                {
                    franchissable = true;
                    nbPointsDepart = 0;
                    positionTestee = new Position(positionActuell);
                    for (i = 0; i > -100 && !raccordable; i--)
                    {
                        positionTestee.Avancer(-10);

                        debutNode = new Node(positionTestee.Coordonnees.X, positionTestee.Coordonnees.Y, 0);
                        raccordable = graph.Raccordable(debutNode, obstacles, rayonSecurite, distanceRaccordable);
                    }

                    // Le point à i*10 mm derrière nous est reliable au graph, on cherche à l'atteindre
                    if (raccordable)
                    {
                        Segment segmentTest = new Segment(new PointReel(positionTestee.Coordonnees), new PointReel(destination.Coordonnees));

                        Synchronizer.Lock(Plateau.ObstaclesBalise);
                        // Test des obstacles
                        foreach (IForme obstacle in obstacles)
                        {
                            if (obstacle.Distance(segmentTest) < distanceSecuriteCote)
                            {
                                franchissable = false;

                                // Si l'obstacle génant est un adversaire, on diminue petit à petit son rayon pour pouvoir s'échapper au bout d'un moment
                                if (Plateau.ObstaclesBalise.Contains(obstacle) && Plateau.RayonAdversaire > 50)
                                {
                                    Robots.GrosRobot.Historique.Log("Adversaire au contact, impossible de s'enfuir, réduction du périmètre adverse", TypeLog.PathFinding);
                                    Plateau.RayonAdversaire -= 10;
                                }
                            }
                        }
                        Synchronizer.Unlock(Plateau.ObstaclesBalise);

                        // Si le semgent entre notre position et le graph relié au graph est parcourable on y va !
                        if (franchissable)
                        {
                            PointsTrouves.Add(new PointReel(positionTestee.Coordonnees));
                            trajectoire.AjouterPoint(new PointReel(positionTestee.Coordonnees));

                            debutNode = new Node(positionTestee.Coordonnees.X, positionTestee.Coordonnees.Y, 0);
                            nbPointsDepart = graph.AddNode(debutNode, obstacles, rayonSecurite, distanceRaccordable);
                        }
                    }
                }
            }

            Node finNode = graph.ClosestNode(destination.Coordonnees.X, destination.Coordonnees.Y, 0, out distance, false);
            if (distance != 0)
            {
                finNode = new Node(destination.Coordonnees.X, destination.Coordonnees.Y, 0);
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

                // Boucle jusqu'à trouver un point qui se connecte au graph jusqu'à 1m devant
                int i;
                for (i = 0; i < 100 && !raccordable; i++)
                {
                    positionTestee.Avancer(10);
                    raccordable = graph.Raccordable(new Node(positionTestee.Coordonnees.X, positionTestee.Coordonnees.Y, 0), obstacles, rayonSecurite, distanceRaccordable);
                }

                // Le point à i*10 mm devant nous est reliable au graph, on cherche à l'atteindre
                if (raccordable)
                {
                    Segment segmentTest = new Segment(new PointReel(positionTestee.Coordonnees), new PointReel(positionActuell.Coordonnees));

                    // Test des obstacles
                    foreach (IForme obstacle in obstacles)
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
                        positionTestee.Avancer(-10);
                        raccordable = graph.Raccordable(new Node(positionTestee.Coordonnees.X, positionTestee.Coordonnees.Y, 0), obstacles, rayonSecurite, distanceRaccordable);
                    }

                    if (raccordable)
                    {
                        franchissable = true;
                        Segment segmentTest = new Segment(new PointReel(positionTestee.Coordonnees), new PointReel(destination.Coordonnees));

                        // Test des obstacles
                        foreach (IForme obstacle in obstacles)
                        {
                            if (obstacle.Distance(segmentTest) < distanceSecuriteCote)
                                franchissable = false;
                        }
                    }
                }

                // Si le semgent entre notre position et le node relié au graph est parcourable on y va !
                if (franchissable)
                {
                    finNode = new Node(positionTestee.Coordonnees.X, positionTestee.Coordonnees.Y, 0);
                    nbPointsArrivee = graph.AddNode(finNode, obstacles, rayonSecurite, distanceRaccordable);
                }
            }

            Synchronizer.Unlock(graph);

            // Teste s'il est possible d'aller directement à la fin sans passer par le graph
            bool toutDroit = true;
            Segment segment = new Segment(new PointReel(debutNode.X, debutNode.Y), new PointReel(finNode.X, finNode.Y));

            foreach (IForme forme in obstacles)
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

                PointsTrouves.Add(new PointReel(finNode.X, finNode.Y));
                trajectoire.AjouterPoint(new PointReel(finNode.X, finNode.Y));
                if (destination.Coordonnees.Distance(new PointReel(finNode.X, finNode.Y)) > 1)
                {
                    PointsTrouves.Add(new PointReel(destination.Coordonnees));
                    trajectoire.AjouterPoint(new PointReel(destination.Coordonnees));
                }
            }

            // Sinon on passe par le graph
            else
            {
                Synchronizer.Lock(graph);

                AStar aStar = new AStar(graph);
                aStar.DijkstraHeuristicBalance = 1;

                //Console.WriteLine("Avant pathFinding : " + (DateTime.Now - debut).TotalMilliseconds + "ms");

                if (aStar.SearchPath(debutNode, finNode))
                {
                    Synchronizer.Unlock(graph);
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
                            PointsTrouves.Add(new PointReel(nodes[iNodeDepart].X, nodes[iNodeDepart].Y));
                            trajectoire.AjouterPoint(new PointReel(nodes[iNodeDepart].X, nodes[iNodeDepart].Y));
                        }

                        CheminEnCoursNoeuds.Add(nodes[iNodeDepart]);

                        bool raccourciPossible = true;
                        for (int iNodeArrivee = nodes.Count - 1; iNodeArrivee > iNodeDepart; iNodeArrivee--)
                        {
                            raccourciPossible = true;

                            Segment racourci = new Segment(new PointReel(nodes[iNodeDepart].X, nodes[iNodeDepart].Y), new PointReel(nodes[iNodeArrivee].X, nodes[iNodeArrivee].Y));
                            //Arc arcRacourci = new Arc(nodes[iNodeDepart], nodes[iNodeArrivee]);
                            //CheminTest = arcRacourci;
                            //arcRacourci.Passable = false;

                            for (int i = obstacles.Count - 1; i >= 4; i--) // > 4 pour ne pas tester les bordures
                            {
                                IForme forme = obstacles[i];
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
                    PointsTrouves.Add(new PointReel(nodes[nodes.Count - 1].X, nodes[nodes.Count - 1].Y));
                    trajectoire.AjouterPoint(new PointReel(nodes[nodes.Count - 1].X, nodes[nodes.Count - 1].Y));
                    Robots.GrosRobot.Historique.Log("Chemin optimisé : " + (CheminEnCoursNoeuds.Count - 2) + " noeud(s) intermédiaire(s)", TypeLog.PathFinding);
                    cheminTrouve = true;

                    if (destination.Coordonnees.Distance(new PointReel(finNode.X, finNode.Y)) > 1)
                    {
                        PointsTrouves.Add(new PointReel(destination.Coordonnees));
                        trajectoire.AjouterPoint(new PointReel(destination.Coordonnees));
                    }
                }
                else
                {
                    Synchronizer.Unlock(graph);
                    CheminEnCoursNoeuds = null;
                    CheminEnCoursArcs = null;
                    cheminTrouve = false;
                }
            }

            Synchronizer.Lock(graph);
            graph.CleanNodesArcsAdd(); 
            Synchronizer.Unlock(graph);

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
                    threadRAZRayonAdverse = new Thread(ThreadRAZRayonAdverse);
                    threadRAZRayonAdverse.Start();
                }

                return trajectoire;
            }
        }

        private static void ThreadRAZRayonAdverse()
        {
            Thread.Sleep(1000);
            while (Plateau.RayonAdversaire < Plateau.RayonAdversaireInitial)
            {
                Plateau.RayonAdversaire++;
                Thread.Sleep(50);
            }
        }
    }

}
