﻿using System;
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
    public partial class PanelGrosRobot : UserControl
    {
        public PanelGrosRobot()
        {
            InitializeComponent();
        }

        public void Init()
        {
            panelDeplacement.Robot = Robots.GrosRobot;
            panelDeplacement.Init();
            panelHistorique.SetHistorique(Robots.GrosRobot.Historique);
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
