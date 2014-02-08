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
            this.lblPwmBalise3 = new System.Windows.Forms.Label();
            this.lblPwmBalise2 = new System.Windows.Forms.Label();
            this.lblPwmBalise1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBalises = new System.Windows.Forms.Button();
            this.btnRecallage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBaliseNon = new System.Windows.Forms.RadioButton();
            this.radioBaliseOui = new System.Windows.Forms.RadioButton();
            this.pictureBoxBalises = new System.Windows.Forms.PictureBox();
            this.pictureBoxCouleur = new System.Windows.Forms.PictureBox();
            this.btnCouleurRouge = new System.Windows.Forms.Button();
            this.btnCouleurJaune = new System.Windows.Forms.Button();
            this.ledJackBranche = new Composants.Led();
            this.ledBalises = new Composants.Led();
            this.ledRecallage = new Composants.Led();
            this.ledJackArme = new Composants.Led();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBalises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecallage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackArme)).BeginInit();
            this.SuspendLayout();
            // 
            // btnArmerJack
            // 
            this.btnArmerJack.Location = new System.Drawing.Point(751, 417);
            this.btnArmerJack.Name = "btnArmerJack";
            this.btnArmerJack.Size = new System.Drawing.Size(91, 23);
            this.btnArmerJack.TabIndex = 39;
            this.btnArmerJack.Text = "Armer le jack";
            this.btnArmerJack.UseVisualStyleBackColor = true;
            this.btnArmerJack.Click += new System.EventHandler(this.btnArmerJack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(489, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Jack branché";
            // 
            // lblPwmBalise3
            // 
            this.lblPwmBalise3.AutoSize = true;
            this.lblPwmBalise3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwmBalise3.ForeColor = System.Drawing.Color.Red;
            this.lblPwmBalise3.Location = new System.Drawing.Point(614, 531);
            this.lblPwmBalise3.Name = "lblPwmBalise3";
            this.lblPwmBalise3.Size = new System.Drawing.Size(35, 13);
            this.lblPwmBalise3.TabIndex = 34;
            this.lblPwmBalise3.Text = "2354";
            this.lblPwmBalise3.Visible = false;
            // 
            // lblPwmBalise2
            // 
            this.lblPwmBalise2.AutoSize = true;
            this.lblPwmBalise2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPwmBalise2.Location = new System.Drawing.Point(614, 507);
            this.lblPwmBalise2.Name = "lblPwmBalise2";
            this.lblPwmBalise2.Size = new System.Drawing.Size(31, 13);
            this.lblPwmBalise2.TabIndex = 33;
            this.lblPwmBalise2.Text = "1654";
            this.lblPwmBalise2.Visible = false;
            // 
            // lblPwmBalise1
            // 
            this.lblPwmBalise1.AutoSize = true;
            this.lblPwmBalise1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPwmBalise1.Location = new System.Drawing.Point(614, 483);
            this.lblPwmBalise1.Name = "lblPwmBalise1";
            this.lblPwmBalise1.Size = new System.Drawing.Size(31, 13);
            this.lblPwmBalise1.TabIndex = 32;
            this.lblPwmBalise1.Text = "1500";
            this.lblPwmBalise1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "RecBoi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "RecBeu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "RecBun";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Pwm à 4 tours / seconde :";
            // 
            // btnBalises
            // 
            this.btnBalises.Location = new System.Drawing.Point(411, 446);
            this.btnBalises.Name = "btnBalises";
            this.btnBalises.Size = new System.Drawing.Size(227, 23);
            this.btnBalises.TabIndex = 27;
            this.btnBalises.Text = "Lancement des balises";
            this.btnBalises.UseVisualStyleBackColor = true;
            // 
            // btnRecallage
            // 
            this.btnRecallage.Location = new System.Drawing.Point(411, 417);
            this.btnRecallage.Name = "btnRecallage";
            this.btnRecallage.Size = new System.Drawing.Size(227, 23);
            this.btnRecallage.TabIndex = 26;
            this.btnRecallage.Text = "Recallage des robots";
            this.btnRecallage.UseVisualStyleBackColor = true;
            this.btnRecallage.Click += new System.EventHandler(this.btnRecallage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBaliseNon);
            this.groupBox1.Controls.Add(this.radioBaliseOui);
            this.groupBox1.Location = new System.Drawing.Point(411, 348);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 52);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balise réfléchissante sur nos robots ?";
            // 
            // radioBaliseNon
            // 
            this.radioBaliseNon.AutoSize = true;
            this.radioBaliseNon.Location = new System.Drawing.Point(116, 23);
            this.radioBaliseNon.Name = "radioBaliseNon";
            this.radioBaliseNon.Size = new System.Drawing.Size(45, 17);
            this.radioBaliseNon.TabIndex = 1;
            this.radioBaliseNon.Text = "Non";
            this.radioBaliseNon.UseVisualStyleBackColor = true;
            // 
            // radioBaliseOui
            // 
            this.radioBaliseOui.AutoSize = true;
            this.radioBaliseOui.Checked = true;
            this.radioBaliseOui.Location = new System.Drawing.Point(47, 23);
            this.radioBaliseOui.Name = "radioBaliseOui";
            this.radioBaliseOui.Size = new System.Drawing.Size(41, 17);
            this.radioBaliseOui.TabIndex = 0;
            this.radioBaliseOui.TabStop = true;
            this.radioBaliseOui.Text = "Oui";
            this.radioBaliseOui.UseVisualStyleBackColor = true;
            this.radioBaliseOui.CheckedChanged += new System.EventHandler(this.radioBaliseOui_CheckedChanged);
            // 
            // pictureBoxBalises
            // 
            this.pictureBoxBalises.Image = global::GoBot.Properties.Resources.TableRouge;
            this.pictureBoxBalises.Location = new System.Drawing.Point(411, 140);
            this.pictureBoxBalises.Name = "pictureBoxBalises";
            this.pictureBoxBalises.Size = new System.Drawing.Size(250, 167);
            this.pictureBoxBalises.TabIndex = 24;
            this.pictureBoxBalises.TabStop = false;
            // 
            // pictureBoxCouleur
            // 
            this.pictureBoxCouleur.Location = new System.Drawing.Point(411, 65);
            this.pictureBoxCouleur.Name = "pictureBoxCouleur";
            this.pictureBoxCouleur.Size = new System.Drawing.Size(250, 50);
            this.pictureBoxCouleur.TabIndex = 23;
            this.pictureBoxCouleur.TabStop = false;
            // 
            // btnCouleurRouge
            // 
            this.btnCouleurRouge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(32)))), ((int)(((byte)(25)))));
            this.btnCouleurRouge.ForeColor = System.Drawing.Color.White;
            this.btnCouleurRouge.Location = new System.Drawing.Point(667, 65);
            this.btnCouleurRouge.Name = "btnCouleurRouge";
            this.btnCouleurRouge.Size = new System.Drawing.Size(75, 50);
            this.btnCouleurRouge.TabIndex = 22;
            this.btnCouleurRouge.Text = "Rouge";
            this.btnCouleurRouge.UseVisualStyleBackColor = false;
            this.btnCouleurRouge.Click += new System.EventHandler(this.btnCouleurRouge_Click);
            // 
            // btnCouleurJaune
            // 
            this.btnCouleurJaune.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(201)))), ((int)(((byte)(0)))));
            this.btnCouleurJaune.ForeColor = System.Drawing.Color.Black;
            this.btnCouleurJaune.Location = new System.Drawing.Point(330, 65);
            this.btnCouleurJaune.Name = "btnCouleurJaune";
            this.btnCouleurJaune.Size = new System.Drawing.Size(75, 50);
            this.btnCouleurJaune.TabIndex = 21;
            this.btnCouleurJaune.Text = "Jaune";
            this.btnCouleurJaune.UseVisualStyleBackColor = false;
            this.btnCouleurJaune.Click += new System.EventHandler(this.btnCouleurJaune_Click);
            // 
            // ledJackBranche
            // 
            this.ledJackBranche.Etat = false;
            this.ledJackBranche.Image = ((System.Drawing.Image)(resources.GetObject("ledJackBranche.Image")));
            this.ledJackBranche.Location = new System.Drawing.Point(567, 321);
            this.ledJackBranche.Name = "ledJackBranche";
            this.ledJackBranche.Size = new System.Drawing.Size(16, 16);
            this.ledJackBranche.TabIndex = 38;
            this.ledJackBranche.TabStop = false;
            // 
            // ledBalises
            // 
            this.ledBalises.Etat = false;
            this.ledBalises.Image = ((System.Drawing.Image)(resources.GetObject("ledBalises.Image")));
            this.ledBalises.Location = new System.Drawing.Point(644, 453);
            this.ledBalises.Name = "ledBalises";
            this.ledBalises.Size = new System.Drawing.Size(16, 16);
            this.ledBalises.TabIndex = 36;
            this.ledBalises.TabStop = false;
            // 
            // ledRecallage
            // 
            this.ledRecallage.Etat = false;
            this.ledRecallage.Image = ((System.Drawing.Image)(resources.GetObject("ledRecallage.Image")));
            this.ledRecallage.Location = new System.Drawing.Point(644, 420);
            this.ledRecallage.Name = "ledRecallage";
            this.ledRecallage.Size = new System.Drawing.Size(16, 16);
            this.ledRecallage.TabIndex = 35;
            this.ledRecallage.TabStop = false;
            // 
            // ledJackArme
            // 
            this.ledJackArme.Etat = false;
            this.ledJackArme.Image = ((System.Drawing.Image)(resources.GetObject("ledJackArme.Image")));
            this.ledJackArme.Location = new System.Drawing.Point(848, 420);
            this.ledJackArme.Name = "ledJackArme";
            this.ledJackArme.Size = new System.Drawing.Size(16, 16);
            this.ledJackArme.TabIndex = 42;
            this.ledJackArme.TabStop = false;
            // 
            // PanelMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ledJackArme);
            this.Controls.Add(this.btnArmerJack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPwmBalise3);
            this.Controls.Add(this.lblPwmBalise2);
            this.Controls.Add(this.lblPwmBalise1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBalises);
            this.Controls.Add(this.btnRecallage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBoxBalises);
            this.Controls.Add(this.pictureBoxCouleur);
            this.Controls.Add(this.btnCouleurRouge);
            this.Controls.Add(this.btnCouleurJaune);
            this.Controls.Add(this.ledJackBranche);
            this.Controls.Add(this.ledBalises);
            this.Controls.Add(this.ledRecallage);
            this.Name = "PanelMatch";
            this.Size = new System.Drawing.Size(1273, 669);
            this.Load += new System.EventHandler(this.PanelMatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBalises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecallage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackArme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnArmerJack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPwmBalise3;
        private System.Windows.Forms.Label lblPwmBalise2;
        private System.Windows.Forms.Label lblPwmBalise1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBalises;
        private System.Windows.Forms.Button btnRecallage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBaliseNon;
        private System.Windows.Forms.RadioButton radioBaliseOui;
        private System.Windows.Forms.PictureBox pictureBoxBalises;
        private System.Windows.Forms.PictureBox pictureBoxCouleur;
        private System.Windows.Forms.Button btnCouleurRouge;
        private System.Windows.Forms.Button btnCouleurJaune;
        private Composants.Led ledJackBranche;
        private Composants.Led ledBalises;
        private Composants.Led ledRecallage;
        private Composants.Led ledJackArme;

    }
}
