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
            this.groupBoxSequences = new Composants.GroupBoxRetractable();
            this.btnRangeBras = new System.Windows.Forms.Button();
            this.btnBrasFeuRange = new System.Windows.Forms.Button();
            this.btnBrasFeuEtage1 = new System.Windows.Forms.Button();
            this.btnBrasFeuInterne1 = new System.Windows.Forms.Button();
            this.groupBoxSequences.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSequences
            // 
            this.groupBoxSequences.Controls.Add(this.btnBrasFeuInterne1);
            this.groupBoxSequences.Controls.Add(this.btnBrasFeuEtage1);
            this.groupBoxSequences.Controls.Add(this.btnRangeBras);
            this.groupBoxSequences.Controls.Add(this.btnBrasFeuRange);
            this.groupBoxSequences.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSequences.Name = "groupBoxSequences";
            this.groupBoxSequences.Size = new System.Drawing.Size(332, 362);
            this.groupBoxSequences.TabIndex = 1;
            this.groupBoxSequences.TabStop = false;
            this.groupBoxSequences.Text = "Séquences";
            // 
            // btnRangeBras
            // 
            this.btnRangeBras.Location = new System.Drawing.Point(32, 44);
            this.btnRangeBras.Name = "btnRangeBras";
            this.btnRangeBras.Size = new System.Drawing.Size(109, 23);
            this.btnRangeBras.TabIndex = 1;
            this.btnRangeBras.Text = "Ranger le bras";
            this.btnRangeBras.UseVisualStyleBackColor = true;
            this.btnRangeBras.Click += new System.EventHandler(this.btnRangeBras_Click);
            // 
            // btnBrasFeuRange
            // 
            this.btnBrasFeuRange.Location = new System.Drawing.Point(32, 112);
            this.btnBrasFeuRange.Name = "btnBrasFeuRange";
            this.btnBrasFeuRange.Size = new System.Drawing.Size(109, 23);
            this.btnBrasFeuRange.TabIndex = 2;
            this.btnBrasFeuRange.Text = "Bras feux rangé";
            this.btnBrasFeuRange.UseVisualStyleBackColor = true;
            this.btnBrasFeuRange.Click += new System.EventHandler(this.btnBrasFeuRange_Click);
            // 
            // btnBrasFeuEtage1
            // 
            this.btnBrasFeuEtage1.Location = new System.Drawing.Point(32, 141);
            this.btnBrasFeuEtage1.Name = "btnBrasFeuEtage1";
            this.btnBrasFeuEtage1.Size = new System.Drawing.Size(109, 23);
            this.btnBrasFeuEtage1.TabIndex = 3;
            this.btnBrasFeuEtage1.Text = "Bras feux 1er étage";
            this.btnBrasFeuEtage1.UseVisualStyleBackColor = true;
            this.btnBrasFeuEtage1.Click += new System.EventHandler(this.btnBrasFeuEtage1_Click);
            // 
            // btnBrasFeuInterne1
            // 
            this.btnBrasFeuInterne1.Location = new System.Drawing.Point(147, 141);
            this.btnBrasFeuInterne1.Name = "btnBrasFeuInterne1";
            this.btnBrasFeuInterne1.Size = new System.Drawing.Size(123, 23);
            this.btnBrasFeuInterne1.TabIndex = 4;
            this.btnBrasFeuInterne1.Text = "Bras feux 1er interne";
            this.btnBrasFeuInterne1.UseVisualStyleBackColor = true;
            this.btnBrasFeuInterne1.Click += new System.EventHandler(this.btnBrasFeuInterne1_Click);
            // 
            // PanelGrosRobotSequences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxSequences);
            this.Name = "PanelGrosRobotSequences";
            this.Size = new System.Drawing.Size(341, 413);
            this.Load += new System.EventHandler(this.PanelSequencesGros_Load);
            this.groupBoxSequences.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.GroupBoxRetractable groupBoxSequences;
        private System.Windows.Forms.Button btnRangeBras;
        private System.Windows.Forms.Button btnBrasFeuEtage1;
        private System.Windows.Forms.Button btnBrasFeuRange;
        private System.Windows.Forms.Button btnBrasFeuInterne1;
    }
}
