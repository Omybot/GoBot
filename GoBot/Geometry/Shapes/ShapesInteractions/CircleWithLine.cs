using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    public static class CircleWithLine
    {
        public static bool Contains(Circle containingCircle, Line containedLine)
        {
            // Un cercle ne peut pas contenir une droite...

            return false;
        }

        public static double Distance(Circle circle, Line line)
        {
            // Distance de la ligne jusqu'au centre du cercle - son rayon (Si négatif c'est que ça croise, donc distance 0)

            return Math.Max(0, line.Distance(circle.Center) - circle.Radius);
        }

        public static bool Cross(Circle circle, Line line)
        {
            // Si une droite croise le cercle, c'est que le point de la droite le plus proche du centre du cercle est éloigné d'une distance inférieure au rayon
            
            return line.Distance(circle.Center) <= circle.Radius;
        }

        public static List<RealPoint> GetCrossingPoints(Circle circle, Line line)
        {
            // TODO

            return new List<RealPoint>();
        }
    }
}
