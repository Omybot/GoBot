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
                timerTension = new System.Timers.Timer(10000);
                timerTension.Elapsed += new ElapsedEventHandler(timerTension_Elapsed);
                timerTension.Start();
            }
        }

        void timerTension_Elapsed(object sender, ElapsedEventArgs e)
        {
            lblTensionPack1.Text = Robots.GrosRobot.TensionPack1 + " V";
            lblTensionPack2.Text = Robots.GrosRobot.TensionPack2 + " V";

            lblTensionBalise1.Text = Plateau.Balise1.Tension + " V";
            lblTensionBalise2.Text = Plateau.Balise2.Tension + " V";
            lblTensionBalise3.Text = Plateau.Balise3.Tension + " V";

            if (Robots.GrosRobot.TensionPack1 < 25)
                ledPack1.CouleurRouge();
            else if (Robots.GrosRobot.TensionPack1 < 26)
                ledPack1.CouleurOrange();
            else
                ledPack1.CouleurVert();

            if (Robots.GrosRobot.TensionPack2 < 25)
                ledPack2.CouleurRouge();
            else if (Robots.GrosRobot.TensionPack2 < 26)
                ledPack2.CouleurOrange();
            else
                ledPack2.CouleurVert();

            if (Plateau.Balise1.Tension < 25)
                ledBalise1.CouleurRouge();
            else if (Plateau.Balise1.Tension < 26)
                ledBalise1.CouleurOrange();
            else
                ledBalise1.CouleurVert();

            if (Plateau.Balise2.Tension < 25)
                ledBalise2.CouleurRouge();
            else if (Plateau.Balise2.Tension < 26)
                ledBalise2.CouleurOrange();
            else
                ledBalise2.CouleurVert();

            if (Plateau.Balise3.Tension < 25)
                ledBalise3.CouleurRouge();
            else if (Plateau.Balise3.Tension < 26)
                ledBalise3.CouleurOrange();
            else
                ledBalise3.CouleurVert();
        }
    }
}
