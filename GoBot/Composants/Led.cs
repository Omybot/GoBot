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
            CouleurRouge();
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

        public void CouleurVert(bool blink = false, bool eteindre = false)
        {
            ChangementImage(global::Composants.Properties.Resources.LedVert, blink, eteindre);
        }

        public void CouleurOrange(bool blink = false, bool eteindre = false)
        {
            ChangementImage(global::Composants.Properties.Resources.LedOrange, blink, eteindre);
        }

        public void CouleurBleu(bool blink = false, bool eteindre = false)
        {
            ChangementImage(global::Composants.Properties.Resources.LedBleu, blink, eteindre);
        }

        public void CouleurJaune(bool blink = false, bool eteindre = false)
        {
            ChangementImage(global::Composants.Properties.Resources.LedJaune, blink, eteindre);
        }

        public void CouleurRouge(bool blink = false, bool eteindre = false)
        {
            ChangementImage(global::Composants.Properties.Resources.LedRouge, blink, eteindre);
        }

        public void CouleurGris(bool blink = false, bool eteindre = false)
        {
            ChangementImage(global::Composants.Properties.Resources.LedGris, blink, eteindre);
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
