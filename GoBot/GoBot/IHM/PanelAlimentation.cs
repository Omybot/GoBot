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

                batteriePack2.TensionMidHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePack2.TensionMid = Config.CurrentConfig.BatterieRobotOrange;
                batteriePack2.TensionLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePack2.TensionNull = Config.CurrentConfig.BatterieRobotCritique;

                batteriePRPack1.TensionMidHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePRPack1.TensionMid = Config.CurrentConfig.BatterieRobotOrange;
                batteriePRPack1.TensionLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePRPack1.TensionNull = Config.CurrentConfig.BatterieRobotCritique;

                batteriePRPack2.TensionMidHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePRPack2.TensionMid = Config.CurrentConfig.BatterieRobotOrange;
                batteriePRPack2.TensionLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePRPack2.TensionNull = Config.CurrentConfig.BatterieRobotCritique;

                batterieBun1.TensionMidHigh = Config.CurrentConfig.BatterieBaliseVert;
                batterieBun1.TensionMid = Config.CurrentConfig.BatterieBaliseOrange;
                batterieBun1.TensionLow = Config.CurrentConfig.BatterieBaliseRouge;
                batterieBun1.TensionNull = Config.CurrentConfig.BatterieBaliseCritique;

                batterieBun2.TensionMidHigh = Config.CurrentConfig.BatterieBaliseVert;
                batterieBun2.TensionMid = Config.CurrentConfig.BatterieBaliseOrange;
                batterieBun2.TensionLow = Config.CurrentConfig.BatterieBaliseRouge;
                batterieBun2.TensionNull = Config.CurrentConfig.BatterieBaliseCritique;

                batterieBeu1.TensionMidHigh = Config.CurrentConfig.BatterieBaliseVert;
                batterieBeu1.TensionMid = Config.CurrentConfig.BatterieBaliseOrange;
                batterieBeu1.TensionLow = Config.CurrentConfig.BatterieBaliseRouge;
                batterieBeu1.TensionNull = Config.CurrentConfig.BatterieBaliseCritique;

                batterieBeu2.TensionMidHigh = Config.CurrentConfig.BatterieBaliseVert;
                batterieBeu2.TensionMid = Config.CurrentConfig.BatterieBaliseOrange;
                batterieBeu2.TensionLow = Config.CurrentConfig.BatterieBaliseRouge;
                batterieBeu2.TensionNull = Config.CurrentConfig.BatterieBaliseCritique;

                batterieBoi1.TensionMidHigh = Config.CurrentConfig.BatterieBaliseVert;
                batterieBoi1.TensionMid = Config.CurrentConfig.BatterieBaliseOrange;
                batterieBoi1.TensionLow = Config.CurrentConfig.BatterieBaliseRouge;
                batterieBoi1.TensionNull = Config.CurrentConfig.BatterieBaliseCritique;

                batterieBoi2.TensionMidHigh = Config.CurrentConfig.BatterieBaliseVert;
                batterieBoi2.TensionMid = Config.CurrentConfig.BatterieBaliseOrange;
                batterieBoi2.TensionLow = Config.CurrentConfig.BatterieBaliseRouge;
                batterieBoi2.TensionNull = Config.CurrentConfig.BatterieBaliseCritique;
            }
        }

        void timerTension_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Config.Shutdown)
                return;

            lblTensionPack1.Text = Robots.GrosRobot.TensionPack1 + " V";
            lblTensionPack2.Text = Robots.GrosRobot.TensionPack2 + " V";

            lblBatPRPack1.Text = Robots.PetitRobot.TensionPack1 + " V";
            lblBatPRPack2.Text = Robots.PetitRobot.TensionPack2 + " V";

            lblTensionBun1.Text = Plateau.Balise1.Tension1 + " V";
            lblTensionBun2.Text = Plateau.Balise1.Tension2 + " V";

            lblTensionBeu1.Text = Plateau.Balise2.Tension1 + " V";
            lblTensionBeu2.Text = Plateau.Balise2.Tension2 + " V";

            lblTensionBoi1.Text = Plateau.Balise3.Tension1 + " V";
            lblTensionBoi2.Text = Plateau.Balise3.Tension2 + " V";

            ctrlGraphique.AjouterPoint("Pack 1", Robots.GrosRobot.TensionPack1, Color.Blue);
            ctrlGraphique.AjouterPoint("Pack 2", Robots.GrosRobot.TensionPack2, Color.LightBlue);

            ctrlGraphique.AjouterPoint("Pack 1 PR", Robots.PetitRobot.TensionPack1, Color.Aqua);
            ctrlGraphique.AjouterPoint("Pack 2 PR", Robots.PetitRobot.TensionPack2, Color.Black);

            ctrlGraphique.AjouterPoint("Bun 1", Plateau.Balise1.Tension1, Color.Red);
            ctrlGraphique.AjouterPoint("Bun 2", Plateau.Balise1.Tension2, Color.Magenta);

            ctrlGraphique.AjouterPoint("Beu 1", Plateau.Balise2.Tension1, Color.Green);
            ctrlGraphique.AjouterPoint("Beu 2", Plateau.Balise2.Tension2, Color.LightGreen);

            ctrlGraphique.AjouterPoint("Boi 1", Plateau.Balise3.Tension1, Color.Orange);
            ctrlGraphique.AjouterPoint("Boi 2", Plateau.Balise3.Tension2, Color.Chocolate);

            ctrlGraphique.DessineCourbes();

            if (Connexions.ConnexionPi.ConnexionCheck.Connecte)
            {
                batteriePRPack1.Afficher = true;
                batteriePRPack2.Afficher = true;
                batteriePRPack1.Tension = Robots.PetitRobot.TensionPack1;
                batteriePRPack2.Tension = Robots.PetitRobot.TensionPack2;
            }
            else
            {
                batteriePRPack1.Afficher = false;
                batteriePRPack2.Afficher = false;
                batteriePRPack1.CouleurGris();
                batteriePRPack2.CouleurGris();
            }

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
