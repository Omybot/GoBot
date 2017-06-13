using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using GoBot.Communications;
using System.Threading;

namespace GoBot.Balises
{
    // Les balises tournent dans le sens anti-horaire
    public class Balise
    {
        /// <summary>
        /// Détections effectuées par le capteur 1 de la balise
        /// </summary>
        public List<DetectionBalise> DetectionsCapteur2 { get; set; }

        /// <summary>
        /// Détections effectuées par le capteur 2 de la balise
        /// </summary>
        public List<DetectionBalise> DetectionsCapteur1 { get; set; }

        /// <summary>
        /// Détections effectuées par les capteurs en prenant en compte les deux capteurs
        /// </summary>
        public List<DetectionBalise> Detections { get; set; }

        public List<DetectionBalise> DetectionsRapides { get; set; }

        /// <summary>
        /// Vitesse appliqué à la pwm à appliquer
        /// </summary>
        public double ValeurConsigne { get; set; }

        /// <summary>
        /// Vitesse en tours / seconde à conserver par asservissement
        /// </summary>
        public double VitesseConsigne { get; set; }

        private bool reglageVitesse = false;
        /// <summary>
        /// Vrai si la vitesse doit être réglée à la vitesse de consigne
        /// </summary>
        public bool ReglageVitesse
        {
            get { return reglageVitesse; }
            set { reglageVitesse = value; if (!reglageVitesse && FinAsservissement != null) FinAsservissement(); }
        }

        /// <summary>
        /// Vrai si la vitesse doit être réglée en permanence, faux si on arrête d'asservir dès qu'on a 1% d'erreur
        /// </summary>
        public bool ReglageVitessePermanent { get; set; }

        /// <summary>
        /// Vitesse actuelle mesurée en tours / s de la balise
        /// </summary>
        public double VitesseToursSecActuelle { get; set; }

        /// <summary>
        /// Placement de la balise sur la table de jeu
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Vrai si le réglage de l'offset est en cours
        /// </summary>
        public bool ReglageOffset { get; set; }

        /// <summary>
        /// Nombre de ticks restants pour le réglage d'offset
        /// </summary>
        private int compteurReglageOffset;

        /// <summary>
        /// Mesures pour l'offset du capteur haut
        /// </summary>
        private List<double> anglesMesuresPourOffsetCapteur1;

        /// <summary>
        /// Mesures pour l'offset du capteur bas
        /// </summary>
        private List<double> anglesMesuresPourOffsetCapteur2;

        /// <summary>
        /// Historique des erreurs relatives de vitesse de rotation
        /// </summary>
        private List<double> dernieresErreurs;
        
        /// <summary>
        /// Statistiques sur la communication avec la balise
        /// </summary>
        public BaliseStats Stats { get; private set; }

        public Connection Connexion { get; private set; }

