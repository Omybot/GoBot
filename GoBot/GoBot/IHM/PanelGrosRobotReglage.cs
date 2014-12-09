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

        private void PanelReglageGros_Load(object sender, EventArgs e)
        {
            groupBoxReglage.Deployer(Config.CurrentConfig.ReglageGROuvert, false);
        }

        private void btnOkDroitePinceDroite_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDroitePinceDroite, (int)numDroitePinceDroite.Value);
        }

        private void btnFermeDroitePinceDroite_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRDroitePinceDroiteFerme = (int)numDroitePinceDroite.Value;
        }

        private void btnOuvertDroitePinceDroite_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRDroitePinceDroiteOuvert = (int)numDroitePinceDroite.Value;
        }

        private void btnOkGauchePinceDroite_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRGauchePinceDroite, (int)numGauchePinceDroite.Value);
        }

        private void btnFermeGauchePinceDroite_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRGauchePinceDroiteFerme = (int)numGauchePinceDroite.Value;
        }

        private void btnOuvertGauchePinceDroite_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRGauchePinceDroiteOuvert = (int)numGauchePinceDroite.Value;
        }

        private void btnOkPinceDroite_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.MoteurPosition(MoteurID.GRAscenseurDroite, (int)numHauteurPinceDroite.Value);
        }

        private void btnHautPinceDroite_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRHautPinceDroite = (int)numHauteurPinceDroite.Value;
        }

        private void btnBasPinceDroite_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.PositionGRBasPinceDroite = (int)numHauteurPinceDroite.Value;
        }
    }
}
