using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class SegmentWithRealPoint
    {
        public static bool Contains(Segment containingSegment, RealPoint containedPoint)
        {
            // Vérifie que le point est situé sur la droite
            if (!LineWithRealPoint.Contains((Line)containingSegment, containedPoint))
                return false;
            // Puis qu'il est entre les deux extrémités

            if (containedPoint.X - RealPoint.PRECISION > Math.Max(containingSegment.StartPoint.X, containingSegment.EndPoint.X) ||
                containedPoint.X + RealPoint.PRECISION < Math.Min(containingSegment.StartPoint.X, containingSegment.EndPoint.X) ||
                containedPoint.Y - RealPoint.PRECISION > Math.Max(containingSegment.StartPoint.Y, containingSegment.EndPoint.Y) ||
                containedPoint.Y + RealPoint.PRECISION < Math.Min(containingSegment.StartPoint.Y, containingSegment.EndPoint.Y))
                return false;

            return true;
        }

        public static bool Cross(Segment segment, RealPoint point)
        {
            return Contains(segment, point);
        }

        public static double Distance(Segment segment, RealPoint point)
        {            
            // Le raisonnement est le même que pour la droite cf Droite.Distance

            Line perpendicular = segment.GetPerpendicular(point);
            List<RealPoint> cross = segment.GetCrossingPoints(perpendicular);

            double distance;

            // Seule différence : on teste si l'intersection appartient bien au segment, sinon on retourne la distance avec l'extrémité la plus proche
            if (cross.Count > 0 && segment.Contains(cross[0]))
            {
                distance = point.Distance(cross[0]);
            }
            else
            {
                double distanceDebut = point.Distance(segment.StartPoint);
                double distanceFin = point.Distance(segment.EndPoint);

                distance = Math.Min(distanceDebut, distanceFin);
            }

            return distance;
        }

        public static List<RealPoint> GetCrossingPoints(Segment segment, RealPoint point)
        {
            List<RealPoint> output = new List<RealPoint>();

            if (segment.Contains(point)) output.Add(new RealPoint(point));

            return output;
        }
    }
}
