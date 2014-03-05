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
    public partial class PanelPetitRobot : UserControl
    {
        public PanelPetitRobot()
        {
            InitializeComponent();
        }

        public void Init()
        {
            panelDeplacement.Robot = Robots.PetitRobot;
            panelDeplacement.Init();
            panelHistorique.SetHistorique(Robots.PetitRobot.Historique);
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

        private void panelHistorique_Resize(object sender, EventArgs e)
        {
            if (panelHistorique.Height > 50)
                Config.CurrentConfig.HistoriquePROuvert = true;
            else
                Config.CurrentConfig.HistoriquePROuvert = false;
        }
    }
}
