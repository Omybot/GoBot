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
            if (switchBoutonPinceDroiteBas.Actif)
                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPousseBouchon, true);
            else
                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPousseBouchon, false);
        }

        private void switchBoutonPinceDroite_ChangementEtat(object sender, EventArgs e)
        {
            if(switchBoutonPinceDroiteBas.Actif)
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceDroiteBas, Config.CurrentConfig.PositionGRPinceFruitBasDroiteOuvert);
            else
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceDroiteBas, Config.CurrentConfig.PositionGRPinceFruitBasDroiteFerme);
        }

        private void switchBoutonPinceGauche_ChangementEtat(object sender, EventArgs e)
        {
            if (switchBoutonPinceGaucheBas.Actif)
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceGaucheBas, Config.CurrentConfig.PositionGRPinceFruitBasGaucheOuvert);
            else
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceGaucheBas, Config.CurrentConfig.PositionGRPinceFruitBasGaucheFerme);
        }

        private void btnCoudeGo_Click(object sender, EventArgs e)
        {
            if (!BrasFruits.PositionCoude((double)numCoude.Value))
                MessageBox.Show("Position inaccessible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Console.WriteLine(Math.Round(BrasFruits.Perimetre1()) + " mm");
        }

        private void btnEpauleGo_Click(object sender, EventArgs e)
        {
            if (!BrasFruits.PositionEpaule((double)numEpaule.Value))
                MessageBox.Show("Position inaccessible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Console.WriteLine(Math.Round(BrasFruits.Perimetre1()) + " mm");
        }

        private void btnBrasRange_Click(object sender, EventArgs e)
        {
            BrasFruits.PositionRange();
        }

        private void btnDepose1_Click(object sender, EventArgs e)
        {
            BrasFruits.PositionDeposeBouchon(); 
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GRPinceDroiteBas, Config.CurrentConfig.PositionGRPinceFruitBasDroiteOuvert);
            //Robots.GrosRobot.TourneMoteur(MoteurID.GRPinceGaucheBas, Config.CurrentConfig.PositionGRPinceFruitBasGaucheOuvert);

            //Robots.GrosRobot.TourneMoteur(MoteurID.GRPinceDroiteBas, 400);
            //Robots.GrosRobot.TourneMoteur(MoteurID.GRPinceGaucheBas, 500);
            //Thread.Sleep(500);
            /*
                Robots.GrosRobot.TourneMoteur(MoteurID.GRPinceDroiteHaut, Config.CurrentConfig.PositionGRPinceFruitHautDroiteOuvert);
                Robots.GrosRobot.TourneMoteur(MoteurID.GRPinceGaucheHaut, Config.CurrentConfig.PositionGRPinceFruitHautGaucheOuvert);
                //Thread.Sleep(150);
                Robots.GrosRobot.TourneMoteur(MoteurID.GRPinceDroiteBas, Config.CurrentConfig.PositionGRPinceFruitBasDroiteFerme);
                Robots.GrosRobot.TourneMoteur(MoteurID.GRPinceGaucheBas, Config.CurrentConfig.PositionGRPinceFruitBasGaucheFerme);

                Thread.Sleep(500);

                Robots.GrosRobot.TourneMoteur(MoteurID.GRPinceDroiteBas, Config.CurrentConfig.PositionGRPinceFruitBasDroiteOuvert);
                Robots.GrosRobot.TourneMoteur(MoteurID.GRPinceGaucheBas, Config.CurrentConfig.PositionGRPinceFruitBasGaucheOuvert);

            /*
            Servomoteur coude = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFruitsCoude, 0);
            Servomoteur epaule = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFruitsEpaule, 0);

            coude.VitesseMax = 150;
            epaule.VitesseMax = 150;

            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceDroiteBas, false);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceGaucheBas, false);

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
            
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceDroiteBas, true);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceGaucheBas, true);
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


            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceDroiteBas, false);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPinceGaucheBas, false);

            Thread.Sleep(700);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPousseBouchon, true);
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPousseBouchon, false);*/

            BrasFruits.BouchonHautBas();
        }

        private void switchBoutonPince_ChangementEtat(object sender, EventArgs e)
        {
            if (switchBoutonPinceBas.Actif)
            {
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceDroiteBas, Config.CurrentConfig.PositionGRPinceFruitBasDroiteFerme);
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceGaucheBas, Config.CurrentConfig.PositionGRPinceFruitBasGaucheFerme);
            }
            else
            {
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceDroiteBas, Config.CurrentConfig.PositionGRPinceFruitBasDroiteOuvert);
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceGaucheBas, Config.CurrentConfig.PositionGRPinceFruitBasGaucheOuvert);
            }
        }

        private void switchBoutonPinceDroiteHaut_ChangementEtat(object sender, EventArgs e)
        {
            if (switchBoutonPinceDroiteHaut.Actif)
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceDroiteHaut, Config.CurrentConfig.PositionGRPinceFruitHautDroiteFerme);
            else
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceDroiteHaut, Config.CurrentConfig.PositionGRPinceFruitHautDroiteOuvert);
        }

        private void switchBoutonPinceGaucheHaut_ChangementEtat(object sender, EventArgs e)
        {
            if (switchBoutonPinceGaucheHaut.Actif)
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceGaucheHaut, Config.CurrentConfig.PositionGRPinceFruitHautGaucheFerme);
            else
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceGaucheHaut, Config.CurrentConfig.PositionGRPinceFruitHautGaucheOuvert);
        }

        private void switchBoutonPinceHaut_ChangementEtat(object sender, EventArgs e)
        {
            if (switchBoutonPinceHaut.Actif)
            {
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceDroiteHaut, Config.CurrentConfig.PositionGRPinceFruitHautDroiteFerme);
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceGaucheHaut, Config.CurrentConfig.PositionGRPinceFruitHautGaucheFerme);
            }
            else
            {
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceDroiteHaut, Config.CurrentConfig.PositionGRPinceFruitHautDroiteOuvert);
                Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceGaucheHaut, Config.CurrentConfig.PositionGRPinceFruitHautGaucheOuvert);
            }
        }

        private void btnArmeCanon_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRCanonPuissance, true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BrasFruits.OuvrirPinceBas();
            BrasFruits.OuvrirPinceHaut();
            BrasFruits.PositionCoude(160);
            BrasFruits.PositionEpaule(0);
            CanonFruits.Armer();
            CanonFruits.PousseBouchon();
            CanonFruits.Tirer();
            BrasFruits.FermerPinceBas();
            BrasFruits.FermerPinceHaut();
            Thread.Sleep(500);
            BrasFruits.PositionRange();

            BrasFeux.PositionInterne3();
            Thread.Sleep(200);
            BrasFeux.PositionTorche3();
            Thread.Sleep(200);
            BrasFeux.PositionInterne3();
        }

        private void btnPoignetFeux_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionPoignet((double)numPoignetFeux.Value);
        }

        private void btnCoudeFeux_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionCoude((double)numCoudeFeux.Value);
        }

        private void btnEpauleFeux_Click(object sender, EventArgs e)
        {
            BrasFeux.PositionEpaule((double)numEpauleFeux.Value);
        }
    }
}
