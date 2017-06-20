using System.Collections.Generic;
using System.Linq;

namespace GoBot.Calculs.Formes
{
    internal static class ListRealPointsExtensions
    {
        public static PointReel AveragePoint(this List<PointReel> pts)
        {
            return new PointReel(pts.Average(p => p.X), pts.Average(p => p.Y));
        }

        public static List<PointReel> GetPointsIn(this List<PointReel> pts, IForme shape)
        {
            return pts.Where(p => shape.Contient(p)).ToList();
        }

        public static Droite ToLine(this List<PointReel> pts)
        {
            return new Droite(pts);
        }

        public static Cercle GetContainingCircle(this List<PointReel> pts)
        {
            PointReel center = pts.AveragePoint();
            double ray = pts.Max(p => p.Distance(center));

            return new Cercle(center, ray);
        }

        public static double MaxDistance(this List<PointReel> pts)
        {
            return pts.Max(p1 => pts.Max(p2 => p1.Distance(p2)));
        }

        public static double MinDistance(this List<PointReel> pts)
        {
            return pts.Min(p1 => pts.Min(p2 => p1.Distance(p2)));
        }

        public static List<List<PointReel>> GroupByDistance(this List<PointReel> pts, double maxDistance)
        {
            List<PointReel> pool = new List<PointReel>(pts);

            List<List<PointReel>> groups = new List<List<PointReel>>();

            while (pool.Count > 0)
            {
                List<PointReel> group = new List<PointReel>();
                groups.Add(group);
                group.Add(pool[0]);
                pool.RemoveAt(0);

                for (int i = 0; i < group.Count; i++)
                {
                    group.AddRange(pool.Where(p => p.Distance(group[i]) < maxDistance).ToList());
                    pool.RemoveAll(p => p.Distance(group[i]) < maxDistance);
                }
            }

            return groups;
        }

        public static void Shift(this List<PointReel> pts, double deltaX, double deltaY)
        {
            pts.ForEach(p => p.Placer(p.X + deltaX, p.Y + deltaY));
        }

        public static List<PointReel> GetPointsNearFrom(this List<PointReel> pts, IForme shape, double maxDistance)
        {
            return pts.Where(p => p.Distance(shape) <= maxDistance).ToList();
        }

        public static List<PointReel> GetPointsInside(this List<PointReel> pts, IForme shape)
        {
            return pts.Where(p => shape.Contient(p)).ToList();
        }
    }
}