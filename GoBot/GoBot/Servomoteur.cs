using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Communications;
using System.Threading;

namespace GoBot
{
    public class Servomoteur
    {
        private Carte carte;
        private ConnexionUDP connexionUdp;

        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                connexionUdp.SendMessage(TrameFactory.ServoEnvoiId((ServomoteurID)id, (char)value));
            }
        }
        private double baudrate;
        public double Baudrate
        {
            get { return baudrate; }
            set
            {
                // TODO
                baudrate = value;
                connexionUdp.SendMessage(TrameFactory.ServoEnvoiBaudrate((ServomoteurID)id, TrameFactory.ServoBaudrate.b19200));
            }
        }
        private void EnvoiCompliance()
        {
            connexionUdp.SendMessage(TrameFactory.ServoEnvoiComplianceParams((ServomoteurID)id, ccwSlope, ccwMargin, cwMargin, cwSlope));
        }
        private byte ccwSlope;
        public byte CCWSlope
        {
            get { return ccwSlope; }
            set
            {
                ccwSlope = value;
                EnvoiCompliance();
            }
        }
        private byte cwSlope;
        public byte CWSlope
        {
            get { return cwSlope; }
            set
            {
                cwSlope = value;
                EnvoiCompliance();
            }
        }
        private byte ccwMargin;
        public byte CCWMargin
        {
            get { return ccwMargin; }
            set
            {
                ccwMargin = value;
                EnvoiCompliance();
            }
        }
        private byte cwMargin;
        public byte CWMargin
        {
            get { return cwMargin; }
            set
            {
                cwMargin = value;
                EnvoiCompliance();
            }
        }
        private void EnvoiParamLED()
        {
            connexionUdp.SendMessage(TrameFactory.ServoEnvoiConfigAlarmeLED((ServomoteurID)id, alarmeLEDInputVoltage, alarmeLEDAngleLimit, alarmeLEDOverheating, alarmeLEDRange, alarmeLEDChecksum, alarmeLEDOverload, alarmeLEDInstruction));
        }
        private bool alarmeLEDInputVoltage;
        public bool AlarmeLEDInputVoltage
        {
            get { return alarmeLEDInputVoltage; }
            set
            {
                alarmeLEDInputVoltage = value;
                EnvoiParamLED();
            }
        }
        private bool alarmeLEDAngleLimit;
        public bool AlarmeLEDAngleLimit
        {
            get { return alarmeLEDAngleLimit; }
            set
            {
                alarmeLEDAngleLimit = value;
                EnvoiParamLED();
            }
        }
        private bool alarmeLEDOverheating;
        public bool AlarmeLEDOverheating
        {
            get { return alarmeLEDOverheating; }
            set
            {
                alarmeLEDOverheating = value;
                EnvoiParamLED();
            }
        }
        private bool alarmeLEDRange;
        public bool AlarmeLEDRange
        {
            get { return alarmeLEDRange; }
            set
            {
                alarmeLEDRange = value;
                EnvoiParamLED();
            }
        }
        private bool alarmeLEDChecksum;
        public bool AlarmeLEDChecksum
        {
            get { return alarmeLEDChecksum; }
            set
            {
                alarmeLEDChecksum = value;
                EnvoiParamLED();
            }
        }
        private bool alarmeLEDOverload;
        public bool AlarmeLEDOverload
        {
            get { return alarmeLEDOverload; }
            set
            {
                alarmeLEDOverload = value;
                EnvoiParamLED();
            }
        }
        private bool alarmeLEDInstruction;
        public bool AlarmeLEDInstruction
        {
            get { return alarmeLEDInstruction; }
            set
            {
                alarmeLEDInstruction = value;
                EnvoiParamLED();
            }
        }

        private void EnvoiParamShutdown()
        {
            connexionUdp.SendMessage(TrameFactory.ServoEnvoiConfigAlarmeShutdown((ServomoteurID)id, alarmeShutdownInputVoltage, alarmeShutdownAngleLimit, alarmeShutdownOverheating, alarmeShutdownRange, alarmeShutdownChecksum, alarmeShutdownOverload, alarmeShutdownInstruction));
        }
        private bool alarmeShutdownInputVoltage;
        public bool AlarmeShutdownInputVoltage
        {
            get { return alarmeShutdownInputVoltage; }
            set
            {
                alarmeShutdownInputVoltage = value;
                EnvoiParamShutdown();
            }
        }
        private bool alarmeShutdownAngleLimit;
        public bool AlarmeShutdownAngleLimit
        {
            get { return alarmeShutdownAngleLimit; }
            set
            {
                alarmeShutdownAngleLimit = value;
                EnvoiParamShutdown();
            }
        }
        private bool alarmeShutdownOverheating;
        public bool AlarmeShutdownOverheating
        {
            get { return alarmeShutdownOverheating; }
            set
            {
                alarmeShutdownOverheating = value;
                EnvoiParamShutdown();
            }
        }
        private bool alarmeShutdownRange;
        public bool AlarmeShutdownRange
        {
            get { return alarmeShutdownRange; }
            set
            {
                alarmeShutdownRange = value;
                EnvoiParamShutdown();
            }
        }
        private bool alarmeShutdownChecksum;
        public bool AlarmeShutdownChecksum
        {
            get { return alarmeShutdownChecksum; }
            set
            {
                alarmeShutdownChecksum = value;
                EnvoiParamShutdown();
            }
        }
        private bool alarmeShutdownOverload;
        public bool AlarmeShutdownOverload
        {
            get { return alarmeShutdownOverload; }
            set
            {
                alarmeShutdownOverload = value;
                EnvoiParamShutdown();
            }
        }
        private bool alarmeShutdownInstruction;
        public bool AlarmeShutdownInstruction
        {
            get { return alarmeShutdownInstruction; }
            set
            {
                alarmeShutdownInstruction = value;
                EnvoiParamShutdown();
            }
        }

        private bool coupleActive;
        public bool CoupleActive
        {
            get { return coupleActive; }
            set
            {
                coupleActive = value;
                connexionUdp.SendMessage(TrameFactory.ServoEnvoiCoupleActive((ServomoteurID)id, coupleActive));
            }
        }
        private int coupleMaximum;
        public int CoupleMaximum
        {
            get { return coupleMaximum; }
            set
            {
                coupleMaximum = value;
                connexionUdp.SendMessage(TrameFactory.ServoEnvoiCoupleMaximum((ServomoteurID)id, coupleMaximum));
            }
        }
        private bool ledAllumee;
        public bool LedAllumee
        {
            get { return ledAllumee; }
            set
            {
                ledAllumee = value;
                connexionUdp.SendMessage(TrameFactory.ServoEnvoiLed((ServomoteurID)id, ledAllumee));
            }
        }
        private bool enMouvement;
        public bool EnMouvement
        {
            get { return enMouvement; }
        }
        private int modele;
        public int Modele
        {
            get { return modele; }
        }
        private int firmware;
        public int Firmware
        {
            get { return firmware; }
        }
        private int positionActuelle;
        public int PositionActuelle
        {
            get { return positionActuelle; }
        }
        private int vitesseActuelle;
        public int VitesseActuelle
        {
            get { return vitesseActuelle; }
        }
        private int positionCible;
        public int PositionCible
        {
            get { return positionCible; }
            set
            {
                positionCible = value;
                connexionUdp.SendMessage(TrameFactory.ServoEnvoiPositionCible((ServomoteurID)id, positionCible));
            }
        }
        private int positionMin;
        public int PositionMin
        {
            get { return positionMin; }
            set
            {
                positionMin = value;
                connexionUdp.SendMessage(TrameFactory.ServoEnvoiPositionMinimum((ServomoteurID)id, positionMin));
            }
        }
        private int positionMax;
        public int PositionMax
        {
            get { return positionMax; }
            set
            {
                positionMax = value;
                connexionUdp.SendMessage(TrameFactory.ServoEnvoiPositionMaximum((ServomoteurID)id, positionMax));
            }
        }
        private int temperature;
        public int Temperature
        {
            get { return temperature; }
        }
        private double tension;
        public double Tension
        {
            get { return tension; }
        }
        private int vitesseMax;
        public int VitesseMax
        {
            get { return vitesseMax; }
            set
            {
                vitesseMax = value;
                connexionUdp.SendMessage(TrameFactory.ServoEnvoiVitesseMax((ServomoteurID)id, vitesseMax));
            }
        }

        public bool ErreurInputVoltage { get; private set; }
        public bool ErreurAngleLimit { get; private set; }
        public bool ErreurOverheating { get; private set; }
        public bool ErreurRange { get; private set; }
        public bool ErreurChecksum { get; private set; }
        public bool ErreurOverload { get; private set; }
        public bool ErreurInstruction { get; private set; }

        public Servomoteur(Carte carte, int id, int baudrate)
        {
            this.carte = carte;
            this.id = id;
            this.baudrate = baudrate;

            switch (carte)
            {
                case (Carte.RecMove):
                    connexionUdp = Connexions.ConnexionMove;
                    break;
            }

            connexionUdp.NouvelleTrameRecue += new ConnexionUDP.ReceptionDelegate(connexion_NouvelleTrame);
        }

        public void DemandeActualisation(bool complete)
        {
            if (complete)
            {
                connexionUdp.SendMessage(TrameFactory.ServoDemandeBaudrate((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeComplianceParams((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeConfigAlarmeLED((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeConfigAlarmeShutdown((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeConfigEcho((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeCoupleActive((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeCoupleMaximum((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeLed((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeMouvement((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeNumeroModele((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandePositionCible((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandePositionMaximum((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandePositionMinimum((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeTemperature((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeVersionFirmware((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeVitesseMax((ServomoteurID)id));
                Thread.Sleep(10);
                connexionUdp.SendMessage(TrameFactory.ServoDemandeTension((ServomoteurID)id));
                Thread.Sleep(30);
            }

            connexionUdp.SendMessage(TrameFactory.ServoDemandePositionActuelle((ServomoteurID)id));
            Thread.Sleep(10);
            connexionUdp.SendMessage(TrameFactory.ServoDemandeErreurs((ServomoteurID)id));
            Thread.Sleep(10);
            connexionUdp.SendMessage(TrameFactory.ServoDemandeVitesseActuelle((ServomoteurID)id));
            Thread.Sleep(10);
        }

        void connexion_NouvelleTrame(Trame trame)
        {
            // Test trame de type configuration servomoteur
            if (trame[1] == (byte)TrameFactory.FonctionMove.CommandeServo)
            {
                // Test trame pour ce servo
                if (trame[3] == id)
                {
                    // Switch sur la fonction
                    switch (trame[2])
                    {
                        case (byte)TrameFactory.FonctionServo.RetourBaudrate:
                            baudrate = ValueToBaudrate(trame[4]);
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourComplianceParams:
                            ccwSlope = trame[4];
                            ccwMargin = trame[5];
                            cwSlope = trame[6];
                            cwMargin = trame[7];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourConfigAlarmeLED:
                            alarmeLEDInputVoltage = (trame[4] == 1 ? true : false);
                            alarmeLEDAngleLimit = (trame[5] == 1 ? true : false);
                            alarmeLEDOverheating = (trame[6] == 1 ? true : false);
                            alarmeLEDRange = (trame[7] == 1 ? true : false);
                            alarmeLEDChecksum = (trame[8] == 1 ? true : false);
                            alarmeLEDOverload = (trame[9] == 1 ? true : false);
                            alarmeLEDInstruction = (trame[10] == 1 ? true : false);
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourConfigAlarmeShutdown:
                            alarmeShutdownInputVoltage = (trame[4] == 1 ? true : false);
                            alarmeShutdownAngleLimit = (trame[5] == 1 ? true : false);
                            alarmeShutdownOverheating = (trame[6] == 1 ? true : false);
                            alarmeShutdownRange = (trame[7] == 1 ? true : false);
                            alarmeShutdownChecksum = (trame[8] == 1 ? true : false);
                            alarmeShutdownOverload = (trame[9] == 1 ? true : false);
                            alarmeShutdownInstruction = (trame[10] == 1 ? true : false);
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourConfigEcho:

                            // TODO
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourCoupleActive:
                            coupleActive = (trame[4] == 1 ? true : false);
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourCoupleMaximum:
                            coupleMaximum = trame[4] * 256 + trame[5];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourId:
                            id = trame[4];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourLed:
                            ledAllumee = (trame[4] == 1 ? true : false);
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourMouvement:
                            enMouvement = (trame[4] == 1 ? true : false);
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourNumeroModele:
                            modele = trame[4] * 256 + trame[5];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourPositionActuelle:
                            positionActuelle = trame[4] * 256 + trame[5];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourPositionCible:
                            positionCible = trame[4] * 256 + trame[5];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourPositionMaximum:
                            positionMax = trame[4] * 256 + trame[5];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourPositionMinimum:
                            positionMin = trame[4] * 256 + trame[5];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourTemperature:
                            temperature = trame[4];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourTension:
                            tension = (double)trame[4] / 10.0;
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourVersionFirmware:
                            firmware = trame[4];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourVitesseActuelle:
                            vitesseActuelle = trame[4] * 256 + trame[5];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourVitesseMax:
                            vitesseMax = trame[4] * 256 + trame[5];
                            break;
                        case (byte)TrameFactory.FonctionServo.RetourErreurs:
                            ErreurAngleLimit = (trame[4] == 1 ? true : false);
                            ErreurChecksum = (trame[5] == 1 ? true : false);
                            ErreurInputVoltage = (trame[6] == 1 ? true : false);
                            ErreurInstruction = (trame[7] == 1 ? true : false);
                            ErreurOverheating = (trame[8] == 1 ? true : false);
                            ErreurOverload = (trame[9] == 1 ? true : false);
                            ErreurRange = (trame[10] == 1 ? true : false);
                            break;
                    }
                }
            }
        }

        private double ValueToBaudrate(int value)
        {
            return 2000000 / (value + 1);
        }

        private int BaudrateToValue(double baudrate)
        {
            return (int)Math.Round((2000000 - baudrate) / baudrate);
        }
    }
}
