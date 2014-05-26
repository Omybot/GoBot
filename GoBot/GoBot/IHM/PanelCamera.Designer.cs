namespace GoBot.IHM
{
    partial class PanelCamera
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
            this.btnCapture = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelCouleurFruit = new System.Windows.Forms.Panel();
            this.panelCouleurFeu = new System.Windows.Forms.Panel();
            this.btnDefinitionZone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCouleur = new System.Windows.Forms.Label();
            this.panelCouleurMoyenne = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(778, 88);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxImage.Image = global::GoBot.Properties.Resources.Webcam;
            this.pictureBoxImage.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImage_MouseDown);
            this.pictureBoxImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImage_MouseMove);
            this.pictureBoxImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImage_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(675, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 46);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // panelCouleurFruit
            // 
            this.panelCouleurFruit.Location = new System.Drawing.Point(737, 166);
            this.panelCouleurFruit.Name = "panelCouleurFruit";
            this.panelCouleurFruit.Size = new System.Drawing.Size(115, 45);
            this.panelCouleurFruit.TabIndex = 3;
            // 
            // panelCouleurFeu
            // 
            this.panelCouleurFeu.Location = new System.Drawing.Point(737, 217);
            this.panelCouleurFeu.Name = "panelCouleurFeu";
            this.panelCouleurFeu.Size = new System.Drawing.Size(115, 45);
            this.panelCouleurFeu.TabIndex = 4;
            // 
            // btnDefinitionZone
            // 
            this.btnDefinitionZone.Location = new System.Drawing.Point(665, 117);
            this.btnDefinitionZone.Name = "btnDefinitionZone";
            this.btnDefinitionZone.Size = new System.Drawing.Size(96, 23);
            this.btnDefinitionZone.TabIndex = 5;
            this.btnDefinitionZone.Text = "Définition zone";
            this.btnDefinitionZone.UseVisualStyleBackColor = true;
            this.btnDefinitionZone.Click += new System.EventHandler(this.btnDefinitionZone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(696, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Couleur";
            // 
            // lblCouleur
            // 
            this.lblCouleur.AutoSize = true;
            this.lblCouleur.Location = new System.Drawing.Point(745, 285);
            this.lblCouleur.Name = "lblCouleur";
            this.lblCouleur.Size = new System.Drawing.Size(10, 13);
            this.lblCouleur.TabIndex = 7;
            this.lblCouleur.Text = "-";
            // 
            // panelCouleurMoyenne
            // 
            this.panelCouleurMoyenne.Location = new System.Drawing.Point(737, 315);
            this.panelCouleurMoyenne.Name = "panelCouleurMoyenne";
            this.panelCouleurMoyenne.Size = new System.Drawing.Size(115, 45);
            this.panelCouleurMoyenne.TabIndex = 5;
            // 
            // PanelCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCouleurMoyenne);
            this.Controls.Add(this.lblCouleur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDefinitionZone);
            this.Controls.Add(this.panelCouleurFeu);
            this.Controls.Add(this.panelCouleurFruit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.pictureBoxImage);
            this.Name = "PanelCamera";
            this.Size = new System.Drawing.Size(1025, 501);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelCouleurFruit;
        private System.Windows.Forms.Panel panelCouleurFeu;
        private System.Windows.Forms.Button btnDefinitionZone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCouleur;
        private System.Windows.Forms.Panel panelCouleurMoyenne;
    }
}
