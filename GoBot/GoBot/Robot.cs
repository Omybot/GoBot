﻿using System;
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

        public bool LancementBalles { get; set; }
        public int NbBallesBlanchesCharges { get; set; }
        public bool BalleCouleurChargee { get; set; }
        public Color CouleurBalleChargee { get; set; }


        public abstract int VitesseDeplacement { get; set; }
        public abstract int AccelerationDeplacement { get; set; }
        public abstract int VitessePivot { get; set; }
        public abstract int AccelerationPivot { get; set; }

        public int Taille { get { return Math.Max(Longueur, Largeur); } }
        public int Longueur { get; set; }
        public int Largeur { get; set; }
        public int Rayon { get { return (int)Math.Sqrt(Longueur * Longueur + Largeur * Largeur) / 2; } }

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
        public abstract void ReglerOffsetAsserv(int offsetX, int offsetY, int offsetTeta);
        public abstract void Recallage(SensAR sens, bool attendre = true);
        public abstract void EnvoyerPID(int p, int i, int d);

        public abstract void TourneMoteur(MoteurID moteur, int vitesse);
        public abstract void ActionneurOnOff(ActionneurOnOffID actionneur, bool on);

        public abstract void Init();
        public abstract void AlimentationPuissance(bool on);
        public abstract void Reset();

        public abstract void ArmerJack();
        public abstract bool GetPresenceBalle(bool historique = true);
        public abstract Color GetCouleurBalle(bool historique = true);
        public abstract bool GetPresenceAssiette(bool historique = true);
        public abstract bool GetAspiRemonte(bool historique = true);
        public abstract int GetVitesseCanon(bool historique = true);
        public abstract bool GetJack(bool historique = true);

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
                TourneMoteur(MoteurID.GRCanonTMin, 7000);
                Thread.Sleep(tempsPause);
                TourneMoteur(MoteurID.GRCanonTMin, 0);
                Thread.Sleep(tempsPause);
                TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
                Thread.Sleep(tempsPause);
                TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
            }
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
            LancementBalles = false;
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

        public bool PathFinding(double x, double y, int timeOut = 0, bool attendre = false)
        {
            Robots.GrosRobot.Historique.Log("Lancement pathfinding pour aller en " + x + " : " + y, TypeLog.PathFinding);
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
            Console.WriteLine("ParcoursPathFinding veut prendre");
            Plateau.SemaphoreGraph.WaitOne();
            Console.WriteLine("ParcoursPathFinding prends");

            CheminEnCoursNoeuds = new List<Node>();
            CheminEnCoursArcs = new List<Arc>();

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
                Console.WriteLine("5");
                Robots.GrosRobot.Historique.Log("Chemin trouvé : ligne droite", TypeLog.PathFinding);
                Console.WriteLine("5.1");
                CheminEnCoursNoeuds.Add(debutNode);
                Console.WriteLine("5.2");
                CheminEnCoursNoeuds.Add(finNode);
                Console.WriteLine("5.3");

                Arc arcToutDroit = new Arc(debutNode, finNode);
                Console.WriteLine("5.4");
                arcToutDroit.Weight = 99999999;
                Console.WriteLine("5.5");
                CheminEnCoursArcs.Add(arcToutDroit);
                Console.WriteLine("5.6");
            }

            // Sinon on passe par le graph
            else
            {
                AStar aStar = new AStar(Plateau.Graph);
                aStar.DijkstraHeuristicBalance = 1;
                
            Console.WriteLine("6");
                if (aStar.SearchPath(debutNode, finNode))
                {
                    Console.WriteLine("7");
                    List<Node> nodes = aStar.PathByNodes.ToList<Node>();
                    Console.WriteLine("7.1");
                    List<Arc> arcs = aStar.PathByArcs.ToList<Arc>();
                    Console.WriteLine("7.2");
                    Robots.GrosRobot.Historique.Log("Chemin trouvé : " + (nodes.Count - 2) + " noeud(s) intermédiaire(s)", TypeLog.PathFinding);

                    Console.WriteLine("7.3");
                    CheminEnCoursNoeuds = new List<Node>();
                    Console.WriteLine("7.4");
                    CheminEnCoursArcs = new List<Arc>();

                    Console.WriteLine("8");
                    CheminTrouve = new List<Arc>(arcs);
                    NodeTrouve = new List<Node>(nodes);

                    Console.WriteLine("9");
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
                    Console.WriteLine("10");
                    
                    CheminEnCoursNoeuds.Add(nodes[nodes.Count - 1]);
                    Robots.GrosRobot.Historique.Log("Chemin optimisé : " + (CheminEnCoursNoeuds.Count - 2) + " noeud(s) intermédiaire(s)", TypeLog.PathFinding);
                }
                else
                {
                    Console.WriteLine("11");
                    CheminEnCoursNoeuds.Clear();
                    CheminEnCoursArcs.Clear();
                }
            }
            Console.WriteLine("12");

            ObstacleProbleme = null;
            ObstacleTeste = null;
            NodeTrouve = new List<Node>();
            CheminTrouve = new List<Arc>();
            
            Console.WriteLine("11");
            // Reset du graph (Trouver un meilleur moyen ?)
            Plateau.ChargerGraph();
            List<IForme> obstacles = new List<IForme>(Plateau.ObstaclesTemporaires);
            Plateau.ObstaclesTemporaires = new List<IForme>();
            foreach (IForme f in obstacles)
                Plateau.AjouterObstacle(f);
            
            Console.WriteLine("12");
            Plateau.SemaphoreGraph.Release();
            Console.WriteLine("ParcoursPathFinding libère");

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
            {
                Robots.GrosRobot.Historique.Log("Trajectoire interrompue, calcul d'un nouvel itinéraire", TypeLog.PathFinding);
                ParcoursPathFinding(CheminEnCoursNoeuds[CheminEnCoursNoeuds.Count - 1].X, CheminEnCoursNoeuds[CheminEnCoursNoeuds.Count - 1].Y);
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Trajectoire terminée", TypeLog.PathFinding);
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
