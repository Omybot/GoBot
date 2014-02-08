using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Calculs.Formes;

namespace GoBot.Mouvements
{
    public abstract class Mouvement
    {
        public abstract bool Executer(int timeOut = 0);
        public abstract int Score { get; }
        public abstract double ScorePondere { get; }
        public Position Position { get; protected set; }

        public double Cout
        {
            get
            {
                if (ScorePondere <= 0)
                    return double.MaxValue;

                double distance = Robots.GrosRobot.Position.Coordonnees.Distance(Position.Coordonnees) / 10;
                double cout = distance / ScorePondere;

                foreach (Cercle c in Plateau.ObstaclesTemporaires)
                {
                    double distanceAdv = Position.Coordonnees.Distance(c.Centre) / 10;
                    if (distanceAdv < 45)
                        cout = double.PositiveInfinity;
                    else
                        cout /= (distanceAdv * distanceAdv);
                }

                return cout * 10000;
            }
        }
    }
}
