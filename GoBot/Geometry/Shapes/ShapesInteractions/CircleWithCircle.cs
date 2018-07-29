﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class CircleWithCircle
    {
        public static bool Contains(Circle circleContaining, Circle circleContained)
        {
            // Pour contenir un cercle il faut que son rayon + la distance entre les centres des deux cercles soit inférieure à notre rayon

            return circleContained.Radius + circleContained.Center.Distance(circleContaining.Center) < circleContaining.Radius;
        }

        public static double Distance(Circle circle1, Circle circle2)
        {
            return Math.Max(0, circle1.Center.Distance(circle2.Center) - circle2.Radius - circle1.Radius);
        }

        public static bool Cross(Circle circle1, Circle circle2)
        {
            // Pour croiser un cercle il suffit que son centre soit éloigné de notre centre de moins que la somme de nos 2 rayons
            // Et que les cercles ne se contiennent pas l'un l'autre

            bool ok;

            if (circle1.Center.Distance(circle2.Center) <= circle1.Radius + circle2.Radius)
                ok = (!circle2.Contains(circle1)) && (!circle1.Contains(circle2));
            else
                ok = false;

            return ok;
        }
        
        public static List<RealPoint> GetCrossingPoints(Circle circle1, Circle circle2)
        {
            // Résolution du système d'équation à deux inconnues des deux équations de cercle

            List<RealPoint> output = new List<RealPoint>();

            bool aligned = Math.Abs(circle1.Center.Y - circle2.Center.Y) < RealPoint.PRECISION;

            if (aligned)// Cercles non alignés horizontalement (on pivote pour les calculs, sinon division par 0)
                circle1 = circle1.Rotation(90, circle2.Center);

            RealPoint oc1 = new RealPoint(circle1.Center), oc2 = new RealPoint(circle2.Center);
            double b = circle1.Radius, c = circle2.Radius;

            double a = (-(Math.Pow(oc1.X, 2)) - (Math.Pow(oc1.Y, 2)) + Math.Pow(oc2.X, 2) + Math.Pow(oc2.Y, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * (oc2.Y - oc1.Y));
            double d = ((oc2.X - oc1.X) / (oc2.Y - oc1.Y));

            double A = Math.Pow(d, 2) + 1;
            double B = -2 * oc1.X + 2 * oc1.Y * d - 2 * a * d;
            double C = Math.Pow(oc1.X, 2) + Math.Pow(oc1.Y, 2) - 2 * oc1.Y * a + Math.Pow(a, 2) - Math.Pow(b, 2);

            double delta = Math.Pow(B, 2) - 4 * A * C;

            if (delta >= 0)
            {
                double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
                double y1 = a - x1 * d;
                output.Add(new RealPoint(x1, y1));

                if (delta > 0)
                {
                    double x2 = (-B - Math.Sqrt(delta)) / (2 * A);
                    double y2 = a - x2 * d;
                    output.Add(new RealPoint(x2, y2));
                }
            }

            if (aligned)
                output = output.ConvertAll(p => p.Rotation(-90, circle2.Center));

            return output;
        }
    }
}
