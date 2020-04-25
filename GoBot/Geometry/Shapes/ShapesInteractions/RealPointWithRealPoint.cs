using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class RealPointWithRealPoint
    {
        public static bool Contains(RealPoint containingPoint, RealPoint containedPoint)
        {
            return containingPoint == containedPoint;
        }

        public static bool Cross(RealPoint point1, RealPoint point2)
        {
            return point1 == point2;
        }

        public static double Distance(RealPoint point1, RealPoint point2)
        {
            return Maths.Hypothenuse((point2.X - point1.X), (point2.Y - point1.Y)); ;
        }

        public static List<RealPoint> GetCrossingPoints(RealPoint point1, RealPoint point2)
        {
            List<RealPoint> output = new List<RealPoint>();

            if (point1 == point2)
                output.Add(new RealPoint(point1));

            return output;
        }
    }
}
