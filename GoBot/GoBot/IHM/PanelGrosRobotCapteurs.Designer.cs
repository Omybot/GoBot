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
            this.groupBoxCapteurs = new Composants.GroupBoxRetractable();
            ((System.ComponentModel.ISupportInitialize)(this.ledJack)).BeginInit();
            this.groupBoxCapteurs.SuspendLayout();
            this.SuspendLayout();
            // 
            // ledJack
            // 
            this.ledJack.Etat = false;
            this.ledJack.Image = ((System.Drawing.Image)(resources.GetObject("ledJack.Image")));
            this.ledJack.Location = new System.Drawing.Point(143, 40);
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
            this.groupBoxCapteurs.Controls.Add(this.boxJack);
            this.groupBoxCapteurs.Controls.Add(this.ledJack);
            this.groupBoxCapteurs.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCapteurs.Name = "groupBoxCapteurs";
            this.groupBoxCapteurs.Size = new System.Drawing.Size(332, 165);
            this.groupBoxCapteurs.TabIndex = 1;
            this.groupBoxCapteurs.TabStop = false;
            this.groupBoxCapteurs.Text = "Capteurs";
            // 
            // PanelGrosRobotCapteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxCapteurs);
            this.Name = "PanelGrosRobotCapteurs";
            this.Size = new System.Drawing.Size(341, 174);
            this.Load += new System.EventHandler(this.PanelSequencesGros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ledJack)).EndInit();
            this.groupBoxCapteurs.ResumeLayout(false);
            this.groupBoxCapteurs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.Led ledJack;
        private System.Windows.Forms.CheckBox boxJack;
        private Composants.GroupBoxRetractable groupBoxCapteurs;
    }
}
