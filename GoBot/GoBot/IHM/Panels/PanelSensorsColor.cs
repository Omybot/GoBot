using System;
using System.Drawing;
using System.Windows.Forms;

using GoBot.Threading;

namespace GoBot.IHM
{
    public partial class PanelSensorsColor : UserControl
    {
        ThreadLink _linkColorLeft, _linkColorRight;

        public PanelSensorsColor()
        {
            InitializeComponent();
        }

        private void PanelSensorsColor_Load(object sender, EventArgs e)
        {
            picColorLeft.SetColor(Color.Red);
            picColorRight.SetColor(Color.HotPink);
        }

        private void btnColorLeft_ValueChanged(object sender, bool value)
        {
            if (value)
            {
                Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.PowerSensorColorBuoyLeft, true);
                Robots.MainRobot.SensorColorChanged += GrosRobot_SensorColorChanged;
                ThreadManager.CreateThread(link => PollingColorLeft(link)).StartInfiniteLoop(50);
            }
            else
            {
                Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.PowerSensorColorBuoyLeft, false);
                _linkColorLeft.Cancel();
                _linkColorLeft.WaitEnd();
                _linkColorLeft = null;
            }
        }

        private void btnColorRight_ValueChanged(object sender, bool value)
        {
            if (value)
            {
                Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.PowerSensorColorBuoyRight, true);
                Robots.MainRobot.SensorColorChanged += GrosRobot_SensorColorChanged;
                ThreadManager.CreateThread(link => PollingColorRight(link)).StartInfiniteLoop(50);
            }
            else
            {
                Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.PowerSensorColorBuoyRight, false);
                _linkColorRight.Cancel();
                _linkColorRight.WaitEnd();
                _linkColorRight = null;
            }
        }

        void PollingColorLeft(ThreadLink link)
        {
            _linkColorLeft = link;
            _linkColorLeft.RegisterName();
            Robots.MainRobot.ReadSensorColor(SensorColorID.BuoyLeft, false);
        }

        void PollingColorRight(ThreadLink link)
        {
            _linkColorRight = link;
            _linkColorRight.RegisterName();
            Robots.MainRobot.ReadSensorColor(SensorColorID.BuoyRight, false);
        }

        void GrosRobot_SensorColorChanged(SensorColorID sensor, Color color)
        {
            this.InvokeAuto(() =>
            {
                switch (sensor)
                {
                    case SensorColorID.BuoyLeft:
                        picColorLeft.SetColor(color);
                        break;
                    case SensorColorID.BuoyRight:
                        picColorRight.SetColor(color);
                        break;
                }
            });
        }
    }
}
