using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Calculs;
using GoBot.Balises;
using System.Drawing.Drawing2D;

namespace GoBot.IHM
{
    public partial class PanelBalise : UserControl
    {
        private Font font;
        private Balise balise;
        private int nbDetections;

        private SolidBrush brushRouge = new SolidBrush(Color.Salmon);
        private SolidBrush brushBlanc = new SolidBrush(Color.White);
        private SolidBrush brushNoir = new SolidBrush(Color.Black);
        private SolidBrush brushBleu = new SolidBrush(Color.LightBlue);
        private Pen penRouge = new Pen(Color.Red);
        private Pen penBleu = new Pen(Color.Blue);

        public PanelBalise()
        {
            InitializeComponent();
            font = new Font("Calibri", 8);
            Bitmap bmp = new Bitmap(pictureBoxAngle.Width, pictureBoxAngle.Height);
            pictureBoxAngle.Image = bmp;
        }

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
                    balise.PositionsChange += new Balise.PositionsChangeDelegate(MAJPosition);
            }
        }

        private void MAJPosition()
        {
            this.InvokeAuto(() => balise_PositionsChange());
        }

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
                    ledAsserv.Color = Color.LimeGreen;
                else
                    ledAsserv.Color = Color.Red;

                if (balise.ReglageOffset)
                    ledOffset.Color = Color.LimeGreen;
                else
                    ledOffset.Color = Color.Red;
            }
        }

        private void trackBarVitesse_TickValueChanged(object sender, EventArgs e)
        {
            balise.VitesseRotation((int)trackBarVitesse.Value);
        }

        private void trackBarVitesse_ValueChanged(object sender, EventArgs e)
        {
            lblVitesse.Text = trackBarVitesse.Value + "";
        }

        private void VideAngles()
        {
            Bitmap bmp = new Bitmap(pictureBoxAngle.Width, pictureBoxAngle.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(brushBlanc, 0, 0, pictureBoxAngle.Width, pictureBoxAngle.Height);

            pictureBoxAngle.Image = bmp;
        }

        private void CompleteAngles()
        {
            Graphics g = Graphics.FromImage(pictureBoxAngle.Image);
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                g.FillEllipse(brush, 97, 97, 5, 5);
                g.FillEllipse(brush, 97, 272, 5, 5);
            }
            pictureBoxAngle.Refresh();
        }
        private void DessineAngle(double debut, double fin, bool ennemi)
        {
            Bitmap bmp;
            Graphics g;

            if (pictureBoxAngle.Image == null)
                bmp = new Bitmap(pictureBoxAngle.Width, pictureBoxAngle.Height);
            else
                bmp = (Bitmap)pictureBoxAngle.Image;

            g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (ennemi)
            {
                g.FillPie(brushRouge, 5, 5, 190, 190, (int)debut, (int)(fin - debut));
                g.DrawPie(penRouge, 5, 5, 190, 190, (int)debut, (int)(fin - debut));
                g.DrawString(Math.Round((fin + debut) / 2.0, 2) + "°", font, brushNoir, 2, 5 + 8 * nbDetections);
            }
            else
            {
                g.FillPie(brushBleu, 5, 180, 190, 190, (int)debut, (int)(fin - debut));
                g.DrawPie(penBleu, 5, 180, 190, 190, (int)debut, (int)(fin - debut));
                g.DrawString(Math.Round((fin + debut) / 2.0, 2) + "°", font, brushNoir, 2, 185 + 10 * nbDetections);
            }

            pictureBoxAngle.Image = bmp;
        }

        private void trackBarConsigne_TickValueChanged(object sender, EventArgs e)
        {
            balise.VitesseConsigne = trackBarConsigne.Value / 10.0;
            balise.ReglageVitesse = true;
        }

        private void trackBarConsigne_ValueChanged(object sender, EventArgs e)
        {
            lblConsigne.Text = trackBarConsigne.Value / 10.0 + "";
        }

        private void boxAsservContinu_CheckedChanged(object sender, EventArgs e)
        {
            balise.ReglageVitessePermanent = !boxAsservContinu.Checked;
        }

        public void btnOffset_Click(object sender, EventArgs e)
        {
            balise.ReglerOffset(16); // 16 mesures à 4 tours seconde ce qui fait 4 secondes de calibration
        }

        private void btnAsserv_Click(object sender, EventArgs e)
        {
            balise.ReglageVitesse = !balise.ReglageVitesse;
        }

        public void btnStart_Click(object sender, EventArgs e)
        {
            boxAffichage.Checked = true;
            balise.Lancer(4);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            balise.Stop();
        }
    }
}
