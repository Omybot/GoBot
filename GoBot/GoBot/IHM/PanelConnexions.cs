using Composants;
using GoBot.Communications;
using System;
using System.Windows.Forms;

namespace GoBot.IHM
{
    public partial class PanelConnexions : UserControl
    {
        private Timer timerBatteries;

        public PanelConnexions()
        {
            InitializeComponent();
        }

        void timerBatteries_Tick(object sender, EventArgs e)
        {
            if (Robots.Simulation)
            {
                batteriePack.CouleurGris();
            }
            else
            {
                if (Connexions.ConnexionIO.ConnexionCheck.Connected)
                {
                    batteriePack.Afficher = true;
                    batteriePack.Tension = Robots.GrosRobot.BatterieVoltage;
                    lblVoltage.Text = Robots.GrosRobot.BatterieVoltage.ToString() + "V";
                }
                else
                {
                    batteriePack.Afficher = false;
                    batteriePack.CouleurGris();
                    lblVoltage.Text = "-";
                }
            }
        }

        void Connections_ConnectionStatusChange(Connexion sender, bool connected)
        {
            Robot_ConnexionChange(Connexions.GetBoardByConnection(sender), connected);
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
                case Carte.RecGB:
                    selectLed = ledRecGB;
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

                Connexions.ConnexionMove.ConnexionCheck.ConnectionStatusChange += new ConnectionChecker.ConnectionChangeDelegate(Connections_ConnectionStatusChange);
                Connexions.ConnexionIO.ConnexionCheck.ConnectionStatusChange += new ConnectionChecker.ConnectionChangeDelegate(Connections_ConnectionStatusChange);
                Connexions.ConnexionGB.ConnexionCheck.ConnectionStatusChange += new ConnectionChecker.ConnectionChangeDelegate(Connections_ConnectionStatusChange);

                Plateau.Balise.Connexion.ConnexionCheck.ConnectionStatusChange += new ConnectionChecker.ConnectionChangeDelegate(Connections_ConnectionStatusChange);
                
                if (Connexions.ConnexionMove.ConnexionCheck.Connected)
                    SetLed(ledRecMove, true);
                if (Connexions.ConnexionIO.ConnexionCheck.Connected)
                    SetLed(ledRecIO, true);
                if (Plateau.Balise.Connexion.ConnexionCheck.Connected)
                    SetLed(ledBalise, true);
                if (Connexions.ConnexionGB.ConnexionCheck.Connected)
                    SetLed(ledRecGB, true);

                batteriePack.TensionMidHigh = Config.CurrentConfig.BatterieRobotVert;
                batteriePack.TensionMid = Config.CurrentConfig.BatterieRobotOrange;
                batteriePack.TensionLow = Config.CurrentConfig.BatterieRobotRouge;
                batteriePack.TensionNull = Config.CurrentConfig.BatterieRobotCritique;

                timerBatteries = new System.Windows.Forms.Timer();
                timerBatteries.Interval = 1000;
                timerBatteries.Tick += new EventHandler(timerBatteries_Tick);
                timerBatteries.Start();
            }
        }
    }
}
