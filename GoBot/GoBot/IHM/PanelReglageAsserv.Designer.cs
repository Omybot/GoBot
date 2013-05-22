namespace GoBot.IHM
{
    partial class PanelReglageAsserv
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
            this.rdoGrosRobot = new System.Windows.Forms.RadioButton();
            this.rdoPetitRobot = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.numCoeffD = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numCoeffI = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numCoeffP = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numPasCodeurs = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numNbPoints = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTpsStabilisationDroite = new System.Windows.Forms.Label();
            this.lblTpsStabilisationGauche = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOvershootDroite = new System.Windows.Forms.Label();
            this.lblOvershootGauche = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ctrlGraphique1 = new GoBot.IHM.Composants.CtrlGraphique();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPasCodeurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNbPoints)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoGrosRobot
            // 
            this.rdoGrosRobot.AutoSize = true;
            this.rdoGrosRobot.Checked = true;
            this.rdoGrosRobot.Location = new System.Drawing.Point(50, 37);
            this.rdoGrosRobot.Name = "rdoGrosRobot";
            this.rdoGrosRobot.Size = new System.Drawing.Size(74, 17);
            this.rdoGrosRobot.TabIndex = 0;
            this.rdoGrosRobot.TabStop = true;
            this.rdoGrosRobot.Text = "Gros robot";
            this.rdoGrosRobot.UseVisualStyleBackColor = true;
            this.rdoGrosRobot.CheckedChanged += new System.EventHandler(this.rdoGrosRobot_CheckedChanged);
            // 
            // rdoPetitRobot
            // 
            this.rdoPetitRobot.AutoSize = true;
            this.rdoPetitRobot.Location = new System.Drawing.Point(130, 37);
            this.rdoPetitRobot.Name = "rdoPetitRobot";
            this.rdoPetitRobot.Size = new System.Drawing.Size(73, 17);
            this.rdoPetitRobot.TabIndex = 1;
            this.rdoPetitRobot.Text = "Petit robot";
            this.rdoPetitRobot.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(68, 244);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(53, 23);
            this.btnOk.TabIndex = 116;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // numCoeffD
            // 
            this.numCoeffD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoeffD.Location = new System.Drawing.Point(68, 128);
            this.numCoeffD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCoeffD.Name = "numCoeffD";
            this.numCoeffD.Size = new System.Drawing.Size(73, 20);
            this.numCoeffD.TabIndex = 115;
            this.numCoeffD.ValueChanged += new System.EventHandler(this.btnOk_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 114;
            this.label6.Text = "D";
            // 
            // numCoeffI
            // 
            this.numCoeffI.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoeffI.Location = new System.Drawing.Point(68, 102);
            this.numCoeffI.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCoeffI.Name = "numCoeffI";
            this.numCoeffI.Size = new System.Drawing.Size(73, 20);
            this.numCoeffI.TabIndex = 113;
            this.numCoeffI.ValueChanged += new System.EventHandler(this.btnOk_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 112;
            this.label5.Text = "I";
            // 
            // numCoeffP
            // 
            this.numCoeffP.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoeffP.Location = new System.Drawing.Point(68, 76);
            this.numCoeffP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCoeffP.Name = "numCoeffP";
            this.numCoeffP.Size = new System.Drawing.Size(73, 20);
            this.numCoeffP.TabIndex = 111;
            this.numCoeffP.ValueChanged += new System.EventHandler(this.btnOk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 110;
            this.label4.Text = "P";
            // 
            // numPasCodeurs
            // 
            this.numPasCodeurs.Location = new System.Drawing.Point(68, 177);
            this.numPasCodeurs.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPasCodeurs.Name = "numPasCodeurs";
            this.numPasCodeurs.Size = new System.Drawing.Size(73, 20);
            this.numPasCodeurs.TabIndex = 117;
            this.numPasCodeurs.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "Distance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 120;
            this.label2.Text = "Nb points";
            // 
            // numNbPoints
            // 
            this.numNbPoints.Location = new System.Drawing.Point(68, 203);
            this.numNbPoints.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numNbPoints.Name = "numNbPoints";
            this.numNbPoints.Size = new System.Drawing.Size(73, 20);
            this.numNbPoints.TabIndex = 119;
            this.numNbPoints.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTpsStabilisationDroite);
            this.groupBox1.Controls.Add(this.lblTpsStabilisationGauche);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(21, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 74);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stabilisation";
            // 
            // lblTpsStabilisationDroite
            // 
            this.lblTpsStabilisationDroite.AutoSize = true;
            this.lblTpsStabilisationDroite.Location = new System.Drawing.Point(74, 47);
            this.lblTpsStabilisationDroite.Name = "lblTpsStabilisationDroite";
            this.lblTpsStabilisationDroite.Size = new System.Drawing.Size(10, 13);
            this.lblTpsStabilisationDroite.TabIndex = 3;
            this.lblTpsStabilisationDroite.Text = "-";
            // 
            // lblTpsStabilisationGauche
            // 
            this.lblTpsStabilisationGauche.AutoSize = true;
            this.lblTpsStabilisationGauche.Location = new System.Drawing.Point(74, 24);
            this.lblTpsStabilisationGauche.Name = "lblTpsStabilisationGauche";
            this.lblTpsStabilisationGauche.Size = new System.Drawing.Size(10, 13);
            this.lblTpsStabilisationGauche.TabIndex = 2;
            this.lblTpsStabilisationGauche.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Droite :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gauche :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOvershootDroite);
            this.groupBox2.Controls.Add(this.lblOvershootGauche);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(21, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 74);
            this.groupBox2.TabIndex = 122;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Overshoot";
            // 
            // lblOvershootDroite
            // 
            this.lblOvershootDroite.AutoSize = true;
            this.lblOvershootDroite.Location = new System.Drawing.Point(74, 47);
            this.lblOvershootDroite.Name = "lblOvershootDroite";
            this.lblOvershootDroite.Size = new System.Drawing.Size(10, 13);
            this.lblOvershootDroite.TabIndex = 3;
            this.lblOvershootDroite.Text = "-";
            // 
            // lblOvershootGauche
            // 
            this.lblOvershootGauche.AutoSize = true;
            this.lblOvershootGauche.Location = new System.Drawing.Point(74, 24);
            this.lblOvershootGauche.Name = "lblOvershootGauche";
            this.lblOvershootGauche.Size = new System.Drawing.Size(10, 13);
            this.lblOvershootGauche.TabIndex = 2;
            this.lblOvershootGauche.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Droite :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Gauche :";
            // 
            // ctrlGraphique1
            // 
            this.ctrlGraphique1.BackColor = System.Drawing.Color.White;
            this.ctrlGraphique1.EchelleCommune = true;
            this.ctrlGraphique1.Location = new System.Drawing.Point(199, 64);
            this.ctrlGraphique1.Name = "ctrlGraphique1";
            this.ctrlGraphique1.Size = new System.Drawing.Size(773, 424);
            this.ctrlGraphique1.TabIndex = 123;
            // 
            // PanelReglageAsserv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlGraphique1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numNbPoints);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPasCodeurs);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.numCoeffD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numCoeffI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numCoeffP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdoPetitRobot);
            this.Controls.Add(this.rdoGrosRobot);
            this.Name = "PanelReglageAsserv";
            this.Size = new System.Drawing.Size(1003, 500);
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPasCodeurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNbPoints)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoGrosRobot;
        private System.Windows.Forms.RadioButton rdoPetitRobot;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown numCoeffD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numCoeffI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCoeffP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPasCodeurs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numNbPoints;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTpsStabilisationDroite;
        private System.Windows.Forms.Label lblTpsStabilisationGauche;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblOvershootDroite;
        private System.Windows.Forms.Label lblOvershootGauche;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Composants.CtrlGraphique ctrlGraphique1;
    }
}
