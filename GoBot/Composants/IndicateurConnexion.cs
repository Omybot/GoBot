using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Composants
{
    public partial class IndicateurConnexion : PictureBox
    {
        Timer timer;
        int compteur = 0;

        public IndicateurConnexion()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            ConnexionNok();
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

        public void ConnexionOk(bool blink = false, bool eteindre = false)
        {
            ChangementImage(global::Composants.Properties.Resources.ConnexionOk, blink, eteindre);
        }

        public void ConnexionNok(bool blink = false, bool eteindre = false)
        {
            ChangementImage(global::Composants.Properties.Resources.ConnexionNok, blink, eteindre);
        }

        private void ChangementImage(Image img, bool blink = false, bool eteindre = false)
        {
            timer.Stop();
            Visible = true;
            compteur = 0;
            if (eteindre)
                compteur = 1;
            Image = img;
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
