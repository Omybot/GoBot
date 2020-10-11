using System;
using System.Windows.Forms;

namespace GoBot.IHM.Pages
{
    public partial class PagePandaMove : UserControl
    {
        bool _asserEna = true; // TODO faut garder la vraie valeur dans le robot...

        public PagePandaMove()
        {
            InitializeComponent();
        }

        private void PagePandaMove_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                btnTrap.Focus();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            Robots.MainRobot.PivotRight(90);
            btnTrap.Focus();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Robots.MainRobot.MoveForward(100);
            btnTrap.Focus();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Robots.MainRobot.MoveBackward(100);
            btnTrap.Focus();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            Robots.MainRobot.PivotLeft(90);
            btnTrap.Focus();
        }

        private void btnAsserv_Click(object sender, EventArgs e)
        {
            _asserEna = !_asserEna;

            if (_asserEna)
            {
                Robots.MainRobot.Stop(StopMode.Abrupt);
                btnAsserv.Image = Properties.Resources.GearsOn124;
            }
            else
            {
                Robots.MainRobot.Stop(StopMode.Freely);
                btnAsserv.Image = Properties.Resources.GearsOff124;
            }

            btnTrap.Focus();
        }

        private void btnCalibration_Click(object sender, EventArgs e)
        {
            Robots.MainRobot.Recalibration(SensAR.Arriere, true);
            btnTrap.Focus();
        }
    }
}
