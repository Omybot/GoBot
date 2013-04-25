using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Calculs.Formes
{
    /// <summary>
    /// Droite avec une équation de la forme cy = ax + b
    /// Pour une droite standard, c = 1
    /// Pour une droite verticale, c = 0 et a = 1
    /// </summary>
    public class Droite : IForme
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
        public Droite(PointReel p1, PointReel p2)
        {
            calculEquation(p1, p2);
        }

        /// <summary>
        /// Calcule l'équation de la droite passant par deux points
        /// </summary>
        /// <param name="p1">Premier point</param>
        /// <param name="p2">Deuxième point</param>
        protected void calculEquation(PointReel p1, PointReel p2)
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

        #region Accesseurs

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

        #region Croisement

        /// <summary>
        /// Fonction testant si la forme donnée en paramètre croise la Droite actuelle
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Vrai si la forme croise la Droite courante</returns>
        public bool croise(IForme forme)
        {
            Type typeForme = forme.GetType();

            // Appel de la fonction en fonction du type

            if (typeForme.IsAssignableFrom(typeof(Droite)))
                return getCroisement((Droite)forme) != null;
            else if (typeForme.IsAssignableFrom(typeof(Segment)))
                return getCroisement((Segment)forme) != null;
            else if (typeForme.IsAssignableFrom(typeof(Polygone)))
                return forme.croise(this);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                return forme.croise(this);
            else if (typeForme.IsAssignableFrom(typeof(PointReel)))
                return contient(forme);
            else
                throw new NotImplementedException("Fonction inexistante : Croisement d'un(e) " + this.GetType().Name + " et d'un(e) " + typeForme.Name);
        }

        /// <summary>
        /// Retourne le point de croisement avec une autre Droite ou null si le croisement n'existe pas
        /// </summary>
        /// <param name="autreDroite">Droite croisant la droite actuelle</param>
        /// <returns>Point de croisement</returns>
        public PointReel getCroisement(Droite autreDroite)
        {
            double x, y;

            if (C == 0 && autreDroite.C == 0                             // Les deux droites sont verticales
                || A == 0 && autreDroite.A == 0                            // Les deux droites sont horizontales
                || (C == 1 && autreDroite.C == 1 && A == autreDroite.A))   // Les deux droites sont parrallèles
                return null;

            x = (autreDroite.B * C - autreDroite.C * B) / (autreDroite.C * A - autreDroite.A * C);
            y = (autreDroite.A * B - autreDroite.B * A) / (autreDroite.A * C - autreDroite.C * A);

            return new PointReel(x, y);
        }

        /// <summary>
        /// Retourne le point de croisement avec un Segment ou null si le croisement n'existe pas
        /// </summary>
        /// <param name="autreSegment"></param>
        /// <returns></returns>
        public PointReel getCroisement(Segment autreSegment)
        {
            // Vérifie de la même manière qu'une droite mais vérifie ensuite que le point appartient au segment
            PointReel croisement = getCroisement((Droite)autreSegment);

            if (croisement != null && autreSegment.contient(croisement))
                return croisement;
            else
                return null;
        }

        #endregion

        #region Contient

        /// <summary>
        /// Teste si la droite contient la forme donnée
        /// </summary>
        /// <param name="forme">Forme testés</param>
        /// <returns>Vrai si la Droite contient la forme donnée</returns>
        public bool contient(IForme forme)
        {
            Type typeForme = forme.GetType();

            // Appel de la bonne fonciton en fonction du type
            if (typeForme.IsAssignableFrom(typeof(Droite)))
                return contient((Droite)forme);
            else if (typeForme.IsAssignableFrom(typeof(Segment)))
                return contient((Segment)forme);
            else if (typeForme.IsAssignableFrom(typeof(Polygone)))
                return contient((Polygone)forme);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                return contient((Cercle)forme);
            else if (typeForme.IsAssignableFrom(typeof(PointReel)))
                return contient((PointReel)forme);
            else
                throw new NotImplementedException("Fonction inexistante : Contenance dans un(e) " + this.GetType().Name + " d'un(e) " + typeForme.Name);
        }

        /// <summary>
        /// Teste si la Droite courante contient le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Vrai si la Droite contient le PointReel donné</returns>
        protected bool contient(PointReel point)
        {
            // Vérifie si le point est sur la droite en vérifiant sa coordonnée Y pour sa coordonnée X par rapport à l'équation de la droite
            // J'arrondi à deux décimales sinon la précision est trop grande et on rejette des points à cause des arrondis

            double calc1 = point.X * A + B;
            double calc2 = point.Y * C;
            double difference = calc1 > calc2 ? calc1 - calc2 : calc2 - calc1;
            if (difference <= PointReel.PRECISION)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Teste si la Droite courante contient le Segment donné
        /// </summary>
        /// <param name="point">Segment testé</param>
        /// <returns>Vrai si la Droite contient le Segment donné</returns>
        protected bool contient(Segment segment)
        {
            // Contenir un Segment revient à contenir la Droite sur laquelle se trouve le Segment
            return contient((Droite)segment);
        }

        /// <summary>
        /// Teste si la Droite courante contient la Droite donnée
        /// </summary>
        /// <param name="point">Droite testée</param>
        /// <returns>Vrai si la Droite contient le PointReel donné</returns>
        protected bool contient(Droite droite)
        {
            // Contenir une droite revient à avoir la même équation
            if (droite.A == A && droite.B == B && droite.C == C)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Teste si la Droite courante contient le Polygone donné
        /// </summary>
        /// <param name="point">Polygone testé</param>
        /// <returns>Vrai si la Droite contient le Polygone donné</returns>
        protected bool contient(Polygone polygone)
        {
            // Contenir un polygone revient à contenir tous les cotés du polygone
            foreach (Segment s in polygone.Cotes)
                if (!contient(s))
                    return false;

            return true;
        }

        /// <summary>
        /// Teste si la Droite courante contient le Cercle donné
        /// </summary>
        /// <param name="point">Cercle testé</param>
        /// <returns>Vrai si la Droite contient le Cercle donné</returns>
        protected bool contient(Cercle Cercle)
        {
            // Une droite ne peut contenir un Cercle que si son centre est sur la Droite et que son rayon est de 0
            return (Cercle.Rayon == 0 && contient(Cercle.Centre));
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimale entre la Droite courante et la Forme donnée
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Distance minimale</returns>
        public double Distance(IForme forme)
        {
            Type typeForme = forme.GetType();

            if (typeForme.IsAssignableFrom(typeof(Segment)))
                return Distance((Segment)forme);
            else if (typeForme.IsAssignableFrom(typeof(PointReel)))
                return Distance((PointReel)forme);
            else if (typeForme.IsAssignableFrom(typeof(Droite)))
                return Distance((Droite)forme);
            else if (typeForme.IsAssignableFrom(typeof(Polygone)))
                return Distance((Polygone)forme);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                return Distance((Cercle)forme);
            else
                throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne la distance minimale entre la Droite courante et le Segment donné
        /// </summary>
        /// <param name="forme">Segment testé</param>
        /// <returns>Distance minimale</returns>
        public double Distance(Segment segment)
        {
            // Le segment sait le faire
            return segment.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre la Droite courante et la Droite donnée
        /// </summary>
        /// <param name="forme">Droite testée</param>
        /// <returns>Distance minimale</returns>
        public double Distance(Droite droite)
        {
            // Si les droites se croisent la distance est de 0
            if (croise(droite))
                return 0;

            // Sinon elles sont parrallèles et la distance entre elles est la distance entre les deux interesections :
            // - D'une perpendiculaire et la première droite
            // - De la même perpendiculaire et la deuxième droite

            Droite perpendiculaire = getPerpendiculaire(new PointReel(0, 0));

            PointReel p1 = getCroisement(perpendiculaire);
            PointReel p2 = getCroisement(perpendiculaire);

            return p1.Distance(p2);
        }

        /// <summary>
        /// Retourne la distance minimale entre la Droite courante et le Cercle donné
        /// </summary>
        /// <param name="forme">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        public double Distance(Cercle Cercle)
        {
            // Distance jusqu'au centre du cercle - son rayon
            return Distance(Cercle.Centre) - Cercle.Rayon;
        }

        /// <summary>
        /// Retourne la distance minimale entre la Droite courante et le Polygone donné
        /// </summary>
        /// <param name="forme">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        public double Distance(Polygone polygone)
        {
            // Distance jusqu'au segment le plus proche
            double minDistance = double.MaxValue;

            foreach (Segment s in polygone.Cotes)
                minDistance = Math.Min(s.Distance(this), minDistance);

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre la Droite courante et le PointReel donné
        /// </summary>
        /// <param name="forme">PointReel testé</param>
        /// <returns>Distance minimale</returns>
        public double Distance(PointReel point)
        {
            // Pour calculer la distance, on calcule la droite perpendiculaire passant par ce point
            // Puis on calcule l'intersection de la droite et de sa perpendiculaire
            // On obtient la de projection orthogonale du point, qui est le point de la droite le plus proche du point
            // On retourne la distance entre ces deux points

            Droite perpendiculaire = getPerpendiculaire(point);
            PointReel intersection = getCroisement(perpendiculaire);

            double distance = point.Distance(intersection);

            return distance;
        }

        #endregion
        
        /// <summary>
        /// Retourne l'équation de la droite perpendiculaire à celle-ci et passant par un point donné
        /// </summary>
        /// <param name="point">Point contenu par la perpendiculaire recherchée</param>
        /// <returns>Equation de la droite perpendiculaire à celle-ci et passant par le point donné</returns>
        public Droite getPerpendiculaire(PointReel point)
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
    }
}
