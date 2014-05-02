﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PanelGrosRobotCapteurs : UserControl
    {
        private ToolTip tooltip;

        public PanelGrosRobotCapteurs()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;
            groupBoxCapteurs.DeploiementChange += new Composants.GroupBoxRetractable.DeploiementDelegate(groupBoxCapteurs_Deploiement);
        }

        void groupBoxCapteurs_Deploiement(bool deploye)
        {
            Config.CurrentConfig.CapteursGROuvert = deploye;
        }

        private void PanelSequencesGros_Load(object sender, EventArgs e)
        {
            ledJack.CouleurGris();
            ledCouleurEquipe.CouleurGris();
            ledPresenceBouchon.CouleurGris();

            groupBoxCapteurs.Deployer(Config.CurrentConfig.CapteursGROuvert, false);

            timerJack = new System.Timers.Timer(100);
            timerJack.Elapsed += new System.Timers.ElapsedEventHandler(timerJack_Elapsed);
            timerCouleurEquipe = new System.Timers.Timer(100);
            timerCouleurEquipe.Elapsed += new System.Timers.ElapsedEventHandler(timerCouleurEquipe_Elapsed);
            timerPresenceBouchon = new System.Timers.Timer(100);
            timerPresenceBouchon.Elapsed += new System.Timers.ElapsedEventHandler(timerPresenceBouchon_Elapsed);
        }

        System.Timers.Timer timerJack;
        System.Timers.Timer timerCouleurEquipe;
        System.Timers.Timer timerPresenceBouchon;

        private void boxJack_CheckedChanged(object sender, EventArgs e)
        {
            if (boxJack.Checked)
                timerJack.Start();
            else
            {
                timerJack.Stop();
                ledJack.CouleurGris();
            }
        }

        void timerJack_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (Robots.GrosRobot.GetJack(false))
                    ledJack.CouleurVert();
                else
                    ledJack.CouleurRouge();
            }));
        }

        void timerCouleurEquipe_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (Robots.GrosRobot.GetCouleurEquipe(false) == Plateau.CouleurDroiteJaune)
                    ledCouleurEquipe.CouleurJaune();
                else
                    ledCouleurEquipe.CouleurRouge();
            }));
        }

        void timerPresenceBouchon_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (Robots.GrosRobot.DemandeCapteurOnOff(CapteurOnOff.GRPresenceBouchon))
                {
                    ledPresenceBouchon.CouleurVert();
                }
                else
                    ledPresenceBouchon.CouleurRouge();
            }));
        }

        private void boxCouleurEquipe_CheckedChanged(object sender, EventArgs e)
        {
            if (boxCouleurEquipe.Checked)
                timerCouleurEquipe.Start();
            else
            {
                timerCouleurEquipe.Stop();
                ledCouleurEquipe.CouleurGris();
            }
        }

        private void boxPresenceBouchon_CheckedChanged(object sender, EventArgs e)
        {
            if (boxPresenceBouchon.Checked)
                timerPresenceBouchon.Start();
            else
            {
                timerPresenceBouchon.Stop();
                ledPresenceBouchon.CouleurGris();
            }
        }
    }
}
