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
            Actionneur.BrasLunaire.Reculer();
            Actionneur.BrasLunaire.Monter();
            Actionneur.BrasLunaire.Fermer();
        }

        private void groupBoxSequences_Enter(object sender, EventArgs e)
        {

        }

        private enum BrasLunaireID
        {
            Central,
            Gauche,
            Droite
        }

        private BrasLunaireID BrasActuel
        {
            get
            {
                return (BrasLunaireID)(cboArmSelection.SelectedIndex);
            }
        }

        private void btnLunaireRange_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Reculer();
        }

        private void btnLunaireSorti_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Avancer();
        }

        private void btnLunaireBas_Click(object sender, EventArgs e)
        {
            switch (BrasActuel)
            {
                case BrasLunaireID.Central:
                    Actionneur.BrasLunaire.Avancer();
                    break;
                case BrasLunaireID.Droite:
                    Actionneur.BrasLunaireDroite.Descendre();
                    break;
                case BrasLunaireID.Gauche:
                    Actionneur.BrasLunaireGauche.Descendre();
                    break;
            }
        }

        private void btnLunaireHaut_Click(object sender, EventArgs e)
        {
            switch (BrasActuel)
            {
                case BrasLunaireID.Central:
                    Actionneur.BrasLunaire.Monter();
                    break;
                case BrasLunaireID.Droite:
                    Actionneur.BrasLunaireDroite.Ranger();
                    break;
                case BrasLunaireID.Gauche:
                    Actionneur.BrasLunaireGauche.Ranger();
                    break;
            }
        }

        private void btnLunaireOuvrir_Click(object sender, EventArgs e)
        {
            switch (BrasActuel)
            {
                case BrasLunaireID.Central:
                    Actionneur.BrasLunaire.Ouvrir();
                    break;
                case BrasLunaireID.Droite:
                    Actionneur.BrasLunaireDroite.Ouvrir();
                    break;
                case BrasLunaireID.Gauche:
                    Actionneur.BrasLunaireGauche.Ouvrir();
                    break;
            }
        }

        private void btnLunaireFermer_Click(object sender, EventArgs e)
        {
            switch (BrasActuel)
            {
                case BrasLunaireID.Central:
                    Actionneur.BrasLunaire.Fermer();
                    break;
                case BrasLunaireID.Droite:
                    Actionneur.BrasLunaireDroite.Fermer();
                    break;
                case BrasLunaireID.Gauche:
                    Actionneur.BrasLunaireGauche.Fermer();
                    break;
            }
        }

        private void btnLunaireSemiOuvert_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Fermer();
        }

        private void btnLunaireSemiSorti_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Fermer();
        }

        private void btnEjecter_Click(object sender, EventArgs e)
        {
            Actionneur.Ejecteur.Ejecter();
        }

        private void btnTourneGauche_Click(object sender, EventArgs e)
        {
            Actionneur.Ejecteur.TournerGauche();
            Thread.Sleep(500);
            Actionneur.Ejecteur.TournerStop();
        }

        private void btnTourneDroite_Click(object sender, EventArgs e)
        {
            Actionneur.Ejecteur.TournerDroite();
            Thread.Sleep(500);
            Actionneur.Ejecteur.TournerStop();
        }

        private void btnBloqueHaut_Click(object sender, EventArgs e)
        {
            Actionneur.Stockeur.BloqueHaut();
        }

        private void btnDebloqueHaut_Click(object sender, EventArgs e)
        {
            Actionneur.Stockeur.RelacheHaut();
        }

        private void btnBloqueBas_Click(object sender, EventArgs e)
        {
            Actionneur.Stockeur.BloqueBas();
        }

        private void btnRelacheBas_Click(object sender, EventArgs e)
        {
            Actionneur.Stockeur.RelacheBas();
        }

        private void btnRehausseurMonter_Click(object sender, EventArgs e)
        {
            Actionneur.Stockeur.MonterRehausseur();
        }

        private void btnRehausseurPreparer_Click(object sender, EventArgs e)
        {
            Actionneur.Stockeur.PreparerRehausseur();
        }

        private void btnRehausseRanger_Click(object sender, EventArgs e)
        {
            Actionneur.Stockeur.RangerRehausseur();
        }

        private void btnVidage_Click(object sender, EventArgs e)
        {
            Actionneur.Ejecteur.Ejecter();
            Actionneur.Stockeur.RelacheBas();
            Thread.Sleep(300);
            Actionneur.Ejecteur.Ejecter();
            Actionneur.Stockeur.MonterRehausseur();
            Thread.Sleep(350);
            Actionneur.Stockeur.RelacheHaut();
            Thread.Sleep(200);
            Actionneur.Stockeur.RangerRehausseur();
            Thread.Sleep(450);
            Actionneur.Ejecteur.Ejecter();
        }

        private void btnAvale_Click(object sender, EventArgs e)
        {
            Actionneur.Convoyeur.Bloque();
            Thread.Sleep(500);
            Actionneur.Convoyeur.Avaler();
            Thread.Sleep(1300);
            Actionneur.Convoyeur.Arreter();
            Actionneur.Convoyeur.Libere();
        }

        private void btnFindColor_Click(object sender, EventArgs e)
        {
            Actionneur.Ejecteur.PositionnerCouleur();
            Thread.Sleep(100);
            Actionneur.Ejecteur.Ejecter();
        }

        private void btnAttrape_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.AlimCapteurCouleur, true);
            Actionneur.BrasLunaire.AttraperModuleEtTransferer();
            Actionneur.Convoyeur.AvaleModule();
            Actionneur.Stockeur.RelacheBas();
            Actionneur.Ejecteur.PositionnerCouleur();
            Actionneur.Stockeur.BloqueBas();
            Actionneur.Ejecteur.Ejecter();
        }

        private void btnStockModule_Click(object sender, EventArgs e)
        {
            switch (BrasActuel)
            {
                case BrasLunaireID.Central:
                    Actionneur.BrasLunaire.MonterStockage();
                    break;
                case BrasLunaireID.Droite:
                    Actionneur.BrasLunaireDroite.Monter();
                    break;
                case BrasLunaireID.Gauche:
                    Actionneur.BrasLunaireGauche.Monter();
                    break;
            }
        }

        private void btnVideTout_Click(object sender, EventArgs e)
        {
            Actionneur.Ejecteur.Ejecter();
            Thread.Sleep(500);
            Actionneur.Stockeur.RelacheBas();
            Thread.Sleep(500);
            Actionneur.Ejecteur.Ejecter();
            Thread.Sleep(500);
            Actionneur.Stockeur.RelacheHaut();
            Thread.Sleep(500);
            Actionneur.Ejecteur.Ejecter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(zAvantArriere));
            ThreadPool.QueueUserWorkItem(new WaitCallback(zOuvreFerme));
        }

        private void zAvantArriere(object useless)
        {
            while(true)
            {
                Robots.GrosRobot.Avancer(400);
                Robots.GrosRobot.Reculer(400);
            }
        }
        private void zOuvreFerme(object useless)
        {
            while (true)
            {
                Robots.GrosRobot.RangerActionneurs();
                Thread.Sleep(750);
                Robots.GrosRobot.DeployerActionnneurs();
                Thread.Sleep(750);
            }
        }
    }
}
