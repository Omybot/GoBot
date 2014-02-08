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
    public partial class PanelDiagnosticBalise : UserControl
    {
        public PanelDiagnosticBalise()
        {
            InitializeComponent();

            if(!Config.DesignMode)
                eventGraphiques = new EventHandler(MAJGraphiques);
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
                }
            }
        }

        void Stats_NouvelleDonnee(TimeSpan temps, DetectionBalise detection)
        {
            ctrlGraphiqueAngle.AjouterPoint("Angle", detection.AngleCentral, Color.Green);
            ctrlGraphiqueDistance.AjouterPoint("Distance", detection.Distance, Color.Red);
            ctrlGraphiqueTemps.AjouterPoint("Temps(ms)", temps.TotalMilliseconds, Color.Blue);

            this.Invoke(eventGraphiques);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            balise.Stats.Reset();
            ctrlGraphiqueAngle.SupprimerCourbe("Angle");
            ctrlGraphiqueDistance.SupprimerCourbe("Distance");
            ctrlGraphiqueTemps.SupprimerCourbe("Temps");
        }

        private void MAJGraphiques(object sender, EventArgs e)
        {
            ctrlGraphiqueAngle.DessineCourbes();
            ctrlGraphiqueDistance.DessineCourbes();
            ctrlGraphiqueTemps.DessineCourbes();

            lblStabiliteAngle.Text = Balise.Stats.StabiliteAngle.ToString("0.00") + "% / " + Balise.Stats.EcartTypeAngle.ToString("0.00") + "°";
            lblStabiliteDistance.Text = Balise.Stats.StabiliteDistance.ToString("0.00") + "% / " + Balise.Stats.EcartTypeDistance.ToString("0.00") + "mm";
            lblNbTrames.Text = Balise.Stats.NombreMessagesRecus + " messages";
        }

        private EventHandler eventGraphiques;

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
