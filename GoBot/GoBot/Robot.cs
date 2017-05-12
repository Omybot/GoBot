using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using System.Threading;
using AStarFolder;
using GoBot.Calculs.Formes;
using System.Drawing;
using GoBot.Actions;
using GoBot.Actionneurs;
using GoBot.PathFinding;
using GoBot.Communications;

namespace GoBot
{
    public abstract class Robot
    {
        // Communication
        public Carte Carte { get; set; }
        public Historique Historique { get; protected set; }
        public double BatterieVoltage { get; protected set; }
        
        // Constitution
        public IDRobot IDRobot { get; protected set; }
        public String Nom { get; set; }
        public int Taille { get { return Math.Max(Longueur, Largeur); } }
        public int Longueur { get; set; }
        public int Largeur { get; set; }
        public int Rayon { get { return (int)Math.Sqrt(Longueur * Longueur + Largeur * Largeur) / 2 - 14; } } // -14 = valeur calculée pour l'année 2015 sur les biseaux

        // Déplacement
        public abstract Position Position { get; set; }
        public PointReel PositionCible { get; set; }
        public bool DeplacementLigne { get; protected set; }
        public bool VitesseAdaptableEnnemi { get; set; }
        public abstract int VitesseDeplacement { get; set; }
        public abstract int AccelerationDebutDeplacement { get; set; }
        public abstract int AccelerationFinDeplacement { get; set; }
        public abstract int VitessePivot { get; set; }
        public abstract int AccelerationPivot { get; set; }
        public int DistanceTotaleParcourue { get; set; }
        public double AngleTotalParcouru { get; set; }
        public List<Position> HistoriqueCoordonnees { get; protected set; }

        // PathFinding
        public Graph Graph { get; set; }
        public Semaphore SemGraph { get; set; }
        public bool TrajectoireEchouee { get; set; }
        private bool TrajectoireCoupee { get; set; }

        private Thread threadTrajectoire;
        private Semaphore semTrajectoire;

        public Semaphore semHistoriquePosition;

        public Trajectoire TrajectoireEnCours = null;
        
        private static Semaphore semDeblocage = new Semaphore(1, 1);

        // Actionneurs / Capteurs

        public List<byte> ServomoteursConnectes { get; protected set; }
        public Dictionary<ServomoteurID, bool> ServoActive { get; set; }
        public Dictionary<MoteurID, bool> MoteurTourne { get; set; }

        public virtual void Avancer(int distance, bool attendre = true)
        {
            DistanceTotaleParcourue += distance;
        }

        public virtual void Reculer(int distance, bool attendre = true)
        {
            DistanceTotaleParcourue += distance;
        }

        public virtual void PivotGauche(double angle, bool attendre = true)
        {
            AngleTotalParcouru += angle;
        }

        public virtual void PivotDroite(double angle, bool attendre = true)
        {
            AngleTotalParcouru += angle;
        }

        public abstract void TrajectoirePolaire(SensAR sens, List<PointReel> points, bool attendre = true);
        public abstract void Stop(StopMode mode = StopMode.Smooth);
        public abstract void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true);
        public abstract void ReglerOffsetAsserv(int offsetX, int offsetY, double offsetTeta);
        public abstract void Recallage(SensAR sens, bool attendre = true);
        public abstract void EnvoyerPID(int p, int i, int d);
        public abstract void EnvoyerPIDCap(int p, int i, int d);
        public abstract void EnvoyerPIDVitesse(int p, int i, int d);
        public abstract List<int>[] MesureTestPid(int consigne, SensAR sens, int nbValeurs);
        public abstract List<double>[] DiagnosticCpuPwm(int nbValeurs);
        public abstract bool DemandeCapteurOnOff(CapteurOnOffID capteur, bool attendre = true);
        public abstract Color DemandeCapteurCouleur(CapteurCouleur capteur, bool attendre = true);
        public abstract void DemandeValeursAnalogiquesIO(bool attendre = true);
        public abstract void DemandeValeursAnalogiquesMove(bool attendre = true);

        public abstract void ActionneurOnOff(ActionneurOnOffID actionneur, bool on);

        public abstract void Init();
        public abstract void AlimentationPuissance(bool on);
        public abstract void Reset();

        public abstract void ArmerJack();
        public abstract bool GetJack();
        public abstract String GetMesureLidar(LidarID lidar, int timeout);
        public abstract Color GetCouleurEquipe(bool historique = true);

        public Dictionary<CapteurOnOffID, bool> CapteurActive { get; set; }
        public Dictionary<CapteurCouleur, Color> CapteursCouleur { get; set; }
        public List<double> ValeursAnalogiquesIO { get; set; }
        public List<double> ValeursAnalogiquesMove { get; set; }

