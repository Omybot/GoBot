namespace GoBot.IHM
{
    partial class PanelImageBalise
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
            this.btnParcourir = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBoxDefilement = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.numRalentissement = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnvoyer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDefilement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRalentissement)).BeginInit();
            this.SuspendLayout();
            // 
            // btnParcourir
            // 
            this.btnParcourir.Location = new System.Drawing.Point(5, 18);
            this.btnParcourir.Name = "btnParcourir";
            this.btnParcourir.Size = new System.Drawing.Size(75, 23);
            this.btnParcourir.TabIndex = 0;
            this.btnParcourir.Text = "Parcourir";
            this.btnParcourir.UseVisualStyleBackColor = true;
            this.btnParcourir.Click += new System.EventHandler(this.btnParcourir_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(5, 47);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(720, 32);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // pictureBoxDefilement
            // 
            this.pictureBoxDefilement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDefilement.Location = new System.Drawing.Point(747, 47);
            this.pictureBoxDefilement.Name = "pictureBoxDefilement";
            this.pictureBoxDefilement.Size = new System.Drawing.Size(15, 32);
            this.pictureBoxDefilement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDefilement.TabIndex = 2;
            this.pictureBoxDefilement.TabStop = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(768, 50);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(38, 23);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // numRalentissement
            // 
            this.numRalentissement.Location = new System.Drawing.Point(893, 53);
            this.numRalentissement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRalentissement.Name = "numRalentissement";
            this.numRalentissement.Size = new System.Drawing.Size(49, 20);
            this.numRalentissement.TabIndex = 4;
            this.numRalentissement.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(812, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ralentissement";
            // 
            // btnEnvoyer
            // 
            this.btnEnvoyer.Location = new System.Drawing.Point(650, 85);
            this.btnEnvoyer.Name = "btnEnvoyer";
            this.btnEnvoyer.Size = new System.Drawing.Size(75, 23);
            this.btnEnvoyer.TabIndex = 6;
            this.btnEnvoyer.Text = "Envoyer";
            this.btnEnvoyer.UseVisualStyleBackColor = true;
            // 
            // PanelImageBalise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEnvoyer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numRalentissement);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pictureBoxDefilement);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnParcourir);
            this.Name = "PanelImageBalise";
            this.Size = new System.Drawing.Size(947, 128);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDefilement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRalentissement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnParcourir;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureBoxDefilement;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.NumericUpDown numRalentissement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnvoyer;
    }
}
