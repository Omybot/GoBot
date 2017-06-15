using Composants;
using GoBot.Communications;
using System;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelConnexions : UserControl
    {
        private Timer timerBatteries;

        public PanelConnexions()
        {
            InitializeComponent();
        }

        void timerBatteries_Tick(object sender, EventArgs e)
        {
            if (Robots.Simulation)
            {
                batteriePack.CouleurGris();
            }
            else
            {
                if (Connections.ConnectionIO.ConnectionChecker.Connected)
                {
                    batteriePack.Afficher = true;
                    batteriePack.Tension = Robots.GrosRobot.BatterieVoltage;
                    lblVoltage.Text = Robots.GrosRobot.BatterieVoltage.ToString() + "V";
                }
                else
                {
                    batteriePack.Afficher = false;
                    batteriePack.CouleurGris();
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
                foreach (Connection conn in Connections.AllConnections)
                {
                    ConnectionStatus status = new ConnectionStatus();
                    status.Connection = conn;
                    _ledsPanel.Controls.Add(status);
                }
                
                batteriePack.TensionMidHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePack.TensionMid = Config.CurrentConfig.BatterieRobotOrange;
                batteriePack.TensionLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePack.TensionNull = Config.CurrentConfig.BatterieRobotCritique;

                timerBatteries = new System.Windows.Forms.Timer();
                timerBatteries.Interval = 1000;
                timerBatteries.Tick += new EventHandler(timerBatteries_Tick);
                timerBatteries.Start();
            }
        }
    }
}
