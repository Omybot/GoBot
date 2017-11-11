using GoBot.Actions;
using System;
using System.Collections.Generic;

namespace GoBot.Communications
{
    static class FrameDecoder
    {
        public static String Decode(Frame trame)
        {
           
            //                case FonctionTrame.CommandeServo:
            //                    switch ((FonctionServo)trame[2])
            //                    {
            //                        case FonctionServo.DemandeComplianceParams:
            //                            message = "Demande compliance servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeConfigAlarmeLED:
            //                            message = "Demande config alarme LED servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeConfigAlarmeShutdown:
            //                            message = "Demande config alarme shutdown servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeConfigEcho:
            //                            message = "Demande config echo servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeCoupleActive:
            //                            message = "Demande couple actif servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeCoupleMaximum:
            //                            message = "Demande couple max servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeLed:
            //                            message = "Demande état LED servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeMouvement:
            //                            message = "Demande mouvemement servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeNumeroModele:
            //                            message = "Demande numéro modèle servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandePositionActuelle:
            //                            message = "Demande position actuelle servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandePositionCible:
            //                            message = "Demande position cible servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandePositionMaximum:
            //                            message = "Demande position maximum servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandePositionMinimum:
            //                            message = "Demande position minimum servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeTemperature:
            //                            message = "Demande température servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeTension:
            //                            message = "Demande tension servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeVersionFirmware:
            //                            message = "Demande version firmware servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeVitesseActuelle:
            //                            message = "Demande vitesse actuelle servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeVitesseMax:
            //                            message = "Demande vitesse max servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.EnvoiBaudrate:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " baudrate " + ((ServoBaudrate)trame[4]).ToString();
            //                            break;
            //                        case FonctionServo.EnvoiComplianceParams:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " compliance CCWSlope=" + trame[4] + " CCWMargin=" + trame[5] + " CWSlope=" + trame[6] + " CWMargin=" + trame[7];
            //                            break;
            //                        case FonctionServo.EnvoiConfigAlarmeLED:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme LED : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
            //                            break;
            //                        case FonctionServo.EnvoiConfigAlarmeShutdown:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme shutdown : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
            //                            break;
            //                        case FonctionServo.EnvoiConfigEcho:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config echo  à " + trame[4];
            //                            break;
            //                        case FonctionServo.EnvoiCoupleActive:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple " + (trame[4] > 0 ? "Activé" : "Désactivé");
            //                            break;
            //                        case FonctionServo.EnvoiCoupleMaximum:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple maximum " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.EnvoiId:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " ID " + trame[4];
            //                            break;
            //                        case FonctionServo.EnvoiLed:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " LED " + (trame[4] > 0 ? "On" : "Off"); ;
            //                            break;
            //                        case FonctionServo.EnvoiPositionCible:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position " + GoBot.Actions.Nommeur.Nommer(trame[4] * 256 + trame[5], (ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.EnvoiPositionMaximum:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position maximum " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.EnvoiPositionMinimum:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position minimum " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.EnvoiVitesseMax:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " vitesse max " + (trame[4] * 256 + trame[5]) + " (" + ((double)(trame[4] * 256 + trame[5]) * 0.111) + "rpm)";
            //                            break;
            //                        case FonctionServo.Reset:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " reset";
            //                            break;
            //                        case FonctionServo.RetourComplianceParams:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " compliance : CCWSlope=" + trame[4] + " CCWMargin=" + trame[5] + " CWSlope=" + trame[6] + " CWMargin=" + trame[7];
            //                            break;
            //                        case FonctionServo.RetourConfigAlarmeLED:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme LED : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
            //                            break;
            //                        case FonctionServo.RetourConfigAlarmeShutdown:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme shutdown : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
            //                            break;
            //                        case FonctionServo.RetourConfigEcho:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config echo = " + trame[4];
            //                            break;
            //                        case FonctionServo.RetourCoupleActive:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple = " + (trame[4] > 0 ? "On" : "Off");
            //                            break;
            //                        case FonctionServo.RetourCoupleMaximum:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple maximum = " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.RetourLed:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " LED " + (trame[4] > 0 ? "On" : "Off");
            //                            break;
            //                        case FonctionServo.RetourMouvement:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " mouvement : " + (trame[4] > 0 ? "En cours" : "Terminé");
            //                            break;
            //                        case FonctionServo.RetourNumeroModele:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " numéro modèle : " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.RetourPositionActuelle:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position actuelle : " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.RetourPositionCible:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position cible : " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.RetourPositionMaximum:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position maximum : " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.RetourPositionMinimum:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position minimum : " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.RetourTemperature:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " température : " + trame[4] + "°C";
            //                            break;
            //                        case FonctionServo.RetourTension:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " tension : " + ((double)trame[4] / 10.0) + "V";
            //                            break;
            //                        case FonctionServo.RetourVersionFirmware:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " version firmware : " + trame[4];
            //                            break;
            //                        case FonctionServo.RetourVitesseActuelle:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " vitesse actuelle : " + (trame[4] * 256 + trame[5]) + " (" + ((double)(trame[4] * 256 + trame[5]) * 0.111) + "rpm)";
            //                            break;
            //                        case FonctionServo.RetourVitesseMax:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " vitesse maximum : " + (trame[4] * 256 + trame[5]) + " (" + ((double)(trame[4] * 256 + trame[5]) * 0.111) + "rpm)";
            //                            break;
            //                        case FonctionServo.DemandeErreurs:
            //                            message = "Demande erreurs servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.DemandeCoupleCourant:
            //                            message = "Demande couple courant servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.RetourCoupleCourant:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple courant : " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.DemandeStatusLevel:
            //                            message = "Demande status level servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.RetourStatusLevel:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " status level : " + trame[4];
            //                            break;
            //                        case FonctionServo.EnvoiTensionMax:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " tension max : " + (trame[4] * 256 + trame[5]) / 10.0 + "V";
            //                            break;
            //                        case FonctionServo.DemandeTensionMax:
            //                            message = "Demande tension max servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.RetourTensionMax:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " tension max : " + trame[4] / 10.0 + "V";
            //                            break;
            //                        case FonctionServo.EnvoiTensionMin:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " tension min : " + trame[4] / 10.0 + "V";
            //                            break;
            //                        case FonctionServo.DemandeTensionMin:
            //                            message = "Demande tension min servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.RetourTensionMin:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " tension min : " + trame[4] / 10.0 + "V";
            //                            break;
            //                        case FonctionServo.EnvoiTemperatureMax:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " temperature max : " + trame[4] + "°C";
            //                            break;
            //                        case FonctionServo.DemandeTemperatureMax:
            //                            message = "Demande temperature max servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.RetourTemperatureMax:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " temperature max : " + trame[4] + "°C";
            //                            break;
            //                        case FonctionServo.DemandeCoupleLimite:
            //                            message = "Demande couple limite servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
            //                            break;
            //                        case FonctionServo.RetourCoupleLimite:
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple limite : " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.EnvoiCoupleLimite:
            //                            message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple limite : " + (trame[4] * 256 + trame[5]);
            //                            break;
            //                        case FonctionServo.RetourErreurs:
            //                            String listeErreurs = "";
            //                            message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " erreurs : ";
            //                            if (trame[4] > 0)
            //                                listeErreurs += "AngleLimit, ";
            //                            if (trame[5] > 0)
            //                                listeErreurs += "Checksum, ";
            //                            if (trame[6] > 0)
            //                                listeErreurs += "InputVoltage, ";
            //                            if (trame[7] > 0)
            //                                listeErreurs += "Instruction, ";
            //                            if (trame[8] > 0)
            //                                listeErreurs += "Overheating, ";
            //                            if (trame[9] > 0)
            //                                listeErreurs += "Overload, ";
            //                            if (trame[10] > 0)
            //                                listeErreurs += "Range, ";

            //                            if (listeErreurs.Length == 0)
            //                                message += "Aucune";
            //                            else
            //                                message += listeErreurs.Substring(0, listeErreurs.Length - 2);
            //                            break;
            //                        default:
            //                            message = ((FonctionServo)trame[2]).ToString();
            //                            break;
            //                    

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
                case FrameFunction.EnvoiUart:
                    output = "Envoi UART {0} caractères";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FrameFunction.RetourUart:
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
