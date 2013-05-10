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
    class MovePetitBougie : Mouvement
    {
        public override Position Position { get; protected set; }
        private int numeroBougie;

        public MovePetitBougie(int iBougie)
        {
            numeroBougie = iBougie;
            Position = PositionsMouvements.PositionPetitBougie[iBougie];
        }

        public override bool Executer(int timeOut = 0)
        {
            Plateau.BougiesEnfoncees[numeroBougie] = true;
            if (Robots.PetitRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Angle angle180 = Position.Angle - Robots.PetitRobot.Position.Angle;

                if (Math.Abs(angle180.AngleDegres) < 90)
                {
                    Robots.PetitRobot.PositionerAngle(Position.Angle, 1);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, 500);
                    Thread.Sleep(500);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, 0);
                }
                else
                {
                    Robots.PetitRobot.PositionerAngle(Position.Angle - new Angle(180, AnglyeType.Degre), 1);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, 500);
                    Thread.Sleep(500);
                    Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, 0);
                }
                Plateau.Score += Score;
                return true;
            }
            else
            {
                Plateau.BougiesEnfoncees[numeroBougie] = false;
                return false;
            }
        }

        public override int Score
        {
            get
            {
                int nbBlancEnfonces = 0;
                for (int i = 0; i < 20; i++)
                {
                    if (Plateau.CouleursBougies[i] == System.Drawing.Color.White && Plateau.BougiesEnfoncees[i])
                        nbBlancEnfonces++;
                }
                if (!Plateau.BougiesEnfoncees[numeroBougie] && Plateau.CouleursBougies[numeroBougie] == System.Drawing.Color.White && nbBlancEnfonces == 3)
                    return 4 + 20;
                else if (!Plateau.BougiesEnfoncees[numeroBougie] && (Plateau.CouleursBougies[numeroBougie] == Plateau.NotreCouleur || Plateau.CouleursBougies[numeroBougie] == System.Drawing.Color.White))
                    return 4;
                else
                    return 0;
            }
        }

        public override double ScorePondere
        {
            get
            {
                return (Score > 0 ? 1 : 0) * Plateau.PoidActions.PoidGlobalPetitBougie * Plateau.PoidActions.PoidsPetitBougie[numeroBougie];
            }
        }
    }
}
