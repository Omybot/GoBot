using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GoBot.Actionneurs;
using GoBot.Threading;
using GoBot.Communications;

namespace GoBot.IHM
{
    public partial class PanelGrosRobotUtilisation : UserControl
    {
        private ToolTip tooltip;

        public PanelGrosRobotUtilisation()
        {
            InitializeComponent();
            
            if(!Execution.DesignMode)
                Robots.GrosRobot.ChangementEtatCapteurOnOff += new Robot.ChangementEtatCapteurOnOffDelegate(GrosRobot_ValueChangedCapteurOnOff);

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;

            groupBoxUtilisation.DeployedChanged += new Composants.GroupBoxPlus.DeployedChangedDelegate(groupBoxUtilisation_Deploiement);
        }
        
        void GrosRobot_ValueChangedCapteurOnOff(CapteurOnOffID capteur, bool etat)
        {
            switch (capteur)
            {
                
            }
        }

        void groupBoxUtilisation_Deploiement(bool deploye)
        {
            Config.CurrentConfig.UtilisationGROuvert = deploye;
        }

        private void PanelUtilGros_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
                groupBoxUtilisation.Deploy(Config.CurrentConfig.UtilisationGROuvert, false);
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.Diagnostic();
        }

        private void trackBarPlus1_TickValueChanged(object sender, double value)
        {
            Robots.GrosRobot.MoteurVitesse(MoteurID.Gulp, SensGD.Gauche, (int)value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.Avancer(50);
            Devices.Devices.ServosCan.SetPosition(5, 34000);
            Devices.Devices.ServosCan.SetPosition(6, 17000);

            Robots.GrosRobot.MoteurVitesse(MoteurID.Gulp, SensGD.Gauche, 4000);
            Thread.Sleep(1000);
            Robots.GrosRobot.MoteurVitesse(MoteurID.Gulp, SensGD.Gauche, 0);


            Devices.Devices.ServosCan.SetPosition(4, 40000);

            Thread.Sleep(1000);
            Devices.Devices.ServosCan.SetPosition(4, 16800);
            Devices.Devices.ServosCan.SetPosition(5, 26000);
            Devices.Devices.ServosCan.SetPosition(6, 23400);
            Robots.GrosRobot.Reculer(50);
        }
    }
}
