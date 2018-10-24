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
        public static Line FitLine(this List<RealPoint> pts)
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

        public static Circle FitCircle(this List<RealPoint> pts)
        {
            double[][] m1 = new double[pts.Count][];

            for (int n = 0; n < m1.Length; n++)
            {
                m1[n] = new double[] { -2f * pts[n].X, -2f * pts[n].Y, 1 };
            }

            double[] m2 = new double[pts.Count];

            for (int n = 0; n < m1.Length; n++)
            {
                m2[n] = -(Math.Pow(pts[n].X, 2) + Math.Pow(pts[n].Y, 2));
            }

            double[][] m3 = Transpose(m1);
            double[][] m4 = Inverse3x3(Multiply(m3, m1));
            double[] m5 = Multiply(m3, m2);
            double[] m6 = Multiply(m4, m5);

            //Results:

            RealPoint center = new RealPoint(m6[0], m6[1]);
            double radius = Math.Sqrt(Math.Pow(center.X, 2) + Math.Pow(center.Y, 2) - m6[2]);

            return new Circle(center, radius);
        }

        public static double FitCircleScore(this List<RealPoint> pts, Circle circle)
        {
            return 1 - pts.Average(o => Math.Abs(o.Distance(circle.Center) - circle.Radius)) / circle.Radius;
        }

        public static double FitLineCorrelation(this List<RealPoint> pts)
        {
            double varX = pts.Average(o => o.X * o.X) - Math.Pow(pts.Average(o => o.X), 2);
            double varY = pts.Average(o => o.Y * o.Y) - Math.Pow(pts.Average(o => o.Y), 2);
            double covar = pts.Average(o => o.X * o.Y) - pts.Average(o => o.X) * pts.Average(o => o.Y);

            return covar / (Math.Sqrt(varX) * Math.Sqrt(varY));
        }

        static double[][] Inverse3x3(double[][] m)
        {
            double d = (1 / Determinant3x3(m));

            return new double[3][] {
            new double[] {
                +Determinant2x2(m[1][1], m[1][2], m[2][1], m[2][2]) * d,//[0][0]
				-Determinant2x2(m[0][1], m[0][2], m[2][1], m[2][2]) * d,//[1][0]
				+Determinant2x2(m[0][1], m[0][2], m[1][1], m[1][2]) * d,//[2][0]
			},
            new double[] {
                -Determinant2x2(m[1][0], m[1][2], m[2][0], m[2][2]) * d,//[0][1]
				+Determinant2x2(m[0][0], m[0][2], m[2][0], m[2][2]) * d,//[1][1]
				-Determinant2x2(m[0][0], m[0][2], m[1][0], m[1][2]) * d,//[2][1]
			},
            new double[] {
                +Determinant2x2(m[1][0], m[1][1], m[2][0], m[2][1]) * d,//[0][2]
				-Determinant2x2(m[0][0], m[0][1], m[2][0], m[2][1]) * d,//[1][2]
				+Determinant2x2(m[0][0], m[0][1], m[1][0], m[1][1]) * d,//[2][2]
			}
        };
        }

        static double Determinant3x3(double[][] m)
        {
            var a = m[0][0] * Determinant2x2(m[1][1], m[1][2], m[2][1], m[2][2]);
            var b = m[0][1] * Determinant2x2(m[1][0], m[1][2], m[2][0], m[2][2]);
            var c = m[0][2] * Determinant2x2(m[1][0], m[1][1], m[2][0], m[2][1]);
            return a - b + c;
        }

        static double Determinant2x2(double m00, double m01, double m10, double m11)
        {
            return ((m00 * m11) - (m10 * m01));
        }

        static double Determinant2x2(double[][] m)
        {
            return Determinant2x2(m[0][0], m[0][1], m[1][0], m[1][1]);
        }

        static double[] Multiply(double[][] m1, double[] m2)
        {
            double[] res = new double[m1.Length];

            for (int iRow = 0; iRow < m1.Length; iRow++)
                for (int iCol = 0; iCol < m2.Length; iCol++)
                    res[iRow] += m1[iRow][iCol] * m2[iCol];

            return res;
        }

        static double[][] Multiply(double[][] m1, double[][] m2)
        {
            double[][] res = new double[m1.Length][];
            for (int iRow = 0; iRow < m1.Length; iRow++)
            {
                res[iRow] = new double[m1.Length];
                for (int iCol2 = 0; iCol2 < m2[0].Length; iCol2++)
                {
                    for (int iCol1 = 0; iCol1 < m1[iRow].Length; iCol1++)
                    {
                        res[iRow][iCol2] += m1[iRow][iCol1] * m2[iCol1][iCol2];
                    }
                }
            }
            return res;
        }

        static T[][] Transpose<T>(T[][] source)
        {
            int rowsCount = source[0].Length;
            int colsCOunt = source.Length;

            var target = new T[rowsCount][];
            for (int row = 0; row < rowsCount; ++row)
            {
                target[row] = new T[colsCOunt];
            }

            for (int row = 0; row < source.Length; ++row)
            {
                for (int col = 0; col < source[row].Length; ++col)
                    target[col][row] = source[row][col];
            };

            return target;
        }
    }
}