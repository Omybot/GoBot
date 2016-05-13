using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Composants;
using GoBot.Communications;
using GoBot.Balises;
using System.Threading;

namespace GoBot.IHM
{
    public partial class PanelConnexions : UserControl
    {
        private System.Windows.Forms.Timer timerBatteries;

        public PanelConnexions()
        {
            InitializeComponent();
        }

        void timerBatteries_Tick(object sender, EventArgs e)
        {
            if (Robots.Simulation)
            {
                batteriePack2.CouleurGris();
                return;
            }

            if (Connexions.ConnexionIO.ConnexionCheck.Connecte)
            {
                batteriePack2.Afficher = true;
                batteriePack2.Tension = Robots.GrosRobot.TensionPack2;
            }
            else
            {
                batteriePack2.Afficher = false;
                batteriePack2.CouleurGris();
            }
        }

        void ConnexionBunCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.Balise, conn);
        }

        void ConnexionMoveCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecMove, conn);
        }

        void ConnexionPiCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecPi, conn);
        }

        void ConnexionIoCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecIO, conn);
        }

        void Robot_ConnexionChange(Carte carte, bool connecte)
        {
            IndicateurConnexion selectLed = null;
            switch (carte)
            {
                case Carte.RecMove:
                    selectLed = ledRecMove;
                    break;
                case Carte.Balise:
                    selectLed = ledBalise;
                    break;
                case Carte.RecIO:
                    selectLed = ledRecIO;
                    break;
            }

            this.Invoke(new EventHandler(delegate
            {
                SetLed(selectLed, connecte);
            }));
        }

        private void SetLed(IndicateurConnexion led, bool on)
        {
            if (on)
                led.ConnexionOk(true);
            else
                led.ConnexionNok(true);
        }

        private void PanelConnexions_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                ledBalise.ConnexionNok();
                ledRecMove.ConnexionNok();
                ledRecIO.ConnexionNok();

                Connexions.ConnexionMove.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMoveCheck_ConnexionChange);
                Connexions.ConnexionIO.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionIoCheck_ConnexionChange);

                Plateau.Balise.Connexion.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBunCheck_ConnexionChange);


                if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
                    SetLed(ledRecMove, true);
                if (Connexions.ConnexionIO.ConnexionCheck.Connecte)
                    SetLed(ledRecIO, true);
                if (Plateau.Balise.Connexion.ConnexionCheck.Connecte)
                    SetLed(ledBalise, true);

                batteriePack2.TensionMidHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePack2.TensionMid = Config.CurrentConfig.BatterieRobotOrange;
                batteriePack2.TensionLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePack2.TensionNull = Config.CurrentConfig.BatterieRobotCritique;

                timerBatteries = new System.Windows.Forms.Timer();
                timerBatteries.Interval = 1000;
                timerBatteries.Tick += new EventHandler(timerBatteries_Tick);
                timerBatteries.Start();
            }
        }
    }
}
