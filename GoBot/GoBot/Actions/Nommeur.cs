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
                case ServomoteurID.GRBrasBasDroite:
                    return "bras bas droite";
                case ServomoteurID.GRBrasBasGauche:
                    return "bras bas gauche";
                case ServomoteurID.GRBrasHautDroite:
                    return "bras haut droite";
                case ServomoteurID.GRBrasHautGauche:
                    return "bras haut gauche";
                case ServomoteurID.GRBrasMilieuDroite:
                    return "bras milieu droite";
                case ServomoteurID.GRBrasMilieuGauche:
                    return "bras milieu gauche";
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

        public static String Nommer(PompeID pompe)
        {
            switch (pompe)
            {
                case PompeID.PRPompeDroite:
                    return "pompe droite";
                case PompeID.PRPompeGauche:
                    return "pompe gauche";
                default :
                    return pompe.ToString();
            }
        }
    }
}
