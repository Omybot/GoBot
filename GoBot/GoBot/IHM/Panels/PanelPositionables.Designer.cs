using Composants;
namespace GoBot.IHM
{
    partial class PanelPositionables
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
            this.grpPositionables = new System.Windows.Forms.GroupBox();
            this.trkPosition = new Composants.TrackBarPlus();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.cboPositionables = new System.Windows.Forms.ComboBox();
            this.cboPositions = new System.Windows.Forms.ComboBox();
            this.numPosition = new System.Windows.Forms.NumericUpDown();
            this.lblPositionable = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.grpPositionables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPositionables
            // 
            this.grpPositionables.Controls.Add(this.lblPosition);
            this.grpPositionables.Controls.Add(this.lblPositionable);
            this.grpPositionables.Controls.Add(this.trkPosition);
            this.grpPositionables.Controls.Add(this.numPosition);
            this.grpPositionables.Controls.Add(this.btnSave);
            this.grpPositionables.Controls.Add(this.cboPositions);
            this.grpPositionables.Controls.Add(this.btnSend);
            this.grpPositionables.Controls.Add(this.cboPositionables);
            this.grpPositionables.Location = new System.Drawing.Point(3, 3);
            this.grpPositionables.Name = "grpPositionables";
            this.grpPositionables.Size = new System.Drawing.Size(320, 142);
            this.grpPositionables.TabIndex = 35;
            this.grpPositionables.TabStop = false;
            this.grpPositionables.Text = "Réglage des positions";
            // 
            // trkPosition
            // 
            this.trkPosition.BackColor = System.Drawing.Color.Transparent;
            this.trkPosition.DecimalPlaces = 0;
            this.trkPosition.IntervalTimer = ((uint)(1u));
            this.trkPosition.Location = new System.Drawing.Point(16, 117);
            this.trkPosition.Max = 100D;
            this.trkPosition.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trkPosition.Min = 0D;
            this.trkPosition.MinimumSize = new System.Drawing.Size(30, 15);
            this.trkPosition.Name = "trkPosition";
            this.trkPosition.Reverse = false;
            this.trkPosition.Size = new System.Drawing.Size(282, 15);
            this.trkPosition.TabIndex = 40;
            this.trkPosition.Vertical = false;
            this.trkPosition.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trkPosition_TickValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::GoBot.Properties.Resources.Save16;
            this.btnSave.Location = new System.Drawing.Point(196, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 23);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Sauvegarder";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Image = global::GoBot.Properties.Resources.Play16;
            this.btnSend.Location = new System.Drawing.Point(95, 85);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(95, 23);
            this.btnSend.TabIndex = 38;
            this.btnSend.Text = "Envoyer";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cboPositionables
            // 
            this.cboPositionables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPositionables.FormattingEnabled = true;
            this.cboPositionables.Location = new System.Drawing.Point(95, 26);
            this.cboPositionables.Name = "cboPositionables";
            this.cboPositionables.Size = new System.Drawing.Size(203, 21);
            this.cboPositionables.TabIndex = 34;
            this.cboPositionables.SelectedValueChanged += new System.EventHandler(this.cboPositionables_SelectedValueChanged);
            // 
            // cboPositions
            // 
            this.cboPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPositions.FormattingEnabled = true;
            this.cboPositions.Location = new System.Drawing.Point(95, 53);
            this.cboPositions.Name = "cboPositions";
            this.cboPositions.Size = new System.Drawing.Size(203, 21);
            this.cboPositions.TabIndex = 35;
            this.cboPositions.SelectedValueChanged += new System.EventHandler(this.cboPositions_SelectedValueChanged);
            // 
            // numPosition
            // 
            this.numPosition.Location = new System.Drawing.Point(16, 87);
            this.numPosition.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numPosition.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numPosition.Name = "numPosition";
            this.numPosition.Size = new System.Drawing.Size(73, 20);
            this.numPosition.TabIndex = 37;
            this.numPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPositionable
            // 
            this.lblPositionable.AutoSize = true;
            this.lblPositionable.Location = new System.Drawing.Point(13, 29);
            this.lblPositionable.Name = "lblPositionable";
            this.lblPositionable.Size = new System.Drawing.Size(76, 13);
            this.lblPositionable.TabIndex = 41;
            this.lblPositionable.Text = "Positionnable :";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(39, 56);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(50, 13);
            this.lblPosition.TabIndex = 42;
            this.lblPosition.Text = "Position :";
            // 
            // PanelPositionables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpPositionables);
            this.Name = "PanelPositionables";
            this.Size = new System.Drawing.Size(330, 165);
            this.Load += new System.EventHandler(this.PanelPositionables_Load);
            this.grpPositionables.ResumeLayout(false);
            this.grpPositionables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TrackBarPlus trkPosition;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cboPositionables;
        private System.Windows.Forms.ComboBox cboPositions;
        private System.Windows.Forms.NumericUpDown numPosition;
        private System.Windows.Forms.GroupBox grpPositionables;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblPositionable;
    }
}
