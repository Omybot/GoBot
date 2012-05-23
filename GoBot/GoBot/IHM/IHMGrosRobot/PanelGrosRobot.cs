using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.Actions;

namespace GoBot.IHM.IHMGrosRobot
{
    public partial class PanelGrosRobot : UserControl
    {
        public PanelGrosRobot()
        {
            InitializeComponent();

            panelHistorique.Deployer(Config.CurrentConfig.HistoriqueGROuvert);
        }

        public void Init()
        {
            panelDeplacementGR.Init();
            panelPinces.Init();

            panelHistorique.setHistorique(GrosRobot.Historique);
            GrosRobot.Historique.nouvelleAction += new Historique.delegateAction(MAJHistoriqueDel);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Config.Save();
            Control parent = Parent;
            while(parent.Parent != null)
                parent = parent.Parent;

            if(parent != null)
                parent.Dispose();
        }

        private void btnFenetre_Click(object sender, EventArgs e)
        {
            Fenetre fen = new Fenetre(new PanelGrosRobot());
            fen.Show();
        }

        private void panelHistorique_Resize(object sender, EventArgs e)
        {
            if (panelHistorique.Height > 50)
                Config.CurrentConfig.HistoriqueGROuvert = true;
            else
                Config.CurrentConfig.HistoriqueGROuvert = false;
        }
    }
}
