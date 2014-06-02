namespace GoBot.IHM
{
    partial class PanelDeplacement
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
            this.btnPID = new System.Windows.Forms.Button();
            this.numCoeffD = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numCoeffI = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numCoeffP = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numAccelPivot = new System.Windows.Forms.NumericUpDown();
            this.numVitessePivot = new System.Windows.Forms.NumericUpDown();
            this.trackBarAccelPivot = new Composants.TrackBarPlus();
            this.trackBarVitessePivot = new Composants.TrackBarPlus();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numAccelLigne = new System.Windows.Forms.NumericUpDown();
            this.numVitesseLigne = new System.Windows.Forms.NumericUpDown();
            this.btnRecallage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControleManuel = new Composants.FocusablePanel();
            this.trackBarAccelLigne = new Composants.TrackBarPlus();
            this.trackBarVitesseLigne = new Composants.TrackBarPlus();
            this.btnVirageArDr = new System.Windows.Forms.Button();
            this.btnPivotGauche = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.contextMenuStop = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.freelyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abruptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVirageArGa = new System.Windows.Forms.Button();
            this.lblAcceleration = new System.Windows.Forms.Label();
            this.btnPivotDroite = new System.Windows.Forms.Button();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.btnVirageAvGa = new System.Windows.Forms.Button();
            this.btnVirageAvDr = new System.Windows.Forms.Button();
            this.btnRecule = new System.Windows.Forms.Button();
            this.txtAngle = new Composants.TextBoxPlus();
            this.txtDistance = new Composants.TextBoxPlus();
            this.btnAvance = new System.Windows.Forms.Button();
            this.groupBoxDep = new Composants.GroupBoxRetractable();
            this.btnGoCoordonnees = new System.Windows.Forms.Button();
            this.numTeta = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLent = new System.Windows.Forms.Button();
            this.btnRapide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccelPivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVitessePivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccelLigne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVitesseLigne)).BeginInit();
            this.contextMenuStop.SuspendLayout();
            this.groupBoxDep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPID
            // 
            this.btnPID.Location = new System.Drawing.Point(257, 346);
            this.btnPID.Name = "btnPID";
            this.btnPID.Size = new System.Drawing.Size(53, 23);
            this.btnPID.TabIndex = 109;
            this.btnPID.Text = "Ok";
            this.btnPID.UseVisualStyleBackColor = true;
            this.btnPID.Click += new System.EventHandler(this.btnPID_Click);
            // 
            // numCoeffD
            // 
            this.numCoeffD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoeffD.Location = new System.Drawing.Point(187, 349);
            this.numCoeffD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCoeffD.Name = "numCoeffD";
            this.numCoeffD.Size = new System.Drawing.Size(51, 20);
            this.numCoeffD.TabIndex = 108;
            this.numCoeffD.ValueChanged += new System.EventHandler(this.numCoeffPID_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 107;
            this.label6.Text = "D";
            // 
            // numCoeffI
            // 
            this.numCoeffI.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoeffI.Location = new System.Drawing.Point(108, 349);
            this.numCoeffI.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCoeffI.Name = "numCoeffI";
            this.numCoeffI.Size = new System.Drawing.Size(51, 20);
            this.numCoeffI.TabIndex = 106;
            this.numCoeffI.ValueChanged += new System.EventHandler(this.numCoeffPID_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 105;
            this.label5.Text = "I";
            // 
            // numCoeffP
            // 
            this.numCoeffP.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoeffP.Location = new System.Drawing.Point(35, 349);
            this.numCoeffP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCoeffP.Name = "numCoeffP";
            this.numCoeffP.Size = new System.Drawing.Size(51, 20);
            this.numCoeffP.TabIndex = 104;
            this.numCoeffP.ValueChanged += new System.EventHandler(this.numCoeffPID_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 103;
            this.label4.Text = "P";
            // 
            // numAccelPivot
            // 
            this.numAccelPivot.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numAccelPivot.Location = new System.Drawing.Point(259, 311);
            this.numAccelPivot.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numAccelPivot.Name = "numAccelPivot";
            this.numAccelPivot.Size = new System.Drawing.Size(51, 20);
            this.numAccelPivot.TabIndex = 102;
            this.numAccelPivot.ValueChanged += new System.EventHandler(this.numAccelPivot_ValueChanged);
            // 
            // numVitessePivot
            // 
            this.numVitessePivot.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numVitessePivot.Location = new System.Drawing.Point(259, 273);
            this.numVitessePivot.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numVitessePivot.Name = "numVitessePivot";
            this.numVitessePivot.Size = new System.Drawing.Size(51, 20);
            this.numVitessePivot.TabIndex = 101;
            this.numVitessePivot.ValueChanged += new System.EventHandler(this.numVitessePivot_ValueChanged);
            // 
            // trackBarAccelPivot
            // 
            this.trackBarAccelPivot.BackColor = System.Drawing.Color.Transparent;
            this.trackBarAccelPivot.IntervalTimer = 500;
            this.trackBarAccelPivot.Location = new System.Drawing.Point(4, 316);
            this.trackBarAccelPivot.Max = 5000D;
            this.trackBarAccelPivot.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarAccelPivot.Min = 0D;
            this.trackBarAccelPivot.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarAccelPivot.Name = "trackBarAccelPivot";
            this.trackBarAccelPivot.NombreDecimales = 0;
            this.trackBarAccelPivot.Reverse = false;
            this.trackBarAccelPivot.Size = new System.Drawing.Size(249, 15);
            this.trackBarAccelPivot.TabIndex = 100;
            this.trackBarAccelPivot.Vertical = false;
            this.trackBarAccelPivot.TickValueChanged += new System.EventHandler(this.trackBarAccelPivot_TickValueChanged);
            this.trackBarAccelPivot.ValueChanged += new System.EventHandler(this.trackBarAccelPivot_ValueChanged);
            // 
            // trackBarVitessePivot
            // 
            this.trackBarVitessePivot.BackColor = System.Drawing.Color.Transparent;
            this.trackBarVitessePivot.IntervalTimer = 500;
            this.trackBarVitessePivot.Location = new System.Drawing.Point(4, 278);
            this.trackBarVitessePivot.Max = 3000D;
            this.trackBarVitessePivot.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarVitessePivot.Min = 0D;
            this.trackBarVitessePivot.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarVitessePivot.Name = "trackBarVitessePivot";
            this.trackBarVitessePivot.NombreDecimales = 0;
            this.trackBarVitessePivot.Reverse = false;
            this.trackBarVitessePivot.Size = new System.Drawing.Size(249, 15);
            this.trackBarVitessePivot.TabIndex = 99;
            this.trackBarVitessePivot.Vertical = false;
            this.trackBarVitessePivot.TickValueChanged += new System.EventHandler(this.trackBarVitessePivot_TickValueChanged);
            this.trackBarVitessePivot.ValueChanged += new System.EventHandler(this.trackBarVitessePivot_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 13);
            this.label2.TabIndex = 98;
            this.label2.Text = "Accélération pivot";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Vitesse pivot";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numAccelLigne
            // 
            this.numAccelLigne.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numAccelLigne.Location = new System.Drawing.Point(259, 237);
            this.numAccelLigne.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numAccelLigne.Name = "numAccelLigne";
            this.numAccelLigne.Size = new System.Drawing.Size(51, 20);
            this.numAccelLigne.TabIndex = 96;
            this.numAccelLigne.ValueChanged += new System.EventHandler(this.numAccelLigne_ValueChanged);
            // 
            // numVitesseLigne
            // 
            this.numVitesseLigne.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numVitesseLigne.Location = new System.Drawing.Point(259, 199);
            this.numVitesseLigne.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numVitesseLigne.Name = "numVitesseLigne";
            this.numVitesseLigne.Size = new System.Drawing.Size(51, 20);
            this.numVitesseLigne.TabIndex = 95;
            this.numVitesseLigne.ValueChanged += new System.EventHandler(this.numVitesseLigne_ValueChanged);
            // 
            // btnRecallage
            // 
            this.btnRecallage.Image = global::GoBot.Properties.Resources.Recale;
            this.btnRecallage.Location = new System.Drawing.Point(187, 128);
            this.btnRecallage.Name = "btnRecallage";
            this.btnRecallage.Size = new System.Drawing.Size(23, 23);
            this.btnRecallage.TabIndex = 93;
            this.btnRecallage.UseVisualStyleBackColor = true;
            this.btnRecallage.Click += new System.EventHandler(this.btnRecallage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Contrôle manuel :";
            // 
            // panelControleManuel
            // 
            this.panelControleManuel.BackColor = System.Drawing.Color.LightGray;
            this.panelControleManuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControleManuel.Location = new System.Drawing.Point(251, 385);
            this.panelControleManuel.Name = "panelControleManuel";
            this.panelControleManuel.Size = new System.Drawing.Size(74, 22);
            this.panelControleManuel.TabIndex = 91;
            this.panelControleManuel.ToucheEnfoncee += new Composants.FocusablePanel.ToucheEnfonceeDelegate(this.panelControleManuel_ToucheEnfoncee);
            this.panelControleManuel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.panelControleManuel_KeyUp);
            // 
            // trackBarAccelLigne
            // 
            this.trackBarAccelLigne.BackColor = System.Drawing.Color.Transparent;
            this.trackBarAccelLigne.IntervalTimer = 500;
            this.trackBarAccelLigne.Location = new System.Drawing.Point(4, 242);
            this.trackBarAccelLigne.Max = 5000D;
            this.trackBarAccelLigne.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarAccelLigne.Min = 0D;
            this.trackBarAccelLigne.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarAccelLigne.Name = "trackBarAccelLigne";
            this.trackBarAccelLigne.NombreDecimales = 0;
            this.trackBarAccelLigne.Reverse = false;
            this.trackBarAccelLigne.Size = new System.Drawing.Size(249, 15);
            this.trackBarAccelLigne.TabIndex = 88;
            this.trackBarAccelLigne.Vertical = false;
            this.trackBarAccelLigne.TickValueChanged += new System.EventHandler(this.trackBarAccelLigne_TickValueChanged);
            this.trackBarAccelLigne.ValueChanged += new System.EventHandler(this.trackBarAccelLigne_ValueChanged);
            // 
            // trackBarVitesseLigne
            // 
            this.trackBarVitesseLigne.BackColor = System.Drawing.Color.Transparent;
            this.trackBarVitesseLigne.IntervalTimer = 500;
            this.trackBarVitesseLigne.Location = new System.Drawing.Point(4, 204);
            this.trackBarVitesseLigne.Max = 3000D;
            this.trackBarVitesseLigne.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarVitesseLigne.Min = 0D;
            this.trackBarVitesseLigne.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarVitesseLigne.Name = "trackBarVitesseLigne";
            this.trackBarVitesseLigne.NombreDecimales = 0;
            this.trackBarVitesseLigne.Reverse = false;
            this.trackBarVitesseLigne.Size = new System.Drawing.Size(249, 15);
            this.trackBarVitesseLigne.TabIndex = 87;
            this.trackBarVitesseLigne.Vertical = false;
            this.trackBarVitesseLigne.TickValueChanged += new System.EventHandler(this.trackBarVitesseLigne_TickValueChanged);
            this.trackBarVitesseLigne.ValueChanged += new System.EventHandler(this.trackBarVitesseLigne_ValueChanged);
            // 
            // btnVirageArDr
            // 
            this.btnVirageArDr.Image = global::GoBot.Properties.Resources.VirageArDr;
            this.btnVirageArDr.Location = new System.Drawing.Point(239, 103);
            this.btnVirageArDr.Name = "btnVirageArDr";
            this.btnVirageArDr.Size = new System.Drawing.Size(32, 23);
            this.btnVirageArDr.TabIndex = 84;
            this.btnVirageArDr.UseVisualStyleBackColor = true;
            this.btnVirageArDr.Click += new System.EventHandler(this.btnVirageArDr_Click);
            // 
            // btnPivotGauche
            // 
            this.btnPivotGauche.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPivotGauche.Image = global::GoBot.Properties.Resources.PivotGauche;
            this.btnPivotGauche.Location = new System.Drawing.Point(128, 51);
            this.btnPivotGauche.Name = "btnPivotGauche";
            this.btnPivotGauche.Size = new System.Drawing.Size(32, 48);
            this.btnPivotGauche.TabIndex = 77;
            this.btnPivotGauche.UseVisualStyleBackColor = true;
            this.btnPivotGauche.Click += new System.EventHandler(this.btnPivotGauche_Click);
            // 
            // btnStop
            // 
            this.btnStop.ContextMenuStrip = this.contextMenuStop;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.Image = global::GoBot.Properties.Resources.Stop;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.Location = new System.Drawing.Point(12, 29);
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(97, 97);
            this.btnStop.TabIndex = 63;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStopSmooth_Click);
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
            this.freelyToolStripMenuItem.CheckOnClick = true;
            this.freelyToolStripMenuItem.Name = "freelyToolStripMenuItem";
            this.freelyToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.freelyToolStripMenuItem.Text = "Freely";
            this.freelyToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // smoothToolStripMenuItem
            // 
            this.smoothToolStripMenuItem.Checked = true;
            this.smoothToolStripMenuItem.CheckOnClick = true;
            this.smoothToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
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
            // btnVirageArGa
            // 
            this.btnVirageArGa.Image = global::GoBot.Properties.Resources.VirageArGa;
            this.btnVirageArGa.Location = new System.Drawing.Point(128, 103);
            this.btnVirageArGa.Name = "btnVirageArGa";
            this.btnVirageArGa.Size = new System.Drawing.Size(32, 23);
            this.btnVirageArGa.TabIndex = 83;
            this.btnVirageArGa.UseVisualStyleBackColor = true;
            this.btnVirageArGa.Click += new System.EventHandler(this.btnVirageArGa_Click);
            // 
            // lblAcceleration
            // 
            this.lblAcceleration.Location = new System.Drawing.Point(1, 225);
            this.lblAcceleration.Name = "lblAcceleration";
            this.lblAcceleration.Size = new System.Drawing.Size(269, 13);
            this.lblAcceleration.TabIndex = 70;
            this.lblAcceleration.Text = "Accélération ligne";
            this.lblAcceleration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPivotDroite
            // 
            this.btnPivotDroite.Image = global::GoBot.Properties.Resources.PivotDroite;
            this.btnPivotDroite.Location = new System.Drawing.Point(239, 51);
            this.btnPivotDroite.Name = "btnPivotDroite";
            this.btnPivotDroite.Size = new System.Drawing.Size(32, 48);
            this.btnPivotDroite.TabIndex = 80;
            this.btnPivotDroite.UseVisualStyleBackColor = true;
            this.btnPivotDroite.Click += new System.EventHandler(this.btnPivotDroite_Click);
            // 
            // lblVitesse
            // 
            this.lblVitesse.Location = new System.Drawing.Point(4, 189);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(266, 13);
            this.lblVitesse.TabIndex = 69;
            this.lblVitesse.Text = "Vitesse ligne";
            this.lblVitesse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVirageAvGa
            // 
            this.btnVirageAvGa.Image = global::GoBot.Properties.Resources.VirageAvGa;
            this.btnVirageAvGa.Location = new System.Drawing.Point(128, 24);
            this.btnVirageAvGa.Name = "btnVirageAvGa";
            this.btnVirageAvGa.Size = new System.Drawing.Size(32, 23);
            this.btnVirageAvGa.TabIndex = 81;
            this.btnVirageAvGa.UseVisualStyleBackColor = true;
            this.btnVirageAvGa.Click += new System.EventHandler(this.btnVirageAvGa_Click);
            // 
            // btnVirageAvDr
            // 
            this.btnVirageAvDr.Image = global::GoBot.Properties.Resources.VirageAvDr;
            this.btnVirageAvDr.Location = new System.Drawing.Point(239, 24);
            this.btnVirageAvDr.Name = "btnVirageAvDr";
            this.btnVirageAvDr.Size = new System.Drawing.Size(32, 23);
            this.btnVirageAvDr.TabIndex = 82;
            this.btnVirageAvDr.UseVisualStyleBackColor = true;
            this.btnVirageAvDr.Click += new System.EventHandler(this.btnVirageAvDr_Click);
            // 
            // btnRecule
            // 
            this.btnRecule.Image = global::GoBot.Properties.Resources.Recule;
            this.btnRecule.Location = new System.Drawing.Point(166, 103);
            this.btnRecule.Name = "btnRecule";
            this.btnRecule.Size = new System.Drawing.Size(67, 23);
            this.btnRecule.TabIndex = 79;
            this.btnRecule.UseVisualStyleBackColor = true;
            this.btnRecule.Click += new System.EventHandler(this.btnRecule_Click);
            // 
            // txtAngle
            // 
            this.txtAngle.BackColor = System.Drawing.Color.White;
            this.txtAngle.DefaultText = "Angle";
            this.txtAngle.ErrorMode = false;
            this.txtAngle.ForeColor = System.Drawing.Color.LightGray;
            this.txtAngle.Location = new System.Drawing.Point(166, 77);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(67, 20);
            this.txtAngle.TabIndex = 78;
            this.txtAngle.Text = "Angle";
            this.txtAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAngle.TextMode = Composants.TextBoxPlus.TextModeEnum.Decimal;
            // 
            // txtDistance
            // 
            this.txtDistance.BackColor = System.Drawing.Color.White;
            this.txtDistance.DefaultText = "Distance";
            this.txtDistance.ErrorMode = false;
            this.txtDistance.ForeColor = System.Drawing.Color.LightGray;
            this.txtDistance.Location = new System.Drawing.Point(166, 53);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(67, 20);
            this.txtDistance.TabIndex = 76;
            this.txtDistance.Text = "Distance";
            this.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDistance.TextMode = Composants.TextBoxPlus.TextModeEnum.Numeric;
            // 
            // btnAvance
            // 
            this.btnAvance.Image = global::GoBot.Properties.Resources.Avance;
            this.btnAvance.Location = new System.Drawing.Point(166, 24);
            this.btnAvance.Name = "btnAvance";
            this.btnAvance.Size = new System.Drawing.Size(67, 23);
            this.btnAvance.TabIndex = 75;
            this.btnAvance.UseVisualStyleBackColor = true;
            this.btnAvance.Click += new System.EventHandler(this.btnAvance_Click);
            // 
            // groupBoxDep
            // 
            this.groupBoxDep.Controls.Add(this.btnRapide);
            this.groupBoxDep.Controls.Add(this.btnLent);
            this.groupBoxDep.Controls.Add(this.btnGoCoordonnees);
            this.groupBoxDep.Controls.Add(this.numTeta);
            this.groupBoxDep.Controls.Add(this.label7);
            this.groupBoxDep.Controls.Add(this.numY);
            this.groupBoxDep.Controls.Add(this.label8);
            this.groupBoxDep.Controls.Add(this.numX);
            this.groupBoxDep.Controls.Add(this.label9);
            this.groupBoxDep.Controls.Add(this.btnStop);
            this.groupBoxDep.Controls.Add(this.btnPID);
            this.groupBoxDep.Controls.Add(this.panelControleManuel);
            this.groupBoxDep.Controls.Add(this.label1);
            this.groupBoxDep.Controls.Add(this.numCoeffD);
            this.groupBoxDep.Controls.Add(this.trackBarAccelLigne);
            this.groupBoxDep.Controls.Add(this.btnAvance);
            this.groupBoxDep.Controls.Add(this.btnRecallage);
            this.groupBoxDep.Controls.Add(this.label6);
            this.groupBoxDep.Controls.Add(this.trackBarVitesseLigne);
            this.groupBoxDep.Controls.Add(this.txtDistance);
            this.groupBoxDep.Controls.Add(this.numVitesseLigne);
            this.groupBoxDep.Controls.Add(this.numCoeffI);
            this.groupBoxDep.Controls.Add(this.numAccelLigne);
            this.groupBoxDep.Controls.Add(this.txtAngle);
            this.groupBoxDep.Controls.Add(this.btnVirageArDr);
            this.groupBoxDep.Controls.Add(this.label5);
            this.groupBoxDep.Controls.Add(this.btnRecule);
            this.groupBoxDep.Controls.Add(this.btnPivotGauche);
            this.groupBoxDep.Controls.Add(this.numCoeffP);
            this.groupBoxDep.Controls.Add(this.btnVirageAvDr);
            this.groupBoxDep.Controls.Add(this.btnVirageArGa);
            this.groupBoxDep.Controls.Add(this.label4);
            this.groupBoxDep.Controls.Add(this.trackBarVitessePivot);
            this.groupBoxDep.Controls.Add(this.btnVirageAvGa);
            this.groupBoxDep.Controls.Add(this.lblAcceleration);
            this.groupBoxDep.Controls.Add(this.numAccelPivot);
            this.groupBoxDep.Controls.Add(this.trackBarAccelPivot);
            this.groupBoxDep.Controls.Add(this.lblVitesse);
            this.groupBoxDep.Controls.Add(this.btnPivotDroite);
            this.groupBoxDep.Controls.Add(this.numVitessePivot);
            this.groupBoxDep.Controls.Add(this.label3);
            this.groupBoxDep.Controls.Add(this.label2);
            this.groupBoxDep.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDep.Name = "groupBoxDep";
            this.groupBoxDep.Size = new System.Drawing.Size(331, 413);
            this.groupBoxDep.TabIndex = 110;
            this.groupBoxDep.TabStop = false;
            this.groupBoxDep.Text = "Déplacement";
            // 
            // btnGoCoordonnees
            // 
            this.btnGoCoordonnees.Location = new System.Drawing.Point(252, 154);
            this.btnGoCoordonnees.Name = "btnGoCoordonnees";
            this.btnGoCoordonnees.Size = new System.Drawing.Size(53, 23);
            this.btnGoCoordonnees.TabIndex = 116;
            this.btnGoCoordonnees.Text = "Go";
            this.btnGoCoordonnees.UseVisualStyleBackColor = true;
            this.btnGoCoordonnees.Click += new System.EventHandler(this.btnGoCoordonnees_Click);
            // 
            // numTeta
            // 
            this.numTeta.DecimalPlaces = 2;
            this.numTeta.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTeta.Location = new System.Drawing.Point(182, 157);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 114;
            this.label7.Text = "T";
            // 
            // numY
            // 
            this.numY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numY.Location = new System.Drawing.Point(103, 157);
            this.numY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(51, 20);
            this.numY.TabIndex = 113;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "Y";
            // 
            // numX
            // 
            this.numX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numX.Location = new System.Drawing.Point(30, 157);
            this.numX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(51, 20);
            this.numX.TabIndex = 111;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 110;
            this.label9.Text = "X";
            // 
            // btnLent
            // 
            this.btnLent.Location = new System.Drawing.Point(7, 384);
            this.btnLent.Name = "btnLent";
            this.btnLent.Size = new System.Drawing.Size(43, 23);
            this.btnLent.TabIndex = 117;
            this.btnLent.Text = "Lent";
            this.btnLent.UseVisualStyleBackColor = true;
            this.btnLent.Click += new System.EventHandler(this.btnLent_Click);
            // 
            // btnRapide
            // 
            this.btnRapide.Location = new System.Drawing.Point(56, 384);
            this.btnRapide.Name = "btnRapide";
            this.btnRapide.Size = new System.Drawing.Size(53, 23);
            this.btnRapide.TabIndex = 118;
            this.btnRapide.Text = "Rapide";
            this.btnRapide.UseVisualStyleBackColor = true;
            this.btnRapide.Click += new System.EventHandler(this.btnRapide_Click);
            // 
            // PanelDeplacement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxDep);
            this.Name = "PanelDeplacement";
            this.Size = new System.Drawing.Size(340, 422);
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoeffP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccelPivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVitessePivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccelLigne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVitesseLigne)).EndInit();
            this.contextMenuStop.ResumeLayout(false);
            this.groupBoxDep.ResumeLayout(false);
            this.groupBoxDep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnVirageArDr;
        protected System.Windows.Forms.Button btnPivotGauche;
        protected System.Windows.Forms.Button btnStop;
        protected System.Windows.Forms.Button btnVirageArGa;
        protected System.Windows.Forms.Label lblAcceleration;
        protected System.Windows.Forms.Button btnPivotDroite;
        protected System.Windows.Forms.Label lblVitesse;
        protected System.Windows.Forms.Button btnVirageAvGa;
        protected System.Windows.Forms.Button btnVirageAvDr;
        protected System.Windows.Forms.Button btnRecule;
        protected Composants.TextBoxPlus txtAngle;
        protected Composants.TextBoxPlus txtDistance;
        protected System.Windows.Forms.Button btnAvance;
        protected Composants.TrackBarPlus trackBarVitesseLigne;
        protected Composants.TrackBarPlus trackBarAccelLigne;
        private Composants.FocusablePanel panelControleManuel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRecallage;
        private System.Windows.Forms.Button btnPID;
        private System.Windows.Forms.NumericUpDown numCoeffD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numCoeffI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCoeffP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numAccelPivot;
        private System.Windows.Forms.NumericUpDown numVitessePivot;
        protected Composants.TrackBarPlus trackBarAccelPivot;
        protected Composants.TrackBarPlus trackBarVitessePivot;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numAccelLigne;
        private System.Windows.Forms.NumericUpDown numVitesseLigne;
        private System.Windows.Forms.ContextMenuStrip contextMenuStop;
        private System.Windows.Forms.ToolStripMenuItem freelyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abruptToolStripMenuItem;
        private Composants.GroupBoxRetractable groupBoxDep;
        private System.Windows.Forms.Button btnGoCoordonnees;
        private System.Windows.Forms.NumericUpDown numTeta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRapide;
        private System.Windows.Forms.Button btnLent;

    }
}
