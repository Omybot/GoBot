namespace GoBot.IHM
{
    partial class PanelDisplacement
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
            this.contextMenuStop = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.freelyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abruptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPIDVit = new System.Windows.Forms.Button();
            this.btnPIDPol = new System.Windows.Forms.Button();
            this.trkLineDecel = new Composants.TrackBarPlus();
            this.numLineDecel = new System.Windows.Forms.NumericUpDown();
            this.lblLineDecel = new System.Windows.Forms.Label();
            this.btnFast = new System.Windows.Forms.Button();
            this.btnLow = new System.Windows.Forms.Button();
            this.btnGoTo = new System.Windows.Forms.Button();
            this.numTeta = new System.Windows.Forms.NumericUpDown();
            this.lblGoToTheta = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.lblGoToY = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.lblGoToX = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPIDXY = new System.Windows.Forms.Button();
            this.pnlManual = new Composants.FocusablePanel();
            this.lblManual = new System.Windows.Forms.Label();
            this.numCoeffD = new System.Windows.Forms.NumericUpDown();
            this.trkLineAccel = new Composants.TrackBarPlus();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnCalibration = new System.Windows.Forms.Button();
            this.lblPIDD = new System.Windows.Forms.Label();
            this.trkLineSpeed = new Composants.TrackBarPlus();
            this.txtDistance = new Composants.TextBoxPlus();
            this.numLineSpeed = new System.Windows.Forms.NumericUpDown();
            this.numCoeffI = new System.Windows.Forms.NumericUpDown();
            this.numLineAccel = new System.Windows.Forms.NumericUpDown();
            this.txtAngle = new Composants.TextBoxPlus();
            this.btnTurnBackwardRight = new System.Windows.Forms.Button();
            this.lblPIDI = new System.Windows.Forms.Label();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnPivotLeft = new System.Windows.Forms.Button();
            this.numCoeffP = new System.Windows.Forms.NumericUpDown();
            this.btnTurnForwardRight = new System.Windows.Forms.Button();
            this.btnTurnBackwardLeft = new System.Windows.Forms.Button();
            this.lblPIDP = new System.Windows.Forms.Label();
            this.trkPivotSpeed = new Composants.TrackBarPlus();
            this.btnTurnForwardLeft = new System.Windows.Forms.Button();
            this.lblLineAccel = new System.Windows.Forms.Label();
            this.numPivotAccel = new System.Windows.Forms.NumericUpDown();
            this.trkPivotAccel = new Composants.TrackBarPlus();
            this.lblLineSpeed = new System.Windows.Forms.Label();
            this.btnPivotRight = new System.Windows.Forms.Button();
            this.numPivotSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblPivotSpeed = new System.Windows.Forms.Label();
            this.lblPivotAccel = new System.Windows.Forms.Label();
            this.grpDisplacement = new System.Windows.Forms.GroupBox();
            this.contextMenuStop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLineDecel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineAccel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPivotAccel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPivotSpeed)).BeginInit();
            this.grpDisplacement.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStop
            // 
            this.contextMenuStop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freelyToolStripMenuItem,
            this.smoothToolStripMenuItem,
            this.abruptToolStripMenuItem});
            this.contextMenuStop.Name = "contextMenuStrip1";
            this.contextMenuStop.Size = new System.Drawing.Size(117, 70);
            // 
            // freelyToolStripMenuItem
            // 
            this.freelyToolStripMenuItem.Checked = true;
            this.freelyToolStripMenuItem.CheckOnClick = true;
            this.freelyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.freelyToolStripMenuItem.Name = "freelyToolStripMenuItem";
            this.freelyToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.freelyToolStripMenuItem.Text = "Freely";
            this.freelyToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // smoothToolStripMenuItem
            // 
            this.smoothToolStripMenuItem.CheckOnClick = true;
            this.smoothToolStripMenuItem.Name = "smoothToolStripMenuItem";
            this.smoothToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.smoothToolStripMenuItem.Text = "Smooth";
            this.smoothToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // abruptToolStripMenuItem
            // 
            this.abruptToolStripMenuItem.CheckOnClick = true;
            this.abruptToolStripMenuItem.Name = "abruptToolStripMenuItem";
            this.abruptToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.abruptToolStripMenuItem.Text = "Abrupt";
            this.abruptToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // btnPIDVit
            // 
            this.btnPIDVit.Location = new System.Drawing.Point(279, 378);
            this.btnPIDVit.Name = "btnPIDVit";
            this.btnPIDVit.Size = new System.Drawing.Size(35, 23);
            this.btnPIDVit.TabIndex = 123;
            this.btnPIDVit.Text = "Vit";
            this.btnPIDVit.UseVisualStyleBackColor = true;
            this.btnPIDVit.Click += new System.EventHandler(this.btnPIDVit_Click);
            // 
            // btnPIDPol
            // 
            this.btnPIDPol.Location = new System.Drawing.Point(243, 378);
            this.btnPIDPol.Name = "btnPIDPol";
            this.btnPIDPol.Size = new System.Drawing.Size(35, 23);
            this.btnPIDPol.TabIndex = 122;
            this.btnPIDPol.Text = "Cap";
            this.btnPIDPol.UseVisualStyleBackColor = true;
            this.btnPIDPol.Click += new System.EventHandler(this.btnPIDPol_Click);
            // 
            // trkLineDecel
            // 
            this.trkLineDecel.BackColor = System.Drawing.Color.Transparent;
            this.trkLineDecel.DecimalPlaces = 0;
            this.trkLineDecel.IntervalTimer = ((uint)(500u));
            this.trkLineDecel.Location = new System.Drawing.Point(9, 274);
            this.trkLineDecel.Max = 5000D;
            this.trkLineDecel.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkLineDecel.Min = 0D;
            this.trkLineDecel.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkLineDecel.Name = "trkLineDecel";
            this.trkLineDecel.Reverse = false;
            this.trkLineDecel.Size = new System.Drawing.Size(250, 15);
            this.trkLineDecel.TabIndex = 120;
            this.trkLineDecel.Vertical = false;
            this.trkLineDecel.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkLineDecel_TickValueChanged);
            this.trkLineDecel.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkLineDecel_ValueChanged);
            // 
            // numLineDecel
            // 
            this.numLineDecel.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numLineDecel.Location = new System.Drawing.Point(264, 269);
            this.numLineDecel.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numLineDecel.Name = "numLineDecel";
            this.numLineDecel.Size = new System.Drawing.Size(51, 20);
            this.numLineDecel.TabIndex = 121;
            this.numLineDecel.ValueChanged += new System.EventHandler(this.numLineDecel_ValueChanged);
            // 
            // lblLineDecel
            // 
            this.lblLineDecel.Location = new System.Drawing.Point(9, 258);
            this.lblLineDecel.Name = "lblLineDecel";
            this.lblLineDecel.Size = new System.Drawing.Size(250, 13);
            this.lblLineDecel.TabIndex = 119;
            this.lblLineDecel.Text = "Décéleration ligne";
            this.lblLineDecel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFast
            // 
            this.btnFast.Image = global::GoBot.Properties.Resources.Rabbit;
            this.btnFast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFast.Location = new System.Drawing.Point(75, 413);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(74, 23);
            this.btnFast.TabIndex = 118;
            this.btnFast.Text = "Rapide";
            this.btnFast.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFast.UseVisualStyleBackColor = true;
            this.btnFast.Click += new System.EventHandler(this.btnFast_Click);
            // 
            // btnLow
            // 
            this.btnLow.Image = global::GoBot.Properties.Resources.Turtle;
            this.btnLow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLow.Location = new System.Drawing.Point(5, 413);
            this.btnLow.Name = "btnLow";
            this.btnLow.Size = new System.Drawing.Size(64, 23);
            this.btnLow.TabIndex = 117;
            this.btnLow.Text = "Lent";
            this.btnLow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLow.UseVisualStyleBackColor = true;
            this.btnLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // btnGoTo
            // 
            this.btnGoTo.Location = new System.Drawing.Point(253, 149);
            this.btnGoTo.Name = "btnGoTo";
            this.btnGoTo.Size = new System.Drawing.Size(53, 23);
            this.btnGoTo.TabIndex = 116;
            this.btnGoTo.Text = "Go";
            this.btnGoTo.UseVisualStyleBackColor = true;
            this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
            // 
            // numTeta
            // 
            this.numTeta.DecimalPlaces = 2;
            this.numTeta.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTeta.Location = new System.Drawing.Point(194, 151);
            this.numTeta.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numTeta.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numTeta.Name = "numTeta";
            this.numTeta.Size = new System.Drawing.Size(51, 20);
            this.numTeta.TabIndex = 115;
            // 
            // lblGoToTheta
            // 
            this.lblGoToTheta.AutoSize = true;
            this.lblGoToTheta.Location = new System.Drawing.Point(173, 153);
            this.lblGoToTheta.Name = "lblGoToTheta";
            this.lblGoToTheta.Size = new System.Drawing.Size(14, 13);
            this.lblGoToTheta.TabIndex = 114;
            this.lblGoToTheta.Text = "T";
            // 
            // numY
            // 
            this.numY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numY.Location = new System.Drawing.Point(115, 151);
            this.numY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(51, 20);
            this.numY.TabIndex = 113;
            // 
            // lblGoToY
            // 
            this.lblGoToY.AutoSize = true;
            this.lblGoToY.Location = new System.Drawing.Point(99, 153);
            this.lblGoToY.Name = "lblGoToY";
            this.lblGoToY.Size = new System.Drawing.Size(14, 13);
            this.lblGoToY.TabIndex = 112;
            this.lblGoToY.Text = "Y";
            // 
            // numX
            // 
            this.numX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numX.Location = new System.Drawing.Point(42, 151);
            this.numX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(51, 20);
            this.numX.TabIndex = 111;
            // 
            // lblGoToX
            // 
            this.lblGoToX.AutoSize = true;
            this.lblGoToX.Location = new System.Drawing.Point(22, 153);
            this.lblGoToX.Name = "lblGoToX";
            this.lblGoToX.Size = new System.Drawing.Size(14, 13);
            this.lblGoToX.TabIndex = 110;
            this.lblGoToX.Text = "X";
            // 
            // btnStop
            // 
            this.btnStop.ContextMenuStrip = this.contextMenuStop;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.Image = global::GoBot.Properties.Resources.Stop;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.Location = new System.Drawing.Point(24, 29);
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(97, 97);
            this.btnStop.TabIndex = 63;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStopSmooth_Click);
            // 
            // btnPIDXY
            // 
            this.btnPIDXY.Location = new System.Drawing.Point(207, 378);
            this.btnPIDXY.Name = "btnPIDXY";
            this.btnPIDXY.Size = new System.Drawing.Size(35, 23);
            this.btnPIDXY.TabIndex = 109;
            this.btnPIDXY.Text = "XY";
            this.btnPIDXY.UseVisualStyleBackColor = true;
            this.btnPIDXY.Click += new System.EventHandler(this.btnPIDXY_Click);
            // 
            // pnlManual
            // 
            this.pnlManual.BackColor = System.Drawing.Color.LightGray;
            this.pnlManual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlManual.Location = new System.Drawing.Point(259, 414);
            this.pnlManual.Name = "pnlManual";
            this.pnlManual.Size = new System.Drawing.Size(56, 22);
            this.pnlManual.TabIndex = 91;
            this.pnlManual.KeyPressed += new Composants.FocusablePanel.KeyPressedDelegate(this.pnlManual_KeyPressed);
            this.pnlManual.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pnlManual_KeyUp);
            // 
            // lblManual
            // 
            this.lblManual.AutoSize = true;
            this.lblManual.Location = new System.Drawing.Point(164, 418);
            this.lblManual.Name = "lblManual";
            this.lblManual.Size = new System.Drawing.Size(89, 13);
            this.lblManual.TabIndex = 92;
            this.lblManual.Text = "Contrôle manuel :";
            // 
            // numCoeffD
            // 
            this.numCoeffD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoeffD.Location = new System.Drawing.Point(148, 378);
            this.numCoeffD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCoeffD.Name = "numCoeffD";
            this.numCoeffD.Size = new System.Drawing.Size(45, 20);
            this.numCoeffD.TabIndex = 108;
            this.numCoeffD.ValueChanged += new System.EventHandler(this.numCoeffPID_ValueChanged);
            // 
            // trkLineAccel
            // 
            this.trkLineAccel.BackColor = System.Drawing.Color.Transparent;
            this.trkLineAccel.DecimalPlaces = 0;
            this.trkLineAccel.IntervalTimer = ((uint)(500u));
            this.trkLineAccel.Location = new System.Drawing.Point(9, 239);
            this.trkLineAccel.Max = 5000D;
            this.trkLineAccel.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkLineAccel.Min = 0D;
            this.trkLineAccel.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkLineAccel.Name = "trkLineAccel";
            this.trkLineAccel.Reverse = false;
            this.trkLineAccel.Size = new System.Drawing.Size(250, 15);
            this.trkLineAccel.TabIndex = 88;
            this.trkLineAccel.Vertical = false;
            this.trkLineAccel.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkLineAccel_TickValueChanged);
            this.trkLineAccel.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkLineAccel_ValueChanged);
            // 
            // btnForward
            // 
            this.btnForward.Image = global::GoBot.Properties.Resources.UpGreen16;
            this.btnForward.Location = new System.Drawing.Point(178, 24);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(67, 23);
            this.btnForward.TabIndex = 75;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnCalibration
            // 
            this.btnCalibration.Image = global::GoBot.Properties.Resources.BottomLine16;
            this.btnCalibration.Location = new System.Drawing.Point(285, 103);
            this.btnCalibration.Name = "btnCalibration";
            this.btnCalibration.Size = new System.Drawing.Size(30, 23);
            this.btnCalibration.TabIndex = 93;
            this.btnCalibration.UseVisualStyleBackColor = true;
            this.btnCalibration.Click += new System.EventHandler(this.btnCalibration_Click);
            // 
            // lblPIDD
            // 
            this.lblPIDD.AutoSize = true;
            this.lblPIDD.Location = new System.Drawing.Point(130, 380);
            this.lblPIDD.Name = "lblPIDD";
            this.lblPIDD.Size = new System.Drawing.Size(15, 13);
            this.lblPIDD.TabIndex = 107;
            this.lblPIDD.Text = "D";
            // 
            // trkLineSpeed
            // 
            this.trkLineSpeed.BackColor = System.Drawing.Color.Transparent;
            this.trkLineSpeed.DecimalPlaces = 0;
            this.trkLineSpeed.IntervalTimer = ((uint)(500u));
            this.trkLineSpeed.Location = new System.Drawing.Point(9, 204);
            this.trkLineSpeed.Max = 3000D;
            this.trkLineSpeed.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkLineSpeed.Min = 0D;
            this.trkLineSpeed.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkLineSpeed.Name = "trkLineSpeed";
            this.trkLineSpeed.Reverse = false;
            this.trkLineSpeed.Size = new System.Drawing.Size(250, 15);
            this.trkLineSpeed.TabIndex = 87;
            this.trkLineSpeed.Vertical = false;
            this.trkLineSpeed.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkLineSpeed_TickValueChanged);
            this.trkLineSpeed.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkLineSpeed_ValueChanged);
            // 
            // txtDistance
            // 
            this.txtDistance.BackColor = System.Drawing.Color.White;
            this.txtDistance.DefaultText = "Distance";
            this.txtDistance.ErrorMode = false;
            this.txtDistance.ForeColor = System.Drawing.Color.LightGray;
            this.txtDistance.Location = new System.Drawing.Point(178, 53);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(67, 20);
            this.txtDistance.TabIndex = 76;
            this.txtDistance.Text = "Distance";
            this.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDistance.TextMode = Composants.TextBoxPlus.TextModeEnum.Numeric;
            // 
            // numLineSpeed
            // 
            this.numLineSpeed.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numLineSpeed.Location = new System.Drawing.Point(264, 199);
            this.numLineSpeed.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numLineSpeed.Name = "numLineSpeed";
            this.numLineSpeed.Size = new System.Drawing.Size(51, 20);
            this.numLineSpeed.TabIndex = 95;
            this.numLineSpeed.ValueChanged += new System.EventHandler(this.numLineSpeed_ValueChanged);
            // 
            // numCoeffI
            // 
            this.numCoeffI.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoeffI.Location = new System.Drawing.Point(80, 378);
            this.numCoeffI.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCoeffI.Name = "numCoeffI";
            this.numCoeffI.Size = new System.Drawing.Size(45, 20);
            this.numCoeffI.TabIndex = 106;
            this.numCoeffI.ValueChanged += new System.EventHandler(this.numCoeffPID_ValueChanged);
            // 
            // numLineAccel
            // 
            this.numLineAccel.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numLineAccel.Location = new System.Drawing.Point(264, 234);
            this.numLineAccel.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numLineAccel.Name = "numLineAccel";
            this.numLineAccel.Size = new System.Drawing.Size(51, 20);
            this.numLineAccel.TabIndex = 96;
            this.numLineAccel.ValueChanged += new System.EventHandler(this.numLineAccel_ValueChanged);
            // 
            // txtAngle
            // 
            this.txtAngle.BackColor = System.Drawing.Color.White;
            this.txtAngle.DefaultText = "Angle";
            this.txtAngle.ErrorMode = false;
            this.txtAngle.ForeColor = System.Drawing.Color.LightGray;
            this.txtAngle.Location = new System.Drawing.Point(178, 77);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(67, 20);
            this.txtAngle.TabIndex = 78;
            this.txtAngle.Text = "Angle";
            this.txtAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAngle.TextMode = Composants.TextBoxPlus.TextModeEnum.Decimal;
            // 
            // btnTurnBackwardRight
            // 
            this.btnTurnBackwardRight.Image = global::GoBot.Properties.Resources.TopToRigth16;
            this.btnTurnBackwardRight.Location = new System.Drawing.Point(251, 103);
            this.btnTurnBackwardRight.Name = "btnTurnBackwardRight";
            this.btnTurnBackwardRight.Size = new System.Drawing.Size(32, 23);
            this.btnTurnBackwardRight.TabIndex = 84;
            this.btnTurnBackwardRight.UseVisualStyleBackColor = true;
            this.btnTurnBackwardRight.Click += new System.EventHandler(this.btnTurnBackwardRight_Click);
            // 
            // lblPIDI
            // 
            this.lblPIDI.AutoSize = true;
            this.lblPIDI.Location = new System.Drawing.Point(70, 380);
            this.lblPIDI.Name = "lblPIDI";
            this.lblPIDI.Size = new System.Drawing.Size(10, 13);
            this.lblPIDI.TabIndex = 105;
            this.lblPIDI.Text = "I";
            // 
            // btnBackward
            // 
            this.btnBackward.Image = global::GoBot.Properties.Resources.DownGreen16;
            this.btnBackward.Location = new System.Drawing.Point(178, 103);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(67, 23);
            this.btnBackward.TabIndex = 79;
            this.btnBackward.UseVisualStyleBackColor = true;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // btnPivotLeft
            // 
            this.btnPivotLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPivotLeft.Image = global::GoBot.Properties.Resources.TurnLeft16;
            this.btnPivotLeft.Location = new System.Drawing.Point(140, 51);
            this.btnPivotLeft.Name = "btnPivotLeft";
            this.btnPivotLeft.Size = new System.Drawing.Size(32, 48);
            this.btnPivotLeft.TabIndex = 77;
            this.btnPivotLeft.UseVisualStyleBackColor = true;
            this.btnPivotLeft.Click += new System.EventHandler(this.btnPivotLeft_Click);
            // 
            // numCoeffP
            // 
            this.numCoeffP.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoeffP.Location = new System.Drawing.Point(18, 378);
            this.numCoeffP.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCoeffP.Name = "numCoeffP";
            this.numCoeffP.Size = new System.Drawing.Size(45, 20);
            this.numCoeffP.TabIndex = 104;
            this.numCoeffP.ValueChanged += new System.EventHandler(this.numCoeffPID_ValueChanged);
            // 
            // btnTurnForwardRight
            // 
            this.btnTurnForwardRight.Image = global::GoBot.Properties.Resources.BottomToRigth16;
            this.btnTurnForwardRight.Location = new System.Drawing.Point(251, 24);
            this.btnTurnForwardRight.Name = "btnTurnForwardRight";
            this.btnTurnForwardRight.Size = new System.Drawing.Size(32, 23);
            this.btnTurnForwardRight.TabIndex = 82;
            this.btnTurnForwardRight.UseVisualStyleBackColor = true;
            this.btnTurnForwardRight.Click += new System.EventHandler(this.btnTurnForwardRight_Click);
            // 
            // btnTurnBackwardLeft
            // 
            this.btnTurnBackwardLeft.Image = global::GoBot.Properties.Resources.TopToLeft16;
            this.btnTurnBackwardLeft.Location = new System.Drawing.Point(140, 103);
            this.btnTurnBackwardLeft.Name = "btnTurnBackwardLeft";
            this.btnTurnBackwardLeft.Size = new System.Drawing.Size(32, 23);
            this.btnTurnBackwardLeft.TabIndex = 83;
            this.btnTurnBackwardLeft.UseVisualStyleBackColor = true;
            this.btnTurnBackwardLeft.Click += new System.EventHandler(this.btnTurnBackwardLeft_Click);
            // 
            // lblPIDP
            // 
            this.lblPIDP.AutoSize = true;
            this.lblPIDP.Location = new System.Drawing.Point(4, 380);
            this.lblPIDP.Name = "lblPIDP";
            this.lblPIDP.Size = new System.Drawing.Size(14, 13);
            this.lblPIDP.TabIndex = 103;
            this.lblPIDP.Text = "P";
            // 
            // trkPivotSpeed
            // 
            this.trkPivotSpeed.BackColor = System.Drawing.Color.Transparent;
            this.trkPivotSpeed.DecimalPlaces = 0;
            this.trkPivotSpeed.IntervalTimer = ((uint)(500u));
            this.trkPivotSpeed.Location = new System.Drawing.Point(9, 309);
            this.trkPivotSpeed.Max = 3000D;
            this.trkPivotSpeed.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkPivotSpeed.Min = 0D;
            this.trkPivotSpeed.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkPivotSpeed.Name = "trkPivotSpeed";
            this.trkPivotSpeed.Reverse = false;
            this.trkPivotSpeed.Size = new System.Drawing.Size(250, 15);
            this.trkPivotSpeed.TabIndex = 99;
            this.trkPivotSpeed.Vertical = false;
            this.trkPivotSpeed.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkPivotSpeed_TickValueChanged);
            this.trkPivotSpeed.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkPivotSpeed_ValueChanged);
            // 
            // btnTurnForwardLeft
            // 
            this.btnTurnForwardLeft.Image = global::GoBot.Properties.Resources.BottomToLeft16;
            this.btnTurnForwardLeft.Location = new System.Drawing.Point(140, 24);
            this.btnTurnForwardLeft.Name = "btnTurnForwardLeft";
            this.btnTurnForwardLeft.Size = new System.Drawing.Size(32, 23);
            this.btnTurnForwardLeft.TabIndex = 81;
            this.btnTurnForwardLeft.UseVisualStyleBackColor = true;
            this.btnTurnForwardLeft.Click += new System.EventHandler(this.btnTurnForwardLeft_Click);
            // 
            // lblLineAccel
            // 
            this.lblLineAccel.Location = new System.Drawing.Point(9, 223);
            this.lblLineAccel.Name = "lblLineAccel";
            this.lblLineAccel.Size = new System.Drawing.Size(250, 13);
            this.lblLineAccel.TabIndex = 70;
            this.lblLineAccel.Text = "Accélération ligne";
            this.lblLineAccel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numPivotAccel
            // 
            this.numPivotAccel.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numPivotAccel.Location = new System.Drawing.Point(264, 339);
            this.numPivotAccel.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numPivotAccel.Name = "numPivotAccel";
            this.numPivotAccel.Size = new System.Drawing.Size(51, 20);
            this.numPivotAccel.TabIndex = 102;
            this.numPivotAccel.ValueChanged += new System.EventHandler(this.numPivotAccel_ValueChanged);
            // 
            // trkPivotAccel
            // 
            this.trkPivotAccel.BackColor = System.Drawing.Color.Transparent;
            this.trkPivotAccel.DecimalPlaces = 0;
            this.trkPivotAccel.IntervalTimer = ((uint)(500u));
            this.trkPivotAccel.Location = new System.Drawing.Point(9, 344);
            this.trkPivotAccel.Max = 5000D;
            this.trkPivotAccel.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkPivotAccel.Min = 0D;
            this.trkPivotAccel.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkPivotAccel.Name = "trkPivotAccel";
            this.trkPivotAccel.Reverse = false;
            this.trkPivotAccel.Size = new System.Drawing.Size(250, 15);
            this.trkPivotAccel.TabIndex = 100;
            this.trkPivotAccel.Vertical = false;
            this.trkPivotAccel.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkPivotAccel_TickValueChanged);
            this.trkPivotAccel.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkPivotAccel_ValueChanged);
            // 
            // lblLineSpeed
            // 
            this.lblLineSpeed.Location = new System.Drawing.Point(9, 188);
            this.lblLineSpeed.Name = "lblLineSpeed";
            this.lblLineSpeed.Size = new System.Drawing.Size(250, 13);
            this.lblLineSpeed.TabIndex = 69;
            this.lblLineSpeed.Text = "Vitesse ligne";
            this.lblLineSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPivotRight
            // 
            this.btnPivotRight.Image = global::GoBot.Properties.Resources.TurnRigth16;
            this.btnPivotRight.Location = new System.Drawing.Point(251, 51);
            this.btnPivotRight.Name = "btnPivotRight";
            this.btnPivotRight.Size = new System.Drawing.Size(32, 48);
            this.btnPivotRight.TabIndex = 80;
            this.btnPivotRight.UseVisualStyleBackColor = true;
            this.btnPivotRight.Click += new System.EventHandler(this.btnPivotRight_Click);
            // 
            // numPivotSpeed
            // 
            this.numPivotSpeed.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numPivotSpeed.Location = new System.Drawing.Point(264, 304);
            this.numPivotSpeed.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numPivotSpeed.Name = "numPivotSpeed";
            this.numPivotSpeed.Size = new System.Drawing.Size(51, 20);
            this.numPivotSpeed.TabIndex = 101;
            this.numPivotSpeed.ValueChanged += new System.EventHandler(this.numPivotSpeed_ValueChanged);
            // 
            // lblPivotSpeed
            // 
            this.lblPivotSpeed.Location = new System.Drawing.Point(9, 293);
            this.lblPivotSpeed.Name = "lblPivotSpeed";
            this.lblPivotSpeed.Size = new System.Drawing.Size(250, 13);
            this.lblPivotSpeed.TabIndex = 97;
            this.lblPivotSpeed.Text = "Vitesse pivot";
            this.lblPivotSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPivotAccel
            // 
            this.lblPivotAccel.Location = new System.Drawing.Point(9, 328);
            this.lblPivotAccel.Name = "lblPivotAccel";
            this.lblPivotAccel.Size = new System.Drawing.Size(250, 13);
            this.lblPivotAccel.TabIndex = 98;
            this.lblPivotAccel.Text = "Accélération pivot";
            this.lblPivotAccel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpDisplacement
            // 
            this.grpDisplacement.Controls.Add(this.btnStop);
            this.grpDisplacement.Controls.Add(this.btnPIDVit);
            this.grpDisplacement.Controls.Add(this.lblPivotAccel);
            this.grpDisplacement.Controls.Add(this.btnPIDPol);
            this.grpDisplacement.Controls.Add(this.lblPivotSpeed);
            this.grpDisplacement.Controls.Add(this.trkLineDecel);
            this.grpDisplacement.Controls.Add(this.numPivotSpeed);
            this.grpDisplacement.Controls.Add(this.numLineDecel);
            this.grpDisplacement.Controls.Add(this.btnPivotRight);
            this.grpDisplacement.Controls.Add(this.lblLineDecel);
            this.grpDisplacement.Controls.Add(this.lblLineSpeed);
            this.grpDisplacement.Controls.Add(this.btnFast);
            this.grpDisplacement.Controls.Add(this.trkPivotAccel);
            this.grpDisplacement.Controls.Add(this.btnLow);
            this.grpDisplacement.Controls.Add(this.numPivotAccel);
            this.grpDisplacement.Controls.Add(this.btnGoTo);
            this.grpDisplacement.Controls.Add(this.lblLineAccel);
            this.grpDisplacement.Controls.Add(this.numTeta);
            this.grpDisplacement.Controls.Add(this.btnTurnForwardLeft);
            this.grpDisplacement.Controls.Add(this.lblGoToTheta);
            this.grpDisplacement.Controls.Add(this.trkPivotSpeed);
            this.grpDisplacement.Controls.Add(this.numY);
            this.grpDisplacement.Controls.Add(this.lblPIDP);
            this.grpDisplacement.Controls.Add(this.lblGoToY);
            this.grpDisplacement.Controls.Add(this.btnTurnBackwardLeft);
            this.grpDisplacement.Controls.Add(this.numX);
            this.grpDisplacement.Controls.Add(this.btnTurnForwardRight);
            this.grpDisplacement.Controls.Add(this.lblGoToX);
            this.grpDisplacement.Controls.Add(this.numCoeffP);
            this.grpDisplacement.Controls.Add(this.btnPivotLeft);
            this.grpDisplacement.Controls.Add(this.btnPIDXY);
            this.grpDisplacement.Controls.Add(this.btnBackward);
            this.grpDisplacement.Controls.Add(this.pnlManual);
            this.grpDisplacement.Controls.Add(this.lblPIDI);
            this.grpDisplacement.Controls.Add(this.lblManual);
            this.grpDisplacement.Controls.Add(this.btnTurnBackwardRight);
            this.grpDisplacement.Controls.Add(this.numCoeffD);
            this.grpDisplacement.Controls.Add(this.txtAngle);
            this.grpDisplacement.Controls.Add(this.trkLineAccel);
            this.grpDisplacement.Controls.Add(this.numLineAccel);
            this.grpDisplacement.Controls.Add(this.btnForward);
            this.grpDisplacement.Controls.Add(this.numCoeffI);
            this.grpDisplacement.Controls.Add(this.btnCalibration);
            this.grpDisplacement.Controls.Add(this.numLineSpeed);
            this.grpDisplacement.Controls.Add(this.lblPIDD);
            this.grpDisplacement.Controls.Add(this.txtDistance);
            this.grpDisplacement.Controls.Add(this.trkLineSpeed);
            this.grpDisplacement.Location = new System.Drawing.Point(3, 3);
            this.grpDisplacement.Name = "grpDisplacement";
            this.grpDisplacement.Size = new System.Drawing.Size(320, 443);
            this.grpDisplacement.TabIndex = 111;
            this.grpDisplacement.TabStop = false;
            this.grpDisplacement.Text = "Déplacement";
            // 
            // PanelDisplacement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpDisplacement);
            this.Name = "PanelDisplacement";
            this.Size = new System.Drawing.Size(340, 450);
            this.contextMenuStop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numLineDecel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineAccel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPivotAccel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPivotSpeed)).EndInit();
            this.grpDisplacement.ResumeLayout(false);
            this.grpDisplacement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnTurnBackwardRight;
        protected System.Windows.Forms.Button btnPivotLeft;
        protected System.Windows.Forms.Button btnStop;
        protected System.Windows.Forms.Button btnTurnBackwardLeft;
        protected System.Windows.Forms.Label lblLineAccel;
        protected System.Windows.Forms.Button btnPivotRight;
        protected System.Windows.Forms.Label lblLineSpeed;
        protected System.Windows.Forms.Button btnTurnForwardLeft;
        protected System.Windows.Forms.Button btnTurnForwardRight;
        protected System.Windows.Forms.Button btnBackward;
        protected Composants.TextBoxPlus txtAngle;
        protected Composants.TextBoxPlus txtDistance;
        protected System.Windows.Forms.Button btnForward;
        protected Composants.TrackBarPlus trkLineSpeed;
        protected Composants.TrackBarPlus trkLineAccel;
        private Composants.FocusablePanel pnlManual;
        private System.Windows.Forms.Label lblManual;
        private System.Windows.Forms.Button btnCalibration;
        private System.Windows.Forms.Button btnPIDXY;
        private System.Windows.Forms.NumericUpDown numCoeffD;
        private System.Windows.Forms.Label lblPIDD;
        private System.Windows.Forms.NumericUpDown numCoeffI;
        private System.Windows.Forms.Label lblPIDI;
        private System.Windows.Forms.NumericUpDown numCoeffP;
        private System.Windows.Forms.Label lblPIDP;
        private System.Windows.Forms.NumericUpDown numPivotAccel;
        private System.Windows.Forms.NumericUpDown numPivotSpeed;
        protected Composants.TrackBarPlus trkPivotAccel;
        protected Composants.TrackBarPlus trkPivotSpeed;
        protected System.Windows.Forms.Label lblPivotAccel;
        protected System.Windows.Forms.Label lblPivotSpeed;
        private System.Windows.Forms.NumericUpDown numLineAccel;
        private System.Windows.Forms.NumericUpDown numLineSpeed;
        private System.Windows.Forms.ContextMenuStrip contextMenuStop;
        private System.Windows.Forms.ToolStripMenuItem freelyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abruptToolStripMenuItem;
        private System.Windows.Forms.Button btnGoTo;
        private System.Windows.Forms.NumericUpDown numTeta;
        private System.Windows.Forms.Label lblGoToTheta;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label lblGoToY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label lblGoToX;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Button btnLow;
        protected Composants.TrackBarPlus trkLineDecel;
        private System.Windows.Forms.NumericUpDown numLineDecel;
        protected System.Windows.Forms.Label lblLineDecel;
        private System.Windows.Forms.Button btnPIDPol;
        private System.Windows.Forms.Button btnPIDVit;
        private System.Windows.Forms.GroupBox grpDisplacement;
    }
}
