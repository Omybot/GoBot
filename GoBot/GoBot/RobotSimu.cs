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
        private Semaphore semDeplacement;
        private Random rand;

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

        public override int Longueur { get; set; }
        public override int Largeur { get; set; }

        private double IntervalleRafraichissementPosition = 10;

        private Position Destination { get; set; }
        private SensGD SensPivot { get; set; }
        private SensAR SensDep { get; set; }

        private bool RecallageEnCours { get; set; }

        public override String Nom { get; set; }

        public RobotSimu()
        {
            Position = new Position();

            timerDeplacement = new System.Timers.Timer(IntervalleRafraichissementPosition);
            timerDeplacement.Elapsed += new ElapsedEventHandler(timerDeplacement_Elapsed);
            timerDeplacement.Start();
            semDeplacement = new Semaphore(1, 1);
            SensDep = SensAR.Avant;

            Nom = "GrosRobot";
            RecallageEnCours = false;
            rand = new Random(DateTime.Now.Millisecond);
        }

        void timerDeplacement_Elapsed(object sender, ElapsedEventArgs e)
        {
            semDeplacement.WaitOne();
            double difference = Destination.Coordonnees.Distance(Position.Coordonnees);
            Angle adifference = Position.Angle - Destination.Angle;
            if (Math.Abs(adifference.AngleDegres) > 0.01)// Math.Round(Position.Angle.AngleDegres, 2) != Math.Round(Destination.Angle.AngleDegres, 2))
            {
                Angle diff = Destination.Angle - Position.Angle;
                int coeff = 1;

                if (SensPivot == SensGD.Gauche)
                    coeff = -1;

                if (Math.Abs(diff.AngleDegres) >= VitessePivot / 100.0)
                    Position.Angle.Tourner(coeff * VitessePivot / 100.0);
                else if (Math.Abs(diff.AngleDegres) <= -VitessePivot / 100.0)
                    Position.Angle.Tourner(coeff * VitessePivot / 100.0);
                else
                    Position.Angle.Tourner(diff.AngleDegres);
            }
            else if (difference > 0)
            {
                double distance = VitesseDeplacement / (1000.0 / IntervalleRafraichissementPosition);

                //VitesseActuelle += AccellerationDeplacement / (1000 / IntervalleRafraichissementPosition);
                if (Destination.Coordonnees.Distance(Position.Coordonnees) < distance)
                    Position = Destination;//.Avancer(Destination.Coordonnees.Distance(Position.Coordonnees));
                else
                {
                    if (SensDep == SensAR.Avant)
                        Position.Avancer(distance);
                    else
                        Position.Avancer(-distance);
                }
            }

            semDeplacement.Release();
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
                    Thread.Sleep(50);

            DeplacementLigne = false;
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
            semDeplacement.WaitOne();
            Destination = Position;
            semDeplacement.Release();
        }

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true)
        {
            // TODO
        }

        public override void ReglerOffsetAsserv(int offsetX, int offsetY, int offsetTeta)
        {
            Position = new Position(new Angle(offsetTeta, AnglyeType.Degre), new PointReel(offsetX, offsetY));
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            RecallageEnCours = true;
            Historique.AjouterAction(new ActionRecallage(this, sens));

            while (Position.Coordonnees.X - Longueur / 2 > 0 &&
                Position.Coordonnees.X + Longueur / 2 < Plateau.LongueurPlateau &&
                Position.Coordonnees.Y - Longueur / 2 > 0 &&
                Position.Coordonnees.Y + Longueur / 2 < Plateau.LargeurPlateau)
            {
                if (sens == SensAR.Arriere)
                    Reculer(50);
                else
                    Avancer(50);
            }
            if (Position.Coordonnees.X < 0)
                Position.Coordonnees.X = Longueur / 2;
            if (Position.Coordonnees.X > Plateau.LongueurPlateau)
                Position.Coordonnees.X = Plateau.LongueurPlateau - Longueur / 2;
            if (Position.Coordonnees.Y < 0)
                Position.Coordonnees.Y = Longueur / 2;
            if (Position.Coordonnees.Y > Plateau.LargeurPlateau)
                Position.Coordonnees.Y = Plateau.LargeurPlateau - Longueur / 2;

            RecallageEnCours = false;
        }

        public override void Init()
        {
            Historique = new Historique();
        }

        public override void BougeServo(ServomoteurID servo, int position)
        {
            // TODO
            base.BougeServo(servo, position);
            Historique.AjouterAction(new ActionServo(this, position, servo));
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

        public override bool GetPresenceBalle(bool historique = true)
        {
            if (rand.Next(2) == 0)
                return true;

            return false; 
        }

        public override Color GetCouleurBalle(bool historique = true)
        {
            if (rand.Next(8) == 0)
                return Color.Blue;

            return Color.White;
        }

        public override bool GetPresenceAssiette(bool historique = true)
        {
            // TODO
            return true;
        }

        public override bool GetAspiRemonte(bool historique = true)
        {
            // TODO
            return true;
        }

        public override void TourneMoteur(MoteurID moteur, int vitesse)
        {
            // TODO
            Historique.AjouterAction(new ActionMoteur(this, vitesse, moteur));

            if (moteur == MoteurID.GRCanonTMin)
                vitesseCanonTMin = vitesse;
        }

        public override void AlimentationPuissance(bool on)
        {
            // TODO
            if (!on)
            {
                VitesseDeplacement = 0;
                AccelerationDeplacement = 0;
                VitessePivot = 0;
                AccelerationPivot = 0;
            }
        }

        private int vitesseCanonTMin = 0;
        public override int GetVitesseCanon(bool historique = true)
        {
            return vitesseCanonTMin;
        }

        public override void Reset()
        {
            // TODO
            Thread.Sleep(500);
        }

        public override void ArmerJack()
        {
            // TODO
        }

        public override bool GetJack(bool historique = true)
        {
            // TODO
            return true;
        }
    }
}
