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
            Robots.GrosRobot.Historique.Log("Début cadeau " + numeroCadeau);
            Plateau.BaisserBras();
            Plateau.CadeauxActives[numeroCadeau] = true;
            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Robots.GrosRobot.Historique.Log("Position cadeau " + numeroCadeau + " atteinte");
                Angle angle180 = Position.Angle - Robots.GrosRobot.Position.Angle;

                Robots.GrosRobot.PositionerAngle(Position.Angle, 1);
                Robots.GrosRobot.Historique.Log("Angle cadeau " + numeroCadeau + " atteint");

                Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasBas);
                Thread.Sleep(400);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasRange);

                Robots.GrosRobot.Historique.Log("Fin cadeau " + numeroCadeau);
                Plateau.Score += Score;
                return true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation cadeau " + numeroCadeau);
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
                return (Score > 0 ? 1 : 0) * Plateau.PoidActions.PoidGlobalGrosCadeau * Plateau.PoidActions.PoidsGrosCadeau[numeroCadeau];
            }
        }
    }
}
