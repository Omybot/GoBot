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
    public partial class PanelPetitRobotUtilisation : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelPetitRobotUtilisation()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            tailleMax = groupBoxUtil.Height;
            tailleMin = 39;
        }

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupBoxUtil.Height == tailleMax)
                Deployer(false);
            else
                Deployer(true);
        }

        public virtual void Deployer(bool deployer)
        {
            if (!deployer)
            {
                foreach (Control c in groupBoxUtil.Controls)
                    c.Visible = false;

                btnTaille.Visible = true;
                groupBoxUtil.Height = tailleMin;
                btnTaille.Image = Properties.Resources.Bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupBoxUtil.Controls)
                    c.Visible = true;

                groupBoxUtil.Height = tailleMax;
                btnTaille.Image = Properties.Resources.Haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }

            Config.CurrentConfig.UtilisationPROuvert = deployer;
        }

        private void PanelUtilGros_Load(object sender, EventArgs e)
        {
            Deployer(Config.CurrentConfig.UtilisationPROuvert);
            switchBoutonPuissance.SetActif(true, false);
        }

        private void switchBoutonPuissance_ChangementEtat(object sender, EventArgs e)
        {
            Robots.PetitRobot.AlimentationPuissance(switchBoutonPuissance.Actif);
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.Diagnostic();
        }
    }
}
