using System;
using System.Windows.Forms;

using Geometry;
using Geometry.Shapes;
using GoBot.Threading;

namespace GoBot.IHM
{
    public partial class PanelDisplacement : UserControl
    {
        private ToolTip tooltip;

        public Robot Robot { get; set; }

        public PanelDisplacement()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            tooltip.SetToolTip(btnForward, "Avancer");
            tooltip.SetToolTip(btnBackward, "Reculer");
            tooltip.SetToolTip(btnPivotRight, "Pivoter vers la droite");
            tooltip.SetToolTip(btnPivotLeft, "Pivoter vers la gauche");
            tooltip.SetToolTip(btnTurnBackwardRight, "Virage vers l'arrière droite");
            tooltip.SetToolTip(btnTurnForwardRight, "Virage vers l'avant droite");
            tooltip.SetToolTip(btnTurnBackwardLeft, "Virage vers l'arrière gauche");
            tooltip.SetToolTip(btnTurnForwardLeft, "Virage vers l'avant droite");
            tooltip.SetToolTip(btnStop, "Stop");
        }

        public virtual void Init()
        {
            // Charger la config

            if (Robot == Robots.MainRobot)
            {
                trkLineSpeed.SetValue(Config.CurrentConfig.ConfigRapide.LineSpeed, false);
                trkLineAccel.SetValue(Config.CurrentConfig.ConfigRapide.LineAcceleration, false);
                trkLineDecel.SetValue(Config.CurrentConfig.ConfigRapide.LineDeceleration, false);
                trkPivotSpeed.SetValue(Config.CurrentConfig.ConfigRapide.PivotSpeed, false);
                trkPivotAccel.SetValue(Config.CurrentConfig.ConfigRapide.PivotAcceleration, false);

                numCoeffP.Value = Config.CurrentConfig.GRCoeffP;
                numCoeffI.Value = Config.CurrentConfig.GRCoeffI;
                numCoeffD.Value = Config.CurrentConfig.GRCoeffD;
                Robot.SendPID(Config.CurrentConfig.GRCoeffP, Config.CurrentConfig.GRCoeffI, Config.CurrentConfig.GRCoeffD);
            }
        }

        #region Boutons pilotage

        protected virtual void btnForward_Click(object sender, EventArgs e)
        {
            int distance;
            if (!(Int32.TryParse(txtDistance.Text, out distance) && distance != 0))
                txtDistance.ErrorMode = true;
            else
                Robot.MoveForward(distance, false);
        }

        protected virtual void btnBackward_Click(object sender, EventArgs e)
        {
            int distance;
            if (!(Int32.TryParse(txtDistance.Text, out distance) && distance != 0))
                txtDistance.ErrorMode = true;
            else
                Robot.MoveBackward(distance, false);
        }

        protected virtual void btnPivotLeft_Click(object sender, EventArgs e)
        {
            int angle;
            if (!(Int32.TryParse(txtAngle.Text, out angle) && angle != 0))
                txtAngle.ErrorMode = true;
            else
                Robot.PivotLeft(angle, false);
        }

        protected virtual void btnPivotRight_Click(object sender, EventArgs e)
        {
            int angle;
            if (!(Int32.TryParse(txtAngle.Text, out angle) && angle != 0))
                txtAngle.ErrorMode = true;
            else
                Robot.PivotRight(angle, false);
        }

        protected virtual void btnTurnForwardRight_Click(object sender, EventArgs e)
        {
            DoTurn(SensAR.Avant, SensGD.Droite);
        }

        protected virtual void btnTurnForwardLeft_Click(object sender, EventArgs e)
        {
            DoTurn(SensAR.Avant, SensGD.Gauche);
        }

        protected virtual void btnTurnBackwardLeft_Click(object sender, EventArgs e)
        {
            DoTurn(SensAR.Arriere, SensGD.Gauche);
        }

        protected virtual void btnTurnBackwardRight_Click(object sender, EventArgs e)
        {
            DoTurn(SensAR.Arriere, SensGD.Droite);
        }

        protected void DoTurn(SensAR sensAr, SensGD sensGd)
        {
            int distance;
            int angle;

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
                Robot.Turn(sensAr, sensGd, distance, angle, false);
        }

        protected virtual void btnStopSmooth_Click(object sender, EventArgs e)
        {
            if (freelyToolStripMenuItem.Checked)
                Robot.Stop(StopMode.Freely);
            else if (smoothToolStripMenuItem.Checked)
                Robot.Stop(StopMode.Smooth);
            else if (abruptToolStripMenuItem.Checked)
                Robot.Stop(StopMode.Abrupt);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            freelyToolStripMenuItem.Checked = false;
            smoothToolStripMenuItem.Checked = false;
            abruptToolStripMenuItem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;

            btnStop.PerformClick();
        }

        #endregion

        #region Vitesse ligne

        protected virtual void trkLineSpeed_TickValueChanged(object sender, double value)
        {
            Robot.SpeedConfig.LineSpeed = (int)value;
        }

        private void trkLineSpeed_ValueChanged(object sender, double value)
        {
            numLineSpeed.Value = (int)value;
        }

