using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoBot.IHM.Composants
{
    public partial class Led : PictureBox
    {
        Timer timer;
        int compteur = 0;

        public Led()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (Visible)
                Visible = false;
            else
                Visible = true;
            compteur++;
            if (compteur > 7)
                timer.Stop();
        }

        public void On(bool blink = false, bool eteindre = false)
        {
            timer.Stop();
            Visible = true;
            compteur = 0;
            if (eteindre)
                compteur = 1;
            Image = global::GoBot.Properties.Resources.ledOn;
            if (blink)
                timer.Start();

            Etat = true;
        }

        public void Off(bool blink = false, bool eteindre = false)
        {
            timer.Stop();
            Visible = true;
            compteur = 0;
            if (eteindre)
                compteur = 1;
            Image = global::GoBot.Properties.Resources.ledOff;
            if (blink)
                timer.Start();

            Etat = false;
        }

        public void Neutre(bool blink = false, bool eteindre = false)
        {
            timer.Stop();
            Visible = true;
            compteur = 0;
            if (eteindre)
                compteur = 1;
            Image = global::GoBot.Properties.Resources.ledNeutre;
            if (blink)
                timer.Start();

            Etat = false;
        }

        public bool Etat
        {
            get;
            set;
        }
    }
}
