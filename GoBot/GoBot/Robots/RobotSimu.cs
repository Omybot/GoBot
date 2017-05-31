using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using System.Timers;
using GoBot.Calculs.Formes;
using System.Threading;
using GoBot.Actions;
using System.Drawing;
using GoBot.Actionneurs;
using System.Diagnostics;
using GoBot.Communications;

namespace GoBot
{
    class RobotSimu : Robot
    {
        private Semaphore SemDeplacement { get; set; }
        private Random Rand { get; set; }

        public double VitesseActuelle { get; set; }

        private double IntervalleRafraichissementPosition = 10;

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

        private int vitesseDeplacement;
        public override int VitesseDeplacement
        {
            get { return vitesseDeplacement; }
            set
            {
                vitesseDeplacement = value;
                Historique.AjouterAction(new ActionVitesseLigne(this, value));
            }
        }

        private int accelerationDebutDeplacement;
        public override int AccelerationDebutDeplacement
        {
            get { return accelerationDebutDeplacement; }
            set
            {
                accelerationDebutDeplacement = value;
                Historique.AjouterAction(new ActionAccelerationLigne(this, value));
            }
        }

        private int accelerationFinDeplacement;
        public override int AccelerationFinDeplacement
        {
            get { return accelerationFinDeplacement; }
            set
            {
                accelerationFinDeplacement = value;
                Historique.AjouterAction(new ActionAccelerationLigne(this, value));
            }
        }

        private int vitessePivot;
        public override int VitessePivot
        {
            get { return vitessePivot; }
            set
            {
                vitessePivot = value;
                Historique.AjouterAction(new ActionVitessePivot(this, value));
            }
        }

        private int accelerationPivot;
        public override int AccelerationPivot
        {
            get { return accelerationPivot; }
            set
            {
                accelerationPivot = value;
                Historique.AjouterAction(new ActionAccelerationPivot(this, value));
            }
        }

        public RobotSimu(IDRobot idRobot) : base()
        {
            IDRobot = idRobot;
            timerDeplacement = new System.Timers.Timer(IntervalleRafraichissementPosition);
            timerDeplacement.Elapsed += new ElapsedEventHandler(timerDeplacement_Elapsed);
            timerDeplacement.Start();

            timerPositions = new System.Timers.Timer(100);
            timerPositions.Elapsed += new ElapsedEventHandler(timerPositions_Elapsed);
            timerPositions.Start();

            SemDeplacement = new Semaphore(1, 1);
            SensDep = SensAR.Avant;
            
            Nom = "GrosRobot";
            RecallageEnCours = false;
            Rand = new Random(DateTime.Now.Millisecond);

            IDRobot = idRobot;
            CapteurActive = new Dictionary<CapteurOnOffID, bool>();
            ActionneurActive = new Dictionary<ActionneurOnOffID, bool>();
            CapteursCouleur = new Dictionary<CapteurCouleurID, Color>();

            foreach (CapteurOnOffID fonction in Enum.GetValues(typeof(CapteurOnOffID)))
            {
                CapteurActive.Add(fonction, false);
            }

            foreach (ActionneurOnOffID fonction in Enum.GetValues(typeof(ActionneurOnOffID)))
            {
                ActionneurActive.Add(fonction, false);
            }

            foreach (CapteurCouleurID fonction in Enum.GetValues(typeof(CapteurCouleurID)))
            {
                CapteursCouleur.Add(fonction, Color.Black);
            }

            ValeursAnalogiques = new Dictionary<Carte, List<double>>();
            ValeursAnalogiques.Add(Carte.RecIO, null);
            ValeursAnalogiques.Add(Carte.RecGB, null);
            ValeursAnalogiques.Add(Carte.RecMove, null);
        }

        void timerPositions_Elapsed(object sender, ElapsedEventArgs e)
        {
            HistoriqueCoordonnees.Add(new Position(new Angle(Position.Angle), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y)));
            if (HistoriqueCoordonnees.Count > 1200)
            {
                semHistoriquePosition.WaitOne();
                while (HistoriqueCoordonnees.Count > 1200)
                    HistoriqueCoordonnees.RemoveAt(0);
                semHistoriquePosition.Release();
            }
        }

