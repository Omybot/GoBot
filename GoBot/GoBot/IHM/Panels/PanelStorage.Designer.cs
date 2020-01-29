namespace GoBot.IHM.Panels
{
    partial class PanelStorage
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
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLateral = new System.Windows.Forms.Button();
            this.picStorage = new System.Windows.Forms.PictureBox();
            this.btnSpawnGreen = new System.Windows.Forms.Button();
            this.btnSpawnRed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picStorage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDown
            // 
            this.btnDown.Image = global::GoBot.Properties.Resources.BigArrowDown;
            this.btnDown.Location = new System.Drawing.Point(322, 455);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(175, 134);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::GoBot.Properties.Resources.BigArrowUp;
            this.btnUp.Location = new System.Drawing.Point(3, 455);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(175, 134);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLateral
            // 
            this.btnLateral.Image = global::GoBot.Properties.Resources.BigArrow;
            this.btnLateral.Location = new System.Drawing.Point(3, 3);
            this.btnLateral.Name = "btnLateral";
            this.btnLateral.Size = new System.Drawing.Size(494, 134);
            this.btnLateral.TabIndex = 1;
            this.btnLateral.UseVisualStyleBackColor = true;
            this.btnLateral.Click += new System.EventHandler(this.btnLateral_Click);
            // 
            // picStorage
            // 
            this.picStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picStorage.Location = new System.Drawing.Point(0, 0);
            this.picStorage.Name = "picStorage";
            this.picStorage.Size = new System.Drawing.Size(500, 592);
            this.picStorage.TabIndex = 0;
            this.picStorage.TabStop = false;
            this.picStorage.Paint += new System.Windows.Forms.PaintEventHandler(this.picStorage_Paint);
            // 
            // btnSpawnGreen
            // 
            this.btnSpawnGreen.Location = new System.Drawing.Point(183, 524);
            this.btnSpawnGreen.Name = "btnSpawnGreen";
            this.btnSpawnGreen.Size = new System.Drawing.Size(65, 65);
            this.btnSpawnGreen.TabIndex = 4;
            this.btnSpawnGreen.UseVisualStyleBackColor = true;
            this.btnSpawnGreen.Click += new System.EventHandler(this.btnSpawnGreen_Click);
            // 
            // btnSpawnRed
            // 
            this.btnSpawnRed.Location = new System.Drawing.Point(252, 524);
            this.btnSpawnRed.Name = "btnSpawnRed";
            this.btnSpawnRed.Size = new System.Drawing.Size(65, 65);
            this.btnSpawnRed.TabIndex = 5;
            this.btnSpawnRed.UseVisualStyleBackColor = true;
            this.btnSpawnRed.Click += new System.EventHandler(this.btnSpawnRed_Click);
            // 
            // PanelStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnSpawnRed);
            this.Controls.Add(this.btnSpawnGreen);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnLateral);
            this.Controls.Add(this.picStorage);
            this.Name = "PanelStorage";
            this.Size = new System.Drawing.Size(500, 592);
            ((System.ComponentModel.ISupportInitialize)(this.picStorage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picStorage;
        private System.Windows.Forms.Button btnLateral;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSpawnGreen;
        private System.Windows.Forms.Button btnSpawnRed;
    }
}
