using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actions;

namespace GoBot.IHM
{
    public partial class PageGrosRobot : UserControl
    {
        public PageGrosRobot()
        {
            InitializeComponent();
        }

        public void Init()
        {
            panelDeplacement.Robot = Robots.MainRobot;
            panelDeplacement.Init();
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
