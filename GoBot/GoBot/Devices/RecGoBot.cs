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
        public delegate void ButtonChangeDelegate(Buttons btn, Boolean state);
        public event ButtonChangeDelegate ButtonChange;

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

        public enum Buttons
        {
            B1,
            B2,
            B3,
            B4,
            B5,
            B6,
            B7,
            B8,
            B9,
            B10,
            Jack,
            Couleur
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
                Buttons but;

                Console.WriteLine(trameRecue[2] + (trameRecue[3]>0 ? " On" : " Off"));

                switch(trameRecue[2])
                {
                    case 0:
                        but = Buttons.B2;
                        break;
                    case 1:
                        but = Buttons.B4;
                        break;
                    case 2:
                        but = Buttons.B1;
                        break;
                    case 3:
                        but = Buttons.B3;
                        break;
                    case 4:
                        but = Buttons.B10;
                        break;
                    case 5:
                        but = Buttons.B8;
                        break;
                    case 6:
                        but = Buttons.B9;
                        break;
                    case 7:
                        but = Buttons.B7;
                        break;
                    case 8:
                        but = Buttons.B6;
                        break;
                    case 9:
                        but = Buttons.Couleur;
                        break;
                    case 10:
                        but = Buttons.Jack;
                        break;
                    case 11:
                        but = Buttons.B5;
                        break;
                    default :
                        but = Buttons.B1;
                        break;
                }

                bool pushed = trameRecue[3] > 0;

                if (ButtonChange != null)
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

        public void Buzz(byte volume)
        {
            connexion.SendMessage(TrameFactory.Buzz(volume));
        }
    }
}
