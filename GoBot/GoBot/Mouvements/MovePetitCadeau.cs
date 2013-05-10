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
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteHaut);
                    Thread.Sleep(500);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, Config.CurrentConfig.PositionPRBrasDroiteRange);
                }
                else
                {
                    Robots.PetitRobot.PositionerAngle(Position.Angle - new Angle(180, AnglyeType.Degre), 1);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheHaut);
                    Thread.Sleep(500);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, Config.CurrentConfig.PositionPRBrasGaucheRange);
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
                return (Score > 0 ? 1 : 0) * Plateau.PoidActions.PoidGlobalPetitCadeau * Plateau.PoidActions.PoidsPetitCadeau[numeroCadeau];
            }
        }
    }
}
