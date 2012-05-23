using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using GoBot.Calculs;

namespace GoBot
{
    public enum Deplacement
    {
        Aucun,
        Avance,
        Recule,
        TourneDroite,
        TourneGauche
    }

    public class Robot
    {
        private Position position;
        private Color couleur;
        private static int TAILLE = 300;
        private static int RAYON = 212;
        Timer timerDep;
        Deplacement depCourant;
        double distanceDep;
        double vitesse;

        public Robot()
        {
            couleur = Color.Blue;
            position = new Position();
            depCourant = Deplacement.Aucun;
            vitesse = 1500;
        }

        public Robot(Position pos, Color _color)
        {
            couleur = _color;
            position = pos;
            depCourant = Deplacement.Aucun;
            vitesse = 1500;
        }

        public void lancement()
        {
            TimerCallback timerDelegate = new TimerCallback(deplacement);
            timerDep = new System.Threading.Timer(timerDelegate, (Object)this, 0, 1);
        }

        public bool Arrete
        {
            get
            {
                return distanceDep == 0;
            }
        }

        private static void deplacement(Object param)
        {
            Robot robot = (Robot)param;

            if (robot.depCourant == Deplacement.Avance)
                robot.avancer();
        }

        public Position Position
        {
            get
            {
                return position;
            }
        }

        public Color Couleur
        {
            get
            {
                return couleur;
            }
        }

        public static int Taille
        {
            get
            {
                return TAILLE;
            }
        }

        public static int Rayon
        {
            get
            {
                return RAYON;
            }
        }

        public void avancer()
        {
            double depX = (float)Math.Cos(position.Angle.AngleRadians) * (float)vitesse / 66;
            double depY = (float)Math.Sin(position.Angle.AngleRadians) * (float)vitesse / 66;

            double distance = Math.Sqrt(depX * depX + depY * depY);

            if (distance < distanceDep)
            {
                position.deplacer(depX, depY);
                distanceDep -= distance;
            }
            else
            {
                depY = (distanceDep * depY) / distance;
                depX = (distanceDep * depX) / distance;
                position.deplacer(depX, depY);
                distanceDep = 0;

                // TODO calculer la bonne longueur
            }
        }

        public void reculer()
        {
            position.deplacer(-(float)Math.Cos(position.Angle.AngleRadians), -(float)Math.Sin(position.Angle.AngleRadians));
        }

        public void tourner(double angleDegres)
        {
            if (angleDegres > 0)
            {
                while (angleDegres >= 1)
                {
                    angleDegres--;
                    Thread.Sleep(7);
                    position.tourner(1);
                }

                position.tourner(angleDegres);
            }
            else
            {
                while (angleDegres <= -1)
                {
                    angleDegres++;
                    Thread.Sleep(7);
                    position.tourner(-1);
                }

                position.tourner(angleDegres);
            }
        }

        public void avancer(int distance)
        {
            depCourant = Deplacement.Avance;
            distanceDep = distance;
        }

        public void reculer(int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                reculer();
                Thread.Sleep(0);
            }
        }

        public void stop()
        {
        }
    }
}
