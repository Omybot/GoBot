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

namespace GoBot.IHM
{
    public partial class PanelBaliseDiagnostic : UserControl
    {
        private Balise balise;
        private EventHandler eventGraphiques;

        public PanelBaliseDiagnostic()
        {
            InitializeComponent();

            if(!Config.DesignMode)
                eventGraphiques = new EventHandler(MAJGraphiques);
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
            }
        }

        void Stats_NouvelleDonnee(TimeSpan temps, int pwm, DetectionBalise detection1, DetectionBalise detection2)
        {
            ctrlGraphiqueAngle1.AjouterPoint("Angle 1", detection1.AngleCentral, Color.Green);
            ctrlGraphiqueDistance1.AjouterPoint("Distance 1", detection1.Distance, Color.Red);

            ctrlGraphiqueAngle2.AjouterPoint("Angle 2", detection2.AngleCentral, Color.Green);
            ctrlGraphiqueDistance2.AjouterPoint("Distance 2", detection2.Distance, Color.Red);

            ctrlGraphiqueTemps.AjouterPoint("Temps(ms)", temps.TotalMilliseconds, Color.Blue);
            ctrlGraphiquePWM.AjouterPoint("PWM", pwm, Color.DarkSalmon);

            this.Invoke(eventGraphiques);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            balise.Stats.Reset();
            ctrlGraphiqueAngle1.SupprimerCourbe("Angle 1");
            ctrlGraphiqueDistance1.SupprimerCourbe("Distance 1");
            ctrlGraphiqueAngle2.SupprimerCourbe("Angle 2");
            ctrlGraphiqueDistance2.SupprimerCourbe("Distance 2");
        }

        private void MAJGraphiques(object sender, EventArgs e)
        {
            ctrlGraphiqueAngle1.DessineCourbes();
            ctrlGraphiqueDistance1.DessineCourbes();
            ctrlGraphiqueAngle2.DessineCourbes();
            ctrlGraphiqueDistance2.DessineCourbes();
            ctrlGraphiqueTemps.DessineCourbes();
            ctrlGraphiquePWM.DessineCourbes();

            lblStabiliteAngle1.Text = Balise.Stats.StabiliteAngle1.ToString("0.00") + "% / " + Balise.Stats.EcartTypeAngle1.ToString("0.00") + "°";
            lblStabiliteDistance1.Text = Balise.Stats.StabiliteDistance1.ToString("0.00") + "% / " + Balise.Stats.EcartTypeDistance1.ToString("0.00") + "mm";

            lblStabiliteAngle2.Text = Balise.Stats.StabiliteAngle2.ToString("0.00") + "% / " + Balise.Stats.EcartTypeAngle2.ToString("0.00") + "°";
            lblStabiliteDistance2.Text = Balise.Stats.StabiliteDistance2.ToString("0.00") + "% / " + Balise.Stats.EcartTypeDistance2.ToString("0.00") + "mm";

            lblNbTrames.Text = Balise.Stats.NombreMessagesRecus + " messages";
        }

        private void btnLancer_Click(object sender, EventArgs e)
        {
            balise.Stats.NouvelleDonnee -= new BaliseStats.NouvelleDonneeDelegate(Stats_NouvelleDonnee);
            if (btnLancer.Text == "Lancer")
            {
                balise.Stats.NouvelleDonnee += new BaliseStats.NouvelleDonneeDelegate(Stats_NouvelleDonnee);
                btnLancer.Text = "Stop";
            }
            else
            {
                btnLancer.Text = "Lancer";
            }
        }
    }
}
