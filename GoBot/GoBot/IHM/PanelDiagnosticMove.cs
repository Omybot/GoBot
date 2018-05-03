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
using GoBot.Threading;

namespace GoBot.IHM
{
    public partial class PanelDiagnosticMove : UserControl
    {
        private ThreadLink _linkPolling;
        private ThreadLink _linkDrawing;

        public PanelDiagnosticMove()
        {
            InitializeComponent();
        }

        private void btnDemandeCharge_Click(object sender, EventArgs e)
        {
            if (_linkPolling != null)
            {
                btnDemandeCharge.Text = "Stopper";

                _linkPolling = ThreadManager.CreateThread(link => DemandeValeurs());
                _linkPolling.StartInfiniteLoop(new TimeSpan(0));

                _linkDrawing = ThreadManager.CreateThread(link => Dessine());
                _linkDrawing.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, 50));
            }
            else
            {
                btnDemandeCharge.Text = "Lancer";
                _linkPolling.Cancel();
                _linkDrawing.Cancel();

                _linkPolling.WaitEnd();
                _linkDrawing.WaitEnd();

                _linkPolling = null;
                _linkDrawing = null;
            }
        }
        
        void Dessine()
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
        }

        double moyenne;
        void DemandeValeurs()
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
