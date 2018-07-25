using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Geometry.Shapes
{
    /// <summary>
    /// Droite avec une équation de la forme cy = ax + b
    /// Pour une droite standard, c = 1
    /// Pour une droite verticale, c = 0 et a = 1
    /// </summary>
    public class Line : IShape, IShapeModifiable<Line>
    {
        #region Attributs

        protected double _a, _b, _c;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut y = 0
        /// </summary>
        public Line()
        {
            _a = 0;
            _b = 0;
            _c = 1;
        }

        /// <summary>
        /// Constructeur type cy = ax + b
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <param name="c">C</param>
        public Line(double a, double b, double c = 1)
        {
            this._a = a;
            this._b = b;
            this._c = c;
        }

        /// <summary>
        /// Construit la droite passant par deux points
        /// </summary>
        /// <param name="p1">Premier point</param>
        /// <param name="p2">Deuxième point</param>
        public Line(RealPoint p1, RealPoint p2)
        {
            SetLine(p1, p2);
        }

        /// <summary>
        /// Construit la Droite à partir d'une autre Droite
        /// </summary>
        /// <param name="line">Droite à copier</param>
        public Line(Line line)
        {
            _a = line.A;
            _b = line.B;
            _c = line.C;
        }

        /// <summary>
        /// Contruit la Droite à partir d'une liste de points en interpolation.
        /// Régression linéaire par la méthode des moindres carrés.
        /// </summary>
        /// <param name="points">Liste des points qui génèrent la droite</param>
        public Line(List<RealPoint> points)
        {
            double xAvg, yAvg, sum1, sum2;

            sum1 = 0;
            sum2 = 0;
            xAvg = points.Average(p => p.X);
            yAvg = points.Average(p => p.Y);

            for (int i = 0; i < points.Count; i++)
            {
                sum1 += (points[i].X - xAvg) * (points[i].Y - yAvg);
                sum2 += (points[i].X - xAvg) * (points[i].X - xAvg);
            }

            if (sum2 == 0)
            {
                // Droite verticale
                _a = 0;
                _b = -points[0].X;
                _c = 0;
            }
            else
            {
                _a = sum1 / sum2;
                _b = yAvg - _a * xAvg;
                _c = 1;
            }
        }

        /// <summary>
        /// Calcule l'équation de la droite passant par deux points
        /// </summary>
        /// <param name="p1">Premier point</param>
        /// <param name="p2">Deuxième point</param>
        protected void SetLine(RealPoint p1, RealPoint p2)
        {
            if (p2.X - p1.X == 0)
            {
                _a = 1;
                _b = -p1.X;
                _c = 0;
            }
            else
            {
                _a = (p2.Y - p1.Y) / (p2.X - p1.X);
                _b = -(_a * p1.X - p1.Y);
                _c = 1;
            }
        }

#       endregion

        #region Propriétés

        /// <summary>
        /// Accesseur sur le paramètre A de la droite sous la forme cy = ax + b
        /// </summary>
        public double A
        {
            get
            {
                return _a;
            }
        }

        /// <summary>
        /// Accesseur sur le paramètre B de la droite sous la forme cy = ax + b
        /// </summary>
        public double B
        {
            get
            {
                return _b;
            }
        }

        /// <summary>
        /// Accesseur sur le paramètre C de la droite sous la forme cy = ax + b
        /// </summary>
        public double C
        {
            get
            {
                return _c;
            }
        }

        /// <summary>
        /// Obtient la surface de la droite
        /// </summary>
        public virtual double Surface
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Obtient le barycentre de la droite
        /// </summary>
        public virtual RealPoint Barycenter
        {
            get
            {
                return null; // Ca n'existe pas le barycentre d'une droite
            }
        }

        #endregion

        #region Opérateurs & Surcharges

        public static bool operator ==(Line a, Line b)
        {
            if ((object)a == null || (object)b == null)
                return (object)a == null && (object)b == null;
            else
                return a.A == b.A
                    && a.B == b.B
                    && a.C == a.C;
        }

        public static bool operator !=(Line a, Line b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            Line p = obj as Line;
            if ((Object)p == null)
            {
                return false;
            }

            return (Line)obj == this;
        }

        public override int GetHashCode()
        {
            return (int)_a ^ (int)_b ^ (int)_c;
        }

        /// <summary>
        /// Retourne une chaine contenant l'équation de la Droite
        /// Droite verticale : x = valeur
        /// Droite horizontale : y = valeur
        /// Droite "normale" : y = valeur X + valeur
        /// </summary>
        /// <returns>Chaine représentant la Droite</returns>
        public override string ToString()
        {
            String cString = C != 1 ? C.ToString("0.00") + "" : "";
            String aString = A != 1 ? A.ToString("0.00") + "" : "";
            if (C == 0)
                return "X = " + ((-B).ToString("0.00"));
            else if (A == 0)
                return cString + "Y = " + B.ToString("0.00");
            else if (B == 0)
                return cString + "Y = " + aString + "X";
            else
                return cString + "Y = " + aString + "X " + (B > 0 ? "+ " : "- ") + Math.Abs(B).ToString("0.00");
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimale entre la Droite et la forme donnée
        /// </summary>
        /// <param name="shape">IForme testée</param>
        /// <returns>Distance minimale</returns>
        public double Distance(IShape shape)
        {
            return Distance(Util.ToRealType(shape));
        }

        /// <summary>
        /// Retourne la distance minimale entre la Droite et le Segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Distance minimale</returns>
        protected virtual double Distance(Segment segment)
        {
            // Le segment sait le faire
            return segment.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre la Droite et la Droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Distance minimale</returns>
        protected virtual double Distance(Line line)
        {
            // Si les droites se croisent la distance est de 0
            if (Cross(line))
                return 0;

            // Sinon elles sont parrallèles et la distance entre elles est la distance entre les deux interesections :
            // - D'une perpendiculaire et la première droite
            // - De la même perpendiculaire et la deuxième droite

            Line perpendicular = GetPerpendicular(new RealPoint(0, 0));

            RealPoint p1 = GetCrossingPoints(perpendicular)[0];
            RealPoint p2 = line.GetCrossingPoints(perpendicular)[0];

            return p1.Distance(p2);
        }

        /// <summary>
        /// Retourne la distance minimale entre la droite courante et le cercle donné
        /// </summary>
        /// <param name="circle">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        protected virtual double Distance(Circle circle)
        {
            // Distance jusqu'au centre du cercle - son rayon
            return Distance(circle.Center) - circle.Radius;
        }

        /// <summary>
        /// Retourne la distance minimale entre la droite courante et le polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        protected virtual double Distance(Polygon polygon)
        {
            // Distance jusqu'au segment le plus proche
            double minDistance = double.MaxValue;

            foreach (Segment s in polygon.Sides)
                minDistance = Math.Min(s.Distance(this), minDistance);

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre la droite courante et le point donné
        /// </summary>
        /// <param name="point">Point testé</param>
        /// <returns>Distance minimale</returns>
        protected virtual double Distance(RealPoint point)
        {
            // Pour calculer la distance, on calcule la droite perpendiculaire passant par ce point
            // Puis on calcule l'intersection de la droite et de sa perpendiculaire
            // On obtient la de projection orthogonale du point, qui est le point de la droite le plus proche du point
            // On retourne la distance entre ces deux points

            Line perpendicular = GetPerpendicular(point);
            RealPoint cross = GetCrossingPoints(perpendicular)[0];

            double distance = point.Distance(cross);

            return distance;
        }

        #endregion
        
        #region Contient
        
        /// <summary>
        /// Teste si la droite courante contient la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Vrai si la droite contient la forme donnée</returns>
        public virtual bool Contains(IShape shape)
        {
            return Contains(Util.ToRealType(shape));
        }

        /// <summary>
        /// Teste si la droite courante contient le point donné
        /// </summary>
        /// <param name="point">Point testé</param>
        /// <returns>Vrai si la droite contient le point donné</returns>
        protected virtual bool Contains(RealPoint point)
        {
            // Vérifie si le point est sur la droite en vérifiant sa coordonnée Y pour sa coordonnée X par rapport à l'équation de la droite
            // J'arrondie sinon la précision est trop grande et on rejette des points à cause des arrondis

            double calc1 = point.X * A + B;
            double calc2 = point.Y * C;
            double difference = calc1 > calc2 ? calc1 - calc2 : calc2 - calc1;
            if (difference <= RealPoint.PRECISION)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Teste si la droite courante contient le segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si la droite contient le segment donné</returns>
        protected virtual bool Contains(Segment segment)
        {
            // Contenir un Segment revient à contenir la Droite sur laquelle se trouve le Segment
            return Contains((Line)segment);
        }

        /// <summary>
        /// Teste si la droite courante contient la droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Vrai si la droite contient la droite donnée</returns>
        protected virtual bool Contains(Line line)
        {
            // Contenir une droite revient à avoir la même équation
            if (line == this)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Teste si la droite courante contient le polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Vrai si la droite contient le polygone donné</returns>
        protected virtual bool Contains(Polygon polygon)
        {
            // Contenir un polygone revient à contenir tous les cotés du polygone
            foreach (Segment s in polygon.Sides)
                if (!Contains(s))
                    return false;

            return true;
        }

        /// <summary>
        /// Teste si la droite courante contient le cercle donné
        /// </summary>
        /// <param name="circle">Cercle testé</param>
        /// <returns>Vrai si la droite contient le cercle donné</returns>
        protected virtual bool Contains(Circle circle)
        {
            // Une droite ne peut contenir un Cercle que si son centre est sur la droite et que son rayon est de 0
            return (circle.Radius == 0 && Contains(circle.Center));
        }

        #endregion

        #region Croisement
        
        /// <summary>
        /// Retourne la liste des points de croisement avec la forme donnée
        /// </summary>
        /// <param name="shape">Forme à tester</param>
        /// <returns>Liste des points de croisement</returns>
        public virtual List<RealPoint> GetCrossingPoints(IShape shape)
        {
            List<RealPoint> output = new List<RealPoint>();

            if (shape is Circle) output = GetCrossingPointsWithCircle(shape as Circle);
            else if (shape is Polygon) output = GetCrossingPointsWithPolygon(shape as Polygon);
            else if (shape is Segment) output = GetCrossingPointsWithSegment(shape as Segment);
            else if (shape is RealPoint) output = GetCrossingPointsWithPoint(shape as RealPoint);
            else if (shape is Line) output = GetCrossingPointsWithLine(shape as Line);

            return output;
        }

        private List<RealPoint> GetCrossingPointsWithCircle(Circle circle)
        {
            return circle.GetCrossingPoints(this); //Le cercle sait faire
        }

        private List<RealPoint> GetCrossingPointsWithPolygon(Polygon polygon)
        {
            return polygon.GetCrossingPoints(this); // Le polygone sait faire
        }

        private List<RealPoint> GetCrossingPointsWithSegment(Segment segment)
        {
            List<RealPoint> output = new List<RealPoint>();

            // Vérifie de la même manière qu'une droite mais vérifie ensuite que le point appartient au segment
            output = GetCrossingPointsWithLine(segment);

            if (output.Count > 0 && !segment.Contains(output[0])) output.Clear();

            return output;
        }

        private List<RealPoint> GetCrossingPointsWithPoint(RealPoint point)
        {
            return point.GetCrossingPoints(this); // Le point sait faire
        }

        private List<RealPoint> GetCrossingPointsWithLine(Line line)
        {
            List<RealPoint> output = new List<RealPoint>();

            double x, y;

            if (!(C == 0 && line.C == 0                              // Les deux droites sont verticales
                || A == 0 && line.A == 0                             // Les deux droites sont horizontales
                || (C == 1 && line.C == 1 && A == line.A)))          // Les deux droites sont parallèles
            {

                x = (line.B * C - line.C * B) / (line.C * A - line.A * C);
                y = (line.A * B - line.B * A) / (line.A * C - line.C * A);

                output.Add(new RealPoint(x, y));
            }

            return output;
        }

        /// <summary>
        /// Teste si la droite courante croise la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Vrai si droite croise la forme testée</returns>
        public virtual bool Cross(IShape shape)
        {
            return Cross(Util.ToRealType(shape));
        }

        /// <summary>
        /// Teste si la droite courante croise la droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Vrai si la droite croise la droite donnée</returns>
        protected virtual bool Cross(Line line)
        {
            return GetCrossingPoints(line).Count > 0;
        }

        /// <summary>
        /// Teste si la droite courante croise le segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si la droite croise le segment</returns>
        protected virtual bool Cross(Segment segment)
        {
            return GetCrossingPoints(segment).Count > 0;
        }

        /// <summary>
        /// Teste si la droite courante croise le polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Vrai si la droite croise le polygone</returns>
        protected virtual bool Cross(Polygon polygon)
        {
            // Le polygone sait faire ça
            return polygon.Cross(this);
        }

        /// <summary>
        /// Teste si la droite courante croise le cercle donné
        /// </summary>
        /// <param name="circle">Cercle testé</param>
        /// <returns>Vrai si la droite croise le cercle</returns>
        protected virtual bool Cross(Circle circle)
        {
            // Le cercle sait faire ça
            return circle.Cross(this);
        }

        /// <summary>
        /// Teste si la droite courante croise le point donné
        /// </summary>
        /// <param name="point">Point testé</param>
        /// <returns>Vrai si la droite croise le point</returns>
        protected virtual bool Cross(RealPoint point)
        {
            return Contains(point);
        }

        #endregion

        #region Transformations

        /// <summary>
        /// Retourne une ligne qui est translatée des distances données
        /// </summary>
        /// <param name="dx">Distance en X</param>
        /// <param name="dy">Distance en Y</param>
        /// <returns>Ligne translatée des distances données</returns>
        public Line Translation(double dx, double dy)
        {
            return new Line(_a, _b + dx + dy, _c);
        }

        /// <summary>
        /// Retourne une ligne qui est tournée de l'angle donné
        /// </summary>
        /// <param name="angle">Angle de rotation</param>
        /// <param name="rotationCenter">Centre de rotation, si null (0, 0) est utilisé</param>
        /// <returns>Droite tournée de l'angle donné</returns>
        public Line Rotation(AngleDelta angle, RealPoint rotationCenter = null)
        {
            RealPoint p1, p2;

            if (rotationCenter == null) rotationCenter = Barycenter;

            if (_c == 1)
            {
                p1 = new RealPoint(0, _a * 0 + _b);
                p2 = new RealPoint(1, _a * 1 + _b);

                p1 = p1.Rotation(angle, rotationCenter);
                p2 = p2.Rotation(angle, rotationCenter);
            }
            else
            {
                p1 = new RealPoint(_b, 0);
                p2 = new RealPoint(_b, 1);
            }

            return new Line(p1, p2);
        }

        #endregion
        
        /// <summary>
        /// Retourne l'équation de la droite perpendiculaire à celle-ci et passant par un point donné
        /// </summary>
        /// <param name="point">Point contenu par la perpendiculaire recherchée</param>
        /// <returns>Equation de la droite perpendiculaire à celle-ci et passant par le point donné</returns>
        public Line GetPerpendicular(RealPoint point)
        {
            // Si je suis une droite verticale, je retourne l'horizontale qui passe par le point
            if (C == 0)
                return new Line(0, point.Y);

            // Si je suis une droite horizontale, je retourne la verticale qui passe par le point
            else if (A == 0)
                return new Line(1, -point.X, 0);

            // Si je suis une droite banale, je calcule
            else
            {
                double newA = -1 / _a;
                double newB = -newA * point.X + point.Y;

                return new Line(newA, newB);
            }
        }


        #region Peinture

        /// <summary>
        /// Peint la ligne sur le Graphic donné
        /// Etant donné qu'on a besoin de limites pour peindre, on cherche des croisements assez loin
        /// </summary>
        /// <param name="g">Graphique sur lequel peindre</param>
        /// <param name="outlineColor">Couleur du contour</param>
        /// <param name="outlineWidth">Epaisseur de la ligne</param>
        /// <param name="fillColor">Couleur de remplissage</param>
        /// <param name="scale">Echelle de conversion</param>
        public virtual void Paint(Graphics g, Color outlineColor, int outlineWidth, Color fillColor, WorldScale scale)
        {
            // Un peu douteux mais bon
            RealPoint p1, p2;

            if(Math.Abs(_a) > 1)
            {
                p1 = GetCrossingPoints(new Line(new RealPoint(-100000, -100000), new RealPoint(+100000, -100000))).FirstOrDefault();
                p2 = GetCrossingPoints(new Line(new RealPoint(-100000, +100000), new RealPoint(+100000, +100000))).FirstOrDefault();
            }
            else
            {
                p1 = GetCrossingPoints(new Line(new RealPoint(-100000, -100000), new RealPoint(-100000, +100000))).FirstOrDefault();
                p2 = GetCrossingPoints(new Line(new RealPoint(+100000, -100000), new RealPoint(+100000, +100000))).FirstOrDefault();
            }

            if (p1 != null && p2 != null)
                new Segment(p1, p2).Paint(g, outlineColor, outlineWidth, fillColor, scale);
        }

        #endregion
    }
}
