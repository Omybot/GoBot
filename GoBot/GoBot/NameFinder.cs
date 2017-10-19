﻿using System;
using System.Reflection;
using GoBot.Actionneurs;
using GoBot.Communications;

namespace GoBot
{
    static class NameFinder
    {
        /// <summary>
        /// Nomme à partir d'un type inconnu en recherchant la meilleure surcharge
        /// </summary>
        /// <param name="o">Objet à nommer</param>
        /// <returns>Nom de l'objet si trouvé, sinon chaine vide</returns>
        public static String GetNameUnknow(object o)
        {
            return GetName(Util.ToRealType(o));
        }

        /// <summary>
        /// Nommage d'un objet pour lequel on n'a à priori pas de surcharge adaptée, donc retourne une chaine vide
        /// Fonction privée car aucun intêret de l'appeler depuis l'exterieur
        /// </summary>
        /// <param name="o">Objet à nommer qui n'a pas trouvé de surcharge</param>
        /// <returns>Chaine vide</returns>
        private static String GetName(object o)
        {
            return "";
        }

        /// <summary>
        /// Retourne le nom usuel du servomoteur
        /// </summary>
        /// <param name="servo">Servomoteur recherché</param>
        /// <returns>Nom usuel</returns>
        public static String GetName(ServomoteurID servo)
        {
            switch (servo)
            {
                case ServomoteurID.Tous:
                    return "tous les servomoteurs";
                case ServomoteurID.BrasLunaireAvance:
                    return "bras lunaire sort";
                case ServomoteurID.BrasLunaireMonte:
                    return "bras lunaire central";
                case ServomoteurID.ServoLunaireSerrageDroit:
                    return "bras lunaire serrage droit";
                case ServomoteurID.ServoLunaireSerrageGauche:
                    return "bras lunaire serrage gauche";
                case ServomoteurID.BloqueurBas:
                    return "bloqueur bas";
                case ServomoteurID.BloqueurHaut:
                    return "bloqueur haut";
                case ServomoteurID.Ejecteur:
                    return "éjecteur";
                case ServomoteurID.Rehausseur:
                    return "réhausseur";
                case ServomoteurID.BrasLunaireGauche:
                    return "bras lunaire gauche";
                case ServomoteurID.ServoLunaireGaucheSerrageDroit:
                    return "serrage droit du bras lunaire gauche";
                case ServomoteurID.ServoLunaireGaucheSerrageGauche:
                    return "serrage gauche du bras lunaire gauche";
                case ServomoteurID.BrasLunaireDroit:
                    return "bras lunaire droit";
                case ServomoteurID.ServoLunaireDroitSerrageDroit:
                    return "serrage droit du bras lunaire droit";
                case ServomoteurID.ServoLunaireDroitSerrageGauche:
                    return "serrage gauche du bras lunaire droit";
                case ServomoteurID.Plaqueur:
                    return "plaqueur de modules";
                case ServomoteurID.Calleur:
                    return "calleur de modules";
                case ServomoteurID.Fusee:
                    return "lanceur de fusée";
                default:
                        return servo.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom de la position en fonction du servomoteur (Ouvert, fermé, etc...)
        /// </summary>
        /// <param name="position">Position du servomoteur</param>
        /// <param name="servo">Servomoteur</param>
        /// <returns>Nom de la position</returns>
        public static String GetName(int position, ServomoteurID servo)
        {
            PropertyInfo[] properties = typeof(Config).GetProperties();
            foreach (PropertyInfo p in properties)
            {
                if (p.PropertyType.IsSubclassOf(typeof(PositionableServo)))
                {
                    PositionableServo positionnableServo = (PositionableServo)(p.GetValue(Config.CurrentConfig, null));

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
        public static String GetName(int position, MoteurID moteur)
        {
            PropertyInfo[] properties = typeof(Config).GetProperties();
            foreach (PropertyInfo p in properties)
            {
                if (p.PropertyType.IsSubclassOf(typeof(PositionableMotorPosition)))
                {
                    PositionableMotorPosition positionnableMoteur = (PositionableMotorPosition)(p.GetValue(Config.CurrentConfig, null));

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
        /// <param name="sensor">Capteur on off à nommer</param>
        /// <returns>Nom du capteur on off</returns>
        public static String GetName(CapteurOnOffID sensor)
        {
            switch (sensor)
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
                case CapteurOnOffID.LSwitch1:
                    return "switch linéaire 1";
                case CapteurOnOffID.LSwitch2:
                    return "switch linéaire 2";
                case CapteurOnOffID.LSwitch3:
                    return "switch linéaire 3";
                case CapteurOnOffID.LSwitch4:
                    return "switch linéaire 4";
                case CapteurOnOffID.ChaiPas:
                    return "on sait pas";
                case CapteurOnOffID.ChaiPlus:
                    return "on sait plus";
                case CapteurOnOffID.PresenceDroite:
                    return "présence module à droite";
                case CapteurOnOffID.PresenceGauche:
                    return "présence module à gauche";
                case CapteurOnOffID.PresenceCentre:
                    return "présence module au centre";
                case CapteurOnOffID.PresenceOnSaitPasOu:
                    return "présence pas cablé";
                default:
                    return sensor.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un codeur
        /// </summary>
        /// <param name="capteur">Codeur à nommer</param>
        /// <returns>Nom du codeur</returns>
        public static String GetName(CodeurID encoder)
        {
            switch (encoder)
            {
                case CodeurID.Manuel:
                    return "manuel";
                default:
                    return encoder.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un bolléen On/Off
        /// </summary>
        /// <param name="capteur">Valeur à nommer</param>
        /// <returns>"On" ou "Off"</returns>
        public static String GetName(bool val)
        {
            return val ? "On" : "Off";
        }

        /// <summary>
        /// Retourne le nom usuel d'un moteur
        /// </summary>
        /// <param name="capteur">Moteur à nommer</param>
        /// <returns>Nom du Moteur</returns>
        public static String GetName(MoteurID motor)
        {
            switch (motor)
            {
                case MoteurID.Balise:
                    return "balise";
                case MoteurID.Orienteur:
                    return "orienteur";
                case MoteurID.Transfert:
                    return "transfert de module";
                default:
                    return motor.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un actionneur On/Off
        /// </summary>
        /// <param name="capteur">Actionneur à nommer</param>
        /// <returns>Nom de l'actionneur</returns>
        public static String GetName(ActionneurOnOffID actuator)
        {
            switch (actuator)
            {
                case ActionneurOnOffID.AlimCapteurCouleur:
                    return "alimentation capteur couleur";
                default:
                    return actuator.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un capteur
        /// </summary>
        /// <param name="sensor">Capteur à nommer</param>
        /// <returns>Nom du capteur</returns>
        public static String GetName(CapteurID sensor)
        {
            switch (sensor)
            {
                case CapteurID.Balise:
                    return "balise";
                case CapteurID.BaliseRapide1:
                    return "balise capteur 1";
                case CapteurID.BaliseRapide2:
                    return "balise capteur 2";
                default:
                    return sensor.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un capteur couleur
        /// </summary>
        /// <param name="sensor">Capteur couleur à nommer</param>
        /// <returns>Nom du capteur couleur</returns>
        public static String GetName(CapteurCouleurID sensor)
        {
            switch (sensor)
            {
                case CapteurCouleurID.CouleurTube:
                    return "module lunaire";
                default:
                    return sensor.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'une balise
        /// </summary>
        /// <param name="capteur">Balise à nommer</param>
        /// <returns>Nom de la balise</returns>
        public static String GetName(BaliseID balise)
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
        public static String GetName(LedRgbID led)
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
        public static String GetName(LidarID lidar)
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
        public static String GetName(FrameFunction frame)
        {
            return FrameDecoder.GetMessage(frame);
        }

        /// <summary>
        /// Retourne le nom usuel d'une led
        /// </summary>
        /// <param name="capteur">Led à nommer</param>
        /// <returns>Nom de la led</returns>
        public static String GetName(LedID led)
        {
            switch (led)
            {
                case LedID.DebugA1:
                    return "debug A1";
                case LedID.DebugA2:
                    return "debug A2";
                case LedID.DebugA3:
                    return "debug A3";
                case LedID.DebugA4:
                    return "debug A4";
                case LedID.DebugA5:
                    return "debug A5";
                case LedID.DebugA6:
                    return "debug A6";
                case LedID.DebugA7:
                    return "debug A7";
                case LedID.DebugA8:
                    return "debug A8";
                case LedID.DebugB8:
                    return "debug B8";
                case LedID.DebugB7:
                    return "debug B7";
                case LedID.DebugB6:
                    return "debug B6";
                case LedID.DebugB5:
                    return "debug B5";
                case LedID.DebugB4:
                    return "debug B4";
                case LedID.DebugB3:
                    return "debug B3";
                case LedID.DebugB2:
                    return "debug B2";
                case LedID.DebugB1:
                    return "debug B1";
                default:
                    return led.ToString();
            }
        }
    }
}