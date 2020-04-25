using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class SegmentWithLine
    {
        public static bool Contains(Segment containingSegment, Line containedLine)
        {
            // Un segment fini ne peut pas contenir une droite infinie.
            return false;
        }

        public static bool Cross(Segment segment, Line line)
        {
            return LineWithSegment.Cross(line, segment);
        }

        public static double Distance(Segment segment, Line line)
        {
            return LineWithSegment.Distance(line, segment);
        }

        public static List<RealPoint> GetCrossingPoints(Segment segment, Line line)
        {
            return LineWithSegment.GetCrossingPoints(line, segment);
        }
    }
}
