using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot.Calculs.Formes
{
    public class PointReel : IForme, IModifiable<PointReel>
    {
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
        /// Constructeur par copie
        /// </summary>
        public PointReel(PointReel other)
        {
            posX = other.posX;
            posY = other.posY;
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

        #region Propriétés

        /// <summary>
        /// Obtient la position sur l'axe des abscisses
        /// </summary>
        public double X
        {
            get
            {
                return posX;
            }
            set
            {
                posX = value;
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
            set
            {
                posY = value;
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
        public PointReel BaryCentre
        {
            get
            {
                return new PointReel(this);
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

        public static implicit operator Point(PointReel point)
        {
            return new Point((int)point.X, (int)point.Y);
        }

        public static implicit operator PointReel(Point point)
        {
            return new PointReel(point.X, point.Y);
        }

        public static implicit operator PointF(PointReel point)
        {
            return new PointF((float)point.X, (float)point.Y);
        }

        #endregion

        #region Distance
        
        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et la IForme donnée
        /// </summary>
        /// <param name="forme">IForme testée</param>
        /// <returns>Distance minimale</returns>
        public double Distance(IForme forme)
        {
            return Distance(Util.ToRealType(forme));
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
        /// <param name="droite">Droite testée</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Droite droite)
        {
            // La droite sait le faire
            return droite.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le Cercle donné
        /// </summary>
        /// <param name="cercle">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Cercle cercle)
        {
            // Distance jusqu'au centre du cercle - son rayon
            return Distance(cercle.Centre) - cercle.Rayon;
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le Polygone donné
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Polygone polygone)
        {
            // Distance jusqu'au segment le plus proche
            double minDistance = double.MaxValue;

            foreach (Segment s in polygone.Cotes)
                minDistance = Math.Min(s.Distance(this), minDistance);

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le PointReel courant et le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(PointReel point)
        {
            // Formule de collège \o/
            return Math.Sqrt((X - point.X) * (X - point.X) + (Y - point.Y) * (Y - point.Y));
        }

        #endregion

        #region Contient
        
        /// <summary>
        /// Teste si le PointReel contient la IForme donnée
        /// </summary>
        /// <param name="forme">IForme testée</param>
        /// <returns>Vrai si le PointReel contient la IForme testée</returns>
        public bool Contient(IForme forme)
        {
            // La seule chose qu'un point peut contenir, c'est un point identique à lui même
            if (forme is PointReel)
                return (PointReel)forme == this;

            return false;
        }

        #endregion

        #region Croisement

        /// <summary>
        /// Teste si le PointReel courant croise la IForme donnée
        /// Pour un PointReel, on dit qu'il croise s'il se trouve sur le contour de la forme avec une marge de <c>PRECISION</c>
        /// </summary>
        /// <param name="forme">IForme testés</param>
        /// <returns>Vrai si le PointReel courant croise la IForme donnée</returns>
        public bool Croise(IForme forme)
        {
            return getCroisement(Util.ToRealType(forme)) != null;
        }

        public List<PointReel> Croisements(IForme forme)
        {
            // TODOFORMES
            return null;
        }

        /// <summary>
        /// Retourne le PointReel si il est sur le Segment donné avec une marge de <c>PRECISION</c>, sinon null
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Le PointReel lui même si il est sur le Segment, sinon null</returns>
        public PointReel getCroisement(Segment segment)
        {
            if (segment.Contient(this))
                return this;
            else
                return null;
        }

        /// <summary>
        /// Retourne le PointReel si il est sur le PointReel donné avec une marge de <c>PRECISION</c>, sinon null
        /// </summary>
        /// <param name="point">point testé</param>
        /// <returns>Le PointReel lui même si il est sur le PointReel, sinon null</returns>
        public PointReel getCroisement(PointReel point)
        {
            if (point.X == X && point.Y == Y)
                return this;
            else
                return null;
        }

        /// <summary>
        /// Retourne le PointReel si il est sur la Droite donnée avec une marge de <c>PRECISION</c>, sinon null
        /// </summary>
        /// <param name="droite">Droite testée</param>
        /// <returns>Le PointReel lui même si il est sur la Droite, sinon null</returns>
        public PointReel getCroisement(Droite droite)
        {
            if (droite.Contient(this))
                return this;
            else
                return null;
        }

        /// <summary>
        /// Retourne le PointReel si il est sur le Polygone donné avec une marge de <c>PRECISION</c>, sinon null
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Le PointReel lui même si il est sur le Polygone, sinon null</returns>
        public PointReel getCroisement(Polygone polygone)
        {
            if (polygone.Contient(this))
                return this;
            else
                return null;
        }

        /// <summary>
        /// Retourne le PointReel si il est sur le Cercle donné avec une marge de <c>PRECISION</c>, sinon null
        /// </summary>
        /// <param name="cercle">Cercle testé</param>
        /// <returns>Le PointReel lui même si il est sur le Cercle, sinon null</returns>
        public PointReel getCroisement(Cercle cercle)
        {
            if (cercle.Contient(this))
                return this;
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
        public void Placer(double x, double y)
        {
            posX = x;
            posY = y;
        }

        /// <summary>
        /// Affecte les coordonnées passées en paramètre
        /// </summary>
        /// <param name="x">Abscisse</param>
        /// <param name="y">Ordonnée</param>
        public void Placer(PointReel pos)
        {
            posX = pos.X;
            posY = pos.Y;
        }

        public PointReel Translation(double dx, double dy)
        {
            return new PointReel(posX + dx, posY + dy);
        }

        public PointReel Rotation(Angle angle, PointReel centreRotation = null)
        {
            PointReel nouvelleCoordonnee = new PointReel();
            nouvelleCoordonnee.X = centreRotation.X + Math.Cos(angle.AngleRadians) * (this.X - centreRotation.X) - Math.Sin(angle.AngleRadians) * (this.Y - centreRotation.Y);
            nouvelleCoordonnee.Y = centreRotation.Y + Math.Cos(angle.AngleRadians) * (this.Y - centreRotation.Y) + Math.Sin(angle.AngleRadians) * (this.X - centreRotation.X);
            return nouvelleCoordonnee;
        }

        #endregion

        #region Peinture

        public void Paint(Graphics g, Color outlineColor, int outlineWidth, Color fillColor, PaintScale scale)
        {
            Point screenPos = scale.RealToScreenPosition(this);

            Rectangle rect = new Rectangle(screenPos.X - outlineWidth, screenPos.Y - outlineWidth, outlineWidth*2, outlineWidth*2);

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
