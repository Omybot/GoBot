namespace GoBot.IHM
{
    partial class PanelGrosRobotSequences
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
            this.btnVerres = new System.Windows.Forms.Button();
            this.btnAssiette = new System.Windows.Forms.Button();
            this.btnCerise1 = new System.Windows.Forms.Button();
            this.btnCerises = new System.Windows.Forms.Button();
            this.groupBoxSequences = new Composants.GroupBoxRetractable();
            this.groupBoxSequences.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVerres
            // 
            this.btnVerres.Location = new System.Drawing.Point(154, 69);
            this.btnVerres.Name = "btnVerres";
            this.btnVerres.Size = new System.Drawing.Size(130, 23);
            this.btnVerres.TabIndex = 93;
            this.btnVerres.Text = "Verres départ";
            this.btnVerres.UseVisualStyleBackColor = true;
            this.btnVerres.Click += new System.EventHandler(this.btnVerres_Click);
            // 
            // btnAssiette
            // 
            this.btnAssiette.Location = new System.Drawing.Point(18, 69);
            this.btnAssiette.Name = "btnAssiette";
            this.btnAssiette.Size = new System.Drawing.Size(130, 23);
            this.btnAssiette.TabIndex = 92;
            this.btnAssiette.Text = "Assiette";
            this.btnAssiette.UseVisualStyleBackColor = true;
            this.btnAssiette.Click += new System.EventHandler(this.btnAssiette_Click);
            // 
            // btnCerise1
            // 
            this.btnCerise1.Location = new System.Drawing.Point(18, 40);
            this.btnCerise1.Name = "btnCerise1";
            this.btnCerise1.Size = new System.Drawing.Size(130, 23);
            this.btnCerise1.TabIndex = 91;
            this.btnCerise1.Text = "Une cerise";
            this.btnCerise1.UseVisualStyleBackColor = true;
            this.btnCerise1.Click += new System.EventHandler(this.btnCerise1_Click);
            // 
            // btnCerises
            // 
            this.btnCerises.Location = new System.Drawing.Point(154, 40);
            this.btnCerises.Name = "btnCerises";
            this.btnCerises.Size = new System.Drawing.Size(130, 23);
            this.btnCerises.TabIndex = 90;
            this.btnCerises.Text = "Cerises";
            this.btnCerises.UseVisualStyleBackColor = true;
            this.btnCerises.Click += new System.EventHandler(this.btnCerises_Click);
            // 
            // groupBoxSequences
            // 
            this.groupBoxSequences.Controls.Add(this.btnVerres);
            this.groupBoxSequences.Controls.Add(this.btnAssiette);
            this.groupBoxSequences.Controls.Add(this.btnCerises);
            this.groupBoxSequences.Controls.Add(this.btnCerise1);
            this.groupBoxSequences.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSequences.Name = "groupBoxSequences";
            this.groupBoxSequences.Size = new System.Drawing.Size(332, 104);
            this.groupBoxSequences.TabIndex = 1;
            this.groupBoxSequences.TabStop = false;
            this.groupBoxSequences.Text = "Séquences";
            // 
            // PanelGrosRobotSequences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxSequences);
            this.Name = "PanelGrosRobotSequences";
            this.Size = new System.Drawing.Size(341, 116);
            this.Load += new System.EventHandler(this.PanelSequencesGros_Load);
            this.groupBoxSequences.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerises;
        private System.Windows.Forms.Button btnCerise1;
        private System.Windows.Forms.Button btnAssiette;
        private System.Windows.Forms.Button btnVerres;
        private Composants.GroupBoxRetractable groupBoxSequences;
    }
}
