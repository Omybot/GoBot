using System;
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
                case ServomoteurID.AscenseurDroitPinceBasDroite:
                    return "servo pince droite bas droit";
                case ServomoteurID.AscenseurDroitPinceBasGauche:
                    return "servo pince droite bas gauche";
                case ServomoteurID.AscenseurDroitPinceHautDroite:
                    return "servo pince droite haut droit";
                case ServomoteurID.AscenseurDroitPinceHautGauche:
                    return "servo pince droite haut gauche";
                case ServomoteurID.AscenseurGauchePinceBasDroite:
                    return "servo pince gauche bas droit";
                case ServomoteurID.AscenseurGauchePinceBasGauche:
                    return "servo pince gauche bas gauche";
                case ServomoteurID.AscenseurGauchePinceHautDroite:
                    return "servo pince gauche haut droit";
                case ServomoteurID.AscenseurGauchePinceHautGauche:
                    return "servo pince gauche haut gauche";
                case ServomoteurID.PinceAmpoule:
                    return "servo pince attrapage balle";
                case ServomoteurID.AspirateurCoude:
                    return "servo aspirateur coude";
                case ServomoteurID.AspirateurEpaule:
                    return "servo aspirateur épaule";
                case ServomoteurID.BalleVerouillageDroit:
                    return "servo verrouillage balle droit";
                case ServomoteurID.BalleVerouillageGauche:
                    return "servo verrouillage balle gauche";
                case ServomoteurID.TapisBras:
                    return "servo bras tapis";
                case ServomoteurID.TapisPinceDroite:
                    return "servo pince tapis droit";
                case ServomoteurID.TapisPinceGauche:
                    return "servo pince tapis gauche";
                default:
                    if (servo.ToString().Contains("zzLibre"))
                        return "servo n°" + (int)servo;
                    else
                        return servo.ToString();
            }
        }

        private static Dictionary<ServomoteurID, PositionnableServo> PositionnableServos = null;

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
                case CapteurOnOffID.SwitchBrasDroitBas:
                    return "présence pied bras droit bas";
                case CapteurOnOffID.SwitchBrasDroitHaut:
                    return "présence pied bras droit haut";
                case CapteurOnOffID.SwitchBrasGaucheBas:
                    return "présence pied bras gauche bas";
                case CapteurOnOffID.SwitchBrasGaucheHaut:
                    return "présence pied bras gauche haut";
                case CapteurOnOffID.OptiqueBrasDroit:
                    return "présence pied bras droit au sol";
                case CapteurOnOffID.OptiqueBrasGauche:
                    return "présence pied bras gauche au sol";
                case CapteurOnOffID.SwitchBrasDroiteOrigine:
                    return "prise d'origine bras droite";
                case CapteurOnOffID.SwitchBrasGaucheOrigine:
                    return "prise d'origine bras gauche";
                default :
                    return capteur.ToString();
            }
        }

        public static String Nommer(MoteurID moteur)
        {
            switch (moteur)
            {
                case MoteurID.AscenseurDroit:
                    return "ascenseur droite";
                case MoteurID.AscenseurGauche:
                    return "ascenseur gauche";
                case MoteurID.Balise:
                    return "balise";
                case MoteurID.AscenseurAmpoule:
                    return "ascenseur ampoule";
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
