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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLeftColor
            // 
            this.lblLeftColor.AutoSize = true;
            this.lblLeftColor.Location = new System.Drawing.Point(58, 25);
            this.lblLeftColor.Name = "lblLeftColor";
            this.lblLeftColor.Size = new System.Drawing.Size(127, 13);
            this.lblLeftColor.TabIndex = 2;
            this.lblLeftColor.Text = "Capteur couleur gauche :";
            // 
            // btnColorLeft
            // 
            this.btnColorLeft.AutoSize = true;
            this.btnColorLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnColorLeft.Location = new System.Drawing.Point(191, 25);
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
            this.picColorLeft.Location = new System.Drawing.Point(6, 46);
            this.picColorLeft.Name = "picColorLeft";
            this.picColorLeft.Size = new System.Drawing.Size(308, 121);
            this.picColorLeft.TabIndex = 3;
            // 
            // picColorRight
            // 
            this.picColorRight.Location = new System.Drawing.Point(6, 213);
            this.picColorRight.Name = "picColorRight";
            this.picColorRight.Size = new System.Drawing.Size(308, 121);
            this.picColorRight.TabIndex = 6;
            // 
            // lblRightColor
            // 
            this.lblRightColor.AutoSize = true;
            this.lblRightColor.Location = new System.Drawing.Point(68, 192);
            this.lblRightColor.Name = "lblRightColor";
            this.lblRightColor.Size = new System.Drawing.Size(117, 13);
            this.lblRightColor.TabIndex = 5;
            this.lblRightColor.Text = "Capteur couleur droite :";
            // 
            // btnColorRight
            // 
            this.btnColorRight.AutoSize = true;
            this.btnColorRight.BackColor = System.Drawing.Color.Transparent;
            this.btnColorRight.Location = new System.Drawing.Point(191, 192);
            this.btnColorRight.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnColorRight.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnColorRight.Mirrored = true;
            this.btnColorRight.Name = "btnColorRight";
            this.btnColorRight.Size = new System.Drawing.Size(35, 15);
            this.btnColorRight.TabIndex = 4;
            this.btnColorRight.Value = false;
            this.btnColorRight.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnColorRight_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLeftColor);
            this.groupBox1.Controls.Add(this.picColorRight);
            this.groupBox1.Controls.Add(this.btnColorLeft);
            this.groupBox1.Controls.Add(this.lblRightColor);
            this.groupBox1.Controls.Add(this.picColorLeft);
            this.groupBox1.Controls.Add(this.btnColorRight);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 347);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // PanelCapteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PanelCapteurs";
            this.Size = new System.Drawing.Size(330, 353);
            this.Load += new System.EventHandler(this.PanelCapteurs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.SwitchButton btnColorLeft;
        private System.Windows.Forms.Label lblLeftColor;
        private Composants.ColorDisplay picColorLeft;
        private Composants.ColorDisplay picColorRight;
        private System.Windows.Forms.Label lblRightColor;
        private Composants.SwitchButton btnColorRight;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
