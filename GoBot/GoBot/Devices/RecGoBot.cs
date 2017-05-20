using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Communications;
using System.Drawing;

namespace GoBot.Devices
{
    public class RecGoBot
    {
        public delegate void ButtonChangeDelegate(CapteurOnOffID btn, Boolean state);
        public event ButtonChangeDelegate ButtonChange;

        public delegate void JackChangeDelegate(Boolean state);
        public event JackChangeDelegate JackChange;

        public delegate void ColorChangeDelegate(MatchColor state);
        public event ColorChangeDelegate ColorChange;

        public enum Leds
        {
            A1,
            A2,
            A3,
            A4,
            A5,
            A6,
            A7,
            A8,
            B1,
            B2,
            B3,
            B4,
            B5,
            B6,
            B7,
            B8
        }

        public enum LedStatus
        {
            Off,
            Rouge,
            Orange,
            Vert
        }

        private ConnexionUDP connexion;

        public RecGoBot(ConnexionUDP conn)
        {
            connexion = conn;
            connexion.NouvelleTrameRecue += new Connexion.ReceptionDelegate(connexion_NouvelleTrameRecue);
        }

        void connexion_NouvelleTrameRecue(Trame trameRecue)
        {
            if (trameRecue[1] == (byte)FonctionTrame.RetourCapteurOnOff)
            {
                CapteurOnOffID but;

                Console.WriteLine(trameRecue[2] + (trameRecue[3]>0 ? " On" : " Off"));

                switch(trameRecue[2])
                {
                    case 0:
                        but = CapteurOnOffID.Bouton2;
                        break;
                    case 1:
                        but = CapteurOnOffID.Bouton4;
                        break;
                    case 2:
                        but = CapteurOnOffID.Bouton1;
                        break;
                    case 3:
                        but = CapteurOnOffID.Bouton3;
                        break;
                    case 4:
                        but = CapteurOnOffID.Bouton10;
                        break;
                    case 5:
                        but = CapteurOnOffID.Bouton8;
                        break;
                    case 6:
                        but = CapteurOnOffID.Bouton9;
                        break;
                    case 7:
                        but = CapteurOnOffID.Bouton7;
                        break;
                    case 8:
                        but = CapteurOnOffID.Bouton6;
                        break;
                    case 9:
                        but = CapteurOnOffID.CouleurEquipe;
                        break;
                    case 10:
                        but = CapteurOnOffID.Jack;
                        break;
                    case 11:
                        but = CapteurOnOffID.Bouton5;
                        break;
                    case 12:
                        but = CapteurOnOffID.LSwitch1;
                        break;
                    case 13:
                        but = CapteurOnOffID.LSwitch2;
                        break;
                    case 14:
                        but = CapteurOnOffID.LSwitch3;
                        break;
                    case 15:
                        but = CapteurOnOffID.LSwitch4;
                        break;
                    default :
                        but = CapteurOnOffID.Bouton1;
                        break;
                }

                bool pushed = trameRecue[3] > 0;

                if (but == CapteurOnOffID.CouleurEquipe && ColorChange != null)
                    ColorChange((MatchColor)trameRecue[3]);

                else if (but == CapteurOnOffID.Jack && JackChange != null)
                    JackChange(pushed);

                else if (ButtonChange != null)
                    ButtonChange(but, pushed);
            }
        }

        public void SetLed(Leds led, LedStatus state)
        {
            connexion.SendMessage(TrameFactory.SetLed(led, state));
        }

        public void SetLedColor(Color color)
        {
            connexion.SendMessage(TrameFactory.SetLedColor(color));
        }

        public void Buzz(int frequency, byte volume)
        {
            connexion.SendMessage(TrameFactory.Buzz(frequency, volume));
        }
    }
}
