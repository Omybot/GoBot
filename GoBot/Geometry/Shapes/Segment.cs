using Geometry.Shapes.ShapesInteractions;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Geometry.Shapes
{
    // Un segment est une Droite avec deux extrémités
    public class Segment : Line, IShapeModifiable<Segment>
    {
        #region Attributs

        protected RealPoint _startPoint, _endPoint;

        #endregion

        #region Constructeurs

        public Segment(RealPoint start, RealPoint end)
        {
            _startPoint = new RealPoint(start);
            _endPoint = new RealPoint(end);

            SetLine(StartPoint, EndPoint);
        }

        public Segment(Segment segment)
        {
            _startPoint = new RealPoint(segment.StartPoint);
            _endPoint = new RealPoint(segment.EndPoint);

            _a = segment.A;
            _b = segment.B;
            _c = segment.C;
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
                return _startPoint;
            }
            set
            {
                _startPoint = value;
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
                return _endPoint;
            }
            set
            {
                _endPoint = value;
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
        /// Obtient la droite sur laquelle le segment se trouve
        /// </summary>
        public Line Line
        {
            get
            {
                return new Line(this);
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
                return new RealPoint((_startPoint.X + _endPoint.X) / 2, (_startPoint.Y + _endPoint.Y) / 2);
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
            return StartPoint + " -> " + EndPoint;
        }

        #endregion

        #region Croisements

        /// <summary>
        /// Retourne la liste des points de croisement avec la forme donnée
        /// </summary>
        /// <param name="shape">Forme à tester</param>
        /// <returns>Liste des points de croisement</returns>
        public override List<RealPoint> GetCrossingPoints(IShape shape)
        {
            List<RealPoint> output = new List<RealPoint>();

            if (shape is RealPoint) output = SegmentWithRealPoint.GetCrossingPoints(this, shape as RealPoint);
            else if (shape is Segment) output = SegmentWithSegment.GetCrossingPoints(this, shape as Segment);
            else if (shape is Polygon) output = SegmentWithPolygon.GetCrossingPoints(this, shape as Polygon);
            else if (shape is Circle) output = SegmentWithCircle.GetCrossingPoints(this, shape as Circle);
            else if (shape is Line) output = SegmentWithLine.GetCrossingPoints(this, shape as Line);

            return output;
        }

        private List<RealPoint> GetCrossingPointsWithPolygon(Polygon polygon)
        {
            return polygon.GetCrossingPoints(this); // Le polygone sait faire
        }

        /// <summary>
        /// Teste si le segment courant croise la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Vrai si le segment croise la forme donnée</returns>
        public override bool Cross(IShape shape)
        {
            bool output = false;

            if (shape is RealPoint) output = SegmentWithRealPoint.Cross(this, shape as RealPoint);
            else if (shape is Segment) output = SegmentWithSegment.Cross(this, shape as Segment);
            else if (shape is Polygon) output = SegmentWithPolygon.Cross(this, shape as Polygon);
            else if (shape is Circle) output = SegmentWithCircle.Cross(this, shape as Circle);
            else if (shape is Line) output = SegmentWithLine.Cross(this, shape as Line);

            return output;
        }

        /// <summary>
        /// Teste si le segment courant croise la droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Vrai si la segment contient la droite donnée</returns>
        protected bool Cross(Line line)
        {
            return GetCrossingPoints(line).Count > 0;
        }

        /// <summary>
        /// Teste si le segment courant croise le polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Vrai si le segment croise le polygone donné</returns>
        protected  bool Cross(Polygon polygon)
        {
            return polygon.Cross(this);
        }

        #endregion

        #region Contient
        
        /// <summary>
        /// Teste si le segment courant contient la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Vrai si le segment contient la forme donnée</returns>
        public override bool Contains(IShape shape)
        {
            bool output = false;

            if (shape is RealPoint) output = SegmentWithRealPoint.Contains(this, shape as RealPoint);
            else if (shape is Segment) output = SegmentWithSegment.Contains(this, shape as Segment);
            else if (shape is Polygon) output = SegmentWithPolygon.Contains(this, shape as Polygon);
            else if (shape is Circle) output = SegmentWithCircle.Contains(this, shape as Circle);
            else if (shape is Line) output = SegmentWithLine.Contains(this, shape as Line);

            return output;
        }

        #endregion

        #region Distance
        
        public override double Distance(IShape shape)
        {
            double output = 0;

            if (shape is RealPoint) output = SegmentWithRealPoint.Distance(this, shape as RealPoint);
            else if (shape is Segment) output = SegmentWithSegment.Distance(this, shape as Segment);
            else if (shape is Polygon) output = SegmentWithPolygon.Distance(this, shape as Polygon);
            else if (shape is Circle) output = SegmentWithCircle.Distance(this, shape as Circle);
            else if (shape is Line) output = SegmentWithLine.Distance(this, shape as Line);

            return output;
        }

        /// <summary>
        /// Retourne la distance minimale entre le segment courant et la droite donnée
        /// </summary>
        /// <param name="forme">Droite testée</param>
        /// <returns>Distance minimale</returns>
        public double Distance(Line line)
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
            return new Segment(_startPoint.Translation(dx, dy), _endPoint.Translation(dx, dy));
        }

        /// <summary>
        /// Retourne un segment qui est tournée de l'angle donné
        /// </summary>
        /// <param name="angle">Angle de rotation</param>
        /// <param name="rotationCenter">Centre de rotation, si null (0, 0) est utilisé</param>
        /// <returns>Segment tourné de l'angle donné</returns>
        public new Segment Rotation(AngleDelta angle, RealPoint rotationCenter = null)
        {
            if (rotationCenter == null) rotationCenter = Barycenter;

            return new Segment(_startPoint.Rotation(angle, rotationCenter), _endPoint.Rotation(angle, rotationCenter));
        }

        /// <summary>
        /// Retourne un segment qui prolonge l'actuel en ajoutant un point.
        /// Le résultat est valide uniquement si le point ajouté se trouve sur la droite formée par le segment.
        /// </summary>
        /// <param name="pt">Point à ajouter au segment</param>
        /// <returns>Segment prolongé jusqu'au point donné</returns>
        public Segment Join(RealPoint pt)
        {
            Segment s1 = new Segment(_startPoint, pt);
            Segment s2 = new Segment(_endPoint, pt);

            Segment res;

            if (this.Contains(pt))
                res = new Segment(this);
            else if (s1.Contains(_endPoint))
                res = s1;
            else if (s2.Contains(_startPoint))
                res = s2;
            else
                res = null;

            return res;
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
        public override void Paint(Graphics g, Pen outline, Brush fill, WorldScale scale)
        {
            Point startPoint = scale.RealToScreenPosition(StartPoint);
            Point endPoint = scale.RealToScreenPosition(EndPoint);
            
            if (outline != null)
                    g.DrawLine(outline, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
        }

        #endregion
    }
}
