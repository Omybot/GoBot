namespace GoBot.IHM
{
    partial class PanelEnvoiUdp
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
            this.btnEnvoyer = new System.Windows.Forms.Button();
            this.boxMove = new System.Windows.Forms.CheckBox();
            this.boxMiwi = new System.Windows.Forms.CheckBox();
            this.txtTrame = new Composants.TextBoxPlus();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSortieRecMove = new System.Windows.Forms.Label();
            this.lblEntreeRecMove = new System.Windows.Forms.Label();
            this.lblIpRecMove = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSortieRecMiwi = new System.Windows.Forms.Label();
            this.lblEntreeRecMiwi = new System.Windows.Forms.Label();
            this.lblIpRecMiwi = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblMonIP = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnvoyer
            // 
            this.btnEnvoyer.Location = new System.Drawing.Point(335, 47);
            this.btnEnvoyer.Name = "btnEnvoyer";
            this.btnEnvoyer.Size = new System.Drawing.Size(75, 23);
            this.btnEnvoyer.TabIndex = 1;
            this.btnEnvoyer.Text = "Envoyer";
            this.btnEnvoyer.UseVisualStyleBackColor = true;
            this.btnEnvoyer.Click += new System.EventHandler(this.btnEnvoyer_Click);
            // 
            // boxMove
            // 
            this.boxMove.AutoSize = true;
            this.boxMove.Location = new System.Drawing.Point(16, 26);
            this.boxMove.Name = "boxMove";
            this.boxMove.Size = new System.Drawing.Size(73, 17);
            this.boxMove.TabIndex = 2;
            this.boxMove.Text = "RecMove";
            this.boxMove.UseVisualStyleBackColor = true;
            // 
            // boxMiwi
            // 
            this.boxMiwi.AutoSize = true;
            this.boxMiwi.Location = new System.Drawing.Point(95, 26);
            this.boxMiwi.Name = "boxMiwi";
            this.boxMiwi.Size = new System.Drawing.Size(67, 17);
            this.boxMiwi.TabIndex = 4;
            this.boxMiwi.Text = "RecMiwi";
            this.boxMiwi.UseVisualStyleBackColor = true;
            // 
            // txtTrame
            // 
            this.txtTrame.BackColor = System.Drawing.Color.White;
            this.txtTrame.DefaultText = "";
            this.txtTrame.ErrorMode = false;
            this.txtTrame.ForeColor = System.Drawing.Color.LightGray;
            this.txtTrame.Location = new System.Drawing.Point(16, 49);
            this.txtTrame.Name = "txtTrame";
            this.txtTrame.Size = new System.Drawing.Size(313, 20);
            this.txtTrame.TabIndex = 5;
            this.txtTrame.TextMode = Composants.TextBoxPlus.TextModeEnum.Text;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSortieRecMove);
            this.groupBox1.Controls.Add(this.lblEntreeRecMove);
            this.groupBox1.Controls.Add(this.lblIpRecMove);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 102);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RecMove";
            // 
            // lblSortieRecMove
            // 
            this.lblSortieRecMove.AutoSize = true;
            this.lblSortieRecMove.Location = new System.Drawing.Point(88, 73);
            this.lblSortieRecMove.Name = "lblSortieRecMove";
            this.lblSortieRecMove.Size = new System.Drawing.Size(10, 13);
            this.lblSortieRecMove.TabIndex = 13;
            this.lblSortieRecMove.Text = "-";
            // 
            // lblEntreeRecMove
            // 
            this.lblEntreeRecMove.AutoSize = true;
            this.lblEntreeRecMove.Location = new System.Drawing.Point(88, 49);
            this.lblEntreeRecMove.Name = "lblEntreeRecMove";
            this.lblEntreeRecMove.Size = new System.Drawing.Size(10, 13);
            this.lblEntreeRecMove.TabIndex = 12;
            this.lblEntreeRecMove.Text = "-";
            // 
            // lblIpRecMove
            // 
            this.lblIpRecMove.AutoSize = true;
            this.lblIpRecMove.Location = new System.Drawing.Point(88, 25);
            this.lblIpRecMove.Name = "lblIpRecMove";
            this.lblIpRecMove.Size = new System.Drawing.Size(10, 13);
            this.lblIpRecMove.TabIndex = 11;
            this.lblIpRecMove.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Port sortie :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port entrée :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP carte :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSortieRecMiwi);
            this.groupBox2.Controls.Add(this.lblEntreeRecMiwi);
            this.groupBox2.Controls.Add(this.lblIpRecMiwi);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(3, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 102);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RecMiwi";
            // 
            // lblSortieRecMiwi
            // 
            this.lblSortieRecMiwi.AutoSize = true;
            this.lblSortieRecMiwi.Location = new System.Drawing.Point(88, 73);
            this.lblSortieRecMiwi.Name = "lblSortieRecMiwi";
            this.lblSortieRecMiwi.Size = new System.Drawing.Size(10, 13);
            this.lblSortieRecMiwi.TabIndex = 13;
            this.lblSortieRecMiwi.Text = "-";
            // 
            // lblEntreeRecMiwi
            // 
            this.lblEntreeRecMiwi.AutoSize = true;
            this.lblEntreeRecMiwi.Location = new System.Drawing.Point(88, 49);
            this.lblEntreeRecMiwi.Name = "lblEntreeRecMiwi";
            this.lblEntreeRecMiwi.Size = new System.Drawing.Size(10, 13);
            this.lblEntreeRecMiwi.TabIndex = 12;
            this.lblEntreeRecMiwi.Text = "-";
            // 
            // lblIpRecMiwi
            // 
            this.lblIpRecMiwi.AutoSize = true;
            this.lblIpRecMiwi.Location = new System.Drawing.Point(88, 25);
            this.lblIpRecMiwi.Name = "lblIpRecMiwi";
            this.lblIpRecMiwi.Size = new System.Drawing.Size(10, 13);
            this.lblIpRecMiwi.TabIndex = 11;
            this.lblIpRecMiwi.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Port sortie :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Port entrée :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "IP carte :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnEnvoyer);
            this.groupBox3.Controls.Add(this.boxMove);
            this.groupBox3.Controls.Add(this.txtTrame);
            this.groupBox3.Controls.Add(this.boxMiwi);
            this.groupBox3.Location = new System.Drawing.Point(235, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 100);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Envoi rapide trame";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label4.Location = new System.Drawing.Point(38, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Forme : 01 23 45 67 89 AB CD EF";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblMonIP);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 56);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Moi";
            // 
            // lblMonIP
            // 
            this.lblMonIP.AutoSize = true;
            this.lblMonIP.Location = new System.Drawing.Point(88, 25);
            this.lblMonIP.Name = "lblMonIP";
            this.lblMonIP.Size = new System.Drawing.Size(10, 13);
            this.lblMonIP.TabIndex = 11;
            this.lblMonIP.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Mon IP :";
            // 
            // PanelEnvoiUdp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PanelEnvoiUdp";
            this.Size = new System.Drawing.Size(850, 509);
            this.Load += new System.EventHandler(this.PanelEnvoiUdp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnvoyer;
        private System.Windows.Forms.CheckBox boxMove;
        private System.Windows.Forms.CheckBox boxMiwi;
        private Composants.TextBoxPlus txtTrame;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSortieRecMove;
        private System.Windows.Forms.Label lblEntreeRecMove;
        private System.Windows.Forms.Label lblIpRecMove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSortieRecMiwi;
        private System.Windows.Forms.Label lblEntreeRecMiwi;
        private System.Windows.Forms.Label lblIpRecMiwi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblMonIP;
        private System.Windows.Forms.Label label13;
    }
}
