using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class CircleWithSegment
    {
        public static bool Contains(Circle containingCircle, Segment containedSegment)
        {
            // Pour contenir un Segment il suffit de contenir ses 2 extremités

            return containingCircle.Contains(containedSegment.StartPoint) && containingCircle.Contains(containedSegment.EndPoint);
        }

        public static double Distance(Circle circle, Segment segment)
        {
            // Distance jusqu'au centre du cercle - son rayon (si négatif c'est que ça croise, donc distance 0)

            return Math.Max(0, segment.Distance(circle.Center) - circle.Radius);
        }

        public static bool Cross(Circle circle, Segment segment)
        {
            // Si un segment croise le cercle, c'est que le point de segment le plus proche du centre du cercle est éloigné d'une distance inférieure au rayon

            return segment.Distance(circle.Center) <= circle.Radius && !circle.Contains(segment);
        }

        public static List<RealPoint> GetCrossingPoints(Circle circle, Segment segment)
        {
            // Equation du second degré

            List<RealPoint> intersectsPoints = new List<RealPoint>();
            double dx = segment.EndPoint.X - segment.StartPoint.X;
            double dy = segment.EndPoint.Y - segment.StartPoint.Y;
            double Ox = segment.StartPoint.X - circle.Center.X;
            double Oy = segment.StartPoint.Y - circle.Center.Y;
            double A = dx * dx + dy * dy;
            double B = 2 * (dx * Ox + dy * Oy);
            double C = Ox * Ox + Oy * Oy - circle.Radius * circle.Radius;
            double delta = B * B - 4 * A * C;

            if (delta < 0 + double.Epsilon && delta > 0 - double.Epsilon)
            {
                double t = -B / (2 * A);
                if (t >= 0 && t <= 1)
                    intersectsPoints.Add(new RealPoint(segment.StartPoint.X + t * dx, segment.StartPoint.Y + t * dy));
            }
            else if (delta > 0)
            {
                double t1 = ((-B - Math.Sqrt(delta)) / (2 * A));
                double t2 = ((-B + Math.Sqrt(delta)) / (2 * A));
                if (t1 >= 0 && t1 <= 1)
                    intersectsPoints.Add(new RealPoint(segment.StartPoint.X + t1 * dx, segment.StartPoint.Y + t1 * dy));
                if (t2 >= 0 && t2 <= 1)
                    intersectsPoints.Add(new RealPoint(segment.StartPoint.X + t2 * dx, segment.StartPoint.Y + t2 * dy));
            }

            return intersectsPoints;
        }
    }
}
