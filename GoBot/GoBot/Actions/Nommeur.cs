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
                    return "coude";
                case ServomoteurID.GRFruitsEpaule:
                    return "épaule";
                case ServomoteurID.GRFruitsPinceDroite:
                    return "pince droite";
                case ServomoteurID.GRFruitsPinceGauche:
                    return "pince gauche";
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
                case ServomoteurID.GRFruitsPinceDroite:
                    if (position == Config.CurrentConfig.PositionGRPinceDroiteOuverte)
                        return "ouverte (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRPinceDroiteFermee)
                        return "fermée (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.GRFruitsPinceGauche:
                    if (position == Config.CurrentConfig.PositionGRPinceGaucheOuverte)
                        return "ouverte (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRPinceGaucheFermee)
                        return "fermée (" + position + ")";
                    else return position.ToString();

                default:
                    return position.ToString();
            }
        }

        public static String Nommer(MoteurID moteur)
        {
            switch (moteur)
            {
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
                case ActionneurOnOffID.GRAlimentation:
                    return "alimentation";
                default:
                    return actionneur.ToString();
            }
        }

        public static String Nommer(CapteurID capteur)
        {
            switch (capteur)
            {
                default:
                    return capteur.ToString();
            }
        }
    }
}
