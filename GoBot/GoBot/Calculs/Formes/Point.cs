using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot.Calculs.Formes
{
    public class PointReel : GoBot.Calculs.Formes.IForme
    {
        // TODO commentaires
        public const double PRECISION = 0.01;

        #region Attributs

        /// <summary>
        /// Position sur l'axe des abscisses
        /// </summary>
        private double posX;

        /// <summary>
        /// Position sur l'axe des ordonnées
        /// </summary>
        private double posY;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut, les coordonnées seront (0, 0)
        /// </summary>
        public PointReel()
        {
            posX = 0;
            posY = 0;
        }

        /// <summary>
        /// Construit des coordonnées selon x et y
        /// </summary>
        /// <param name="x">Abscisse</param>
        /// <param name="y">Ordonnée</param>
        public PointReel(double x, double y)
        {
            posX = x;
            posY = y;
        }

        #endregion

        #region Accesseurs

        /// <summary>
        /// Obtient la position sur l'axe des abscisses
        /// </summary>
        public double X
        {
            get
            {
                return posX;
            }
        }

        /// <summary>
        /// Obtient la coordonnée sur l'axe des ordonnées
        /// </summary>
        public double Y
        {
            get
            {
                return posY;
            }
        }

        #endregion

        #region Opérateurs & Surcharges

        public static bool operator ==(PointReel a, PointReel b)
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

        public static bool operator !=(PointReel a, PointReel b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return "{" + Math.Round(X, 2) + " : " + Math.Round(Y, 2) + "}";
        }

        public override bool Equals(object obj)
        {
            PointReel p = obj as PointReel;
            if ((Object)p == null)
            {
                return false;
            }

            return (PointReel)obj == this;
        }

        public override int GetHashCode()
        {
            return (int)X ^ (int)Y;
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et la Forme donnée
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Distance minimale</returns>
        public double getDistance(IForme forme)
        {
            Type typeForme = forme.GetType();

            if (typeForme.IsAssignableFrom(typeof(Segment)))
                return getDistance((Segment)forme);
            else if (typeForme.IsAssignableFrom(typeof(PointReel)))
                return getDistance((PointReel)forme);
            else if (typeForme.IsAssignableFrom(typeof(Droite)))
                return getDistance((Droite)forme);
            else if (typeForme.IsAssignableFrom(typeof(Polygone)))
                return getDistance((Polygone)forme);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                return getDistance((Cercle)forme);
            else
                throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le Segment donné
        /// </summary>
        /// <param name="forme">Segment testé</param>
        /// <returns>Distance minimale</returns>
        public double getDistance(Segment segment)
        {
            // Le segment sait le faire
            return segment.getDistance(this);
        }
        
        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et la Droite donnée
        /// </summary>
        /// <param name="forme">Droite testée</param>
        /// <returns>Distance minimale</returns>
        public double getDistance(Droite droite)
        {
            // La droite sait le faire
            return droite.getDistance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le Cercle donné
        /// </summary>
        /// <param name="forme">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        public double getDistance(Cercle Cercle)
        {
            // Distance jusqu'au centre du cercle - son rayon
            return getDistance(Cercle.Centre) - Cercle.Rayon;
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le Polygone donné
        /// </summary>
        /// <param name="forme">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        public double getDistance(Polygone polygone)
        {
            // Distance jusqu'au segment le plus proche
            double minDistance = double.MaxValue;

            foreach (Segment s in polygone.Cotes)
                minDistance = Math.Min(s.getDistance(this), minDistance);

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le PointReel donné
        /// </summary>
        /// <param name="forme">PointReel testé</param>
        /// <returns>Distance minimale</returns>
        public double getDistance(PointReel autrePoint)
        {
            // Formule de collège \o/
            return Math.Sqrt((X - autrePoint.X) * (X - autrePoint.X) + (Y - autrePoint.Y) * (Y - autrePoint.Y));
        }

        #endregion

        #region Croisement

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forme"></param>
        /// <returns></returns>
        public bool croise(IForme forme)
        {
            Type typeForme = forme.GetType();

            if (typeForme.IsAssignableFrom(typeof(Segment)))
                return getCroisement((Segment)forme) != null;
            else if (typeForme.IsAssignableFrom(typeof(PointReel)))
                return getCroisement((PointReel)forme) != null;
            else if (typeForme.IsAssignableFrom(typeof(Droite)))
                return getCroisement((Droite)forme) != null;
            else if (typeForme.IsAssignableFrom(typeof(Polygone)))
                return forme.croise(this);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                return forme.croise(this);
            else
                throw new NotImplementedException();
        }

        public PointReel getCroisement(Segment segment)
        {
            if (segment.contient(this))
                return this;
            else
                return null;
        }

        public PointReel getCroisement(PointReel point)
        {
            if (point.X == X && point.Y == Y)
                return this;
            else
                return null;
        }

        public PointReel getCroisement(Droite droite)
        {
            if (droite.contient(this))
                return this;
            else
                return null;
        }

        public PointReel getCroisement(Polygone polygone)
        {
            if (polygone.contient(this))
                return this;
            else
                return null;
        }

        public PointReel getCroisement(Cercle Cercle)
        {
            if (Cercle.contient(this))
                return this;
            else
                return null;
        }

        #endregion

        #region Contient

        public bool contient(IForme forme)
        {
            Type typeForme = forme.GetType();

            if (typeForme.IsAssignableFrom(typeof(PointReel)))
                return (PointReel)forme == this;

            return false;
        }

        #endregion

        /// <summary>
        /// Affecte les coordonnées passées en paramètre
        /// </summary>
        /// <param name="x">Abscisse</param>
        /// <param name="y">Ordonnée</param>
        public void allerA(double x, double y)
        {
            posX = x;
            posY = y;
        }

        /// <summary>
        /// Déplace les coordonnées par rapport aux anciennes coordonnées
        /// </summary>
        /// <param name="x">Déplacement sur l'axe des abscisses</param>
        /// <param name="y">Déplacement sur l'axe des ordonnées</param>
        public void deplacer(double x, double y)
        {
            posX += x;
            posY += y;
        }

    }
}
