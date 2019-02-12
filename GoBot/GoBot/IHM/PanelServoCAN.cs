using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoBot.Threading;
using GoBot.Devices.CAN;

namespace GoBot.IHM
{
    public partial class PanelServoCAN : UserControl
    {
        private ThreadLink _linkPolling, _linkDrawing;
        private CanServo _servo;

        public PanelServoCAN()
        {
            InitializeComponent();

            graphTorque.LimitsVisible = true;
            graphTorque.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;

            if (!Execution.DesignMode)
            {
                _servo = Devices.Devices.CanServos[0];
            }
        }

        private void trackBarPosition_TickValueChanged(object sender, double value)
        {
            _servo.SetPosition((int)value);
            lblPosition.Text = value.ToString();
        }

        private void trackBarSpeed_TickValueChanged(object sender, double value)
        {
            _servo.SetSpeed((int)value);
            lblSpeed.Text = value.ToString();
        }

        private void trackBarTorque_TickValueChanged(object sender, double value)
        {
            _servo.SetTorqueMax((int)value);
            lblTorqueMax.Text = value.ToString();
        }

        private void boxTorque_ValueChanged(object sender, bool value)
        {
            if(value)
            {
                _linkPolling = ThreadManager.CreateThread(link => GetServoTorque());
                _linkPolling.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, 100));

                _linkDrawing = ThreadManager.CreateThread(link => DrawTorqueCurve());
                _linkDrawing.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, 100));
            }
            else
            {
                _linkPolling.Cancel();
                _linkPolling.WaitEnd();
                _linkPolling = null;
            }
        }

        private void GetServoTorque()
        {
            _linkPolling.Name = "PanelServoCAN.GetServoTorque : " + _servo.ID.ToString();
            graphTorque.AddPoint("Couple", _servo.ReadTorqueCurrent(), Color.RoyalBlue);
        }

        private void DrawTorqueCurve()
        {
            this.InvokeAuto(() => graphTorque.DrawCurves());
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            _servo.SetTrajectory((int)numPosition.Value, (int)numSpeed.Value, (int)numAccel.Value);
        }

        private void btnGetPos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Position : " + _servo.ReadPosition().ToString());
        }

        private void numID_ValueChanged(object sender, EventArgs e)
        {
            _servo = Devices.Devices.CanServos[(int)numID.Value];
        }
    }
}
