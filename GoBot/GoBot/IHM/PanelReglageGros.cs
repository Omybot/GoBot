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
    public partial class PanelReglageGros : UserControl
    {
        private ToolTip tooltip;
        int tailleMax;
        int tailleMin;

        public PanelReglageGros()
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

            Config.CurrentConfig.ReglageGROuvert = deployer;
        }

        #region Aspiration
        private void btnTurbineOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.AspirerVitesse((int)numTurbine.Value);
        }

        private void btnTurbineSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la vitesse d'aspiration ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.VitesseAspiration = (int)numTurbine.Value;
        }
        #endregion

        #region Canon
        private void btnCanonOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.CanonVitesse((int)numCanon.Value);
        }

        private void btnCanonSaveBonne_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la vitesse de propulsion des cerises blanches ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.VitessePropulsionBonne = (int)numCanon.Value;
        }

        private void btnCanonSaveMauvaise_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la vitesse de propulsion des cerises de couleur ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.VitessePropulsionMauvaise = (int)numCanon.Value;
        }
        #endregion

        #region Shutter
        private void btnShutterOn_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.Shutter(true);
        }

        private void btnShutterOff_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.Shutter(false);
        }

        private void btnShutterOuvrir_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.Shutter(true);
            Thread.Sleep((int)numShutter.Value);
            Robots.GrosRobot.Shutter(false);
        }
        #endregion

        #region Aspirateur
        private void btnAspirateurOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, (int)numAspirateur.Value);
        }

        private void btnAspirateurHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haute de l'aspirateur ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRAspirateurHaut = (int)numAspirateur.Value;
        }

        private void btnAspirateurBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse de l'aspirateur ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRAspirateurBas = (int)numAspirateur.Value;
        }
        #endregion

        #region Débloqueur
        private void btnDebloqueurOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRDebloqueur, (int)numDebloqueur.Value);
        }

        private void btnDebloqueurHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haute du débloqueur ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRDebloqueurHaut = (int)numDebloqueur.Value;
        }

        private void btnDebloqueurBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du débloqueur ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRDebloqueurBas = (int)numDebloqueur.Value;
        }
        #endregion

        #region GrandBras
        private void btnGrandBrasOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, (int)numGrandBras.Value);
        }

        private void btnGrandBrasHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haute du grand bras ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRGrandBrasHaut = (int)numGrandBras.Value;
        }

        private void btnGrandBrasBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du grand bras ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRGrandBrasBas = (int)numGrandBras.Value;
        }

        private void btnGrandBrasRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée du grand bras ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRGrandBrasRange = (int)numGrandBras.Value;
        }
        #endregion
        
        #region PetitBras
        private void btnPetitBrasOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRPetitBras, (int)numPetitBras.Value);
        }

        private void btnPetitBrasHaut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position haute du petit bras ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPetitBrasHaut = (int)numPetitBras.Value;
        }

        private void btnPetitBrasBas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position basse du petit bras ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPetitBrasBas = (int)numPetitBras.Value;
        }

        private void btnPetitBrasRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée du petit bras ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRPetitBrasRange = (int)numPetitBras.Value;
        }
        #endregion

        #region BrasGauche
        private void btnBrasGaucheOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasGauche, (int)numBrasGauche.Value);
        }

        private void btnBrasGaucheSorti_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position sortie du bras gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRBrasGaucheSorti = (int)numBrasGauche.Value;
        }

        private void btnBrasGaucheRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée du bras gauche ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRBrasGaucheRange = (int)numBrasGauche.Value;
        }
        #endregion

        #region BrasDroit
        private void btnBrasDroitOk_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasDroit, (int)numBrasDroit.Value);
        }

        private void btnBrasDroitSorti_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position sortie du bras droit ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRBrasDroitSorti = (int)numBrasDroit.Value;
        }

        private void btnBrasDroitRange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rangée du bras droit ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRBrasDroitRange = (int)numBrasDroit.Value;
        }
        #endregion

        #region Camera
        private void btnCameraOK_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.BougeServo(ServomoteurID.GRCamera, (int)numCamera.Value);
        }

        private void btnCameraRouge_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position rouge de la caméra ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRCameraRouge = (int)numCamera.Value;
        }
        private void btnCameraBleu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Enregistrer cette valeur pour la position bleue de la caméra ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Config.CurrentConfig.PositionGRCameraBleu = (int)numCamera.Value;
        }
        #endregion

        private void PanelReglageGros_Load(object sender, EventArgs e)
        {
            Deployer(Config.CurrentConfig.ReglageGROuvert);
        }
    }
}
