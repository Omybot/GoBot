namespace GoBot.IHM
{
    partial class PanelActuatorOnOff
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
            this.btnOnOff = new Composants.SwitchButton();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOnOff
            // 
            this.btnOnOff.AutoSize = true;
            this.btnOnOff.BackColor = System.Drawing.Color.Transparent;
            this.btnOnOff.Location = new System.Drawing.Point(4, 5);
            this.btnOnOff.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnOnOff.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnOnOff.Mirrored = false;
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(35, 15);
            this.btnOnOff.TabIndex = 0;
            this.btnOnOff.Value = false;
            this.btnOnOff.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnOnOff_ValueChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(46, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(16, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "...";
            // 
            // PanelActuatorOnOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnOnOff);
            this.Name = "PanelActuatorOnOff";
            this.Size = new System.Drawing.Size(320, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Composants.SwitchButton btnOnOff;
        private System.Windows.Forms.Label lblName;
    }
}
