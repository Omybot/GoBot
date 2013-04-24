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
    class MovePetitCadeau : Mouvement
    {
        private Position position;
        private int numeroCadeau;

        public MovePetitCadeau(int iCadeau)
        {
            numeroCadeau = iCadeau;
            position = PositionsMouvements.PositionPetitCadeau[iCadeau];
        }

        public override bool Executer(int timeOut = 0)
        {
            if (PanelTable.Plateau.PathFinding(Robots.PetitRobot, position.Coordonnees.X, position.Coordonnees.Y, timeOut, true))
            {
                Angle angle180 = position.Angle - Robots.PetitRobot.Position.Angle;

                if (Math.Abs(angle180.AngleDegres) < 90)
                {
                    Robots.PetitRobot.PositionerAngle(position.Angle, 1);
                    Robots.PetitRobot.BougeServo(ServomoteurID.GRBrasBasDroite, 500);
                    Thread.Sleep(500);
                    Robots.PetitRobot.BougeServo(ServomoteurID.GRBrasBasDroite, 0);
                }
                else
                {
                    Robots.PetitRobot.PositionerAngle(position.Angle - new Angle(180, AnglyeType.Degre), 1);
                    Robots.PetitRobot.BougeServo(ServomoteurID.GRBrasBasGauche, 500);
                    Thread.Sleep(500);
                    Robots.PetitRobot.BougeServo(ServomoteurID.GRBrasBasGauche, 0);
                }
                Plateau.Score += Score;
                Plateau.CadeauxActives[numeroCadeau] = true;
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
                if (!Plateau.CadeauxActives[numeroCadeau] && 
                    (Plateau.NotreCouleur == Plateau.CouleurJ2 && numeroCadeau % 2 == 0)
                    ||
                    (Plateau.NotreCouleur == Plateau.CouleurJ1 && numeroCadeau % 2 == 1))
                    return 4;
                else
                    return 0;
            }
        }

        public override double ScorePondere
        {
            get
            {
                return Score * Plateau.PoidActions.PoidGlobalPetitCadeau * Plateau.PoidActions.PoidsPetitCadeau[numeroCadeau];
            }
        }
    }
}
