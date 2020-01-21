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
            this.lblLeftColor = new System.Windows.Forms.Label();
            this.btnColorLeft = new Composants.SwitchButton();
            this.picColorLeft = new Composants.ColorDisplay();
            this.picColorRight = new Composants.ColorDisplay();
            this.lblRightColor = new System.Windows.Forms.Label();
            this.btnColorRight = new Composants.SwitchButton();
            this.SuspendLayout();
            // 
            // lblLeftColor
            // 
            this.lblLeftColor.AutoSize = true;
            this.lblLeftColor.Location = new System.Drawing.Point(30, 20);
            this.lblLeftColor.Name = "lblLeftColor";
            this.lblLeftColor.Size = new System.Drawing.Size(127, 13);
            this.lblLeftColor.TabIndex = 2;
            this.lblLeftColor.Text = "Capteur couleur gauche :";
            // 
            // btnColorLeft
            // 
            this.btnColorLeft.AutoSize = true;
            this.btnColorLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnColorLeft.Location = new System.Drawing.Point(163, 20);
            this.btnColorLeft.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnColorLeft.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnColorLeft.Mirrored = true;
            this.btnColorLeft.Name = "btnColorLeft";
            this.btnColorLeft.Size = new System.Drawing.Size(35, 15);
            this.btnColorLeft.TabIndex = 0;
            this.btnColorLeft.Value = false;
            this.btnColorLeft.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnColorLeft_ValueChanged);
            // 
            // picColorLeft
            // 
            this.picColorLeft.Location = new System.Drawing.Point(11, 50);
            this.picColorLeft.Name = "picColorLeft";
            this.picColorLeft.Size = new System.Drawing.Size(232, 121);
            this.picColorLeft.TabIndex = 3;
            // 
            // picColorRight
            // 
            this.picColorRight.Location = new System.Drawing.Point(11, 217);
            this.picColorRight.Name = "picColorRight";
            this.picColorRight.Size = new System.Drawing.Size(232, 121);
            this.picColorRight.TabIndex = 6;
            // 
            // lblRightColor
            // 
            this.lblRightColor.AutoSize = true;
            this.lblRightColor.Location = new System.Drawing.Point(40, 187);
            this.lblRightColor.Name = "lblRightColor";
            this.lblRightColor.Size = new System.Drawing.Size(117, 13);
            this.lblRightColor.TabIndex = 5;
            this.lblRightColor.Text = "Capteur couleur droite :";
            // 
            // btnColorRight
            // 
            this.btnColorRight.AutoSize = true;
            this.btnColorRight.BackColor = System.Drawing.Color.Transparent;
            this.btnColorRight.Location = new System.Drawing.Point(163, 187);
            this.btnColorRight.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnColorRight.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnColorRight.Mirrored = true;
            this.btnColorRight.Name = "btnColorRight";
            this.btnColorRight.Size = new System.Drawing.Size(35, 15);
            this.btnColorRight.TabIndex = 4;
            this.btnColorRight.Value = false;
            this.btnColorRight.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnColorRight_ValueChanged);
            // 
            // PanelCapteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picColorRight);
            this.Controls.Add(this.lblRightColor);
            this.Controls.Add(this.btnColorRight);
            this.Controls.Add(this.picColorLeft);
            this.Controls.Add(this.lblLeftColor);
            this.Controls.Add(this.btnColorLeft);
            this.Name = "PanelCapteurs";
            this.Size = new System.Drawing.Size(264, 353);
            this.Load += new System.EventHandler(this.PanelCapteurs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Composants.SwitchButton btnColorLeft;
        private System.Windows.Forms.Label lblLeftColor;
        private Composants.ColorDisplay picColorLeft;
        private Composants.ColorDisplay picColorRight;
        private System.Windows.Forms.Label lblRightColor;
        private Composants.SwitchButton btnColorRight;
    }
}
