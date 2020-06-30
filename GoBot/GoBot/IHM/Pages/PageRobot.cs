using System;
using System.Windows.Forms;

namespace GoBot.IHM.Pages
{
    public partial class PageRobot : UserControl
    {
        public PageRobot()
        {
            InitializeComponent();
        }

        public void Init()
        {
            panelDisplacement.Robot = Robots.MainRobot;
            panelDisplacement.Init();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Config.Save();
            Control parent = Parent;
            while (parent.Parent != null)
                parent = parent.Parent;

            if (parent != null)
                parent.Dispose();
        }

        private void rdoMainRobot_CheckedChanged(object sender, EventArgs e)
        {
            if (Config.CurrentConfig.IsMiniRobot != !rdoMainRobot.Checked)
            {
                Config.CurrentConfig.IsMiniRobot = !rdoMainRobot.Checked;
                Robots.Init();
            }
        }

        private void PageRobot_Load(object sender, EventArgs e)
        {
            rdoMainRobot.Checked = !Config.CurrentConfig.IsMiniRobot;
            rdoSecondaryRobot.Checked = Config.CurrentConfig.IsMiniRobot;
        }
    }
}
