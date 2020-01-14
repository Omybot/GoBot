using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace GoBot.IHM
{
    public partial class PagePower : UserControl
    {
        private System.Timers.Timer _timerVoltage;
        private bool _loaded;

        public PagePower()
        {
            InitializeComponent();
            _loaded = false;
        }

        public void StartGraph()
        {
            ctrlGraphic.NamesVisible = true;
            ctrlGraphic.MinLimit = 20;
            ctrlGraphic.MaxLimit = 26;
            ctrlGraphic.ScaleMode = Composants.GraphPanel.ScaleType.FixedIfEnough;
            ctrlGraphic.LimitsVisible = true;

            _timerVoltage = new System.Timers.Timer(1000);
            _timerVoltage.Elapsed += new ElapsedEventHandler(timerTension_Elapsed);
            _timerVoltage.Start();
        }

        private void PanelAlimentation_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                numBatHighToAverage.Value = (decimal)Config.CurrentConfig.BatterieRobotVert;
                numBatAverageToLow.Value = (decimal)Config.CurrentConfig.BatterieRobotOrange;
                numBatLowToVeryLow.Value = (decimal)Config.CurrentConfig.BatterieRobotRouge;
                numBatVeryLowToAbsent.Value = (decimal)Config.CurrentConfig.BatterieRobotCritique;

                batAbsent.CurrentState = Composants.Battery.State.Absent;
                batVeryLow.CurrentState = Composants.Battery.State.VeryLow;
                batLow.CurrentState = Composants.Battery.State.Low;
                batAverage.CurrentState = Composants.Battery.State.Average;
                batHigh.CurrentState = Composants.Battery.State.High;

                _loaded = true;
            }
        }

        void timerTension_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Execution.Shutdown)
                return;

            this.InvokeAuto(() =>
            {
                ctrlGraphic.AddPoint("Tension", Robots.MainRobot.BatterieVoltage, Color.DodgerBlue, true);
                ctrlGraphic.AddPoint("High", Config.CurrentConfig.BatterieRobotVert, Color.LimeGreen);
                ctrlGraphic.AddPoint("Average", Config.CurrentConfig.BatterieRobotOrange, Color.Orange);
                ctrlGraphic.AddPoint("Low", Config.CurrentConfig.BatterieRobotRouge, Color.Firebrick);
                ctrlGraphic.AddPoint("VeryLow", Config.CurrentConfig.BatterieRobotCritique, Color.Black);

                ctrlGraphic.DrawCurves();
            });
        }

        private void numBat_ValueChanged(object sender, EventArgs e)
        {
            if (_loaded)
            {
                Config.CurrentConfig.BatterieRobotVert = (double)numBatHighToAverage.Value;
                Config.CurrentConfig.BatterieRobotOrange = (double)numBatAverageToLow.Value;
                Config.CurrentConfig.BatterieRobotRouge = (double)numBatLowToVeryLow.Value;
                Config.CurrentConfig.BatterieRobotCritique = (double)numBatVeryLowToAbsent.Value;

                Config.Save();
            }
        }
    }
}
