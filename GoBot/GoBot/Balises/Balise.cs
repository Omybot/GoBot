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
    public class Balise
    {
        private Semaphore semTestConnexion;
        private Semaphore semReceptionBalise;

        public static Balise GetBalise(Carte carte)
        {
            switch (carte)
            {
                case Carte.RecBun:
                    return Plateau.Balise1;
                case Carte.RecBeu:
                    return Plateau.Balise2;
                case Carte.RecBoi:
                    return Plateau.Balise3;
            }

            return null;
        }

        public const int DISTANCE_LASER_TABLE = 62;

        /// <summary>
        /// Tension de la batterie 1
        /// </summary>
        public double Tension1 { get; private set; }

        /// <summary>
        /// Tension de la batterie 2
        /// </summary>
        public double Tension2 { get; private set; }

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

        /// <summary>
        /// Vitesse appliqué à la pwm à appliquer
        /// </summary>
        public double ValeurConsigne { get; set; }

        /// <summary>
        /// Vitesse en tours / seconde à conserver par asservissement
        /// </summary>
        public double VitesseConsigne { get; set; }

        /// <summary>
        /// Vrai si la vitesse doit être réglée à la vitesse de consigne
        /// </summary>
        public bool ReglageVitesse { get; set; }

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
        public bool ReglageOffset { get; private set; }

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
        /// Identificant de la carte électronique de la balise
        /// </summary>
        public Carte Carte { get; set; }

        /// <summary>
        /// Statistiques sur la communication avec la balise
        /// </summary>
        public BaliseStats Stats { get; private set; }

        public Connexion Connexion { get; private set; }

        /// <summary>
        /// Détermine si la balise est rotation (Au moins un tour a été effectué durant la dernière seconde)
        /// </summary>
        public bool EnRotation { get; private set; }
        private System.Timers.Timer timerRotation;
        private int cptRotation;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="carte">Carte sur laquelle est connectée la balise</param>
        public Balise(Carte carte)
        {
            Carte = carte;
            dernieresErreurs = new List<double>();
            ReglageVitessePermanent = true;
            EnRotation = false;
            DetectionsCapteur1 = new List<DetectionBalise>();
            DetectionsCapteur2 = new List<DetectionBalise>();

            switch (carte)
            {
                case GoBot.Carte.RecBun:
                    Connexion = Connexions.ConnexionBun;
                    break;
                case GoBot.Carte.RecBeu:
                    Connexion = Connexions.ConnexionBeu;
                    break;
                case GoBot.Carte.RecBoi:
                    Connexion = Connexions.ConnexionBoi;
                    break;
            }

            Connexion.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(connexion_NouvelleTrame);
            Connexion.ConnexionCheck = new Communications.ConnexionCheck(5000);
            Connexion.ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(TestConnexion);

            Stats = new BaliseStats(this);

            cptRotation = 0;

            timerRotation = new System.Timers.Timer();
            timerRotation.Interval = 1000;
            timerRotation.Elapsed += timerRotation_Elapsed;
        }

        void timerRotation_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            bool temp = EnRotation;
            EnRotation = cptRotation > 0;
            cptRotation = 0;

            if(temp != EnRotation)
                RotationChange(EnRotation);
        }

        /// <summary>
        /// Envoie un ordre de reset électronique à la balise
        /// </summary>
        public void Reset()
        {
            Trame t = TrameFactory.BaliseReset(Carte);
            Connexion.SendMessage(t);
        }

        /// <summary>
        /// Réception d'un message envoyé par la carte de la balise
        /// </summary>
        /// <param name="trame">Message reçu</param>
        public void connexion_NouvelleTrame(Trame trame)
        {
            if (trame == null)
                return;

            try
            {
                // On ne traite que les messages qui nous sont adressés
                if (trame[0] != (byte)Carte)
                    return;

                if (trame[1] == (byte)FonctionBalise.Detection)
                {
                    // Réception d'une mesure sur un tour de rotation
                    // Vérification checksum
                    cptRotation++;

                    int checksumRecu = trame[trame.Length - 1];

                    int checksumCalcul = 0;

                    for (int i = 0; i < trame.Length - 1; i++)
                        checksumCalcul ^= trame[i];

                    if (checksumCalcul != checksumRecu)
                    {
                        Console.WriteLine("Erreur de ckecksum");
                        Connexion.SendMessage(TrameFactory.BaliseErreurDetection(Carte));
                        return;
                    }

                    // Calcul de la vitesse de rotation
                    int nbTicks = trame[2] * 256 + trame[3];
                    VitesseToursSecActuelle = 400.0 / (nbTicks * 0.0064);

                    int nouvelleVitesse = 0;
                    if (ReglageVitesse)
                        nouvelleVitesse = AsservissementVitesse();

                    // Réception des données angulaires

                    int nbMesures1 = trame[4];
                    int nbMesures2 = trame[5];

                    // Si on a un nombre impair de fronts on laisse tomber cette mesure, elle n'est pas bonne
                    if (nbMesures1 % 2 != 0 || nbMesures2 % 2 != 0)
                        return;

                    nbMesures1 = nbMesures1 / 2;
                    nbMesures2 = nbMesures2 / 2;

                    // Vérification de la taille de la trame
                    if (trame.Length != 7 + nbMesures1 * 4 + nbMesures2 * 4)
                    {
                        Console.WriteLine("Erreur de taille de trame");
                        Connexion.SendMessage(TrameFactory.BaliseErreurDetection(Carte));
                        return;
                    }

                    // Réception des mesures du capteur 1
                    DetectionsCapteur1.Clear();
                    List<int> tabAngle = new List<int>();

                    for (int i = 0; i < nbMesures1 * 4; i += 2)
                    {
                        int valeur = trame[6 + i] * 256 + trame[6 + i + 1];
                        tabAngle.Add(valeur);
                    }

                    tabAngle.Sort();

                    for (int i = 0; i < nbMesures1; i++)
                    {
                        double debut = 360 - (tabAngle[i * 2] / 100.0) + Config.CurrentConfig.GetOffsetBalise(Carte, 1);
                        double fin = 360 - (tabAngle[i * 2 + 1] / 100.0) + Config.CurrentConfig.GetOffsetBalise(Carte, 1);

                        DetectionsCapteur1.Add(new DetectionBalise(this, debut, fin));
                    }

                    /*writer.WriteLine((DateTime.Now - prec).TotalMilliseconds + ";" + nouvelleVitesse + ";" + (d == null ? ";;" : d.AngleCentral + ";" + d.Distance + ";") + VitesseToursSecActuelle);
                    prec = DateTime.Now;*/

                    // Réception des mesures du capteur 2

                    int offSet = nbMesures1 * 4 + 6;

                    DetectionsCapteur2.Clear();

                    // tableau pour trier les angles ( correction logiciel )
                    tabAngle.Clear();

                    long verif = 0;
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
                        Console.WriteLine("Inversion détectée");
                    }
                    else
                        Console.Write("-");

                    for (int i = 0; i < nbMesures2; i++)
                    {
                        double debut = 360 - (tabAngle[i * 2] / 100.0) + Config.CurrentConfig.GetOffsetBalise(Carte, 2);
                        double fin = 360 - (tabAngle[i * 2 + 1] / 100.0) + Config.CurrentConfig.GetOffsetBalise(Carte, 2);
                        if (this == Plateau.Balise3)
                        {
                            debut = (debut + 180) % 360;
                            fin = (fin + 180) % 360;
                        }

                        //if (debut < 360 && debut > 0 && fin < 360 && fin > 0)
                        DetectionsCapteur2.Add(new DetectionBalise(this, debut, fin));
                        //else
                        //    Console.WriteLine("Mauvaise mesure : début = " + debut + " / fin = " + fin);
                    }

                    // Réglage de l'offset d'angle des capteurs
                    if (ReglageOffset)
                    {
                        // Si on a une mesure incorrecte (une mesure correcte demande une détection en haut et une en bas)
                        // Le réglage est annulé
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

                            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                            {
                                // Les valeurs sont les angles que doivent retourner chaque balise pour un reflecteur placé au centre de la table (sur le palmier)
                                switch (Carte)
                                {
                                    case GoBot.Carte.RecBun:
                                        moyenne = 33.69 - moyenne;
                                        break;
                                    case GoBot.Carte.RecBeu:
                                        moyenne = 326.31 - moyenne;
                                        break;
                                    case GoBot.Carte.RecBoi:
                                        moyenne = 180 - moyenne;
                                        break;
                                }
                            }
                            else
                            {
                                // Les valeurs sont les angles que doivent retourner chaque balise pour un reflecteur placé au centre de la table (sur le palmier)
                                switch (Carte)
                                {
                                    case GoBot.Carte.RecBun:
                                        moyenne = 213.69 - moyenne;
                                        break;
                                    case GoBot.Carte.RecBeu:
                                        moyenne = 146.31 - moyenne;
                                        break;
                                    case GoBot.Carte.RecBoi:
                                        moyenne = -moyenne;
                                        break;
                                }
                            }

                            // On le sauve dans la config (haut)
                            Config.CurrentConfig.SetOffsetBalise(Carte, 1, moyenne + Config.CurrentConfig.GetOffsetBalise(Carte, 1));

                            moyenne = 0;

                            foreach (double dv in anglesMesuresPourOffsetCapteur2)
                                moyenne += dv;

                            moyenne /= anglesMesuresPourOffsetCapteur2.Count;
                            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                            {
                                switch (Carte)
                                {
                                    case GoBot.Carte.RecBun:
                                        moyenne = 33.69 - moyenne;
                                        break;
                                    case GoBot.Carte.RecBeu:
                                        moyenne = 326.31 - moyenne;
                                        break;
                                    case GoBot.Carte.RecBoi:
                                        moyenne = 180 - moyenne;
                                        break;
                                }
                            }
                            else
                            {
                                // Les valeurs sont les angles que doivent retourner chaque balise pour un reflecteur placé au centre de la table (sur le palmier)
                                switch (Carte)
                                {
                                    case GoBot.Carte.RecBun:
                                        moyenne = 213.69 - moyenne;
                                        break;
                                    case GoBot.Carte.RecBeu:
                                        moyenne = 146.31 - moyenne;
                                        break;
                                    case GoBot.Carte.RecBoi:
                                        moyenne = -moyenne;
                                        break;
                                }
                            }

                            // On le sauve dans la config (bas)
                            Config.CurrentConfig.SetOffsetBalise(Carte, 2, moyenne + Config.CurrentConfig.GetOffsetBalise(Carte, 2));
                            Config.Save();
                            // Réglage terminé
                            ReglageOffset = false;
                            CalibrationAngulaireTerminee();
                        }
                    }

                    Detections = new List<DetectionBalise>();
                    foreach (DetectionBalise d2 in DetectionsCapteur1)
                        Detections.Add(d2);

                    foreach (DetectionBalise d1 in DetectionsCapteur2)
                        Detections.Add(d1);

                    angleTotal = 0;

                    foreach (DetectionBalise detection in Detections)
                        angleTotal += Math.Abs(detection.AngleFin - detection.AngleDebut);

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
                                Droite perpendiculaire = droiteBalise0Degres.getPerpendiculaire(robot.Position.Coordonnees);
                                PointReel troisiemePoint = perpendiculaire.getCroisement(droiteBalise0Degres);
                                double distanceBaliseTroisiemePoint = troisiemePoint.Distance(Position.Coordonnees);
                                double distanceBaliseRobot = robot.Position.Coordonnees.Distance(Position.Coordonnees);

                                double a = Math.Acos(distanceBaliseTroisiemePoint / distanceBaliseRobot);
                                Angle angleGrosRobot = new Angle(a, AnglyeType.Radian);
                                Angle angleDetection = new Angle(detection.AngleCentral);

                                double marge = 4;

                                if (Carte == GoBot.Carte.RecBeu && Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                                {
                                    Angle diff = new Angle(180) - (angleGrosRobot + angleDetection);
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        // Robot repéré sur balise bun
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                                else if (Carte == GoBot.Carte.RecBoi && Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                                {
                                    Angle diff = angleGrosRobot - angleDetection;
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        // Robot repéré sur balise boi
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                                else if (Carte == GoBot.Carte.RecBun && Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                                {
                                    Angle diff = new Angle(180) - (angleDetection - angleGrosRobot);
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        // Robot repéré sur balise beu
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                                else if (Carte == GoBot.Carte.RecBeu && Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                                {
                                    Angle diff = angleDetection + angleGrosRobot;
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        // Robot repéré sur balise beu
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                                else if (Carte == GoBot.Carte.RecBoi && Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                                {
                                    Angle diff = new Angle(180) + angleGrosRobot - angleDetection;
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        // Robot repéré sur balise boi
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                                else if (Carte == GoBot.Carte.RecBun && Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                                {
                                    Angle diff = angleGrosRobot - angleDetection;
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        // Robot repéré sur balise bun
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                            }
                        }
                    }

                    if (semReceptionBalise != null)
                        semReceptionBalise.Release();

                    // Génération de l'event de notification de détection
                    PositionsChange();
                }
                else if (trame[1] == (byte)FonctionBalise.RetourTestConnexion)
                {
                    Tension1 = (double)(trame[2] * 256 + trame[3]) / 100.0;
                    Tension2 = (double)(trame[4] * 256 + trame[5]) / 100.0;

                    if (semTestConnexion != null)
                        semTestConnexion.Release();
                }
            }
            catch (Exception)
            { }

            Connexion.ConnexionCheck.MajConnexion();
        }

        /// <summary>
        /// Réglage de la vitesse de rotation de la balise en modifiant la valeur de la pwm
        /// </summary>
        /// <param name="vitesse">Valeur pwm à appliquer au moteur</param>
        public void VitesseRotation(int vitesse)
        {
            // Les valeurs correctes sont entre 0 et 4000
            if (vitesse > 4000 || vitesse < 0)
            {
                vitesse = 4000;
                ValeurConsigne = vitesse;
                Trame t = TrameFactory.BaliseVitesse(Carte, vitesse);
                Connexion.SendMessage(t);

                Console.WriteLine("Erreur d'affectation de vitesse");
            }
            else
            {
                ValeurConsigne = vitesse;
                Trame t = TrameFactory.BaliseVitesse(Carte, vitesse);
                Connexion.SendMessage(t);
            }
        }

        /// <summary>
        /// Teste la connexion avec la balise en lui demandant un echo
        /// </summary>
        public void TestConnexion()
        {
            Trame t = TrameFactory.BaliseTestConnexion(Carte);
            Connexion.SendMessage(t);
        }

        /// <summary>
        /// Teste la connexion avec la balise en lui demandant un echo
        /// </summary>
        /// <returns>Temps de ping</returns>
        public int TestConnexionPing()
        {
            Trame t = TrameFactory.BaliseTestConnexion(Carte);
            semTestConnexion = new Semaphore(0, 1);
            Connexion.SendMessage(t);
            DateTime debut = DateTime.Now;
            semTestConnexion.WaitOne(1000);
            return (int)(DateTime.Now - debut).TotalMilliseconds;
        }

        //Déclaration du délégué pour l’évènement détection de positions
        public delegate void PositionsChangeDelegate();
        //Déclaration de l’évènement utilisant le délégué
        public event PositionsChangeDelegate PositionsChange;

        //Déclaration du délégué pour l’évènement mise en rotation ou arrêt de la balise
        public delegate void RotationChangeDelegate(bool rotation);
        //Déclaration de l’évènement utilisant le délégué
        public event RotationChangeDelegate RotationChange;

        //Déclaration du délégué pour évènement simple
        public delegate void ChangeDelegate();
        //Déclaration de l’évènement utilisant le délégué
        public event ChangeDelegate CalibrationAngulaireTerminee;
        public event ChangeDelegate CalibrationAssietteTerminee;

        /// <summary>
        /// Démarre le réglage d'offset sur le nombre de mesures spécifié
        /// </summary>
        /// <param name="nbMesures">Nombre de mesures à moyenner pour calculer l'offset</param>
        public void ReglerOffset(int nbMesures)
        {
            // Réinitialisation des offsets
            Config.CurrentConfig.SetOffsetBalise(Carte, 1, 0);
            Config.CurrentConfig.SetOffsetBalise(Carte, 2, 0);

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
            int nouvelleVitesse = (int)Math.Min((ValeurConsigne + (VitesseConsigne - VitesseToursSecActuelle) * 100.0), 4000);
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
            VitesseRotation(3200);
            VitesseConsigne = vitesse;
            ReglageVitesse = true;
            ReglageVitessePermanent = true;
            // Pour être sûr au cas où...
            VitesseRotation(3200);
        }

        /// <summary>
        /// Arrête la balise
        /// </summary>
        public void Stop()
        {
            VitesseRotation(0);
            ReglageVitesse = false;
        }

        private int inclinaisonFace;
        public int InclinaisonFace
        {
            get { return inclinaisonFace; }
            set
            {
                inclinaisonFace = value;
                Console.WriteLine("Envoi pwm face " + inclinaisonFace);
                Trame t = TrameFactory.BaliseInclinaisonFace(Carte, inclinaisonFace);
                Connexion.SendMessage(t);
            }
        }

        private int inclinaisonProfil;
        public int InclinaisonProfil
        {
            get { return inclinaisonProfil; }
            set
            {
                inclinaisonProfil = value;
                Trame t = TrameFactory.BaliseInclinaisonProfil(Carte, inclinaisonProfil);
                Connexion.SendMessage(t);
            }
        }

        private double angleTotal;
        public List<double> ParcourirAxeFace(int pas, int min, int max, bool stopSiTrouveDebut, bool stopSiTrouveFin)
        {
            List<double> valeurs = new List<double>();
            bool trouve = false;

            for (int i = min; i <= max; i += pas)
            {
                Console.WriteLine("Position face " + i);
                Thread.Sleep(100);
                InclinaisonFace = i;
                semReceptionBalise = new Semaphore(0, int.MaxValue);
                semReceptionBalise.WaitOne();
                semReceptionBalise.WaitOne();
                valeurs.Add(angleTotal);

                if(angleTotal != 0)
                    trouve = true;

                Console.WriteLine(angleTotal + " / " + (trouve ? "Oui" : "Non"));

                if (stopSiTrouveDebut && trouve)
                    break;

                if (stopSiTrouveFin && trouve && angleTotal == 0)
                    break;
            }

            return valeurs;
        }

        public List<double> ParcourirAxeProfil(int pas, int min, int max, bool stopSiTrouve)
        {
            List<double> valeurs = new List<double>();

            for (int i = min; i <= max; i += pas)
            {
                InclinaisonProfil = i;
                semReceptionBalise = new Semaphore(0, int.MaxValue);
                semReceptionBalise.WaitOne();
                semReceptionBalise.WaitOne();
                valeurs.Add(angleTotal);

                if (stopSiTrouve && angleTotal == 0)
                    break;
            }

            return valeurs;
        }

        public void ReglerAssiette()
        {
            // todo
        }
    }
}
