using Composants;
namespace GoBot.IHM
{
    partial class PanelGrosRobotReglage
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
            this.groupBoxReglage = new Composants.GroupBoxPlus();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBarValeurPosition = new Composants.TrackBarPlus();
            this.btnSauvegarderPosition = new System.Windows.Forms.Button();
            this.btnEnvoyerValeurPosition = new System.Windows.Forms.Button();
            this.comboBoxPositionnables = new System.Windows.Forms.ComboBox();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.numValeurPosition = new System.Windows.Forms.NumericUpDown();
            this.groupBoxReglage.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValeurPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxReglage
            // 
            this.groupBoxReglage.Controls.Add(this.flowLayoutPanel);
            this.groupBoxReglage.Location = new System.Drawing.Point(3, 3);
            this.groupBoxReglage.Name = "groupBoxReglage";
            this.groupBoxReglage.Size = new System.Drawing.Size(332, 210);
            this.groupBoxReglage.TabIndex = 1;
            this.groupBoxReglage.TabStop = false;
            this.groupBoxReglage.Text = "Réglages";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.groupBox1);
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 32);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(323, 171);
            this.flowLayoutPanel.TabIndex = 32;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 155);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Positions";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trackBarValeurPosition);
            this.panel1.Controls.Add(this.btnSauvegarderPosition);
            this.panel1.Controls.Add(this.btnEnvoyerValeurPosition);
            this.panel1.Controls.Add(this.comboBoxPositionnables);
            this.panel1.Controls.Add(this.comboBoxPosition);
            this.panel1.Controls.Add(this.numValeurPosition);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 131);
            this.panel1.TabIndex = 34;
            // 
            // trackBarValeurPosition
            // 
            this.trackBarValeurPosition.BackColor = System.Drawing.Color.Transparent;
            this.trackBarValeurPosition.IntervalTimer = 1;
            this.trackBarValeurPosition.Location = new System.Drawing.Point(11, 110);
            this.trackBarValeurPosition.Max = 100D;
            this.trackBarValeurPosition.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarValeurPosition.Min = 0D;
            this.trackBarValeurPosition.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarValeurPosition.Name = "trackBarValeurPosition";
            this.trackBarValeurPosition.DecimalPlaces = 0;
            this.trackBarValeurPosition.Reverse = false;
            this.trackBarValeurPosition.Size = new System.Drawing.Size(294, 15);
            this.trackBarValeurPosition.TabIndex = 40;
            this.trackBarValeurPosition.Vertical = false;
            this.trackBarValeurPosition.TickValueChanged += new TrackBarPlus.ValueChangedDelegate(this.trackBarValeurPosition_TickValueChanged);
            // 
            // btnSauvegarderPosition
            // 
            this.btnSauvegarderPosition.Image = global::GoBot.Properties.Resources.Save16;
            this.btnSauvegarderPosition.Location = new System.Drawing.Point(11, 74);
            this.btnSauvegarderPosition.Name = "btnSauvegarderPosition";
            this.btnSauvegarderPosition.Size = new System.Drawing.Size(102, 23);
            this.btnSauvegarderPosition.TabIndex = 39;
            this.btnSauvegarderPosition.Text = "Sauvegarder";
            this.btnSauvegarderPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSauvegarderPosition.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSauvegarderPosition.UseVisualStyleBackColor = true;
            this.btnSauvegarderPosition.Click += new System.EventHandler(this.btnSauvegarderPosition_Click);
            // 
            // btnEnvoyerValeurPosition
            // 
            this.btnEnvoyerValeurPosition.Image = global::GoBot.Properties.Resources.Play16;
            this.btnEnvoyerValeurPosition.Location = new System.Drawing.Point(230, 74);
            this.btnEnvoyerValeurPosition.Name = "btnEnvoyerValeurPosition";
            this.btnEnvoyerValeurPosition.Size = new System.Drawing.Size(75, 23);
            this.btnEnvoyerValeurPosition.TabIndex = 38;
            this.btnEnvoyerValeurPosition.Text = "Envoyer";
            this.btnEnvoyerValeurPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnvoyerValeurPosition.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEnvoyerValeurPosition.UseVisualStyleBackColor = true;
            this.btnEnvoyerValeurPosition.Click += new System.EventHandler(this.btnEnvoyerValeurPosition_Click);
            // 
            // comboBoxPositionnables
            // 
            this.comboBoxPositionnables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPositionnables.FormattingEnabled = true;
            this.comboBoxPositionnables.Location = new System.Drawing.Point(10, 13);
            this.comboBoxPositionnables.Name = "comboBoxPositionnables";
            this.comboBoxPositionnables.Size = new System.Drawing.Size(236, 21);
            this.comboBoxPositionnables.TabIndex = 34;
            this.comboBoxPositionnables.SelectedValueChanged += new System.EventHandler(this.comboBoxPositionnables_SelectedValueChanged);
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Location = new System.Drawing.Point(10, 40);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(188, 21);
            this.comboBoxPosition.TabIndex = 35;
            this.comboBoxPosition.SelectedValueChanged += new System.EventHandler(this.comboBoxPosition_SelectedValueChanged);
            // 
            // numValeurPosition
            // 
            this.numValeurPosition.Location = new System.Drawing.Point(115, 75);
            this.numValeurPosition.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numValeurPosition.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.numValeurPosition.Name = "numValeurPosition";
            this.numValeurPosition.Size = new System.Drawing.Size(112, 20);
            this.numValeurPosition.TabIndex = 37;
            // 
            // PanelGrosRobotReglage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxReglage);
            this.Name = "PanelGrosRobotReglage";
            this.Size = new System.Drawing.Size(341, 223);
            this.Load += new System.EventHandler(this.PanelReglageGros_Load);
            this.groupBoxReglage.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numValeurPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.GroupBoxPlus groupBoxReglage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private TrackBarPlus trackBarValeurPosition;
        private System.Windows.Forms.Button btnSauvegarderPosition;
        private System.Windows.Forms.Button btnEnvoyerValeurPosition;
        private System.Windows.Forms.ComboBox comboBoxPositionnables;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.NumericUpDown numValeurPosition;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
