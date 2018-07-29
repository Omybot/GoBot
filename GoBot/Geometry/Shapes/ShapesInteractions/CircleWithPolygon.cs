using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class CircleWithPolygon
    {
        public static bool Contains(Circle circleContaining, Polygon polygonContained)
        {
            // Pour contenir un polygone il suffit de contenir tous ses cotés

            return  polygonContained.Sides.TrueForAll(s => circleContaining.Contains(s));
        }

        public static double Distance(Circle circle, Polygon polygon)
        {
            // Si une des forme contient l'autre ou qu'elles se croisent, la distance est de 0.
            // Sinon c'est la distance minimale à tous les segments.

            double distance;

            if (circle.Cross(polygon) || polygon.Contains(circle) || circle.Contains(polygon))
                distance = 0;
            else
                distance = polygon.Sides.Min(s => s.Distance(circle));
            
            return distance;
        }
        
        public static bool Cross(Circle circle, Polygon polygon)
        {
            // Pour croiser un polygone il suffit de croiser un de ses cotés
            
            return polygon.Sides.Exists(s => circle.Cross(s));
        }
        
        public static List<RealPoint> GetCrossingPoints(Circle circle, Polygon polygon)
        {
            // Croisement du cercle avec tous les segments du polygone

            return polygon.Sides.SelectMany(s => s.GetCrossingPoints(circle)).Distinct().ToList();
        }
    }
}
