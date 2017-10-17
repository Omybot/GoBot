﻿namespace GoBot.IHM
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
            this.lblCapteurCouleurTxt = new System.Windows.Forms.Label();
            this.btnColor = new Composants.SwitchButton();
            this.picColor = new Composants.ColorDisplay();
            this.SuspendLayout();
            // 
            // lblCapteurCouleurTxt
            // 
            this.lblCapteurCouleurTxt.AutoSize = true;
            this.lblCapteurCouleurTxt.Location = new System.Drawing.Point(69, 20);
            this.lblCapteurCouleurTxt.Name = "lblCapteurCouleurTxt";
            this.lblCapteurCouleurTxt.Size = new System.Drawing.Size(88, 13);
            this.lblCapteurCouleurTxt.TabIndex = 2;
            this.lblCapteurCouleurTxt.Text = "Capteur couleur :";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Transparent;
            this.btnColor.Location = new System.Drawing.Point(163, 20);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(35, 15);
            this.btnColor.Mirrored = true;
            this.btnColor.TabIndex = 0;
            this.btnColor.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnColor_ValueChanged);
            // 
            // picColor
            // 
            this.picColor.Location = new System.Drawing.Point(11, 50);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(232, 121);
            this.picColor.TabIndex = 3;
            // 
            // PanelCapteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picColor);
            this.Controls.Add(this.lblCapteurCouleurTxt);
            this.Controls.Add(this.btnColor);
            this.Name = "PanelCapteurs";
            this.Size = new System.Drawing.Size(264, 183);
            this.Load += new System.EventHandler(this.PanelCapteurs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Composants.SwitchButton btnColor;
        private System.Windows.Forms.Label lblCapteurCouleurTxt;
        private Composants.ColorDisplay picColor;
    }
}
