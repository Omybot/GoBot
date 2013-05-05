﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.IHM;
using System.Threading;
using GoBot.Calculs.Formes;

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
            ServomoteurID servo = ServomoteurID.GRPetitBras;
            int posHaut = Config.CurrentConfig.PositionGRPetitBrasHaut;
            int posBas = Config.CurrentConfig.PositionGRPetitBrasBas;

            if (numeroBougie == 1 || numeroBougie == 11 || numeroBougie == 0 || numeroBougie == 2 || numeroBougie == 4 || numeroBougie == 8 || numeroBougie == 10 || numeroBougie == 12 || numeroBougie == 14 || numeroBougie == 18)
            {
                servo = ServomoteurID.GRGrandBras;
                posHaut = Config.CurrentConfig.PositionGRGrandBrasHaut;
                posBas = Config.CurrentConfig.PositionGRGrandBrasBas;
            }
            if (numeroBougie == 1 || numeroBougie == 11)
            {
                posBas = Config.CurrentConfig.PositionGRGrandBrasRange;
            }

            Plateau.BougiesEnfoncees[numeroBougie] = true;
            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                if (!Robots.GrosRobot.ServoSorti[servo])
                {
                    Robots.GrosRobot.PositionerAngle(new Angle(Position.Angle.AngleDegres + 90), 25);
                    Robots.GrosRobot.BougeServo(servo, posHaut);
                }
                Robots.GrosRobot.PositionerAngle(Position.Angle, 1);

                Robots.GrosRobot.BougeServo(servo, posBas);
                Thread.Sleep(300);
                Robots.GrosRobot.BougeServo(servo, posHaut);
                Thread.Sleep(300);
                Robots.GrosRobot.BougeServo(servo, posBas);
                Thread.Sleep(300);
                Robots.GrosRobot.BougeServo(servo, posHaut);

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
                return Score * Plateau.PoidActions.PoidGlobalGrosBougie * Plateau.PoidActions.PoidsGrosBougie[numeroBougie];
            }
        }
    }
}
