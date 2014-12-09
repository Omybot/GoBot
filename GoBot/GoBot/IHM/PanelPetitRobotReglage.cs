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
    }
}
