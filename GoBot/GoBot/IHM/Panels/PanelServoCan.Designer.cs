namespace GoBot.IHM
{
    partial class PanelServoCan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelServoCan));
            this.grpMonitoring = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.switchButton1 = new Composants.SwitchButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gphMonitoringTorque = new Composants.GraphPanel();
            this.gphMonitoringPos = new Composants.GraphPanel();
            this.boxMonitoring = new Composants.SwitchButton();
            this.lblTorqueUnit = new System.Windows.Forms.Label();
            this.lblTorqueMaxTxt = new System.Windows.Forms.Label();
            this.numTorqueMax = new System.Windows.Forms.NumericUpDown();
            this.numID = new System.Windows.Forms.NumericUpDown();
            this.lblPosMinTxt = new System.Windows.Forms.Label();
            this.lblSpeedMaxTxt = new System.Windows.Forms.Label();
            this.lblPosMaxTxt = new System.Windows.Forms.Label();
            this.lblAccelTxt = new System.Windows.Forms.Label();
            this.grpTrajectory = new System.Windows.Forms.GroupBox();
            this.lblTrajectoryTime = new System.Windows.Forms.Label();
            this.picArrow = new System.Windows.Forms.PictureBox();
            this.lblTrajectoryAccelTxt = new System.Windows.Forms.Label();
            this.lblTrajectorySpeedTxt = new System.Windows.Forms.Label();
            this.lblTrajectoryTargetTxt = new System.Windows.Forms.Label();
            this.lblTrajectoryAccel = new System.Windows.Forms.Label();
            this.lblTrajectorySpeed = new System.Windows.Forms.Label();
            this.lblTrajectoryTarget = new System.Windows.Forms.Label();
            this.trkTrajectoryAccel = new Composants.TrackBarPlus();
            this.trkTrajectorySpeed = new Composants.TrackBarPlus();
            this.trkTrajectoryTarget = new Composants.TrackBarPlus();
            this.gphTrajectorySpeed = new Composants.GraphPanel();
            this.gphTrajectoryPosition = new Composants.GraphPanel();
            this.btnTrajectoryGo = new System.Windows.Forms.Button();
            this.numPositionMin = new System.Windows.Forms.NumericUpDown();
            this.numPositionMax = new System.Windows.Forms.NumericUpDown();
            this.numSpeedMax = new System.Windows.Forms.NumericUpDown();
            this.numPosition = new System.Windows.Forms.NumericUpDown();
            this.numAccel = new System.Windows.Forms.NumericUpDown();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.btnAutoMax = new System.Windows.Forms.Button();
            this.btnAutoMin = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.trkPosition = new Composants.TrackBarPlus();
            this.lblIDTxt = new Composants.LabelPlus();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.picConnection = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.lblSpeedUnit = new System.Windows.Forms.Label();
            this.lblAccelUnit = new System.Windows.Forms.Label();
            this.grpPositions = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSauvegarderPosition = new System.Windows.Forms.Button();
            this.switchButton2 = new Composants.SwitchButton();
            this.label3 = new System.Windows.Forms.Label();
            this.grpMonitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTorqueMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).BeginInit();
            this.grpTrajectory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccel)).BeginInit();
            this.grpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConnection)).BeginInit();
            this.grpSettings.SuspendLayout();
            this.grpPositions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMonitoring
            // 
            this.grpMonitoring.Controls.Add(this.label2);
            this.grpMonitoring.Controls.Add(this.switchButton1);
            this.grpMonitoring.Controls.Add(this.label1);
            this.grpMonitoring.Controls.Add(this.gphMonitoringTorque);
            this.grpMonitoring.Controls.Add(this.gphMonitoringPos);
            this.grpMonitoring.Controls.Add(this.boxMonitoring);
            this.grpMonitoring.Enabled = false;
            this.grpMonitoring.Location = new System.Drawing.Point(304, 34);
            this.grpMonitoring.Name = "grpMonitoring";
            this.grpMonitoring.Size = new System.Drawing.Size(295, 453);
            this.grpMonitoring.TabIndex = 1;
            this.grpMonitoring.TabStop = false;
            this.grpMonitoring.Text = "Monitoring";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Suivre le courant";
            // 
            // switchButton1
            // 
            this.switchButton1.AutoSize = true;
            this.switchButton1.BackColor = System.Drawing.Color.Transparent;
            this.switchButton1.Location = new System.Drawing.Point(254, 237);
            this.switchButton1.MaximumSize = new System.Drawing.Size(35, 15);
            this.switchButton1.MinimumSize = new System.Drawing.Size(35, 15);
            this.switchButton1.Mirrored = true;
            this.switchButton1.Name = "switchButton1";
            this.switchButton1.Size = new System.Drawing.Size(35, 15);
            this.switchButton1.TabIndex = 43;
            this.switchButton1.Value = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Suivre la position";
            // 
            // gphMonitoringTorque
            // 
            this.gphMonitoringTorque.BackColor = System.Drawing.Color.White;
            this.gphMonitoringTorque.BorderColor = System.Drawing.Color.LightGray;
            this.gphMonitoringTorque.BorderVisible = false;
            this.gphMonitoringTorque.LimitsVisible = true;
            this.gphMonitoringTorque.Location = new System.Drawing.Point(6, 258);
            this.gphMonitoringTorque.MaxLimit = 1D;
            this.gphMonitoringTorque.MinLimit = 0D;
            this.gphMonitoringTorque.Name = "gphMonitoringTorque";
            this.gphMonitoringTorque.NamesAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.gphMonitoringTorque.NamesVisible = true;
            this.gphMonitoringTorque.ScaleMode = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.gphMonitoringTorque.Size = new System.Drawing.Size(283, 185);
            this.gphMonitoringTorque.TabIndex = 7;
            // 
            // gphMonitoringPos
            // 
            this.gphMonitoringPos.BackColor = System.Drawing.Color.White;
            this.gphMonitoringPos.BorderColor = System.Drawing.Color.LightGray;
            this.gphMonitoringPos.BorderVisible = false;
            this.gphMonitoringPos.LimitsVisible = true;
            this.gphMonitoringPos.Location = new System.Drawing.Point(6, 39);
            this.gphMonitoringPos.MaxLimit = 1D;
            this.gphMonitoringPos.MinLimit = 0D;
            this.gphMonitoringPos.Name = "gphMonitoringPos";
            this.gphMonitoringPos.NamesAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.gphMonitoringPos.NamesVisible = true;
            this.gphMonitoringPos.ScaleMode = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.gphMonitoringPos.Size = new System.Drawing.Size(283, 185);
            this.gphMonitoringPos.TabIndex = 4;
            // 
            // boxMonitoring
            // 
            this.boxMonitoring.AutoSize = true;
            this.boxMonitoring.BackColor = System.Drawing.Color.Transparent;
            this.boxMonitoring.Location = new System.Drawing.Point(254, 18);
            this.boxMonitoring.MaximumSize = new System.Drawing.Size(35, 15);
            this.boxMonitoring.MinimumSize = new System.Drawing.Size(35, 15);
            this.boxMonitoring.Mirrored = true;
            this.boxMonitoring.Name = "boxMonitoring";
            this.boxMonitoring.Size = new System.Drawing.Size(35, 15);
            this.boxMonitoring.TabIndex = 0;
            this.boxMonitoring.Value = false;
            this.boxMonitoring.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.boxTorque_ValueChanged);
            // 
            // lblTorqueUnit
            // 
            this.lblTorqueUnit.AutoSize = true;
            this.lblTorqueUnit.Location = new System.Drawing.Point(186, 77);
            this.lblTorqueUnit.Name = "lblTorqueUnit";
            this.lblTorqueUnit.Size = new System.Drawing.Size(22, 13);
            this.lblTorqueUnit.TabIndex = 42;
            this.lblTorqueUnit.Text = "mA";
            // 
            // lblTorqueMaxTxt
            // 
            this.lblTorqueMaxTxt.AutoSize = true;
            this.lblTorqueMaxTxt.Location = new System.Drawing.Point(48, 77);
            this.lblTorqueMaxTxt.Name = "lblTorqueMaxTxt";
            this.lblTorqueMaxTxt.Size = new System.Drawing.Size(73, 13);
            this.lblTorqueMaxTxt.TabIndex = 26;
            this.lblTorqueMaxTxt.Text = "Alerte courant";
            // 
            // numTorqueMax
            // 
            this.numTorqueMax.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTorqueMax.Location = new System.Drawing.Point(130, 75);
            this.numTorqueMax.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numTorqueMax.Name = "numTorqueMax";
            this.numTorqueMax.Size = new System.Drawing.Size(50, 20);
            this.numTorqueMax.TabIndex = 35;
            this.numTorqueMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTorqueMax.ValueChanged += new System.EventHandler(this.numTorqueMax_ValueChanged);
            // 
            // numID
            // 
            this.numID.Location = new System.Drawing.Point(284, 7);
            this.numID.Name = "numID";
            this.numID.Size = new System.Drawing.Size(34, 20);
            this.numID.TabIndex = 2;
            this.numID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numID.ValueChanged += new System.EventHandler(this.numID_ValueChanged);
            // 
            // lblPosMinTxt
            // 
            this.lblPosMinTxt.AutoSize = true;
            this.lblPosMinTxt.Location = new System.Drawing.Point(6, 55);
            this.lblPosMinTxt.Name = "lblPosMinTxt";
            this.lblPosMinTxt.Size = new System.Drawing.Size(24, 13);
            this.lblPosMinTxt.TabIndex = 23;
            this.lblPosMinTxt.Text = "Min";
            // 
            // lblSpeedMaxTxt
            // 
            this.lblSpeedMaxTxt.AutoSize = true;
            this.lblSpeedMaxTxt.Location = new System.Drawing.Point(48, 51);
            this.lblSpeedMaxTxt.Name = "lblSpeedMaxTxt";
            this.lblSpeedMaxTxt.Size = new System.Drawing.Size(63, 13);
            this.lblSpeedMaxTxt.TabIndex = 24;
            this.lblSpeedMaxTxt.Text = "Vitesse max";
            // 
            // lblPosMaxTxt
            // 
            this.lblPosMaxTxt.AutoSize = true;
            this.lblPosMaxTxt.Location = new System.Drawing.Point(264, 55);
            this.lblPosMaxTxt.Name = "lblPosMaxTxt";
            this.lblPosMaxTxt.Size = new System.Drawing.Size(27, 13);
            this.lblPosMaxTxt.TabIndex = 25;
            this.lblPosMaxTxt.Text = "Max";
            // 
            // lblAccelTxt
            // 
            this.lblAccelTxt.AutoSize = true;
            this.lblAccelTxt.Location = new System.Drawing.Point(48, 25);
            this.lblAccelTxt.Name = "lblAccelTxt";
            this.lblAccelTxt.Size = new System.Drawing.Size(66, 13);
            this.lblAccelTxt.TabIndex = 28;
            this.lblAccelTxt.Text = "Accélération";
            // 
            // grpTrajectory
            // 
            this.grpTrajectory.Controls.Add(this.lblTrajectoryTime);
            this.grpTrajectory.Controls.Add(this.picArrow);
            this.grpTrajectory.Controls.Add(this.lblTrajectoryAccelTxt);
            this.grpTrajectory.Controls.Add(this.lblTrajectorySpeedTxt);
            this.grpTrajectory.Controls.Add(this.lblTrajectoryTargetTxt);
            this.grpTrajectory.Controls.Add(this.lblTrajectoryAccel);
            this.grpTrajectory.Controls.Add(this.lblTrajectorySpeed);
            this.grpTrajectory.Controls.Add(this.lblTrajectoryTarget);
            this.grpTrajectory.Controls.Add(this.trkTrajectoryAccel);
            this.grpTrajectory.Controls.Add(this.trkTrajectorySpeed);
            this.grpTrajectory.Controls.Add(this.trkTrajectoryTarget);
            this.grpTrajectory.Controls.Add(this.gphTrajectorySpeed);
            this.grpTrajectory.Controls.Add(this.gphTrajectoryPosition);
            this.grpTrajectory.Controls.Add(this.btnTrajectoryGo);
            this.grpTrajectory.Enabled = false;
            this.grpTrajectory.Location = new System.Drawing.Point(3, 314);
            this.grpTrajectory.Name = "grpTrajectory";
            this.grpTrajectory.Size = new System.Drawing.Size(295, 173);
            this.grpTrajectory.TabIndex = 31;
            this.grpTrajectory.TabStop = false;
            this.grpTrajectory.Text = "Trajectoire";
            // 
            // lblTrajectoryTime
            // 
            this.lblTrajectoryTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTrajectoryTime.Location = new System.Drawing.Point(206, 150);
            this.lblTrajectoryTime.Name = "lblTrajectoryTime";
            this.lblTrajectoryTime.Size = new System.Drawing.Size(35, 23);
            this.lblTrajectoryTime.TabIndex = 40;
            this.lblTrajectoryTime.Text = "00.0s";
            this.lblTrajectoryTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picArrow
            // 
            this.picArrow.Location = new System.Drawing.Point(158, 153);
            this.picArrow.Name = "picArrow";
            this.picArrow.Size = new System.Drawing.Size(131, 15);
            this.picArrow.TabIndex = 41;
            this.picArrow.TabStop = false;
            // 
            // lblTrajectoryAccelTxt
            // 
            this.lblTrajectoryAccelTxt.AutoSize = true;
            this.lblTrajectoryAccelTxt.Location = new System.Drawing.Point(15, 104);
            this.lblTrajectoryAccelTxt.Name = "lblTrajectoryAccelTxt";
            this.lblTrajectoryAccelTxt.Size = new System.Drawing.Size(66, 13);
            this.lblTrajectoryAccelTxt.TabIndex = 35;
            this.lblTrajectoryAccelTxt.Text = "Accélération";
            // 
            // lblTrajectorySpeedTxt
            // 
            this.lblTrajectorySpeedTxt.AutoSize = true;
            this.lblTrajectorySpeedTxt.Location = new System.Drawing.Point(17, 66);
            this.lblTrajectorySpeedTxt.Name = "lblTrajectorySpeedTxt";
            this.lblTrajectorySpeedTxt.Size = new System.Drawing.Size(63, 13);
            this.lblTrajectorySpeedTxt.TabIndex = 33;
            this.lblTrajectorySpeedTxt.Text = "Vitesse max";
            // 
            // lblTrajectoryTargetTxt
            // 
            this.lblTrajectoryTargetTxt.AutoSize = true;
            this.lblTrajectoryTargetTxt.Location = new System.Drawing.Point(17, 28);
            this.lblTrajectoryTargetTxt.Name = "lblTrajectoryTargetTxt";
            this.lblTrajectoryTargetTxt.Size = new System.Drawing.Size(69, 13);
            this.lblTrajectoryTargetTxt.TabIndex = 32;
            this.lblTrajectoryTargetTxt.Text = "Position cible";
            // 
            // lblTrajectoryAccel
            // 
            this.lblTrajectoryAccel.Location = new System.Drawing.Point(74, 104);
            this.lblTrajectoryAccel.Name = "lblTrajectoryAccel";
            this.lblTrajectoryAccel.Size = new System.Drawing.Size(73, 13);
            this.lblTrajectoryAccel.TabIndex = 39;
            this.lblTrajectoryAccel.Text = "-";
            this.lblTrajectoryAccel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrajectorySpeed
            // 
            this.lblTrajectorySpeed.Location = new System.Drawing.Point(74, 66);
            this.lblTrajectorySpeed.Name = "lblTrajectorySpeed";
            this.lblTrajectorySpeed.Size = new System.Drawing.Size(73, 13);
            this.lblTrajectorySpeed.TabIndex = 38;
            this.lblTrajectorySpeed.Text = "-";
            this.lblTrajectorySpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrajectoryTarget
            // 
            this.lblTrajectoryTarget.Location = new System.Drawing.Point(74, 28);
            this.lblTrajectoryTarget.Name = "lblTrajectoryTarget";
            this.lblTrajectoryTarget.Size = new System.Drawing.Size(73, 13);
            this.lblTrajectoryTarget.TabIndex = 37;
            this.lblTrajectoryTarget.Text = "-";
            this.lblTrajectoryTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trkTrajectoryAccel
            // 
            this.trkTrajectoryAccel.BackColor = System.Drawing.Color.Transparent;
            this.trkTrajectoryAccel.DecimalPlaces = 0;
            this.trkTrajectoryAccel.IntervalTimer = ((uint)(1u));
            this.trkTrajectoryAccel.Location = new System.Drawing.Point(20, 120);
            this.trkTrajectoryAccel.Max = 10000D;
            this.trkTrajectoryAccel.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkTrajectoryAccel.Min = 0D;
            this.trkTrajectoryAccel.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkTrajectoryAccel.Name = "trkTrajectoryAccel";
            this.trkTrajectoryAccel.Reverse = false;
            this.trkTrajectoryAccel.Size = new System.Drawing.Size(127, 15);
            this.trkTrajectoryAccel.TabIndex = 36;
            this.trkTrajectoryAccel.Vertical = false;
            this.trkTrajectoryAccel.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkTrajectoryAccel_ValueChanged);
            // 
            // trkTrajectorySpeed
            // 
            this.trkTrajectorySpeed.BackColor = System.Drawing.Color.Transparent;
            this.trkTrajectorySpeed.DecimalPlaces = 0;
            this.trkTrajectorySpeed.IntervalTimer = ((uint)(1u));
            this.trkTrajectorySpeed.Location = new System.Drawing.Point(20, 82);
            this.trkTrajectorySpeed.Max = 20000D;
            this.trkTrajectorySpeed.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkTrajectorySpeed.Min = 0D;
            this.trkTrajectorySpeed.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkTrajectorySpeed.Name = "trkTrajectorySpeed";
            this.trkTrajectorySpeed.Reverse = false;
            this.trkTrajectorySpeed.Size = new System.Drawing.Size(127, 15);
            this.trkTrajectorySpeed.TabIndex = 34;
            this.trkTrajectorySpeed.Vertical = false;
            this.trkTrajectorySpeed.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkTrajectorySpeed_ValueChanged);
            // 
            // trkTrajectoryTarget
            // 
            this.trkTrajectoryTarget.BackColor = System.Drawing.Color.Transparent;
            this.trkTrajectoryTarget.DecimalPlaces = 0;
            this.trkTrajectoryTarget.IntervalTimer = ((uint)(100u));
            this.trkTrajectoryTarget.Location = new System.Drawing.Point(20, 44);
            this.trkTrajectoryTarget.Max = 40000D;
            this.trkTrajectoryTarget.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkTrajectoryTarget.Min = 0D;
            this.trkTrajectoryTarget.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkTrajectoryTarget.Name = "trkTrajectoryTarget";
            this.trkTrajectoryTarget.Reverse = false;
            this.trkTrajectoryTarget.Size = new System.Drawing.Size(127, 15);
            this.trkTrajectoryTarget.TabIndex = 31;
            this.trkTrajectoryTarget.Vertical = false;
            this.trkTrajectoryTarget.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkTrajectoryTarget_ValueChanged);
            // 
            // gphTrajectorySpeed
            // 
            this.gphTrajectorySpeed.BackColor = System.Drawing.Color.White;
            this.gphTrajectorySpeed.BorderColor = System.Drawing.Color.LightGray;
            this.gphTrajectorySpeed.BorderVisible = false;
            this.gphTrajectorySpeed.LimitsVisible = true;
            this.gphTrajectorySpeed.Location = new System.Drawing.Point(158, 12);
            this.gphTrajectorySpeed.MaxLimit = 1D;
            this.gphTrajectorySpeed.MinLimit = 0D;
            this.gphTrajectorySpeed.Name = "gphTrajectorySpeed";
            this.gphTrajectorySpeed.NamesAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.gphTrajectorySpeed.NamesVisible = true;
            this.gphTrajectorySpeed.ScaleMode = Composants.GraphPanel.ScaleType.DynamicPerCurve;
            this.gphTrajectorySpeed.Size = new System.Drawing.Size(131, 69);
            this.gphTrajectorySpeed.TabIndex = 5;
            // 
            // gphTrajectoryPosition
            // 
            this.gphTrajectoryPosition.BackColor = System.Drawing.Color.White;
            this.gphTrajectoryPosition.BorderColor = System.Drawing.Color.LightGray;
            this.gphTrajectoryPosition.BorderVisible = false;
            this.gphTrajectoryPosition.LimitsVisible = true;
            this.gphTrajectoryPosition.Location = new System.Drawing.Point(158, 82);
            this.gphTrajectoryPosition.MaxLimit = 1D;
            this.gphTrajectoryPosition.MinLimit = 0D;
            this.gphTrajectoryPosition.Name = "gphTrajectoryPosition";
            this.gphTrajectoryPosition.NamesAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.gphTrajectoryPosition.NamesVisible = true;
            this.gphTrajectoryPosition.ScaleMode = Composants.GraphPanel.ScaleType.DynamicPerCurve;
            this.gphTrajectoryPosition.Size = new System.Drawing.Size(131, 69);
            this.gphTrajectoryPosition.TabIndex = 29;
            // 
            // btnTrajectoryGo
            // 
            this.btnTrajectoryGo.Image = global::GoBot.Properties.Resources.Play16;
            this.btnTrajectoryGo.Location = new System.Drawing.Point(56, 145);
            this.btnTrajectoryGo.Name = "btnTrajectoryGo";
            this.btnTrajectoryGo.Size = new System.Drawing.Size(47, 23);
            this.btnTrajectoryGo.TabIndex = 21;
            this.btnTrajectoryGo.Text = "Go";
            this.btnTrajectoryGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrajectoryGo.UseVisualStyleBackColor = true;
            this.btnTrajectoryGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // numPositionMin
            // 
            this.numPositionMin.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPositionMin.Location = new System.Drawing.Point(28, 74);
            this.numPositionMin.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numPositionMin.Name = "numPositionMin";
            this.numPositionMin.Size = new System.Drawing.Size(50, 20);
            this.numPositionMin.TabIndex = 32;
            this.numPositionMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numPositionMin.ValueChanged += new System.EventHandler(this.numPositionMin_ValueChanged);
            // 
            // numPositionMax
            // 
            this.numPositionMax.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPositionMax.Location = new System.Drawing.Point(217, 74);
            this.numPositionMax.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numPositionMax.Name = "numPositionMax";
            this.numPositionMax.Size = new System.Drawing.Size(50, 20);
            this.numPositionMax.TabIndex = 33;
            this.numPositionMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numPositionMax.ValueChanged += new System.EventHandler(this.numPositionMax_ValueChanged);
            // 
            // numSpeedMax
            // 
            this.numSpeedMax.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSpeedMax.Location = new System.Drawing.Point(130, 49);
            this.numSpeedMax.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numSpeedMax.Name = "numSpeedMax";
            this.numSpeedMax.Size = new System.Drawing.Size(50, 20);
            this.numSpeedMax.TabIndex = 34;
            this.numSpeedMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSpeedMax.ValueChanged += new System.EventHandler(this.numSpeedMax_ValueChanged);
            // 
            // numPosition
            // 
            this.numPosition.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numPosition.Location = new System.Drawing.Point(105, 74);
            this.numPosition.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numPosition.Name = "numPosition";
            this.numPosition.Size = new System.Drawing.Size(94, 20);
            this.numPosition.TabIndex = 36;
            this.numPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numPosition.ValueChanged += new System.EventHandler(this.numPosition_ValueChanged);
            // 
            // numAccel
            // 
            this.numAccel.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAccel.Location = new System.Drawing.Point(130, 23);
            this.numAccel.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numAccel.Name = "numAccel";
            this.numAccel.Size = new System.Drawing.Size(50, 20);
            this.numAccel.TabIndex = 37;
            this.numAccel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numAccel.ValueChanged += new System.EventHandler(this.numAccel_ValueChanged);
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.label3);
            this.grpControl.Controls.Add(this.switchButton2);
            this.grpControl.Controls.Add(this.btnAutoMax);
            this.grpControl.Controls.Add(this.btnAutoMin);
            this.grpControl.Controls.Add(this.btnStop);
            this.grpControl.Controls.Add(this.trkPosition);
            this.grpControl.Controls.Add(this.numPosition);
            this.grpControl.Controls.Add(this.lblPosMinTxt);
            this.grpControl.Controls.Add(this.lblPosMaxTxt);
            this.grpControl.Controls.Add(this.numPositionMax);
            this.grpControl.Controls.Add(this.numPositionMin);
            this.grpControl.Enabled = false;
            this.grpControl.Location = new System.Drawing.Point(3, 34);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(295, 102);
            this.grpControl.TabIndex = 38;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "Contrôle";
            // 
            // btnAutoMax
            // 
            this.btnAutoMax.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoMax.Image")));
            this.btnAutoMax.Location = new System.Drawing.Point(267, 73);
            this.btnAutoMax.Name = "btnAutoMax";
            this.btnAutoMax.Size = new System.Drawing.Size(22, 22);
            this.btnAutoMax.TabIndex = 41;
            this.btnAutoMax.UseVisualStyleBackColor = true;
            this.btnAutoMax.Click += new System.EventHandler(this.btnAutoMax_Click);
            // 
            // btnAutoMin
            // 
            this.btnAutoMin.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoMin.Image")));
            this.btnAutoMin.Location = new System.Drawing.Point(6, 73);
            this.btnAutoMin.Name = "btnAutoMin";
            this.btnAutoMin.Size = new System.Drawing.Size(22, 22);
            this.btnAutoMin.TabIndex = 40;
            this.btnAutoMin.UseVisualStyleBackColor = true;
            this.btnAutoMin.Click += new System.EventHandler(this.btnAutoMin_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = global::GoBot.Properties.Resources.Close16;
            this.btnStop.Location = new System.Drawing.Point(175, 21);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(114, 23);
            this.btnStop.TabIndex = 40;
            this.btnStop.Text = "Couper le couple";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // trkPosition
            // 
            this.trkPosition.BackColor = System.Drawing.Color.Transparent;
            this.trkPosition.DecimalPlaces = 0;
            this.trkPosition.IntervalTimer = ((uint)(25u));
            this.trkPosition.Location = new System.Drawing.Point(31, 54);
            this.trkPosition.Max = 40000D;
            this.trkPosition.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkPosition.Min = 0D;
            this.trkPosition.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkPosition.Name = "trkPosition";
            this.trkPosition.Reverse = false;
            this.trkPosition.Size = new System.Drawing.Size(232, 15);
            this.trkPosition.TabIndex = 4;
            this.trkPosition.Vertical = false;
            this.trkPosition.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarPosition_TickValueChanged);
            // 
            // lblIDTxt
            // 
            this.lblIDTxt.AutoSize = true;
            this.lblIDTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDTxt.Location = new System.Drawing.Point(175, 9);
            this.lblIDTxt.Name = "lblIDTxt";
            this.lblIDTxt.Size = new System.Drawing.Size(103, 13);
            this.lblIDTxt.TabIndex = 3;
            this.lblIDTxt.Text = "Servomoteur ID :";
            // 
            // picConnection
            // 
            this.picConnection.Image = global::GoBot.Properties.Resources.ConnectionOk;
            this.picConnection.Location = new System.Drawing.Point(324, 9);
            this.picConnection.Name = "picConnection";
            this.picConnection.Size = new System.Drawing.Size(16, 16);
            this.picConnection.TabIndex = 39;
            this.picConnection.TabStop = false;
            this.toolTip.SetToolTip(this.picConnection, "Le servomoteur demandé est introuvable...");
            this.picConnection.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(342, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 13);
            this.lblName.TabIndex = 40;
            this.lblName.Text = "Pas de connexion";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.lblSpeedUnit);
            this.grpSettings.Controls.Add(this.lblAccelUnit);
            this.grpSettings.Controls.Add(this.lblTorqueUnit);
            this.grpSettings.Controls.Add(this.lblAccelTxt);
            this.grpSettings.Controls.Add(this.numAccel);
            this.grpSettings.Controls.Add(this.lblSpeedMaxTxt);
            this.grpSettings.Controls.Add(this.numSpeedMax);
            this.grpSettings.Controls.Add(this.lblTorqueMaxTxt);
            this.grpSettings.Controls.Add(this.numTorqueMax);
            this.grpSettings.Location = new System.Drawing.Point(3, 200);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(295, 108);
            this.grpSettings.TabIndex = 41;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Réglage";
            // 
            // lblSpeedUnit
            // 
            this.lblSpeedUnit.AutoSize = true;
            this.lblSpeedUnit.Location = new System.Drawing.Point(186, 51);
            this.lblSpeedUnit.Name = "lblSpeedUnit";
            this.lblSpeedUnit.Size = new System.Drawing.Size(40, 13);
            this.lblSpeedUnit.TabIndex = 44;
            this.lblSpeedUnit.Text = "pas / s";
            // 
            // lblAccelUnit
            // 
            this.lblAccelUnit.AutoSize = true;
            this.lblAccelUnit.Location = new System.Drawing.Point(186, 25);
            this.lblAccelUnit.Name = "lblAccelUnit";
            this.lblAccelUnit.Size = new System.Drawing.Size(43, 13);
            this.lblAccelUnit.TabIndex = 43;
            this.lblAccelUnit.Text = "pas / s²";
            // 
            // grpPositions
            // 
            this.grpPositions.Controls.Add(this.btnSauvegarderPosition);
            this.grpPositions.Controls.Add(this.comboBox1);
            this.grpPositions.Location = new System.Drawing.Point(3, 142);
            this.grpPositions.Name = "grpPositions";
            this.grpPositions.Size = new System.Drawing.Size(295, 52);
            this.grpPositions.TabIndex = 42;
            this.grpPositions.TabStop = false;
            this.grpPositions.Text = "Positions";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // btnSauvegarderPosition
            // 
            this.btnSauvegarderPosition.Image = global::GoBot.Properties.Resources.Save16;
            this.btnSauvegarderPosition.Location = new System.Drawing.Point(196, 18);
            this.btnSauvegarderPosition.Name = "btnSauvegarderPosition";
            this.btnSauvegarderPosition.Size = new System.Drawing.Size(93, 23);
            this.btnSauvegarderPosition.TabIndex = 40;
            this.btnSauvegarderPosition.Text = "Sauvegarder";
            this.btnSauvegarderPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSauvegarderPosition.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSauvegarderPosition.UseVisualStyleBackColor = true;
            // 
            // switchButton2
            // 
            this.switchButton2.AutoSize = true;
            this.switchButton2.BackColor = System.Drawing.Color.Transparent;
            this.switchButton2.Location = new System.Drawing.Point(11, 25);
            this.switchButton2.MaximumSize = new System.Drawing.Size(35, 15);
            this.switchButton2.MinimumSize = new System.Drawing.Size(35, 15);
            this.switchButton2.Mirrored = true;
            this.switchButton2.Name = "switchButton2";
            this.switchButton2.Size = new System.Drawing.Size(35, 15);
            this.switchButton2.TabIndex = 43;
            this.switchButton2.Value = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Contrôle par codeur";
            // 
            // PanelServoCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpPositions);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picConnection);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.grpTrajectory);
            this.Controls.Add(this.numID);
            this.Controls.Add(this.grpMonitoring);
            this.Controls.Add(this.lblIDTxt);
            this.Name = "PanelServoCan";
            this.Size = new System.Drawing.Size(603, 490);
            this.Load += new System.EventHandler(this.PanelServoCan_Load);
            this.grpMonitoring.ResumeLayout(false);
            this.grpMonitoring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTorqueMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).EndInit();
            this.grpTrajectory.ResumeLayout(false);
            this.grpTrajectory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccel)).EndInit();
            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConnection)).EndInit();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.grpPositions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Composants.SwitchButton boxMonitoring;
        private System.Windows.Forms.GroupBox grpMonitoring;
        private System.Windows.Forms.NumericUpDown numID;
        private Composants.LabelPlus lblIDTxt;
        private Composants.GraphPanel gphMonitoringPos;
        private Composants.TrackBarPlus trkPosition;
        private System.Windows.Forms.Button btnTrajectoryGo;
        private System.Windows.Forms.Label lblPosMinTxt;
        private System.Windows.Forms.Label lblSpeedMaxTxt;
        private System.Windows.Forms.Label lblPosMaxTxt;
        private System.Windows.Forms.Label lblTorqueMaxTxt;
        private System.Windows.Forms.Label lblAccelTxt;
        private Composants.GraphPanel gphTrajectorySpeed;
        private System.Windows.Forms.GroupBox grpTrajectory;
        private System.Windows.Forms.Label lblTrajectoryAccelTxt;
        private System.Windows.Forms.Label lblTrajectorySpeedTxt;
        private System.Windows.Forms.Label lblTrajectoryTargetTxt;
        private System.Windows.Forms.Label lblTrajectoryAccel;
        private System.Windows.Forms.Label lblTrajectorySpeed;
        private System.Windows.Forms.Label lblTrajectoryTarget;
        private Composants.TrackBarPlus trkTrajectoryAccel;
        private Composants.TrackBarPlus trkTrajectorySpeed;
        private Composants.TrackBarPlus trkTrajectoryTarget;
        private System.Windows.Forms.NumericUpDown numPositionMin;
        private System.Windows.Forms.NumericUpDown numPositionMax;
        private System.Windows.Forms.NumericUpDown numSpeedMax;
        private System.Windows.Forms.NumericUpDown numTorqueMax;
        private System.Windows.Forms.NumericUpDown numPosition;
        private System.Windows.Forms.NumericUpDown numAccel;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Label lblTrajectoryTime;
        private Composants.GraphPanel gphTrajectoryPosition;
        private System.Windows.Forms.PictureBox picArrow;
        private System.Windows.Forms.PictureBox picConnection;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnStop;
        private Composants.GraphPanel gphMonitoringTorque;
        private System.Windows.Forms.Button btnAutoMin;
        private System.Windows.Forms.Label lblTorqueUnit;
        private System.Windows.Forms.Button btnAutoMax;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Label lblSpeedUnit;
        private System.Windows.Forms.Label lblAccelUnit;
        private System.Windows.Forms.Label label2;
        private Composants.SwitchButton switchButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpPositions;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSauvegarderPosition;
        private System.Windows.Forms.Label label3;
        private Composants.SwitchButton switchButton2;
    }
}
