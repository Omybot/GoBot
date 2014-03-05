namespace GoBot.IHM
{
    partial class PanelPetitRobotReglage
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
            this.groupBoxReglage = new System.Windows.Forms.GroupBox();
            this.btnTaille = new System.Windows.Forms.Button();
            this.groupBoxReglage.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxReglage
            // 
            this.groupBoxReglage.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxReglage.Controls.Add(this.btnTaille);
            this.groupBoxReglage.Location = new System.Drawing.Point(5, 3);
            this.groupBoxReglage.Name = "groupBoxReglage";
            this.groupBoxReglage.Size = new System.Drawing.Size(332, 256);
            this.groupBoxReglage.TabIndex = 0;
            this.groupBoxReglage.TabStop = false;
            this.groupBoxReglage.Text = "Réglage";
            // 
            // btnTaille
            // 
            this.btnTaille.Image = global::GoBot.Properties.Resources.Haut;
            this.btnTaille.Location = new System.Drawing.Point(304, 10);
            this.btnTaille.Name = "btnTaille";
            this.btnTaille.Size = new System.Drawing.Size(24, 23);
            this.btnTaille.TabIndex = 87;
            this.btnTaille.UseVisualStyleBackColor = true;
            this.btnTaille.Click += new System.EventHandler(this.btnTaille_Click);
            // 
            // PanelPetitRobotReglage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxReglage);
            this.Name = "PanelPetitRobotReglage";
            this.Size = new System.Drawing.Size(341, 262);
            this.Load += new System.EventHandler(this.PanelPetitRobotReglage_Load);
            this.groupBoxReglage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxReglage;
        protected System.Windows.Forms.Button btnTaille;
    }
}
