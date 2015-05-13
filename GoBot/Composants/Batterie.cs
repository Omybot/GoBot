using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Composants
{
    public partial class Batterie : PictureBox
    {
        System.Windows.Forms.Timer timer;
        int compteur = 0;
        bool vide = false;

        private double tension;
        public double Tension 
        {
            get { return tension; }
            set
            {
                toolTip.SetToolTip(this, tension + "V");
                if (Afficher)
                {
                    tension = value;
                    if (tension > TensionMidHigh)
                        CouleurVert();
                    else if (tension > TensionMid)
                        CouleurOrange();
                    else if (tension > TensionLow)
                    {
                        CouleurRouge();
                        Thread bip = new Thread(Bip);
                        bip.Start();
                    }
                    else if (tension >= TensionNull)
                    {
                        CouleurRougeCritique(true);
                        Thread bip = new Thread(BipUrgent);
                        bip.Start();
                    }
                    else
                        CouleurGris();
                }
                else
                {
                    CouleurGris();
                }
            }
        }

        public void BipUrgent()
        {
            Console.Beep(7000, 100);
            Thread.Sleep(20);
            Console.Beep(7000, 100);
        }

        public void Bip()
        {
            Console.Beep(6000, 100);
        }

        public double TensionMidHigh { get; set; }
        public double TensionMid { get; set; }
        public double TensionLow { get; set; }
        public double TensionNull { get; set; }

        public Batterie()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 300;
            timer.Tick += new EventHandler(timer_Tick);
            Tension = -1;
            TensionLow = 0;
            TensionMid = 0;
            TensionMidHigh = 0;
            CouleurGris();
            Afficher = false;
            toolTip.SetToolTip(this, "0V");
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

        public void CouleurOrange(bool blink = false, bool eteindre = false)
        {
            vide = false;
            ChangementImage(global::Composants.Properties.Resources.BatMid, blink, eteindre);
        }

        public void CouleurJaune(bool blink = false, bool eteindre = false)
        {
            vide = false;
            ChangementImage(global::Composants.Properties.Resources.BatMidHigh, blink, eteindre);
        }

        public void CouleurRouge(bool blink = false, bool eteindre = false)
        {
            vide = true;
            if(timer.Interval != 400)
                timer.Interval = 400;
            ChangementImage(global::Composants.Properties.Resources.BatLow, blink, eteindre);
        }

        public void CouleurRougeCritique(bool blink = false, bool eteindre = false)
        {
            vide = true;
            if (timer.Interval != 120)
                timer.Interval = 120;
            ChangementImage(global::Composants.Properties.Resources.BatCrit, blink, eteindre);
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
        }

        public bool Afficher { get; set; }
    }
}
