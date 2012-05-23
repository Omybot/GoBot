using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;

namespace GoBot.Calculs
{
    class Maths
    {
        public static int ArCercleir(double nombre)
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

        public static double Distance2Points(PointReel a, PointReel b)
        {
            double diffX = Math.Pow(a.X - b.X, 2);
            double diffY = Math.Pow(a.Y - b.Y, 2);
            double distance = Math.Sqrt(diffX + diffY);
            return distance;
        }
    }
}
