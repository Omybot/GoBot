using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Calculs.Formes
{
    public class Cercle : IForme, IModifiable<Cercle>
    {
        #region Attributs

        /// <summary>
        /// Centre du Cercle
        /// </summary>
        private PointReel centre;

        /// <summary>
        /// Rayon du Cercle
        /// </summary>
        private double rayon;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Construit un Cercle depuis son centre et son rayon
        /// </summary>
        /// <param name="centre">Point central du Cercle</param>
        /// <param name="rayon">Rayon du Cercle</param>
        public Cercle(PointReel centre, double rayon)
        {
            this.centre = centre;
            this.rayon = rayon;
        }

        /// <summary>
        /// Construit un Cercle depuis un autre Cercle
        /// </summary>
        /// <param name="cercle">Cercle à copier</param>
        public Cercle(Cercle cercle)
        {
            this.centre = cercle.centre;
            this.rayon = cercle.rayon;
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// Obtient le centre du Cercle
        /// </summary>
        public PointReel Centre
        {
            get
            {
                return centre;
            }
        }

        /// <summary>
        /// Obtient le rayon du Cercle
        /// </summary>
        public double Rayon
        {
            get
            {
                return rayon;
            }
        }

        /// <summary>
        /// Surface du Cercle
        /// </summary>
        public double Surface
        {
            get
            {
                return rayon * rayon * Math.PI;
            }
        }

        /// <summary>
        /// Barycentre du Cercle
        /// </summary>
        public PointReel BaryCentre
        {
            get
            {
                return Centre;
            }
        }

        #endregion

        #region Opérateurs & Surcharges

        public static bool operator ==(Cercle a, Cercle b)
        {
            if ((object)a == null || (object)b == null)
                return (object)a == null && (object)b == null;
            else
                return a.Rayon == b.Rayon
                        && a.Centre == b.Centre;
        }

        public static bool operator !=(Cercle a, Cercle b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            Cercle p = obj as Cercle;
            if ((Object)p == null)
            {
                return false;
            }

            return (Cercle)obj == this;
        }

        public override int GetHashCode()
        {
            return (int)(centre.GetHashCode()) ^ (int)rayon;
        }

        public override string ToString()
        {
            return centre + " R = " + rayon;
        }

        #endregion

        #region Distance
        
        /// <summary>
        /// Retourne la distance minimale entre le Cercle courant et la IForme donnée
        /// </summary>
        /// <param name="forme">IForme testé</param>
        /// <returns>Distance minimale</returns>
        public double Distance(IForme forme)
        {
            return Distance(Util.ToRealType(forme));
        }

        /// <summary>
        /// Retourne la distance minimale entre le Cercle courant et le Segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Segment segment)
        {
            // Le segment sait le faire
            return segment.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le Cercle courant et la Droite donnée
        /// </summary>
        /// <param name="droite">Droite testée</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Droite droite)
        {
            // La droite sait le faire
            return droite.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le Cercle courant et le Cercle donné
        /// </summary>
        /// <param name="Cercle">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Cercle Cercle)
        {
            if (Croise(Cercle))
                return 0;

            return Cercle.Centre.Distance(Centre) - Rayon - Cercle.Rayon;
        }

        /// <summary>
        /// Retourne la distance minimale entre le Cercle courant et le Polygone donné
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        protected double Distance(Polygone polygone)
        {
            // Le polygone sait le faire
            return polygone.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le Cercle courant et le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Distance calculée</returns>
        public double Distance(PointReel point)
        {
            // C'est la distance entre le centre du Cercle et le point moins le rayon du cercle
            return point.Distance(Centre) - Rayon;
        }

        #endregion
    
        #region Contient
        
        /// <summary>
        /// Teste si le Cercle courant contient la IForme donnée
        /// </summary>
        /// <param name="forme">IForme testée</param>
        /// <returns>Vrai si le Cercle contient la IForme testée</returns>
        public bool Contient(IForme forme)
        {
            return Contient(Util.ToRealType(forme));
        }

        /// <summary>
        /// Teste si le Cercle courant contient le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Vrai si le Cercle contient le PointReel testé</returns>
        protected bool Contient(PointReel point)
        {
            // Pour contenir un point, celui si se trouve à une distance inférieure au rayon du centre
            return point.Distance(centre) <= rayon;
        }

        /// <summary>
        /// Teste si le Cercle courant contient le Segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si le Cercle courant contient le Segment testé</returns>
        protected bool Contient(Segment segment)
        {
            // Pour contenir un Segment il suffit de contenir ses 2 extremités
            return Contient(segment.Debut) && Contient(segment.Fin);
        }

        /// <summary>
        /// Teste si le Cercle courant contient la Droite donnée
        /// </summary>
        /// <param name="droite">Droite testée</param>
        /// <returns>Vrai si le Cercle courant contient la Droite testée</returns>
        protected bool Contient(Droite droite)
        {
            // Un Cercle ne peut pas contenir de droite
            return false;
        }

        /// <summary>
        /// Teste si le Cercle courant contient le Polygone donné
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Vrai si le Cercle courant contient le Polygone testé</returns>
        protected bool Contient(Polygone polygone)
        {
            // Pour contenir un polygone iul suffit de contenir tous ses cotés
            foreach (Segment s in polygone.Cotes)
            {
                if (!Contient(s))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Teste si le Cercle courant contient le Cercle donné
        /// </summary>
        /// <param name="Cercle">Cercle testé</param>
        /// <returns>Vrai si le Cercle courant contient le Cercle testé</returns>
        protected bool Contient(Cercle Cercle)
        {
            // Pour contenir un Cercle il faut que son rayon + la distance entre les centres des deux Cercles soit inférieure à notre rayon
            return Cercle.rayon + Cercle.Centre.Distance(Centre) < rayon;
        }

        #endregion

        #region Croise

        public List<PointReel> Croisements(IForme forme)
        {
            // TODOFORMES
            return null;
        }

        /// <summary>
        /// Teste si le Cercle courant croise la IForme donnée
        /// </summary>
        /// <param name="forme">IForme testés</param>
        /// <returns>Vrai si le Cercle courant croise la IForme donnée</returns>
        public bool Croise(IForme forme)
        {
            return Croise(Util.ToRealType(forme));
        }

        /// <summary>
        /// Teste si le Cercle courant croise la Droite donnée
        /// </summary>
        /// <param name="droite">Droite testés</param>
        /// <returns>Vrai si le Cercle courant contient la Droite donnée</returns>
        protected bool Croise(Droite droite)
        {
            // Si une droite croise le Cercle, c'est que le point de la droite le plus proche du centre du Cercle est éloigné d'une distance inférieure au rayon
            double distanceAuCentre = droite.Distance(centre);
            return distanceAuCentre <= rayon;
        }

        /// <summary>
        /// Teste si le Cercle courant contient le Segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si le Cercle courant croise le Segment testé</returns>
        protected bool Croise(Segment segment)
        {
            // Même test que pour la droite
            double distanceAuCentre = segment.Distance(centre);
            return distanceAuCentre <= rayon;
        }

        /// <summary>
        /// Teste si le Cercle courant contient le Polygone donné
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Vrai si le Cercle courant contient le Polygone testé</returns>
        protected bool Croise(Polygone polygone)
        {
            // On teste le croisement avec chaque coté du polygone
            foreach (Segment segment in polygone.Cotes)
            {
                if (Croise(segment))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Teste si le Cercle courant croise un autre Cercle donné
        /// </summary>
        /// <param name="cercle">Cercle testé</param>
        /// <returns>Vrai si le Cercle courant croise le Cercle testé</returns>
        protected bool Croise(Cercle cercle)
        {
            // Pour croiser un Cercle il suffit que son centre soit éloigné de notre centre de moins que la somme de nos 2 rayons

            double distanceCentres = centre.Distance(cercle.centre);

            if (distanceCentres <= rayon + cercle.rayon)
                return true;

            return false;
        }

        /// <summary>
        /// Teste si le Cercle courant croise un PointReel donné
        /// </summary>
        /// <param name=" point">PointReel testé</param>
        /// <returns>Vrai si le Cercle courant croise le Cercle testé</returns>
        protected bool Croise(PointReel point)
        {
            // Pour croiser un Cercle il suffit que son centre soit éloigné de notre centre de moins que la somme de nos 2 rayons

            double distanceCentre = centre.Distance(point);

            if (distanceCentre <= rayon + PointReel.PRECISION && distanceCentre >= rayon - PointReel.PRECISION)
                return true;

            return false;
        }

        #endregion

        #region Transformations
        
        public Cercle Translation(double dx, double dy)
        {
            return new Cercle(centre.Translation(dx, dy), rayon);
        }

        public Cercle Rotation(Angle angle, PointReel centreRotation = null)
        {
            return new Cercle(centre.Rotation(angle, centreRotation), rayon);
        }

        #endregion

    }
}
