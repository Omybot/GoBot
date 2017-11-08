using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.Calculs
{
    public struct Direction
    {
        public Angle angle;
        public double distance;
    }

    class BaliseCalc
    {
        public BaliseCalc()
        {
        }

        public static Direction getDirection(Position depart, PointReel arrivee)
        {
            Direction result = new Direction();

            double distance = Maths.Distance2Points(depart.Coordonnees, arrivee);
            result.distance = distance;

            PointReel devantRobot = new PointReel(depart.Coordonnees.X + Math.Cos(depart.Angle.AngleRadians) * 100, depart.Coordonnees.Y + Math.Sin(depart.Angle.AngleRadians) * 100);
            
            Angle angle;

            double angleCalc = 0;

            // Deux points sur le même axe vertical : 90° ou -90° selon le point le plus haut
            if (arrivee.X == depart.Coordonnees.X)
            {
                angleCalc = Math.PI / 2;
                if (arrivee.Y > depart.Coordonnees.Y)
                    angleCalc = -angleCalc;
            }
            // Deux points sur le même axe horizontal : 0° ou 180° selon le point le plus à gauche
            else if (arrivee.Y == depart.Coordonnees.Y)
            {
                angleCalc = Math.PI;
                if (arrivee.X > depart.Coordonnees.X)
                    angleCalc = 0;
            }
            // Cas général : Calcul de l'angle
            else
            {
                angleCalc = Math.Acos((arrivee.X - depart.Coordonnees.X) / distance);

                if (arrivee.Y > depart.Coordonnees.Y)
                    angleCalc = -angleCalc;
            }
                
            // Prendre en compte l'angle initial du robot
            angle = new Angle(angleCalc, AnglyeType.Radian);
            angle = angle + depart.Angle;

            result.angle = angle;

            return result;
        }

        public static PointReel getCoordonnees(Position depart, Direction direction)
        {
            Angle angleAdverse = direction.angle + depart.Angle;

            double x = depart.Coordonnees.X + Math.Cos(angleAdverse.AngleRadians) * direction.distance;
            double y = depart.Coordonnees.Y + Math.Sin(angleAdverse.AngleRadians) * direction.distance;

            PointReel positionAdv = new PointReel(x, y);

            return positionAdv;
        }
    }
}
