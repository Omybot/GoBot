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
        private Font font;
        public PanelBalise()
        {
            InitializeComponent();
            font = new Font("Calibri", 8);
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

        private int nbDetections;
        void balise_PositionsChange()
        {
            if (boxAffichage.Checked)
            {
                VideAngles();

                nbDetections = 0;
                foreach (DetectionBalise detection in balise.DetectionsCapteur2)
                {
                    DessineAngle(detection.AngleDebut, detection.AngleFin, false);
                    nbDetections++;
                }

                nbDetections = 0;
                foreach (DetectionBalise detection in balise.DetectionsCapteur1)
                {
                    DessineAngle(detection.AngleDebut, detection.AngleFin, true);
                    nbDetections++;
                }

                CompleteAngles();

                trackBarVitesse.SetValue(balise.ValeurConsigne, false);
                lblVitesse.Text = balise.ValeurConsigne + "";
                lblToursSecondesActuel.Text = Math.Round(balise.VitesseToursSecActuelle, 2) + "";
                if (balise.ReglageVitesse)
                    ledAsserv.CouleurVert();
                else
                    ledAsserv.CouleurRouge();

                if (balise.ReglageOffset)
                    ledOffset.CouleurVert();
                else
                    ledOffset.CouleurRouge();
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
                    g.DrawString((fin + debut) / 2.0 + "°", font, new SolidBrush(Color.Black), 2, 5 + 8 * nbDetections);
                }
                else
                {
                    g.FillPie(new SolidBrush(Color.LightBlue), 5, 180, 190, 190, (int)debut, (int)(fin - debut));
                    g.DrawPie(new Pen(Color.Blue), 5, 180, 190, 190, (int)debut, (int)(fin - debut));
                    g.DrawString((fin + debut) / 2.0 + "°", font, new SolidBrush(Color.Black), 2, 185 + 8 * nbDetections);
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

        public void btnOffset_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.SetOffsetBalise(Balise.Carte, 1, 0);
            Config.CurrentConfig.SetOffsetBalise(Balise.Carte, 2, 0);
            balise.ReglerOffset(16); // 16 mesures à 4 tours seconde ce qui fait 4 secondes de calibration
        }

        private void btnAsserv_Click(object sender, EventArgs e)
        {
            balise.ReglageVitesse = !balise.ReglageVitesse;
        }

        public void btnStart_Click(object sender, EventArgs e)
        {
            boxAffichage.Checked = true;
            trackBarConsigne.SetValue(40);
            trackBarVitesse.SetValue(2000);
            balise.ReglageVitesse = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            balise.ReglageVitesse = false;
            balise.VitesseRotation(0);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            balise.Reset();
        }
    }
}
