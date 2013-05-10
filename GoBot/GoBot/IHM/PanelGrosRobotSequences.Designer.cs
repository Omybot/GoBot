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
            this.groupBoxSeq = new System.Windows.Forms.GroupBox();
            this.btnAssiette = new System.Windows.Forms.Button();
            this.btnCerise1 = new System.Windows.Forms.Button();
            this.btnCerises = new System.Windows.Forms.Button();
            this.btnTaille = new System.Windows.Forms.Button();
            this.btnVerres = new System.Windows.Forms.Button();
            this.groupBoxSeq.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSeq
            // 
            this.groupBoxSeq.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxSeq.Controls.Add(this.btnVerres);
            this.groupBoxSeq.Controls.Add(this.btnAssiette);
            this.groupBoxSeq.Controls.Add(this.btnCerise1);
            this.groupBoxSeq.Controls.Add(this.btnCerises);
            this.groupBoxSeq.Controls.Add(this.btnTaille);
            this.groupBoxSeq.Location = new System.Drawing.Point(5, 3);
            this.groupBoxSeq.Name = "groupBoxSeq";
            this.groupBoxSeq.Size = new System.Drawing.Size(332, 144);
            this.groupBoxSeq.TabIndex = 0;
            this.groupBoxSeq.TabStop = false;
            this.groupBoxSeq.Text = "Sequences";
            // 
            // btnAssiette
            // 
            this.btnAssiette.Location = new System.Drawing.Point(30, 68);
            this.btnAssiette.Name = "btnAssiette";
            this.btnAssiette.Size = new System.Drawing.Size(130, 23);
            this.btnAssiette.TabIndex = 92;
            this.btnAssiette.Text = "Assiette";
            this.btnAssiette.UseVisualStyleBackColor = true;
            this.btnAssiette.Click += new System.EventHandler(this.btnAssiette_Click);
            // 
            // btnCerise1
            // 
            this.btnCerise1.Location = new System.Drawing.Point(30, 39);
            this.btnCerise1.Name = "btnCerise1";
            this.btnCerise1.Size = new System.Drawing.Size(130, 23);
            this.btnCerise1.TabIndex = 91;
            this.btnCerise1.Text = "Une cerise";
            this.btnCerise1.UseVisualStyleBackColor = true;
            this.btnCerise1.Click += new System.EventHandler(this.btnCerise1_Click);
            // 
            // btnCerises
            // 
            this.btnCerises.Location = new System.Drawing.Point(166, 39);
            this.btnCerises.Name = "btnCerises";
            this.btnCerises.Size = new System.Drawing.Size(130, 23);
            this.btnCerises.TabIndex = 90;
            this.btnCerises.Text = "Cerises";
            this.btnCerises.UseVisualStyleBackColor = true;
            this.btnCerises.Click += new System.EventHandler(this.btnCerises_Click);
            // 
            // btnTaille
            // 
            this.btnTaille.Image = global::GoBot.Properties.Resources.haut;
            this.btnTaille.Location = new System.Drawing.Point(304, 10);
            this.btnTaille.Name = "btnTaille";
            this.btnTaille.Size = new System.Drawing.Size(24, 23);
            this.btnTaille.TabIndex = 87;
            this.btnTaille.UseVisualStyleBackColor = true;
            this.btnTaille.Click += new System.EventHandler(this.btnTaille_Click);
            // 
            // btnVerres
            // 
            this.btnVerres.Location = new System.Drawing.Point(30, 115);
            this.btnVerres.Name = "btnVerres";
            this.btnVerres.Size = new System.Drawing.Size(130, 23);
            this.btnVerres.TabIndex = 93;
            this.btnVerres.Text = "Verres départ";
            this.btnVerres.UseVisualStyleBackColor = true;
            this.btnVerres.Click += new System.EventHandler(this.btnVerres_Click);
            // 
            // PanelGrosRobotSequences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxSeq);
            this.Name = "PanelGrosRobotSequences";
            this.Size = new System.Drawing.Size(341, 167);
            this.Load += new System.EventHandler(this.PanelSequencesGros_Load);
            this.groupBoxSeq.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSeq;
        protected System.Windows.Forms.Button btnTaille;
        private System.Windows.Forms.Button btnCerises;
        private System.Windows.Forms.Button btnCerise1;
        private System.Windows.Forms.Button btnAssiette;
        private System.Windows.Forms.Button btnVerres;
    }
}
