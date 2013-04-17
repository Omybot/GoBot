using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Calculs.Formes
{
    // Un segment est une Droite avec deux extrémités
    public class Segment : Droite
    {
        #region Attributs

        protected PointReel pointDebut, pointFin;

        #endregion

        #region Constructeurs

        public Segment(PointReel debut, PointReel fin) 
        {
            pointDebut = debut;
            pointFin = fin;

            calculEquation(Debut, Fin);
        }

        #endregion

        #region Accesseurs

        public PointReel Debut
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

        public PointReel Fin
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

        #endregion

        #region Croisements

        /// <summary>
        /// Teste le croisement avec une autre forme. Renvoie vrai si la forme croise le Segment courant
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Vrai si la forme croise le Segment courant</returns>
        new public bool croise(IForme forme)
        {
            Type typeForme = forme.GetType();
            if (typeForme.IsAssignableFrom(typeof(Droite)))
                return getCroisement((Droite)forme) != null;
            else if (typeForme.IsAssignableFrom(typeof(Segment)))
                return getCroisement((Segment)forme) != null;
            else if (typeForme.IsAssignableFrom(typeof(Polygone)))
                return forme.croise(this);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                return forme.croise(this);
            else
                throw new NotImplementedException("Fonction inexistante : Croisement d'un(e) " + this.GetType().Name + " et d'un(e) " + typeForme.Name);
        }

        /// <summary>
        /// Retourne le croisement du Segment courant avec une Droite
        /// </summary>
        /// <param name="autreDroite">Droite testée</param>
        /// <returns>Le PointReel du croisement si la Droite testée croise le Segment courant, sinon null</returns>
        new public PointReel getCroisement(Droite autreDroite)
        {
            // Il existe la fonction pour tester le croisement entre une droite et un segment, on l'utilise
            return autreDroite.getCroisement(this);
        }

        /// <summary>
        /// Retourne le croisement du Segment courant avec un autre Segment
        /// </summary>
        /// <param name="autreDroite">Segment testé</param>
        /// <returns>Le PointReel du croisement si le Segment testé croise le Segment courant, sinon null</returns>
        new public PointReel getCroisement(Segment autreSegment)
        {
            // Pour ne pas réécrire du code existant, on récupère le croisement entre ce segment et l'autre en tant que droite
            // Si l'autre segment contient ce point, c'est le croisement, sinon il n'en existe pas

            PointReel croisement = getCroisement((Droite)autreSegment);
            if (croisement != null && autreSegment.contient(croisement))
                return croisement;

            return null;
        }

        #endregion

        #region Contient

        /// <summary>
        /// Teste si le Segment courant contient la Forme
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Vrai si le Segment courant contient la Forme</returns>
        new public bool contient(IForme forme)
        {
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
        /// Teste si le Segment courant contient le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Vrai si le Segment courant contient le PointReel donné</returns>
        new protected bool contient(PointReel point)
        {
            // Vérifie que le point est situé sur la droite
            if (!base.contient(point))
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
        new protected bool contient(Segment segment)
        {
            // Il suffit de vérifier que le segment contient les deux extrémités
            return contient(segment.Debut) && contient(segment.Fin);
        }

        /// <summary>
        /// Teste si le Segment courant contient une Droite
        /// </summary>
        /// <param name="droite">Droite testée</param>
        /// <returns>Vrai si le Segment courant contient la Droite testée</returns>
        new protected bool contient(Droite droite)
        {
            // Un segment ne peut pas contenir de Droite
            return false;
        }

        /// <summary>
        /// Teste si le Segment courant contient un Polygone
        /// </summary>
        /// <param name="polygone">Polygone testé</param>
        /// <returns>Vrai si le Segment courant contient le Polygone testé</returns>
        new protected bool contient(Polygone polygone)
        {
            // Contenir un polygone revient à contenir tous les cotés du polygone
            foreach (Segment s in polygone.Cotes)
                if (!contient(s))
                    return false;

            return true;
        }

        /// <summary>
        /// Teste si le Segment courant contient un Cercle
        /// </summary>
        /// <param name="Cercle">Cercle testé</param>
        /// <returns>Vrai si le Segment courant contient le Cercle testé</returns>
        new protected bool contient(Cercle Cercle)
        {
            // Contenir un Cercle revient à avoir un Cercle de rayon 0 dont le centre se trouve sur le segment
            return contient(Cercle.Centre) && Cercle.Rayon == 0;
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

        #region Distance

        /// <summary>
        /// Retourne la distance minimale entre le Segment courant et la Forme donnée
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Distance minimale</returns>
        new public double getDistance(IForme forme)
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
        /// Retourne la distance minimale entre le Segment courant et le Segment donné
        /// </summary>
        /// <param name="forme">Segment testé</param>
        /// <returns>Distance minimale</returns>
        new private double getDistance(Segment segment)
        {
            // Si les segments se croisent la distance est de 0
            if (croise(segment))
                return 0;

            // Sinon c'est la distance minimale entre (chaque extremité d'un segment) et (l'autre segment)
            double minDistance = double.MaxValue;

            // TODO c'est faux dans pas mal de cas... Voir avec la projection orthogonale

            // Le minimal est peut être entre les extremités
            minDistance = Math.Min(minDistance, segment.Debut.getDistance(Debut));
            minDistance = Math.Min(minDistance, segment.Debut.getDistance(Fin));
            minDistance = Math.Min(minDistance, segment.Fin.getDistance(Debut));
            minDistance = Math.Min(minDistance, segment.Fin.getDistance(Fin));

            // Le minimal est peut etre entre une extremité et le projeté hortogonal sur l'autre segment
            Droite perpendiculaire = segment.getPerpendiculaire(Debut);
            PointReel croisement = segment.getCroisement(perpendiculaire);
            if(croisement != null)
                minDistance = Math.Min(minDistance, croisement.getDistance(Debut));

            perpendiculaire = segment.getPerpendiculaire(Fin);
            croisement = segment.getCroisement(perpendiculaire);
            if(croisement != null)
                minDistance = Math.Min(minDistance, croisement.getDistance(Fin));

            perpendiculaire = getPerpendiculaire(segment.Debut);
            croisement = getCroisement(perpendiculaire);
            if (croisement != null)
                minDistance = Math.Min(minDistance, croisement.getDistance(segment.Debut));

            perpendiculaire = getPerpendiculaire(segment.Fin);
            croisement = getCroisement(perpendiculaire);
            if (croisement != null)
                minDistance = Math.Min(minDistance, croisement.getDistance(segment.Fin));

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le Segment courant et la Droite donnée
        /// </summary>
        /// <param name="forme">Droite testée</param>
        /// <returns>Distance minimale</returns>
        new private double getDistance(Droite droite)
        {
            // Si la droite et le segment se croisent la distance est de 0
            if (croise(droite))
                return 0;

            // Sinon c'est la distance minimale entre chaque extremité du segment et la droite
            double minDistance = double.MaxValue;

            // TODO c'est faux dans pas mal de cas...Voir avec la projection orthogonale
            minDistance = Math.Min(minDistance, droite.getDistance(Debut));
            minDistance = Math.Min(minDistance, droite.getDistance(Fin));

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le Segment courant et le Cercle donné
        /// </summary>
        /// <param name="forme">Cercle testé</param>
        /// <returns>Distance minimale</returns>
        new private double getDistance(Cercle Cercle)
        {
            if (croise(Cercle))
                return 0;

            // Distance jusqu'au centre du cercle - son rayon
            return getDistance(Cercle.Centre) - Cercle.Rayon;
        }

        /// <summary>
        /// Retourne la distance minimale entre le Segment courant et le Polygone donné
        /// </summary>
        /// <param name="forme">Polygone testé</param>
        /// <returns>Distance minimale</returns>
        new private double getDistance(Polygone polygone)
        {
            // Distance jusqu'au segment le plus proche
            double minDistance = double.MaxValue;

            foreach (Segment s in polygone.Cotes)
            {
                if (croise(s))
                    return 0;

                minDistance = Math.Min(s.getDistance(this), minDistance);
            }

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimale entre le Segment courant et un PointReel
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Distance minimale</returns>
        new private double getDistance(PointReel point)
        {
            // Le raisonnement est le même que pour la droite cf Droite.getDistance

            Droite perpendiculaire = getPerpendiculaire(point);
            PointReel pointProche = getCroisement(perpendiculaire);

            double distance;

            // Seule différence : on teste si l'intersection appartient bien au segment, sinon on retourne la distance avec l'extrémité la plus proche
            if (pointProche == null)
            {
                double distanceDebut = point.getDistance(Debut);
                double distanceFin = point.getDistance(Fin);

                distance = Math.Min(distanceDebut,  distanceFin);
            }
            else
            {
                distance = point.getDistance(pointProche);
            }

            return distance;
        }

        #endregion
    }
}
