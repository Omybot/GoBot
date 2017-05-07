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
            this.lblBalise = new System.Windows.Forms.Label();
            this.lblRecIO = new System.Windows.Forms.Label();
            this.lblRecMove = new System.Windows.Forms.Label();
            this.lblGoBot = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.ledRecGB = new Composants.IndicateurConnexion();
            this.ledRecMove = new Composants.IndicateurConnexion();
            this.ledRecIO = new Composants.IndicateurConnexion();
            this.ledBalise = new Composants.IndicateurConnexion();
            this.batteriePack = new Composants.Batterie();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBalise
            // 
            this.lblBalise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBalise.AutoSize = true;
            this.lblBalise.Location = new System.Drawing.Point(566, 7);
            this.lblBalise.Name = "lblBalise";
            this.lblBalise.Size = new System.Drawing.Size(35, 13);
            this.lblBalise.TabIndex = 81;
            this.lblBalise.Text = "Balise";
            // 
            // lblRecIO
            // 
            this.lblRecIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecIO.AutoSize = true;
            this.lblRecIO.Location = new System.Drawing.Point(294, 7);
            this.lblRecIO.Name = "lblRecIO";
            this.lblRecIO.Size = new System.Drawing.Size(38, 13);
            this.lblRecIO.TabIndex = 79;
            this.lblRecIO.Text = "RecIO";
            // 
            // lblRecMove
            // 
            this.lblRecMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecMove.AutoSize = true;
            this.lblRecMove.Location = new System.Drawing.Point(158, 7);
            this.lblRecMove.Name = "lblRecMove";
            this.lblRecMove.Size = new System.Drawing.Size(54, 13);
            this.lblRecMove.TabIndex = 75;
            this.lblRecMove.Text = "RecMove";
            // 
            // lblGoBot
            // 
            this.lblGoBot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGoBot.AutoSize = true;
            this.lblGoBot.Location = new System.Drawing.Point(430, 7);
            this.lblGoBot.Name = "lblGoBot";
            this.lblGoBot.Size = new System.Drawing.Size(57, 13);
            this.lblGoBot.TabIndex = 96;
            this.lblGoBot.Text = "RecGoBot";
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
            // ledRecGB
            // 
            this.ledRecGB.Etat = false;
            this.ledRecGB.Image = ((System.Drawing.Image)(resources.GetObject("ledRecGB.Image")));
            this.ledRecGB.Location = new System.Drawing.Point(408, 6);
            this.ledRecGB.Name = "ledRecGB";
            this.ledRecGB.Size = new System.Drawing.Size(16, 16);
            this.ledRecGB.TabIndex = 97;
            this.ledRecGB.TabStop = false;
            // 
            // ledRecMove
            // 
            this.ledRecMove.Etat = false;
            this.ledRecMove.Image = ((System.Drawing.Image)(resources.GetObject("ledRecMove.Image")));
            this.ledRecMove.Location = new System.Drawing.Point(136, 7);
            this.ledRecMove.Name = "ledRecMove";
            this.ledRecMove.Size = new System.Drawing.Size(16, 16);
            this.ledRecMove.TabIndex = 95;
            this.ledRecMove.TabStop = false;
            // 
            // ledRecIO
            // 
            this.ledRecIO.Etat = false;
            this.ledRecIO.Image = ((System.Drawing.Image)(resources.GetObject("ledRecIO.Image")));
            this.ledRecIO.Location = new System.Drawing.Point(272, 7);
            this.ledRecIO.Name = "ledRecIO";
            this.ledRecIO.Size = new System.Drawing.Size(16, 16);
            this.ledRecIO.TabIndex = 94;
            this.ledRecIO.TabStop = false;
            // 
            // ledBalise
            // 
            this.ledBalise.Etat = false;
            this.ledBalise.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise.Image")));
            this.ledBalise.Location = new System.Drawing.Point(544, 7);
            this.ledBalise.Name = "ledBalise";
            this.ledBalise.Size = new System.Drawing.Size(16, 16);
            this.ledBalise.TabIndex = 93;
            this.ledBalise.TabStop = false;
            // 
            // batteriePack
            // 
            this.batteriePack.Afficher = false;
            this.batteriePack.Image = ((System.Drawing.Image)(resources.GetObject("batteriePack.Image")));
            this.batteriePack.Location = new System.Drawing.Point(14, 6);
            this.batteriePack.Name = "batteriePack";
            this.batteriePack.Size = new System.Drawing.Size(16, 16);
            this.batteriePack.TabIndex = 89;
            this.batteriePack.TabStop = false;
            this.batteriePack.Tension = 0D;
            this.batteriePack.TensionLow = 0D;
            this.batteriePack.TensionMid = 0D;
            this.batteriePack.TensionMidHigh = 0D;
            this.batteriePack.TensionNull = 0D;
            // 
            // PanelConnexions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblVoltage);
            this.Controls.Add(this.ledRecGB);
            this.Controls.Add(this.lblGoBot);
            this.Controls.Add(this.ledRecMove);
            this.Controls.Add(this.ledRecIO);
            this.Controls.Add(this.ledBalise);
            this.Controls.Add(this.batteriePack);
            this.Controls.Add(this.lblBalise);
            this.Controls.Add(this.lblRecIO);
            this.Controls.Add(this.lblRecMove);
            this.Name = "PanelConnexions";
            this.Size = new System.Drawing.Size(979, 27);
            this.Load += new System.EventHandler(this.PanelConnexions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ledRecGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBalise;
        private System.Windows.Forms.Label lblRecIO;
        private System.Windows.Forms.Label lblRecMove;
        private Composants.Batterie batteriePack;
        private Composants.IndicateurConnexion ledBalise;
        private Composants.IndicateurConnexion ledRecIO;
        private Composants.IndicateurConnexion ledRecMove;
        private Composants.IndicateurConnexion ledRecGB;
        private System.Windows.Forms.Label lblGoBot;
        private System.Windows.Forms.Label lblVoltage;

    }
}
