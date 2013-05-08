using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System.Drawing;

namespace GoBot
{
    public class PointReelGenere
    {
        public PointReel Point { get; set; }
        public List<DetectionBalise> DetectionsOrigine { get; set; }

        public PointReelGenere(PointReel point, List<DetectionBalise> detections)
        {
            Point = point;
            DetectionsOrigine = detections;
        }
    }

    /// <summary>
    /// Permet de transformer les détections des balises en coordonnées des alliés et ennemis
    /// </summary>
    public class InterpreteurBalise
    {
        enum ModeInterpretation
        {
            /// <summary>
            /// La méthode des intersections consiste à calculer toutes les intersections de médianes de détection et de les regrouper ensemble
            /// pour en déduire la position de tous les robots
            /// </summary>
            Intersections,
            /// <summary>
            /// La méthode des polygones consiste à calculer les surfaces de juxtaposition des détections des 3 balises pour positionner
            /// les robots sur la piste. Cette méthode nécessite que toutes les balises aient une vision sur l'ensemble des balises sans quoi
            /// la superposition des 3 détection ne sera pas réalisée
            /// </summary>
            Polygones
        }

        /// <summary>
        /// Vrai si les données de la balise 1 ont été reçues depuis la dernière interpolation de positions
        /// </summary>
        private bool donneesBalise1Recues;
        /// <summary>
        /// Vrai si les données de la balise 2 ont été reçues depuis la dernière interpolation de positions
        /// </summary>
        private bool donneesBalise2Recues;
        /// <summary>
        /// Vrai si les données de la balise 3 ont été reçues depuis la dernière interpolation de positions
        /// </summary>
        private bool donneesBalise3Recues;

        /// <summary>
        /// Ensemble des détections du capteur bas de la balise 1 pour le calcul d'interpolation courant
        /// </summary>
        public List<DetectionBalise> DetectionBalise1Bas { get; private set; }
        /// <summary>
        /// Ensemble des détections du capteur bas de la balise 2 pour le calcul d'interpolation courant
        /// </summary>
        public List<DetectionBalise> DetectionBalise2Bas { get; private set; }
        /// <summary>
        /// Ensemble des détections du capteur bas de la balise 3 pour le calcul d'interpolation courant
        /// </summary>
        public List<DetectionBalise> DetectionBalise3Bas { get; private set; }

        /// <summary>
        /// Ensemble des détections du capteur haut de la balise 1 pour le calcul d'interpolation courant
        /// </summary>
        public List<DetectionBalise> DetectionBalise1Haut { get; private set; }
        /// <summary>
        /// Ensemble des détections du capteur haut de la balise 2 pour le calcul d'interpolation courant
        /// </summary>
        public List<DetectionBalise> DetectionBalise2Haut { get; private set; }
        /// <summary>
        /// Ensemble des détections du capteur haut de la balise 3 pour le calcul d'interpolation courant
        /// </summary>
        public List<DetectionBalise> DetectionBalise3Haut { get; private set; }

        // Uniquement pour affichage et debug des calculs d'interpolation de la méthode par intersections
        public List<PointReelGenere> Intersections { get; private set; }
        public List<List<PointReelGenere>> RegroupementsIntersections { get; private set; }
        public List<PointReelGenere> MoyennesIntersections { get; private set; }
        public List<List<PointReelGenere>> RegroupementsDistance { get; private set; }
        public List<PointReelGenere> MoyennesDistance { get; private set; }
        public List<List<PointReel>> AssociationPointDistanceIntersection { get; private set; }

        /// <summary>
        /// Ensemble des détections des capteurs bas de toutes les balises
        /// </summary>
        public List<DetectionBalise> DetectionBalisesBas
        {
            get
            {
                List<DetectionBalise> liste = new List<DetectionBalise>();
                liste.AddRange(DetectionBalise1Bas);
                liste.AddRange(DetectionBalise2Bas);
                liste.AddRange(DetectionBalise3Bas);

                return liste;
            }
        }

        /// <summary>
        /// Ensemble des détections des capteurs haut de toutes les balises
        /// </summary>
        public List<DetectionBalise> DetectionBalisesHaut
        {
            get
            {
                List<DetectionBalise> liste = new List<DetectionBalise>();
                liste.AddRange(DetectionBalise1Haut);
                liste.AddRange(DetectionBalise2Haut);
                liste.AddRange(DetectionBalise3Haut);

                return liste;
            }
        }

