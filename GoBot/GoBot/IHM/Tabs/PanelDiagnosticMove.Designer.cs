namespace GoBot.IHM
{
    partial class PanelDiagnosticMove
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
            this.ctrlGraphique = new Composants.GraphPanel();
            this.btnDemandeCharge = new System.Windows.Forms.Button();
            this.ctrlGraphique1 = new Composants.GraphPanel();
            this.ctrlGraphique2 = new Composants.GraphPanel();
            this.lblChargeCPU = new System.Windows.Forms.Label();
            this.pictureBoxVumetreCPU = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVumetreCPU)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlGraphique
            // 
            this.ctrlGraphique.BackColor = System.Drawing.Color.White;
            this.ctrlGraphique.GraphScale = Composants.GraphPanel.ScaleType.Fixed;
            this.ctrlGraphique.LimitsVisible = false;
            this.ctrlGraphique.Location = new System.Drawing.Point(199, 64);
            this.ctrlGraphique.MaxLimit = 1D;
            this.ctrlGraphique.MinLimit = 0D;
            this.ctrlGraphique.Name = "ctrlGraphique";
            this.ctrlGraphique.NamesVisible = false;
            this.ctrlGraphique.Size = new System.Drawing.Size(773, 170);
            this.ctrlGraphique.TabIndex = 123;
            // 
            // btnDemandeCharge
            // 
            this.btnDemandeCharge.Location = new System.Drawing.Point(55, 128);
            this.btnDemandeCharge.Name = "btnDemandeCharge";
            this.btnDemandeCharge.Size = new System.Drawing.Size(75, 23);
            this.btnDemandeCharge.TabIndex = 124;
            this.btnDemandeCharge.Text = "Lancer";
            this.btnDemandeCharge.UseVisualStyleBackColor = true;
            this.btnDemandeCharge.Click += new System.EventHandler(this.btnDemandeCharge_Click);
            // 
            // ctrlGraphique1
            // 
            this.ctrlGraphique1.BackColor = System.Drawing.Color.White;
            this.ctrlGraphique1.GraphScale = Composants.GraphPanel.ScaleType.Fixed;
            this.ctrlGraphique1.LimitsVisible = false;
            this.ctrlGraphique1.Location = new System.Drawing.Point(199, 240);
            this.ctrlGraphique1.MaxLimit = 4000D;
            this.ctrlGraphique1.MinLimit = -4000D;
            this.ctrlGraphique1.Name = "ctrlGraphique1";
            this.ctrlGraphique1.NamesVisible = false;
            this.ctrlGraphique1.Size = new System.Drawing.Size(773, 170);
            this.ctrlGraphique1.TabIndex = 125;
            // 
            // ctrlGraphique2
            // 
            this.ctrlGraphique2.BackColor = System.Drawing.Color.White;
            this.ctrlGraphique2.GraphScale = Composants.GraphPanel.ScaleType.Fixed;
            this.ctrlGraphique2.LimitsVisible = false;
            this.ctrlGraphique2.Location = new System.Drawing.Point(199, 416);
            this.ctrlGraphique2.MaxLimit = 4000D;
            this.ctrlGraphique2.MinLimit = -4000D;
            this.ctrlGraphique2.Name = "ctrlGraphique2";
            this.ctrlGraphique2.NamesVisible = false;
            this.ctrlGraphique2.Size = new System.Drawing.Size(773, 170);
            this.ctrlGraphique2.TabIndex = 126;
            // 
            // lblChargeCPU
            // 
            this.lblChargeCPU.AutoSize = true;
            this.lblChargeCPU.Location = new System.Drawing.Point(1052, 128);
            this.lblChargeCPU.Name = "lblChargeCPU";
            this.lblChargeCPU.Size = new System.Drawing.Size(21, 13);
            this.lblChargeCPU.TabIndex = 127;
            this.lblChargeCPU.Text = "0%";
            // 
            // pictureBoxVumetreCPU
            // 
            this.pictureBoxVumetreCPU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxVumetreCPU.Location = new System.Drawing.Point(1034, 103);
            this.pictureBoxVumetreCPU.Name = "pictureBoxVumetreCPU";
            this.pictureBoxVumetreCPU.Size = new System.Drawing.Size(12, 75);
            this.pictureBoxVumetreCPU.TabIndex = 128;
            this.pictureBoxVumetreCPU.TabStop = false;
            // 
            // PanelDiagnosticMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxVumetreCPU);
            this.Controls.Add(this.lblChargeCPU);
            this.Controls.Add(this.ctrlGraphique2);
            this.Controls.Add(this.ctrlGraphique1);
            this.Controls.Add(this.btnDemandeCharge);
            this.Controls.Add(this.ctrlGraphique);
            this.Name = "PanelDiagnosticMove";
            this.Size = new System.Drawing.Size(1254, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVumetreCPU)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Composants.GraphPanel ctrlGraphique;
        private System.Windows.Forms.Button btnDemandeCharge;
        private Composants.GraphPanel ctrlGraphique1;
        private Composants.GraphPanel ctrlGraphique2;
        private System.Windows.Forms.Label lblChargeCPU;
        private System.Windows.Forms.PictureBox pictureBoxVumetreCPU;
    }
}
