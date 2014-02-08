using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Calculs.Formes
{
    public class Cercle : IForme
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

        #endregion

        #region Accesseurs

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

        #endregion

        #region Croise
        
        /// <summary>
        /// Teste si le Cercle courant croise la Forme donnée
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Vrai si le Cercle courant croise la Forme testée</returns>
        public bool croise(IForme forme)
        {
            Type typeForme = forme.GetType();

            if (typeForme.IsAssignableFrom(typeof(Droite)))
                return croise((Droite)forme);
            else if (typeForme.IsAssignableFrom(typeof(Segment)))
                return croise((Segment)forme);
            else if (typeForme.IsAssignableFrom(typeof(Polygone)))
                return croise((Polygone)forme);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                return croise((Cercle)forme);
            else
                throw new NotImplementedException("Fonction inexistante : Croisement d'un(e) " + this.GetType().Name + " et d'un(e) " + typeForme.Name);
        }

        /// <summary>
        /// Teste si le Cercle courant croise la Droite donnée
        /// </summary>
        /// <param name="droite">Droite testés</param>
        /// <returns>Vrai si le Cercle courant contient la Droite donnée</returns>
        protected bool croise(Droite droite)
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
        protected bool croise(Segment segment)
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
        protected bool croise(Polygone polygone)
        {
            // On teste le croisement avec chaque coté du polygone
            foreach (Segment segment in polygone.Cotes)
            {
                if (croise(segment))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Teste si le Cercle courant croise un autre Cercle donné
        /// </summary>
        /// <param name="Cercle">Cercle testé</param>
        /// <returns>Vrai si le Cercle courant croise le Cercle testé</returns>
        protected bool croise(Cercle Cercle)
        {
            // Pour croiser un Cercle il suffit que son centre soit éloigné de notre centre de moins que la somme de nos 2 rayons

            double distanceCentres = centre.Distance(Cercle.centre);

            if (distanceCentres <= rayon + Cercle.rayon)
                return true;

            return false;
        }

        #endregion

        #region Contient

        /// <summary>
        /// Teste si le Cercle courant contient la Forme donnée
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Vrai si le Cercle courant contient la Forme testée</returns>
        public bool contient(IForme forme)
        {
            if (forme == null)
                return false;

            Type typeForme = forme.GetType();
            
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
        /// Teste si le Cercle courant contient le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns></returns>
        protected bool contient(PointReel point)
        {
            // Pour contenir un point, celui si se trouve à une distance inférieure au rayon du centre
            return point.Distance(centre) <= rayon;
        }

        /// <summary>
        /// Teste si le Cercle courant contient le Segment donné
        /// </summary>
        /// <param name="segment">Segment testé</param>
        /// <returns>Vrai si le Cercle courant contient le Segment testé</returns>
        protected bool contient(Segment segment)
        {
            // Pour contenir un Segment il suffit de contenir ses 2 extremités
            return contient(segment.Debut) && contient(segment.Fin);
        }

        /// <summary>
        /// Teste si le Cercle courant contient la Droite donnée
        /// </summary>
        /// <param name="droite">Droite testée</param>
        /// <returns>Vrai si le Cercle courant contient la Droite testée</returns>
        protected bool contient(Droite droite)
        {
            // Un Cercle ne peut pas contenir de droite
            return false;
        }

        /// <summary>
        /// Teste si le Cercle courant contient le Polygone donné
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Vrai si le Cercle courant contient le Polygone testé</returns>
        protected bool contient(Polygone polygone)
        {
            // Pour contenir un polygone iul suffit de contenir tous ses cotés
            foreach (Segment s in polygone.Cotes)
            {
                if (!contient(s))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Teste si le Cercle courant contient le Cercle donné
        /// </summary>
        /// <param name="Cercle">Cercle testé</param>
        /// <returns>Vrai si le Cercle courant contient le Cercle testé</returns>
        protected bool contient(Cercle Cercle)
        {
            // Pour contenir un Cercle il faut que son rayon + la distance entre les centres des deux Cercles soit inférieure à notre rayon
            return Cercle.rayon + Cercle.Centre.Distance(Centre) < rayon;
        }

        #endregion

        #region Opérateurs & Surcharges

        public static bool operator ==(Cercle a, Cercle b)
        {
            if ((object)a == null || (object)b == null)
                return (object)a == null && (object)b == null;
            else
            return      a.Rayon == b.Rayon
                    &&  a.Centre == b.Centre;
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
        /// Retourne la distance minimale entre le Cercle courant et la Forme donnée
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
        /// Retourne la distance minimale entre le Cercle courant et le Segment donné
        /// </summary>
        /// <param name="forme">Segment testé</param>
        /// <returns>Distance minimale</returns>
        public double Distance(Segment segment)
        {
            // Le segment sait le faire
            return segment.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le Cercle courant et la Droite donnée
        /// </summary>
        /// <param name="forme">Droite testée</param>
        /// <returns>Distance minimale</returns>
        public double Distance(Droite droite)
        {
            return droite.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimale entre le Cercle courant et le Cercle donné
        /// </summary>
        /// <param name="forme">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        public double Distance(Cercle Cercle)
        {
            if (croise(Cercle))
                return 0;

            return Cercle.Centre.Distance(Centre) - Rayon - Cercle.Rayon;
        }

        /// <summary>
        /// Retourne la distance minimale entre le Cercle courant et le Polygone donné
        /// </summary>
        /// <param name="forme">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        public double Distance(Polygone polygone)
        {
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
    }
}
