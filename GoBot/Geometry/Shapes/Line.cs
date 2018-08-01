using Geometry.Shapes.ShapesInteractions;
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
        /// Retourne vrai si la droite est parrallèle à l'axe des abscisses.
        /// Dans ce cas l'équation donne Y = B
        /// </summary>
        public bool IsHorizontal
        {
            get
            {
                return _a == 0;
            }
        }

        /// <summary>
        /// Retourne vrai si la droite est parallèle à l'axe des ordonnées.
        /// Dans ce cas l'équation donne X = -B
        /// </summary>
        public bool IsVertical
        {
            get
            {
                return _c == 0;
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
                return Math.Abs(a.A - b.A) < RealPoint.PRECISION
                    && Math.Abs(a.B - b.B) < RealPoint.PRECISION
                    && Math.Abs(a.C - a.C) < RealPoint.PRECISION;
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
            String output;

            String cString = C != 1 ? C.ToString("0.00") : "";
            String aString = A != 1 ? A.ToString("0.00") : "";

            if (this.IsVertical)
                output = "X = " + ((-B).ToString("0.00"));
            else if (this.IsHorizontal)
                output = cString + "Y = " + B.ToString("0.00");
            else if (B == 0)
                output = cString + "Y = " + aString + "X";
            else
                output = cString + "Y = " + aString + "X " + (B > 0 ? "+ " : "- ") + Math.Abs(B).ToString("0.00");

            return output;
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimale entre la Droite et la forme donnée
        /// </summary>
        /// <param name="shape">IForme testée</param>
        /// <returns>Distance minimale</returns>
        public virtual double Distance(IShape shape)
        {
            double output = 0;

            if (shape is Circle) output = CircleWithLine.Distance(shape as Circle, this);
            else if (shape is Polygon) output = LineWithPolygon.Distance(this, shape as Polygon);
            else if (shape is Segment) output = LineWithSegment.Distance(this, shape as Segment);
            else if (shape is RealPoint) output = LineWithRealPoint.Distance(this, shape as RealPoint);
            else if (shape is Line) output = LineWithLine.Distance(this, shape as Line);

            return output;
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
            bool output = false;

            if (shape is Circle) output = CircleWithLine.Contains(shape as Circle, this);
            else if (shape is Polygon) output = LineWithPolygon.Contains(this, shape as Polygon);
            else if (shape is Segment) output = LineWithSegment.Contains(this, shape as Segment);
            else if (shape is RealPoint) output = LineWithRealPoint.Contains(this, shape as RealPoint);
            else if (shape is Line) output = LineWithLine.Contains(this, shape as Line);

            return output;
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

            if (shape is Circle) output = CircleWithLine.GetCrossingPoints(shape as Circle, this);
            else if (shape is Polygon) output = LineWithPolygon.GetCrossingPoints(this, shape as Polygon);
            else if (shape is Segment) output = LineWithSegment.GetCrossingPoints(this, shape as Segment);
            else if (shape is RealPoint) output = LineWithRealPoint.GetCrossingPoints(this, shape as RealPoint);
            else if (shape is Line) output = LineWithLine.GetCrossingPoints(this, shape as Line);

            return output;
        }

        /// <summary>
        /// Teste si la droite courante croise la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Vrai si droite croise la forme testée</returns>
        public virtual bool Cross(IShape shape)
        {
            bool output = false;

            if (shape is Circle) output = CircleWithLine.Cross(shape as Circle, this);
            else if (shape is Polygon) output = LineWithPolygon.Cross(this, shape as Polygon);
            else if (shape is Segment) output = LineWithSegment.Cross(this, shape as Segment);
            else if (shape is RealPoint) output = LineWithRealPoint.Cross(this, shape as RealPoint);
            else if (shape is Line) output = LineWithLine.Cross(this, shape as Line);

            return output;
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

        public bool IsParallel(Line other)
        {
            // Les deux horizontales, les deux verticales, ou la même pente

            return this.IsHorizontal && other.IsHorizontal || this.IsVertical && other.IsVertical || this.A == other.A;
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
