using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.IHM;
using System.Threading;

namespace GoBot.Mouvements
{
    class MoveGrosBougie : Mouvement
    {
        public override Position Position { get; protected set; }
        private int numeroBougie;

        public MoveGrosBougie(int iBougie)
        {
            numeroBougie = iBougie;
            Position = PositionsMouvements.PositionGrosBougie[iBougie];
        }

        public override bool Executer(int timeOut = 0)
        {
            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Robots.GrosRobot.PositionerAngle(Position.Angle, 1);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasBasDroite, 500);
                Thread.Sleep(500);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasBasDroite, 0);

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
                if (Score <= 0)
                    return double.MaxValue;

                double distance = Robots.GrosRobot.Position.Coordonnees.Distance(Position.Coordonnees);
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
                return Score * Plateau.PoidActions.PoidGlobalGrosBougie * Plateau.PoidActions.PoidsGrosBougie[numeroBougie];
            }
        }
    }
}
