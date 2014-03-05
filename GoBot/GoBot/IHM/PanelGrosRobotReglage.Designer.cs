namespace GoBot.IHM
{
    partial class PanelGrosRobotReglage
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
            this.btnPinceGaucheOuverte = new System.Windows.Forms.Button();
            this.btnPinceGaucheFermee = new System.Windows.Forms.Button();
            this.btnPinceGaucheOk = new System.Windows.Forms.Button();
            this.numPinceGauche = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPinceDroiteOuverte = new System.Windows.Forms.Button();
            this.btnPinceDroiteFermee = new System.Windows.Forms.Button();
            this.btnPinceDroiteOk = new System.Windows.Forms.Button();
            this.numPinceDroite = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEpauleOk = new System.Windows.Forms.Button();
            this.numEpaule = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCoudeOk = new System.Windows.Forms.Button();
            this.numCoude = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxReglage = new Composants.GroupBoxRetractable();
            ((System.ComponentModel.ISupportInitialize)(this.numPinceGauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPinceDroite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpaule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoude)).BeginInit();
            this.groupBoxReglage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPinceGaucheOuverte
            // 
            this.btnPinceGaucheOuverte.Location = new System.Drawing.Point(265, 123);
            this.btnPinceGaucheOuverte.Name = "btnPinceGaucheOuverte";
            this.btnPinceGaucheOuverte.Size = new System.Drawing.Size(53, 23);
            this.btnPinceGaucheOuverte.TabIndex = 142;
            this.btnPinceGaucheOuverte.Text = "Ouverte";
            this.btnPinceGaucheOuverte.UseVisualStyleBackColor = true;
            this.btnPinceGaucheOuverte.Click += new System.EventHandler(this.btnPetitBrasBas_Click);
            // 
            // btnPinceGaucheFermee
            // 
            this.btnPinceGaucheFermee.Location = new System.Drawing.Point(206, 123);
            this.btnPinceGaucheFermee.Name = "btnPinceGaucheFermee";
            this.btnPinceGaucheFermee.Size = new System.Drawing.Size(53, 23);
            this.btnPinceGaucheFermee.TabIndex = 141;
            this.btnPinceGaucheFermee.Text = "Fermée";
            this.btnPinceGaucheFermee.UseVisualStyleBackColor = true;
            this.btnPinceGaucheFermee.Click += new System.EventHandler(this.btnPetitBrasHaut_Click);
            // 
            // btnPinceGaucheOk
            // 
            this.btnPinceGaucheOk.Location = new System.Drawing.Point(147, 123);
            this.btnPinceGaucheOk.Name = "btnPinceGaucheOk";
            this.btnPinceGaucheOk.Size = new System.Drawing.Size(53, 23);
            this.btnPinceGaucheOk.TabIndex = 140;
            this.btnPinceGaucheOk.Text = "Ok";
            this.btnPinceGaucheOk.UseVisualStyleBackColor = true;
            this.btnPinceGaucheOk.Click += new System.EventHandler(this.btnPetitBrasOk_Click);
            // 
            // numPinceGauche
            // 
            this.numPinceGauche.Location = new System.Drawing.Point(89, 126);
            this.numPinceGauche.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numPinceGauche.Name = "numPinceGauche";
            this.numPinceGauche.Size = new System.Drawing.Size(52, 20);
            this.numPinceGauche.TabIndex = 139;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 138;
            this.label5.Text = "Pince gauche";
            // 
            // btnPinceDroiteOuverte
            // 
            this.btnPinceDroiteOuverte.Location = new System.Drawing.Point(265, 97);
            this.btnPinceDroiteOuverte.Name = "btnPinceDroiteOuverte";
            this.btnPinceDroiteOuverte.Size = new System.Drawing.Size(53, 23);
            this.btnPinceDroiteOuverte.TabIndex = 136;
            this.btnPinceDroiteOuverte.Text = "Ouverte";
            this.btnPinceDroiteOuverte.UseVisualStyleBackColor = true;
            this.btnPinceDroiteOuverte.Click += new System.EventHandler(this.btnPinceDroiteOuverte_Click);
            // 
            // btnPinceDroiteFermee
            // 
            this.btnPinceDroiteFermee.Location = new System.Drawing.Point(206, 97);
            this.btnPinceDroiteFermee.Name = "btnPinceDroiteFermee";
            this.btnPinceDroiteFermee.Size = new System.Drawing.Size(53, 23);
            this.btnPinceDroiteFermee.TabIndex = 135;
            this.btnPinceDroiteFermee.Text = "Fermée";
            this.btnPinceDroiteFermee.UseVisualStyleBackColor = true;
            this.btnPinceDroiteFermee.Click += new System.EventHandler(this.btnPinceDroiteFermee_Click);
            // 
            // btnPinceDroiteOk
            // 
            this.btnPinceDroiteOk.Location = new System.Drawing.Point(147, 97);
            this.btnPinceDroiteOk.Name = "btnPinceDroiteOk";
            this.btnPinceDroiteOk.Size = new System.Drawing.Size(53, 23);
            this.btnPinceDroiteOk.TabIndex = 134;
            this.btnPinceDroiteOk.Text = "Ok";
            this.btnPinceDroiteOk.UseVisualStyleBackColor = true;
            this.btnPinceDroiteOk.Click += new System.EventHandler(this.btnPinceDroiteOk_Click);
            // 
            // numPinceDroite
            // 
            this.numPinceDroite.Location = new System.Drawing.Point(89, 100);
            this.numPinceDroite.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numPinceDroite.Name = "numPinceDroite";
            this.numPinceDroite.Size = new System.Drawing.Size(52, 20);
            this.numPinceDroite.TabIndex = 133;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 132;
            this.label4.Text = "Pince droite";
            // 
            // btnEpauleOk
            // 
            this.btnEpauleOk.Location = new System.Drawing.Point(147, 71);
            this.btnEpauleOk.Name = "btnEpauleOk";
            this.btnEpauleOk.Size = new System.Drawing.Size(53, 23);
            this.btnEpauleOk.TabIndex = 129;
            this.btnEpauleOk.Text = "Ok";
            this.btnEpauleOk.UseVisualStyleBackColor = true;
            this.btnEpauleOk.Click += new System.EventHandler(this.btnEpauleOk_Click);
            // 
            // numEpaule
            // 
            this.numEpaule.Location = new System.Drawing.Point(89, 74);
            this.numEpaule.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numEpaule.Name = "numEpaule";
            this.numEpaule.Size = new System.Drawing.Size(52, 20);
            this.numEpaule.TabIndex = 128;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 127;
            this.label1.Text = "Epaule";
            // 
            // btnCoudeOk
            // 
            this.btnCoudeOk.Location = new System.Drawing.Point(147, 45);
            this.btnCoudeOk.Name = "btnCoudeOk";
            this.btnCoudeOk.Size = new System.Drawing.Size(53, 23);
            this.btnCoudeOk.TabIndex = 124;
            this.btnCoudeOk.Text = "Ok";
            this.btnCoudeOk.UseVisualStyleBackColor = true;
            this.btnCoudeOk.Click += new System.EventHandler(this.btnCoudeOk_Click);
            // 
            // numCoude
            // 
            this.numCoude.Location = new System.Drawing.Point(89, 48);
            this.numCoude.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numCoude.Name = "numCoude";
            this.numCoude.Size = new System.Drawing.Size(52, 20);
            this.numCoude.TabIndex = 123;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 122;
            this.label3.Text = "Coude";
            // 
            // groupBoxReglage
            // 
            this.groupBoxReglage.Controls.Add(this.label3);
            this.groupBoxReglage.Controls.Add(this.numCoude);
            this.groupBoxReglage.Controls.Add(this.btnCoudeOk);
            this.groupBoxReglage.Controls.Add(this.label1);
            this.groupBoxReglage.Controls.Add(this.btnEpauleOk);
            this.groupBoxReglage.Controls.Add(this.numEpaule);
            this.groupBoxReglage.Controls.Add(this.label4);
            this.groupBoxReglage.Controls.Add(this.btnPinceGaucheOuverte);
            this.groupBoxReglage.Controls.Add(this.btnPinceGaucheFermee);
            this.groupBoxReglage.Controls.Add(this.numPinceDroite);
            this.groupBoxReglage.Controls.Add(this.btnPinceGaucheOk);
            this.groupBoxReglage.Controls.Add(this.btnPinceDroiteOk);
            this.groupBoxReglage.Controls.Add(this.label5);
            this.groupBoxReglage.Controls.Add(this.numPinceGauche);
            this.groupBoxReglage.Controls.Add(this.btnPinceDroiteFermee);
            this.groupBoxReglage.Controls.Add(this.btnPinceDroiteOuverte);
            this.groupBoxReglage.Location = new System.Drawing.Point(3, 3);
            this.groupBoxReglage.Name = "groupBoxReglage";
            this.groupBoxReglage.Size = new System.Drawing.Size(332, 382);
            this.groupBoxReglage.TabIndex = 1;
            this.groupBoxReglage.TabStop = false;
            this.groupBoxReglage.Text = "Réglages";
            // 
            // PanelGrosRobotReglage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxReglage);
            this.Name = "PanelGrosRobotReglage";
            this.Size = new System.Drawing.Size(341, 396);
            this.Load += new System.EventHandler(this.PanelReglageGros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPinceGauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPinceDroite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpaule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoude)).EndInit();
            this.groupBoxReglage.ResumeLayout(false);
            this.groupBoxReglage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEpauleOk;
        private System.Windows.Forms.NumericUpDown numEpaule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCoudeOk;
        private System.Windows.Forms.NumericUpDown numCoude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPinceGaucheOuverte;
        private System.Windows.Forms.Button btnPinceGaucheFermee;
        private System.Windows.Forms.Button btnPinceGaucheOk;
        private System.Windows.Forms.NumericUpDown numPinceGauche;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPinceDroiteOuverte;
        private System.Windows.Forms.Button btnPinceDroiteFermee;
        private System.Windows.Forms.Button btnPinceDroiteOk;
        private System.Windows.Forms.NumericUpDown numPinceDroite;
        private System.Windows.Forms.Label label4;
        private Composants.GroupBoxRetractable groupBoxReglage;
    }
}