        public delegate void ChangementEtatCapteurOnOffDelegate(CapteurOnOffID capteur, bool etat);
        public event ChangementEtatCapteurOnOffDelegate ChangementEtatCapteurOnOff;

        public delegate void PositionChangeDelegate(Position position);
        public event PositionChangeDelegate PositionChange;

        public delegate void CapteurCouleurDelegate(CapteurCouleur capteur, Color couleur);
        public event CapteurCouleurDelegate CapteurCouleurChange;

        /// <summary>
        /// Génère l'évènement de changement de position
        /// </summary>
        /// <param name="position">Nouvelle position</param>
        protected void ChangerPosition(Position position)
        {
            if (PositionChange != null)
                PositionChange(position);
        }

        /// <summary>
        /// Génère l'évènement de changement d'état d'un capteur
        /// </summary>
        /// <param name="capteur"></param>
        /// <param name="etat"></param>
        protected void ChangerEtatCapteurOnOff(CapteurOnOffID capteur, bool etat)
        {
            CapteurActive[capteur] = etat;
            if (ChangementEtatCapteurOnOff != null)
                ChangementEtatCapteurOnOff(capteur, etat);
        }

        protected void ChangeCouleurCapteur(CapteurCouleur capteur, Color couleur)
        {
            if (CapteurCouleurChange != null)
                CapteurCouleurChange(capteur, couleur);
        }

        public void Diagnostic()
        {
            if (this == Robots.GrosRobot)
            {
                int tempo = 200;
                
                Lent();
                Avancer(50);
                Reculer(50);
                PivotDroite(10);
                PivotGauche(10);
                
                // TODO procédure de diagnostic des actionneurs

            }
        }

        public virtual void BougeServo(ServomoteurID servo, int position)
        {
            if (ServoActive.ContainsKey(servo))
            {
                /*
                 * Todo
                 * if (servo == ServomoteurID.GRFruitsCoude && position != Config.CurrentConfig.PositionGRCoudeRange ||
                    servo == ServomoteurID.GRFruitsEpaule && position != Config.CurrentConfig.PositionGREpauleRange)
                    ServoActive[servo] = true;
                else
                    ServoActive[servo] = false;*/
            }

            Thread.Sleep(10);
        }

        public abstract void ServoVitesse(ServomoteurID servo, int vitesse);

        public virtual void MoteurPosition(MoteurID moteur, int position)
        {
            Historique.AjouterAction(new ActionMoteur(this, position, moteur));
        }

        public virtual void MoteurVitesse(MoteurID moteur, int vitesse)
        {
            if (MoteurTourne.ContainsKey(moteur))
                MoteurTourne[moteur] = vitesse == 0 ? false : true;
            Historique.AjouterAction(new ActionMoteur(this, vitesse, moteur));
        }

