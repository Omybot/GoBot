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
            this.btnFruitsPinceGaucheOuverte = new System.Windows.Forms.Button();
            this.btnFruitsPinceGaucheFermee = new System.Windows.Forms.Button();
            this.btnFruitsPinceGaucheOk = new System.Windows.Forms.Button();
            this.numFruitsPinceGauche = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFruitsPinceDroiteOuverte = new System.Windows.Forms.Button();
            this.btnFruitsPinceDroiteFermee = new System.Windows.Forms.Button();
            this.btnFruitsPinceDroiteOk = new System.Windows.Forms.Button();
            this.numFruitsPinceDroite = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFruitsEpauleOk = new System.Windows.Forms.Button();
            this.numFruitsEpaule = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFruitsCoudeOk = new System.Windows.Forms.Button();
            this.numFruitsCoude = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxReglage = new Composants.GroupBoxRetractable();
            this.btnFruitsEpauleRange = new System.Windows.Forms.Button();
            this.btnFruitsCoudeRange = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numFeuxEpaule = new System.Windows.Forms.NumericUpDown();
            this.btnFeuxOkEpaule = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFeuxOkCoude = new System.Windows.Forms.Button();
            this.numFeuxCoude = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numFeuxPoignet = new System.Windows.Forms.NumericUpDown();
            this.btnFeuxOkPoignet = new System.Windows.Forms.Button();
            this.cboFeuxEpaule = new System.Windows.Forms.ComboBox();
            this.cboFeuxCoude = new System.Windows.Forms.ComboBox();
            this.cboFeuxPoignet = new System.Windows.Forms.ComboBox();
            this.btnFeuxEpauleSave = new System.Windows.Forms.Button();
            this.btnFeuxCoudeSave = new System.Windows.Forms.Button();
            this.btnFeuxPoignetSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numFruitsPinceGauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFruitsPinceDroite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFruitsEpaule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFruitsCoude)).BeginInit();
            this.groupBoxReglage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFeuxEpaule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFeuxCoude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFeuxPoignet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFruitsPinceGaucheOuverte
            // 
            this.btnFruitsPinceGaucheOuverte.Location = new System.Drawing.Point(265, 123);
            this.btnFruitsPinceGaucheOuverte.Name = "btnFruitsPinceGaucheOuverte";
            this.btnFruitsPinceGaucheOuverte.Size = new System.Drawing.Size(53, 23);
            this.btnFruitsPinceGaucheOuverte.TabIndex = 142;
            this.btnFruitsPinceGaucheOuverte.Text = "Ouverte";
            this.btnFruitsPinceGaucheOuverte.UseVisualStyleBackColor = true;
            this.btnFruitsPinceGaucheOuverte.Click += new System.EventHandler(this.btnPinceGaucheOuverte_Click);
            // 
            // btnFruitsPinceGaucheFermee
            // 
            this.btnFruitsPinceGaucheFermee.Location = new System.Drawing.Point(206, 123);
            this.btnFruitsPinceGaucheFermee.Name = "btnFruitsPinceGaucheFermee";
            this.btnFruitsPinceGaucheFermee.Size = new System.Drawing.Size(53, 23);
            this.btnFruitsPinceGaucheFermee.TabIndex = 141;
            this.btnFruitsPinceGaucheFermee.Text = "Fermée";
            this.btnFruitsPinceGaucheFermee.UseVisualStyleBackColor = true;
            this.btnFruitsPinceGaucheFermee.Click += new System.EventHandler(this.btnPinceGaucheFermee_Click);
            // 
            // btnFruitsPinceGaucheOk
            // 
            this.btnFruitsPinceGaucheOk.Location = new System.Drawing.Point(147, 123);
            this.btnFruitsPinceGaucheOk.Name = "btnFruitsPinceGaucheOk";
            this.btnFruitsPinceGaucheOk.Size = new System.Drawing.Size(53, 23);
            this.btnFruitsPinceGaucheOk.TabIndex = 140;
            this.btnFruitsPinceGaucheOk.Text = "Ok";
            this.btnFruitsPinceGaucheOk.UseVisualStyleBackColor = true;
            this.btnFruitsPinceGaucheOk.Click += new System.EventHandler(this.btnPinceGaucheOk_Click);
            // 
            // numFruitsPinceGauche
            // 
            this.numFruitsPinceGauche.Location = new System.Drawing.Point(89, 126);
            this.numFruitsPinceGauche.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numFruitsPinceGauche.Name = "numFruitsPinceGauche";
            this.numFruitsPinceGauche.Size = new System.Drawing.Size(52, 20);
            this.numFruitsPinceGauche.TabIndex = 139;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 138;
            this.label5.Text = "Pince gauche";
            // 
            // btnFruitsPinceDroiteOuverte
            // 
            this.btnFruitsPinceDroiteOuverte.Location = new System.Drawing.Point(265, 97);
            this.btnFruitsPinceDroiteOuverte.Name = "btnFruitsPinceDroiteOuverte";
            this.btnFruitsPinceDroiteOuverte.Size = new System.Drawing.Size(53, 23);
            this.btnFruitsPinceDroiteOuverte.TabIndex = 136;
            this.btnFruitsPinceDroiteOuverte.Text = "Ouverte";
            this.btnFruitsPinceDroiteOuverte.UseVisualStyleBackColor = true;
            this.btnFruitsPinceDroiteOuverte.Click += new System.EventHandler(this.btnPinceDroiteOuverte_Click);
            // 
            // btnFruitsPinceDroiteFermee
            // 
            this.btnFruitsPinceDroiteFermee.Location = new System.Drawing.Point(206, 97);
            this.btnFruitsPinceDroiteFermee.Name = "btnFruitsPinceDroiteFermee";
            this.btnFruitsPinceDroiteFermee.Size = new System.Drawing.Size(53, 23);
            this.btnFruitsPinceDroiteFermee.TabIndex = 135;
            this.btnFruitsPinceDroiteFermee.Text = "Fermée";
            this.btnFruitsPinceDroiteFermee.UseVisualStyleBackColor = true;
            this.btnFruitsPinceDroiteFermee.Click += new System.EventHandler(this.btnPinceDroiteFermee_Click);
            // 
            // btnFruitsPinceDroiteOk
            // 
            this.btnFruitsPinceDroiteOk.Location = new System.Drawing.Point(147, 97);
            this.btnFruitsPinceDroiteOk.Name = "btnFruitsPinceDroiteOk";
            this.btnFruitsPinceDroiteOk.Size = new System.Drawing.Size(53, 23);
            this.btnFruitsPinceDroiteOk.TabIndex = 134;
            this.btnFruitsPinceDroiteOk.Text = "Ok";
            this.btnFruitsPinceDroiteOk.UseVisualStyleBackColor = true;
            this.btnFruitsPinceDroiteOk.Click += new System.EventHandler(this.btnPinceDroiteOk_Click);
            // 
            // numFruitsPinceDroite
            // 
            this.numFruitsPinceDroite.Location = new System.Drawing.Point(89, 100);
            this.numFruitsPinceDroite.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numFruitsPinceDroite.Name = "numFruitsPinceDroite";
            this.numFruitsPinceDroite.Size = new System.Drawing.Size(52, 20);
            this.numFruitsPinceDroite.TabIndex = 133;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 132;
            this.label4.Text = "Pince droite";
            // 
            // btnFruitsEpauleOk
            // 
            this.btnFruitsEpauleOk.Location = new System.Drawing.Point(147, 71);
            this.btnFruitsEpauleOk.Name = "btnFruitsEpauleOk";
            this.btnFruitsEpauleOk.Size = new System.Drawing.Size(53, 23);
            this.btnFruitsEpauleOk.TabIndex = 129;
            this.btnFruitsEpauleOk.Text = "Ok";
            this.btnFruitsEpauleOk.UseVisualStyleBackColor = true;
            this.btnFruitsEpauleOk.Click += new System.EventHandler(this.btnEpauleOk_Click);
            // 
            // numFruitsEpaule
            // 
            this.numFruitsEpaule.Location = new System.Drawing.Point(89, 74);
            this.numFruitsEpaule.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numFruitsEpaule.Name = "numFruitsEpaule";
            this.numFruitsEpaule.Size = new System.Drawing.Size(52, 20);
            this.numFruitsEpaule.TabIndex = 128;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 127;
            this.label1.Text = "Epaule";
            // 
            // btnFruitsCoudeOk
            // 
            this.btnFruitsCoudeOk.Location = new System.Drawing.Point(147, 45);
            this.btnFruitsCoudeOk.Name = "btnFruitsCoudeOk";
            this.btnFruitsCoudeOk.Size = new System.Drawing.Size(53, 23);
            this.btnFruitsCoudeOk.TabIndex = 124;
            this.btnFruitsCoudeOk.Text = "Ok";
            this.btnFruitsCoudeOk.UseVisualStyleBackColor = true;
            this.btnFruitsCoudeOk.Click += new System.EventHandler(this.btnCoudeOk_Click);
            // 
            // numFruitsCoude
            // 
            this.numFruitsCoude.Location = new System.Drawing.Point(89, 48);
            this.numFruitsCoude.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numFruitsCoude.Name = "numFruitsCoude";
            this.numFruitsCoude.Size = new System.Drawing.Size(52, 20);
            this.numFruitsCoude.TabIndex = 123;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 122;
            this.label3.Text = "Coude";
            // 
            // groupBoxReglage
            // 
            this.groupBoxReglage.Controls.Add(this.btnFeuxEpauleSave);
            this.groupBoxReglage.Controls.Add(this.btnFeuxCoudeSave);
            this.groupBoxReglage.Controls.Add(this.btnFeuxPoignetSave);
            this.groupBoxReglage.Controls.Add(this.cboFeuxPoignet);
            this.groupBoxReglage.Controls.Add(this.cboFeuxCoude);
            this.groupBoxReglage.Controls.Add(this.cboFeuxEpaule);
            this.groupBoxReglage.Controls.Add(this.label7);
            this.groupBoxReglage.Controls.Add(this.numFeuxEpaule);
            this.groupBoxReglage.Controls.Add(this.btnFeuxOkEpaule);
            this.groupBoxReglage.Controls.Add(this.label8);
            this.groupBoxReglage.Controls.Add(this.btnFeuxOkCoude);
            this.groupBoxReglage.Controls.Add(this.numFeuxCoude);
            this.groupBoxReglage.Controls.Add(this.label9);
            this.groupBoxReglage.Controls.Add(this.numFeuxPoignet);
            this.groupBoxReglage.Controls.Add(this.btnFeuxOkPoignet);
            this.groupBoxReglage.Controls.Add(this.label6);
            this.groupBoxReglage.Controls.Add(this.btnFruitsEpauleRange);
            this.groupBoxReglage.Controls.Add(this.label2);
            this.groupBoxReglage.Controls.Add(this.btnFruitsCoudeRange);
            this.groupBoxReglage.Controls.Add(this.label3);
            this.groupBoxReglage.Controls.Add(this.numFruitsCoude);
            this.groupBoxReglage.Controls.Add(this.btnFruitsCoudeOk);
            this.groupBoxReglage.Controls.Add(this.label1);
            this.groupBoxReglage.Controls.Add(this.btnFruitsEpauleOk);
            this.groupBoxReglage.Controls.Add(this.numFruitsEpaule);
            this.groupBoxReglage.Controls.Add(this.label4);
            this.groupBoxReglage.Controls.Add(this.btnFruitsPinceGaucheOuverte);
            this.groupBoxReglage.Controls.Add(this.btnFruitsPinceGaucheFermee);
            this.groupBoxReglage.Controls.Add(this.numFruitsPinceDroite);
            this.groupBoxReglage.Controls.Add(this.btnFruitsPinceGaucheOk);
            this.groupBoxReglage.Controls.Add(this.btnFruitsPinceDroiteOk);
            this.groupBoxReglage.Controls.Add(this.label5);
            this.groupBoxReglage.Controls.Add(this.numFruitsPinceGauche);
            this.groupBoxReglage.Controls.Add(this.btnFruitsPinceDroiteFermee);
            this.groupBoxReglage.Controls.Add(this.btnFruitsPinceDroiteOuverte);
            this.groupBoxReglage.Location = new System.Drawing.Point(3, 3);
            this.groupBoxReglage.Name = "groupBoxReglage";
            this.groupBoxReglage.Size = new System.Drawing.Size(332, 382);
            this.groupBoxReglage.TabIndex = 1;
            this.groupBoxReglage.TabStop = false;
            this.groupBoxReglage.Text = "Réglages";
            // 
            // btnFruitsEpauleRange
            // 
            this.btnFruitsEpauleRange.Location = new System.Drawing.Point(206, 71);
            this.btnFruitsEpauleRange.Name = "btnFruitsEpauleRange";
            this.btnFruitsEpauleRange.Size = new System.Drawing.Size(53, 23);
            this.btnFruitsEpauleRange.TabIndex = 144;
            this.btnFruitsEpauleRange.Text = "Rangé";
            this.btnFruitsEpauleRange.UseVisualStyleBackColor = true;
            this.btnFruitsEpauleRange.Click += new System.EventHandler(this.btnEpauleRange_Click);
            // 
            // btnFruitsCoudeRange
            // 
            this.btnFruitsCoudeRange.Location = new System.Drawing.Point(206, 45);
            this.btnFruitsCoudeRange.Name = "btnFruitsCoudeRange";
            this.btnFruitsCoudeRange.Size = new System.Drawing.Size(53, 23);
            this.btnFruitsCoudeRange.TabIndex = 143;
            this.btnFruitsCoudeRange.Text = "Rangé";
            this.btnFruitsCoudeRange.UseVisualStyleBackColor = true;
            this.btnFruitsCoudeRange.Click += new System.EventHandler(this.btnCoudeRange_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 145;
            this.label2.Text = "Fruits :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 146;
            this.label6.Text = "Feux :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 147;
            this.label7.Text = "Epaule";
            // 
            // numFeuxEpaule
            // 
            this.numFeuxEpaule.Location = new System.Drawing.Point(89, 199);
            this.numFeuxEpaule.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numFeuxEpaule.Name = "numFeuxEpaule";
            this.numFeuxEpaule.Size = new System.Drawing.Size(52, 20);
            this.numFeuxEpaule.TabIndex = 148;
            // 
            // btnFeuxOkEpaule
            // 
            this.btnFeuxOkEpaule.Location = new System.Drawing.Point(147, 196);
            this.btnFeuxOkEpaule.Name = "btnFeuxOkEpaule";
            this.btnFeuxOkEpaule.Size = new System.Drawing.Size(32, 23);
            this.btnFeuxOkEpaule.TabIndex = 149;
            this.btnFeuxOkEpaule.Text = "Ok";
            this.btnFeuxOkEpaule.UseVisualStyleBackColor = true;
            this.btnFeuxOkEpaule.Click += new System.EventHandler(this.btnFeuxOkEpaule_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 150;
            this.label8.Text = "Coude";
            // 
            // btnFeuxOkCoude
            // 
            this.btnFeuxOkCoude.Location = new System.Drawing.Point(147, 222);
            this.btnFeuxOkCoude.Name = "btnFeuxOkCoude";
            this.btnFeuxOkCoude.Size = new System.Drawing.Size(32, 23);
            this.btnFeuxOkCoude.TabIndex = 152;
            this.btnFeuxOkCoude.Text = "Ok";
            this.btnFeuxOkCoude.UseVisualStyleBackColor = true;
            this.btnFeuxOkCoude.Click += new System.EventHandler(this.btnFeuxOkCoude_Click);
            // 
            // numFeuxCoude
            // 
            this.numFeuxCoude.Location = new System.Drawing.Point(89, 225);
            this.numFeuxCoude.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numFeuxCoude.Name = "numFeuxCoude";
            this.numFeuxCoude.Size = new System.Drawing.Size(52, 20);
            this.numFeuxCoude.TabIndex = 151;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 153;
            this.label9.Text = "Poignet";
            // 
            // numFeuxPoignet
            // 
            this.numFeuxPoignet.Location = new System.Drawing.Point(89, 251);
            this.numFeuxPoignet.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numFeuxPoignet.Name = "numFeuxPoignet";
            this.numFeuxPoignet.Size = new System.Drawing.Size(52, 20);
            this.numFeuxPoignet.TabIndex = 154;
            // 
            // btnFeuxOkPoignet
            // 
            this.btnFeuxOkPoignet.Location = new System.Drawing.Point(147, 248);
            this.btnFeuxOkPoignet.Name = "btnFeuxOkPoignet";
            this.btnFeuxOkPoignet.Size = new System.Drawing.Size(32, 23);
            this.btnFeuxOkPoignet.TabIndex = 155;
            this.btnFeuxOkPoignet.Text = "Ok";
            this.btnFeuxOkPoignet.UseVisualStyleBackColor = true;
            this.btnFeuxOkPoignet.Click += new System.EventHandler(this.btnFeuxOkPoignet_Click);
            // 
            // cboFeuxEpaule
            // 
            this.cboFeuxEpaule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeuxEpaule.FormattingEnabled = true;
            this.cboFeuxEpaule.Location = new System.Drawing.Point(185, 198);
            this.cboFeuxEpaule.Name = "cboFeuxEpaule";
            this.cboFeuxEpaule.Size = new System.Drawing.Size(95, 21);
            this.cboFeuxEpaule.TabIndex = 156;
            // 
            // cboFeuxCoude
            // 
            this.cboFeuxCoude.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeuxCoude.FormattingEnabled = true;
            this.cboFeuxCoude.Location = new System.Drawing.Point(185, 224);
            this.cboFeuxCoude.Name = "cboFeuxCoude";
            this.cboFeuxCoude.Size = new System.Drawing.Size(95, 21);
            this.cboFeuxCoude.TabIndex = 157;
            // 
            // cboFeuxPoignet
            // 
            this.cboFeuxPoignet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeuxPoignet.FormattingEnabled = true;
            this.cboFeuxPoignet.Location = new System.Drawing.Point(185, 250);
            this.cboFeuxPoignet.Name = "cboFeuxPoignet";
            this.cboFeuxPoignet.Size = new System.Drawing.Size(95, 21);
            this.cboFeuxPoignet.TabIndex = 158;
            // 
            // btnFeuxEpauleSave
            // 
            this.btnFeuxEpauleSave.Location = new System.Drawing.Point(286, 196);
            this.btnFeuxEpauleSave.Name = "btnFeuxEpauleSave";
            this.btnFeuxEpauleSave.Size = new System.Drawing.Size(32, 23);
            this.btnFeuxEpauleSave.TabIndex = 159;
            this.btnFeuxEpauleSave.Text = "Ok";
            this.btnFeuxEpauleSave.UseVisualStyleBackColor = true;
            this.btnFeuxEpauleSave.Click += new System.EventHandler(this.btnFeuxEpauleSave_Click);
            // 
            // btnFeuxCoudeSave
            // 
            this.btnFeuxCoudeSave.Location = new System.Drawing.Point(286, 222);
            this.btnFeuxCoudeSave.Name = "btnFeuxCoudeSave";
            this.btnFeuxCoudeSave.Size = new System.Drawing.Size(32, 23);
            this.btnFeuxCoudeSave.TabIndex = 160;
            this.btnFeuxCoudeSave.Text = "Ok";
            this.btnFeuxCoudeSave.UseVisualStyleBackColor = true;
            this.btnFeuxCoudeSave.Click += new System.EventHandler(this.btnFeuxCoudeSave_Click);
            // 
            // btnFeuxPoignetSave
            // 
            this.btnFeuxPoignetSave.Location = new System.Drawing.Point(286, 248);
            this.btnFeuxPoignetSave.Name = "btnFeuxPoignetSave";
            this.btnFeuxPoignetSave.Size = new System.Drawing.Size(32, 23);
            this.btnFeuxPoignetSave.TabIndex = 161;
            this.btnFeuxPoignetSave.Text = "Ok";
            this.btnFeuxPoignetSave.UseVisualStyleBackColor = true;
            this.btnFeuxPoignetSave.Click += new System.EventHandler(this.btnFeuxPoignetSave_Click);
            // 
            // PanelGrosRobotReglage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxReglage);
            this.Name = "PanelGrosRobotReglage";
            this.Size = new System.Drawing.Size(341, 396);
            this.Load += new System.EventHandler(this.PanelReglageGros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFruitsPinceGauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFruitsPinceDroite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFruitsEpaule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFruitsCoude)).EndInit();
            this.groupBoxReglage.ResumeLayout(false);
            this.groupBoxReglage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFeuxEpaule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFeuxCoude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFeuxPoignet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFruitsEpauleOk;
        private System.Windows.Forms.NumericUpDown numFruitsEpaule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFruitsCoudeOk;
        private System.Windows.Forms.NumericUpDown numFruitsCoude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFruitsPinceGaucheOuverte;
        private System.Windows.Forms.Button btnFruitsPinceGaucheFermee;
        private System.Windows.Forms.Button btnFruitsPinceGaucheOk;
        private System.Windows.Forms.NumericUpDown numFruitsPinceGauche;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFruitsPinceDroiteOuverte;
        private System.Windows.Forms.Button btnFruitsPinceDroiteFermee;
        private System.Windows.Forms.Button btnFruitsPinceDroiteOk;
        private System.Windows.Forms.NumericUpDown numFruitsPinceDroite;
        private System.Windows.Forms.Label label4;
        private Composants.GroupBoxRetractable groupBoxReglage;
        private System.Windows.Forms.Button btnFruitsEpauleRange;
        private System.Windows.Forms.Button btnFruitsCoudeRange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numFeuxEpaule;
        private System.Windows.Forms.Button btnFeuxOkEpaule;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFeuxOkCoude;
        private System.Windows.Forms.NumericUpDown numFeuxCoude;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numFeuxPoignet;
        private System.Windows.Forms.Button btnFeuxOkPoignet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFeuxEpauleSave;
        private System.Windows.Forms.Button btnFeuxCoudeSave;
        private System.Windows.Forms.Button btnFeuxPoignetSave;
        private System.Windows.Forms.ComboBox cboFeuxPoignet;
        private System.Windows.Forms.ComboBox cboFeuxCoude;
        private System.Windows.Forms.ComboBox cboFeuxEpaule;
    }
}
