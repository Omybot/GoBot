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

        private void switchBoutonPinceDroite_ChangementEtat(object sender, EventArgs e)
        {
            if (switchBoutonPinceDroite.Actif)
                BrasPiedsDroite.FermerPince();
            else
                BrasPiedsDroite.OuvrirPince();
        }

        private void switchBoutonAscenseurDroite_ChangementEtat(object sender, EventArgs e)
        {
            if (switchBoutonAscenseurDroite.Actif)
                BrasPiedsDroite.MonterBras();
            else
                BrasPiedsDroite.DescendreBras();
        }
    }
}
