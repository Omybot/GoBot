using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Calculs;

namespace GoBot.IHM
{
    public partial class PanelBalise : UserControl
    {
        public PanelBalise()
        {
            InitializeComponent();
        }

        private Balise balise;
        public Balise Balise
        {
            get
            {
                return balise;
            }
            set
            {
                balise = value;
                if (balise != null)
                {
                    groupBalise.Text = "Balise " + balise.Carte;
                    balise.PositionsChange += new GoBot.Balise.PositionsChangeDelegate(MAJPosition);
                }
            }
        }

        private void MAJPosition()
        {
            this.Invoke(new EventHandler(delegate
            {
                balise_PositionsChange();
            }));
        }

        void balise_PositionsChange()
        {
            if (boxAffichage.Checked)
            {
                VideAngles();

                foreach (DetectionBalise detection in balise.DetectionsBas)
                {
                    DessineAngle(detection.AngleDebut, detection.AngleFin, false);
                    //lblAngleEnnemi.Text = Math.Round(angle.X, 2) + "°";
                }
                foreach (DetectionBalise detection in balise.DetectionsHaut)
                {
                    DessineAngle(detection.AngleDebut, detection.AngleFin, true);
                    //lblAngleEnnemi.Text = Math.Round(angle.X, 2) + "°";
                }

                CompleteAngles();

                trackBarVitesse.SetValue(balise.ValeurConsigne, false);
                lblVitesse.Text = balise.ValeurConsigne + "";
                lblToursSecondesActuel.Text = Math.Round(balise.VitesseToursSecActuelle, 2) + "";
                if (balise.ReglageVitesse)
                    ledAsserv.On();
                else
                    ledAsserv.Off();

                if (balise.ReglageOffset)
                    ledOffset.On();
                else
                    ledOffset.Off();
            }
        }

        private void trackBarVitesse_TickValueChanged()
        {
            balise.VitesseRotation((int)trackBarVitesse.Value);
        }

        private void trackBarVitesse_ValueChanged()
        {
            lblVitesse.Text = trackBarVitesse.Value + "";
        }

        private void VideAngles()
        {
            Bitmap bmp = new Bitmap(pictureBoxAngle.Width, pictureBoxAngle.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBoxAngle.Width, pictureBoxAngle.Height);

            pictureBoxAngle.Image = bmp;
        }

        private void CompleteAngles()
        {
            Graphics g = Graphics.FromImage(pictureBoxAngle.Image);
            g.FillEllipse(new SolidBrush(Color.Black), 97, 97, 5, 5);
            g.FillEllipse(new SolidBrush(Color.Black), 97, 272, 5, 5);
            pictureBoxAngle.Refresh();
        }

        private void DessineAngle(double debut, double fin, bool ennemi)
        {
            try
            {
                Bitmap bmp;
                Graphics g;

                if (pictureBoxAngle.Image == null)
                    bmp = new Bitmap(pictureBoxAngle.Width, pictureBoxAngle.Height);
                else
                    bmp = (Bitmap)pictureBoxAngle.Image;

                g = Graphics.FromImage(bmp);
                
                if (ennemi)
                {
                    g.FillPie(new SolidBrush(Color.Salmon), 5, 5, 190, 190, (int)debut, (int)(fin - debut));
                    g.DrawPie(new Pen(Color.Red), 5, 5, 190, 190, (int)debut, (int)(fin - debut));
                }
                else
                {
                    g.FillPie(new SolidBrush(Color.LightBlue), 5, 180, 190, 190, (int)debut, (int)(fin - debut));
                    g.DrawPie(new Pen(Color.Blue), 5, 180, 190, 190, (int)debut, (int)(fin - debut));
                    //Console.WriteLine(debut + " -> " + fin);
                }

                pictureBoxAngle.Image = bmp;
            }
            catch (Exception)
            {
            }
        }

        private void trackBarConsigne_TickValueChanged()
        {
            balise.VitesseConsigne = trackBarConsigne.Value / 10.0;
            balise.ReglageVitesse = true;
        }

        private void trackBarConsigne_ValueChanged()
        {
            lblConsigne.Text = trackBarConsigne.Value / 10.0 + "";
        }

        private void boxAsservContinu_CheckedChanged(object sender, EventArgs e)
        {
            balise.ReglageVitessePermanent = !boxAsservContinu.Checked;
        }

        private void btnOffset_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.SetOffsetBaliseBas(Balise.Carte, 0);
            Config.CurrentConfig.SetOffsetBaliseHaut(Balise.Carte, 0);
            balise.ReglerOffset(40);
        }

        private void btnAsserv_Click(object sender, EventArgs e)
        {
            balise.ReglageVitesse = !balise.ReglageVitesse;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            boxAffichage.Checked = true;
            trackBarConsigne.SetValue(40);
            trackBarVitesse.SetValue(2000);
            balise.ReglageVitesse = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            balise.ReglageVitesse = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            balise.Reset();
        }
    }
}
