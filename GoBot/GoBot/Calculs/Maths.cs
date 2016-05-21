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

    class Maths
    {
        public static int Arrondi(double nombre)
        {
            return (int)(Math.Round(nombre));
        }

        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static Direction GetDirection(PointReel depart, PointReel arrivee)
        {
            Position positionDepart = new Position(0, depart);
            return GetDirection(positionDepart, arrivee);
        }

        /// <summary>
        ///  Retourne la direction (angle et distance) à suivre pour arriver à un point donné en partant d'une position précise (coordonnées et angle)
        /// </summary>
        /// <param name="depart">Position de départ</param>
        /// <param name="arrivee">Coordonnées d'arrivée</param>
        /// <returns>Direction à prendre</returns>
        public static Direction GetDirection(Position depart, PointReel arrivee)
        {
            Direction result = new Direction();

            double distance = depart.Coordonnees.Distance(arrivee);
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

        /// <summary>
        /// Retourneles coordonnées d'un point en fonction d'une position de départ et d'une direction
        /// </summary>
        /// <param name="depart">Point de départ</param>
        /// <param name="direction">Direction</param>
        /// <returns>Coordonnées du point</returns>
        public static PointReel GetCoordonnees(Position depart, Direction direction)
        {
            Angle angleAdverse = direction.angle + depart.Angle;

            double x = depart.Coordonnees.X + Math.Cos(angleAdverse.AngleRadians) * direction.distance;
            double y = depart.Coordonnees.Y + Math.Sin(angleAdverse.AngleRadians) * direction.distance;

            PointReel positionAdv = new PointReel(x, y);

            return positionAdv;
        }

        public static double EcartType(List<double> liste)
        {
            if (liste.Count > 0)
            {
                double moyenne = liste.Average();

                double ecarts = 0;

                foreach (double val in liste)
                    ecarts += (val - moyenne) * (val - moyenne);

                ecarts /= liste.Count;

                ecarts = Math.Sqrt(ecarts);

                return ecarts;
            }
            else
                return 0;
        }
    }
}
