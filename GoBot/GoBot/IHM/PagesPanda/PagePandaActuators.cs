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

        private void btnFlagRight_Click(object sender, EventArgs e)
        {
            if (!_flagRight)
                Actionneur.Flags.DoOpenRight();
            else
                Actionneur.Flags.DoCloseRight();

            _flagRight = !_flagRight;
        }

        private void DemoFingerRight()
        {

        }
    }
}
