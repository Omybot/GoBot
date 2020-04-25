using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class PolygonWithPolygon
    {
        public static bool Contains(Polygon containingPolygon, Polygon containedPolygon)
        {            
            // Il suffit de contenir tous les segments du polygone testé
            return containedPolygon.Sides.TrueForAll(s => PolygonWithSegment.Contains(containingPolygon, s));
        }

        public static bool Cross(Polygon polygon1, Polygon polygon2)
        {
            // Si un des segments du premier polygone croise le second

            return polygon1.Sides.Exists(s => SegmentWithPolygon.Cross(s, polygon2));
        }

        public static double Distance(Polygon polygon1, Polygon polygon2)
        {
            double minDistance = 0;

            // Si les polygones se croisent ou se contiennent, la distance est nulle
            if (!PolygonWithPolygon.Cross(polygon1, polygon2) && !PolygonWithPolygon.Contains(polygon1, polygon2) && !PolygonWithPolygon.Contains(polygon2, polygon1))
            {
                minDistance = double.MaxValue;

                foreach (Segment s1 in polygon1.Sides)
                    foreach (Segment s2 in polygon2.Sides)
                        minDistance = Math.Min(minDistance, s1.Distance(s2));
            }

            return minDistance;
        }

        public static List<RealPoint> GetCrossingPoints(Polygon polygon1, Polygon polygon2)
        {
            // Croisement des segments du premier polygone avec le second

            return polygon1.Sides.SelectMany(s => SegmentWithPolygon.GetCrossingPoints(s, polygon2)).ToList();
        }
    }
}
