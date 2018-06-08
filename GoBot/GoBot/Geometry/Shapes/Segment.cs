using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.Geometry.Shapes
{
    // Un segment est une Droite avec deux extrémités
    public class Segment : Line, IShapeModifiable<Segment>
    {
        #region Attributs

        protected RealPoint startPoint, endPoint;

        #endregion

        #region Constructeurs

        public Segment(RealPoint start, RealPoint end)
        {
            startPoint = new RealPoint(start);
            endPoint = new RealPoint(end);

            SetLine(StartPoint, EndPoint);
        }

        public Segment(Segment segment)
        {
            startPoint = new RealPoint(segment.StartPoint);
            endPoint = new RealPoint(segment.EndPoint);

            a = segment.A;
            b = segment.B;
            c = segment.C;
            SetLine(StartPoint, EndPoint);
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// Obtient la 1ère extremité du segment
        /// </summary>
        public RealPoint StartPoint
        {
            get
            {
                return startPoint;
            }
            set
            {
                startPoint = value;
                SetLine(StartPoint, EndPoint);
            }
        }

        /// <summary>
        /// Obtient la 2ème extremité du segment
        /// </summary>
        public RealPoint EndPoint
        {
            get
            {
                return endPoint;
            }
            set
            {
                endPoint = value;
                SetLine(StartPoint, EndPoint);
            }
        }

        /// <summary>
        /// Obtient la longueur du segment
        /// </summary>
        public Double Length
        {
            get
            {
                return StartPoint.Distance(EndPoint);
            }
        }

        /// <summary>
        /// Obtient la surface du segment
        /// </summary>
        public override double Surface
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Obtient le barycentre du segment
        /// </summary>
        public override RealPoint Barycenter
        {
            get
            {
                return new RealPoint((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            }
        }

        #endregion

        #region Opérateurs & Surcharges

        public static bool operator ==(Segment a, Segment b)
        {
            if ((object)a == null || (object)b == null)
                return (object)a == null && (object)b == null;
            else
                return a.A == b.A
                    && a.B == b.B
                    && a.C == a.C
                    && a.StartPoint == b.StartPoint
                    && a.EndPoint == b.StartPoint;
        }

        public static bool operator !=(Segment a, Segment b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            Segment p = obj as Segment;
            if ((Object)p == null)
            {
                return false;
            }

            return (Segment)obj == this;
        }

        public override int GetHashCode()
        {
            return (int)StartPoint.X ^ (int)StartPoint.Y ^ (int)EndPoint.X ^ (int)EndPoint.Y;
        }

        public override string ToString()
        {
            return StartPoint + " -> " + EndPoint + " / " + base.ToString();
        }

        #endregion

        #region Croisements

        /// <summary>
        /// Retourne la liste des points de croisement avec la forme donnée
        /// </summary>
        /// <param name="forme">Forme à tester</param>
        /// <returns>Liste des points de croisement</returns>
        public override List<RealPoint> GetCrossingPoints(IShape forme)
        {
            Circle c = forme as Circle;
            if (c != null)
                return GetCrossingPoints(c);

            return null;
        }

        /// <summary>
        /// Retourne la liste des points de croisement avec le cercle donné
        /// </summary>
        /// <param name="circle">Cercle à tester</param>
        /// <returns>Liste des points de croisement</returns>
        public List<RealPoint> GetCrossingPoints(Circle circle)
        {
            List<RealPoint> intersectsPoints = null;
	        double dx = endPoint.X - startPoint.X;
            double dy = endPoint.Y - startPoint.Y;
            double Ox = startPoint.X - circle.Center.X;
            double Oy = startPoint.Y - circle.Center.Y;
            double A = dx * dx + dy * dy;
            double B = 2 * (dx * Ox + dy * Oy);
            double C = Ox * Ox + Oy * Oy - circle.Radius * circle.Radius;
            double delta = B * B - 4 * A * C;

	        if (delta < 0 + double.Epsilon && delta > 0 - double.Epsilon)
	        {
                intersectsPoints = new List<RealPoint>();
                double t = -B / (2 * A);
		        if (t >= 0 && t <= 1)
                    intersectsPoints.Add(new RealPoint(startPoint.X + t * dx, startPoint.Y + t * dy));
	        }
	        if (delta > 0)
	        {
                intersectsPoints = new List<RealPoint>();
                double t1 = (double)((-B - Math.Sqrt(delta)) / (2 * A));
                double t2 = (double)((-B + Math.Sqrt(delta)) / (2 * A));
		        if (t1 >= 0 && t1 <= 1)
                    intersectsPoints.Add(new RealPoint(startPoint.X + t1 * dx, startPoint.Y + t1 * dy));
		        if (t2 >= 0 && t2 <= 1)
                    intersectsPoints.Add(new RealPoint(startPoint.X + t2 * dx, startPoint.Y + t2 * dy));
	        }
	        return intersectsPoints;
        }

        /// <summary>
        /// Teste si le segment courant croise la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Vrai si le segment contient la forme donnée</returns>
        public override bool Cross(IShape shape)
        {
            return Cross(Util.ToRealType(shape));
        }

        /// <summary>
        /// Teste si le segment courant croise le point donné
        /// </summary>
        /// <param name="point">Point testé</param>
        /// <returns>Vrai si le segment contient le point donné</returns>
        protected override bool Cross(RealPoint point)
        {
            return Contains(point);
        }

        /// <summary>
        /// Teste si le segment courant croise le segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si le segment contient le segment donné</returns>
        protected override bool Cross(Segment segment)
        {
            return GetCrossingPoint(segment) != null;
        }

        /// <summary>
        /// Teste si le segment courant croise la droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Vrai si la segment contient la droite donnée</returns>
        protected override bool Cross(Line line)
        {
            return GetCrossingPoint(line) != null;
        }

        /// <summary>
        /// Teste si le segment courant croise le cercle donné
        /// </summary>
        /// <param name="circle">Cercle testé</param>
        /// <returns>Vrai si la Droite contient le cercle donné</returns>
        protected override bool Cross(Circle circle)
        {
            return circle.Cross(this);
        }

        /// <summary>
        /// Teste si le segment courant croise le polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Vrai si le segment croise le polygone donné</returns>
        protected override bool Cross(Polygon polygon)
        {
            return polygon.Cross(this);
        }

        /// <summary>
        /// Retourne le point de croisement du segment courant avec une droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Le point de croisement si la droite donnée croise le segment courant, sinon null</returns>
        new public RealPoint GetCrossingPoint(Line line)
        {
            // La ligne sait le faire
            return line.GetCrossingPoint(this);
        }

        /// <summary>
        /// Retourne le point croisement du segment courant avec un segment donné
        /// </summary>
        /// <param name="autreDroite">Segment testé</param>
        /// <returns>Le point de croisement si le segment donné croise le segment courant, sinon null</returns>
        new public RealPoint GetCrossingPoint(Segment segment)
        {
            // Pour ne pas réécrire du code existant, on récupère le croisement entre ce segment et l'autre en tant que droite
            // Si l'autre segment contient ce point, c'est le croisement, sinon il n'en existe pas

            RealPoint crossingPoint = GetCrossingPoint((Line)segment);
            if (crossingPoint != null && segment.Contains(crossingPoint) && this.Contains(crossingPoint))
                return crossingPoint;

            return null;
        }

        #endregion

        #region Contient

        /// <summary>
        /// Teste si le segment courant contient le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Vrai si le segment contient le PointReel donné</returns>
        protected override bool Contains(RealPoint point)
        {
            // Vérifie que le point est situé sur la droite
            if (!base.Contains(point))
                return false;
            // Puis qu'il est entre les deux extrémités

            if (point.X - RealPoint.PRECISION > Math.Max(StartPoint.X, EndPoint.X) ||
                point.X + RealPoint.PRECISION < Math.Min(StartPoint.X, EndPoint.X) ||
                point.Y - RealPoint.PRECISION > Math.Max(StartPoint.Y, EndPoint.Y) ||
                point.Y + RealPoint.PRECISION < Math.Min(StartPoint.Y, EndPoint.Y))
                return false;

            return true;
        }

        /// <summary>
        /// Teste si le segment courant contient le segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si le segment contient le segment donné</returns>
        protected override bool Contains(Segment segment)
        {
            // Il suffit de vérifier que le segment contient les deux extrémités
            return Contains(segment.StartPoint) && Contains(segment.EndPoint);
        }

        /// <summary>
        /// Teste si le segment courant contient la droite donnée
        /// </summary>
        /// <param name="droite">Droite testée</param>
        /// <returns>Vrai si le segment contient la droite donnée</returns>
        protected override bool Contains(Line droite)
        {
            // Un segment ne peut pas contenir de Droite
            return false;
        }

        /// <summary>
        /// Teste si le segment courant contient le polygone donné
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Vrai si le segment contient le polygone donné</returns>
        protected override bool Contains(Polygon polygone)
        {
            // Contenir un polygone revient à contenir tous les points du polygone
            foreach (RealPoint p in polygone.Points)
                if (!Contains(p))
                    return false;

            return true;
        }

        /// <summary>
        /// Teste si le segment courant contient le cercle donné
        /// </summary>
        /// <param name="Cercle">Cercle testé</param>
        /// <returns>Vrai si le segment contient le Cercle donné</returns>
        protected override bool Contains(Circle Cercle)
        {
            // Contenir un cercle revient à avoir un cercle de rayon 0 dont le centre se trouve sur le segment
            return Contains(Cercle.Center) && Cercle.Radius == 0;
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimale entre le segment courant et le segment donné
        /// </summary>
        /// <param name="forme">Segment testé</param>
        /// <returns>Distance minimale</returns>
        protected override double Distance(Segment segment)
        {
            // Si les segments se croisent la distance est de 0
            if (Cross(segment))
                return 0;

            // Sinon c'est la distance minimale entre (chaque extremité d'un segment) et (l'autre segment)
            double minDistance = double.MaxValue;

            // Le minimal est peut être entre les extremités
            minDistance = Math.Min(minDistance, segment.StartPoint.Distance(StartPoint));
            minDistance = Math.Min(minDistance, segment.StartPoint.Distance(EndPoint));
            minDistance = Math.Min(minDistance, segment.EndPoint.Distance(StartPoint));
            minDistance = Math.Min(minDistance, segment.EndPoint.Distance(EndPoint));

            // Le minimal est peut etre entre une extremité et son projeté hortogonal sur l'autre segment
            Line perpendicular = segment.GetPerpendicular(StartPoint);
            RealPoint crossingPoint = segment.GetCrossingPoint(perpendicular);
            if(crossingPoint != null)
                minDistance = Math.Min(minDistance, crossingPoint.Distance(StartPoint));

            perpendicular = segment.GetPerpendicular(EndPoint);
            crossingPoint = segment.GetCrossingPoint(perpendicular);
            if(crossingPoint != null)
                minDistance = Math.Min(minDistance, crossingPoint.Distance(EndPoint));

            perpendicular = GetPerpendicular(segment.StartPoint);
            crossingPoint = GetCrossingPoint(perpendicular);
            if (crossingPoint != null)
                minDistance = Math.Min(minDistance, crossingPoint.Distance(segment.StartPoint));

            perpendicular = GetPerpendicular(segment.EndPoint);
            crossingPoint = GetCrossingPoint(perpendicular);
            if (crossingPoint != null)
                minDistance = Math.Min(minDistance, crossingPoint.Distance(segment.EndPoint));

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le segment courant et la droite donnée
        /// </summary>
        /// <param name="forme">Droite testée</param>
        /// <returns>Distance minimale</returns>
        protected override double Distance(Line line)
        {
            // Si la droite et le segment se croisent la distance est de 0
            if (Cross(line))
                return 0;

            // Sinon c'est la distance minimale entre chaque extremité du segment et la droite
            double minDistance = double.MaxValue;

            minDistance = Math.Min(minDistance, line.Distance(StartPoint));
            minDistance = Math.Min(minDistance, line.Distance(EndPoint));

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le segment courant et le cercle donné
        /// </summary>
        /// <param name="forme">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        protected override double Distance(Circle circle)
        {
            if (Cross(circle))
                return 0;

            // Distance jusqu'au centre du cercle - son rayon
            return Distance(circle.Center) - circle.Radius;
        }

        /// <summary>
        /// Retourne la distance minimale entre le segment courant et le polygone donné
        /// </summary>
        /// <param name="forme">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        protected override double Distance(Polygon polygon)
        {
            // Distance jusqu'au segment le plus proche
            double minDistance = double.MaxValue;

            foreach (Segment s in polygon.Sides)
            {
                if (Cross(s))
                    return 0;

                minDistance = Math.Min(s.Distance(this), minDistance);
            }

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le segment courant et un point donné
        /// </summary>
        /// <param name="point">Point testé</param>
        /// <returns>Distance minimale</returns>
        protected override double Distance(RealPoint point)
        {
            // Le raisonnement est le même que pour la droite cf Droite.Distance

            Line perpendicular = GetPerpendicular(point);
            RealPoint crossingPoint = GetCrossingPoint(perpendicular);

            double distance;

            // Seule différence : on teste si l'intersection appartient bien au segment, sinon on retourne la distance avec l'extrémité la plus proche
            if (crossingPoint == null)
            {
                double distanceDebut = point.Distance(StartPoint);
                double distanceFin = point.Distance(EndPoint);

                distance = Math.Min(distanceDebut,  distanceFin);
            }
            else
            {
                distance = point.Distance(crossingPoint);
            }

            return distance;
        }

        #endregion

        #region Transformations

        /// <summary>
        /// Retourne un segment qui est translaté des distances données
        /// </summary>
        /// <param name="dx">Distance en X</param>
        /// <param name="dy">Distance en Y</param>
        /// <returns>Segment translaté des distances données</returns>
        public new Segment Translation(double dx, double dy)
        {
            return new Segment(startPoint.Translation(dx, dy), endPoint.Translation(dx, dy));
        }

        /// <summary>
        /// Retourne un segment qui est tournée de l'angle donné
        /// </summary>
        /// <param name="angle">Angle de rotation</param>
        /// <param name="rotationCenter">Centre de rotation, si null (0, 0) est utilisé</param>
        /// <returns>Segment tourné de l'angle donné</returns>
        public new Segment Rotation(AngleDelta angle, RealPoint rotationCenter = null)
        {
            if (rotationCenter == null)
                rotationCenter = Barycenter;

            return new Segment(startPoint.Rotation(angle, rotationCenter), endPoint.Rotation(angle, rotationCenter));
        }
        #endregion

        #region Peinture

        /// <summary>
        /// Peint le segment sur le Graphic donné
        /// </summary>
        /// <param name="g">Graphique sur lequel peindre</param>
        /// <param name="outlineColor">Couleur du contour</param>
        /// <param name="outlineWidth">Epaisseur du segment</param>
        /// <param name="fillColor">Couleur de remplissage</param>
        /// <param name="scale">Echelle de conversion</param>
        public override void Paint(Graphics g, Color outlineColor, int outlineWidth, Color fillColor, WorldScale scale)
        {
            Point startPoint = scale.RealToScreenPosition(StartPoint);
            Point endPoint = scale.RealToScreenPosition(EndPoint);
            
            if (outlineColor != Color.Transparent)
                using (Pen pen = new Pen(outlineColor, outlineWidth))
                    g.DrawLine(pen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

            if (fillColor != Color.Transparent)
                using (Pen pen = new Pen(fillColor, outlineWidth - 2))
                    g.DrawLine(pen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
        }

        #endregion
    }
}
