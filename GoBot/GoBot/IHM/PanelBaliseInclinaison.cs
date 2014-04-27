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
    public partial class PanelBaliseInclinaison : UserControl
    {
        public Balise Balise { get; set; }

        public PanelBaliseInclinaison()
        {
            InitializeComponent();
        }

        private void trackBarInclinaisonFace_ValueChanged(object sender, EventArgs e)
        {
            lblInclinaisonFace.Text = trackBarInclinaisonFace.Value.ToString();
        }

        private void trackBarInclinaisonProfil_ValueChanged(object sender, EventArgs e)
        {
            lblInclinaisonProfil.Text = trackBarInclinaisonProfil.Value.ToString();
        }

        private void trackBarInclinaisonFace_TickValueChanged(object sender, EventArgs e)
        {

        }
    }
}
