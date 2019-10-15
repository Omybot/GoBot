using AStarFolder;
using Geometry;
using Geometry.Shapes;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.BoardContext;

namespace GoBot.PathFinding
{
    static class PathFinder
    {
        private static ThreadLink _linkResetRadius;

        public static List<Node> CheminEnCoursNoeuds { get; private set; }
        public static List<Node> CheminEnCoursNoeudsSimplifyed { get; private set; }
        public static List<Arc> CheminEnCoursArcs { get; private set; }

        public static Segment CheminTest { get; private set; }
        public static IShape ObstacleTeste { get; private set; }
        public static IShape ObstacleProbleme { get; private set; }
        public static List<RealPoint> PointsTrouves { get; private set; }

        private static Trajectory DirectTrajectory(Graph graph, IEnumerable<IShape> obstacles, Position startPos, Position endPos, double securityRadius)
        {
            Segment directLine = new Segment(new RealPoint(startPos.Coordinates), new RealPoint(endPos.Coordinates));

            Trajectory output = null;
            if (obstacles.All(o => o.Distance(directLine) > securityRadius))
            {
                output = new Trajectory();
                output.StartAngle = startPos.Angle;
                output.AddPoint(startPos.Coordinates);
                output.AddPoint(endPos.Coordinates);
                output.EndAngle = endPos.Angle;
            }

            return output;
        }

