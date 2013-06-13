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

        public Robot Robot { get; set; }

        public PanelDeplacement()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            groupBoxDep.DeploiementChange += new Composants.GroupBoxRetractable.DeploiementDelegate(groupBoxDep_Deploiement);

            tooltip.SetToolTip(btnAvance, "Avancer");
            tooltip.SetToolTip(btnRecule, "Reculer");
            tooltip.SetToolTip(btnPivotDroite, "Pivoter vers la droite");
            tooltip.SetToolTip(btnPivotGauche, "Pivoter vers la gauche");
            tooltip.SetToolTip(btnVirageArDr, "Virage vers l'arrière droite");
            tooltip.SetToolTip(btnVirageAvDr, "Virage vers l'avant droite");
            tooltip.SetToolTip(btnVirageArGa, "Virage vers l'arrière gauche");
            tooltip.SetToolTip(btnVirageAvGa, "Virage vers l'avant droite");
            tooltip.SetToolTip(btnStop, "Stop");
        }

        void groupBoxDep_Deploiement(bool deploye)
        {
            if (Robot == Robots.GrosRobot)
                Config.CurrentConfig.DeplacementGROuvert = deploye;
            else
                Config.CurrentConfig.DeplacementPROuvert = deploye;
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

                groupBoxDep.Deployer(Config.CurrentConfig.DeplacementGROuvert, false);
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

                groupBoxDep.Deployer(Config.CurrentConfig.DeplacementPROuvert, false);
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

        #region Vitesse ligne

        protected virtual void trackBarVitesseLigne_TickValueChanged(object sender, EventArgs e)
        {
            Robot.VitesseDeplacement = (int)trackBarVitesseLigne.Value;
            if (Robot == Robots.GrosRobot)
                Config.CurrentConfig.GRVitesseLigneRapide = (int)trackBarVitesseLigne.Value;
            else
                Config.CurrentConfig.PRVitesseLigneRapide = (int)trackBarVitesseLigne.Value;
        }

        private void trackBarVitesseLigne_ValueChanged(object sender, EventArgs e)
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

        protected virtual void trackBarAccelLigne_TickValueChanged(object sender, EventArgs e)
        {
            Robot.AccelerationDeplacement = (int)trackBarAccelLigne.Value;
            if (Robot == Robots.GrosRobot)
                Config.CurrentConfig.GRAccelerationLigneRapide = (int)trackBarAccelLigne.Value;
            else
                Config.CurrentConfig.PRAccelerationLigneRapide = (int)trackBarAccelLigne.Value;
        }

        private void trackBarAccelLigne_ValueChanged(object sender, EventArgs e)
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

        private void trackBarVitessePivot_TickValueChanged(object sender, EventArgs e)
        {
            Robot.VitessePivot = (int)trackBarVitessePivot.Value;
            if (Robot == Robots.GrosRobot)
                Config.CurrentConfig.GRVitessePivotRapide = (int)trackBarVitessePivot.Value;
            else
                Config.CurrentConfig.PRVitessePivotRapide = (int)trackBarVitessePivot.Value;
        }

        private void trackBarVitessePivot_ValueChanged(object sender, EventArgs e)
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

        private void trackBarAccelPivot_TickValueChanged(object sender, EventArgs e)
        {
            Robot.AccelerationPivot = (int)trackBarAccelPivot.Value;
            if (Robot == Robots.GrosRobot)
                Config.CurrentConfig.GRAccelerationPivotRapide = (int)trackBarAccelPivot.Value;
            else
                Config.CurrentConfig.PRAccelerationPivotRapide = (int)trackBarAccelPivot.Value;
        }

        private void trackBarAccelPivot_ValueChanged(object sender, EventArgs e)
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
            if (freelyToolStripMenuItem.Checked)
                Robot.Stop(StopMode.Freely);
            else if (smoothToolStripMenuItem.Checked)
                Robot.Stop(StopMode.Smooth);
            else if(abruptToolStripMenuItem.Checked)
                Robot.Stop(StopMode.Abrupt);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            freelyToolStripMenuItem.Checked = false;
            smoothToolStripMenuItem.Checked = false;
            abruptToolStripMenuItem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
            btnStopSmooth_Click(sender, e);
        }
    }
}
