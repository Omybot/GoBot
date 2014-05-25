namespace GoBot.IHM
{
    partial class PanelPetitRobotUtilisation
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
            this.groupBoxUtil = new System.Windows.Forms.GroupBox();
            this.switchBoutonReservoir = new Composants.SwitchBouton();
            this.label3 = new System.Windows.Forms.Label();
            this.switchBoutonFilet = new Composants.SwitchBouton();
            this.label2 = new System.Windows.Forms.Label();
            this.switchBoutonAimantLances = new Composants.SwitchBouton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDiagnostic = new System.Windows.Forms.Button();
            this.switchBoutonPuissance = new Composants.SwitchBouton();
            this.label12 = new System.Windows.Forms.Label();
            this.btnTaille = new System.Windows.Forms.Button();
            this.switchBoutonRideau = new Composants.SwitchBouton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLances = new System.Windows.Forms.Button();
            this.groupBoxUtil.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUtil
            // 
            this.groupBoxUtil.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxUtil.Controls.Add(this.btnLances);
            this.groupBoxUtil.Controls.Add(this.switchBoutonRideau);
            this.groupBoxUtil.Controls.Add(this.label4);
            this.groupBoxUtil.Controls.Add(this.switchBoutonReservoir);
            this.groupBoxUtil.Controls.Add(this.label3);
            this.groupBoxUtil.Controls.Add(this.switchBoutonFilet);
            this.groupBoxUtil.Controls.Add(this.label2);
            this.groupBoxUtil.Controls.Add(this.switchBoutonAimantLances);
            this.groupBoxUtil.Controls.Add(this.label1);
            this.groupBoxUtil.Controls.Add(this.btnDiagnostic);
            this.groupBoxUtil.Controls.Add(this.switchBoutonPuissance);
            this.groupBoxUtil.Controls.Add(this.label12);
            this.groupBoxUtil.Controls.Add(this.btnTaille);
            this.groupBoxUtil.Location = new System.Drawing.Point(5, 3);
            this.groupBoxUtil.Name = "groupBoxUtil";
            this.groupBoxUtil.Size = new System.Drawing.Size(332, 324);
            this.groupBoxUtil.TabIndex = 0;
            this.groupBoxUtil.TabStop = false;
            this.groupBoxUtil.Text = "Utilisation";
            // 
            // switchBoutonReservoir
            // 
            this.switchBoutonReservoir.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonReservoir.Location = new System.Drawing.Point(98, 165);
            this.switchBoutonReservoir.Name = "switchBoutonReservoir";
            this.switchBoutonReservoir.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonReservoir.Symetrique = false;
            this.switchBoutonReservoir.TabIndex = 208;
            this.switchBoutonReservoir.ChangementEtat += new System.EventHandler(this.switchBoutonReservoir_ChangementEtat);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 207;
            this.label3.Text = "Réservoir";
            // 
            // switchBoutonFilet
            // 
            this.switchBoutonFilet.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonFilet.Location = new System.Drawing.Point(98, 134);
            this.switchBoutonFilet.Name = "switchBoutonFilet";
            this.switchBoutonFilet.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonFilet.Symetrique = false;
            this.switchBoutonFilet.TabIndex = 206;
            this.switchBoutonFilet.ChangementEtat += new System.EventHandler(this.switchBoutonFilet_ChangementEtat);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 205;
            this.label2.Text = "Lance filet";
            // 
            // switchBoutonAimantLances
            // 
            this.switchBoutonAimantLances.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonAimantLances.Location = new System.Drawing.Point(98, 104);
            this.switchBoutonAimantLances.Name = "switchBoutonAimantLances";
            this.switchBoutonAimantLances.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonAimantLances.Symetrique = false;
            this.switchBoutonAimantLances.TabIndex = 204;
            this.switchBoutonAimantLances.ChangementEtat += new System.EventHandler(this.switchBoutonAimantLances_ChangementEtat);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 203;
            this.label1.Text = "Aimant lances";
            // 
            // btnDiagnostic
            // 
            this.btnDiagnostic.Location = new System.Drawing.Point(203, 19);
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
            this.switchBoutonPuissance.Location = new System.Drawing.Point(137, 25);
            this.switchBoutonPuissance.Name = "switchBoutonPuissance";
            this.switchBoutonPuissance.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonPuissance.Symetrique = false;
            this.switchBoutonPuissance.TabIndex = 200;
            this.switchBoutonPuissance.ChangementEtat += new System.EventHandler(this.switchBoutonPuissance_ChangementEtat);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 13);
            this.label12.TabIndex = 199;
            this.label12.Text = "Alimentation puissance";
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
            // switchBoutonRideau
            // 
            this.switchBoutonRideau.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonRideau.Location = new System.Drawing.Point(98, 196);
            this.switchBoutonRideau.Name = "switchBoutonRideau";
            this.switchBoutonRideau.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonRideau.Symetrique = false;
            this.switchBoutonRideau.TabIndex = 210;
            this.switchBoutonRideau.ChangementEtat += new System.EventHandler(this.switchBoutonRideau_ChangementEtat);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 209;
            this.label4.Text = "Rideau";
            // 
            // btnLances
            // 
            this.btnLances.Location = new System.Drawing.Point(58, 251);
            this.btnLances.Name = "btnLances";
            this.btnLances.Size = new System.Drawing.Size(75, 23);
            this.btnLances.TabIndex = 211;
            this.btnLances.Text = "Attaque lances";
            this.btnLances.UseVisualStyleBackColor = true;
            this.btnLances.Click += new System.EventHandler(this.btnLances_Click);
            // 
            // PanelPetitRobotUtilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxUtil);
            this.Name = "PanelPetitRobotUtilisation";
            this.Size = new System.Drawing.Size(341, 332);
            this.Load += new System.EventHandler(this.PanelUtilGros_Load);
            this.groupBoxUtil.ResumeLayout(false);
            this.groupBoxUtil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUtil;
        protected System.Windows.Forms.Button btnTaille;
        private Composants.SwitchBouton switchBoutonPuissance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnDiagnostic;
        private Composants.SwitchBouton switchBoutonAimantLances;
        private System.Windows.Forms.Label label1;
        private Composants.SwitchBouton switchBoutonFilet;
        private System.Windows.Forms.Label label2;
        private Composants.SwitchBouton switchBoutonReservoir;
        private System.Windows.Forms.Label label3;
        private Composants.SwitchBouton switchBoutonRideau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLances;
    }
}
