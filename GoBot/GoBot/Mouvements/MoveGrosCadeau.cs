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
            Plateau.BaisserBras();
            Plateau.CadeauxActives[numeroCadeau] = true;
            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Angle angle180 = Position.Angle - Robots.GrosRobot.Position.Angle;

                Robots.GrosRobot.PositionerAngle(Position.Angle, 1);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasBas);
                Thread.Sleep(200);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasRange);

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
                return Score * Plateau.PoidActions.PoidGlobalGrosCadeau * Plateau.PoidActions.PoidsGrosCadeau[numeroCadeau];
            }
        }
    }
}
