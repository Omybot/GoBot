namespace GoBot.IHM
{
    partial class PanelConnexions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelConnexions));
            this.lblVoltage = new System.Windows.Forms.Label();
            this.batteryPack = new Composants.Battery();
            this._ledsPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.batteryPack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVoltage
            // 
            this.lblVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Location = new System.Drawing.Point(38, 7);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(10, 13);
            this.lblVoltage.TabIndex = 98;
            this.lblVoltage.Text = "-";
            // 
            // batteriePack
            // 
            this.batteryPack.CurrentState = Composants.Battery.State.VeryLow;
            this.batteryPack.CurrentVoltage = 0D;
            this.batteryPack.Image = ((System.Drawing.Image)(resources.GetObject("batteriePack.Image")));
            this.batteryPack.Location = new System.Drawing.Point(14, 6);
            this.batteryPack.Name = "batteriePack";
            this.batteryPack.Size = new System.Drawing.Size(16, 16);
            this.batteryPack.TabIndex = 89;
            this.batteryPack.TabStop = false;
            this.batteryPack.VoltageAverage = 0D;
            this.batteryPack.VoltageHigh = 0D;
            this.batteryPack.VoltageLow = 0D;
            this.batteryPack.VoltageVeryLow = 0D;
            // 
            // _ledsPanel
            // 
            this._ledsPanel.Location = new System.Drawing.Point(83, 3);
            this._ledsPanel.Name = "_ledsPanel";
            this._ledsPanel.Size = new System.Drawing.Size(1165, 24);
            this._ledsPanel.TabIndex = 99;
            // 
            // PanelConnexions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._ledsPanel);
            this.Controls.Add(this.lblVoltage);
            this.Controls.Add(this.batteryPack);
            this.Name = "PanelConnexions";
            this.Size = new System.Drawing.Size(1251, 27);
            this.Load += new System.EventHandler(this.PanelConnexions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.batteryPack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Composants.Battery batteryPack;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.FlowLayoutPanel _ledsPanel;
    }
}
