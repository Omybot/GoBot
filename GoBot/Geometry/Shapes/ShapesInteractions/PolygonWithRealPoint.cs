using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Shapes.ShapesInteractions
{
    internal static class PolygonWithRealPoint
    {
        public static bool Contains(Polygon containingPolygon, RealPoint containedPoint)
        {
            if(containingPolygon is PolygonRectangle)
            {
                // Plus rapide que la méthode des polygones
                return containedPoint.X >= containingPolygon.Points[0].X && containedPoint.X <= containingPolygon.Points[2].X && containedPoint.Y >= containingPolygon.Points[0].Y && containedPoint.Y <= containingPolygon.Points[2].Y;
            }

            // Pour savoir si le Polygone contient un point on trace un segment entre ce point et un point très éloigné
            // On compte combien de cotés du polygone croisent cette droite
            // Si ce nombre est impaire alors le point est contenu dans le polygone

            int crossCount = 0;
            Segment testSeg = new Segment(containedPoint, new RealPoint(containingPolygon.Sides.Min(o => o.StartPoint.X) - 10000, containedPoint.Y));

            foreach (Segment s in containingPolygon.Sides)
            {
                if (s.Contains(containedPoint))
                    return true;

                if (s.Cross(testSeg))
                {
                    List<RealPoint> cross = testSeg.GetCrossingPoints(s);
                    if (cross.Count > 0 && cross[0] != s.EndPoint) // Pour ne pas compter 2 fois un croisement sur un sommet, il sera déjà compté sur le Begin d'un autre
                        crossCount++;
                }
            }

            crossCount -= containingPolygon.Sides.Count(o => Math.Abs(o.StartPoint.Y - containedPoint.Y) < RealPoint.PRECISION);

            return (crossCount % 2 == 1);
        }

        public static bool Cross(Polygon polygon, RealPoint point)
        {
            return RealPointWithPolygon.Cross(point, polygon);
        }

        public static double Distance(Polygon polygon, RealPoint point)
        {
            return RealPointWithPolygon.Distance(point, polygon);
        }

        public static List<RealPoint> GetCrossingPoints(Polygon polygon, RealPoint point)
        {
            return RealPointWithPolygon.GetCrossingPoints(point, polygon);
        }
    }
}
