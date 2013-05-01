using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.IHM;
using System.Threading;
using GoBot.Calculs.Formes;

namespace GoBot.Mouvements
{
    class MoveGrosCadeau : Mouvement
    {
        public override Position Position { get; protected set; }
        private int numeroCadeau;

        public MoveGrosCadeau(int iCadeau)
        {
            numeroCadeau = iCadeau;
            Position = PositionsMouvements.PositionGrosCadeau[iCadeau];
        }

        public override bool Executer(int timeOut = 0)
        {
            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Angle angle180 = Position.Angle - Robots.GrosRobot.Position.Angle;

                if (Math.Abs(angle180.AngleDegres) < 90)
                {
                    Robots.GrosRobot.PositionerAngle(Position.Angle, 1);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, 500);
                    Thread.Sleep(500);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, 0);
                }
                else
                {
                    Robots.GrosRobot.PositionerAngle(Position.Angle - new Angle(180, AnglyeType.Degre), 1);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, 500);
                    Thread.Sleep(500);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, 0);
                }
                Plateau.Score += Score;
                Plateau.CadeauxActives[numeroCadeau] = true;
                return true;
            }
            else
                return false;
        }

        public override double Cout
        {
            get
            {
                if (Score == 0)
                    return double.MaxValue;

                double distance = Robots.GrosRobot.Position.Coordonnees.Distance(Position.Coordonnees);
                return distance * distance / ScorePondere;
            }
        }

        public override int Score
        {
            get
            {
                if (!Plateau.CadeauxActives[numeroCadeau] &&
                    ((Plateau.NotreCouleur == Plateau.CouleurJ2 && numeroCadeau % 2 == 0)
                    ||
                    (Plateau.NotreCouleur == Plateau.CouleurJ1 && numeroCadeau % 2 == 1)))
                    return 4;
                else
                    return 0;
            }
        }

        public override double ScorePondere
        {
            get
            {
                return Score * Plateau.PoidActions.PoidGlobalGrosCadeau * Plateau.PoidActions.PoidsGrosCadeau[numeroCadeau];
            }
        }
    }
}
