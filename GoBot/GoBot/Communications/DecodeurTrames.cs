using GoBot.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications
{
    static class DecodeurTrames
    {
        public static String Decode(String trame)
        {
            return Decode(new Trame(trame));
        }

        public static String Decode(Trame trame)
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

        public static String GetMessage(FonctionTrame function, List<uint> parameters = null)
        {
            String output = "";

            switch (function)
            {
                case FonctionTrame.Debug:
                    output = "Debug {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FonctionTrame.TestConnexion:
                    output = "Test connexion";
                    break;
                case FonctionTrame.TensionBatteries:
                    output = "Tension batteries = {0-1}V";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (parameters[0] / 100.0).ToString("0.00"));
                    }
                    break;
                case FonctionTrame.Reset:
                    output = "Envoi Reset";
                    break;
                case FonctionTrame.Buzzer:
                    output = "Buzzer fréquence = {0-1}Hz, volume={2}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FonctionTrame.DemandeCouleurEquipe:
                    output = "Demande couleur équipe";
                    break;
                case FonctionTrame.RetourCouleurEquipe:
                    output = "Retour couleur équipe : {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FonctionTrame.DemandeCapteurOnOff: 
                    output = "Demande capteur {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((CapteurOnOffID)parameters[0]));
                    }
                    break;
                case FonctionTrame.RetourCapteurOnOff:
                    output = "Retour capteur {0} : {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((CapteurOnOffID)parameters[0]));
                        output = ReplaceParam(output, Nommeur.Nommer(parameters[1] > 0));
                    }
                    break;
                case FonctionTrame.DemandeValeursAnalogiques:
                    output = "Demande valeurs analogiques";
                    break;
                case FonctionTrame.RetourValeursAnalogiques:
                    output = "Retour valeurs analogiques : {0}V / {1}V / {2}V / {3}V / {4}V / {5}V / {6}V / {7}V / {8}V";
                    if (parameters != null)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            output = ReplaceParam(output, (parameters[i] * 0.0008056640625).ToString("0.0000") + "V");
                        }
                    }
                    break;
                case FonctionTrame.DemandeCapteurCouleur:
                    output = "Demande capteur couleur {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((CapteurCouleurID)parameters[0]));
                    }
                    break;
                case FonctionTrame.RetourCapteurCouleur:
                    output = "Retour capteur couleur {0} : {1}-{2}-{3}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((CapteurCouleurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString("000"));
                        output = ReplaceParam(output, parameters[2].ToString("000"));
                        output = ReplaceParam(output, parameters[3].ToString("000"));
                    }
                    break;
                case FonctionTrame.DemandePositionCodeur:
                    output = "Demande position codeur {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((CodeurID)parameters[0]));
                    }
                    break;
                case FonctionTrame.RetourPositionCodeur:
                    output = "Retour position codeur {0} : {1-2-3-4}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((CodeurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FonctionTrame.PilotageOnOff:
                    output = "Pilote actionneur on off {0} : {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((ActionneurOnOffID)parameters[0]));
                        output = ReplaceParam(output, Nommeur.Nommer(parameters[1] > 0));
                    }
                    break;
                case FonctionTrame.Led:
                    output = "Pilote led {0} : {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((LedID)parameters[0]));
                        output = ReplaceParam(output, ((Devices.RecGoBot.LedStatus)parameters[1]).ToString());
                    }
                    break;
                case FonctionTrame.MoteurPosition:
                    output = "Pilote moteur {0} position {1-2}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((MoteurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FonctionTrame.MoteurVitesse:
                    output = "Pilote moteur {0} vitesse {2-3} vers la {1}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((MoteurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, ((SensGD)parameters[2]).ToString().ToLower());
                    }
                    break;
                case FonctionTrame.MoteurAccel:
                    output = "Pilote moteur {0} accélération {1-2}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((MoteurID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FonctionTrame.CommandeServo:
                    output = "Commande servomoteur";
                    // TODO
                    break;
                case FonctionTrame.Deplace:
                    output = "{0} sur {1-2} mm";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (SensAR)parameters[0] == SensAR.Avant ? "Avance" : "Recule");
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FonctionTrame.Pivot:
                    output = "Pivot {0} sur {1-2}°";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensGD)parameters[0]).ToString().ToLower());
                        output = ReplaceParam(output, (parameters[1] / 100.0).ToString());
                    }
                    break;
                case FonctionTrame.Virage:
                    output = "Virage {0} {1} de {4-5}° sur un rayon de {2-3}mm";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                        output = ReplaceParam(output, ((SensGD)parameters[1]).ToString().ToLower());
                        output = ReplaceParam(output, (parameters[2] / 100.0).ToString());
                        output = ReplaceParam(output, parameters[3].ToString());
                    }
                    break;
                case FonctionTrame.Stop:
                    output = "Stop {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((StopMode)parameters[0]).ToString().ToLower());
                    }
                    break;
                case FonctionTrame.Recallage:
                    output = "Recallage {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                    }
                    break;
                case FonctionTrame.TrajectoirePolaire:
                    output = "Trajectoire polaire {0} sur {1-2} points";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FonctionTrame.FinRecallage:
                    output = "Fin de recallage";
                    break;
                case FonctionTrame.FinDeplacement:
                    output = "Fin de déplacement";
                    break;
                case FonctionTrame.Blocage:
                    output = "Blocage !!!";
                    break;
                case FonctionTrame.AsserDemandePositionCodeurs:
                    output = "Demande position codeurs déplacement";
                    break;
                case FonctionTrame.AsserRetourPositionCodeurs:
                    output = "Retour position codeurs déplacement : {0} valeurs";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FonctionTrame.AsserEnvoiConsigneBrutePosition:
                    output = "Envoi consigne brute : {1-2} pas en {0}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, ((SensAR)parameters[0]).ToString().ToLower());
                    }
                    break;
                case FonctionTrame.DemandeChargeCPU_PWM:
                    output = "Demande charge CPU PWM";
                    break;
                case FonctionTrame.RetourChargeCPU_PWM:
                    output = "Retour charge CPU PWM : {0} valeurs";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FonctionTrame.AsserIntervalleRetourPosition:
                    output = "Intervalle de retour de la position : {0}ms";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (parameters[0] * 10).ToString());
                    }
                    break;
                case FonctionTrame.AsserDemandePositionXYTeta:
                    output = "Demande position X Y Teta";
                    break;
                case FonctionTrame.AsserRetourPositionXYTeta:
                    output = "Retour position X = {0-1}mm Y = {2-3}mm Teta = {4-5}°";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, (parameters[0] / 10.0).ToString());
                        output = ReplaceParam(output, (parameters[1] / 10.0).ToString());
                        output = ReplaceParam(output, (parameters[2] / 100.0).ToString());
                    }
                    break;
                case FonctionTrame.AsserVitesseDeplacement:
                    output = "Vitesse ligne : {0-1}mm/s";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FonctionTrame.AsserAccelerationDeplacement:
                    output = "Accélération ligne : {0-1}mm/s² au début, {2-3}mm/s² à la fin";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FonctionTrame.AsserVitessePivot:
                    output = "Vitesse pivot : {0-1}mm/s";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FonctionTrame.AsserAccelerationPivot:
                    output = "Accélération pivot : {0-1}mm/s² au début, {2-3}mm/s² à la fin";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FonctionTrame.AsserPID:
                    output = "Asservissement P={0-1} I={2-3} D={4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[2].ToString());
                    }
                    break;
                case FonctionTrame.AsserEnvoiPositionAbsolue:
                    output = "Envoi position absolue : X={0-1}mm Y={2-3}mm Teta={4-5}°";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, (parameters[2] / 100.0).ToString());
                    }
                    break;
                case FonctionTrame.AsserPIDCap:
                    output = "Asservissement cap P={0-1} I={2-3} D={4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FonctionTrame.AsserPIDVitesse:
                    output = "Asservissement vitesse P={0-1} I={2-3} D={4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case FonctionTrame.EnvoiUart:
                    output = "Envoi UART {0} caractères";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FonctionTrame.RetourUart:
                    output = "Réception UART {0} caractères";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[0].ToString());
                    }
                    break;
                case FonctionTrame.DemandeLidar:
                    output = "Demande mesure LIDAR";
                    break;
                case FonctionTrame.ReponseLidar:
                    output = "Retour mesure LIDAR";
                    break;
                case FonctionTrame.ChangementBaudrateUART:
                    output = "Changement baudrate UART : {0} bauds";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServoBaudrate)parameters[0]).ToString().Substring(1));
                    }
                    break;
                case FonctionTrame.AffichageLCD:
                    output = "Affichage message LCD : ";
                    for (int i = 0; i < 32; i++)
                        output += "{" + i + "}";
                    if (parameters != null)
                    {
                        for (int i = 0; i < 32; i++)
                            output = ReplaceParam(output, ((char)parameters[i]).ToString());
                    }
                        break;
                case FonctionTrame.CouleurLedRGB:
                    output = "Envoi couleur LED {0}: {1}-{2}-{3}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((LedRgbID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString("000"));
                        output = ReplaceParam(output, parameters[2].ToString("000"));
                        output = ReplaceParam(output, parameters[3].ToString("000"));
                    }
                    break;
                case FonctionTrame.DetectionBalise:
                    output = "Détection balise {0} : Tour de {1-2} ticks, {3} détections en haut, {4} détections en bas";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, Nommeur.Nommer((BaliseID)parameters[0]));
                        output = ReplaceParam(output, parameters[1].ToString());
                        output = ReplaceParam(output, parameters[2].ToString());
                        output = ReplaceParam(output, parameters[3].ToString());
                    }
                    break;
                case FonctionTrame.DetectionBaliseRapide:
                    output = "Détection rapide balise";
                    break;
                default:
                    output = "Inconnu";
                    break;
            }

            return output;
        }

        public static String GetMessage(Trame trame)
        {
            String output = "";

            output = GetMessage((FonctionTrame)trame[1]);
            output = GetMessage((FonctionTrame)trame[1], GetParameters(output, trame));

            return output;
        }

        private static List<uint> GetParameters(String format, Trame trame)
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
                        parameters[parameters.Count - 1] = parameters[parameters.Count - 1] * 256 + trame[int.Parse(subParameter) + 2];
                        if (format[iChar] == '-')
                            iChar++;
                    }
                }
            }

            return parameters;
        }

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
