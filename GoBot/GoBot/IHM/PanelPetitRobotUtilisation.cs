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
                btnTaille.Image = Properties.Resources.bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupBoxUtil.Controls)
                    c.Visible = true;

                groupBoxUtil.Height = tailleMax;
                btnTaille.Image = Properties.Resources.haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }

            Config.CurrentConfig.UtilisationPROuvert = deployer;
        }
        private void PanelUtilGros_Load(object sender, EventArgs e)
        {
            Deployer(Config.CurrentConfig.UtilisationPROuvert);
            switchBoutonPuissance.SetActif(true, false);
        }

        private void switchBoutonPuissance_ChangementEtat(bool actif)
        {
            Robots.PetitRobot.AlimentationPuissance(actif);
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.Diagnostic();
        }

        #region BrasAvant
        private void btnAvantHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvant, Config.CurrentConfig.PositionPRBrasAvantHaut);
        }

        private void btnAvantBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvant, Config.CurrentConfig.PositionPRBrasAvantBas);
        }

        private void btnAvantAssiette_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvant, Config.CurrentConfig.PositionPRBrasAvantAssiette);
        }

        private void btnAvantRange_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvant, Config.CurrentConfig.PositionPRBrasAvantRange);
        }
        #endregion

        #region BrasArriere
        private void btnArriereHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriere, Config.CurrentConfig.PositionPRBrasArriereHaut);
        }

        private void btnArriereBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriere, Config.CurrentConfig.PositionPRBrasArriereBas);
        }

        private void btnArriereAssiette_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriere, Config.CurrentConfig.PositionPRBrasArriereAssiette);
        }

        private void btnArriereRange_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriere, Config.CurrentConfig.PositionPRBrasArriereRange);
        }
        #endregion

        private void btnAvGaHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheHaut);
        }

        private void btnAvGaBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, Config.CurrentConfig.PositionPRBrasAvantGaucheBas);
        }

        private void btnAvDrHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitHaut);
        }

        private void btnAvDrBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, Config.CurrentConfig.PositionPRBrasAvantDroitBas);
        }

        private void btnArGaHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheHaut);
        }

        private void btnArGaBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, Config.CurrentConfig.PositionPRBrasArriereGaucheBas);
        }

        private void btnArDrHaut_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitHaut);
        }

        private void btnArDrBas_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, Config.CurrentConfig.PositionPRBrasArriereDroitBas);
        }
    }
}
