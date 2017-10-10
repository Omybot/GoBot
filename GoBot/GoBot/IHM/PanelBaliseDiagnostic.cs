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

        public PanelBaliseDiagnostic()
        {
            InitializeComponent();
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
            ctrlGraphiqueAngle1.AddPoint("Angle 1", detection1.AngleCentral, Color.Green);
            ctrlGraphiqueDistance1.AddPoint("Distance 1", detection1.Distance, Color.Red);

            ctrlGraphiqueAngle2.AddPoint("Angle 2", detection2.AngleCentral, Color.Green);
            ctrlGraphiqueDistance2.AddPoint("Distance 2", detection2.Distance, Color.Red);

            ctrlGraphiqueTemps.AddPoint("Temps(ms)", temps.TotalMilliseconds, Color.Blue);
            ctrlGraphiquePWM.AddPoint("PWM", pwm, Color.DarkSalmon);

            this.InvokeAuto(() => MAJGraphiques());
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            balise.Stats.Reset();
            ctrlGraphiqueAngle1.DeleteCurve("Angle 1");
            ctrlGraphiqueDistance1.DeleteCurve("Distance 1");
            ctrlGraphiqueAngle2.DeleteCurve("Angle 2");
            ctrlGraphiqueDistance2.DeleteCurve("Distance 2");
        }

        private void MAJGraphiques()
        {
            ctrlGraphiqueAngle1.DrawCurves();
            ctrlGraphiqueDistance1.DrawCurves();
            ctrlGraphiqueAngle2.DrawCurves();
            ctrlGraphiqueDistance2.DrawCurves();
            ctrlGraphiqueTemps.DrawCurves();
            ctrlGraphiquePWM.DrawCurves();

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
