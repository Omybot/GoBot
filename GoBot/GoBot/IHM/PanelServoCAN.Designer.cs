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
            this.grpMonitoring = new System.Windows.Forms.GroupBox();
            this.numID = new System.Windows.Forms.NumericUpDown();
            this.lblPositionTxt = new System.Windows.Forms.Label();
            this.lblPosMinTxt = new System.Windows.Forms.Label();
            this.lblSpeedMaxTxt = new System.Windows.Forms.Label();
            this.lblPosMaxTxt = new System.Windows.Forms.Label();
            this.lblTorqueMaxTxt = new System.Windows.Forms.Label();
            this.lblAccelTxt = new System.Windows.Forms.Label();
            this.grpTrajectory = new System.Windows.Forms.GroupBox();
            this.lblTrajectoryTime = new System.Windows.Forms.Label();
            this.lblTrajectoryAccelTxt = new System.Windows.Forms.Label();
            this.lblTrajectorySpeedTxt = new System.Windows.Forms.Label();
            this.lblTrajectoryTargetTxt = new System.Windows.Forms.Label();
            this.lblTrajectoryAccel = new System.Windows.Forms.Label();
            this.lblTrajectorySpeed = new System.Windows.Forms.Label();
            this.lblTrajectoryTarget = new System.Windows.Forms.Label();
            this.numPositionMin = new System.Windows.Forms.NumericUpDown();
            this.numPositionMax = new System.Windows.Forms.NumericUpDown();
            this.numSpeedMax = new System.Windows.Forms.NumericUpDown();
            this.numTorqueMax = new System.Windows.Forms.NumericUpDown();
            this.numPosition = new System.Windows.Forms.NumericUpDown();
            this.numAccel = new System.Windows.Forms.NumericUpDown();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.lblAutoScale = new System.Windows.Forms.Label();
            this.trkPosition = new Composants.TrackBarPlus();
            this.trkTrajectoryAccel = new Composants.TrackBarPlus();
            this.trkTrajectorySpeed = new Composants.TrackBarPlus();
            this.trkTrajectoryTarget = new Composants.TrackBarPlus();
            this.gphTrajectorySpeed = new Composants.GraphPanel();
            this.gphTrajectoryPosition = new Composants.GraphPanel();
            this.boxAutoScale = new Composants.SwitchButton();
            this.gphMonitoring = new Composants.GraphPanel();
            this.boxMonitoring = new Composants.SwitchButton();
            this.lblIDTxt = new Composants.LabelPlus();
            this.picWarning = new System.Windows.Forms.PictureBox();
            this.btnReadValue = new System.Windows.Forms.Button();
            this.picArrow = new System.Windows.Forms.PictureBox();
            this.btnTrajectoryGo = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grpMonitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).BeginInit();
            this.grpTrajectory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTorqueMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccel)).BeginInit();
            this.grpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMonitoring
            // 
            this.grpMonitoring.Controls.Add(this.lblAutoScale);
            this.grpMonitoring.Controls.Add(this.boxAutoScale);
            this.grpMonitoring.Controls.Add(this.gphMonitoring);
            this.grpMonitoring.Controls.Add(this.boxMonitoring);
            this.grpMonitoring.Enabled = false;
            this.grpMonitoring.Location = new System.Drawing.Point(3, 167);
            this.grpMonitoring.Name = "grpMonitoring";
            this.grpMonitoring.Size = new System.Drawing.Size(295, 142);
            this.grpMonitoring.TabIndex = 1;
            this.grpMonitoring.TabStop = false;
            this.grpMonitoring.Text = "Monitoring";
            // 
            // numID
            // 
            this.numID.Location = new System.Drawing.Point(168, 8);
            this.numID.Name = "numID";
            this.numID.Size = new System.Drawing.Size(50, 20);
            this.numID.TabIndex = 2;
            this.numID.ValueChanged += new System.EventHandler(this.numID_ValueChanged);
            // 
            // lblPositionTxt
            // 
            this.lblPositionTxt.AutoSize = true;
            this.lblPositionTxt.Location = new System.Drawing.Point(9, 23);
            this.lblPositionTxt.Name = "lblPositionTxt";
            this.lblPositionTxt.Size = new System.Drawing.Size(44, 13);
            this.lblPositionTxt.TabIndex = 5;
            this.lblPositionTxt.Text = "Position";
            // 
            // lblPosMinTxt
            // 
            this.lblPosMinTxt.AutoSize = true;
            this.lblPosMinTxt.Location = new System.Drawing.Point(9, 49);
            this.lblPosMinTxt.Name = "lblPosMinTxt";
            this.lblPosMinTxt.Size = new System.Drawing.Size(63, 13);
            this.lblPosMinTxt.TabIndex = 23;
            this.lblPosMinTxt.Text = "Position min";
            // 
            // lblSpeedMaxTxt
            // 
            this.lblSpeedMaxTxt.AutoSize = true;
            this.lblSpeedMaxTxt.Location = new System.Drawing.Point(165, 49);
            this.lblSpeedMaxTxt.Name = "lblSpeedMaxTxt";
            this.lblSpeedMaxTxt.Size = new System.Drawing.Size(63, 13);
            this.lblSpeedMaxTxt.TabIndex = 24;
            this.lblSpeedMaxTxt.Text = "Vitesse max";
            // 
            // lblPosMaxTxt
            // 
            this.lblPosMaxTxt.AutoSize = true;
            this.lblPosMaxTxt.Location = new System.Drawing.Point(9, 75);
            this.lblPosMaxTxt.Name = "lblPosMaxTxt";
            this.lblPosMaxTxt.Size = new System.Drawing.Size(66, 13);
            this.lblPosMaxTxt.TabIndex = 25;
            this.lblPosMaxTxt.Text = "Position max";
            // 
            // lblTorqueMaxTxt
            // 
            this.lblTorqueMaxTxt.AutoSize = true;
            this.lblTorqueMaxTxt.Location = new System.Drawing.Point(166, 75);
            this.lblTorqueMaxTxt.Name = "lblTorqueMaxTxt";
            this.lblTorqueMaxTxt.Size = new System.Drawing.Size(62, 13);
            this.lblTorqueMaxTxt.TabIndex = 26;
            this.lblTorqueMaxTxt.Text = "Couple max";
            // 
            // lblAccelTxt
            // 
            this.lblAccelTxt.AutoSize = true;
            this.lblAccelTxt.Location = new System.Drawing.Point(9, 101);
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
            this.grpTrajectory.Location = new System.Drawing.Point(3, 315);
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
            // numPositionMin
            // 
            this.numPositionMin.Location = new System.Drawing.Point(89, 47);
            this.numPositionMin.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numPositionMin.Name = "numPositionMin";
            this.numPositionMin.Size = new System.Drawing.Size(50, 20);
            this.numPositionMin.TabIndex = 32;
            this.numPositionMin.ValueChanged += new System.EventHandler(this.numPositionMin_ValueChanged);
            // 
            // numPositionMax
            // 
            this.numPositionMax.Location = new System.Drawing.Point(89, 73);
            this.numPositionMax.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numPositionMax.Name = "numPositionMax";
            this.numPositionMax.Size = new System.Drawing.Size(50, 20);
            this.numPositionMax.TabIndex = 33;
            this.numPositionMax.ValueChanged += new System.EventHandler(this.numPositionMax_ValueChanged);
            // 
            // numSpeedMax
            // 
            this.numSpeedMax.Location = new System.Drawing.Point(234, 47);
            this.numSpeedMax.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numSpeedMax.Name = "numSpeedMax";
            this.numSpeedMax.Size = new System.Drawing.Size(50, 20);
            this.numSpeedMax.TabIndex = 34;
            this.numSpeedMax.ValueChanged += new System.EventHandler(this.numSpeedMax_ValueChanged);
            // 
            // numTorqueMax
            // 
            this.numTorqueMax.Location = new System.Drawing.Point(234, 73);
            this.numTorqueMax.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numTorqueMax.Name = "numTorqueMax";
            this.numTorqueMax.Size = new System.Drawing.Size(50, 20);
            this.numTorqueMax.TabIndex = 35;
            this.numTorqueMax.ValueChanged += new System.EventHandler(this.numTorqueMax_ValueChanged);
            // 
            // numPosition
            // 
            this.numPosition.Location = new System.Drawing.Point(89, 21);
            this.numPosition.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numPosition.Name = "numPosition";
            this.numPosition.Size = new System.Drawing.Size(50, 20);
            this.numPosition.TabIndex = 36;
            this.numPosition.ValueChanged += new System.EventHandler(this.numPosition_ValueChanged);
            // 
            // numAccel
            // 
            this.numAccel.Location = new System.Drawing.Point(89, 99);
            this.numAccel.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numAccel.Name = "numAccel";
            this.numAccel.Size = new System.Drawing.Size(50, 20);
            this.numAccel.TabIndex = 37;
            this.numAccel.ValueChanged += new System.EventHandler(this.numAccel_ValueChanged);
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.btnReadValue);
            this.grpControl.Controls.Add(this.lblPositionTxt);
            this.grpControl.Controls.Add(this.numAccel);
            this.grpControl.Controls.Add(this.trkPosition);
            this.grpControl.Controls.Add(this.numPosition);
            this.grpControl.Controls.Add(this.lblPosMinTxt);
            this.grpControl.Controls.Add(this.numTorqueMax);
            this.grpControl.Controls.Add(this.lblSpeedMaxTxt);
            this.grpControl.Controls.Add(this.numSpeedMax);
            this.grpControl.Controls.Add(this.lblPosMaxTxt);
            this.grpControl.Controls.Add(this.numPositionMax);
            this.grpControl.Controls.Add(this.lblTorqueMaxTxt);
            this.grpControl.Controls.Add(this.numPositionMin);
            this.grpControl.Controls.Add(this.lblAccelTxt);
            this.grpControl.Enabled = false;
            this.grpControl.Location = new System.Drawing.Point(3, 34);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(295, 127);
            this.grpControl.TabIndex = 38;
            this.grpControl.TabStop = false;
            this.grpControl.Text = "Contrôle";
            // 
            // lblAutoScale
            // 
            this.lblAutoScale.AutoSize = true;
            this.lblAutoScale.Location = new System.Drawing.Point(187, 0);
            this.lblAutoScale.Name = "lblAutoScale";
            this.lblAutoScale.Size = new System.Drawing.Size(61, 13);
            this.lblAutoScale.TabIndex = 6;
            this.lblAutoScale.Text = "Echelle fixe";
            // 
            // trkPosition
            // 
            this.trkPosition.BackColor = System.Drawing.Color.Transparent;
            this.trkPosition.DecimalPlaces = 0;
            this.trkPosition.IntervalTimer = ((uint)(25u));
            this.trkPosition.Location = new System.Drawing.Point(148, 23);
            this.trkPosition.Max = 40000D;
            this.trkPosition.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkPosition.Min = 0D;
            this.trkPosition.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkPosition.Name = "trkPosition";
            this.trkPosition.Reverse = false;
            this.trkPosition.Size = new System.Drawing.Size(136, 15);
            this.trkPosition.TabIndex = 4;
            this.trkPosition.Vertical = false;
            this.trkPosition.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarPosition_TickValueChanged);
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
            this.gphTrajectorySpeed.GraphScale = Composants.GraphPanel.ScaleType.DynamicPerCurve;
            this.gphTrajectorySpeed.LimitsVisible = true;
            this.gphTrajectorySpeed.Location = new System.Drawing.Point(158, 12);
            this.gphTrajectorySpeed.MaxLimit = 1D;
            this.gphTrajectorySpeed.MinLimit = 0D;
            this.gphTrajectorySpeed.Name = "gphTrajectorySpeed";
            this.gphTrajectorySpeed.NamesAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.gphTrajectorySpeed.NamesVisible = true;
            this.gphTrajectorySpeed.Size = new System.Drawing.Size(131, 69);
            this.gphTrajectorySpeed.TabIndex = 5;
            // 
            // gphTrajectoryPosition
            // 
            this.gphTrajectoryPosition.BackColor = System.Drawing.Color.White;
            this.gphTrajectoryPosition.BorderColor = System.Drawing.Color.LightGray;
            this.gphTrajectoryPosition.BorderVisible = false;
            this.gphTrajectoryPosition.GraphScale = Composants.GraphPanel.ScaleType.DynamicPerCurve;
            this.gphTrajectoryPosition.LimitsVisible = true;
            this.gphTrajectoryPosition.Location = new System.Drawing.Point(158, 82);
            this.gphTrajectoryPosition.MaxLimit = 1D;
            this.gphTrajectoryPosition.MinLimit = 0D;
            this.gphTrajectoryPosition.Name = "gphTrajectoryPosition";
            this.gphTrajectoryPosition.NamesAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.gphTrajectoryPosition.NamesVisible = true;
            this.gphTrajectoryPosition.Size = new System.Drawing.Size(131, 69);
            this.gphTrajectoryPosition.TabIndex = 29;
            // 
            // boxAutoScale
            // 
            this.boxAutoScale.AutoSize = true;
            this.boxAutoScale.BackColor = System.Drawing.Color.Transparent;
            this.boxAutoScale.Location = new System.Drawing.Point(254, 0);
            this.boxAutoScale.MaximumSize = new System.Drawing.Size(35, 15);
            this.boxAutoScale.MinimumSize = new System.Drawing.Size(35, 15);
            this.boxAutoScale.Mirrored = true;
            this.boxAutoScale.Name = "boxAutoScale";
            this.boxAutoScale.Size = new System.Drawing.Size(35, 15);
            this.boxAutoScale.TabIndex = 5;
            this.boxAutoScale.Value = false;
            this.boxAutoScale.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.boxAutoScale_ValueChanged);
            // 
            // gphMonitoring
            // 
            this.gphMonitoring.BackColor = System.Drawing.Color.White;
            this.gphMonitoring.BorderColor = System.Drawing.Color.LightGray;
            this.gphMonitoring.BorderVisible = false;
            this.gphMonitoring.GraphScale = Composants.GraphPanel.ScaleType.DynamicPerCurve;
            this.gphMonitoring.LimitsVisible = true;
            this.gphMonitoring.Location = new System.Drawing.Point(8, 21);
            this.gphMonitoring.MaxLimit = 1D;
            this.gphMonitoring.MinLimit = 0D;
            this.gphMonitoring.Name = "gphMonitoring";
            this.gphMonitoring.NamesAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.gphMonitoring.NamesVisible = true;
            this.gphMonitoring.Size = new System.Drawing.Size(281, 115);
            this.gphMonitoring.TabIndex = 4;
            // 
            // boxMonitoring
            // 
            this.boxMonitoring.AutoSize = true;
            this.boxMonitoring.BackColor = System.Drawing.Color.Transparent;
            this.boxMonitoring.Location = new System.Drawing.Point(68, 0);
            this.boxMonitoring.MaximumSize = new System.Drawing.Size(35, 15);
            this.boxMonitoring.MinimumSize = new System.Drawing.Size(35, 15);
            this.boxMonitoring.Mirrored = true;
            this.boxMonitoring.Name = "boxMonitoring";
            this.boxMonitoring.Size = new System.Drawing.Size(35, 15);
            this.boxMonitoring.TabIndex = 0;
            this.boxMonitoring.Value = false;
            this.boxMonitoring.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.boxTorque_ValueChanged);
            // 
            // lblIDTxt
            // 
            this.lblIDTxt.AutoSize = true;
            this.lblIDTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDTxt.Location = new System.Drawing.Point(59, 10);
            this.lblIDTxt.Name = "lblIDTxt";
            this.lblIDTxt.Size = new System.Drawing.Size(103, 13);
            this.lblIDTxt.TabIndex = 3;
            this.lblIDTxt.Text = "Servomoteur ID :";
            // 
            // picWarning
            // 
            this.picWarning.Image = global::GoBot.Properties.Resources.Warning24;
            this.picWarning.Location = new System.Drawing.Point(221, 5);
            this.picWarning.Name = "picWarning";
            this.picWarning.Size = new System.Drawing.Size(25, 25);
            this.picWarning.TabIndex = 39;
            this.picWarning.TabStop = false;
            this.toolTip.SetToolTip(this.picWarning, "Le servomoteur demandé est introuvable...");
            this.picWarning.Visible = false;
            // 
            // btnReadValue
            // 
            this.btnReadValue.Image = global::GoBot.Properties.Resources.Refresh16;
            this.btnReadValue.Location = new System.Drawing.Point(169, 98);
            this.btnReadValue.Name = "btnReadValue";
            this.btnReadValue.Size = new System.Drawing.Size(115, 24);
            this.btnReadValue.TabIndex = 39;
            this.btnReadValue.Text = "Lire les valeurs";
            this.btnReadValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReadValue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadValue.UseVisualStyleBackColor = true;
            this.btnReadValue.Click += new System.EventHandler(this.btnReadValue_Click);
            // 
            // picArrow
            // 
            this.picArrow.Location = new System.Drawing.Point(158, 153);
            this.picArrow.Name = "picArrow";
            this.picArrow.Size = new System.Drawing.Size(131, 15);
            this.picArrow.TabIndex = 41;
            this.picArrow.TabStop = false;
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
            // PanelServoCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picWarning);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.grpTrajectory);
            this.Controls.Add(this.numID);
            this.Controls.Add(this.grpMonitoring);
            this.Controls.Add(this.lblIDTxt);
            this.Name = "PanelServoCan";
            this.Size = new System.Drawing.Size(302, 491);
            this.grpMonitoring.ResumeLayout(false);
            this.grpMonitoring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).EndInit();
            this.grpTrajectory.ResumeLayout(false);
            this.grpTrajectory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPositionMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTorqueMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccel)).EndInit();
            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Composants.SwitchButton boxMonitoring;
        private System.Windows.Forms.GroupBox grpMonitoring;
        private System.Windows.Forms.NumericUpDown numID;
        private Composants.LabelPlus lblIDTxt;
        private Composants.GraphPanel gphMonitoring;
        private Composants.TrackBarPlus trkPosition;
        private System.Windows.Forms.Label lblPositionTxt;
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
        private System.Windows.Forms.Button btnReadValue;
        private System.Windows.Forms.Label lblTrajectoryTime;
        private Composants.GraphPanel gphTrajectoryPosition;
        private System.Windows.Forms.PictureBox picArrow;
        private System.Windows.Forms.Label lblAutoScale;
        private Composants.SwitchButton boxAutoScale;
        private System.Windows.Forms.PictureBox picWarning;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
