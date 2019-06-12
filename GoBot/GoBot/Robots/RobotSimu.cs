using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using System.Timers;
using Geometry.Shapes;
using System.Threading;
using GoBot.Actions;
using System.Drawing;
using GoBot.Actionneurs;
using System.Diagnostics;
using GoBot.Communications;
using GoBot.Threading;
using GoBot.GameElements;

namespace GoBot
{
    class RobotSimu : Robot
    {
        private Semaphore SemDeplacement { get; set; }

        public double VitesseActuelle { get; set; }

        private bool HighResolutionAsservissement = true;

        private Position Destination { get; set; }
        private SensGD SensPivot { get; set; }
        private SensAR SensDep { get; set; }

        private bool RecallageEnCours { get; set; }

        private Position position;
        public override Position Position
        {
            get { return position; }
            set { position = value; Destination = value; }
        }

        private ThreadLink _linkAsserv;

        public RobotSimu(IDRobot idRobot) : base()
        {
            IDRobot = idRobot;

            _linkAsserv = ThreadManager.CreateThread(link => Asservissement());
            _linkAsserv.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, HighResolutionAsservissement ? 1 : 16));

            timerPositions = new System.Timers.Timer(100);
            timerPositions.Elapsed += new ElapsedEventHandler(timerPositions_Elapsed);
            timerPositions.Start();

            SemDeplacement = new Semaphore(1, 1);
            SensDep = SensAR.Avant;

            Nom = "GrosRobot";
            RecallageEnCours = false;

            IDRobot = idRobot;
            CapteurActive = new Dictionary<SensorOnOffID, bool>();
            ActionneurActive = new Dictionary<ActuatorOnOffID, bool>();
            CapteursCouleur = new Dictionary<SensorColorID, Color>();

            foreach (SensorOnOffID fonction in Enum.GetValues(typeof(SensorOnOffID)))
            {
                CapteurActive.Add(fonction, false);
            }

            foreach (ActuatorOnOffID fonction in Enum.GetValues(typeof(ActuatorOnOffID)))
            {
                ActionneurActive.Add(fonction, false);
            }

            foreach (SensorColorID fonction in Enum.GetValues(typeof(SensorColorID)))
            {
                CapteursCouleur.Add(fonction, Color.Black);
            }

            ValeursAnalogiques = new Dictionary<Board, List<double>>();
            ValeursAnalogiques.Add(Board.RecIO, null);
            ValeursAnalogiques.Add(Board.RecGB, null);
            ValeursAnalogiques.Add(Board.RecMove, null);

            ValeursNumeriques = new Dictionary<Board, List<Byte>>();
            ValeursNumeriques.Add(Board.RecIO, new List<byte>());
            ValeursNumeriques.Add(Board.RecGB, new List<byte>());
            ValeursNumeriques.Add(Board.RecMove, new List<byte>());

