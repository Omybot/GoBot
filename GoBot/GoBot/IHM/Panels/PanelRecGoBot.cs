using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using GoBot.Communications;
using System.Reflection;
using GoBot.Devices;
using Composants;
using GoBot.Actionneurs;
namespace GoBot.IHM
{
    public partial class PanelRecGoBot : UserControl
    {
        List<Button3D> boutons;
        List<Led> leds;
        Dictionary<Led, RecGoBot.LedStatus> ledActive;

        public PanelRecGoBot()
        {
            InitializeComponent();

            boutons = new List<Button3D> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btnJack, btnCouleur, swi1, swi2, swi3, swi4 };
            leds = new List<Led> { ledA1, ledA2, ledA3, ledA4, ledA5, ledA6, ledA7, ledA8, ledB1, ledB2, ledB3, ledB4, ledB5, ledB6, ledB7, ledB8 };
            ledActive = new Dictionary<Led, RecGoBot.LedStatus>();
            leds.ForEach(led => ledActive.Add(led, RecGoBot.LedStatus.Off));
            leds.ForEach(led => led.Color = Color.Gray);

            colorPickup1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            colorPickup1.ColorHover += colorPickup1_ColorHover;
            colorPickup1.ColorClick += colorPickup1_ColorClick;

            btn1.Tag = SensorOnOffID.Bouton1;
            btn2.Tag = SensorOnOffID.Bouton2;
            btn3.Tag = SensorOnOffID.Bouton3;
            btn4.Tag = SensorOnOffID.Bouton4;
            btn5.Tag = SensorOnOffID.Bouton5;
            btn6.Tag = SensorOnOffID.Bouton6;
            btn7.Tag = SensorOnOffID.Bouton7;
            btn8.Tag = SensorOnOffID.Bouton8;
            btn9.Tag = SensorOnOffID.Bouton9;
            btn10.Tag = SensorOnOffID.Bouton10;
            btnJack.Tag = SensorOnOffID.Jack;
            btnCouleur.Tag = SensorOnOffID.CouleurEquipe;
            swi1.Tag = SensorOnOffID.LSwitch1;
            swi2.Tag = SensorOnOffID.LSwitch2;
            swi3.Tag = SensorOnOffID.LSwitch3;
            swi4.Tag = SensorOnOffID.LSwitch4;

            ledA1.Tag = LedID.DebugA1;
            ledA2.Tag = LedID.DebugA2;
            ledA3.Tag = LedID.DebugA3;
            ledA4.Tag = LedID.DebugA4;
            ledA5.Tag = LedID.DebugA5;
            ledA6.Tag = LedID.DebugA6;
            ledA7.Tag = LedID.DebugA7;
            ledA8.Tag = LedID.DebugA8;

            ledB1.Tag = LedID.DebugB1;
            ledB2.Tag = LedID.DebugB2;
            ledB3.Tag = LedID.DebugB3;
            ledB4.Tag = LedID.DebugB4;
            ledB5.Tag = LedID.DebugB5;
            ledB6.Tag = LedID.DebugB6;
            ledB7.Tag = LedID.DebugB7;
            ledB8.Tag = LedID.DebugB8;
        }

