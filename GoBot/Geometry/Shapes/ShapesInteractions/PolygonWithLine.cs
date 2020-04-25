using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class PolygonWithLine
    {
        public static bool Contains(Polygon containingPolygon, Line containedLine)
        {
            // Un polygon fini ne peut pas contenir une droite infinie.
            return false;
        }

        public static bool Cross(Polygon polygon, Line line)
        {
            return LineWithPolygon.Cross(line, polygon);
        }

        public static double Distance(Polygon polygon, Line line)
        {
            return LineWithPolygon.Distance(line, polygon);
        }

        public static List<RealPoint> GetCrossingPoints(Polygon polygon, Line line)
        {
            return LineWithPolygon.GetCrossingPoints(line, polygon);
        }
    }
}
