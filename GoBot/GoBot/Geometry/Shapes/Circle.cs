using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.Geometry.Shapes
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
            return Distance(Util.ToRealType(shape));
        }

        /// <summary>
        /// Retourne la distance minimale entre le cercle courant et le segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Segment segment)
        {
            // Le segment sait le faire
            return segment.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le cercle courant et la droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Line line)
        {
            // La droite sait le faire
            return line.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le cercle courant et le cercle donné
        /// </summary>
        /// <param name="circle">cercle testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Circle circle)
        {
            if (Cross(circle))
                return 0;

            return circle.Center.Distance(Center) - Radius - circle.Radius;
        }

        /// <summary>
        /// Retourne la distance minimale entre le cercle courant et le polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Polygon polygon)
        {
            // Le polygone sait le faire
            return polygon.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le cercle courant et le point donné
        /// </summary>
        /// <param name="point">Point testé</param>
        /// <returns>Distance calculée</returns>
        protected double Distance(RealPoint point)
        {
            // C'est la distance entre le centre du cercle et le point moins le rayon du cercle
            return point.Distance(Center) - _radius;
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
            return Contains(Util.ToRealType(shape));
        }

        /// <summary>
        /// Teste si le cercle courant contient le point donné
        /// </summary>
        /// <param name="point">Point testé</param>
        /// <returns>Vrai si le cercle contient le point testé</returns>
        protected bool Contains(RealPoint point)
        {
            // Pour contenir un point, celui si se trouve à une distance inférieure au rayon du centre
            return point.Distance(_center) <= _radius;
        }

        /// <summary>
        /// Teste si le cercle courant contient le segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si le cercle courant contient le segment testé</returns>
        protected bool Contains(Segment segment)
        {
            // Pour contenir un Segment il suffit de contenir ses 2 extremités
            return Contains(segment.StartPoint) && Contains(segment.EndPoint);
        }

        /// <summary>
        /// Teste si le cercle courant contient la droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Vrai si le cercle courant contient la droite testée</returns>
        protected bool Contains(Line line)
        {
            // Un cercle ne peut pas contenir de droite
            return false;
        }

        /// <summary>
        /// Teste si le cercle courant contient le Polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Vrai si le cercle courant contient le Polygone testé</returns>
        protected bool Contains(Polygon polygon)
        {
            // Pour contenir un polygone il suffit de contenir tous ses cotés
            foreach (Segment s in polygon.Sides)
            {
                if (!Contains(s))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Teste si le cercle courant contient le cercle donné
        /// </summary>
        /// <param name="circle">cercle testé</param>
        /// <returns>Vrai si le cercle courant contient le cercle testé</returns>
        protected bool Contains(Circle circle)
        {
            // Pour contenir un cercle il faut que son rayon + la distance entre les centres des deux cercles soit inférieure à notre rayon
            return circle._radius + circle.Center.Distance(Center) < _radius;
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

            if (shape is Circle) output = GetCrossingPointsWithCircle(shape as Circle);
            else if (shape is Polygon) output = GetCrossingPointsWithPolygon(shape as Polygon);
            else if (shape is Segment) output = GetCrossingPointsWithSegment(shape as Segment);
            else if (shape is RealPoint) output = GetCrossingPointsWithPoint(shape as RealPoint);
            else if (shape is Line) output = GetCrossingPointsWithLine(shape as Line);

            return output;
        }

        private List<RealPoint> GetCrossingPointsWithCircle(Circle circle)
        {
            List<RealPoint> output = new List<RealPoint>();

            RealPoint oc1 = new RealPoint(circle.Center), oc2 = new RealPoint(_center);
            double b = circle.Radius, c = _radius;

            if (Math.Abs(oc1.Y - oc2.Y) > RealPoint.PRECISION) // Cercles non alignés horizontalement (sinon division par 0)
            {
                double a = (-(Math.Pow(oc1.X, 2)) - (Math.Pow(oc1.Y, 2)) + Math.Pow(oc2.X, 2) + Math.Pow(oc2.Y, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * (oc2.Y - oc1.Y));
                double d = ((oc2.X - oc1.X) / (oc2.Y - oc1.Y));

                double A = Math.Pow(d, 2) + 1;
                double B = -2 * oc1.X + 2 * oc1.Y * d - 2 * a * d;
                double C = Math.Pow(oc1.X, 2) + Math.Pow(oc1.Y, 2) - 2 * oc1.Y * a + Math.Pow(a, 2) - Math.Pow(b, 2);

                double delta = Math.Pow(B, 2) - 4 * A * C;

                if (delta >= 0)
                {
                    double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
                    double y1 = a - x1 * d;
                    output.Add(new RealPoint(x1, y1));

                    if (delta > 0)
                    {
                        double x2 = (-B - Math.Sqrt(delta)) / (2 * A);
                        double y2 = a - x2 * d;
                        output.Add(new RealPoint(x2, y2));
                    }
                }
            }
            else
            {
                double a = oc1.Distance(oc2);

                if (a <= b + c)
                {
                    double x1 = ((c * c) - (a * a) - (b * b)) / (-2 * a);
                    double y1 = Math.Sqrt((c * c) - Math.Pow(a - x1, 2));

                    output.Add(new RealPoint(x1 + oc1.X, y1 + oc1.Y));
                    if (Math.Abs(y1) > RealPoint.PRECISION)
                        output.Add(new RealPoint(x1 + oc1.X, -y1 + oc1.Y));
                }
            }

            return output;
        }

        private List<RealPoint> GetCrossingPointsWithPolygon(Polygon polygon)
        {
            return polygon.GetCrossingPoints(this); //Le polygone sait faire
        }

        private List<RealPoint> GetCrossingPointsWithSegment(Segment segment)
        {
            return segment.GetCrossingPoints(this); //Le segment sait faire
        }

        private List<RealPoint> GetCrossingPointsWithPoint(RealPoint point)
        {
            return point.GetCrossingPoints(this); //Le point sait faire
        }

        private List<RealPoint> GetCrossingPointsWithLine(Line line)
        {
            // TODO
            return new List<RealPoint>();
        }

        /// <summary>
        /// Teste si le cercle courant croise la forme donnée
        /// </summary>
        /// <param name="shape">Forme testéé</param>
        /// <returns>Vrai si le cercle courant croise la forme donnée</returns>
        public bool Cross(IShape shape)
        {
            return Cross(Util.ToRealType(shape));
        }

        /// <summary>
        /// Teste si le cercle courant croise la droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Vrai si le cercle courant contient la droite donnée</returns>
        protected bool Cross(Line line)
        {
            // Si une droite croise le cercle, c'est que le point de la droite le plus proche du centre du cercle est éloigné d'une distance inférieure au rayon
            double distanceToCenter = line.Distance(_center);
            return distanceToCenter <= _radius;
        }

        /// <summary>
        /// Teste si le cercle courant contient le segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si le cercle courant croise le segment testé</returns>
        protected bool Cross(Segment segment)
        {
            // Même test que pour la droite
            double distanceToCenter = segment.Distance(_center);

            return distanceToCenter <= _radius && !this.Contains(segment);
        }

        /// <summary>
        /// Teste si le cercle courant contient le polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Vrai si le cercle courant contient le polygone testé</returns>
        protected bool Cross(Polygon polygon)
        {
            // On teste le croisement avec chaque coté du polygone
            foreach (Segment segment in polygon.Sides)
            {
                if (Cross(segment))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Teste si le cercle courant croise un autre cercle donné
        /// </summary>
        /// <param name="circle">Cercle testé</param>
        /// <returns>Vrai si le cercle courant croise le cercle testé</returns>
        protected bool Cross(Circle circle)
        {
            // Pour croiser un cercle il suffit que son centre soit éloigné de notre centre de moins que la somme de nos 2 rayons
            // Et que les cercles ne se contiennent pas l'un l'autre

            double distanceBetweenCenters = _center.Distance(circle._center);

            if (distanceBetweenCenters <= _radius + circle._radius)
                return (!circle.Contains(this)) && (!this.Contains(circle));

            return false;
        }

        /// <summary>
        /// Teste si le cercle courant croise un PointReel donné
        /// </summary>
        /// <param name=" point">PointReel testé</param>
        /// <returns>Vrai si le cercle courant croise le cercle testé</returns>
        protected bool Cross(RealPoint point)
        {
            double distanceToCenter = _center.Distance(point);

            if (distanceToCenter <= _radius + RealPoint.PRECISION && distanceToCenter >= _radius - RealPoint.PRECISION)
                return true;

            return false;
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
        /// <param name="outlineColor">Couleur du contour du cercle</param>
        /// <param name="outlineWidth">Epaisseur du contour</param>
        /// <param name="fillColor">Couleur de remplissage du cercle</param>
        /// <param name="scale">Echelle de conversion</param>
        public void Paint(Graphics g, Color outlineColor, int outlineWidth, Color fillColor, WorldScale scale)
        {
            Point screenPosition = scale.RealToScreenPosition(Center);
            int screenRadius = scale.RealToScreenDistance(Radius);

            if (fillColor != Color.Transparent)
                using (SolidBrush brush = new SolidBrush(fillColor))
                    g.FillEllipse(brush, new Rectangle(screenPosition.X - screenRadius, screenPosition.Y - screenRadius, screenRadius * 2, screenRadius * 2));

            if (outlineColor != Color.Transparent)
                using (Pen pen = new Pen(outlineColor, outlineWidth))
                    g.DrawEllipse(pen, new Rectangle(screenPosition.X - screenRadius, screenPosition.Y - screenRadius, screenRadius * 2, screenRadius * 2));

        }

        #endregion
    }
}
