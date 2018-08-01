using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class LineWithRealPoint
    {
        public static bool Contains(Line containingLine, RealPoint containedPoint)
        {
            bool output;

            if (containingLine.IsHorizontal)
                output = containedPoint.Y == containingLine.B;
            else if (containingLine.IsVertical)
                output = containedPoint.X == -containingLine.B;
            else
            {
                // Vérifie si le point est sur la droite en vérifiant sa coordonnée Y pour sa coordonnée X par rapport à l'équation de la droite

                double expectedY = containingLine.A * containedPoint.X + containingLine.B;
                output = Math.Abs(expectedY - containedPoint.Y) <= RealPoint.PRECISION;
            }

            return output;
        }

        public static bool Cross(Line line, RealPoint point)
        {
            // Pour qu'une droite croise un point c'est qu'elle contient le point...

            return Contains(line, point);
        }

        public static double Distance(Line line, RealPoint point)
        {
            // Pour calculer la distance, on calcule la droite perpendiculaire passant par ce point
            // Puis on calcule l'intersection de la droite et de sa perpendiculaire
            // On obtient la projection orthogonale du point, qui est le point de la droite le plus proche du point donné
            // On retourne la distance entre ces deux points

            Line perpendicular = line.GetPerpendicular(point);
            RealPoint cross = line.GetCrossingPoints(perpendicular)[0];

            return point.Distance(cross);
        }


        public static List<RealPoint> GetCrossingPoints(Line line, RealPoint point)
        {
            // Si la droite contient le point, son seul croisement c'est le point lui même...

            List<RealPoint> output = new List<RealPoint>();

            if (line.Contains(point)) 
                output.Add(new RealPoint(point));

            return output;
        }
    }
}
