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
                batteriePack1.CouleurGris();
                batteriePack2.CouleurGris();
                batterieBun1.CouleurGris();
                batterieBeu1.CouleurGris();
                batterieBoi1.CouleurGris();
                batteriePi.CouleurGris();
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

            if (Connexions.ConnexionPi.ConnexionCheck.Connecte)
            {
                batteriePi.Afficher = true;
                batteriePi.Tension = Robots.PetitRobot.TensionPack1;
            }
            else
            {
                batteriePi.Afficher = false;
                batteriePi.CouleurGris();
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

        void ConnexionIoCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecIO, conn);
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
                case Carte.RecIO:
                    selectLed = ledRecIO;
                    break;
                case Carte.RecMiwi:
                    selectLed = ledRecMiwi;
                    break;
                case Carte.RecPi:
                    selectLed = ledRecPi;
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
                ledRecBun.ConnexionNok();
                ledRecBeu.ConnexionNok();
                ledRecBoi.ConnexionNok();
                ledRecMiwi.ConnexionNok();
                ledRecMove.ConnexionNok();
                ledRecIO.ConnexionNok();
                ledRecPi.ConnexionNok();

                Connexions.ConnexionMove.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMoveCheck_ConnexionChange);
                Connexions.ConnexionMiwi.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMiwiCheck_ConnexionChange);
                Connexions.ConnexionIO.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionIoCheck_ConnexionChange);
                Connexions.ConnexionPi.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionPiCheck_ConnexionChange);

                Balise.GetBalise(Carte.RecBun).Connexion.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBunCheck_ConnexionChange);
                Balise.GetBalise(Carte.RecBeu).Connexion.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBeuCheck_ConnexionChange);
                Balise.GetBalise(Carte.RecBoi).Connexion.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBoiCheck_ConnexionChange);


                if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
                    SetLed(ledRecMove, true);
                if (Connexions.ConnexionMiwi.ConnexionCheck.Connecte)
                    SetLed(ledRecMiwi, true);
                if (Connexions.ConnexionIO.ConnexionCheck.Connecte)
                    SetLed(ledRecIO, true);
                if (Balise.GetBalise(Carte.RecBun).Connexion.ConnexionCheck.Connecte)
                    SetLed(ledRecBun, true);
                if (Balise.GetBalise(Carte.RecBeu).Connexion.ConnexionCheck.Connecte)
                    SetLed(ledRecBeu, true);
                if (Balise.GetBalise(Carte.RecBoi).Connexion.ConnexionCheck.Connecte)
                    SetLed(ledRecBoi, true);

                batteriePack1.TensionMidHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePack1.TensionMid = Config.CurrentConfig.BatterieRobotOrange;
                batteriePack1.TensionLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePack1.TensionNull = Config.CurrentConfig.BatterieRobotCritique;

                batteriePack2.TensionMidHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePack2.TensionMid = Config.CurrentConfig.BatterieRobotOrange;
                batteriePack2.TensionLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePack2.TensionNull = Config.CurrentConfig.BatterieRobotCritique;

                batteriePi.TensionMidHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePi.TensionMid = Config.CurrentConfig.BatterieRobotOrange;
                batteriePi.TensionLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePi.TensionNull = Config.CurrentConfig.BatterieRobotCritique;

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

                timerBatteries = new System.Windows.Forms.Timer();
                timerBatteries.Interval = 1000;
                timerBatteries.Tick += new EventHandler(timerBatteries_Tick);
                timerBatteries.Start();
            }
        }
    }
}