        /// <summary>
        /// Liste des positions Alliées calculées par la dernière interpolation réussie
        /// </summary>
        public List<PointReel> PositionsAlliees { get; private set; }
        /// <summary>
        /// Liste des positions Ennemies calculées par la dernière interpolation réussie
        /// </summary>
        public List<PointReel> PositionsEnnemies { get; private set; }

        public InterpreteurBalise()
        {
            donneesBalise1Recues = false;
            donneesBalise2Recues = false;
            donneesBalise3Recues = false;

            Plateau.Balise1.PositionsChange += new Balise.PositionsChangeDelegate(Balise1_PositionsChange);
            Plateau.Balise2.PositionsChange += new Balise.PositionsChangeDelegate(Balise2_PositionsChange);
            Plateau.Balise3.PositionsChange += new Balise.PositionsChangeDelegate(Balise3_PositionsChange);
        }

        /// <summary>
        /// Réception des données de la balise 1
        /// </summary>
        void Balise1_PositionsChange()
        {
            DetectionBalise1Bas = new List<DetectionBalise>(Plateau.Balise1.DetectionsBas);
            DetectionBalise1Haut = new List<DetectionBalise>(Plateau.Balise1.DetectionsHaut);
            donneesBalise1Recues = true;

            // Si on a reçu les données de toutes les balises, on calcule l'interpolation des positions
            if (donneesBalise1Recues && donneesBalise2Recues && donneesBalise3Recues)
                Actualisation();
        }

        /// <summary>
        /// Réception des données de la balise 1
        /// </summary>
        void Balise2_PositionsChange()
        {
            DetectionBalise2Bas = new List<DetectionBalise>(Plateau.Balise2.DetectionsBas);
            DetectionBalise2Haut = new List<DetectionBalise>(Plateau.Balise2.DetectionsHaut);
            donneesBalise2Recues = true;

            // Si on a reçu les données de toutes les balises, on calcule l'interpolation des positions
            if (donneesBalise1Recues && donneesBalise2Recues && donneesBalise3Recues)
                Actualisation();
        }

        /// <summary>
        /// Réception des données de la balise 1
        /// </summary>
        void Balise3_PositionsChange()
        {
            DetectionBalise3Bas = new List<DetectionBalise>(Plateau.Balise3.DetectionsBas);
            DetectionBalise3Haut = new List<DetectionBalise>(Plateau.Balise3.DetectionsHaut);
            donneesBalise3Recues = true;

            // Si on a reçu les données de toutes les balises, on calcule l'interpolation des positions
            if (donneesBalise1Recues && donneesBalise2Recues && donneesBalise3Recues)
                Actualisation();
        }

