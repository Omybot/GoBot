using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class PolygonWithCircle
    {
        public static bool Contains(Polygon containingPolygon, Circle containedCircle)
        {
            // Pour contenir un cercle, un polygone ne doit pas être contenu par le cercle, ne pas le croiser et contenir son centre
            return !CircleWithPolygon.Contains(containedCircle, containingPolygon) && !PolygonWithCircle.Cross(containingPolygon, containedCircle) && PolygonWithRealPoint.Contains(containingPolygon, containedCircle.Center);
        }

        public static bool Cross(Polygon polygon, Circle circle)
        {
            return CircleWithPolygon.Cross(circle, polygon);
        }

        public static double Distance(Polygon polygon, Circle circle)
        {
            return CircleWithPolygon.Distance(circle, polygon);
        }

        public static List<RealPoint> GetCrossingPoints(Polygon polygon, Circle circle)
        {
            return CircleWithPolygon.GetCrossingPoints(circle, polygon);
        }
    }
}
