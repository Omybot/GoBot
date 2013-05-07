using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using UDP;

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
                btnTaille.Image = Properties.Resources.bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupBoxReglage.Controls)
                    c.Visible = true;

                groupBoxReglage.Height = tailleMax;
                btnTaille.Image = Properties.Resources.haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }

            Config.CurrentConfig.ReglagePROuvert = deployer;
        }

        #region BrasGauche
        private void btnBrasGaucheOk_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasGauche, (int)numBrasGauche.Value);
        }

        private void btnBrasGaucheHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haute du bras gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasGaucheHaut = (int)numBrasGauche.Value;
        }

        private void btnBrasGaucheBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du bras gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasGaucheBas = (int)numBrasGauche.Value;
        }

        private void btnBrasGaucheRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée du bras gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasGaucheRange = (int)numBrasGauche.Value;
        }
        #endregion

        #region BrasDroit
        private void btnBrasDroitOk_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasDroit, (int)numBrasDroit.Value);
        }

        private void btnBrasDroitHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haute du bras droit ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasDroiteHaut = (int)numBrasDroit.Value;
        }

        private void btnBrasDroitBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du bras droit ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasDroiteBas = (int)numBrasDroit.Value;
        }

        private void btnBrasDroitRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée du bras droit ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasDroiteRange = (int)numBrasDroit.Value;
        }
        #endregion

        #region BrasAvant
        private void btnAvantOk_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvant, (int)numAvant.Value);
        }

        private void btnAvantHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haute du bras avant ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasAvantHaut = (int)numAvant.Value;
        }

        private void btnAvantBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du bras avant ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasAvantBas = (int)numAvant.Value;
        }

        private void btnAvantRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée du bras avant ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasAvantRange = (int)numAvant.Value;
        }

        private void btnAvantAssiette_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position assiette du bras avant ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasAvantAssiette = (int)numAvant.Value;
        }
        #endregion


        #region BrasArriere
        private void btnArriereOk_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriere, (int)numArriere.Value);
        }

        private void btnArriereHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haute du bras arriere ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasArriereHaut = (int)numArriere.Value;
        }

        private void btnArriereBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du bras arriere ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasArriereBas = (int)numArriere.Value;
        }

        private void btnArriereRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée du bras arriere ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasArriereRange = (int)numArriere.Value;
        }

        private void btnArriereAssiette_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position assiette du bras arriere ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasArriereAssiette = (int)numArriere.Value;
        }
        #endregion


        #region AvantGauche
        private void btnAvGaOk_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantGauche, (int)numAvGa.Value);
        }

        private void btnAvGaHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haut du bras avant gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasAvantGaucheHaut = (int)numAvGa.Value;
        }

        private void btnAvGaBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du bras avant gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasAvantGaucheBas = (int)numAvGa.Value;
        }
        #endregion

        #region AvantDroite
        private void btnAvDrOk_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasAvantDroit, (int)numAvDr.Value);
        }

        private void btnAvDrHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haut du bras avant droit ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasAvantDroitHaut = (int)numAvDr.Value;
        }

        private void btnAvDrBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du bras avant droit ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasAvantDroitBas = (int)numAvDr.Value;
        }
        #endregion

        #region ArriereGauche
        private void btnArGaOk_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereGauche, (int)numArGa.Value);
        }

        private void btnArGaHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haut du bras arriere gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasArriereGaucheHaut = (int)numArGa.Value;
        }

        private void btnArGaBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du bras arriere gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasArriereGaucheBas = (int)numArGa.Value;
        }
        #endregion

        #region ArriereDroit
        private void btnArDrOk_Click(object sender, EventArgs e)
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRBrasArriereDroit, (int)numArDr.Value);
        }

        private void btnArDrHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haut du bras arriere droit ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasArriereDroitHaut = (int)numArDr.Value;
        }

        private void btnArDrBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du bras arriere droit ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionPRBrasArriereDroitBas = (int)numArDr.Value;
        }
        #endregion

        private void PanelPetitRobotReglage_Load(object sender, EventArgs e)
        {
            Deployer(Config.CurrentConfig.ReglagePROuvert);
        }
    }
}
