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
    public partial class PanelNumerique : UserControl
    {
        private System.Timers.Timer timerTrame;

        public PanelNumerique()
        {
            InitializeComponent();
        }

        public Board Carte { get; set; }

        private void PanelNumerique_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                timerTrame = new System.Timers.Timer();
                timerTrame.Elapsed += new ElapsedEventHandler(timerTrame_Elapsed);
                timerTrame.Start();
                timerTrame.Enabled = false;
                timerTrame.Interval = 50;
            }
        }

        void timerTrame_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Execution.Shutdown)
                return;

            List<Byte> values = Robots.GrosRobot.ValeursNumeriques[Carte];

            if (values != null)
            {
                graph1.SetValue(values[0]);
                graph2.SetValue(values[1]);
            }

            Robots.GrosRobot.DemandeValeursNumeriques(Carte, false);
        }

        private void switchBouton_ValueChanged(object sender, bool value)
        {
            timerTrame.Enabled = value;
        }
    }
}
