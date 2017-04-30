﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using GoBot.Actionneurs;

namespace GoBot.Actions
{
    static class Nommeur
    {
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
        /// <returns></returns>
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
        /// <returns></returns>
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

        public static String Nommer(CapteurOnOffID capteur)
        {
            switch (capteur)
            {
                default :
                    return capteur.ToString();
            }
        }

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

        public static String Nommer(ActionneurOnOffID actionneur)
        {
            switch (actionneur)
            {
                case ActionneurOnOffID.Alimentation:
                    return "alimentation";
                default:
                    return actionneur.ToString();
            }
        }

        public static String Nommer(CapteurID capteur)
        {
            switch (capteur)
            {
                case CapteurID.Jack:
                    return "jack";
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

        public static String Nommer(object o)
        {
            if (o is CapteurID)
                return Nommer((CapteurID)o);
            else if (o is CapteurOnOffID)
                return Nommer((CapteurOnOffID)o);
            else if (o is ActionneurOnOffID)
                return Nommer((ActionneurOnOffID)o);
            else if (o is ServomoteurID)
                return Nommer((ServomoteurID)o);
            else if (o is MoteurID)
                return Nommer((MoteurID)o);
            else
                return "";
        }
    }
}
