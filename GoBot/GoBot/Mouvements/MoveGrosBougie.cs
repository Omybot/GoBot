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
            Robots.GrosRobot.Historique.Log("Début bougie " + numeroBougie);

            bool grandBras = false;
            bool petitBras = false;
            int bougieAdditionnelle = -1;

            Plateau.DerniereBougieGros = numeroBougie;
            if (numeroBougie == 1 ||
                numeroBougie == 11 ||
                numeroBougie == 0 ||
                numeroBougie == 2 ||
                numeroBougie == 4 ||
                numeroBougie == 8 ||
                numeroBougie == 10 ||
                numeroBougie == 12 ||
                numeroBougie == 14 ||
                numeroBougie == 18)
            {
                grandBras = true;
            }
            else
            {
                petitBras = true;
            }

            if (numeroBougie == 14 && (Plateau.CouleursBougies[16] == Plateau.NotreCouleur || Plateau.CouleursBougies[16] == Color.White))
            {
                petitBras = true;
                bougieAdditionnelle = 16;
            }
            else if (numeroBougie == 8 && (Plateau.CouleursBougies[9] == Plateau.NotreCouleur || Plateau.CouleursBougies[9] == Color.White))
            {
                petitBras = true;
                bougieAdditionnelle = 9;
            }
            else if (numeroBougie == 2 && (Plateau.CouleursBougies[5] == Plateau.NotreCouleur || Plateau.CouleursBougies[5] == Color.White))
            {
                petitBras = true;
                bougieAdditionnelle = 5;
            }
            else if (numeroBougie == 4 && (Plateau.CouleursBougies[6] == Plateau.NotreCouleur || Plateau.CouleursBougies[6] == Color.White))
            {
                petitBras = true;
                bougieAdditionnelle = 6;
            }
            else if (numeroBougie == 18 && (Plateau.CouleursBougies[19] == Plateau.NotreCouleur || Plateau.CouleursBougies[19] == Color.White))
            {
                petitBras = true;
                bougieAdditionnelle = 19;
            }

            if (numeroBougie == 16 && (Plateau.CouleursBougies[14] == Plateau.NotreCouleur || Plateau.CouleursBougies[14] == Color.White))
            {
                grandBras = true;
                bougieAdditionnelle = 14;
            }
            else if (numeroBougie == 9 && (Plateau.CouleursBougies[8] == Plateau.NotreCouleur || Plateau.CouleursBougies[8] == Color.White))
            {
                grandBras = true;
                bougieAdditionnelle = 8;
            }
            else if (numeroBougie == 5 && (Plateau.CouleursBougies[2] == Plateau.NotreCouleur || Plateau.CouleursBougies[2] == Color.White))
            {
                grandBras = true;
                bougieAdditionnelle = 2;
            }
            else if (numeroBougie == 6 && (Plateau.CouleursBougies[4] == Plateau.NotreCouleur || Plateau.CouleursBougies[4] == Color.White))
            {
                grandBras = true;
                bougieAdditionnelle = 4;
            }
            else if (numeroBougie == 19 && (Plateau.CouleursBougies[18] == Plateau.NotreCouleur || Plateau.CouleursBougies[18] == Color.White))
            {
                grandBras = true;
                bougieAdditionnelle = 18;
            }

            if (bougieAdditionnelle != -1)
            {
                Robots.GrosRobot.Historique.Log("Ajout bougie " + bougieAdditionnelle + " additionnelle");
            }


            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Robots.GrosRobot.Historique.Log("Position bougie " + numeroBougie + (bougieAdditionnelle != -1 ? " et " + bougieAdditionnelle : "") + " atteinte");
                if (!Robots.GrosRobot.ServoSorti[ServomoteurID.GRPetitBras] || !Robots.GrosRobot.ServoSorti[ServomoteurID.GRGrandBras])
                {
                    Robots.GrosRobot.Historique.Log("Ouverture des bras pour les bougies");
                    // Sors les bras
                    Robots.GrosRobot.PositionerAngle(new Angle(Position.Angle.AngleDegres + 90), 5);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasHaut);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasHaut);
                    Thread.Sleep(300);
                }
                Robots.GrosRobot.PositionerAngle(Position.Angle, 1);
                Robots.GrosRobot.Historique.Log("Angle bougie " + numeroBougie + " atteint");

                if (grandBras)
                {
                    // Les bougies des coins avec les grands bras
                    if (numeroBougie == 1 || numeroBougie == 11)
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasRange);
                    else
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasBas);

                    Robots.GrosRobot.Historique.Log("Grand bras pour enfoncer la bougie " + numeroBougie);
                }
                if (petitBras)
                {
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasBas);
                    Robots.GrosRobot.Historique.Log("Petit bras pour enfoncer la bougie " + numeroBougie);
                }
                Thread.Sleep(300);
                if (grandBras)
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasHaut);
                if (petitBras)
                {
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasHaut);
                }
                Thread.Sleep(200);

                Robots.GrosRobot.Historique.Log("Fin bougie " + numeroBougie);
                Plateau.Score += Score;
                if (bougieAdditionnelle != -1)
                {
                    Plateau.Score += Score;
                    Plateau.BougiesEnfoncees[bougieAdditionnelle] = true;
                }
                Plateau.BougiesEnfoncees[numeroBougie] = true;
                return true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation bougie " + numeroBougie);

                if (bougieAdditionnelle != -1)
                    Plateau.BougiesEnfoncees[bougieAdditionnelle] = false;

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
                return (Score > 0 ? 1 : 0) * Plateau.PoidActions.PoidGlobalGrosBougie * Plateau.PoidActions.PoidsGrosBougie[numeroBougie];
            }
        }
    }
}
