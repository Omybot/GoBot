using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.Calculs.Formes
{
    // Un segment est une Droite avec deux extrémités
    public class Segment : Droite, IModifiable<Segment>
    {
        #region Attributs

        protected RealPoint pointDebut, pointFin;

        #endregion

        #region Constructeurs

        public Segment(RealPoint debut, RealPoint fin)
        {
            pointDebut = debut;
            pointFin = fin;

            calculEquation(Debut, Fin);
        }

        public Segment(Segment segment)
        {
            pointDebut = new RealPoint(segment.Debut);
            pointFin = new RealPoint(segment.Fin);

            a = segment.A;
            b = segment.B;
            c = segment.C;
            calculEquation(Debut, Fin);
        }

        #endregion

        #region Propriétés

        public RealPoint Debut
        {
            get
            {
                return pointDebut;
            }
            set
            {
                pointDebut = value;
                calculEquation(Debut, Fin);
            }
        }

        public RealPoint Fin
        {
            get
            {
                return pointFin;
            }
            set
            {
                pointFin = value;
                calculEquation(Debut, Fin);
            }
        }

        public Double Longueur
        {
            get
            {
                return Debut.Distance(Fin);
            }
        }

        /// <summary>
        /// Surface du Segment
        /// </summary>
        public override double Surface
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Barycentre du Segment
        /// </summary>
        public override RealPoint BaryCentre
        {
            get
            {
                return new RealPoint((pointDebut.X + pointFin.X) / 2, (pointDebut.Y + pointFin.Y) / 2);
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
                    && a.Debut == b.Debut
                    && a.Fin == b.Debut;
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
            return (int)Debut.X ^ (int)Debut.Y ^ (int)Fin.X ^ (int)Fin.Y;
        }

        public override string ToString()
        {
            return Debut + " -> " + Fin + " / " + base.ToString();
        }

        #endregion

        #region Croisements

        public override List<RealPoint> Croisements(IForme forme)
        {
            Cercle c = forme as Cercle;
            if (c != null)
                return Croisements(c);

            return null;
        }

        public List<RealPoint> Croisements(Cercle cercle)
        {
            List<RealPoint> intersectsPoints = null;
	        double dx = pointFin.X - pointDebut.X;
            double dy = pointFin.Y - pointDebut.Y;
            double Ox = pointDebut.X - cercle.Centre.X;
            double Oy = pointDebut.Y - cercle.Centre.Y;
            double A = dx * dx + dy * dy;
            double B = 2 * (dx * Ox + dy * Oy);
            double C = Ox * Ox + Oy * Oy - cercle.Rayon * cercle.Rayon;
            double delta = B * B - 4 * A * C;

	        if (delta < 0 + double.Epsilon && delta > 0 - double.Epsilon)
	        {
                intersectsPoints = new List<RealPoint>();
                double t = -B / (2 * A);
		        if (t >= 0 && t <= 1)
                    intersectsPoints.Add(new RealPoint(pointDebut.X + t * dx, pointDebut.Y + t * dy));
	        }
	        if (delta > 0)
	        {
                intersectsPoints = new List<RealPoint>();
                double t1 = (double)((-B - Math.Sqrt(delta)) / (2 * A));
                double t2 = (double)((-B + Math.Sqrt(delta)) / (2 * A));
		        if (t1 >= 0 && t1 <= 1)
                    intersectsPoints.Add(new RealPoint(pointDebut.X + t1 * dx, pointDebut.Y + t1 * dy));
		        if (t2 >= 0 && t2 <= 1)
                    intersectsPoints.Add(new RealPoint(pointDebut.X + t2 * dx, pointDebut.Y + t2 * dy));
	        }
	        return intersectsPoints;
        }

        /// <summary>
        /// Teste si le Segment croise la IForme donnée
        /// </summary>
        /// <param name="forme">IForme testé</param>
        /// <returns>Vrai si le Segment contient la IForme donnée</returns>
        public override bool Croise(IForme forme)
        {
            return Croise(Util.ToRealType(forme));
        }

        /// <summary>
        /// Teste si la Droite croise le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Vrai si la Droite contient le PointReel donné</returns>
        protected override bool Croise(RealPoint point)
        {
            return Contient(point);
        }

        /// <summary>
        /// Teste si la Droite croise le Segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si la Droite contient le Segment donné</returns>
        protected override bool Croise(Segment segment)
        {
            return getCroisement(segment) != null;
        }

        /// <summary>
        /// Teste si la Droite croise la Droite donnée
        /// </summary>
        /// <param name="droite">Droite testée</param>
        /// <returns>Vrai si la Droite contient la Droite donnée</returns>
        protected override bool Croise(Droite droite)
        {
            return getCroisement(droite) != null;
        }

        /// <summary>
        /// Teste si la Droite croise le Cercle donné
        /// </summary>
        /// <param name="cercle">Cercle testé</param>
        /// <returns>Vrai si la Droite contient le Cercle donné</returns>
        protected override bool Croise(Cercle cercle)
        {
            return cercle.Croise(this);
        }

        /// <summary>
        /// Teste si le Polygone croise le Polygone donné
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Vrai si la Droite contient le Polygone donné</returns>
        protected override bool Croise(Polygone polygone)
        {
            return polygone.Croise(this);
        }

        /// <summary>
        /// Retourne le croisement du Segment courant avec une Droite
        /// </summary>
        /// <param name="autreDroite">Droite testée</param>
        /// <returns>Le PointReel du croisement si la Droite testée croise le Segment courant, sinon null</returns>
        new public RealPoint getCroisement(Droite autreDroite)
        {
            // Il existe la fonction pour tester le croisement entre une droite et un segment, on l'utilise
            return autreDroite.getCroisement(this);
        }

        /// <summary>
        /// Retourne le croisement du Segment courant avec un autre Segment
        /// </summary>
        /// <param name="autreDroite">Segment testé</param>
        /// <returns>Le PointReel du croisement si le Segment testé croise le Segment courant, sinon null</returns>
        new public RealPoint getCroisement(Segment autreSegment)
        {
            // Pour ne pas réécrire du code existant, on récupère le croisement entre ce segment et l'autre en tant que droite
            // Si l'autre segment contient ce point, c'est le croisement, sinon il n'en existe pas

            RealPoint croisement = getCroisement((Droite)autreSegment);
            if (croisement != null && autreSegment.Contient(croisement))
                return croisement;

            return null;
        }

        #endregion

        #region Contient

        /// <summary>
        /// Teste si le Segment courant contient le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Vrai si le Segment courant contient le PointReel donné</returns>
        protected override bool Contient(RealPoint point)
        {
            // Vérifie que le point est situé sur la droite
            if (!base.Contient(point))
                return false;
            // Puis qu'il est entre les deux extrémités
            if ((Math.Round(point.X, 2) > Math.Round(Math.Max(Debut.X, Fin.X), 2)) ||
                (Math.Round(point.X, 2) < Math.Round(Math.Min(Debut.X, Fin.X), 2)) ||
                (Math.Round(point.Y, 2) > Math.Round(Math.Max(Debut.Y, Fin.Y), 2)) ||
                (Math.Round(point.Y, 2) < Math.Round(Math.Min(Debut.Y, Fin.Y), 2)))
                return false;

            return true;
        }

        /// <summary>
        /// Teste si le Segment courant contient un autre Segment
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si le Segment courant contient le Segment testé</returns>
        protected override bool Contient(Segment segment)
        {
            // Il suffit de vérifier que le segment contient les deux extrémités
            return Contient(segment.Debut) && Contient(segment.Fin);
        }

        /// <summary>
        /// Teste si le Segment courant contient une Droite
        /// </summary>
        /// <param name="droite">Droite testée</param>
        /// <returns>Vrai si le Segment courant contient la Droite testée</returns>
        protected override bool Contient(Droite droite)
        {
            // Un segment ne peut pas contenir de Droite
            return false;
        }

        /// <summary>
        /// Teste si le Segment courant contient un Polygone
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Vrai si le Segment courant contient le Polygone testé</returns>
        protected override bool Contient(Polygone polygone)
        {
            // Contenir un polygone revient à contenir tous les cotés du polygone
            foreach (Segment s in polygone.Cotes)
                if (!Contient(s))
                    return false;

            return true;
        }

        /// <summary>
        /// Teste si le Segment courant contient un Cercle
        /// </summary>
        /// <param name="Cercle">Cercle testé</param>
        /// <returns>Vrai si le Segment courant contient le Cercle testé</returns>
        protected override bool Contient(Cercle Cercle)
        {
            // Contenir un Cercle revient à avoir un Cercle de rayon 0 dont le centre se trouve sur le segment
            return Contient(Cercle.Centre) && Cercle.Rayon == 0;
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimale entre le Segment courant et le Segment donné
        /// </summary>
        /// <param name="forme">Segment testé</param>
        /// <returns>Distance minimale</returns>
        protected override double Distance(Segment segment)
        {
            // Si les segments se croisent la distance est de 0
            if (Croise(segment))
                return 0;

            // Sinon c'est la distance minimale entre (chaque extremité d'un segment) et (l'autre segment)
            double minDistance = double.MaxValue;

            // Le minimal est peut être entre les extremités
            minDistance = Math.Min(minDistance, segment.Debut.Distance(Debut));
            minDistance = Math.Min(minDistance, segment.Debut.Distance(Fin));
            minDistance = Math.Min(minDistance, segment.Fin.Distance(Debut));
            minDistance = Math.Min(minDistance, segment.Fin.Distance(Fin));

            // Le minimal est peut etre entre une extremité et le projeté hortogonal sur l'autre segment
            Droite perpendiculaire = segment.GetPerpendiculaire(Debut);
            RealPoint croisement = segment.getCroisement(perpendiculaire);
            if(croisement != null)
                minDistance = Math.Min(minDistance, croisement.Distance(Debut));

            perpendiculaire = segment.GetPerpendiculaire(Fin);
            croisement = segment.getCroisement(perpendiculaire);
            if(croisement != null)
                minDistance = Math.Min(minDistance, croisement.Distance(Fin));

            perpendiculaire = GetPerpendiculaire(segment.Debut);
            croisement = getCroisement(perpendiculaire);
            if (croisement != null)
                minDistance = Math.Min(minDistance, croisement.Distance(segment.Debut));

            perpendiculaire = GetPerpendiculaire(segment.Fin);
            croisement = getCroisement(perpendiculaire);
            if (croisement != null)
                minDistance = Math.Min(minDistance, croisement.Distance(segment.Fin));

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le Segment courant et la Droite donnée
        /// </summary>
        /// <param name="forme">Droite testée</param>
        /// <returns>Distance minimale</returns>
        protected override double Distance(Droite droite)
        {
            // Si la droite et le segment se croisent la distance est de 0
            if (Croise(droite))
                return 0;

            // Sinon c'est la distance minimale entre chaque extremité du segment et la droite
            double minDistance = double.MaxValue;

            minDistance = Math.Min(minDistance, droite.Distance(Debut));
            minDistance = Math.Min(minDistance, droite.Distance(Fin));

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le Segment courant et le Cercle donné
        /// </summary>
        /// <param name="forme">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        protected override double Distance(Cercle Cercle)
        {
            if (Croise(Cercle))
                return 0;

            // Distance jusqu'au centre du cercle - son rayon
            return Distance(Cercle.Centre) - Cercle.Rayon;
        }

        /// <summary>
        /// Retourne la distance minimale entre le Segment courant et le Polygone donné
        /// </summary>
        /// <param name="forme">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        protected override double Distance(Polygone polygone)
        {
            // Distance jusqu'au segment le plus proche
            double minDistance = double.MaxValue;

            foreach (Segment s in polygone.Cotes)
            {
                if (Croise(s))
                    return 0;

                minDistance = Math.Min(s.Distance(this), minDistance);
            }

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le Segment courant et un PointReel
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Distance minimale</returns>
        protected override double Distance(RealPoint point)
        {
            // Le raisonnement est le même que pour la droite cf Droite.Distance

            Droite perpendiculaire = GetPerpendiculaire(point);
            RealPoint pointProche = getCroisement(perpendiculaire);

            double distance;

            // Seule différence : on teste si l'intersection appartient bien au segment, sinon on retourne la distance avec l'extrémité la plus proche
            if (pointProche == null)
            {
                double distanceDebut = point.Distance(Debut);
                double distanceFin = point.Distance(Fin);

                distance = Math.Min(distanceDebut,  distanceFin);
            }
            else
            {
                distance = point.Distance(pointProche);
            }

            return distance;
        }

        #endregion

        #region Transformations

        public new Segment Translation(double dx, double dy)
        {
            return new Segment(pointDebut.Translation(dx, dy), pointFin.Translation(dx, dy));
        }

        public new Segment Rotation(Angle angle, RealPoint centreRotation = null)
        {
            if (centreRotation == null)
                centreRotation = BaryCentre;

            return new Segment(pointDebut.Rotation(angle, centreRotation), pointFin.Rotation(angle, centreRotation));
        }
        #endregion

        #region Peinture

        public override void Paint(Graphics g, Color outlineColor, int outlineWidth, Color fillColor, WorldScale scale)
        {
            Point startPoint = scale.RealToScreenPosition(Debut);
            Point endPoint = scale.RealToScreenPosition(Fin);
            
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
