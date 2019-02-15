using System;
using System.Collections.Generic;

namespace GoBot.Communications.CAN
{
    static class CanFrameDecoder
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
        public static String GetMessage(CanFrameFunction function, List<uint> parameters = null)
        {
            String output = "";

            switch (function)
            {
                case CanFrameFunction.PositionAsk:
                    output = "Demande de position servo {ServoID}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                    }
                    break;
                case CanFrameFunction.PositionResponse:
                    output = "Retour de position servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.PositionSet:
                    output = "Envoi de position servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.PositionMinAsk:
                    output = "Demande de position min servo {ServoID}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                    }
                    break;
                case CanFrameFunction.PositionMinResponse:
                    output = "Retour de position min servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.PositionMinSet:
                    output = "Envoi de position min servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.PositionMaxAsk:
                    output = "Demande de position max servo {ServoID}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                    }
                    break;
                case CanFrameFunction.PositionMaxResponse:
                    output = "Retour de position max servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.PositionMaxSet:
                    output = "Envoi de position max servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.SpeedAsk:
                    output = "Demande de vitesse servo {ServoID}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                    }
                    break;
                case CanFrameFunction.SpeedResponse:
                    output = "Retour de vitesse servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.SpeedSet:
                    output = "Envoi de vitesse servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.TorqueMaxAsk:
                    output = "Demande de couple max servo {ServoID}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                    }
                    break;
                case CanFrameFunction.TorqueMaxResponse:
                    output = "Retour de couple max servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.TorqueMaxSet:
                    output = "Envoi de couple max servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.TorqueCurrentAsk:
                    output = "Demande de couple actuel servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.TorqueCurrentResponse:
                    output = "Retour de couple actuel servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.AccelerationAsk:
                    output = "Demande de l'acceleration servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.AccelerationResponse:
                    output = "Retour de l'acceleration servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.AccelerationSet:
                    output = "Envoi de l'acceleration servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.TargetSet:
                    output = "Déplacement servo {ServoID} : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.TrajectorySet:
                    output = "Déplacement servo {ServoID} : Pos = {4-5}; Vit = {6-7}; Accel = {8-9}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, ((ServomoteurID)parameters[0]).ToString());
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.SetScore:
                    output = "Affichage de score : {4-5}";
                    if (parameters != null)
                    {
                        output = ReplaceParam(output, parameters[1].ToString());
                    }
                    break;
                case CanFrameFunction.Debug:
                    output = "Debug";
                    break;
                case CanFrameFunction.DebugAsk:
                    output = "Demande valeur debug";
                    break;
                case CanFrameFunction.DebugResponse:
                    output = "Retour valeur debug";
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
        /// <param name="frame">Trame à décoder</param>
        /// <returns>Message sur le contnu de la trame</returns>
        public static String GetMessage(Frame frame)
        {
            String output = "";

            output = GetMessage(CanFrameFactory.ExtractFunction(frame));
            output = GetMessage(CanFrameFactory.ExtractFunction(frame), GetParameters(output, frame));

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

            if (format.Contains("{ServoID}"))
            {
                parameters.Add((uint)CanFrameFactory.ExtractServoGlobalId(frame));
                format = format.Replace("{ServoID}", "");
            }

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
                        parameters[parameters.Count - 1] = parameters[parameters.Count - 1] * 256 + frame[int.Parse(subParameter)];
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
