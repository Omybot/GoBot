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
        public static RealPoint GetBarycenter(this List<RealPoint> pts)
        {
            return new RealPoint(pts.Average(p => p.X), pts.Average(p => p.Y));
        }

        /// <summary>
        /// Retourne la liste des points contenus dans la forme
        /// </summary>
        /// <param name="pts">Liste des points d'origine</param>
        /// <param name="shape">Forme qui doit contenir les points</param>
        /// <returns>Points contenus par la forme</returns>
        public static List<RealPoint> GetPointsIn(this List<RealPoint> pts, IShape shape)
        {
            return pts.Where(p => shape.Contains(p)).ToList();
        }

        /// <summary>
        /// Retourne une droite approximant la liste de points par la méthode des moindres carrés
        /// </summary>
        /// <param name="pts">Liste de points à approximer</param>
        /// <returns>Droite estimée</returns>
        public static Line ToLine(this List<RealPoint> pts)
        {
            return new Line(pts);
        }

        /// <summary>
        /// Retourne le plus petit cercle contenant tous les points et dont le centre est le barycentre des points
        /// </summary>
        /// <param name="pts">Liste des points à contenir</param>
        /// <returns>Cercle obtenu</returns>
        public static Circle GetContainingCircle(this List<RealPoint> pts)
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
        public static double MaxDistance(this List<RealPoint> pts)
        {
            return pts.Max(p1 => pts.Max(p2 => p1.Distance(p2)));
        }

        /// <summary>
        /// Retourne la distance entre les deux points les plus proches de la liste
        /// </summary>
        /// <param name="pts">Liste de points</param>
        /// <returns>Distance minimale</returns>
        public static double MinDistance(this List<RealPoint> pts)
        {
            return pts.Min(p1 => pts.Min(p2 => p1.Distance(p2)));
        }

        /// <summary>
        /// Regroupe les points en différents groupes suivant leur proximité et une distance maximale de regroupement
        /// </summary>
        /// <param name="pts">Liste de points à regrouper</param>
        /// <param name="maxDistance">Distance maximale pour accrocher un point à un groupe. Représente donc également la distance minimale entre deux groupes.</param>
        /// <returns>Liste des listes de points pour chaque regroupement</returns>
        public static List<List<RealPoint>> GroupByDistance(this List<RealPoint> pts, double maxDistance)
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
        public static List<RealPoint> GetPointsNearFrom(this List<RealPoint> pts, IShape shape, double maxDistance)
        {
            return pts.Where(p => p.Distance(shape) <= maxDistance).ToList();
        }

        /// <summary>
        /// Retourne les points contenus dans une forme
        /// </summary>
        /// <param name="pts">Liste de points</param>
        /// <param name="shape">Forme qui doit contenir les points</param>
        /// <returns>Points contenus par la forme</returns>
        public static List<RealPoint> GetPointsInside(this List<RealPoint> pts, IShape shape)
        {
            return pts.Where(p => shape.Contains(p)).ToList();
        }
    }
}