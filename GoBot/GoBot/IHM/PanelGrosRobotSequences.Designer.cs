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
            this.btnDebutMatchGauche = new System.Windows.Forms.Button();
            this.btnBasTableGauche = new System.Windows.Forms.Button();
            this.btnEmpilerGauche = new System.Windows.Forms.Button();
            this.btnDebutMatch = new System.Windows.Forms.Button();
            this.btnCleanBasGauche = new System.Windows.Forms.Button();
            this.btnEmpilerDroite = new System.Windows.Forms.Button();
            this.groupBoxSequences.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSequences
            // 
            this.groupBoxSequences.Controls.Add(this.btnDebutMatchGauche);
            this.groupBoxSequences.Controls.Add(this.btnBasTableGauche);
            this.groupBoxSequences.Controls.Add(this.btnEmpilerGauche);
            this.groupBoxSequences.Controls.Add(this.btnDebutMatch);
            this.groupBoxSequences.Controls.Add(this.btnCleanBasGauche);
            this.groupBoxSequences.Controls.Add(this.btnEmpilerDroite);
            this.groupBoxSequences.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSequences.Name = "groupBoxSequences";
            this.groupBoxSequences.Size = new System.Drawing.Size(332, 376);
            this.groupBoxSequences.TabIndex = 1;
            this.groupBoxSequences.TabStop = false;
            this.groupBoxSequences.Text = "Séquences";
            // 
            // btnDebutMatchGauche
            // 
            this.btnDebutMatchGauche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnDebutMatchGauche.Location = new System.Drawing.Point(184, 111);
            this.btnDebutMatchGauche.Name = "btnDebutMatchGauche";
            this.btnDebutMatchGauche.Size = new System.Drawing.Size(121, 23);
            this.btnDebutMatchGauche.TabIndex = 6;
            this.btnDebutMatchGauche.Text = "Debut match";
            this.btnDebutMatchGauche.UseVisualStyleBackColor = false;
            this.btnDebutMatchGauche.Click += new System.EventHandler(this.btnDebutMatchGauche_Click);
            // 
            // btnBasTableGauche
            // 
            this.btnBasTableGauche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBasTableGauche.Location = new System.Drawing.Point(184, 140);
            this.btnBasTableGauche.Name = "btnBasTableGauche";
            this.btnBasTableGauche.Size = new System.Drawing.Size(121, 23);
            this.btnBasTableGauche.TabIndex = 5;
            this.btnBasTableGauche.Text = "Ramasser bas gauche";
            this.btnBasTableGauche.UseVisualStyleBackColor = false;
            this.btnBasTableGauche.Click += new System.EventHandler(this.btnBasTableGauche_Click);
            // 
            // btnEmpilerGauche
            // 
            this.btnEmpilerGauche.Location = new System.Drawing.Point(184, 58);
            this.btnEmpilerGauche.Name = "btnEmpilerGauche";
            this.btnEmpilerGauche.Size = new System.Drawing.Size(113, 23);
            this.btnEmpilerGauche.TabIndex = 4;
            this.btnEmpilerGauche.Text = "Empiler pince gauche";
            this.btnEmpilerGauche.UseVisualStyleBackColor = true;
            this.btnEmpilerGauche.Click += new System.EventHandler(this.btnEmpilerGauche_Click);
            // 
            // btnDebutMatch
            // 
            this.btnDebutMatch.BackColor = System.Drawing.Color.Yellow;
            this.btnDebutMatch.Location = new System.Drawing.Point(23, 111);
            this.btnDebutMatch.Name = "btnDebutMatch";
            this.btnDebutMatch.Size = new System.Drawing.Size(121, 23);
            this.btnDebutMatch.TabIndex = 3;
            this.btnDebutMatch.Text = "Debut match";
            this.btnDebutMatch.UseVisualStyleBackColor = false;
            this.btnDebutMatch.Click += new System.EventHandler(this.btnDebutMatch_Click);
            // 
            // btnCleanBasGauche
            // 
            this.btnCleanBasGauche.BackColor = System.Drawing.Color.Yellow;
            this.btnCleanBasGauche.Location = new System.Drawing.Point(23, 140);
            this.btnCleanBasGauche.Name = "btnCleanBasGauche";
            this.btnCleanBasGauche.Size = new System.Drawing.Size(121, 23);
            this.btnCleanBasGauche.TabIndex = 2;
            this.btnCleanBasGauche.Text = "Ramasser bas gauche";
            this.btnCleanBasGauche.UseVisualStyleBackColor = false;
            this.btnCleanBasGauche.Click += new System.EventHandler(this.btnCleanBasGauche_Click);
            // 
            // btnEmpilerDroite
            // 
            this.btnEmpilerDroite.Location = new System.Drawing.Point(23, 58);
            this.btnEmpilerDroite.Name = "btnEmpilerDroite";
            this.btnEmpilerDroite.Size = new System.Drawing.Size(113, 23);
            this.btnEmpilerDroite.TabIndex = 1;
            this.btnEmpilerDroite.Text = "Empiler pince droite";
            this.btnEmpilerDroite.UseVisualStyleBackColor = true;
            this.btnEmpilerDroite.Click += new System.EventHandler(this.btnEmpilerDroite_Click);
            // 
            // PanelGrosRobotSequences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxSequences);
            this.Name = "PanelGrosRobotSequences";
            this.Size = new System.Drawing.Size(341, 382);
            this.Load += new System.EventHandler(this.PanelSequencesGros_Load);
            this.groupBoxSequences.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.GroupBoxRetractable groupBoxSequences;
        private System.Windows.Forms.Button btnEmpilerDroite;
        private System.Windows.Forms.Button btnCleanBasGauche;
        private System.Windows.Forms.Button btnDebutMatch;
        private System.Windows.Forms.Button btnDebutMatchGauche;
        private System.Windows.Forms.Button btnBasTableGauche;
        private System.Windows.Forms.Button btnEmpilerGauche;
    }
}
