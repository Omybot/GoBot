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
            this.ledJack = new Composants.Led();
            this.boxJack = new System.Windows.Forms.CheckBox();
            this.groupBoxCapteurs = new Composants.GroupBoxPlus();
            this.boxCouleurEquipe = new System.Windows.Forms.CheckBox();
            this.ledCouleurEquipe = new Composants.Led();
            ((System.ComponentModel.ISupportInitialize)(this.ledJack)).BeginInit();
            this.groupBoxCapteurs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledCouleurEquipe)).BeginInit();
            this.SuspendLayout();
            // 
            // ledJack
            // 
            this.ledJack.Image = ((System.Drawing.Image)(resources.GetObject("ledJack.Image")));
            this.ledJack.Location = new System.Drawing.Point(147, 40);
            this.ledJack.Name = "ledJack";
            this.ledJack.Size = new System.Drawing.Size(16, 16);
            this.ledJack.TabIndex = 101;
            this.ledJack.TabStop = false;
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
            // groupBoxCapteurs
            // 
            this.groupBoxCapteurs.Controls.Add(this.boxCouleurEquipe);
            this.groupBoxCapteurs.Controls.Add(this.ledCouleurEquipe);
            this.groupBoxCapteurs.Controls.Add(this.boxJack);
            this.groupBoxCapteurs.Controls.Add(this.ledJack);
            this.groupBoxCapteurs.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCapteurs.Name = "groupBoxCapteurs";
            this.groupBoxCapteurs.Size = new System.Drawing.Size(332, 185);
            this.groupBoxCapteurs.TabIndex = 1;
            this.groupBoxCapteurs.TabStop = false;
            this.groupBoxCapteurs.Text = "Capteurs";
            // 
            // boxCouleurEquipe
            // 
            this.boxCouleurEquipe.AutoSize = true;
            this.boxCouleurEquipe.Location = new System.Drawing.Point(23, 63);
            this.boxCouleurEquipe.Name = "boxCouleurEquipe";
            this.boxCouleurEquipe.Size = new System.Drawing.Size(103, 17);
            this.boxCouleurEquipe.TabIndex = 102;
            this.boxCouleurEquipe.Text = "Couleur équipe :";
            this.boxCouleurEquipe.UseVisualStyleBackColor = true;
            this.boxCouleurEquipe.CheckedChanged += new System.EventHandler(this.boxCouleurEquipe_CheckedChanged);
            // 
            // ledCouleurEquipe
            // 
            this.ledCouleurEquipe.Image = ((System.Drawing.Image)(resources.GetObject("ledCouleurEquipe.Image")));
            this.ledCouleurEquipe.Location = new System.Drawing.Point(147, 63);
            this.ledCouleurEquipe.Name = "ledCouleurEquipe";
            this.ledCouleurEquipe.Size = new System.Drawing.Size(16, 16);
            this.ledCouleurEquipe.TabIndex = 103;
            this.ledCouleurEquipe.TabStop = false;
            // 
            // PanelGrosRobotCapteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxCapteurs);
            this.Name = "PanelGrosRobotCapteurs";
            this.Size = new System.Drawing.Size(341, 194);
            this.Load += new System.EventHandler(this.PanelSequencesGros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ledJack)).EndInit();
            this.groupBoxCapteurs.ResumeLayout(false);
            this.groupBoxCapteurs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledCouleurEquipe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.Led ledJack;
        private System.Windows.Forms.CheckBox boxJack;
        private Composants.GroupBoxPlus groupBoxCapteurs;
        private System.Windows.Forms.CheckBox boxCouleurEquipe;
        private Composants.Led ledCouleurEquipe;
    }
}
