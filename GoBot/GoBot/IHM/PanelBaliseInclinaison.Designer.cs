namespace GoBot.IHM
{
    partial class PanelBaliseInclinaison
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
            this.groupBalise = new System.Windows.Forms.GroupBox();
            this.lblTxtInclinaisonProfil = new System.Windows.Forms.Label();
            this.lblInclinaisonProfil = new System.Windows.Forms.Label();
            this.trackBarInclinaisonProfil = new Composants.TrackBarPlus();
            this.lblTxtInclinaisonFace = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblInclinaisonFace = new System.Windows.Forms.Label();
            this.trackBarInclinaisonFace = new Composants.TrackBarPlus();
            this.groupBalise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBalise
            // 
            this.groupBalise.Controls.Add(this.lblTxtInclinaisonProfil);
            this.groupBalise.Controls.Add(this.lblInclinaisonProfil);
            this.groupBalise.Controls.Add(this.trackBarInclinaisonProfil);
            this.groupBalise.Controls.Add(this.lblTxtInclinaisonFace);
            this.groupBalise.Controls.Add(this.pictureBox);
            this.groupBalise.Controls.Add(this.lblInclinaisonFace);
            this.groupBalise.Controls.Add(this.trackBarInclinaisonFace);
            this.groupBalise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBalise.Location = new System.Drawing.Point(0, 0);
            this.groupBalise.Name = "groupBalise";
            this.groupBalise.Size = new System.Drawing.Size(333, 604);
            this.groupBalise.TabIndex = 0;
            this.groupBalise.TabStop = false;
            this.groupBalise.Text = "Balise";
            // 
            // lblTxtInclinaisonProfil
            // 
            this.lblTxtInclinaisonProfil.AutoSize = true;
            this.lblTxtInclinaisonProfil.Location = new System.Drawing.Point(62, 63);
            this.lblTxtInclinaisonProfil.Name = "lblTxtInclinaisonProfil";
            this.lblTxtInclinaisonProfil.Size = new System.Drawing.Size(82, 13);
            this.lblTxtInclinaisonProfil.TabIndex = 10;
            this.lblTxtInclinaisonProfil.Text = "Inclinaison profil";
            // 
            // lblInclinaisonProfil
            // 
            this.lblInclinaisonProfil.AutoSize = true;
            this.lblInclinaisonProfil.Location = new System.Drawing.Point(20, 81);
            this.lblInclinaisonProfil.Name = "lblInclinaisonProfil";
            this.lblInclinaisonProfil.Size = new System.Drawing.Size(13, 13);
            this.lblInclinaisonProfil.TabIndex = 9;
            this.lblInclinaisonProfil.Text = "0";
            // 
            // trackBarInclinaisonProfil
            // 
            this.trackBarInclinaisonProfil.BackColor = System.Drawing.Color.Transparent;
            this.trackBarInclinaisonProfil.IntervalTimer = 500;
            this.trackBarInclinaisonProfil.Location = new System.Drawing.Point(65, 79);
            this.trackBarInclinaisonProfil.Max = 100D;
            this.trackBarInclinaisonProfil.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarInclinaisonProfil.Min = 0D;
            this.trackBarInclinaisonProfil.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarInclinaisonProfil.Name = "trackBarInclinaisonProfil";
            this.trackBarInclinaisonProfil.NombreDecimales = 0;
            this.trackBarInclinaisonProfil.Reverse = false;
            this.trackBarInclinaisonProfil.Size = new System.Drawing.Size(246, 15);
            this.trackBarInclinaisonProfil.TabIndex = 8;
            this.trackBarInclinaisonProfil.Vertical = false;
            this.trackBarInclinaisonProfil.ValueChanged += new System.EventHandler(this.trackBarInclinaisonProfil_ValueChanged);
            // 
            // lblTxtInclinaisonFace
            // 
            this.lblTxtInclinaisonFace.AutoSize = true;
            this.lblTxtInclinaisonFace.Location = new System.Drawing.Point(62, 21);
            this.lblTxtInclinaisonFace.Name = "lblTxtInclinaisonFace";
            this.lblTxtInclinaisonFace.Size = new System.Drawing.Size(81, 13);
            this.lblTxtInclinaisonFace.TabIndex = 7;
            this.lblTxtInclinaisonFace.Text = "Inclinaison face";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(106, 100);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(205, 379);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // lblInclinaisonFace
            // 
            this.lblInclinaisonFace.AutoSize = true;
            this.lblInclinaisonFace.Location = new System.Drawing.Point(20, 39);
            this.lblInclinaisonFace.Name = "lblInclinaisonFace";
            this.lblInclinaisonFace.Size = new System.Drawing.Size(13, 13);
            this.lblInclinaisonFace.TabIndex = 3;
            this.lblInclinaisonFace.Text = "0";
            // 
            // trackBarInclinaisonFace
            // 
            this.trackBarInclinaisonFace.BackColor = System.Drawing.Color.Transparent;
            this.trackBarInclinaisonFace.IntervalTimer = 500;
            this.trackBarInclinaisonFace.Location = new System.Drawing.Point(65, 37);
            this.trackBarInclinaisonFace.Max = 4000D;
            this.trackBarInclinaisonFace.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarInclinaisonFace.Min = 0D;
            this.trackBarInclinaisonFace.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarInclinaisonFace.Name = "trackBarInclinaisonFace";
            this.trackBarInclinaisonFace.NombreDecimales = 0;
            this.trackBarInclinaisonFace.Reverse = false;
            this.trackBarInclinaisonFace.Size = new System.Drawing.Size(246, 15);
            this.trackBarInclinaisonFace.TabIndex = 2;
            this.trackBarInclinaisonFace.Vertical = false;
            this.trackBarInclinaisonFace.TickValueChanged += new System.EventHandler(this.trackBarInclinaisonFace_TickValueChanged);
            this.trackBarInclinaisonFace.ValueChanged += new System.EventHandler(this.trackBarInclinaisonFace_ValueChanged);
            // 
            // PanelBaliseInclinaison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBalise);
            this.Name = "PanelBaliseInclinaison";
            this.Size = new System.Drawing.Size(333, 604);
            this.groupBalise.ResumeLayout(false);
            this.groupBalise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBalise;
        private Composants.TrackBarPlus trackBarInclinaisonFace;
        private System.Windows.Forms.Label lblInclinaisonFace;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblTxtInclinaisonProfil;
        private System.Windows.Forms.Label lblInclinaisonProfil;
        private Composants.TrackBarPlus trackBarInclinaisonProfil;
        private System.Windows.Forms.Label lblTxtInclinaisonFace;
    }
}
