using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDP;
using GoBot.UDP;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using GoBot.Calculs;
using GoBot.Calculs.Formes;

namespace GoBot
{
    public class Balise
    {
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
        /// Vérificateur de connexion avec la balise
        /// </summary>
        public ConnexionCheck ConnexionCheck { get; set; }

        //public StreamWriter writer;
        //DateTime prec;

        public Balise(Carte carte)
        {
            Carte = carte;
            dernieresErreurs = new List<double>();
            ReglageVitessePermanent = true;
            DetectionsCapteur2 = new List<DetectionBalise>();
            DetectionsCapteur1 = new List<DetectionBalise>();

            ConnexionCheck = new GoBot.ConnexionCheck(5000);
            ConnexionCheck.TestConnexion += new GoBot.ConnexionCheck.TestConnexionDelegate(TestConnexion);

            Connexions.ConnexionMiwi.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(connexionIo_NouvelleTrame);

            /*writer = new StreamWriter(carte.ToString() + ".csv");
            prec = DateTime.Now;
            writer.WriteLine("Time since previous;PWM;angle;Distance;vitesse");*/
        }

        public void Reset()
        {
            Trame t = TrameFactory.BaliseReset(Carte);
            Connexions.ConnexionMiwi.SendMessage(t);
        }

        /// <summary>
        /// Réception d'un message envoyé par la balise
        /// </summary>
        /// <param name="trame">Message reçu</param>
        public void connexionIo_NouvelleTrame(Trame trame)
        {
            // On ne traite que les messages qui nous sont adressés
            if (trame[0] != (byte)Carte)
                return;

            if (trame[1] == (byte)TrameFactory.FonctionBalise.Detection)
            {
                // Réception d'une mesure sur un tour de rotation
                try
                {
                    // Vérification checksum
                    int checksumRecu = trame[trame.Length - 1];

                    int checksumCalcul = 0;

                    for (int i = 0; i < trame.Length - 1; i++)
                        checksumCalcul ^= trame[i];

                    if (checksumCalcul != checksumRecu)
                    {
                        Console.WriteLine("Erreur de ckecksum");
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
                        Console.WriteLine(trame.ToString());
                    else
                    {
                        // Réception des mesures du capteur 1
                        DetectionsCapteur1.Clear();
                        List<int> tabAngle = new List<int>();

                        for (int i = 0; i < nbMesures1 * 4; i += 2)
                        {
                            int valeur = trame[6 + i] * 256 + trame[6 + i + 1];
                            tabAngle.Add(valeur);
                        }

                        tabAngle.Sort();

                        DetectionBalise d = null;

                        for (int i = 0; i < nbMesures1; i++)
                        {
                            double debut = 360 - (tabAngle[i * 2] / 100.0) + Config.CurrentConfig.GetOffsetBalise(Carte, 1);
                            double fin = 360 - (tabAngle[i * 2 + 1] / 100.0) + Config.CurrentConfig.GetOffsetBalise(Carte, 1);

                            //if (debut < 360 && debut > 0 && fin < 360 && fin > 0)
                            DetectionsCapteur1.Add(d = new DetectionBalise(this, debut, fin));
                            //else
                            //    Console.WriteLine("Mauvaise mesure : début = " + debut + " / fin = " + fin);
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
                            Console.WriteLine();
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

                                if (Plateau.NotreCouleur == Plateau.CouleurJ2B)
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
                                            moyenne = 146.31 - moyenne;
                                            break;
                                        case GoBot.Carte.RecBeu:
                                            moyenne = 213.69 - moyenne;
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
                                if (Plateau.NotreCouleur == Plateau.CouleurJ2B)
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
                                            moyenne = 146.31 - moyenne;
                                            break;
                                        case GoBot.Carte.RecBeu:
                                            moyenne = 213.69 - moyenne;
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
                            }
                        }

                        // Réunification des mesures détectées par les deux capteurs
                        Detections = new List<DetectionBalise>();
                        double ecartAngle = 1;

                        /*
                        foreach (DetectionBalise d1 in DetectionsCapteur1)
                        {
                            bool correspondance = false;
                            foreach (DetectionBalise d2 in DetectionsCapteur2)
                            {
                                if (d1.AngleCentral > d2.AngleCentral - ecartAngle && d1.AngleCentral < d2.AngleCentral + ecartAngle)
                                {
                                    // Moins de +- 1° de différence, les capteurs ont la même cible
                                    DetectionBalise detection = new DetectionBalise(this, (d1.AngleDebut + d2.AngleDebut) / 2, (d1.AngleFin + d2.AngleFin) / 2);
                                    Detections.Add(detection);
                                    correspondance = true;
                                }
                            }
                            if (!correspondance)
                                Detections.Add(d1);
                        }
                        // Cherche les détections du capteur 2 non trouvées par le capteur 1
                        foreach (DetectionBalise d2 in DetectionsCapteur1)
                        {
                            bool correspondance = false;
                            foreach (DetectionBalise d1 in DetectionsCapteur2)
                            {
                                if (d1.AngleCentral > d2.AngleCentral - ecartAngle && d1.AngleCentral < d2.AngleCentral + ecartAngle)
                                {
                                    correspondance = true;
                                }
                            }
                            if (!correspondance)
                                Detections.Add(d2);
                        }*/

                        foreach (DetectionBalise d2 in DetectionsCapteur1)
                            Detections.Add(d2);

                        foreach (DetectionBalise d1 in DetectionsCapteur2)
                            Detections.Add(d1);

                        // Retire les détections correspondant à la position de robots alliés
                        if (Plateau.ReflecteursNosRobots)
                        {
                            for (int i = 0; i < Detections.Count; i++)
                            {
                                DetectionBalise detection = Detections[i];
                                // Calcul du 3ème point du triangle rectangle Balise / Gros robot
                                Droite droiteBalise0Degres = new Droite(Position.Coordonnees, new PointReel(Position.Coordonnees.X + 500, Position.Coordonnees.Y));
                                Droite perpendiculaire = droiteBalise0Degres.getPerpendiculaire(Robots.GrosRobot.Position.Coordonnees);
                                PointReel troisiemePoint = perpendiculaire.getCroisement(droiteBalise0Degres);
                                //sohcahtoa
                                double distanceBaliseTroisiemePoint = troisiemePoint.Distance(Position.Coordonnees);
                                double distanceBaliseRobot = Robots.GrosRobot.Position.Coordonnees.Distance(Position.Coordonnees);

                                double a = Math.Acos(distanceBaliseTroisiemePoint / distanceBaliseRobot);
                                Angle angleGrosRobot = new Angle(a, AnglyeType.Radian);
                                Angle angleDetection = new Angle(detection.AngleCentral);

                                double marge = 4;

                                if (Carte == GoBot.Carte.RecBeu && Plateau.NotreCouleur == Plateau.CouleurJ1R)
                                {
                                    Angle diff = new Angle(180) - (angleDetection - angleGrosRobot);
                                    Console.WriteLine("Beu " + diff);
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        Console.WriteLine("GrosRobot repéré sur balise beu");
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                                else if (Carte == GoBot.Carte.RecBoi && Plateau.NotreCouleur == Plateau.CouleurJ1R)
                                {
                                    Angle diff = angleGrosRobot - angleDetection;
                                    Console.WriteLine("Boi " + diff);
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        Console.WriteLine("GrosRobot repéré sur balise boi");
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                                else if (Carte == GoBot.Carte.RecBun && Plateau.NotreCouleur == Plateau.CouleurJ1R)
                                {
                                    Angle diff = new Angle(180) - (angleGrosRobot + angleDetection);
                                    Console.WriteLine("Bun " + diff);
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        Console.WriteLine("GrosRobot repéré sur balise boi");
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                } 
                                else if (Carte == GoBot.Carte.RecBeu && Plateau.NotreCouleur == Plateau.CouleurJ2B)
                                {
                                    Angle diff = angleDetection + angleGrosRobot;
                                    Console.WriteLine("Beu " + diff);
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                                else if (Carte == GoBot.Carte.RecBoi && Plateau.NotreCouleur == Plateau.CouleurJ2B)
                                {
                                    Angle diff = new Angle(180) + angleGrosRobot - angleDetection;
                                    Console.WriteLine("Boi " + diff);
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                                else if (Carte == GoBot.Carte.RecBun && Plateau.NotreCouleur == Plateau.CouleurJ2B)
                                {
                                    Angle diff = angleGrosRobot - angleDetection;
                                    Console.WriteLine("Bun " + diff);
                                    if (Math.Abs((diff).AngleDegres) < marge)
                                    {
                                        Detections.RemoveAt(i);
                                        i--;
                                    }
                                }
                            }
                        }
                        // Génération de l'event de notification de détection
                        PositionsChange();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            ConnexionCheck.MajConnexion();
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
                Connexions.ConnexionMiwi.SendMessage(t);

                Console.WriteLine("Erreur d'affectation de vitesse");
            }
            else
            {
                ValeurConsigne = vitesse;
                Trame t = TrameFactory.BaliseVitesse(Carte, vitesse);
                Connexions.ConnexionMiwi.SendMessage(t);
            }
        }

        /// <summary>
        /// Teste la connexion avec la balise en lui demandant un echo
        /// </summary>
        public void TestConnexion()
        {
            Trame t = TrameFactory.BaliseTestConnexion(Carte);
            Connexions.ConnexionMiwi.SendMessage(t);
        }

        //Déclaration du délégué pour l’évènement détection de positions
        public delegate void PositionsChangeDelegate();
        //Déclaration de l’évènement utilisant le délégué
        public event PositionsChangeDelegate PositionsChange;

        /// <summary>
        /// Démarre le réglage d'offset sur le nombre de mesures spécifié
        /// </summary>
        /// <param name="nbMesures">Nombre de mesures à moyenner pour calculer l'offset</param>
        public void ReglerOffset(int nbMesures)
        {
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
            VitesseRotation(2500);
            VitesseConsigne = vitesse;
            ReglageVitesse = true;
            ReglageVitessePermanent = true;
            // Pour être sûr au cas où...
            VitesseRotation(2500);
        }

        /// <summary>
        /// Arrête la balise
        /// </summary>
        public void Stop()
        {
            VitesseRotation(0);
            ReglageVitesse = false;
        }
    }
}