            for (int i = 0; i < 3 * 2; i++)
            {
                ValeursNumeriques[Board.RecIO].Add(0);
                ValeursNumeriques[Board.RecGB].Add(0);
                ValeursNumeriques[Board.RecMove].Add(0);
            }
        }

        public override void Delete()
        {
            _linkAsserv.Cancel();
            _linkAsserv.WaitEnd();
        }

        public override String GetMesureLidar(LidarID lidar, int timeout, out Position refPosition)
        {
            refPosition = new Position(position);
            return "";
        }

        void timerPositions_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (HistoriqueCoordonnees)
            {
                HistoriqueCoordonnees.Add(new Position(Position.Angle, new RealPoint(Position.Coordinates.X, Position.Coordinates.Y)));

                while (HistoriqueCoordonnees.Count > 1200)
                    HistoriqueCoordonnees.RemoveAt(0);
            }
        }

        public double DistanceFreinageActuelle
        {
            get
            {
                return (VitesseActuelle * VitesseActuelle) / (2 * SpeedConfig.LineDeceleration);
            }
        }

        public double AngleFreinageActuel
        {
            get
            {
                return (VitesseActuelle * VitesseActuelle) / (2 * SpeedConfig.PivotDeceleration);
            }
        }

        double DistanceParcours(List<RealPoint> points, int from, int to)
        {
            double distance = 0;

            for (int i = from + 1; i <= to; i++)
                distance += points[i - 1].Distance(points[i]);

            return distance;
        }

        Stopwatch watch = null;
        int pointCourantTrajPolaire = -1;

        private long _lastTimerTick;

        void Asservissement()
        {
            _linkAsserv.RegisterName();

            // Calcul du temps écoulé depuis la dernière mise à jour de la position
            double interval = 0;

            long currentTick = 0;

            if (watch != null)
            {
                currentTick = watch.ElapsedMilliseconds;
                interval = currentTick - _lastTimerTick;
                _lastTimerTick = currentTick;
            }
            else
                watch = Stopwatch.StartNew();

            if (interval > 0)
            {
                SemDeplacement.WaitOne();

                if (pointCourantTrajPolaire >= 0)
                {
                    double distanceAvantProchainPoint = Position.Coordinates.Distance(trajectoirePolaire[pointCourantTrajPolaire]);
                    double distanceTotaleRestante = distanceAvantProchainPoint;

                    distanceTotaleRestante += DistanceParcours(trajectoirePolaire, pointCourantTrajPolaire, trajectoirePolaire.Count - 1);

                    if (distanceTotaleRestante > DistanceFreinageActuelle)
                        VitesseActuelle = Math.Min(SpeedConfig.LineSpeed, VitesseActuelle + SpeedConfig.LineAcceleration / (1000.0 / interval));
                    else
                        VitesseActuelle = VitesseActuelle - SpeedConfig.LineDeceleration / (1000.0 / interval);

                    double distanceAParcourir = VitesseActuelle / (1000.0 / interval);

                    double distanceTestee = distanceAvantProchainPoint;

                    bool changePoint = false;
                    while (distanceTestee < distanceAParcourir && pointCourantTrajPolaire < trajectoirePolaire.Count - 1)
                    {
                        pointCourantTrajPolaire++;
                        distanceTestee += trajectoirePolaire[pointCourantTrajPolaire - 1].Distance(trajectoirePolaire[pointCourantTrajPolaire]);
                        changePoint = true;
                    }

                    Segment seg = null;
                    Circle cer = null;

                    if (changePoint)
                    {
                        seg = new Segment(trajectoirePolaire[pointCourantTrajPolaire - 1], trajectoirePolaire[pointCourantTrajPolaire]);
                        cer = new Circle(trajectoirePolaire[pointCourantTrajPolaire - 1], distanceAParcourir - (distanceTestee - trajectoirePolaire[pointCourantTrajPolaire - 1].Distance(trajectoirePolaire[pointCourantTrajPolaire])));
                    }
                    else
                    {
                        seg = new Segment(Position.Coordinates, trajectoirePolaire[pointCourantTrajPolaire]);
                        cer = new Circle(Position.Coordinates, distanceAParcourir);
                    }

                    RealPoint newPos = seg.GetCrossingPoints(cer)[0];
                    AngleDelta a = -Maths.GetDirection(newPos, trajectoirePolaire[pointCourantTrajPolaire]).angle;
                    position = new Position(new AnglePosition(a), newPos);
                    OnPositionChange(Position);

                    if (pointCourantTrajPolaire == trajectoirePolaire.Count - 1)
                    {
                        pointCourantTrajPolaire = -1;
                        Destination.Copy(Position);
                    }
                }
                else
                {
                    bool needLine = Destination.Coordinates.Distance(Position.Coordinates) > 0;
                    bool needAngle = Math.Abs(Destination.Angle - Position.Angle) > 0.01;

                    if (needAngle)
                    {
                        AngleDelta diff = Math.Abs(Destination.Angle - Position.Angle);

                        double speedWithAcceleration = Math.Min(SpeedConfig.PivotSpeed, VitesseActuelle + SpeedConfig.PivotAcceleration / (1000.0 / interval));
                        double remainingDistanceWithAcceleration = CircleArcLenght(Entraxe, diff) - (VitesseActuelle + speedWithAcceleration) / 2 / (1000.0 / interval);

                        if (remainingDistanceWithAcceleration > DistanceFreinage(speedWithAcceleration))
                        {
                            double distParcourue = (VitesseActuelle + speedWithAcceleration) / 2 / (1000.0 / interval);
                            AngleDelta angleParcouru = (360 * distParcourue) / (Math.PI * Entraxe);

                            VitesseActuelle = speedWithAcceleration;

                            Position.Angle += (SensPivot.Factor() * angleParcouru);
                        }
                        else if (VitesseActuelle > 0)
                        {
                            double speedWithDeceleration = Math.Max(0, VitesseActuelle - SpeedConfig.PivotDeceleration / (1000.0 / interval));
                            double distParcourue = (VitesseActuelle + speedWithDeceleration) / 2 / (1000.0 / interval);
                            AngleDelta angleParcouru = (360 * distParcourue) / (Math.PI * Entraxe);

                            VitesseActuelle = speedWithDeceleration;

                            Position.Angle += (SensPivot.Factor() * angleParcouru);
                        }
                        else
                        {
                            Position.Copy(Destination);
                        }

                        OnPositionChange(Position);
                    }
                    else if (needLine)
                    {
                        double speedWithAcceleration = Math.Min(SpeedConfig.LineSpeed, VitesseActuelle + SpeedConfig.LineAcceleration / (1000.0 / interval));
                        double remainingDistanceWithAcceleration = Position.Coordinates.Distance(Destination.Coordinates) - (VitesseActuelle + speedWithAcceleration) / 2 / (1000.0 / interval);

                        // Phase accélération ou déccélération
                        if (remainingDistanceWithAcceleration > DistanceFreinage(speedWithAcceleration))
                        {
                            double distance = (VitesseActuelle + speedWithAcceleration) / 2 / (1000.0 / interval);
                            VitesseActuelle = speedWithAcceleration;

                            Position.Move(distance * SensDep.Factor());
                        }
                        else if (VitesseActuelle > 0)
                        {
                            double speedWithDeceleration = Math.Max(0, VitesseActuelle - SpeedConfig.LineDeceleration / (1000.0 / interval));
                            double distance = Math.Min(Destination.Coordinates.Distance(Position.Coordinates), (VitesseActuelle + speedWithDeceleration) / 2 / (1000.0 / interval));
                            VitesseActuelle = speedWithDeceleration;

                            Position.Move(distance * SensDep.Factor());
                        }
                        else
                        {
                            // Si on est déjà à l'arrêt on force l'équivalence de la position avec la destination.

                            Position.Copy(Destination);
                            DeplacementLigne = false;
                        }

                        OnPositionChange(Position);
                    }
                }

                SemDeplacement.Release();
            }
        }

        private double DistanceFreinage(Double speed)
        {
            return (speed * speed) / (2 * SpeedConfig.LineDeceleration);
        }

        private double CircleArcLenght(double diameter, AngleDelta arc)
        {
            return Math.Abs(arc.InDegrees) / 360 * Math.PI * diameter;
        }

        public override void Avancer(int distance, bool attendre = true)
        {
            base.Avancer(distance, attendre);

            DeplacementLigne = true;

            if (distance > 0)
            {
                if (!RecallageEnCours)
                    Historique.AjouterAction(new ActionAvance(this, distance));
                SensDep = SensAR.Avant;
            }
            else
            {
                if (!RecallageEnCours)
                    Historique.AjouterAction(new ActionRecule(this, -distance));
                SensDep = SensAR.Arriere;
            }

            Destination = new Position(Position.Angle, new RealPoint(Position.Coordinates.X + distance * Position.Angle.Cos, Position.Coordinates.Y + distance * Position.Angle.Sin));

            // TODO2018 attente avec un sémaphore ?
            if (attendre)
                while ((Position.Coordinates.X != Destination.Coordinates.X ||
                    Position.Coordinates.Y != Destination.Coordinates.Y) && !Execution.Shutdown)
                    Thread.Sleep(10);
        }

        public override void Reculer(int distance, bool attendre = true)
        {
            Avancer(-distance, attendre);
        }

        public override void PivotGauche(AngleDelta angle, bool attendre = true)
        {
            base.PivotGauche(angle, attendre);

            angle = Math.Round(angle, 2);
            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Gauche));
            Destination = new Position(Position.Angle - angle, new RealPoint(Position.Coordinates.X, Position.Coordinates.Y));
            SensPivot = SensGD.Gauche;

            if (attendre)
                while (Position.Angle != Destination.Angle)
                    Thread.Sleep(10);
        }

        public override void PivotDroite(AngleDelta angle, bool attendre = true)
        {
            base.PivotDroite(angle, attendre);

            angle = Math.Round(angle, 2);
            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Droite));
            Destination = new Position(Position.Angle + angle, new RealPoint(Position.Coordinates.X, Position.Coordinates.Y));
            SensPivot = SensGD.Droite;

            if (attendre)
                while (Position.Angle != Destination.Angle)
                    Thread.Sleep(10);
        }

        public override void Stop(StopMode mode)
        {
            Historique.AjouterAction(new ActionStop(this, mode));
            SemDeplacement.WaitOne();

            if (mode == StopMode.Smooth)
            {
                Position nouvelleDestination = new Position(Position.Angle, new RealPoint(position.Coordinates.X, position.Coordinates.Y));

                if (DeplacementLigne)
                {
                    if (SensDep == SensAR.Avant)
                        nouvelleDestination.Move(DistanceFreinageActuelle);
                    else
                        nouvelleDestination.Move(-DistanceFreinageActuelle);
                }

                Destination = nouvelleDestination;
            }
            else if (mode == StopMode.Abrupt)
            {
                VitesseActuelle = 0;
                Destination = Position;
            }
            SemDeplacement.Release();
        }

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, AngleDelta angle, bool attendre = true)
        {
            // TODO2018
        }

        private List<RealPoint> trajectoirePolaire;
        public override void TrajectoirePolaire(SensAR sens, List<RealPoint> points, bool attendre = true)
        {
            trajectoirePolaire = points;
            pointCourantTrajPolaire = 0;

            while (attendre && pointCourantTrajPolaire != -1)
                Thread.Sleep(10);
        }

        public override void ReglerOffsetAsserv(Position newPosition)
        {
            Position = new Position(-newPosition.Angle, newPosition.Coordinates); // TODO2018 Hum, pouruqoi c'est pas le meme repere ?
            PositionCible?.Set(Position.Coordinates);
            OnPositionChange(Position);
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            RecallageEnCours = true;
            Historique.AjouterAction(new ActionRecallage(this, sens));

            if (attendre)
                RecalProcedure(sens);
            else
                ThreadManager.CreateThread(link => RecalProcedure(sens)).StartThread();
        }

        private void RecalProcedure(SensAR sens)
        {

            int realAccel = SpeedConfig.LineAcceleration;
            int realDeccel = SpeedConfig.LineAcceleration;
            SpeedConfig.LineAcceleration = 50000;
            SpeedConfig.LineDeceleration = 50000;

            IShape contact = GetBounds(sens);

            while (Position.Coordinates.X - Longueur / 2 > 0 &&
                Position.Coordinates.X + Longueur / 2 < Plateau.Largeur &&
                Position.Coordinates.Y - Longueur / 2 > 0 &&
                Position.Coordinates.Y + Longueur / 2 < Plateau.Hauteur &&
                !Plateau.ListeObstacles.ToList().Exists(o => o.Cross(contact)))
            {
                if (sens == SensAR.Arriere)
                    Reculer(1);
                else
                    Avancer(1);

                contact = GetBounds(sens);
            }

            SpeedConfig.LineAcceleration = realAccel;
            SpeedConfig.LineDeceleration = realDeccel;

            RecallageEnCours = false;
        }

        public override void Init()
        {
            Historique = new Historique(IDRobot);
            HistoriqueCoordonnees = new List<Position>();
            Position = new Position(Recallages.PositionDepart);

            PositionCible = null;
        }

        public override bool DemandeCapteurOnOff(SensorOnOffID capteur, bool attendre = true)
        {
            // TODO
            return true;
        }

        public override Color DemandeCapteurCouleur(SensorColorID capteur, bool attendre = true)
        {
            // TODO
            return Color.Black;
        }

        public override void EnvoyerPID(int p, int i, int d)
        {
            // TODO
        }

        public override void EnvoyerPIDCap(int p, int i, int d)
        {
            // TODO
        }

        public override void EnvoyerPIDVitesse(int p, int i, int d)
        {
            // TODO
        }

        public override void ActionneurOnOff(ActuatorOnOffID actionneur, bool on)
        {
            // TODO
            Historique.AjouterAction(new ActionOnOff(this, actionneur, on));
        }

        System.Timers.Timer timerPositions;

        public override void MoteurPosition(MotorID moteur, int vitesse, bool waitEnd)
        {
            base.MoteurPosition(moteur, vitesse);
        }

        public override void MoteurVitesse(MotorID moteur, SensGD sens, int vitesse)
        {
            base.MoteurVitesse(moteur, sens, vitesse);
        }

        public override void MoteurAcceleration(MotorID moteur, int acceleration)
        {
            base.MoteurAcceleration(moteur, acceleration);
        }

        public override void AlimentationPuissance(bool on)
        {
            // TODO
            if (!on)
            {
                /*VitesseDeplacement = 0;
                AccelerationDeplacement = 0;
                VitessePivot = 0;
                AccelerationPivot = 0;*/
            }
        }

        public override void Reset()
        {
            // TODO
        }

        public override bool GetJack()
        {
            return true;
        }

        public override Color GetCouleurEquipe(bool historique = true)
        {
            return Plateau.CouleurDroiteViolet;
        }

        public override List<int>[] MesureTestPid(int consigne, SensAR sens, int nbValeurs)
        {
            List<int>[] retour = new List<int>[2];
            retour[0] = new List<int>();
            retour[1] = new List<int>();

            for (double i = 0; i < nbValeurs; i++)
            {
                retour[0].Add((int)(Math.Sin((i + DateTime.Now.Millisecond) / 100.0 * Math.PI) * consigne * 10000000 / (i * i * i)));
                retour[1].Add((int)(Math.Sin((i + DateTime.Now.Millisecond) / 100.0 * Math.PI) * consigne * 10000000 / (i * i * i) + 10));
            }

            return retour;
        }

        public override List<double>[] DiagnosticCpuPwm(int ptsCount)
        {
            List<double> cpuLoad, pwmLeft, pwmRight;
            Random r = new Random();

            cpuLoad = new List<double>();
            pwmLeft = new List<double>();
            pwmRight = new List<double>();

            for(int i = 0; i < ptsCount; i++)
            {
                cpuLoad.Add((Math.Sin(i / (double)ptsCount * Math.PI*2) / 2 + 0.5) * 0.2 + r.NextDouble() * 0.2 + 0.3);
                pwmLeft.Add(Math.Sin((DateTime.Now.Millisecond + i + DateTime.Now.Second * 1000) % 1500 / (double)1500 * Math.PI * 2) * 3800 + (r.NextDouble() - 0.5) * 400);
                pwmRight.Add(Math.Sin((DateTime.Now.Millisecond + i + DateTime.Now.Second*1000) % 5000 / (double)5000 * Math.PI * 2) * 3800 + (r.NextDouble() - 0.5) * 400);
            }

            Thread.Sleep(ptsCount);
            
            return new List<double>[3] { cpuLoad, pwmLeft, pwmRight };
        }

        public override void DemandeValeursAnalogiques(Board carte, bool attendre)
        {
            List<double> values = Enumerable.Range(1, 9).Select(o => (double)o).ToList();
            ValeursAnalogiques[carte] = values;
        }

        public override void DemandeValeursNumeriques(Board carte, bool attendre)
        {
            Random r = new Random();

            for (int i = 0; i < 3 * 2; i++)
                ValeursNumeriques[carte][i] = (Byte)r.Next();
        }
    }
}
