using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class SegmentWithSegment
    {

        public static bool Contains(Segment containingSegment, Segment containedSegment)
        {
            // Il suffit de vérifier que le segment contient les deux extrémités
            return SegmentWithRealPoint.Contains(containingSegment, containedSegment.StartPoint) && SegmentWithRealPoint.Contains(containingSegment, containedSegment.EndPoint);
        }

        public static bool Cross(Segment segment1, Segment segment2)
        {
            return GetCrossingPoints(segment1, segment2).Count > 0;
        }

        public static double Distance(Segment segment1, Segment segment2)
        {
            // Si les segments se croisent la distance est de 0
            if (Cross(segment1, segment2))
                return 0;

            // Sinon c'est la distance minimale entre (chaque extremité d'un segment) et (l'autre segment)
            double minDistance = double.MaxValue;

            // Le minimal est peut être entre les extremités
            minDistance = Math.Min(minDistance, segment1.StartPoint.Distance(segment2.StartPoint));
            minDistance = Math.Min(minDistance, segment1.StartPoint.Distance(segment2.EndPoint));
            minDistance = Math.Min(minDistance, segment1.EndPoint.Distance(segment2.StartPoint));
            minDistance = Math.Min(minDistance, segment1.EndPoint.Distance(segment2.EndPoint));

            // Le minimal est peut etre entre une extremité et son projeté hortogonal sur l'autre segment
            Line perpendicular = segment1.GetPerpendicular(segment2.StartPoint);
            List<RealPoint> cross = segment1.GetCrossingPoints(perpendicular);
            if (cross.Count > 0) minDistance = Math.Min(minDistance, cross[0].Distance(segment2.StartPoint));

            perpendicular = segment1.GetPerpendicular(segment2.EndPoint);
            cross = segment1.GetCrossingPoints(perpendicular);
            if (cross.Count > 0) minDistance = Math.Min(minDistance, cross[0].Distance(segment2.EndPoint));

            perpendicular = segment2.GetPerpendicular(segment1.StartPoint);
            cross = segment2.GetCrossingPoints(perpendicular);
            if (cross.Count > 0) minDistance = Math.Min(minDistance, cross[0].Distance(segment1.StartPoint));

            perpendicular = segment2.GetPerpendicular(segment1.EndPoint);
            cross = segment2.GetCrossingPoints(perpendicular);
            if (cross.Count > 0) minDistance = Math.Min(minDistance, cross[0].Distance(segment1.EndPoint));

            return minDistance;
        }

        public static List<RealPoint> GetCrossingPoints(Segment segment1, Segment segment2)
        {
            List<RealPoint> output = new List<RealPoint>();

            double x1, x2, x3, x4, y1, y2, y3, y4;

            x1 = segment1.StartPoint.X;
            x2 = segment1.EndPoint.X;
            x3 = segment2.StartPoint.X;
            x4 = segment2.EndPoint.X;

            y1 = segment1.StartPoint.Y;
            y2 = segment1.EndPoint.Y;
            y3 = segment2.StartPoint.Y;
            y4 = segment2.EndPoint.Y;

            double den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            if (den != 0)
            {
                double t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
                double u = -((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / den;

                if (t > 0 && t < 1 && u > 0 && u < 1)
                {
                    output.Add(new RealPoint(x1 + t * (x2 - x1), y1 + t * (y2 - y1)));
                }
            }

            return output;
        }
    }
}
