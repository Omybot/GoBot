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

namespace GoBot.IHM
{
    public partial class PanelServoCAN : UserControl
    {
        private ThreadLink _linkPolling;
        private int _id;

        public PanelServoCAN()
        {
            InitializeComponent();

            graphTorque.LimitsVisible = true;
            graphTorque.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
        }

        private void trackBarPosition_TickValueChanged(object sender, double value)
        {
            Devices.Devices.ServosCan.SetPosition(_id, (int)value);
            lblPosition.Text = value.ToString();
        }

        private void trackBarSpeed_TickValueChanged(object sender, double value)
        {
            Devices.Devices.ServosCan.SetSpeed(_id, (int)value);
            lblSpeed.Text = value.ToString();
        }

        private void trackBarTorque_TickValueChanged(object sender, double value)
        {
            Devices.Devices.ServosCan.SetTorqueMax(_id, (int)value);
            lblTorqueMax.Text = value.ToString();
        }

        private void boxTorque_ValueChanged(object sender, bool value)
        {
            if(value)
            {
                _linkPolling = ThreadManager.CreateThread(link => GetServoTorque());
                _linkPolling.StartInfiniteLoop(new TimeSpan(0, 0, 0, 0, 100));
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
            _linkPolling.Name = "PanelServoCAN.GetServoTorque : " + _id.ToString();
            graphTorque.AddPoint("Couple", Devices.Devices.ServosCan.GetTorqueCurrent(_id), Color.RoyalBlue);
            this.InvokeAuto(() => graphTorque.DrawCurves());
        }

        private void numID_ValueChanged(object sender, EventArgs e)
        {
            _id = (int)numID.Value;
        }
    }
}
