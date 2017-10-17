using System;
using System.Drawing;
using System.Windows.Forms;

namespace Composants
{
    public partial class ConnectionIndicator : PictureBox
    {
        private Timer BlinkTimer { get; set; }
        private int BlinkCounter { get; set; } = 0;

        /// <summary>
        /// Obtient l'état actuel de la connexion entrante
        /// </summary>
        public bool StateIn { get; protected set; }

        /// <summary>
        /// Obtient l'état actuel de la connexion sortante
        /// </summary>
        public bool StateOut { get; protected set; }

        public ConnectionIndicator()
        {
            InitializeComponent();
            BlinkTimer = new Timer();
            BlinkTimer.Interval = 100;
            BlinkTimer.Tick += new EventHandler(timer_Tick);
            SetConnectionState(false, false);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Visible = !Visible;
            BlinkCounter++;
            if (BlinkCounter > 7)
                BlinkTimer.Stop();
        }

        /// <summary>
        /// Permet de déterminer l'état des connexions
        /// </summary>
        /// <param name="stateIn">Etat de la connexion entrante</param>
        /// <param name="stateOut">Etat de la connexion sortante</param>
        /// <param name="blink">Si vrai, clignotement si changement d'état</param>
        public void SetConnectionState(bool stateIn, bool stateOut, bool blink = false)
        {
            if (stateIn != StateIn || stateOut != StateOut)
            {
                StateIn = stateIn;
                StateOut = stateOut;

                if (StateIn && StateOut)
                    SetImage(Properties.Resources.ConnectionOk, blink);
                else if (!StateIn && !StateOut)
                    SetImage(Properties.Resources.ConnectionNok, blink);
                else
                    SetImage(Properties.Resources.ConnectionHalf, blink);
            }
        }

        private void SetImage(Image img, bool blink = false)
        {
            BlinkTimer.Stop();
            Visible = true;
            BlinkCounter = 0;
            Image = img;
            if (blink)
                BlinkTimer.Start();
        }
    }
}
