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
    public partial class PanelPetitRobotReglage : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelPetitRobotReglage()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            tailleMax = groupBoxReglage.Height;
            tailleMin = 39;
        }

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupBoxReglage.Height == tailleMax)
                Deployer(false);
            else
                Deployer(true);
        }

        public virtual void Deployer(bool deployer)
        {
            if (!deployer)
            {
                foreach (Control c in groupBoxReglage.Controls)
                    c.Visible = false;

                btnTaille.Visible = true;
                groupBoxReglage.Height = tailleMin;
                btnTaille.Image = Properties.Resources.Bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupBoxReglage.Controls)
                    c.Visible = true;

                groupBoxReglage.Height = tailleMax;
                btnTaille.Image = Properties.Resources.Haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }

            Config.CurrentConfig.ReglagePROuvert = deployer;
        }

        private void PanelPetitRobotReglage_Load(object sender, EventArgs e)
        {
            Deployer(Config.CurrentConfig.ReglagePROuvert);
        }


        private void btnOkFilet_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.TourneMoteur(MoteurID.PRLanceFilet, (int)numTirFilet.Value);
        }

        private void btnFiletTir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes vous sûr de vouloir sauvegarder la position comme étant la position de tir ?", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRFiletTir = (int)numTirFilet.Value;
        }

        private void btnFiletArme_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes vous sûr de vouloir sauvegarder la position comme étant la position armée ?", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRFiletArme = (int)numTirFilet.Value;
        }

        private void trackBarReservoir_ValueChanged(object sender, EventArgs e)
        {
            lblPositionReservoir.Text = trackBarReservoir.Value.ToString();
        }

        private void trackBarReservoir_TickValueChanged(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBacBouchons, (int)trackBarReservoir.Value);
        }

        private void trackBarBrasFresque_ValueChanged(object sender, EventArgs e)
        {
            lblBrasFresque.Text = trackBarBrasFresque.Value.ToString();
        }

        private void trackBarBrasFresque_TickValueChanged(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRFresque, (int)trackBarReservoir.Value);
        }

        private void trackBarTensionTissu_ValueChanged(object sender, EventArgs e)
        {
            lblTensionTissu.Text = trackBarTensionTissu.Value.ToString();
        }

        private void trackBarTensionTissu_TickValueChanged(object sender, EventArgs e)
        {
            Robots.PetitRobot.TourneMoteur(MoteurID.PRTensionTissu, (int)trackBarTensionTissu.Value);
        }

        private void btnRideauRelache_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes vous sûr de vouloir sauvegarder la position comme étant la position lâche ?", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PRTensionTissuRelache = (int)trackBarTensionTissu.Value;
        }

        private void btnRideauTendu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes vous sûr de vouloir sauvegarder la position comme étant la position tendue ?", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PRTensionTissuTendu = (int)trackBarTensionTissu.Value;
        }
    }
}
