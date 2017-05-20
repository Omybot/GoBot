using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using GoBot.Actionneurs;
using GoBot.Communications;

namespace GoBot.Actions
{
    static class Nommeur
    {
        /// <summary>
        /// Nomme à partir d'un type inconnu en recherchant la meilleure surcharge
        /// </summary>
        /// <param name="o">Objet à nommer</param>
        /// <returns>Nom de l'objet si trouvé, sinon chaine vide</returns>
        public static String NommerInconnu(object o)
        {
            return Nommer(Util.ToRealType(o));
        }

        /// <summary>
        /// Nommage d'un objet pour lequel on n'a à priori pas de surcharge adaptée, donc retourne une chaine vide
        /// Fonction privée car aucun intêret de l'appeler depuis l'exterieur
        /// </summary>
        /// <param name="o">Objet à nommer qui n'a pas trouvé de surcharge</param>
        /// <returns>Chaine vide</returns>
        private static String Nommer(object o)
        {
            return "";
        }

        /// <summary>
        /// Retourne le nom usuel du servomoteur
        /// </summary>
        /// <param name="servo">Servomoteur recherché</param>
        /// <returns>Nom usuel</returns>
        public static String Nommer(ServomoteurID servo)
        {
            switch (servo)
            {
                case ServomoteurID.Tous:
                    return "tous les servomoteurs";
                case ServomoteurID.BrasLunaireAvance:
                    return "bras lunaire linéaire";
                case ServomoteurID.BrasLunaireMonte:
                    return "bras lunaire rotation";
                case ServomoteurID.ServoLunaireSerrageDroit:
                    return "bras lunaire serrage droit";
                case ServomoteurID.ServoLunaireSerrageGauche:
                    return "bras lunaire serrage gauche";
                case ServomoteurID.BloqueurBas:
                    return "bloqueur bas";
                case ServomoteurID.BloqueurHaut:
                    return "bloqueur haut";
                case ServomoteurID.Chariot:
                    return "chariot";
                case ServomoteurID.Ejecteur:
                    return "éjecteur";
                case ServomoteurID.Rehausseur:
                    return "réhausseur";

                
                default:
                    if (servo.ToString().Contains("zzLibre"))
                        return "servo n°" + (int)servo;
                    else
                        return servo.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom de la position en fonction du servomoteur (Ouvert, fermé, etc...)
        /// </summary>
        /// <param name="position">Position du servomoteur</param>
        /// <param name="servo">Servomoteur</param>
        /// <returns>Nom de la position</returns>
        public static String Nommer(int position, ServomoteurID servo)
        {
            PropertyInfo[] proprietes = typeof(Config).GetProperties();
            foreach (PropertyInfo p in proprietes)
            {
                if (p.PropertyType.IsSubclassOf(typeof(PositionnableServo)))
                {
                    PositionnableServo positionnableServo = (PositionnableServo)(p.GetValue(Config.CurrentConfig, null));

                    if (positionnableServo.ID == servo)
                    {
                        PropertyInfo[] proprietesServo = positionnableServo.GetType().GetProperties();
                        foreach (PropertyInfo ps in proprietesServo)
                        {
                            if (ps.Name.StartsWith("Position") && ((int)(ps.GetValue(positionnableServo, null)) == position))
                                return Config.PropertyNameToScreen(ps) + " (" + position + ")";
                        }
                    }
                }
            }
                    
            return position.ToString();
        }

        /// <summary>
        /// Retourne le nom de la position en fonction du moteur (Haut, Bas, etc...)
        /// </summary>
        /// <param name="position">Position du moteur</param>
        /// <param name="moteur">Moteur</param>
        /// <returns>Nom de la position</returns>
        public static String Nommer(int position, MoteurID moteur)
        {
            PropertyInfo[] proprietes = typeof(Config).GetProperties();
            foreach (PropertyInfo p in proprietes)
            {
                if (p.PropertyType.IsSubclassOf(typeof(PositionnableMoteur)))
                {
                    PositionnableMoteur positionnableMoteur = (PositionnableMoteur)(p.GetValue(Config.CurrentConfig, null));

                    if (positionnableMoteur.ID == moteur)
                    {
                        PropertyInfo[] proprietesMoteur = positionnableMoteur.GetType().GetProperties();
                        foreach (PropertyInfo ps in proprietesMoteur)
                        {
                            if (ps.Name.StartsWith("Position") && ((int)(ps.GetValue(positionnableMoteur, null)) == position))
                                return Config.PropertyNameToScreen(ps) + " (" + position + ")";
                        }
                    }
                }
            }

            return position.ToString();
        }

        /// <summary>
        /// Retourne le nom usuel d'un capteur on off
        /// </summary>
        /// <param name="capteur">Capteur on off à nommer</param>
        /// <returns>Nom du capteur on off</returns>
        public static String Nommer(CapteurOnOffID capteur)
        {
            switch (capteur)
            {
                case CapteurOnOffID.Bouton1:
                    return "bouton 1";
                case CapteurOnOffID.Bouton2:
                    return "bouton 2";
                case CapteurOnOffID.Bouton3:
                    return "bouton 3";
                case CapteurOnOffID.Bouton4:
                    return "bouton 4";
                case CapteurOnOffID.Bouton5:
                    return "bouton 5";
                case CapteurOnOffID.Bouton6:
                    return "bouton 6";
                case CapteurOnOffID.Bouton7:
                    return "bouton 7";
                case CapteurOnOffID.Bouton8:
                    return "bouton 8";
                case CapteurOnOffID.Bouton9:
                    return "bouton 9";
                case CapteurOnOffID.Bouton10:
                    return "bouton 10";
                case CapteurOnOffID.Jack:
                    return "jack";
                case CapteurOnOffID.CouleurEquipe:
                    return "couleur d'equipe";
                default:
                    return capteur.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un codeur
        /// </summary>
        /// <param name="capteur">Codeur à nommer</param>
        /// <returns>Nom du codeur</returns>
        public static String Nommer(CodeurID codeur)
        {
            switch (codeur)
            {
                case CodeurID.Manuel:
                    return "manuel";
                default:
                    return codeur.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un bolléen On/Off
        /// </summary>
        /// <param name="capteur">Valeur à nommer</param>
        /// <returns>"On" ou "Off"</returns>
        public static String Nommer(bool val)
        {
            return val ? "On" : "Off";
        }

        /// <summary>
        /// Retourne le nom usuel d'un moteur
        /// </summary>
        /// <param name="capteur">Moteur à nommer</param>
        /// <returns>Nom du Moteur</returns>
        public static String Nommer(MoteurID moteur)
        {
            switch (moteur)
            {
                case MoteurID.Balise:
                    return "balise";
                case MoteurID.Orienteur:
                    return "orienteur";
                case MoteurID.Transfert:
                    return "transfert de module";
                default:
                    return moteur.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un actionneur On/Off
        /// </summary>
        /// <param name="capteur">Actionneur à nommer</param>
        /// <returns>Nom de l'actionneur</returns>
        public static String Nommer(ActionneurOnOffID actionneur)
        {
            switch (actionneur)
            {
                default:
                    return actionneur.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un capteur
        /// </summary>
        /// <param name="capteur">Capteur à nommer</param>
        /// <returns>Nom du capteur</returns>
        public static String Nommer(CapteurID capteur)
        {
            switch (capteur)
            {
                case CapteurID.Balise:
                    return "balise";
                case CapteurID.BaliseRapide1:
                    return "balise capteur 1";
                case CapteurID.BaliseRapide2:
                    return "balise capteur 2";
                default:
                    return capteur.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un capteur couleur
        /// </summary>
        /// <param name="capteur">Capteur couleur à nommer</param>
        /// <returns>Nom du capteur couleur</returns>
        public static String Nommer(CapteurCouleurID capteur)
        {
            switch (capteur)
            {
                case CapteurCouleurID.CouleurTube:
                    return "module lunaire";
                default:
                    return capteur.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'une balise
        /// </summary>
        /// <param name="capteur">Balise à nommer</param>
        /// <returns>Nom de la balise</returns>
        public static String Nommer(BaliseID balise)
        {
            switch (balise)
            {
                case BaliseID.Principale:
                    return "principale";
                default:
                    return balise.ToString();
            }
        }


        /// <summary>
        /// Retourne le nom usuel d'une LED RGB
        /// </summary>
        /// <param name="capteur">LED RGB à nommer</param>
        /// <returns>Nom de la LED RGB</returns>
        public static String Nommer(LedRgbID led)
        {
            switch (led)
            {
                case LedRgbID.CouleurMatch:
                    return "couleur match";
                default:
                    return led.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un Lidar
        /// </summary>
        /// <param name="capteur">Lidar à nommer</param>
        /// <returns>Nom du Lidar</returns>
        public static String Nommer(LidarID lidar)
        {
            switch (lidar)
            {
                case LidarID.ScanSol:
                    return "scan sol";
                default:
                    return lidar.ToString();
            }
        }

        /// <summary>
        /// Retourne le template de décodage d'une fonction dans le protocole de communication UDP
        /// </summary>
        /// <param name="capteur">Fonction à décoder</param>
        /// <returns>Template de décodage</returns>
        public static String Nommer(FonctionTrame trame)
        {
            return DecodeurTrames.GetMessage(trame);
        }

        /// <summary>
        /// Retourne le nom usuel d'une led
        /// </summary>
        /// <param name="capteur">Led à nommer</param>
        /// <returns>Nom de la led</returns>
        public static String Nommer(LedID led)
        {
            switch (led)
            {
                case LedID.Debug1:
                    return "debug 1";
                case LedID.Debug2:
                    return "debug 2";
                case LedID.Debug3:
                    return "debug 3";
                case LedID.Debug4:
                    return "debug 4";
                case LedID.Debug5:
                    return "debug 5";
                case LedID.Debug6:
                    return "debug 6";
                case LedID.Debug7:
                    return "debug 7";
                case LedID.Debug8:
                    return "debug 8";
                case LedID.Debug9:
                    return "debug 9";
                case LedID.Debug10:
                    return "debug 10";
                case LedID.Debug11:
                    return "debug 11";
                case LedID.Debug12:
                    return "debug 12";
                case LedID.Debug13:
                    return "debug 13";
                case LedID.Debug14:
                    return "debug 14";
                case LedID.Debug15:
                    return "debug 15";
                case LedID.Debug16:
                    return "debug 16";
                default:
                    return led.ToString();
            }
        }
    }
}
