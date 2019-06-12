namespace GoBot.IHM
{
    partial class PageHokuyo
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.switchBouton1 = new Composants.SwitchButton();
            this.rdoOutline = new System.Windows.Forms.RadioButton();
            this.rdoRays = new System.Windows.Forms.RadioButton();
            this.rdoShadows = new System.Windows.Forms.RadioButton();
            this.trackZoom = new Composants.TrackBarPlus();
            this.boxScale = new System.Windows.Forms.CheckBox();
            this.rdoObjects = new System.Windows.Forms.RadioButton();
            this.boxGroup = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblMousePosition = new System.Windows.Forms.Label();
            this.lblMousePositionTxt = new System.Windows.Forms.Label();
            this.lblMeasuresPerSecond = new System.Windows.Forms.Label();
            this.numDistanceMax = new System.Windows.Forms.NumericUpDown();
            this.lblDistanceMax = new System.Windows.Forms.Label();
            this.lblDistanceMaxUnit = new System.Windows.Forms.Label();
            this.cboHokuyo = new System.Windows.Forms.ComboBox();
            this.numFrom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numTo = new System.Windows.Forms.NumericUpDown();
            this.picWorld = new GoBot.IHM.WorldPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numDistanceMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // switchBouton1
            // 
            this.switchBouton1.AutoSize = true;
            this.switchBouton1.BackColor = System.Drawing.Color.Transparent;
            this.switchBouton1.Location = new System.Drawing.Point(39, 42);
            this.switchBouton1.MaximumSize = new System.Drawing.Size(35, 15);
            this.switchBouton1.MinimumSize = new System.Drawing.Size(35, 15);
            this.switchBouton1.Mirrored = true;
            this.switchBouton1.Name = "switchBouton1";
            this.switchBouton1.Size = new System.Drawing.Size(35, 15);
            this.switchBouton1.TabIndex = 2;
            this.switchBouton1.Value = false;
            this.switchBouton1.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.switchEnable_ValueChanged);
            // 
            // rdoOutline
            // 
            this.rdoOutline.AutoSize = true;
            this.rdoOutline.Location = new System.Drawing.Point(19, 99);
            this.rdoOutline.Name = "rdoOutline";
            this.rdoOutline.Size = new System.Drawing.Size(62, 17);
            this.rdoOutline.TabIndex = 3;
            this.rdoOutline.Text = "Contour";
            this.rdoOutline.UseVisualStyleBackColor = true;
            // 
            // rdoRays
            // 
            this.rdoRays.AutoSize = true;
            this.rdoRays.Location = new System.Drawing.Point(19, 122);
            this.rdoRays.Name = "rdoRays";
            this.rdoRays.Size = new System.Drawing.Size(61, 17);
            this.rdoRays.TabIndex = 4;
            this.rdoRays.Text = "Rayons";
            this.rdoRays.UseVisualStyleBackColor = true;
            // 
            // rdoShadows
            // 
            this.rdoShadows.AutoSize = true;
            this.rdoShadows.Location = new System.Drawing.Point(19, 145);
            this.rdoShadows.Name = "rdoShadows";
            this.rdoShadows.Size = new System.Drawing.Size(61, 17);
            this.rdoShadows.TabIndex = 5;
            this.rdoShadows.Text = "Ombres";
            this.rdoShadows.UseVisualStyleBackColor = true;
            // 
            // trackZoom
            // 
            this.trackZoom.BackColor = System.Drawing.Color.Transparent;
            this.trackZoom.DecimalPlaces = 1;
            this.trackZoom.IntervalTimer = ((uint)(1u));
            this.trackZoom.Location = new System.Drawing.Point(5, 170);
            this.trackZoom.Max = 10D;
            this.trackZoom.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackZoom.Min = 0.1D;
            this.trackZoom.MinimumSize = new System.Drawing.Size(30, 15);
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Reverse = false;
            this.trackZoom.Size = new System.Drawing.Size(90, 15);
            this.trackZoom.TabIndex = 6;
            this.trackZoom.Vertical = false;
            this.trackZoom.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackZoom_ValueChanged);
            // 
            // boxScale
            // 
            this.boxScale.AutoSize = true;
            this.boxScale.Checked = true;
            this.boxScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxScale.Location = new System.Drawing.Point(13, 191);
            this.boxScale.Name = "boxScale";
            this.boxScale.Size = new System.Drawing.Size(61, 17);
            this.boxScale.TabIndex = 7;
            this.boxScale.Text = "Echelle";
            this.boxScale.UseVisualStyleBackColor = true;
            // 
            // rdoObjects
            // 
            this.rdoObjects.AutoSize = true;
            this.rdoObjects.Checked = true;
            this.rdoObjects.Location = new System.Drawing.Point(19, 76);
            this.rdoObjects.Name = "rdoObjects";
            this.rdoObjects.Size = new System.Drawing.Size(55, 17);
            this.rdoObjects.TabIndex = 8;
            this.rdoObjects.TabStop = true;
            this.rdoObjects.Text = "Objets";
            this.rdoObjects.UseVisualStyleBackColor = true;
            // 
            // boxGroup
            // 
            this.boxGroup.AutoSize = true;
            this.boxGroup.Location = new System.Drawing.Point(13, 214);
            this.boxGroup.Name = "boxGroup";
            this.boxGroup.Size = new System.Drawing.Size(64, 17);
            this.boxGroup.TabIndex = 9;
            this.boxGroup.Text = "Grouper";
            this.boxGroup.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(6, 439);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Va chercher";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblMousePosition
            // 
            this.lblMousePosition.Location = new System.Drawing.Point(0, 506);
            this.lblMousePosition.Name = "lblMousePosition";
            this.lblMousePosition.Size = new System.Drawing.Size(100, 23);
            this.lblMousePosition.TabIndex = 12;
            this.lblMousePosition.Text = "-";
            this.lblMousePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMousePositionTxt
            // 
            this.lblMousePositionTxt.AutoSize = true;
            this.lblMousePositionTxt.Location = new System.Drawing.Point(10, 493);
            this.lblMousePositionTxt.Name = "lblMousePositionTxt";
            this.lblMousePositionTxt.Size = new System.Drawing.Size(74, 13);
            this.lblMousePositionTxt.TabIndex = 13;
            this.lblMousePositionTxt.Text = "Position souris";
            // 
            // lblMeasuresPerSecond
            // 
            this.lblMeasuresPerSecond.Location = new System.Drawing.Point(0, 529);
            this.lblMeasuresPerSecond.Name = "lblMeasuresPerSecond";
            this.lblMeasuresPerSecond.Size = new System.Drawing.Size(100, 23);
            this.lblMeasuresPerSecond.TabIndex = 14;
            this.lblMeasuresPerSecond.Text = "-";
            this.lblMeasuresPerSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numDistanceMax
            // 
            this.numDistanceMax.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDistanceMax.Location = new System.Drawing.Point(6, 258);
            this.numDistanceMax.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numDistanceMax.Name = "numDistanceMax";
            this.numDistanceMax.Size = new System.Drawing.Size(58, 20);
            this.numDistanceMax.TabIndex = 15;
            this.numDistanceMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDistanceMax.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numDistanceMax.ValueChanged += new System.EventHandler(this.numDistanceMax_ValueChanged);
            // 
            // lblDistanceMax
            // 
            this.lblDistanceMax.AutoSize = true;
            this.lblDistanceMax.Location = new System.Drawing.Point(5, 242);
            this.lblDistanceMax.Name = "lblDistanceMax";
            this.lblDistanceMax.Size = new System.Drawing.Size(77, 13);
            this.lblDistanceMax.TabIndex = 16;
            this.lblDistanceMax.Text = "Distance max :";
            // 
            // lblDistanceMaxUnit
            // 
            this.lblDistanceMaxUnit.AutoSize = true;
            this.lblDistanceMaxUnit.Location = new System.Drawing.Point(70, 260);
            this.lblDistanceMaxUnit.Name = "lblDistanceMaxUnit";
            this.lblDistanceMaxUnit.Size = new System.Drawing.Size(23, 13);
            this.lblDistanceMaxUnit.TabIndex = 17;
            this.lblDistanceMaxUnit.Text = "mm";
            // 
            // cboHokuyo
            // 
            this.cboHokuyo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHokuyo.FormattingEnabled = true;
            this.cboHokuyo.Location = new System.Drawing.Point(8, 15);
            this.cboHokuyo.Name = "cboHokuyo";
            this.cboHokuyo.Size = new System.Drawing.Size(96, 21);
            this.cboHokuyo.TabIndex = 18;
            // 
            // numFrom
            // 
            this.numFrom.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFrom.Location = new System.Drawing.Point(42, 284);
            this.numFrom.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numFrom.Name = "numFrom";
            this.numFrom.Size = new System.Drawing.Size(58, 20);
            this.numFrom.TabIndex = 19;
            this.numFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numFrom.ValueChanged += new System.EventHandler(this.numFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "To";
            // 
            // numTo
            // 
            this.numTo.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTo.Location = new System.Drawing.Point(42, 310);
            this.numTo.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numTo.Name = "numTo";
            this.numTo.Size = new System.Drawing.Size(58, 20);
            this.numTo.TabIndex = 22;
            this.numTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTo.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.numTo.ValueChanged += new System.EventHandler(this.numTo_ValueChanged);
            // 
            // picWorld
            // 
            this.picWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picWorld.Location = new System.Drawing.Point(110, 16);
            this.picWorld.Name = "picWorld";
            this.picWorld.Size = new System.Drawing.Size(727, 572);
            this.picWorld.TabIndex = 11;
            this.picWorld.TabStop = false;
            this.picWorld.WorldChange += new GoBot.IHM.WorldPanel.WorldChangeDelegate(this.picWorld_WorldChange);
            this.picWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.picWorld_Paint);
            this.picWorld.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picWorld_MouseMove);
            // 
            // PanelHokuyo
            // 
            this.Controls.Add(this.numTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numFrom);
            this.Controls.Add(this.cboHokuyo);
            this.Controls.Add(this.lblDistanceMaxUnit);
            this.Controls.Add(this.lblDistanceMax);
            this.Controls.Add(this.numDistanceMax);
            this.Controls.Add(this.lblMeasuresPerSecond);
            this.Controls.Add(this.lblMousePositionTxt);
            this.Controls.Add(this.lblMousePosition);
            this.Controls.Add(this.picWorld);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.boxGroup);
            this.Controls.Add(this.rdoObjects);
            this.Controls.Add(this.boxScale);
            this.Controls.Add(this.trackZoom);
            this.Controls.Add(this.rdoShadows);
            this.Controls.Add(this.rdoRays);
            this.Controls.Add(this.rdoOutline);
            this.Controls.Add(this.switchBouton1);
            this.Name = "PanelHokuyo";
            this.Size = new System.Drawing.Size(851, 604);
            this.Load += new System.EventHandler(this.PanelHokuyo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDistanceMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Composants.SwitchButton switchBouton1;
        private System.Windows.Forms.RadioButton rdoOutline;
        private System.Windows.Forms.RadioButton rdoRays;
        private System.Windows.Forms.RadioButton rdoShadows;
        private Composants.TrackBarPlus trackZoom;
        private System.Windows.Forms.CheckBox boxScale;
        private System.Windows.Forms.RadioButton rdoObjects;
        private System.Windows.Forms.CheckBox boxGroup;
        private System.Windows.Forms.Button btnGo;
        private WorldPanel picWorld;
        private System.Windows.Forms.Label lblMousePosition;
        private System.Windows.Forms.Label lblMousePositionTxt;
        private System.Windows.Forms.Label lblMeasuresPerSecond;
        private System.Windows.Forms.NumericUpDown numDistanceMax;
        private System.Windows.Forms.Label lblDistanceMax;
        private System.Windows.Forms.Label lblDistanceMaxUnit;
        private System.Windows.Forms.ComboBox cboHokuyo;
        private System.Windows.Forms.NumericUpDown numFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numTo;
    }
}
