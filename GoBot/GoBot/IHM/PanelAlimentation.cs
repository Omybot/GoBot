using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using GoBot.Communications;

namespace GoBot.IHM
{
    public partial class PanelAlimentation : UserControl
    {
        private System.Timers.Timer timerTension;

        public PanelAlimentation()
        {
            InitializeComponent();
        }

        private void PanelAlimentation_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                timerTension = new System.Timers.Timer(1000);
                timerTension.Elapsed += new ElapsedEventHandler(timerTension_Elapsed);
                timerTension.Start();

                batteriePack1.VoltageHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePack1.VoltageAverage = Config.CurrentConfig.BatterieRobotOrange;
                batteriePack1.VoltageLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePack1.VoltageVeryLow = Config.CurrentConfig.BatterieRobotCritique;

            }
        }

        void timerTension_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Execution.Shutdown)
                return;

            lblTensionPack1.Text = Robots.GrosRobot.BatterieVoltage + " V";

            ctrlGraphique.AddPoint("Pack 1", Robots.GrosRobot.BatterieVoltage, Color.Blue);

            ctrlGraphique.DrawCurves();
            
            if (Connections.ConnectionIO.ConnectionChecker.Connected)
            {
                batteriePack1.Enabled = true;
                batteriePack1.CurrentVoltage = Robots.GrosRobot.BatterieVoltage;
            }
            else
            {
                batteriePack1.Enabled = false;
                batteriePack1.CurrentState = Composants.Battery.State.Absent;
            }
        }
    }
}
