using System;
using System.Collections.Generic;
using System.Drawing;
using Geometry.Shapes.ShapesInteractions;

namespace Geometry.Shapes
{
    public class Circle : IShape, IShapeModifiable<Circle>
    {
        #region Attributs

        private RealPoint _center;
        private double _radius;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Construit un cercle depuis son centre et son rayon
        /// </summary>
        /// <param name="center">Point central du cercle</param>
        /// <param name="radius">Rayon du cercle</param>
        public Circle(RealPoint center, double radius)
        {
            if (radius < 0) throw new ArgumentException("Radius must be >= 0");

            _center = center;
            _radius = radius;
        }

        /// <summary>
        /// Construit un cercle depuis un autre cercle
        /// </summary>
        /// <param name="circle">cercle à copier</param>
        public Circle(Circle circle)
        {
            _center = circle._center;
            _radius = circle._radius;
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// Obtient le centre du cercle
        /// </summary>
        public RealPoint Center { get { return _center; } }

        /// <summary>
        /// Obtient le rayon du cercle
        /// </summary>
        public double Radius { get { return _radius; } }

        /// <summary>
        /// Obtient la surface du cercle
        /// </summary>
        public double Surface { get { return _radius * _radius * Math.PI; } }

        /// <summary>
        /// Obtient le barycentre du cercle
        /// </summary>
        public RealPoint Barycenter { get { return _center; } }

        #endregion

        #region Opérateurs & Surcharges

        public static bool operator ==(Circle a, Circle b)
        {
            if ((object)a == null || (object)b == null)
                return (object)a == null && (object)b == null;
            else
                return Math.Abs(a.Radius - b.Radius) < RealPoint.PRECISION
                        && a.Center == b.Center;
        }

        public static bool operator !=(Circle a, Circle b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            Circle p = obj as Circle;
            if ((Object)p == null)
            {
                return false;
            }

            return (Circle)obj == this;
        }

        public override int GetHashCode()
        {
            return (int)(_center.GetHashCode()) ^ (int)_radius;
        }

        public override string ToString()
        {
            return "C = " + _center.ToString() + "; R = " + _radius.ToString("0.00");
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimale entre le cercle courant et la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Distance minimale</returns>
        public double Distance(IShape shape)
        {
            double output = 0;

            if (shape is RealPoint) output = CircleWithRealPoint.Distance(this, shape as RealPoint);
            else if (shape is Segment) output = CircleWithSegment.Distance(this, shape as Segment);
            else if (shape is Polygon) output = CircleWithPolygon.Distance(this, shape as Polygon);
            else if (shape is Circle) output = CircleWithCircle.Distance(this, shape as Circle);
            else if (shape is Line) output = CircleWithLine.Distance(this, shape as Line);

            return output;
        }

        #endregion

        #region Contient

        /// <summary>
        /// Teste si le cercle courant contient la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Vrai si le cercle contient la forme testée</returns>
        public bool Contains(IShape shape)
        {
            bool output = false;

            if (shape is RealPoint) output = CircleWithRealPoint.Contains(this, shape as RealPoint);
            else if (shape is Segment) output = CircleWithSegment.Contains(this, shape as Segment);
            else if (shape is Polygon) output = CircleWithPolygon.Contains(this, shape as Polygon);
            else if (shape is Circle) output = CircleWithCircle.Contains(this, shape as Circle);
            else if (shape is Line) output = CircleWithLine.Contains(this, shape as Line);

            return output;
        }

        #endregion

        #region Croise

        /// <summary>
        /// Retourne la liste des points de croisement avec la forme donnée
        /// </summary>
        /// <param name="shape">Forme à tester</param>
        /// <returns>Liste des points de croisement</returns>
        public List<RealPoint> GetCrossingPoints(IShape shape)
        {
            List<RealPoint> output = new List<RealPoint>();

            if (shape is RealPoint) output = CircleWithRealPoint.GetCrossingPoints(this, shape as RealPoint);
            else if (shape is Segment) output = CircleWithSegment.GetCrossingPoints(this, shape as Segment);
            else if (shape is Polygon) output = CircleWithPolygon.GetCrossingPoints(this, shape as Polygon);
            else if (shape is Circle) output = CircleWithCircle.GetCrossingPoints(this, shape as Circle);
            else if (shape is Line) output = CircleWithLine.GetCrossingPoints(this, shape as Line);

            return output;
        }

        /// <summary>
        /// Teste si le cercle courant croise la forme donnée
        /// </summary>
        /// <param name="shape">Forme testéé</param>
        /// <returns>Vrai si le cercle courant croise la forme donnée</returns>
        public bool Cross(IShape shape)
        {
            bool output = false;

            if (shape is RealPoint) output = CircleWithRealPoint.Cross(this, shape as RealPoint);
            else if (shape is Segment) output = CircleWithSegment.Cross(this, shape as Segment);
            else if (shape is Polygon) output = CircleWithPolygon.Cross(this, shape as Polygon);
            else if (shape is Circle) output = CircleWithCircle.Cross(this, shape as Circle);
            else if (shape is Line) output = CircleWithLine.Cross(this, shape as Line);

            return output;
        }

        #endregion

        #region Transformations

        /// <summary>
        /// Retourne un cercle qui est translaté des distances données
        /// </summary>
        /// <param name="dx">Distance en X</param>
        /// <param name="dy">Distance en Y</param>
        /// <returns>Cercle translaté des distances données</returns>
        public Circle Translation(double dx, double dy)
        {
            return new Circle(_center.Translation(dx, dy), _radius);
        }

        /// <summary>
        /// Retourne un cercle qui est tourné de l'angle donné
        /// </summary>
        /// <param name="angle">Angle de rotation</param>
        /// <param name="rotationCenter">Centre de rotation, si null le barycentre est utilisé</param>
        /// <returns>Cercle tourné de l'angle donné</returns>
        public Circle Rotation(AngleDelta angle, RealPoint rotationCenter = null)
        {
            if (rotationCenter == null) rotationCenter = Barycenter;

            return new Circle(_center.Rotation(angle, rotationCenter), _radius);
        }

        #endregion

        #region Peinture

        /// <summary>
        /// Dessine le cercle sur un Graphic
        /// </summary>
        /// <param name="g">Graphic sur lequel dessiner</param>
        /// <param name="outline">Pen utilisé pour dessiner le contour du cercle</param>
        /// <param name="fill">Brush utilisé pour remplissage du cercle</param>
        /// <param name="scale">Echelle de conversion</param>
        public void Paint(Graphics g, Pen outline, Brush fill, WorldScale scale)
        {
            Point screenPosition = scale.RealToScreenPosition(Center);
            int screenRadius = scale.RealToScreenDistance(Radius);

            if (fill != null)
                g.FillEllipse(fill, new Rectangle(screenPosition.X - screenRadius, screenPosition.Y - screenRadius, screenRadius * 2, screenRadius * 2));

            if (outline != null)
                g.DrawEllipse(outline, new Rectangle(screenPosition.X - screenRadius, screenPosition.Y - screenRadius, screenRadius * 2, screenRadius * 2));

        }

        #endregion
    }
}
