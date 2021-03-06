﻿using System;
using System.Reflection;
using GoBot.Actionneurs;
using GoBot.Communications;
using GoBot.Communications.UDP;

namespace GoBot
{
    static class NameFinder
    {
        /// <summary>
        /// Nomme à partir d'un type inconnu en recherchant la meilleure surcharge
        /// </summary>
        /// <param name="o">Objet à nommer</param>
        /// <returns>Nom de l'objet si trouvé, sinon chaine vide</returns>
        public static String GetNameUnknow(object o)
        {
            return GetName(ToRealType(o));
        }

        private static dynamic ToRealType(Object o)
        {
            Type type = o.GetType();
            dynamic pp = Convert.ChangeType(o, type);
            return pp;
        }

        /// <summary>
        /// Nommage d'un objet pour lequel on n'a à priori pas de surcharge adaptée, donc retourne une chaine vide
        /// Fonction privée car aucun intêret de l'appeler depuis l'exterieur
        /// </summary>
        /// <param name="o">Objet à nommer qui n'a pas trouvé de surcharge</param>
        /// <returns>Chaine vide</returns>
        private static String GetName(object o)
        {
            return "";
        }

        /// <summary>
        /// Retourne le nom usuel du servomoteur
        /// </summary>
        /// <param name="servo">Servomoteur recherché</param>
        /// <returns>Nom usuel</returns>
        public static String GetName(ServomoteurID servo)
        {
            switch (servo)
            {
                case ServomoteurID.Clamp1:
                    return "crochet gauche";
                case ServomoteurID.Clamp2:
                    return "crochet milieu gauche";
                case ServomoteurID.Clamp3:
                    return "crochet milieu";
                case ServomoteurID.Clamp4:
                    return "crochet milieu droite";
                case ServomoteurID.Clamp5:
                    return "crochet droite";
                case ServomoteurID.FingerLeft:
                    return "doigt gauche";
                case ServomoteurID.FingerRight:
                    return "doigt droite";
                case ServomoteurID.FlagLeft:
                    return "drapeau gauche";
                case ServomoteurID.FlagRight:
                    return "drapeau droite";
                case ServomoteurID.GrabberLeft:
                    return "rabatteur gauche";
                case ServomoteurID.GrabberRight:
                    return "rabatteur droite";
                case ServomoteurID.Lifter:
                    return "monteur crochets";
                case ServomoteurID.LockerLeft:
                    return "verrouilleur gauche";
                case ServomoteurID.LockerRight:
                    return "verrouilleur droite";
                case ServomoteurID.PushArmLeft:
                    return "bras sortie gauche";
                case ServomoteurID.PushArmRight:
                    return "bras sortie droite";
                case ServomoteurID.Tilter:
                    return "rotationneur crochets";
                default:
                        return servo.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom de la position en fonction du servomoteur (Ouvert, fermé, etc...)
        /// </summary>
        /// <param name="position">Position du servomoteur</param>
        /// <param name="servo">Servomoteur</param>
        /// <returns>Nom de la position</returns>
        public static String GetName(int position, ServomoteurID servo)
        {
            PropertyInfo[] properties = typeof(Config).GetProperties();
            foreach (PropertyInfo p in properties)
            {
                if (p.PropertyType.IsSubclassOf(typeof(PositionableServo)))
                {
                    PositionableServo positionnableServo = (PositionableServo)(p.GetValue(Config.CurrentConfig, null));

                    if (positionnableServo.ID == servo)
                    {
                        PropertyInfo[] proprietesServo = positionnableServo.GetType().GetProperties();
                        foreach (PropertyInfo ps in proprietesServo)
                        {
                            if (ps.Name.StartsWith("Position") && ((int)(ps.GetValue(positionnableServo, null)) == position))
                                return Config.PropertyNameToScreen(ps) + " (" + position + ")";
                        }
                    }
                }
            }
                    
            return position.ToString();
        }

        /// <summary>
        /// Retourne le nom de la position en fonction du moteur (Haut, Bas, etc...)
        /// </summary>
        /// <param name="position">Position du moteur</param>
        /// <param name="moteur">Moteur</param>
        /// <returns>Nom de la position</returns>
        public static String GetName(int position, MotorID moteur)
        {
            PropertyInfo[] properties = typeof(Config).GetProperties();
            foreach (PropertyInfo p in properties)
            {
                if (p.PropertyType.IsSubclassOf(typeof(PositionableMotorPosition)))
                {
                    PositionableMotorPosition positionnableMoteur = (PositionableMotorPosition)(p.GetValue(Config.CurrentConfig, null));

                    if (positionnableMoteur.ID == moteur)
                    {
                        PropertyInfo[] proprietesMoteur = positionnableMoteur.GetType().GetProperties();
                        foreach (PropertyInfo ps in proprietesMoteur)
                        {
                            if (ps.Name.StartsWith("Position") && ((int)(ps.GetValue(positionnableMoteur, null)) == position))
                                return Config.PropertyNameToScreen(ps) + " (" + position + ")";
                        }
                    }
                }
            }

            return position.ToString();
        }

        /// <summary>
        /// Retourne le nom usuel d'un capteur on off
        /// </summary>
        /// <param name="sensor">Capteur on off à nommer</param>
        /// <returns>Nom du capteur on off</returns>
        public static String GetName(SensorOnOffID sensor)
        {
            switch (sensor)
            {
                case SensorOnOffID.StartTrigger:
                    return "jack";
                case SensorOnOffID.PressureSensorLeftBack:
                    return "pression arrière gauche";
                case SensorOnOffID.PressureSensorLeftFront:
                    return "pression avant gauche";
                case SensorOnOffID.PressureSensorRightBack:
                    return "pression arrière droit";
                case SensorOnOffID.PressureSensorRightFront:
                    return "pression avant droit";
                default:
                    return sensor.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un codeur
        /// </summary>
        /// <param name="capteur">Codeur à nommer</param>
        /// <returns>Nom du codeur</returns>
        public static String GetName(CodeurID encoder)
        {
            switch (encoder)
            {
                case CodeurID.Manuel:
                    return "manuel";
                default:
                    return encoder.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un bolléen On/Off
        /// </summary>
        /// <param name="capteur">Valeur à nommer</param>
        /// <returns>"On" ou "Off"</returns>
        public static String GetName(bool val)
        {
            return val ? "On" : "Off";
        }

        /// <summary>
        /// Retourne le nom usuel d'un moteur
        /// </summary>
        /// <param name="capteur">Moteur à nommer</param>
        /// <returns>Nom du Moteur</returns>
        public static String GetName(MotorID motor)
        {
            switch (motor)
            {
                case MotorID.ElevatorLeft:
                    return "ascenseur gauche";
                case MotorID.ElevatorRight:
                    return "ascenseur droite";
                case MotorID.AvailableOnRecIO2:
                    return "RecIO 2";
                case MotorID.AvailableOnRecIO3:
                    return "RecIO 3";
                case MotorID.AvailableOnRecMove11:
                    return "RecMove 1";
                case MotorID.AvailableOnRecMove12:
                    return "RecMove 2";
                default:
                    return motor.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un actionneur On/Off
        /// </summary>
        /// <param name="capteur">Actionneur à nommer</param>
        /// <returns>Nom de l'actionneur</returns>
        public static String GetName(ActuatorOnOffID actuator)
        {
            switch (actuator)
            {
                case ActuatorOnOffID.PowerSensorColorBuoyRight:
                    return "alimentation capteur couleur bouée droite";
                case ActuatorOnOffID.PowerSensorColorBuoyLeft:
                    return "alimentation capteur couleur bouée gauche";
                case ActuatorOnOffID.MakeVacuumLeftBack:
                    return "aspiration arrière gauche";
                case ActuatorOnOffID.MakeVacuumRightBack:
                    return "aspiration arrière droite";
                case ActuatorOnOffID.MakeVacuumLeftFront:
                    return "aspiration avant gauche";
                case ActuatorOnOffID.MakeVacuumRightFront:
                    return "aspiration avant droite";
                case ActuatorOnOffID.OpenVacuumLeftBack:
                    return "electrovanne arrière gauche";
                case ActuatorOnOffID.OpenVacuumRightBack:
                    return "electrovanne arrière droite";
                case ActuatorOnOffID.OpenVacuumLeftFront:
                    return "electrovanne avant gauche";
                case ActuatorOnOffID.OpenVacuumRightFront:
                    return "electrovanne avant droite";
                default:
                    return actuator.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un capteur couleur
        /// </summary>
        /// <param name="sensor">Capteur couleur à nommer</param>
        /// <returns>Nom du capteur couleur</returns>
        public static String GetName(SensorColorID sensor)
        {
            switch (sensor)
            {
                case SensorColorID.BuoyRight:
                    return "bouée droite";
                case SensorColorID.BuoyLeft:
                    return "bouée gauche";
                default:
                    return sensor.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'une balise
        /// </summary>
        /// <param name="capteur">Balise à nommer</param>
        /// <returns>Nom de la balise</returns>
        public static String GetName(BaliseID balise)
        {
            switch (balise)
            {
                case BaliseID.Principale:
                    return "principale";
                default:
                    return balise.ToString();
            }
        }

        /// <summary>
        /// Retourne le nom usuel d'un Lidar
        /// </summary>
        /// <param name="capteur">Lidar à nommer</param>
        /// <returns>Nom du Lidar</returns>
        public static String GetName(LidarID lidar)
        {
            switch (lidar)
            {
                case LidarID.Ground:
                    return "scan sol";
                case LidarID.Avoid:
                    return "évitement";
                default:
                    return lidar.ToString();
            }
        }

        /// <summary>
        /// Retourne le template de décodage d'une fonction dans le protocole de communication UDP
        /// </summary>
        /// <param name="capteur">Fonction à décoder</param>
        /// <returns>Template de décodage</returns>
        public static String GetName(UdpFrameFunction frame)
        {
            return UdpFrameDecoder.GetMessage(frame);
        }
    }
}
