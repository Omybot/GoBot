using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class LineWithPolygon
    {
        public static bool Contains(Line containingLine, Polygon containedPolygon)
        {
            // Contenir un polygone revient à contenir tous les cotés du polygone

            return containedPolygon.Sides.TrueForAll(s => containingLine.Contains(s));
        }

        public static bool Cross(Line line, Polygon polygon)
        {
            // On teste si la ligne croise un des cotés du polygone

            return polygon.Sides.Exists(s => s.Cross(line));
        }
        
        public static double Distance(Line line, Polygon polygon)
        {
            // Distance jusqu'au segment le plus proche

            return polygon.Sides.Min(s => s.Distance(line));
        }

        public static List<RealPoint> GetCrossingPoints(Line line, Polygon polygon)
        {
            // Croisements avec tous les segments du polygone

            return polygon.Sides.SelectMany(s => s.GetCrossingPoints(line)).ToList();
        }
    }
}
