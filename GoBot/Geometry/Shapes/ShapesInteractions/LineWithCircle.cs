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
    }
}
