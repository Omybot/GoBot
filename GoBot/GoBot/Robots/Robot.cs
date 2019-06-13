using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using System.Threading;
using AStarFolder;
using Geometry.Shapes;
using System.Drawing;
using GoBot.Actions;
using GoBot.Actionneurs;
using GoBot.PathFinding;
using GoBot.Communications;
using System.Diagnostics;
using GoBot.Threading;
using GoBot.GameElements;
using System.Linq;
using GoBot.Devices;

namespace GoBot
{
    public abstract class Robot
    {
        // Communication
        public Board AsservBoard { get; set; }
        public Historique Historique { get; protected set; }
        public double BatterieVoltage { get; protected set; }

        // Constitution
        public IDRobot IDRobot { get; protected set; }
        public String Nom { get; set; }
        public double Taille { get { return Math.Max(Longueur, Largeur); } }

        public double Longueur { get; set; }
        public double Largeur { get; set; }
        public double Rayon { get { return Maths.Hypothenuse(Longueur, Largeur) / 2; } } 
        public double RayonAvecChanfrein { get { return Rayon - 16; } } // -16 = valeur calculée par Nico en 2018
        public double Entraxe { get; set; }// Distance entre les deux roues en mm

        // Déplacement
        public bool AsserActif { get; set; }
        public abstract Position Position { get; set; }
        public RealPoint PositionCible { get; set; }
        public bool DeplacementLigne { get; protected set; }
        public bool VitesseAdaptableEnnemi { get; set; }

        public SpeedConfig SpeedConfig { get; protected set; }
        public List<Position> HistoriqueCoordonnees { get; protected set; }

        public AsserStats AsserStats { get; protected set; }

        // PathFinding
        public Graph Graph { get; set; }
        public bool TrajectoireEchouee { get; set; }
        private bool TrajectoireCoupee { get; set; }

        private Semaphore semTrajectoire;

        public Trajectory TrajectoireEnCours = null;

        // Actionneurs / Capteurs

        public bool JackArme { get; protected set; } = false;
        public Dictionary<MotorID, bool> MoteurTourne { get; set; }

        public abstract void Delete();

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

        public virtual void PivotGauche(AngleDelta angle, bool attendre = true)
        {
            AsserStats.LeftRotations.Add(angle);
        }

        public virtual void PivotDroite(AngleDelta angle, bool attendre = true)
        {
            AsserStats.RightsRotations.Add(angle);
        }

        public abstract void TrajectoirePolaire(SensAR sens, List<RealPoint> points, bool attendre = true);
        public abstract void Stop(StopMode mode = StopMode.Smooth);
        public abstract void Virage(SensAR sensAr, SensGD sensGd, int rayon, AngleDelta angle, bool attendre = true);
        public abstract void ReglerOffsetAsserv(Position newPosition);
        public abstract void Recallage(SensAR sens, bool attendre = true);
        public abstract void EnvoyerPID(int p, int i, int d);
        public abstract void EnvoyerPIDCap(int p, int i, int d);
        public abstract void EnvoyerPIDVitesse(int p, int i, int d);
        public abstract List<int>[] MesureTestPid(int consigne, SensAR sens, int nbValeurs);
        public abstract List<double>[] DiagnosticCpuPwm(int nbValeurs);
        public abstract bool DemandeCapteurOnOff(SensorOnOffID capteur, bool attendre = true);
        public abstract Color DemandeCapteurCouleur(SensorColorID capteur, bool attendre = true);
        public abstract void DemandeValeursAnalogiques(Board carte, bool attendre = true);
        public abstract void DemandeValeursNumeriques(Board carte, bool attendre = true);
        public abstract String GetMesureLidar(LidarID lidar, int timeout, out Position refPosition);

        public abstract void ActionneurOnOff(ActuatorOnOffID actionneur, bool on);

        public abstract void Init();
        public abstract void AlimentationPuissance(bool on);
        public abstract void Reset();

        public void ArmerJack()
        {
            JackArme = true;
        }

        public abstract bool GetJack();
        public abstract Color GetCouleurEquipe(bool historique = true);

        public Dictionary<SensorOnOffID, bool> CapteurActive { get; set; }
        public Dictionary<SensorColorID, Color> CapteursCouleur { get; set; }
        public Dictionary<ActuatorOnOffID, bool> ActionneurActive { get; set; }
        public Dictionary<Board, List<double>> ValeursAnalogiques { get; set; }
        public Dictionary<Board, List<Byte>> ValeursNumeriques { get; set; }

        public delegate void ChangementEtatCapteurOnOffDelegate(SensorOnOffID capteur, bool etat);
        public event ChangementEtatCapteurOnOffDelegate ChangementEtatCapteurOnOff;

        public delegate void PositionChangeDelegate(Position position);
        public event PositionChangeDelegate PositionChange;

        public delegate void CapteurCouleurDelegate(SensorColorID capteur, Color couleur);
        public event CapteurCouleurDelegate CapteurCouleurChange;

