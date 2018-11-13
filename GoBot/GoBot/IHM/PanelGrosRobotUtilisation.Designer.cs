namespace GoBot.IHM
{
    partial class PanelGrosRobotUtilisation
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
            this.groupBoxUtilisation = new Composants.GroupBoxPlus();
            this.btnDiagnostic = new System.Windows.Forms.Button();
            this.trackBarPlus1 = new Composants.TrackBarPlus();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxUtilisation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUtilisation
            // 
            this.groupBoxUtilisation.Controls.Add(this.button1);
            this.groupBoxUtilisation.Controls.Add(this.trackBarPlus1);
            this.groupBoxUtilisation.Controls.Add(this.btnDiagnostic);
            this.groupBoxUtilisation.Location = new System.Drawing.Point(3, 3);
            this.groupBoxUtilisation.Name = "groupBoxUtilisation";
            this.groupBoxUtilisation.Size = new System.Drawing.Size(332, 388);
            this.groupBoxUtilisation.TabIndex = 1;
            this.groupBoxUtilisation.TabStop = false;
            this.groupBoxUtilisation.Text = "Utilisation";
            // 
            // btnDiagnostic
            // 
            this.btnDiagnostic.Location = new System.Drawing.Point(130, 11);
            this.btnDiagnostic.Name = "btnDiagnostic";
            this.btnDiagnostic.Size = new System.Drawing.Size(75, 23);
            this.btnDiagnostic.TabIndex = 201;
            this.btnDiagnostic.Text = "Diagnostic";
            this.btnDiagnostic.UseVisualStyleBackColor = true;
            this.btnDiagnostic.Click += new System.EventHandler(this.btnDiagnostic_Click);
            // 
            // trackBarPlus1
            // 
            this.trackBarPlus1.BackColor = System.Drawing.Color.Transparent;
            this.trackBarPlus1.DecimalPlaces = 0;
            this.trackBarPlus1.IntervalTimer = ((uint)(1u));
            this.trackBarPlus1.Location = new System.Drawing.Point(55, 80);
            this.trackBarPlus1.Max = 8000D;
            this.trackBarPlus1.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarPlus1.Min = 0D;
            this.trackBarPlus1.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarPlus1.Name = "trackBarPlus1";
            this.trackBarPlus1.Reverse = false;
            this.trackBarPlus1.Size = new System.Drawing.Size(150, 15);
            this.trackBarPlus1.TabIndex = 202;
            this.trackBarPlus1.Vertical = false;
            this.trackBarPlus1.TickValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackBarPlus1_TickValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 203;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PanelGrosRobotUtilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxUtilisation);
            this.Name = "PanelGrosRobotUtilisation";
            this.Size = new System.Drawing.Size(341, 395);
            this.Load += new System.EventHandler(this.PanelUtilGros_Load);
            this.groupBoxUtilisation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDiagnostic;
        private Composants.GroupBoxPlus groupBoxUtilisation;
        private Composants.TrackBarPlus trackBarPlus1;
        private System.Windows.Forms.Button button1;
    }
}
