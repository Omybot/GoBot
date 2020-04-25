using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class RealPointWithCircle
    {
        public static bool Contains(RealPoint containingPoint, Circle containedCircle)
        {
            return containedCircle.Center == containingPoint && containedCircle.Radius == 0;
        }

        public static bool Cross(RealPoint point, Circle circle)
        {
            return CircleWithRealPoint.Cross(circle, point);
        }

        public static double Distance(RealPoint point, Circle circle)
        {
            return CircleWithRealPoint.Distance(circle, point);
        }

        public static List<RealPoint> GetCrossingPoints(RealPoint point, Circle circle)
        {
            return CircleWithRealPoint.GetCrossingPoints(circle, point);
        }
    }
}
