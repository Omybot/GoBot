using System;
using System.Windows.Forms;

namespace GoBot.IHM.Pages
{
    public partial class PagePandaActuators : UserControl
    {
        public PagePandaActuators()
        {
            InitializeComponent();
        }

        private void PagePandaActuators_Load(object sender, System.EventArgs e)
        {
            if (!Execution.DesignMode)
            {
                
            }
        }

        private void btnFingerRight_Click(object sender, EventArgs e)
        {
            Threading.ThreadManager.CreateThread(link => Actionneurs.Actionneur.FingerRight.DoDemoGrab());
        }

        private void btnFingerLeft_Click(object sender, EventArgs e)
        {
            Threading.ThreadManager.CreateThread(link => Actionneurs.Actionneur.FingerLeft.DoDemoGrab());
        }
    }
}
