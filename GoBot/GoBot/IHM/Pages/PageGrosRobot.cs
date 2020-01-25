using System;
using System.Windows.Forms;

namespace GoBot.IHM.Pages
{
    public partial class PageGrosRobot : UserControl
    {
        public PageGrosRobot()
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
            while(parent.Parent != null)
                parent = parent.Parent;

            if(parent != null)
                parent.Dispose();
        }
    }
}
