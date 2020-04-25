using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class PolygonWithSegment
    {
        public static bool Contains(Polygon containingPolygon, Segment containedSegement)
        {
            // Il suffit de contenir les deux extrémités du segment et de ne jamais croiser le segment
            // À part si le croisement se fait sur une extremité

            bool result;

            if (Cross(containingPolygon, containedSegement))
            {
                // Si ça se croise : ça peut encore être les extremités qui touchent

                List<RealPoint> crossPoints = GetCrossingPoints(containingPolygon, containedSegement);
                if (crossPoints.Count > 2)
                {
                    // Plus de 2 croisements : le segment n'est pas contenu
                    result = false;
                }
                else
                {
                    // Maximum 2 croisements (= les 2 extremités) : le segment est contenu si les 2 extremités et le milieu sont contenus
                    if (PolygonWithRealPoint.Contains(containingPolygon, containedSegement.StartPoint) && PolygonWithRealPoint.Contains(containingPolygon, containedSegement.EndPoint) && PolygonWithRealPoint.Contains(containingPolygon, containedSegement.Barycenter))
                        result = true;
                    else
                        result = false;
                }
            }
            else
            {
                // Pas de croisement, il suffit de contenir un point du segment
                result = PolygonWithRealPoint.Contains(containingPolygon, containedSegement.StartPoint);
            }

            return result;
        }

        public static bool Cross(Polygon polygon, Segment segment)
        {
            return SegmentWithPolygon.Cross(segment, polygon);
        }

        public static double Distance(Polygon polygon, Segment segment)
        {
            return SegmentWithPolygon.Distance(segment, polygon);
        }

        public static List<RealPoint> GetCrossingPoints(Polygon polygon, Segment segment)
        {
            return SegmentWithPolygon.GetCrossingPoints(segment, polygon);
        }
    }
}
