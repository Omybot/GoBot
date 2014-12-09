namespace GoBot.IHM
{
    partial class PanelMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelMatch));
            this.btnArmerJack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBalises = new System.Windows.Forms.Button();
            this.btnRecallage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBaliseNon = new System.Windows.Forms.RadioButton();
            this.radioBaliseOui = new System.Windows.Forms.RadioButton();
            this.btnJoueurGauche = new System.Windows.Forms.Button();
            this.btnJoueurDroite = new System.Windows.Forms.Button();
            this.btnCalibrationAssiette = new System.Windows.Forms.Button();
            this.btnCalibrationAngle = new System.Windows.Forms.Button();
            this.boxCalibrationAssiette = new System.Windows.Forms.CheckBox();
            this.boxCalibrationAngulaire = new System.Windows.Forms.CheckBox();
            this.pictureBoxTable = new System.Windows.Forms.PictureBox();
            this.pictureBoxCouleur = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnBalise1 = new System.Windows.Forms.Button();
            this.btnBalise2 = new System.Windows.Forms.Button();
            this.btnBalise3 = new System.Windows.Forms.Button();
            this.ledRecallagePetit = new Composants.Led();
            this.ledBalise3Angle = new Composants.Led();
            this.ledBalise2Angle = new Composants.Led();
            this.ledBalise1Angle = new Composants.Led();
            this.ledBalise3Assiette = new Composants.Led();
            this.ledBalise2Assiette = new Composants.Led();
            this.ledBalise1Assiette = new Composants.Led();
            this.ledBalise3Rotation = new Composants.Led();
            this.ledBalise2Rotation = new Composants.Led();
            this.ledJackArme = new Composants.Led();
            this.ledJackBranche = new Composants.Led();
            this.ledBalise1Rotation = new Composants.Led();
            this.ledRecallageGros = new Composants.Led();
            this.boxPetit = new System.Windows.Forms.CheckBox();
            this.lblBunGauche = new System.Windows.Forms.Label();
            this.lblBeuGauche = new System.Windows.Forms.Label();
            this.lblBoiDroite = new System.Windows.Forms.Label();
            this.lblBunDroite = new System.Windows.Forms.Label();
            this.lblBoiGauche = new System.Windows.Forms.Label();
            this.lblBeuDroite = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecallagePetit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise3Angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise2Angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise1Angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise3Assiette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise2Assiette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise1Assiette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise3Rotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise2Rotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackArme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise1Rotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecallageGros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnArmerJack
            // 
            this.btnArmerJack.Location = new System.Drawing.Point(15, 358);
            this.btnArmerJack.Name = "btnArmerJack";
            this.btnArmerJack.Size = new System.Drawing.Size(227, 23);
            this.btnArmerJack.TabIndex = 39;
            this.btnArmerJack.Text = "Armer le jack";
            this.btnArmerJack.UseVisualStyleBackColor = true;
            this.btnArmerJack.Click += new System.EventHandler(this.btnArmerJack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Jack branché";
            // 
            // btnBalises
            // 
            this.btnBalises.Location = new System.Drawing.Point(15, 271);
            this.btnBalises.Name = "btnBalises";
            this.btnBalises.Size = new System.Drawing.Size(227, 23);
            this.btnBalises.TabIndex = 27;
            this.btnBalises.Text = "Lancement des balises";
            this.btnBalises.UseVisualStyleBackColor = true;
            this.btnBalises.Click += new System.EventHandler(this.btnBalises_Click);
            // 
            // btnRecallage
            // 
            this.btnRecallage.Location = new System.Drawing.Point(15, 242);
            this.btnRecallage.Name = "btnRecallage";
            this.btnRecallage.Size = new System.Drawing.Size(227, 23);
            this.btnRecallage.TabIndex = 26;
            this.btnRecallage.Text = "Recallage des robots";
            this.btnRecallage.UseVisualStyleBackColor = true;
            this.btnRecallage.Click += new System.EventHandler(this.btnRecallage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBaliseNon);
            this.groupBox1.Controls.Add(this.radioBaliseOui);
            this.groupBox1.Location = new System.Drawing.Point(15, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 52);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balise réfléchissante sur nos robots ?";
            // 
            // radioBaliseNon
            // 
            this.radioBaliseNon.AutoSize = true;
            this.radioBaliseNon.Location = new System.Drawing.Point(135, 26);
            this.radioBaliseNon.Name = "radioBaliseNon";
            this.radioBaliseNon.Size = new System.Drawing.Size(45, 17);
            this.radioBaliseNon.TabIndex = 1;
            this.radioBaliseNon.Text = "Non";
            this.radioBaliseNon.UseVisualStyleBackColor = true;
            // 
            // radioBaliseOui
            // 
            this.radioBaliseOui.AutoSize = true;
            this.radioBaliseOui.Checked = true;
            this.radioBaliseOui.Location = new System.Drawing.Point(66, 26);
            this.radioBaliseOui.Name = "radioBaliseOui";
            this.radioBaliseOui.Size = new System.Drawing.Size(41, 17);
            this.radioBaliseOui.TabIndex = 0;
            this.radioBaliseOui.TabStop = true;
            this.radioBaliseOui.Text = "Oui";
            this.radioBaliseOui.UseVisualStyleBackColor = true;
            this.radioBaliseOui.CheckedChanged += new System.EventHandler(this.radioBaliseOui_CheckedChanged);
            // 
            // btnJoueurGauche
            // 
            this.btnJoueurGauche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(210)))), ((int)(((byte)(1)))));
            this.btnJoueurGauche.ForeColor = System.Drawing.Color.Black;
            this.btnJoueurGauche.Location = new System.Drawing.Point(15, 63);
            this.btnJoueurGauche.Name = "btnJoueurGauche";
            this.btnJoueurGauche.Size = new System.Drawing.Size(75, 50);
            this.btnJoueurGauche.TabIndex = 22;
            this.btnJoueurGauche.UseVisualStyleBackColor = false;
            this.btnJoueurGauche.Click += new System.EventHandler(this.btnCouleurJoueurGauche_Click);
            // 
            // btnJoueurDroite
            // 
            this.btnJoueurDroite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.btnJoueurDroite.ForeColor = System.Drawing.Color.Black;
            this.btnJoueurDroite.Location = new System.Drawing.Point(190, 63);
            this.btnJoueurDroite.Name = "btnJoueurDroite";
            this.btnJoueurDroite.Size = new System.Drawing.Size(75, 50);
            this.btnJoueurDroite.TabIndex = 21;
            this.btnJoueurDroite.UseVisualStyleBackColor = false;
            this.btnJoueurDroite.Click += new System.EventHandler(this.btnCouleurJoueurDroite_Click);
            // 
            // btnCalibrationAssiette
            // 
            this.btnCalibrationAssiette.Location = new System.Drawing.Point(52, 300);
            this.btnCalibrationAssiette.Name = "btnCalibrationAssiette";
            this.btnCalibrationAssiette.Size = new System.Drawing.Size(190, 23);
            this.btnCalibrationAssiette.TabIndex = 43;
            this.btnCalibrationAssiette.Text = "Calibration assiette";
            this.btnCalibrationAssiette.UseVisualStyleBackColor = true;
            this.btnCalibrationAssiette.Click += new System.EventHandler(this.btnCalibrationAssiette_Click);
            // 
            // btnCalibrationAngle
            // 
            this.btnCalibrationAngle.Location = new System.Drawing.Point(52, 329);
            this.btnCalibrationAngle.Name = "btnCalibrationAngle";
            this.btnCalibrationAngle.Size = new System.Drawing.Size(190, 23);
            this.btnCalibrationAngle.TabIndex = 44;
            this.btnCalibrationAngle.Text = "Calibration angulaire";
            this.btnCalibrationAngle.UseVisualStyleBackColor = true;
            this.btnCalibrationAngle.Click += new System.EventHandler(this.btnCalibrationAngle_Click);
            // 
            // boxCalibrationAssiette
            // 
            this.boxCalibrationAssiette.AutoSize = true;
            this.boxCalibrationAssiette.Checked = true;
            this.boxCalibrationAssiette.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxCalibrationAssiette.Location = new System.Drawing.Point(27, 304);
            this.boxCalibrationAssiette.Name = "boxCalibrationAssiette";
            this.boxCalibrationAssiette.Size = new System.Drawing.Size(15, 14);
            this.boxCalibrationAssiette.TabIndex = 53;
            this.boxCalibrationAssiette.UseVisualStyleBackColor = true;
            // 
            // boxCalibrationAngulaire
            // 
            this.boxCalibrationAngulaire.AutoSize = true;
            this.boxCalibrationAngulaire.Checked = true;
            this.boxCalibrationAngulaire.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxCalibrationAngulaire.Location = new System.Drawing.Point(27, 334);
            this.boxCalibrationAngulaire.Name = "boxCalibrationAngulaire";
            this.boxCalibrationAngulaire.Size = new System.Drawing.Size(15, 14);
            this.boxCalibrationAngulaire.TabIndex = 54;
            this.boxCalibrationAngulaire.UseVisualStyleBackColor = true;
            // 
            // pictureBoxTable
            // 
            this.pictureBoxTable.Image = global::GoBot.Properties.Resources.TablePlan;
            this.pictureBoxTable.Location = new System.Drawing.Point(421, 63);
            this.pictureBoxTable.Name = "pictureBoxTable";
            this.pictureBoxTable.Size = new System.Drawing.Size(782, 530);
            this.pictureBoxTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTable.TabIndex = 56;
            this.pictureBoxTable.TabStop = false;
            // 
            // pictureBoxCouleur
            // 
            this.pictureBoxCouleur.Location = new System.Drawing.Point(96, 63);
            this.pictureBoxCouleur.Name = "pictureBoxCouleur";
            this.pictureBoxCouleur.Size = new System.Drawing.Size(88, 50);
            this.pictureBoxCouleur.TabIndex = 23;
            this.pictureBoxCouleur.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(81, 424);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 63;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnBalise1
            // 
            this.btnBalise1.Location = new System.Drawing.Point(15, 482);
            this.btnBalise1.Name = "btnBalise1";
            this.btnBalise1.Size = new System.Drawing.Size(75, 23);
            this.btnBalise1.TabIndex = 64;
            this.btnBalise1.Text = "Reset B1";
            this.btnBalise1.UseVisualStyleBackColor = true;
            this.btnBalise1.Click += new System.EventHandler(this.btnBalise1_Click);
            // 
            // btnBalise2
            // 
            this.btnBalise2.Location = new System.Drawing.Point(96, 482);
            this.btnBalise2.Name = "btnBalise2";
            this.btnBalise2.Size = new System.Drawing.Size(75, 23);
            this.btnBalise2.TabIndex = 65;
            this.btnBalise2.Text = "Reset B2";
            this.btnBalise2.UseVisualStyleBackColor = true;
            this.btnBalise2.Click += new System.EventHandler(this.btnBalise2_Click);
            // 
            // btnBalise3
            // 
            this.btnBalise3.Location = new System.Drawing.Point(177, 482);
            this.btnBalise3.Name = "btnBalise3";
            this.btnBalise3.Size = new System.Drawing.Size(75, 23);
            this.btnBalise3.TabIndex = 66;
            this.btnBalise3.Text = "Reset B3";
            this.btnBalise3.UseVisualStyleBackColor = true;
            this.btnBalise3.Click += new System.EventHandler(this.btnBalise3_Click);
            // 
            // ledRecallagePetit
            // 
            this.ledRecallagePetit.Etat = false;
            this.ledRecallagePetit.Image = ((System.Drawing.Image)(resources.GetObject("ledRecallagePetit.Image")));
            this.ledRecallagePetit.Location = new System.Drawing.Point(271, 245);
            this.ledRecallagePetit.Name = "ledRecallagePetit";
            this.ledRecallagePetit.Size = new System.Drawing.Size(16, 16);
            this.ledRecallagePetit.TabIndex = 55;
            this.ledRecallagePetit.TabStop = false;
            // 
            // ledBalise3Angle
            // 
            this.ledBalise3Angle.Etat = false;
            this.ledBalise3Angle.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise3Angle.Image")));
            this.ledBalise3Angle.Location = new System.Drawing.Point(293, 332);
            this.ledBalise3Angle.Name = "ledBalise3Angle";
            this.ledBalise3Angle.Size = new System.Drawing.Size(16, 16);
            this.ledBalise3Angle.TabIndex = 52;
            this.ledBalise3Angle.TabStop = false;
            // 
            // ledBalise2Angle
            // 
            this.ledBalise2Angle.Etat = false;
            this.ledBalise2Angle.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise2Angle.Image")));
            this.ledBalise2Angle.Location = new System.Drawing.Point(271, 332);
            this.ledBalise2Angle.Name = "ledBalise2Angle";
            this.ledBalise2Angle.Size = new System.Drawing.Size(16, 16);
            this.ledBalise2Angle.TabIndex = 51;
            this.ledBalise2Angle.TabStop = false;
            // 
            // ledBalise1Angle
            // 
            this.ledBalise1Angle.Etat = false;
            this.ledBalise1Angle.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise1Angle.Image")));
            this.ledBalise1Angle.Location = new System.Drawing.Point(248, 332);
            this.ledBalise1Angle.Name = "ledBalise1Angle";
            this.ledBalise1Angle.Size = new System.Drawing.Size(16, 16);
            this.ledBalise1Angle.TabIndex = 50;
            this.ledBalise1Angle.TabStop = false;
            // 
            // ledBalise3Assiette
            // 
            this.ledBalise3Assiette.Etat = false;
            this.ledBalise3Assiette.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise3Assiette.Image")));
            this.ledBalise3Assiette.Location = new System.Drawing.Point(293, 303);
            this.ledBalise3Assiette.Name = "ledBalise3Assiette";
            this.ledBalise3Assiette.Size = new System.Drawing.Size(16, 16);
            this.ledBalise3Assiette.TabIndex = 49;
            this.ledBalise3Assiette.TabStop = false;
            // 
            // ledBalise2Assiette
            // 
            this.ledBalise2Assiette.Etat = false;
            this.ledBalise2Assiette.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise2Assiette.Image")));
            this.ledBalise2Assiette.Location = new System.Drawing.Point(271, 303);
            this.ledBalise2Assiette.Name = "ledBalise2Assiette";
            this.ledBalise2Assiette.Size = new System.Drawing.Size(16, 16);
            this.ledBalise2Assiette.TabIndex = 48;
            this.ledBalise2Assiette.TabStop = false;
            // 
            // ledBalise1Assiette
            // 
            this.ledBalise1Assiette.Etat = false;
            this.ledBalise1Assiette.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise1Assiette.Image")));
            this.ledBalise1Assiette.Location = new System.Drawing.Point(248, 303);
            this.ledBalise1Assiette.Name = "ledBalise1Assiette";
            this.ledBalise1Assiette.Size = new System.Drawing.Size(16, 16);
            this.ledBalise1Assiette.TabIndex = 47;
            this.ledBalise1Assiette.TabStop = false;
            // 
            // ledBalise3Rotation
            // 
            this.ledBalise3Rotation.Etat = false;
            this.ledBalise3Rotation.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise3Rotation.Image")));
            this.ledBalise3Rotation.Location = new System.Drawing.Point(293, 275);
            this.ledBalise3Rotation.Name = "ledBalise3Rotation";
            this.ledBalise3Rotation.Size = new System.Drawing.Size(16, 16);
            this.ledBalise3Rotation.TabIndex = 46;
            this.ledBalise3Rotation.TabStop = false;
            // 
            // ledBalise2Rotation
            // 
            this.ledBalise2Rotation.Etat = false;
            this.ledBalise2Rotation.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise2Rotation.Image")));
            this.ledBalise2Rotation.Location = new System.Drawing.Point(271, 275);
            this.ledBalise2Rotation.Name = "ledBalise2Rotation";
            this.ledBalise2Rotation.Size = new System.Drawing.Size(16, 16);
            this.ledBalise2Rotation.TabIndex = 45;
            this.ledBalise2Rotation.TabStop = false;
            // 
            // ledJackArme
            // 
            this.ledJackArme.Etat = false;
            this.ledJackArme.Image = ((System.Drawing.Image)(resources.GetObject("ledJackArme.Image")));
            this.ledJackArme.Location = new System.Drawing.Point(248, 361);
            this.ledJackArme.Name = "ledJackArme";
            this.ledJackArme.Size = new System.Drawing.Size(16, 16);
            this.ledJackArme.TabIndex = 42;
            this.ledJackArme.TabStop = false;
            // 
            // ledJackBranche
            // 
            this.ledJackBranche.Etat = false;
            this.ledJackBranche.Image = ((System.Drawing.Image)(resources.GetObject("ledJackBranche.Image")));
            this.ledJackBranche.Location = new System.Drawing.Point(171, 146);
            this.ledJackBranche.Name = "ledJackBranche";
            this.ledJackBranche.Size = new System.Drawing.Size(16, 16);
            this.ledJackBranche.TabIndex = 38;
            this.ledJackBranche.TabStop = false;
            // 
            // ledBalise1Rotation
            // 
            this.ledBalise1Rotation.Etat = false;
            this.ledBalise1Rotation.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise1Rotation.Image")));
            this.ledBalise1Rotation.Location = new System.Drawing.Point(248, 275);
            this.ledBalise1Rotation.Name = "ledBalise1Rotation";
            this.ledBalise1Rotation.Size = new System.Drawing.Size(16, 16);
            this.ledBalise1Rotation.TabIndex = 36;
            this.ledBalise1Rotation.TabStop = false;
            // 
            // ledRecallageGros
            // 
            this.ledRecallageGros.Etat = false;
            this.ledRecallageGros.Image = ((System.Drawing.Image)(resources.GetObject("ledRecallageGros.Image")));
            this.ledRecallageGros.Location = new System.Drawing.Point(248, 245);
            this.ledRecallageGros.Name = "ledRecallageGros";
            this.ledRecallageGros.Size = new System.Drawing.Size(16, 16);
            this.ledRecallageGros.TabIndex = 35;
            this.ledRecallageGros.TabStop = false;
            // 
            // boxPetit
            // 
            this.boxPetit.AutoSize = true;
            this.boxPetit.Location = new System.Drawing.Point(309, 246);
            this.boxPetit.Name = "boxPetit";
            this.boxPetit.Size = new System.Drawing.Size(74, 17);
            this.boxPetit.TabIndex = 67;
            this.boxPetit.Text = "Petit robot";
            this.boxPetit.UseVisualStyleBackColor = true;
            // 
            // lblBunGauche
            // 
            this.lblBunGauche.AutoSize = true;
            this.lblBunGauche.Font = new System.Drawing.Font("Jokerman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBunGauche.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBunGauche.Location = new System.Drawing.Point(341, 37);
            this.lblBunGauche.Name = "lblBunGauche";
            this.lblBunGauche.Size = new System.Drawing.Size(107, 47);
            this.lblBunGauche.TabIndex = 68;
            this.lblBunGauche.Text = "Bun 1";
            // 
            // lblBeuGauche
            // 
            this.lblBeuGauche.AutoSize = true;
            this.lblBeuGauche.Font = new System.Drawing.Font("Jokerman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeuGauche.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBeuGauche.Location = new System.Drawing.Point(336, 572);
            this.lblBeuGauche.Name = "lblBeuGauche";
            this.lblBeuGauche.Size = new System.Drawing.Size(112, 47);
            this.lblBeuGauche.TabIndex = 69;
            this.lblBeuGauche.Text = "Beu 2";
            // 
            // lblBoiDroite
            // 
            this.lblBoiDroite.AutoSize = true;
            this.lblBoiDroite.Font = new System.Drawing.Font("Jokerman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoiDroite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBoiDroite.Location = new System.Drawing.Point(339, 303);
            this.lblBoiDroite.Name = "lblBoiDroite";
            this.lblBoiDroite.Size = new System.Drawing.Size(107, 47);
            this.lblBoiDroite.TabIndex = 70;
            this.lblBoiDroite.Text = "Boi 3";
            // 
            // lblBunDroite
            // 
            this.lblBunDroite.AutoSize = true;
            this.lblBunDroite.Font = new System.Drawing.Font("Jokerman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBunDroite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBunDroite.Location = new System.Drawing.Point(1176, 37);
            this.lblBunDroite.Name = "lblBunDroite";
            this.lblBunDroite.Size = new System.Drawing.Size(107, 47);
            this.lblBunDroite.TabIndex = 71;
            this.lblBunDroite.Text = "1 Bun";
            // 
            // lblBoiGauche
            // 
            this.lblBoiGauche.AutoSize = true;
            this.lblBoiGauche.Font = new System.Drawing.Font("Jokerman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoiGauche.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBoiGauche.Location = new System.Drawing.Point(1178, 305);
            this.lblBoiGauche.Name = "lblBoiGauche";
            this.lblBoiGauche.Size = new System.Drawing.Size(107, 47);
            this.lblBoiGauche.TabIndex = 72;
            this.lblBoiGauche.Text = "3 Boi";
            // 
            // lblBeuDroite
            // 
            this.lblBeuDroite.AutoSize = true;
            this.lblBeuDroite.Font = new System.Drawing.Font("Jokerman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeuDroite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBeuDroite.Location = new System.Drawing.Point(1176, 572);
            this.lblBeuDroite.Name = "lblBeuDroite";
            this.lblBeuDroite.Size = new System.Drawing.Size(112, 47);
            this.lblBeuDroite.TabIndex = 73;
            this.lblBeuDroite.Text = "2 Beu";
            // 
            // PanelMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblBeuDroite);
            this.Controls.Add(this.lblBoiGauche);
            this.Controls.Add(this.lblBunDroite);
            this.Controls.Add(this.lblBoiDroite);
            this.Controls.Add(this.lblBeuGauche);
            this.Controls.Add(this.lblBunGauche);
            this.Controls.Add(this.boxPetit);
            this.Controls.Add(this.btnBalise3);
            this.Controls.Add(this.btnBalise2);
            this.Controls.Add(this.btnBalise1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pictureBoxTable);
            this.Controls.Add(this.ledRecallagePetit);
            this.Controls.Add(this.boxCalibrationAngulaire);
            this.Controls.Add(this.boxCalibrationAssiette);
            this.Controls.Add(this.ledBalise3Angle);
            this.Controls.Add(this.ledBalise2Angle);
            this.Controls.Add(this.ledBalise1Angle);
            this.Controls.Add(this.ledBalise3Assiette);
            this.Controls.Add(this.ledBalise2Assiette);
            this.Controls.Add(this.ledBalise1Assiette);
            this.Controls.Add(this.ledBalise3Rotation);
            this.Controls.Add(this.ledBalise2Rotation);
            this.Controls.Add(this.btnCalibrationAngle);
            this.Controls.Add(this.btnCalibrationAssiette);
            this.Controls.Add(this.ledJackArme);
            this.Controls.Add(this.btnArmerJack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBalises);
            this.Controls.Add(this.btnRecallage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBoxCouleur);
            this.Controls.Add(this.btnJoueurGauche);
            this.Controls.Add(this.btnJoueurDroite);
            this.Controls.Add(this.ledJackBranche);
            this.Controls.Add(this.ledBalise1Rotation);
            this.Controls.Add(this.ledRecallageGros);
            this.Name = "PanelMatch";
            this.Size = new System.Drawing.Size(1273, 669);
            this.Load += new System.EventHandler(this.PanelMatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecallagePetit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise3Angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise2Angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise1Angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise3Assiette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise2Assiette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise1Assiette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise3Rotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise2Rotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackArme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledJackBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise1Rotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecallageGros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnArmerJack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBalises;
        private System.Windows.Forms.Button btnRecallage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBaliseNon;
        private System.Windows.Forms.RadioButton radioBaliseOui;
        private System.Windows.Forms.PictureBox pictureBoxCouleur;
        private System.Windows.Forms.Button btnJoueurGauche;
        private System.Windows.Forms.Button btnJoueurDroite;
        private Composants.Led ledJackBranche;
        private Composants.Led ledBalise1Rotation;
        private Composants.Led ledRecallageGros;
        private Composants.Led ledJackArme;
        private System.Windows.Forms.Button btnCalibrationAssiette;
        private System.Windows.Forms.Button btnCalibrationAngle;
        private Composants.Led ledBalise2Rotation;
        private Composants.Led ledBalise3Rotation;
        private Composants.Led ledBalise3Assiette;
        private Composants.Led ledBalise2Assiette;
        private Composants.Led ledBalise1Assiette;
        private Composants.Led ledBalise3Angle;
        private Composants.Led ledBalise2Angle;
        private Composants.Led ledBalise1Angle;
        private System.Windows.Forms.CheckBox boxCalibrationAssiette;
        private System.Windows.Forms.CheckBox boxCalibrationAngulaire;
        private Composants.Led ledRecallagePetit;
        private System.Windows.Forms.PictureBox pictureBoxTable;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnBalise1;
        private System.Windows.Forms.Button btnBalise2;
        private System.Windows.Forms.Button btnBalise3;
        private System.Windows.Forms.CheckBox boxPetit;
        private System.Windows.Forms.Label lblBunGauche;
        private System.Windows.Forms.Label lblBeuGauche;
        private System.Windows.Forms.Label lblBoiDroite;
        private System.Windows.Forms.Label lblBunDroite;
        private System.Windows.Forms.Label lblBoiGauche;
        private System.Windows.Forms.Label lblBeuDroite;

    }
}
