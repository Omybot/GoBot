namespace GoBot.IHM
{
    partial class PanelGrosRobotUtilisation
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
            this.groupBoxUtilisation = new Composants.GroupBoxRetractable();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDiagnostic = new System.Windows.Forms.Button();
            this.switchBoutonPuissance = new Composants.SwitchBouton();
            this.label1 = new System.Windows.Forms.Label();
            this.switchBoutonPinceDroite = new Composants.SwitchBouton();
            this.switchBoutonAscenseurDroite = new Composants.SwitchBouton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxUtilisation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUtilisation
            // 
            this.groupBoxUtilisation.Controls.Add(this.label4);
            this.groupBoxUtilisation.Controls.Add(this.label3);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonAscenseurDroite);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonPinceDroite);
            this.groupBoxUtilisation.Controls.Add(this.label1);
            this.groupBoxUtilisation.Controls.Add(this.label12);
            this.groupBoxUtilisation.Controls.Add(this.btnDiagnostic);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonPuissance);
            this.groupBoxUtilisation.Location = new System.Drawing.Point(3, 3);
            this.groupBoxUtilisation.Name = "groupBoxUtilisation";
            this.groupBoxUtilisation.Size = new System.Drawing.Size(332, 325);
            this.groupBoxUtilisation.TabIndex = 1;
            this.groupBoxUtilisation.TabStop = false;
            this.groupBoxUtilisation.Text = "Utilisation";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 13);
            this.label12.TabIndex = 199;
            this.label12.Text = "Alimentation puissance";
            // 
            // btnDiagnostic
            // 
            this.btnDiagnostic.Location = new System.Drawing.Point(211, 30);
            this.btnDiagnostic.Name = "btnDiagnostic";
            this.btnDiagnostic.Size = new System.Drawing.Size(75, 23);
            this.btnDiagnostic.TabIndex = 201;
            this.btnDiagnostic.Text = "Diagnostic";
            this.btnDiagnostic.UseVisualStyleBackColor = true;
            this.btnDiagnostic.Click += new System.EventHandler(this.btnDiagnostic_Click);
            // 
            // switchBoutonPuissance
            // 
            this.switchBoutonPuissance.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonPuissance.Location = new System.Drawing.Point(145, 36);
            this.switchBoutonPuissance.Name = "switchBoutonPuissance";
            this.switchBoutonPuissance.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonPuissance.Symetrique = false;
            this.switchBoutonPuissance.TabIndex = 200;
            this.switchBoutonPuissance.ChangementEtat += new System.EventHandler(this.switchBoutonPuissance_ChangementEtat);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 202;
            this.label1.Text = "Pince";
            // 
            // switchBoutonPinceDroite
            // 
            this.switchBoutonPinceDroite.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonPinceDroite.Location = new System.Drawing.Point(154, 81);
            this.switchBoutonPinceDroite.Name = "switchBoutonPinceDroite";
            this.switchBoutonPinceDroite.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.switchBoutonPinceDroite.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonPinceDroite.Symetrique = false;
            this.switchBoutonPinceDroite.TabIndex = 204;
            this.switchBoutonPinceDroite.ChangementEtat += new System.EventHandler(this.switchBoutonPinceDroite_ChangementEtat);
            // 
            // switchBoutonAscenseurDroite
            // 
            this.switchBoutonAscenseurDroite.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonAscenseurDroite.Location = new System.Drawing.Point(282, 81);
            this.switchBoutonAscenseurDroite.Name = "switchBoutonAscenseurDroite";
            this.switchBoutonAscenseurDroite.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonAscenseurDroite.Symetrique = false;
            this.switchBoutonAscenseurDroite.TabIndex = 206;
            this.switchBoutonAscenseurDroite.ChangementEtat += new System.EventHandler(this.switchBoutonAscenseurDroite_ChangementEtat);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 207;
            this.label3.Text = "Ascensceur";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 208;
            this.label4.Text = "Droite";
            // 
            // PanelGrosRobotUtilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxUtilisation);
            this.Name = "PanelGrosRobotUtilisation";
            this.Size = new System.Drawing.Size(341, 334);
            this.Load += new System.EventHandler(this.PanelUtilGros_Load);
            this.groupBoxUtilisation.ResumeLayout(false);
            this.groupBoxUtilisation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.SwitchBouton switchBoutonPuissance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnDiagnostic;
        private Composants.GroupBoxRetractable groupBoxUtilisation;
        private Composants.SwitchBouton switchBoutonPinceDroite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Composants.SwitchBouton switchBoutonAscenseurDroite;
    }
}
