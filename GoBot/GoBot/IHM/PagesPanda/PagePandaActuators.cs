using GoBot.Actionneurs;
using GoBot.Threading;
using System;
using System.Windows.Forms;

namespace GoBot.IHM.Pages
{
    public partial class PagePandaActuators : UserControl
    {
        private ThreadLink _linkFingerRight, _linkFingerLeft;
        private bool _flagRight, _flagLeft;
        private bool _clamp1, _clamp2, _clamp3, _clamp4, _clamp5;

        public PagePandaActuators()
        {
            InitializeComponent();
        }

        private void PagePandaActuators_Load(object sender, System.EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                btnTrap.Focus();
            }
        }

        private void btnFingerRight_Click(object sender, EventArgs e)
        {
            if (_linkFingerRight == null)
            {
                _linkFingerRight = Threading.ThreadManager.CreateThread(link => Actionneurs.Actionneur.FingerRight.DoDemoGrab(link));
                _linkFingerRight.StartThread();
            }
            else
            {
                _linkFingerRight.Cancel();
                _linkFingerRight.WaitEnd();
                _linkFingerRight = null;
            }
        }

        private void btnFingerLeft_Click(object sender, EventArgs e)
        {
            if (_linkFingerLeft == null)
            {
                _linkFingerLeft = Threading.ThreadManager.CreateThread(link => Actionneurs.Actionneur.FingerLeft.DoDemoGrab(link));
                _linkFingerLeft.StartThread();
            }
            else
            {
                _linkFingerLeft.Cancel();
                _linkFingerLeft.WaitEnd();
                _linkFingerLeft = null;
            }
        }

        private void btnFlagLeft_Click(object sender, EventArgs e)
        {
            if (!_flagLeft)
                Actionneur.Flags.DoOpenLeft();
            else
                Actionneur.Flags.DoCloseLeft();

            _flagLeft = !_flagLeft;
        }

        private void btnClamp1_Click(object sender, EventArgs e)
        {
            _clamp1 = !_clamp1;

            if (_clamp1)
            {
                Config.CurrentConfig.ServoClamp1.SendPosition(Config.CurrentConfig.ServoClamp1.PositionOpen);
                btnClamp1.Image = Properties.Resources.Unlock64;
            }
            else
            {
                Config.CurrentConfig.ServoClamp1.SendPosition(Config.CurrentConfig.ServoClamp1.PositionClose);
                btnClamp1.Image = Properties.Resources.Lock64;
            }
        }

        private void btnClamp2_Click(object sender, EventArgs e)
        {
            _clamp2 = !_clamp2;

            if (_clamp2)
            {
                Config.CurrentConfig.ServoClamp2.SendPosition(Config.CurrentConfig.ServoClamp2.PositionOpen);
                btnClamp2.Image = Properties.Resources.Unlock64;
            }
            else
            {
                Config.CurrentConfig.ServoClamp2.SendPosition(Config.CurrentConfig.ServoClamp2.PositionClose);
                btnClamp2.Image = Properties.Resources.Lock64;
            }
        }

        private void btnClamp3_Click(object sender, EventArgs e)
        {
            _clamp3 = !_clamp3;

            if (_clamp3)
            {
                Config.CurrentConfig.ServoClamp3.SendPosition(Config.CurrentConfig.ServoClamp3.PositionOpen);
                btnClamp3.Image = Properties.Resources.Unlock64;
            }
            else
            {
                Config.CurrentConfig.ServoClamp3.SendPosition(Config.CurrentConfig.ServoClamp3.PositionClose);
                btnClamp3.Image = Properties.Resources.Lock64;
            }
        }

        private void btnClamp4_Click(object sender, EventArgs e)
        {
            _clamp4 = !_clamp4;

            if (_clamp4)
            {
                Config.CurrentConfig.ServoClamp4.SendPosition(Config.CurrentConfig.ServoClamp4.PositionOpen);
                btnClamp4.Image = Properties.Resources.Unlock64;
            }
            else
            {
                Config.CurrentConfig.ServoClamp4.SendPosition(Config.CurrentConfig.ServoClamp4.PositionClose);
                btnClamp4.Image = Properties.Resources.Lock64;
            }
        }

        private void btnClamp5_Click(object sender, EventArgs e)
        {
            _clamp5 = !_clamp5;

            if (_clamp5)
            {
                Config.CurrentConfig.ServoClamp5.SendPosition(Config.CurrentConfig.ServoClamp5.PositionOpen);
                btnClamp5.Image = Properties.Resources.Unlock64;
            }
            else
            {
                Config.CurrentConfig.ServoClamp5.SendPosition(Config.CurrentConfig.ServoClamp5.PositionClose);
                btnClamp5.Image = Properties.Resources.Lock64;
            }
        }

        private void btnFlagRight_Click(object sender, EventArgs e)
        {
            if (!_flagRight)
                Actionneur.Flags.DoOpenRight();
            else
                Actionneur.Flags.DoCloseRight();

            _flagRight = !_flagRight;
        }
    }
}
