using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GoBot.Actionneurs;
using GoBot.Mouvements;

namespace GoBot.IHM
{
    public partial class PanelGrosRobotSequences : UserControl
    {
        private ToolTip tooltip;

        public PanelGrosRobotSequences()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            groupBoxSequences.DeploiementChange += new Composants.GroupBoxRetractable.DeploiementDelegate(groupBoxSequences_Deploiement);
        }

        void groupBoxSequences_Deploiement(bool deploye)
        {
            Config.CurrentConfig.SequencesGROuvert = deploye;
        }

        private void PanelSequencesGros_Load(object sender, EventArgs e)
        {
            groupBoxSequences.Deployer(Config.CurrentConfig.SequencesGROuvert, false);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Rentrer();
            Actionneur.BrasLunaire.Monter();
            Actionneur.BrasLunaire.SemiOuvrir();
        }

        private void groupBoxSequences_Enter(object sender, EventArgs e)
        {

        }

        private void btnLunaireRange_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Rentrer();
        }

        private void btnLunaireSorti_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Sortir();
        }

        private void btnLunaireBas_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Descendre();
        }

        private void btnLunaireHaut_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Monter();
        }

        private void btnLunaireOuvrir_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Ouvrir();
        }

        private void btnLunaireFermer_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Fermer();
        }

        private void btnLunaireSemiOuvert_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.SemiOuvrir();
        }

        private void btnLunaireSequence_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.AttrapageFusee();
        }

        private void btnLunaireSemiSorti_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.SemiSortir();
        }
    }
}
