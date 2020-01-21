namespace GoBot.IHM
{
    partial class PanelActuatorsOnOff
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
            this.grpActuatorsOnOff = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grpActuatorsOnOff
            // 
            this.grpActuatorsOnOff.BackColor = System.Drawing.Color.Transparent;
            this.grpActuatorsOnOff.Location = new System.Drawing.Point(3, 3);
            this.grpActuatorsOnOff.Name = "grpActuatorsOnOff";
            this.grpActuatorsOnOff.Size = new System.Drawing.Size(320, 100);
            this.grpActuatorsOnOff.TabIndex = 0;
            this.grpActuatorsOnOff.TabStop = false;
            this.grpActuatorsOnOff.Text = "Actionneurs On / Off";
            // 
            // PanelActuatorsOnOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpActuatorsOnOff);
            this.Name = "PanelActuatorsOnOff";
            this.Size = new System.Drawing.Size(330, 110);
            this.Load += new System.EventHandler(this.PanelActuatorsOnOff_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpActuatorsOnOff;
    }
}
