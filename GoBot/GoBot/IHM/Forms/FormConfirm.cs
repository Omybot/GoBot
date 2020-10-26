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
            _link.Cancel();
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
            _link.StartLoop(1000, _countdown + 2);
        }

        private void Countdown()
        {
            if (!_link.Cancelled)
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

        private void FormConfirm_Load(object sender, EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                if (Screen.PrimaryScreen.Bounds.Width > 1024)
                {
                    this.FormBorderStyle = FormBorderStyle.FixedSingle;
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }
    }
}
