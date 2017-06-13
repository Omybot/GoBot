using System;
using System.Drawing;
using System.Windows.Forms;

namespace Composants
{
    public partial class ConnectionIndicator : PictureBox
    {
        private Timer BlinkTimer { get; set; }
        private int BlinkCounter { get; set; } = 0;
        
        public bool State { get; protected set; }

        public ConnectionIndicator()
        {
            InitializeComponent();
            BlinkTimer = new Timer();
            BlinkTimer.Interval = 100;
            BlinkTimer.Tick += new EventHandler(timer_Tick);
            SetConnectionState(false);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Visible = !Visible;
            BlinkCounter++;
            if (BlinkCounter > 7)
                BlinkTimer.Stop();
        }

        public void SetConnectionState(bool state, bool blink = false)
        {
            State = state;
            SetImage(state ? Properties.Resources.ConnexionOk : Properties.Resources.ConnexionNok, blink);
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