        public double DistanceFreinageActuelle
        {
            get
            {
                return (VitesseActuelle * VitesseActuelle) / (2 * AccelerationFinDeplacement);
            }
        }

        public double AngleFreinageActuel
        {
            get
            {
                return (VitesseActuelle * VitesseActuelle) / (2 * AccelerationPivot);
            }
        }

        double DistanceParcours(List<PointReel> points, int from, int to)
        {
            double distance = 0;

            for (int i = from + 1; i <= to; i++)
                distance += points[i - 1].Distance(points[i]);

            return distance;
        }

        Stopwatch watch = null;
        int pointCourantTrajPolaire = -1;

        List<double> inter = new List<double>();
        void timerDeplacement_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Calcul du temps écoulé depuis la dernière mise à jour de la position
            double intervalle = 0;

            if (watch != null)
            {
                intervalle = watch.ElapsedMilliseconds;
                inter.Add(intervalle);
                watch.Restart();
            }
            else
                watch = Stopwatch.StartNew();

            SemDeplacement.WaitOne();

            if (pointCourantTrajPolaire >= 0)
            {
                double distanceAvantProchainPoint = Position.Coordonnees.Distance(trajectoirePolaire[pointCourantTrajPolaire]);
                double distanceTotaleRestante = distanceAvantProchainPoint;

                distanceTotaleRestante += DistanceParcours(trajectoirePolaire, pointCourantTrajPolaire, trajectoirePolaire.Count - 1);

                if (distanceTotaleRestante > DistanceFreinageActuelle)
                    VitesseActuelle = Math.Min(VitesseDeplacement, VitesseActuelle + AccelerationDebutDeplacement / (1000.0 / intervalle));
                else
                    VitesseActuelle = VitesseActuelle - AccelerationDebutDeplacement / (1000.0 / intervalle);

                double distanceAParcourir = VitesseActuelle / (1000.0 / intervalle);

                double distanceTestee = distanceAvantProchainPoint;

                bool changePoint = false;
                while (distanceTestee < distanceAParcourir && pointCourantTrajPolaire < trajectoirePolaire.Count - 1)
                {
                    pointCourantTrajPolaire++;
                    distanceTestee += trajectoirePolaire[pointCourantTrajPolaire - 1].Distance(trajectoirePolaire[pointCourantTrajPolaire]);
                    changePoint = true;
                }

                Segment seg = null;
                Cercle cer = null;

                if (changePoint)
                {
                    seg = new Segment(trajectoirePolaire[pointCourantTrajPolaire - 1], trajectoirePolaire[pointCourantTrajPolaire]);
                    cer = new Cercle(trajectoirePolaire[pointCourantTrajPolaire - 1], distanceAParcourir - (distanceTestee - trajectoirePolaire[pointCourantTrajPolaire - 1].Distance(trajectoirePolaire[pointCourantTrajPolaire])));
                }
                else
                {
                    seg = new Segment(Position.Coordonnees, trajectoirePolaire[pointCourantTrajPolaire]);
                    cer = new Cercle(Position.Coordonnees, distanceAParcourir);
                }

                PointReel newPos = seg.Croisements(cer)[0];
                Angle a = -Maths.GetDirection(newPos, trajectoirePolaire[pointCourantTrajPolaire]).angle;
                position = new Position(a, newPos);
                ChangerPosition(Position);

                if (pointCourantTrajPolaire == trajectoirePolaire.Count - 1)
                {
                    pointCourantTrajPolaire = -1;
                    Destination.Copie(Position);
                }
            }
            else
            {
                double difference = Destination.Coordonnees.Distance(Position.Coordonnees);
                Angle adifference = Position.Angle - Destination.Angle;
                if (Math.Abs(adifference.AngleDegres) > 0.01)
                {
                    Angle diff = Destination.Angle - Position.Angle;
                    int coeff = 1;

                    if (SensPivot == SensGD.Gauche)
                        coeff = -1;

                    double distance = Math.Abs(adifference.AngleDegres) / 360.0 * Entraxe * Math.PI;

                    double distParcourue = VitesseActuelle / (1000.0 / intervalle);
                    Angle angleParcouru = (360 * distParcourue) / (Math.PI * Entraxe);

                    if (distance > AngleFreinageActuel)
                        VitesseActuelle = Math.Min(VitessePivot, VitesseActuelle + AccelerationPivot / (1000.0 / intervalle));
                    else
                        VitesseActuelle = VitesseActuelle - AccelerationPivot / (1000.0 / intervalle);

                    if (Math.Abs(diff.AngleDegres) >= angleParcouru)
                        Position.Angle.Tourner(coeff * angleParcouru);
                    else
                    {
                        Position.Angle.Tourner(diff.AngleDegres);
                        intervalle = 0;
                    }

                    ChangerPosition(Position);
                }
                else if (difference > 0)
                {
                    double distance = VitesseActuelle / (1000.0 / intervalle);

                    // Phase accélération ou déccélération
                    if (Position.Coordonnees.Distance(Destination.Coordonnees) > DistanceFreinageActuelle)
                        VitesseActuelle = Math.Min(VitesseDeplacement, VitesseActuelle + AccelerationDebutDeplacement / (1000.0 / intervalle));
                    else
                        VitesseActuelle = VitesseActuelle - AccelerationFinDeplacement / (1000.0 / intervalle);
                    
                    if (Destination.Coordonnees.Distance(Position.Coordonnees) <= distance)
                    {
                        VitesseActuelle = 0;
                        Position.Copie(Destination);
                        DeplacementLigne = false;
                    }
                    else
                    {
                        if (SensDep == SensAR.Avant)
                            Position.Avancer(distance);
                        else
                            Position.Avancer(-distance);
                    }

                    ChangerPosition(Position);
                }
            }

