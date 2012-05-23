using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDP;
using GoBot.UDP;
using System.Windows.Forms;

namespace GoBot
{
    public class Servomoteur
    {
        private int id = 0;
        private double baudrate = 0;
        private Carte carte;
        private ConnexionUDP connexionUdp;
        private bool recherche;

        public ConnexionCheck ConnexionCheck
        {
            get;
            set;
        }

        int temperature;
        double tension;
        int couple;

        public Servomoteur(Carte carte, int id, double baudrate)
        {
            this.carte = carte;
            this.id = id;
            this.baudrate = baudrate;

            temperature = 0;
            tension = 0;
            couple = 0;

            ConnexionCheck = new ConnexionCheck(2000);
            ConnexionCheck.TestConnexion += new ConnexionCheck.TestConnexionDelegate(TestConnexion);
            ConnexionCheck.Start();

            switch (carte)
            {
                case (Carte.RecIo):
                    connexionUdp = GrosRobot.connexionIo;
                    break;
                case (Carte.RecMove):
                    connexionUdp = GrosRobot.connexionMove;
                    break;
            }

            connexionUdp.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(connexion_NouvelleTrame);
        }

        public delegate void TemperatureDelegate(int temperature);
        public event TemperatureDelegate TemperatureChange;

        public delegate void CoupleDelegate(int couple);
        public event CoupleDelegate CoupleChange;

        public delegate void TensionDelegate(double tension);
        public event TensionDelegate TensionChange;

        public delegate void RechercheAutoDelegate(int idServo, double baudrate);
        public event RechercheAutoDelegate RechercheAutoFinie;

        void connexion_NouvelleTrame(Trame trame)
        {
            if (trame[1] == 0xE0)
            {
                if (trame[2] == (Byte)TrameFactory.FonctionReglageServo.RechercheAuto)
                    return;

                // Trame de configuration servomoteur
                if (trame[3] == id)
                {
                    //Trame pour ce servo

                    ConnexionCheck.MajConnexion();

                    switch (trame[2])
                    {
                        case (byte)GoBot.UDP.TrameFactory.FonctionReglageServo.GetCouple:

                            int nouveauCouple = trame[4] * 256 + trame[5];
                            if(couple != nouveauCouple)
                            {
                                CoupleChange(nouveauCouple);
                                couple = nouveauCouple;
                            }
                            break;

                        case (byte)GoBot.UDP.TrameFactory.FonctionReglageServo.GetPosition:
                            break;
                        case (byte)GoBot.UDP.TrameFactory.FonctionReglageServo.GetTemperature:

                            int nouvelleTemp = trame[4] * 256 + trame[5];
                            if (temperature != nouvelleTemp)
                            {
                                TemperatureChange(nouvelleTemp);
                                temperature = nouvelleTemp;
                            }
                            break;

                        case (byte)GoBot.UDP.TrameFactory.FonctionReglageServo.GetTension:
                            
                            double nouvelleTension = (trame[4] * 256 + trame[5]) / 10.0;
                            if (tension != nouvelleTension)
                            {
                                TensionChange(nouvelleTension);
                                tension = nouvelleTension;
                            }
                            break;

                        case (byte)GoBot.UDP.TrameFactory.FonctionReglageServo.GetVitesse:
                            break;
                        case (byte)GoBot.UDP.TrameFactory.FonctionReglageServo.RechercheAuto:

                            if (recherche)
                            {
                                id = trame[3];
                                baudrate = 2000000 / (trame[4] + 1);

                                RechercheAutoFinie(id, baudrate);
                            }
                            break;

                        case (byte)GoBot.UDP.TrameFactory.FonctionReglageServo.TestConnexion:
                            break;
                    }
                }
            }
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public void ChangerID(int nouvelID)
        {
            Trame t = TrameFactory.ServoSetId(carte, id, BaudrateToValue(baudrate), nouvelID);
            connexionUdp.SendMessage(t);
            id = nouvelID;
        }

        public double Baudrate
        {
            get
            {
                return baudrate;
            }
            set
            {
                baudrate = value;
            }
        }

        public void ChangerBaudrate(int nouveauBaudrate)
        {
            Trame t = TrameFactory.ServoSetBaudrate(carte, id, BaudrateToValue(baudrate), BaudrateToValue(nouveauBaudrate));
            connexionUdp.SendMessage(t);
            baudrate = nouveauBaudrate;
        }

        public void TestConnexion()
        {
            Trame t = TrameFactory.ServoTestConnexion(carte, id, BaudrateToValue(baudrate));
            connexionUdp. SendMessage(t);
        }

        public void DemandeTemperature()
        {
            Trame t = TrameFactory.ServoGetTemperature(carte, id, BaudrateToValue(baudrate));
            connexionUdp.SendMessage(t);
        }

        public void DemandeCouple()
        {
            Trame t = TrameFactory.ServoGetCouple(carte, id, BaudrateToValue(baudrate));
            connexionUdp.SendMessage(t);
        }

        public void DemandeTension()
        {
            Trame t = TrameFactory.ServoGetTension(carte, id, BaudrateToValue(baudrate));
            connexionUdp.SendMessage(t);
        }

        public void DemandePosition()
        {
            Trame t = TrameFactory.ServoGetPosition(carte, id, BaudrateToValue(baudrate));
            connexionUdp.SendMessage(t);
        }

        public void SetPosition(int position)
        {
            Trame t = TrameFactory.ServoSetPosition(carte, id, BaudrateToValue(baudrate), position);
            connexionUdp.SendMessage(t);
        }

        public void DemandeVitesse()
        {
            Trame t = TrameFactory.ServoGetVitesse(carte, id, BaudrateToValue(baudrate));
            connexionUdp.SendMessage(t);
        }

        public void SetVitesse(int vitesse)
        {
            Trame t = TrameFactory.ServoSetVitesse(carte, id, BaudrateToValue(baudrate), vitesse);
            connexionUdp.SendMessage(t);
        }

        public void SetLed(bool allume)
        {
            Trame t = TrameFactory.ServoSetLed(carte, id, BaudrateToValue(baudrate), allume);
            connexionUdp.SendMessage(t);
        }

        public void SetPositionMin(int position)
        {
            Trame t = TrameFactory.ServoSetPositionMin(carte, id, BaudrateToValue(baudrate), position);
            connexionUdp.SendMessage(t);
        }

        public void SetPositionMax(int position)
        {
            Trame t = TrameFactory.ServoSetPositionMax(carte, id, BaudrateToValue(baudrate), position);
            connexionUdp.SendMessage(t);
        }

        public void RechercheAuto()
        {
            recherche = true;
            Trame t = TrameFactory.ServoRechercheAuto(carte);
            connexionUdp.SendMessage(t);
        }

        public void Reset()
        {
            Trame t = TrameFactory.ServoReset(carte, id);
            connexionUdp.SendMessage(t);
        }

        public void Surveiller()
        {
            //todo
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
