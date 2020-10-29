namespace GoBot.IHM.Pages
{
    partial class PagePandaTable
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
            this.btnTrap = new System.Windows.Forms.Button();
            this.picTable = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTrap
            // 
            this.btnTrap.Location = new System.Drawing.Point(-25, -25);
            this.btnTrap.Name = "btnTrap";
            this.btnTrap.Size = new System.Drawing.Size(23, 23);
            this.btnTrap.TabIndex = 81;
            this.btnTrap.UseVisualStyleBackColor = true;
            // 
            // picTable
            // 
            this.picTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picTable.Location = new System.Drawing.Point(3, 3);
            this.picTable.Name = "picTable";
            this.picTable.Size = new System.Drawing.Size(914, 594);
            this.picTable.TabIndex = 0;
            this.picTable.TabStop = false;
            // 
            // PagePandaTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnTrap);
            this.Controls.Add(this.picTable);
            this.DoubleBuffered = true;
            this.Name = "PagePandaTable";
            this.Size = new System.Drawing.Size(920, 600);
            this.Load += new System.EventHandler(this.PagePandaTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picTable;
        private System.Windows.Forms.Button btnTrap;
    }
}
