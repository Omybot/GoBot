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
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsCoude, (int)numFruitsCoude.Value);
        }

        private void btnCoudeRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée du coude ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRCoudeRange = (int)numFruitsCoude.Value;
        }

        #endregion

        #region Epaule
        private void btnEpauleOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsEpaule, (int)numFruitsEpaule.Value);
        }

        private void btnEpauleRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée de l'épaule ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGREpauleRange = (int)numFruitsEpaule.Value;
        }
        #endregion

        #region Pince droite
        private void btnPinceDroiteOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsPinceDroite, (int)numFruitsPinceDroite.Value);
        }

        private void btnPinceDroiteFermee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position fermée de la pince droite ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPinceDroiteFermee = (int)numFruitsPinceDroite.Value;
        }

        private void btnPinceDroiteOuverte_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position ouverte de la pince droite ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPinceDroiteOuverte = (int)numFruitsPinceDroite.Value;
        }
        #endregion
        
        #region PinceGauche
        private void btnPinceGaucheOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsPinceGauche, (int)numFruitsPinceGauche.Value);
        }

        private void btnPinceGaucheFermee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position fermée de la pince gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPinceGaucheFermee = (int)numFruitsPinceGauche.Value;
        }

        private void btnPinceGaucheOuverte_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position ouverte de la pince gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPinceGaucheOuverte = (int)numFruitsPinceGauche.Value;
        }
        #endregion

        private void PanelReglageGros_Load(object sender, EventArgs e)
        {
            groupBoxReglage.Deployer(Config.CurrentConfig.ReglageGROuvert, false);
        }

        #region Coude Feux

        private void btnFeuxOkCoude_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, (int)numFeuxCoude.Value);
        }

        private void btnFeuxCoudeSave_Click(object sender, EventArgs e)
        {
            // TODO
        }

        #endregion

        #region Poignet Feux

        private void btnFeuxOkPoignet_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, (int)numFeuxPoignet.Value);
        }

        private void btnFeuxPoignetSave_Click(object sender, EventArgs e)
        {
            // TODO
        }

        #endregion

        #region Epaule Feux

        private void btnFeuxOkEpaule_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnFeuxEpauleSave_Click(object sender, EventArgs e)
        {
            // TODO
        }

        #endregion
    }
}