            SemDeplacement.Release();
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

            double depX = distance * Math.Cos(Position.Angle.AngleRadians);
            double depY = distance * Math.Sin(Position.Angle.AngleRadians);
            
            Destination = new Position(Position.Angle, new PointReel(Position.Coordonnees.X + depX, Position.Coordonnees.Y + depY));

            // TODO2018 attente avec un sémaphore ?
            if (attendre)
                while (Position.Coordonnees.X != Destination.Coordonnees.X ||
                    Position.Coordonnees.Y != Destination.Coordonnees.Y)
                    Thread.Sleep(10);
        }

        public override void Reculer(int distance, bool attendre = true)
        {
            Avancer(-distance, attendre);
        }

        public override void PivotGauche(Angle angle, bool attendre = true)
        {
            base.PivotGauche(angle, attendre);
            
            angle = Math.Round(angle, 2);
            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Gauche));
            Destination = new Position(new Angle(Position.Angle.AngleDegres - angle, AnglyeType.Degre), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));
            SensPivot = SensGD.Gauche;

            if (attendre)
                while (Position.Angle != Destination.Angle)
                    Thread.Sleep(10);
        }

        public override void PivotDroite(Angle angle, bool attendre = true)
        {
            base.PivotDroite(angle, attendre);
            
            angle = Math.Round(angle, 2);
            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Droite));
            Destination = new Position(new Angle(Position.Angle.AngleDegres + angle, AnglyeType.Degre), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));
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
                Position nouvelleDestination = new Calculs.Position(new Angle(Position.Angle.AngleDegres), new PointReel(position.Coordonnees.X, position.Coordonnees.Y));

                if (DeplacementLigne)
                {
                    if (SensDep == SensAR.Avant)
                        nouvelleDestination.Avancer(DistanceFreinageActuelle);
                    else
                        nouvelleDestination.Avancer(-DistanceFreinageActuelle);
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

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, Angle angle, bool attendre = true)
        {
            // TODO2018
        }

        private List<PointReel> trajectoirePolaire;
        public override void TrajectoirePolaire(SensAR sens, List<PointReel> points, bool attendre = true)
        {
            trajectoirePolaire = points;
            pointCourantTrajPolaire = 0;

            while (pointCourantTrajPolaire != -1)
                Thread.Sleep(10);
        }

        public override void ReglerOffsetAsserv(int offsetX, int offsetY, Angle offsetTeta)
        {
            Position = new Position(new Angle(-offsetTeta, AnglyeType.Degre), new PointReel(offsetX, offsetY));
            PositionCible = new PointReel(offsetX, offsetY);
            ChangerPosition(Position);
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            RecallageEnCours = true;
            Historique.AjouterAction(new ActionRecallage(this, sens));

            int accelTmp = AccelerationDebutDeplacement;
            AccelerationDebutDeplacement = 4000;

            while (Position.Coordonnees.X - Longueur / 2 > 0 &&
                Position.Coordonnees.X + Longueur / 2 < Plateau.LongueurPlateau &&
                Position.Coordonnees.Y - Longueur / 2 > 0 &&
                Position.Coordonnees.Y + Longueur / 2 < Plateau.LargeurPlateau)
            {
                if (sens == SensAR.Arriere)
                    Reculer(5);
                else
                    Avancer(5);
            }
            if (Position.Coordonnees.X < 0)
                Position.Coordonnees.X = Longueur / 2;
            if (Position.Coordonnees.X > Plateau.LongueurPlateau)
                Position.Coordonnees.X = Plateau.LongueurPlateau - Longueur / 2;
            if (Position.Coordonnees.Y < 0)
                Position.Coordonnees.Y = Longueur / 2;
            if (Position.Coordonnees.Y > Plateau.LargeurPlateau)
                Position.Coordonnees.Y = Plateau.LargeurPlateau - Longueur / 2;

            AccelerationDebutDeplacement = accelTmp;

            RecallageEnCours = false;
        }

        public override void Init()
        {
            Historique = new Historique(IDRobot);
            HistoriqueCoordonnees = new List<Position>();
            if (this == Robots.GrosRobot)
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                    Position = new Calculs.Position(new Angle(0, AnglyeType.Degre), new PointReel(240, 1000));
                else
                    Position = new Calculs.Position(new Angle(180, AnglyeType.Degre), new PointReel(3000 - 240, 1000));
            }
            else
            {
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                    Position = new Calculs.Position(new Angle(0, AnglyeType.Degre), new PointReel(480, 1000));
                else
                    Position = new Calculs.Position(new Angle(180, AnglyeType.Degre), new PointReel(3000 - 480, 1000));
            }

            PositionCible = null;
        }

        public override void BougeServo(ServomoteurID servo, int position)
        {
            base.BougeServo(servo, position);
            Historique.AjouterAction(new ActionServo(this, position, servo));
        }

        public override bool DemandeCapteurOnOff(CapteurOnOffID capteur, bool attendre = true)
        {
            // TODO
            return true;
        }

        public override Color DemandeCapteurCouleur(CapteurCouleurID capteur, bool attendre = true)
        {
            // TODO
            return Color.Black;
        }

        public override void ServoVitesse(ServomoteurID servo, int vitesse)
        {
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

        public override void ActionneurOnOff(ActionneurOnOffID actionneur, bool on)
        {
            // TODO
            Historique.AjouterAction(new ActionOnOff(this, actionneur, on));
        }

        System.Timers.Timer timerDeplacement;
        System.Timers.Timer timerPositions;

        public override void MoteurPosition(MoteurID moteur, int vitesse)
        {
            base.MoteurPosition(moteur, vitesse);
        }

        public override void MoteurVitesse(MoteurID moteur, SensGD sens, int vitesse)
        {
            base.MoteurVitesse(moteur, sens, vitesse);
        }

        public override void MoteurAcceleration(MoteurID moteur, int acceleration)
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

        public override void ArmerJack()
        {
            // TODO
        }

        public override bool GetJack()
        {
            return true;
        }

        public override String GetMesureLidar(LidarID lidar, int timeout, out Position refPosition)
        {
            refPosition = new Position(position);
            return "";
        }

        public override Color GetCouleurEquipe(bool historique = true)
        {
            return Plateau.CouleurDroiteJaune;
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

        public override List<double>[] DiagnosticCpuPwm(int nbValeurs)
        {
            return null;
        }

        public override void DemandeValeursAnalogiques(Carte carte, bool attendre)
        {
            List<double> values = Enumerable.Range(1, 9).Select(o => (double)o).ToList();
            ValeursAnalogiques[carte] = values;
        }
    }
}
