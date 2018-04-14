using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Geometry.Shapes;
using System.Drawing;

namespace GoBot.Geometry.Shapes
{
    public class RealPoint : IShape, IShapeModifiable<RealPoint>
    {
        public const double PRECISION = 0.01;

        #region Attributs

        /// <summary>
        /// Position sur l'axe des abscisses
        /// </summary>
        private double xPosition;

        /// <summary>
        /// Position sur l'axe des ordonnées
        /// </summary>
        private double yPosition;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut, les coordonnées seront (0, 0)
        /// </summary>
        public RealPoint()
        {
            xPosition = 0;
            yPosition = 0;
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        public RealPoint(RealPoint other)
        {
            xPosition = other.xPosition;
            yPosition = other.yPosition;
        }

        /// <summary>
        /// Construit des coordonnées selon x et y
        /// </summary>
        /// <param name="x">Abscisse</param>
        /// <param name="y">Ordonnée</param>
        public RealPoint(double x, double y)
        {
            xPosition = x;
            yPosition = y;
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// Obtient la position sur l'axe des abscisses
        /// </summary>
        public double X
        {
            get
            {
                return xPosition;
            }
            set
            {
                xPosition = value;
            }
        }

        /// <summary>
        /// Obtient la coordonnée sur l'axe des ordonnées
        /// </summary>
        public double Y
        {
            get
            {
                return yPosition;
            }
            set
            {
                yPosition = value;
            }
        }

        /// <summary>
        /// Surface du PointReel
        /// </summary>
        public double Surface
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Barycentre du PointReel
        /// </summary>
        public RealPoint Barycenter
        {
            get
            {
                return new RealPoint(this);
            }
        }

        #endregion

        #region Opérateurs & Surcharges

        public static bool operator ==(RealPoint a, RealPoint b)
        {
            if ((object)a == null || (object)b == null)
                return (object)a == null && (object)b == null;
            else
            {
                double diffX = a.X > b.X ? a.X - b.X : b.X - a.X;
                double diffY = a.Y > b.Y ? a.Y - b.Y : b.Y - a.Y;

                return (diffX < PRECISION && diffY < PRECISION);
            }
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
            return "{" + Math.Round(X, 2) + " : " + Math.Round(Y, 2) + "}";
        }

        public override bool Equals(object obj)
        {
            RealPoint p = obj as RealPoint;
            if ((Object)p == null)
            {
                return false;
            }

            return (RealPoint)obj == this;
        }

        public override int GetHashCode()
        {
            return (int)X ^ (int)Y;
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
            return Distance(Util.ToRealType(shape));
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le Segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Segment segment)
        {
            // Le segment sait le faire
            return segment.Distance(this);
        }
        
        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et la Droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Line line)
        {
            // La droite sait le faire
            return line.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le Cercle donné
        /// </summary>
        /// <param name="circle">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Circle circle)
        {
            // Distance jusqu'au centre du cercle - son rayon
            return Distance(circle.Center) - circle.Radius;
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le Polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Polygon polygon)
        {
            // Distance jusqu'au segment le plus proche
            double minDistance = double.MaxValue;

            foreach (Segment s in polygon.Sides)
                minDistance = Math.Min(s.Distance(this), minDistance);

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(RealPoint point)
        {
            return Maths.Hypothenuse((X - point.X), (Y - point.Y));
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
            // La seule chose qu'un point peut contenir, c'est un point identique à lui même
            if (shape is RealPoint)
                return (RealPoint)shape == this;

            return false;
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
            return GetCrossingPoints(Util.ToRealType(shape)) != null;
        }

        /// <summary>
        /// Retourne les points de croisements entre ce point et la forme donnée. Le croisement ne peut au mieux qu'être le point lui même.
        /// </summary>
        /// <param name="shape">Forme avec laquelle tester les croisements</param>
        /// <returns>Points de croisement</returns>
        public List<RealPoint> GetCrossingPoints(IShape shape)
        {
            RealPoint crossPoint = GetCrossingPoint(Util.ToRealType(shape));
            List<RealPoint> crossPoints = new List<RealPoint>();

            if (crossPoint != null)
                crossPoints.Add(crossPoint);

            return crossPoints;
        }

        /// <summary>
        /// Retourne le PointReel si il est sur le Segment donné avec une marge de <c>PRECISION</c>, sinon null
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Le PointReel lui même si il est sur le Segment, sinon null</returns>
        protected RealPoint GetCrossingPoint(Segment segment)
        {
            if (segment.Contains(this))
                return new RealPoint(this);
            else
                return null;
        }

        /// <summary>
        /// Retourne le PointReel si il est sur le PointReel donné avec une marge de <c>PRECISION</c>, sinon null
        /// </summary>
        /// <param name="point">point testé</param>
        /// <returns>Le PointReel lui même si il est sur le PointReel, sinon null</returns>
        protected RealPoint GetCrossingPoints(RealPoint point)
        {
            if (point.X == X && point.Y == Y)
                return new RealPoint(this);
            else
                return null;
        }

        /// <summary>
        /// Retourne le PointReel si il est sur la Droite donnée avec une marge de <c>PRECISION</c>, sinon null
        /// </summary>
        /// <param name="droite">Droite testée</param>
        /// <returns>Le PointReel lui même si il est sur la Droite, sinon null</returns>
        protected RealPoint GetCrossingPoints(Line droite)
        {
            if (droite.Contains(this))
                return new RealPoint(this);
            else
                return null;
        }

        /// <summary>
        /// Retourne le PointReel si il est sur le Polygone donné avec une marge de <c>PRECISION</c>, sinon null
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Le PointReel lui même si il est sur le Polygone, sinon null</returns>
        protected RealPoint GetCrossingPoints(Polygon polygone)
        {
            if (polygone.Contains(this))
                return new RealPoint(this);
            else
                return null;
        }

        /// <summary>
        /// Retourne le PointReel si il est sur le Cercle donné avec une marge de <c>PRECISION</c>, sinon null
        /// </summary>
        /// <param name="cercle">Cercle testé</param>
        /// <returns>Le PointReel lui même si il est sur le Cercle, sinon null</returns>
        protected RealPoint GetCrossingPoints(Circle cercle)
        {
            if (cercle.Contains(this))
                return new RealPoint(this);
            else
                return null;
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
            xPosition = x;
            yPosition = y;
        }

        /// <summary>
        /// Affecte les coordonnées passées en paramètre
        /// </summary>
        /// <param name="x">Abscisse</param>
        /// <param name="y">Ordonnée</param>
        public void Set(RealPoint pos)
        {
            xPosition = pos.X;
            yPosition = pos.Y;
        }

        /// <summary>
        /// Retourne un point translaté des distances données
        /// </summary>
        /// <param name="dx">Déplacement sur l'axe X</param>
        /// <param name="dy">Déplacement sur l'axe Y</param>
        /// <returns>Point translaté</returns>
        public RealPoint Translation(double dx, double dy)
        {
            return new RealPoint(xPosition + dx, yPosition + dy);
        }

        /// <summary>
        /// Retourne un point qui a subit une rotation selon l'angle et le centre donné
        /// </summary>
        /// <param name="angle">Angle de rotation</param>
        /// <param name="rotationCenter">Centre de la rotation</param>
        /// <returns>Point ayant subit la rotation donnée</returns>
        public RealPoint Rotation(Angle angle, RealPoint rotationCenter = null)
        {
            RealPoint newPoint = new RealPoint();
            newPoint.X = rotationCenter.X + Math.Cos(angle.InRadians) * (this.X - rotationCenter.X) - Math.Sin(angle.InRadians) * (this.Y - rotationCenter.Y);
            newPoint.Y = rotationCenter.Y + Math.Cos(angle.InRadians) * (this.Y - rotationCenter.Y) + Math.Sin(angle.InRadians) * (this.X - rotationCenter.X);
            return newPoint;
        }

        #endregion

        #region Peinture

        /// <summary>
        /// Dessine le point sur un Graphic
        /// </summary>
        /// <param name="g">Graphic sur lequel dessiner</param>
        /// <param name="outlineColor">Couleur du contour du point</param>
        /// <param name="outlineWidth">Rayon du point</param>
        /// <param name="fillColor">Couleur de remplissage du point</param>
        /// <param name="scale">Echelle de conversion</param>
        public void Paint(Graphics g, Color outlineColor, int outlineWidth, Color fillColor, WorldScale scale)
        {
            Point screenPosition = scale.RealToScreenPosition(this);

            Rectangle rect = new Rectangle(screenPosition.X - outlineWidth, screenPosition.Y - outlineWidth, outlineWidth * 2, outlineWidth * 2);

            if (fillColor != Color.Transparent)
                using (SolidBrush brush = new SolidBrush(fillColor))
                    g.FillEllipse(brush, rect);

            if (outlineColor != Color.Transparent)
                using (Pen pen = new Pen(outlineColor))
                    g.DrawEllipse(pen, rect);

        }

        #endregion
    }
}
