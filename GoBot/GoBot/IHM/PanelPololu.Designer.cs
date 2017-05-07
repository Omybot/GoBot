namespace GoBot.IHM
{
    partial class PanelPololu
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
            this.numId = new System.Windows.Forms.NumericUpDown();
            this.lblIDTxt = new System.Windows.Forms.Label();
            this.lblPositionTxt = new System.Windows.Forms.Label();
            this.lblMinTxt = new System.Windows.Forms.Label();
            this.lblMaxTxt = new System.Windows.Forms.Label();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.trackBarPosition = new Composants.TrackBarPlus();
            this.lblPosition = new System.Windows.Forms.Label();
            this.groupPololu = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            this.groupPololu.SuspendLayout();
            this.SuspendLayout();
            // 
            // numId
            // 
            this.numId.Location = new System.Drawing.Point(46, 25);
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(62, 20);
            this.numId.TabIndex = 0;
            // 
            // lblIDTxt
            // 
            this.lblIDTxt.AutoSize = true;
            this.lblIDTxt.Location = new System.Drawing.Point(22, 27);
            this.lblIDTxt.Name = "lblIDTxt";
            this.lblIDTxt.Size = new System.Drawing.Size(18, 13);
            this.lblIDTxt.TabIndex = 1;
            this.lblIDTxt.Text = "ID";
            // 
            // lblPositionTxt
            // 
            this.lblPositionTxt.AutoSize = true;
            this.lblPositionTxt.Location = new System.Drawing.Point(302, 56);
            this.lblPositionTxt.Name = "lblPositionTxt";
            this.lblPositionTxt.Size = new System.Drawing.Size(44, 13);
            this.lblPositionTxt.TabIndex = 2;
            this.lblPositionTxt.Text = "Position";
            // 
            // lblMinTxt
            // 
            this.lblMinTxt.AutoSize = true;
            this.lblMinTxt.Location = new System.Drawing.Point(64, 56);
            this.lblMinTxt.Name = "lblMinTxt";
            this.lblMinTxt.Size = new System.Drawing.Size(24, 13);
            this.lblMinTxt.TabIndex = 3;
            this.lblMinTxt.Text = "Min";
            // 
            // lblMaxTxt
            // 
            this.lblMaxTxt.AutoSize = true;
            this.lblMaxTxt.Location = new System.Drawing.Point(552, 56);
            this.lblMaxTxt.Name = "lblMaxTxt";
            this.lblMaxTxt.Size = new System.Drawing.Size(27, 13);
            this.lblMaxTxt.TabIndex = 4;
            this.lblMaxTxt.Text = "Max";
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(46, 72);
            this.numMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(62, 20);
            this.numMin.TabIndex = 5;
            this.numMin.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(536, 72);
            this.numMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(62, 20);
            this.numMax.TabIndex = 6;
            this.numMax.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMax.ValueChanged += new System.EventHandler(this.numMax_ValueChanged);
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.BackColor = System.Drawing.Color.Transparent;
            this.trackBarPosition.IntervalTimer = 1;
            this.trackBarPosition.Location = new System.Drawing.Point(114, 74);
            this.trackBarPosition.Max = 100D;
            this.trackBarPosition.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarPosition.Min = 0D;
            this.trackBarPosition.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.NombreDecimales = 0;
            this.trackBarPosition.Reverse = false;
            this.trackBarPosition.Size = new System.Drawing.Size(416, 15);
            this.trackBarPosition.TabIndex = 7;
            this.trackBarPosition.Vertical = false;
            this.trackBarPosition.TickValueChanged += new System.EventHandler(this.trackBarPosition_TickValueChanged);
            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(273, 91);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(100, 23);
            this.lblPosition.TabIndex = 8;
            this.lblPosition.Text = "-";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPololu
            // 
            this.groupPololu.Controls.Add(this.lblIDTxt);
            this.groupPololu.Controls.Add(this.lblPosition);
            this.groupPololu.Controls.Add(this.numId);
            this.groupPololu.Controls.Add(this.trackBarPosition);
            this.groupPololu.Controls.Add(this.lblPositionTxt);
            this.groupPololu.Controls.Add(this.numMax);
            this.groupPololu.Controls.Add(this.lblMinTxt);
            this.groupPololu.Controls.Add(this.numMin);
            this.groupPololu.Controls.Add(this.lblMaxTxt);
            this.groupPololu.Location = new System.Drawing.Point(3, 3);
            this.groupPololu.Name = "groupPololu";
            this.groupPololu.Size = new System.Drawing.Size(604, 116);
            this.groupPololu.TabIndex = 9;
            this.groupPololu.TabStop = false;
            this.groupPololu.Text = "Pololu";
            // 
            // PanelPololu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPololu);
            this.Name = "PanelPololu";
            this.Size = new System.Drawing.Size(620, 137);
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            this.groupPololu.ResumeLayout(false);
            this.groupPololu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numId;
        private System.Windows.Forms.Label lblIDTxt;
        private System.Windows.Forms.Label lblPositionTxt;
        private System.Windows.Forms.Label lblMinTxt;
        private System.Windows.Forms.Label lblMaxTxt;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.NumericUpDown numMax;
        private Composants.TrackBarPlus trackBarPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.GroupBox groupPololu;
    }
}
