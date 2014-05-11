using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using System.Threading;
using AStarFolder;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot
{
    public abstract class Robot
    {
        public IDRobot IDRobot { get; protected set; }
        public Semaphore SemGraph { get; set; }
        public Carte Carte { get; set; }
        public Historique Historique { get; protected set; }
        public bool DeplacementLigne { get; protected set; }
        public Graph Graph { get; set; }
        public bool FailTrajectoire { get; set; }

        public abstract Position Position { get; set; }
        public PointReel PositionCible { get; set; }

        public abstract int VitesseDeplacement { get; set; }
        public abstract int AccelerationDeplacement { get; set; }
        public abstract int VitessePivot { get; set; }
        public abstract int AccelerationPivot { get; set; }

        public int Taille { get { return Math.Max(Longueur, Largeur); } }
        public int Longueur { get; set; }
        public int Largeur { get; set; }
        public int Rayon { get { return (int)Math.Sqrt(Longueur * Longueur + Largeur * Largeur) / 2; } }

        public List<byte> ServomoteursConnectes { get; protected set; }

        public String Nom { get; set; }

        // Pathfinding
        private Thread threadTrajectoire;
        private Semaphore semTrajectoire;

        public List<Arc> CheminTrouve { get; set; }
        public List<Node> NodeTrouve { get; set; }
        public Arc CheminTest { get; set; }
        public IForme ObstacleTeste { get; set; }
        public IForme ObstacleProbleme { get; set; }
        private bool nouvelleTrajectoire = false;
        public abstract void Avancer(int distance, bool attendre = true);
        public abstract void Reculer(int distance, bool attendre = true);
        public abstract void PivotGauche(double angle, bool attendre = true);
        public abstract void PivotDroite(double angle, bool attendre = true);
        public abstract void Stop(StopMode mode = StopMode.Smooth);
        public abstract void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true);
        public abstract void ReglerOffsetAsserv(int offsetX, int offsetY, double offsetTeta);
        public abstract void Recallage(SensAR sens, bool attendre = true);
        public abstract void EnvoyerPID(int p, int i, int d);
        public abstract List<int>[] MesureTestPid(int consigne, SensAR sens, int nbValeurs);
        public abstract List<double>[] DiagnosticCpuPwm(int nbValeurs);
        public abstract bool DemandeCapteurOnOff(CapteurOnOff capteur, bool attendre = true);

        public abstract void ActionneurOnOff(ActionneurOnOffID actionneur, bool on);

        public abstract void Init();
        public abstract void AlimentationPuissance(bool on);
        public abstract void Reset();

        public abstract void ArmerJack();
        public abstract bool GetJack(bool historique = true);
        public abstract Color GetCouleurEquipe(bool historique = true);

        public Dictionary<ServomoteurID, bool> ServoActive { get; set; }
        public Dictionary<MoteurID, bool> MoteurTourne { get; set; }

        public double TensionPack1 { get; protected set; }
        public double TensionPack2 { get; protected set; }

        public void Diagnostic()
        {
            if (this == Robots.GrosRobot)
            {
                Lent();
                int tempsPause = 400;
                Avancer(50);
                Reculer(50);
                PivotDroite(10);
                PivotGauche(10);
                // TODO
            }
        }

        public virtual void BougeServo(ServomoteurID servo, int position)
        {
            if (ServoActive.ContainsKey(servo))
            {
                if (servo == ServomoteurID.GRFruitsCoude && position != Config.CurrentConfig.PositionGRCoudeRange ||
                    servo == ServomoteurID.GRFruitsEpaule && position != Config.CurrentConfig.PositionGREpauleRange)
                    ServoActive[servo] = true;
                else
                    ServoActive[servo] = false;
            }
        }

        public abstract void ServoVitesse(ServomoteurID servo, int vitesse);

        public virtual void TourneMoteur(MoteurID moteur, int vitesse)
        {
            if (MoteurTourne.ContainsKey(moteur))
                MoteurTourne[moteur] = vitesse == 0 ? false : true;
        }

        public void PositionerAngle(Angle angle, double marge = 0)
        {
            Angle diff = angle - Position.Angle;
            if (Math.Abs(diff.AngleDegres) > marge)
            {
                if (diff.AngleDegres > 0)
                    PivotDroite(diff.AngleDegres);
                else
                    PivotGauche(-diff.AngleDegres);
            }
        }

        /// <summary>
        /// Liste des noeuds du chemin en cours de parcours
        /// </summary>
        public List<Node> CheminEnCoursNoeuds { get; set; }

        /// <summary>
        /// Liste des arcs du chemin en cours de parcours
        /// </summary>
        public List<Arc> CheminEnCoursArcs { get; set; }

        public Robot()
        {
            CheminTrouve = new List<Arc>();
            CheminEnCoursArcs = new List<Arc>();
            NodeTrouve = new List<Node>();
            ServoActive = new Dictionary<ServomoteurID, bool>();
            foreach (ServomoteurID servo in Enum.GetValues(typeof(ServomoteurID)))
                ServoActive.Add(servo, false);
            MoteurTourne = new Dictionary<MoteurID, bool>();
            foreach (MoteurID moteur in Enum.GetValues(typeof(MoteurID)))
                MoteurTourne.Add(moteur, false);

            SemGraph = new Semaphore(1, 1);

            TensionPack1 = TensionPack2 = 0;
            FailTrajectoire = false;
        }

        public void Lent()
        {
            if (this == Robots.GrosRobot)
            {
                VitesseDeplacement = Config.CurrentConfig.GRVitesseLigneLent;
                AccelerationDeplacement = Config.CurrentConfig.GRAccelerationLigneLent;
                VitessePivot = Config.CurrentConfig.GRVitessePivotLent;
                AccelerationPivot = Config.CurrentConfig.GRAccelerationLigneLent;
            }
            else
            {
                VitesseDeplacement = Config.CurrentConfig.PRVitesseLigneLent;
                AccelerationDeplacement = Config.CurrentConfig.PRAccelerationLigneLent;
                VitessePivot = Config.CurrentConfig.PRVitessePivotLent;
                AccelerationPivot = Config.CurrentConfig.PRAccelerationLigneLent;
            }
        }

        public void Rapide()
        {
            if (this == Robots.GrosRobot)
            {
                VitesseDeplacement = Config.CurrentConfig.GRVitesseLigneRapide;
                AccelerationDeplacement = Config.CurrentConfig.GRAccelerationLigneRapide;
                VitessePivot = Config.CurrentConfig.GRVitessePivotRapide;
                AccelerationPivot = Config.CurrentConfig.GRAccelerationLigneRapide;
            }
            else
            {
                VitesseDeplacement = Config.CurrentConfig.PRVitesseLigneRapide;
                AccelerationDeplacement = Config.CurrentConfig.PRAccelerationLigneRapide;
                VitessePivot = Config.CurrentConfig.PRVitessePivotRapide;
                AccelerationPivot = Config.CurrentConfig.PRAccelerationLigneRapide;
            }
        }

        public bool GotoXYTeta(double x, double y, Angle teta)
        {
            if (PathFinding(x, y, 0, true))
                PositionerAngle(teta, 0.5);
            else
                return false;

            return true;
        }

        public bool PathFinding(double x, double y, int timeOut = 0, bool attendre = false)
        {
            Historique.Log("Lancement pathfinding pour aller en " + x + " : " + y, TypeLog.PathFinding);
            PointReel destination = new PointReel(x, y);

            if (destination.Distance(Position.Coordonnees) <= 10)
                return true;

            semTrajectoire = new Semaphore(0, 999);

            succesPathFinding = false;

            ParcoursPathFinding(x, y, timeOut, attendre);

            if (attendre)
                semTrajectoire.WaitOne();

            return succesPathFinding;
        }

        private bool succesPathFinding;
        protected void ParcoursPathFinding(double x, double y, int timeOut = 0, bool attendre = false)
        {
            MajGraphFranchissable();

            CheminEnCoursNoeuds = new List<Node>();
            CheminEnCoursArcs = new List<Arc>();

            double distance;

            SemGraph.WaitOne();

            int nbPointsDepart = 0;
            int nbPointsArrivee = 0;

            List<IForme> obstacles = CalculerObstacles();
            Node debutNode;
            Node nodeProche = Graph.ClosestNode(Position.Coordonnees.X, Position.Coordonnees.Y, 0, out distance, false);
            if (distance != 0)
            {
                debutNode = new Node(Position.Coordonnees.X, Position.Coordonnees.Y, 0);
                nbPointsDepart = AddNode(Graph, debutNode, 600);
            }
            else
                debutNode = nodeProche;

            if (nbPointsDepart == 0)
            {
                // On ne peut pas partir de là où on est

                Position positionActuelle = new Position(new Angle(Position.Angle), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));
                bool franchissable = true;

                int i;
                for(i = 0; i < 100 && nbPointsDepart == 0; i += 1)
                {
                    positionActuelle.Avancer(10);
                    nbPointsDepart = AddNode(Graph, new Node(positionActuelle.Coordonnees.X, positionActuelle.Coordonnees.Y, 0), 600);

                    foreach (Arc a in arcsAdd)
                        Graph.RemoveArc(a);
                    arcsAdd.Clear();

                    foreach (Node n in nodesAdd)
                        Graph.RemoveNode(n);
                    nodesAdd.Clear();
                }

                if (nbPointsDepart > 0)
                {
                    Segment segmentTest = new Segment(new PointReel(positionActuelle.Coordonnees.X, positionActuelle.Coordonnees.Y), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));

                    foreach (IForme obstacle in obstacles)
                    {
                        if (obstacle.Distance(segmentTest) < Longueur / 2)
                            franchissable = false;
                    }

                    if (franchissable)
                    {
                        Avancer(i * 10);
                        debutNode = new Node(Position.Coordonnees.X, Position.Coordonnees.Y, 0);
                        nbPointsDepart = AddNode(Graph, debutNode, 600);
                    }
                }

                if (!franchissable)
                {
                    franchissable = true;
                    positionActuelle = new Position(new Angle(Position.Angle), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));
                    nbPointsDepart = 0;
                    for (i = 0; i < 100 && nbPointsDepart == 0; i += 1)
                    {
                        positionActuelle.Avancer(-10);
                        nbPointsDepart = AddNode(Graph, new Node(positionActuelle.Coordonnees.X, positionActuelle.Coordonnees.Y, 0), 600);

                        foreach (Arc a in arcsAdd)
                            Graph.RemoveArc(a);
                        arcsAdd.Clear();

                        foreach (Node n in nodesAdd)
                            Graph.RemoveNode(n);
                        nodesAdd.Clear();
                    }

                    if (nbPointsDepart > 0)
                    {
                        Segment segmentTest = new Segment(new PointReel(positionActuelle.Coordonnees.X, positionActuelle.Coordonnees.Y), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));

                        foreach (IForme obstacle in obstacles)
                        {
                            if (obstacle.Distance(segmentTest) < Longueur / 2)
                                franchissable = false;
                        }

                        if (franchissable)
                        {
                            Reculer(i * 10);
                            debutNode = new Node(Position.Coordonnees.X, Position.Coordonnees.Y, 0);
                            nbPointsDepart = AddNode(Graph, debutNode, 600);
                        }
                    }
                }
            }

            Node finNode = Graph.ClosestNode(x, y, 0, out distance, false);
            if (distance != 0)
            {
                finNode = new Node(x, y, 0);
                nbPointsArrivee = AddNode(Graph, finNode, 600);
            }
            if (nbPointsArrivee == 0)
            {
                // On ne peut pas arriver là où on souhaite aller
                // On teste si on peut faire une approche en ligne 
            }

            SemGraph.Release();

            // Teste s'il est possible d'aller directement à la fin sans passer par le graph
            bool toutDroit = true;
            Segment segment = new Segment(new PointReel(debutNode.X, debutNode.Y), new PointReel(finNode.X, finNode.Y));

            foreach (IForme forme in obstacles)
            {
                if (TropProche(segment, forme))
                {
                    toutDroit = false;
                    break;
                }
            }

            if (toutDroit)
            {
                Historique.Log("Chemin trouvé : ligne droite", TypeLog.PathFinding);
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

                    Historique.Log("Chemin trouvé : " + (nodes.Count - 2) + " noeud(s) intermédiaire(s)", TypeLog.PathFinding);

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

                            List<IForme> obstaclesPlateau = CalculerObstacles();

                            for (int i = obstaclesPlateau.Count - 1; i >= 4; i--)
                            {
                                IForme forme = obstaclesPlateau[i];
                                ObstacleTeste = forme;
                                ObstacleProbleme = null;

                                if (TropProche(racourci, forme))
                                {
                                    ObstacleProbleme = forme;
                                    if(Config.CurrentConfig.AfficheDetailTraj > 0)
                                        Thread.Sleep(Config.CurrentConfig.AfficheDetailTraj);
                                    raccourciPossible = false;
                                    break;
                                }
                                //else if(Config.CurrentConfig.AfficheDetailTraj > 0)
                                //    Thread.Sleep(Config.CurrentConfig.AfficheDetailTraj);
                            }
                            if(Config.CurrentConfig.AfficheDetailTraj > 0)
                                Thread.Sleep(Config.CurrentConfig.AfficheDetailTraj);
                            ObstacleTeste = null;
                            if (raccourciPossible)
                            {
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
                    Historique.Log("Chemin optimisé : " + (CheminEnCoursNoeuds.Count - 2) + " noeud(s) intermédiaire(s)", TypeLog.PathFinding);
                }
                else
                {
                    CheminEnCoursNoeuds.Clear();
                    CheminEnCoursArcs.Clear();
                }
            }

            ObstacleProbleme = null;
            ObstacleTeste = null;
            NodeTrouve = new List<Node>();
            CheminTrouve = new List<Arc>();

            SemGraph.WaitOne();

            foreach (Arc a in arcsAdd)
                Graph.RemoveArc(a);
            arcsAdd.Clear();

            foreach (Node n in nodesAdd)
                Graph.RemoveNode(n);
            nodesAdd.Clear();

            if (this == Robots.GrosRobot)
                Plateau.ChargerGraphGros();
            if (this == Robots.PetitRobot)
                Plateau.ChargerGraphPetit();

            SemGraph.Release();
            MajGraphFranchissable();

            PositionCible = new PointReel(x, y);
            AutreRobot.MajGraphFranchissable();

            /*List<IForme> obstacles = new List<IForme>(Plateau.ObstaclesTemporaires);
            Plateau.ObstaclesTemporaires = new List<IForme>();
            foreach (IForme f in obstacles)
                Plateau.AjouterObstacle(f);*/

            //MajGraphFranchissable();

            //Console.WriteLine((DateTime.Now - debut).TotalMilliseconds + " ms");

            if (CheminEnCoursArcs.Count == 0)
            {
                semTrajectoire.Release();
                succesPathFinding = false;
                return;
            }
            else
            {
                // Execution du parcours
                threadTrajectoire = new Thread(ThreadChemin);
                threadTrajectoire.Start();
                return;
            }
        }



        /// <summary>
        /// Ajoute un noeud au graph en reliant tous les points à une distance maximale
        /// </summary>
        /// <param name="node">Noeud à ajouter</param>
        /// <param name="distanceMax">Distance (mm) max de liaison avec les autres noeuds</param>
        /// <returns>Nombre de points reliés au point ajouté</returns>
        public int AddNode(Graph graph, Node node, double distanceMax = 400, bool ajouter = true)
        {
            double distanceNode;

            // Si un noeud est deja présent à cet endroit on ne l'ajoute pas
            graph.ClosestNode(node.X, node.Y, node.Z, out distanceNode, true);
            if (distanceNode == 0)
                return 0;

            // Teste si le noeud est franchissable avec la liste des obstacles
            foreach (IForme obstacle in Plateau.ObstaclesFixes)
            {
                if (TropProche(obstacle, new PointReel(node.X, node.Y)))
                {
                    node.Passable = false;
                    return 0;
                }
            }

            graph.Nodes.Add(node);
            nodesAdd.Add(node);

            int nbLiaisons = 0;

            // Liaisons avec les autres noeuds du graph
            foreach (Node no in graph.Nodes)
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

                        List<IForme> obstacles = CalculerObstacles();

                        foreach (IForme obstacle in obstacles)
                        {
                            if (TropProche(obstacle, new Segment(new PointReel(no.X, no.Y), new PointReel(node.X, node.Y))))
                            {
                                arc.Passable = false;
                                arc2.Passable = false;
                                break;
                            }
                        }

                        if (arc.Passable)
                        {
                            graph.AddArc(arc);
                            graph.AddArc(arc2);

                            arcsAdd.Add(arc);
                            arcsAdd.Add(arc2);

                            nbLiaisons++;
                        }
                    }
                }
            }

            return nbLiaisons;
        }

        List<Arc> arcsAdd = new List<Arc>();
        List<Node> nodesAdd = new List<Node>();

        /// <summary>
        /// Teste si deux formes sont trop proches pour envisager le passage du robot
        /// </summary>
        /// <param name="forme1">Forme 1</param>
        /// <param name="forme2">Forme 2</param>
        /// <returns>Vrai si les deux formes sont trop proches</returns>
        public bool TropProche(IForme forme1, IForme forme2)
        {
            Type typeForme1 = forme1.GetType();
            Type typeForme2 = forme2.GetType();

            if (typeForme1.IsAssignableFrom(typeof(Segment)))
                if (typeForme2.IsAssignableFrom(typeof(Segment)))
                    return ((Segment)forme1).Distance((Segment)forme2) < Rayon;
                else
                    return ((Segment)forme1).Distance(forme2) < Rayon;
            else
                return forme1.Distance(forme2) < Rayon;
        }

        /// <summary>
        /// Parcours le chemin pour arriver au point de destination
        /// </summary>
        private void ThreadChemin()
        {
            nouvelleTrajectoire = false;
            while (CheminEnCoursNoeuds.Count > 1)
            {
                PointReel c1 = new PointReel(CheminEnCoursNoeuds[0].X, CheminEnCoursNoeuds[0].Y);
                PointReel c2 = new PointReel(CheminEnCoursNoeuds[1].X, CheminEnCoursNoeuds[1].Y);

                Position p = new Position(Position.Angle, c1);
                Direction traj = Maths.GetDirection(p, c2);

                // Teste si il est plus rapide (moins d'angle à tourner) de se déplacer en marche arrière
                bool inverse = false;
                //Console.WriteLine("Angle positif :" + traj.angle.AnglePositif);
                if (Math.Abs(traj.angle.AngleDegres) > 90)
                {
                    inverse = true;
                    traj.angle = new Angle(traj.angle.AngleDegres - 180);
                }

                if (traj.angle.AngleDegres < 0)
                    PivotDroite(-traj.angle.AngleDegres);
                else
                    PivotGauche(traj.angle.AngleDegres);

                if (nouvelleTrajectoire)
                    break;

                if (FailTrajectoire)
                    break;

                bool boucler = false;
                Bloque = false;
                do
                {
                    boucler = false;
                    Segment ligne = new Segment(c1, c2);

                    if (AutreRobot.CheminEnCoursNoeuds != null && AutreRobot.CheminEnCoursNoeuds.Count >= 2)
                    {
                        PointReel c1g = new PointReel(AutreRobot.Position.Coordonnees.X, AutreRobot.Position.Coordonnees.Y);
                        PointReel c2g = new PointReel(AutreRobot.CheminEnCoursNoeuds[1].X, AutreRobot.CheminEnCoursNoeuds[1].Y);
                        Segment ligneAutre = new Segment(c1g, c2g);

                        if (ligne.Distance(ligneAutre) < Robots.GrosRobot.Rayon + Robots.PetitRobot.Rayon)
                            boucler = true;
                    }

                    if (boucler || AutreRobot.Position.Coordonnees.Distance(ligne) < Robots.GrosRobot.Rayon + Robots.PetitRobot.Rayon)
                    {
                        boucler = true;
                        Thread.Sleep(100);
                    }

                    // Teste si l'autre robot est bloqué si on peut avancer sans problèmes
                    // le sémaphore permet de ne pas lancer les deux robots sur ce déblocage en même temps
                    if (boucler)
                    {
                        semDeblocage.WaitOne();

                        if (AutreRobot.Bloque && ligne.Distance(AutreRobot.Position.Coordonnees) > Robots.GrosRobot.Rayon + Robots.PetitRobot.Rayon)
                        {
                            Console.WriteLine("Autorisation déblocage");
                            boucler = false;
                        }
                        else
                            Bloque = true;

                        semDeblocage.Release();
                    }

                    if (Robots.PetitRobot.Bloque && Robots.GrosRobot.Bloque)
                    {
                        Console.WriteLine("Interblocage !");
                        nouvelleTrajectoire = true;
                        boucler = false;
                    }
                } while (boucler);

                Bloque = false;

                if (nouvelleTrajectoire)
                    break;

                if (inverse)
                    Reculer((int)traj.distance);
                else
                    Avancer((int)traj.distance);

                if(CheminEnCoursNoeuds.Count > 0)
                    CheminEnCoursNoeuds.RemoveAt(0);
                if (CheminEnCoursArcs.Count > 0)
                    CheminEnCoursArcs.RemoveAt(0);

                Robots.GrosRobot.Historique.Log("Noeud atteint", TypeLog.PathFinding);
            }
            if (nouvelleTrajectoire)
            {
                Robots.GrosRobot.Historique.Log("Trajectoire interrompue, calcul d'un nouvel itinéraire", TypeLog.PathFinding);
                ParcoursPathFinding(CheminEnCoursNoeuds[CheminEnCoursNoeuds.Count - 1].X, CheminEnCoursNoeuds[CheminEnCoursNoeuds.Count - 1].Y);
            }
            if (FailTrajectoire)
            {
                Robots.GrosRobot.Historique.Log("Trajectoire échouée", TypeLog.PathFinding);
                succesPathFinding = false;
                if (semTrajectoire != null)
                    semTrajectoire.Release();
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Trajectoire terminée", TypeLog.PathFinding);
                succesPathFinding = true;
                if (semTrajectoire != null)
                    semTrajectoire.Release();
            }
        }

        public bool Bloque { get; set; }
        private static Semaphore semDeblocage = new Semaphore(1, 1);

        public bool ObstacleTest()
        {
            if (nouvelleTrajectoire)
                return false;

            try
            {
                // Teste si le chemin en cours de parcous est toujours franchissable
                if (CheminEnCoursNoeuds != null && CheminEnCoursNoeuds.Count > 1)
                {
                    List<IForme> obstacles = new List<IForme>(Plateau.ObstaclesTemporaires);

                    List<Segment> segmentsTrajectoire = new List<Segment>();
                    // Calcule le segment entre nous et notre destination (permet de ne pas considérer un obstacle sur un tronçon déjà franchi)
                    Segment seg = new Segment(Position.Coordonnees, new PointReel(CheminEnCoursNoeuds[1].X, CheminEnCoursNoeuds[1].Y));
                    segmentsTrajectoire.Add(seg);

                    for (int iArc = 1; iArc < CheminEnCoursArcs.Count; iArc++)
                    {
                        Arc a = CheminEnCoursArcs[iArc];
                        segmentsTrajectoire.Add(new Segment(new PointReel(a.StartNode.X, a.StartNode.Y), new PointReel(a.EndNode.X, a.EndNode.Y)));
                    }
                    foreach (IForme forme in Plateau.ObstaclesTemporaires)
                    {
                        foreach (Segment segment in segmentsTrajectoire)
                        {
                            if (TropProche(seg, forme))
                            {
                                Console.Beep();
                                // Demande de génération d'une nouvelle trajectoire
                                Historique.Log("Trajectoire coupée, annulation", TypeLog.PathFinding);
                                nouvelleTrajectoire = true;
                                if (DeplacementLigne)
                                {
                                    Stop();
                                    Thread.Sleep(2000);
                                }
                            }
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

        public void MajGraphFranchissable()
        {
            SemGraph.WaitOne();

            List<IForme> obstacles = CalculerObstacles();

            foreach (Arc arc in Graph.Arcs)
                arc.Passable = true;

            foreach (Node node in Graph.Nodes)
                node.Passable = true;

            foreach (IForme obstacle in obstacles)
            {
                // Teste les arcs non franchissables
                for (int i = 0; i < Graph.Arcs.Count; i++)
                {
                    Arc arc = (Arc)Graph.Arcs[i];

                    if (arc.Passable)
                    {
                        Segment segment = new Segment(new PointReel(arc.StartNode.X, arc.StartNode.Y), new PointReel(arc.EndNode.X, arc.EndNode.Y));
                        if (Robots.GrosRobot.TropProche(obstacle, segment))
                        {
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
                        if (Robots.GrosRobot.TropProche(obstacle, noeud))
                        {
                            n.Passable = false;
                        }
                    }
                }
            }

            SemGraph.Release();
        }

        public override string ToString()
        {
            return Nom;
        }

        protected Robot AutreRobot
        {
            get
            {
                if (this == Robots.GrosRobot)
                    return Robots.PetitRobot;
                else
                    return Robots.GrosRobot;
            }
        }

        public List<IForme> CalculerObstacles()
        {
            List<IForme> obstacles = new List<IForme>();
            obstacles.AddRange(Plateau.ListeObstacles);
            obstacles.Add(new Cercle(AutreRobot.Position.Coordonnees, AutreRobot.Rayon));
            obstacles.Add(new Cercle(AutreRobot.PositionCible, AutreRobot.Rayon));

            return obstacles;
        }
    }
}
