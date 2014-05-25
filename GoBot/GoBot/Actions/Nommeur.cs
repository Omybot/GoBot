using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                case ServomoteurID.GRFruitsCoude:
                    return "coude fruit";
                case ServomoteurID.GRFruitsEpaule:
                    return "épaule fruit";
                case ServomoteurID.GRFeuxCoude:
                    return "coude feu";
                case ServomoteurID.GRFeuxPoignet:
                    return "poignet feu";
                default:
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
            switch (servo)
            {

                default:
                    return position.ToString();
            }
        }

        public static String Nommer(CapteurOnOff capteur)
        {
            switch (capteur)
            {
                case CapteurOnOff.GRPresenceBouchon:
                    return "présence bouchon";
                default :
                    return "Inconnu";
            }
        }

        public static String Nommer(MoteurID moteur)
        {
            switch (moteur)
            {
                case MoteurID.GREpauleFeu:
                    return "épaule feu";
                case MoteurID.GRPinceDroiteBas:
                    return "pince fruit droite bas";
                case MoteurID.GRPinceGaucheBas:
                    return "pince fruit gauche bas";
                case MoteurID.GRPinceDroiteHaut:
                    return "pince fruit haut bas";
                case MoteurID.GRPinceGaucheHaut:
                    return "pince fruit gauche haut";
                case MoteurID.GRPousseBouchon:
                    return "pousse bouchon";
                default:
                    return moteur.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom de la vitesse en fonction du moteur (Arrêter, aspirer, souffler, etc...)
        /// </summary>
        /// <param name="position">Vitesse du moteur</param>
        /// <param name="moteur">Moteur</param>
        /// <returns></returns>
        public static String Nommer(int vitesse, MoteurID moteur)
        {
            switch (moteur)
            {
                /*case MoteurID.GRCanon:
                    if (vitesse == Config.CurrentConfig.VitessePropulsionBonne)
                        return "panier (" + vitesse + ")";
                    else if (vitesse == 0)
                        return "éteint (0)";
                    else
                        return vitesse + "";*/
                default:
                    return vitesse.ToString();
            }
        }

        public static String Nommer(ActionneurOnOffID actionneur)
        {
            switch (actionneur)
            {
                case ActionneurOnOffID.GRElectrovanneFeu:
                    return "électrovanne des feux";
                case ActionneurOnOffID.GRPompeFeu:
                    return "pompe des feux";
                case ActionneurOnOffID.GRCanonFruit:
                    return "canon à fruits";
                case ActionneurOnOffID.PRLancesMammouth:
                    return "canon à lances mammouth";
                default:
                    return actionneur.ToString();
            }
        }

        public static String Nommer(CapteurID capteur)
        {
            switch (capteur)
            {
                case CapteurID.GRJack:
                    return "jack";
                default:
                    return capteur.ToString();
            }
        }
    }
}
