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
            this.groupBoxUtilisation = new Composants.GroupBoxPlus();
            this.btnDiagnostic = new System.Windows.Forms.Button();
            this.panelActionneursOnOff1 = new GoBot.IHM.PanelActionneursOnOff();
            this.groupBoxUtilisation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUtilisation
            // 
            this.groupBoxUtilisation.Controls.Add(this.panelActionneursOnOff1);
            this.groupBoxUtilisation.Controls.Add(this.btnDiagnostic);
            this.groupBoxUtilisation.Location = new System.Drawing.Point(3, 3);
            this.groupBoxUtilisation.Name = "groupBoxUtilisation";
            this.groupBoxUtilisation.Size = new System.Drawing.Size(332, 196);
            this.groupBoxUtilisation.TabIndex = 1;
            this.groupBoxUtilisation.TabStop = false;
            this.groupBoxUtilisation.Text = "Utilisation";
            // 
            // btnDiagnostic
            // 
            this.btnDiagnostic.Location = new System.Drawing.Point(130, 11);
            this.btnDiagnostic.Name = "btnDiagnostic";
            this.btnDiagnostic.Size = new System.Drawing.Size(75, 23);
            this.btnDiagnostic.TabIndex = 201;
            this.btnDiagnostic.Text = "Diagnostic";
            this.btnDiagnostic.UseVisualStyleBackColor = true;
            this.btnDiagnostic.Click += new System.EventHandler(this.btnDiagnostic_Click);
            // 
            // panelActionneursOnOff1
            // 
            this.panelActionneursOnOff1.Location = new System.Drawing.Point(6, 40);
            this.panelActionneursOnOff1.Name = "panelActionneursOnOff1";
            this.panelActionneursOnOff1.Size = new System.Drawing.Size(320, 150);
            this.panelActionneursOnOff1.TabIndex = 202;
            // 
            // PanelGrosRobotUtilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxUtilisation);
            this.Name = "PanelGrosRobotUtilisation";
            this.Size = new System.Drawing.Size(341, 202);
            this.Load += new System.EventHandler(this.PanelUtilGros_Load);
            this.groupBoxUtilisation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDiagnostic;
        private Composants.GroupBoxPlus groupBoxUtilisation;
        private PanelActionneursOnOff panelActionneursOnOff1;
    }
}
