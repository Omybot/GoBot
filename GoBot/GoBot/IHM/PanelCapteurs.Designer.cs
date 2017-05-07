namespace GoBot.IHM
{
    partial class PanelCapteurs
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
            this.btnColor = new Composants.SwitchBouton();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.lblCapteurCouleurTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Transparent;
            this.btnColor.Location = new System.Drawing.Point(119, 20);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(35, 15);
            this.btnColor.Symetrique = true;
            this.btnColor.TabIndex = 0;
            this.btnColor.ChangementEtat += new System.EventHandler(this.btnColor_ChangementEtat);
            // 
            // picColor
            // 
            this.picColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picColor.Location = new System.Drawing.Point(28, 41);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(126, 62);
            this.picColor.TabIndex = 1;
            this.picColor.TabStop = false;
            // 
            // lblCapteurCouleurTxt
            // 
            this.lblCapteurCouleurTxt.AutoSize = true;
            this.lblCapteurCouleurTxt.Location = new System.Drawing.Point(25, 20);
            this.lblCapteurCouleurTxt.Name = "lblCapteurCouleurTxt";
            this.lblCapteurCouleurTxt.Size = new System.Drawing.Size(88, 13);
            this.lblCapteurCouleurTxt.TabIndex = 2;
            this.lblCapteurCouleurTxt.Text = "Capteur couleur :";
            // 
            // PanelCapteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCapteurCouleurTxt);
            this.Controls.Add(this.picColor);
            this.Controls.Add(this.btnColor);
            this.Name = "PanelCapteurs";
            this.Size = new System.Drawing.Size(213, 140);
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Composants.SwitchBouton btnColor;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.Label lblCapteurCouleurTxt;
    }
}