        public virtual void MoteurAcceleration(MoteurID moteur, int acceleration)
        {
            Historique.AjouterAction(new ActionMoteur(this, acceleration, moteur));
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

        public Robot()
        {
            VitesseAdaptableEnnemi = true;
            ServoActive = new Dictionary<ServomoteurID, bool>();
            foreach (ServomoteurID servo in Enum.GetValues(typeof(ServomoteurID)))
                ServoActive.Add(servo, false);
            MoteurTourne = new Dictionary<MoteurID, bool>();
            foreach (MoteurID moteur in Enum.GetValues(typeof(MoteurID)))
                MoteurTourne.Add(moteur, false);

            SemGraph = new Semaphore(1, 1);

            BatterieVoltage = 0;
            TrajectoireEchouee = false;
            TrajectoireCoupee = false;

            semHistoriquePosition = new Semaphore(1, int.MaxValue);
        }

        public void Lent()
        {
            if (this == Robots.GrosRobot)
            {
                VitesseDeplacement = Config.CurrentConfig.GRVitesseLigneLent;
                AccelerationDebutDeplacement = Config.CurrentConfig.GRAccelerationLigneLent;
                AccelerationFinDeplacement = Config.CurrentConfig.GRAccelerationFinLigneLent;
                VitessePivot = Config.CurrentConfig.GRVitessePivotLent;
                AccelerationPivot = Config.CurrentConfig.GRAccelerationLigneLent;
            }
            else
            {
                VitesseDeplacement = Config.CurrentConfig.PRVitesseLigneLent;
                AccelerationDebutDeplacement = Config.CurrentConfig.PRAccelerationLigneLent;
                VitessePivot = Config.CurrentConfig.PRVitessePivotLent;
                AccelerationPivot = Config.CurrentConfig.PRAccelerationLigneLent;
            }

            VitesseAdaptableEnnemi = false;
        }

        public void Rapide()
        {
            if (this == Robots.GrosRobot)
            {
                VitesseDeplacement = Config.CurrentConfig.GRVitesseLigneRapide;
                AccelerationDebutDeplacement = Config.CurrentConfig.GRAccelerationLigneRapide;
                AccelerationFinDeplacement = Config.CurrentConfig.GRAccelerationFinLigneRapide;
                VitessePivot = Config.CurrentConfig.GRVitessePivotRapide;
                AccelerationPivot = Config.CurrentConfig.GRAccelerationPivotRapide;
            }
            else
            {
                VitesseDeplacement = Config.CurrentConfig.PRVitesseLigneRapide;
                AccelerationDebutDeplacement = Config.CurrentConfig.PRAccelerationLigneRapide;
                VitessePivot = Config.CurrentConfig.PRVitessePivotRapide;
                AccelerationPivot = Config.CurrentConfig.PRAccelerationPivotRapide;
            }

            VitesseAdaptableEnnemi = true;
        }

        public bool GotoXYTeta(double x, double y, Angle teta)
        {
            return PathFinding(x, y, teta, 0, true);
        }

        public bool PathFinding(double x, double y, Angle teta = null, int timeOut = 0, bool attendre = false)
        {
            Historique.Log("Lancement pathfinding pour aller en " + x + " : " + y, TypeLog.PathFinding);
            Position destination = new Position(teta, new PointReel(x, y));

            Trajectoire traj = PathFinder.ChercheTrajectoire(Graph, Plateau.ListeObstacles, Position, destination, Rayon, 130);
            Console.WriteLine(Plateau.ListeObstacles.Count + " obstacles");
            if (traj == null)
                return false;

            semTrajectoire = new Semaphore(0, int.MaxValue);

            threadTrajectoire = new Thread(ParcourirTrajectoire);
            threadTrajectoire.Start(traj);

            if (attendre)
                semTrajectoire.WaitOne();

            return !TrajectoireCoupee && !TrajectoireEchouee;
        }

        /// <summary>
        /// Teste si deux formes sont trop proches pour envisager le passage du robot
        /// </summary>
        /// <param name="forme1">Forme 1</param>
        /// <param name="forme2">Forme 2</param>
        /// <returns>Vrai si les deux formes sont trop proches</returns>
        public bool TropProche(IForme forme1, IForme forme2, int marge = 0)
        {
            Type typeForme1 = forme1.GetType();
            Type typeForme2 = forme2.GetType();

            if (typeForme1.IsAssignableFrom(typeof(Segment)))
                if (typeForme2.IsAssignableFrom(typeof(Segment)))
                    return ((Segment)forme1).Distance((Segment)forme2) < Rayon;
                else
                    return ((Segment)forme1).Distance(forme2) < Rayon;
            else
                return forme1.Distance(forme2) < Rayon + marge;
        }

        public bool ObstacleTest()
        {
            if (TrajectoireCoupee)
                return false;


            try
            {
                // Teste si le chemin en cours de parcours est toujours franchissable
                if (TrajectoireEnCours != null && TrajectoireEnCours.Segments.Count > 0)
                {
                    List<Segment> segmentsTrajectoire = new List<Segment>();
                    // Calcule le segment entre nous et notre destination (permet de ne pas considérer un obstacle sur un tronçon déjà franchi)
                    Segment seg = new Segment(Position.Coordonnees, new PointReel(TrajectoireEnCours.Segments[0].Fin));
                    segmentsTrajectoire.Add(seg);

                    for (int iSegment = 1; iSegment < TrajectoireEnCours.Segments.Count; iSegment++)
                    {
                        segmentsTrajectoire.Add(TrajectoireEnCours.Segments[iSegment]);
                    }
                    Synchronizer.Lock(Plateau.ObstaclesBalise);
                    foreach (IForme forme in Plateau.ObstaclesBalise)
                    {
                        foreach (Segment segment in segmentsTrajectoire)
                        {
                            // Marge de 30mm pour être plus permissif sur le passage te ne pas s'arreter dès que l'adversaire approche
                            if (TropProche(seg, forme, - 30))
                            {
                                // Demande de génération d'une nouvelle trajectoire
                                Historique.Log("Trajectoire coupée, annulation", TypeLog.PathFinding);
                                TrajectoireCoupee = true;
                                TrajectoireEnCours = null;

                                if (DeplacementLigne)
                                    Stop();
                                Synchronizer.Unlock(Plateau.ObstaclesBalise);
                                return false;
                            }
                        }
                    }
                    Synchronizer.Unlock(Plateau.ObstaclesBalise);
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
            Synchronizer.Lock(Graph);

            List<IForme> obstacles = new List<IForme>(Plateau.ObstaclesBalise);

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

                        // Marge de 20mm pour prévoir une trajectoire plus éloignée de l'adversaire
                        if (TropProche(obstacle, segment, 20))
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
                        if (TropProche(obstacle, noeud))
                        {
                            n.Passable = false;
                        }
                    }
                }
            }

            Synchronizer.Unlock(Graph);
        }

