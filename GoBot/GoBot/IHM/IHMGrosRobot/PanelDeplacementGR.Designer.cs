namespace GoBot.IHM.IHMGrosRobot
{
    partial class PanelDeplacementGR
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
            this.groupDeplacement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReglageVertical)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAvance
            // 
            this.btnAvance.Click += new System.EventHandler(this.btnAvance_Click_1);
            // 
            // PanelDeplacementGR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "PanelDeplacementGR";
            this.Size = new System.Drawing.Size(337, 262);
            this.groupDeplacement.ResumeLayout(false);
            this.groupDeplacement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReglageVertical)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
