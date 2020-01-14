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
            this.boxMyColor = new System.Windows.Forms.CheckBox();
            this.ledMyColor = new Composants.Led();
            ((System.ComponentModel.ISupportInitialize)(this.ledStartTrigger)).BeginInit();
            this.grpSensors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledMyColor)).BeginInit();
            this.SuspendLayout();
            // 
            // ledStartTrigger
            // 
            this.ledStartTrigger.Image = ((System.Drawing.Image)(resources.GetObject("ledJack.Image")));
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
            this.grpSensors.Controls.Add(this.boxMyColor);
            this.grpSensors.Controls.Add(this.ledMyColor);
            this.grpSensors.Controls.Add(this.boxJack);
            this.grpSensors.Controls.Add(this.ledStartTrigger);
            this.grpSensors.Location = new System.Drawing.Point(3, 3);
            this.grpSensors.Name = "grpSensors";
            this.grpSensors.Size = new System.Drawing.Size(332, 185);
            this.grpSensors.TabIndex = 1;
            this.grpSensors.TabStop = false;
            this.grpSensors.Text = "Capteurs";
            // 
            // boxMyColor
            // 
            this.boxMyColor.AutoSize = true;
            this.boxMyColor.Location = new System.Drawing.Point(23, 63);
            this.boxMyColor.Name = "boxMyColor";
            this.boxMyColor.Size = new System.Drawing.Size(103, 17);
            this.boxMyColor.TabIndex = 102;
            this.boxMyColor.Text = "Couleur équipe :";
            this.boxMyColor.UseVisualStyleBackColor = true;
            this.boxMyColor.CheckedChanged += new System.EventHandler(this.boxMyColor_CheckedChanged);
            // 
            // ledMyColor
            // 
            this.ledMyColor.Image = ((System.Drawing.Image)(resources.GetObject("ledCouleurEquipe.Image")));
            this.ledMyColor.Location = new System.Drawing.Point(147, 63);
            this.ledMyColor.Name = "ledMyColor";
            this.ledMyColor.Size = new System.Drawing.Size(16, 16);
            this.ledMyColor.TabIndex = 103;
            this.ledMyColor.TabStop = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.ledMyColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.Led ledStartTrigger;
        private System.Windows.Forms.CheckBox boxJack;
        private Composants.GroupBoxPlus grpSensors;
        private System.Windows.Forms.CheckBox boxMyColor;
        private Composants.Led ledMyColor;
    }
}
