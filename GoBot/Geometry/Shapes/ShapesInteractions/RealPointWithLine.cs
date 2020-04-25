using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class RealPointWithLine
    {
        public static bool Contains(RealPoint containingPoint, Line containedLine)
        {
            // Un point fini ne peut pas contenir une droite infinie
            return false;
        }

        public static bool Cross(RealPoint point, Line line)
        {
            return LineWithRealPoint.Cross(line, point);
        }

        public static double Distance(RealPoint point, Line line)
        {
            return LineWithRealPoint.Distance(line, point);
        }

        public static List<RealPoint> GetCrossingPoints(RealPoint point, Line line)
        {
            return LineWithRealPoint.GetCrossingPoints(line, point);
        }
    }
}
