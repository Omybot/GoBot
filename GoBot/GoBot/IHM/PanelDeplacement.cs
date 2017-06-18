using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actions;
using System.Threading;
using GoBot.Calculs;
using GoBot.Calculs.Formes;

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
        }

        public virtual void Init()
        {
            // Charger la config

            if (Robot == Robots.GrosRobot)
            {
                trackBarVitesseLigne.SetValue(Config.CurrentConfig.ConfigRapide.LineSpeed, false);
                trackBarAccelLigne.SetValue(Config.CurrentConfig.ConfigRapide.LineAcceleration, false);
                trackBarAccelerationFinLigne.SetValue(Config.CurrentConfig.ConfigRapide.LineDeceleration, false);
                trackBarVitessePivot.SetValue(Config.CurrentConfig.ConfigRapide.PivotSpeed, false);
                trackBarAccelPivot.SetValue(Config.CurrentConfig.ConfigRapide.PivotAcceleration, false);

                numCoeffP.Value = Config.CurrentConfig.GRCoeffP;
                numCoeffI.Value = Config.CurrentConfig.GRCoeffI;
                numCoeffD.Value = Config.CurrentConfig.GRCoeffD;
                Robot.EnvoyerPID(Config.CurrentConfig.GRCoeffP, Config.CurrentConfig.GRCoeffI, Config.CurrentConfig.GRCoeffD);

                groupBoxDep.Deployer(Config.CurrentConfig.DeplacementGROuvert, false);
            }
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
            Virage_Click(SensAR.Avant, SensGD.Droite);
        }

        protected virtual void btnVirageAvGa_Click(object sender, EventArgs e)
        {
            Virage_Click(SensAR.Avant, SensGD.Gauche);
        }

        protected virtual void btnVirageArGa_Click(object sender, EventArgs e)
        {
            Virage_Click(SensAR.Arriere, SensGD.Gauche);
        }

        protected virtual void btnVirageArDr_Click(object sender, EventArgs e)
        {
            Virage_Click(SensAR.Arriere, SensGD.Droite);
        }

        protected void Virage_Click(SensAR sensAr, SensGD sensGd)
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
                Robot.Virage(sensAr, sensGd, distance, angle, false);
        }

        #region Vitesse ligne

        protected virtual void trackBarVitesseLigne_TickValueChanged(object sender, EventArgs e)
        {
            Robot.SpeedConfig.LineSpeed = (int)trackBarVitesseLigne.Value;
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
            Robot.SpeedConfig.LineAcceleration = (int)trackBarAccelLigne.Value;
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
            Robot.SpeedConfig.PivotSpeed = (int)trackBarVitessePivot.Value;
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
            Robot.SpeedConfig.PivotAcceleration = (int)trackBarAccelPivot.Value;
            Robot.SpeedConfig.PivotDeceleration = (int)trackBarAccelPivot.Value;
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
                Robot.PivotGauche(90, false);
            }
            else if (e.KeyCode == Keys.Right)
            {
                // Pivot droit
                Robot.PivotDroite(90, false);
            }
        }

        private void btnRecallage_Click(object sender, EventArgs e)
        {
            Robot.Avancer(10);
            Robot.Lent();
            Robot.Recallage(SensAR.Arriere);
            Robot.Rapide();
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

        private void btnGoCoordonnees_Click(object sender, EventArgs e)
        {
            thGoto = new Thread(ThreadGoTo);
            thGoto.Start();
        }

        Thread thGoto;
        private void ThreadGoTo()
        {
            Robot.GotoXYTeta(new Position((double)numTeta.Value, new PointReel((double)numX.Value, (double)numY.Value)));
        }

        private void btnLent_Click(object sender, EventArgs e)
        {
            Robot.Lent();
        }

        private void btnRapide_Click(object sender, EventArgs e)
        {
            Robot.Rapide();
        }

        private void trackBarAccelerationFinLigne_TickValueChanged(object sender, EventArgs e)
        {
            Robot.SpeedConfig.LineDeceleration = (int)trackBarAccelerationFinLigne.Value;
        }

        private void trackBarAccelerationFinLigne_ValueChanged(object sender, EventArgs e)
        {
            numAccelerationFinLigne.Value = (int)trackBarAccelerationFinLigne.Value;
        }

        private void numAccelerationFinLigne_ValueChanged(object sender, EventArgs e)
        {
            if (numAccelerationFinLigne.Focused)
                trackBarAccelerationFinLigne.SetValue((double)numAccelerationFinLigne.Value);
        }

        private void btnPIDPol_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.EnvoyerPIDCap((int)numCoeffP.Value, (int)numCoeffI.Value, (int)numCoeffD.Value);
        }

        private void btnPIDVit_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.EnvoyerPIDVitesse((int)numCoeffP.Value, (int)numCoeffI.Value, (int)numCoeffD.Value);
        }
    }
}
