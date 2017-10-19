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
using System.Diagnostics;

namespace GoBot
{
    public abstract class Robot
    {
        // Communication
        public Board Carte { get; set; }
        public Historique Historique { get; protected set; }
        public double BatterieVoltage { get; protected set; }

        // Constitution
        public IDRobot IDRobot { get; protected set; }
        public String Nom { get; set; }
        public double Taille { get { return Math.Max(Longueur, Largeur); } }
        public double Longueur { get; set; }
        public double Largeur { get; set; }
        public double Rayon { get { return (int)Math.Sqrt(Longueur * Longueur + Largeur * Largeur) / 2 - 14; } } // -14 = valeur calculée pour l'année 2015 sur les biseaux
        public double Entraxe { get; set; }// Distance entre les deux roues en mm

        // Déplacement
        public bool AsserActif { get; set; }
        public abstract Position Position { get; set; }
        public PointReel PositionCible { get; set; }
        public bool DeplacementLigne { get; protected set; }
        public bool VitesseAdaptableEnnemi { get; set; }

        public SpeedConfig SpeedConfig { get; protected set; }
        public List<Position> HistoriqueCoordonnees { get; protected set; }

        public AsserStats AsserStats { get; protected set; }

        // PathFinding
        public Graph Graph { get; set; }
        public bool TrajectoireEchouee { get; set; }
        private bool TrajectoireCoupee { get; set; }

        private Thread threadTrajectoire;
        private Semaphore semTrajectoire;

        public Trajectory TrajectoireEnCours = null;

        // Actionneurs / Capteurs

        public bool JackArme { get; protected set; } = false;
        public Dictionary<ServomoteurID, bool> ServoActive { get; set; }
        public Dictionary<MoteurID, bool> MoteurTourne { get; set; }

        public virtual void Avancer(int distance, bool attendre = true)
        {
            if (distance > 0)
                AsserStats.ForwardMoves.Add(distance);
            else
                AsserStats.BackwardMoves.Add(-distance);
        }

        public virtual void Reculer(int distance, bool attendre = true)
        {
            if (distance < 0)
                AsserStats.ForwardMoves.Add(distance);
            else
                AsserStats.BackwardMoves.Add(-distance);
        }

        public virtual void PivotGauche(Angle angle, bool attendre = true)
        {
            AsserStats.LeftRotations.Add(angle);
        }

        public virtual void PivotDroite(Angle angle, bool attendre = true)
        {
            AsserStats.RightsRotations.Add(angle);
        }

        public abstract void TrajectoirePolaire(SensAR sens, List<PointReel> points, bool attendre = true);
        public abstract void Stop(StopMode mode = StopMode.Smooth);
        public abstract void Virage(SensAR sensAr, SensGD sensGd, int rayon, Angle angle, bool attendre = true);
        public abstract void ReglerOffsetAsserv(Position newPosition);
        public abstract void Recallage(SensAR sens, bool attendre = true);
        public abstract void EnvoyerPID(int p, int i, int d);
        public abstract void EnvoyerPIDCap(int p, int i, int d);
        public abstract void EnvoyerPIDVitesse(int p, int i, int d);
        public abstract List<int>[] MesureTestPid(int consigne, SensAR sens, int nbValeurs);
        public abstract List<double>[] DiagnosticCpuPwm(int nbValeurs);
        public abstract bool DemandeCapteurOnOff(CapteurOnOffID capteur, bool attendre = true);
        public abstract Color DemandeCapteurCouleur(CapteurCouleurID capteur, bool attendre = true);
        public abstract void DemandeValeursAnalogiques(Board carte, bool attendre = true);
        public abstract void DemandeValeursNumeriques(Board carte, bool attendre = true);

        public abstract void ActionneurOnOff(ActionneurOnOffID actionneur, bool on);

        public abstract void Init();
        public abstract void AlimentationPuissance(bool on);
        public abstract void Reset();

