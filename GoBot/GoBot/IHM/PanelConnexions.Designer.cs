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
            this.lblRecBoi = new System.Windows.Forms.Label();
            this.lblRecBeu = new System.Windows.Forms.Label();
            this.lblRecBun = new System.Windows.Forms.Label();
            this.lblRecIO = new System.Windows.Forms.Label();
            this.lblRecMiwi = new System.Windows.Forms.Label();
            this.lblRecMove = new System.Windows.Forms.Label();
            this.ledRecBoi = new Composants.Led();
            this.ledRecBeu = new Composants.Led();
            this.ledRecBun = new Composants.Led();
            this.ledRecPi = new Composants.Led();
            this.ledRecMiwi = new Composants.Led();
            this.ledRecMove = new Composants.Led();
            this.batterieBoi = new Composants.Batterie();
            this.batterieBeu = new Composants.Batterie();
            this.batterieBun = new Composants.Batterie();
            this.batteriePack2 = new Composants.Batterie();
            this.batteriePack1 = new Composants.Batterie();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecPi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecMiwi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batterieBoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batterieBeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batterieBun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecBoi
            // 
            this.lblRecBoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecBoi.AutoSize = true;
            this.lblRecBoi.Location = new System.Drawing.Point(808, 7);
            this.lblRecBoi.Name = "lblRecBoi";
            this.lblRecBoi.Size = new System.Drawing.Size(42, 13);
            this.lblRecBoi.TabIndex = 85;
            this.lblRecBoi.Text = "RecBoi";
            // 
            // lblRecBeu
            // 
            this.lblRecBeu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecBeu.AutoSize = true;
            this.lblRecBeu.Location = new System.Drawing.Point(658, 8);
            this.lblRecBeu.Name = "lblRecBeu";
            this.lblRecBeu.Size = new System.Drawing.Size(46, 13);
            this.lblRecBeu.TabIndex = 83;
            this.lblRecBeu.Text = "RecBeu";
            // 
            // lblRecBun
            // 
            this.lblRecBun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecBun.AutoSize = true;
            this.lblRecBun.Location = new System.Drawing.Point(510, 8);
            this.lblRecBun.Name = "lblRecBun";
            this.lblRecBun.Size = new System.Drawing.Size(46, 13);
            this.lblRecBun.TabIndex = 81;
            this.lblRecBun.Text = "RecBun";
            // 
            // lblRecIO
            // 
            this.lblRecIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecIO.AutoSize = true;
            this.lblRecIO.Location = new System.Drawing.Point(362, 8);
            this.lblRecIO.Name = "lblRecIO";
            this.lblRecIO.Size = new System.Drawing.Size(38, 13);
            this.lblRecIO.TabIndex = 79;
            this.lblRecIO.Text = "RecIO";
            // 
            // lblRecMiwi
            // 
            this.lblRecMiwi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecMiwi.AutoSize = true;
            this.lblRecMiwi.Location = new System.Drawing.Point(45, 8);
            this.lblRecMiwi.Name = "lblRecMiwi";
            this.lblRecMiwi.Size = new System.Drawing.Size(48, 13);
            this.lblRecMiwi.TabIndex = 77;
            this.lblRecMiwi.Text = "RecMiwi";
            // 
            // lblRecMove
            // 
            this.lblRecMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecMove.AutoSize = true;
            this.lblRecMove.Location = new System.Drawing.Point(202, 7);
            this.lblRecMove.Name = "lblRecMove";
            this.lblRecMove.Size = new System.Drawing.Size(54, 13);
            this.lblRecMove.TabIndex = 75;
            this.lblRecMove.Text = "RecMove";
            // 
            // ledRecBoi
            // 
            this.ledRecBoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecBoi.Etat = false;
            this.ledRecBoi.Image = ((System.Drawing.Image)(resources.GetObject("ledRecBoi.Image")));
            this.ledRecBoi.Location = new System.Drawing.Point(762, 7);
            this.ledRecBoi.Name = "ledRecBoi";
            this.ledRecBoi.Size = new System.Drawing.Size(16, 16);
            this.ledRecBoi.TabIndex = 84;
            this.ledRecBoi.TabStop = false;
            // 
            // ledRecBeu
            // 
            this.ledRecBeu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecBeu.Etat = false;
            this.ledRecBeu.Image = ((System.Drawing.Image)(resources.GetObject("ledRecBeu.Image")));
            this.ledRecBeu.Location = new System.Drawing.Point(614, 7);
            this.ledRecBeu.Name = "ledRecBeu";
            this.ledRecBeu.Size = new System.Drawing.Size(16, 16);
            this.ledRecBeu.TabIndex = 82;
            this.ledRecBeu.TabStop = false;
            // 
            // ledRecBun
            // 
            this.ledRecBun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecBun.Etat = false;
            this.ledRecBun.Image = ((System.Drawing.Image)(resources.GetObject("ledRecBun.Image")));
            this.ledRecBun.Location = new System.Drawing.Point(466, 7);
            this.ledRecBun.Name = "ledRecBun";
            this.ledRecBun.Size = new System.Drawing.Size(16, 16);
            this.ledRecBun.TabIndex = 80;
            this.ledRecBun.TabStop = false;
            // 
            // ledRecPi
            // 
            this.ledRecPi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecPi.Etat = false;
            this.ledRecPi.Image = ((System.Drawing.Image)(resources.GetObject("ledRecPi.Image")));
            this.ledRecPi.Location = new System.Drawing.Point(318, 7);
            this.ledRecPi.Name = "ledRecPi";
            this.ledRecPi.Size = new System.Drawing.Size(16, 16);
            this.ledRecPi.TabIndex = 78;
            this.ledRecPi.TabStop = false;
            // 
            // ledRecMiwi
            // 
            this.ledRecMiwi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecMiwi.Etat = false;
            this.ledRecMiwi.Image = ((System.Drawing.Image)(resources.GetObject("ledRecMiwi.Image")));
            this.ledRecMiwi.Location = new System.Drawing.Point(23, 6);
            this.ledRecMiwi.Name = "ledRecMiwi";
            this.ledRecMiwi.Size = new System.Drawing.Size(16, 16);
            this.ledRecMiwi.TabIndex = 76;
            this.ledRecMiwi.TabStop = false;
            // 
            // ledRecMove
            // 
            this.ledRecMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecMove.Etat = false;
            this.ledRecMove.Image = ((System.Drawing.Image)(resources.GetObject("ledRecMove.Image")));
            this.ledRecMove.Location = new System.Drawing.Point(158, 6);
            this.ledRecMove.Name = "ledRecMove";
            this.ledRecMove.Size = new System.Drawing.Size(16, 16);
            this.ledRecMove.TabIndex = 74;
            this.ledRecMove.TabStop = false;
            // 
            // batterieBoi
            // 
            this.batterieBoi.Etat = false;
            this.batterieBoi.Image = ((System.Drawing.Image)(resources.GetObject("batterieBoi.Image")));
            this.batterieBoi.Location = new System.Drawing.Point(786, 7);
            this.batterieBoi.Name = "batterieBoi";
            this.batterieBoi.Size = new System.Drawing.Size(16, 16);
            this.batterieBoi.TabIndex = 86;
            this.batterieBoi.TabStop = false;
            // 
            // batterieBeu
            // 
            this.batterieBeu.Etat = false;
            this.batterieBeu.Image = ((System.Drawing.Image)(resources.GetObject("batterieBeu.Image")));
            this.batterieBeu.Location = new System.Drawing.Point(636, 7);
            this.batterieBeu.Name = "batterieBeu";
            this.batterieBeu.Size = new System.Drawing.Size(16, 16);
            this.batterieBeu.TabIndex = 87;
            this.batterieBeu.TabStop = false;
            // 
            // batterieBun
            // 
            this.batterieBun.Etat = false;
            this.batterieBun.Image = ((System.Drawing.Image)(resources.GetObject("batterieBun.Image")));
            this.batterieBun.Location = new System.Drawing.Point(488, 6);
            this.batterieBun.Name = "batterieBun";
            this.batterieBun.Size = new System.Drawing.Size(16, 16);
            this.batterieBun.TabIndex = 88;
            this.batterieBun.TabStop = false;
            // 
            // batteriePack2
            // 
            this.batteriePack2.Etat = false;
            this.batteriePack2.Image = ((System.Drawing.Image)(resources.GetObject("batteriePack2.Image")));
            this.batteriePack2.Location = new System.Drawing.Point(340, 7);
            this.batteriePack2.Name = "batteriePack2";
            this.batteriePack2.Size = new System.Drawing.Size(16, 16);
            this.batteriePack2.TabIndex = 89;
            this.batteriePack2.TabStop = false;
            // 
            // batteriePack1
            // 
            this.batteriePack1.Etat = false;
            this.batteriePack1.Image = ((System.Drawing.Image)(resources.GetObject("batteriePack1.Image")));
            this.batteriePack1.Location = new System.Drawing.Point(180, 6);
            this.batteriePack1.Name = "batteriePack1";
            this.batteriePack1.Size = new System.Drawing.Size(16, 16);
            this.batteriePack1.TabIndex = 90;
            this.batteriePack1.TabStop = false;
            // 
            // PanelConnexions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.batteriePack1);
            this.Controls.Add(this.batteriePack2);
            this.Controls.Add(this.batterieBun);
            this.Controls.Add(this.batterieBeu);
            this.Controls.Add(this.batterieBoi);
            this.Controls.Add(this.lblRecBoi);
            this.Controls.Add(this.ledRecBoi);
            this.Controls.Add(this.lblRecBeu);
            this.Controls.Add(this.ledRecBeu);
            this.Controls.Add(this.lblRecBun);
            this.Controls.Add(this.ledRecBun);
            this.Controls.Add(this.lblRecIO);
            this.Controls.Add(this.ledRecPi);
            this.Controls.Add(this.lblRecMiwi);
            this.Controls.Add(this.ledRecMiwi);
            this.Controls.Add(this.lblRecMove);
            this.Controls.Add(this.ledRecMove);
            this.Name = "PanelConnexions";
            this.Size = new System.Drawing.Size(850, 27);
            this.Load += new System.EventHandler(this.PanelConnexions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecPi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecMiwi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batterieBoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batterieBeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batterieBun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecBoi;
        private Composants.Led ledRecBoi;
        private System.Windows.Forms.Label lblRecBeu;
        private Composants.Led ledRecBeu;
        private System.Windows.Forms.Label lblRecBun;
        private Composants.Led ledRecBun;
        private System.Windows.Forms.Label lblRecIO;
        private Composants.Led ledRecPi;
        private System.Windows.Forms.Label lblRecMiwi;
        private Composants.Led ledRecMiwi;
        private System.Windows.Forms.Label lblRecMove;
        private Composants.Led ledRecMove;
        private Composants.Batterie batterieBoi;
        private Composants.Batterie batterieBeu;
        private Composants.Batterie batterieBun;
        private Composants.Batterie batteriePack2;
        private Composants.Batterie batteriePack1;

    }
}