        public List<PointReel> PositionsAdverses { get; private set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="carte">Carte sur laquelle est connectée la balise</param>
        public Balise()
        {
            dernieresErreurs = new List<double>();
            ReglageVitessePermanent = true;
            DetectionsCapteur1 = new List<DetectionBalise>();
            DetectionsCapteur2 = new List<DetectionBalise>();

            Connexion = Connections.ConnectionMove;
            Connexion.FrameReceived += new UDPConnection.ReceptionDelegate(connexion_NouvelleTrame);

            Stats = new BaliseStats(this);
        }

        private int nbDetectionsRapides = 0;

        /// <summary>
        /// Réception d'un message envoyé par la carte de la balise
        /// </summary>
        /// <param name="trame">Message reçu</param>
        public void connexion_NouvelleTrame(Frame trame)
        {
            if (trame == null)
                return;

            try
            {
                if (trame[1] == (byte)FonctionTrame.DetectionBaliseRapide)
                {
                    if (Position != null)
                    {
                        int capteur = trame[2];

                        double debut = 360 - ((trame[3] * 256 + trame[4]) / 100.0) + Config.CurrentConfig.GetOffsetBalise(capteur);
                        double fin = 360 - ((trame[5] * 256 + trame[6]) / 100.0) + Config.CurrentConfig.GetOffsetBalise(capteur);

                        debut = debut + Position.Angle;
                        fin = fin + Position.Angle;

                        if (DetectionsRapides == null)
                            DetectionsRapides = new List<DetectionBalise>();

                        DetectionBalise detect = new DetectionBalise(this, debut, fin);

                        bool recalcul = false;
                        if (capteur == 2 && detect.Distance > 1250)
                        {
                            recalcul = true;
                            detect.Distance = 1250;
                        }
                        else if (capteur == 2 && detect.Distance < 480)
                        {
                            recalcul = true;
                            detect.Distance = 480;
                        }
                        else if (capteur == 3 && detect.Distance > 600)
                        {
                            recalcul = true;
                            detect.Distance = 600;
                        }
                        else if (capteur == 3 && detect.Distance < 300)
                        {
                            recalcul = true;
                            detect.Distance = 300;
                        }

                        if (recalcul)
                        {
                            // Un peu de trigo pas bien compliquée
                            double xPoint = Position.Coordonnees.X + Math.Cos(detect.AngleCentral.AngleRadians) * detect.Distance;
                            double yPoint = Position.Coordonnees.Y + Math.Sin(detect.AngleCentral.AngleRadians) * detect.Distance;

                            detect.Position = new PointReel(xPoint, yPoint);
                        }

                        DetectionsRapides.Add(detect);

                        nbDetectionsRapides++;

                        PositionsChange();
                    }
                }

                if (trame[1] == (byte)FonctionTrame.DetectionBalise)
                {
                    if (Position != null)
                    {
                        if (DetectionsRapides != null)
                        {
                            // Vide les détections rapides datant de plus d'un tour
                            for (int i = 0; i < DetectionsRapides.Count - nbDetectionsRapides; i++)
                                DetectionsRapides.RemoveAt(0);
                        }

                        nbDetectionsRapides = 0;

                        int noCapteur = trame[2];

                        // Réception d'une mesure sur un tour de rotation
                        // Vérification checksum

                        // Calcul de la vitesse de rotation
                        int nbTicks = trame[3] * 256 + trame[4];
                        VitesseToursSecActuelle = 1 / (nbTicks * 0.0000064);

                        int nouvelleVitesse = 0;
                        if (ReglageVitesse)
                            nouvelleVitesse = AsservissementVitesse();

                        // Réception des données angulaires

                        int nbMesures1 = trame[5];
                        int nbMesures2 = trame[6];

                        // Si on a un nombre impair de fronts on laisse tomber cette mesure, elle n'est pas bonne
                        if (nbMesures1 % 2 != 0 || nbMesures2 % 2 != 0)
                        {
                            Console.WriteLine("Erreur de détection (fronts impairs)");
                            return;
                        }

                        nbMesures1 = nbMesures1 / 2;
                        nbMesures2 = nbMesures2 / 2;

                        // Vérification de la taille de la trame
                        if (trame.Length != 7 + nbMesures1 * 4 + nbMesures2 * 4)
                        {
                            Console.WriteLine("Erreur de taille de trame");
                            return;
                        }

                        // Réception des mesures du capteur 1
                        DetectionsCapteur1.Clear();
                        List<int> tabAngle = new List<int>();

                        long verif = 0;
                        for (int i = 0; i < nbMesures1 * 4; i += 2)
                        {
                            int valeur = trame[7 + i] * 256 + trame[7 + i + 1];
                            tabAngle.Add(valeur);
                            verif += valeur * (i / 2 + 1);
                        }

                        tabAngle.Sort();

                        for (int i = 0; i < nbMesures1 * 2; i++)
                        {
                            verif -= tabAngle[i] * (i + 1);
                        }

                        if (verif != 0)
                        {
                            Console.WriteLine("Inversion détectée capteur 1");
                        }

                        for (int i = 0; i < nbMesures1; i++)
                        {
                            double debut = 360 - (tabAngle[i * 2] / 100.0) + Config.CurrentConfig.GetOffsetBalise(1);
                            double fin = 360 - (tabAngle[i * 2 + 1] / 100.0) + Config.CurrentConfig.GetOffsetBalise(1);

                            debut = debut + Position.Angle;
                            fin = fin + Position.Angle;
                            
                            DetectionBalise detect = new DetectionBalise(this, debut, fin);

                            bool recalcul = false;
                            if (detect.Distance > 600)
                            {
                                recalcul = true;
                                detect.Distance = 600;
                            }
                            else if (detect.Distance < 300)
                            {
                                recalcul = true;
                                detect.Distance = 300;
                            }

                            if (recalcul)
                            {
                                // Un peu de trigo pas bien compliquée
                                double xPoint = Position.Coordonnees.X + Math.Cos(detect.AngleCentral.AngleRadians) * detect.Distance;
                                double yPoint = Position.Coordonnees.Y + Math.Sin(detect.AngleCentral.AngleRadians) * detect.Distance;

                                detect.Position = new PointReel(xPoint, yPoint);
                            }

                            DetectionsCapteur1.Add(detect);
                        }

                        // Réception des mesures du capteur 2

                        int offSet = nbMesures1 * 4 + 7;

                        DetectionsCapteur2.Clear();

                        // tableau pour trier les angles ( correction logiciel )
                        tabAngle.Clear();

                        verif = 0;
                        for (int i = 0; i < nbMesures2 * 4; i += 2)
                        {
                            int valeur = trame[offSet + i] * 256 + trame[offSet + i + 1];
                            tabAngle.Add(valeur);
                            verif += valeur * (i / 2 + 1);
                        }

                        tabAngle.Sort();

                        for (int i = 0; i < nbMesures2 * 2; i++)
                        {
                            verif -= tabAngle[i] * (i + 1);
                        }

                        if (verif != 0)
                        {
                            Console.WriteLine("Inversion détectée capteur 2");
                        }

                        for (int i = 0; i < nbMesures2; i++)
                        {
                            double debut = 360 - (tabAngle[i * 2] / 100.0) + Config.CurrentConfig.GetOffsetBalise(2);
                            double fin = 360 - (tabAngle[i * 2 + 1] / 100.0) + Config.CurrentConfig.GetOffsetBalise(2);

                            debut = debut + Position.Angle;
                            fin = fin + Position.Angle;

                            DetectionBalise detect = new DetectionBalise(this, debut, fin);

                            bool recalcul = false;
                            if (detect.Distance > 1250)
                            {
                                recalcul = true;
                                detect.Distance = 1250;
                            }
                            else if (detect.Distance < 480)
                            {
                                recalcul = true;
                                detect.Distance = 480;
                            }

                            if (recalcul)
                            {
                                // Un peu de trigo pas bien compliquée
                                double xPoint = Position.Coordonnees.X + Math.Cos(detect.AngleCentral.AngleRadians) * detect.Distance;
                                double yPoint = Position.Coordonnees.Y + Math.Sin(detect.AngleCentral.AngleRadians) * detect.Distance;

                                detect.Position = new PointReel(xPoint, yPoint);
                            }

                            DetectionsCapteur2.Add(detect);
                        }

                        // Réglage de l'offset d'angle des capteurs
                        if (ReglageOffset)
                        {
                            // Si on a une mesure incorrecte (une mesure correcte demande 2 détections sur chaque balise : un reflecteur au "centre" et un autre en bas de la piste)
                            // Le réglage est annulé
                            /*if (DetectionsCapteur1.Count == 2 && DetectionsCapteur2.Count == 2)
                            {
                                // 3 cas où on passe d'abord par la balise en bas de la piste avant celle du milieu (sens de rotation anti-horaire)
                                if (Carte == GoBot.Carte.RecBun && Plateau.NotreCouleur == Plateau.CouleurGaucheJaune ||
                                    Carte == GoBot.Carte.RecBeu && Plateau.NotreCouleur == Plateau.CouleurGaucheJaune ||
                                    Carte == GoBot.Carte.RecBoi && Plateau.NotreCouleur == Plateau.CouleurDroiteVert)
                                {
                                    DetectionsCapteur1.RemoveAt(0);
                                    DetectionsCapteur2.RemoveAt(0);
                                }

                                if (ReglageOffset)
                                {
                                    compteurReglageOffset--;
                                    // On ajoute les angles mesurés à l'historique
                                    anglesMesuresPourOffsetCapteur2.Add(DetectionsCapteur2[0].AngleCentral);
                                    anglesMesuresPourOffsetCapteur1.Add(DetectionsCapteur1[0].AngleCentral);
                                }
                            }*/
                            if (DetectionsCapteur1.Count == 1 && DetectionsCapteur2.Count == 1)
                            {
                                compteurReglageOffset--;
                                // On ajoute les angles mesurés à l'historique
                                anglesMesuresPourOffsetCapteur2.Add(DetectionsCapteur2[0].AngleCentral);
                                anglesMesuresPourOffsetCapteur1.Add(DetectionsCapteur1[0].AngleCentral);
                            }

                            if (ReglageOffset && compteurReglageOffset == 0)
                            {
                                // Compteur arrivé à la fin, on calcule l'offset
                                double moyenne = 0;

                                foreach (double dv in anglesMesuresPourOffsetCapteur1)
                                    moyenne += dv;

                                moyenne /= anglesMesuresPourOffsetCapteur1.Count;

                                // Calcul l'offset en fonction de ce qu'il est censé mesurer au centre
                                moyenne = 0 - moyenne;

                                // On le sauve dans la config (haut)
                                Config.CurrentConfig.SetOffsetBalise(1, moyenne + Config.CurrentConfig.GetOffsetBalise(1));

                                moyenne = 0;

                                foreach (double dv in anglesMesuresPourOffsetCapteur2)
                                    moyenne += dv;

                                moyenne /= anglesMesuresPourOffsetCapteur2.Count;
                                moyenne = 0 - moyenne;

                                // On le sauve dans la config (bas)
                                Config.CurrentConfig.SetOffsetBalise(2, moyenne + Config.CurrentConfig.GetOffsetBalise(2));
                                Config.Save();
                                // Réglage terminé
                                ReglageOffset = false;
                                if (CalibrationAngulaireTerminee != null) CalibrationAngulaireTerminee();
                            }
                        }

                        Detections = new List<DetectionBalise>();
                        Detections.AddRange(DetectionsCapteur1);
                        Detections.AddRange(DetectionsCapteur2);

                        // Retire les détections correspondant à la position de robots alliés
                        if (!ReglageOffset && Plateau.ReflecteursNosRobots)
                        {
                            foreach (Robot robot in Robots.DicRobots.Values)
                            {
                                for (int i = 0; i < Detections.Count; i++)
                                {
                                    DetectionBalise detection = Detections[i];
                                    // Calcul du 3ème point du triangle rectangle Balise / Gros robot
                                    Droite droiteBalise0Degres = new Droite(Position.Coordonnees, new PointReel(Position.Coordonnees.X + 500, Position.Coordonnees.Y));
                                    Droite perpendiculaire = droiteBalise0Degres.GetPerpendiculaire(robot.Position.Coordonnees);
                                    PointReel troisiemePoint = perpendiculaire.getCroisement(droiteBalise0Degres);
                                    double distanceBaliseTroisiemePoint = troisiemePoint.Distance(Position.Coordonnees);
                                    double distanceBaliseRobot = robot.Position.Coordonnees.Distance(Position.Coordonnees);

                                    double a = Math.Acos(distanceBaliseTroisiemePoint / distanceBaliseRobot);
                                    Angle angleGrosRobot = new Angle(a, AnglyeType.Radian);
                                    Angle angleDetection = new Angle(detection.AngleCentral);

                                    double marge = 4;

                                    if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                                    {
                                        Angle diff = new Angle(180) - (angleDetection - angleGrosRobot);
                                        if (Math.Abs((diff).AngleDegres) < marge)
                                        {
                                            Detections.RemoveAt(i);
                                            i--;
                                        }
                                    }
                                    else if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                                    {
                                        Angle diff = angleGrosRobot - angleDetection;
                                        if (Math.Abs((diff).AngleDegres) < marge)
                                        {
                                            Detections.RemoveAt(i);
                                            i--;
                                        }
                                    }
                                }
                            }
                        }

                        // Génération de l'event de notification de détection
                        PositionsChange();
                        Actualisation();
                    }
                }
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// Réglage de la vitesse de rotation de la balise en modifiant la valeur de la pwm
        /// </summary>
        /// <param name="vitesse">Valeur pwm à appliquer au moteur</param>
        public void VitesseRotation(int vitesse)
        {
            // Les valeurs correctes sont entre 0 et 312
            if (vitesse > 312 || vitesse < 0)
            {
                vitesse = 312;
                Console.WriteLine("Erreur d'affectation de vitesse");
            }

            ValeurConsigne = vitesse;
            Frame t = TrameFactory.BaliseVitesse(vitesse);
            Connexion.SendMessage(t);
        }

        //Déclaration du délégué pour l’évènement détection de positions
        public delegate void PositionsChangeDelegate();
        //Déclaration de l’évènement utilisant le délégué
        public event PositionsChangeDelegate PositionsChange;

        //Déclaration du délégué pour l’évènement fin de l'asservissement de la balise (la balise est reglée à la bonne vitesse)
        public delegate void FinAsservissementDelegate();
        //Déclaration de l’évènement utilisant le délégué
        public event FinAsservissementDelegate FinAsservissement;

        //Déclaration du délégué pour évènement simple
        public delegate void ChangeDelegate();
        //Déclaration de l’évènement utilisant le délégué
        public event ChangeDelegate CalibrationAngulaireTerminee;

        /// <summary>
        /// Démarre le réglage d'offset sur le nombre de mesures spécifié
        /// </summary>
        /// <param name="nbMesures">Nombre de mesures à moyenner pour calculer l'offset</param>
        public void ReglerOffset(int nbMesures)
        {
            // Réinitialisation des offsets
            Config.CurrentConfig.SetOffsetBalise(1, 0);
            Config.CurrentConfig.SetOffsetBalise(2, 0);

            compteurReglageOffset = nbMesures;
            ReglageOffset = true;
            anglesMesuresPourOffsetCapteur1 = new List<double>();
            anglesMesuresPourOffsetCapteur2 = new List<double>();
        }

        /// <summary>
        /// Ajuste la valeur pwm en fonction de la vitesse de rotation actuelle
        /// </summary>
        public int AsservissementVitesse()
        {
            dernieresErreurs.Add(VitesseConsigne - VitesseToursSecActuelle);

            // On ne garde que les 10 dernières mesures en mémoire
            if (dernieresErreurs.Count > 10)
                dernieresErreurs.RemoveAt(0);

            // Asservissement de la vitesse en fonction de l'erreur mesurée au tour précédent
            // 150 est un coefficient modifiable pour la réactivité de l'asservissement
            int nouvelleVitesse = (int)Math.Min((ValeurConsigne + (VitesseConsigne - VitesseToursSecActuelle) * 70.0), 312);
            VitesseRotation(nouvelleVitesse);

            if (!ReglageVitessePermanent && VitesseConsigne < VitesseToursSecActuelle * 1.01 && VitesseConsigne > VitesseToursSecActuelle * 0.99)
            {
                // On arrête l'asservissement si les 10 dernières valeurs sont justes à 1% près et qu'on ne veut pas asservir en continu
                bool historiqueOk = true;
                foreach (double erreur in dernieresErreurs)
                {
                    if (erreur > VitesseConsigne * 0.01)
                    {
                        historiqueOk = false;
                        break;
                    }
                }
                ReglageVitesse = !historiqueOk;
            }

            return nouvelleVitesse;
        }

        public DetectionBalise MoyennerMesures(int nbMesures)
        {
            // TODO
            return null;
        }

        /// <summary>
        /// Lance la balise à une vitesse de consigne
        /// </summary>
        /// <param name="vitesse">Vitesse de consigne en tours / seconde</param>
        public void Lancer(double vitesse)
        {
            VitesseRotation(2400);
            VitesseConsigne = vitesse;
            ReglageVitesse = true;
            ReglageVitessePermanent = true;
            // Pour être sûr au cas où...
            VitesseRotation(2400);
        }

        /// <summary>
        /// Arrête la balise
        /// </summary>
        public void Stop()
        {
            VitesseRotation(0);
            ReglageVitesse = false;
        }

        /// <summary>
        /// Actualisation des positions détectées par les balises par interpolation selon la méthode choisie
        /// </summary>
        public void Actualisation(bool balise = true, PointReel point = null)
        {
            try
            {
                List<PointReel> ennemis = new List<PointReel>();
                List<PointReel> ennemisReduits = new List<PointReel>();

                if (balise)
                    ennemis.AddRange(Detections.Select(f => f.Position));
                else
                    ennemis.Add(point);

                while (ennemis.Count > 0)
                {
                    List<int> detectionsSimilaires = new List<int>();

                    for (int j = ennemis.Count - 1; j > 0; j--)
                    {
                        if (ennemis[0].Distance(ennemis[j]) < 150)
                            detectionsSimilaires.Add(j);
                    }
                    detectionsSimilaires.Add(0);
                    int coeff = 0;
                    double x = 0, y = 0;
                    for (int i = 0; i < detectionsSimilaires.Count; i++)
                    {
                        x += (ennemis[detectionsSimilaires[i]].X * (i + 1) * (i + 1));
                        y += (ennemis[detectionsSimilaires[i]].Y * (i + 1) * (i + 1));

                        ennemis.RemoveAt(detectionsSimilaires[i]);

                        coeff += (i + 1) * (i + 1);
                    }

                    x /= coeff;
                    y /= coeff;

                    ennemisReduits.Add(new PointReel(x, y));
                }

                PositionsAdverses = new List<PointReel>(ennemisReduits);

                if (PositionEnnemisActualisee != null)
                    PositionEnnemisActualisee(PositionsAdverses);

            }
            catch (Exception)
            {
            }
        }

        //Déclaration du délégué pour l’évènement de position des ennemis
        public delegate void PositionEnnemisDelegate(List<PointReel> positions);
        //Déclaration de l’évènement utilisant le délégué
        public event PositionEnnemisDelegate PositionEnnemisActualisee;
    }
}
