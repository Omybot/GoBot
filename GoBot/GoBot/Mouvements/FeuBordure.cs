﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;

namespace GoBot.Mouvements
{
    class MouvementFeuBordure : Mouvement
    {
        private int numeroFeu;

        public MouvementFeuBordure(int i)
        {
            numeroFeu = i;
            Position = PositionsMouvements.PositionGrosFeuxBordure[i];
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début feu bordure " + numeroFeu);

            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Robots.GrosRobot.Historique.Log("Position feu bordure " + numeroFeu + " atteinte");
                Angle angle180 = Position.Angle - Robots.GrosRobot.Position.Angle;

                Robots.GrosRobot.PositionerAngle(Position.Angle, 1);
                BrasFeux.MoveAttrapeContreMur();

                Robots.GrosRobot.Historique.Log("Fin feu bordure " + numeroFeu);
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation feu bordure " + numeroFeu);
                return false;
            }

            return true;
        }

        public override int Score
        {
            get { return 1; }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
    }
}
