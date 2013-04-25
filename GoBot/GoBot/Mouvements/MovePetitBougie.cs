using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.IHM;
using System.Threading;

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
            if (Robots.PetitRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Angle angle180 = Position.Angle - Robots.PetitRobot.Position.Angle;

                if (Math.Abs(angle180.AngleDegres) < 90)
                {
                    Robots.PetitRobot.PositionerAngle(Position.Angle, 1);
                    Robots.PetitRobot.BougeServo(ServomoteurID.GRBrasBasDroite, 500);
                    Thread.Sleep(500);
                    Robots.PetitRobot.BougeServo(ServomoteurID.GRBrasBasDroite, 0);
                }
                else
                {
                    Robots.PetitRobot.PositionerAngle(Position.Angle - new Angle(180, AnglyeType.Degre), 1);
                    Robots.PetitRobot.BougeServo(ServomoteurID.GRBrasBasGauche, 500);
                    Thread.Sleep(500);
                    Robots.PetitRobot.BougeServo(ServomoteurID.GRBrasBasGauche, 0);
                }
                Plateau.Score += Score;
                Plateau.BougiesEnfoncees[numeroBougie] = true;
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

                double distance = Robots.PetitRobot.Position.Coordonnees.Distance(Position.Coordonnees);
                return distance * distance / ScorePondere;
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
                return Score * Plateau.PoidActions.PoidGlobalPetitBougie * Plateau.PoidActions.PoidsPetitBougie[numeroBougie];
            }
        }
    }
}
