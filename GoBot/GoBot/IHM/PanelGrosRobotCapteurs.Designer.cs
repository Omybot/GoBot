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
            this.boxPresenceBouchon = new System.Windows.Forms.CheckBox();
            this.ledPresenceBouchon = new Composants.Led();
            this.boxCouleurEquipe = new System.Windows.Forms.CheckBox();
            this.ledCouleurEquipe = new Composants.Led();
            this.boxFeux = new System.Windows.Forms.CheckBox();
            this.ledFeu1 = new Composants.Led();
            this.ledFeu2 = new Composants.Led();
            this.ledFeu3 = new Composants.Led();
            ((System.ComponentModel.ISupportInitialize)(this.ledJack)).BeginInit();
            this.groupBoxCapteurs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledPresenceBouchon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledCouleurEquipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledFeu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledFeu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledFeu3)).BeginInit();
            this.SuspendLayout();
            // 
            // ledJack
            // 
            this.ledJack.Etat = false;
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
            this.groupBoxCapteurs.Controls.Add(this.ledFeu3);
            this.groupBoxCapteurs.Controls.Add(this.ledFeu2);
            this.groupBoxCapteurs.Controls.Add(this.boxFeux);
            this.groupBoxCapteurs.Controls.Add(this.ledFeu1);
            this.groupBoxCapteurs.Controls.Add(this.boxPresenceBouchon);
            this.groupBoxCapteurs.Controls.Add(this.ledPresenceBouchon);
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
            // boxPresenceBouchon
            // 
            this.boxPresenceBouchon.AutoSize = true;
            this.boxPresenceBouchon.Location = new System.Drawing.Point(23, 86);
            this.boxPresenceBouchon.Name = "boxPresenceBouchon";
            this.boxPresenceBouchon.Size = new System.Drawing.Size(122, 17);
            this.boxPresenceBouchon.TabIndex = 104;
            this.boxPresenceBouchon.Text = "Présence bouchon :";
            this.boxPresenceBouchon.UseVisualStyleBackColor = true;
            this.boxPresenceBouchon.CheckedChanged += new System.EventHandler(this.boxPresenceBouchon_CheckedChanged);
            // 
            // ledPresenceBouchon
            // 
            this.ledPresenceBouchon.Etat = false;
            this.ledPresenceBouchon.Image = ((System.Drawing.Image)(resources.GetObject("ledPresenceBouchon.Image")));
            this.ledPresenceBouchon.Location = new System.Drawing.Point(147, 86);
            this.ledPresenceBouchon.Name = "ledPresenceBouchon";
            this.ledPresenceBouchon.Size = new System.Drawing.Size(16, 16);
            this.ledPresenceBouchon.TabIndex = 105;
            this.ledPresenceBouchon.TabStop = false;
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
            this.ledCouleurEquipe.Etat = false;
            this.ledCouleurEquipe.Image = ((System.Drawing.Image)(resources.GetObject("ledCouleurEquipe.Image")));
            this.ledCouleurEquipe.Location = new System.Drawing.Point(147, 63);
            this.ledCouleurEquipe.Name = "ledCouleurEquipe";
            this.ledCouleurEquipe.Size = new System.Drawing.Size(16, 16);
            this.ledCouleurEquipe.TabIndex = 103;
            this.ledCouleurEquipe.TabStop = false;
            // 
            // boxFeux
            // 
            this.boxFeux.AutoSize = true;
            this.boxFeux.Location = new System.Drawing.Point(23, 109);
            this.boxFeux.Name = "boxFeux";
            this.boxFeux.Size = new System.Drawing.Size(100, 17);
            this.boxFeux.TabIndex = 106;
            this.boxFeux.Text = "Présence feux :";
            this.boxFeux.UseVisualStyleBackColor = true;
            this.boxFeux.CheckedChanged += new System.EventHandler(this.boxFeux_CheckedChanged);
            // 
            // ledFeu1
            // 
            this.ledFeu1.Etat = false;
            this.ledFeu1.Image = ((System.Drawing.Image)(resources.GetObject("ledFeu1.Image")));
            this.ledFeu1.Location = new System.Drawing.Point(147, 109);
            this.ledFeu1.Name = "ledFeu1";
            this.ledFeu1.Size = new System.Drawing.Size(16, 16);
            this.ledFeu1.TabIndex = 107;
            this.ledFeu1.TabStop = false;
            // 
            // ledFeu2
            // 
            this.ledFeu2.Etat = false;
            this.ledFeu2.Image = ((System.Drawing.Image)(resources.GetObject("ledFeu2.Image")));
            this.ledFeu2.Location = new System.Drawing.Point(169, 109);
            this.ledFeu2.Name = "ledFeu2";
            this.ledFeu2.Size = new System.Drawing.Size(16, 16);
            this.ledFeu2.TabIndex = 108;
            this.ledFeu2.TabStop = false;
            // 
            // ledFeu3
            // 
            this.ledFeu3.Etat = false;
            this.ledFeu3.Image = ((System.Drawing.Image)(resources.GetObject("ledFeu3.Image")));
            this.ledFeu3.Location = new System.Drawing.Point(191, 109);
            this.ledFeu3.Name = "ledFeu3";
            this.ledFeu3.Size = new System.Drawing.Size(16, 16);
            this.ledFeu3.TabIndex = 109;
            this.ledFeu3.TabStop = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.ledPresenceBouchon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledCouleurEquipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledFeu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledFeu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledFeu3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.Led ledJack;
        private System.Windows.Forms.CheckBox boxJack;
        private Composants.GroupBoxRetractable groupBoxCapteurs;
        private System.Windows.Forms.CheckBox boxCouleurEquipe;
        private Composants.Led ledCouleurEquipe;
        private System.Windows.Forms.CheckBox boxPresenceBouchon;
        private Composants.Led ledPresenceBouchon;
        private Composants.Led ledFeu3;
        private Composants.Led ledFeu2;
        private System.Windows.Forms.CheckBox boxFeux;
        private Composants.Led ledFeu1;
    }
}
