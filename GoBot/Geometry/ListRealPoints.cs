using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry.Shapes
{
    public static class ListRealPointsExtensions
    {
        /// <summary>
        /// Retourne le barycentre des points
        /// </summary>
        /// <param name="pts">Liste des points</param>
        /// <returns>Barycentre des points</returns>
        public static RealPoint GetBarycenter(this IEnumerable<RealPoint> pts)
        {
            return new RealPoint(pts.Average(p => p.X), pts.Average(p => p.Y));
        }

        /// <summary>
        /// Retourne une droite approximant la liste de points par la méthode des moindres carrés
        /// </summary>
        /// <param name="pts">Liste de points à approximer</param>
        /// <returns>Droite estimée</returns>
        public static Line FitLine(this IEnumerable<RealPoint> pts)
        {
            return new Line(pts);
        }

        /// <summary>
        /// Retourne un segment approximant la liste de points par la méthode des moindres carrés
        /// </summary>
        /// <param name="pts">Liste de points à approximer</param>
        /// <returns>Segment estimée</returns>
        public static Segment FitSegment(this IEnumerable<RealPoint> pts)
        {
            Segment res = null;

            if (pts.Count() >= 2)
            {
                Line line = new Line(pts);

                List<RealPoint> projections = pts.Select(o => line.GetProjection(o)).ToList();

                res = new Segment(projections[0], projections[1]);

                for (int i = 2; i < projections.Count; i++)
                {
                    res = res.Join(projections[i]);
                }
            }

            return res;
        }

        /// <summary>
        /// Retourne le plus petit cercle contenant tous les points et dont le centre est le barycentre des points
        /// </summary>
        /// <param name="pts">Liste des points à contenir</param>
        /// <returns>Cercle obtenu</returns>
        public static Circle GetContainingCircle(this IEnumerable<RealPoint> pts)
        {
            RealPoint center = pts.GetBarycenter();
            double ray = pts.Max(p => p.Distance(center));

            return new Circle(center, ray);
        }

        /// <summary>
        /// Retourne la distance entre les deux points les plus éloignés de la liste
        /// </summary>
        /// <param name="pts">Liste de points</param>
        /// <returns>Distance maximale</returns>
        public static double MaxDistance(this IEnumerable<RealPoint> pts)
        {
            return pts.Max(p1 => pts.Max(p2 => p1.Distance(p2)));
        }

        /// <summary>
        /// Retourne la distance entre les deux points les plus proches de la liste
        /// </summary>
        /// <param name="pts">Liste de points</param>
        /// <returns>Distance minimale</returns>
        public static double MinDistance(this IEnumerable<RealPoint> pts)
        {
            return pts.Min(p1 => pts.Min(p2 => p1.Distance(p2)));
        }

        /// <summary>
        /// Regroupe les points en différents groupes suivant leur proximité et une distance maximale de regroupement
        /// </summary>
        /// <param name="pts">Liste de points à regrouper</param>
        /// <param name="maxDistance">Distance maximale pour accrocher un point à un groupe. Représente donc également la distance minimale entre deux groupes.</param>
        /// <returns>Liste des listes de points pour chaque regroupement</returns>
        public static List<List<RealPoint>> GroupByDistance(this IEnumerable<RealPoint> pts, double maxDistance)
        {
            List<RealPoint> pool = new List<RealPoint>(pts);

            List<List<RealPoint>> groups = new List<List<RealPoint>>();

            while (pool.Count > 0)
            {
                List<RealPoint> group = new List<RealPoint>();
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

        /// <summary>
        /// Décalle tous les points dans une certaine direction
        /// </summary>
        /// <param name="pts">Points à décaller</param>
        /// <param name="deltaX">Delta sur l'axe des abscisses</param>
        /// <param name="deltaY">Delta sur l'axe des ordonnées</param>
        public static void Shift(this List<RealPoint> pts, double deltaX, double deltaY)
        {
            pts.ForEach(p => p.Set(p.X + deltaX, p.Y + deltaY));
        }

        /// <summary>
        /// Retourne les points qui sont proches d'une forme
        /// </summary>
        /// <param name="pts">Liste de points</param>
        /// <param name="shape">Forme dont les points doivent être proche</param>
        /// <param name="maxDistance">Distance maximale à la forme pour être sélectionné</param>
        /// <returns></returns>
        public static IEnumerable<RealPoint> GetPointsNearFrom(this IEnumerable<RealPoint> pts, IShape shape, double maxDistance)
        {
            return pts.Where(p => p.Distance(shape) <= maxDistance);
        }

        /// <summary>
        /// Retourne les points contenus dans une forme
        /// </summary>
        /// <param name="pts">Liste de points</param>
        /// <param name="shape">Forme qui doit contenir les points</param>
        /// <returns>Points contenus par la forme</returns>
        public static IEnumerable<RealPoint> GetPointsInside(this List<RealPoint> pts, IShape shape)
        {
            return pts.Where(p => shape.Contains(p));
        }

        /// <summary>
        /// Retourne le cercle correspondant le mieux aux points données.
        /// </summary>
        /// <param name="pts">Points dont on cherche un cercle approchant.</param>
        /// <returns>Cercle calculé</returns>
        public static Circle FitCircle(this List<RealPoint> pts)
        {
            double[,] m1 = new double[pts.Count, 3];
            double[] m2 = new double[pts.Count];
            
            for (int n = 0; n < pts.Count; n++)
            {
                m1[n, 0] = -2f * pts[n].X;
                m1[n, 1] = -2f * pts[n].Y;
                m1[n, 2] = 1;

                m2[n] = -(Math.Pow(pts[n].X, 2) + Math.Pow(pts[n].Y, 2));
            }

            double[,] m3 = Matrix.Transpose(m1);
            double[,] m4 = Matrix.Inverse3x3(Matrix.Multiply(m3, m1));
            double[] m5 = Matrix.Multiply(m3, m2);
            double[] m6 = Matrix.Multiply(m4, m5);

            RealPoint center = new RealPoint(m6[0], m6[1]);
            double radius = Math.Sqrt(Math.Pow(center.X, 2) + Math.Pow(center.Y, 2) - m6[2]);

            return new Circle(center, radius);
        }

        /// <summary>
        /// Retourne un score de correspondance des points à un cercle. (Meilleur score = Meilleure correspondance avec le cercle)
        /// </summary>
        /// <param name="pts">Points</param>
        /// <param name="circle">Cercle avec lequel calculer la correspondance</param>
        /// <returns>Score de correspondance</returns>
        public static double FitCircleScore(this List<RealPoint> pts, Circle circle)
        {
            return 1 - pts.Average(o => Math.Abs(o.Distance(circle.Center) - circle.Radius)) / circle.Radius * pts.Select(o => Math.Atan2(circle.Center.Y - o.Y, circle.Center.X - o.X)).ToList().StandardDeviation();
        }

        /// <summary>
        /// Calcule le facteur de corrélation de la régression linaire des points en une droite.
        /// </summary>
        /// <param name="pts">Points</param>
        /// <returns>Facteur de corrélation (-1 à 1)</returns>
        public static double FitLineCorrelation(this List<RealPoint> pts)
        {
            double varX = pts.Average(o => o.X * o.X) - Math.Pow(pts.Average(o => o.X), 2);
            double varY = pts.Average(o => o.Y * o.Y) - Math.Pow(pts.Average(o => o.Y), 2);
            double covar = pts.Average(o => o.X * o.Y) - pts.Average(o => o.X) * pts.Average(o => o.Y);

            return covar / (Math.Sqrt(varX) * Math.Sqrt(varY));
        }
    }
}