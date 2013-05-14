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
                Position position = null;
                if (numeroAssiette == 1 || numeroAssiette == 2 || numeroAssiette == 3)
                    position = new Position(new Angle(0), new PointReel(Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.X + 300, Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.Y + 40));
                if (numeroAssiette == 6 || numeroAssiette == 7 || numeroAssiette == 8)
                    position = new Position(new Angle(180), new PointReel(Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.X - 340, Plateau.PositionsAssiettes[numeroAssiette].Coordonnees.Y - 40));

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
            Robots.GrosRobot.Historique.Log("Début accrochage assiette " + numeroAssiette);
            Plateau.BaisserBras();
            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Robots.GrosRobot.Historique.Log("Position assiette " + numeroAssiette + " atteinte");
                Robots.GrosRobot.PositionerAngle(Position.Angle, 5);
                Robots.GrosRobot.Historique.Log("Angle assiette " + numeroAssiette + " atteint");

                Robots.GrosRobot.Lent();
                Robots.GrosRobot.Reculer(170);

                // Si pas d'assiette on abandonne et on s'en va. On considère que l'assiette n'est pas ici
                if (!Robots.GrosRobot.GetPresenceAssiette())
                {
                    Robots.GrosRobot.Historique.Log("Assiette " + numeroAssiette + " non détectée");
                    Robots.GrosRobot.Avancer(150);
                    Plateau.AssiettesExiste[numeroAssiette] = false;
                    return false;
                }

                // Attrapage de l'assiette
                Robots.GrosRobot.Historique.Log("Assiette " + numeroAssiette + " accrochée");
                Robots.GrosRobot.BougeServo(ServomoteurID.GRServoAssiette, Config.CurrentConfig.PositionGRBloqueurFerme);
                Thread.Sleep(1000);
                Robots.GrosRobot.Avancer(170);
                Plateau.AssietteAttrapee = numeroAssiette;
                return true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation accrochage assiette " + numeroAssiette);
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
                if (Plateau.Enchainement.TempsRestant.TotalSeconds > 35 &&
                    Plateau.AssietteAttrapee == -1 && Robots.GrosRobot.BallesChargees &&
                    !Plateau.AssiettesVidees[numeroAssiette] &&
                    Plateau.AssiettesExiste[numeroAssiette])
                    return Plateau.PoidActions.PoidGlobalGrosAccrocheAssiette * Plateau.PoidActions.PoidsGrosAssiette[numeroAssiette];
                else
                    return 0;
            }
        }
    }
}
