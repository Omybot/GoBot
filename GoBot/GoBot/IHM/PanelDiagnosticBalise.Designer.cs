namespace GoBot.IHM
{
    partial class PanelDiagnosticBalise
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
            this.lblNbTrames = new System.Windows.Forms.Label();
            this.btnLancer = new System.Windows.Forms.Button();
            this.lblTauxPertes = new System.Windows.Forms.Label();
            this.lblStabiliteDistance = new System.Windows.Forms.Label();
            this.lblStabiliteAngle = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlGraphiqueTemps = new Composants.CtrlGraphique();
            this.ctrlGraphiqueDistance = new Composants.CtrlGraphique();
            this.ctrlGraphiqueAngle = new Composants.CtrlGraphique();
            this.label7 = new System.Windows.Forms.Label();
            this.numTauxPerte = new System.Windows.Forms.NumericUpDown();
            this.lblPourcent = new System.Windows.Forms.Label();
            this.boxAck = new System.Windows.Forms.CheckBox();
            this.groupBalise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTauxPerte)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBalise
            // 
            this.groupBalise.Controls.Add(this.boxAck);
            this.groupBalise.Controls.Add(this.lblPourcent);
            this.groupBalise.Controls.Add(this.numTauxPerte);
            this.groupBalise.Controls.Add(this.label7);
            this.groupBalise.Controls.Add(this.lblNbTrames);
            this.groupBalise.Controls.Add(this.btnLancer);
            this.groupBalise.Controls.Add(this.lblTauxPertes);
            this.groupBalise.Controls.Add(this.lblStabiliteDistance);
            this.groupBalise.Controls.Add(this.lblStabiliteAngle);
            this.groupBalise.Controls.Add(this.label6);
            this.groupBalise.Controls.Add(this.label5);
            this.groupBalise.Controls.Add(this.label4);
            this.groupBalise.Controls.Add(this.btnReset);
            this.groupBalise.Controls.Add(this.label3);
            this.groupBalise.Controls.Add(this.ctrlGraphiqueTemps);
            this.groupBalise.Controls.Add(this.label2);
            this.groupBalise.Controls.Add(this.ctrlGraphiqueDistance);
            this.groupBalise.Controls.Add(this.label1);
            this.groupBalise.Controls.Add(this.ctrlGraphiqueAngle);
            this.groupBalise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBalise.Location = new System.Drawing.Point(0, 0);
            this.groupBalise.Name = "groupBalise";
            this.groupBalise.Size = new System.Drawing.Size(398, 669);
            this.groupBalise.TabIndex = 0;
            this.groupBalise.TabStop = false;
            this.groupBalise.Text = "Balise";
            // 
            // lblNbTrames
            // 
            this.lblNbTrames.AutoSize = true;
            this.lblNbTrames.Location = new System.Drawing.Point(249, 398);
            this.lblNbTrames.Name = "lblNbTrames";
            this.lblNbTrames.Size = new System.Drawing.Size(63, 13);
            this.lblNbTrames.TabIndex = 14;
            this.lblNbTrames.Text = "0 messages";
            // 
            // btnLancer
            // 
            this.btnLancer.Location = new System.Drawing.Point(252, 424);
            this.btnLancer.Name = "btnLancer";
            this.btnLancer.Size = new System.Drawing.Size(60, 23);
            this.btnLancer.TabIndex = 13;
            this.btnLancer.Text = "Lancer";
            this.btnLancer.UseVisualStyleBackColor = true;
            this.btnLancer.Click += new System.EventHandler(this.btnLancer_Click);
            // 
            // lblTauxPertes
            // 
            this.lblTauxPertes.AutoSize = true;
            this.lblTauxPertes.Location = new System.Drawing.Point(150, 460);
            this.lblTauxPertes.Name = "lblTauxPertes";
            this.lblTauxPertes.Size = new System.Drawing.Size(10, 13);
            this.lblTauxPertes.TabIndex = 12;
            this.lblTauxPertes.Text = "-";
            // 
            // lblStabiliteDistance
            // 
            this.lblStabiliteDistance.AutoSize = true;
            this.lblStabiliteDistance.Location = new System.Drawing.Point(150, 429);
            this.lblStabiliteDistance.Name = "lblStabiliteDistance";
            this.lblStabiliteDistance.Size = new System.Drawing.Size(10, 13);
            this.lblStabiliteDistance.TabIndex = 11;
            this.lblStabiliteDistance.Text = "-";
            // 
            // lblStabiliteAngle
            // 
            this.lblStabiliteAngle.AutoSize = true;
            this.lblStabiliteAngle.Location = new System.Drawing.Point(150, 398);
            this.lblStabiliteAngle.Name = "lblStabiliteAngle";
            this.lblStabiliteAngle.Size = new System.Drawing.Size(10, 13);
            this.lblStabiliteAngle.TabIndex = 10;
            this.lblStabiliteAngle.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 460);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Taux de pertes :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stabilité distance :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stabilité angle :";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(252, 453);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(60, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Temps entre chaque message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mesure de la distance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mesure de l\'angle";
            // 
            // ctrlGraphiqueTemps
            // 
            this.ctrlGraphiqueTemps.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueTemps.EchelleCommune = true;
            this.ctrlGraphiqueTemps.Location = new System.Drawing.Point(14, 281);
            this.ctrlGraphiqueTemps.Name = "ctrlGraphiqueTemps";
            this.ctrlGraphiqueTemps.Size = new System.Drawing.Size(378, 100);
            this.ctrlGraphiqueTemps.TabIndex = 4;
            // 
            // ctrlGraphiqueDistance
            // 
            this.ctrlGraphiqueDistance.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueDistance.EchelleCommune = true;
            this.ctrlGraphiqueDistance.Location = new System.Drawing.Point(14, 160);
            this.ctrlGraphiqueDistance.Name = "ctrlGraphiqueDistance";
            this.ctrlGraphiqueDistance.Size = new System.Drawing.Size(378, 100);
            this.ctrlGraphiqueDistance.TabIndex = 2;
            // 
            // ctrlGraphiqueAngle
            // 
            this.ctrlGraphiqueAngle.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueAngle.EchelleCommune = true;
            this.ctrlGraphiqueAngle.Location = new System.Drawing.Point(14, 39);
            this.ctrlGraphiqueAngle.Name = "ctrlGraphiqueAngle";
            this.ctrlGraphiqueAngle.Size = new System.Drawing.Size(378, 100);
            this.ctrlGraphiqueAngle.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 509);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Simuler un taux de perte de";
            // 
            // numTauxPerte
            // 
            this.numTauxPerte.Location = new System.Drawing.Point(195, 507);
            this.numTauxPerte.Name = "numTauxPerte";
            this.numTauxPerte.Size = new System.Drawing.Size(41, 20);
            this.numTauxPerte.TabIndex = 16;
            // 
            // lblPourcent
            // 
            this.lblPourcent.AutoSize = true;
            this.lblPourcent.Location = new System.Drawing.Point(242, 509);
            this.lblPourcent.Name = "lblPourcent";
            this.lblPourcent.Size = new System.Drawing.Size(15, 13);
            this.lblPourcent.TabIndex = 17;
            this.lblPourcent.Text = "%";
            // 
            // boxAck
            // 
            this.boxAck.AutoSize = true;
            this.boxAck.Location = new System.Drawing.Point(56, 535);
            this.boxAck.Name = "boxAck";
            this.boxAck.Size = new System.Drawing.Size(134, 17);
            this.boxAck.TabIndex = 18;
            this.boxAck.Text = "Acquitter les messages";
            this.boxAck.UseVisualStyleBackColor = true;
            // 
            // PanelDiagnosticBalise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBalise);
            this.Name = "PanelDiagnosticBalise";
            this.Size = new System.Drawing.Size(398, 669);
            this.groupBalise.ResumeLayout(false);
            this.groupBalise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTauxPerte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBalise;
        private System.Windows.Forms.Label lblTauxPertes;
        private System.Windows.Forms.Label lblStabiliteDistance;
        private System.Windows.Forms.Label lblStabiliteAngle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label3;
        private Composants.CtrlGraphique ctrlGraphiqueTemps;
        private System.Windows.Forms.Label label2;
        private Composants.CtrlGraphique ctrlGraphiqueDistance;
        private System.Windows.Forms.Label label1;
        private Composants.CtrlGraphique ctrlGraphiqueAngle;
        private System.Windows.Forms.Button btnLancer;
        private System.Windows.Forms.Label lblNbTrames;
        private System.Windows.Forms.CheckBox boxAck;
        private System.Windows.Forms.Label lblPourcent;
        private System.Windows.Forms.NumericUpDown numTauxPerte;
        private System.Windows.Forms.Label label7;
    }
}
