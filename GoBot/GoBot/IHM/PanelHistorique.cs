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
    public partial class PanelHistorique : UserControl
    {
        private ToolTip tooltip;
        private List<Button> listBtnHistorique;

        private Historique Historique { get; set; }

        public void SetHistorique(Historique histo) 
        {
            if(Historique != null)
                Historique.NouvelleAction -= new Historique.DelegateAction(MAJHistoriqueDel);
            Historique = histo;
            Historique.NouvelleAction += new Historique.DelegateAction(MAJHistoriqueDel);
        }

        public PanelHistorique()
        {
            InitializeComponent();

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;
            tooltip.SetToolTip(btnCopierHistorique, "Copier dans le presse-papiers");
            groupBoxHisto.DeploiementChange += new Composants.GroupBoxRetractable.DeploiementDelegate(groupBoxHisto_Deploiement);

            listBtnHistorique = new List<Button>();
            listBtnHistorique.Add(btnHistorique0);
            listBtnHistorique.Add(btnHistorique1);
            listBtnHistorique.Add(btnHistorique2);
            listBtnHistorique.Add(btnHistorique3);
            listBtnHistorique.Add(btnHistorique4);
            listBtnHistorique.Add(btnHistorique5);
            listBtnHistorique.Add(btnHistorique6);
            listBtnHistorique.Add(btnHistorique7);
            listBtnHistorique.Add(btnHistorique8);
            listBtnHistorique.Add(btnHistorique9);

            this.btnHistorique0.MouseEnter += new System.EventHandler(this.btnHistorique_MouseEnter);
            this.btnHistorique1.MouseEnter += new System.EventHandler(this.btnHistorique_MouseEnter);
            this.btnHistorique2.MouseEnter += new System.EventHandler(this.btnHistorique_MouseEnter);
            this.btnHistorique3.MouseEnter += new System.EventHandler(this.btnHistorique_MouseEnter);
            this.btnHistorique4.MouseEnter += new System.EventHandler(this.btnHistorique_MouseEnter);
            this.btnHistorique5.MouseEnter += new System.EventHandler(this.btnHistorique_MouseEnter);
            this.btnHistorique6.MouseEnter += new System.EventHandler(this.btnHistorique_MouseEnter);
            this.btnHistorique7.MouseEnter += new System.EventHandler(this.btnHistorique_MouseEnter);
            this.btnHistorique8.MouseEnter += new System.EventHandler(this.btnHistorique_MouseEnter);
            this.btnHistorique9.MouseEnter += new System.EventHandler(this.btnHistorique_MouseEnter);

            this.btnHistorique0.Click += new System.EventHandler(this.btnHistorique_Click);
            this.btnHistorique1.Click += new System.EventHandler(this.btnHistorique_Click);
            this.btnHistorique2.Click += new System.EventHandler(this.btnHistorique_Click);
            this.btnHistorique3.Click += new System.EventHandler(this.btnHistorique_Click);
            this.btnHistorique4.Click += new System.EventHandler(this.btnHistorique_Click);
            this.btnHistorique5.Click += new System.EventHandler(this.btnHistorique_Click);
            this.btnHistorique6.Click += new System.EventHandler(this.btnHistorique_Click);
            this.btnHistorique7.Click += new System.EventHandler(this.btnHistorique_Click);
            this.btnHistorique8.Click += new System.EventHandler(this.btnHistorique_Click);
            this.btnHistorique9.Click += new System.EventHandler(this.btnHistorique_Click);
        }

        void groupBoxHisto_Deploiement(bool deploye)
        {
            Config.CurrentConfig.HistoriqueGROuvert = deploye;
            Config.CurrentConfig.HistoriquePROuvert = deploye;
        }

        private void MAJHistoriqueDel(IAction action)
        {
            /*this.Invoke(new EventHandler(delegate
            {
                MAJHistorique(action);
            }));*/
        }

        private void MAJHistorique(IAction action)
        {
            lblHistorique.Text = "";
            btnCopierHistorique.Enabled = true;

            for (int iAction = 0; iAction < Historique.Actions.Count; iAction++)
            {
                listBtnHistorique[iAction].Image = Historique.Actions[iAction].Image;
                listBtnHistorique[iAction].Enabled = true;
            }
        }

        private void btnHistorique_MouseEnter(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            for (int iBtn = 0; iBtn < 10; iBtn++)
            {
                if (listBtnHistorique[iBtn] == bouton && Historique.Actions.Count >= iBtn)
                    lblHistorique.Text = Historique.Actions[iBtn].ToString();
            }
        }

        private void btnHistorique_Click(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            for (int iBtn = 0; iBtn < 10; iBtn++)
            {
                if (listBtnHistorique[iBtn] == bouton && Historique.Actions.Count >= iBtn)
                {
                    Historique.Actions[iBtn].Executer();
                    btnHistorique_MouseEnter(bouton, null);
                }
            }
        }

        private void btnCopierHistorique_Click(object sender, EventArgs e)
        {
            if (Historique.Actions.Count == 0)
                Clipboard.SetText("Aucune action");
            else
            {
                String chaine = "";
                foreach (IAction action in Historique.Actions)
                    chaine += action.ToString() + Environment.NewLine;

                Clipboard.SetText(chaine);
            }

            btnCopierHistorique.Enabled = false;
        }

        private void PanelHistorique_Load(object sender, EventArgs e)
        {
            groupBoxHisto.Deployer(Config.CurrentConfig.HistoriqueGROuvert, false);
        }
    }
}
