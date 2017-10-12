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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelServo));
            this.lblID = new System.Windows.Forms.Label();
            this.numID = new System.Windows.Forms.NumericUpDown();
            this.lblTxtPosition = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.lblTxtVitesse = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblTxtTemperature = new System.Windows.Forms.Label();
            this.lblTension = new System.Windows.Forms.Label();
            this.lblTxtTension = new System.Windows.Forms.Label();
            this.btnOkBaudrate = new System.Windows.Forms.Button();
            this.lblTxtBaudrate = new System.Windows.Forms.Label();
            this.groupServo = new System.Windows.Forms.GroupBox();
            this.numPunch = new System.Windows.Forms.NumericUpDown();
            this.btnOkPunch = new System.Windows.Forms.Button();
            this.lblTxtPunch = new System.Windows.Forms.Label();
            this.pictureBoxCompliance = new System.Windows.Forms.PictureBox();
            this.cboBaudrate = new System.Windows.Forms.ComboBox();
            this.btnChangeID = new System.Windows.Forms.Button();
            this.numCoupleLimite = new System.Windows.Forms.NumericUpDown();
            this.btnOkCoupleLimite = new System.Windows.Forms.Button();
            this.lblTxtCoupleLimite = new System.Windows.Forms.Label();
            this.numTempMax = new System.Windows.Forms.NumericUpDown();
            this.btnOkTempMax = new System.Windows.Forms.Button();
            this.lblTxtTempMax = new System.Windows.Forms.Label();
            this.numTensionMax = new System.Windows.Forms.NumericUpDown();
            this.btnOkTensionMax = new System.Windows.Forms.Button();
            this.lblTxtTensionMax = new System.Windows.Forms.Label();
            this.numTensionMin = new System.Windows.Forms.NumericUpDown();
            this.btnOkTensionMin = new System.Windows.Forms.Button();
            this.lblTxtTensionMin = new System.Windows.Forms.Label();
            this.ctrlGraphiqueCouple = new Composants.GraphPanel();
            this.lblCoupleActuel = new System.Windows.Forms.Label();
            this.lblTxtCoupleActuel = new System.Windows.Forms.Label();
            this.ctrlGraphiquePosition = new Composants.GraphPanel();
            this.ctrlGraphiqueVitesse = new Composants.GraphPanel();
            this.ctrlGraphiqueTemperature = new Composants.GraphPanel();
            this.pictureBoxAngles = new System.Windows.Forms.PictureBox();
            this.ledErreurInstruction = new Composants.Led();
            this.ledErreurOverload = new Composants.Led();
            this.ledErreurChecksum = new Composants.Led();
            this.ledErreurRange = new Composants.Led();
            this.ledErreurOverheating = new Composants.Led();
            this.ledErreurAngleLimit = new Composants.Led();
            this.ledErreurInputVoltage = new Composants.Led();
            this.boxShutdownInstruction = new System.Windows.Forms.CheckBox();
            this.boxLEDInstruction = new System.Windows.Forms.CheckBox();
            this.imgAlarmes = new System.Windows.Forms.PictureBox();
            this.numCWMargin = new System.Windows.Forms.NumericUpDown();
            this.btnOkCWMargin = new System.Windows.Forms.Button();
            this.lblTxtCWMargin = new System.Windows.Forms.Label();
            this.numCWSlope = new System.Windows.Forms.NumericUpDown();
            this.btnOkCWSlope = new System.Windows.Forms.Button();
            this.lblTxtCWSlope = new System.Windows.Forms.Label();
            this.numCCWMargin = new System.Windows.Forms.NumericUpDown();
            this.btnOkCCWMargin = new System.Windows.Forms.Button();
            this.lblTxtCCWMargin = new System.Windows.Forms.Label();
            this.numCCWSlope = new System.Windows.Forms.NumericUpDown();
            this.btnOkCCWSlope = new System.Windows.Forms.Button();
            this.lblTxtCCWSlope = new System.Windows.Forms.Label();
            this.lblVitesseActuelle = new System.Windows.Forms.Label();
            this.lblTxtVitesseActuelle = new System.Windows.Forms.Label();
            this.lblPositionActuelle = new System.Windows.Forms.Label();
            this.lblTxtPositionActuelle = new System.Windows.Forms.Label();
            this.lblTxtAlarmeShutdown = new System.Windows.Forms.Label();
            this.lblTxtAlarmeLED = new System.Windows.Forms.Label();
            this.boxShutdownOverload = new System.Windows.Forms.CheckBox();
            this.boxShutdownChecksum = new System.Windows.Forms.CheckBox();
            this.boxShutdownRange = new System.Windows.Forms.CheckBox();
            this.boxShutdownOverheating = new System.Windows.Forms.CheckBox();
            this.boxLEDInputVoltage = new System.Windows.Forms.CheckBox();
            this.boxLEDAngleLimit = new System.Windows.Forms.CheckBox();
            this.boxLEDOverload = new System.Windows.Forms.CheckBox();
            this.boxLEDChecksum = new System.Windows.Forms.CheckBox();
            this.boxLEDRange = new System.Windows.Forms.CheckBox();
            this.boxLEDOverheating = new System.Windows.Forms.CheckBox();
            this.boxShutdownAngleLimit = new System.Windows.Forms.CheckBox();
            this.boxShutdownInputVoltage = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTxtIntervalleMs = new System.Windows.Forms.Label();
            this.numIntervalle = new System.Windows.Forms.NumericUpDown();
            this.lblTxtIntervalle = new System.Windows.Forms.Label();
            this.ledCouple = new Composants.Led();
            this.ledLed = new Composants.Led();
            this.lblFirmware = new System.Windows.Forms.Label();
            this.lblTxtFirmware = new System.Windows.Forms.Label();
            this.lblModele = new System.Windows.Forms.Label();
            this.lblTxtModele = new System.Windows.Forms.Label();
            this.numPositionMax = new System.Windows.Forms.NumericUpDown();
            this.btnOkPositionMax = new System.Windows.Forms.Button();
            this.lblTxtPositionMax = new System.Windows.Forms.Label();
            this.numPositionMin = new System.Windows.Forms.NumericUpDown();
            this.btnOkPositionMin = new System.Windows.Forms.Button();
            this.lblTxtPositionMin = new System.Windows.Forms.Label();
            this.ledMouvement = new Composants.Led();
            this.lblTxtMouvement = new System.Windows.Forms.Label();
            this.switchCouple = new Composants.SwitchBouton();
            this.lblTxtCouple = new System.Windows.Forms.Label();
            this.numCouple = new System.Windows.Forms.NumericUpDown();
            this.btnOkCoupleMax = new System.Windows.Forms.Button();
            this.lblTxtCoupleMax = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblLed = new System.Windows.Forms.Label();
            this.switchLed = new Composants.SwitchBouton();
            this.switchSurveillance = new Composants.SwitchBouton();
            this.lblTxtSurveillance = new System.Windows.Forms.Label();
            this.trackBarPosition = new Composants.TrackBarPlus();
            this.trackBarVitesse = new Composants.TrackBarPlus();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).BeginInit();
            this.groupServo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompliance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoupleLimite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTensionMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTensionMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAngles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurInstruction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurOverload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurChecksum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurOverheating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurAngleLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurInputVoltage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAlarmes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCWMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCWSlope)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCCWMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCCWSlope)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledCouple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledLed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledMouvement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCouple)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(15, 34);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID :";
            // 
            // numID
            // 
            this.numID.Location = new System.Drawing.Point(42, 32);
            this.numID.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numID.Name = "numID";
            this.numID.Size = new System.Drawing.Size(66, 20);
            this.numID.TabIndex = 4;
            // 
            // lblTxtPosition
            // 
            this.lblTxtPosition.AutoSize = true;
            this.lblTxtPosition.Location = new System.Drawing.Point(70, 107);
            this.lblTxtPosition.Name = "lblTxtPosition";
            this.lblTxtPosition.Size = new System.Drawing.Size(44, 13);
            this.lblTxtPosition.TabIndex = 7;
            this.lblTxtPosition.Text = "Position";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(457, 107);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(13, 13);
            this.lblPosition.TabIndex = 8;
            this.lblPosition.Text = "0";
            // 
            // lblVitesse
            // 
            this.lblVitesse.AutoSize = true;
            this.lblVitesse.Location = new System.Drawing.Point(457, 128);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(13, 13);
            this.lblVitesse.TabIndex = 11;
            this.lblVitesse.Text = "0";
            // 
            // lblTxtVitesse
            // 
            this.lblTxtVitesse.AutoSize = true;
            this.lblTxtVitesse.Location = new System.Drawing.Point(70, 128);
            this.lblTxtVitesse.Name = "lblTxtVitesse";
            this.lblTxtVitesse.Size = new System.Drawing.Size(41, 13);
            this.lblTxtVitesse.TabIndex = 10;
            this.lblTxtVitesse.Text = "Vitesse";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(304, 243);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(10, 13);
            this.lblTemperature.TabIndex = 20;
            this.lblTemperature.Text = "-";
            // 
            // lblTxtTemperature
            // 
            this.lblTxtTemperature.AutoSize = true;
            this.lblTxtTemperature.Location = new System.Drawing.Point(217, 243);
            this.lblTxtTemperature.Name = "lblTxtTemperature";
            this.lblTxtTemperature.Size = new System.Drawing.Size(67, 13);
            this.lblTxtTemperature.TabIndex = 19;
            this.lblTxtTemperature.Text = "Température";
            // 
            // lblTension
            // 
            this.lblTension.AutoSize = true;
            this.lblTension.Location = new System.Drawing.Point(304, 265);
            this.lblTension.Name = "lblTension";
            this.lblTension.Size = new System.Drawing.Size(10, 13);
            this.lblTension.TabIndex = 23;
            this.lblTension.Text = "-";
            // 
            // lblTxtTension
            // 
            this.lblTxtTension.AutoSize = true;
            this.lblTxtTension.Location = new System.Drawing.Point(217, 265);
            this.lblTxtTension.Name = "lblTxtTension";
            this.lblTxtTension.Size = new System.Drawing.Size(45, 13);
            this.lblTxtTension.TabIndex = 22;
            this.lblTxtTension.Text = "Tension";
            // 
            // btnOkBaudrate
            // 
            this.btnOkBaudrate.Location = new System.Drawing.Point(173, 196);
            this.btnOkBaudrate.Name = "btnOkBaudrate";
            this.btnOkBaudrate.Size = new System.Drawing.Size(30, 23);
            this.btnOkBaudrate.TabIndex = 28;
            this.btnOkBaudrate.Text = "Ok";
            this.btnOkBaudrate.UseVisualStyleBackColor = true;
            this.btnOkBaudrate.Click += new System.EventHandler(this.btnOkBaudrate_Click);
            // 
            // lblTxtBaudrate
            // 
            this.lblTxtBaudrate.AutoSize = true;
            this.lblTxtBaudrate.Location = new System.Drawing.Point(15, 202);
            this.lblTxtBaudrate.Name = "lblTxtBaudrate";
            this.lblTxtBaudrate.Size = new System.Drawing.Size(50, 13);
            this.lblTxtBaudrate.TabIndex = 27;
            this.lblTxtBaudrate.Text = "Baudrate";
            // 
            // groupServo
            // 
            this.groupServo.BackColor = System.Drawing.Color.Transparent;
            this.groupServo.Controls.Add(this.numPunch);
            this.groupServo.Controls.Add(this.btnOkPunch);
            this.groupServo.Controls.Add(this.lblTxtPunch);
            this.groupServo.Controls.Add(this.pictureBoxCompliance);
            this.groupServo.Controls.Add(this.cboBaudrate);
            this.groupServo.Controls.Add(this.btnChangeID);
            this.groupServo.Controls.Add(this.numCoupleLimite);
            this.groupServo.Controls.Add(this.btnOkCoupleLimite);
            this.groupServo.Controls.Add(this.lblTxtCoupleLimite);
            this.groupServo.Controls.Add(this.numTempMax);
            this.groupServo.Controls.Add(this.btnOkTempMax);
            this.groupServo.Controls.Add(this.lblTxtTempMax);
            this.groupServo.Controls.Add(this.numTensionMax);
            this.groupServo.Controls.Add(this.btnOkTensionMax);
            this.groupServo.Controls.Add(this.lblTxtTensionMax);
            this.groupServo.Controls.Add(this.numTensionMin);
            this.groupServo.Controls.Add(this.btnOkTensionMin);
            this.groupServo.Controls.Add(this.lblTxtTensionMin);
            this.groupServo.Controls.Add(this.ctrlGraphiqueCouple);
            this.groupServo.Controls.Add(this.lblCoupleActuel);
            this.groupServo.Controls.Add(this.lblTxtCoupleActuel);
            this.groupServo.Controls.Add(this.ctrlGraphiquePosition);
            this.groupServo.Controls.Add(this.ctrlGraphiqueVitesse);
            this.groupServo.Controls.Add(this.ctrlGraphiqueTemperature);
            this.groupServo.Controls.Add(this.pictureBoxAngles);
            this.groupServo.Controls.Add(this.ledErreurInstruction);
            this.groupServo.Controls.Add(this.ledErreurOverload);
            this.groupServo.Controls.Add(this.ledErreurChecksum);
            this.groupServo.Controls.Add(this.ledErreurRange);
            this.groupServo.Controls.Add(this.ledErreurOverheating);
            this.groupServo.Controls.Add(this.ledErreurAngleLimit);
            this.groupServo.Controls.Add(this.ledErreurInputVoltage);
            this.groupServo.Controls.Add(this.boxShutdownInstruction);
            this.groupServo.Controls.Add(this.boxLEDInstruction);
            this.groupServo.Controls.Add(this.imgAlarmes);
            this.groupServo.Controls.Add(this.numCWMargin);
            this.groupServo.Controls.Add(this.btnOkCWMargin);
            this.groupServo.Controls.Add(this.lblTxtCWMargin);
            this.groupServo.Controls.Add(this.numCWSlope);
            this.groupServo.Controls.Add(this.btnOkCWSlope);
            this.groupServo.Controls.Add(this.lblTxtCWSlope);
            this.groupServo.Controls.Add(this.numCCWMargin);
            this.groupServo.Controls.Add(this.btnOkCCWMargin);
            this.groupServo.Controls.Add(this.lblTxtCCWMargin);
            this.groupServo.Controls.Add(this.numCCWSlope);
            this.groupServo.Controls.Add(this.btnOkCCWSlope);
            this.groupServo.Controls.Add(this.lblTxtCCWSlope);
            this.groupServo.Controls.Add(this.lblVitesseActuelle);
            this.groupServo.Controls.Add(this.lblTxtVitesseActuelle);
            this.groupServo.Controls.Add(this.lblPositionActuelle);
            this.groupServo.Controls.Add(this.lblTxtPositionActuelle);
            this.groupServo.Controls.Add(this.lblTxtAlarmeShutdown);
            this.groupServo.Controls.Add(this.lblTxtAlarmeLED);
            this.groupServo.Controls.Add(this.boxShutdownOverload);
            this.groupServo.Controls.Add(this.boxShutdownChecksum);
            this.groupServo.Controls.Add(this.boxShutdownRange);
            this.groupServo.Controls.Add(this.boxShutdownOverheating);
            this.groupServo.Controls.Add(this.boxLEDInputVoltage);
            this.groupServo.Controls.Add(this.boxLEDAngleLimit);
            this.groupServo.Controls.Add(this.boxLEDOverload);
            this.groupServo.Controls.Add(this.boxLEDChecksum);
            this.groupServo.Controls.Add(this.boxLEDRange);
            this.groupServo.Controls.Add(this.boxLEDOverheating);
            this.groupServo.Controls.Add(this.boxShutdownAngleLimit);
            this.groupServo.Controls.Add(this.boxShutdownInputVoltage);
            this.groupServo.Controls.Add(this.btnRefresh);
            this.groupServo.Controls.Add(this.lblTxtIntervalleMs);
            this.groupServo.Controls.Add(this.numIntervalle);
            this.groupServo.Controls.Add(this.lblTxtIntervalle);
            this.groupServo.Controls.Add(this.ledCouple);
            this.groupServo.Controls.Add(this.ledLed);
            this.groupServo.Controls.Add(this.lblFirmware);
            this.groupServo.Controls.Add(this.lblTxtFirmware);
            this.groupServo.Controls.Add(this.lblModele);
            this.groupServo.Controls.Add(this.lblTxtModele);
            this.groupServo.Controls.Add(this.numPositionMax);
            this.groupServo.Controls.Add(this.btnOkPositionMax);
            this.groupServo.Controls.Add(this.lblTxtPositionMax);
            this.groupServo.Controls.Add(this.numPositionMin);
            this.groupServo.Controls.Add(this.btnOkPositionMin);
            this.groupServo.Controls.Add(this.lblTxtPositionMin);
            this.groupServo.Controls.Add(this.ledMouvement);
            this.groupServo.Controls.Add(this.lblTxtMouvement);
            this.groupServo.Controls.Add(this.switchCouple);
            this.groupServo.Controls.Add(this.lblTxtCouple);
            this.groupServo.Controls.Add(this.numCouple);
            this.groupServo.Controls.Add(this.btnOkCoupleMax);
            this.groupServo.Controls.Add(this.lblTxtCoupleMax);
            this.groupServo.Controls.Add(this.btnReset);
            this.groupServo.Controls.Add(this.lblLed);
            this.groupServo.Controls.Add(this.switchLed);
            this.groupServo.Controls.Add(this.switchSurveillance);
            this.groupServo.Controls.Add(this.lblTxtSurveillance);
            this.groupServo.Controls.Add(this.numID);
            this.groupServo.Controls.Add(this.lblID);
            this.groupServo.Controls.Add(this.btnOkBaudrate);
            this.groupServo.Controls.Add(this.lblTxtBaudrate);
            this.groupServo.Controls.Add(this.trackBarPosition);
            this.groupServo.Controls.Add(this.lblTxtPosition);
            this.groupServo.Controls.Add(this.lblPosition);
            this.groupServo.Controls.Add(this.trackBarVitesse);
            this.groupServo.Controls.Add(this.lblTension);
            this.groupServo.Controls.Add(this.lblTxtVitesse);
            this.groupServo.Controls.Add(this.lblTxtTension);
            this.groupServo.Controls.Add(this.lblVitesse);
            this.groupServo.Controls.Add(this.lblTemperature);
            this.groupServo.Controls.Add(this.lblTxtTemperature);
            this.groupServo.Location = new System.Drawing.Point(3, 3);
            this.groupServo.Name = "groupServo";
            this.groupServo.Size = new System.Drawing.Size(1028, 514);
            this.groupServo.TabIndex = 33;
            this.groupServo.TabStop = false;
            this.groupServo.Text = "Servomoteur";
            // 
            // numPunch
            // 
            this.numPunch.Location = new System.Drawing.Point(456, 318);
            this.numPunch.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numPunch.Name = "numPunch";
            this.numPunch.Size = new System.Drawing.Size(66, 20);
            this.numPunch.TabIndex = 146;
            this.numPunch.Enter += new System.EventHandler(this.numPunch_Enter);
            this.numPunch.Leave += new System.EventHandler(this.numCompliance_Leave);
            // 
            // btnOkPunch
            // 
            this.btnOkPunch.Location = new System.Drawing.Point(528, 316);
            this.btnOkPunch.Name = "btnOkPunch";
            this.btnOkPunch.Size = new System.Drawing.Size(30, 23);
            this.btnOkPunch.TabIndex = 145;
            this.btnOkPunch.Text = "Ok";
            this.btnOkPunch.UseVisualStyleBackColor = true;
            this.btnOkPunch.Click += new System.EventHandler(this.btnOkPunch_Click);
            // 
            // lblTxtPunch
            // 
            this.lblTxtPunch.AutoSize = true;
            this.lblTxtPunch.Location = new System.Drawing.Point(370, 321);
            this.lblTxtPunch.Name = "lblTxtPunch";
            this.lblTxtPunch.Size = new System.Drawing.Size(38, 13);
            this.lblTxtPunch.TabIndex = 144;
            this.lblTxtPunch.Text = "Punch";
            // 
            // pictureBoxCompliance
            // 
            this.pictureBoxCompliance.Location = new System.Drawing.Point(564, 210);
            this.pictureBoxCompliance.Name = "pictureBoxCompliance";
            this.pictureBoxCompliance.Size = new System.Drawing.Size(218, 140);
            this.pictureBoxCompliance.TabIndex = 143;
            this.pictureBoxCompliance.TabStop = false;
            // 
            // cboBaudrate
            // 
            this.cboBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaudrate.FormattingEnabled = true;
            this.cboBaudrate.Location = new System.Drawing.Point(101, 195);
            this.cboBaudrate.Name = "cboBaudrate";
            this.cboBaudrate.Size = new System.Drawing.Size(66, 21);
            this.cboBaudrate.TabIndex = 142;
            // 
            // btnChangeID
            // 
            this.btnChangeID.Location = new System.Drawing.Point(33, 58);
            this.btnChangeID.Name = "btnChangeID";
            this.btnChangeID.Size = new System.Drawing.Size(75, 23);
            this.btnChangeID.TabIndex = 141;
            this.btnChangeID.Text = "Changer l\'ID";
            this.btnChangeID.UseVisualStyleBackColor = true;
            this.btnChangeID.Click += new System.EventHandler(this.btnChangeID_Click);
            // 
            // numCoupleLimite
            // 
            this.numCoupleLimite.Location = new System.Drawing.Point(101, 249);
            this.numCoupleLimite.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numCoupleLimite.Name = "numCoupleLimite";
            this.numCoupleLimite.Size = new System.Drawing.Size(66, 20);
            this.numCoupleLimite.TabIndex = 140;
            // 
            // btnOkCoupleLimite
            // 
            this.btnOkCoupleLimite.Location = new System.Drawing.Point(173, 247);
            this.btnOkCoupleLimite.Name = "btnOkCoupleLimite";
            this.btnOkCoupleLimite.Size = new System.Drawing.Size(30, 23);
            this.btnOkCoupleLimite.TabIndex = 139;
            this.btnOkCoupleLimite.Text = "Ok";
            this.btnOkCoupleLimite.UseVisualStyleBackColor = true;
            this.btnOkCoupleLimite.Click += new System.EventHandler(this.btnOkCoupleLimite_Click);
            // 
            // lblTxtCoupleLimite
            // 
            this.lblTxtCoupleLimite.AutoSize = true;
            this.lblTxtCoupleLimite.Location = new System.Drawing.Point(15, 252);
            this.lblTxtCoupleLimite.Name = "lblTxtCoupleLimite";
            this.lblTxtCoupleLimite.Size = new System.Drawing.Size(66, 13);
            this.lblTxtCoupleLimite.TabIndex = 138;
            this.lblTxtCoupleLimite.Text = "Couple limite";
            // 
            // numTempMax
            // 
            this.numTempMax.Location = new System.Drawing.Point(101, 483);
            this.numTempMax.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numTempMax.Name = "numTempMax";
            this.numTempMax.Size = new System.Drawing.Size(66, 20);
            this.numTempMax.TabIndex = 137;
            this.numTempMax.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnOkTempMax
            // 
            this.btnOkTempMax.Location = new System.Drawing.Point(173, 481);
            this.btnOkTempMax.Name = "btnOkTempMax";
            this.btnOkTempMax.Size = new System.Drawing.Size(30, 23);
            this.btnOkTempMax.TabIndex = 136;
            this.btnOkTempMax.Text = "Ok";
            this.btnOkTempMax.UseVisualStyleBackColor = true;
            this.btnOkTempMax.Click += new System.EventHandler(this.btnOkTempMax_Click);
            // 
            // lblTxtTempMax
            // 
            this.lblTxtTempMax.AutoSize = true;
            this.lblTxtTempMax.Location = new System.Drawing.Point(15, 486);
            this.lblTxtTempMax.Name = "lblTxtTempMax";
            this.lblTxtTempMax.Size = new System.Drawing.Size(59, 13);
            this.lblTxtTempMax.TabIndex = 135;
            this.lblTxtTempMax.Text = "Temp. max";
            // 
            // numTensionMax
            // 
            this.numTensionMax.DecimalPlaces = 1;
            this.numTensionMax.Location = new System.Drawing.Point(101, 457);
            this.numTensionMax.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numTensionMax.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTensionMax.Name = "numTensionMax";
            this.numTensionMax.Size = new System.Drawing.Size(66, 20);
            this.numTensionMax.TabIndex = 134;
            this.numTensionMax.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnOkTensionMax
            // 
            this.btnOkTensionMax.Location = new System.Drawing.Point(173, 455);
            this.btnOkTensionMax.Name = "btnOkTensionMax";
            this.btnOkTensionMax.Size = new System.Drawing.Size(30, 23);
            this.btnOkTensionMax.TabIndex = 133;
            this.btnOkTensionMax.Text = "Ok";
            this.btnOkTensionMax.UseVisualStyleBackColor = true;
            this.btnOkTensionMax.Click += new System.EventHandler(this.btnOkTensionMax_Click);
            // 
            // lblTxtTensionMax
            // 
            this.lblTxtTensionMax.AutoSize = true;
            this.lblTxtTensionMax.Location = new System.Drawing.Point(15, 460);
            this.lblTxtTensionMax.Name = "lblTxtTensionMax";
            this.lblTxtTensionMax.Size = new System.Drawing.Size(67, 13);
            this.lblTxtTensionMax.TabIndex = 132;
            this.lblTxtTensionMax.Text = "Tension max";
            // 
            // numTensionMin
            // 
            this.numTensionMin.DecimalPlaces = 1;
            this.numTensionMin.Location = new System.Drawing.Point(101, 431);
            this.numTensionMin.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numTensionMin.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTensionMin.Name = "numTensionMin";
            this.numTensionMin.Size = new System.Drawing.Size(66, 20);
            this.numTensionMin.TabIndex = 131;
            this.numTensionMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnOkTensionMin
            // 
            this.btnOkTensionMin.Location = new System.Drawing.Point(173, 429);
            this.btnOkTensionMin.Name = "btnOkTensionMin";
            this.btnOkTensionMin.Size = new System.Drawing.Size(30, 23);
            this.btnOkTensionMin.TabIndex = 130;
            this.btnOkTensionMin.Text = "Ok";
            this.btnOkTensionMin.UseVisualStyleBackColor = true;
            this.btnOkTensionMin.Click += new System.EventHandler(this.btnOkTensionMin_Click);
            // 
            // lblTxtTensionMin
            // 
            this.lblTxtTensionMin.AutoSize = true;
            this.lblTxtTensionMin.Location = new System.Drawing.Point(15, 434);
            this.lblTxtTensionMin.Name = "lblTxtTensionMin";
            this.lblTxtTensionMin.Size = new System.Drawing.Size(64, 13);
            this.lblTxtTensionMin.TabIndex = 129;
            this.lblTxtTensionMin.Text = "Tension min";
            // 
            // ctrlGraphiqueCouple
            // 
            this.ctrlGraphiqueCouple.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueCouple.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphiqueCouple.LimitsVisible = false;
            this.ctrlGraphiqueCouple.Location = new System.Drawing.Point(795, 363);
            this.ctrlGraphiqueCouple.MaxLimit = 1D;
            this.ctrlGraphiqueCouple.MinLimit = 0D;
            this.ctrlGraphiqueCouple.Name = "ctrlGraphiqueCouple";
            this.ctrlGraphiqueCouple.NamesVisible = false;
            this.ctrlGraphiqueCouple.Size = new System.Drawing.Size(218, 140);
            this.ctrlGraphiqueCouple.TabIndex = 128;
            // 
            // lblCoupleActuel
            // 
            this.lblCoupleActuel.AutoSize = true;
            this.lblCoupleActuel.Location = new System.Drawing.Point(304, 332);
            this.lblCoupleActuel.Name = "lblCoupleActuel";
            this.lblCoupleActuel.Size = new System.Drawing.Size(10, 13);
            this.lblCoupleActuel.TabIndex = 127;
            this.lblCoupleActuel.Text = "-";
            // 
            // lblTxtCoupleActuel
            // 
            this.lblTxtCoupleActuel.AutoSize = true;
            this.lblTxtCoupleActuel.Location = new System.Drawing.Point(217, 331);
            this.lblTxtCoupleActuel.Name = "lblTxtCoupleActuel";
            this.lblTxtCoupleActuel.Size = new System.Drawing.Size(72, 13);
            this.lblTxtCoupleActuel.TabIndex = 126;
            this.lblTxtCoupleActuel.Text = "Couple actuel";
            // 
            // ctrlGraphiquePosition
            // 
            this.ctrlGraphiquePosition.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiquePosition.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphiquePosition.LimitsVisible = false;
            this.ctrlGraphiquePosition.Location = new System.Drawing.Point(795, 210);
            this.ctrlGraphiquePosition.MaxLimit = 1D;
            this.ctrlGraphiquePosition.MinLimit = 0D;
            this.ctrlGraphiquePosition.Name = "ctrlGraphiquePosition";
            this.ctrlGraphiquePosition.NamesVisible = false;
            this.ctrlGraphiquePosition.Size = new System.Drawing.Size(218, 140);
            this.ctrlGraphiquePosition.TabIndex = 125;
            // 
            // ctrlGraphiqueVitesse
            // 
            this.ctrlGraphiqueVitesse.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueVitesse.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphiqueVitesse.LimitsVisible = false;
            this.ctrlGraphiqueVitesse.Location = new System.Drawing.Point(795, 57);
            this.ctrlGraphiqueVitesse.MaxLimit = 1D;
            this.ctrlGraphiqueVitesse.MinLimit = 0D;
            this.ctrlGraphiqueVitesse.Name = "ctrlGraphiqueVitesse";
            this.ctrlGraphiqueVitesse.NamesVisible = false;
            this.ctrlGraphiqueVitesse.Size = new System.Drawing.Size(218, 140);
            this.ctrlGraphiqueVitesse.TabIndex = 124;
            // 
            // ctrlGraphiqueTemperature
            // 
            this.ctrlGraphiqueTemperature.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueTemperature.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphiqueTemperature.LimitsVisible = false;
            this.ctrlGraphiqueTemperature.Location = new System.Drawing.Point(564, 363);
            this.ctrlGraphiqueTemperature.MaxLimit = 1D;
            this.ctrlGraphiqueTemperature.MinLimit = 0D;
            this.ctrlGraphiqueTemperature.Name = "ctrlGraphiqueTemperature";
            this.ctrlGraphiqueTemperature.NamesVisible = false;
            this.ctrlGraphiqueTemperature.Size = new System.Drawing.Size(218, 140);
            this.ctrlGraphiqueTemperature.TabIndex = 123;
            // 
            // pictureBoxAngles
            // 
            this.pictureBoxAngles.Image = global::GoBot.Properties.Resources.FondServo;
            this.pictureBoxAngles.Location = new System.Drawing.Point(585, 19);
            this.pictureBoxAngles.Name = "pictureBoxAngles";
            this.pictureBoxAngles.Size = new System.Drawing.Size(160, 160);
            this.pictureBoxAngles.TabIndex = 122;
            this.pictureBoxAngles.TabStop = false;
            // 
            // ledErreurInstruction
            // 
            this.ledErreurInstruction.BackColor = System.Drawing.Color.Transparent;
            this.ledErreurInstruction.Color = System.Drawing.Color.Empty;
            this.ledErreurInstruction.Image = ((System.Drawing.Image)(resources.GetObject("ledErreurInstruction.Image")));
            this.ledErreurInstruction.Location = new System.Drawing.Point(474, 445);
            this.ledErreurInstruction.Name = "ledErreurInstruction";
            this.ledErreurInstruction.Size = new System.Drawing.Size(16, 16);
            this.ledErreurInstruction.TabIndex = 121;
            this.ledErreurInstruction.TabStop = false;
            // 
            // ledErreurOverload
            // 
            this.ledErreurOverload.BackColor = System.Drawing.Color.Transparent;
            this.ledErreurOverload.Color = System.Drawing.Color.Empty;
            this.ledErreurOverload.Image = ((System.Drawing.Image)(resources.GetObject("ledErreurOverload.Image")));
            this.ledErreurOverload.Location = new System.Drawing.Point(447, 445);
            this.ledErreurOverload.Name = "ledErreurOverload";
            this.ledErreurOverload.Size = new System.Drawing.Size(16, 16);
            this.ledErreurOverload.TabIndex = 120;
            this.ledErreurOverload.TabStop = false;
            // 
            // ledErreurChecksum
            // 
            this.ledErreurChecksum.BackColor = System.Drawing.Color.Transparent;
            this.ledErreurChecksum.Color = System.Drawing.Color.Empty;
            this.ledErreurChecksum.Image = ((System.Drawing.Image)(resources.GetObject("ledErreurChecksum.Image")));
            this.ledErreurChecksum.Location = new System.Drawing.Point(420, 445);
            this.ledErreurChecksum.Name = "ledErreurChecksum";
            this.ledErreurChecksum.Size = new System.Drawing.Size(16, 16);
            this.ledErreurChecksum.TabIndex = 119;
            this.ledErreurChecksum.TabStop = false;
            // 
            // ledErreurRange
            // 
            this.ledErreurRange.BackColor = System.Drawing.Color.Transparent;
            this.ledErreurRange.Color = System.Drawing.Color.Empty;
            this.ledErreurRange.Image = ((System.Drawing.Image)(resources.GetObject("ledErreurRange.Image")));
            this.ledErreurRange.Location = new System.Drawing.Point(393, 445);
            this.ledErreurRange.Name = "ledErreurRange";
            this.ledErreurRange.Size = new System.Drawing.Size(16, 16);
            this.ledErreurRange.TabIndex = 118;
            this.ledErreurRange.TabStop = false;
            // 
            // ledErreurOverheating
            // 
            this.ledErreurOverheating.BackColor = System.Drawing.Color.Transparent;
            this.ledErreurOverheating.Color = System.Drawing.Color.Empty;
            this.ledErreurOverheating.Image = ((System.Drawing.Image)(resources.GetObject("ledErreurOverheating.Image")));
            this.ledErreurOverheating.Location = new System.Drawing.Point(366, 445);
            this.ledErreurOverheating.Name = "ledErreurOverheating";
            this.ledErreurOverheating.Size = new System.Drawing.Size(16, 16);
            this.ledErreurOverheating.TabIndex = 117;
            this.ledErreurOverheating.TabStop = false;
            // 
            // ledErreurAngleLimit
            // 
            this.ledErreurAngleLimit.BackColor = System.Drawing.Color.Transparent;
            this.ledErreurAngleLimit.Color = System.Drawing.Color.Empty;
            this.ledErreurAngleLimit.Image = ((System.Drawing.Image)(resources.GetObject("ledErreurAngleLimit.Image")));
            this.ledErreurAngleLimit.Location = new System.Drawing.Point(339, 445);
            this.ledErreurAngleLimit.Name = "ledErreurAngleLimit";
            this.ledErreurAngleLimit.Size = new System.Drawing.Size(16, 16);
            this.ledErreurAngleLimit.TabIndex = 116;
            this.ledErreurAngleLimit.TabStop = false;
            // 
            // ledErreurInputVoltage
            // 
            this.ledErreurInputVoltage.BackColor = System.Drawing.Color.Transparent;
            this.ledErreurInputVoltage.Color = System.Drawing.Color.Empty;
            this.ledErreurInputVoltage.Image = ((System.Drawing.Image)(resources.GetObject("ledErreurInputVoltage.Image")));
            this.ledErreurInputVoltage.Location = new System.Drawing.Point(312, 445);
            this.ledErreurInputVoltage.Name = "ledErreurInputVoltage";
            this.ledErreurInputVoltage.Size = new System.Drawing.Size(16, 16);
            this.ledErreurInputVoltage.TabIndex = 115;
            this.ledErreurInputVoltage.TabStop = false;
            // 
            // boxShutdownInstruction
            // 
            this.boxShutdownInstruction.AutoSize = true;
            this.boxShutdownInstruction.Location = new System.Drawing.Point(475, 486);
            this.boxShutdownInstruction.Name = "boxShutdownInstruction";
            this.boxShutdownInstruction.Size = new System.Drawing.Size(15, 14);
            this.boxShutdownInstruction.TabIndex = 113;
            this.boxShutdownInstruction.UseVisualStyleBackColor = true;
            this.boxShutdownInstruction.CheckedChanged += new System.EventHandler(this.boxShutdownInstruction_CheckedChanged);
            // 
            // boxLEDInstruction
            // 
            this.boxLEDInstruction.AutoSize = true;
            this.boxLEDInstruction.Location = new System.Drawing.Point(475, 466);
            this.boxLEDInstruction.Name = "boxLEDInstruction";
            this.boxLEDInstruction.Size = new System.Drawing.Size(15, 14);
            this.boxLEDInstruction.TabIndex = 112;
            this.boxLEDInstruction.UseVisualStyleBackColor = true;
            this.boxLEDInstruction.CheckedChanged += new System.EventHandler(this.boxLEDInstruction_CheckedChanged);
            // 
            // imgAlarmes
            // 
            this.imgAlarmes.Image = global::GoBot.Properties.Resources.Alertes;
            this.imgAlarmes.Location = new System.Drawing.Point(314, 391);
            this.imgAlarmes.Name = "imgAlarmes";
            this.imgAlarmes.Size = new System.Drawing.Size(218, 50);
            this.imgAlarmes.TabIndex = 111;
            this.imgAlarmes.TabStop = false;
            // 
            // numCWMargin
            // 
            this.numCWMargin.Location = new System.Drawing.Point(456, 265);
            this.numCWMargin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numCWMargin.Name = "numCWMargin";
            this.numCWMargin.Size = new System.Drawing.Size(66, 20);
            this.numCWMargin.TabIndex = 110;
            this.numCWMargin.Enter += new System.EventHandler(this.numCWMargin_Enter);
            this.numCWMargin.Leave += new System.EventHandler(this.numCompliance_Leave);
            // 
            // btnOkCWMargin
            // 
            this.btnOkCWMargin.Location = new System.Drawing.Point(528, 263);
            this.btnOkCWMargin.Name = "btnOkCWMargin";
            this.btnOkCWMargin.Size = new System.Drawing.Size(30, 23);
            this.btnOkCWMargin.TabIndex = 109;
            this.btnOkCWMargin.Text = "Ok";
            this.btnOkCWMargin.UseVisualStyleBackColor = true;
            this.btnOkCWMargin.Click += new System.EventHandler(this.btnOkCWMargin_Click);
            // 
            // lblTxtCWMargin
            // 
            this.lblTxtCWMargin.AutoSize = true;
            this.lblTxtCWMargin.Location = new System.Drawing.Point(370, 268);
            this.lblTxtCWMargin.Name = "lblTxtCWMargin";
            this.lblTxtCWMargin.Size = new System.Drawing.Size(60, 13);
            this.lblTxtCWMargin.TabIndex = 108;
            this.lblTxtCWMargin.Text = "CW Margin";
            // 
            // numCWSlope
            // 
            this.numCWSlope.Location = new System.Drawing.Point(456, 291);
            this.numCWSlope.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numCWSlope.Name = "numCWSlope";
            this.numCWSlope.Size = new System.Drawing.Size(66, 20);
            this.numCWSlope.TabIndex = 107;
            this.numCWSlope.Enter += new System.EventHandler(this.numCWSlope_Enter);
            this.numCWSlope.Leave += new System.EventHandler(this.numCompliance_Leave);
            // 
            // btnOkCWSlope
            // 
            this.btnOkCWSlope.Location = new System.Drawing.Point(528, 289);
            this.btnOkCWSlope.Name = "btnOkCWSlope";
            this.btnOkCWSlope.Size = new System.Drawing.Size(30, 23);
            this.btnOkCWSlope.TabIndex = 106;
            this.btnOkCWSlope.Text = "Ok";
            this.btnOkCWSlope.UseVisualStyleBackColor = true;
            this.btnOkCWSlope.Click += new System.EventHandler(this.btnOkCWSlope_Click);
            // 
            // lblTxtCWSlope
            // 
            this.lblTxtCWSlope.AutoSize = true;
            this.lblTxtCWSlope.Location = new System.Drawing.Point(370, 294);
            this.lblTxtCWSlope.Name = "lblTxtCWSlope";
            this.lblTxtCWSlope.Size = new System.Drawing.Size(55, 13);
            this.lblTxtCWSlope.TabIndex = 105;
            this.lblTxtCWSlope.Text = "CW Slope";
            // 
            // numCCWMargin
            // 
            this.numCCWMargin.Location = new System.Drawing.Point(456, 239);
            this.numCCWMargin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numCCWMargin.Name = "numCCWMargin";
            this.numCCWMargin.Size = new System.Drawing.Size(66, 20);
            this.numCCWMargin.TabIndex = 104;
            this.numCCWMargin.Enter += new System.EventHandler(this.numCCWMargin_Enter);
            this.numCCWMargin.Leave += new System.EventHandler(this.numCompliance_Leave);
            // 
            // btnOkCCWMargin
            // 
            this.btnOkCCWMargin.Location = new System.Drawing.Point(528, 237);
            this.btnOkCCWMargin.Name = "btnOkCCWMargin";
            this.btnOkCCWMargin.Size = new System.Drawing.Size(30, 23);
            this.btnOkCCWMargin.TabIndex = 103;
            this.btnOkCCWMargin.Text = "Ok";
            this.btnOkCCWMargin.UseVisualStyleBackColor = true;
            this.btnOkCCWMargin.Click += new System.EventHandler(this.btnOkCCWMargin_Click);
            // 
            // lblTxtCCWMargin
            // 
            this.lblTxtCCWMargin.AutoSize = true;
            this.lblTxtCCWMargin.Location = new System.Drawing.Point(370, 242);
            this.lblTxtCCWMargin.Name = "lblTxtCCWMargin";
            this.lblTxtCCWMargin.Size = new System.Drawing.Size(67, 13);
            this.lblTxtCCWMargin.TabIndex = 102;
            this.lblTxtCCWMargin.Text = "CCW Margin";
            // 
            // numCCWSlope
            // 
            this.numCCWSlope.Location = new System.Drawing.Point(456, 212);
            this.numCCWSlope.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numCCWSlope.Name = "numCCWSlope";
            this.numCCWSlope.Size = new System.Drawing.Size(66, 20);
            this.numCCWSlope.TabIndex = 101;
            this.numCCWSlope.Enter += new System.EventHandler(this.numCCWSlope_Enter);
            this.numCCWSlope.Leave += new System.EventHandler(this.numCompliance_Leave);
            // 
            // btnOkCCWSlope
            // 
            this.btnOkCCWSlope.Location = new System.Drawing.Point(528, 211);
            this.btnOkCCWSlope.Name = "btnOkCCWSlope";
            this.btnOkCCWSlope.Size = new System.Drawing.Size(30, 23);
            this.btnOkCCWSlope.TabIndex = 100;
            this.btnOkCCWSlope.Text = "Ok";
            this.btnOkCCWSlope.UseVisualStyleBackColor = true;
            this.btnOkCCWSlope.Click += new System.EventHandler(this.btnOkCCWSlope_Click);
            // 
            // lblTxtCCWSlope
            // 
            this.lblTxtCCWSlope.AutoSize = true;
            this.lblTxtCCWSlope.Location = new System.Drawing.Point(370, 216);
            this.lblTxtCCWSlope.Name = "lblTxtCCWSlope";
            this.lblTxtCCWSlope.Size = new System.Drawing.Size(62, 13);
            this.lblTxtCCWSlope.TabIndex = 99;
            this.lblTxtCCWSlope.Text = "CCW Slope";
            // 
            // lblVitesseActuelle
            // 
            this.lblVitesseActuelle.AutoSize = true;
            this.lblVitesseActuelle.Location = new System.Drawing.Point(304, 310);
            this.lblVitesseActuelle.Name = "lblVitesseActuelle";
            this.lblVitesseActuelle.Size = new System.Drawing.Size(10, 13);
            this.lblVitesseActuelle.TabIndex = 98;
            this.lblVitesseActuelle.Text = "-";
            // 
            // lblTxtVitesseActuelle
            // 
            this.lblTxtVitesseActuelle.AutoSize = true;
            this.lblTxtVitesseActuelle.Location = new System.Drawing.Point(217, 309);
            this.lblTxtVitesseActuelle.Name = "lblTxtVitesseActuelle";
            this.lblTxtVitesseActuelle.Size = new System.Drawing.Size(81, 13);
            this.lblTxtVitesseActuelle.TabIndex = 97;
            this.lblTxtVitesseActuelle.Text = "Vitesse actuelle";
            // 
            // lblPositionActuelle
            // 
            this.lblPositionActuelle.AutoSize = true;
            this.lblPositionActuelle.Location = new System.Drawing.Point(304, 287);
            this.lblPositionActuelle.Name = "lblPositionActuelle";
            this.lblPositionActuelle.Size = new System.Drawing.Size(10, 13);
            this.lblPositionActuelle.TabIndex = 96;
            this.lblPositionActuelle.Text = "-";
            // 
            // lblTxtPositionActuelle
            // 
            this.lblTxtPositionActuelle.AutoSize = true;
            this.lblTxtPositionActuelle.Location = new System.Drawing.Point(217, 287);
            this.lblTxtPositionActuelle.Name = "lblTxtPositionActuelle";
            this.lblTxtPositionActuelle.Size = new System.Drawing.Size(84, 13);
            this.lblTxtPositionActuelle.TabIndex = 95;
            this.lblTxtPositionActuelle.Text = "Position actuelle";
            // 
            // lblTxtAlarmeShutdown
            // 
            this.lblTxtAlarmeShutdown.AutoSize = true;
            this.lblTxtAlarmeShutdown.Location = new System.Drawing.Point(217, 486);
            this.lblTxtAlarmeShutdown.Name = "lblTxtAlarmeShutdown";
            this.lblTxtAlarmeShutdown.Size = new System.Drawing.Size(88, 13);
            this.lblTxtAlarmeShutdown.TabIndex = 94;
            this.lblTxtAlarmeShutdown.Text = "Alarme shutdown";
            // 
            // lblTxtAlarmeLED
            // 
            this.lblTxtAlarmeLED.AutoSize = true;
            this.lblTxtAlarmeLED.Location = new System.Drawing.Point(217, 465);
            this.lblTxtAlarmeLED.Name = "lblTxtAlarmeLED";
            this.lblTxtAlarmeLED.Size = new System.Drawing.Size(63, 13);
            this.lblTxtAlarmeLED.TabIndex = 93;
            this.lblTxtAlarmeLED.Text = "Alarme LED";
            // 
            // boxShutdownOverload
            // 
            this.boxShutdownOverload.AutoSize = true;
            this.boxShutdownOverload.Location = new System.Drawing.Point(448, 486);
            this.boxShutdownOverload.Name = "boxShutdownOverload";
            this.boxShutdownOverload.Size = new System.Drawing.Size(15, 14);
            this.boxShutdownOverload.TabIndex = 91;
            this.boxShutdownOverload.UseVisualStyleBackColor = true;
            this.boxShutdownOverload.CheckedChanged += new System.EventHandler(this.boxShutdownOverload_CheckedChanged);
            // 
            // boxShutdownChecksum
            // 
            this.boxShutdownChecksum.AutoSize = true;
            this.boxShutdownChecksum.Location = new System.Drawing.Point(421, 486);
            this.boxShutdownChecksum.Name = "boxShutdownChecksum";
            this.boxShutdownChecksum.Size = new System.Drawing.Size(15, 14);
            this.boxShutdownChecksum.TabIndex = 90;
            this.boxShutdownChecksum.UseVisualStyleBackColor = true;
            this.boxShutdownChecksum.CheckedChanged += new System.EventHandler(this.boxShutdownChecksum_CheckedChanged);
            // 
            // boxShutdownRange
            // 
            this.boxShutdownRange.AutoSize = true;
            this.boxShutdownRange.Location = new System.Drawing.Point(394, 486);
            this.boxShutdownRange.Name = "boxShutdownRange";
            this.boxShutdownRange.Size = new System.Drawing.Size(15, 14);
            this.boxShutdownRange.TabIndex = 89;
            this.boxShutdownRange.UseVisualStyleBackColor = true;
            this.boxShutdownRange.CheckedChanged += new System.EventHandler(this.boxShutdownRange_CheckedChanged);
            // 
            // boxShutdownOverheating
            // 
            this.boxShutdownOverheating.AutoSize = true;
            this.boxShutdownOverheating.Location = new System.Drawing.Point(367, 486);
            this.boxShutdownOverheating.Name = "boxShutdownOverheating";
            this.boxShutdownOverheating.Size = new System.Drawing.Size(15, 14);
            this.boxShutdownOverheating.TabIndex = 88;
            this.boxShutdownOverheating.UseVisualStyleBackColor = true;
            this.boxShutdownOverheating.CheckedChanged += new System.EventHandler(this.boxShutdownOverheating_CheckedChanged);
            // 
            // boxLEDInputVoltage
            // 
            this.boxLEDInputVoltage.AutoSize = true;
            this.boxLEDInputVoltage.Location = new System.Drawing.Point(313, 466);
            this.boxLEDInputVoltage.Name = "boxLEDInputVoltage";
            this.boxLEDInputVoltage.Size = new System.Drawing.Size(15, 14);
            this.boxLEDInputVoltage.TabIndex = 87;
            this.boxLEDInputVoltage.UseVisualStyleBackColor = true;
            this.boxLEDInputVoltage.CheckedChanged += new System.EventHandler(this.boxLEDInputVoltage_CheckedChanged);
            // 
            // boxLEDAngleLimit
            // 
            this.boxLEDAngleLimit.AutoSize = true;
            this.boxLEDAngleLimit.Location = new System.Drawing.Point(340, 466);
            this.boxLEDAngleLimit.Name = "boxLEDAngleLimit";
            this.boxLEDAngleLimit.Size = new System.Drawing.Size(15, 14);
            this.boxLEDAngleLimit.TabIndex = 86;
            this.boxLEDAngleLimit.UseVisualStyleBackColor = true;
            this.boxLEDAngleLimit.CheckedChanged += new System.EventHandler(this.boxLEDAngleLimit_CheckedChanged);
            // 
            // boxLEDOverload
            // 
            this.boxLEDOverload.AutoSize = true;
            this.boxLEDOverload.Location = new System.Drawing.Point(448, 466);
            this.boxLEDOverload.Name = "boxLEDOverload";
            this.boxLEDOverload.Size = new System.Drawing.Size(15, 14);
            this.boxLEDOverload.TabIndex = 84;
            this.boxLEDOverload.UseVisualStyleBackColor = true;
            this.boxLEDOverload.CheckedChanged += new System.EventHandler(this.boxLEDOverload_CheckedChanged);
            // 
            // boxLEDChecksum
            // 
            this.boxLEDChecksum.AutoSize = true;
            this.boxLEDChecksum.Location = new System.Drawing.Point(421, 466);
            this.boxLEDChecksum.Name = "boxLEDChecksum";
            this.boxLEDChecksum.Size = new System.Drawing.Size(15, 14);
            this.boxLEDChecksum.TabIndex = 83;
            this.boxLEDChecksum.UseVisualStyleBackColor = true;
            this.boxLEDChecksum.CheckedChanged += new System.EventHandler(this.boxLEDChecksum_CheckedChanged);
            // 
            // boxLEDRange
            // 
            this.boxLEDRange.AutoSize = true;
            this.boxLEDRange.Location = new System.Drawing.Point(394, 466);
            this.boxLEDRange.Name = "boxLEDRange";
            this.boxLEDRange.Size = new System.Drawing.Size(15, 14);
            this.boxLEDRange.TabIndex = 82;
            this.boxLEDRange.UseVisualStyleBackColor = true;
            this.boxLEDRange.CheckedChanged += new System.EventHandler(this.boxLEDRange_CheckedChanged);
            // 
            // boxLEDOverheating
            // 
            this.boxLEDOverheating.AutoSize = true;
            this.boxLEDOverheating.Location = new System.Drawing.Point(367, 466);
            this.boxLEDOverheating.Name = "boxLEDOverheating";
            this.boxLEDOverheating.Size = new System.Drawing.Size(15, 14);
            this.boxLEDOverheating.TabIndex = 81;
            this.boxLEDOverheating.UseVisualStyleBackColor = true;
            this.boxLEDOverheating.CheckedChanged += new System.EventHandler(this.boxLEDOverheating_CheckedChanged);
            // 
            // boxShutdownAngleLimit
            // 
            this.boxShutdownAngleLimit.AutoSize = true;
            this.boxShutdownAngleLimit.Location = new System.Drawing.Point(340, 486);
            this.boxShutdownAngleLimit.Name = "boxShutdownAngleLimit";
            this.boxShutdownAngleLimit.Size = new System.Drawing.Size(15, 14);
            this.boxShutdownAngleLimit.TabIndex = 80;
            this.boxShutdownAngleLimit.UseVisualStyleBackColor = true;
            this.boxShutdownAngleLimit.CheckedChanged += new System.EventHandler(this.boxShutdownAngleLimit_CheckedChanged);
            // 
            // boxShutdownInputVoltage
            // 
            this.boxShutdownInputVoltage.AutoSize = true;
            this.boxShutdownInputVoltage.Location = new System.Drawing.Point(313, 486);
            this.boxShutdownInputVoltage.Name = "boxShutdownInputVoltage";
            this.boxShutdownInputVoltage.Size = new System.Drawing.Size(15, 14);
            this.boxShutdownInputVoltage.TabIndex = 79;
            this.boxShutdownInputVoltage.UseVisualStyleBackColor = true;
            this.boxShutdownInputVoltage.CheckedChanged += new System.EventHandler(this.boxShutdownInputVoltage_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(132, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 78;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTxtIntervalleMs
            // 
            this.lblTxtIntervalleMs.AutoSize = true;
            this.lblTxtIntervalleMs.Location = new System.Drawing.Point(367, 34);
            this.lblTxtIntervalleMs.Name = "lblTxtIntervalleMs";
            this.lblTxtIntervalleMs.Size = new System.Drawing.Size(20, 13);
            this.lblTxtIntervalleMs.TabIndex = 77;
            this.lblTxtIntervalleMs.Text = "ms";
            // 
            // numIntervalle
            // 
            this.numIntervalle.Location = new System.Drawing.Point(295, 32);
            this.numIntervalle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numIntervalle.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numIntervalle.Name = "numIntervalle";
            this.numIntervalle.Size = new System.Drawing.Size(66, 20);
            this.numIntervalle.TabIndex = 76;
            this.numIntervalle.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblTxtIntervalle
            // 
            this.lblTxtIntervalle.AutoSize = true;
            this.lblTxtIntervalle.Location = new System.Drawing.Point(233, 34);
            this.lblTxtIntervalle.Name = "lblTxtIntervalle";
            this.lblTxtIntervalle.Size = new System.Drawing.Size(56, 13);
            this.lblTxtIntervalle.TabIndex = 75;
            this.lblTxtIntervalle.Text = "Intervalle :";
            // 
            // ledCouple
            // 
            this.ledCouple.BackColor = System.Drawing.Color.Transparent;
            this.ledCouple.Color = System.Drawing.Color.Gray;
            this.ledCouple.Image = ((System.Drawing.Image)(resources.GetObject("ledCouple.Image")));
            this.ledCouple.Location = new System.Drawing.Point(307, 196);
            this.ledCouple.Name = "ledCouple";
            this.ledCouple.Size = new System.Drawing.Size(16, 16);
            this.ledCouple.TabIndex = 74;
            this.ledCouple.TabStop = false;
            // 
            // ledLed
            // 
            this.ledLed.BackColor = System.Drawing.Color.Transparent;
            this.ledLed.Color = System.Drawing.Color.Empty;
            this.ledLed.Image = ((System.Drawing.Image)(resources.GetObject("ledLed.Image")));
            this.ledLed.Location = new System.Drawing.Point(307, 174);
            this.ledLed.Name = "ledLed";
            this.ledLed.Size = new System.Drawing.Size(16, 16);
            this.ledLed.TabIndex = 73;
            this.ledLed.TabStop = false;
            // 
            // lblFirmware
            // 
            this.lblFirmware.AutoSize = true;
            this.lblFirmware.Location = new System.Drawing.Point(111, 176);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(10, 13);
            this.lblFirmware.TabIndex = 71;
            this.lblFirmware.Text = "-";
            // 
            // lblTxtFirmware
            // 
            this.lblTxtFirmware.AutoSize = true;
            this.lblTxtFirmware.Location = new System.Drawing.Point(15, 178);
            this.lblTxtFirmware.Name = "lblTxtFirmware";
            this.lblTxtFirmware.Size = new System.Drawing.Size(84, 13);
            this.lblTxtFirmware.TabIndex = 70;
            this.lblTxtFirmware.Text = "Version firmware";
            // 
            // lblModele
            // 
            this.lblModele.AutoSize = true;
            this.lblModele.Location = new System.Drawing.Point(111, 154);
            this.lblModele.Name = "lblModele";
            this.lblModele.Size = new System.Drawing.Size(10, 13);
            this.lblModele.TabIndex = 69;
            this.lblModele.Text = "-";
            // 
            // lblTxtModele
            // 
            this.lblTxtModele.AutoSize = true;
            this.lblTxtModele.Location = new System.Drawing.Point(15, 154);
            this.lblTxtModele.Name = "lblTxtModele";
            this.lblTxtModele.Size = new System.Drawing.Size(56, 13);
            this.lblTxtModele.TabIndex = 68;
            this.lblTxtModele.Text = "N° modèle";
            // 
            // numPositionMax
            // 
            this.numPositionMax.Location = new System.Drawing.Point(101, 300);
            this.numPositionMax.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numPositionMax.Name = "numPositionMax";
            this.numPositionMax.Size = new System.Drawing.Size(66, 20);
            this.numPositionMax.TabIndex = 67;
            // 
            // btnOkPositionMax
            // 
            this.btnOkPositionMax.Location = new System.Drawing.Point(173, 299);
            this.btnOkPositionMax.Name = "btnOkPositionMax";
            this.btnOkPositionMax.Size = new System.Drawing.Size(30, 23);
            this.btnOkPositionMax.TabIndex = 66;
            this.btnOkPositionMax.Text = "Ok";
            this.btnOkPositionMax.UseVisualStyleBackColor = true;
            this.btnOkPositionMax.Click += new System.EventHandler(this.btnOkPositionMax_Click);
            // 
            // lblTxtPositionMax
            // 
            this.lblTxtPositionMax.AutoSize = true;
            this.lblTxtPositionMax.Location = new System.Drawing.Point(15, 304);
            this.lblTxtPositionMax.Name = "lblTxtPositionMax";
            this.lblTxtPositionMax.Size = new System.Drawing.Size(66, 13);
            this.lblTxtPositionMax.TabIndex = 65;
            this.lblTxtPositionMax.Text = "Position max";
            // 
            // numPositionMin
            // 
            this.numPositionMin.Location = new System.Drawing.Point(101, 274);
            this.numPositionMin.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numPositionMin.Name = "numPositionMin";
            this.numPositionMin.Size = new System.Drawing.Size(66, 20);
            this.numPositionMin.TabIndex = 64;
            // 
            // btnOkPositionMin
            // 
            this.btnOkPositionMin.Location = new System.Drawing.Point(173, 273);
            this.btnOkPositionMin.Name = "btnOkPositionMin";
            this.btnOkPositionMin.Size = new System.Drawing.Size(30, 23);
            this.btnOkPositionMin.TabIndex = 63;
            this.btnOkPositionMin.Text = "Ok";
            this.btnOkPositionMin.UseVisualStyleBackColor = true;
            this.btnOkPositionMin.Click += new System.EventHandler(this.btnOkPositionMin_Click);
            // 
            // lblTxtPositionMin
            // 
            this.lblTxtPositionMin.AutoSize = true;
            this.lblTxtPositionMin.Location = new System.Drawing.Point(15, 278);
            this.lblTxtPositionMin.Name = "lblTxtPositionMin";
            this.lblTxtPositionMin.Size = new System.Drawing.Size(63, 13);
            this.lblTxtPositionMin.TabIndex = 62;
            this.lblTxtPositionMin.Text = "Position min";
            // 
            // ledMouvement
            // 
            this.ledMouvement.BackColor = System.Drawing.Color.Transparent;
            this.ledMouvement.Color = System.Drawing.Color.Empty;
            this.ledMouvement.Image = ((System.Drawing.Image)(resources.GetObject("ledMouvement.Image")));
            this.ledMouvement.Location = new System.Drawing.Point(307, 218);
            this.ledMouvement.Name = "ledMouvement";
            this.ledMouvement.Size = new System.Drawing.Size(16, 16);
            this.ledMouvement.TabIndex = 61;
            this.ledMouvement.TabStop = false;
            // 
            // lblTxtMouvement
            // 
            this.lblTxtMouvement.AutoSize = true;
            this.lblTxtMouvement.Location = new System.Drawing.Point(217, 221);
            this.lblTxtMouvement.Name = "lblTxtMouvement";
            this.lblTxtMouvement.Size = new System.Drawing.Size(78, 13);
            this.lblTxtMouvement.TabIndex = 60;
            this.lblTxtMouvement.Text = "En mouvement";
            // 
            // switchCouple
            // 
            this.switchCouple.BackColor = System.Drawing.Color.Transparent;
            this.switchCouple.Location = new System.Drawing.Point(329, 197);
            this.switchCouple.Name = "switchCouple";
            this.switchCouple.Size = new System.Drawing.Size(35, 15);
            this.switchCouple.Symetrique = false;
            this.switchCouple.TabIndex = 59;
            this.switchCouple.ChangementEtat += new System.EventHandler(this.switchCouple_ChangementEtat);
            // 
            // lblTxtCouple
            // 
            this.lblTxtCouple.AutoSize = true;
            this.lblTxtCouple.Location = new System.Drawing.Point(217, 199);
            this.lblTxtCouple.Name = "lblTxtCouple";
            this.lblTxtCouple.Size = new System.Drawing.Size(40, 13);
            this.lblTxtCouple.TabIndex = 58;
            this.lblTxtCouple.Text = "Couple";
            // 
            // numCouple
            // 
            this.numCouple.Location = new System.Drawing.Point(101, 223);
            this.numCouple.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numCouple.Name = "numCouple";
            this.numCouple.Size = new System.Drawing.Size(66, 20);
            this.numCouple.TabIndex = 57;
            // 
            // btnOkCoupleMax
            // 
            this.btnOkCoupleMax.Location = new System.Drawing.Point(173, 221);
            this.btnOkCoupleMax.Name = "btnOkCoupleMax";
            this.btnOkCoupleMax.Size = new System.Drawing.Size(30, 23);
            this.btnOkCoupleMax.TabIndex = 56;
            this.btnOkCoupleMax.Text = "Ok";
            this.btnOkCoupleMax.UseVisualStyleBackColor = true;
            this.btnOkCoupleMax.Click += new System.EventHandler(this.btnOkCoupleMax_Click);
            // 
            // lblTxtCoupleMax
            // 
            this.lblTxtCoupleMax.AutoSize = true;
            this.lblTxtCoupleMax.Location = new System.Drawing.Point(15, 226);
            this.lblTxtCoupleMax.Name = "lblTxtCoupleMax";
            this.lblTxtCoupleMax.Size = new System.Drawing.Size(62, 13);
            this.lblTxtCoupleMax.TabIndex = 55;
            this.lblTxtCoupleMax.Text = "Couple max";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(444, 29);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 54;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblLed
            // 
            this.lblLed.AutoSize = true;
            this.lblLed.Location = new System.Drawing.Point(217, 177);
            this.lblLed.Name = "lblLed";
            this.lblLed.Size = new System.Drawing.Size(25, 13);
            this.lblLed.TabIndex = 53;
            this.lblLed.Text = "Led";
            // 
            // switchLed
            // 
            this.switchLed.BackColor = System.Drawing.Color.Transparent;
            this.switchLed.Location = new System.Drawing.Point(329, 174);
            this.switchLed.Name = "switchLed";
            this.switchLed.Size = new System.Drawing.Size(35, 15);
            this.switchLed.Symetrique = false;
            this.switchLed.TabIndex = 52;
            this.switchLed.ChangementEtat += new System.EventHandler(this.switchLed_ChangementEtat);
            // 
            // switchSurveillance
            // 
            this.switchSurveillance.BackColor = System.Drawing.Color.Transparent;
            this.switchSurveillance.Location = new System.Drawing.Point(308, 56);
            this.switchSurveillance.Name = "switchSurveillance";
            this.switchSurveillance.Size = new System.Drawing.Size(35, 15);
            this.switchSurveillance.Symetrique = false;
            this.switchSurveillance.TabIndex = 51;
            this.switchSurveillance.ChangementEtat += new System.EventHandler(this.switchSurveillance_ChangementEtat);
            // 
            // lblTxtSurveillance
            // 
            this.lblTxtSurveillance.AutoSize = true;
            this.lblTxtSurveillance.Location = new System.Drawing.Point(233, 58);
            this.lblTxtSurveillance.Name = "lblTxtSurveillance";
            this.lblTxtSurveillance.Size = new System.Drawing.Size(71, 13);
            this.lblTxtSurveillance.TabIndex = 50;
            this.lblTxtSurveillance.Text = "Surveillance :";
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.BackColor = System.Drawing.Color.Transparent;
            this.trackBarPosition.IntervalTimer = 500;
            this.trackBarPosition.Location = new System.Drawing.Point(132, 107);
            this.trackBarPosition.Max = 1024D;
            this.trackBarPosition.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarPosition.Min = 0D;
            this.trackBarPosition.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.DecimalPlaces = 0;
            this.trackBarPosition.Reverse = false;
            this.trackBarPosition.Size = new System.Drawing.Size(318, 15);
            this.trackBarPosition.TabIndex = 6;
            this.trackBarPosition.Vertical = false;
            this.trackBarPosition.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarPosition_TickValueChanged);
            this.trackBarPosition.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarPosition_ValueChanged);
            // 
            // trackBarVitesse
            // 
            this.trackBarVitesse.BackColor = System.Drawing.Color.Transparent;
            this.trackBarVitesse.IntervalTimer = 500;
            this.trackBarVitesse.Location = new System.Drawing.Point(132, 128);
            this.trackBarVitesse.Max = 1023D;
            this.trackBarVitesse.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarVitesse.Min = 0D;
            this.trackBarVitesse.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarVitesse.Name = "trackBarVitesse";
            this.trackBarVitesse.DecimalPlaces = 0;
            this.trackBarVitesse.Reverse = false;
            this.trackBarVitesse.Size = new System.Drawing.Size(318, 15);
            this.trackBarVitesse.TabIndex = 9;
            this.trackBarVitesse.Vertical = false;
            this.trackBarVitesse.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarVitesse_TickValueChanged);
            this.trackBarVitesse.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarVitesse_ValueChanged);
            // 
            // PanelServo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupServo);
            this.Name = "PanelServo";
            this.Size = new System.Drawing.Size(1041, 520);
            this.Load += new System.EventHandler(this.PanelServo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numID)).EndInit();
            this.groupServo.ResumeLayout(false);
            this.groupServo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompliance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoupleLimite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTensionMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTensionMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAngles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurInstruction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurOverload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurChecksum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurOverheating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurAngleLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledErreurInputVoltage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAlarmes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCWMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCWSlope)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCCWMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCCWSlope)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledCouple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledLed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledMouvement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCouple)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.NumericUpDown numID;
        private Composants.TrackBarPlus trackBarPosition;
        private System.Windows.Forms.Label lblTxtPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.Label lblTxtVitesse;
        private Composants.TrackBarPlus trackBarVitesse;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblTxtTemperature;
        private System.Windows.Forms.Label lblTension;
        private System.Windows.Forms.Label lblTxtTension;
        private System.Windows.Forms.Button btnOkBaudrate;
        private System.Windows.Forms.Label lblTxtBaudrate;
        private System.Windows.Forms.GroupBox groupServo;
        private Composants.SwitchBouton switchSurveillance;
        private System.Windows.Forms.Label lblTxtSurveillance;
        private System.Windows.Forms.Label lblLed;
        private Composants.SwitchBouton switchLed;
        private System.Windows.Forms.NumericUpDown numCWMargin;
        private System.Windows.Forms.Button btnOkCWMargin;
        private System.Windows.Forms.Label lblTxtCWMargin;
        private System.Windows.Forms.NumericUpDown numCWSlope;
        private System.Windows.Forms.Button btnOkCWSlope;
        private System.Windows.Forms.Label lblTxtCWSlope;
        private System.Windows.Forms.NumericUpDown numCCWMargin;
        private System.Windows.Forms.Button btnOkCCWMargin;
        private System.Windows.Forms.Label lblTxtCCWMargin;
        private System.Windows.Forms.NumericUpDown numCCWSlope;
        private System.Windows.Forms.Button btnOkCCWSlope;
        private System.Windows.Forms.Label lblTxtCCWSlope;
        private System.Windows.Forms.Label lblVitesseActuelle;
        private System.Windows.Forms.Label lblTxtVitesseActuelle;
        private System.Windows.Forms.Label lblPositionActuelle;
        private System.Windows.Forms.Label lblTxtPositionActuelle;
        private System.Windows.Forms.Label lblTxtAlarmeShutdown;
        private System.Windows.Forms.Label lblTxtAlarmeLED;
        private System.Windows.Forms.CheckBox boxShutdownOverload;
        private System.Windows.Forms.CheckBox boxShutdownChecksum;
        private System.Windows.Forms.CheckBox boxShutdownRange;
        private System.Windows.Forms.CheckBox boxShutdownOverheating;
        private System.Windows.Forms.CheckBox boxLEDInputVoltage;
        private System.Windows.Forms.CheckBox boxLEDAngleLimit;
        private System.Windows.Forms.CheckBox boxLEDOverload;
        private System.Windows.Forms.CheckBox boxLEDChecksum;
        private System.Windows.Forms.CheckBox boxLEDRange;
        private System.Windows.Forms.CheckBox boxLEDOverheating;
        private System.Windows.Forms.CheckBox boxShutdownAngleLimit;
        private System.Windows.Forms.CheckBox boxShutdownInputVoltage;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTxtIntervalleMs;
        private System.Windows.Forms.NumericUpDown numIntervalle;
        private System.Windows.Forms.Label lblTxtIntervalle;
        private Composants.Led ledCouple;
        private Composants.Led ledLed;
        private System.Windows.Forms.Label lblFirmware;
        private System.Windows.Forms.Label lblTxtFirmware;
        private System.Windows.Forms.Label lblModele;
        private System.Windows.Forms.Label lblTxtModele;
        private System.Windows.Forms.NumericUpDown numPositionMax;
        private System.Windows.Forms.Button btnOkPositionMax;
        private System.Windows.Forms.Label lblTxtPositionMax;
        private System.Windows.Forms.NumericUpDown numPositionMin;
        private System.Windows.Forms.Button btnOkPositionMin;
        private System.Windows.Forms.Label lblTxtPositionMin;
        private Composants.Led ledMouvement;
        private System.Windows.Forms.Label lblTxtMouvement;
        private Composants.SwitchBouton switchCouple;
        private System.Windows.Forms.Label lblTxtCouple;
        private System.Windows.Forms.NumericUpDown numCouple;
        private System.Windows.Forms.Button btnOkCoupleMax;
        private System.Windows.Forms.Label lblTxtCoupleMax;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox imgAlarmes;
        private System.Windows.Forms.CheckBox boxShutdownInstruction;
        private System.Windows.Forms.CheckBox boxLEDInstruction;
        private Composants.Led ledErreurInstruction;
        private Composants.Led ledErreurOverload;
        private Composants.Led ledErreurChecksum;
        private Composants.Led ledErreurRange;
        private Composants.Led ledErreurOverheating;
        private Composants.Led ledErreurAngleLimit;
        private Composants.Led ledErreurInputVoltage;
        private System.Windows.Forms.PictureBox pictureBoxAngles;
        private Composants.GraphPanel ctrlGraphiqueTemperature;
        private Composants.GraphPanel ctrlGraphiquePosition;
        private Composants.GraphPanel ctrlGraphiqueVitesse;
        private System.Windows.Forms.Label lblCoupleActuel;
        private System.Windows.Forms.Label lblTxtCoupleActuel;
        private Composants.GraphPanel ctrlGraphiqueCouple;
        private System.Windows.Forms.NumericUpDown numTensionMax;
        private System.Windows.Forms.Button btnOkTensionMax;
        private System.Windows.Forms.Label lblTxtTensionMax;
        private System.Windows.Forms.NumericUpDown numTensionMin;
        private System.Windows.Forms.Button btnOkTensionMin;
        private System.Windows.Forms.Label lblTxtTensionMin;
        private System.Windows.Forms.NumericUpDown numTempMax;
        private System.Windows.Forms.Button btnOkTempMax;
        private System.Windows.Forms.Label lblTxtTempMax;
        private System.Windows.Forms.NumericUpDown numCoupleLimite;
        private System.Windows.Forms.Button btnOkCoupleLimite;
        private System.Windows.Forms.Label lblTxtCoupleLimite;
        private System.Windows.Forms.Button btnChangeID;
        private System.Windows.Forms.ComboBox cboBaudrate;
        private System.Windows.Forms.PictureBox pictureBoxCompliance;
        private System.Windows.Forms.NumericUpDown numPunch;
        private System.Windows.Forms.Button btnOkPunch;
        private System.Windows.Forms.Label lblTxtPunch;
    }
}
