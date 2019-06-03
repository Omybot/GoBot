namespace GoBot.IHM
{
    partial class PanelAlimentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelAlimentation));
            this.grpBatteries = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numBatVeryLowToAbsent = new System.Windows.Forms.NumericUpDown();
            this.numBatLowToVeryLow = new System.Windows.Forms.NumericUpDown();
            this.numBatAverageToLow = new System.Windows.Forms.NumericUpDown();
            this.numBatHighToAverage = new System.Windows.Forms.NumericUpDown();
            this.batAbsent = new Composants.Battery();
            this.batVeryLow = new Composants.Battery();
            this.batLow = new Composants.Battery();
            this.batAverage = new Composants.Battery();
            this.batHigh = new Composants.Battery();
            this.ctrlGraphic = new Composants.GraphPanel();
            this.grpVoltage = new System.Windows.Forms.GroupBox();
            this.grpBatteries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatVeryLowToAbsent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatLowToVeryLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatAverageToLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatHighToAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batAbsent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batVeryLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batHigh)).BeginInit();
            this.grpVoltage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBatteries
            // 
            this.grpBatteries.Controls.Add(this.label4);
            this.grpBatteries.Controls.Add(this.label3);
            this.grpBatteries.Controls.Add(this.label2);
            this.grpBatteries.Controls.Add(this.label1);
            this.grpBatteries.Controls.Add(this.batAbsent);
            this.grpBatteries.Controls.Add(this.numBatVeryLowToAbsent);
            this.grpBatteries.Controls.Add(this.batVeryLow);
            this.grpBatteries.Controls.Add(this.numBatLowToVeryLow);
            this.grpBatteries.Controls.Add(this.batLow);
            this.grpBatteries.Controls.Add(this.numBatAverageToLow);
            this.grpBatteries.Controls.Add(this.batAverage);
            this.grpBatteries.Controls.Add(this.batHigh);
            this.grpBatteries.Controls.Add(this.numBatHighToAverage);
            this.grpBatteries.Location = new System.Drawing.Point(3, 7);
            this.grpBatteries.Name = "grpBatteries";
            this.grpBatteries.Size = new System.Drawing.Size(112, 163);
            this.grpBatteries.TabIndex = 22;
            this.grpBatteries.TabStop = false;
            this.grpBatteries.Text = "Niveaux d\'alerte";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "V";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "V";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "V";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "V";
            // 
            // numBatVeryLowToAbsent
            // 
            this.numBatVeryLowToAbsent.DecimalPlaces = 1;
            this.numBatVeryLowToAbsent.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numBatVeryLowToAbsent.Location = new System.Drawing.Point(43, 114);
            this.numBatVeryLowToAbsent.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numBatVeryLowToAbsent.Name = "numBatVeryLowToAbsent";
            this.numBatVeryLowToAbsent.Size = new System.Drawing.Size(45, 20);
            this.numBatVeryLowToAbsent.TabIndex = 24;
            this.numBatVeryLowToAbsent.ValueChanged += new System.EventHandler(this.numBat_ValueChanged);
            // 
            // numBatLowToVeryLow
            // 
            this.numBatLowToVeryLow.DecimalPlaces = 1;
            this.numBatLowToVeryLow.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numBatLowToVeryLow.Location = new System.Drawing.Point(43, 88);
            this.numBatLowToVeryLow.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numBatLowToVeryLow.Name = "numBatLowToVeryLow";
            this.numBatLowToVeryLow.Size = new System.Drawing.Size(45, 20);
            this.numBatLowToVeryLow.TabIndex = 22;
            this.numBatLowToVeryLow.ValueChanged += new System.EventHandler(this.numBat_ValueChanged);
            // 
            // numBatAverageToLow
            // 
            this.numBatAverageToLow.DecimalPlaces = 1;
            this.numBatAverageToLow.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numBatAverageToLow.Location = new System.Drawing.Point(43, 62);
            this.numBatAverageToLow.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numBatAverageToLow.Name = "numBatAverageToLow";
            this.numBatAverageToLow.Size = new System.Drawing.Size(45, 20);
            this.numBatAverageToLow.TabIndex = 20;
            this.numBatAverageToLow.ValueChanged += new System.EventHandler(this.numBat_ValueChanged);
            // 
            // numBatHighToAverage
            // 
            this.numBatHighToAverage.DecimalPlaces = 1;
            this.numBatHighToAverage.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numBatHighToAverage.Location = new System.Drawing.Point(43, 36);
            this.numBatHighToAverage.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numBatHighToAverage.Name = "numBatHighToAverage";
            this.numBatHighToAverage.Size = new System.Drawing.Size(45, 20);
            this.numBatHighToAverage.TabIndex = 17;
            this.numBatHighToAverage.ValueChanged += new System.EventHandler(this.numBat_ValueChanged);
            // 
            // batAbsent
            // 
            this.batAbsent.CurrentState = Composants.Battery.State.VeryLow;
            this.batAbsent.CurrentVoltage = 0D;
            this.batAbsent.Image = ((System.Drawing.Image)(resources.GetObject("batAbsent.Image")));
            this.batAbsent.Location = new System.Drawing.Point(21, 127);
            this.batAbsent.Name = "batAbsent";
            this.batAbsent.Size = new System.Drawing.Size(16, 16);
            this.batAbsent.TabIndex = 25;
            this.batAbsent.TabStop = false;
            this.batAbsent.VoltageAverage = 0D;
            this.batAbsent.VoltageHigh = 0D;
            this.batAbsent.VoltageLow = 0D;
            this.batAbsent.VoltageVeryLow = 0D;
            // 
            // batVeryLow
            // 
            this.batVeryLow.CurrentState = Composants.Battery.State.VeryLow;
            this.batVeryLow.CurrentVoltage = 0D;
            this.batVeryLow.Image = ((System.Drawing.Image)(resources.GetObject("batVeryLow.Image")));
            this.batVeryLow.Location = new System.Drawing.Point(21, 105);
            this.batVeryLow.Name = "batVeryLow";
            this.batVeryLow.Size = new System.Drawing.Size(16, 16);
            this.batVeryLow.TabIndex = 23;
            this.batVeryLow.TabStop = false;
            this.batVeryLow.VoltageAverage = 0D;
            this.batVeryLow.VoltageHigh = 0D;
            this.batVeryLow.VoltageLow = 0D;
            this.batVeryLow.VoltageVeryLow = 0D;
            // 
            // batLow
            // 
            this.batLow.CurrentState = Composants.Battery.State.VeryLow;
            this.batLow.CurrentVoltage = 0D;
            this.batLow.Image = ((System.Drawing.Image)(resources.GetObject("batLow.Image")));
            this.batLow.Location = new System.Drawing.Point(21, 79);
            this.batLow.Name = "batLow";
            this.batLow.Size = new System.Drawing.Size(16, 16);
            this.batLow.TabIndex = 21;
            this.batLow.TabStop = false;
            this.batLow.VoltageAverage = 0D;
            this.batLow.VoltageHigh = 0D;
            this.batLow.VoltageLow = 0D;
            this.batLow.VoltageVeryLow = 0D;
            // 
            // batAverage
            // 
            this.batAverage.CurrentState = Composants.Battery.State.VeryLow;
            this.batAverage.CurrentVoltage = 0D;
            this.batAverage.Image = ((System.Drawing.Image)(resources.GetObject("batAverage.Image")));
            this.batAverage.Location = new System.Drawing.Point(21, 53);
            this.batAverage.Name = "batAverage";
            this.batAverage.Size = new System.Drawing.Size(16, 16);
            this.batAverage.TabIndex = 19;
            this.batAverage.TabStop = false;
            this.batAverage.VoltageAverage = 0D;
            this.batAverage.VoltageHigh = 0D;
            this.batAverage.VoltageLow = 0D;
            this.batAverage.VoltageVeryLow = 0D;
            // 
            // batHigh
            // 
            this.batHigh.CurrentState = Composants.Battery.State.VeryLow;
            this.batHigh.CurrentVoltage = 0D;
            this.batHigh.Image = ((System.Drawing.Image)(resources.GetObject("batHigh.Image")));
            this.batHigh.Location = new System.Drawing.Point(21, 27);
            this.batHigh.Name = "batHigh";
            this.batHigh.Size = new System.Drawing.Size(16, 16);
            this.batHigh.TabIndex = 18;
            this.batHigh.TabStop = false;
            this.batHigh.VoltageAverage = 0D;
            this.batHigh.VoltageHigh = 0D;
            this.batHigh.VoltageLow = 0D;
            this.batHigh.VoltageVeryLow = 0D;
            // 
            // ctrlGraphic
            // 
            this.ctrlGraphic.BackColor = System.Drawing.Color.White;
            this.ctrlGraphic.BorderColor = System.Drawing.Color.LightGray;
            this.ctrlGraphic.BorderVisible = false;
            this.ctrlGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGraphic.LimitsVisible = false;
            this.ctrlGraphic.Location = new System.Drawing.Point(3, 16);
            this.ctrlGraphic.MaxLimit = 1D;
            this.ctrlGraphic.MinLimit = 0D;
            this.ctrlGraphic.Name = "ctrlGraphic";
            this.ctrlGraphic.NamesAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.ctrlGraphic.NamesVisible = false;
            this.ctrlGraphic.ScaleMode = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphic.Size = new System.Drawing.Size(908, 484);
            this.ctrlGraphic.TabIndex = 15;
            // 
            // grpVoltage
            // 
            this.grpVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVoltage.Controls.Add(this.ctrlGraphic);
            this.grpVoltage.Location = new System.Drawing.Point(121, 7);
            this.grpVoltage.Name = "grpVoltage";
            this.grpVoltage.Size = new System.Drawing.Size(914, 503);
            this.grpVoltage.TabIndex = 23;
            this.grpVoltage.TabStop = false;
            this.grpVoltage.Text = "Tension des batteries";
            // 
            // PanelAlimentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpVoltage);
            this.Controls.Add(this.grpBatteries);
            this.Name = "PanelAlimentation";
            this.Size = new System.Drawing.Size(1038, 513);
            this.Load += new System.EventHandler(this.PanelAlimentation_Load);
            this.grpBatteries.ResumeLayout(false);
            this.grpBatteries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatVeryLowToAbsent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatLowToVeryLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatAverageToLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatHighToAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batAbsent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batVeryLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batHigh)).EndInit();
            this.grpVoltage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Composants.GraphPanel ctrlGraphic;
        private System.Windows.Forms.GroupBox grpBatteries;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Composants.Battery batAbsent;
        private System.Windows.Forms.NumericUpDown numBatVeryLowToAbsent;
        private Composants.Battery batVeryLow;
        private System.Windows.Forms.NumericUpDown numBatLowToVeryLow;
        private Composants.Battery batLow;
        private System.Windows.Forms.NumericUpDown numBatAverageToLow;
        private Composants.Battery batAverage;
        private Composants.Battery batHigh;
        private System.Windows.Forms.NumericUpDown numBatHighToAverage;
        private System.Windows.Forms.GroupBox grpVoltage;
    }
}
