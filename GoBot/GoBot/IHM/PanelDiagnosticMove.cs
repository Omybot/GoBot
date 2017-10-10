using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Communications;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PanelDiagnosticMove : UserControl
    {
        public PanelDiagnosticMove()
        {
            InitializeComponent();
        }

        private void btnDemandeCharge_Click(object sender, EventArgs e)
        {
            if (thDemandeValeurs == null)
            {
                thDemandeValeurs = new Thread(DemandeValeurs);
                thDemandeValeurs.Start();

                thDessine = new Thread(Dessine);
                thDessine.Start();

                btnDemandeCharge.Text = "Stoper";
            }
            else
            {
                thDemandeValeurs.Abort();
                thDemandeValeurs = null;

                thDessine.Abort();
                thDessine = null;

                btnDemandeCharge.Text = "Lancer";
            }
        }

        Thread thDemandeValeurs;
        Thread thDessine;

        void Dessine()
        {
            while (true)
            {
                lblChargeCPU.Text = (moyenne * 100).ToString("#.##") + "%";
                ctrlGraphique.DrawCurves();
                ctrlGraphique1.DrawCurves();
                ctrlGraphique2.DrawCurves();

                Color c = Color.FromArgb(230, Color.White);
                Image img = new Bitmap(global::GoBot.Properties.Resources.Vumetre);
                Graphics g = Graphics.FromImage(img);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, 12, img.Height - (int)(moyenne * img.Height));
                pictureBoxVumetreCPU.Image = img;

                Thread.Sleep(50);
            }
        }

        double moyenne;
        void DemandeValeurs()
        {
            while (true)
            {
                List<double>[] valeurs = Robots.GrosRobot.DiagnosticCpuPwm(30);
                moyenne = valeurs[0].Average();

                int min = Math.Min(valeurs[0].Count, valeurs[1].Count); 
                min = Math.Min(min, valeurs[2].Count);

                for (int i = 0; i < min; i++)
                {
                    ctrlGraphique.AddPoint("CPU", valeurs[0][i], Color.Green);

                    ctrlGraphique2.AddPoint("PWM gauche", valeurs[1][i], Color.Blue);
                    ctrlGraphique1.AddPoint("PWM droite", valeurs[2][i], Color.Red);
                }
            }
        }
    }
}
