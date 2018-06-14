using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace GoBot.Geometry.Shapes
{
    public class Polygon : IShape, IShapeModifiable<Polygon>
    {
        #region Attributs

        /// <summary>
        /// Liste des côtés du Polygone sous forme de segments
        /// La figure est forcément fermée et le dernier point est donc forcément relié au premier
        /// </summary>
        protected List<Segment> _sides;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Contruit un polygone selon une liste de cotés
        /// Les côtés doivent être donnés dans l'ordre
        /// Si 2 côtés ne se touchent pas ils sont automatiquement reliés par un Segment intermédiaire
        /// Si 2 côtés se croisent une exception ArgumentException est levée
        /// Si le polygone n'est pas fermé le premier et le dernier point sont reliés
        /// </summary>
        /// <param name="sides">Liste des cotés</param>
        public Polygon(IEnumerable<Segment> sides)
        {
            BuildPolygon(sides);
        }

        /// <summary>
        /// Constructeur par défaut utile uniquement pour les héritiés
        /// </summary>
        protected Polygon()
        {
            _sides = new List<Segment>();
        }

        /// <summary>
        /// Construit un Polygone depuis un autre Polygone
        /// </summary>
        protected Polygon(Polygon polygon)
        {
            _sides = new List<Segment>();

            foreach(Segment s in polygon.Sides)
                _sides.Add(new Segment(s));
        }

        /// <summary>
        /// Construit un polygone selon une liste de points
        /// Si le polygone n'est pas fermé le premier et le dernier point sont reliés
        /// </summary>
        /// <param name="points">Liste des points du polygone dans l'ordre où ils sont reliés</param>
        public Polygon(IEnumerable<RealPoint> points)
        {
            _sides = new List<Segment>();

            List<Segment> segs = new List<Segment>();

            if (points.Count() == 0)
                return;

            for (int i = 1; i < points.Count(); i++)
                segs.Add(new Segment(points.ElementAt(i - 1), points.ElementAt(i)));

            segs.Add(new Segment(points.ElementAt(points.Count() - 1), points.ElementAt(0)));

            BuildPolygon(segs);
        }

        /// <summary>
        /// Construit le polygone à partir d'une liste de segment définissant son contour
        /// </summary>
        /// <param name="segs">Segments du contour</param>
        protected void BuildPolygon(IEnumerable<Segment> segs)
        {
            if (segs.Count() == 0)
                return;

            _sides = new List<Segment>();

            for (int i = 0; i < segs.Count() - 1; i++)
            {
                Segment seg1 = segs.ElementAt(i);
                Segment seg2 = segs.ElementAt(i + 1);

                _sides.Add(seg1);

                if (seg1.EndPoint != seg2.StartPoint)
                    _sides.Add(new Segment(seg1.EndPoint, seg2.StartPoint));

            }

            _sides.Add(segs.ElementAt(segs.Count() - 1));

            for (int i = 0; i < _sides.Count; i++)
                for (int j = i+1; j < _sides.Count; j++)
                {
                    List<RealPoint> cross = _sides[i].GetCrossingPoints(_sides[j]);
                    if (cross.Count > 0 && cross[0] != _sides[i].StartPoint && cross[0] != _sides[i].EndPoint)
                        throw new ArgumentException("Le polygone construit a un ou plusieurs côtés qui se croisent. Création impossible.");
                }
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// Obtient la liste des cotés du polygone
        /// </summary>
        public List<Segment> Sides
        {
            get
            {
                return _sides;
            }
        }

        /// <summary>
        /// Obtient la liste des sommets du polygone
        /// </summary>
        public List<RealPoint> Points
        {
            get
            {
                return Sides.Select(s => new RealPoint(s.StartPoint.X, s.StartPoint.Y)).ToList();
            }
        }

        /// <summary>
        /// Obtient la surface du polygone
        /// </summary>
        public virtual double Surface
        {
            get
            {
                double surface = 0;

                foreach(PolygonTriangle t in this.ToTriangles())
                    surface += t.Surface;

                return surface;
            }
        }

        /// <summary>
        /// Obtient le barycentre du polygone
        /// </summary>
        public virtual RealPoint Barycenter
        {
            get
            {
                double x = 0;
                double y = 0;
                double surface = Surface;

                foreach (PolygonTriangle t in this.ToTriangles())
                {
                    RealPoint barycentreTriangle = t.Barycenter;
                    double otherSurface = t.Surface;

                    x += barycentreTriangle.X * otherSurface / surface;
                    y += barycentreTriangle.Y * otherSurface / surface;
                }

                return new RealPoint(x, y);
            }
        }

        #endregion

        #region Opérateurs & Surcharges

        public static bool operator ==(Polygon a, Polygon b)
        {

            if ((object)a == null || (object)b == null)
                return (object)a == null && (object)b == null;
            else if (a.Sides.Count == b.Sides.Count)
            {
                for (int i = 0; i < a.Sides.Count; i++)
                {
                    if (a.Sides[i] != b.Sides[i])
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        public static bool operator !=(Polygon a, Polygon b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            Polygon p = obj as Polygon;
            if ((Object)p == null)
            {
                return false;
            }

            return (Polygon)obj == this;
        }

        public override int GetHashCode()
        {
            if (_sides.Count == 0)
                return 0;

            int hash = _sides[0].GetHashCode();
            for (int i = 1; i < _sides.Count; i++)
                hash ^= _sides[i].GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            if (_sides.Count == 0)
                return "-";

            String chaine = _sides[0].ToString() + Environment.NewLine;
            for (int i = 1; i < _sides.Count; i++)
                chaine += _sides[i].ToString() + Environment.NewLine;

            return chaine;
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimum entre le polygone courant et la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Distance minimum entre le polygone et la forme donnée</returns>
        public double Distance(IShape shape)
        {
            return Distance(Util.ToRealType(shape));
        }

        /// <summary>
        /// Retourne la distance minimum entre le polygone courant et le segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Distance minimum entre le polygone et le segment donné</returns>
        public double Distance(Segment segment)
        {
            // Le segment sait le faire
            return segment.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimum entre le polygone courant et la droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Distance minimum entre le polygone et la droite donnée</returns>
        public double Distance(Line line)
        {
            return line.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimum entre le polygone courant et le cercle donné
        /// </summary>
        /// <param name="circle">Cercle testé</param>
        /// <returns>Distance minimum entre le polygone et le cercle donné</returns>
        public double Distance(Circle circle)
        {
            double minDistance = double.MaxValue;

            foreach (Segment s in Sides)
                minDistance = Math.Min(minDistance, s.Distance(circle));

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimum entre le polygone courant et le polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Distance minimum entre le polygone et le polygone donné</returns>
        public double Distance(Polygon polygon)
        {
            double minDistance = double.MaxValue;

            foreach (Segment s1 in polygon.Sides)
                foreach (Segment s2 in Sides)
                {
                    if (s1.Cross(s2))
                        return 0;
                    minDistance = Math.Min(minDistance, s1.Distance(s2));
                }

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimum entre le polygone courant et le point donné
        /// </summary>
        /// <param name="point">Point testé</param>
        /// <returns>Distance minimum entre le polygone et le point donné</returns>
        public double Distance(RealPoint point)
        {
            // C'est la distance minimale entre le point et chaque segment

            if (Contains(point))
                return 0;

            double minDistance = double.MaxValue;

            foreach (Segment s in _sides)
                minDistance = Math.Min(minDistance, s.Distance(point));

            return minDistance;
        }

        #endregion

        #region Contient

        /// <summary>
        /// Teste si le polygone courant contient la forme donnée
        /// </summary>
        /// <param name="shape">Forme testé</param>
        /// <returns>Vrai si le polygone contient la forme testée</returns>
        public bool Contains(IShape shape)
        {
            return Contains(Util.ToRealType(shape));
        }

        /// <summary>
        /// Teste si le polygone courant contient le point donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Vrai si le polygone contient le point donné</returns>
        protected bool Contains(RealPoint point)
        {
            // Pour savoir si le Polygone contient un point on trace un segment entre ce point et un point très éloigné
            // On compte combien de cotés du polygone croisent cette droite
            // Si ce nombre est impaire alors le point est contenu dans le polygone

            int crossCount = 0;
            Segment testSeg = new Segment(point, new RealPoint(-100000, -100000));

            foreach (Segment s in Sides)
            {
                if (s.Contains(point))
                    return true;

                if (s.Cross(testSeg))
                {
                    List<RealPoint> cross = testSeg.GetCrossingPoints(s);
                    if(cross.Count > 0 && cross[0] != s.EndPoint) // Pour ne pas compter 2 fois un croisement sur un sommet, il sera déjà compté sur le Begin d'un autre
                        crossCount++;
                }
            }

            return (crossCount % 2 == 1);
        }

        /// <summary>
        /// Teste si le polygone courant contient le polygone donné
        /// </summary>
        /// <param name="polygon">Polygone testé</param>
        /// <returns>Vrai si le polygone contient le polygone donné</returns>
        protected bool Contains(Polygon polygon)
        {
            // Il suffit de contenir tous les segments du polygone testé
            foreach (Segment s in polygon.Sides)
            {
                if (!Contains(s))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Teste si le polygone courant contient le segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si le polygone contient le segment donné</returns>
        protected bool Contains(Segment segment)
        {
            // Il suffit de contenir les deux extrémités du segment et de ne jamais croiser le segment
            // À part si le croisement se fait sur une extremité

            bool result = false;

            if (Cross(segment))
            {
                // Si ça se croise : ça peut encore être les extremités qui touchent

                List<RealPoint> crossPoints = GetCrossingPoints(segment);
                if (crossPoints.Count > 2)
                {
                    // Plus de 2 croisements : le segment n'est pas contenu
                    result = false; 
                }
                else
                {
                    // Maximum 2 croisements : le segment est contenu si les 2 extremités et un point aléatoire du segment (genre le milieu) sont contenus
                    if(Contains(segment.StartPoint) && Contains(segment.EndPoint) && Contains(segment.Barycenter))
                        result = true;
                    else
                        result = false;
                }
            }
            else
            {
                // Pas de croisement, il suffit de contenir un point du segment
                result = Contains(segment.StartPoint);
            }

            return result;
        }

        /// <summary>
        /// Teste si le polygone courant contient la droite donnée
        /// </summary>
        /// <param name="line">Droite testée</param>
        /// <returns>Vrai si le polygone contient la droite donnée</returns>
        protected bool Contains(Line line)
        {
            // Un polygone ne peut pas contenir de droite
            return false;
        }

        /// <summary>
        /// Teste si le polygone courant contient le cercle donné
        /// </summary>
        /// <param name="circle">Cercle testé</param>
        /// <returns>Vrai si le polygone contient le cercle donné</returns>
        protected bool Contains(Circle circle)
        {
            // Pour contenir un cercle, un polygone ne doit pas le croiser et contenir son centre
            return !Cross(circle) && Contains(circle.Center);
        }

        #endregion

        #region Croisements

        /// <summary>
        /// Retourne la liste des points de croisement avec la forme donnée
        /// </summary>
        /// <param name="forme">Forme à tester</param>
        /// <returns>Liste des points de croisement</returns>
        public List<RealPoint> GetCrossingPoints(IShape shape)
        {
            List<RealPoint> output = new List<RealPoint>();

            _sides.ForEach(s => output.AddRange(s.GetCrossingPoints(shape)));
            
            return output;
        }

        /// <summary>
        /// Teste si le polygone courant croise la forme donnée
        /// </summary>
        /// <param name="shape">Forme testée</param>
        /// <returns>Vrai si le polygone croise la forme donnée</returns>
        public bool Cross(IShape shape)
        {
            // On teste si la forme croise un des cotés du polygone
            return _sides.Exists(s => s.Cross(shape));
        }

        #endregion

        #region Intersection
        
        /// <summary>
        /// Sépare un polygone en coupant les segments qui croisent un autre polygone
        /// </summary>
        /// <param name="origin">Le polygone a découper</param>
        /// <param name="cutter">Le polygone qui découpe</param>
        /// <returns>Le polygone d'origine dont les cotés sont coupés</returns>
        private List<Segment> Cut(Polygon origin, Polygon cutter)
        {
            List<Segment> segs = new List<Segment>();

            foreach (Segment seg in origin.Sides)
            {
                List<RealPoint> points = cutter.GetCrossingPoints(seg).OrderBy(p => p.Distance(seg.StartPoint)).ToList();
                
                if (points.Count != 0)
                {
                    points.Insert(0, seg.StartPoint);
                    points.Add(seg.EndPoint);

                    // Découpage du coté selon les points de croisement
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        if (points[i] != points[i + 1])
                            segs.Add(new Segment(points[i], points[i + 1]));
                    }
                }
                else
                {
                    // Si aucun croisement, ajout du coté tel quel
                    segs.Add(new Segment(seg.StartPoint, seg.EndPoint));
                }
            }
            return segs;
        }

        /// <summary>
        /// Retourne les polygones représentant l'intersection entre le polygone courant et le polygone donné
        /// </summary>
        /// <param name="other">Polygone avec lequel calculer l'intersection</param>
        /// <returns>Liste des polygones d'intersection</returns>
        public List<Polygon> Intersection(Polygon other)
        {
            List<Segment> segsMe = Cut(this, other);
            List<Segment> segsOther = Cut(other, this);

            // On supprime les segments qui ne sont pas dans les 2 polygones
            for (int i = segsMe.Count - 1; i >= 0; i--)
            {
                if (!other.Contains(segsMe[i]))
                    segsMe.RemoveAt(i);
            }

            for (int i = segsOther.Count - 1; i >= 0; i--)
            {
                if (!this.Contains(segsOther[i]))
                    segsOther.RemoveAt(i);
            }

            List<Segment> segs = new List<Segment>();
            segs.AddRange(segsMe);
            segs.AddRange(segsOther);

            return BuildPolygons(segs);
        }

        /// <summary>
        /// Crée une liste de polygone à partir d'une liste de segment.
        /// On cherche à rejoindre les début et fin de segment pour former les polygones.
        /// </summary>
        /// <param name="inputSegs">Segments à partir desquels contruire les polygones</param>
        /// <returns>Liste de polygones construits</returns>
        private List<Polygon> BuildPolygons(List<Segment> inputSegs)
        {
            List<Segment> currentSegs = new List<Segment>();
            List<Polygon> polygons = new List<Polygon>();
            
            while (inputSegs.Count != 0)
            {
                currentSegs.Add(inputSegs[0]);
                inputSegs.RemoveAt(0);
                
                bool polygonOpen = true;
                
                while (polygonOpen)
                {
                    for (int i = inputSegs.Count - 1; i >= 0; i--)
                    {
                        Segment seg = inputSegs[i];
                        inputSegs.RemoveAt(i);

                        if (currentSegs[currentSegs.Count - 1].EndPoint == seg.StartPoint)
                        {
                            // Le segment est la suite du polygone ...
                            if (currentSegs[0].StartPoint == seg.EndPoint)
                            {
                                // ... et le ferme : on a terminé un polygone
                                currentSegs.Add(seg);
                                polygons.Add(new Polygon(currentSegs));
                                currentSegs.Clear();
                                polygonOpen = false;
                                break;
                            }
                            else
                            {
                                // ... on l'ajoute
                                currentSegs.Add(seg);
                            }
                        }
                        else if (currentSegs[currentSegs.Count - 1].EndPoint == seg.EndPoint)
                        {
                            // Le segment à l'envers est la suite du polygone ...
                            if (currentSegs[0].StartPoint == seg.StartPoint)
                            {
                                // ... et le ferme : on le retourne et on a terminé un polygone
                                currentSegs.Add(new Segment(seg.EndPoint, seg.StartPoint));
                                polygons.Add(new Polygon(currentSegs));
                                currentSegs.Clear();
                                polygonOpen = false;
                                break;
                            }
                            else
                            {
                                // ... on le retourne et on l'ajoute
                                currentSegs.Add(new Segment(seg.EndPoint, seg.StartPoint));
                            }
                        }
                    }

                }
            }

            return polygons;

        }

        /// <summary>
        /// Calcule la liste des polygones résultant de l'intersection de tous les polygones donnés
        /// </summary>
        /// <param name="polygons">Polygones à intersecter</param>
        /// <returns>Intersections des polygones</returns>
        public static List<Polygon> Intersections(List<Polygon> polygons)
        {
            List<Polygon> currentIntersects = new List<Polygon>();
            List<Polygon> intersects = new List<Polygon>();

            if (polygons.Count >= 2)
            {
                intersects = polygons[0].Intersection(polygons[1]);

                for (int i = 2; i < polygons.Count; i++)
                {
                    currentIntersects.Clear();

                    foreach (Polygon p in intersects)
                        currentIntersects.AddRange(p.Intersection(polygons[i]));

                    intersects.Clear();
                    intersects.AddRange(currentIntersects);
                }
            }

            return intersects;
        }

        #endregion

        #region Transformations

        /// <summary>
        /// Retourne un polygone qui est translaté des distances données
        /// </summary>
        /// <param name="dx">Distance en X</param>
        /// <param name="dy">Distance en Y</param>
        /// <returns>Polygone translaté des distances données</returns>
        public Polygon Translation(double dx, double dy)
        {
            return new Polygon(Points.Select(p => p.Translation(dx, dy)));
        }

        /// <summary>
        /// Retourne un polygone qui est tourné de l'angle donné
        /// </summary>
        /// <param name="angle">Angle de rotation</param>
        /// <param name="rotationCenter">Centre de rotation, si null le barycentre est utilisé</param>
        /// <returns>Polygone tourné de l'angle donné</returns>
        public Polygon Rotation(AngleDelta angle, RealPoint rotationCenter = null)
        {
            if (rotationCenter == null) rotationCenter = Barycenter;

            return new Polygon(Points.Select(p => p.Rotation(angle, rotationCenter)));
        }

        /// <summary>
        /// Transforme le polygone en liste de triangle qui représentent la même surface.
        /// </summary>
        /// <returns>Liste de triangles équivalente au polygone</returns>
        public List<PolygonTriangle> ToTriangles()
        {
            List<PolygonTriangle> triangles = new List<PolygonTriangle>();
            List<RealPoint> points = new List<RealPoint>(Points);
            RealPoint p1, p2, p3;

            do
            {
                p1 = points[0];
                p2 = points[1];
                p3 = points[2];

                PolygonTriangle triangle = new PolygonTriangle(p1, p2, p3);
                if(this.Contains(triangle.Barycenter))
                {
                    triangles.Add(triangle);
                    points.Add(p1);
                    points.RemoveAt(1);
                    points.RemoveAt(0);
                }
                else
                {
                    points.Add(p1);
                    points.RemoveAt(0);
                }
            } while (points.Count >= 3);
            

            return triangles;
        }

        #endregion

        #region Peinture

        /// <summary>
        /// Dessine le polygone sur un Graphic
        /// </summary>
        /// <param name="g">Graphic sur lequel dessiner</param>
        /// <param name="outlineColor">Couleur du contour du polygone</param>
        /// <param name="outlineWidth">Epaisseur du contour</param>
        /// <param name="fillColor">Couleur de remplissage du polygone</param>
        /// <param name="scale">Echelle de conversion</param>
        public void Paint(Graphics g, Color outlineColor, int outlineWidth, Color fillColor, WorldScale scale)
        {
            if (Sides.Count == 0)
                return;

            Point[] listePoints = new Point[Sides.Count + 1];

            listePoints[0] = scale.RealToScreenPosition(Sides[0].StartPoint);

            for (int i = 0; i < Sides.Count; i++)
            {
                Segment s = Sides[i];
                listePoints[i] = scale.RealToScreenPosition(s.EndPoint);
            }

            listePoints[listePoints.Length - 1] = listePoints[0];
            
            if (fillColor != Color.Transparent)
                using (SolidBrush brush = new SolidBrush(fillColor))
                    g.FillPolygon(brush, listePoints, System.Drawing.Drawing2D.FillMode.Winding);

            if (outlineColor != Color.Transparent)
                using (Pen pen = new Pen(outlineColor, outlineWidth))
                    g.DrawPolygon(pen, listePoints);
        }

        #endregion
    }
}
