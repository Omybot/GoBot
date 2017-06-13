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
            if (!Config.DesignMode)
            {
                timerTension = new System.Timers.Timer(1000);
                timerTension.Elapsed += new ElapsedEventHandler(timerTension_Elapsed);
                timerTension.Start();

                batteriePack1.TensionMidHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePack1.TensionMid = Config.CurrentConfig.BatterieRobotOrange;
                batteriePack1.TensionLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePack1.TensionNull = Config.CurrentConfig.BatterieRobotCritique;

            }
        }

        void timerTension_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Config.Shutdown)
                return;

            lblTensionPack1.Text = Robots.GrosRobot.BatterieVoltage + " V";

            ctrlGraphique.AjouterPoint("Pack 1", Robots.GrosRobot.BatterieVoltage, Color.Blue);

            ctrlGraphique.DessineCourbes();
            
            if (Connections.ConnectionIO.ConnectionChecker.Connected)
            {
                batteriePack1.Afficher = true;
                batteriePack1.Tension = Robots.GrosRobot.BatterieVoltage;
            }
            else
            {
                batteriePack1.Afficher = false;
                batteriePack1.CouleurGris();
            }
        }
    }
}
