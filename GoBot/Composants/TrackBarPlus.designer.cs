namespace Composants
{
    partial class TrackBarPlus
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
            this.SuspendLayout();
            // 
            // TrackBarPlus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(3000, 15);
            this.MinimumSize = new System.Drawing.Size(0, 15);
            this.Name = "TrackBarPlus";
            this.Size = new System.Drawing.Size(150, 15);
            this.SizeChanged += new System.EventHandler(this.TrackBarPlus_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TrackBarPlus_Paint);
            this.Enter += new System.EventHandler(this.TrackBarPlus_Enter);
            this.Leave += new System.EventHandler(this.TrackBarPlus_Leave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
