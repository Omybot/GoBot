﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Balises;

namespace GoBot.IHM
{
    public partial class PanelBaliseUnique : UserControl
    {
        private Font font;
        Balise balise;
        public PanelBaliseUnique()
        {
            InitializeComponent();
            balise = Plateau.Balise1;
            font = new Font("Calibri", 8);
            balise.PositionsChange += new Balise.PositionsChangeDelegate(MAJPosition);
        }

        private void trackBarVitesse_TickValueChanged(object sender, EventArgs e)
        {
            lblVitesse.Text = trackBarVitesse.Value.ToString();
            Robots.GrosRobot.MoteurPosition(MoteurID.Balise, (int)trackBarVitesse.Value);
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
                foreach (DetectionBalise detection in Plateau.Balise1.DetectionsCapteur2)
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

                lblVitesse.Text = balise.ValeurConsigne + "";
                lblToursSecondesActuel.Text = Math.Round(balise.VitesseToursSecActuelle, 2) + "";
            }
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

        private SolidBrush brushRouge = new SolidBrush(Color.Salmon);
        private SolidBrush brushBlanc = new SolidBrush(Color.White);
        private SolidBrush brushNoir = new SolidBrush(Color.Black);
        private SolidBrush brushBleu = new SolidBrush(Color.LightBlue);
        private Pen penRouge = new Pen(Color.Salmon);
        private Pen penBleu = new Pen(Color.LightBlue);
        private void DessineAngle(double debut, double fin, bool ennemi)
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
    }
}