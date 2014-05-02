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
            String message = "";

            try
            {
                switch (trame[0])
                {
                    case (byte)Carte.RecIO:
                        switch ((FonctionIO)trame[1])
                        {
                            case FonctionIO.DemandeCapteurOnOff:
                                message = "Demande capteur " + Nommeur.Nommer((CapteurOnOff)trame[2]);
                                break;
                            case FonctionIO.RetourCapteurOnOff:
                                message = "Retour capteur " + Nommeur.Nommer((CapteurOnOff)trame[2]) + " = " + (((int)trame[3]) > 0 ? "Oui" : "Non");
                                break;
                            case FonctionIO.Debug:
                                message = "Debug " + (int)trame[2];
                                break;
                            case FonctionIO.Moteur:
                                message = "Moteur " + Nommeur.Nommer((MoteurID)trame[2]) + " position " + (trame[3] * 256 + trame[4]);
                                break;
                            case FonctionIO.ActionneurOnOff:
                                message = "Actionneur " + Nommeur.Nommer((ActionneurOnOffID)trame[2]) + (trame[3] > 0 ? " on" : " off");
                                break;
                            case FonctionIO.ReponseTension:
                                message = "Tension batteries : Pack1 = " + (double)(trame[2] * 256 + trame[3]) / 100.0 + " V - Pack2 = " + (double)(trame[4] * 256 + trame[5]) / 100.0;
                                break;
                            case FonctionIO.DemandeTension:
                                message = "Demande tension batteries";
                                break;
                            case FonctionIO.ArmerJack:
                                message = "Armage du jack";
                                break;
                            case FonctionIO.DemandeCouleurEquipe:
                                message = "Demande couleur équipe";
                                break;
                            case FonctionIO.DemandeJack:
                                message = "Demande état jack";
                                break;
                            case FonctionIO.DepartJack:
                                message = "Top départ jack";
                                break;
                            case FonctionIO.ReponseCouleurEquipe:
                                byte valeurCouleurEquipe = trame[2];
                                message = "Retour couleur équipe : " + (valeurCouleurEquipe == 0 ? "rouge" : "jaune");
                                break;
                            case FonctionIO.ReponseJack:
                                byte valeurEtatJack = trame[2];
                                message = "Retour jack : " + (valeurEtatJack == 0 ? "débranché" : "branché");
                                break;
                            case FonctionIO.Alimentation:
                                byte valeurAlimentation = trame[2];
                                message = "Envoi alimentation : " + (valeurAlimentation > 0 ? "On" : "Off");
                                break;
                            case FonctionIO.AlimentationCamera:
                                byte valeurAlimentationCamera = trame[2];
                                message = "Envoi alimentation camera : " + (valeurAlimentationCamera > 0 ? "On" : "Off");
                                break;
                            case FonctionIO.RetourTestConnexion:
                                double tension1 = (double)(trame[2] * 256 + trame[3]) / 100.0;
                                double tension2 = (double)(trame[4] * 256 + trame[5]) / 100.0;
                                message = "Test connexion tension = " + tension1 + "V / " + tension2 + "V";
                                break;
                            case FonctionIO.TestConnexion:
                                message = "Test connexion";
                                break;
                            case FonctionIO.CommandeServo:
                                switch ((FonctionServo)trame[2])
                                {
                                    case FonctionServo.DemandeBaudrate:
                                        message = "Demande baudrate servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeComplianceParams:
                                        message = "Demande compliance servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeConfigAlarmeLED:
                                        message = "Demande config alarme LED servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeConfigAlarmeShutdown:
                                        message = "Demande config alarme shutdown servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeConfigEcho:
                                        message = "Demande config echo servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeCoupleActive:
                                        message = "Demande couple actif servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeCoupleMaximum:
                                        message = "Demande couple max servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeId:
                                        message = "Demande ID servo";
                                        break;
                                    case FonctionServo.DemandeLed:
                                        message = "Demande état LED servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeMouvement:
                                        message = "Demande mouvelement servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeNumeroModele:
                                        message = "Demande numéro modèle servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandePositionActuelle:
                                        message = "Demand eposition actuelle servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandePositionCible:
                                        message = "Demande position cible servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandePositionMaximum:
                                        message = "Demande position maximum servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandePositionMinimum:
                                        message = "Demande position minimum servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeTemperature:
                                        message = "Demande température servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeTension:
                                        message = "Demande tension servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeVersionFirmware:
                                        message = "Demande version firmware servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeVitesseActuelle:
                                        message = "Demande vitesse actuelle servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.DemandeVitesseMax:
                                        message = "Demande vitesse max servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.EnvoiBaudrate:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " baudrate " + ((ServoBaudrate)trame[4]).ToString();
                                        break;
                                    case FonctionServo.EnvoiComplianceParams:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " compliance CCWSlope=" + trame[4] + " CCWMargin=" + trame[5] + " CWSlope=" + trame[6] + " CWMargin=" + trame[7];
                                        break;
                                    case FonctionServo.EnvoiConfigAlarmeLED:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme LED : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
                                        break;
                                    case FonctionServo.EnvoiConfigAlarmeShutdown:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme shutdown : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
                                        break;
                                    case FonctionServo.EnvoiConfigEcho:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config echo  à " + trame[4];
                                        break;
                                    case FonctionServo.EnvoiCoupleActive:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple " + (trame[4] > 0 ? "Activé" : "Désactivé");
                                        break;
                                    case FonctionServo.EnvoiCoupleMaximum:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple maximum " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.EnvoiId:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " ID " + trame[4];
                                        break;
                                    case FonctionServo.EnvoiLed:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " LED " + (trame[4] > 0 ? "On" : "Off"); ;
                                        break;
                                    case FonctionServo.EnvoiPositionCible:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position " + GoBot.Actions.Nommeur.Nommer(trame[4] * 256 + trame[5], (ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.EnvoiPositionMaximum:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position maximum " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.EnvoiPositionMinimum:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position minimum " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.EnvoiVitesseMax:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " vitesse max " + (trame[4] * 256 + trame[5]) + " (" + ((double)(trame[4] * 256 + trame[5]) * 0.111) + "rpm)";
                                        break;
                                    case FonctionServo.Reset:
                                        message = "Envoi servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " reset";
                                        break;
                                    case FonctionServo.RetourBaudrate:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " baudrate = " + ((ServoBaudrate)(trame[4])).ToString();
                                        break;
                                    case FonctionServo.RetourComplianceParams:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " compliance : CCWSlope=" + trame[4] + " CCWMargin=" + trame[5] + " CWSlope=" + trame[6] + " CWMargin=" + trame[7];
                                        break;
                                    case FonctionServo.RetourConfigAlarmeLED:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme LED : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
                                        break;
                                    case FonctionServo.RetourConfigAlarmeShutdown:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config alarme shutdown : Input Voltage=" + trame[4] + " Angle limit=" + trame[5] + " Overheating=" + trame[6] + " Range=" + trame[7] + " Checksum=" + trame[8] + " Overload=" + trame[9] + " Instruction=" + trame[10];
                                        break;
                                    case FonctionServo.RetourConfigEcho:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " config echo = " + trame[4];
                                        break;
                                    case FonctionServo.RetourCoupleActive:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple = " + (trame[4] > 0 ? "On" : "Off");
                                        break;
                                    case FonctionServo.RetourCoupleMaximum:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " couple maximum = " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourId:
                                        message = "Retour servo ID = " + trame[3];
                                        break;
                                    case FonctionServo.RetourLed:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " LED " + (trame[4] > 0 ? "On" : "Off");
                                        break;
                                    case FonctionServo.RetourMouvement:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " mouvement : " + (trame[4] > 0 ? "En cours" : "Terminé");
                                        break;
                                    case FonctionServo.RetourNumeroModele:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " numéro modèle : " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourPositionActuelle:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position actuelle : " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourPositionCible:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position cible : " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourPositionMaximum:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position maximum : " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourPositionMinimum:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " position minimum : " + (trame[4] * 256 + trame[5]);
                                        break;
                                    case FonctionServo.RetourTemperature:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " température : " + trame[4] + "°C";
                                        break;
                                    case FonctionServo.RetourTension:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " tension : " + ((double)trame[4] / 10.0) + "V";
                                        break;
                                    case FonctionServo.RetourVersionFirmware:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " version firmware : " + trame[4];
                                        break;
                                    case FonctionServo.RetourVitesseActuelle:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " vitesse actuelle : " + (trame[4] * 256 + trame[5]) + " (" + ((double)(trame[4] * 256 + trame[5]) * 0.111) + "rpm)";
                                        break;
                                    case FonctionServo.RetourVitesseMax:
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " vitesse maximum : " + (trame[4] * 256 + trame[5]) + " (" + ((double)(trame[4] * 256 + trame[5]) * 0.111) + "rpm)";
                                        break;
                                    case FonctionServo.DemandeErreurs:
                                        message = "Demande erreurs servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]);
                                        break;
                                    case FonctionServo.RetourErreurs:
                                        String listeErreurs = "";
                                        message = "Retour servo " + GoBot.Actions.Nommeur.Nommer((ServomoteurID)trame[3]) + " erreurs : ";
                                        if (trame[4] > 0)
                                            listeErreurs += "AngleLimit, ";
                                        if (trame[5] > 0)
                                            listeErreurs += "Checksum, ";
                                        if (trame[6] > 0)
                                            listeErreurs += "InputVoltage, ";
                                        if (trame[7] > 0)
                                            listeErreurs += "Instruction, ";
                                        if (trame[8] > 0)
                                            listeErreurs += "Overheating, ";
                                        if (trame[9] > 0)
                                            listeErreurs += "Overload, ";
                                        if (trame[10] > 0)
                                            listeErreurs += "Range, ";

                                        if (listeErreurs.Length == 0)
                                            message += "Aucune";
                                        else
                                            message += listeErreurs.Substring(0, listeErreurs.Length - 2);
                                        break;
                                }
                                break;
                        }
                        break;

                    case (byte)Carte.RecMove:
                        switch ((FonctionMove)trame[1])
                        {
                            case FonctionMove.Debug:
                                message = "Debug " + (int)trame[2];
                                break;
                            case FonctionMove.AccelerationLigne:
                                int valeurAccelLigne = trame[2] * 256 + trame[3];
                                message = "Envoi accélération ligne : " + valeurAccelLigne;
                                break;
                            case FonctionMove.AccelerationPivot:
                                int valeurAccelPivot = trame[2] * 256 + trame[3];
                                message = "Envoi accélération pivot : " + valeurAccelPivot;
                                break;
                            case FonctionMove.Blocage:
                                message = "Blocage détécté";
                                break;
                            case FonctionMove.CoeffAsservPID:
                                int valeurP = trame[2] * 256 + trame[3];
                                int valeurI = trame[4] * 256 + trame[5];
                                int valeurD = trame[6] * 256 + trame[7];
                                message = "Envoi PID : P=" + valeurP + " I=" + valeurI + " D=" + valeurD;
                                break;
                            case FonctionMove.DemandePositionsCodeurs:
                                message = "Demande position codeurs";
                                break;
                            case FonctionMove.DemandePositionXYTeta:
                                message = "Demande position X Y Teta";
                                break;
                            case FonctionMove.Deplace:
                                byte valeurAvance = trame[2];
                                int valeurDistanceAvance = trame[3] * 256 + trame[4];
                                message = (valeurAvance == (byte)SensAR.Avant ? "Avance" : "Recule") + " de " + valeurDistanceAvance + "mm";
                                break;
                            case FonctionMove.EnvoiConsigneBrute:
                                byte valeurConsigneBrute = trame[2];
                                int valeurDistanceConsigneBrute = trame[3] * 256 + trame[4];
                                message = (valeurConsigneBrute == (byte)SensAR.Avant ? "Avance" : "Recule") + " brut de " + valeurDistanceConsigneBrute + " pas codeurs";
                                break;
                            case FonctionMove.EnvoiPositionAbsolue:
                                int valeurPositionAbsolueX = trame[2] * 256 + trame[3];
                                int valeurPositionABsolueY = trame[4] * 256 + trame[5];
                                double valeurPositionAbsolueTeta = (double)(trame[6] * 256 + trame[7]) / 100.0;
                                message = "Envoi position absolue X=" + valeurPositionAbsolueX + "mm Y=" + valeurPositionABsolueY + "mm Teta=" + valeurPositionAbsolueTeta + "°";
                                break;
                            case FonctionMove.FinDeplacement:
                                message = "Fin du déplacement";
                                break;
                            case FonctionMove.FinRecallage:
                                message = "Fin du recallage";
                                break;
                            case FonctionMove.Pivot:
                                byte valeurSensPivot = trame[2];
                                double valeurDistancePivot = (double)(trame[3] * 256 + trame[4]) / 100.0;
                                message = "Pivot " + (valeurSensPivot == (char)SensGD.Droite ? "droite" : "gauche") + " de " + valeurDistancePivot + "°";
                                break;
                            case FonctionMove.Recallage:
                                byte valeurSensRecallage = trame[2];
                                message = "Recallage " + (valeurSensRecallage == (char)SensAR.Avant ? "avant" : "arrière");
                                break;
                            case FonctionMove.Reset:
                                message = "Envoi reset";
                                break;
                            case FonctionMove.RetourPositionCodeurs:
                                byte valeurPositionsCodeursNombre = trame[2];
                                message = "Retour positions codeurs : " + valeurPositionsCodeursNombre + " valeurs";
                                break;
                            case FonctionMove.RetourPositionXYTeta:
                                double valeurPositionX = (double)(trame[2] * 256 + trame[3]) / 10.0;
                                double valeurPositionY = (double)(trame[4] * 256 + trame[5]) / 10.0;
                                double valeurPositionTeta = (double)(trame[6] * 256 + trame[7]) / 100.0;
                                message = "Retour position X Y Teta : X=" + valeurPositionX + "mm Y=" + valeurPositionY + "mm Teta=" + valeurPositionTeta + "°";
                                break;
                            case FonctionMove.Stop:
                                String stopMode = ((StopMode)trame[2]).ToString();
                                message = "Envoi stop " + stopMode;
                                break;
                            case FonctionMove.TestConnexion:
                                message = "Test connexion";
                                break;
                            case FonctionMove.Virage:
                                SensAR valeurVirageSensAR = ((SensAR)trame[2]);
                                SensGD valeurVirageSensGD = ((SensGD)trame[3]);
                                int valeurVirageRayon = trame[4] * 256 + trame[5];
                                double valeurVirageAngle = (double)(trame[6] * 256 + trame[7]) / 100.0;
                                message = "Envoi virage " + valeurVirageSensAR.ToString().ToLower() + " " + valeurVirageSensGD.ToString().ToLower() + " rayon=" + valeurVirageRayon + "mm angle=" + valeurVirageAngle + "°";
                                break;
                            case FonctionMove.VitesseLigne:
                                int valeurVitesseLigne = trame[2] * 256 + trame[3];
                                message = "Envoi vitesse ligne " + valeurVitesseLigne;
                                break;
                            case FonctionMove.VitessePivot:
                                int valeurVitessePivot = trame[2] * 256 + trame[3];
                                message = "Envoi vitesse pivot " + valeurVitessePivot;
                                break;
                            case FonctionMove.DemandeDiagnostic:
                                message = "Demande charge";
                                break;
                            case FonctionMove.RetourDiagnostic:
                                int nbValeurs = trame[2];
                                message = "Retour charge : " + nbValeurs + " valeurs";
                                break;
                            default:
                                return "Inconnu";
                        }
                        break;

                    case (byte)Carte.RecPi:
                        switch ((FonctionPi)trame[1])
                        {
                            case FonctionPi.Debug:
                                message = "Debug " + (int)trame[2];
                                break;
                            case FonctionPi.AccelerationLigne:
                                int valeurAccelLigne = trame[2] * 256 + trame[3];
                                message = "Envoi accélération ligne : " + valeurAccelLigne;
                                break;
                            case FonctionPi.AccelerationPivot:
                                int valeurAccelPivot = trame[2] * 256 + trame[3];
                                message = "Envoi accélération pivot : " + valeurAccelPivot;
                                break;
                            case FonctionPi.Blocage:
                                message = "Blocage détécté";
                                break;
                            case FonctionPi.CoeffAsservPID:
                                int valeurP = trame[2] * 256 + trame[3];
                                int valeurI = trame[4] * 256 + trame[5];
                                int valeurD = trame[6] * 256 + trame[7];
                                message = "Envoi PID : P=" + valeurP + " I=" + valeurI + " D=" + valeurD;
                                break;
                            case FonctionPi.DemandePositionsCodeurs:
                                message = "Demande position codeurs";
                                break;
                            case FonctionPi.DemandePositionXYTeta:
                                message = "Demande position X Y Teta";
                                break;
                            case FonctionPi.Deplace:
                                byte valeurAvance = trame[2];
                                int valeurDistanceAvance = trame[3] * 256 + trame[4];
                                message = (valeurAvance == (byte)SensAR.Avant ? "Avance" : "Recule") + " de " + valeurDistanceAvance + "mm";
                                break;
                            case FonctionPi.EnvoiConsigneBrute:
                                byte valeurConsigneBrute = trame[2];
                                int valeurDistanceConsigneBrute = trame[3] * 256 + trame[4];
                                message = (valeurConsigneBrute == (byte)SensAR.Avant ? "Avance" : "Recule") + " brut de " + valeurDistanceConsigneBrute + " pas codeurs";
                                break;
                            case FonctionPi.EnvoiPositionAbsolue:
                                int valeurPositionAbsolueX = trame[2] * 256 + trame[3];
                                int valeurPositionABsolueY = trame[4] * 256 + trame[5];
                                double valeurPositionAbsolueTeta = (double)(trame[6] * 256 + trame[7]) / 100.0;
                                message = "Envoi position absolue X=" + valeurPositionAbsolueX + "mm Y=" + valeurPositionABsolueY + "mm Teta=" + valeurPositionAbsolueTeta + "°";
                                break;
                            case FonctionPi.FinDeplacement:
                                message = "Fin du déplacement";
                                break;
                            case FonctionPi.FinRecallage:
                                message = "Fin du recallage";
                                break;
                            case FonctionPi.Pivot:
                                byte valeurSensPivot = trame[2];
                                double valeurDistancePivot = (double)(trame[3] * 256 + trame[4]) / 100.0;
                                message = "Pivot " + (valeurSensPivot == (char)SensGD.Droite ? "droite" : "gauche") + " de " + valeurDistancePivot + "°";
                                break;
                            case FonctionPi.Recallage:
                                byte valeurSensRecallage = trame[2];
                                message = "Recallage " + (valeurSensRecallage == (char)SensAR.Avant ? "avant" : "arrière");
                                break;
                            case FonctionPi.Reset:
                                message = "Envoi reset";
                                break;
                            case FonctionPi.RetourPositionCodeurs:
                                byte valeurPositionsCodeursNombre = trame[2];
                                message = "Retour positions codeurs : " + valeurPositionsCodeursNombre + " valeurs";
                                break;
                            case FonctionPi.RetourPositionXYTeta:
                                double valeurPositionX = (double)(trame[2] * 256 + trame[3]) / 10.0;
                                double valeurPositionY = (double)(trame[4] * 256 + trame[5]) / 10.0;
                                double valeurPositionTeta = (double)(trame[6] * 256 + trame[7]) / 100.0;
                                message = "Retour position X Y Teta : X=" + valeurPositionX + "mm Y=" + valeurPositionY + "mm Teta=" + valeurPositionTeta + "°";
                                break;
                            case FonctionPi.Stop:
                                String stopMode = ((StopMode)trame[2]).ToString();
                                message = "Envoi stop " + stopMode;
                                break;
                            case FonctionPi.TestConnexion:
                                message = "Test connexion";
                                break;
                            case FonctionPi.Virage:
                                SensAR valeurVirageSensAR = ((SensAR)trame[2]);
                                SensGD valeurVirageSensGD = ((SensGD)trame[3]);
                                int valeurVirageRayon = trame[4] * 256 + trame[5];
                                double valeurVirageAngle = (double)(trame[6] * 256 + trame[7]) / 100.0;
                                message = "Envoi virage " + valeurVirageSensAR.ToString().ToLower() + " " + valeurVirageSensGD.ToString().ToLower() + " rayon=" + valeurVirageRayon + "mm angle=" + valeurVirageAngle + "°";
                                break;
                            case FonctionPi.VitesseLigne:
                                int valeurVitesseLigne = trame[2] * 256 + trame[3];
                                message = "Envoi vitesse ligne " + valeurVitesseLigne;
                                break;
                            case FonctionPi.VitessePivot:
                                int valeurVitessePivot = trame[2] * 256 + trame[3];
                                message = "Envoi vitesse pivot " + valeurVitessePivot;
                                break;
                            case FonctionPi.DemandeDiagnostic:
                                message = "Demande charge";
                                break;
                            case FonctionPi.RetourDiagnostic:
                                int nbValeurs = trame[2];
                                message = "Retour charge : " + nbValeurs + " valeurs";
                                break;
                            case FonctionPi.TestEmission:
                                message = "Test d'émission n°" + trame[2];
                                break;
                            case FonctionPi.TestEmissionCorrompu:
                                message = "Test d'émission n°" + trame[2] + " corrompu";
                                break;
                            case FonctionPi.TestEmissionPerdu:
                                message = "Test d'émission perdu " + trame[2] + " à " + trame[3];
                                break;
                            case FonctionPi.TestEmissionReussi:
                                message = "Test d'émission n°" + trame[2] + " réussi";
                                break;
                            default:
                                return "Inconnu";
                        }
                        break;
                    case (byte)Carte.RecBeu:
                    case (byte)Carte.RecBoi:
                    case (byte)Carte.RecBun:
                        switch ((FonctionBalise)trame[1])
                        {
                            case FonctionBalise.InclinaisonFace:
                                message = "Inclinaison face " + (int)(trame[2] * 256 + trame[3]);
                                break;
                            case FonctionBalise.InclinaisonProfil:
                                message = "Inclinaison profil " + (int)(trame[2] * 256 + trame[3]);
                                break;
                            case FonctionBalise.Debug:
                                message = "Debug " + (int)trame[2];
                                break;
                            case FonctionBalise.Detection:
                                int valeurDetectionNombreTicksTour = trame[2] * 256 + trame[3];
                                byte valeurDetectionNombre1 = trame[4];
                                byte valeurDetectionNombre2 = trame[5];
                                message = "Tour balise : " + valeurDetectionNombreTicksTour + " ticks " + valeurDetectionNombre1 + " angles / " + valeurDetectionNombre2 + " angles";
                                break;
                            case FonctionBalise.Reset:
                                message = "Envoi reset";
                                break;
                            case FonctionBalise.RetourTestConnexion:
                                double tension1 = (double)(trame[2] * 256 + trame[3]) / 100.0;
                                double tension2 = (double)(trame[4] * 256 + trame[5]) / 100.0;
                                message = "Test connexion tension = " + tension1 + "V / " + tension2 + "V";
                                break;
                            case FonctionBalise.TestConnexion:
                                message = "Test connexion";
                                break;
                            case FonctionBalise.Vitesse:
                                int vitesse = trame[2] * 256 + trame[3];
                                message = "Envoi vitesse pwm " + vitesse;
                                break;
                            case FonctionBalise.TestEmission:
                                message = "Test d'émission n°" + trame[2];
                                break;
                            case FonctionBalise.TestEmissionCorrompu:
                                message = "Test d'émission n°" + trame[2] + " corrompu";
                                break;
                            case FonctionBalise.TestEmissionPerdu:
                                message = "Test d'émission perdu " + trame[2] + " à " + trame[3];
                                break;
                            case FonctionBalise.TestEmissionReussi:
                                message = "Test d'émission n°" + trame[2] + " réussi";
                                break;
                        }
                        break;
                    case (byte)Carte.RecMiwi:
                        switch ((FonctionMiwi)trame[1])
                        {
                            case FonctionMiwi.Debug:
                                message = "Debug " + (int)trame[2];
                                break;
                            case FonctionMiwi.Transmettre:
                                byte[] octets = trame.ToTabBytes();
                                byte[] octetsExtrait = new byte[octets.Length - 1];
                                for (int i = 2; i < octets.Length; i++)
                                    octetsExtrait[i - 2] = octets[i];

                                Trame trameInterne = new Trame(octetsExtrait);
                                message = Decode(trameInterne);
                                break;
                            case FonctionMiwi.TestConnexion:
                                message = "Test connexion";
                                break;
                            case FonctionMiwi.RetourTestConnexion:
                                message = "Retour test connexion";
                                break;
                        }
                        break;
                    default:
                        message = "Inconnu";
                        break;
                }
            }
            catch (Exception)
            {
                message = "Inconnu";
            }

            return message;
        }
    }
}
