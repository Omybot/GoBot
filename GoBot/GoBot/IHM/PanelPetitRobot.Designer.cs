namespace GoBot.IHM
{
    partial class PanelPetitRobot
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDeplacement = new GoBot.IHM.PanelDeplacement();
            this.panelHistorique = new GoBot.IHM.PanelHistorique();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelReglagePetit1 = new GoBot.IHM.PanelPetitRobotReglage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panelPetitRobotUtilisation1 = new GoBot.IHM.PanelPetitRobotUtilisation();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.panelDeplacement);
            this.flowLayoutPanel1.Controls.Add(this.panelHistorique);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(343, 556);
            this.flowLayoutPanel1.TabIndex = 90;
            // 
            // panelDeplacement
            // 
            this.panelDeplacement.AutoSize = true;
            this.panelDeplacement.BackColor = System.Drawing.Color.Transparent;
            this.panelDeplacement.Location = new System.Drawing.Point(3, 3);
            this.panelDeplacement.Name = "panelDeplacement";
            this.panelDeplacement.Robot = null;
            this.panelDeplacement.Size = new System.Drawing.Size(337, 262);
            this.panelDeplacement.TabIndex = 72;
            // 
            // panelHistorique
            // 
            this.panelHistorique.AutoSize = true;
            this.panelHistorique.BackColor = System.Drawing.Color.Transparent;
            this.panelHistorique.Location = new System.Drawing.Point(3, 271);
            this.panelHistorique.Name = "panelHistorique";
            this.panelHistorique.Size = new System.Drawing.Size(337, 115);
            this.panelHistorique.TabIndex = 71;
            this.panelHistorique.Resize += new System.EventHandler(this.panelHistorique_Resize);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel2.Controls.Add(this.panelReglagePetit1);
            this.flowLayoutPanel2.Controls.Add(this.panelPetitRobotUtilisation1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(352, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(343, 559);
            this.flowLayoutPanel2.TabIndex = 91;
            // 
            // panelReglagePetit1
            // 
            this.panelReglagePetit1.AutoSize = true;
            this.panelReglagePetit1.BackColor = System.Drawing.Color.Transparent;
            this.panelReglagePetit1.Location = new System.Drawing.Point(3, 3);
            this.panelReglagePetit1.Name = "panelReglagePetit1";
            this.panelReglagePetit1.Size = new System.Drawing.Size(340, 45);
            this.panelReglagePetit1.TabIndex = 0;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.ForeColor = System.Drawing.Color.Green;
            this.txtLog.Location = new System.Drawing.Point(701, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(299, 543);
            this.txtLog.TabIndex = 92;
            // 
            // panelPetitRobotUtilisation1
            // 
            this.panelPetitRobotUtilisation1.AutoSize = true;
            this.panelPetitRobotUtilisation1.BackColor = System.Drawing.Color.Transparent;
            this.panelPetitRobotUtilisation1.Location = new System.Drawing.Point(3, 54);
            this.panelPetitRobotUtilisation1.Name = "panelPetitRobotUtilisation1";
            this.panelPetitRobotUtilisation1.Size = new System.Drawing.Size(340, 45);
            this.panelPetitRobotUtilisation1.TabIndex = 1;
            // 
            // PanelPetitRobot
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PanelPetitRobot";
            this.Size = new System.Drawing.Size(1003, 562);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private PanelHistorique panelHistorique;
        private System.Windows.Forms.TextBox txtLog;
        private PanelDeplacement panelDeplacement;
        private PanelPetitRobotReglage panelReglagePetit1;
        private PanelPetitRobotUtilisation panelPetitRobotUtilisation1;

    }
}
