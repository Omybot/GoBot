namespace GoBot.IHM
{
    partial class PanelServo
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
            this.lblID = new System.Windows.Forms.Label();
            this.numID = new System.Windows.Forms.NumericUpDown();
            this.lblPositionText = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.lblVitesseText = new System.Windows.Forms.Label();
            this.lblCouple = new System.Windows.Forms.Label();
            this.lblCoupleText = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblTemperatureText = new System.Windows.Forms.Label();
            this.lblTension = new System.Windows.Forms.Label();
            this.lblTensionText = new System.Windows.Forms.Label();
            this.lblErreurs = new System.Windows.Forms.Label();
            this.numBaudrate = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblBaudrate = new System.Windows.Forms.Label();
            this.groupServo = new System.Windows.Forms.GroupBox();
            this.lblLed = new System.Windows.Forms.Label();
            this.switchLed = new Composants.SwitchBouton();
            this.switchSurveillance = new Composants.SwitchBouton();
            this.lblSurveillance = new System.Windows.Forms.Label();
            this.numValeur = new System.Windows.Forms.NumericUpDown();
            this.btnSet = new System.Windows.Forms.Button();
            this.comboBoxFonctions = new System.Windows.Forms.ComboBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.ledConnect = new Composants.Led();
            this.ledErreur7 = new Composants.Led();
            this.ledErreur5 = new Composants.Led();
            this.ledErreur6 = new Composants.Led();
            this.ledErreur3 = new Composants.Led();
            this.ledErreur4 = new Composants.Led();
            this.ledErreur2 = new Composants.Led();
            this.btnAuto = new System.Windows.Forms.Button();
            this.trackBarPosition = new Composants.TrackBarPlus();
            this.ledErreur1 = new Composants.Led();
            this.trackBarVitesse = new Composants.TrackBarPlus();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBaudrate)).BeginInit();
            this.groupServo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValeur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(22, 26);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID :";
            // 
            // numID
            // 
            this.numID.Location = new System.Drawing.Point(49, 24);
            this.numID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numID.Name = "numID";
            this.numID.Size = new System.Drawing.Size(66, 20);
            this.numID.TabIndex = 4;
            // 
            // lblPositionText
            // 
            this.lblPositionText.AutoSize = true;
            this.lblPositionText.Location = new System.Drawing.Point(22, 94);
            this.lblPositionText.Name = "lblPositionText";
            this.lblPositionText.Size = new System.Drawing.Size(50, 13);
            this.lblPositionText.TabIndex = 7;
            this.lblPositionText.Text = "Position :";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(285, 94);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(19, 13);
            this.lblPosition.TabIndex = 8;
            this.lblPosition.Text = "12";
            // 
            // lblVitesse
            // 
            this.lblVitesse.AutoSize = true;
            this.lblVitesse.Location = new System.Drawing.Point(285, 115);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(19, 13);
            this.lblVitesse.TabIndex = 11;
            this.lblVitesse.Text = "12";
            // 
            // lblVitesseText
            // 
            this.lblVitesseText.AutoSize = true;
            this.lblVitesseText.Location = new System.Drawing.Point(22, 115);
            this.lblVitesseText.Name = "lblVitesseText";
            this.lblVitesseText.Size = new System.Drawing.Size(47, 13);
            this.lblVitesseText.TabIndex = 10;
            this.lblVitesseText.Text = "Vitesse :";
            // 
            // lblCouple
            // 
            this.lblCouple.AutoSize = true;
            this.lblCouple.Location = new System.Drawing.Point(83, 147);
            this.lblCouple.Name = "lblCouple";
            this.lblCouple.Size = new System.Drawing.Size(19, 13);
            this.lblCouple.TabIndex = 14;
            this.lblCouple.Text = "12";
            // 
            // lblCoupleText
            // 
            this.lblCoupleText.AutoSize = true;
            this.lblCoupleText.Location = new System.Drawing.Point(22, 147);
            this.lblCoupleText.Name = "lblCoupleText";
            this.lblCoupleText.Size = new System.Drawing.Size(46, 13);
            this.lblCoupleText.TabIndex = 13;
            this.lblCoupleText.Text = "Couple :";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(198, 147);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(23, 13);
            this.lblTemperature.TabIndex = 20;
            this.lblTemperature.Text = "12°";
            // 
            // lblTemperatureText
            // 
            this.lblTemperatureText.AutoSize = true;
            this.lblTemperatureText.Location = new System.Drawing.Point(119, 147);
            this.lblTemperatureText.Name = "lblTemperatureText";
            this.lblTemperatureText.Size = new System.Drawing.Size(73, 13);
            this.lblTemperatureText.TabIndex = 19;
            this.lblTemperatureText.Text = "Température :";
            // 
            // lblTension
            // 
            this.lblTension.AutoSize = true;
            this.lblTension.Location = new System.Drawing.Point(285, 147);
            this.lblTension.Name = "lblTension";
            this.lblTension.Size = new System.Drawing.Size(26, 13);
            this.lblTension.TabIndex = 23;
            this.lblTension.Text = "12V";
            // 
            // lblTensionText
            // 
            this.lblTensionText.AutoSize = true;
            this.lblTensionText.Location = new System.Drawing.Point(232, 147);
            this.lblTensionText.Name = "lblTensionText";
            this.lblTensionText.Size = new System.Drawing.Size(51, 13);
            this.lblTensionText.TabIndex = 22;
            this.lblTensionText.Text = "Tension :";
            // 
            // lblErreurs
            // 
            this.lblErreurs.AutoSize = true;
            this.lblErreurs.Location = new System.Drawing.Point(22, 172);
            this.lblErreurs.Name = "lblErreurs";
            this.lblErreurs.Size = new System.Drawing.Size(46, 13);
            this.lblErreurs.TabIndex = 24;
            this.lblErreurs.Text = "Erreurs :";
            // 
            // numBaudrate
            // 
            this.numBaudrate.Location = new System.Drawing.Point(184, 24);
            this.numBaudrate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numBaudrate.Name = "numBaudrate";
            this.numBaudrate.Size = new System.Drawing.Size(66, 20);
            this.numBaudrate.TabIndex = 31;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(252, 22);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(30, 23);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblBaudrate
            // 
            this.lblBaudrate.AutoSize = true;
            this.lblBaudrate.Location = new System.Drawing.Point(125, 26);
            this.lblBaudrate.Name = "lblBaudrate";
            this.lblBaudrate.Size = new System.Drawing.Size(56, 13);
            this.lblBaudrate.TabIndex = 27;
            this.lblBaudrate.Text = "Baudrate :";
            // 
            // groupServo
            // 
            this.groupServo.BackColor = System.Drawing.Color.Transparent;
            this.groupServo.Controls.Add(this.lblLed);
            this.groupServo.Controls.Add(this.switchLed);
            this.groupServo.Controls.Add(this.switchSurveillance);
            this.groupServo.Controls.Add(this.lblSurveillance);
            this.groupServo.Controls.Add(this.numValeur);
            this.groupServo.Controls.Add(this.btnSet);
            this.groupServo.Controls.Add(this.comboBoxFonctions);
            this.groupServo.Controls.Add(this.btnGet);
            this.groupServo.Controls.Add(this.ledConnect);
            this.groupServo.Controls.Add(this.ledErreur7);
            this.groupServo.Controls.Add(this.ledErreur5);
            this.groupServo.Controls.Add(this.ledErreur6);
            this.groupServo.Controls.Add(this.ledErreur3);
            this.groupServo.Controls.Add(this.ledErreur4);
            this.groupServo.Controls.Add(this.ledErreur2);
            this.groupServo.Controls.Add(this.btnAuto);
            this.groupServo.Controls.Add(this.numID);
            this.groupServo.Controls.Add(this.lblID);
            this.groupServo.Controls.Add(this.numBaudrate);
            this.groupServo.Controls.Add(this.btnOk);
            this.groupServo.Controls.Add(this.lblBaudrate);
            this.groupServo.Controls.Add(this.trackBarPosition);
            this.groupServo.Controls.Add(this.lblPositionText);
            this.groupServo.Controls.Add(this.ledErreur1);
            this.groupServo.Controls.Add(this.lblPosition);
            this.groupServo.Controls.Add(this.lblErreurs);
            this.groupServo.Controls.Add(this.trackBarVitesse);
            this.groupServo.Controls.Add(this.lblTension);
            this.groupServo.Controls.Add(this.lblVitesseText);
            this.groupServo.Controls.Add(this.lblTensionText);
            this.groupServo.Controls.Add(this.lblVitesse);
            this.groupServo.Controls.Add(this.lblTemperature);
            this.groupServo.Controls.Add(this.lblCoupleText);
            this.groupServo.Controls.Add(this.lblTemperatureText);
            this.groupServo.Controls.Add(this.lblCouple);
            this.groupServo.Location = new System.Drawing.Point(3, 3);
            this.groupServo.Name = "groupServo";
            this.groupServo.Size = new System.Drawing.Size(333, 244);
            this.groupServo.TabIndex = 33;
            this.groupServo.TabStop = false;
            this.groupServo.Text = "Servomoteur";
            // 
            // lblLed
            // 
            this.lblLed.AutoSize = true;
            this.lblLed.Location = new System.Drawing.Point(133, 58);
            this.lblLed.Name = "lblLed";
            this.lblLed.Size = new System.Drawing.Size(31, 13);
            this.lblLed.TabIndex = 53;
            this.lblLed.Text = "Led :";
            // 
            // switchLed
            // 
            this.switchLed.BackColor = System.Drawing.Color.Transparent;
            this.switchLed.Location = new System.Drawing.Point(170, 58);
            this.switchLed.Name = "switchLed";
            this.switchLed.Size = new System.Drawing.Size(35, 15);
            this.switchLed.Symetrique = false;
            this.switchLed.TabIndex = 52;
            this.switchLed.ChangementEtat += new System.EventHandler(this.switchLed_ChangementEtat);
            // 
            // switchSurveillance
            // 
            this.switchSurveillance.BackColor = System.Drawing.Color.Transparent;
            this.switchSurveillance.Location = new System.Drawing.Point(289, 58);
            this.switchSurveillance.Name = "switchSurveillance";
            this.switchSurveillance.Size = new System.Drawing.Size(35, 15);
            this.switchSurveillance.Symetrique = false;
            this.switchSurveillance.TabIndex = 51;
            // 
            // lblSurveillance
            // 
            this.lblSurveillance.AutoSize = true;
            this.lblSurveillance.Location = new System.Drawing.Point(212, 58);
            this.lblSurveillance.Name = "lblSurveillance";
            this.lblSurveillance.Size = new System.Drawing.Size(71, 13);
            this.lblSurveillance.TabIndex = 50;
            this.lblSurveillance.Text = "Surveillance :";
            // 
            // numValeur
            // 
            this.numValeur.Location = new System.Drawing.Point(234, 208);
            this.numValeur.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numValeur.Name = "numValeur";
            this.numValeur.Size = new System.Drawing.Size(91, 20);
            this.numValeur.TabIndex = 49;
            // 
            // btnSet
            // 
            this.btnSet.Image = global::GoBot.Properties.Resources.FlecheGauche;
            this.btnSet.Location = new System.Drawing.Point(178, 218);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(50, 15);
            this.btnSet.TabIndex = 48;
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // comboBoxFonctions
            // 
            this.comboBoxFonctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFonctions.FormattingEnabled = true;
            this.comboBoxFonctions.Items.AddRange(new object[] {
            "ID",
            "Baudrate",
            "Firmware",
            "Position minimum",
            "Position maximum",
            "Limite de température",
            "Limite de voltage minimum",
            "Limite de voltage maximum",
            "Couple maximum",
            "CW compliance margin",
            "CCW compliance margin",
            "CW compliance slope",
            "CCW compliance slope",
            "Punch"});
            this.comboBoxFonctions.Location = new System.Drawing.Point(11, 208);
            this.comboBoxFonctions.Name = "comboBoxFonctions";
            this.comboBoxFonctions.Size = new System.Drawing.Size(161, 21);
            this.comboBoxFonctions.TabIndex = 46;
            // 
            // btnGet
            // 
            this.btnGet.Image = global::GoBot.Properties.Resources.FlecheDroite;
            this.btnGet.Location = new System.Drawing.Point(178, 202);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(50, 15);
            this.btnGet.TabIndex = 45;
            this.btnGet.UseVisualStyleBackColor = true;
            // 
            // ledConnect
            // 
            this.ledConnect.Etat = false;
            this.ledConnect.Location = new System.Drawing.Point(27, 59);
            this.ledConnect.Name = "ledConnect";
            this.ledConnect.Size = new System.Drawing.Size(16, 16);
            this.ledConnect.TabIndex = 43;
            this.ledConnect.TabStop = false;
            // 
            // ledErreur7
            // 
            this.ledErreur7.Etat = false;
            this.ledErreur7.Location = new System.Drawing.Point(289, 172);
            this.ledErreur7.Name = "ledErreur7";
            this.ledErreur7.Size = new System.Drawing.Size(16, 16);
            this.ledErreur7.TabIndex = 42;
            this.ledErreur7.TabStop = false;
            // 
            // ledErreur5
            // 
            this.ledErreur5.Etat = false;
            this.ledErreur5.Location = new System.Drawing.Point(221, 172);
            this.ledErreur5.Name = "ledErreur5";
            this.ledErreur5.Size = new System.Drawing.Size(16, 16);
            this.ledErreur5.TabIndex = 41;
            this.ledErreur5.TabStop = false;
            // 
            // ledErreur6
            // 
            this.ledErreur6.Etat = false;
            this.ledErreur6.Location = new System.Drawing.Point(255, 172);
            this.ledErreur6.Name = "ledErreur6";
            this.ledErreur6.Size = new System.Drawing.Size(16, 16);
            this.ledErreur6.TabIndex = 39;
            this.ledErreur6.TabStop = false;
            // 
            // ledErreur3
            // 
            this.ledErreur3.Etat = false;
            this.ledErreur3.Location = new System.Drawing.Point(153, 172);
            this.ledErreur3.Name = "ledErreur3";
            this.ledErreur3.Size = new System.Drawing.Size(16, 16);
            this.ledErreur3.TabIndex = 38;
            this.ledErreur3.TabStop = false;
            // 
            // ledErreur4
            // 
            this.ledErreur4.Etat = false;
            this.ledErreur4.Location = new System.Drawing.Point(187, 172);
            this.ledErreur4.Name = "ledErreur4";
            this.ledErreur4.Size = new System.Drawing.Size(16, 16);
            this.ledErreur4.TabIndex = 37;
            this.ledErreur4.TabStop = false;
            // 
            // ledErreur2
            // 
            this.ledErreur2.Etat = false;
            this.ledErreur2.Location = new System.Drawing.Point(119, 172);
            this.ledErreur2.Name = "ledErreur2";
            this.ledErreur2.Size = new System.Drawing.Size(16, 16);
            this.ledErreur2.TabIndex = 36;
            this.ledErreur2.TabStop = false;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(283, 22);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(43, 23);
            this.btnAuto.TabIndex = 35;
            this.btnAuto.Text = "Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.BackColor = System.Drawing.Color.Transparent;
            this.trackBarPosition.IntervalTimer = 500;
            this.trackBarPosition.Location = new System.Drawing.Point(84, 94);
            this.trackBarPosition.Max = 1023D;
            this.trackBarPosition.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarPosition.Min = 0D;
            this.trackBarPosition.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Reverse = false;
            this.trackBarPosition.Size = new System.Drawing.Size(193, 15);
            this.trackBarPosition.TabIndex = 6;
            this.trackBarPosition.TickValueChanged += new System.EventHandler(this.trackBarPosition_TickValueChanged);
            this.trackBarPosition.ValueChanged += new System.EventHandler(this.trackBarPosition_ValueChanged);
            // 
            // ledErreur1
            // 
            this.ledErreur1.Etat = false;
            this.ledErreur1.Location = new System.Drawing.Point(85, 172);
            this.ledErreur1.Name = "ledErreur1";
            this.ledErreur1.Size = new System.Drawing.Size(16, 16);
            this.ledErreur1.TabIndex = 25;
            this.ledErreur1.TabStop = false;
            // 
            // trackBarVitesse
            // 
            this.trackBarVitesse.BackColor = System.Drawing.Color.Transparent;
            this.trackBarVitesse.IntervalTimer = 500;
            this.trackBarVitesse.Location = new System.Drawing.Point(84, 115);
            this.trackBarVitesse.Max = 1023D;
            this.trackBarVitesse.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarVitesse.Min = 0D;
            this.trackBarVitesse.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarVitesse.Name = "trackBarVitesse";
            this.trackBarVitesse.Reverse = false;
            this.trackBarVitesse.Size = new System.Drawing.Size(193, 15);
            this.trackBarVitesse.TabIndex = 9;
            this.trackBarVitesse.TickValueChanged += new System.EventHandler(this.trackBarVitesse_TickValueChanged);
            this.trackBarVitesse.ValueChanged += new System.EventHandler(this.trackBarVitesse_ValueChanged);
            // 
            // PanelServo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupServo);
            this.Name = "PanelServo";
            this.Size = new System.Drawing.Size(344, 255);
            this.Load += new System.EventHandler(this.PanelServo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBaudrate)).EndInit();
            this.groupServo.ResumeLayout(false);
            this.groupServo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValeur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreur1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.NumericUpDown numID;
        private Composants.TrackBarPlus trackBarPosition;
        private System.Windows.Forms.Label lblPositionText;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.Label lblVitesseText;
        private Composants.TrackBarPlus trackBarVitesse;
        private System.Windows.Forms.Label lblCouple;
        private System.Windows.Forms.Label lblCoupleText;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblTemperatureText;
        private System.Windows.Forms.Label lblTension;
        private System.Windows.Forms.Label lblTensionText;
        private System.Windows.Forms.Label lblErreurs;
        private Composants.Led ledErreur1;
        private System.Windows.Forms.NumericUpDown numBaudrate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblBaudrate;
        private System.Windows.Forms.GroupBox groupServo;
        private System.Windows.Forms.Button btnAuto;
        private Composants.Led ledErreur7;
        private Composants.Led ledErreur5;
        private Composants.Led ledErreur6;
        private Composants.Led ledErreur3;
        private Composants.Led ledErreur4;
        private Composants.Led ledErreur2;
        private Composants.Led ledConnect;
        private System.Windows.Forms.ComboBox comboBoxFonctions;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.NumericUpDown numValeur;
        private Composants.SwitchBouton switchSurveillance;
        private System.Windows.Forms.Label lblSurveillance;
        private System.Windows.Forms.Label lblLed;
        private Composants.SwitchBouton switchLed;
    }
}
