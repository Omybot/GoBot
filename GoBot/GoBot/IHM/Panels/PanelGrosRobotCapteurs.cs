using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelGrosRobotCapteurs : UserControl
    {
        private System.Timers.Timer _timerStartTrigger;
        private ToolTip _tooltip;

        public PanelGrosRobotCapteurs()
        {
            InitializeComponent();

            _tooltip = new ToolTip();
            _tooltip.InitialDelay = 1500;
            grpSensors.DeployedChanged += new Composants.GroupBoxPlus.DeployedChangedDelegate(groupBoxCapteurs_Deploiement);
        }

        void groupBoxCapteurs_Deploiement(bool deploye)
        {
            Config.CurrentConfig.CapteursGROuvert = deploye;
        }

        private void PanelSequencesGros_Load(object sender, EventArgs e)
        {
            ledStartTrigger.Color = Color.Gray;

            grpSensors.Deploy(Config.CurrentConfig.CapteursGROuvert, false);

            _timerStartTrigger = new System.Timers.Timer(100);
            _timerStartTrigger.Elapsed += new System.Timers.ElapsedEventHandler(_timerStartTrigger_Elapsed);
        }

        private void boxJack_CheckedChanged(object sender, EventArgs e)
        {
            if (boxJack.Checked)
                _timerStartTrigger.Start();
            else
            {
                _timerStartTrigger.Stop();
                ledStartTrigger.Color = Color.Gray;
            }
        }

        void _timerStartTrigger_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.InvokeAuto(() =>
            { 
                if (Robots.MainRobot.ReadStartTrigger())
                    ledStartTrigger.Color = Color.LimeGreen;
                else
                    ledStartTrigger.Color = Color.Red;
            });
        }
    }
}
