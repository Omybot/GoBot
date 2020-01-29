namespace GoBot.IHM.Pages
{
    partial class PageStorage
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
            this.panelStorage1 = new GoBot.IHM.Panels.PanelStorage();
            this.SuspendLayout();
            // 
            // panelStorage1
            // 
            this.panelStorage1.BackColor = System.Drawing.Color.Transparent;
            this.panelStorage1.Location = new System.Drawing.Point(3, 3);
            this.panelStorage1.Name = "panelStorage1";
            this.panelStorage1.Size = new System.Drawing.Size(500, 592);
            this.panelStorage1.TabIndex = 0;
            // 
            // PageStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelStorage1);
            this.Name = "PageStorage";
            this.Size = new System.Drawing.Size(1022, 598);
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.PanelStorage panelStorage1;
    }
}
