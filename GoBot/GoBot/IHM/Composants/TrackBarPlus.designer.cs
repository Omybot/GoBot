namespace GoBot.IHM.Composants
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
            this.imgCurseur = new System.Windows.Forms.PictureBox();
            this.imgBarre = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCurseur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBarre)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCurseur
            // 
            this.imgCurseur.Image = global::GoBot.Properties.Resources.trackBarCurseurNormal;
            this.imgCurseur.Location = new System.Drawing.Point(0, 0);
            this.imgCurseur.Name = "imgCurseur";
            this.imgCurseur.Size = new System.Drawing.Size(15, 15);
            this.imgCurseur.TabIndex = 0;
            this.imgCurseur.TabStop = false;
            // 
            // imgBarre
            // 
            this.imgBarre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBarre.BackgroundImage = global::GoBot.Properties.Resources.trackBarFond;
            this.imgBarre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgBarre.ErrorImage = null;
            this.imgBarre.ImageLocation = " ";
            this.imgBarre.Location = new System.Drawing.Point(0, 5);
            this.imgBarre.Name = "imgBarre";
            this.imgBarre.Size = new System.Drawing.Size(150, 5);
            this.imgBarre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBarre.TabIndex = 3;
            this.imgBarre.TabStop = false;
            // 
            // TrackBarPlus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.imgCurseur);
            this.Controls.Add(this.imgBarre);
            this.MaximumSize = new System.Drawing.Size(3000, 15);
            this.MinimumSize = new System.Drawing.Size(0, 15);
            this.Name = "TrackBarPlus";
            this.Size = new System.Drawing.Size(150, 15);
            this.Enter += new System.EventHandler(this.TrackBarPlus_Enter);
            this.Leave += new System.EventHandler(this.TrackBarPlus_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.imgCurseur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBarre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCurseur;
        private System.Windows.Forms.PictureBox imgBarre;
    }
}
