using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

using GoBot.Threading;
using GoBot.Devices.CAN;
using GoBot.Devices;
using System.Linq;

namespace GoBot.IHM
{
    public partial class PanelServoCan : UserControl
    {
        private ThreadLink _linkPolling, _linkDrawing;
        private CanServo _servo;

        public PanelServoCan()
        {
            InitializeComponent();

            numID.Maximum = Enum.GetValues(typeof(ServomoteurID)).Cast<int>().Max();
        }

        public void SetServo(ServomoteurID servo)
        {
            if (_servo is null || _servo.ID != servo)
            {
                numID.Value = (int)(servo);
                _servo = AllDevices.CanServos[(ServomoteurID)numID.Value];
                picConnection.Visible = false;
                lblName.Text = "";
                ReadValues();
            }
        }

        private void DrawTimeArrow()
        {
            Bitmap bmp = new Bitmap(picArrow.Width, picArrow.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen p = new Pen(Color.DimGray, 1);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            p.StartCap = LineCap.Custom;
            p.EndCap = LineCap.Custom;
            p.CustomStartCap = p.CustomEndCap = new AdjustableArrowCap(3, 3);
            g.DrawLine(p, new Point(0, picArrow.Height / 2), new Point(picArrow.Width, picArrow.Height / 2));
            p.Dispose();

            picArrow.Image = bmp;
            lblTrajectoryTime.Visible = true;
        }

        private void trackBarPosition_TickValueChanged(object sender, double value)
        {
            numPosition.Value = (int)value;
        }

        private void boxTorque_ValueChanged(object sender, bool value)
        {
            if (value)
            {
                _linkPolling = ThreadManager.CreateThread(link => GetServoInfos());
                _linkPolling.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, 20));

                _linkDrawing = ThreadManager.CreateThread(link => DrawTorqueCurve());
                _linkDrawing.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, 100));
            }
            else
            {
                _linkPolling.Cancel();
                _linkDrawing.Cancel();

                _linkPolling.WaitEnd();
                _linkDrawing.WaitEnd();

                _linkPolling = null;
                _linkDrawing = null;
            }
        }

        private void GetServoInfos()
        {
            _linkPolling.RegisterName(" : " + _servo.ID.ToString());
            gphMonitoringTorque.AddPoint("Couple", _servo.ReadTorqueCurrent(), Color.Firebrick, true);
            gphMonitoringTorque.AddPoint("Alerte", _servo.LastTorqueMax, Color.Red, false);
            gphMonitoringPos.AddPoint("Position", _servo.ReadPosition(), Color.RoyalBlue);
        }

        private void DrawTorqueCurve()
        {
            _linkDrawing.RegisterName(" : " + _servo.ID.ToString());
            this.InvokeAuto(() =>
            {
                gphMonitoringPos.DrawCurves();
                gphMonitoringTorque.DrawCurves();
            });
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            _servo.SetTrajectory((int)numPosition.Value, (int)numSpeedMax.Value, (int)numAccel.Value);
        }

        private void numPosition_ValueChanged(object sender, EventArgs e)
        {
            if (_servo.LastPosition != numPosition.Value)
            {
                _servo.SetPosition((int)numPosition.Value);
            }
        }

        private void numPositionMin_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)numPositionMin.Value;

            if (_servo.LastPositionMin != val)
            {
                _servo.SetPositionMin(val);
                gphMonitoringPos.MinLimit = val;
            }

            trkPosition.Min = val;
        }

        private void numPositionMax_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)numPositionMax.Value;

            if (_servo.LastPositionMax != val)
            {
                _servo.SetPositionMax(val);
                gphMonitoringPos.MaxLimit = val;
            }

            trkPosition.Max = val;
        }

        private void numAccel_ValueChanged(object sender, EventArgs e)
        {
            if (_servo.LastAcceleration != (int)numAccel.Value)
                _servo.SetAcceleration((int)numAccel.Value);
        }

        private void numSpeedMax_ValueChanged(object sender, EventArgs e)
        {
            if (_servo.LastSpeedMax != (int)numSpeedMax.Value)
                _servo.SetSpeedMax((int)numSpeedMax.Value);
        }

        private void numTorqueMax_ValueChanged(object sender, EventArgs e)
        {
            if (_servo.LastTorqueMax != (int)numTorqueMax.Value)
            {
                _servo.SetTorqueMax((int)numTorqueMax.Value);
                gphMonitoringTorque.MaxLimit = _servo.LastTorqueMax * 1.5;
            }
        }

        private void trkTrajectoryTarget_ValueChanged(object sender, double value)
        {
            lblTrajectoryTarget.Text = trkTrajectoryTarget.Value.ToString();
            DrawTrajectoryGraphs();
        }

        private void trkTrajectorySpeed_ValueChanged(object sender, double value)
        {
            lblTrajectorySpeed.Text = trkTrajectorySpeed.Value.ToString();
            DrawTrajectoryGraphs();
        }

        private void trkTrajectoryAccel_ValueChanged(object sender, double value)
        {
            lblTrajectoryAccel.Text = trkTrajectoryAccel.Value.ToString();
            DrawTrajectoryGraphs();
        }

        private void numID_ValueChanged(object sender, EventArgs e)
        {
            SetServo((ServomoteurID)numID.Value);
        }

        private void DrawTrajectoryGraphs()
        {
            SpeedConfig config = new SpeedConfig((int)trkTrajectorySpeed.Value, (int)trkTrajectoryAccel.Value, (int)trkTrajectoryAccel.Value, 0, 0, 0);
            SpeedSample sample = new SpeedSampler(config).SampleLine(_servo.LastPosition, (int)trkTrajectoryTarget.Value, gphTrajectoryPosition.Width);

            gphTrajectorySpeed.DeleteCurve("Vitesse");
            gphTrajectoryPosition.DeleteCurve("Position");

            if (sample.Valid)
            {
                sample.Speeds.ForEach(s => gphTrajectorySpeed.AddPoint("Vitesse", s, Color.Purple));
                gphTrajectorySpeed.DrawCurves();

                sample.Positions.ForEach(s => gphTrajectoryPosition.AddPoint("Position", s, Color.ForestGreen));
                gphTrajectoryPosition.DrawCurves();

                lblTrajectoryTime.Text = sample.Duration.TotalSeconds.ToString("0.0") + "s";
            }

            if (picArrow.Image == null) DrawTimeArrow();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _servo.DisableOutput();
        }

        private void btnAutoMax_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Lancer une recherche automatique de maximum ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnAutoMax.Enabled = false;
                ThreadManager.CreateThread(link =>
                {
                    link.Name = "Recherche servo max";
                    _servo.SearchMax();
                    ReadValues();
                    btnAutoMin.InvokeAuto(() => btnAutoMax.Enabled = true);
                });
            }
        }

        private void btnAutoMin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Lancer une recherche automatique de minimum ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnAutoMin.Enabled = false;
                ThreadManager.CreateThread(link =>
                {
                    link.Name = "Recherche servo min";
                    _servo.SearchMin();
                    ReadValues();
                    btnAutoMin.InvokeAuto(() => btnAutoMin.Enabled = true);
                });
            }
        }

        private void PanelServoCan_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                gphMonitoringTorque.ScaleMode = Composants.GraphPanel.ScaleType.FixedIfEnough;
                gphMonitoringPos.ScaleMode = Composants.GraphPanel.ScaleType.FixedIfEnough;
            }
        }

        private void ReadValues()
        {
            try
            {
                numPositionMin.Value = _servo.ReadPositionMin();
                numPositionMax.Value = _servo.ReadPositionMax();
                numPosition.Value = _servo.ReadPosition();
                numAccel.Value = _servo.ReadAcceleration();
                numSpeedMax.Value = _servo.ReadSpeedMax();
                numTorqueMax.Value = _servo.ReadTorqueMax();

                trkPosition.Min = _servo.LastPositionMin;
                trkPosition.Max = _servo.LastPositionMax;
                trkPosition.SetValue(_servo.LastPosition, false);

                //trkTrajectoryTarget.Min = _servo.LastPositionMin;
                //trkTrajectoryTarget.Max = _servo.LastPositionMax;
                //trkTrajectoryTarget.SetValue(_servo.LastPosition);
                //trkTrajectorySpeed.SetValue(_servo.LastSpeedMax);
                //trkTrajectoryAccel.SetValue(_servo.LastAcceleration);
                
                gphMonitoringTorque.MinLimit = 0;
                gphMonitoringTorque.MaxLimit = _servo.LastTorqueMax * 1.5;

                gphMonitoringPos.MinLimit = _servo.LastPositionMin;
                gphMonitoringPos.MaxLimit = _servo.LastPositionMax;

                picConnection.Visible = true;
                picConnection.Image = GoBot.Properties.Resources.ConnectionOk;
                lblName.Text = NameFinder.GetName(_servo.ID);

                grpControl.Enabled = true;
                grpMonitoring.Enabled = true;
                grpTrajectory.Enabled = true;
                grpSettings.Enabled = true;
                grpPositions.Enabled = true;

            }
            catch
            {
                picConnection.Visible = true;
                picConnection.Image = GoBot.Properties.Resources.ConnectionNok;
                lblName.Text = "Pas de connexion";

                grpControl.Enabled = false;
                grpMonitoring.Enabled = false;
                grpTrajectory.Enabled = false;
                grpSettings.Enabled = false;
                grpPositions.Enabled = false;
            }
        }
    }
}
