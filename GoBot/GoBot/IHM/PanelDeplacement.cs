using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actions;

namespace GoBot.IHM
{
    public partial class PanelDeplacement : UserControl
    {
        private ToolTip tooltip;
        private int tailleMax;
        private int tailleMin;

        public Robot Robot { get; set; }

        public PanelDeplacement()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            tailleMax = groupDeplacement.Height;
            tailleMin = 39;

            tooltip.SetToolTip(btnAvance, "Avancer");
            tooltip.SetToolTip(btnRecule, "Reculer");
            tooltip.SetToolTip(btnPivotDroite, "Pivoter vers la droite");
            tooltip.SetToolTip(btnPivotGauche, "Pivoter vers la gauche");
            tooltip.SetToolTip(btnVirageArDr, "Virage vers l'arrière droite");
            tooltip.SetToolTip(btnVirageAvDr, "Virage vers l'avant droite");
            tooltip.SetToolTip(btnVirageArGa, "Virage vers l'arrière gauche");
            tooltip.SetToolTip(btnVirageAvGa, "Virage vers l'avant droite");
            tooltip.SetToolTip(btnStopSmooth, "Stop (et active l'asserv)");
            tooltip.SetToolTip(btnStopFreely, "Stop (et coupe l'asserv)");
        }

        public virtual void Init()
        {
            // Charger la config

            if (Robot == Robots.GrosRobot)
            {
                trackBarVitesseLigne.SetValue(Config.CurrentConfig.GRVitesseLigneRapide);
                trackBarAccelLigne.SetValue(Config.CurrentConfig.GRAccelerationLigneRapide);
                trackBarVitessePivot.SetValue(Config.CurrentConfig.GRVitessePivotRapide);
                trackBarAccelPivot.SetValue(Config.CurrentConfig.GRAccelerationPivotRapide);

                numCoeffP.Value = Config.CurrentConfig.GRCoeffP;
                numCoeffI.Value = Config.CurrentConfig.GRCoeffI;
                numCoeffD.Value = Config.CurrentConfig.GRCoeffD;
                Robot.EnvoyerPID(Config.CurrentConfig.GRCoeffP, Config.CurrentConfig.GRCoeffI, Config.CurrentConfig.GRCoeffD);

                Deployer(Config.CurrentConfig.DeplacementGROuvert);
            }
            else
            {
                trackBarVitesseLigne.SetValue(Config.CurrentConfig.PRVitesseLigneRapide);
                trackBarAccelLigne.SetValue(Config.CurrentConfig.PRAccelerationLigneRapide);
                trackBarVitessePivot.SetValue(Config.CurrentConfig.PRVitessePivotRapide);
                trackBarAccelPivot.SetValue(Config.CurrentConfig.PRAccelerationPivotRapide);

                numCoeffP.Value = Config.CurrentConfig.PRCoeffP;
                numCoeffI.Value = Config.CurrentConfig.PRCoeffI;
                numCoeffD.Value = Config.CurrentConfig.PRCoeffD;
                Robot.EnvoyerPID(Config.CurrentConfig.PRCoeffP, Config.CurrentConfig.PRCoeffI, Config.CurrentConfig.PRCoeffD);

                Deployer(Config.CurrentConfig.DeplacementPROuvert);
            }

            Robot.Rapide();
        }

        protected virtual void btnAvance_Click(object sender, EventArgs e)
        {
            int distance;
            if (!(Int32.TryParse(txtDistance.Text, out distance) && distance != 0))
                txtDistance.ErrorMode = true;
            else
                Robot.Avancer(distance, false);
        }

        protected virtual void btnRecule_Click(object sender, EventArgs e)
        {
            int distance;
            if (!(Int32.TryParse(txtDistance.Text, out distance) && distance != 0))
                txtDistance.ErrorMode = true;
            else
                Robot.Reculer(distance, false);
        }

        protected virtual void btnPivotGauche_Click(object sender, EventArgs e)
        {
            int angle;
            if (!(Int32.TryParse(txtAngle.Text, out angle) && angle != 0))
                txtAngle.ErrorMode = true;
            else
                Robot.PivotGauche(angle, false);
        }

        protected virtual void btnPivotDroite_Click(object sender, EventArgs e)
        {
            int angle;
            if (!(Int32.TryParse(txtAngle.Text, out angle) && angle != 0))
                txtAngle.ErrorMode = true;
            else
                Robot.PivotDroite(angle, false);
        }

