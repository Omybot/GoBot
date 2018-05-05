﻿using GoBot.Actions;
using System;
using System.Collections.Generic;

namespace GoBot.Communications
{
    static class FrameDecoder
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
        public static String GetMessage(FrameFunction function, List<uint> parameters = null)
        {
            String output = "";

            switch (function)
            {
                case FrameFunction.EnvoiUart2:
                    output = "Envoi UART2";
                    break;
                case FrameFunction.RetourUart2:
                    output = "Retour UART2";
                    break;
                case FrameFunction.DemandeCapteurPattern:
                    output = "Demande periode capteur pattern";
                    break;
                case FrameFunction.RetourCapteurPattern:
                    output = "Retour periode capteur pattern {0-1}";
                    break;
                case FrameFunction.DemandeValeursNumeriques:
                    output = "Demande valeurs des ports numériques";
                    break;
                case FrameFunction.RetourValeursNumeriques:
                    output = "Retour ports numériques : {0}_{1} / {2}_{3} / {4}_{5}";
                    if(parameters != null)
                    {
                        for(int i = 0; i < 6; i++)
                            output = ReplaceParam(output, Convert.ToString(parameters[i], 2).PadLeft(8, '0'));
                    }
                    break;

                case FrameFunction.Debug:
                    output = "Debug {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.TestConnexion:
                    output = "Test connexion";
                    break;
                case FrameFunction.TensionBatteries:
                    output = "Tension batteries = {0-1}V";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (parameters[0] / 100.0).ToString("0.00"));
                    }
                    break;
                case FrameFunction.Reset:
                    output = "Envoi Reset";
                    break;
                case FrameFunction.Buzzer:
                    output = "Buzzer fréquence = {0-1}Hz, volume={2}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FrameFunction.DemandeCouleurEquipe:
                    output = "Demande couleur équipe";
                    break;
                case FrameFunction.RetourCouleurEquipe:
                    output = "Retour couleur équipe : {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.DemandeCapteurOnOff: 
                    output = "Demande capteur {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CapteurOnOffID)parameters[0]));
                    }
                    break;
                case FrameFunction.RetourCapteurOnOff:
                    output = "Retour capteur {0} : {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CapteurOnOffID)parameters[0]));
                        output = ReplaceParam(output, NameFinder.GetName(parameters[1] > 0));
                    }
                    break;
                case FrameFunction.DemandeValeursAnalogiques:
                    output = "Demande valeurs analogiques";
                    break;
                case FrameFunction.RetourValeursAnalogiques:
                    output = "Retour valeurs analogiques : {0}V / {1}V / {2}V / {3}V / {4}V / {5}V / {6}V / {7}V / {8}V";
                    if (parameters != null)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            output = ReplaceParam(output, (parameters[i] * 0.0008056640625).ToString("0.0000") + "V");
                        }
                    }
                    break;
                case FrameFunction.DemandeCapteurCouleur:
                    output = "Demande capteur couleur {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CapteurCouleurID)parameters[0]));
                    }
                    break;
                case FrameFunction.RetourCapteurCouleur:
                    output = "Retour capteur couleur {0} : {1}-{2}-{3}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CapteurCouleurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString("000"));
                        output = ReplaceParam(output, parameters[2].ToString("000"));
                        output = ReplaceParam(output, parameters[3].ToString("000"));
                    }
                    break;
                case FrameFunction.DemandePositionCodeur:
                    output = "Demande position codeur {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CodeurID)parameters[0]));
                    }
                    break;
                case FrameFunction.RetourPositionCodeur:
                    output = "Retour position codeur {0} : {1-2-3-4}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((CodeurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FrameFunction.PilotageOnOff:
                    output = "Pilote actionneur on off {0} : {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((ActionneurOnOffID)parameters[0]));
                        output = ReplaceParam(output, NameFinder.GetName(parameters[1] > 0));
                    }
                    break;
                case FrameFunction.Led:
                    output = "Pilote led {0} : {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((LedID)parameters[0]));
                        output = ReplaceParam(output, ((Devices.RecGoBot.LedStatus)parameters[1]).ToString());
                    }
                    break;
                case FrameFunction.MoteurPosition:
                    output = "Pilote moteur {0} position {1-2}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FrameFunction.MoteurVitesse:
                    output = "Pilote moteur {0} vitesse {2-3} vers la {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, ((SensGD)parameters[2]).ToString().ToLower());
                    }
                    break;
                case FrameFunction.MoteurAccel:
                    output = "Pilote moteur {0} accélération {1-2}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((MoteurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FrameFunction.CommandeServo:
                    output = "Commande servomoteur";
                    // TODO
                    break;
                case FrameFunction.Deplace:
                    output = "{0} sur {1-2} mm";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (SensAR)parameters[0] == SensAR.Avant ? "Avance" : "Recule");
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FrameFunction.Pivot:
                    output = "Pivot {0} sur {1-2}°";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensGD)parameters[0]).ToString().ToLower());
                        output = ReplaceParam(output, (parameters[1] / 100.0).ToString());
                    }
                    break;
                case FrameFunction.Virage:
                    output = "Virage {0} {1} de {4-5}° sur un rayon de {2-3}mm";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                        output = ReplaceParam(output, ((SensGD)parameters[1]).ToString().ToLower());
                        output = ReplaceParam(output, (parameters[2] / 100.0).ToString());
                        output = ReplaceParam(output, parameters[3].ToString());
                    }
                    break;
                case FrameFunction.Stop:
                    output = "Stop {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((StopMode)parameters[0]).ToString().ToLower());
                    }
                    break;
                case FrameFunction.Recallage:
                    output = "Recallage {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                    }
                    break;
                case FrameFunction.TrajectoirePolaire:
                    output = "Trajectoire polaire {0} sur {1-2} points";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FrameFunction.FinRecallage:
                    output = "Fin de recallage";
                    break;
                case FrameFunction.FinDeplacement:
                    output = "Fin de déplacement";
                    break;
                case FrameFunction.Blocage:
                    output = "Blocage !!!";
                    break;
                case FrameFunction.AsserDemandePositionCodeurs:
                    output = "Demande position codeurs déplacement";
                    break;
                case FrameFunction.AsserRetourPositionCodeurs:
                    output = "Retour position codeurs déplacement : {0} valeurs";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.AsserEnvoiConsigneBrutePosition:
                    output = "Envoi consigne brute : {1-2} pas en {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                    }
                    break;
                case FrameFunction.DemandeChargeCPU_PWM:
                    output = "Demande charge CPU PWM";
                    break;
                case FrameFunction.RetourChargeCPU_PWM:
                    output = "Retour charge CPU PWM : {0} valeurs";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.AsserIntervalleRetourPosition:
                    output = "Intervalle de retour de la position : {0}ms";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (parameters[0] * 10).ToString());
                    }
                    break;
                case FrameFunction.AsserDemandePositionXYTeta:
                    output = "Demande position X Y Teta";
                    break;
                case FrameFunction.AsserRetourPositionXYTeta:
                    output = "Retour position X = {0-1}mm Y = {2-3}mm Teta = {4-5}°";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (parameters[0] / 10.0).ToString());
                        output = ReplaceParam(output, (parameters[1] / 10.0).ToString());
                        output = ReplaceParam(output, (parameters[2] / 100.0).ToString());
                    }
                    break;
                case FrameFunction.AsserVitesseDeplacement:
                    output = "Vitesse ligne : {0-1}mm/s";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.AsserAccelerationDeplacement:
                    output = "Accélération ligne : {0-1}mm/s² au début, {2-3}mm/s² à la fin";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.AsserVitessePivot:
                    output = "Vitesse pivot : {0-1}mm/s";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.AsserAccelerationPivot:
                    output = "Accélération pivot : {0-1}mm/s² au début, {2-3}mm/s² à la fin";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.AsserPID:
                    output = "Asservissement P={0-1} I={2-3} D={4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[2].ToString());
                    }
                    break;
                case FrameFunction.AsserEnvoiPositionAbsolue:
                    output = "Envoi position absolue : X={0-1}mm Y={2-3}mm Teta={4-5}°";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, (parameters[2] / 100.0).ToString());
                    }
                    break;
                case FrameFunction.AsserPIDCap:
                    output = "Asservissement cap P={0-1} I={2-3} D={4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FrameFunction.AsserPIDVitesse:
                    output = "Asservissement vitesse P={0-1} I={2-3} D={4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FrameFunction.EnvoiUart1:
                    output = "Envoi UART {0} caractères";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.RetourUart1:
                    output = "Réception UART {0} caractères";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.DemandeLidar:
                    output = "Demande mesure LIDAR";
                    break;
                case FrameFunction.ReponseLidar:
                    output = "Retour mesure LIDAR";
                    break;
                case FrameFunction.ChangementBaudrateUART:
                    output = "Changement baudrate UART : {0} bauds";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServoBaudrate)parameters[0]).ToString().Substring(1));
                    }
                    break;
                case FrameFunction.AffichageLCD:
                    output = "Affichage message LCD : ";
                    for (int i = 0; i < 32; i++)
                        output += "{" + i + "}";
                    if (parameters != null)
                    {
                        for (int i = 0; i < 32; i++)
                            output = ReplaceParam(output, ((char)parameters[i]).ToString());
                    }
                        break;
                case FrameFunction.CouleurLedRGB:
                    output = "Envoi couleur LED {0}: {1}-{2}-{3}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((LedRgbID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString("000"));
                        output = ReplaceParam(output, parameters[2].ToString("000"));
                        output = ReplaceParam(output, parameters[3].ToString("000"));
                    }
                    break;
                case FrameFunction.DetectionBalise:
                    output = "Détection balise {0} : Tour de {1-2} ticks, {3} détections en haut, {4} détections en bas";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, NameFinder.GetName((BaliseID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[2].ToString());
                        output = ReplaceParam(output, parameters[3].ToString());
                    }
                    break;
                case FrameFunction.DetectionBaliseRapide:
                    output = "Détection rapide balise";
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

            output = GetMessage((FrameFunction)trame[1]);
            output = GetMessage((FrameFunction)trame[1], GetParameters(output, trame));

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
