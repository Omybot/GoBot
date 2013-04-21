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
        private Position position;
        private int numeroBougie;

        public MovePetitBougie(int iBougie)
        {
            numeroBougie = iBougie;
            position = PositionsMouvements.PositionPetitBougie[iBougie];
        }

        public override bool Executer(int timeOut = 0)
        {
            if (PanelTable.Plateau.PathFinding(position.Coordonnees.X, position.Coordonnees.Y, timeOut, true))
            {
                Angle angle180 = position.Angle - Robots.GrosRobot.Position.Angle;

                if (Math.Abs(angle180.AngleDegres) < 90)
                {
                    Robots.GrosRobot.PositionerAngle(position.Angle, 1);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasBasDroite, 500);
                    Thread.Sleep(500);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasBasDroite, 0);
                }
                else
                {
                    Robots.GrosRobot.PositionerAngle(position.Angle - new Angle(180, AnglyeType.Degre), 1);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasBasGauche, 500);
                    Thread.Sleep(500);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasBasGauche, 0);
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
            get { throw new NotImplementedException(); }
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
                if (Plateau.CouleursBougies[numeroBougie] == System.Drawing.Color.White && nbBlancEnfonces == 3)
                    return 4 + 20;
                else if (!Plateau.BougiesEnfoncees[numeroBougie] && (Plateau.CouleursBougies[numeroBougie] == Plateau.NotreCouleur || Plateau.CouleursBougies[numeroBougie] == System.Drawing.Color.White))
                    return 4;
                else
                    return 0;
            }
        }
    }
}