        protected virtual void btnVirageAvDr_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            bool ok = true;
            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
            {
                txtDistance.ErrorMode = true;
                ok = false;
            }
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
            {
                txtAngle.ErrorMode = true;
                ok = false;
            }

            if (ok)
                Robot.Virage(SensAR.Avant, SensGD.Droite, distance, angle, false);
        }

        protected virtual void btnVirageAvGa_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            bool ok = true;
            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
            {
                txtDistance.ErrorMode = true;
                ok = false;
            }
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
            {
                txtAngle.ErrorMode = true;
                ok = false;
            }

            if (ok)
                Robot.Virage(SensAR.Avant, SensGD.Gauche, distance, angle, false);
        }

        protected virtual void btnVirageArGa_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            bool ok = true;
            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
            {
                txtDistance.ErrorMode = true;
                ok = false;
            }
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
            {
                txtAngle.ErrorMode = true;
                ok = false;
            }

            if (ok)
                Robot.Virage(SensAR.Arriere, SensGD.Gauche, distance, angle, false);
        }

        protected virtual void btnVirageArDr_Click(object sender, EventArgs e)
        {
            int distance = 0;
            int angle = 0;

            bool ok = true;
            if (!Int32.TryParse(txtDistance.Text, out distance) || distance == 0)
            {
                txtDistance.ErrorMode = true;
                ok = false;
            }
            if (!Int32.TryParse(txtAngle.Text, out angle) || angle == 0)
            {
                txtAngle.ErrorMode = true;
                ok = false;
            }

            if (ok)
                Robot.Virage(SensAR.Arriere, SensGD.Droite, distance, angle, false);
        }

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupDeplacement.Height == tailleMax)
                Deployer(false);
            else
                Deployer(true);
        }

        public virtual void Deployer(bool deployer)
        {
            if (!deployer)
            {
                foreach (Control c in groupDeplacement.Controls)
                    c.Visible = false;

                btnTaille.Visible = true;
                groupDeplacement.Height = tailleMin;
                btnTaille.Image = Properties.Resources.bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                foreach (Control c in groupDeplacement.Controls)
                    c.Visible = true;

                groupDeplacement.Height = tailleMax;
                btnTaille.Image = Properties.Resources.haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }

            if (Robot == Robots.GrosRobot)
                Config.CurrentConfig.DeplacementGROuvert = deployer;
            else
                Config.CurrentConfig.DeplacementPROuvert = deployer;
        }

        #region Vitesse ligne

        protected virtual void trackBarVitesseLigne_TickValueChanged()
        {
            Robot.VitesseDeplacement = (int)trackBarVitesseLigne.Value;
            if (Robot == Robots.GrosRobot)
                Config.CurrentConfig.GRVitesseLigneRapide = (int)trackBarVitesseLigne.Value;
            else
                Config.CurrentConfig.PRVitesseLigneRapide = (int)trackBarVitesseLigne.Value;
        }

        private void trackBarVitesseLigne_ValueChanged()
        {
            numVitesseLigne.Value = (int)trackBarVitesseLigne.Value;
        }

        private void numVitesseLigne_ValueChanged(object sender, EventArgs e)
        {
            if (numVitesseLigne.Focused)
                trackBarVitesseLigne.SetValue((double)numVitesseLigne.Value);
        }

        #endregion

        #region Accélération ligne

        protected virtual void trackBarAccelLigne_TickValueChanged()
        {
            Robot.AccelerationDeplacement = (int)trackBarAccelLigne.Value;
            if (Robot == Robots.GrosRobot)
                Config.CurrentConfig.GRAccelerationLigneRapide = (int)trackBarAccelLigne.Value;
            else
                Config.CurrentConfig.PRAccelerationLigneRapide = (int)trackBarAccelLigne.Value;
        }

        private void trackBarAccelLigne_ValueChanged()
        {
            numAccelLigne.Value = (int)trackBarAccelLigne.Value;
        }

        private void numAccelLigne_ValueChanged(object sender, EventArgs e)
        {
            if (numAccelLigne.Focused)
                trackBarAccelLigne.SetValue((double)numAccelLigne.Value);
        }

        #endregion

        #region Vitesse pivot

        private void trackBarVitessePivot_TickValueChanged()
        {
            Robot.VitessePivot = (int)trackBarVitesseLigne.Value;
            if (Robot == Robots.GrosRobot)
                Config.CurrentConfig.GRVitessePivotRapide = (int)trackBarVitessePivot.Value;
            else
                Config.CurrentConfig.PRVitessePivotRapide = (int)trackBarVitessePivot.Value;
        }

        private void trackBarVitessePivot_ValueChanged()
        {
            numVitessePivot.Value = (int)trackBarVitessePivot.Value;
        }

        private void numVitessePivot_ValueChanged(object sender, EventArgs e)
        {
            if (numVitessePivot.Focused)
                trackBarVitessePivot.SetValue((double)numVitessePivot.Value);
        }

        #endregion

        #region Acceleration pivot

        private void trackBarAccelPivot_TickValueChanged()
        {
            Robot.AccelerationPivot = (int)trackBarAccelLigne.Value;
            if (Robot == Robots.GrosRobot)
                Config.CurrentConfig.GRAccelerationPivotRapide = (int)trackBarAccelLigne.Value;
            else
                Config.CurrentConfig.PRAccelerationPivotRapide = (int)trackBarAccelLigne.Value;
        }

        private void trackBarAccelPivot_ValueChanged()
        {
            numAccelPivot.Value = (int)trackBarAccelPivot.Value;
        }

        private void numAccelPivot_ValueChanged(object sender, EventArgs e)
        {
            if (numAccelPivot.Focused)
                trackBarAccelPivot.SetValue((double)numAccelPivot.Value);
        }

        #endregion

        protected virtual void panelControleManuel_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                Robot.Stop();
        }

        protected virtual void panelControleManuel_ToucheEnfoncee(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // Reculer
                Robot.Reculer(10000, false);
            }
            else if (e.KeyCode == Keys.Up)
            {
                // Avancer
                Robot.Avancer(10000, false);
            }
            else if (e.KeyCode == Keys.Left)
            {
                // Pivot gauche
                Robot.PivotGauche(3600, false);
            }
            else if (e.KeyCode == Keys.Right)
            {
                // Pivot droit
                Robot.PivotDroite(3600, false);
            }
            else if (e.KeyCode == Keys.Add)
            {
                // Augmenter vitesse
                Robot.VitesseDeplacement += 50;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                // Diminuer vitesse
                Robot.VitesseDeplacement -= 50;
            }
        }

        private void btnRecallage_Click(object sender, EventArgs e)
        {
            int vitesseTemp = Robot.VitesseDeplacement;
            int accelerationTemp = Robot.AccelerationDeplacement;
            Robot.VitesseDeplacement = 150;
            Robot.AccelerationDeplacement = 150;
            Robot.Recallage(SensAR.Arriere);
            Robot.VitesseDeplacement = vitesseTemp;
            Robot.AccelerationDeplacement = accelerationTemp;
        }

        private void btnFreely_Click(object sender, EventArgs e)
        {
            Robot.Stop(StopMode.Freely);
        }

        private void btnPID_Click(object sender, EventArgs e)
        {
            Robot.EnvoyerPID((int)numCoeffP.Value, (int)numCoeffI.Value, (int)numCoeffD.Value);

            if (Robot == Robots.GrosRobot)
            {
                Config.CurrentConfig.GRCoeffP = (int)numCoeffP.Value;
                Config.CurrentConfig.GRCoeffI = (int)numCoeffI.Value;
                Config.CurrentConfig.GRCoeffD = (int)numCoeffD.Value;
            }
            else
            {
                Config.CurrentConfig.PRCoeffP = (int)numCoeffP.Value;
                Config.CurrentConfig.PRCoeffI = (int)numCoeffI.Value;
                Config.CurrentConfig.PRCoeffD = (int)numCoeffD.Value;
            }

            btnPID.Enabled = false;
        }

        private void numCoeffPID_ValueChanged(object sender, EventArgs e)
        {
            btnPID.Enabled = true;
        }

        protected virtual void btnStopSmooth_Click(object sender, EventArgs e)
        {
            Robot.Stop(StopMode.Smooth);
        }

        private void btnStopFreely_Click(object sender, EventArgs e)
        {
            Robot.Stop(StopMode.Freely);
        }
    }
}
