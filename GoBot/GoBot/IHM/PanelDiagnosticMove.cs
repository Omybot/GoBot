using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Communications;

namespace GoBot.IHM
{
    public partial class PanelDiagnosticMove : UserControl
    {
        public PanelDiagnosticMove()
        {
            InitializeComponent();
            ctrlGraphique.EchelleFixe = true;
            ctrlGraphique1.EchelleFixe = true;
            ctrlGraphique2.EchelleFixe = true;

            ctrlGraphique1.EchelleMax = 4000;
            ctrlGraphique2.EchelleMax = 4000;
            ctrlGraphique1.EchelleMin = -4000;
            ctrlGraphique2.EchelleMin = -4000;
        }

        private void btnDemandeCharge_Click(object sender, EventArgs e)
        {
            if (timer == null)
            {
                timer = new Timer();
                timer.Interval = 30;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
                btnDemandeCharge.Text = "Stoper";
            }
            else
            {
                timer.Stop();
                timer = null;
                btnDemandeCharge.Text = "Lancer";
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            List<double>[] valeurs = Robots.GrosRobot.DiagnosticCpuPwm(30);

            for (int i = 0; i < valeurs[1].Count; i++)
            {
                ctrlGraphique.AjouterPoint("CPU", valeurs[0][i], Color.Green);
                ctrlGraphique1.AjouterPoint("PWM droite", valeurs[1][i], Color.Red);
                ctrlGraphique2.AjouterPoint("PWM gauche", valeurs[2][i], Color.Blue);
            }

            lblChargeCPU.Text = (valeurs[0].Average() / 50.0).ToString("#.##") + "%";
            ctrlGraphique.DessineCourbes();
            ctrlGraphique1.DessineCourbes();
            ctrlGraphique2.DessineCourbes();

            Color c = Color.FromArgb(230, Color.White);
            Image img = new Bitmap(global::GoBot.Properties.Resources.Vumetre);
            Graphics g = Graphics.FromImage(img);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, 12, (int)(valeurs[0].Average() * 75));
            pictureBoxVumetreCPU.Image = img;
        }

        private Timer timer;
    }
}
