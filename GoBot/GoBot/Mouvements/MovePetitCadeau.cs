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
    class MovePetitCadeau : Mouvement
    {
        public override Position Position { get; protected set; }
        private int numeroCadeau;

        public MovePetitCadeau(int iCadeau)
        {
            numeroCadeau = iCadeau;
            Position = PositionsMouvements.PositionPetitCadeau[iCadeau];
        }

        public override bool Executer(int timeOut = 0)
        {
            Plateau.CadeauxActives[numeroCadeau] = true;
            if (Robots.PetitRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Angle angle180 = Position.Angle - Robots.PetitRobot.Position.Angle;

                if (Math.Abs(angle180.AngleDegres) < 90)
                {
                    Robots.PetitRobot.PositionerAngle(Position.Angle, 1);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBras, 500);
                    Thread.Sleep(500);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBras, 0);
                }
                else
                {
                    Robots.PetitRobot.PositionerAngle(Position.Angle - new Angle(180, AnglyeType.Degre), 1);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBras, 500);
                    Thread.Sleep(500);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBras, 0);
                }
                Plateau.Score += Score;
                return true;
            }
            else
            {
                Plateau.CadeauxActives[numeroCadeau] = false;
                return false;
            }
        }

        public override double Cout
        {
            get
            {
                if (Score <= 0)
                    return double.MaxValue;

                double distance = Robots.PetitRobot.Position.Coordonnees.Distance(Position.Coordonnees) / 10;
                double cout = distance * distance / ScorePondere;

                Plateau.SemaphoreGraph.WaitOne();
                foreach (Cercle c in Plateau.ObstaclesTemporaires)
                {
                    double distanceAdv = Position.Coordonnees.Distance(c.Centre) / 10;
                    if (distanceAdv < 45)
                        cout = double.PositiveInfinity;
                    else
                        cout /= (distanceAdv * distanceAdv * distanceAdv);
                }
                Plateau.SemaphoreGraph.Release();

                return cout * 10000;
            }
        }

        public override int Score
        {
            get 
            {
                if (!Plateau.CadeauxActives[numeroCadeau] && 
                    ((Plateau.NotreCouleur == Plateau.CouleurJ2B && numeroCadeau % 2 == 0)
                    ||
                    (Plateau.NotreCouleur == Plateau.CouleurJ1R && numeroCadeau % 2 == 1)))
                    return 4;
                else
                    return 0;
            }
        }

        public override double ScorePondere
        {
            get
            {
                return Score * Plateau.PoidActions.PoidGlobalPetitCadeau * Plateau.PoidActions.PoidsPetitCadeau[numeroCadeau];
            }
        }
    }
}