        public void ArmerJack()
        {
            JackArme = true;
        }

        public abstract bool GetJack();
        public abstract String GetMesureLidar(LidarID lidar, int timeout, out Position refPosition);
        public abstract Color GetCouleurEquipe(bool historique = true);

        public Dictionary<CapteurOnOffID, bool> CapteurActive { get; set; }
        public Dictionary<CapteurCouleurID, Color> CapteursCouleur { get; set; }
        public Dictionary<ActionneurOnOffID, bool> ActionneurActive { get; set; }
        public Dictionary<Board, List<double>> ValeursAnalogiques { get; set; }
        public Dictionary<Board, List<Byte>> ValeursNumeriques { get; set; }

        public delegate void ChangementEtatCapteurOnOffDelegate(CapteurOnOffID capteur, bool etat);
        public event ChangementEtatCapteurOnOffDelegate ChangementEtatCapteurOnOff;

        public delegate void PositionChangeDelegate(Position position);
        public event PositionChangeDelegate PositionChange;

        public delegate void CapteurCouleurDelegate(CapteurCouleurID capteur, Color couleur);
        public event CapteurCouleurDelegate CapteurCouleurChange;

        /// <summary>
        /// Génère l'évènement de changement de position
        /// </summary>
        /// <param name="position">Nouvelle position</param>
        protected void ChangerPosition(Position position)
        {
            PositionChange?.Invoke(position);
        }

        /// <summary>
        /// Génère l'évènement de changement d'état d'un capteur
        /// </summary>
        /// <param name="capteur"></param>
        /// <param name="etat"></param>
        protected void ChangerEtatCapteurOnOff(CapteurOnOffID capteur, bool etat)
        {
            CapteurActive[capteur] = etat;
            ChangementEtatCapteurOnOff?.Invoke(capteur, etat);
        }

        protected void ChangeCouleurCapteur(CapteurCouleurID capteur, Color couleur)
        {
            CapteurCouleurChange?.Invoke(capteur, couleur);
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
                Plateau.Balise.VitesseRotation(150);
                Actionneur.BrasLunaire.Avancer();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaire.Reculer();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaire.Descendre();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaire.Monter();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaire.Ouvrir();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaire.Fermer();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaire.Reculer();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaire.Monter();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaire.Monter();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaireGauche.Descendre();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaireGauche.Ouvrir();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaireGauche.Fermer();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaireGauche.Ranger();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaireDroite.Descendre();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaireDroite.Ouvrir();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaireDroite.Fermer();
                Thread.Sleep(tempo);
                Actionneur.BrasLunaireDroite.Monter();
                Thread.Sleep(tempo);
                Actionneur.Convoyeur.Avaler();
                Thread.Sleep(tempo * 4);
                Actionneur.Convoyeur.Arreter();
                Thread.Sleep(tempo);
                Actionneur.Convoyeur.Bloque();
                Thread.Sleep(tempo);
                Actionneur.Convoyeur.Libere();
                Thread.Sleep(tempo);
                Actionneur.Ejecteur.SortirEjecteur();
                Thread.Sleep(tempo);
                Actionneur.Ejecteur.RentrerEjecteur();
                Thread.Sleep(tempo);
                Actionneur.Ejecteur.TournerDroite();
                Thread.Sleep(tempo * 4);
                Actionneur.Ejecteur.TournerGauche();
                Thread.Sleep(tempo * 4);
                Actionneur.Ejecteur.TournerStop();
                Thread.Sleep(tempo);
                Actionneur.Stockeur.RelacheBas();
                Thread.Sleep(tempo);
                Actionneur.Stockeur.BloqueBas();
                Thread.Sleep(tempo);
                Actionneur.Stockeur.RelacheHaut();
                Thread.Sleep(tempo);
                Actionneur.Stockeur.BloquerHaut();
                Thread.Sleep(tempo);
                Actionneur.Stockeur.MonterRehausseur();
                Thread.Sleep(tempo);
                Actionneur.Stockeur.RangerRehausseur();
                Thread.Sleep(tempo);
                Devices.Devices.RecGoBot.Buzz(5000, 200);
                Thread.Sleep(tempo * 4);
                Devices.Devices.RecGoBot.Buzz(0, 200);
                Plateau.Balise.VitesseRotation(0);
            }
        }

