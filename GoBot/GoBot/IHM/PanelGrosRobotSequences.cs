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
            Actionneur.BrasLunaire.Fermer();
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
            Actionneur.BrasLunaire.Ranger();
        }

        private void btnLunaireSemiOuvert_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.Fermer();
        }

        private void btnLunaireSequence_Click(object sender, EventArgs e)
        {
            Actionneur.BrasLunaire.AttrapageFusee();
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
    }
}
