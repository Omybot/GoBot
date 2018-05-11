﻿using System;
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

        private void btnConvAllOut_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoConvoyeurGauche.SendPosition(Config.CurrentConfig.ServoConvoyeurGauche.PositionArriere);
            Config.CurrentConfig.ServoConvoyeurCentre.SendPosition(Config.CurrentConfig.ServoConvoyeurCentre.PositionArriere);
            Config.CurrentConfig.ServoConvoyeurDroite.SendPosition(Config.CurrentConfig.ServoConvoyeurDroite.PositionArriere);
        }

        private void btnConvAllIn_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoConvoyeurGauche.SendPosition(Config.CurrentConfig.ServoConvoyeurGauche.PositionAvant);
            Config.CurrentConfig.ServoConvoyeurCentre.SendPosition(Config.CurrentConfig.ServoConvoyeurCentre.PositionAvant);
            Config.CurrentConfig.ServoConvoyeurDroite.SendPosition(Config.CurrentConfig.ServoConvoyeurDroite.PositionAvant);
        }

        private void btnConvLeftOut_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoConvoyeurGauche.SendPosition(Config.CurrentConfig.ServoConvoyeurGauche.PositionArriere);
        }

        private void btnConvCenterOut_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoConvoyeurCentre.SendPosition(Config.CurrentConfig.ServoConvoyeurCentre.PositionArriere);
        }

        private void btnConvRightOut_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoConvoyeurDroite.SendPosition(Config.CurrentConfig.ServoConvoyeurDroite.PositionArriere);
        }

        private void btnConvLeftIn_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoConvoyeurGauche.SendPosition(Config.CurrentConfig.ServoConvoyeurGauche.PositionAvant);
        }

        private void btnConvCenterIn_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoConvoyeurCentre.SendPosition(Config.CurrentConfig.ServoConvoyeurCentre.PositionAvant);
        }

        private void btnConvRightIn_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoConvoyeurDroite.SendPosition(Config.CurrentConfig.ServoConvoyeurDroite.PositionAvant);
        }

        private void btnRightPumpOff_Click(object sender, EventArgs e)
        {
            Actionneur.Harvester.DoRightPumpDisable();
        }

        private void btnRightPumpOn_Click(object sender, EventArgs e)
        {
            Actionneur.Harvester.DoRightPumpEnable();
        }

        private void btnLeftPumDisable_Click(object sender, EventArgs e)
        {
            Actionneur.Harvester.DoLeftPumpDisable();
        }

        private void btnLeftPumpEnable_Click(object sender, EventArgs e)
        {
            Actionneur.Harvester.DoLeftPumpEnable();
        }
        
        private void btnBenneBuild_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.DeplacementDepose);
        }

        private void btnBenneKeepBuild_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.PositionDepose);
        }

        private void btnBenneOff_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.Neutre);
        }

        private void btnBenneKeepStored_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.PositionRange);
        }

        private void btnBenneStore_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.MoteurElevation.SendPosition(Config.CurrentConfig.MoteurElevation.DeplacementRange);
        }

        private void btnGateOpen_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionOuvert);
        }

        private void btnGateUnblock_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionDeblocage);
        }

        private void btnGateClose_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoBenneOuverture.SendPosition(Config.CurrentConfig.ServoBenneOuverture.PositionFerme);
        }

        private void btnBenneLiberation_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoBenneLiberation.SendPosition(Config.CurrentConfig.ServoBenneLiberation.PositionLiberation);
        }

        private void btnBenneHandle_Click(object sender, EventArgs e)
        {
            Config.CurrentConfig.ServoBenneLiberation.SendPosition(Config.CurrentConfig.ServoBenneLiberation.PositionMaintien);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
