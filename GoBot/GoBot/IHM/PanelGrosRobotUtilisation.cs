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
    public partial class PanelGrosRobotUtilisation : UserControl
    {
        private ToolTip tooltip;

        public PanelGrosRobotUtilisation()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            groupBoxUtilisation.DeploiementChange += new Composants.GroupBoxRetractable.DeploiementDelegate(groupBoxUtilisation_Deploiement);
        }

        void groupBoxUtilisation_Deploiement(bool deploye)
        {
            Config.CurrentConfig.UtilisationGROuvert = deploye;
        }

        private void PanelUtilGros_Load(object sender, EventArgs e)
        {
            groupBoxUtilisation.Deployer(Config.CurrentConfig.UtilisationGROuvert, false);
            switchBoutonPuissance.SetActif(true, false);
        }

        private void switchBoutonPuissance_ChangementEtat(object sender, EventArgs e)
        {
            Robots.GrosRobot.AlimentationPuissance(switchBoutonPuissance.Actif);
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.Diagnostic();
        }

        private void btnPinceDroiteFermee_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceDroite, true);
        }

        private void btnPinceDroiteOuverte_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceDroite, false);
        }

        private void btnPinceGaucheFermee_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceGauche, true);
        }

        private void btnPinceGaucheOuverte_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceGauche, false);
        }

        private void btnCoudeRange_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsCoude, Config.CurrentConfig.PositionGRCoudeRange);
        }

        private void btnEpauleRange_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsEpaule, Config.CurrentConfig.PositionGREpauleRange);
        }

        private void switchBoutonPompeFeu_ChangementEtat(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, switchBoutonPompeFeu.Actif);
        }

        private void switchBoutonElectrvanne_ChangementEtat(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRElectrovanneFeu, switchBoutonElectrvanne.Actif);
        }

        private void btnTirBouchon_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRCanonFruit, true);
        }

        private void switchBoutonPousse_ChangementEtat(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPousseBouchon, switchBoutonPousse.Actif);
        }

        private void switchBoutonPinceDroite_ChangementEtat(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceDroite, switchBoutonPinceDroite.Actif);
        }

        private void switchBoutonPinceGauche_ChangementEtat(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceGauche, switchBoutonPinceGauche.Actif);
        }

        private void groupBoxUtilisation_Enter(object sender, EventArgs e)
        {

        }

        private void btnCoudeGo_Click(object sender, EventArgs e)
        {
            BrasFruits.PositionCoude((double)numCoude.Value);
        }

        private void btnEpauleGo_Click(object sender, EventArgs e)
        {
            BrasFruits.PositionEpaule((double)numEpaule.Value);
        }

        private void btnDepose2_Click(object sender, EventArgs e)
        {
            BrasFruits.PositionDeposeBouchon2();
        }

        private void btnBrasRange_Click(object sender, EventArgs e)
        {
            BrasFruits.PositionRange();
        }

        private void btnDepose1_Click(object sender, EventArgs e)
        {
            BrasFruits.PositionDeposeBouchon1();
        }
    }
}
