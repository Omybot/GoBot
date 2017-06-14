using System;
using System.Drawing;
using System.Windows.Forms;

namespace Composants
{
    public partial class ConnectionIndicator : PictureBox
    {
        private Timer BlinkTimer { get; set; }
        private int BlinkCounter { get; set; } = 0;

        public bool StateIn { get; protected set; }
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

        public void SetConnectionState(bool stateIn, bool stateOut, bool blink = false)
        {
            if (stateIn != StateIn || stateOut != StateOut)
            {
                StateIn = stateIn;
                StateOut = stateOut;

                if (StateIn && StateOut)
                    SetImage(Properties.Resources.ConnexionOk, blink);
                else if (!StateIn && !StateOut)
                    SetImage(Properties.Resources.ConnexionNok, blink);
                else
                    SetImage(Properties.Resources.ConnexionUnilateral, blink);
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
