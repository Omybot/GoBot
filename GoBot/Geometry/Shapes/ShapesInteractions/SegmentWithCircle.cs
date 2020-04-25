using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class SegmentWithCircle
    {
        public static bool Contains(Segment containingSegment, Circle containedCircle)
        {
            // Contenir un cercle revient à avoir un cercle de rayon 0 dont le centre se trouve sur le segment
            return SegmentWithRealPoint.Contains(containingSegment, containedCircle.Center) && containedCircle.Radius == 0;
        }

        public static bool Cross(Segment segment, Circle circle)
        {
            return CircleWithSegment.Cross(circle, segment);
        }

        public static double Distance(Segment segment, Circle circle)
        {
            return CircleWithSegment.Distance(circle, segment);
        }

        public static List<RealPoint> GetCrossingPoints(Segment segment, Circle circle)
        {
            return CircleWithSegment.GetCrossingPoints(circle, segment);
        }
    }
}
