using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace GoBot.Calculs.Formes
{
    public class System
    {
        public static Out Out = new Out();
    }

    public class Out
    {
        public void println(String message)
        {
            MessageBox.Show(message + Environment.NewLine);
        }
    }

    public class Polygone : IForme
    {
        #region Attributs

        /// <summary>
        /// Liste des côtés du Polygone sous forme de segments
        /// La figure est forcément fermée et le dernier point est donc forcément relié au premier
        /// </summary>
        protected List<Segment> cotes;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Contruit un polygone selon une liste de cotés
        /// Les côtés doivent être donnés dans l'ordre
        /// Si 2 côtés ne se touchent pas ils sont automatiquement reliés par un Segment intermédiaire
        /// Si 2 côtés se croisent une exception ArgumentException est levée
        /// Si le polygone n'est pas fermé le premier et le dernier point sont reliés
        /// </summary>
        /// <param name="cotesPolygone">Liste des cotés</param>
        public Polygone(List<Segment> cotesPolygone)
        {
            cotes = new List<Segment>();

            construirePolygone(cotesPolygone);
        }

        /// <summary>
        /// Constructeur par défaut utile uniquement pour les héritiés
        /// </summary>
        protected Polygone()
        {
            cotes = new List<Segment>();
        }

        /// <summary>
        /// Construit un polygone selon une liste de points
        /// Si le polygone n'est pas fermé le premier et le dernier point sont reliés
        /// </summary>
        /// <param name="points">Liste des points du polygone dans l'ordre où ils sont reliés</param>
        public Polygone(List<PointReel> points)
        {
            cotes = new List<Segment>();

            List<Segment> cotesPoly = new List<Segment>();

            if (points.Count == 0)
                return;

            for (int i = 1; i < points.Count; i++)
                cotesPoly.Add(new Segment(points[i - 1], points[i]));

            cotesPoly.Add(new Segment(points[points.Count - 1], points[0]));

            construirePolygone(cotesPoly);
        }

        protected void construirePolygone(List<Segment> cotesPolygone)
        {
            if (cotesPolygone.Count == 0)
                return;

            for (int i = 0; i < cotesPolygone.Count - 1; i++)
            {
                cotes.Add(cotesPolygone[i]);

                if (cotesPolygone[i].Fin != cotesPolygone[i + 1].Debut)
                    cotes.Add(new Segment(cotesPolygone[i].Fin, cotesPolygone[i + 1].Debut));

            }

            cotes.Add(cotesPolygone[cotesPolygone.Count - 1]);

            foreach (Segment s1 in cotes)
                foreach (Segment s2 in cotes)
                    if (s1 != s2)
                    {
                        PointReel croisement = s1.getCroisement(s2);
                        if(croisement != null && croisement != s1.Debut && croisement != s1.Fin)
                            throw new ArgumentException("Le polygone construit a un ou plusieurs côtés qui se croisent. Création impossible.");
                    }
        }

        #endregion

        #region Accesseurs

        /// <summary>
        /// Obtient la liste des cotés du polygone
        /// </summary>
        public List<Segment> Cotes
        {
            get
            {
                return cotes;
            }
        }

        #endregion

        #region Opérateurs & Surcharges

        public static bool operator ==(Polygone a, Polygone b)
        {

            if ((object)a == null || (object)b == null)
                return (object)a == null && (object)b == null;
            else if (a.Cotes.Count == b.Cotes.Count)
            {
                for (int i = 0; i < a.Cotes.Count; i++)
                {
                    if (a.Cotes[i] != b.Cotes[i])
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        public static bool operator !=(Polygone a, Polygone b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            Polygone p = obj as Polygone;
            if ((Object)p == null)
            {
                return false;
            }

            return (Polygone)obj == this;
        }

        public override int GetHashCode()
        {
            if (cotes.Count == 0)
                return 0;

            int hash = cotes[0].GetHashCode();
            for (int i = 1; i < cotes.Count; i++)
                hash ^= cotes[i].GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            if (cotes.Count == 0)
                return "-";

            String chaine = cotes[0].ToString() + Environment.NewLine;
            for (int i = 1; i < cotes.Count; i++)
                chaine += cotes[i].ToString() + Environment.NewLine;

            return chaine;
        }

        #endregion

        #region Contient

        /// <summary>
        /// Teste si le Polygone courant contient la Forme donnée
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Vrai si le Polygone courant contient la Forme testée</returns>
        public bool contient(IForme forme)
        {
            Type typeForme = forme.GetType();
            
            if (typeForme.IsAssignableFrom(typeof(Droite)))
                return contient((Droite)forme);
            else if (typeForme.IsAssignableFrom(typeof(Segment)))
                return contient((Segment)forme);
            else if (typeForme.IsAssignableFrom(typeof(Polygone)) || typeForme.IsSubclassOf(typeof(Polygone)))
                return contient((Polygone)forme);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                return contient((Cercle)forme);
            else if (typeForme.IsAssignableFrom(typeof(PointReel)))
                return contient((PointReel)forme);
            else
                throw new NotImplementedException("Fonction inexistante : Contenance dans un(e) " + this.GetType().Name + " d'un(e) " + typeForme.Name);
        }

        /// <summary>
        /// Retourne vrai si le Polygone courant contient le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Vrai si le Polygone courant contient le PointReel testé</returns>
        protected bool contient(PointReel point)
        {
            // Pour savoir si le Polygone contient un poin on trace un segment entre ce point et un point très éloigné.
            // On compte combien de cotés du polygone croisent cette droite
            // Si ce nombre est impair alors le point est contenu dans le polygone
            int nbCroisements = 0;
            Segment segmentTest = new Segment(point, new PointReel(-100000, -100000));

            foreach (Segment s in Cotes)
            {
                if (s.contient(point))
                    return true;

                if (s.croise(segmentTest))
                    nbCroisements++;
            }

            return (nbCroisements % 2 == 1);
        }

        /// <summary>
        /// Retourne vrai si le Polygone courant contient le Polygone donné
        /// </summary>
        /// <param name="point">Polygone testé</param>
        /// <returns>Vrai si le Polygone courant contient le Polygone testé</returns>
        protected bool contient(Polygone polygone)
        {
            // Il suffit de contenir tous les segments du polygone testé
            foreach (Segment s in polygone.Cotes)
            {
                if (!contient(s))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Retourne vrai si le Polygone courant contient le Segment donné
        /// </summary>
        /// <param name="point">Segment testé</param>
        /// <returns>Vrai si le Polygone courant contient le Segment testé</returns>
        protected bool contient(Segment segment)
        {
            // Il suffit de contenir les deux extrémités du segment et de ne jamais croiser le segment
            bool result = contient(segment.Debut) && contient(segment.Fin);
            if (croise(segment)) // si ça se croise : est ce que c'est sur un bout ? 
            {
                List<PointReel> lpr = this.getCroisements(segment);
                if (lpr.Count > 2)
                {
                    return false; 
                }
                else if (lpr.Count == 2)
                {
                    // tu le send avec les mains
                    if ((lpr[0] == segment.Debut || lpr[0] == segment.Fin) && (lpr[1] == segment.Debut || lpr[1] == segment.Fin))
                    {
                        // test d'un point au milieux;
                        PointReel p = new PointReel((segment.Debut.X + segment.Fin.X) / 2, (segment.Debut.Y + segment.Fin.Y) / 2);
                        if (this.contient(p))
                        {
                            return result;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else // if (lpr.Count == 1)
                {
                    if (lpr[0] == segment.Debut || lpr[0] == segment.Fin)
                    {
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            else // cas normal 
            {
                return contient(segment.Debut) && contient(segment.Fin) && !croise(segment);
            }

           
        }

        /// <summary>
        /// Retourne vrai si le Polygone courant contient la Droite donnée
        /// </summary>
        /// <param name="point">Droite testée</param>
        /// <returns>Vrai si le Polygone courant contient la Droite testée</returns>
        protected bool contient(Droite droite)
        {
            // Un polygone ne peut pas contenir de droite
            return false;
        }

        /// <summary>
        /// Retourne vrai si le Polygone courant contient le Cercle donné
        /// </summary>
        /// <param name="point">Cercle testé</param>
        /// <returns>Vrai si le Polygone courant contient le Cercle testé</returns>
        protected bool contient(Cercle Cercle)
        {
            // Pour contenir un Cercle, un polygone ne doit pas le croiser et contenir son centre

            foreach (Segment s in Cotes)
            {
                if (s.croise(Cercle))
                    return false;
            }

            if (contient(Cercle.Centre))
                return true;
            else
                return false;
        }

        #endregion

        #region Croisements
        
        /// <summary>
        /// Retourne si le Polygone croise la Forme donnée
        /// </summary>
        /// <param name="forme">Forme testée</param>
        /// <returns>Vrai si le Polygone croise la Forme testée</returns>
        public bool croise(IForme forme)
        {
            Type typeForme = forme.GetType();
            
            if (typeForme.IsAssignableFrom(typeof(Droite)))
                return croise((Droite)forme);
            else if (typeForme.IsAssignableFrom(typeof(Segment)))
                return croise((Segment)forme);
            else if (typeForme.IsAssignableFrom(typeof(Polygone)) || typeForme.IsSubclassOf(typeof(Polygone)))
                return croise((Polygone)forme);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                return forme.croise(this);
            else
                throw new NotImplementedException("Fonction inexistante : Croisement d'un(e) " + this.GetType().Name + " et d'un(e) " + typeForme.Name);
        }

        /// <summary>
        /// Retourne si le Polygone croise le Segment donnée
        /// </summary>
        /// <param name="forme">Segment testé</param>
        /// <returns>Vrai si le Polygone croise le Segment testé</returns>
        protected bool croise(Segment segment)
        {
            // On teste si le segment croise un des cotés du polygone
            foreach (Segment cote in cotes)
            {
                if (cote.croise(segment))
                {
                    return true;
                }
                
            }

            return false;
        }

        /// <summary>
        /// Retourne si le Polygone croise la Droite donnée
        /// </summary>
        /// <param name="forme">Droite testée</param>
        /// <returns>Vrai si le Polygone croise la Droite testée</returns>
        protected bool croise(Droite droite)
        {
            // On teste si la droite croise un des cotés du polygone
            foreach (Segment cote in cotes)
                if (cote.croise(droite))
                    return true;

            return false;
        }

        /// <summary>
        /// Retourne si le Polygone croise le Polygone donnée
        /// </summary>
        /// <param name="forme">Polygone testé</param>
        /// <returns>Vrai si le Polygone croise le Polygone testé</returns>
        protected bool croise(Polygone polygone)
        {
            // On teste si un des cotés du polygone croise un des cotés de l'autre polygone
            foreach (Segment cote in cotes)
                foreach (Segment coteAutre in polygone.cotes)
                    if (cote.croise(coteAutre))
                        return true;

            return false;
        }

        public List<PointReel> getCroisements(Segment segment)
        {
            List<PointReel> retour = new List<PointReel>();

            foreach (Segment s in Cotes)
            {
                PointReel croisement = segment.getCroisement(s);
                if (croisement != null)
                    retour.Add(croisement);
            }

            return retour;
        }

        #endregion

        #region Distance

        /// <summary>
        /// Retourne la distance minimum entre le Polygone courant et la Forme donnée
        /// </summary>
        /// <param name="point">Forme testée</param>
        /// <returns>Distance minimum entre le Polygone courant et la Forme testée</returns>
        public double Distance(IForme forme)
        {
            Type typeForme = forme.GetType();

            if (typeForme.IsAssignableFrom(typeof(Segment)))
                return Distance((Segment)forme);
            else if (typeForme.IsAssignableFrom(typeof(PointReel)))
                return Distance((PointReel)forme);
            else if (typeForme.IsAssignableFrom(typeof(Droite)))
                return Distance((Droite)forme);
            else if (typeForme.IsAssignableFrom(typeof(Polygone)) || typeForme.IsSubclassOf(typeof(Polygone)))
                return Distance((Polygone)forme);
            else if (typeForme.IsAssignableFrom(typeof(Cercle)))
                return Distance((Cercle)forme);
            else
                throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne la distance minimum entre le Polygone courant et le Segment donné
        /// </summary>
        /// <param name="point">Segment testé</param>
        /// <returns>Distance minimum entre le Polygone courant et le Segment testé</returns>
        public double Distance(Segment segment)
        {
            // Le segment sait le faire
            return segment.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimum entre le Polygone courant et la Droite donnée
        /// </summary>
        /// <param name="point">Droite testée</param>
        /// <returns>Distance minimum entre le Polygone courant et la Droite testée</returns>
        public double Distance(Droite droite)
        {
            return droite.Distance(this);
        }

        /// <summary>
        /// Retourne la distance minimum entre le Polygone courant et le Cercle donné
        /// </summary>
        /// <param name="point">Cercle testé</param>
        /// <returns>Distance minimum entre le Polygone courant et le Cercle testé</returns>
        public double Distance(Cercle Cercle)
        {
            double distanceMin = double.MaxValue;

            foreach (Segment s in Cotes)
                distanceMin = Math.Min(distanceMin, s.Distance(Cercle));

            return distanceMin;
        }

        /// <summary>
        /// Retourne la distance minimum entre le Polygone courant et le Polygone donné
        /// </summary>
        /// <param name="point">Polygone testé</param>
        /// <returns>Distance minimum entre le Polygone courant et le Polygone testé</returns>
        public double Distance(Polygone polygone)
        {
            double minDistance = double.MaxValue;

            foreach (Segment s1 in polygone.Cotes)
                foreach (Segment s2 in Cotes)
                {
                    if (s1.croise(s2))
                        return 0;
                    minDistance = Math.Min(minDistance, s1.Distance(s2));
                }

            return minDistance;
        }

        /// <summary>
        /// Retourne la distance minimum entre le Polygone courant et le PointReel donné
        /// </summary>
        /// <param name="point">PointReel testé</param>
        /// <returns>Distance minimum entre le Polygone courant et le PointReel testé</returns>
        public double Distance(PointReel point)
        {
            // C'est la distance minimale entre le point et chaque segment

            if (contient(point))
                return 0;

            double distanceMin = double.MaxValue;

            foreach (Segment s in cotes)
                distanceMin = Math.Min(distanceMin, s.Distance(point));

            return distanceMin;
        }

        #endregion

        #region Intersection

        private List<PointReel> triListPointAuPlusProche(PointReel reff, List<PointReel> lpr)
        {
            List<PointReel> lprReturn = new List<PointReel>();
            int min = 0;
            double distanceMin = double.MaxValue;
            double distance;
            while (lpr.Count != 0)
            {
                for (int i = 0; i < lpr.Count; i++)
                {
                    if ((distance = reff.Distance(lpr[i])) < distanceMin)
                    {
                        min = i;
                        distanceMin = distance;
                    }
                }
                lprReturn.Add(lpr[min]);
                lpr.RemoveAt(min);
                min = 0;
                distanceMin = double.MaxValue;
            }
            return lprReturn;
        }
        /// <summary>
        ///     fonction privé pour simplifier intersection
        /// </summary>
        /// <param name="p2"> Le polygone a découper ( les segement seront des bout de celui la )</param>
        /// <param name="p1"> le polygone qui donne ou découpé</param>
        /// <returns></returns>
        private List<Segment> decoupe(Polygone p2, Polygone p1)
        {
            List<Segment> ListSeg = new List<Segment>();

            foreach (Segment seg in p2.Cotes)
            {
                List<PointReel> lpr = p1.getCroisements(seg);
                lpr = this.triListPointAuPlusProche(seg.Debut, lpr);
                // decoupege de chaque coté, en sous segement 
                if (lpr.Count != 0)
                {
                    // premier segement
                    //ListSeg.Add(new Segment(seg.Debut, lpr[0]));
                    addSegList(ListSeg, seg.Debut, lpr[0]);
                    // le découpage
                    for (int i = 0; i < lpr.Count - 1; i++)
                    {
                        //ListSeg.Add(new Segment(lpr[i], lpr[i + 1]));
                        addSegList(ListSeg, lpr[i], lpr[i + 1]);
                    }
                    // et le dernier
                    // ListSeg.Add(new Segment(lpr[lpr.Count - 1], seg.Fin));
                    addSegList(ListSeg, lpr[lpr.Count - 1], seg.Fin);
                }
                // si il y a pas d'intersection on prend tout le segement
                else
                {
                    addSegList(ListSeg, seg.Debut, seg.Fin);
                }
            }
            return ListSeg;
        }

        // ajoute a la liste que si le point n''est pas null
        private void addSegList(List<Segment> list, PointReel p, PointReel p2)
        {
            if (p.X != p2.X || p.Y != p2.Y)
            {
                list.Add(new Segment(p, p2));
            }
        }

        /// <summary>
        ///     retourne les polygones representant la surface de superposition des 2 polygones
        /// </summary>
        /// <param name="p1"> le 2em polygone</param>
        /// <returns> la liste des polygones generé par l'intersection</returns>
        public List<Polygone> Intersection(Polygone p1)
        {
            // on "decoupe" une figure en ségment 
            List<Segment> ListSegThis = decoupe(this, p1);
            List<Segment> ListSegP1 = decoupe(p1, this);

            // on vire le seg qui sont pas dans les 2
            for (int i = ListSegThis.Count - 1; i >= 0; i--)
            {

                if (!p1.contient(ListSegThis[i]))
                {
                    // etragne : ListSegThis.Remove(ListSegThis[i]);
                    ListSegThis.RemoveAt(i);
                    //alert("pas dedans");
                }
                else
                {
                }
            }

            for (int i = ListSegP1.Count - 1; i >= 0; i--)
            {
                if (!this.contient(ListSegP1[i]))
                {

                    ListSegP1.RemoveAt(i);// Remove(ListSegP1[i]);
                    //alert("pas dedans");
                }
                else
                {
                }
            }

            List<Segment> bonneListe = new List<Segment>(ListSegThis);
            bonneListe.AddRange(ListSegP1);

            List<Polygone> l = creationPolygone(bonneListe);

            return l;
        }

        private List<Polygone> creationPolygone(List<Segment> bonneListe)
        {
            List<Segment> lsittemp = new List<Segment>();
            List<Polygone> listRetour = new List<Polygone>();
            if (bonneListe.Count == 0)
            {
                return listRetour;
            }



            while (bonneListe.Count != 0)
            {

                lsittemp.Add(bonneListe[0]);
                bonneListe.RemoveAt(0);

                // tant que bouclé, bouclez
                bool boucler = true;

                // simple test comme ça :
                int taille = -1;
                while (boucler)
                {
                    if (taille == bonneListe.Count)
                    {
                        boucler = false;
                    }
                    taille = bonneListe.Count;
                    for (int i = bonneListe.Count - 1; i >= 0; i--)
                    {
                        Segment seg = bonneListe[i];
                        // si c'est le segment qui ferme le poylgone : CAS DANS LE BON SENS
                        if (lsittemp[lsittemp.Count - 1].Fin == seg.Debut && lsittemp[0].Debut == seg.Fin)
                        {
                            bonneListe.RemoveAt(i);

                            lsittemp.Add(seg);
                            listRetour.Add(new Polygone(lsittemp));
                            lsittemp.Clear();
                            boucler = false;
                            break;

                        }
                        else if (lsittemp[lsittemp.Count - 1].Fin == seg.Debut)
                        {
                            bonneListe.RemoveAt(i);
                            lsittemp.Add(seg);


                        }
                        else if (lsittemp[lsittemp.Count - 1].Fin == seg.Fin && lsittemp[0].Debut == seg.Debut)
                        {
                            bonneListe.RemoveAt(i);
                            lsittemp.Add(new Segment(seg.Fin, seg.Debut));
                            listRetour.Add(new Polygone(lsittemp));
                            lsittemp.Clear();
                            boucler = false;
                            break;

                        }
                        else if (lsittemp[lsittemp.Count - 1].Fin == seg.Fin)
                        {
                            bonneListe.RemoveAt(i);
                            lsittemp.Add(new Segment(seg.Fin, seg.Debut));

                        }
                    }

                }
            }

            return listRetour;

        }

        public static List<Polygone> Intersections(List<Polygone> polygones)
        {
            List<Polygone> intersectionsCourant = new List<Polygone>();
            List<Polygone> intersectionsNouveaux = new List<Polygone>();

            if (polygones.Count >= 2)
            {
                intersectionsNouveaux = polygones[0].Intersection(polygones[1]);

                for (int i = 2; i < polygones.Count; i++)
                {
                    intersectionsCourant.Clear();

                    foreach (Polygone p in intersectionsNouveaux)
                        intersectionsCourant.AddRange(p.Intersection(polygones[i]));

                    intersectionsNouveaux.Clear();
                    intersectionsNouveaux.AddRange(intersectionsCourant);
                }
            }

            return intersectionsNouveaux;
        }

        #endregion

        public List<Point> Points
        {
            get
            {
                List<Point> points = new List<Point>();

                foreach (Segment s in Cotes)
                {
                    points.Add(new Point((int)s.Debut.X, (int)s.Debut.Y));
                }

                return points;
            }
        }
    }
}
