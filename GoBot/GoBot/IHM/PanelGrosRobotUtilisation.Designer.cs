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
            this.btnDiagnostic = new System.Windows.Forms.Button();
            this.switchBoutonPuissance = new Composants.SwitchBouton();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBoxUtilisation = new Composants.GroupBoxRetractable();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.switchBoutonPompeFeu = new Composants.SwitchBouton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEpauleRange = new System.Windows.Forms.Button();
            this.btnCoudeRange = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPinceGaucheOuverte = new System.Windows.Forms.Button();
            this.btnPinceGaucheFermee = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPinceDroiteFermee = new System.Windows.Forms.Button();
            this.btnPinceDroiteOuverte = new System.Windows.Forms.Button();
            this.groupBoxUtilisation.SuspendLayout();
            this.SuspendLayout();
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 13);
            this.label12.TabIndex = 199;
            this.label12.Text = "Alimentation puissance";
            // 
            // groupBoxUtilisation
            // 
            this.groupBoxUtilisation.Controls.Add(this.label2);
            this.groupBoxUtilisation.Controls.Add(this.label3);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonPompeFeu);
            this.groupBoxUtilisation.Controls.Add(this.label1);
            this.groupBoxUtilisation.Controls.Add(this.btnEpauleRange);
            this.groupBoxUtilisation.Controls.Add(this.btnCoudeRange);
            this.groupBoxUtilisation.Controls.Add(this.label4);
            this.groupBoxUtilisation.Controls.Add(this.btnPinceGaucheOuverte);
            this.groupBoxUtilisation.Controls.Add(this.btnPinceGaucheFermee);
            this.groupBoxUtilisation.Controls.Add(this.label5);
            this.groupBoxUtilisation.Controls.Add(this.btnPinceDroiteFermee);
            this.groupBoxUtilisation.Controls.Add(this.btnPinceDroiteOuverte);
            this.groupBoxUtilisation.Controls.Add(this.label12);
            this.groupBoxUtilisation.Controls.Add(this.btnDiagnostic);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonPuissance);
            this.groupBoxUtilisation.Location = new System.Drawing.Point(3, 3);
            this.groupBoxUtilisation.Name = "groupBoxUtilisation";
            this.groupBoxUtilisation.Size = new System.Drawing.Size(332, 211);
            this.groupBoxUtilisation.TabIndex = 1;
            this.groupBoxUtilisation.TabStop = false;
            this.groupBoxUtilisation.Text = "Utilisation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 217;
            this.label2.Text = "Pompe feu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 214;
            this.label3.Text = "Coude";
            // 
            // switchBoutonPompeFeu
            // 
            this.switchBoutonPompeFeu.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonPompeFeu.Location = new System.Drawing.Point(117, 184);
            this.switchBoutonPompeFeu.Name = "switchBoutonPompeFeu";
            this.switchBoutonPompeFeu.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonPompeFeu.Symetrique = true;
            this.switchBoutonPompeFeu.TabIndex = 216;
            this.switchBoutonPompeFeu.ChangementEtat += new System.EventHandler(this.switchBoutonPompeFeu_ChangementEtat);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 215;
            this.label1.Text = "Epaule";
            // 
            // btnEpauleRange
            // 
            this.btnEpauleRange.Location = new System.Drawing.Point(117, 103);
            this.btnEpauleRange.Name = "btnEpauleRange";
            this.btnEpauleRange.Size = new System.Drawing.Size(53, 23);
            this.btnEpauleRange.TabIndex = 213;
            this.btnEpauleRange.Text = "Rangé";
            this.btnEpauleRange.UseVisualStyleBackColor = true;
            this.btnEpauleRange.Click += new System.EventHandler(this.btnEpauleRange_Click);
            // 
            // btnCoudeRange
            // 
            this.btnCoudeRange.Location = new System.Drawing.Point(117, 77);
            this.btnCoudeRange.Name = "btnCoudeRange";
            this.btnCoudeRange.Size = new System.Drawing.Size(53, 23);
            this.btnCoudeRange.TabIndex = 212;
            this.btnCoudeRange.Text = "Rangé";
            this.btnCoudeRange.UseVisualStyleBackColor = true;
            this.btnCoudeRange.Click += new System.EventHandler(this.btnCoudeRange_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 202;
            this.label4.Text = "Pince droite";
            // 
            // btnPinceGaucheOuverte
            // 
            this.btnPinceGaucheOuverte.Location = new System.Drawing.Point(176, 155);
            this.btnPinceGaucheOuverte.Name = "btnPinceGaucheOuverte";
            this.btnPinceGaucheOuverte.Size = new System.Drawing.Size(53, 23);
            this.btnPinceGaucheOuverte.TabIndex = 211;
            this.btnPinceGaucheOuverte.Text = "Ouverte";
            this.btnPinceGaucheOuverte.UseVisualStyleBackColor = true;
            this.btnPinceGaucheOuverte.Click += new System.EventHandler(this.btnPinceGaucheOuverte_Click);
            // 
            // btnPinceGaucheFermee
            // 
            this.btnPinceGaucheFermee.Location = new System.Drawing.Point(117, 155);
            this.btnPinceGaucheFermee.Name = "btnPinceGaucheFermee";
            this.btnPinceGaucheFermee.Size = new System.Drawing.Size(53, 23);
            this.btnPinceGaucheFermee.TabIndex = 210;
            this.btnPinceGaucheFermee.Text = "Fermée";
            this.btnPinceGaucheFermee.UseVisualStyleBackColor = true;
            this.btnPinceGaucheFermee.Click += new System.EventHandler(this.btnPinceGaucheFermee_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Pince gauche";
            // 
            // btnPinceDroiteFermee
            // 
            this.btnPinceDroiteFermee.Location = new System.Drawing.Point(117, 129);
            this.btnPinceDroiteFermee.Name = "btnPinceDroiteFermee";
            this.btnPinceDroiteFermee.Size = new System.Drawing.Size(53, 23);
            this.btnPinceDroiteFermee.TabIndex = 205;
            this.btnPinceDroiteFermee.Text = "Fermée";
            this.btnPinceDroiteFermee.UseVisualStyleBackColor = true;
            this.btnPinceDroiteFermee.Click += new System.EventHandler(this.btnPinceDroiteFermee_Click);
            // 
            // btnPinceDroiteOuverte
            // 
            this.btnPinceDroiteOuverte.Location = new System.Drawing.Point(176, 129);
            this.btnPinceDroiteOuverte.Name = "btnPinceDroiteOuverte";
            this.btnPinceDroiteOuverte.Size = new System.Drawing.Size(53, 23);
            this.btnPinceDroiteOuverte.TabIndex = 206;
            this.btnPinceDroiteOuverte.Text = "Ouverte";
            this.btnPinceDroiteOuverte.UseVisualStyleBackColor = true;
            this.btnPinceDroiteOuverte.Click += new System.EventHandler(this.btnPinceDroiteOuverte_Click);
            // 
            // PanelGrosRobotUtilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxUtilisation);
            this.Name = "PanelGrosRobotUtilisation";
            this.Size = new System.Drawing.Size(341, 221);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPinceGaucheOuverte;
        private System.Windows.Forms.Button btnPinceGaucheFermee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPinceDroiteFermee;
        private System.Windows.Forms.Button btnPinceDroiteOuverte;
        private System.Windows.Forms.Button btnEpauleRange;
        private System.Windows.Forms.Button btnCoudeRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Composants.SwitchBouton switchBoutonPompeFeu;
    }
}
