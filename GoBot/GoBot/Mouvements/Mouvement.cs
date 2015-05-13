using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using GoBot.ElementsJeu;
using System.Drawing;

namespace GoBot.Mouvements
{
    public abstract class Mouvement
    {
        public abstract bool Executer(int timeOut = 0);
        public abstract double Score { get; }
        public abstract double ScorePondere { get; }
        public List<Position> Positions { get; protected set; }
        public ElementJeu Element { get; protected set; }
        public Robot Robot { get; set; }
        public DateTime DateMinimum { get; set; }
        public Color Couleur { get; set; }

        public Mouvement()
        {
            Positions = new List<Position>();
        }
        public Mouvement(int i)
        {
            Positions = new List<Position>();
        }

        public bool BonneCouleur()
        {
            if (Couleur == null)
                return true;
            else
                return Couleur == Plateau.NotreCouleur;
        }


        public Position PositionProche
        {
            get
            {
                if (Positions.Count == 1)
                    return Positions[0];

                double distance = double.MaxValue;

                if (Positions.Count < 1)
                    return null;

                Position proche = Positions[0];

                foreach (Position position in Positions)
                {
                    double distancePosition = Robot.Position.Coordonnees.Distance(position.Coordonnees); 
                    
                    List<IForme> obstacles = new List<IForme>(Plateau.ObstaclesTemporaires);
                    foreach (Cercle c in obstacles)
                    {
                        double distanceAdv = position.Coordonnees.Distance(c.Centre) / 10;
                        if (distanceAdv < 45)
                            distancePosition = double.PositiveInfinity;
                        else
                            distancePosition -= distanceAdv;
                    }

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
                // Si il faut attendre avant de faire cette action
                if (DateMinimum != null && DateMinimum > DateTime.Now)
                    return double.MaxValue;

                if (ScorePondere <= 0 && Positions.Count < 1)
                    return double.MaxValue;

                Position position = PositionProche;

                if (position == null) 
                    return double.MaxValue;

                double distance = Robot.Position.Coordonnees.Distance(position.Coordonnees) / 10;
                double cout = distance / ScorePondere;
                bool adversairePlusProche = false;

                List<IForme> obstacles = new List<IForme>(Plateau.ObstaclesTemporaires);
                foreach (Cercle c in obstacles)
                {
                    double distanceAdv = position.Coordonnees.Distance(c.Centre) / 10;
                    if (distanceAdv < 45)
                        cout = double.PositiveInfinity;
                    else
                        cout /= (distanceAdv * distanceAdv);

                    if (distanceAdv < distance)
                        adversairePlusProche = true;
                }

                if (adversairePlusProche)
                    cout *= 2;

                return cout * 10000;
            }
        }
    }
}
