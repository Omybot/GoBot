using System.Drawing;
using System.Windows.Forms;

using GoBot.Threading;

namespace GoBot.IHM
{
    public partial class PanelSensorOnOff : UserControl
    {
        private SensorOnOffID _sensor;
        private ThreadLink _linkPolling;

        public PanelSensorOnOff()
        {
            InitializeComponent();
        }

        private void PanelSensorOnOff_Load(object sender, System.EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                Robots.MainRobot.SensorOnOffChanged += MainRobot_SensorOnOffChanged;
            }
        }

        private void MainRobot_SensorOnOffChanged(SensorOnOffID sensor, bool state)
        {
            if (sensor == _sensor && _linkPolling != null)  ledState.Color = state ? Color.LimeGreen : Color.Red;
        }

        public void SetSensor(SensorOnOffID sensor)
        {
            _sensor = sensor;
            lblName.Text = NameFinder.GetName(sensor).Substring(0, 1).ToUpper() + NameFinder.GetName(sensor).Substring(1);
        }

        private void btnOnOff_ValueChanged(object sender, bool value)
        {
            if(value)
            {
                ledState.Color = Robots.MainRobot.ReadSensorOnOff(_sensor) ? Color.LimeGreen : Color.Red;
                _linkPolling = ThreadManager.CreateThread(link => PollingSensor());
                _linkPolling.RegisterName(nameof(PollingSensor) + " " + lblName.Text);
                _linkPolling.StartInfiniteLoop(50);
            }
            else
            {
                _linkPolling.Cancel();
                _linkPolling.WaitEnd();
                _linkPolling = null;
                ledState.Color = Color.Gray;
            }
        }

        private void PollingSensor()
        {
            Robots.MainRobot.ReadSensorOnOff(_sensor, false);
        }
    }
}
