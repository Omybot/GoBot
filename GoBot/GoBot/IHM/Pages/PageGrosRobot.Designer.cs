namespace GoBot.IHM.Pages
{
    partial class PageGrosRobot
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
            this.panelDisplacement = new GoBot.IHM.PanelDisplacement();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPositionables = new GoBot.IHM.PanelPositionables();
            this.panelSpeedConfig1 = new GoBot.IHM.PanelSpeedConfig();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelActuatorsOnOff1 = new GoBot.IHM.PanelActuatorsOnOff();
            this.panelSensorsOnOff1 = new GoBot.IHM.PanelSensorsOnOff();
            this.panelSensorsColor = new GoBot.IHM.PanelSensorsColor();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.panelDisplacement);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(343, 556);
            this.flowLayoutPanel1.TabIndex = 90;
            // 
            // panelDisplacement
            // 
            this.panelDisplacement.AutoSize = true;
            this.panelDisplacement.BackColor = System.Drawing.Color.Transparent;
            this.panelDisplacement.Location = new System.Drawing.Point(3, 3);
            this.panelDisplacement.Name = "panelDisplacement";
            this.panelDisplacement.Robot = null;
            this.panelDisplacement.Size = new System.Drawing.Size(326, 449);
            this.panelDisplacement.TabIndex = 72;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel2.Controls.Add(this.pnlPositionables);
            this.flowLayoutPanel2.Controls.Add(this.panelSpeedConfig1);
            this.flowLayoutPanel2.Controls.Add(this.panelSensorsOnOff1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(352, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(343, 562);
            this.flowLayoutPanel2.TabIndex = 91;
            // 
            // pnlPositionables
            // 
            this.pnlPositionables.AutoSize = true;
            this.pnlPositionables.BackColor = System.Drawing.Color.Transparent;
            this.pnlPositionables.Location = new System.Drawing.Point(3, 3);
            this.pnlPositionables.Name = "pnlPositionables";
            this.pnlPositionables.Size = new System.Drawing.Size(326, 148);
            this.pnlPositionables.TabIndex = 115;
            // 
            // panelSpeedConfig1
            // 
            this.panelSpeedConfig1.Location = new System.Drawing.Point(3, 157);
            this.panelSpeedConfig1.Name = "panelSpeedConfig1";
            this.panelSpeedConfig1.Size = new System.Drawing.Size(330, 245);
            this.panelSpeedConfig1.TabIndex = 119;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel3.Controls.Add(this.panelActuatorsOnOff1);
            this.flowLayoutPanel3.Controls.Add(this.panelSensorsColor);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(699, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(343, 562);
            this.flowLayoutPanel3.TabIndex = 92;
            // 
            // panelActuatorsOnOff1
            // 
            this.panelActuatorsOnOff1.BackColor = System.Drawing.Color.Transparent;
            this.panelActuatorsOnOff1.Location = new System.Drawing.Point(3, 3);
            this.panelActuatorsOnOff1.Name = "panelActuatorsOnOff1";
            this.panelActuatorsOnOff1.Size = new System.Drawing.Size(330, 110);
            this.panelActuatorsOnOff1.TabIndex = 0;
            // 
            // panelSensorsOnOff1
            // 
            this.panelSensorsOnOff1.BackColor = System.Drawing.Color.Transparent;
            this.panelSensorsOnOff1.Location = new System.Drawing.Point(3, 408);
            this.panelSensorsOnOff1.Name = "panelSensorsOnOff1";
            this.panelSensorsOnOff1.Size = new System.Drawing.Size(330, 110);
            this.panelSensorsOnOff1.TabIndex = 1;
            // 
            // panelSensorsColor
            // 
            this.panelSensorsColor.Location = new System.Drawing.Point(3, 119);
            this.panelSensorsColor.Name = "panelSensorsColor";
            this.panelSensorsColor.Size = new System.Drawing.Size(330, 353);
            this.panelSensorsColor.TabIndex = 1;
            // 
            // PageGrosRobot
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PageGrosRobot";
            this.Size = new System.Drawing.Size(1003, 562);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private PanelDisplacement panelDisplacement;
        private PanelPositionables pnlPositionables;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private PanelSpeedConfig panelSpeedConfig1;
        private PanelActuatorsOnOff panelActuatorsOnOff1;
        private PanelSensorsOnOff panelSensorsOnOff1;
        private PanelSensorsColor panelSensorsColor;
    }
}
