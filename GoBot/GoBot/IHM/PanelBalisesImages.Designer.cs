namespace GoBot.IHM
{
    partial class PanelBalisesImages
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
            this.panelImageBalise1 = new GoBot.IHM.PanelBaliseImage();
            this.panelImageBalise2 = new GoBot.IHM.PanelBaliseImage();
            this.panelImageBalise3 = new GoBot.IHM.PanelBaliseImage();
            this.SuspendLayout();
            // 
            // panelImageBalise1
            // 
            this.panelImageBalise1.Location = new System.Drawing.Point(17, 3);
            this.panelImageBalise1.Name = "panelImageBalise1";
            this.panelImageBalise1.Size = new System.Drawing.Size(962, 128);
            this.panelImageBalise1.TabIndex = 0;
            // 
            // panelImageBalise2
            // 
            this.panelImageBalise2.Location = new System.Drawing.Point(17, 156);
            this.panelImageBalise2.Name = "panelImageBalise2";
            this.panelImageBalise2.Size = new System.Drawing.Size(962, 128);
            this.panelImageBalise2.TabIndex = 1;
            // 
            // panelImageBalise3
            // 
            this.panelImageBalise3.Location = new System.Drawing.Point(17, 321);
            this.panelImageBalise3.Name = "panelImageBalise3";
            this.panelImageBalise3.Size = new System.Drawing.Size(962, 128);
            this.panelImageBalise3.TabIndex = 2;
            // 
            // PanelImagesBalises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelImageBalise3);
            this.Controls.Add(this.panelImageBalise2);
            this.Controls.Add(this.panelImageBalise1);
            this.Name = "PanelImagesBalises";
            this.Size = new System.Drawing.Size(1025, 501);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelBaliseImage panelImageBalise1;
        private PanelBaliseImage panelImageBalise2;
        private PanelBaliseImage panelImageBalise3;


    }
}
