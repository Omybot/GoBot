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

            if (numeroBougie == 16 && (Plateau.CouleursBougies[14] == Plateau.NotreCouleur || Plateau.CouleursBougies[14] == Color.White))
            {
                petitBras = true;
                bougieAdditionnelle = 14;
            }
            else if (numeroBougie == 9 && (Plateau.CouleursBougies[8] == Plateau.NotreCouleur || Plateau.CouleursBougies[8] == Color.White))
            {
                petitBras = true;
                bougieAdditionnelle = 8;
            }
            else if (numeroBougie == 5 && (Plateau.CouleursBougies[2] == Plateau.NotreCouleur || Plateau.CouleursBougies[2] == Color.White))
            {
                petitBras = true;
                bougieAdditionnelle = 2;
            }

            if(bougieAdditionnelle != -1)
                Plateau.BougiesEnfoncees[bougieAdditionnelle] = true;

            Plateau.BougiesEnfoncees[numeroBougie] = true;

            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                if (!Robots.GrosRobot.ServoSorti[ServomoteurID.GRPetitBras] || !Robots.GrosRobot.ServoSorti[ServomoteurID.GRGrandBras])
                {
                    // Sors les bras
                    Robots.GrosRobot.PositionerAngle(new Angle(Position.Angle.AngleDegres + 90), 5);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasHaut);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasHaut);
                    Thread.Sleep(500);
                }
                Robots.GrosRobot.PositionerAngle(Position.Angle, 1);

                if (grandBras)
                {
                    // Les bougies des coins avec les grands bras
                    if (numeroBougie == 1 || numeroBougie == 11)
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasRange);
                    else
                        Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasBas);
                }
                if (petitBras)
                {
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasBas);
                    //Thread.Sleep(50);
                }
                Thread.Sleep(300);
                if (grandBras)
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasHaut);
                if (petitBras)
                {
                    //Thread.Sleep(50);
                    Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasHaut);
                }
                Thread.Sleep(300);

                Plateau.Score += Score;
                return true;
            }
            else
            {
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
                return Score * Plateau.PoidActions.PoidGlobalGrosBougie * Plateau.PoidActions.PoidsGrosBougie[numeroBougie];
            }
        }
    }
}
