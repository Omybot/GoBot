using System;
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
            groupBoxCapteurs.DeployedChanged += new Composants.GroupBoxPlus.DeployedChangedDelegate(groupBoxCapteurs_Deploiement);
        }

        void groupBoxCapteurs_Deploiement(bool deploye)
        {
            Config.CurrentConfig.CapteursGROuvert = deploye;
        }

        private void PanelSequencesGros_Load(object sender, EventArgs e)
        {
            ledJack.Color = Color.Gray;
            ledCouleurEquipe.Color = Color.Gray;

            groupBoxCapteurs.Deploy(Config.CurrentConfig.CapteursGROuvert, false);

            timerJack = new System.Timers.Timer(100);
            timerJack.Elapsed += new System.Timers.ElapsedEventHandler(timerJack_Elapsed);
            timerCouleurEquipe = new System.Timers.Timer(100);
            timerCouleurEquipe.Elapsed += new System.Timers.ElapsedEventHandler(timerCouleurEquipe_Elapsed);
        }

        System.Timers.Timer timerJack;
        System.Timers.Timer timerCouleurEquipe;

        private void boxJack_CheckedChanged(object sender, EventArgs e)
        {
            if (boxJack.Checked)
                timerJack.Start();
            else
            {
                timerJack.Stop();
                ledJack.Color = Color.Gray;
            }
        }

        void timerJack_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.InvokeAuto(() =>
            { 
                if (Robots.GrosRobot.GetJack())
                    ledJack.Color = Color.LimeGreen;
                else
                    ledJack.Color = Color.Red;
            });
        }

        void timerCouleurEquipe_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.InvokeAuto(() =>
            {
                if (Robots.GrosRobot.GetCouleurEquipe(false) == Plateau.CouleurDroiteOrange)
                    ledCouleurEquipe.Color = Color.LimeGreen;
                else
                    ledCouleurEquipe.Color = Color.Yellow;
            });
        }

        private void boxCouleurEquipe_CheckedChanged(object sender, EventArgs e)
        {
            if (boxCouleurEquipe.Checked)
                timerCouleurEquipe.Start();
            else
            {
                timerCouleurEquipe.Stop();
                ledCouleurEquipe.Color = Color.Gray;
            }
        }
    }
}
