using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actions;

namespace GoBot.IHM.IHMPetitRobot
{
    public partial class PanelPetitRobot : UserControl
    {
        public PanelPetitRobot()
        {
            InitializeComponent();
        }

        public void Init()
        {
            panelDeplacementPR.Init();
            panelBras.Init();

            panelHistorique.setHistorique(PetitRobot.Historique);
            panelHistorique.Deployer(Config.CurrentConfig.HistoriquePROuvert);

            PetitRobot.Historique.nouvelleAction += new Historique.delegateAction(MAJHistoriqueDel);
        }

        private void MAJHistoriqueDel(IAction action)
        {
            this.Invoke(new EventHandler(delegate
            {
                Historique_nouvelleAction(action);
            }));
        }

        void Historique_nouvelleAction(IAction action)
        {
            txtLog.Text = "> " + action.ToString() + Environment.NewLine + txtLog.Text;
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
