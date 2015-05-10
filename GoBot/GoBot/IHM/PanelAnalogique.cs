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
        private System.Timers.Timer timerTrameIO;
        private System.Timers.Timer timerTrameMove;

        public PanelAnalogique()
        {
            InitializeComponent();
        }

        private void PanelAnalogique_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                timerTrameIO = new System.Timers.Timer();
                timerTrameIO.Elapsed += new ElapsedEventHandler(timerTrameIO_Elapsed);
                timerTrameIO.Start();
                timerTrameIO.Enabled = false;
                timerTrameMove = new System.Timers.Timer();
                timerTrameMove.Elapsed += new ElapsedEventHandler(timerTrameMove_Elapsed);
                timerTrameMove.Start();
                timerTrameMove.Enabled = false;
            }
        }

        void timerTrameIO_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Config.Shutdown)
                return;

            if(Robots.GrosRobot.ValeursAnalogiquesIO != null)

            //lock (Robots.GrosRobot.ValeursAnalogiques)
            {
                lblAN1.Text = Robots.GrosRobot.ValeursAnalogiquesIO[0].ToString();
                lblAN2.Text = Robots.GrosRobot.ValeursAnalogiquesIO[1].ToString();
                lblAN3.Text = Robots.GrosRobot.ValeursAnalogiquesIO[2].ToString();
                lblAN4.Text = Robots.GrosRobot.ValeursAnalogiquesIO[3].ToString();
                lblAN5.Text = Robots.GrosRobot.ValeursAnalogiquesIO[4].ToString();
                lblAN6.Text = Robots.GrosRobot.ValeursAnalogiquesIO[5].ToString();
                lblAN7.Text = Robots.GrosRobot.ValeursAnalogiquesIO[6].ToString();
                lblAN8.Text = Robots.GrosRobot.ValeursAnalogiquesIO[7].ToString();
                lblAN9.Text = Robots.GrosRobot.ValeursAnalogiquesIO[8].ToString();

                ctrlGraphiqueIO.AjouterPoint("AN1", Robots.GrosRobot.ValeursAnalogiquesIO[0], Color.Blue);
                ctrlGraphiqueIO.AjouterPoint("AN2", Robots.GrosRobot.ValeursAnalogiquesIO[1], Color.Aqua);
                ctrlGraphiqueIO.AjouterPoint("AN3", Robots.GrosRobot.ValeursAnalogiquesIO[2], Color.Red);
                ctrlGraphiqueIO.AjouterPoint("AN4", Robots.GrosRobot.ValeursAnalogiquesIO[3], Color.Magenta);
                ctrlGraphiqueIO.AjouterPoint("AN5", Robots.GrosRobot.ValeursAnalogiquesIO[4], Color.Green);
                ctrlGraphiqueIO.AjouterPoint("AN6", Robots.GrosRobot.ValeursAnalogiquesIO[5], Color.Orange);
                ctrlGraphiqueIO.AjouterPoint("AN7", Robots.GrosRobot.ValeursAnalogiquesIO[6], Color.Black);
                ctrlGraphiqueIO.AjouterPoint("AN8", Robots.GrosRobot.ValeursAnalogiquesIO[7], Color.Coral);
                ctrlGraphiqueIO.AjouterPoint("AN9", Robots.GrosRobot.ValeursAnalogiquesIO[8], Color.DeepPink);
            }

            ctrlGraphiqueIO.DessineCourbes();

            Robots.GrosRobot.DemandeValeursAnalogiquesIO();
        }

        void timerTrameMove_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Config.Shutdown)
                return;

            if (Robots.GrosRobot.ValeursAnalogiquesMove != null)

            //lock (Robots.GrosRobot.ValeursAnalogiques)
            {
                lblMoveAN1.Text = Robots.GrosRobot.ValeursAnalogiquesMove[0].ToString();
                lblMoveAN2.Text = Robots.GrosRobot.ValeursAnalogiquesMove[1].ToString();
                lblMoveAN3.Text = Robots.GrosRobot.ValeursAnalogiquesMove[2].ToString();
                lblMoveAN4.Text = Robots.GrosRobot.ValeursAnalogiquesMove[3].ToString();
                lblMoveAN5.Text = Robots.GrosRobot.ValeursAnalogiquesMove[4].ToString();
                lblMoveAN6.Text = Robots.GrosRobot.ValeursAnalogiquesMove[5].ToString();

                if(checkBox1.Checked)
                    ctrlGraphiqueMove.AjouterPoint("AN1", Robots.GrosRobot.ValeursAnalogiquesMove[0], Color.Blue);

                ctrlGraphiqueMove.AjouterPoint("AN2", Robots.GrosRobot.ValeursAnalogiquesMove[1], Color.Aqua);
                ctrlGraphiqueMove.AjouterPoint("AN3", Robots.GrosRobot.ValeursAnalogiquesMove[2], Color.Red);
                ctrlGraphiqueMove.AjouterPoint("AN4", Robots.GrosRobot.ValeursAnalogiquesMove[3], Color.Magenta);
                ctrlGraphiqueMove.AjouterPoint("AN5", Robots.GrosRobot.ValeursAnalogiquesMove[4], Color.Green);
                ctrlGraphiqueMove.AjouterPoint("AN6", Robots.GrosRobot.ValeursAnalogiquesMove[5], Color.Orange);
            }

            ctrlGraphiqueMove.DessineCourbes();

            Robots.GrosRobot.DemandeValeursAnalogiquesMove();
        }

        private void switchBoutonIO_ChangementEtat(object sender, EventArgs e)
        {
            timerTrameIO.Enabled = switchBoutonIO.Actif;
        }

        private void switchBoutonMove_ChangementEtat(object sender, EventArgs e)
        {
            timerTrameMove.Enabled = switchBoutonMove.Actif;
        }
    }
}
