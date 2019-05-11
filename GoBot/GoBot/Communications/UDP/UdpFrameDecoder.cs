using System;
using System.Collections.Generic;

namespace GoBot.Communications.UDP
{
    static class UdpFrameDecoder
    {
        public static String Decode(Frame trame)
        {
            return GetMessage(trame);
        }

        /// <summary>
        /// Récupère le message explicite associé à une fonction du protocole.
        /// Les paramètres sont signalés par des accolades indiquant la position dans la trame des octets correspondant à la valeur du paramètre.
        /// Si les paramètres sont fournis, leur valeur remplacent les paramètres entre accolades.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static String GetMessage(UdpFrameFunction function, List<uint> parameters = null)
        {
            String output = "";

            switch (function)
            {
                case UdpFrameFunction.EnvoiUart2:
                    output = "Envoi UART2";
                    break;
                case UdpFrameFunction.RetourUart2:
                    output = "Retour UART2";
                    break;
                case UdpFrameFunction.DemandeValeursNumeriques:
                    output = "Demande valeurs des ports numériques";
                    break;
                case UdpFrameFunction.RetourValeursNumeriques:
                    output = "Retour ports numériques : {0}_{1} / {2}_{3} / {4}_{5}";
                    if (parameters != null)
                    {
                        for (int i = 0; i < 6; i++)
                            output = ReplaceParam(output, Convert.ToString(parameters[i], 2).PadLeft(8, '0'));
                    }
                    break;

                case UdpFrameFunction.Debug:
                    output = "Debug {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case UdpFrameFunction.TestConnexion:
                    output = "Test connexion";
                    break;
                case UdpFrameFunction.TensionBatteries:
                    output = "Tension batteries = {0-1}V";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (parameters[0] / 100.0).ToString("0.00"));
                    }
                    break;
                case UdpFrameFunction.Reset:
                    output = "Envoi Reset";
                    break;
                case UdpFrameFunction.Buzzer:
                    output = "Buzzer fréquence = {0-1}Hz, volume={2}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case UdpFrameFunction.DemandeCouleurEquipe:
                    output = "Demande couleur équipe";
                    break;
                case UdpFrameFunction.RetourCouleurEquipe:
                    output = "Retour couleur équipe : {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case UdpFrameFunction.DemandeCapteurOnOff:
                    output = "Demande capteur {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CapteurOnOffID)parameters[0]));
                    }
                    break;
                case UdpFrameFunction.RetourCapteurOnOff:
                    output = "Retour capteur {0} : {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CapteurOnOffID)parameters[0]));
                        output = ReplaceParam(output, NameFinder.GetName(parameters[1] > 0));
                    }
                    break;
                case UdpFrameFunction.DemandeValeursAnalogiques:
                    output = "Demande valeurs analogiques";
                    break;
                case UdpFrameFunction.RetourValeursAnalogiques:
                    output = "Retour valeurs analogiques : {0}V / {1}V / {2}V / {3}V / {4}V / {5}V / {6}V / {7}V / {8}V";
                    if (parameters != null)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            output = ReplaceParam(output, (parameters[i] * 0.0008056640625).ToString("0.0000") + "V");
                        }
                    }
                    break;
                case UdpFrameFunction.DemandeCapteurCouleur:
                    output = "Demande capteur couleur {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CapteurCouleurID)parameters[0]));
                    }
                    break;
                case UdpFrameFunction.RetourCapteurCouleur:
                    output = "Retour capteur couleur {0} : {1}-{2}-{3}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CapteurCouleurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString("000"));
                        output = ReplaceParam(output, parameters[2].ToString("000"));
                        output = ReplaceParam(output, parameters[3].ToString("000"));
                    }
                    break;
                case UdpFrameFunction.DemandePositionCodeur:
                    output = "Demande position codeur {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CodeurID)parameters[0]));
                    }
                    break;
                case UdpFrameFunction.RetourPositionCodeur:
                    output = "Retour position codeur {0} : {1-2-3-4}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CodeurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case UdpFrameFunction.PilotageOnOff:
                    output = "Pilote actionneur on off {0} : {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((ActionneurOnOffID)parameters[0]));
                        output = ReplaceParam(output, NameFinder.GetName(parameters[1] > 0));
                    }
                    break;
                case UdpFrameFunction.Led:
                    output = "Pilote led {0} : {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((LedID)parameters[0]));
                        output = ReplaceParam(output, ((Devices.RecGoBot.LedStatus)parameters[1]).ToString());
                    }
                    break;
                case UdpFrameFunction.MoteurPosition:
                    output = "Pilote moteur {0} position {1-2}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case UdpFrameFunction.MoteurVitesse:
                    output = "Pilote moteur {0} vitesse {2-3} vers la {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, ((SensGD)parameters[2]).ToString().ToLower());
                    }
                    break;
                case UdpFrameFunction.MoteurAccel:
                    output = "Pilote moteur {0} accélération {1-2}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case UdpFrameFunction.MoteurStop:
                    output = "Moteur {0} stoppé {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                        output = ReplaceParam(output, ((StopMode)parameters[1]).ToString());
                    }
                    break;
                case UdpFrameFunction.MoteurOrigin:
                    output = "Envoi du moteur {0} à l'origine";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                    }
                    break;
                case UdpFrameFunction.MoteurResetPosition:
                    output = "Moteur {0} réintialisé à 0";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                    }
                    break;
                case UdpFrameFunction.MoteurFin:
                    output = "Moteur {0} arrivé à destination";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                    }
                    break;
                case UdpFrameFunction.MoteurBlocage:
                    output = "Moteur {0} bloqué";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                    }
                    break;
                case UdpFrameFunction.CommandeServo:
                    output = "Commande servomoteur";
                    // TODO
                    break;
                case UdpFrameFunction.Deplace:
                    output = "{0} sur {1-2} mm";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (SensAR)parameters[0] == SensAR.Avant ? "Avance" : "Recule");
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case UdpFrameFunction.Pivot:
                    output = "Pivot {0} sur {1-2}°";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensGD)parameters[0]).ToString().ToLower());
                        output = ReplaceParam(output, (parameters[1] / 100.0).ToString());
                    }
                    break;
                case UdpFrameFunction.Virage:
                    output = "Virage {0} {1} de {4-5}° sur un rayon de {2-3}mm";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                        output = ReplaceParam(output, ((SensGD)parameters[1]).ToString().ToLower());
                        output = ReplaceParam(output, (parameters[2] / 100.0).ToString());
                        output = ReplaceParam(output, parameters[3].ToString());
                    }
                    break;
                case UdpFrameFunction.Stop:
                    output = "Stop {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((StopMode)parameters[0]).ToString().ToLower());
                    }
                    break;
                case UdpFrameFunction.Recallage:
                    output = "Recallage {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                    }
                    break;
                case UdpFrameFunction.TrajectoirePolaire:
                    output = "Trajectoire polaire {0} sur {1-2} points";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case UdpFrameFunction.FinRecallage:
                    output = "Fin de recallage";
                    break;
                case UdpFrameFunction.FinDeplacement:
                    output = "Fin de déplacement";
                    break;
                case UdpFrameFunction.Blocage:
                    output = "Blocage !!!";
                    break;
                case UdpFrameFunction.AsserDemandePositionCodeurs:
                    output = "Demande position codeurs déplacement";
                    break;
                case UdpFrameFunction.AsserRetourPositionCodeurs:
                    output = "Retour position codeurs déplacement : {0} valeurs";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case UdpFrameFunction.AsserEnvoiConsigneBrutePosition:
                    output = "Envoi consigne brute : {1-2} pas en {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                    }
                    break;
                case UdpFrameFunction.DemandeChargeCPU_PWM:
                    output = "Demande charge CPU PWM";
                    break;
                case UdpFrameFunction.RetourChargeCPU_PWM:
                    output = "Retour charge CPU PWM : {0} valeurs";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case UdpFrameFunction.AsserIntervalleRetourPosition:
                    output = "Intervalle de retour de la position : {0}ms";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (parameters[0] * 10).ToString());
                    }
                    break;
                case UdpFrameFunction.AsserDemandePositionXYTeta:
                    output = "Demande position X Y Teta";
                    break;
                case UdpFrameFunction.AsserRetourPositionXYTeta:
                    output = "Retour position X = {0-1}mm Y = {2-3}mm Teta = {4-5}°";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (parameters[0] / 10.0).ToString());
                        output = ReplaceParam(output, (parameters[1] / 10.0).ToString());
                        output = ReplaceParam(output, (parameters[2] / 100.0).ToString());
                    }
                    break;
                case UdpFrameFunction.AsserVitesseDeplacement:
                    output = "Vitesse ligne : {0-1}mm/s";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case UdpFrameFunction.AsserAccelerationDeplacement:
                    output = "Accélération ligne : {0-1}mm/s² au début, {2-3}mm/s² à la fin";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case UdpFrameFunction.AsserVitessePivot:
                    output = "Vitesse pivot : {0-1}mm/s";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case UdpFrameFunction.AsserAccelerationPivot:
                    output = "Accélération pivot : {0-1}mm/s² au début, {2-3}mm/s² à la fin";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case UdpFrameFunction.AsserPID:
                    output = "Asservissement P={0-1} I={2-3} D={4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[2].ToString());
                    }
                    break;
                case UdpFrameFunction.AsserEnvoiPositionAbsolue:
                    output = "Envoi position absolue : X={0-1}mm Y={2-3}mm Teta={4-5}°";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, (parameters[2] / 100.0).ToString());
                    }
                    break;
                case UdpFrameFunction.AsserPIDCap:
                    output = "Asservissement cap P={0-1} I={2-3} D={4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case UdpFrameFunction.AsserPIDVitesse:
                    output = "Asservissement vitesse P={0-1} I={2-3} D={4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case UdpFrameFunction.EnvoiUart1:
                    output = "Envoi UART {0} caractères";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case UdpFrameFunction.RetourUart1:
                    output = "Réception UART {0} caractères";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case UdpFrameFunction.ChangementBaudrateUART:
                    output = "Changement baudrate UART : {0} bauds";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServoBaudrate)parameters[0]).ToString().Substring(1));
                    }
                    break;
                case UdpFrameFunction.AffichageLCD:
                    output = "Affichage message LCD : ";
                    for (int i = 0; i < 32; i++)
                        output += "{" + i + "}";
                    if (parameters != null)
                    {
                        for (int i = 0; i < 32; i++)
                            output = ReplaceParam(output, ((char)parameters[i]).ToString());
                    }
                    break;
                case UdpFrameFunction.CouleurLedRGB:
                    output = "Envoi couleur LED {0}: {1}-{2}-{3}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((LedRgbID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString("000"));
                        output = ReplaceParam(output, parameters[2].ToString("000"));
                        output = ReplaceParam(output, parameters[3].ToString("000"));
                    }
                    break;
                case UdpFrameFunction.DetectionBalise:
                    output = "Détection balise {0} : Tour de {1-2} ticks, {3} détections en haut, {4} détections en bas";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((BaliseID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[2].ToString());
                        output = ReplaceParam(output, parameters[3].ToString());
                    }
                    break;
                case UdpFrameFunction.DetectionBaliseRapide:
                    output = "Détection rapide balise";
                    break;
                case UdpFrameFunction.EnvoiCAN:
                    output = "Envoi message CAN";
                    break;
                case UdpFrameFunction.ReponseCAN:
                    output = "Reception message CAN";
                    break;
                default:
                    output = "Inconnu";
                    break;
            }

            return output;
        }

        /// <summary>
        /// Retourne le message contenu dans une trame dans un texte explicite avec les paramètres décodés
        /// </summary>
        /// <param name="trame">Trame à décoder</param>
        /// <returns>Message sur le contnu de la trame</returns>
        public static String GetMessage(Frame trame)
        {
            String output = "";

            output = GetMessage((UdpFrameFunction)trame[1]);
            output = GetMessage((UdpFrameFunction)trame[1], GetParameters(output, trame));

            return output;
        }

        /// <summary>
        /// Retourne la liste des valeurs des paramètres d'une trame selon le format donné
        /// </summary>
        /// <param name="format">Format du décodage sous la forme "Message valeur = {0-1}" équivaut à un paramètre situé sur les 1er et 2eme octets.</param>
        /// <param name="frame">Trame dans laquelle lire les valeurs</param>
        /// <returns>Liste des valeurs brutes des paramètres</returns>
        private static List<uint> GetParameters(String format, Frame frame)
        {
            List<uint> parameters = new List<uint>();
            String subParameter;

            for (int iChar = 0; iChar < format.Length; iChar++)
            {
                if (format[iChar] == '{')
                {
                    iChar++;
                    parameters.Add(0);

                    while (format[iChar] != '}')
                    {
                        subParameter = "";
                        while (format[iChar] != '-' && format[iChar] != '}')
                        {
                            subParameter += format[iChar];
                            iChar++;
                        }
                        parameters[parameters.Count - 1] = parameters[parameters.Count - 1] * 256 + frame[int.Parse(subParameter) + 2];
                        if (format[iChar] == '-')
                            iChar++;
                    }
                }
            }

            return parameters;
        }

        /// <summary>
        /// Remplace le premier paramètre entre accolades par le message donné
        /// </summary>
        /// <param name="input">Chaine contenant le message entier paramétré</param>
        /// <param name="msg">Message à écrire à la place du premier paramètre</param>
        /// <returns>Chaine contenant le message avec le paramètre remplacé</returns>
        private static String ReplaceParam(String input, String msg)
        {
            int iStart = input.IndexOf("{");
            int iEnd = input.IndexOf("}");

            String param = input.Substring(iStart, iEnd - iStart + 1);
            String output = input.Replace(param, msg);

            return output;
        }
    }
}
