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
                case ServomoteurID.GRAspirateur:
                    return "aspirateur";
                case ServomoteurID.GRDebloqueur:
                    return "débloqueur";
                case ServomoteurID.GRBrasDroit:
                    return "bras droit";
                case ServomoteurID.GRBrasGauche:
                    return "bras gauche";
                case ServomoteurID.GRCamera:
                    return "camera";
                case ServomoteurID.GRGrandBras:
                    return "grand bras";
                case ServomoteurID.GRPetitBras:
                    return "petit bras";
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
                case ServomoteurID.GRAspirateur:
                    if (position == Config.CurrentConfig.PositionGRAspirateurBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRAspirateurHaut)
                        return "haut (" + position + ")";
                    else
                        return position + "";
                case ServomoteurID.GRDebloqueur:
                    if (position == Config.CurrentConfig.PositionGRDebloqueurBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRDebloqueurHaut)
                        return "haut (" + position + ")";
                    else
                        return position + "";
                case ServomoteurID.GRBrasDroit:
                    if (position == Config.CurrentConfig.PositionGRBrasDroitRange)
                        return "rangé (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRBrasDroitSorti)
                        return "sorti (" + position + ")";
                    else
                        return position + "";
                case ServomoteurID.GRBrasGauche:
                    if (position == Config.CurrentConfig.PositionGRBrasGaucheRange)
                        return "rangé (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRBrasGaucheSorti)
                        return "sorti (" + position + ")";
                    else
                        return position + "";
                case ServomoteurID.GRCamera:
                    if (position == Config.CurrentConfig.PositionGRCameraBleu)
                        return "bleu (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRCameraRouge)
                        return "rouge (" + position + ")";
                    else
                        return position + "";
                case ServomoteurID.GRGrandBras:
                    if (position == Config.CurrentConfig.PositionGRGrandBrasBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRGrandBrasHaut)
                        return "haut (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRGrandBrasRange)
                        return "rangé (" + position + ")";
                    else
                        return position + "";
                case ServomoteurID.GRPetitBras:
                    if (position == Config.CurrentConfig.PositionGRPetitBrasBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRPetitBrasHaut)
                        return "haut (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRPetitBrasRange)
                        return "rangé (" + position + ")";
                    else
                        return position + "";
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
