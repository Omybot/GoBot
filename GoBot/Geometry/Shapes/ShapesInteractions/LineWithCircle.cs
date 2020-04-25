using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    public static class LineWithCircle
    {
        public static bool Contains(Line containingLine, Circle containedCircle)
        {
            // Une droite contient un cercle si son rayon est nul et qu'il est sur la droite

            return containedCircle.Radius == 0 && containingLine.Contains(containedCircle.Center);
        }

        public static bool Cross(Line line, Circle circle)
        {
            return CircleWithLine.Cross(circle, line);
        }

        public static double Distance(Line line, Circle circle)
        {
            return CircleWithLine.Distance(circle, line);
        }

        public static List<RealPoint> GetCrossingPoints(Line line, Circle circle)
        {
            return CircleWithLine.GetCrossingPoints(circle, line);
        }
    }
}