        public override string ToString()
        {
            return Nom;
        }

        public int CalculDureeLigne(int distance)
        {
            int duree = CalculDureeDeplacement(distance, AccelerationDebutDeplacement, VitesseDeplacement, AccelerationFinDeplacement);

            return duree;
        }

        public int CalculDureePivot(Angle angle)
        {
            double entraxe = 272.1177476;
            int duree = CalculDureeDeplacement((int)((Math.PI * entraxe) / 360 * angle.AngleDegresPositif), AccelerationPivot, VitessePivot, AccelerationPivot);

            return duree;
        }

        private int CalculDureeDeplacement(int distance, int acceleration, int vitesseMax, int decceleration)
        {
            if (distance == 0)
                return 0;

            double dureeAcceleration, dureeCroisiere, dureeFreinage;
            int distanceAcceleration, distanceCroisere, distanceFreinage;

            distanceAcceleration = (vitesseMax * vitesseMax) / (2 * acceleration);
            distanceFreinage = (vitesseMax * vitesseMax) / (2 * decceleration);

            if (distanceAcceleration + distanceFreinage < distance)
            {
                distanceCroisere = distance - distanceAcceleration - distanceFreinage;

                dureeAcceleration = vitesseMax / (double)acceleration;
                dureeFreinage = vitesseMax / (double)decceleration;
                dureeCroisiere = distanceCroisere / (double)vitesseMax;
            }
            else
            {
                distanceCroisere = 0;
                dureeCroisiere = 0;

                double rapport = decceleration / (double)acceleration;
                distanceFreinage = (int)(distance / (rapport + 1));
                distanceAcceleration = distance - distanceFreinage;

                dureeAcceleration = Math.Sqrt((2 * distanceAcceleration) / (double)acceleration);
                dureeFreinage = Math.Sqrt((2 * distanceFreinage) / (double)(decceleration));
            }

            int duree = (int)((dureeAcceleration + dureeCroisiere + dureeFreinage) * 1000);
            return duree;
        }

        protected void ParcourirTrajectoire(Object traj)
        { 
            ParcourirTrajectoire((Trajectoire)traj);
        }

        public bool ParcourirTrajectoire(Trajectoire traj)
        {
            TrajectoireEnCours = traj;
            DateTime debut = DateTime.Now;

            Console.WriteLine("Lancement traj");
            TrajectoireCoupee = false;
            TrajectoireEchouee = false;

            foreach (IAction action in traj.ToActions())
            {
                action.Executer();

                if (TrajectoireCoupee || TrajectoireEchouee)
                    break;

                if ( action is ActionAvance || action is ActionRecule)
                {
                    Historique.Log("Noeud atteint " + TrajectoireEnCours.PointsPassage[0].X + ":" + TrajectoireEnCours.PointsPassage[0].Y, TypeLog.PathFinding);
                    TrajectoireEnCours.PointsPassage.RemoveAt(0);
                    TrajectoireEnCours.Segments.RemoveAt(0);
                }
            }
            Console.WriteLine("Traj terminée");

            if(!TrajectoireCoupee && !TrajectoireEchouee)
            {
                Historique.Log("Trajectoire parcourue en " + Math.Round((((DateTime.Now - debut).TotalMilliseconds) / 1000.0), 1) + "s", TypeLog.PathFinding);
                Console.WriteLine("Temps prévu :" + traj.Duree + "ms / Temps effectif : " + (DateTime.Now - debut).TotalMilliseconds + "ms");

                if(semTrajectoire != null)
                    semTrajectoire.Release();
                TrajectoireEnCours = null;
                return true;
            }

            if(TrajectoireEchouee)
            {
                Historique.Log("Echec du parcours de la trajectoire (dérapage, blocage...)", TypeLog.PathFinding);

                if (semTrajectoire != null)
                    semTrajectoire.Release();
                TrajectoireEnCours = null;
                return true;
            }
            
            TrajectoireEnCours = null;

            if (semTrajectoire != null)
                semTrajectoire.Release();
            return false;
        }
    }
}
