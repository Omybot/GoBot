using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class LineWithSegment
    {
        public static bool Contains(Line containingLine, Segment containedSegment)
        {
            // Contenir un segment revient à contenir la droite sur laquelle se trouve le segment

            return LineWithLine.Contains(containingLine, containedSegment);
        }
        
        public static bool Cross(Line line, Segment segment)
        {
            // Pas trouvé plus simple

            return GetCrossingPoints(line, segment).Count > 0;
        }

        public static double Distance(Line line, Segment segment)
        {
            double output;

            if (Cross(line, segment))
            {
                // Si la droite et le segment se croisent la distance est de 0
                output = 0;
            }
            else
            {
                // Sinon c'est la distance minimale entre chaque extremité du segment et la droite puisque c'est forcément un de ces deux points le plus proche
                output = Math.Min(line.Distance(segment.StartPoint), line.Distance(segment.EndPoint));
            }

            return output;
        }

        public static List<RealPoint> GetCrossingPoints(Line line, Segment segment)
        {
            List<RealPoint> output = new List<RealPoint>();

            // Vérifie de la même manière qu'une droite mais vérifie ensuite que le point obtenu (s'il existe) appartient bien au segment
            output = LineWithLine.GetCrossingPoints(line, segment);

            if (output.Count > 0 && !segment.Contains(output[0]))
                output.Clear();

            return output;
        }
    }
}
