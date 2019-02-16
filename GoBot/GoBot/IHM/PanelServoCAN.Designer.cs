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
            this.boxTorque = new Composants.SwitchButton();
            this.grpTorque = new System.Windows.Forms.GroupBox();
            this.graphTorque = new Composants.GraphPanel();
            this.numID = new System.Windows.Forms.NumericUpDown();
            this.lblIdTxt = new Composants.LabelPlus();
            this.trackBarPosition = new Composants.TrackBarPlus();
            this.lblPositionTxt = new System.Windows.Forms.Label();
            this.lblSpeedTxt = new System.Windows.Forms.Label();
            this.trackBarSpeed = new Composants.TrackBarPlus();
            this.trackBarTorque = new Composants.TrackBarPlus();
            this.lblTorqueMaxTxt = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblTorqueMax = new System.Windows.Forms.Label();
            this.numPosition = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numAccel = new System.Windows.Forms.NumericUpDown();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnGetPos = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.grpTorque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccel)).BeginInit();
            this.SuspendLayout();
            // 
            // boxTorque
            // 
            this.boxTorque.AutoSize = true;
            this.boxTorque.BackColor = System.Drawing.Color.Transparent;
            this.boxTorque.Location = new System.Drawing.Point(85, 1);
            this.boxTorque.MaximumSize = new System.Drawing.Size(35, 15);
            this.boxTorque.MinimumSize = new System.Drawing.Size(35, 15);
            this.boxTorque.Mirrored = true;
            this.boxTorque.Name = "boxTorque";
            this.boxTorque.Size = new System.Drawing.Size(35, 15);
            this.boxTorque.TabIndex = 0;
            this.boxTorque.Value = false;
            this.boxTorque.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.boxTorque_ValueChanged);
            // 
            // grpTorque
            // 
            this.grpTorque.Controls.Add(this.graphTorque);
            this.grpTorque.Controls.Add(this.boxTorque);
            this.grpTorque.Location = new System.Drawing.Point(16, 40);
            this.grpTorque.Name = "grpTorque";
            this.grpTorque.Size = new System.Drawing.Size(200, 100);
            this.grpTorque.TabIndex = 1;
            this.grpTorque.TabStop = false;
            this.grpTorque.Text = "Suivi du couple";
            // 
            // graphTorque
            // 
            this.graphTorque.BackColor = System.Drawing.Color.White;
            this.graphTorque.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.graphTorque.LimitsVisible = false;
            this.graphTorque.Location = new System.Drawing.Point(19, 22);
            this.graphTorque.MaxLimit = 1D;
            this.graphTorque.MinLimit = 0D;
            this.graphTorque.Name = "graphTorque";
            this.graphTorque.NamesVisible = false;
            this.graphTorque.Size = new System.Drawing.Size(163, 72);
            this.graphTorque.TabIndex = 4;
            // 
            // numID
            // 
            this.numID.Location = new System.Drawing.Point(51, 13);
            this.numID.Name = "numID";
            this.numID.Size = new System.Drawing.Size(50, 20);
            this.numID.TabIndex = 2;
            this.numID.ValueChanged += new System.EventHandler(this.numID_ValueChanged);
            // 
            // lblIdTxt
            // 
            this.lblIdTxt.AutoSize = true;
            this.lblIdTxt.Location = new System.Drawing.Point(21, 15);
            this.lblIdTxt.Name = "lblIdTxt";
            this.lblIdTxt.Size = new System.Drawing.Size(24, 13);
            this.lblIdTxt.TabIndex = 3;
            this.lblIdTxt.Text = "ID :";
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.BackColor = System.Drawing.Color.Transparent;
            this.trackBarPosition.DecimalPlaces = 0;
            this.trackBarPosition.IntervalTimer = ((uint)(100u));
            this.trackBarPosition.Location = new System.Drawing.Point(233, 51);
            this.trackBarPosition.Max = 40000D;
            this.trackBarPosition.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarPosition.Min = 0D;
            this.trackBarPosition.MinimumSize = new System.Drawing.Size(30, 15);
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Reverse = false;
            this.trackBarPosition.Size = new System.Drawing.Size(150, 15);
            this.trackBarPosition.TabIndex = 4;
            this.trackBarPosition.Vertical = false;
            this.trackBarPosition.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarPosition_TickValueChanged);
            // 
            // lblPositionTxt
            // 
            this.lblPositionTxt.AutoSize = true;
            this.lblPositionTxt.Location = new System.Drawing.Point(230, 35);
            this.lblPositionTxt.Name = "lblPositionTxt";
            this.lblPositionTxt.Size = new System.Drawing.Size(44, 13);
            this.lblPositionTxt.TabIndex = 5;
            this.lblPositionTxt.Text = "Position";
            // 
            // lblSpeedTxt
            // 
            this.lblSpeedTxt.AutoSize = true;
            this.lblSpeedTxt.Location = new System.Drawing.Point(230, 73);
            this.lblSpeedTxt.Name = "lblSpeedTxt";
            this.lblSpeedTxt.Size = new System.Drawing.Size(41, 13);
            this.lblSpeedTxt.TabIndex = 6;
            this.lblSpeedTxt.Text = "Vitesse";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.BackColor = System.Drawing.Color.Transparent;
            this.trackBarSpeed.DecimalPlaces = 0;
            this.trackBarSpeed.IntervalTimer = ((uint)(1u));
            this.trackBarSpeed.Location = new System.Drawing.Point(233, 89);
            this.trackBarSpeed.Max = 1000D;
            this.trackBarSpeed.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarSpeed.Min = 0D;
            this.trackBarSpeed.MinimumSize = new System.Drawing.Size(30, 15);
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Reverse = false;
            this.trackBarSpeed.Size = new System.Drawing.Size(150, 15);
            this.trackBarSpeed.TabIndex = 7;
            this.trackBarSpeed.Vertical = false;
            this.trackBarSpeed.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarSpeed_TickValueChanged);
            // 
            // trackBarTorque
            // 
            this.trackBarTorque.BackColor = System.Drawing.Color.Transparent;
            this.trackBarTorque.DecimalPlaces = 0;
            this.trackBarTorque.IntervalTimer = ((uint)(1u));
            this.trackBarTorque.Location = new System.Drawing.Point(233, 127);
            this.trackBarTorque.Max = 1000D;
            this.trackBarTorque.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarTorque.Min = 0D;
            this.trackBarTorque.MinimumSize = new System.Drawing.Size(30, 15);
            this.trackBarTorque.Name = "trackBarTorque";
            this.trackBarTorque.Reverse = false;
            this.trackBarTorque.Size = new System.Drawing.Size(150, 15);
            this.trackBarTorque.TabIndex = 9;
            this.trackBarTorque.Vertical = false;
            this.trackBarTorque.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarTorque_TickValueChanged);
            // 
            // lblTorqueMaxTxt
            // 
            this.lblTorqueMaxTxt.AutoSize = true;
            this.lblTorqueMaxTxt.Location = new System.Drawing.Point(230, 111);
            this.lblTorqueMaxTxt.Name = "lblTorqueMaxTxt";
            this.lblTorqueMaxTxt.Size = new System.Drawing.Size(62, 13);
            this.lblTorqueMaxTxt.TabIndex = 8;
            this.lblTorqueMaxTxt.Text = "Couple max";
            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(310, 35);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(73, 13);
            this.lblPosition.TabIndex = 10;
            this.lblPosition.Text = "-";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Location = new System.Drawing.Point(310, 73);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(73, 13);
            this.lblSpeed.TabIndex = 11;
            this.lblSpeed.Text = "-";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTorqueMax
            // 
            this.lblTorqueMax.Location = new System.Drawing.Point(310, 111);
            this.lblTorqueMax.Name = "lblTorqueMax";
            this.lblTorqueMax.Size = new System.Drawing.Size(73, 13);
            this.lblTorqueMax.TabIndex = 12;
            this.lblTorqueMax.Text = "-";
            this.lblTorqueMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numPosition
            // 
            this.numPosition.Location = new System.Drawing.Point(66, 155);
            this.numPosition.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPosition.Name = "numPosition";
            this.numPosition.Size = new System.Drawing.Size(57, 20);
            this.numPosition.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Position";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Vitesse";
            // 
            // numSpeed
            // 
            this.numSpeed.Location = new System.Drawing.Point(174, 155);
            this.numSpeed.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(57, 20);
            this.numSpeed.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Accel";
            // 
            // numAccel
            // 
            this.numAccel.Location = new System.Drawing.Point(278, 155);
            this.numAccel.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numAccel.Name = "numAccel";
            this.numAccel.Size = new System.Drawing.Size(57, 20);
            this.numAccel.TabIndex = 19;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(347, 153);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(36, 23);
            this.btnGo.TabIndex = 21;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnGetPos
            // 
            this.btnGetPos.Location = new System.Drawing.Point(323, 3);
            this.btnGetPos.Name = "btnGetPos";
            this.btnGetPos.Size = new System.Drawing.Size(60, 23);
            this.btnGetPos.TabIndex = 22;
            this.btnGetPos.Text = "GetPos";
            this.btnGetPos.UseVisualStyleBackColor = true;
            this.btnGetPos.Click += new System.EventHandler(this.btnGetPos_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(244, 3);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 23;
            this.btnDebug.Text = "Debug CAN";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // PanelServoCAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnGetPos);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numAccel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPosition);
            this.Controls.Add(this.lblTorqueMax);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.trackBarTorque);
            this.Controls.Add(this.lblTorqueMaxTxt);
            this.Controls.Add(this.trackBarSpeed);
            this.Controls.Add(this.lblSpeedTxt);
            this.Controls.Add(this.lblPositionTxt);
            this.Controls.Add(this.trackBarPosition);
            this.Controls.Add(this.lblIdTxt);
            this.Controls.Add(this.numID);
            this.Controls.Add(this.grpTorque);
            this.Name = "PanelServoCAN";
            this.Size = new System.Drawing.Size(407, 185);
            this.grpTorque.ResumeLayout(false);
            this.grpTorque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Composants.SwitchButton boxTorque;
        private System.Windows.Forms.GroupBox grpTorque;
        private System.Windows.Forms.NumericUpDown numID;
        private Composants.LabelPlus lblIdTxt;
        private Composants.GraphPanel graphTorque;
        private Composants.TrackBarPlus trackBarPosition;
        private System.Windows.Forms.Label lblPositionTxt;
        private System.Windows.Forms.Label lblSpeedTxt;
        private Composants.TrackBarPlus trackBarSpeed;
        private Composants.TrackBarPlus trackBarTorque;
        private System.Windows.Forms.Label lblTorqueMaxTxt;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblTorqueMax;
        private System.Windows.Forms.NumericUpDown numPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numAccel;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnGetPos;
        private System.Windows.Forms.Button btnDebug;
    }
}