        private void PanelConstantes_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                // TODO déplacer en dehors de la fenetre
                AllDevices.RecGoBot.ButtonChange += RecGoBot_ButtonChange;
                AllDevices.RecGoBot.ColorChange += RecGoBot_ColorChange;
                AllDevices.RecGoBot.JackChange += RecGoBot_JackChange;
                AllDevices.RecGoBot.LedChange += RecGoBot_LedChange;
            }
        }

        private void RecGoBot_LedChange(LedID led, RecGoBot.LedStatus state)
        {
            Led target = null;

            switch(led)
            {
                case LedID.DebugA1:
                    target = ledA1;
                    break;
                case LedID.DebugA2:
                    target = ledA2;
                    break;
                case LedID.DebugA3:
                    target = ledA3;
                    break;
                case LedID.DebugA4:
                    target = ledA4;
                    break;
                case LedID.DebugA5:
                    target = ledA5;
                    break;
                case LedID.DebugA6:
                    target = ledA6;
                    break;
                case LedID.DebugA7:
                    target = ledA7;
                    break;
                case LedID.DebugA8:
                    target = ledA8;
                    break;
                case LedID.DebugB1:
                    target = ledB1;
                    break;
                case LedID.DebugB2:
                    target = ledB2;
                    break;
                case LedID.DebugB3:
                    target = ledB3;
                    break;
                case LedID.DebugB4:
                    target = ledB4;
                    break;
                case LedID.DebugB5:
                    target = ledB5;
                    break;
                case LedID.DebugB6:
                    target = ledB6;
                    break;
                case LedID.DebugB7:
                    target = ledB7;
                    break;
                case LedID.DebugB8:
                    target = ledB8;
                    break;
            }

            ledActive[target] = state;
            target.Color = LedStateToColor(state);
        }

        void RecGoBot_JackChange(bool state)
        {
            this.InvokeAuto(() => btnJack.Value = state);
        }

        void RecGoBot_ColorChange(MatchColor state)
        {
            this.InvokeAuto(() => btnCouleur.Value = state == MatchColor.LeftBlue ? true : false);
        }

        void colorPickup1_ColorClick(Color color)
        {
            SetColor(color);
            colorPickup1.Visible = false;
        }

        void colorPickup1_ColorHover(Color color)
        {
            SetColor(color);
        }

        void RecGoBot_ButtonChange(SensorOnOffID btn, bool state)
        {
            this.InvokeAuto(() =>
            {
                try
                {
                    boutons.Find(b => (SensorOnOffID)b.Tag == btn).Value = state;
                }
                catch (Exception)
                {
                    Console.WriteLine("Bouton inconnu");
                }
            });
        }

        private void leds_MouseClick(object sender, MouseEventArgs e)
        {
            Led ledSender = (Led)sender;
            LedID ledNo = (LedID)ledSender.Tag;

            switch (ledActive[ledSender])
            {
                case RecGoBot.LedStatus.Off:
                    ledActive[ledSender] = RecGoBot.LedStatus.Rouge;
                    ledSender.Color = Color.Red;
                    break;
                case RecGoBot.LedStatus.Rouge:
                    ledActive[ledSender] = RecGoBot.LedStatus.Orange;
                    ledSender.Color = Color.DarkOrange;
                    break;
                case RecGoBot.LedStatus.Orange:
                    ledActive[ledSender] = RecGoBot.LedStatus.Vert;
                    ledSender.Color = Color.LimeGreen;
                    break;
                case RecGoBot.LedStatus.Vert:
                    ledActive[ledSender] = RecGoBot.LedStatus.Off;
                    ledSender.Color = Color.Gray;
                    break;
            }

            AllDevices.RecGoBot.SetLed((LedID)ledNo, ledActive[ledSender]);
        }

        private Color LedStateToColor(RecGoBot.LedStatus state)
        {
            Color c = Color.Gray;

            switch (state)
            {
                case RecGoBot.LedStatus.Off:
                    c = Color.Gray;
                    break;
                case RecGoBot.LedStatus.Rouge:
                    c = Color.Red;
                    break;
                case RecGoBot.LedStatus.Orange:
                    c = Color.DarkOrange;
                    break;
                case RecGoBot.LedStatus.Vert:
                    c = Color.LimeGreen;
                    break;
            }

            return c;
        }

        private void picLedColor_Click(object sender, EventArgs e)
        {
            colorPickup1.Visible = true;
            colorPickup1.BringToFront();
            colorPickup1.Location = this.PointToClient(MousePosition);
        }

        private void btnBuzz_Click(object sender, EventArgs e)
        {
            AllDevices.RecGoBot.Buzz(8000, 200);
            Thread.Sleep(1000);
            AllDevices.RecGoBot.Buzz(0, 0);
        }

        private void SetColor(Color color)
        {
            picLedColor.BackColor = color;
            AllDevices.RecGoBot.SetLedColor(color);
        }
    }
}
