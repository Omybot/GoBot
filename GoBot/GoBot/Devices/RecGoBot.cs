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
            B10
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
                if (trameRecue[2] == (byte)11)
                    but = (Buttons)Buttons.B2;
                else if (trameRecue[2] == 2)
                    but = (Buttons)Buttons.B4;
                else if (trameRecue[2] == 3)
                    but = (Buttons)Buttons.B1;
                else if (trameRecue[2] == 6)
                    but = (Buttons)Buttons.B8;
                else if (trameRecue[2] == 7)
                    but = (Buttons)Buttons.B9;
                else
                    but = (Buttons)trameRecue[2];

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
