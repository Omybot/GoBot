using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.IHM;
using System.Threading;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot.Mouvements
{
    class MoveGrosAccrocheAssiette : Mouvement
    {
        public override Position Position
        {
            get
            {
                Position position;
                if (numeroAssiette < 5)
                    position = new Position(new Angle(0), new PointReel(Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.X + 300, Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.Y));
                else
                    position = new Position(new Angle(180), new PointReel(Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.X - 300, Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.Y));

                return position;
            }
            protected set
            {
            }
        }

        private int numeroAssiette;

        public MoveGrosAccrocheAssiette(int iAssiette)
        {
            numeroAssiette = iAssiette;
        }

        public override bool Executer(int timeOut = 0)
        {
            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Robots.GrosRobot.PositionerAngle(Position.Angle, 5);

                Robots.GrosRobot.Lent();
                Robots.GrosRobot.Reculer(150);
                Robots.GrosRobot.Rapide();

                // Si pas d'assiette on abandonne et on s'en va. On considère que l'assiette n'est pas ici
                if (!Robots.GrosRobot.GetPresenceAssiette())
                {
                    Robots.GrosRobot.Avancer(150);
                    Plateau.AssiettesExiste[numeroAssiette] = false;
                    return false;
                }

                // Attrapage de l'assiette
                Robots.GrosRobot.BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurFerme);
                Robots.GrosRobot.Avancer(150);
                Plateau.AssietteAttrapee = numeroAssiette;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int Score
        {
            get
            {
                return 0;
            }
        }

        public override double ScorePondere
        {
            get
            {
                // Si on n'a pas de balles chargées on ne considère pas l'action sinon il est interessant d'accrocher une assiette
                int score;
                if (Plateau.AssietteAttrapee == -1 && Robots.GrosRobot.BallesChargees && !Plateau.AssiettesVidees[numeroAssiette])
                    score = 14;
                else
                    score = 0;

                return score * Plateau.PoidActions.PoidGlobalGrosAccrocheAssiette * Plateau.PoidActions.PoidsGrosAssiette[numeroAssiette];
            }
        }
    }
}
