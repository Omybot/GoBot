using System;
using System.Windows.Forms;

using GoBot.Threading;

namespace GoBot.IHM.Forms
{
    public partial class FormConfirm : Form
    {
        ThreadLink _link;
        int _countdown;

        public FormConfirm()
        {
            InitializeComponent();
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            _link.Cancel();
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void FormConfirm_Shown(object sender, EventArgs e)
        {
            btnTrap.Focus();
            _countdown = 3;
            btnStay.Text = "Rester (" + _countdown + ")";
            _link = ThreadManager.CreateThread(link => Countdown());
            _link.StartLoop(1000, _countdown+2);
        }

        private void Countdown()
        {
            if (_countdown < 0)
            {
                _link.Cancel();
                btnStay.InvokeAuto(() => btnStay.PerformClick());
            }
            else
            {
                btnStay.InvokeAuto(() => btnStay.Text = "Rester (" + _countdown + ")");
            }

            _countdown -= 1;

        }
    }
}
