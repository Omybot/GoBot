using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Geometry.Shapes.ShapesInteractions;

namespace Geometry.Shapes
{
    public class RealPoint : IShape, IShapeModifiable<RealPoint>
    {
        public const double PRECISION = 0.01;

        #region Attributs

        private double _x;
        private double _y;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut, les coordonnées seront (0, 0)
        /// </summary>
        public RealPoint()
        {
            _x = 0;
            _y = 0;
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        public RealPoint(RealPoint other)
        {
            _x = other._x;
            _y = other._y;
        }

        /// <summary>
        /// Construit des coordonnées selon x et y
        /// </summary>
        /// <param name="x">Abscisse</param>
        /// <param name="y">Ordonnée</param>
        public RealPoint(double x, double y)
        {
            _x = x;
            _y = y;
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// Obtient ou définit la position sur l'axe des abscisses
        /// </summary>
        public double X { get { return _x; } set { _x = value; } }

        /// <summary>
        /// Obtient ou définit  la coordonnée sur l'axe des ordonnées
        /// </summary>
        public double Y { get { return _y; } set { _y = value; } }

        /// <summary>
        /// Obtient la surface du point (toujours 0)
        /// </summary>
        public double Surface { get { return 0; } }

        /// <summary>
        /// Obtient le barycentre du point (toujours lui même)
        /// </summary>
        public RealPoint Barycenter { get { return new RealPoint(this); } }

        #endregion

        #region Opérateurs & Surcharges
        
        public static bool operator ==(RealPoint a, RealPoint b)
        {
            if (a is null || b is null)
                return (a is null && b is null);
            else
                return (Math.Abs(a.X - b.X) < PRECISION && Math.Abs(a.Y - b.Y) < PRECISION);
        }

        public static bool operator !=(RealPoint a, RealPoint b)
        {
            return !(a == b);
        }

        public static RealPoint operator -(RealPoint a, RealPoint b)
        {
            return new RealPoint(a.X - b.X, a.Y - b.Y);
        }

        public static RealPoint operator +(RealPoint a, RealPoint b)
        {
            return new RealPoint(a.X + b.X, a.Y + b.Y);
        }

        public override string ToString()
        {
            return "{" + X.ToString("0.00") + " : " + Y.ToString("0.00") + "}";
        }

        public override bool Equals(object o)
        {
            RealPoint p = o as RealPoint;

            return (p != null) && (p == this);
        }

        public override int GetHashCode()
        {
            //return (int)X ^ (int)Y;
            return (int)(_x * _y);
            //return (int)(_x*10000 + _y);
        }

        public static implicit operator Point(RealPoint point)
        {
            return new Point((int)point.X, (int)point.Y);
        }

        public static implicit operator RealPoint(Point point)
        {
            return new RealPoint(point.X, point.Y);
        }

        public static implicit operator PointF(RealPoint point)
        {
            return new PointF((float)point.X, (float)point.Y);
        }

        public static implicit operator RealPoint(PointF point)
        {
            return new RealPoint(point.X, point.Y);
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et la IForme donnée
        /// </summary>
        /// <param name="shape">IForme testée</param>
        /// <returns>Distance minimale</returns>
        public double Distance(IShape shape)
        {
            double output = 0;

            if (shape is RealPoint) output = RealPointWithRealPoint.Distance(this, shape as RealPoint);
            else if (shape is Segment) output = RealPointWithSegment.Distance(this, shape as Segment);
            else if (shape is Polygon) output = RealPointWithPolygon.Distance(this, shape as Polygon);
            else if(shape is Circle) output = RealPointWithCircle.Distance(this, shape as Circle);
            else if (shape is Line) output = RealPointWithLine.Distance(this, shape as Line);

            return output;
        }

        #endregion

        #region Contient

        /// <summary>
        /// Teste si le PointReel contient la IForme donnée
        /// </summary>
        /// <param name="shape">IForme testée</param>
        /// <returns>Vrai si le PointReel contient la IForme testée</returns>
        public bool Contains(IShape shape)
        {
            bool output = false;

            if (shape is RealPoint) output = RealPointWithRealPoint.Contains(this, shape as RealPoint);
            else if (shape is Segment) output = RealPointWithSegment.Contains(this, shape as Segment);
            else if (shape is Polygon) output = RealPointWithPolygon.Contains(this, shape as Polygon);
            else if (shape is Circle) output = RealPointWithCircle.Contains(this, shape as Circle);
            else if (shape is Line) output = RealPointWithLine.Contains(this, shape as Line);

            return output;
        }

        #endregion

        #region Croisement

        /// <summary>
        /// Teste si le PointReel courant croise la IForme donnée
        /// Pour un PointReel, on dit qu'il croise s'il se trouve sur le contour de la forme avec une marge de <c>PRECISION</c>
        /// </summary>
        /// <param name="shape">IForme testés</param>
        /// <returns>Vrai si le PointReel courant croise la IForme donnée</returns>
        public bool Cross(IShape shape)
        {
            bool output = false;

            if (shape is RealPoint) output = RealPointWithRealPoint.Cross(this, shape as RealPoint);
            else if (shape is Segment) output = RealPointWithSegment.Cross(this, shape as Segment);
            else if (shape is Polygon) output = RealPointWithPolygon.Cross(this, shape as Polygon);
            else if (shape is Circle) output =  RealPointWithCircle.Cross(this, shape as Circle);
            else if (shape is Line) output = RealPointWithLine.Cross(this, shape as Line);

            return output;
        }

        /// <summary>
        /// Retourne les points de croisements entre ce point et la forme donnée. Le croisement ne peut au mieux qu'être le point lui même.
        /// </summary>
        /// <param name="shape">Forme avec laquelle tester les croisements</param>
        /// <returns>Points de croisement</returns>
        public List<RealPoint> GetCrossingPoints(IShape shape)
        {
            List<RealPoint> output = new List<RealPoint>();

            if (shape is RealPoint) output = RealPointWithRealPoint.GetCrossingPoints(this, shape as RealPoint);
            else if (shape is Segment) output = RealPointWithSegment.GetCrossingPoints(this, shape as Segment);
            else if (shape is Polygon) output = RealPointWithPolygon.GetCrossingPoints(this, shape as Polygon);
            else if (shape is Circle) output = RealPointWithCircle.GetCrossingPoints(this, shape as Circle);
            else if (shape is Line) output = RealPointWithLine.GetCrossingPoints(this, shape as Line);

            return output;
        }

        #endregion

        #region Transformations

        /// <summary>
        /// Affecte les coordonnées passées en paramètre
        /// </summary>
        /// <param name="x">Abscisse</param>
        /// <param name="y">Ordonnée</param>
        public void Set(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Affecte les coordonnées passées en paramètre
        /// </summary>
        /// <param name="x">Abscisse</param>
        /// <param name="y">Ordonnée</param>
        public void Set(RealPoint pos)
        {
            _x = pos.X;
            _y = pos.Y;
        }

        /// <summary>
        /// Retourne un point translaté des distances données
        /// </summary>
        /// <param name="dx">Déplacement sur l'axe X</param>
        /// <param name="dy">Déplacement sur l'axe Y</param>
        /// <returns>Point translaté</returns>
        public RealPoint Translation(double dx, double dy)
        {
            return new RealPoint(_x + dx, _y + dy);
        }

        /// <summary>
        /// Retourne un point qui a subit une rotation selon l'angle et le centre donné
        /// </summary>
        /// <param name="angle">Angle de rotation</param>
        /// <param name="rotationCenter">Centre de la rotation</param>
        /// <returns>Point ayant subit la rotation donnée</returns>
        public RealPoint Rotation(AngleDelta angle, RealPoint rotationCenter)
        {
            RealPoint newPoint = new RealPoint();
            newPoint.X = rotationCenter.X + angle.Cos * (this.X - rotationCenter.X) - angle.Sin * (this.Y - rotationCenter.Y);
            newPoint.Y = rotationCenter.Y + angle.Cos * (this.Y - rotationCenter.Y) + angle.Sin * (this.X - rotationCenter.X);
            return newPoint;
        }

        #endregion

        #region Peinture

        /// <summary>
        /// Dessine le point sur un Graphic
        /// </summary>
        /// <param name="g">Graphic sur lequel dessiner</param>
        /// <param name="outline">Pen pour dessiner le contour du point</param>
        /// <param name="fill">Brush pour le remplissage du point</param>
        /// <param name="scale">Echelle de conversion</param>
        public void Paint(Graphics g, Pen outline, Brush fill, WorldScale scale)
        {
            Point screenPosition = scale.RealToScreenPosition(this);

            Rectangle rect = new Rectangle(screenPosition.X - (int)outline.Width, screenPosition.Y - (int)outline.Width, (int)outline.Width * 2, (int)outline.Width * 2);

            if (fill != null)
                    g.FillEllipse(fill, rect);

            if (outline != null)
            {
                Pen tmp = new Pen(outline.Color);
                g.DrawEllipse(tmp, rect);
                tmp.Dispose();
            }
        }

        #endregion

        #region Statiques

        public static RealPoint Shift(RealPoint realPoint, double dx, double dy)
        {
            return new RealPoint(realPoint.X + dx, realPoint.Y + dy);
        }

        #endregion
    }
}
