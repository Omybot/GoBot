namespace GoBot.IHM
{
    partial class PanelTable
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
            this.pictureBoxTable = new System.Windows.Forms.PictureBox();
            this.btnAffichage = new System.Windows.Forms.Button();
            this.boxDroites = new System.Windows.Forms.CheckBox();
            this.boxTable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTable
            // 
            this.pictureBoxTable.Image = global::GoBot.Properties.Resources.table;
            this.pictureBoxTable.Location = new System.Drawing.Point(126, 3);
            this.pictureBoxTable.Name = "pictureBoxTable";
            this.pictureBoxTable.Size = new System.Drawing.Size(750, 500);
            this.pictureBoxTable.TabIndex = 0;
            this.pictureBoxTable.TabStop = false;
            // 
            // btnAffichage
            // 
            this.btnAffichage.Location = new System.Drawing.Point(9, 32);
            this.btnAffichage.Name = "btnAffichage";
            this.btnAffichage.Size = new System.Drawing.Size(111, 25);
            this.btnAffichage.TabIndex = 1;
            this.btnAffichage.Text = "Afficher la détection";
            this.btnAffichage.UseVisualStyleBackColor = true;
            this.btnAffichage.Click += new System.EventHandler(this.btnAffichage_Click);
            // 
            // boxDroites
            // 
            this.boxDroites.AutoSize = true;
            this.boxDroites.Location = new System.Drawing.Point(19, 118);
            this.boxDroites.Name = "boxDroites";
            this.boxDroites.Size = new System.Drawing.Size(83, 17);
            this.boxDroites.TabIndex = 2;
            this.boxDroites.Text = "Afficher tout";
            this.boxDroites.UseVisualStyleBackColor = true;
            // 
            // boxTable
            // 
            this.boxTable.AutoSize = true;
            this.boxTable.Checked = true;
            this.boxTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxTable.Location = new System.Drawing.Point(19, 141);
            this.boxTable.Name = "boxTable";
            this.boxTable.Size = new System.Drawing.Size(99, 17);
            this.boxTable.TabIndex = 3;
            this.boxTable.Text = "Afficher la table";
            this.boxTable.UseVisualStyleBackColor = true;
            // 
            // PanelTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.boxTable);
            this.Controls.Add(this.boxDroites);
            this.Controls.Add(this.btnAffichage);
            this.Controls.Add(this.pictureBoxTable);
            this.Name = "PanelTable";
            this.Size = new System.Drawing.Size(879, 526);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTable;
        private System.Windows.Forms.Button btnAffichage;
        private System.Windows.Forms.CheckBox boxDroites;
        private System.Windows.Forms.CheckBox boxTable;
    }
}
