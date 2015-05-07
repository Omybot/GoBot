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
    public partial class PanelAnalogique : UserControl
    {
        private System.Timers.Timer timerTrame;

        public PanelAnalogique()
        {
            InitializeComponent();
        }

        private void PanelAnalogique_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                timerTrame = new System.Timers.Timer();
                timerTrame.Elapsed += new ElapsedEventHandler(timerTrame_Elapsed);
                timerTrame.Start();
            }
        }

        void timerTrame_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Config.Shutdown)
                return;

            if(Robots.GrosRobot.ValeursAnalogiques != null)

            //lock (Robots.GrosRobot.ValeursAnalogiques)
            {
                lblAN1.Text = Robots.GrosRobot.ValeursAnalogiques[0].ToString();
                lblAN2.Text = Robots.GrosRobot.ValeursAnalogiques[1].ToString();
                lblAN3.Text = Robots.GrosRobot.ValeursAnalogiques[2].ToString();
                lblAN4.Text = Robots.GrosRobot.ValeursAnalogiques[3].ToString();
                lblAN5.Text = Robots.GrosRobot.ValeursAnalogiques[4].ToString();
                lblAN6.Text = Robots.GrosRobot.ValeursAnalogiques[5].ToString();

                ctrlGraphique.AjouterPoint("AN1", Robots.GrosRobot.ValeursAnalogiques[0], Color.Blue);
                ctrlGraphique.AjouterPoint("AN2", Robots.GrosRobot.ValeursAnalogiques[1], Color.Aqua);
                ctrlGraphique.AjouterPoint("AN3", Robots.GrosRobot.ValeursAnalogiques[2], Color.Red);
                ctrlGraphique.AjouterPoint("AN4", Robots.GrosRobot.ValeursAnalogiques[3], Color.Magenta);
                ctrlGraphique.AjouterPoint("AN5", Robots.GrosRobot.ValeursAnalogiques[4], Color.Green);
                ctrlGraphique.AjouterPoint("AN6", Robots.GrosRobot.ValeursAnalogiques[5], Color.Orange);
            }

            ctrlGraphique.DessineCourbes();

            Robots.GrosRobot.DemandeValeursAnalogiques();
        }
    }
}
