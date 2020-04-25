using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class RealPointWithPolygon
    {
        public static bool Contains(RealPoint containingPoint, Polygon containedPolygon)
        {
            return containedPolygon.Points.TrueForAll(p => p == containingPoint);
        }

        public static bool Cross(RealPoint point, Polygon polygon)
        {
            return polygon.Sides.Exists(s => s.Cross(point));
        }

        public static double Distance(RealPoint point, Polygon polygon)
        {
            if (polygon is PolygonRectangle)
            {
                // Plus rapide que la méthode des polygones
                RealPoint topLeft = polygon.Sides[0].StartPoint;
                RealPoint topRight = polygon.Sides[1].StartPoint;
                RealPoint bottomRight = polygon.Sides[2].StartPoint;
                RealPoint bottomLeft = polygon.Sides[3].StartPoint;

                double distance;

                if (point.X < topLeft.X)
                {
                    if (point.Y < topLeft.Y)
                        distance = point.Distance(topLeft);
                    else if (point.Y > bottomRight.Y)
                        distance = point.Distance(bottomLeft);
                    else
                        distance = topLeft.X - point.X;
                }
                else if (point.X > bottomRight.X)
                {
                    if (point.Y < topLeft.Y)
                        distance = point.Distance(topRight);
                    else if (point.Y > bottomRight.Y)
                        distance = point.Distance(bottomRight);
                    else
                        distance = point.X - topRight.X;
                }
                else
                {
                    if (point.Y < topLeft.Y)
                        distance = topLeft.Y - point.Y;
                    else if (point.Y > bottomRight.Y)
                        distance = point.Y - bottomLeft.Y;
                    else
                        distance = 0;
                }

                return distance;
            }

            // Distance jusqu'au segment le plus proche
            double minDistance = double.MaxValue;

            foreach (Segment s in polygon.Sides)
                minDistance = Math.Min(s.Distance(point), minDistance);

            return minDistance;
        }

        public static List<RealPoint> GetCrossingPoints(RealPoint point, Polygon polygon)
        {
            List<RealPoint> output = new List<RealPoint>();

            if (Cross(point, polygon)) 
                output.Add(new RealPoint(point));

            return output;
        }
    }
}
