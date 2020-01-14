namespace GoBot.IHM
{
    partial class PanelGrosRobotCapteurs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelGrosRobotCapteurs));
            this.ledStartTrigger = new Composants.Led();
            this.boxJack = new System.Windows.Forms.CheckBox();
            this.grpSensors = new Composants.GroupBoxPlus();
            ((System.ComponentModel.ISupportInitialize)(this.ledStartTrigger)).BeginInit();
            this.grpSensors.SuspendLayout();
            this.SuspendLayout();
            // 
            // ledStartTrigger
            // 
            this.ledStartTrigger.BackColor = System.Drawing.Color.Transparent;
            this.ledStartTrigger.Color = System.Drawing.Color.Red;
            this.ledStartTrigger.Image = ((System.Drawing.Image)(resources.GetObject("ledStartTrigger.Image")));
            this.ledStartTrigger.Location = new System.Drawing.Point(147, 40);
            this.ledStartTrigger.Name = "ledStartTrigger";
            this.ledStartTrigger.Size = new System.Drawing.Size(16, 16);
            this.ledStartTrigger.TabIndex = 101;
            this.ledStartTrigger.TabStop = false;
            // 
            // boxJack
            // 
            this.boxJack.AutoSize = true;
            this.boxJack.Location = new System.Drawing.Point(23, 40);
            this.boxJack.Name = "boxJack";
            this.boxJack.Size = new System.Drawing.Size(100, 17);
            this.boxJack.TabIndex = 100;
            this.boxJack.Text = "Présence jack :";
            this.boxJack.UseVisualStyleBackColor = true;
            this.boxJack.CheckedChanged += new System.EventHandler(this.boxJack_CheckedChanged);
            // 
            // grpSensors
            // 
            this.grpSensors.Controls.Add(this.boxJack);
            this.grpSensors.Controls.Add(this.ledStartTrigger);
            this.grpSensors.Location = new System.Drawing.Point(3, 3);
            this.grpSensors.Name = "grpSensors";
            this.grpSensors.Size = new System.Drawing.Size(332, 185);
            this.grpSensors.TabIndex = 1;
            this.grpSensors.TabStop = false;
            this.grpSensors.Text = "Capteurs";
            // 
            // PanelGrosRobotCapteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpSensors);
            this.Name = "PanelGrosRobotCapteurs";
            this.Size = new System.Drawing.Size(341, 194);
            this.Load += new System.EventHandler(this.PanelSequencesGros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ledStartTrigger)).EndInit();
            this.grpSensors.ResumeLayout(false);
            this.grpSensors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.Led ledStartTrigger;
        private System.Windows.Forms.CheckBox boxJack;
        private Composants.GroupBoxPlus grpSensors;
    }
}
