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
        public List<Position> Positions { get; protected set; }

        public Mouvement()
        {
            Positions = new List<Position>();
        }
        public Mouvement(int i)
        {
            Positions = new List<Position>();
        }

        public Position PositionProche
        {
            get
            {
                if (Positions.Count == 1)
                    return Positions[0];

                double distance = double.MaxValue;
                Position proche = Positions[0];

                foreach (Position position in Positions)
                {
                    double distancePosition = Robots.GrosRobot.Position.Coordonnees.Distance(position.Coordonnees);
                    if (distancePosition < distance)
                    {
                        distance = distancePosition;
                        proche = position;
                    }
                }

                return proche;
            }
        }

        public double Cout
        {
            get
            {
                if (ScorePondere <= 0)
                    return double.MaxValue;

                Position position = PositionProche;

                double distance = Robots.GrosRobot.Position.Coordonnees.Distance(position.Coordonnees) / 10;
                double cout = distance / ScorePondere;

                foreach (Cercle c in Plateau.ObstaclesTemporaires)
                {
                    double distanceAdv = position.Coordonnees.Distance(c.Centre) / 10;
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
