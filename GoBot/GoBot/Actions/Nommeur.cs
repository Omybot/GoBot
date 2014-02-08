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
                case ServomoteurID.GRServoAssiette:
                    return "blocage assiette";
                case ServomoteurID.PRBrasArriere:
                    return "bras arrière";
                //case ServomoteurID.PRBrasAvant:
                //    return "bras avant";
                case ServomoteurID.PRBrasAvantDroit:
                    return "bras avant droit";
                case ServomoteurID.PRBrasAvantGauche:
                    return "bras avant gauche";
                case ServomoteurID.PRBrasArriereDroit:
                    return "bras avant droit";
                case ServomoteurID.PRBrasArriereGauche:
                    return "bras arrière gauche";
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
                    else return position.ToString();

                case ServomoteurID.GRDebloqueur:
                    if (position == Config.CurrentConfig.PositionGRDebloqueurBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRDebloqueurHaut)
                        return "haut (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.GRBrasDroit:
                    if (position == Config.CurrentConfig.PositionGRBrasDroitRange)
                        return "rangé (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRBrasDroitSorti)
                        return "sorti (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.GRBrasGauche:
                    if (position == Config.CurrentConfig.PositionGRBrasGaucheRange)
                        return "rangé (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRBrasGaucheSorti)
                        return "sorti (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.GRCamera:
                    if (position == Config.CurrentConfig.PositionGRCameraBleu)
                        return "bleu (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRCameraRouge)
                        return "rouge (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.GRGrandBras:
                    if (position == Config.CurrentConfig.PositionGRGrandBrasBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRGrandBrasHaut)
                        return "haut (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRGrandBrasRange)
                        return "rangé (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.GRPetitBras:
                    if (position == Config.CurrentConfig.PositionGRPetitBrasBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRPetitBrasHaut)
                        return "haut (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRPetitBrasRange)
                        return "rangé (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.GRServoAssiette:
                    if (position == Config.CurrentConfig.PositionGRBloqueurFerme)
                        return "bloqué (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionGRBloqueurOuvert)
                        return "ouvert (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.PRBrasArriere:
                    if (position == Config.CurrentConfig.PositionPRBrasArriereBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionPRBrasArriereHaut)
                        return "haut (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionPRBrasArriereAssiette)
                        return "assiette (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionPRBrasArriereRange)
                        return "rangé (" + position + ")";
                    else return position.ToString();

                    /*
                case ServomoteurID.PRBrasAvant:
                    if (position == Config.CurrentConfig.PositionPRBrasAvantBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionPRBrasAvantHaut)
                        return "haut (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionPRBrasAvantAssiette)
                        return "assiette (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionPRBrasAvantRange)
                        return "rangé (" + position + ")";*/


                case ServomoteurID.PRBrasAvantDroit:
                    if (position == Config.CurrentConfig.PositionPRBrasAvantDroitBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionPRBrasAvantDroitHaut)
                        return "haut (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.PRBrasAvantGauche:
                    if (position == Config.CurrentConfig.PositionPRBrasAvantGaucheBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionPRBrasAvantGaucheHaut)
                        return "haut (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.PRBrasArriereDroit:
                    if (position == Config.CurrentConfig.PositionPRBrasArriereDroitBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionPRBrasArriereDroitHaut)
                        return "haut (" + position + ")";
                    else return position.ToString();

                case ServomoteurID.PRBrasArriereGauche:
                    if (position == Config.CurrentConfig.PositionPRBrasArriereGaucheBas)
                        return "bas (" + position + ")";
                    else if (position == Config.CurrentConfig.PositionPRBrasArriereGaucheHaut)
                        return "haut (" + position + ")";
                    else return position.ToString();

                default:
                    return position.ToString();
            }
        }

        public static String Nommer(MoteurID moteur)
        {
            switch (moteur)
            {
                case MoteurID.GRCanon:
                    return "canon";
                case MoteurID.GRTurbineAspirateur:
                    return "aspiration";
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
                case MoteurID.GRCanon:
                    if (vitesse == Config.CurrentConfig.VitessePropulsionBonne)
                        return "panier (" + vitesse + ")";
                    else if (vitesse == 0)
                        return "éteint (0)";
                    else
                        return vitesse + "";
                case MoteurID.GRTurbineAspirateur:
                    if (vitesse == Config.CurrentConfig.VitesseAspiration)
                        return "aspirer (" + vitesse + ")";
                    else if (vitesse == Config.CurrentConfig.VitesseAspirationMaintien)
                        return "maintien (" + vitesse + ")";
                    else if (vitesse == 0)
                        return "éteint (0)";
                    else
                        return vitesse + "";
                default:
                    return vitesse.ToString();
            }
        }

        public static String Nommer(ActionneurOnOffID actionneur)
        {
            switch (actionneur)
            {
                case ActionneurOnOffID.GRShutter:
                    return "shutter";
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
                case CapteurID.GRCouleurBalle:
                    return "couleur balle";
                case CapteurID.GRPresenceBalle:
                    return "présence balle";
                default:
                    return capteur.ToString();
            }
        }
    }
}
