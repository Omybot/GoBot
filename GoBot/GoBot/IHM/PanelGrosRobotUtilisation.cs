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
            if (!BrasFruits.PositionCoude((double)numCoude.Value))
                MessageBox.Show("Position inaccessible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEpauleGo_Click(object sender, EventArgs e)
        {
            if (!BrasFruits.PositionEpaule((double)numEpaule.Value))
                MessageBox.Show("Position inaccessible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            Servomoteur coude = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFruitsCoude, 0);
            Servomoteur epaule = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFruitsEpaule, 0);

            coude.VitesseMax = 150;
            epaule.VitesseMax = 150;

            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceDroite, false);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceGauche, false);

            BrasFruits.PositionCoude(-95.77);
            BrasFruits.PositionEpaule(163.79);


            do
            {
                coude.DemandeActualisation(false);
            } while (coude.EnMouvement);
            do
            {
                epaule.DemandeActualisation(false);
            } while (epaule.EnMouvement);


            Robots.GrosRobot.Reculer(250);


            BrasFruits.PositionCoude(-114);
            BrasFruits.PositionEpaule(156.30);
            do
            {
                coude.DemandeActualisation(false);
            } while (coude.EnMouvement);
            do
            {
                epaule.DemandeActualisation(false);
            } while (epaule.EnMouvement);


            BrasFruits.PositionCoude(-104.51);
            BrasFruits.PositionEpaule(146.60);
            do
            {
                coude.DemandeActualisation(false);
            } while (coude.EnMouvement);
            do
            {
                epaule.DemandeActualisation(false);
            } while (epaule.EnMouvement);
            
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceDroite, true);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceGauche, true);
            Thread.Sleep(500);
            coude.VitesseMax = 1000;
            epaule.VitesseMax = 1000;

            BrasFruits.PositionCoude(-95.77);
            BrasFruits.PositionEpaule(163.79);
            do
            {
                coude.DemandeActualisation(false);
            } while (coude.EnMouvement);
            do
            {
                epaule.DemandeActualisation(false);
            } while (epaule.EnMouvement);

            Robots.GrosRobot.Avancer(250);

            BrasFruits.PositionCoude(0);
            do
            {
                coude.DemandeActualisation(false);
            } while (coude.EnMouvement);

            BrasFruits.PositionDeposeBouchon2();
            do
            {
                coude.DemandeActualisation(false);
            } while (coude.EnMouvement);
            do
            {
                epaule.DemandeActualisation(false);
            } while (epaule.EnMouvement);


            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceDroite, false);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceGauche, false);

            Thread.Sleep(700);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPousseBouchon, true);
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPousseBouchon, false);
        }
    }
}
