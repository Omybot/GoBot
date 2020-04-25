using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class RealPointWithSegment
    {
        public static bool Contains(RealPoint containingPoint, Segment containedSegment)
        {
            // Un point qui contient un segment c'est que les deux extremités du segment sont ce même point...
            return (containingPoint == containedSegment.StartPoint) && (containingPoint == containedSegment.EndPoint);
        }

        public static bool Cross(RealPoint point, Segment segment)
        {
            return SegmentWithRealPoint.Cross(segment, point);
        }

        public static double Distance(RealPoint point, Segment segment)
        {
            return SegmentWithRealPoint.Distance(segment, point);
        }

        public static List<RealPoint> GetCrossingPoints(RealPoint point, Segment segment)
        {
            return SegmentWithRealPoint.GetCrossingPoints(segment, point);
        }
    }
}
