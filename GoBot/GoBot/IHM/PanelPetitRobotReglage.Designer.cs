namespace GoBot.IHM
{
    partial class PanelPetitRobotReglage
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
            this.groupBoxReglage = new System.Windows.Forms.GroupBox();
            this.lblBrasFresque = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBarBrasFresque = new Composants.TrackBarPlus();
            this.lblPositionReservoir = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarReservoir = new Composants.TrackBarPlus();
            this.btnOkFilet = new System.Windows.Forms.Button();
            this.btnFiletTir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFiletArme = new System.Windows.Forms.Button();
            this.numTirFilet = new System.Windows.Forms.NumericUpDown();
            this.btnTaille = new System.Windows.Forms.Button();
            this.lblTensionTissu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarTensionTissu = new Composants.TrackBarPlus();
            this.btnRideauRelache = new System.Windows.Forms.Button();
            this.btnRideauTendu = new System.Windows.Forms.Button();
            this.groupBoxReglage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTirFilet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxReglage
            // 
            this.groupBoxReglage.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxReglage.Controls.Add(this.btnRideauRelache);
            this.groupBoxReglage.Controls.Add(this.btnRideauTendu);
            this.groupBoxReglage.Controls.Add(this.lblTensionTissu);
            this.groupBoxReglage.Controls.Add(this.label5);
            this.groupBoxReglage.Controls.Add(this.trackBarTensionTissu);
            this.groupBoxReglage.Controls.Add(this.lblBrasFresque);
            this.groupBoxReglage.Controls.Add(this.label4);
            this.groupBoxReglage.Controls.Add(this.trackBarBrasFresque);
            this.groupBoxReglage.Controls.Add(this.lblPositionReservoir);
            this.groupBoxReglage.Controls.Add(this.label2);
            this.groupBoxReglage.Controls.Add(this.trackBarReservoir);
            this.groupBoxReglage.Controls.Add(this.btnOkFilet);
            this.groupBoxReglage.Controls.Add(this.btnFiletTir);
            this.groupBoxReglage.Controls.Add(this.label1);
            this.groupBoxReglage.Controls.Add(this.btnFiletArme);
            this.groupBoxReglage.Controls.Add(this.numTirFilet);
            this.groupBoxReglage.Controls.Add(this.btnTaille);
            this.groupBoxReglage.Location = new System.Drawing.Point(5, 3);
            this.groupBoxReglage.Name = "groupBoxReglage";
            this.groupBoxReglage.Size = new System.Drawing.Size(332, 256);
            this.groupBoxReglage.TabIndex = 0;
            this.groupBoxReglage.TabStop = false;
            this.groupBoxReglage.Text = "Réglage";
            // 
            // lblBrasFresque
            // 
            this.lblBrasFresque.AutoSize = true;
            this.lblBrasFresque.Location = new System.Drawing.Point(176, 137);
            this.lblBrasFresque.Name = "lblBrasFresque";
            this.lblBrasFresque.Size = new System.Drawing.Size(10, 13);
            this.lblBrasFresque.TabIndex = 155;
            this.lblBrasFresque.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 154;
            this.label4.Text = "Bras fresque";
            // 
            // trackBarBrasFresque
            // 
            this.trackBarBrasFresque.BackColor = System.Drawing.Color.Transparent;
            this.trackBarBrasFresque.IntervalTimer = 1;
            this.trackBarBrasFresque.Location = new System.Drawing.Point(32, 153);
            this.trackBarBrasFresque.Max = 1023D;
            this.trackBarBrasFresque.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarBrasFresque.Min = 0D;
            this.trackBarBrasFresque.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarBrasFresque.Name = "trackBarBrasFresque";
            this.trackBarBrasFresque.NombreDecimales = 0;
            this.trackBarBrasFresque.Reverse = false;
            this.trackBarBrasFresque.Size = new System.Drawing.Size(284, 15);
            this.trackBarBrasFresque.TabIndex = 153;
            this.trackBarBrasFresque.Vertical = false;
            this.trackBarBrasFresque.TickValueChanged += new System.EventHandler(this.trackBarBrasFresque_TickValueChanged);
            this.trackBarBrasFresque.ValueChanged += new System.EventHandler(this.trackBarBrasFresque_ValueChanged);
            // 
            // lblPositionReservoir
            // 
            this.lblPositionReservoir.AutoSize = true;
            this.lblPositionReservoir.Location = new System.Drawing.Point(176, 97);
            this.lblPositionReservoir.Name = "lblPositionReservoir";
            this.lblPositionReservoir.Size = new System.Drawing.Size(10, 13);
            this.lblPositionReservoir.TabIndex = 152;
            this.lblPositionReservoir.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 151;
            this.label2.Text = "Reservoir bouchons";
            // 
            // trackBarReservoir
            // 
            this.trackBarReservoir.BackColor = System.Drawing.Color.Transparent;
            this.trackBarReservoir.IntervalTimer = 1;
            this.trackBarReservoir.Location = new System.Drawing.Point(32, 113);
            this.trackBarReservoir.Max = 1023D;
            this.trackBarReservoir.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarReservoir.Min = 0D;
            this.trackBarReservoir.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarReservoir.Name = "trackBarReservoir";
            this.trackBarReservoir.NombreDecimales = 0;
            this.trackBarReservoir.Reverse = false;
            this.trackBarReservoir.Size = new System.Drawing.Size(284, 15);
            this.trackBarReservoir.TabIndex = 150;
            this.trackBarReservoir.Vertical = false;
            this.trackBarReservoir.TickValueChanged += new System.EventHandler(this.trackBarReservoir_TickValueChanged);
            this.trackBarReservoir.ValueChanged += new System.EventHandler(this.trackBarReservoir_ValueChanged);
            // 
            // btnOkFilet
            // 
            this.btnOkFilet.Location = new System.Drawing.Point(145, 48);
            this.btnOkFilet.Name = "btnOkFilet";
            this.btnOkFilet.Size = new System.Drawing.Size(53, 23);
            this.btnOkFilet.TabIndex = 149;
            this.btnOkFilet.Text = "Ok";
            this.btnOkFilet.UseVisualStyleBackColor = true;
            this.btnOkFilet.Click += new System.EventHandler(this.btnOkFilet_Click);
            // 
            // btnFiletTir
            // 
            this.btnFiletTir.Location = new System.Drawing.Point(204, 48);
            this.btnFiletTir.Name = "btnFiletTir";
            this.btnFiletTir.Size = new System.Drawing.Size(53, 23);
            this.btnFiletTir.TabIndex = 148;
            this.btnFiletTir.Text = "Tir";
            this.btnFiletTir.UseVisualStyleBackColor = true;
            this.btnFiletTir.Click += new System.EventHandler(this.btnFiletTir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 145;
            this.label1.Text = "Tir filet";
            // 
            // btnFiletArme
            // 
            this.btnFiletArme.Location = new System.Drawing.Point(263, 48);
            this.btnFiletArme.Name = "btnFiletArme";
            this.btnFiletArme.Size = new System.Drawing.Size(53, 23);
            this.btnFiletArme.TabIndex = 147;
            this.btnFiletArme.Text = "Arme";
            this.btnFiletArme.UseVisualStyleBackColor = true;
            this.btnFiletArme.Click += new System.EventHandler(this.btnFiletArme_Click);
            // 
            // numTirFilet
            // 
            this.numTirFilet.Location = new System.Drawing.Point(87, 51);
            this.numTirFilet.Maximum = new decimal(new int[] {
            312,
            0,
            0,
            0});
            this.numTirFilet.Name = "numTirFilet";
            this.numTirFilet.Size = new System.Drawing.Size(52, 20);
            this.numTirFilet.TabIndex = 146;
            // 
            // btnTaille
            // 
            this.btnTaille.Image = global::GoBot.Properties.Resources.Haut;
            this.btnTaille.Location = new System.Drawing.Point(304, 10);
            this.btnTaille.Name = "btnTaille";
            this.btnTaille.Size = new System.Drawing.Size(24, 23);
            this.btnTaille.TabIndex = 87;
            this.btnTaille.UseVisualStyleBackColor = true;
            this.btnTaille.Click += new System.EventHandler(this.btnTaille_Click);
            // 
            // lblTensionTissu
            // 
            this.lblTensionTissu.AutoSize = true;
            this.lblTensionTissu.Location = new System.Drawing.Point(176, 178);
            this.lblTensionTissu.Name = "lblTensionTissu";
            this.lblTensionTissu.Size = new System.Drawing.Size(10, 13);
            this.lblTensionTissu.TabIndex = 158;
            this.lblTensionTissu.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 157;
            this.label5.Text = "Tension tissu";
            // 
            // trackBarTensionTissu
            // 
            this.trackBarTensionTissu.BackColor = System.Drawing.Color.Transparent;
            this.trackBarTensionTissu.IntervalTimer = 1;
            this.trackBarTensionTissu.Location = new System.Drawing.Point(32, 194);
            this.trackBarTensionTissu.Max = 312D;
            this.trackBarTensionTissu.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarTensionTissu.Min = 0D;
            this.trackBarTensionTissu.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarTensionTissu.Name = "trackBarTensionTissu";
            this.trackBarTensionTissu.NombreDecimales = 0;
            this.trackBarTensionTissu.Reverse = false;
            this.trackBarTensionTissu.Size = new System.Drawing.Size(284, 15);
            this.trackBarTensionTissu.TabIndex = 156;
            this.trackBarTensionTissu.Vertical = false;
            this.trackBarTensionTissu.TickValueChanged += new System.EventHandler(this.trackBarTensionTissu_TickValueChanged);
            this.trackBarTensionTissu.ValueChanged += new System.EventHandler(this.trackBarTensionTissu_ValueChanged);
            // 
            // btnRideauRelache
            // 
            this.btnRideauRelache.Location = new System.Drawing.Point(204, 210);
            this.btnRideauRelache.Name = "btnRideauRelache";
            this.btnRideauRelache.Size = new System.Drawing.Size(53, 23);
            this.btnRideauRelache.TabIndex = 160;
            this.btnRideauRelache.Text = "Lâche";
            this.btnRideauRelache.UseVisualStyleBackColor = true;
            this.btnRideauRelache.Click += new System.EventHandler(this.btnRideauRelache_Click);
            // 
            // btnRideauTendu
            // 
            this.btnRideauTendu.Location = new System.Drawing.Point(263, 210);
            this.btnRideauTendu.Name = "btnRideauTendu";
            this.btnRideauTendu.Size = new System.Drawing.Size(53, 23);
            this.btnRideauTendu.TabIndex = 159;
            this.btnRideauTendu.Text = "Tendu";
            this.btnRideauTendu.UseVisualStyleBackColor = true;
            this.btnRideauTendu.Click += new System.EventHandler(this.btnRideauTendu_Click);
            // 
            // PanelPetitRobotReglage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxReglage);
            this.Name = "PanelPetitRobotReglage";
            this.Size = new System.Drawing.Size(341, 262);
            this.Load += new System.EventHandler(this.PanelPetitRobotReglage_Load);
            this.groupBoxReglage.ResumeLayout(false);
            this.groupBoxReglage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTirFilet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxReglage;
        protected System.Windows.Forms.Button btnTaille;
        private System.Windows.Forms.Button btnFiletTir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFiletArme;
        private System.Windows.Forms.NumericUpDown numTirFilet;
        private System.Windows.Forms.Button btnOkFilet;
        private System.Windows.Forms.Label lblPositionReservoir;
        private System.Windows.Forms.Label label2;
        private Composants.TrackBarPlus trackBarReservoir;
        private System.Windows.Forms.Label lblBrasFresque;
        private System.Windows.Forms.Label label4;
        private Composants.TrackBarPlus trackBarBrasFresque;
        private System.Windows.Forms.Label lblTensionTissu;
        private System.Windows.Forms.Label label5;
        private Composants.TrackBarPlus trackBarTensionTissu;
        private System.Windows.Forms.Button btnRideauRelache;
        private System.Windows.Forms.Button btnRideauTendu;
    }
}
