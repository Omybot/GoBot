using Composants;
using GoBot.Communications;
using System;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelConnexions : UserControl
    {
        private Timer _timerBatteries;

        public PanelConnexions()
        {
            InitializeComponent();
        }

        void timerBatteries_Tick(object sender, EventArgs e)
        {
            if (Robots.Simulation)
            {
                batteryPack.Enabled = false;
            }
            else
            {
                if (Connections.ConnectionGB.ConnectionChecker.Connected)
                {
                    batteryPack.Enabled = true;
                    batteryPack.CurrentVoltage = Robots.MainRobot.BatterieVoltage;
                    lblVoltage.Text = Robots.MainRobot.BatterieVoltage.ToString() + "V";
                }
                else
                {
                    batteryPack.Enabled = false;
                    lblVoltage.Text = "-";
                }
            }
        }

        private void SetLed(ConnectionIndicator led, bool on)
        {
            led.SetConnectionState(on, true);
        }

        private void PanelConnexions_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                ConnectionStatus statusAvoid = new ConnectionStatus();
                statusAvoid.Connection = Devices.AllDevices.LidarAvoid.ConnectionChecker;
                statusAvoid.ConnectionName = "Avoid";
                _ledsPanel.Controls.Add(statusAvoid);

                foreach (Connection conn in Connections.AllConnections)
                {
                    ConnectionStatus status = new ConnectionStatus();
                    status.Connection = conn.ConnectionChecker;
                    status.ConnectionName = conn.Name;
                    _ledsPanel.Controls.Add(status);
                }

                batteryPack.VoltageHigh = Config.CurrentConfig.BatterieRobotVert;
                batteryPack.VoltageAverage = Config.CurrentConfig.BatterieRobotOrange;
                batteryPack.VoltageLow = Config.CurrentConfig.BatterieRobotRouge;
                batteryPack.VoltageVeryLow = Config.CurrentConfig.BatterieRobotCritique;

                _timerBatteries = new System.Windows.Forms.Timer();
                _timerBatteries.Interval = 1000;
                _timerBatteries.Tick += new EventHandler(timerBatteries_Tick);
                _timerBatteries.Start();
            }
        }
    }
}
