﻿namespace GoBot.IHM
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
            this.btnEmpilerDroite = new System.Windows.Forms.Button();
            this.groupBoxSequences.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSequences
            // 
            this.groupBoxSequences.Controls.Add(this.btnEmpilerDroite);
            this.groupBoxSequences.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSequences.Name = "groupBoxSequences";
            this.groupBoxSequences.Size = new System.Drawing.Size(332, 376);
            this.groupBoxSequences.TabIndex = 1;
            this.groupBoxSequences.TabStop = false;
            this.groupBoxSequences.Text = "Séquences";
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
    }
}
