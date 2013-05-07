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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelReglageGros1 = new GoBot.IHM.PanelGrosRobotReglage();
            this.panelUtilGros1 = new GoBot.IHM.PanelGrosRobotUtilisation();
            this.panelSequencesGros1 = new GoBot.IHM.PanelGrosRobotSequences();
            this.panelCapteursGros1 = new GoBot.IHM.PanelGrosRobotCapteurs();
            this.panelDeplacement = new GoBot.IHM.PanelDeplacement();
            this.panelHistorique = new GoBot.IHM.PanelHistorique();
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
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtLog.Location = new System.Drawing.Point(706, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(294, 543);
            this.txtLog.TabIndex = 92;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel2.Controls.Add(this.panelReglageGros1);
            this.flowLayoutPanel2.Controls.Add(this.panelUtilGros1);
            this.flowLayoutPanel2.Controls.Add(this.panelSequencesGros1);
            this.flowLayoutPanel2.Controls.Add(this.panelCapteursGros1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(352, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(343, 562);
            this.flowLayoutPanel2.TabIndex = 91;
            // 
            // panelReglageGros1
            // 
            this.panelReglageGros1.AutoSize = true;
            this.panelReglageGros1.BackColor = System.Drawing.Color.Transparent;
            this.panelReglageGros1.Location = new System.Drawing.Point(3, 3);
            this.panelReglageGros1.Name = "panelReglageGros1";
            this.panelReglageGros1.Size = new System.Drawing.Size(340, 45);
            this.panelReglageGros1.TabIndex = 115;
            // 
            // panelUtilGros1
            // 
            this.panelUtilGros1.AutoSize = true;
            this.panelUtilGros1.BackColor = System.Drawing.Color.Transparent;
            this.panelUtilGros1.Location = new System.Drawing.Point(3, 54);
            this.panelUtilGros1.Name = "panelUtilGros1";
            this.panelUtilGros1.Size = new System.Drawing.Size(340, 45);
            this.panelUtilGros1.TabIndex = 116;
            // 
            // panelSequencesGros1
            // 
            this.panelSequencesGros1.AutoSize = true;
            this.panelSequencesGros1.BackColor = System.Drawing.Color.Transparent;
            this.panelSequencesGros1.Location = new System.Drawing.Point(3, 105);
            this.panelSequencesGros1.Name = "panelSequencesGros1";
            this.panelSequencesGros1.Size = new System.Drawing.Size(340, 45);
            this.panelSequencesGros1.TabIndex = 117;
            // 
            // panelCapteursGros1
            // 
            this.panelCapteursGros1.AutoSize = true;
            this.panelCapteursGros1.BackColor = System.Drawing.Color.Transparent;
            this.panelCapteursGros1.Location = new System.Drawing.Point(3, 156);
            this.panelCapteursGros1.Name = "panelCapteursGros1";
            this.panelCapteursGros1.Size = new System.Drawing.Size(340, 45);
            this.panelCapteursGros1.TabIndex = 118;
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
            // PanelGrosRobot
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PanelGrosRobot";
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
        private PanelHistorique panelHistorique;
        private System.Windows.Forms.TextBox txtLog;
        private PanelDeplacement panelDeplacement;
        private PanelGrosRobotReglage panelReglageGros1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private PanelGrosRobotUtilisation panelUtilGros1;
        private PanelGrosRobotSequences panelSequencesGros1;
        private PanelGrosRobotCapteurs panelCapteursGros1;

    }
}
