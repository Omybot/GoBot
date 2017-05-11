namespace Composants
{
    partial class ColorDisplay
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
            this.lblR = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.picR = new System.Windows.Forms.PictureBox();
            this.picG = new System.Windows.Forms.PictureBox();
            this.picB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB)).BeginInit();
            this.SuspendLayout();
            // 
            // lblR
            // 
            this.lblR.Location = new System.Drawing.Point(60, 56);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(25, 13);
            this.lblR.TabIndex = 1;
            this.lblR.Text = "255";
            this.lblR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblG
            // 
            this.lblG.Location = new System.Drawing.Point(91, 56);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(25, 13);
            this.lblG.TabIndex = 2;
            this.lblG.Text = "255";
            this.lblG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblB
            // 
            this.lblB.Location = new System.Drawing.Point(122, 56);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(25, 13);
            this.lblB.TabIndex = 3;
            this.lblB.Text = "255";
            this.lblB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picColor
            // 
            this.picColor.Location = new System.Drawing.Point(3, 3);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(50, 50);
            this.picColor.TabIndex = 0;
            this.picColor.TabStop = false;
            // 
            // picR
            // 
            this.picR.Location = new System.Drawing.Point(59, 3);
            this.picR.Name = "picR";
            this.picR.Size = new System.Drawing.Size(26, 50);
            this.picR.TabIndex = 4;
            this.picR.TabStop = false;
            // 
            // picG
            // 
            this.picG.Location = new System.Drawing.Point(90, 3);
            this.picG.Name = "picG";
            this.picG.Size = new System.Drawing.Size(26, 50);
            this.picG.TabIndex = 5;
            this.picG.TabStop = false;
            // 
            // picB
            // 
            this.picB.Location = new System.Drawing.Point(121, 3);
            this.picB.Name = "picB";
            this.picB.Size = new System.Drawing.Size(26, 50);
            this.picB.TabIndex = 6;
            this.picB.TabStop = false;
            // 
            // ColorDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picB);
            this.Controls.Add(this.picG);
            this.Controls.Add(this.picR);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblG);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.picColor);
            this.Name = "ColorDisplay";
            this.Size = new System.Drawing.Size(150, 77);
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.PictureBox picR;
        private System.Windows.Forms.PictureBox picG;
        private System.Windows.Forms.PictureBox picB;
    }
}
