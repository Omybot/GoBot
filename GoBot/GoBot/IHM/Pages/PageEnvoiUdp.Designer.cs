﻿namespace GoBot.IHM.Pages
{
    partial class PageEnvoiUdp
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.boxCan = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numIntervalleTest = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSendTest = new System.Windows.Forms.Button();
            this.btnDebug9 = new System.Windows.Forms.Button();
            this.btnDebug8 = new System.Windows.Forms.Button();
            this.btnDebug7 = new System.Windows.Forms.Button();
            this.btnDebug6 = new System.Windows.Forms.Button();
            this.btnDebug5 = new System.Windows.Forms.Button();
            this.btnDebug4 = new System.Windows.Forms.Button();
            this.btnDebug3 = new System.Windows.Forms.Button();
            this.btnDebug2 = new System.Windows.Forms.Button();
            this.btnDebug1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDebug0 = new System.Windows.Forms.Button();
            this.boxIO = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrame = new Composants.TextBoxPlus();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblMonIP = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.RecMove = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.switchBoutonMove = new Composants.SwitchButton();
            this.switchBoutonIO = new Composants.SwitchButton();
            this._pnlConnections = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalleTest)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this._pnlConnections.SuspendLayout();
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.boxCan);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.btnDebug9);
            this.groupBox3.Controls.Add(this.btnDebug8);
            this.groupBox3.Controls.Add(this.btnDebug7);
            this.groupBox3.Controls.Add(this.btnDebug6);
            this.groupBox3.Controls.Add(this.btnDebug5);
            this.groupBox3.Controls.Add(this.btnDebug4);
            this.groupBox3.Controls.Add(this.btnDebug3);
            this.groupBox3.Controls.Add(this.btnDebug2);
            this.groupBox3.Controls.Add(this.btnDebug1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnDebug0);
            this.groupBox3.Controls.Add(this.boxIO);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnEnvoyer);
            this.groupBox3.Controls.Add(this.boxMove);
            this.groupBox3.Controls.Add(this.txtTrame);
            this.groupBox3.Location = new System.Drawing.Point(235, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(481, 224);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Envoi rapide trame";
            // 
            // boxCan
            // 
            this.boxCan.AutoSize = true;
            this.boxCan.Location = new System.Drawing.Point(172, 26);
            this.boxCan.Name = "boxCan";
            this.boxCan.Size = new System.Drawing.Size(65, 17);
            this.boxCan.TabIndex = 28;
            this.boxCan.Text = "RecCan";
            this.boxCan.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.numIntervalleTest);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.btnSendTest);
            this.groupBox6.Location = new System.Drawing.Point(17, 160);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(294, 52);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Envoi tests de connexion";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "ms";
            // 
            // numIntervalleTest
            // 
            this.numIntervalleTest.Location = new System.Drawing.Point(87, 22);
            this.numIntervalleTest.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numIntervalleTest.Name = "numIntervalleTest";
            this.numIntervalleTest.Size = new System.Drawing.Size(75, 20);
            this.numIntervalleTest.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Toutes les";
            // 
            // btnSendTest
            // 
            this.btnSendTest.Location = new System.Drawing.Point(203, 19);
            this.btnSendTest.Name = "btnSendTest";
            this.btnSendTest.Size = new System.Drawing.Size(75, 23);
            this.btnSendTest.TabIndex = 38;
            this.btnSendTest.Text = "Envoyer";
            this.btnSendTest.UseVisualStyleBackColor = true;
            this.btnSendTest.Click += new System.EventHandler(this.btnSendTest_Click);
            // 
            // btnDebug9
            // 
            this.btnDebug9.Location = new System.Drawing.Point(317, 112);
            this.btnDebug9.Name = "btnDebug9";
            this.btnDebug9.Size = new System.Drawing.Size(23, 23);
            this.btnDebug9.TabIndex = 26;
            this.btnDebug9.Tag = "9";
            this.btnDebug9.Text = "9";
            this.btnDebug9.UseVisualStyleBackColor = true;
            this.btnDebug9.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnDebug8
            // 
            this.btnDebug8.Location = new System.Drawing.Point(288, 112);
            this.btnDebug8.Name = "btnDebug8";
            this.btnDebug8.Size = new System.Drawing.Size(23, 23);
            this.btnDebug8.TabIndex = 25;
            this.btnDebug8.Tag = "8";
            this.btnDebug8.Text = "8";
            this.btnDebug8.UseVisualStyleBackColor = true;
            this.btnDebug8.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnDebug7
            // 
            this.btnDebug7.Location = new System.Drawing.Point(259, 112);
            this.btnDebug7.Name = "btnDebug7";
            this.btnDebug7.Size = new System.Drawing.Size(23, 23);
            this.btnDebug7.TabIndex = 24;
            this.btnDebug7.Tag = "7";
            this.btnDebug7.Text = "7";
            this.btnDebug7.UseVisualStyleBackColor = true;
            this.btnDebug7.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnDebug6
            // 
            this.btnDebug6.Location = new System.Drawing.Point(230, 112);
            this.btnDebug6.Name = "btnDebug6";
            this.btnDebug6.Size = new System.Drawing.Size(23, 23);
            this.btnDebug6.TabIndex = 23;
            this.btnDebug6.Tag = "6";
            this.btnDebug6.Text = "6";
            this.btnDebug6.UseVisualStyleBackColor = true;
            this.btnDebug6.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnDebug5
            // 
            this.btnDebug5.Location = new System.Drawing.Point(201, 112);
            this.btnDebug5.Name = "btnDebug5";
            this.btnDebug5.Size = new System.Drawing.Size(23, 23);
            this.btnDebug5.TabIndex = 22;
            this.btnDebug5.Tag = "5";
            this.btnDebug5.Text = "5";
            this.btnDebug5.UseVisualStyleBackColor = true;
            this.btnDebug5.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnDebug4
            // 
            this.btnDebug4.Location = new System.Drawing.Point(172, 112);
            this.btnDebug4.Name = "btnDebug4";
            this.btnDebug4.Size = new System.Drawing.Size(23, 23);
            this.btnDebug4.TabIndex = 21;
            this.btnDebug4.Tag = "4";
            this.btnDebug4.Text = "4";
            this.btnDebug4.UseVisualStyleBackColor = true;
            this.btnDebug4.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnDebug3
            // 
            this.btnDebug3.Location = new System.Drawing.Point(143, 112);
            this.btnDebug3.Name = "btnDebug3";
            this.btnDebug3.Size = new System.Drawing.Size(23, 23);
            this.btnDebug3.TabIndex = 20;
            this.btnDebug3.Tag = "3";
            this.btnDebug3.Text = "3";
            this.btnDebug3.UseVisualStyleBackColor = true;
            this.btnDebug3.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnDebug2
            // 
            this.btnDebug2.Location = new System.Drawing.Point(114, 112);
            this.btnDebug2.Name = "btnDebug2";
            this.btnDebug2.Size = new System.Drawing.Size(23, 23);
            this.btnDebug2.TabIndex = 19;
            this.btnDebug2.Tag = "2";
            this.btnDebug2.Text = "2";
            this.btnDebug2.UseVisualStyleBackColor = true;
            this.btnDebug2.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnDebug1
            // 
            this.btnDebug1.Location = new System.Drawing.Point(85, 112);
            this.btnDebug1.Name = "btnDebug1";
            this.btnDebug1.Size = new System.Drawing.Size(23, 23);
            this.btnDebug1.TabIndex = 18;
            this.btnDebug1.Tag = "1";
            this.btnDebug1.Text = "1";
            this.btnDebug1.UseVisualStyleBackColor = true;
            this.btnDebug1.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Debug";
            // 
            // btnDebug0
            // 
            this.btnDebug0.Location = new System.Drawing.Point(56, 112);
            this.btnDebug0.Name = "btnDebug0";
            this.btnDebug0.Size = new System.Drawing.Size(23, 23);
            this.btnDebug0.TabIndex = 16;
            this.btnDebug0.Tag = "0";
            this.btnDebug0.Text = "0";
            this.btnDebug0.UseVisualStyleBackColor = true;
            this.btnDebug0.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // boxIO
            // 
            this.boxIO.AutoSize = true;
            this.boxIO.Location = new System.Drawing.Point(97, 26);
            this.boxIO.Name = "boxIO";
            this.boxIO.Size = new System.Drawing.Size(57, 17);
            this.boxIO.TabIndex = 7;
            this.boxIO.Text = "RecIO";
            this.boxIO.UseVisualStyleBackColor = true;
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
            // RecMove
            // 
            this.RecMove.AutoSize = true;
            this.RecMove.Location = new System.Drawing.Point(42, 35);
            this.RecMove.Name = "RecMove";
            this.RecMove.Size = new System.Drawing.Size(54, 13);
            this.RecMove.TabIndex = 14;
            this.RecMove.Text = "RecMove";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(42, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "RecIO";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.switchBoutonMove);
            this.groupBox7.Controls.Add(this.switchBoutonIO);
            this.groupBox7.Controls.Add(this.RecMove);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Location = new System.Drawing.Point(235, 233);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 88);
            this.groupBox7.TabIndex = 29;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Activation connexions";
            // 
            // switchBoutonMove
            // 
            this.switchBoutonMove.AutoSize = true;
            this.switchBoutonMove.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonMove.Location = new System.Drawing.Point(119, 33);
            this.switchBoutonMove.MaximumSize = new System.Drawing.Size(35, 15);
            this.switchBoutonMove.MinimumSize = new System.Drawing.Size(35, 15);
            this.switchBoutonMove.Mirrored = true;
            this.switchBoutonMove.Name = "switchBoutonMove";
            this.switchBoutonMove.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonMove.TabIndex = 16;
            this.switchBoutonMove.Value = false;
            this.switchBoutonMove.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.switchBoutonConnexion_ValueChanged);
            // 
            // switchBoutonIO
            // 
            this.switchBoutonIO.AutoSize = true;
            this.switchBoutonIO.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonIO.Location = new System.Drawing.Point(119, 54);
            this.switchBoutonIO.MaximumSize = new System.Drawing.Size(35, 15);
            this.switchBoutonIO.MinimumSize = new System.Drawing.Size(35, 15);
            this.switchBoutonIO.Mirrored = true;
            this.switchBoutonIO.Name = "switchBoutonIO";
            this.switchBoutonIO.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonIO.TabIndex = 17;
            this.switchBoutonIO.Value = false;
            this.switchBoutonIO.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.switchBoutonConnexion_ValueChanged);
            // 
            // _pnlConnections
            // 
            this._pnlConnections.Controls.Add(this.groupBox4);
            this._pnlConnections.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._pnlConnections.Location = new System.Drawing.Point(17, 0);
            this._pnlConnections.Name = "_pnlConnections";
            this._pnlConnections.Size = new System.Drawing.Size(212, 596);
            this._pnlConnections.TabIndex = 30;
            // 
            // PageEnvoiUdp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._pnlConnections);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Name = "PageEnvoiUdp";
            this.Size = new System.Drawing.Size(916, 608);
            this.Load += new System.EventHandler(this.PanelEnvoiUdp_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalleTest)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this._pnlConnections.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnvoyer;
        private System.Windows.Forms.CheckBox boxMove;
        private Composants.TextBoxPlus txtTrame;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblMonIP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox boxIO;
        private System.Windows.Forms.Button btnDebug9;
        private System.Windows.Forms.Button btnDebug8;
        private System.Windows.Forms.Button btnDebug7;
        private System.Windows.Forms.Button btnDebug6;
        private System.Windows.Forms.Button btnDebug5;
        private System.Windows.Forms.Button btnDebug4;
        private System.Windows.Forms.Button btnDebug3;
        private System.Windows.Forms.Button btnDebug2;
        private System.Windows.Forms.Button btnDebug1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDebug0;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numIntervalleTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSendTest;
        private Composants.SwitchButton switchBoutonMove;
        private Composants.SwitchButton switchBoutonIO;
        private System.Windows.Forms.Label RecMove;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.FlowLayoutPanel _pnlConnections;
        private System.Windows.Forms.CheckBox boxCan;
    }
}
