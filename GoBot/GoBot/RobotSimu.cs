using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using System.Timers;
using GoBot.Calculs.Formes;
using System.Threading;

namespace GoBot
{
    class RobotSimu : Robot
    {
        private Semaphore semDeplacement;
        public override Position Position { get; protected set; }

        public override int VitesseDeplacement { get; set; }
        public override int AccelerationDeplacement { get; set; }
        public override int VitessePivot { get; set; }
        public override int AccelerationPivot { get; set; }

        private double VitesseActuelle { get; set; }

        public override int Taille { get { return 280; } }

        private double IntervalleRafraichissementPosition = 10;

        private Position Destination { get; set; }
        private SensGD SensPivot { get; set; }
        private SensAR SensDep { get; set; }

        public RobotSimu()
        {
            Position = new Position();

            VitesseActuelle = 0;
            timerDeplacement = new System.Timers.Timer(IntervalleRafraichissementPosition);
            timerDeplacement.Elapsed += new ElapsedEventHandler(timerDeplacement_Elapsed);
            timerDeplacement.Start();
            VitesseActuelle = 600;
            semDeplacement = new Semaphore(1, 1);
            SensDep = SensAR.Avant;
        }

        void timerDeplacement_Elapsed(object sender, ElapsedEventArgs e)
        {
            semDeplacement.WaitOne();
            double difference = Destination.Coordonnees.getDistance(Position.Coordonnees);
            if (Position.Angle.AngleDegres != Destination.Angle.AngleDegres)
            {
                difference = Destination.Angle.AngleDegres - Position.Angle.AngleDegres;
                int coeff = 1;

                if (SensPivot == SensGD.Gauche)
                    coeff = -1;

                if (difference >= VitesseActuelle / 100.0)
                    Position.Angle.Tourner(coeff * VitesseActuelle / 100.0);
                else if (difference <= -VitesseActuelle / 100.0)
                    Position.Angle.Tourner(coeff * VitesseActuelle / 100.0);
                else
                    Position.Angle.Tourner(difference);
            }
            else if (difference > 0)
            {
                double distance = VitesseActuelle / (1000.0 / IntervalleRafraichissementPosition);

                //VitesseActuelle += AccellerationDeplacement / (1000 / IntervalleRafraichissementPosition);
                if (Destination.Coordonnees.getDistance(Position.Coordonnees) < distance)
                    Position = Destination;//.Avancer(Destination.Coordonnees.getDistance(Position.Coordonnees));
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
                SensDep = SensAR.Avant;
            else
                SensDep = SensAR.Arriere;

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

        public void Pivoter(double angle, bool attendre = true)
        {
            Destination = new Position(new Angle(Position.Angle.AngleDegres + angle, AnglyeType.Degre), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));
        }

        public override void PivotGauche(double angle, bool attendre = true)
        {
            Destination = new Position(new Angle(Position.Angle.AngleDegres - angle, AnglyeType.Degre), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));
            SensPivot = SensGD.Gauche;

            if (attendre)
                while (Position.Angle.AngleDegres != Destination.Angle.AngleDegres)
                    Thread.Sleep(50);
        }

        public override void PivotDroite(double angle, bool attendre = true)
        {
            Destination = new Position(new Angle(Position.Angle.AngleDegres + angle, AnglyeType.Degre), new PointReel(Position.Coordonnees.X, Position.Coordonnees.Y));
            SensPivot = SensGD.Droite;

            if (attendre)
                while (Position.Angle.AngleDegres != Destination.Angle.AngleDegres)
                    Thread.Sleep(50);
        }

        public override void Stop(StopMode mode)
        {
            semDeplacement.WaitOne();
            Destination = Position;
            semDeplacement.Release();
        }

        public override void Virage(SensAR sensAr, SensGD sensGd, int rayon, int angle, bool attendre = true)
        {
            throw new NotImplementedException();
        }

        public override void ReglerOffsetAsserv(int offsetX, int offsetY, int offsetTeta)
        {
            Position = new Position(new Angle(offsetTeta, AnglyeType.Degre), new PointReel(offsetX, offsetY));
        }

        public override void Recallage(SensAR sens, bool attendre = true)
        {
            if (sens == SensAR.Arriere)
            {
                while (Position.Coordonnees.X - Taille / 2 > 0 &&
                    Position.Coordonnees.X + Taille / 2 < 3000 &&
                    Position.Coordonnees.Y - Taille / 2 > 0 &&
                    Position.Coordonnees.Y + Taille / 2 < 2000)
                {
                    Reculer(50);
                }
                if (Position.Coordonnees.X < 0)
                    Position.Coordonnees.X = Taille / 2;
                if (Position.Coordonnees.X > 3000)
                    Position.Coordonnees.X = 3000 - Taille / 2;
                if (Position.Coordonnees.Y < 0)
                    Position.Coordonnees.Y = Taille / 2;
                if (Position.Coordonnees.Y > 2000)
                    Position.Coordonnees.Y = 2000 - Taille / 2;
            }
        }

        public override void Init()
        {
            Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(3000-1100, 1000));
            Destination = Position;
            Historique = new Historique();
        }

        public override void BougeServo(ServomoteurID servo, int position)
        {
            throw new NotImplementedException();
        }

        public override void EnvoyerPID(int p, int i, int d)
        {
            throw new NotImplementedException();
        }

        public override void CoupureAlim()
        {
            throw new NotImplementedException();
        }

        System.Timers.Timer timerDeplacement; 
    }
}
