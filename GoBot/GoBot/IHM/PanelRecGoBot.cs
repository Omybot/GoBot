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
        RecGoBot carte;

        List<Button3D> boutons;
        List<Led> leds;
        Dictionary<Led, Boolean> ledActive;

        public PanelRecGoBot()
        {
            InitializeComponent();
            
            boutons = new List<Button3D> {btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10};
            leds = new List<Led> {ledA1, ledA2, ledA3, ledA4, ledA5, ledA6, ledA7, ledA8, ledB1, ledB2, ledB3, ledB4, ledB5, ledB6, ledB7, ledB8};
            ledActive = new Dictionary<Led, bool>();
            leds.ForEach(led => ledActive.Add(led, false));

            if (!Config.DesignMode)
            {
                this.carte = new RecGoBot(Connexions.ConnexionGB);
                carte.ButtonChange += new RecGoBot.ButtonChangeDelegate(carte_ButtonChange);
            }
        }

        void carte_ButtonChange(RecGoBot.Buttons btn, bool state)
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
            int ledNo = leds.IndexOf((Led)sender);
            ledActive[(Led)sender] = !ledActive[(Led)sender];
            carte.SetLed((RecGoBot.Leds)ledNo, ledActive[(Led)sender]);
        }

        private void picLedColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picLedColor.BackColor = dlg.Color;
                carte.SetLedColor(dlg.Color);
            }
        }

        private void btnBuzz_Click(object sender, EventArgs e)
        {
            carte.Buzz(200);
            Thread.Sleep(1000);
            carte.Buzz(0);
        }
    }
}
