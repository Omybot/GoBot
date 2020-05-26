using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    public static class CircleWithRealPoint
    {
        public static bool Contains(Circle containingCircle, RealPoint containedPoint)
        {
            // Pour contenir un point, celui si se trouve à une distance inférieure au rayon du centre

            return containedPoint.Distance(containingCircle.Center) <= containingCircle.Radius;
        }

        public static double Distance(Circle circle, RealPoint point)
        {
            // C'est la distance entre le centre du cercle et le point moins le rayon du cercle

            return Math.Max(0, point.Distance(circle.Center) - circle.Radius);
        }

        public static bool Cross(Circle circle, RealPoint point)
        {
            // Pour qu'un cercle croise un point en c'est que le point est sur son contour donc à une distance égale au rayon de son centre.

            return Math.Abs(circle.Center.Distance(point) - circle.Radius) < RealPoint.PRECISION;
        }
        
        public static List<RealPoint> GetCrossingPoints(Circle circle, RealPoint point)
        {
            // Le seul point de croisement d'un point et d'un cercle, c'est le point lui même si il croise le cercle.
            
            return circle.Cross(point) ? new List<RealPoint>(){ new RealPoint(point) } : new List<RealPoint>();
        }
    }
}
