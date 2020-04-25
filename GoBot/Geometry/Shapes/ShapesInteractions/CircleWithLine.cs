using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    public static class CircleWithLine
    {
        public static bool Contains(Circle containingCircle, Line containedLine)
        {
            // Un cercle ne peut pas contenir une droite...

            return false;
        }

        public static double Distance(Circle circle, Line line)
        {
            // Distance de la ligne jusqu'au centre du cercle - son rayon (Si négatif c'est que ça croise, donc distance 0)

            return Math.Max(0, line.Distance(circle.Center) - circle.Radius);
        }

        public static bool Cross(Circle circle, Line line)
        {
            // Si une droite croise le cercle, c'est que le point de la droite le plus proche du centre du cercle est éloigné d'une distance inférieure au rayon

            return line.Distance(circle.Center) <= circle.Radius;
        }

        public static List<RealPoint> GetCrossingPoints(Circle circle, Line line)
        {
            List<RealPoint> intersectsPoints = new List<RealPoint>();

            double x1, y1, x2, y2;

            if (line.IsVertical)
            {
                y1 = 0;
                x1 = -line.B;
                y2 = 100;
                x2 = -line.B;
            }
            else
            {
                x1 = 0;
                y1 = line.A * x1 + line.B;
                x2 = 100;
                y2 = line.A * x2 + line.B;
            }

            double dx = x2 - x1;
            double dy = y2 - y1;
            double Ox = x1 - circle.Center.X;
            double Oy = y1 - circle.Center.Y;
            double A = dx * dx + dy * dy;
            double B = 2 * (dx * Ox + dy * Oy);
            double C = Ox * Ox + Oy * Oy - circle.Radius * circle.Radius;
            double delta = B * B - 4 * A * C;

            if (delta < 0 + double.Epsilon && delta > 0 - double.Epsilon)
            {
                double t = -B / (2 * A);
                intersectsPoints.Add(new RealPoint(x1 + t * dx, y1 + t * dy));
            }
            if (delta > 0)
            {
                double t1 = (double)((-B - Math.Sqrt(delta)) / (2 * A));
                double t2 = (double)((-B + Math.Sqrt(delta)) / (2 * A));
                intersectsPoints.Add(new RealPoint(x1 + t1 * dx, y1 + t1 * dy));
                intersectsPoints.Add(new RealPoint(x1 + t2 * dx, y1 + t2 * dy));
            }

            return intersectsPoints;
        }
    }
}
