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

            boutons = new List<Button3D> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10 };
            leds = new List<Led> { ledA1, ledA2, ledA3, ledA4, ledA5, ledA6, ledA7, ledA8, ledB1, ledB2, ledB3, ledB4, ledB5, ledB6, ledB7, ledB8 };
            ledActive = new Dictionary<Led, RecGoBot.LedStatus>();
            leds.ForEach(led => ledActive.Add(led, RecGoBot.LedStatus.Off));
            leds.ForEach(led => led.CouleurGris());

            if (!Config.DesignMode)
            {
                Devices.Devices.RecGoBot.ButtonChange += new RecGoBot.ButtonChangeDelegate(carte_ButtonChange);
            }
            colorPickup1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            colorPickup1.ColorHover += colorPickup1_ColorHover;
            colorPickup1.ColorClick += colorPickup1_ColorClick;
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

        void carte_ButtonChange(RecGoBot.Buttons btn, bool state)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    carte_ButtonChange(btn, state);
                }));
            }
            else
            {
                if (state)
                {
                    boutons[(int)btn].On();
                }
                else
                {
                    boutons[(int)btn].Off();
                }

            }
        }

        private void PanelConstantes_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
            }
        }

        private void button3D4_MouseEnter(object sender, EventArgs e)
        {
            btn4.On();
        }

        private void button3D4_MouseLeave(object sender, EventArgs e)
        {
            btn4.Off();
        }

        private void leds_MouseClick(object sender, MouseEventArgs e)
        {
            Led ledSender = (Led)sender;
            int ledNo = leds.IndexOf(ledSender);

            switch (ledActive[ledSender])
            {
                case RecGoBot.LedStatus.Off:
                    ledActive[ledSender] = RecGoBot.LedStatus.Rouge;
                    ledSender.CouleurRouge();
                    break;
                case RecGoBot.LedStatus.Rouge:
                    ledActive[ledSender] = RecGoBot.LedStatus.Orange;
                    ledSender.CouleurOrange();
                    break;
                case RecGoBot.LedStatus.Orange:
                    ledActive[ledSender] = RecGoBot.LedStatus.Vert;
                    ledSender.CouleurVert();
                    break;
                case RecGoBot.LedStatus.Vert:
                    ledActive[ledSender] = RecGoBot.LedStatus.Off;
                    ledSender.CouleurGris();
                    break;
            }

            Devices.Devices.RecGoBot.SetLed((RecGoBot.Leds)ledNo, ledActive[ledSender]);
        }

        private void picLedColor_Click(object sender, EventArgs e)
        {
            colorPickup1.Visible = true;
            colorPickup1.BringToFront();
            colorPickup1.Location = this.PointToClient(MousePosition);
        }

        private void btnBuzz_Click(object sender, EventArgs e)
        {
            Devices.Devices.RecGoBot.Buzz(200);
            Thread.Sleep(1000);
            Devices.Devices.RecGoBot.Buzz(0);
        }

        private void SetColor(Color color)
        {
            picLedColor.BackColor = color;
            Devices.Devices.RecGoBot.SetLedColor(color);
        }
    }
}