        private MinimumDelay _delayServo = new MinimumDelay(10);

        public virtual void BougeServo(ServomoteurID servo, int position)
        {
            //TODO2018 : améliorer cette tempo ?
            // Testé sur AX12 et sur pololu, c'est vraiment nécessaire
            // Attention sur pololu ca dépend des servos, desfois ca mache sans tempo...
            _delayServo.Wait();

            Historique.AjouterAction(new ActionServo(this, position, servo));

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
        }

        public abstract void ServoVitesse(ServomoteurID servo, int vitesse);

        public virtual void MoteurPosition(MoteurID moteur, int position)
        {
            Historique.AjouterAction(new ActionMoteur(this, position, moteur));
        }

        public virtual void MoteurVitesse(MoteurID moteur, SensGD sens, int vitesse)
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
            SpeedConfig = new SpeedConfig(500, 1000, 1000, 500, 1000, 1000);
            AsserStats = new AsserStats();
            VitesseAdaptableEnnemi = true;
            ServoActive = new Dictionary<ServomoteurID, bool>();
            foreach (ServomoteurID servo in Enum.GetValues(typeof(ServomoteurID)))
                ServoActive.Add(servo, false);
            MoteurTourne = new Dictionary<MoteurID, bool>();
            foreach (MoteurID moteur in Enum.GetValues(typeof(MoteurID)))
                MoteurTourne.Add(moteur, false);