        /// <summary>
        /// Génère l'évènement de changement de position
        /// </summary>
        /// <param name="position">Nouvelle position</param>
        protected void OnPositionChange(Position position)
        {
            PositionChange?.Invoke(position);
        }

        /// <summary>
        /// Génère l'évènement de changement d'état d'un capteur
        /// </summary>
        /// <param name="capteur"></param>
        /// <param name="etat"></param>
        protected void ChangerEtatCapteurOnOff(SensorOnOffID capteur, bool etat)
        {
            CapteurActive[capteur] = etat;
            ChangementEtatCapteurOnOff?.Invoke(capteur, etat);
        }

        protected void ChangeCouleurCapteur(SensorColorID capteur, Color couleur)
        {
            CapteurCouleurChange?.Invoke(capteur, couleur);
        }

        public virtual void MoteurPosition(MotorID moteur, int position, bool waitEnd = false)
        {
            Historique.AjouterAction(new ActionMoteur(this, position, moteur));
        }

        public virtual void MoteurOrigin(MotorID moteur, bool waitEnd = false)
        {

        }

        public virtual void MoteurWait(MotorID moteur)
        {

        }

        public virtual void MoteurVitesse(MotorID moteur, SensGD sens, int vitesse)
        {
            if (MoteurTourne.ContainsKey(moteur))
                MoteurTourne[moteur] = vitesse == 0 ? false : true;
            Historique.AjouterAction(new ActionMoteur(this, vitesse, moteur));
        }

        public virtual void MoteurAcceleration(MotorID moteur, int acceleration)
        {
            Historique.AjouterAction(new ActionMoteur(this, acceleration, moteur));
        }

        public void PositionerAngle(AnglePosition angle, double marge = 0)
        {
            AngleDelta diff = angle - Position.Angle;
            if (Math.Abs(diff.InDegrees) > marge)
            {
                if (diff.InDegrees > 0)
                    PivotDroite(diff.InDegrees);
                else
                    PivotGauche(-diff.InDegrees);
            }
        }

        public Robot()
        {
            SpeedConfig = new SpeedConfig(500, 1000, 1000, 500, 1000, 1000);
            AsserStats = new AsserStats();
            VitesseAdaptableEnnemi = true;
           
            MoteurTourne = new Dictionary<MotorID, bool>();
            foreach (MotorID moteur in Enum.GetValues(typeof(MotorID)))
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
            Historique.Log("Lancement pathfinding pour aller en " + dest.ToString(), TypeLog.PathFinding);

            Trajectory traj = PathFinder.ChercheTrajectoire(Graph, Plateau.ListeObstacles, Plateau.ObstaclesOpponents, Position, dest, RayonAvecChanfrein, Robots.GrosRobot.Largeur / 2);

            if (traj == null)
                return false;

            ParcourirTrajectoire(traj);

            return !TrajectoireCoupee && !TrajectoireEchouee;
        }

        /// <summary>
        /// Teste si deux formes sont trop proches pour envisager le passage du robot
        /// </summary>
        /// <param name="forme1">Forme 1</param>
        /// <param name="forme2">Forme 2</param>
        /// <returns>Vrai si les deux formes sont trop proches</returns>
        public bool TropProche(IShape forme1, IShape forme2, int marge = 0)
        {
            Type typeForme1 = forme1.GetType();
            Type typeForme2 = forme2.GetType();

            if (typeForme1.IsAssignableFrom(typeof(Segment)))
                if (typeForme2.IsAssignableFrom(typeof(Segment)))
                    return ((Segment)forme1).Distance((Segment)forme2) < RayonAvecChanfrein + marge;
                else
                    return ((Segment)forme1).Distance(forme2) < RayonAvecChanfrein + marge;
            else
                return forme1.Distance(forme2) < RayonAvecChanfrein + marge;
        }

        public bool ObstacleTest(IEnumerable<IShape> obstacles)
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
                        Segment seg = new Segment(Position.Coordinates, new RealPoint(TrajectoireEnCours.Lines[0].EndPoint));
                        segmentsTrajectoire.Add(seg);

                        for (int iSegment = 1; iSegment < TrajectoireEnCours.Lines.Count; iSegment++)
                        {
                            segmentsTrajectoire.Add(TrajectoireEnCours.Lines[iSegment]);
                        }

                        foreach (IShape forme in obstacles)
                        {
                            foreach (Segment segment in segmentsTrajectoire)
                            {
                                // Marge de 30mm pour être plus permissif sur le passage et ne pas s'arreter dès que l'adversaire approche
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
                catch (Exception)
                {
                    ok = false;
                }
            }

            return ok;
        }

