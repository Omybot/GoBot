using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.Calculs.Formes
{
    /// <summary>
    /// Droite avec une équation de la forme cy = ax + b
    /// Pour une droite standard, c = 1
    /// Pour une droite verticale, c = 0 et a = 1
    /// </summary>
    public class Droite : IForme, IModifiable<Droite>
    {
        #region Attributs

        protected double a, b, c;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut y = 0
        /// </summary>
        public Droite()
        {
            a = 0;
            b = 0;
            c = 1;
        }

        /// <summary>
        /// Constructeur type cy = ax + b
        /// </summary>
        /// <param name="_a">A</param>
        /// <param name="_b">B</param>
        /// <param name="_c">C</param>
        public Droite(double _a, double _b, double _c = 1)
        {
            a = _a;
            b = _b;
            c = _c;
        }

        /// <summary>
        /// Construit la droite passant par deux points
        /// </summary>
        /// <param name="p1">Premier point</param>
        /// <param name="p2">Deuxième point</param>
        public Droite(RealPoint p1, RealPoint p2)
        {
            calculEquation(p1, p2);
        }

        /// <summary>
        /// Construit la Droite à partir d'une autre Droite
        /// </summary>
        /// <param name="droite">Droite à copier</param>
        public Droite(Droite droite)
        {
            a = droite.A;
            b = droite.B;
            c = droite.C;
        }

        /// <summary>
        /// Contruit la Droite à partir d'une liste de points en interpolation.
        /// Régression linéaire par la méthode des moindres carrés.
        /// </summary>
        /// <param name="points">Liste des points qui génèrent la droite</param>
        public Droite(List<RealPoint> points)
        {
            double xMoy, yMoy, sum1, sum2;

            sum1 = 0;
            sum2 = 0;
            xMoy = points.Average(p => p.X);
            yMoy = points.Average(p => p.Y);

            for (int i = 0; i < points.Count; i++)
            {
                sum1 += (points[i].X - xMoy) * (points[i].Y - yMoy);
                sum2 += (points[i].X - xMoy) * (points[i].X - xMoy);
            }

            if (sum2 == 0)
            {
                // Droite verticale
                a = 0;
                b = -points[0].X;
                c = 0;
            }
            else
            {
                a = sum1 / sum2;
                b = yMoy - a * xMoy;
                c = 1;
            }
        }

        /// <summary>
        /// Calcule l'équation de la droite passant par deux points
        /// </summary>
        /// <param name="p1">Premier point</param>
        /// <param name="p2">Deuxième point</param>
        protected void calculEquation(RealPoint p1, RealPoint p2)
        {
            if (p2.X - p1.X == 0)
            {
                a = 1;
                b = -p1.X;
                c = 0;
            }
            else
            {
                a = (p2.Y - p1.Y) / (p2.X - p1.X);
                b = -(a * p1.X - p1.Y);
                c = 1;
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
                return a;
            }
        }

        /// <summary>
        /// Accesseur sur le paramètre B de la droite sous la forme cy = ax + b
        /// </summary>
        public double B
        {
            get
            {
                return b;
            }
        }

        /// <summary>
        /// Accesseur sur le paramètre C de la droite sous la forme cy = ax + b
        /// </summary>
        public double C
        {
            get
            {
                return c;
            }
        }

        /// <summary>
        /// Surface de la Droite
        /// </summary>
        public virtual double Surface
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Barycentre de la Droite
        /// </summary>
        public virtual RealPoint BaryCentre
        {
            get
            {
                return new RealPoint(0, 0); // Arbitraire
            }
        }

        #endregion

        #region Opérateurs & Surcharges

        public static bool operator ==(Droite a, Droite b)
        {
            if ((object)a == null || (object)b == null)
                return (object)a == null && (object)b == null;
            else
                return a.A == b.A
                    && a.B == b.B
                    && a.C == a.C;
        }

        public static bool operator !=(Droite a, Droite b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            Droite p = obj as Droite;
            if ((Object)p == null)
            {
                return false;
            }

            return (Droite)obj == this;
        }

        public override int GetHashCode()
        {
            return (int)a ^ (int)b ^ (int)c;
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
            String chaineC = C != 1 ? C + "" : "";
            String chaineA = A != 1 ? A + "" : "";
            if (C == 0)
                return "x = " + (-B);
            else if (A == 0)
                return chaineC + "y = " + B;
            else if (B == 0)
                return chaineC + "y = " + chaineA + "x";
            else
                return chaineC + "y = " + chaineA + "x + " + B;
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimale entre la Droite et la IForme donnée
        /// </summary>
        /// <param name="forme">IForme testée</param>
        /// <returns>Distance minimale</returns>
        public double Distance(IForme forme)
        {
            return Distance(Util.ToRealType(forme));
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
        /// <param name="droite">Droite testée</param>
        /// <returns>Distance minimale</returns>
        protected virtual double Distance(Droite droite)
        {
            // Si les droites se croisent la distance est de 0
            if (Croise(droite))
                return 0;

            // Sinon elles sont parrallèles et la distance entre elles est la distance entre les deux interesections :
            // - D'une perpendiculaire et la première droite
            // - De la même perpendiculaire et la deuxième droite

            Droite perpendiculaire = GetPerpendiculaire(new RealPoint(0, 0));

            RealPoint p1 = getCroisement(perpendiculaire);
            RealPoint p2 = getCroisement(perpendiculaire);

            return p1.Distance(p2);
        }

        /// <summary>
        /// Retourne la distance minimale entre la Droite et le Cercle donné
        /// </summary>
        /// <param name="cercle">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        protected virtual double Distance(Cercle cercle)
        {
            // Distance jusqu'au centre du cercle - son rayon
            return Distance(cercle.Centre) - cercle.Rayon;
        }

        /// <summary>
        /// Retourne la distance minimale entre la Droite et le Polygone donné
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        protected virtual double Distance(Polygone polygone)
        {
            // Distance jusqu'au segment le plus proche
            double minDistance = double.MaxValue;

            foreach (Segment s in polygone.Cotes)
                minDistance = Math.Min(s.Distance(this), minDistance);

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre la Droite et le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Distance minimale</returns>
        protected virtual double Distance(RealPoint point)
        {
            // Pour calculer la distance, on calcule la droite perpendiculaire passant par ce point
            // Puis on calcule l'intersection de la droite et de sa perpendiculaire
            // On obtient la de projection orthogonale du point, qui est le point de la droite le plus proche du point
            // On retourne la distance entre ces deux points

            Droite perpendiculaire = GetPerpendiculaire(point);
            RealPoint intersection = getCroisement(perpendiculaire);

            double distance = point.Distance(intersection);

            return distance;
        }

        #endregion
        
        #region Contient
        
        /// <summary>
        /// Teste si la Droite contient la IForme donnée
        /// </summary>
        /// <param name="forme">IForme testée</param>
        /// <returns>Vrai si la Droite contient la IForme donnée</returns>
        public virtual bool Contient(IForme forme)
        {
            return Contient(Util.ToRealType(forme));
        }

        /// <summary>
        /// Teste si la Droite contient le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Vrai si la Droite contient le PointReel donné</returns>
        protected virtual bool Contient(RealPoint point)
        {
            // Vérifie si le point est sur la droite en vérifiant sa coordonnée Y pour sa coordonnée X par rapport à l'équation de la droite
            // J'arrondi à deux décimales sinon la précision est trop grande et on rejette des points à cause des arrondis

            double calc1 = point.X * A + B;
            double calc2 = point.Y * C;
            double difference = calc1 > calc2 ? calc1 - calc2 : calc2 - calc1;
            if (difference <= RealPoint.PRECISION)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Teste si la Droite contient le Segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si la Droite contient le Segment donné</returns>
        protected virtual bool Contient(Segment segment)
        {
            // Contenir un Segment revient à contenir la Droite sur laquelle se trouve le Segment
            return Contient((Droite)segment);
        }

        /// <summary>
        /// Teste si la Droite courante contient la Droite donnée
        /// </summary>
        /// <param name="droite">Droite testée</param>
        /// <returns>Vrai si la Droite contient la Droite donnée</returns>
        protected virtual bool Contient(Droite droite)
        {
            // Contenir une droite revient à avoir la même équation
            if (droite == this)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Teste si la Droite contient le Polygone donné
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Vrai si la Droite contient le Polygone donné</returns>
        protected virtual bool Contient(Polygone polygone)
        {
            // Contenir un polygone revient à contenir tous les cotés du polygone
            foreach (Segment s in polygone.Cotes)
                if (!Contient(s))
                    return false;

            return true;
        }

        /// <summary>
        /// Teste si la Droite contient le Cercle donné
        /// </summary>
        /// <param name="cercle">Cercle testé</param>
        /// <returns>Vrai si la Droite contient le Cercle donné</returns>
        protected virtual bool Contient(Cercle cercle)
        {
            // Une droite ne peut contenir un Cercle que si son centre est sur la Droite et que son rayon est de 0
            return (cercle.Rayon == 0 && Contient(cercle.Centre));
        }

        #endregion

        #region Croisement
        public virtual List<RealPoint> Croisements(IForme forme)
        {
            // TODOFORMES
            return null;
        }

        /// <summary>
        /// Teste si la Droite croise la IForme donnée
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Vrai si droite croise la IForme testée</returns>
        public virtual bool Croise(IForme forme)
        {
            return Croise(Util.ToRealType(forme));
        }

        protected virtual bool Croise(Droite droite)
        {
            return getCroisement(droite) != null;
        }

        protected virtual bool Croise(Segment segment)
        {
            return getCroisement(segment) != null;
        }

        protected virtual bool Croise(Polygone polygone)
        {
            // Le polygone sait faire ça
            return polygone.Croise(this);
        }

        protected virtual bool Croise(Cercle cercle)
        {
            // Le cercle sait faire ça
            return cercle.Croise(this);
        }

        protected virtual bool Croise(RealPoint point)
        {
            return Contient(point);
        }

        /// <summary>
        /// Retourne le point de croisement avec une autre Droite ou null si le croisement n'existe pas
        /// </summary>
        /// <param name="autreDroite">Droite croisant la droite actuelle</param>
        /// <returns>Point de croisement</returns>
        public RealPoint getCroisement(Droite autreDroite)
        {
            double x, y;

            if (C == 0 && autreDroite.C == 0                             // Les deux droites sont verticales
                || A == 0 && autreDroite.A == 0                            // Les deux droites sont horizontales
                || (C == 1 && autreDroite.C == 1 && A == autreDroite.A))   // Les deux droites sont parallèles
                return null;

            x = (autreDroite.B * C - autreDroite.C * B) / (autreDroite.C * A - autreDroite.A * C);
            y = (autreDroite.A * B - autreDroite.B * A) / (autreDroite.A * C - autreDroite.C * A);

            return new RealPoint(x, y);
        }

        /// <summary>
        /// Retourne le point de croisement avec un Segment ou null si le croisement n'existe pas
        /// </summary>
        /// <param name="autreSegment"></param>
        /// <returns></returns>
        public RealPoint getCroisement(Segment autreSegment)
        {
            // Vérifie de la même manière qu'une droite mais vérifie ensuite que le point appartient au segment
            RealPoint croisement = getCroisement((Droite)autreSegment);

            if (croisement != null && autreSegment.Contient(croisement))
                return croisement;
            else
                return null;
        }

        #endregion
        
        #region Transformations

        public Droite Translation(double dx, double dy)
        {
            return new Droite(a, b + dx + dy, c);
        }

        public Droite Rotation(Angle angle, RealPoint centreRotation = null)
        {
            RealPoint p1, p2;

            if(centreRotation == null)
                centreRotation = BaryCentre;

            if(c == 1)
            {
                p1 = new RealPoint(0, a * 0 + b);
                p2 = new RealPoint(1, a * 1 + b);

                p1 = p1.Rotation(angle, centreRotation);
                p2 = p2.Rotation(angle, centreRotation);
            }
            else
            {
                p1 = new RealPoint(b, 0);
                p2 = new RealPoint(b, 1);
            }

            return new Droite(p1, p2);
        }

        #endregion
        
        /// <summary>
        /// Retourne l'équation de la droite perpendiculaire à celle-ci et passant par un point donné
        /// </summary>
        /// <param name="point">Point contenu par la perpendiculaire recherchée</param>
        /// <returns>Equation de la droite perpendiculaire à celle-ci et passant par le point donné</returns>
        public Droite GetPerpendiculaire(RealPoint point)
        {
            // Si je suis une droite verticale, je retourne l'horizontale qui passe par le point
            if (C == 0)
                return new Droite(0, point.Y);

            // Si je suis une droite horizontale, je retourne la verticale qui passe par le point
            else if (A == 0)
                return new Droite(1, -point.X, 0);

            // Si je suis une droite banale, je calcule
            else
            {
                double newA = -1 / a;
                double newB = -newA * point.X + point.Y;

                return new Droite(newA, newB);
            }
        }


        #region Peinture

        public virtual void Paint(Graphics g, Color outlineColor, int outlineWidth, Color fillColor, WorldScale scale)
        {
            // Un peu douteux mais bon
            RealPoint p1 = getCroisement(new Droite(new RealPoint(-10000, -10000), new RealPoint(-10001, 10000)));
            RealPoint p2 = getCroisement(new Droite(new RealPoint(10000, -10000), new RealPoint(10001, 10000)));

            if (p1 == null || p2 == null)
            {
                p1 = getCroisement(new Droite(new RealPoint(-10000, -10000), new RealPoint(10000, -10001)));
                p2 = getCroisement(new Droite(new RealPoint(10000, 10000), new RealPoint(-10000, 10001)));
            }

            if (p1 != null && p2 != null)
                new Segment(p1, p2).Paint(g, outlineColor, outlineWidth, fillColor, scale);
        }

        #endregion
    }
}
