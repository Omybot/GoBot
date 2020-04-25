using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class SegmentWithPolygon
    {    
        public static bool Contains(Segment containingSegment, Polygon containedPolygon)
        {            
            // Contenir un polygone dans un segment revient à contenir tous les points du polygone
            return containedPolygon.Points.TrueForAll(p => SegmentWithRealPoint.Contains(containingSegment, p));
        }

        public static bool Cross(Segment segment, Polygon polygon)
        {
            return polygon.Sides.Exists(s => SegmentWithSegment.Cross(s, segment));
        }

        public static double Distance(Segment segment, Polygon polygon)
        {
            return polygon.Sides.Min(s => SegmentWithSegment.Distance(s, segment));
        }

        public static List<RealPoint> GetCrossingPoints(Segment segment, Polygon polygon)
        {
            return polygon.Sides.SelectMany(s => SegmentWithSegment.GetCrossingPoints(s, segment)).ToList();
        }
    }
}