        /// <summary>
        /// Actualisation des positions détectées par les balises par interpolation selon la méthode choisie
        /// </summary>
        void Actualisation()
        {
            try
            {
                donneesBalise1Recues = false;
                donneesBalise2Recues = false;
                donneesBalise3Recues = false;

                InterpreterDetection(ModeInterpretation.Intersections);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Interprète les mesures des 3 balises pour en extraire la position de tous les robots sur la piste
        /// </summary>
        /// <param name="mode">Mode de calcul de l'interpolation</param>
        private void InterpreterDetection(ModeInterpretation mode)
        {
            List<PointReel> detectionBas = null;
            List<PointReel> detectionHaut = null;

            PositionsAlliees = new List<PointReel>();
            PositionsEnnemies = new List<PointReel>();

            if(mode == ModeInterpretation.Polygones)
            {
                detectionBas = InterpolationPolygonale(DetectionBalise1Bas, DetectionBalise2Bas, DetectionBalise3Bas);
                detectionHaut = InterpolationPolygonale(DetectionBalise1Haut, DetectionBalise2Haut, DetectionBalise3Haut);
            }
            else if(mode == ModeInterpretation.Intersections)
            {
                detectionBas = new List<PointReel>();// DetectionParIntersections(DetectionBalise1Bas, DetectionBalise2Bas, DetectionBalise3Bas);
                detectionHaut = DetectionParIntersections(DetectionBalise1Haut, DetectionBalise2Haut, DetectionBalise3Haut);
            }

            //detectionHaut.Clear();

            // Cas si il y a plus de 2 détections en haut : c'est qu'on a des balises réfléchissantes sur la tête
            // On retire donc les positions alliées des positions ennemies
            if (detectionHaut.Count > 2)
            {
                // On cherche nos points en bas pour retirer nos positions des positions ennemies
                foreach (PointReel p in detectionBas)
                {
                    double distance = double.MaxValue;
                    int plusProche = -1;

                    for (int i = 0; i < detectionHaut.Count; i++)
                    {
                        double distanceActuelle = p.Distance(detectionHaut[i]);
                        if (distanceActuelle < distance)
                        {
                            distance = distanceActuelle;
                            plusProche = i;
                        }
                    }

                    // Si le point est à moins de 20 cm on l'enlève
                    if (distance < 200)
                        detectionHaut.RemoveAt(plusProche);
                }

                PositionsAlliees = new List<PointReel>(detectionBas);
                PositionsEnnemies = new List<PointReel>(detectionHaut);

                PositionEnnemisActualisee(this);
            }
            // Cas attendu si on a pas de balise réfléchissante sur la tête
            else if (detectionBas.Count == 2 && detectionHaut.Count == 2)
            {
                PositionsAlliees = new List<PointReel>(detectionBas);
                PositionsEnnemies = new List<PointReel>(detectionHaut);

                PositionEnnemisActualisee(this);
            }
            else
            {
                PositionsAlliees = new List<PointReel>(detectionBas);
                PositionsEnnemies = new List<PointReel>(detectionHaut);

                PositionEnnemisActualisee(this);
                //Console.WriteLine("Interprétation étrange : " + detectionHaut.Count + " alliés et " + detectionHaut.Count + " adversaires.");
            }
        }

        #region Interprétation par polygones

        /// <summary>
        /// Retourne la liste des points calculés par la méthode des polygones
        /// </summary>
        /// <param name="detectionBalise1">Détections effectuées par la balise 1</param>
        /// <param name="detectionBalise2">Détections effectuées par la balise 2</param>
        /// <param name="detectionBalise3">Détections effectuées par la balise 3</param>
        /// <returns></returns>
        private List<PointReel> InterpolationPolygonale(List<DetectionBalise> detectionBalise1, List<DetectionBalise> detectionBalise2, List<DetectionBalise> detectionBalise3)
        {
            List<Polygone> polygonesBalise1 = new List<Polygone>();
            List<Polygone> polygonesBalise2 = new List<Polygone>();
            List<Polygone> polygonesBalise3 = new List<Polygone>();

            // On transforme les détections en triangles
            foreach (DetectionBalise detection in detectionBalise1)
                polygonesBalise1.Add(DetectionToPolygone(detection));
            foreach (DetectionBalise detection in detectionBalise2)
                polygonesBalise2.Add(DetectionToPolygone(detection));
            foreach (DetectionBalise detection in detectionBalise3)
                polygonesBalise3.Add(DetectionToPolygone(detection));

            List<Polygone> polygonesInter = new List<Polygone>();

            // Pour chaque combinaison de détection de la balise 1, 2 et 3, on cherche si il y a une juxtaposition des 3 triangles
            foreach (Polygone p1 in polygonesBalise1)
            {
                foreach (Polygone p2 in polygonesBalise2)
                {
                    foreach (Polygone p3 in polygonesBalise3)
                    {
                        List<Polygone> jeuPolygones = new List<Polygone>();
                        jeuPolygones.Add(p1);
                        jeuPolygones.Add(p2);
                        jeuPolygones.Add(p3);

                        List<Polygone> inter = Polygone.Intersections(jeuPolygones);
                        polygonesInter.AddRange(inter);
                    }
                }
            }

            // On remplace chaque polygone par son barycentre
            List<PointReel> positions = new List<PointReel>();
            foreach (Polygone p in polygonesInter)
            {
                double moyenneX = 0;
                double moyenneY = 0;

                foreach (Point point in p.Points)
                {
                    moyenneX += point.X;
                    moyenneY += point.Y;
                }

                moyenneX /= p.Points.Count;
                moyenneY /= p.Points.Count;

                positions.Add(new PointReel(moyenneX, moyenneY));
            }

            // Améliorations possibles : 
            // - Prise en compte des distances de détection pour écarter les faux positifs
            // - Prendre en compte les superpositions d'uniquement 2 détections et des distances pour se permettre qu'une balise ne voit pas

            return positions;
        }

        /// <summary>
        /// Transforme une détection de balise en triangle
        /// </summary>
        /// <param name="detection">Détection de la balise</param>
        /// <returns>Triangle correspondant à la détection</returns>
        public static Polygone DetectionToPolygone(DetectionBalise detection)
        {
            List<PointReel> listePoints = new List<PointReel>();

            // Point de la balise

            double xPoint1 = detection.Balise.Position.Coordonnees.X;
            double yPoint1 = detection.Balise.Position.Coordonnees.Y;

            PointReel point = new PointReel(xPoint1, yPoint1);

            listePoints.Add(point);

            // Point du côté du début de l'angle
            // 5000 valeur arbitraire, assez grande pour dépasser de la table

            xPoint1 = detection.Balise.Position.Coordonnees.X + Math.Cos(Maths.DegreeToRadian(detection.AngleDebut)) * 5000;
            yPoint1 = detection.Balise.Position.Coordonnees.Y + Math.Sin(Maths.DegreeToRadian(detection.AngleDebut)) * 5000;
            point = new PointReel(xPoint1, yPoint1);

            listePoints.Add(point);

            // Point du côté du début de l'angle

            xPoint1 = detection.Balise.Position.Coordonnees.X + Math.Cos(Maths.DegreeToRadian(detection.AngleFin)) * 5000;
            yPoint1 = detection.Balise.Position.Coordonnees.Y + Math.Sin(Maths.DegreeToRadian(detection.AngleFin)) * 5000;
            point = new PointReel(xPoint1, yPoint1);

            listePoints.Add(point);

            Polygone polygone = new Polygone(listePoints);

            return polygone;
        }

        #endregion

        #region Interprétation par Intersections

        /// <summary>
        /// Retourne la liste des points calculées par la méthode des intersections
        /// </summary>
        /// <param name="detectionBalise1">Détections effectuées par la balise 1</param>
        /// <param name="detectionBalise2">Détections effectuées par la balise 2</param>
        /// <param name="detectionBalise3">Détections effectuées par la balise 3</param>
        /// <returns></returns>
        private List<PointReel> DetectionParIntersections(List<DetectionBalise> detectionBalise1, List<DetectionBalise> detectionBalise2, List<DetectionBalise> detectionBalise3)
        {
            List<PointReelGenere> intersections = new List<PointReelGenere>();

            // On calcule tous les croisements entre les médianes de B1 et B2, B2 et B3, B3 et B1
            intersections.AddRange(CroisementsBalises(detectionBalise1, detectionBalise2));
            intersections.AddRange(CroisementsBalises(detectionBalise2, detectionBalise3));
            intersections.AddRange(CroisementsBalises(detectionBalise3, detectionBalise1));
                
            // Pour affichage
            Intersections = new List<PointReelGenere>(intersections);

            // On regroupe les points les plus proches ensemble pour les moyenner
            List<PointReelGenere> intersectionsGroupees = RegroupementPoints(intersections, 2);

            // Pour affichage
            MoyennesIntersections = new List<PointReelGenere>(intersectionsGroupees);

            List<PointReelGenere> positionsDetectees = new List<PointReelGenere>();

            // On liste l'ensemble des points calculés grâce aux angles et distances approximées par les balises
            foreach (DetectionBalise detection in DetectionBalisesHaut)
            {
                List<DetectionBalise> detections = new List<DetectionBalise>();
                detections.Add(detection);
                positionsDetectees.Add(new PointReelGenere(detection.Position, detections));
            }

            // Et on les moyenne en les regroupement par proximité -> ou pas
            List<PointReelGenere> positionsDetecteesGroupees = positionsDetectees;// RegroupementPoints(positionsDetectees, 1);

            // Pour affichage
            MoyennesDistance = positionsDetecteesGroupees;

            List<PointReel> positionsFinales = new List<PointReel>();

            AssociationPointDistanceIntersection = new List<List<PointReel>>();
            // Pour chaque point de distance moyenné, on garde l'intersection moyennée la plus proche

            Dictionary<PointReel, int> compteurProches = new Dictionary<PointReel, int>();

            foreach (PointReelGenere pointDistance in positionsDetecteesGroupees)
            {
                PointReel plusProche = null;
                double distanceMin = 600;

                foreach (PointReelGenere pointIntersection in intersectionsGroupees)
                {
                    bool genereOk = false;

                    foreach(DetectionBalise d1 in pointDistance.DetectionsOrigine)
                        foreach(DetectionBalise d2 in pointIntersection.DetectionsOrigine)
                            if (d1 == d2)
                            {
                                genereOk = true;
                                break;
                            }

                    if (genereOk)
                    {
                        double distance = pointDistance.Point.Distance(pointIntersection.Point);
                        if (distance < distanceMin)
                        {
                            plusProche = pointIntersection.Point;
                            distanceMin = distance;
                        }
                    }
                }

                List<PointReel> asso = new List<PointReel>();
                asso.Add(pointDistance.Point);
                asso.Add(plusProche);
                AssociationPointDistanceIntersection.Add(asso);

                if (plusProche != null && compteurProches.ContainsKey(plusProche))
                    compteurProches[plusProche]++;
                else if(plusProche != null)
                    compteurProches.Add(plusProche, 1);

                /*if (!positionsFinales.Contains(plusProche))
                    positionsFinales.Add(plusProche);*/
            }

            foreach (KeyValuePair<PointReel, int> compteur in compteurProches)
            {
                if(compteur.Value >= 2)
                    positionsFinales.Add(compteur.Key);
            }

            return positionsFinales;
        }

        /// <summary>
        /// Retourne les points de croisements entre les détections de 2 balises
        /// On ne garde que les points proches de ce qui est calculé par la distance des balises (et en particulier celle qui est la plus proche de la cible)
        /// </summary>
        /// <param name="detectionBaliseA">Détection d'une balise</param>
        /// <param name="detectionBaliseB">Détection d'une autre balise</param>
        /// <returns>Intersections conservées</returns>
        private List<PointReelGenere> CroisementsBalises(List<DetectionBalise> detectionBaliseA, List<DetectionBalise> detectionBaliseB)
        {
            List<PointReel> intersections = new List<PointReel>();
            List<PointReelGenere> intersectionsAvecOrigine = new List<PointReelGenere>();

            foreach (DetectionBalise detection1 in detectionBaliseA)
            {
                Droite droite1 = new Droite(detection1.Balise.Position.Coordonnees, detection1.Position);

                foreach (DetectionBalise detection2 in detectionBaliseB)
                {
                    Droite droite2 = new Droite(detection2.Balise.Position.Coordonnees, detection2.Position);
                    PointReel croisement = droite1.getCroisement(droite2);

                    List<DetectionBalise> detections = new List<DetectionBalise>();
                    detections.Add(detection1);
                    detections.Add(detection2);

                    // On ne considère pas les points en dehors du plateau
                    if (croisement != null && Plateau.Contient(croisement))
                    {
                        // Le point le plus proche de la balise (donc plus précis) entre les deux droites qui ont généré le croisement
                        //PointReel positionDistance = detection1.Distance < detection2.Distance ? detection1.Position : detection2.Position;

                        // On ne considère cette intersection que si elle est à moins de 50 cm de la distance donnée par la plus précise des balises
                        // Ce qui permet d'enlever tous les croisements éloignés d'une approximation de balise
                        if (detection1.Position.Distance(croisement) < 500 && detection2.Position.Distance(croisement) < 500)
                            intersectionsAvecOrigine.Add(new PointReelGenere(croisement, detections));
                            //intersections.Add(croisement);
                    }
                }
            }

            return intersectionsAvecOrigine;
        }

        /// <summary>
        /// Regroupe chaque point avec son voisin le plus proche.
        /// Retourne la liste des points moyens de chaque regroupement.
        /// Cela permet d'assembler des points proches ensemble, mais ne fonctionne qu'avec des groupes de 2 ou 3 points
        /// À partir de 4, les points peuvent se grouper 2 par 2 plutôt que les 4 ensemble
        /// </summary>
        /// <param name="points">Points à regrouper par paquets</param>
        /// <param name="var">Pour affichage, 1 pour regroupement des intersections et 2 pour regroupement des points de balise</param>
        /// <returns>Liste des points moyens de chaque regroupement de points</returns>
        public List<PointReelGenere> RegroupementPoints(List<PointReelGenere> points, int var)
        {
            if (points.Count == 1)
                return points;

            Dictionary<PointReelGenere, List<PointReelGenere>> regroupements = new Dictionary<PointReelGenere, List<PointReelGenere>>();
            List<List<PointReelGenere>> regroupementsPoints = new List<List<PointReelGenere>>();

            for (int i = 0; i < points.Count; i++)
            {
                double distanceMin = 200;
                PointReelGenere plusProche = null;

                for (int j = 0; j < points.Count; j++)
                {
                    if (i != j)
                    {
                        double distancePoint = points[i].Point.Distance(points[j].Point);
                        if (distancePoint < distanceMin)
                        {
                            distanceMin = distancePoint;
                            plusProche = points[j];
                        }
                    }
                }

                if (plusProche == null)
                {
                    List<PointReelGenere> listeProches = new List<PointReelGenere>();
                    listeProches.Add(points[i]);
                    regroupementsPoints.Add(listeProches);
                }
                // Si le plus proche est déjà dans une liste, on met notre point dans la même et on lui affecte cette liste
                else if (regroupements.ContainsKey(plusProche) && !regroupements.ContainsKey(points[i]))
                {
                    regroupements[plusProche].Add(points[i]);
                    regroupements.Add(points[i], regroupements[plusProche]);
                }
                else if (regroupements.ContainsKey(points[i]) && !regroupements.ContainsKey(plusProche))
                {
                    regroupements[points[i]].Add(plusProche);
                    regroupements.Add(plusProche, regroupements[points[i]]);
                }
                // Sinon on crée une nouvelle liste avec ces deux points et on leur attribue cette liste à tous les deux
                else if(!regroupements.ContainsKey(points[i]) && !regroupements.ContainsKey(plusProche))
                {
                    List<PointReelGenere> listeProches = new List<PointReelGenere>();
                    listeProches.Add(points[i]);
                    listeProches.Add(plusProche);
                    regroupementsPoints.Add(listeProches);

                    regroupements.Add(points[i], listeProches);
                    regroupements.Add(plusProche, listeProches);
                }
            }

            /*foreach (List<PointReel> regroupement in regroupementsPoints)
            {
                while (regroupement.Count > 3)
                {
                    double moyenneX = 0;
                    double moyenneY = 0;

                    foreach (PointReel point in regroupement)
                    {
                        moyenneX += point.X;
                        moyenneY += point.Y;
                    }

                    moyenneX /= regroupement.Count;
                    moyenneY /= regroupement.Count;

                    PointReel barycentre = new PointReel(moyenneX, moyenneY);

                    int indexMax = 0;
                    double distanceMax = 0;
                    for (int i = 0; i < regroupement.Count; i++)
                    {
                        PointReel point = regroupement[i];
                        double distance = point.Distance(barycentre);
                        if (distanceMax < distance)
                        {
                            distanceMax = distance;
                            indexMax = i;
                        }
                    }

                    regroupement.RemoveAt(indexMax);
                }
            }*/

            List<PointReelGenere> pointsGroupes = new List<PointReelGenere>();

            // Pour affichage
            if (var == 1)
                RegroupementsDistance = new List<List<PointReelGenere>>(regroupementsPoints);
            else if (var == 2)
                RegroupementsIntersections = new List<List<PointReelGenere>>(regroupementsPoints);

            foreach (List<PointReelGenere> listePoints in regroupementsPoints)
            {
                double moyenneX = 0;
                double moyenneY = 0;

                List<DetectionBalise> detections = new List<DetectionBalise>();

                foreach (PointReelGenere point in listePoints)
                {
                    foreach(DetectionBalise detection in point.DetectionsOrigine)
                        if(!detections.Contains(detection))
                            detections.Add(detection);

                    moyenneX += point.Point.X;
                    moyenneY += point.Point.Y;
                }

                moyenneX /= listePoints.Count;
                moyenneY /= listePoints.Count;



                pointsGroupes.Add(new PointReelGenere(new PointReel(moyenneX, moyenneY), detections));
            }

            return pointsGroupes;
        }

        #endregion

        //Déclaration du délégué pour l’évènement de position des ennemis
        public delegate void PositionEnnemisDelegate(InterpreteurBalise interprete);
        //Déclaration de l’évènement utilisant le délégué
        public event PositionEnnemisDelegate PositionEnnemisActualisee;
    }
}
