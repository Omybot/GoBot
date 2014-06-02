using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using System.Threading;

namespace GoBot.Mouvements
{
    class MouvementFresque : Mouvement
    {
        public MouvementFresque()
        {
            Robot = Robots.PetitRobot;
            Positions.Add(PositionsMouvements.PositionsFresque[0]);
            Positions.Add(PositionsMouvements.PositionsFresque[1]);
        }

        public override bool Executer(int timeOut = 0)
        {
            Robot.Historique.Log("Début fresque");

            Position position = PositionProche;

            if (Robot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Robot.Lent();
                BrasFresque.Lever();
                Robot.Reculer(110);
                BrasFresque.FresquesCollees = Robot.Position.Coordonnees.X < 1500 ? 1 : 2;
                Robot.Avancer(110);
                BrasFresque.Baisser();
                Robot.Rapide();
                Robot.Historique.Log("Fin fresque");

                Plateau.Score += 6;
                return true;
            }
            else
                Robot.Historique.Log("Annulation fresque");

            return false;
        }

        public override int Score
        {
            get { return BrasFresque.FresquesCollees == 0 ? 6 : 0; }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
    }
}