            BatterieVoltage = 0;
            TrajectoireEchouee = false;
            TrajectoireCoupee = false;
        }

        public void Lent()
        {
            SpeedConfig.SetParams(Config.CurrentConfig.ConfigLent);

            VitesseAdaptableEnnemi = false;
        }

        public void Rapide()
        {
            SpeedConfig.SetParams(Config.CurrentConfig.ConfigRapide);

            VitesseAdaptableEnnemi = true;
        }

        public bool GotoXYTeta(Position dest)
        {
            return PathFinding(dest.Coordonnees.X, dest.Coordonnees.Y, dest.Angle, 0, true);
        }

        public bool PathFinding(double x, double y, Angle teta = null, int timeOut = 0, bool attendre = false)
        {
            Historique.Log("Lancement pathfinding pour aller en " + x + " : " + y, TypeLog.PathFinding);
            Position destination = new Position(teta, new PointReel(x, y));

            Trajectory traj = PathFinder.ChercheTrajectoire(Graph, Plateau.ListeObstacles, Position, destination, Rayon, 130);

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
            bool ok = true;

            if (TrajectoireCoupee)
                ok = false;

            if (ok)
            {
                try
                {
                    // Teste si le chemin en cours de parcours est toujours franchissable
                    if (TrajectoireEnCours != null && TrajectoireEnCours.Lines.Count > 0)
                    {
                        List<Segment> segmentsTrajectoire = new List<Segment>();
                        // Calcule le segment entre nous et notre destination (permet de ne pas considérer un obstacle sur un tronçon déjà franchi)
                        Segment seg = new Segment(Position.Coordonnees, new PointReel(TrajectoireEnCours.Lines[0].Fin));
                        segmentsTrajectoire.Add(seg);

                        for (int iSegment = 1; iSegment < TrajectoireEnCours.Lines.Count; iSegment++)
                        {
                            segmentsTrajectoire.Add(TrajectoireEnCours.Lines[iSegment]);
                        }

                        lock (Plateau.ObstaclesBalise)
                        {
                            foreach (IForme forme in Plateau.ObstaclesBalise)
                            {
                                foreach (Segment segment in segmentsTrajectoire)
                                {
                                    // Marge de 30mm pour être plus permissif sur le passage te ne pas s'arreter dès que l'adversaire approche
                                    if (TropProche(seg, forme, -30))
                                    {
                                        // Demande de génération d'une nouvelle trajectoire
                                        Historique.Log("Trajectoire coupée, annulation", TypeLog.PathFinding);
                                        TrajectoireCoupee = true;
                                        TrajectoireEnCours = null;

                                        if (DeplacementLigne)
                                            Stop();
                                        ok = false;
                                        break;
                                    }
                                }

                                if (!ok)
                                    break;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    ok = false;
                }
            }

            return ok;
        }

        public void MajGraphFranchissable()
        {
            lock (Graph)
            {
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
            }
        }

        public override string ToString()
        {
            return Nom;
        }

        protected void ParcourirTrajectoire(Object traj)
        {
            ParcourirTrajectoire((Trajectory)traj);
        }

        public bool ParcourirTrajectoire(Trajectory traj)
        {
            TrajectoireEnCours = traj;
            TimeSpan dureeEstimee = traj.GetDuration(this);
            Stopwatch sw = Stopwatch.StartNew();

            TrajectoireCoupee = false;
            TrajectoireEchouee = false;

            foreach (IAction action in traj.ConvertToActions(this))
            {
                action.Executer();

                if (TrajectoireCoupee || TrajectoireEchouee)
                    break;

                if (action is ActionAvance || action is ActionRecule)
                {
                    Historique.Log("Noeud atteint " + TrajectoireEnCours.Points[0].X + ":" + TrajectoireEnCours.Points[0].Y, TypeLog.PathFinding);
                    TrajectoireEnCours.RemoveFirst();
                }
            }

            if (!TrajectoireCoupee && !TrajectoireEchouee)
            {
                Historique.Log("Trajectoire parcourue en " + (sw.ElapsedMilliseconds / 1000.0).ToString("0.0") + "s (durée théorique : " + (dureeEstimee.TotalSeconds).ToString("0.0") + "s)", TypeLog.PathFinding);

                if (semTrajectoire != null)
                    semTrajectoire.Release();
                TrajectoireEnCours = null;
                return true;
            }

            if (TrajectoireEchouee)
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

        public void RangerActionneurs()
        {
            Actionneur.BrasLunaire.Fermer();
            Actionneur.BrasLunaire.Monter();
            Actionneur.BrasLunaire.Reculer();
            Actionneur.BrasLunaireDroite.Fermer();
            Actionneur.BrasLunaireDroite.Ranger();
            Actionneur.BrasLunaireGauche.Fermer();
            Actionneur.BrasLunaireGauche.Ranger();
            Actionneur.Stockeur.RangerRehausseur();
            Actionneur.Stockeur.BloqueBas();
            Actionneur.Stockeur.BloquerHaut();
            Actionneur.Ejecteur.RentrerEjecteur();
            Actionneur.Ejecteur.TournerStop();
            Actionneur.Convoyeur.Arreter();
            Actionneur.Convoyeur.Libere();
            Actionneur.Stockeur.RangerCalleur();
        }

        public void DeployerActionnneurs()
        {
            Actionneur.BrasLunaire.Fermer();
            Actionneur.BrasLunaire.Descendre();
            Actionneur.BrasLunaire.Avancer();
            Actionneur.BrasLunaireDroite.Fermer();
            Actionneur.BrasLunaireDroite.Descendre();
            Actionneur.BrasLunaireGauche.Fermer();
            Actionneur.BrasLunaireGauche.Descendre();
            Actionneur.Stockeur.MonterRehausseur();
            Actionneur.Stockeur.RelacheBas();
            Actionneur.Stockeur.RelacheHaut();
            Actionneur.Convoyeur.Bloque();
            Actionneur.Stockeur.RangerCalleur();
        }
    }
}
