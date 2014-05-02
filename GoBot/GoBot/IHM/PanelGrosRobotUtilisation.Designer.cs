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
            this.btnTirBouchon = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.switchBoutonElectrvanne = new Composants.SwitchBouton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.switchBoutonPompeFeu = new Composants.SwitchBouton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEpauleRange = new System.Windows.Forms.Button();
            this.btnCoudeRange = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDiagnostic = new System.Windows.Forms.Button();
            this.switchBoutonPuissance = new Composants.SwitchBouton();
            this.label8 = new System.Windows.Forms.Label();
            this.switchBoutonPousse = new Composants.SwitchBouton();
            this.switchBoutonPinceGauche = new Composants.SwitchBouton();
            this.switchBoutonPinceDroite = new Composants.SwitchBouton();
            this.groupBoxUtilisation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUtilisation
            // 
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonPinceGauche);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonPinceDroite);
            this.groupBoxUtilisation.Controls.Add(this.label8);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonPousse);
            this.groupBoxUtilisation.Controls.Add(this.btnTirBouchon);
            this.groupBoxUtilisation.Controls.Add(this.label7);
            this.groupBoxUtilisation.Controls.Add(this.label6);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonElectrvanne);
            this.groupBoxUtilisation.Controls.Add(this.label2);
            this.groupBoxUtilisation.Controls.Add(this.label3);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonPompeFeu);
            this.groupBoxUtilisation.Controls.Add(this.label1);
            this.groupBoxUtilisation.Controls.Add(this.btnEpauleRange);
            this.groupBoxUtilisation.Controls.Add(this.btnCoudeRange);
            this.groupBoxUtilisation.Controls.Add(this.label4);
            this.groupBoxUtilisation.Controls.Add(this.label5);
            this.groupBoxUtilisation.Controls.Add(this.label12);
            this.groupBoxUtilisation.Controls.Add(this.btnDiagnostic);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonPuissance);
            this.groupBoxUtilisation.Location = new System.Drawing.Point(3, 3);
            this.groupBoxUtilisation.Name = "groupBoxUtilisation";
            this.groupBoxUtilisation.Size = new System.Drawing.Size(332, 244);
            this.groupBoxUtilisation.TabIndex = 1;
            this.groupBoxUtilisation.TabStop = false;
            this.groupBoxUtilisation.Text = "Utilisation";
            // 
            // btnTirBouchon
            // 
            this.btnTirBouchon.Location = new System.Drawing.Point(117, 205);
            this.btnTirBouchon.Name = "btnTirBouchon";
            this.btnTirBouchon.Size = new System.Drawing.Size(53, 23);
            this.btnTirBouchon.TabIndex = 221;
            this.btnTirBouchon.Text = "Feu !!";
            this.btnTirBouchon.UseVisualStyleBackColor = true;
            this.btnTirBouchon.Click += new System.EventHandler(this.btnTirBouchon_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 220;
            this.label7.Text = "Tir bouchon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 219;
            this.label6.Text = "Electrovanne";
            // 
            // switchBoutonElectrvanne
            // 
            this.switchBoutonElectrvanne.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonElectrvanne.Location = new System.Drawing.Point(264, 184);
            this.switchBoutonElectrvanne.Name = "switchBoutonElectrvanne";
            this.switchBoutonElectrvanne.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonElectrvanne.Symetrique = true;
            this.switchBoutonElectrvanne.TabIndex = 218;
            this.switchBoutonElectrvanne.ChangementEtat += new System.EventHandler(this.switchBoutonElectrvanne_ChangementEtat);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Pince gauche";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 223;
            this.label8.Text = "Pousse bouchon";
            // 
            // switchBoutonPousse
            // 
            this.switchBoutonPousse.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonPousse.Location = new System.Drawing.Point(264, 210);
            this.switchBoutonPousse.Name = "switchBoutonPousse";
            this.switchBoutonPousse.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonPousse.Symetrique = true;
            this.switchBoutonPousse.TabIndex = 222;
            this.switchBoutonPousse.ChangementEtat += new System.EventHandler(this.switchBoutonPousse_ChangementEtat);
            // 
            // switchBoutonPinceGauche
            // 
            this.switchBoutonPinceGauche.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonPinceGauche.Location = new System.Drawing.Point(117, 160);
            this.switchBoutonPinceGauche.Name = "switchBoutonPinceGauche";
            this.switchBoutonPinceGauche.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonPinceGauche.Symetrique = true;
            this.switchBoutonPinceGauche.TabIndex = 225;
            this.switchBoutonPinceGauche.ChangementEtat += new System.EventHandler(this.switchBoutonPinceGauche_ChangementEtat);
            // 
            // switchBoutonPinceDroite
            // 
            this.switchBoutonPinceDroite.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonPinceDroite.Location = new System.Drawing.Point(117, 134);
            this.switchBoutonPinceDroite.Name = "switchBoutonPinceDroite";
            this.switchBoutonPinceDroite.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonPinceDroite.Symetrique = true;
            this.switchBoutonPinceDroite.TabIndex = 224;
            this.switchBoutonPinceDroite.ChangementEtat += new System.EventHandler(this.switchBoutonPinceDroite_ChangementEtat);
            // 
            // PanelGrosRobotUtilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxUtilisation);
            this.Name = "PanelGrosRobotUtilisation";
            this.Size = new System.Drawing.Size(341, 250);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEpauleRange;
        private System.Windows.Forms.Button btnCoudeRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Composants.SwitchBouton switchBoutonPompeFeu;
        private System.Windows.Forms.Label label6;
        private Composants.SwitchBouton switchBoutonElectrvanne;
        private System.Windows.Forms.Button btnTirBouchon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Composants.SwitchBouton switchBoutonPousse;
        private Composants.SwitchBouton switchBoutonPinceGauche;
        private Composants.SwitchBouton switchBoutonPinceDroite;
    }
}
