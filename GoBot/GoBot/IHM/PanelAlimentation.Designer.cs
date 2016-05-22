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
            this.ctrlGraphique = new Composants.CtrlGraphique();
            this.batteriePack1 = new Composants.Batterie();
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack1)).BeginInit();
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
            // PanelAlimentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.batteriePack1);
            this.Controls.Add(this.ctrlGraphique);
            this.Controls.Add(this.lblTensionPack1);
            this.Controls.Add(this.label1);
            this.Name = "PanelAlimentation";
            this.Size = new System.Drawing.Size(1025, 501);
            this.Load += new System.EventHandler(this.PanelAlimentation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.batteriePack1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTensionPack1;
        private Composants.CtrlGraphique ctrlGraphique;
        private Composants.Batterie batteriePack1;

    }
}
