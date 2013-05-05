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
        public Historique Historique { get; protected set; }
        public bool DeplacementLigne { get; protected set; }

        public abstract Position Position { get; set; }

        public abstract void Avancer(int distance, bool attendre = true);
        public abstract void Reculer(int distance, bool attendre = true);
        public abstract void PivotGauche(double angle, bool attendre = true);
        public abstract void PivotDroite(double angle, bool attendre = true);
        public abstract void Stop(StopMode mode = StopMode.Smooth);
        public abstract void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true);
        public abstract void ReglerOffsetAsserv(int offsetX, int offsetY, int offsetTeta);
        public abstract void Recallage(SensAR sens, bool attendre = true);
        public abstract void Init();
        public abstract void TourneMoteur(MoteurID moteur, int vitesse);
        public abstract void EnvoyerPID(int p, int i, int d);
        public abstract void ActionneurOnOff(ActionneurOnOffID actionneur, bool on);
        public abstract void AlimentationPuissance(bool on);

        public abstract bool PresenceBalle(bool historique = true);
        public abstract Color CouleurBalle(bool historique = true);
        public abstract bool PresenceAssiette(bool historique = true);
        public abstract bool AspiRemonte(bool historique = true);

        public void Diagnostic()
        {
            int tempsPause = 500;
            //Avancer(50);
            //Reculer(50);
            BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRBrasDroit, Config.CurrentConfig.PositionGRBrasDroitSorti);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRBrasDroit, Config.CurrentConfig.PositionGRBrasDroitRange);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRBrasGauche, Config.CurrentConfig.PositionGRBrasGaucheSorti);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRBrasGauche, Config.CurrentConfig.PositionGRBrasGaucheRange);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRCamera, Config.CurrentConfig.PositionGRCameraBleu);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRCamera, Config.CurrentConfig.PositionGRCameraRouge);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasHaut);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasRange);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasHaut);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasRange);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurFerme);
            Thread.Sleep(tempsPause);
            BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurOuvert);
            Thread.Sleep(tempsPause);
            ActionneurOnOff(ActionneurOnOffID.GRShutter, true);
            Thread.Sleep(tempsPause);
            ActionneurOnOff(ActionneurOnOffID.GRShutter, false);
            Thread.Sleep(tempsPause);
            TourneMoteur(MoteurID.GRCanon, Config.CurrentConfig.VitessePropulsionBonne);
            Thread.Sleep(tempsPause);
            TourneMoteur(MoteurID.GRCanon, 0);
            Thread.Sleep(tempsPause);
            TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
            Thread.Sleep(tempsPause);
            TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
        }

        public Dictionary<ServomoteurID, bool> ServoSorti { get; set; }
        public virtual void BougeServo(ServomoteurID servo, int position)
        {
            if (ServoSorti.ContainsKey(servo))
            {
                if (servo == ServomoteurID.GRBrasDroit && position == Config.CurrentConfig.PositionGRBrasDroitSorti ||
                    servo == ServomoteurID.GRBrasGauche && position == Config.CurrentConfig.PositionGRBrasGaucheSorti ||
                    servo == ServomoteurID.GRGrandBras && position == Config.CurrentConfig.PositionGRGrandBrasHaut ||
                    servo == ServomoteurID.GRPetitBras && position == Config.CurrentConfig.PositionGRPetitBrasHaut)
                    ServoSorti[servo] = true;
                else
                    ServoSorti[servo] = false;
            }
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

        public abstract int VitesseDeplacement { get; set; }
        public abstract int AccelerationDeplacement { get; set; }
        public abstract int VitessePivot { get; set; }
        public abstract int AccelerationPivot { get; set; }

        public int Taille { get { return Math.Max(Longueur, Largeur); } }
        public abstract int Longueur { get; set; }
        public abstract int Largeur { get; set; }
        public int Rayon { get { return (int)Math.Sqrt(Longueur * Longueur + Largeur * Largeur) / 2; } }

        public abstract String Nom { get; set; }

        // Pathfinding


        Thread th;
        Semaphore semTrajectoire;

        public List<Arc> CheminTrouve;
        public List<Node> NodeTrouve;
        public Arc CheminTest;
        public IForme ObstacleTeste;
        public IForme ObstacleProbleme;
        bool nouvelleTrajectoire = false;

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
            ServoSorti = new Dictionary<ServomoteurID, bool>();
            ServoSorti.Add(ServomoteurID.GRBrasDroit, false);
            ServoSorti.Add(ServomoteurID.GRBrasGauche, false);
            ServoSorti.Add(ServomoteurID.GRGrandBras, false);
            ServoSorti.Add(ServomoteurID.GRPetitBras, false);
        }

        public bool PathFinding(double x, double y, int timeOut = 0, bool attendre = false)
        {
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
        public void ParcoursPathFinding(double x, double y, int timeOut = 0, bool attendre = false)
        {
            Plateau.SemaphoreGraph.WaitOne();

            CheminEnCoursNoeuds = new List<Node>();
            CheminEnCoursArcs = new List<Arc>();

            DateTime debut = DateTime.Now;

            double distance;

            Node debutNode = Plateau.Graph.ClosestNode(Position.Coordonnees.X, Position.Coordonnees.Y, 0, out distance, false);
            if (distance != 0)
            {
                debutNode = new Node(Position.Coordonnees.X, Position.Coordonnees.Y, 0);
                Plateau.AddNode(debutNode, this, 600);
            }
            Node finNode = Plateau.Graph.ClosestNode(x, y, 0, out distance, false);
            if (distance != 0)
            {
                finNode = new Node(x, y, 0);
                Plateau.AddNode(finNode, this, 600);
            }

            // Teste s'il est possible d'aller directement à la fin sans passer par le graph
            bool toutDroit = true;
            Segment segment = new Segment(new PointReel(debutNode.X, debutNode.Y), new PointReel(finNode.X, finNode.Y));
            foreach (IForme forme in Plateau.ListeObstacles)
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
                AStar aStar = new AStar(Plateau.Graph);
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
                            for (int i = Plateau.ListeObstacles.Count - 1; i >= 4; i--)
                            {
                                IForme forme = Plateau.ListeObstacles[i];
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

            // Reset du graph (Trouver un meilleur moyen ?)
            Plateau.ChargerGraph();
            List<IForme> obstacles = new List<IForme>(Plateau.ObstaclesTemporaires);
            Plateau.ObstaclesTemporaires = new List<IForme>();
            foreach (IForme f in obstacles)
                Plateau.AjouterObstacle(f);

            Plateau.SemaphoreGraph.Release();

            if (CheminEnCoursArcs.Count == 0)
            {
                semTrajectoire.Release();
                succesPathFinding = false;
                return;
            }
            else
            {
                // Execution du parcours
                th = new Thread(ThreadChemin);
                th.Start();
                return;
            }
        }


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

                if (inverse)
                    Reculer((int)traj.distance);
                else
                    Avancer((int)traj.distance);

                CheminEnCoursNoeuds.RemoveAt(0);
                CheminEnCoursArcs.RemoveAt(0);

                if (nouvelleTrajectoire)
                    break;
            }
            if (nouvelleTrajectoire)
                ParcoursPathFinding(CheminEnCoursNoeuds[CheminEnCoursNoeuds.Count - 1].X, CheminEnCoursNoeuds[CheminEnCoursNoeuds.Count - 1].Y);
            else
            {
                succesPathFinding = true;
                if (semTrajectoire != null)
                    semTrajectoire.Release();
            }
        }

        public bool ObstacleTest()
        {
            if (nouvelleTrajectoire)
                return false;

            try
            {
                // Teste si le chemin en cours de parcous est toujours franchissable
                if (CheminEnCoursNoeuds != null && CheminEnCoursNoeuds.Count > 0)
                {
                    List<IForme> obstacles = new List<IForme>(Plateau.ObstaclesTemporaires);
                    foreach (IForme forme in Plateau.ObstaclesTemporaires)
                    {
                        foreach (Arc a in CheminEnCoursArcs)
                        {
                            Segment segment = new Segment(new PointReel(a.StartNode.X, a.StartNode.Y), new PointReel(a.EndNode.X, a.EndNode.Y));

                            if (TropProche(segment, forme))
                            {
                                // Demande de génération d'une nouvelle trajectoire
                                nouvelleTrajectoire = true;
                                if (DeplacementLigne)
                                    Stop();
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

        public override string ToString()
        {
            return Nom;
        }
    }
}
