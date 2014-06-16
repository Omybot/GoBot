﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using System.Timers;
using GoBot.Calculs.Formes;
using System.Threading;
using GoBot.Actions;
using System.Drawing;

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

        // Distance entre les deux roues en mm
        private double Entraxe { get; set; }

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

        private int accelerationDeplacement;
        public override int AccelerationDeplacement
        {
            get { return accelerationDeplacement; }
            set
            {
                accelerationDeplacement = value;
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

        public RobotSimu(IDRobot idRobot)
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

            Entraxe = 306.11;
            Nom = "GrosRobot";
            RecallageEnCours = false;
            Rand = new Random(DateTime.Now.Millisecond);
        }

        void timerPositions_Elapsed(object sender, ElapsedEventArgs e)
        {
            HistoriqueCoordonnees.Add(new Position(new Angle(Position.Angle), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y)));
            while (HistoriqueCoordonnees.Count > 3000)
                HistoriqueCoordonnees.RemoveAt(0);
        }

        public double DistanceFreinageActuelle
        {
            get
            {
                if (VitesseActuelle == 0)
                    return 0;

                return (VitesseActuelle * VitesseActuelle) / (2 * AccelerationDeplacement);
            }
        }

        public double AngleFreinageActuel
        {
            get
            {
                return (VitesseActuelle * VitesseActuelle) / (2 * AccelerationPivot);
            }
        }

        DateTime prec = DateTime.Now;
        void timerDeplacement_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Calcul du temps écoulé depuis la dernière mise à jour de la position
            double intervalle = (DateTime.Now - prec).TotalMilliseconds;
            prec = DateTime.Now;

            SemDeplacement.WaitOne();
            double difference = Destination.Coordonnees.Distance(Position.Coordonnees);
            Angle adifference = Position.Angle - Destination.Angle;
            if (Math.Abs(adifference.AngleDegres) > 0.01)// Math.Round(Position.Angle.AngleDegres, 2) != Math.Round(Destination.Angle.AngleDegres, 2))
            {
                Angle diff = Destination.Angle - Position.Angle;
                int coeff = 1;

                if (SensPivot == SensGD.Gauche)
                    coeff = -1;

                double distance = Math.Abs(adifference.AngleDegres) / 360.0 * Entraxe * Math.PI;

                if (distance > AngleFreinageActuel)
                    VitesseActuelle = Math.Min(VitessePivot, VitesseActuelle + AccelerationPivot / (1000.0 / intervalle));
                else
                    VitesseActuelle = VitesseActuelle - AccelerationPivot / (1000.0 / intervalle);

                if (Math.Abs(diff.AngleDegres) >= VitesseActuelle / (1000.0 / intervalle))
                    Position.Angle.Tourner(coeff * VitesseActuelle / (1000.0 / intervalle));
                else if (Math.Abs(diff.AngleDegres) <= -VitesseActuelle / (1000.0 / intervalle))
                    Position.Angle.Tourner(coeff * VitesseActuelle / (1000.0 / intervalle));
                else
                    Position.Angle.Tourner(diff.AngleDegres);
            }
            else if (difference > 0)
            {
                // Phase accélération ou déccélération
                if (Position.Coordonnees.Distance(Destination.Coordonnees) > DistanceFreinageActuelle)
                    VitesseActuelle = Math.Min(VitesseDeplacement, VitesseActuelle + AccelerationDeplacement / (1000.0 / intervalle));
                else
                    VitesseActuelle = VitesseActuelle - AccelerationDeplacement / (1000.0 / intervalle);

                double distance = VitesseActuelle / (1000.0 / intervalle);

                //VitesseActuelle += AccellerationDeplacement / (1000 / IntervalleRafraichissementPosition);
                if (Destination.Coordonnees.Distance(Position.Coordonnees) <= distance)
                {
                    VitesseActuelle = 0;
                    Position = Destination;//.Avancer(Destination.Coordonnees.Distance(Position.Coordonnees));

                    DeplacementLigne = false;
                }
                else
                {
                    if (SensDep == SensAR.Avant)
                        Position.Avancer(distance);
                    else
                        Position.Avancer(-distance);
                }
            }

            SemDeplacement.Release();
        }

        public override void Avancer(int distance, bool attendre = true)
        {
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

            if (attendre)
                while (Position.Coordonnees.X != Destination.Coordonnees.X ||
                    Position.Coordonnees.Y != Destination.Coordonnees.Y)
                    Thread.Sleep(10);
        }

        public override void Reculer(int distance, bool attendre = true)
        {
            Avancer(-distance, attendre);
        }

        public override void PivotGauche(double angle, bool attendre = true)
        {
            angle = Math.Round(angle, 2);
            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Gauche));
            Destination = new Position(new Angle(Position.Angle.AngleDegres - angle, AnglyeType.Degre), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));
            SensPivot = SensGD.Gauche;

            if (attendre)
                while (Position.Angle != Destination.Angle)
                    Thread.Sleep(50);
        }

        public override void PivotDroite(double angle, bool attendre = true)
        {
            angle = Math.Round(angle, 2);
            Historique.AjouterAction(new ActionPivot(this, angle, SensGD.Droite));
            Destination = new Position(new Angle(Position.Angle.AngleDegres + angle, AnglyeType.Degre), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));
            SensPivot = SensGD.Droite;

            if (attendre)
                while (Position.Angle != Destination.Angle)
                    Thread.Sleep(50);
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

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true)
        {
            // TODO
        }

        public override void ReglerOffsetAsserv(int offsetX, int offsetY, double offsetTeta)
        {
            Position = new Position(new Angle(-offsetTeta, AnglyeType.Degre), new PointReel(offsetX, offsetY));
            //PositionCible = new PointReel(offsetX, offsetY);
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            RecallageEnCours = true;
            Historique.AjouterAction(new ActionRecallage(this, sens));

            int accelTmp = AccelerationDeplacement;
            AccelerationDeplacement = 4000;

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

            AccelerationDeplacement = accelTmp;

            RecallageEnCours = false;
        }

        public override void Init()
        {
            Historique = new Historique(IDRobot);
            HistoriqueCoordonnees = new List<Position>();
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
            {
                if (this == Robots.PetitRobot)
                    Position = new Calculs.Position(new Angle(90, AnglyeType.Degre), new PointReel(191, 91));
                else
                    Position = new Calculs.Position(new Angle(26, AnglyeType.Degre), new PointReel(187, 397));
            }
            else
            {
                if (this == Robots.PetitRobot)
                    Position = new Calculs.Position(new Angle(90, AnglyeType.Degre), new PointReel(3000 - 191, 91));
                else
                    Position = new Calculs.Position(new Angle(180 - 26, AnglyeType.Degre), new PointReel(3000 - 187, 397));
            }

            PositionCible = null;
        }

        public override void BougeServo(ServomoteurID servo, int position)
        {
            base.BougeServo(servo, position);
            Historique.AjouterAction(new ActionServo(this, position, servo));
        }

        public override bool DemandeCapteurOnOff(CapteurOnOff capteur, bool attendre = true)
        {
            // TODO
            return true;
        }

        public override void ServoVitesse(ServomoteurID servo, int vitesse)
        {
        }

        public override void EnvoyerPID(int p, int i, int d)
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

            Historique.AjouterAction(new ActionMoteur(this, vitesse, moteur));
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

        public override bool GetJack(bool historique = true)
        {
            return true;
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
    }
}
