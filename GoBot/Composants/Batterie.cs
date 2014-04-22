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
    public partial class Batterie : PictureBox
    {
        Timer timer;
        int compteur = 0;
        bool vide = false;

        private double tension;
        public double Tension 
        {
            get { return tension; }
            set
            {
                tension = value;
                if (tension > TensionMid)
                    CouleurVert();
                else if (tension > TensionLow)
                    CouleurJaune();
                else
                    CouleurRouge(true);
            }
        }
        public double TensionMid { get; set; }
        public double TensionLow { get; set; }

        public Batterie()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += new EventHandler(timer_Tick);
            CouleurGris();
            Tension = 999;
            TensionLow = 0;
            TensionLow = 0;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (Visible)
                Visible = false;
            else
                Visible = true;

            compteur++;

            if (!vide && compteur > 7)
                timer.Stop();
        }

        public void CouleurVert(bool blink = false, bool eteindre = false)
        {
            vide = false;
            ChangementImage(global::Composants.Properties.Resources.BatHigh, blink, eteindre);
        }

        public void CouleurJaune(bool blink = false, bool eteindre = false)
        {
            vide = false;
            ChangementImage(global::Composants.Properties.Resources.BatMid, blink, eteindre);
        }

        public void CouleurRouge(bool blink = false, bool eteindre = false)
        {
            vide = true;
            ChangementImage(global::Composants.Properties.Resources.BatLow, blink, eteindre);
        }

        public void CouleurGris(bool blink = false, bool eteindre = false)
        {
            vide = false;
            ChangementImage(global::Composants.Properties.Resources.BatNo, blink, eteindre);
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
