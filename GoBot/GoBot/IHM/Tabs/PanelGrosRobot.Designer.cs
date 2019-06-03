namespace GoBot.IHM
{
    partial class PanelGrosRobot
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelReglageGros1 = new GoBot.IHM.PanelGrosRobotReglage();
            this.panelCapteursGros1 = new GoBot.IHM.PanelGrosRobotCapteurs();
            this.panelDeplacement = new GoBot.IHM.PanelDeplacement();
            this.panelHistorique = new GoBot.IHM.PanelHistorique();
            this.panelGrosRobotUtilisation1 = new GoBot.IHM.PanelGrosRobotUtilisation();
            this.panelGrosRobotSequences1 = new GoBot.IHM.PanelGrosRobotSequences();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
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
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel2.Controls.Add(this.panelReglageGros1);
            this.flowLayoutPanel2.Controls.Add(this.panelCapteursGros1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(352, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(343, 562);
            this.flowLayoutPanel2.TabIndex = 91;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel3.Controls.Add(this.panelGrosRobotUtilisation1);
            this.flowLayoutPanel3.Controls.Add(this.panelGrosRobotSequences1);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(699, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(343, 559);
            this.flowLayoutPanel3.TabIndex = 119;
            // 
            // panelReglageGros1
            // 
            this.panelReglageGros1.AutoSize = true;
            this.panelReglageGros1.BackColor = System.Drawing.Color.Transparent;
            this.panelReglageGros1.Location = new System.Drawing.Point(3, 3);
            this.panelReglageGros1.Name = "panelReglageGros1";
            this.panelReglageGros1.Size = new System.Drawing.Size(338, 43);
            this.panelReglageGros1.TabIndex = 115;
            // 
            // panelCapteursGros1
            // 
            this.panelCapteursGros1.AutoSize = true;
            this.panelCapteursGros1.BackColor = System.Drawing.Color.Transparent;
            this.panelCapteursGros1.Location = new System.Drawing.Point(3, 52);
            this.panelCapteursGros1.Name = "panelCapteursGros1";
            this.panelCapteursGros1.Size = new System.Drawing.Size(338, 43);
            this.panelCapteursGros1.TabIndex = 118;
            // 
            // panelDeplacement
            // 
            this.panelDeplacement.AutoSize = true;
            this.panelDeplacement.BackColor = System.Drawing.Color.Transparent;
            this.panelDeplacement.Location = new System.Drawing.Point(3, 3);
            this.panelDeplacement.Name = "panelDeplacement";
            this.panelDeplacement.Robot = null;
            this.panelDeplacement.Size = new System.Drawing.Size(337, 419);
            this.panelDeplacement.TabIndex = 72;
            // 
            // panelHistorique
            // 
            this.panelHistorique.AutoSize = true;
            this.panelHistorique.BackColor = System.Drawing.Color.Transparent;
            this.panelHistorique.Location = new System.Drawing.Point(3, 428);
            this.panelHistorique.Name = "panelHistorique";
            this.panelHistorique.Size = new System.Drawing.Size(337, 43);
            this.panelHistorique.TabIndex = 71;
            // 
            // panelGrosRobotUtilisation1
            // 
            this.panelGrosRobotUtilisation1.AutoSize = true;
            this.panelGrosRobotUtilisation1.BackColor = System.Drawing.Color.Transparent;
            this.panelGrosRobotUtilisation1.Location = new System.Drawing.Point(3, 3);
            this.panelGrosRobotUtilisation1.Name = "panelGrosRobotUtilisation1";
            this.panelGrosRobotUtilisation1.Size = new System.Drawing.Size(338, 43);
            this.panelGrosRobotUtilisation1.TabIndex = 116;
            // 
            // panelGrosRobotSequences1
            // 
            this.panelGrosRobotSequences1.AutoSize = true;
            this.panelGrosRobotSequences1.BackColor = System.Drawing.Color.Transparent;
            this.panelGrosRobotSequences1.Location = new System.Drawing.Point(3, 52);
            this.panelGrosRobotSequences1.Name = "panelGrosRobotSequences1";
            this.panelGrosRobotSequences1.Size = new System.Drawing.Size(338, 43);
            this.panelGrosRobotSequences1.TabIndex = 117;
            // 
            // PanelGrosRobot
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Name = "PanelGrosRobot";
            this.Size = new System.Drawing.Size(1003, 562);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private PanelHistorique panelHistorique;
        private PanelDeplacement panelDeplacement;
        private PanelGrosRobotReglage panelReglageGros1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private PanelGrosRobotCapteurs panelCapteursGros1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private PanelGrosRobotUtilisation panelGrosRobotUtilisation1;
        private PanelGrosRobotSequences panelGrosRobotSequences1;

    }
}
