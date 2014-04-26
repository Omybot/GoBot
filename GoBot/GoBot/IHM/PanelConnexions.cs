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

            ledRecBun.ConnexionNok();
            ledRecBeu.ConnexionNok();
            ledRecBoi.ConnexionNok();
            ledRecMiwi.ConnexionNok();
            ledRecMove.ConnexionNok();
            ledRecPi.ConnexionNok();

            batteriePack1.CouleurGris();
        }

        void timerBatteries_Tick(object sender, EventArgs e)
        {
            if (Robots.Simulation)
            {
                batteriePack1.CouleurGris();
                batteriePack2.CouleurGris();
                batterieBun1.CouleurGris();
                batterieBeu1.CouleurGris();
                batterieBoi1.CouleurGris();
                return;
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

            if (Plateau.Balise1.ConnexionCheck.Connecte)
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

            if (Plateau.Balise2.ConnexionCheck.Connecte)
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

            if (Plateau.Balise3.ConnexionCheck.Connecte)
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

        void ConnexionBunCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecBun, conn);
        }

        void ConnexionBeuCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecBeu, conn);
        }

        void ConnexionBoiCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecBoi, conn);
        }

        void ConnexionMoveCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecMove, conn);
        }

        void ConnexionPiCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecPi, conn);
        }

        void ConnexionMiwiCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecMiwi, conn);
        }

        void Robot_ConnexionChange(Carte carte, bool connecte)
        {
            IndicateurConnexion selectLed = null;
            switch (carte)
            {
                case Carte.RecMove:
                    selectLed = ledRecMove;
                    break;
                case Carte.RecBun:
                    selectLed = ledRecBun;
                    break;
                case Carte.RecBeu:
                    selectLed = ledRecBeu;
                    break;
                case Carte.RecBoi:
                    selectLed = ledRecBoi;
                    break;
                case Carte.RecPi:
                    selectLed = ledRecPi;
                    break;
                case Carte.RecMiwi:
                    selectLed = ledRecMiwi;
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
                if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
                    SetLed(ledRecMove, true);
                if (Connexions.ConnexionMiwi.ConnexionCheck.Connecte)
                    SetLed(ledRecMiwi, true);
                if (Connexions.ConnexionIO.ConnexionCheck.Connecte)
                    SetLed(ledRecPi, true);
                if (Balise.GetBalise(Carte.RecBun).ConnexionCheck.Connecte)
                    SetLed(ledRecBun, true);
                if (Balise.GetBalise(Carte.RecBeu).ConnexionCheck.Connecte)
                    SetLed(ledRecBeu, true);
                if (Balise.GetBalise(Carte.RecBoi).ConnexionCheck.Connecte)
                    SetLed(ledRecBoi, true);

                Connexions.ConnexionMove.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMoveCheck_ConnexionChange);
                Connexions.ConnexionMiwi.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMiwiCheck_ConnexionChange);
                Connexions.ConnexionIO.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionPiCheck_ConnexionChange);

                Balise.GetBalise(Carte.RecBun).ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBunCheck_ConnexionChange);
                Balise.GetBalise(Carte.RecBeu).ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBeuCheck_ConnexionChange);
                Balise.GetBalise(Carte.RecBoi).ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBoiCheck_ConnexionChange);

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

                timerBatteries = new System.Windows.Forms.Timer();
                timerBatteries.Interval = 1000;
                timerBatteries.Tick += new EventHandler(timerBatteries_Tick);
                timerBatteries.Start();
            }
        }
    }
}
