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
        ToolTip tooltip;
        List<Button> listBtnHistorique;

        private Historique historique;

        public void setHistorique(Historique histo) 
        {
            if(historique != null)
                historique.nouvelleAction -= new Historique.delegateAction(MAJHistoriqueDel);
            historique = histo;
            historique.nouvelleAction += new Historique.delegateAction(MAJHistoriqueDel);
        }

        int tailleMax;
        int tailleMin;

        public PanelHistorique()
        {
            InitializeComponent();

            tailleMax = groupHistorique.Height;
            tailleMin = 39;

            tooltip = new ToolTip();
            tooltip.InitialDelay = 1500;
            tooltip.SetToolTip(btnCopierHistorique, "Copier dans le presse-papiers");

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

        private void btnTaille_Click(object sender, EventArgs e)
        {
            if (groupHistorique.Height == tailleMax)
                Deployer(false);
            else
                Deployer(true);
        }

        public void Deployer(bool deployer)
        {
            if (!deployer)
            {
                groupHistorique.Height = tailleMin;
                btnTaille.Image = Properties.Resources.bas;
                tooltip.SetToolTip(btnTaille, "Agrandir");
            }
            else
            {
                groupHistorique.Height = tailleMax;
                btnTaille.Image = Properties.Resources.haut;
                tooltip.SetToolTip(btnTaille, "Réduire");
            }
        }

        private void MAJHistoriqueDel(IAction action)
        {
            this.Invoke(new EventHandler(delegate
            {
                MAJHistorique(action);
            }));
        }

        private void MAJHistorique(IAction action)
        {
            lblHistorique.Text = "";
            btnCopierHistorique.Enabled = true;

            for (int iAction = 0; iAction < historique.Actions.Count; iAction++)
            {
                listBtnHistorique[iAction].Image = historique.Actions[iAction].Image;
                listBtnHistorique[iAction].Enabled = true;
            }
        }

        private void btnHistorique_MouseEnter(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            for (int iBtn = 0; iBtn < 10; iBtn++)
            {
                if (listBtnHistorique[iBtn] == bouton && historique.Actions.Count >= iBtn)
                    lblHistorique.Text = historique.Actions[iBtn].ToString();
            }
        }

        private void btnHistorique_Click(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            for (int iBtn = 0; iBtn < 10; iBtn++)
            {
                if (listBtnHistorique[iBtn] == bouton && historique.Actions.Count >= iBtn)
                {
                    historique.Actions[iBtn].Executer();
                    btnHistorique_MouseEnter(bouton, null);
                }
            }
        }

        private void btnCopierHistorique_Click(object sender, EventArgs e)
        {
            if (historique.Actions.Count == 0)
                Clipboard.SetText("Aucune action");
            else
            {
                String chaine = "";
                foreach (IAction action in historique.Actions)
                    chaine += action.ToString() + Environment.NewLine;


                Clipboard.SetText(chaine);
            }

            btnCopierHistorique.Enabled = false;
        }
    }
}
