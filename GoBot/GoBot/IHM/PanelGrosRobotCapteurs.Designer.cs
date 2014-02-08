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
            this.boxVitesseCanon = new System.Windows.Forms.CheckBox();
            this.lblVitesseCanon = new System.Windows.Forms.Label();
            this.ledAspi = new Composants.Led();
            this.boxAspiRemonte = new System.Windows.Forms.CheckBox();
            this.ledAssiette = new Composants.Led();
            this.boxAssiette = new System.Windows.Forms.CheckBox();
            this.ledCouleur = new Composants.Led();
            this.ledPresence = new Composants.Led();
            this.boxCouleur = new System.Windows.Forms.CheckBox();
            this.boxBalle = new System.Windows.Forms.CheckBox();
            this.groupBoxCapteurs = new Composants.GroupBoxRetractable();
            ((System.ComponentModel.ISupportInitialize)(this.ledJack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledAspi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledAssiette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledCouleur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPresence)).BeginInit();
            this.groupBoxCapteurs.SuspendLayout();
            this.SuspendLayout();
            // 
            // ledJack
            // 
            this.ledJack.Etat = false;
            this.ledJack.Image = ((System.Drawing.Image)(resources.GetObject("ledJack.Image")));
            this.ledJack.Location = new System.Drawing.Point(139, 132);
            this.ledJack.Name = "ledJack";
            this.ledJack.Size = new System.Drawing.Size(16, 16);
            this.ledJack.TabIndex = 101;
            this.ledJack.TabStop = false;
            // 
            // boxJack
            // 
            this.boxJack.AutoSize = true;
            this.boxJack.Location = new System.Drawing.Point(19, 132);
            this.boxJack.Name = "boxJack";
            this.boxJack.Size = new System.Drawing.Size(100, 17);
            this.boxJack.TabIndex = 100;
            this.boxJack.Text = "Présence jack :";
            this.boxJack.UseVisualStyleBackColor = true;
            this.boxJack.CheckedChanged += new System.EventHandler(this.boxJack_CheckedChanged);
            // 
            // boxVitesseCanon
            // 
            this.boxVitesseCanon.AutoSize = true;
            this.boxVitesseCanon.Location = new System.Drawing.Point(173, 96);
            this.boxVitesseCanon.Name = "boxVitesseCanon";
            this.boxVitesseCanon.Size = new System.Drawing.Size(99, 17);
            this.boxVitesseCanon.TabIndex = 99;
            this.boxVitesseCanon.Text = "Vitesse canon :";
            this.boxVitesseCanon.UseVisualStyleBackColor = true;
            this.boxVitesseCanon.CheckedChanged += new System.EventHandler(this.boxVitesseCanon_CheckedChanged);
            // 
            // lblVitesseCanon
            // 
            this.lblVitesseCanon.AutoSize = true;
            this.lblVitesseCanon.Location = new System.Drawing.Point(290, 96);
            this.lblVitesseCanon.Name = "lblVitesseCanon";
            this.lblVitesseCanon.Size = new System.Drawing.Size(10, 13);
            this.lblVitesseCanon.TabIndex = 98;
            this.lblVitesseCanon.Text = "-";
            // 
            // ledAspi
            // 
            this.ledAspi.Etat = false;
            this.ledAspi.Image = ((System.Drawing.Image)(resources.GetObject("ledAspi.Image")));
            this.ledAspi.Location = new System.Drawing.Point(293, 64);
            this.ledAspi.Name = "ledAspi";
            this.ledAspi.Size = new System.Drawing.Size(16, 16);
            this.ledAspi.TabIndex = 97;
            this.ledAspi.TabStop = false;
            // 
            // boxAspiRemonte
            // 
            this.boxAspiRemonte.AutoSize = true;
            this.boxAspiRemonte.Location = new System.Drawing.Point(173, 64);
            this.boxAspiRemonte.Name = "boxAspiRemonte";
            this.boxAspiRemonte.Size = new System.Drawing.Size(93, 17);
            this.boxAspiRemonte.TabIndex = 96;
            this.boxAspiRemonte.Text = "Aspi remonté :";
            this.boxAspiRemonte.UseVisualStyleBackColor = true;
            this.boxAspiRemonte.CheckedChanged += new System.EventHandler(this.boxAspiRemonte_CheckedChanged);
            // 
            // ledAssiette
            // 
            this.ledAssiette.Etat = false;
            this.ledAssiette.Image = ((System.Drawing.Image)(resources.GetObject("ledAssiette.Image")));
            this.ledAssiette.Location = new System.Drawing.Point(139, 98);
            this.ledAssiette.Name = "ledAssiette";
            this.ledAssiette.Size = new System.Drawing.Size(16, 16);
            this.ledAssiette.TabIndex = 95;
            this.ledAssiette.TabStop = false;
            // 
            // boxAssiette
            // 
            this.boxAssiette.AutoSize = true;
            this.boxAssiette.Location = new System.Drawing.Point(19, 98);
            this.boxAssiette.Name = "boxAssiette";
            this.boxAssiette.Size = new System.Drawing.Size(116, 17);
            this.boxAssiette.TabIndex = 94;
            this.boxAssiette.Text = "Présence assiette :";
            this.boxAssiette.UseVisualStyleBackColor = true;
            this.boxAssiette.CheckedChanged += new System.EventHandler(this.boxAssiette_CheckedChanged);
            // 
            // ledCouleur
            // 
            this.ledCouleur.Etat = false;
            this.ledCouleur.Image = ((System.Drawing.Image)(resources.GetObject("ledCouleur.Image")));
            this.ledCouleur.Location = new System.Drawing.Point(139, 65);
            this.ledCouleur.Name = "ledCouleur";
            this.ledCouleur.Size = new System.Drawing.Size(16, 16);
            this.ledCouleur.TabIndex = 93;
            this.ledCouleur.TabStop = false;
            // 
            // ledPresence
            // 
            this.ledPresence.Etat = false;
            this.ledPresence.Image = ((System.Drawing.Image)(resources.GetObject("ledPresence.Image")));
            this.ledPresence.Location = new System.Drawing.Point(139, 30);
            this.ledPresence.Name = "ledPresence";
            this.ledPresence.Size = new System.Drawing.Size(16, 16);
            this.ledPresence.TabIndex = 92;
            this.ledPresence.TabStop = false;
            // 
            // boxCouleur
            // 
            this.boxCouleur.AutoSize = true;
            this.boxCouleur.Location = new System.Drawing.Point(19, 65);
            this.boxCouleur.Name = "boxCouleur";
            this.boxCouleur.Size = new System.Drawing.Size(93, 17);
            this.boxCouleur.TabIndex = 90;
            this.boxCouleur.Text = "Couleur balle :";
            this.boxCouleur.UseVisualStyleBackColor = true;
            this.boxCouleur.CheckedChanged += new System.EventHandler(this.boxCouleur_CheckedChanged);
            // 
            // boxBalle
            // 
            this.boxBalle.AutoSize = true;
            this.boxBalle.Location = new System.Drawing.Point(19, 30);
            this.boxBalle.Name = "boxBalle";
            this.boxBalle.Size = new System.Drawing.Size(102, 17);
            this.boxBalle.TabIndex = 88;
            this.boxBalle.Text = "Présence balle :";
            this.boxBalle.UseVisualStyleBackColor = true;
            this.boxBalle.CheckedChanged += new System.EventHandler(this.boxBalle_CheckedChanged);
            // 
            // groupBoxCapteurs
            // 
            this.groupBoxCapteurs.Controls.Add(this.ledJack);
            this.groupBoxCapteurs.Controls.Add(this.boxJack);
            this.groupBoxCapteurs.Controls.Add(this.boxBalle);
            this.groupBoxCapteurs.Controls.Add(this.boxVitesseCanon);
            this.groupBoxCapteurs.Controls.Add(this.boxCouleur);
            this.groupBoxCapteurs.Controls.Add(this.lblVitesseCanon);
            this.groupBoxCapteurs.Controls.Add(this.ledPresence);
            this.groupBoxCapteurs.Controls.Add(this.ledAspi);
            this.groupBoxCapteurs.Controls.Add(this.ledCouleur);
            this.groupBoxCapteurs.Controls.Add(this.boxAspiRemonte);
            this.groupBoxCapteurs.Controls.Add(this.boxAssiette);
            this.groupBoxCapteurs.Controls.Add(this.ledAssiette);
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
            ((System.ComponentModel.ISupportInitialize)(this.ledAspi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledAssiette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledCouleur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPresence)).EndInit();
            this.groupBoxCapteurs.ResumeLayout(false);
            this.groupBoxCapteurs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox boxBalle;
        private System.Windows.Forms.CheckBox boxCouleur;
        private Composants.Led ledPresence;
        private Composants.Led ledCouleur;
        private Composants.Led ledAssiette;
        private System.Windows.Forms.CheckBox boxAssiette;
        private Composants.Led ledAspi;
        private System.Windows.Forms.CheckBox boxAspiRemonte;
        private System.Windows.Forms.Label lblVitesseCanon;
        private System.Windows.Forms.CheckBox boxVitesseCanon;
        private Composants.Led ledJack;
        private System.Windows.Forms.CheckBox boxJack;
        private Composants.GroupBoxRetractable groupBoxCapteurs;
    }
}
