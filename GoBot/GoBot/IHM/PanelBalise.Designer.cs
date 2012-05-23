namespace GoBot.IHM
{
    partial class PanelBalise
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
            this.groupBalise = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAsserv = new System.Windows.Forms.Button();
            this.ledOffset = new GoBot.IHM.Composants.Led();
            this.btnOffset = new System.Windows.Forms.Button();
            this.ledAsserv = new GoBot.IHM.Composants.Led();
            this.boxAsservContinu = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblToursSecondesActuel = new System.Windows.Forms.Label();
            this.lblConsigneAff = new System.Windows.Forms.Label();
            this.lblConsigne = new System.Windows.Forms.Label();
            this.trackBarConsigne = new GoBot.IHM.Composants.TrackBarPlus();
            this.lblVitesseAff = new System.Windows.Forms.Label();
            this.boxAffichage = new System.Windows.Forms.CheckBox();
            this.pictureBoxAngle = new System.Windows.Forms.PictureBox();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.trackBarVitesse = new GoBot.IHM.Composants.TrackBarPlus();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBalise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledAsserv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBalise
            // 
            this.groupBalise.Controls.Add(this.btnReset);
            this.groupBalise.Controls.Add(this.btnStop);
            this.groupBalise.Controls.Add(this.btnStart);
            this.groupBalise.Controls.Add(this.btnAsserv);
            this.groupBalise.Controls.Add(this.ledOffset);
            this.groupBalise.Controls.Add(this.btnOffset);
            this.groupBalise.Controls.Add(this.ledAsserv);
            this.groupBalise.Controls.Add(this.boxAsservContinu);
            this.groupBalise.Controls.Add(this.label2);
            this.groupBalise.Controls.Add(this.lblToursSecondesActuel);
            this.groupBalise.Controls.Add(this.lblConsigneAff);
            this.groupBalise.Controls.Add(this.lblConsigne);
            this.groupBalise.Controls.Add(this.trackBarConsigne);
            this.groupBalise.Controls.Add(this.lblVitesseAff);
            this.groupBalise.Controls.Add(this.boxAffichage);
            this.groupBalise.Controls.Add(this.pictureBoxAngle);
            this.groupBalise.Controls.Add(this.lblVitesse);
            this.groupBalise.Controls.Add(this.trackBarVitesse);
            this.groupBalise.Location = new System.Drawing.Point(3, 3);
            this.groupBalise.Name = "groupBalise";
            this.groupBalise.Size = new System.Drawing.Size(327, 485);
            this.groupBalise.TabIndex = 0;
            this.groupBalise.TabStop = false;
            this.groupBalise.Text = "Balise";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 390);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 19;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAsserv
            // 
            this.btnAsserv.Location = new System.Drawing.Point(6, 317);
            this.btnAsserv.Name = "btnAsserv";
            this.btnAsserv.Size = new System.Drawing.Size(75, 23);
            this.btnAsserv.TabIndex = 18;
            this.btnAsserv.Text = "Asserv. actif";
            this.btnAsserv.UseVisualStyleBackColor = true;
            this.btnAsserv.Click += new System.EventHandler(this.btnAsserv_Click);
            // 
            // ledOffset
            // 
            this.ledOffset.Etat = false;
            this.ledOffset.Location = new System.Drawing.Point(84, 349);
            this.ledOffset.Name = "ledOffset";
            this.ledOffset.Size = new System.Drawing.Size(16, 16);
            this.ledOffset.TabIndex = 17;
            this.ledOffset.TabStop = false;
            // 
            // btnOffset
            // 
            this.btnOffset.Location = new System.Drawing.Point(6, 346);
            this.btnOffset.Name = "btnOffset";
            this.btnOffset.Size = new System.Drawing.Size(75, 23);
            this.btnOffset.TabIndex = 16;
            this.btnOffset.Text = "Calcul offset";
            this.btnOffset.UseVisualStyleBackColor = true;
            this.btnOffset.Click += new System.EventHandler(this.btnOffset_Click);
            // 
            // ledAsserv
            // 
            this.ledAsserv.Etat = false;
            this.ledAsserv.Location = new System.Drawing.Point(84, 320);
            this.ledAsserv.Name = "ledAsserv";
            this.ledAsserv.Size = new System.Drawing.Size(16, 16);
            this.ledAsserv.TabIndex = 14;
            this.ledAsserv.TabStop = false;
            // 
            // boxAsservContinu
            // 
            this.boxAsservContinu.Location = new System.Drawing.Point(6, 215);
            this.boxAsservContinu.Name = "boxAsservContinu";
            this.boxAsservContinu.Size = new System.Drawing.Size(94, 72);
            this.boxAsservContinu.TabIndex = 13;
            this.boxAsservContinu.Text = "Arrêter d\'asservir une fois 1% d\'erreur atteint";
            this.boxAsservContinu.UseVisualStyleBackColor = true;
            this.boxAsservContinu.CheckedChanged += new System.EventHandler(this.boxAsservContinu_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "tours / s";
            // 
            // lblToursSecondesActuel
            // 
            this.lblToursSecondesActuel.AutoSize = true;
            this.lblToursSecondesActuel.Location = new System.Drawing.Point(20, 115);
            this.lblToursSecondesActuel.Name = "lblToursSecondesActuel";
            this.lblToursSecondesActuel.Size = new System.Drawing.Size(13, 13);
            this.lblToursSecondesActuel.TabIndex = 11;
            this.lblToursSecondesActuel.Text = "0";
            // 
            // lblConsigneAff
            // 
            this.lblConsigneAff.AutoSize = true;
            this.lblConsigneAff.Location = new System.Drawing.Point(62, 63);
            this.lblConsigneAff.Name = "lblConsigneAff";
            this.lblConsigneAff.Size = new System.Drawing.Size(171, 13);
            this.lblConsigneAff.TabIndex = 10;
            this.lblConsigneAff.Text = "Consigne vitesse (tours / seconde)";
            // 
            // lblConsigne
            // 
            this.lblConsigne.AutoSize = true;
            this.lblConsigne.Location = new System.Drawing.Point(20, 81);
            this.lblConsigne.Name = "lblConsigne";
            this.lblConsigne.Size = new System.Drawing.Size(13, 13);
            this.lblConsigne.TabIndex = 9;
            this.lblConsigne.Text = "0";
            // 
            // trackBarConsigne
            // 
            this.trackBarConsigne.BackColor = System.Drawing.Color.Transparent;
            this.trackBarConsigne.IntervalTimer = 500;
            this.trackBarConsigne.Location = new System.Drawing.Point(65, 79);
            this.trackBarConsigne.Max = 100D;
            this.trackBarConsigne.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarConsigne.Min = 0D;
            this.trackBarConsigne.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarConsigne.Name = "trackBarConsigne";
            this.trackBarConsigne.Reverse = false;
            this.trackBarConsigne.Size = new System.Drawing.Size(246, 15);
            this.trackBarConsigne.TabIndex = 8;
            this.trackBarConsigne.TickValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarConsigne_TickValueChanged);
            this.trackBarConsigne.ValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarConsigne_ValueChanged);
            // 
            // lblVitesseAff
            // 
            this.lblVitesseAff.AutoSize = true;
            this.lblVitesseAff.Location = new System.Drawing.Point(62, 21);
            this.lblVitesseAff.Name = "lblVitesseAff";
            this.lblVitesseAff.Size = new System.Drawing.Size(62, 13);
            this.lblVitesseAff.TabIndex = 7;
            this.lblVitesseAff.Text = "Valeur pwm";
            // 
            // boxAffichage
            // 
            this.boxAffichage.Location = new System.Drawing.Point(6, 152);
            this.boxAffichage.Name = "boxAffichage";
            this.boxAffichage.Size = new System.Drawing.Size(94, 31);
            this.boxAffichage.TabIndex = 5;
            this.boxAffichage.Text = "Afficher les données";
            this.boxAffichage.UseVisualStyleBackColor = true;
            // 
            // pictureBoxAngle
            // 
            this.pictureBoxAngle.Location = new System.Drawing.Point(106, 100);
            this.pictureBoxAngle.Name = "pictureBoxAngle";
            this.pictureBoxAngle.Size = new System.Drawing.Size(205, 379);
            this.pictureBoxAngle.TabIndex = 4;
            this.pictureBoxAngle.TabStop = false;
            // 
            // lblVitesse
            // 
            this.lblVitesse.AutoSize = true;
            this.lblVitesse.Location = new System.Drawing.Point(20, 39);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(13, 13);
            this.lblVitesse.TabIndex = 3;
            this.lblVitesse.Text = "0";
            // 
            // trackBarVitesse
            // 
            this.trackBarVitesse.BackColor = System.Drawing.Color.Transparent;
            this.trackBarVitesse.IntervalTimer = 500;
            this.trackBarVitesse.Location = new System.Drawing.Point(65, 37);
            this.trackBarVitesse.Max = 4000D;
            this.trackBarVitesse.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarVitesse.Min = 0D;
            this.trackBarVitesse.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarVitesse.Name = "trackBarVitesse";
            this.trackBarVitesse.Reverse = false;
            this.trackBarVitesse.Size = new System.Drawing.Size(246, 15);
            this.trackBarVitesse.TabIndex = 2;
            this.trackBarVitesse.TickValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarVitesse_TickValueChanged);
            this.trackBarVitesse.ValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarVitesse_ValueChanged);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(6, 419);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(6, 456);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // PanelBalise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBalise);
            this.Name = "PanelBalise";
            this.Size = new System.Drawing.Size(333, 493);
            this.groupBalise.ResumeLayout(false);
            this.groupBalise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledAsserv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAngle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBalise;
        private Composants.TrackBarPlus trackBarVitesse;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.PictureBox pictureBoxAngle;
        private System.Windows.Forms.CheckBox boxAffichage;
        private System.Windows.Forms.Label lblConsigneAff;
        private System.Windows.Forms.Label lblConsigne;
        private Composants.TrackBarPlus trackBarConsigne;
        private System.Windows.Forms.Label lblVitesseAff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblToursSecondesActuel;
        private System.Windows.Forms.CheckBox boxAsservContinu;
        private Composants.Led ledAsserv;
        private Composants.Led ledOffset;
        private System.Windows.Forms.Button btnOffset;
        private System.Windows.Forms.Button btnAsserv;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStop;
    }
}
