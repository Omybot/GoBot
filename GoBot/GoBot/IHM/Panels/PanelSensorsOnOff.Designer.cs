namespace GoBot.IHM
{
    partial class PanelSensorsOnOff
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
            this.grpSensors = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grpSensors
            // 
            this.grpSensors.Location = new System.Drawing.Point(3, 3);
            this.grpSensors.Name = "grpSensors";
            this.grpSensors.Size = new System.Drawing.Size(320, 100);
            this.grpSensors.TabIndex = 2;
            this.grpSensors.TabStop = false;
            this.grpSensors.Text = "Capteurs On / Off";
            // 
            // PanelSensorsOnOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpSensors);
            this.Name = "PanelSensorsOnOff";
            this.Size = new System.Drawing.Size(330, 110);
            this.Load += new System.EventHandler(this.PanelSensorsOnOff_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSensors;
    }
}
