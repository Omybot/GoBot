namespace GoBot.IHM
{
    partial class PanelAlimentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelAlimentation));
            this.label1 = new System.Windows.Forms.Label();
            this.lblTensionPack1 = new System.Windows.Forms.Label();
            this.lblTensionPack2 = new System.Windows.Forms.Label();
            this.ctrlGraphique = new Composants.CtrlGraphique();
            this.batteriePack1 = new Composants.Batterie();
            this.batteriePack2 = new Composants.Batterie();
            this.batteriePRPack2 = new Composants.Batterie();
            this.batteriePRPack1 = new Composants.Batterie();
            this.lblBatPRPack2 = new System.Windows.Forms.Label();
            this.lblBatPRPack1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePRPack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePRPack1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gros Robot :";
            // 
            // lblTensionPack1
            // 
            this.lblTensionPack1.AutoSize = true;
            this.lblTensionPack1.Location = new System.Drawing.Point(126, 67);
            this.lblTensionPack1.Name = "lblTensionPack1";
            this.lblTensionPack1.Size = new System.Drawing.Size(23, 13);
            this.lblTensionPack1.TabIndex = 4;
            this.lblTensionPack1.Text = "0 V";
            // 
            // lblTensionPack2
            // 
            this.lblTensionPack2.AutoSize = true;
            this.lblTensionPack2.Location = new System.Drawing.Point(126, 92);
            this.lblTensionPack2.Name = "lblTensionPack2";
            this.lblTensionPack2.Size = new System.Drawing.Size(23, 13);
            this.lblTensionPack2.TabIndex = 5;
            this.lblTensionPack2.Text = "0 V";
            // 
            // ctrlGraphique
            // 
            this.ctrlGraphique.BackColor = System.Drawing.Color.White;
            this.ctrlGraphique.EchelleCommune = true;
            this.ctrlGraphique.EchelleFixe = false;
            this.ctrlGraphique.EchelleMax = 1D;
            this.ctrlGraphique.EchelleMin = 0D;
            this.ctrlGraphique.Location = new System.Drawing.Point(210, 25);
            this.ctrlGraphique.Name = "ctrlGraphique";
            this.ctrlGraphique.Size = new System.Drawing.Size(719, 446);
            this.ctrlGraphique.TabIndex = 15;
            // 
            // batteriePack1
            // 
            this.batteriePack1.Afficher = false;
            this.batteriePack1.Image = ((System.Drawing.Image)(resources.GetObject("batteriePack1.Image")));
            this.batteriePack1.Location = new System.Drawing.Point(104, 67);
            this.batteriePack1.Name = "batteriePack1";
            this.batteriePack1.Size = new System.Drawing.Size(16, 16);
            this.batteriePack1.TabIndex = 21;
            this.batteriePack1.TabStop = false;
            this.batteriePack1.Tension = 0D;
            this.batteriePack1.TensionLow = 0D;
            this.batteriePack1.TensionMid = 0D;
            this.batteriePack1.TensionMidHigh = 0D;
            this.batteriePack1.TensionNull = 0D;
            // 
            // batteriePack2
            // 
            this.batteriePack2.Afficher = false;
            this.batteriePack2.Image = ((System.Drawing.Image)(resources.GetObject("batteriePack2.Image")));
            this.batteriePack2.Location = new System.Drawing.Point(104, 89);
            this.batteriePack2.Name = "batteriePack2";
            this.batteriePack2.Size = new System.Drawing.Size(16, 16);
            this.batteriePack2.TabIndex = 22;
            this.batteriePack2.TabStop = false;
            this.batteriePack2.Tension = 0D;
            this.batteriePack2.TensionLow = 0D;
            this.batteriePack2.TensionMid = 0D;
            this.batteriePack2.TensionMidHigh = 0D;
            this.batteriePack2.TensionNull = 0D;
            // 
            // batteriePRPack2
            // 
            this.batteriePRPack2.Afficher = false;
            this.batteriePRPack2.Image = ((System.Drawing.Image)(resources.GetObject("batteriePRPack2.Image")));
            this.batteriePRPack2.Location = new System.Drawing.Point(104, 134);
            this.batteriePRPack2.Name = "batteriePRPack2";
            this.batteriePRPack2.Size = new System.Drawing.Size(16, 16);
            this.batteriePRPack2.TabIndex = 36;
            this.batteriePRPack2.TabStop = false;
            this.batteriePRPack2.Tension = 0D;
            this.batteriePRPack2.TensionLow = 0D;
            this.batteriePRPack2.TensionMid = 0D;
            this.batteriePRPack2.TensionMidHigh = 0D;
            this.batteriePRPack2.TensionNull = 0D;
            // 
            // batteriePRPack1
            // 
            this.batteriePRPack1.Afficher = false;
            this.batteriePRPack1.Image = ((System.Drawing.Image)(resources.GetObject("batteriePRPack1.Image")));
            this.batteriePRPack1.Location = new System.Drawing.Point(104, 112);
            this.batteriePRPack1.Name = "batteriePRPack1";
            this.batteriePRPack1.Size = new System.Drawing.Size(16, 16);
            this.batteriePRPack1.TabIndex = 35;
            this.batteriePRPack1.TabStop = false;
            this.batteriePRPack1.Tension = 0D;
            this.batteriePRPack1.TensionLow = 0D;
            this.batteriePRPack1.TensionMid = 0D;
            this.batteriePRPack1.TensionMidHigh = 0D;
            this.batteriePRPack1.TensionNull = 0D;
            // 
            // lblBatPRPack2
            // 
            this.lblBatPRPack2.AutoSize = true;
            this.lblBatPRPack2.Location = new System.Drawing.Point(126, 137);
            this.lblBatPRPack2.Name = "lblBatPRPack2";
            this.lblBatPRPack2.Size = new System.Drawing.Size(23, 13);
            this.lblBatPRPack2.TabIndex = 34;
            this.lblBatPRPack2.Text = "0 V";
            // 
            // lblBatPRPack1
            // 
            this.lblBatPRPack1.AutoSize = true;
            this.lblBatPRPack1.Location = new System.Drawing.Point(126, 115);
            this.lblBatPRPack1.Name = "lblBatPRPack1";
            this.lblBatPRPack1.Size = new System.Drawing.Size(23, 13);
            this.lblBatPRPack1.TabIndex = 33;
            this.lblBatPRPack1.Text = "0 V";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Petit Robot :";
            // 
            // PanelAlimentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.batteriePRPack2);
            this.Controls.Add(this.batteriePRPack1);
            this.Controls.Add(this.lblBatPRPack2);
            this.Controls.Add(this.lblBatPRPack1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.batteriePack2);
            this.Controls.Add(this.batteriePack1);
            this.Controls.Add(this.ctrlGraphique);
            this.Controls.Add(this.lblTensionPack2);
            this.Controls.Add(this.lblTensionPack1);
            this.Controls.Add(this.label1);
            this.Name = "PanelAlimentation";
            this.Size = new System.Drawing.Size(1025, 501);
            this.Load += new System.EventHandler(this.PanelAlimentation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePRPack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePRPack1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTensionPack1;
        private System.Windows.Forms.Label lblTensionPack2;
        private Composants.CtrlGraphique ctrlGraphique;
        private Composants.Batterie batteriePack1;
        private Composants.Batterie batteriePack2;
        private Composants.Batterie batteriePRPack2;
        private Composants.Batterie batteriePRPack1;
        private System.Windows.Forms.Label lblBatPRPack2;
        private System.Windows.Forms.Label lblBatPRPack1;
        private System.Windows.Forms.Label label6;

    }
}