        private void numLineSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (numLineSpeed.Focused)
                trkLineSpeed.SetValue((double)numLineSpeed.Value);
        }

        #endregion

        #region Accélération ligne

        protected virtual void trkLineAccel_TickValueChanged(object sender, double value)
        {
            Robot.SpeedConfig.LineAcceleration = (int)value;
        }

        private void trkLineAccel_ValueChanged(object sender, double value)
        {
            numLineAccel.Value = (int)value;
        }

        private void numLineAccel_ValueChanged(object sender, EventArgs e)
        {
            if (numLineAccel.Focused)
                trkLineAccel.SetValue((double)numLineAccel.Value);
        }

        #endregion

        #region Décélération ligne

        private void trkLineDecel_TickValueChanged(object sender, double value)
        {
            Robot.SpeedConfig.LineDeceleration = (int)value;
        }

        private void trkLineDecel_ValueChanged(object sender, double value)
        {
            numLineDecel.Value = (int)value;
        }

        private void numLineDecel_ValueChanged(object sender, EventArgs e)
        {
            if (numLineDecel.Focused)
                trkLineDecel.SetValue((double)numLineDecel.Value);
        }

        #endregion

        #region Vitesse pivot

        private void trkPivotSpeed_TickValueChanged(object sender, double value)
        {
            Robot.SpeedConfig.PivotSpeed = (int)value;
        }

        private void trkPivotSpeed_ValueChanged(object sender, double value)
        {
            numPivotSpeed.Value = (int)value;
        }

        private void numPivotSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (numPivotSpeed.Focused)
                trkPivotSpeed.SetValue((double)numPivotSpeed.Value);
        }

        #endregion

        #region Acceleration pivot

        private void trkPivotAccel_TickValueChanged(object sender, double value)
        {
            Robot.SpeedConfig.PivotAcceleration = (int)value;
            Robot.SpeedConfig.PivotDeceleration = (int)value;
        }

        private void trkPivotAccel_ValueChanged(object sender, double value)
        {
            numPivotAccel.Value = (int)value;
        }

        private void numPivotAccel_ValueChanged(object sender, EventArgs e)
        {
            if (numPivotAccel.Focused)
                trkPivotAccel.SetValue((double)numPivotAccel.Value);
        }

        #endregion

        #region Pilotage manuel

        protected virtual void pnlManual_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                Robot.Stop();
        }

        protected virtual void pnlManual_KeyPressed(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // Reculer
                Robot.MoveBackward(10000, false);
            }
            else if (e.KeyCode == Keys.Up)
            {
                // Avancer
                Robot.MoveForward(10000, false);
            }
            else if (e.KeyCode == Keys.Left)
            {
                // Pivot gauche
                Robot.PivotLeft(90, false);
            }
            else if (e.KeyCode == Keys.Right)
            {
                // Pivot droit
                Robot.PivotRight(90, false);
            }
        }

        #endregion

        private void btnCalibration_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(link =>
            {
                btnCalibration.InvokeAuto(() => btnCalibration.Enabled = false);
                Robot.MoveForward(10);
                Robot.SetSpeedSlow();
                Robot.Recalibration(SensAR.Arriere);
                Robot.SetSpeedFast();
                btnCalibration.InvokeAuto(() => btnCalibration.Enabled = true);
            }).StartThread();
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            ThreadManager.CreateThread(link => ThreadGoTo(link)).StartThread();
        }

        private void ThreadGoTo(ThreadLink link)
        {
            link.RegisterName();
            Robot.GoToPosition(new Position((double)numTeta.Value, new RealPoint((double)numX.Value, (double)numY.Value)));
        }

        private void btnLow_Click(object sender, EventArgs e)
        {
            Robot.SetSpeedSlow();
            trkLineSpeed.SetValue(Robot.SpeedConfig.LineSpeed, false);
            trkLineAccel.SetValue(Robot.SpeedConfig.LineAcceleration, false);
            trkLineDecel.SetValue(Robot.SpeedConfig.LineDeceleration, false);
            trkPivotSpeed.SetValue(Robot.SpeedConfig.LineSpeed, false);
            trkPivotAccel.SetValue(Robot.SpeedConfig.LineSpeed, false);
        }

        private void btnFast_Click(object sender, EventArgs e)
        {
            Robot.SetSpeedFast();
            trkLineSpeed.SetValue(Robot.SpeedConfig.LineSpeed, false);
            trkLineAccel.SetValue(Robot.SpeedConfig.LineAcceleration, false);
            trkLineDecel.SetValue(Robot.SpeedConfig.LineDeceleration, false);
            trkPivotSpeed.SetValue(Robot.SpeedConfig.PivotSpeed, false);
            trkPivotAccel.SetValue(Robot.SpeedConfig.PivotAcceleration, false);
        }

        private void numCoeffPID_ValueChanged(object sender, EventArgs e)
        {
            btnPIDXY.Enabled = true;
        }

        private void btnPIDPol_Click(object sender, EventArgs e)
        {
            Robots.MainRobot.SendPIDCap((int)numCoeffP.Value, (int)numCoeffI.Value, (int)numCoeffD.Value);
        }

        private void btnPIDVit_Click(object sender, EventArgs e)
        {
            Robots.MainRobot.SendPIDSpeed((int)numCoeffP.Value, (int)numCoeffI.Value, (int)numCoeffD.Value);
        }

        private void btnPIDXY_Click(object sender, EventArgs e)
        {
            Robot.SendPID((int)numCoeffP.Value, (int)numCoeffI.Value, (int)numCoeffD.Value);

            if (Robot == Robots.MainRobot)
            {
                Config.CurrentConfig.GRCoeffP = (int)numCoeffP.Value;
                Config.CurrentConfig.GRCoeffI = (int)numCoeffI.Value;
                Config.CurrentConfig.GRCoeffD = (int)numCoeffD.Value;
                Config.Save();
            }

            btnPIDXY.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    Robot.Move(800);
            //    Robot.PivotLeft(360);
            //    Robot.Move(-800);
            //    Console.WriteLine(Robot.Position.Angle);
            //    Robot.Pivot(new AngleDelta(Robot.Position.Angle));
            for (int i = 0; i < 10; i++)
            {
                Robot.PivotRight(360);
            }
        }
    }
}
