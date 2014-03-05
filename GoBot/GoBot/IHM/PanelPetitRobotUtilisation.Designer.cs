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
            this.btnDiagnostic = new System.Windows.Forms.Button();
            this.switchBoutonPuissance = new Composants.SwitchBouton();
            this.label12 = new System.Windows.Forms.Label();
            this.btnTaille = new System.Windows.Forms.Button();
            this.groupBoxUtil.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUtil
            // 
            this.groupBoxUtil.BackColor = System.Drawing.Color.Transparent;
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
    }
}
