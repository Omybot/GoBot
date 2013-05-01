namespace GoBot.IHM
{
    partial class PanelCapteursGros
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
            this.groupBoxCap = new System.Windows.Forms.GroupBox();
            this.lblCouleur = new System.Windows.Forms.Label();
            this.boxCouleur = new System.Windows.Forms.CheckBox();
            this.boxBalle = new System.Windows.Forms.CheckBox();
            this.btnTaille = new System.Windows.Forms.Button();
            this.ledPresence = new GoBot.IHM.Composants.Led();
            this.groupBoxCap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledPresence)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCap
            // 
            this.groupBoxCap.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxCap.Controls.Add(this.ledPresence);
            this.groupBoxCap.Controls.Add(this.lblCouleur);
            this.groupBoxCap.Controls.Add(this.boxCouleur);
            this.groupBoxCap.Controls.Add(this.boxBalle);
            this.groupBoxCap.Controls.Add(this.btnTaille);
            this.groupBoxCap.Location = new System.Drawing.Point(5, 3);
            this.groupBoxCap.Name = "groupBoxCap";
            this.groupBoxCap.Size = new System.Drawing.Size(332, 122);
            this.groupBoxCap.TabIndex = 0;
            this.groupBoxCap.TabStop = false;
            this.groupBoxCap.Text = "Capteurs";
            // 
            // lblCouleur
            // 
            this.lblCouleur.AutoSize = true;
            this.lblCouleur.Location = new System.Drawing.Point(131, 72);
            this.lblCouleur.Name = "lblCouleur";
            this.lblCouleur.Size = new System.Drawing.Size(10, 13);
            this.lblCouleur.TabIndex = 91;
            this.lblCouleur.Text = "-";
            // 
            // boxCouleur
            // 
            this.boxCouleur.AutoSize = true;
            this.boxCouleur.Location = new System.Drawing.Point(26, 71);
            this.boxCouleur.Name = "boxCouleur";
            this.boxCouleur.Size = new System.Drawing.Size(93, 17);
            this.boxCouleur.TabIndex = 90;
            this.boxCouleur.Text = "Couleur balle :";
            this.boxCouleur.UseVisualStyleBackColor = true;
            this.boxCouleur.CheckedChanged += new System.EventHandler(this.boxCouleur_CheckedChanged);
            // 
            // boxBalle
            // 
            this.boxBalle.AutoSize = true;
            this.boxBalle.Location = new System.Drawing.Point(26, 36);
            this.boxBalle.Name = "boxBalle";
            this.boxBalle.Size = new System.Drawing.Size(102, 17);
            this.boxBalle.TabIndex = 88;
            this.boxBalle.Text = "Présence balle :";
            this.boxBalle.UseVisualStyleBackColor = true;
            this.boxBalle.CheckedChanged += new System.EventHandler(this.boxBalle_CheckedChanged);
            // 
            // btnTaille
            // 
            this.btnTaille.Image = global::GoBot.Properties.Resources.haut;
            this.btnTaille.Location = new System.Drawing.Point(304, 10);
            this.btnTaille.Name = "btnTaille";
            this.btnTaille.Size = new System.Drawing.Size(24, 23);
            this.btnTaille.TabIndex = 87;
            this.btnTaille.UseVisualStyleBackColor = true;
            this.btnTaille.Click += new System.EventHandler(this.btnTaille_Click);
            // 
            // ledPresence
            // 
            this.ledPresence.Etat = false;
            this.ledPresence.Location = new System.Drawing.Point(134, 36);
            this.ledPresence.Name = "ledPresence";
            this.ledPresence.Size = new System.Drawing.Size(16, 16);
            this.ledPresence.TabIndex = 92;
            this.ledPresence.TabStop = false;
            // 
            // PanelCapteursGros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxCap);
            this.Name = "PanelCapteursGros";
            this.Size = new System.Drawing.Size(341, 131);
            this.Load += new System.EventHandler(this.PanelSequencesGros_Load);
            this.groupBoxCap.ResumeLayout(false);
            this.groupBoxCap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledPresence)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCap;
        protected System.Windows.Forms.Button btnTaille;
        private System.Windows.Forms.CheckBox boxBalle;
        private System.Windows.Forms.Label lblCouleur;
        private System.Windows.Forms.CheckBox boxCouleur;
        private Composants.Led ledPresence;
    }
}
