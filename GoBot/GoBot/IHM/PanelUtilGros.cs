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
    public partial class PanelUtilGros : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelUtilGros()
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

            Config.CurrentConfig.UtilGROuvert = deployer;
        }

        private void btnDebloqueur_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, 250);
            Thread.Sleep(500);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, 550);
        }

        private void btnDescendre_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
        }

        private void btnMonter_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
        }

        private void btnGrandHaut_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasHaut);
        }

        private void btnGrandBas_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasBas);
        }

        private void btnGrandRange_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasRange);
        }

        private void btnPetitHaut_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasHaut);
        }

        private void btnPetitBas_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasBas);
        }

        private void btnPetitRange_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasRange);
        }

        private void btnAspirateurHaut_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);
        }

        private void btnAspirateurBas_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
        }

        private void btnDebloqueurHaut_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurHaut);
        }

        private void btnDebloqueurBas_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, Config.CurrentConfig.PositionGRDebloqueurBas);
        }

        private void btnGrandBrasHaut_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasHaut);
        }

        private void btnGrandBrasBas_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasBas);
        }

        private void btnGrandBrasRange_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasRange);
        }

        private void btnPetitBrasHaut_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasHaut);
        }

        private void btnPetitBrasBas_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasBas);
        }

        private void btnPetitBrasRange_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, Config.CurrentConfig.PositionGRPetitBrasRange);
        }

        private void btnBrasGaucheSorti_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasGauche, Config.CurrentConfig.PositionGRBrasGaucheSorti);
        }

        private void btnBrasGaucheRange_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasGauche, Config.CurrentConfig.PositionGRBrasGaucheRange);
        }

        private void btnBrasDroitSorti_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasDroit, Config.CurrentConfig.PositionGRBrasDroitSorti);
        }

        private void btnBrasDroitRange_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasDroit, Config.CurrentConfig.PositionGRBrasDroitRange);
        }

        private void btnCameraRouge_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRCamera, Config.CurrentConfig.PositionGRCameraRouge);
        }

        private void btnCameraBleu_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRCamera, Config.CurrentConfig.PositionGRCameraBleu);
        }

        private void PanelUtilGros_Load(object sender, EventArgs e)
        {
            Deployer(Config.CurrentConfig.UtilGROuvert);
        }

        private void btnTurbineOn_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, Config.CurrentConfig.VitesseAspiration);
        }

        private void btnTurbineOff_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
        }

        private void btnCanonBonne_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, Config.CurrentConfig.VitessePropulsionBonne);
        }

        private void btnCanonMauvaise_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, Config.CurrentConfig.VitessePropulsionMauvaise);
        }

        private void btnCanonStop_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanon, 0);
        }
    }
}
