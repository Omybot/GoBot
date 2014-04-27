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

                batteriePack1.TensionMidHigh = 28.6;
                batteriePack1.TensionMid = 26.95;
                batteriePack1.TensionLow = 25.85;

                batteriePack2.TensionMidHigh = 28.6;
                batteriePack2.TensionMid = 26.95;
                batteriePack2.TensionLow = 25.85;

                batterieBun1.TensionMidHigh = 10;
                batterieBun1.TensionMid = 9;
                batterieBun1.TensionLow = 8;

                batterieBun2.TensionMidHigh = 10;
                batterieBun2.TensionMid = 9;
                batterieBun2.TensionLow = 8;

                batterieBeu1.TensionMidHigh = 10;
                batterieBeu1.TensionMid = 9;
                batterieBeu1.TensionLow = 8;

                batterieBeu2.TensionMidHigh = 10;
                batterieBeu2.TensionMid = 9;
                batterieBeu2.TensionLow = 8;

                batterieBoi1.TensionMidHigh = 10;
                batterieBoi1.TensionMid = 9;
                batterieBoi1.TensionLow = 8;

                batterieBoi2.TensionMidHigh = 10;
                batterieBoi2.TensionMid = 9;
                batterieBoi2.TensionLow = 8;
            }
        }

        void timerTension_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Config.Shutdown)
                return;

            lblTensionPack1.Text = Robots.GrosRobot.TensionPack1 + " V";
            lblTensionPack2.Text = Robots.GrosRobot.TensionPack2 + " V";

            lblTensionBun1.Text = Plateau.Balise1.Tension1 + " V";
            lblTensionBun2.Text = Plateau.Balise2.Tension2 + " V";

            lblTensionBeu1.Text = Plateau.Balise2.Tension1 + " V";
            lblTensionBeu2.Text = Plateau.Balise2.Tension2 + " V";

            lblTensionBoi1.Text = Plateau.Balise3.Tension1 + " V";
            lblTensionBoi2.Text = Plateau.Balise3.Tension2 + " V";

            ctrlGraphique.AjouterPoint("Pack 1", Robots.GrosRobot.TensionPack1, Color.Blue);
            ctrlGraphique.AjouterPoint("Pack 2", Robots.GrosRobot.TensionPack2, Color.LightBlue);

            ctrlGraphique.AjouterPoint("Bun 1", Plateau.Balise1.Tension1, Color.Red);
            ctrlGraphique.AjouterPoint("Bun 2", Plateau.Balise1.Tension2, Color.Magenta);

            ctrlGraphique.AjouterPoint("Beu 1", Plateau.Balise2.Tension1, Color.Green);
            ctrlGraphique.AjouterPoint("Beu 2", Plateau.Balise2.Tension2, Color.LightGreen);

            ctrlGraphique.AjouterPoint("Boi 1", Plateau.Balise3.Tension1, Color.Orange);
            ctrlGraphique.AjouterPoint("Boi 2", Plateau.Balise3.Tension2, Color.Beige);

            ctrlGraphique.DessineCourbes();

            if (Connexions.ConnexionIO.ConnexionCheck.Connecte)
            {
                batteriePack1.Afficher = true;
                batteriePack2.Afficher = true;
                batteriePack1.Tension = Robots.GrosRobot.TensionPack1;
                batteriePack2.Tension = Robots.GrosRobot.TensionPack2;
            }
            else
            {
                batteriePack1.Afficher = false;
                batteriePack2.Afficher = false;
                batteriePack1.CouleurGris();
                batteriePack2.CouleurGris();
            }

            if (Plateau.Balise1.Connexion.ConnexionCheck.Connecte)
            {
                batterieBun1.Afficher = true;
                batterieBun1.Tension = Plateau.Balise1.Tension1;

                batterieBun2.Afficher = true;
                batterieBun2.Tension = Plateau.Balise1.Tension2;
            }
            else
            {
                batterieBun1.Afficher = false;
                batterieBun1.CouleurGris();

                batterieBun2.Afficher = false;
                batterieBun2.CouleurGris();
            }

            if (Plateau.Balise2.Connexion.ConnexionCheck.Connecte)
            {
                batterieBeu1.Afficher = true;
                batterieBeu1.Tension = Plateau.Balise2.Tension1;

                batterieBeu2.Afficher = true;
                batterieBeu2.Tension = Plateau.Balise2.Tension2;
            }
            else
            {
                batterieBeu1.Afficher = false;
                batterieBeu1.CouleurGris();

                batterieBeu2.Afficher = false;
                batterieBeu2.CouleurGris();
            }

            if (Plateau.Balise3.Connexion.ConnexionCheck.Connecte)
            {
                batterieBoi1.Afficher = true;
                batterieBoi1.Tension = Plateau.Balise3.Tension1;

                batterieBoi2.Afficher = true;
                batterieBoi2.Tension = Plateau.Balise3.Tension2;
            }
            else
            {
                batterieBoi1.Afficher = false;
                batterieBoi1.CouleurGris();

                batterieBoi2.Afficher = false;
                batterieBoi2.CouleurGris();
            }
        }
    }
}
