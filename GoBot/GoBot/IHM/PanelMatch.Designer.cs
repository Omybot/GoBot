namespace GoBot.IHM
{
    partial class PanelMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelMatch));
            this.btnArmerJack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRecallage = new System.Windows.Forms.Button();
            this.btnJoueurGauche = new System.Windows.Forms.Button();
            this.btnJoueurDroite = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pictureBoxTable = new System.Windows.Forms.PictureBox();
            this.ledJackArme = new Composants.Led();
            this.pictureBoxCouleur = new System.Windows.Forms.PictureBox();
            this.ledJackBranche = new Composants.Led();
            this.ledRecallageGros = new Composants.Led();
            this.boxHomologtion = new System.Windows.Forms.CheckBox();
            this.boxAR = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackArme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecallageGros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnArmerJack
            // 
            this.btnArmerJack.Location = new System.Drawing.Point(61, 350);
            this.btnArmerJack.Name = "btnArmerJack";
            this.btnArmerJack.Size = new System.Drawing.Size(227, 23);
            this.btnArmerJack.TabIndex = 39;
            this.btnArmerJack.Text = "Armer le jack";
            this.btnArmerJack.UseVisualStyleBackColor = true;
            this.btnArmerJack.Click += new System.EventHandler(this.btnArmerJack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Jack branché";
            // 
            // btnRecallage
            // 
            this.btnRecallage.Location = new System.Drawing.Point(61, 260);
            this.btnRecallage.Name = "btnRecallage";
            this.btnRecallage.Size = new System.Drawing.Size(227, 23);
            this.btnRecallage.TabIndex = 26;
            this.btnRecallage.Text = "Recallage des robots";
            this.btnRecallage.UseVisualStyleBackColor = true;
            this.btnRecallage.Click += new System.EventHandler(this.btnRecallage_Click);
            // 
            // btnJoueurGauche
            // 
            this.btnJoueurGauche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(1)))));
            this.btnJoueurGauche.ForeColor = System.Drawing.Color.Black;
            this.btnJoueurGauche.Location = new System.Drawing.Point(61, 81);
            this.btnJoueurGauche.Name = "btnJoueurGauche";
            this.btnJoueurGauche.Size = new System.Drawing.Size(75, 50);
            this.btnJoueurGauche.TabIndex = 22;
            this.btnJoueurGauche.UseVisualStyleBackColor = false;
            this.btnJoueurGauche.Click += new System.EventHandler(this.btnCouleurJoueurGauche_Click);
            // 
            // btnJoueurDroite
            // 
            this.btnJoueurDroite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.btnJoueurDroite.ForeColor = System.Drawing.Color.Black;
            this.btnJoueurDroite.Location = new System.Drawing.Point(236, 81);
            this.btnJoueurDroite.Name = "btnJoueurDroite";
            this.btnJoueurDroite.Size = new System.Drawing.Size(75, 50);
            this.btnJoueurDroite.TabIndex = 21;
            this.btnJoueurDroite.UseVisualStyleBackColor = false;
            this.btnJoueurDroite.Click += new System.EventHandler(this.btnCouleurJoueurDroite_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(136, 406);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 63;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pictureBoxTable
            // 
            this.pictureBoxTable.Image = global::GoBot.Properties.Resources.TablePlan;
            this.pictureBoxTable.Location = new System.Drawing.Point(421, 63);
            this.pictureBoxTable.Name = "pictureBoxTable";
            this.pictureBoxTable.Size = new System.Drawing.Size(782, 530);
            this.pictureBoxTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTable.TabIndex = 56;
            this.pictureBoxTable.TabStop = false;
            // 
            // ledJackArme
            // 
            this.ledJackArme.BackColor = System.Drawing.Color.Transparent;
            this.ledJackArme.Image = ((System.Drawing.Image)(resources.GetObject("ledJackArme.Image")));
            this.ledJackArme.Location = new System.Drawing.Point(294, 353);
            this.ledJackArme.Name = "ledJackArme";
            this.ledJackArme.Size = new System.Drawing.Size(16, 16);
            this.ledJackArme.TabIndex = 42;
            this.ledJackArme.TabStop = false;
            // 
            // pictureBoxCouleur
            // 
            this.pictureBoxCouleur.Location = new System.Drawing.Point(142, 81);
            this.pictureBoxCouleur.Name = "pictureBoxCouleur";
            this.pictureBoxCouleur.Size = new System.Drawing.Size(88, 50);
            this.pictureBoxCouleur.TabIndex = 23;
            this.pictureBoxCouleur.TabStop = false;
            // 
            // ledJackBranche
            // 
            this.ledJackBranche.BackColor = System.Drawing.Color.Transparent;
            this.ledJackBranche.Image = ((System.Drawing.Image)(resources.GetObject("ledJackBranche.Image")));
            this.ledJackBranche.Location = new System.Drawing.Point(217, 198);
            this.ledJackBranche.Name = "ledJackBranche";
            this.ledJackBranche.Size = new System.Drawing.Size(16, 16);
            this.ledJackBranche.TabIndex = 38;
            this.ledJackBranche.TabStop = false;
            // 
            // ledRecallageGros
            // 
            this.ledRecallageGros.BackColor = System.Drawing.Color.Transparent;
            this.ledRecallageGros.Image = ((System.Drawing.Image)(resources.GetObject("ledRecallageGros.Image")));
            this.ledRecallageGros.Location = new System.Drawing.Point(294, 263);
            this.ledRecallageGros.Name = "ledRecallageGros";
            this.ledRecallageGros.Size = new System.Drawing.Size(16, 16);
            this.ledRecallageGros.TabIndex = 35;
            this.ledRecallageGros.TabStop = false;
            // 
            // boxHomologtion
            // 
            this.boxHomologtion.AutoSize = true;
            this.boxHomologtion.Location = new System.Drawing.Point(71, 237);
            this.boxHomologtion.Name = "boxHomologtion";
            this.boxHomologtion.Size = new System.Drawing.Size(91, 17);
            this.boxHomologtion.TabIndex = 64;
            this.boxHomologtion.Text = "Homologation";
            this.boxHomologtion.UseVisualStyleBackColor = true;
            this.boxHomologtion.CheckedChanged += new System.EventHandler(this.boxHomologtion_CheckedChanged);
            // 
            // boxAR
            // 
            this.boxAR.AutoSize = true;
            this.boxAR.Location = new System.Drawing.Point(197, 237);
            this.boxAR.Name = "boxAR";
            this.boxAR.Size = new System.Drawing.Size(76, 17);
            this.boxAR.TabIndex = 65;
            this.boxAR.Text = "Aller retour";
            this.boxAR.UseVisualStyleBackColor = true;
            this.boxAR.CheckedChanged += new System.EventHandler(this.boxAR_CheckedChanged);
            // 
            // PanelMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.boxAR);
            this.Controls.Add(this.boxHomologtion);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pictureBoxTable);
            this.Controls.Add(this.ledJackArme);
            this.Controls.Add(this.btnArmerJack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRecallage);
            this.Controls.Add(this.pictureBoxCouleur);
            this.Controls.Add(this.btnJoueurGauche);
            this.Controls.Add(this.btnJoueurDroite);
            this.Controls.Add(this.ledJackBranche);
            this.Controls.Add(this.ledRecallageGros);
            this.Name = "PanelMatch";
            this.Size = new System.Drawing.Size(1273, 669);
            this.Load += new System.EventHandler(this.PanelMatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackArme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecallageGros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnArmerJack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRecallage;
        private System.Windows.Forms.PictureBox pictureBoxCouleur;
        private System.Windows.Forms.Button btnJoueurGauche;
        private System.Windows.Forms.Button btnJoueurDroite;
        private Composants.Led ledJackBranche;
        private Composants.Led ledRecallageGros;
        private Composants.Led ledJackArme;
        private System.Windows.Forms.PictureBox pictureBoxTable;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox boxHomologtion;
        private System.Windows.Forms.CheckBox boxAR;

    }
}