        public static Trajectory ChercheTrajectoire(Graph graph, IEnumerable<IShape> obstacles, IEnumerable<IShape> opponents, Position startPos, Position endPos, double rayonSecurite, double distanceSecuriteCote)
        {
            Stopwatch sw = Stopwatch.StartNew();
            bool pathFound = false;

            Trajectory output = DirectTrajectory(graph, obstacles.Concat(opponents), startPos, endPos, rayonSecurite);

            if (output != null)
                pathFound = true;
            else
            {
                _linkResetRadius = null;

                double distance;
                bool raccordable = false;

                output = new Trajectory();
                output.StartAngle = startPos.Angle;
                output.EndAngle = endPos.Angle;

                PointsTrouves = new List<RealPoint>();
                PointsTrouves.Add(new RealPoint(startPos.Coordinates));
                output.AddPoint(new RealPoint(startPos.Coordinates));

                lock (graph)
                {
                    Console.WriteLine("Cherche trajectoire début");
                    int nbPointsDepart = 0;
                    int nbPointsArrivee = 0;

                    Node debutNode = null, finNode = null;
                    Node nodeProche = graph.ClosestNode(startPos.Coordinates, out distance);
                    if (distance != 0)
                    {
                        debutNode = new Node(startPos.Coordinates);
                        nbPointsDepart = graph.AddNode(debutNode, obstacles, rayonSecurite);
                    }
                    else
                    {
                        debutNode = nodeProche;
                        nbPointsDepart = debutNode.OutgoingArcs.Count;
                    }

                    //TODO2018 phase d'approche finale pourrie, l'angle final peut se faire à la fin au lieu de à la fin du path finding avant l'approche finale
                    if (nbPointsDepart == 0)
                    {
                        // On ne peut pas partir de là où on est

                        Position positionTestee = new Position(startPos);
                        bool franchissable = true;

                        // Boucle jusqu'à trouver un point qui se connecte au graph jusqu'à 1m devant
                        int i;
                        for (i = 0; i < 100 && !raccordable; i += 1)
                        {
                            positionTestee.Move(10);

                            debutNode = new Node(positionTestee.Coordinates);
                            raccordable = graph.Raccordable(debutNode, obstacles, rayonSecurite);
                        }

                        // Le point à i*10 mm devant nous est reliable au graph, on cherche à l'atteindre
                        if (raccordable)
                        {
                            Segment segmentTest = new Segment(new RealPoint(positionTestee.Coordinates), new RealPoint(startPos.Coordinates));

                            // Test des obstacles

                            foreach (IShape obstacle in obstacles)
                            {
                                if (obstacle.Distance(segmentTest) < distanceSecuriteCote)
                                {
                                    franchissable = false;

                                    // Si l'obstacle génant est un adversaire, on diminue petit à petit son rayon pour pouvoir s'échapper au bout d'un moment
                                    if (opponents.Contains(obstacle) && GameBoard.OpponentRadius > 50)
                                    {
                                        Robots.GrosRobot.Historique.Log("Adversaire au contact, impossible de s'enfuir, réduction du périmètre adverse", TypeLog.PathFinding);
                                        GameBoard.OpponentRadius -= 10;
                                        _linkResetRadius?.Cancel();
                                    }
                                }
                            }

                            // Si le semgent entre notre position et le graph relié au graph est parcourable on y va !
                            if (franchissable)
                            {
                                PointsTrouves.Add(new RealPoint(positionTestee.Coordinates));
                                output.AddPoint(new RealPoint(positionTestee.Coordinates));

                                debutNode = new Node(positionTestee.Coordinates);
                                nbPointsDepart = graph.AddNode(debutNode, obstacles, rayonSecurite);
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
                            positionTestee = new Position(startPos);
                            for (i = 0; i > -100 && !raccordable; i--)
                            {
                                positionTestee.Move(-10);

                                debutNode = new Node(positionTestee.Coordinates);
                                raccordable = graph.Raccordable(debutNode, obstacles, rayonSecurite);
                            }

                            // Le point à i*10 mm derrière nous est reliable au graph, on cherche à l'atteindre
                            if (raccordable)
                            {
                                Segment segmentTest = new Segment(new RealPoint(positionTestee.Coordinates), new RealPoint(startPos.Coordinates));

                                // Test des obstacles
                                foreach (IShape obstacle in obstacles)
                                {
                                    if (obstacle.Distance(segmentTest) < distanceSecuriteCote)
                                    {
                                        franchissable = false;

                                        // Si l'obstacle génant est un adversaire, on diminue petit à petit son rayon pour pouvoir s'échapper au bout d'un moment
                                        if (opponents.Contains(obstacle) && GameBoard.OpponentRadius > 50)
                                        {
                                            Robots.GrosRobot.Historique.Log("Adversaire au contact, impossible de s'enfuir, réduction du périmètre adverse", TypeLog.PathFinding);
                                            GameBoard.OpponentRadius -= 10;
                                            _linkResetRadius?.Cancel();
                                        }
                                    }
                                }

                                // Si le semgent entre notre position et le graph relié au graph est parcourable on y va !
                                if (franchissable)
                                {
                                    PointsTrouves.Add(new RealPoint(positionTestee.Coordinates));
                                    output.AddPoint(new RealPoint(positionTestee.Coordinates));

                                    debutNode = new Node(positionTestee.Coordinates);
                                    nbPointsDepart = graph.AddNode(debutNode, obstacles, rayonSecurite);
                                }
                            }
                        }
                    }

                    if (nbPointsDepart > 0)
                    {
                        finNode = graph.ClosestNode(endPos.Coordinates, out distance);
                        if (distance != 0)
                        {
                            finNode = new Node(endPos.Coordinates);
                            nbPointsArrivee = graph.AddNode(finNode, obstacles, rayonSecurite);
                        }
                        else
                        {
                            nbPointsArrivee = 1;
                        }
                        if (nbPointsArrivee == 0)
                        {
                            Console.WriteLine("Blocage arrivée");
                            // On ne peut pas arriver là où on souhaite aller
                            // On teste si on peut faire une approche en ligne 
                            // teta ne doit pas être nul sinon c'est qu'on ne maitrise pas l'angle d'arrivée et on ne connait pas l'angle d'approche

                            Position positionTestee = new Position(endPos);
                            bool franchissable = true;
                            raccordable = false;

                            // Boucle jusqu'à trouver un point qui se connecte au graph jusqu'à 1m devant
                            int i;
                            for (i = 0; i < 100 && !raccordable; i++)
                            {
                                positionTestee.Move(10);
                                raccordable = graph.Raccordable(new Node(positionTestee.Coordinates), obstacles, rayonSecurite);
                            }

                            // Le point à i*10 mm devant nous est reliable au graph, on cherche à l'atteindre
                            if (raccordable)
                            {
                                Segment segmentTest = new Segment(new RealPoint(positionTestee.Coordinates), new RealPoint(endPos.Coordinates));

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
                                positionTestee = new Position(endPos);
                                nbPointsArrivee = 0;

                                for (i = 0; i > -100 && !raccordable; i--)
                                {
                                    positionTestee.Move(-10);
                                    raccordable = graph.Raccordable(new Node(positionTestee.Coordinates), obstacles, rayonSecurite);
                                }

                                if (raccordable)
                                {
                                    franchissable = true;
                                    Segment segmentTest = new Segment(new RealPoint(positionTestee.Coordinates), new RealPoint(endPos.Coordinates));

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
                                finNode = new Node(positionTestee.Coordinates);
                                nbPointsArrivee = graph.AddNode(finNode, obstacles, rayonSecurite);
                            }
                        }
                    }

                    if (nbPointsDepart > 0 && nbPointsArrivee > 0)
                    {

                        // Teste s'il est possible d'aller directement à la fin sans passer par le graph
                        bool toutDroit = true;
                        Segment segment = new Segment(debutNode.Position, finNode.Position);

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
                            pathFound = true;

                            PointsTrouves.Add(finNode.Position);
                            output.AddPoint(finNode.Position);
                            if (endPos.Coordinates.Distance(finNode.Position) > 1)
                            {
                                PointsTrouves.Add(new RealPoint(endPos.Coordinates));
                                output.AddPoint(new RealPoint(endPos.Coordinates));
                            }
                        }

                        // Sinon on passe par le graph
                        else
                        {
                            AStar aStar = new AStar(graph);
                            aStar.DijkstraHeuristicBalance = 0;

                            //Console.WriteLine("Avant pathFinding : " + (DateTime.Now - debut).TotalMilliseconds + "ms");

                            if (aStar.SearchPath(debutNode, finNode))
                            {
                                //Console.WriteLine("PathFinding trouvé : " + (DateTime.Now - debut).TotalMilliseconds + "ms");

                                List<Node> nodes = aStar.PathByNodes.ToList<Node>();

                                Robots.GrosRobot.Historique.Log("Chemin trouvé : " + (nodes.Count - 2) + " noeud(s) intermédiaire(s)", TypeLog.PathFinding);

                                CheminEnCoursNoeuds = new List<Node>();
                                CheminEnCoursArcs = new List<Arc>();

                                //Console.WriteLine("Début simplification : " + (DateTime.Now - debut).TotalMilliseconds + "ms");

                                // Simplification du chemin
                                // On part du début et on essaie d'aller au point du plus éloigné au moins éloigné en testant si le passage est possible
                                // Si c'est possible on zappe tous les points entre les deux
                                for (int iNodeDepart = 0; iNodeDepart < nodes.Count - 1; iNodeDepart++)
                                {
                                    if (iNodeDepart != 0)
                                    {
                                        PointsTrouves.Add(nodes[iNodeDepart].Position);
                                        output.AddPoint(nodes[iNodeDepart].Position);
                                    }

                                    CheminEnCoursNoeuds.Add(nodes[iNodeDepart]);

                                    bool raccourciPossible = true;
                                    for (int iNodeArrivee = nodes.Count - 1; iNodeArrivee > iNodeDepart; iNodeArrivee--)
                                    {
                                        raccourciPossible = true;

                                        Segment racourci = new Segment(nodes[iNodeDepart].Position, nodes[iNodeArrivee].Position);
                                        //Arc arcRacourci = new Arc(nodes[iNodeDepart], nodes[iNodeArrivee]);
                                        CheminTest = racourci;
                                        //arcRacourci.Passable = false;

                                        for (int i = obstacles.Count() - 1; i >= 4; i--) // > 4 pour ne pas tester les bordures
                                        {
                                            IShape forme = obstacles.ElementAt(i);
                                            ObstacleTeste = forme;
                                            ObstacleProbleme = null;

                                            if (racourci.Distance(forme) < rayonSecurite)
                                            {
                                                ObstacleProbleme = forme;

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
                                PointsTrouves.Add(nodes[nodes.Count - 1].Position);
                                output.AddPoint(nodes[nodes.Count - 1].Position);
                                Robots.GrosRobot.Historique.Log("Chemin optimisé : " + (CheminEnCoursNoeuds.Count - 2) + " noeud(s) intermédiaire(s)", TypeLog.PathFinding);
                                pathFound = true;

                                if (endPos.Coordinates.Distance(finNode.Position) > 1)
                                {
                                    PointsTrouves.Add(new RealPoint(endPos.Coordinates));
                                    output.AddPoint(new RealPoint(endPos.Coordinates));
                                }
                            }
                            else
                            {
                                CheminEnCoursNoeuds = null;
                                CheminEnCoursArcs = null;
                                pathFound = false;
                            }
                        }
                    }

                    graph.CleanNodesArcsAdd();

                }
            }

            Dessinateur.CurrentTrack = null;
            //CheminEnCoursNoeuds = null;

            Console.WriteLine("Cherche trajectoire fin : " + sw.ElapsedMilliseconds + "ms");

            PointsTrouves = null;
            ObstacleProbleme = null;
            ObstacleTeste = null;

            //Console.WriteLine("PathFinding en " + (DateTime.Now - debut).TotalMilliseconds + " ms");

            if (!pathFound)
            {
                Robots.GrosRobot.Historique.Log("Chemin non trouvé", TypeLog.PathFinding);
                return null;
            }
            else
            {
                if (GameBoard.OpponentRadius < GameBoard.OpponentRadiusInitial)
                {
                    _linkResetRadius = ThreadManager.CreateThread(link => ResetOpponentRadiusLoop());
                    _linkResetRadius.StartThread();
                }

                if (output.Lines.Count > 1)
                {
                    output = ReduceLines(output, obstacles.Concat(opponents), rayonSecurite);
                }

                return output;
            }
        }

        private static void ResetOpponentRadiusLoop()
        {
            _linkResetRadius.RegisterName();

            Thread.Sleep(1000);
            while (_linkResetRadius != null && !_linkResetRadius.Cancelled && GameBoard.OpponentRadius < GameBoard.OpponentRadiusInitial)
            {
                GameBoard.OpponentRadius++;
                Thread.Sleep(50);
            }
        }

        private static Trajectory ReduceLines(Trajectory traj, IEnumerable<IShape> obstacles, double securityRadius)
        {
            Trajectory output = traj;
            TimeSpan currentDuration = output.GetDuration(Robots.GrosRobot);

            Console.WriteLine("Avant : " + currentDuration.ToString());

            int iSeg = 1;

            while (iSeg < output.Lines.Count - 1)
            {
                Trajectory tested = new Trajectory(output);
                tested.RemoveLine(iSeg);
                iSeg++;

                CheminEnCoursNoeudsSimplifyed = tested.Points.Select(o => new Node(o)).ToList();

                ObstacleProbleme = obstacles.FirstOrDefault(o => tested.Lines.Any(s => s.Distance(o) < securityRadius));
                Thread.Sleep(Config.CurrentConfig.AfficheDetailTraj * 15);

                if (ObstacleProbleme == null)
                {
                    TimeSpan testedDuration = tested.GetDuration(Robots.GrosRobot);

                    if (testedDuration < currentDuration)
                    {
                        output = tested;
                        if (Config.CurrentConfig.AfficheDetailTraj > 0)
                        {
                            CheminEnCoursNoeuds = CheminEnCoursNoeudsSimplifyed;
                            CheminEnCoursNoeudsSimplifyed = null;
                            Thread.Sleep(Config.CurrentConfig.AfficheDetailTraj * 15);
                        }
                        currentDuration = testedDuration;
                        iSeg--;
                    }
                }
            }

            CheminEnCoursNoeuds = null;
            CheminEnCoursNoeudsSimplifyed = null;


            Console.WriteLine("Après : " + currentDuration.ToString());

            return output;
        }
    }
}
