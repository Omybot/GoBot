using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PanelGrosRobotReglage : UserControl
    {
        private ToolTip tooltip;

        public PanelGrosRobotReglage()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            groupBoxReglage.DeploiementChange += new Composants.GroupBoxRetractable.DeploiementDelegate(groupBoxReglage_Deploiement);
        }

        void groupBoxReglage_Deploiement(bool deploye)
        {
            Config.CurrentConfig.ReglageGROuvert = deploye;
        }

        #region Coude
        private void btnCoudeOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRCoude, (int)numCoude.Value);
        }

        private void btnCoudeRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée du coude ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRCoudeRange = (int)numCoude.Value;
        }

        #endregion

        #region Epaule
        private void btnEpauleOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GREpaule, (int)numEpaule.Value);
        }

        private void btnEpauleRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée de l'épaule ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGREpauleRange = (int)numEpaule.Value;
        }
        #endregion

        #region Pince droite
        private void btnPinceDroiteOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRPinceDroite, (int)numPinceDroite.Value);
        }

        private void btnPinceDroiteFermee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position fermée de la pince droite ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPinceDroiteFermee = (int)numPinceDroite.Value;
        }

        private void btnPinceDroiteOuverte_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position ouverte de la pince droite ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPinceDroiteOuverte = (int)numPinceDroite.Value;
        }
        #endregion
        
        #region PinceGauche
        private void btnPinceGaucheOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRPinceGauche, (int)numPinceGauche.Value);
        }

        private void btnPinceGaucheFermee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position fermée de la pince gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPinceGaucheFermee = (int)numPinceGauche.Value;
        }

        private void btnPinceGaucheOuverte_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position ouverte de la pince gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPinceGaucheOuverte = (int)numPinceGauche.Value;
        }
        #endregion

        private void PanelReglageGros_Load(object sender, EventArgs e)
        {
            groupBoxReglage.Deployer(Config.CurrentConfig.ReglageGROuvert, false);
        }
    }
}
