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
        /// Détections effectuées par le capteur bas de la balise
        /// </summary>
        public List<DetectionBalise> DetectionsBas { get; set; }

        /// <summary>
        /// Détections effectuées par le capteur haut de la balise
        /// </summary>
        public List<DetectionBalise> DetectionsHaut { get; set; }

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
        private List<double> anglesMesuresPourOffsetHaut;

        /// <summary>
        /// Mesures pour l'offset du capteur bas
        /// </summary>
        private List<double> anglesMesuresPourOffsetBas;

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
            DetectionsBas = new List<DetectionBalise>();
            DetectionsHaut = new List<DetectionBalise>();

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
                    int nbHaut = trame[4];
                    int nbBas = trame[5];

                    // Si on a un nombre impair de fronts on laisse tomber cette mesure, elle n'est pas bonne
                    if (nbHaut % 2 != 0 || nbBas % 2 != 0)
                        return;

                    nbHaut = nbHaut / 2;
                    nbBas = nbBas / 2;

                    // Vérification de la taille de la trame
                    if (trame.Length != 7 + nbHaut * 4 + nbBas * 4)
                        Console.WriteLine(trame.ToString());
                    else
                    {
                        // Réception des mesures du capteur haut
                        DetectionsHaut.Clear();
                        List<int> tabAngle = new List<int>();

                        for (int i = 0; i < nbHaut * 4; i += 2)
                        {
                            int valeur = trame[6 + i] * 256 + trame[6 + i + 1];
                            tabAngle.Add(valeur);
                        }

                        tabAngle.Sort();

                        DetectionBalise d = null;

                        for (int i = 0; i < nbHaut; i++)
                        {
                            double debut = 360 - (tabAngle[i * 2] / 100.0) + Config.CurrentConfig.GetOffsetBaliseHaut(Carte);
                            double fin = 360 - (tabAngle[i * 2 + 1] / 100.0) + Config.CurrentConfig.GetOffsetBaliseHaut(Carte);

                            if (debut < 360 && debut > 0 && fin < 360 && fin > 0)
                                DetectionsHaut.Add(d = new DetectionBalise(this, debut, fin));
                            else
                                Console.WriteLine("Mauvaise mesure : début = " + debut + " / fin = " + fin);
                        }

                        /*writer.WriteLine((DateTime.Now - prec).TotalMilliseconds + ";" + nouvelleVitesse + ";" + (d == null ? ";;" : d.AngleCentral + ";" + d.Distance + ";") + VitesseToursSecActuelle);
                        prec = DateTime.Now;*/

                        // Réception des mesures du capteur bas

                        int offSet = nbHaut * 4 + 6;

                        DetectionsBas.Clear();

                        // tableau pour trier les angles ( correction logiciel )
                        tabAngle.Clear();

                        long verif = 0;
                        for (int i = 0; i < nbBas * 4; i += 2)
                        {
                            int valeur = trame[offSet + i] * 256 + trame[offSet + i + 1];
                            tabAngle.Add(valeur);
                            verif += valeur * (i/2 + 1);
                        }

                        tabAngle.Sort();

                        for (int i = 0; i < nbBas * 2; i++)
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

                        for (int i = 0; i < nbBas; i++)
                        {
                            double debut = 360 - (tabAngle[i * 2] / 100.0) + Config.CurrentConfig.GetOffsetBaliseBas(Carte);
                            double fin = 360 - (tabAngle[i * 2 + 1] / 100.0) + Config.CurrentConfig.GetOffsetBaliseBas(Carte);

                            if (debut < 360 && debut > 0 && fin < 360 && fin > 0)
                                DetectionsBas.Add(new DetectionBalise(this, debut, fin));
                            else
                                Console.WriteLine("Mauvaise mesure : début = " + debut + " / fin = " + fin);
                        }

                        // Réglage de l'offset d'angle des capteurs
                        if (ReglageOffset)
                        {
                            // Si on a une mesure incorrecte (une mesure correcte demande une détection en haut et une en bas)
                            // Le réglage est annulé
                            if (DetectionsHaut.Count == 1 || DetectionsBas.Count == 1)
                            {
                                compteurReglageOffset--;

                                // On ajoute les angles mesurés à l'historique
                                anglesMesuresPourOffsetBas.Add(DetectionsBas[0].AngleCentral);
                                anglesMesuresPourOffsetHaut.Add(DetectionsHaut[0].AngleCentral);
                            }

                            if (ReglageOffset && compteurReglageOffset == 0)
                            {
                                // Compteur arrivé à la fin, on calcule l'offset
                                double moyenne = 0;

                                foreach (double dv in anglesMesuresPourOffsetHaut)
                                    moyenne += dv;

                                moyenne /= anglesMesuresPourOffsetHaut.Count;

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

                                // On le sauve dans la config (haut)
                                Config.CurrentConfig.SetOffsetBaliseHaut(Carte, moyenne + Config.CurrentConfig.GetOffsetBaliseHaut(Carte));

                                moyenne = 0;

                                foreach (double dv in anglesMesuresPourOffsetBas)
                                    moyenne += dv;

                                moyenne /= anglesMesuresPourOffsetBas.Count;

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

                                // On le sauve dans la config (bas)
                                Config.CurrentConfig.SetOffsetBaliseBas(Carte, moyenne + Config.CurrentConfig.GetOffsetBaliseBas(Carte));

                                // Réglage terminé
                                ReglageOffset = false;
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
            anglesMesuresPourOffsetHaut = new List<double>();
            anglesMesuresPourOffsetBas = new List<double>();
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
