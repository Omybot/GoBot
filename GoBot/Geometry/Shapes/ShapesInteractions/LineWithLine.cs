using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    public static class LineWithLine
    {
        public static bool Contains(Line containingLine, Line containedLine)
        {
            // Contenir une droite revient à avoir la même équation

            return (containingLine == containedLine);
        }

        public static bool Cross(Line line1, Line line2)
        {
            // Deux droites se croisent forcément si elles n'ont pas la même pente ou qu'elles sont toutes les deux verticales

            return !line1.IsParallel(line2);
        }
        
        public static double Distance(Line line1, Line line2)
        {
            double distance;

            if (!line1.IsParallel(line2))
            {
                // Si les droites se croisent la distance est de 0
                distance = 0;
            }
            else
            {
                // Sinon elles sont parrallèles donc on trace une perdendiculaire et une mesure la distance entre les croisements avec les 2 droites

                Line perpendicular = line1.GetPerpendicular(new RealPoint(0, 0));

                RealPoint p1 = line1.GetCrossingPoints(perpendicular)[0];
                RealPoint p2 = line2.GetCrossingPoints(perpendicular)[0];

                distance = p1.Distance(p2);
            }

            return distance;
        }

        public static List<RealPoint> GetCrossingPoints(Line line1, Line line2)
        {
            List<RealPoint> output = new List<RealPoint>();
            
            if (!line1.IsParallel(line2))
            {
                // Résolution de l'équation line1 = line2

                output.Add(new RealPoint
                {
                    X = (line2.B * line1.C - line2.C * line1.B) / (line2.C * line1.A - line2.A * line1.C),
                    Y = (line2.A * line1.B - line2.B * line1.A) / (line2.A * line1.C - line2.C * line1.A),
                });
            }

            return output;
        }
    }
}
