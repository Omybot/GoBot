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
        static Servomoteur()
        {
            // Les servos >= 100 sont pour la pololu avec identifiant = ID - 100
        }

        public static short idServoPololu(ServomoteurID servo)
        {
            if ((int)servo >= 100)
                return (short)(servo - 100);
            else
                return -1;
        }

        private Board carte;
        private Connection connexion;

        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                connexion.SendMessage(FrameFactory.ServoEnvoiId((ServomoteurID)id, (char)value, carte));
                id = value;
            }
        }
        private ServoBaudrate baudrate;
        public ServoBaudrate Baudrate
        {
            get { return baudrate; }
            set
            {
                baudrate = value;
                connexion.SendMessage(FrameFactory.ServoEnvoiBaudrate((ServomoteurID)id, baudrate, carte));
            }
        }
        private void EnvoiCompliance()
        {
            connexion.SendMessage(FrameFactory.ServoEnvoiComplianceParams((ServomoteurID)id, ccwSlope, ccwMargin, cwMargin, cwSlope, carte));
        }
        private int punch;
        public int Punch
        {
            get { return punch; }
            set
            {
                punch = value;
                EnvoiCompliance();
            }
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
        private int coupleLimite;
        public int CoupleLimite
        {
            get { return coupleLimite; }
            set
            {
                coupleLimite = value;
                connexion.SendMessage(FrameFactory.ServoEnvoiCoupleLimite((ServomoteurID)id, coupleLimite, carte));
            }
        }
        private void EnvoiParamLED()
        {
            connexion.SendMessage(FrameFactory.ServoEnvoiConfigAlarmeLED((ServomoteurID)id, alarmeLEDInputVoltage, alarmeLEDAngleLimit, alarmeLEDOverheating, alarmeLEDRange, alarmeLEDChecksum, alarmeLEDOverload, alarmeLEDInstruction, carte));
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
            connexion.SendMessage(FrameFactory.ServoEnvoiConfigAlarmeShutdown((ServomoteurID)id, alarmeShutdownInputVoltage, alarmeShutdownAngleLimit, alarmeShutdownOverheating, alarmeShutdownRange, alarmeShutdownChecksum, alarmeShutdownOverload, alarmeShutdownInstruction, carte));
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
                connexion.SendMessage(FrameFactory.ServoEnvoiCoupleActive((ServomoteurID)id, coupleActive, carte));
            }
        }
        private int coupleActuel;
        public int CoupleActuel
        {
            get { return coupleActuel; }
        }
        private int coupleMaximum;
        public int CoupleMaximum
        {
            get { return coupleMaximum; }
            set
            {
                coupleMaximum = value;
                connexion.SendMessage(FrameFactory.ServoEnvoiCoupleMaximum((ServomoteurID)id, coupleMaximum, carte));
            }
        }
        private double tensionMaximum = 5;
        public double TensionMaximum
        {
            get { return tensionMaximum; }
            set
            {
                if (value < 5)
                    tensionMaximum = 5;
                else
                    tensionMaximum = value;
                connexion.SendMessage(FrameFactory.ServoEnvoiTensionMax((ServomoteurID)id, tensionMaximum, carte));
            }
        }
        private int temperatureMaximum;
        public int TemperatureMaximum
        {
            get { return temperatureMaximum; }
            set
            {
                temperatureMaximum = value;
                connexion.SendMessage(FrameFactory.ServoEnvoiTemperatureMax((ServomoteurID)id, temperatureMaximum, carte));
            }
        }
        private double tensionMinimum = 5;
        public double TensionMinimum
        {
            get { return tensionMinimum; }
            set
            {
                tensionMinimum = value;
                connexion.SendMessage(FrameFactory.ServoEnvoiTensionMin((ServomoteurID)id, tensionMinimum, carte));
            }
        }
        private bool ledAllumee;
        public bool LedAllumee
        {
            get { return ledAllumee; }
            set
            {
                ledAllumee = value;
                connexion.SendMessage(FrameFactory.ServoEnvoiLed((ServomoteurID)id, ledAllumee, carte));
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
                connexion.SendMessage(FrameFactory.ServoEnvoiPositionCible((ServomoteurID)id, positionCible, carte));
            }
        }
        private int positionMin;
        public int PositionMin
        {
            get { return positionMin; }
            set
            {
                positionMin = value;
                connexion.SendMessage(FrameFactory.ServoEnvoiPositionMinimum((ServomoteurID)id, positionMin, carte));
            }
        }
        private int positionMax;
        public int PositionMax
        {
            get { return positionMax; }
            set
            {
                positionMax = value;
                connexion.SendMessage(FrameFactory.ServoEnvoiPositionMaximum((ServomoteurID)id, positionMax, carte));
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
                connexion.SendMessage(FrameFactory.ServoEnvoiVitesseMax((ServomoteurID)id, vitesseMax, carte));
            }
        }

        public bool ErreurInputVoltage { get; private set; }
        public bool ErreurAngleLimit { get; private set; }
        public bool ErreurOverheating { get; private set; }
        public bool ErreurRange { get; private set; }
        public bool ErreurChecksum { get; private set; }
        public bool ErreurOverload { get; private set; }
        public bool ErreurInstruction { get; private set; }

        public Servomoteur(Board carte, int id, ServoBaudrate baudrate)
        {
            this.carte = carte;
            this.id = id;
            this.baudrate = baudrate;

            connexion = Connections.BoardConnection[carte];

            connexion.FrameReceived += new UDPConnection.NewFrameDelegate(connexion_NouvelleTrame);
        }

        public void DemandeActualisation(bool complete)
        {
            /*if (complete)
            {
                //connexion.SendMessage(TrameFactory.ServoDemandeBaudrate((ServomoteurID)id, carte));
                //Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandeComplianceParams((ServomoteurID)id, carte));
                Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandeConfigAlarmeLED((ServomoteurID)id, carte));
                Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandeConfigAlarmeShutdown((ServomoteurID)id, carte));
                Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandeConfigEcho((ServomoteurID)id, carte));
                Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandeCoupleMaximum((ServomoteurID)id, carte));
                Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandeNumeroModele((ServomoteurID)id, carte));
                Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandePositionCible((ServomoteurID)id, carte));
                Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandePositionMaximum((ServomoteurID)id, carte));
                Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandePositionMinimum((ServomoteurID)id, carte));
                Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandeVersionFirmware((ServomoteurID)id, carte));
                Thread.Sleep(10);
                connexion.SendMessage(TrameFactory.ServoDemandeVitesseMax((ServomoteurID)id, carte));
                Thread.Sleep(30);
                connexion.SendMessage(TrameFactory.ServoDemandeTensionMin((ServomoteurID)id, carte));
                Thread.Sleep(30);
                connexion.SendMessage(TrameFactory.ServoDemandeTensionMax((ServomoteurID)id, carte));
                Thread.Sleep(30);
                connexion.SendMessage(TrameFactory.ServoDemandeTemperatureMax((ServomoteurID)id, carte));
                Thread.Sleep(30);
                connexion.SendMessage(TrameFactory.ServoDemandeCoupleLimite((ServomoteurID)id, carte));
                Thread.Sleep(30);
            }

            connexion.SendMessage(TrameFactory.ServoDemandeTension((ServomoteurID)id, carte));
            Thread.Sleep(10);
            connexion.SendMessage(TrameFactory.ServoDemandeMouvement((ServomoteurID)id, carte));
            Thread.Sleep(10);
            connexion.SendMessage(TrameFactory.ServoDemandePositionActuelle((ServomoteurID)id, carte));
            Thread.Sleep(10);
            connexion.SendMessage(TrameFactory.ServoDemandeVitesseActuelle((ServomoteurID)id, carte));
            Thread.Sleep(10);
            connexion.SendMessage(TrameFactory.ServoDemandeCoupleActuel((ServomoteurID)id, carte));
            Thread.Sleep(10);
            connexion.SendMessage(TrameFactory.ServoDemandeTemperature((ServomoteurID)id, carte));
            Thread.Sleep(10);
            connexion.SendMessage(TrameFactory.ServoDemandeErreurs((ServomoteurID)id, carte));
            Thread.Sleep(10);
            connexion.SendMessage(TrameFactory.ServoDemandeCoupleActive((ServomoteurID)id, carte));
            Thread.Sleep(10);
            connexion.SendMessage(TrameFactory.ServoDemandeLed((ServomoteurID)id, carte));
            Thread.Sleep(10);*/

            connexion.SendMessage(FrameFactory.ServoDemandeAllIn((ServomoteurID)id, carte));
        }

        void connexion_NouvelleTrame(Frame trame)
        {
            // Test trame de type configuration servomoteur
            if (trame[1] == (byte)FrameFunction.CommandeServo)
            {
                // Test trame pour ce servo
                if (trame[3] == id)
                {
                    // Switch sur la fonction
                    switch (trame[2])
                    {
                        case (byte)ServoFunction.RetourComplianceParams:
                            ccwSlope = trame[4];
                            ccwMargin = trame[5];
                            cwSlope = trame[6];
                            cwMargin = trame[7];
                            break;
                        case (byte)ServoFunction.RetourConfigAlarmeLED:
                            alarmeLEDInputVoltage = (trame[4] == 1 ? true : false);
                            alarmeLEDAngleLimit = (trame[5] == 1 ? true : false);
                            alarmeLEDOverheating = (trame[6] == 1 ? true : false);
                            alarmeLEDRange = (trame[7] == 1 ? true : false);
                            alarmeLEDChecksum = (trame[8] == 1 ? true : false);
                            alarmeLEDOverload = (trame[9] == 1 ? true : false);
                            alarmeLEDInstruction = (trame[10] == 1 ? true : false);
                            break;
                        case (byte)ServoFunction.RetourConfigAlarmeShutdown:
                            alarmeShutdownInputVoltage = (trame[4] == 1 ? true : false);
                            alarmeShutdownAngleLimit = (trame[5] == 1 ? true : false);
                            alarmeShutdownOverheating = (trame[6] == 1 ? true : false);
                            alarmeShutdownRange = (trame[7] == 1 ? true : false);
                            alarmeShutdownChecksum = (trame[8] == 1 ? true : false);
                            alarmeShutdownOverload = (trame[9] == 1 ? true : false);
                            alarmeShutdownInstruction = (trame[10] == 1 ? true : false);
                            break;
                        case (byte)ServoFunction.RetourConfigEcho:

                            // TODO
                            break;
                        case (byte)ServoFunction.RetourCoupleActive:
                            coupleActive = (trame[4] == 1 ? true : false);
                            break;
                        case (byte)ServoFunction.RetourCoupleMaximum:
                            coupleMaximum = trame[4] * 256 + trame[5];
                            if (coupleMaximum < 0 || coupleMaximum > 1023)
                                coupleMaximum = 0;
                            break;
                        case (byte)ServoFunction.RetourLed:
                            ledAllumee = (trame[4] == 1 ? true : false);
                            break;
                        case (byte)ServoFunction.RetourMouvement:
                            enMouvement = (trame[4] == 1 ? true : false);
                            break;
                        case (byte)ServoFunction.RetourNumeroModele:
                            modele = trame[4] * 256 + trame[5];
                            break;
                        case (byte)ServoFunction.RetourPositionActuelle:
                            positionActuelle = trame[4] * 256 + trame[5];
                            if (positionActuelle < 0 || positionActuelle > 1023)
                                positionActuelle = 0;
                            break;
                        case (byte)ServoFunction.RetourPositionCible:
                            positionCible = trame[4] * 256 + trame[5];
                            if (positionCible < 0 || positionCible > 1023)
                                positionCible = 0;
                            break;
                        case (byte)ServoFunction.RetourPositionMaximum:
                            positionMax = trame[4] * 256 + trame[5];
                            if (positionMax < 0 || positionMax > 1023)
                                positionMax = 0;
                            break;
                        case (byte)ServoFunction.RetourPositionMinimum:
                            positionMin = trame[4] * 256 + trame[5];
                            if (positionMin < 0 || positionMin > 1023)
                                positionMin = 0;
                            break;
                        case (byte)ServoFunction.RetourTemperature:
                            temperature = trame[4];
                            break;
                        case (byte)ServoFunction.RetourTension:
                            tension = (double)trame[4] / 10.0;
                            if(semPing != null)
                                semPing.Release();
                            break;
                        case (byte)ServoFunction.RetourTensionMin:
                            tensionMinimum = (double)trame[4] / 10.0;
                            if (tensionMinimum < 5 || tensionMinimum > 25)
                                tensionMinimum = 5;
                            break;
                        case (byte)ServoFunction.RetourTensionMax:
                            tensionMaximum = (double)trame[4] / 10.0;
                            if (tensionMaximum < 5 || tensionMaximum > 25)
                                tensionMaximum = 5;
                            break;
                        case (byte)ServoFunction.RetourCoupleLimite:
                            coupleLimite = trame[4] * 256 + trame[5];
                            if (coupleLimite < 0 || coupleLimite > 1023)
                                coupleLimite = 0;
                            break;
                        case (byte)ServoFunction.RetourVersionFirmware:
                            firmware = trame[4];
                            break;
                        case (byte)ServoFunction.RetourVitesseActuelle:
                            vitesseActuelle = trame[4] * 256 + trame[5];
                            if (vitesseActuelle > 1023)
                                vitesseActuelle = 1024 - vitesseActuelle;
                            break;
                        case (byte)ServoFunction.RetourVitesseMax:
                            vitesseMax = trame[4] * 256 + trame[5];
                            if (vitesseMax < 0 || vitesseMax > 1023)
                                vitesseMax = 0;
                            break;
                        case (byte)ServoFunction.RetourTemperatureMax:
                            temperatureMaximum = trame[4];
                            break;
                        case (byte)ServoFunction.RetourCoupleCourant:
                            coupleActuel = trame[4] * 256 + trame[5];
                            if (coupleActuel > 1024)
                                coupleActuel = 1024 - coupleActuel;
                            break;
                        case (byte)ServoFunction.RetourErreurs:
                            ErreurAngleLimit = (trame[4] == 1 ? true : false);
                            ErreurChecksum = (trame[5] == 1 ? true : false);
                            ErreurInputVoltage = (trame[6] == 1 ? true : false);
                            ErreurInstruction = (trame[7] == 1 ? true : false);
                            ErreurOverheating = (trame[8] == 1 ? true : false);
                            ErreurOverload = (trame[9] == 1 ? true : false);
                            ErreurRange = (trame[10] == 1 ? true : false);
                            break;
                        case (byte)ServoFunction.RetourAllIn:
                            // 4 = taille de l'entête
                            try
                            {
                                modele = trame[6 + 1] * 256 + trame[6 + 0];
                                firmware = trame[6 + 2];
                                positionMin = trame[6 + 7] * 256 + trame[6 + 6];
                                positionMax = trame[6 + 9] * 256 + trame[6 + 8];
                                temperatureMaximum = trame[6 + 11];
                                tensionMinimum = trame[6 + 12] / 10.0;
                                tensionMaximum = trame[6 + 13] / 10.0;
                                coupleMaximum = trame[6 + 15] * 256 + trame[6 + 14];

                                // todo incorrect
                                alarmeLEDInputVoltage = (trame[6 + 17] == 1 ? true : false);
                                alarmeLEDAngleLimit = (trame[6 + 17] == 1 ? true : false);
                                alarmeLEDOverheating = (trame[6 + 17] == 1 ? true : false);
                                alarmeLEDRange = (trame[6 + 17] == 1 ? true : false);
                                alarmeLEDChecksum = (trame[6 + 17] == 1 ? true : false);
                                alarmeLEDOverload = (trame[6 + 17] == 1 ? true : false);
                                alarmeLEDInstruction = (trame[6 + 17] == 1 ? true : false);

                                alarmeShutdownInputVoltage = (trame[6 + 18] == 1 ? true : false);
                                alarmeShutdownAngleLimit = (trame[6 + 18] == 1 ? true : false);
                                alarmeShutdownOverheating = (trame[6 + 18] == 1 ? true : false);
                                alarmeShutdownRange = (trame[6 + 18] == 1 ? true : false);
                                alarmeShutdownChecksum = (trame[6 + 18] == 1 ? true : false);
                                alarmeShutdownOverload = (trame[6 + 18] == 1 ? true : false);
                                alarmeShutdownInstruction = (trame[6 + 18] == 1 ? true : false);

                                coupleActive = trame[6 + 24] > 0;
                                ledAllumee = trame[6 + 25] > 0;
                                cwMargin = trame[6 + 26];
                                ccwMargin = trame[6 + 27];
                                cwSlope = trame[6 + 28];
                                ccwSlope = trame[6 + 29];
                                positionCible = trame[6 + 31] * 256 + trame[6 + 32];
                                vitesseMax = trame[6 + 33] * 256 + trame[6 + 32];
                                coupleLimite = trame[6 + 35] * 256 + trame[6 + 34];
                                positionActuelle = trame[6 + 37] * 256 + trame[6 + 36];
                                vitesseActuelle = trame[6 + 39] * 256 + trame[6 + 38];
                                coupleActuel = trame[6 + 41] * 256 + trame[6 + 40];
                                tension = trame[6 + 42] / 10.0;
                                temperature = trame[6 + 43];
                                enMouvement = trame[6 + 46] > 0;
                                //punch = trame[6 + 49] * 256 + trame[6 + 48];
                            }
                            catch (Exception)
                            {
                            }
                            break;
                    }
                }
            }
        }

        private Semaphore semPing = null;

        private double ValueToBaudrate(int value)
        {
            return 2000000 / (value + 1);
        }

        private int BaudrateToValue(double baudrate)
        {
            return (int)Math.Round((2000000 - baudrate) / baudrate);
        }

        public bool Connecte
        {
            get
            {
                semPing = new Semaphore(0, int.MaxValue);
                connexion.SendMessage(FrameFactory.ServoDemandeTension((ServomoteurID)id, carte));
                if (semPing.WaitOne(100))
                    return Tension != 4.2; // Code de retour timeout = 42
                else
                    return false;
            }
        }

        public override string ToString()
        {
            ServomoteurID servo;
            try
            {
                servo = (ServomoteurID)id;
                return ((ServomoteurID)id).ToString() + "\tID " + id + "\t" + baudrate.ToString().Substring(1);
            }
            catch(Exception)
            {
                return "Inconnu\tID " + id + "\t" + baudrate.ToString().Substring(1);
            }
        }
    }
}
