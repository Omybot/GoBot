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

namespace GoBot.IHM
{
    public partial class PanelConnexions : UserControl
    {
        public PanelConnexions()
        {
            InitializeComponent();
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
            Led selectLed = null;
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

        private void SetLed(Led led, bool on)
        {
            if (on)
                led.CouleurVert(true);
            else
                led.CouleurRouge(true);
        }

        private void PanelConnexions_Load(object sender, EventArgs e)
        {
            if (!Config.DesignMode)
            {
                if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
                    SetLed(ledRecMove, true);
                if (Connexions.ConnexionMiwi.ConnexionCheck.Connecte)
                    SetLed(ledRecMiwi, true);
                if (Connexions.ConnexionPi.ConnexionCheck.Connecte)
                    SetLed(ledRecPi, true);
                if (Balise.GetBalise(Carte.RecBun).ConnexionCheck.Connecte)
                    SetLed(ledRecBun, true);
                if (Balise.GetBalise(Carte.RecBeu).ConnexionCheck.Connecte)
                    SetLed(ledRecBeu, true);
                if (Balise.GetBalise(Carte.RecBoi).ConnexionCheck.Connecte)
                    SetLed(ledRecBoi, true);

                Connexions.ConnexionMove.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMoveCheck_ConnexionChange);
                Connexions.ConnexionMiwi.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMiwiCheck_ConnexionChange);
                Connexions.ConnexionPi.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionPiCheck_ConnexionChange);

                Balise.GetBalise(Carte.RecBun).ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBunCheck_ConnexionChange);
                Balise.GetBalise(Carte.RecBeu).ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBeuCheck_ConnexionChange);
                Balise.GetBalise(Carte.RecBoi).ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBoiCheck_ConnexionChange);
            }
        }
    }
}