        public void MajGraphFranchissable(IEnumerable<IShape> obstacles)
        {
            lock (Graph)
            {
                foreach (Arc arc in Graph.Arcs)
                    arc.Passable = true;

                foreach (Node node in Graph.Nodes)
                    node.Passable = true;

                foreach (IShape obstacle in obstacles)
                {
                    // Teste les arcs non franchissables
                    //for (int i = 0; i < Graph.Arcs.Count; i++)
                    //{
                    //    Arc arc = (Arc)Graph.Arcs[i];

                    //    if (arc.Passable)
                    //    {
                    //        Segment segment = new Segment(new RealPoint(arc.StartNode.X, arc.StartNode.Y), new RealPoint(arc.EndNode.X, arc.EndNode.Y));

                    //        // Marge de 20mm pour prévoir une trajectoire plus éloignée de l'adversaire
                    //        if (TropProche(obstacle, segment, 20))
                    //        {
                    //            arc.Passable = false;
                    //        }
                    //    }
                    //}

                    // Teste les noeuds non franchissables
                    for (int i = 0; i < Graph.Nodes.Count; i++)
                    {
                        Node n = (Node)Graph.Nodes[i];

                        if (n.Passable)
                        {
                            if (TropProche(obstacle, n.Position))
                            {
                                n.Passable = false;
                                // Désactivation des arcs connectés aux noeuds désactivés = 10 fois plus rapide que tester les arcs
                                foreach (Arc a in n.IncomingArcs) a.Passable = false;
                                foreach (Arc a in n.OutgoingArcs) a.Passable = false;
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

        public bool ParcourirTrajectoire(Trajectory traj)
        {
            TrajectoireEnCours = traj;
            TimeSpan dureeEstimee = traj.GetDuration(this);
            Stopwatch sw = Stopwatch.StartNew();

            TrajectoireCoupee = false;
            TrajectoireEchouee = false;

            foreach (IAction action in traj.ConvertToActions(this))
            {
                if (!Execution.Shutdown)
                {
                    action.Executer();

                    if (TrajectoireCoupee || TrajectoireEchouee)
                        break;

                    if (action is ActionAvance || action is ActionRecule)
                    {
                        Historique.Log("Noeud atteint " + TrajectoireEnCours.Points[0].X.ToString("0") + ":" + TrajectoireEnCours.Points[0].Y.ToString("0"), TypeLog.PathFinding);
                        TrajectoireEnCours.RemovePoint(0);
                    }
                }
            }

            if (!Execution.Shutdown)
            {
                TrajectoireEnCours = null;

                if (!TrajectoireCoupee && !TrajectoireEchouee)
                {
                    Historique.Log("Trajectoire parcourue en " + (sw.ElapsedMilliseconds / 1000.0).ToString("0.0") + "s (durée théorique : " + (dureeEstimee.TotalSeconds).ToString("0.0") + "s)", TypeLog.PathFinding);

                    semTrajectoire?.Release();

                    return true;
                }

                if (TrajectoireEchouee)
                {
                    Historique.Log("Echec du parcours de la trajectoire (dérapage, blocage...)", TypeLog.PathFinding);

                    semTrajectoire?.Release();

                    return false;
                }
            }

            semTrajectoire?.Release();

            return false;
        }

        public void RangerActionneurs()
        {
            // TODOEACHYEAR

            Actionneur.AtomUnloaderLeft.DoUnloaderStore();
            Thread.Sleep(250);

            ThreadManager.CreateThread(link => Actionneur.AtomStacker.DoInit()).StartThread();
            Actionneur.AtomHandler.DoInit();
            Actionneur.AtomUnloaderLeft.DoInit();
            Actionneur.AtomUnloaderRight.DoInit();
            Actionneur.GoldGrabberLeft.DoInit();
            Actionneur.GoldGrabberRight.DoInit();

            Robots.GrosRobot.ReglerOffsetAsserv(new Position(0, new RealPoint(1500, 1000)));
        }

        public void DeployerActionnneurs()
        {
            // TODOEACHYEAR
        }
        
        public IShape GetBounds(SensAR sens)
        {
            RealPoint p1 = new RealPoint((Robots.GrosRobot.Position.Coordinates.X - Robots.GrosRobot.Longueur / 2), (Robots.GrosRobot.Position.Coordinates.Y + Robots.GrosRobot.Largeur / 2));
            RealPoint p2 = new RealPoint((Robots.GrosRobot.Position.Coordinates.X - Robots.GrosRobot.Longueur / 2), (Robots.GrosRobot.Position.Coordinates.Y - Robots.GrosRobot.Largeur / 2));
            RealPoint p3 = new RealPoint((Robots.GrosRobot.Position.Coordinates.X + Robots.GrosRobot.Longueur / 2), (Robots.GrosRobot.Position.Coordinates.Y - Robots.GrosRobot.Largeur / 2));
            RealPoint p4 = new RealPoint((Robots.GrosRobot.Position.Coordinates.X + Robots.GrosRobot.Longueur / 2), (Robots.GrosRobot.Position.Coordinates.Y + Robots.GrosRobot.Largeur / 2));

            IShape contact = new PolygonRectangle(new RealPoint(Position.Coordinates.X - Longueur / 2, Position.Coordinates.Y - Largeur / 2), Longueur, Largeur);
            contact = contact.Rotation(new AngleDelta(Position.Angle));

            return contact;
        }
    }
}
