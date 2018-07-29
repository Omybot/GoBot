using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes
{
    internal static class ShapesCrossingPoints
    {
        public static List<RealPoint> CircleAndCircle(Circle circle1, Circle circle2)
        {
            List<RealPoint> output = new List<RealPoint>();

            bool aligned = Math.Abs(circle2.Center.Y - circle1.Center.Y) < RealPoint.PRECISION;

            if (aligned)// Cercles non alignés horizontalement (on pivote pour les calculs, sinon division par 0)
                circle2 = circle2.Rotation(90, circle1.Center);

            RealPoint oc1 = new RealPoint(circle2.Center), oc2 = new RealPoint(circle1.Center);
            double b = circle2.Radius, c = circle1.Radius;

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
                output = output.ConvertAll(p => p.Rotation(-90, circle1.Center));

            return output;
        }

        public static List<RealPoint> CircleAndSegment(Circle circle, Segment segment)
        {
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
            if (delta > 0)
            {
                double t1 = (double)((-B - Math.Sqrt(delta)) / (2 * A));
                double t2 = (double)((-B + Math.Sqrt(delta)) / (2 * A));
                if (t1 >= 0 && t1 <= 1)
                    intersectsPoints.Add(new RealPoint(segment.StartPoint.X + t1 * dx, segment.StartPoint.Y + t1 * dy));
                if (t2 >= 0 && t2 <= 1)
                    intersectsPoints.Add(new RealPoint(segment.StartPoint.X + t2 * dx, segment.StartPoint.Y + t2 * dy));
            }

            return intersectsPoints;
        }
    }
}
