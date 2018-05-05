namespace GoBot.IHM
{
    partial class PotarControl
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
            this.cboPositionnable = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.trackBar = new Composants.TrackBarPlus();
            this.switchBouton = new Composants.SwitchButton();
            this.lblValue = new System.Windows.Forms.Label();
            this.trackBarSpeed = new Composants.TrackBarPlus();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblPositionTxt = new System.Windows.Forms.Label();
            this.cboPositions = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboPositionnable
            // 
            this.cboPositionnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPositionnable.DropDownWidth = 220;
            this.cboPositionnable.FormattingEnabled = true;
            this.cboPositionnable.Location = new System.Drawing.Point(112, 12);
            this.cboPositionnable.Name = "cboPositionnable";
            this.cboPositionnable.Size = new System.Drawing.Size(152, 21);
            this.cboPositionnable.TabIndex = 0;
            this.cboPositionnable.SelectedIndexChanged += new System.EventHandler(this.cboPositionnable_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Positionnable :";
            // 
            // trackBar
            // 
            this.trackBar.BackColor = System.Drawing.Color.Transparent;
            this.trackBar.DecimalPlaces = 0;
            this.trackBar.IntervalTimer = ((uint)(1u));
            this.trackBar.Location = new System.Drawing.Point(28, 65);
            this.trackBar.Max = 100D;
            this.trackBar.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBar.Min = 0D;
            this.trackBar.MinimumSize = new System.Drawing.Size(30, 15);
            this.trackBar.Name = "trackBar";
            this.trackBar.Reverse = false;
            this.trackBar.Size = new System.Drawing.Size(305, 15);
            this.trackBar.TabIndex = 2;
            this.trackBar.Vertical = false;
            this.trackBar.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.TrackBar_TickValueChanged);
            // 
            // switchBouton
            // 
            this.switchBouton.AutoSize = true;
            this.switchBouton.BackColor = System.Drawing.Color.Transparent;
            this.switchBouton.Location = new System.Drawing.Point(279, 15);
            this.switchBouton.MaximumSize = new System.Drawing.Size(35, 15);
            this.switchBouton.MinimumSize = new System.Drawing.Size(35, 15);
            this.switchBouton.Mirrored = true;
            this.switchBouton.Name = "switchBouton";
            this.switchBouton.Size = new System.Drawing.Size(35, 15);
            this.switchBouton.TabIndex = 3;
            this.switchBouton.Value = false;
            this.switchBouton.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.switchBouton_ValueChanged);
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(136, 78);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(100, 20);
            this.lblValue.TabIndex = 4;
            this.lblValue.Text = "0";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.BackColor = System.Drawing.Color.Transparent;
            this.trackBarSpeed.DecimalPlaces = 1;
            this.trackBarSpeed.IntervalTimer = ((uint)(100u));
            this.trackBarSpeed.Location = new System.Drawing.Point(364, 24);
            this.trackBarSpeed.Max = 10D;
            this.trackBarSpeed.MaximumSize = new System.Drawing.Size(15, 3000);
            this.trackBarSpeed.Min = 1D;
            this.trackBarSpeed.MinimumSize = new System.Drawing.Size(15, 30);
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Reverse = true;
            this.trackBarSpeed.Size = new System.Drawing.Size(15, 61);
            this.trackBarSpeed.TabIndex = 5;
            this.trackBarSpeed.Vertical = true;
            this.trackBarSpeed.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarSpeed_ValueChanged);
            // 
            // lblSpeed
            // 
            this.lblSpeed.Location = new System.Drawing.Point(329, 3);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(66, 18);
            this.lblSpeed.TabIndex = 6;
            this.lblSpeed.Text = "Rapport : ?";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPositionTxt
            // 
            this.lblPositionTxt.AutoSize = true;
            this.lblPositionTxt.Location = new System.Drawing.Point(30, 42);
            this.lblPositionTxt.Name = "lblPositionTxt";
            this.lblPositionTxt.Size = new System.Drawing.Size(50, 13);
            this.lblPositionTxt.TabIndex = 8;
            this.lblPositionTxt.Text = "Position :";
            // 
            // cboPositions
            // 
            this.cboPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPositions.DropDownWidth = 220;
            this.cboPositions.FormattingEnabled = true;
            this.cboPositions.Location = new System.Drawing.Point(112, 39);
            this.cboPositions.Name = "cboPositions";
            this.cboPositions.Size = new System.Drawing.Size(152, 21);
            this.cboPositions.TabIndex = 7;
            this.cboPositions.SelectedIndexChanged += new System.EventHandler(this.cboPositions_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::GoBot.Properties.Resources.Save16;
            this.btnSave.Location = new System.Drawing.Point(283, 38);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PotarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPositionTxt);
            this.Controls.Add(this.cboPositions);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.trackBarSpeed);
            this.Controls.Add(this.switchBouton);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cboPositionnable);
            this.Controls.Add(this.lblValue);
            this.Name = "PotarControl";
            this.Size = new System.Drawing.Size(406, 98);
            this.Load += new System.EventHandler(this.PotarControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPositionnable;
        private System.Windows.Forms.Label lblName;
        private Composants.TrackBarPlus trackBar;
        private Composants.SwitchButton switchBouton;
        private System.Windows.Forms.Label lblValue;
        private Composants.TrackBarPlus trackBarSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblPositionTxt;
        private System.Windows.Forms.ComboBox cboPositions;
        private System.Windows.Forms.Button btnSave;
    }
}
