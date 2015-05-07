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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelGrosRobotUtilisation));
            this.groupBoxUtilisation = new Composants.GroupBoxRetractable();
            this.groupBoxAmpoule = new System.Windows.Forms.GroupBox();
            this.btnMonterPince = new System.Windows.Forms.Button();
            this.btnOuvrirPince = new System.Windows.Forms.Button();
            this.pictureBoxPinceBalle = new System.Windows.Forms.PictureBox();
            this.groupBoxPinces = new System.Windows.Forms.GroupBox();
            this.imgOrigineDroite = new System.Windows.Forms.PictureBox();
            this.imgOrigineGauche = new System.Windows.Forms.PictureBox();
            this.ledBarriereOptiqueGauche = new Composants.Led();
            this.ledBarriereOptiqueDroite = new Composants.Led();
            this.ledBrasGaucheSwitchBas = new Composants.Led();
            this.ledBrasGaucheSwitchHaut = new Composants.Led();
            this.ledBrasDroitSwitchBas = new Composants.Led();
            this.ledBrasDroitSwitchHaut = new Composants.Led();
            this.btnBrasGaucheOuverturePincesBas = new System.Windows.Forms.Button();
            this.btnBrasGaucheOuverturePincesHaut = new System.Windows.Forms.Button();
            this.btnBrasDroitOuverturePincesBas = new System.Windows.Forms.Button();
            this.btnBrasDroitOuverturePincesHaut = new System.Windows.Forms.Button();
            this.btnHauteurBrasDroit = new System.Windows.Forms.Button();
            this.btnHauteurBrasGauche = new System.Windows.Forms.Button();
            this.pictureBoxBrasGauche = new System.Windows.Forms.PictureBox();
            this.pictureBoxBrasDroit = new System.Windows.Forms.PictureBox();
            this.btnOuvertureBrasDroitPinceHautDroite = new System.Windows.Forms.Button();
            this.btnOuvertureBrasGauchePinceHautDroite = new System.Windows.Forms.Button();
            this.btnOuvertureBrasGauchePinceBasGauche = new System.Windows.Forms.Button();
            this.btnOuvertureBrasDroitPinceBasGauche = new System.Windows.Forms.Button();
            this.btnOuvertureBrasGauchePinceHautGauche = new System.Windows.Forms.Button();
            this.btnOuvertureBrasGauchePinceBasDroite = new System.Windows.Forms.Button();
            this.btnOuvertureBrasDroitPinceHautGauche = new System.Windows.Forms.Button();
            this.btnOuvertureBrasDroitPinceBasDroite = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDiagnostic = new System.Windows.Forms.Button();
            this.switchBoutonPuissance = new Composants.SwitchBouton();
            this.btnCalibrationAscenseurDroit = new System.Windows.Forms.Button();
            this.btnCalibrationAscenseurGauche = new System.Windows.Forms.Button();
            this.btnCalibrationAscenseurAmpoule = new System.Windows.Forms.Button();
            this.groupBoxUtilisation.SuspendLayout();
            this.groupBoxAmpoule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPinceBalle)).BeginInit();
            this.groupBoxPinces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrigineDroite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrigineGauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBarriereOptiqueGauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBarriereOptiqueDroite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBrasGaucheSwitchBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBrasGaucheSwitchHaut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBrasDroitSwitchBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBrasDroitSwitchHaut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBrasGauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBrasDroit)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxUtilisation
            // 
            this.groupBoxUtilisation.Controls.Add(this.groupBoxAmpoule);
            this.groupBoxUtilisation.Controls.Add(this.groupBoxPinces);
            this.groupBoxUtilisation.Controls.Add(this.label12);
            this.groupBoxUtilisation.Controls.Add(this.btnDiagnostic);
            this.groupBoxUtilisation.Controls.Add(this.switchBoutonPuissance);
            this.groupBoxUtilisation.Location = new System.Drawing.Point(3, 3);
            this.groupBoxUtilisation.Name = "groupBoxUtilisation";
            this.groupBoxUtilisation.Size = new System.Drawing.Size(332, 527);
            this.groupBoxUtilisation.TabIndex = 1;
            this.groupBoxUtilisation.TabStop = false;
            this.groupBoxUtilisation.Text = "Utilisation";
            // 
            // groupBoxAmpoule
            // 
            this.groupBoxAmpoule.Controls.Add(this.btnCalibrationAscenseurAmpoule);
            this.groupBoxAmpoule.Controls.Add(this.btnMonterPince);
            this.groupBoxAmpoule.Controls.Add(this.btnOuvrirPince);
            this.groupBoxAmpoule.Controls.Add(this.pictureBoxPinceBalle);
            this.groupBoxAmpoule.Location = new System.Drawing.Point(15, 307);
            this.groupBoxAmpoule.Name = "groupBoxAmpoule";
            this.groupBoxAmpoule.Size = new System.Drawing.Size(302, 214);
            this.groupBoxAmpoule.TabIndex = 222;
            this.groupBoxAmpoule.TabStop = false;
            this.groupBoxAmpoule.Text = "Pince ampoule";
            // 
            // btnMonterPince
            // 
            this.btnMonterPince.Image = global::GoBot.Properties.Resources.Avance;
            this.btnMonterPince.Location = new System.Drawing.Point(247, 99);
            this.btnMonterPince.Name = "btnMonterPince";
            this.btnMonterPince.Size = new System.Drawing.Size(23, 23);
            this.btnMonterPince.TabIndex = 220;
            this.btnMonterPince.UseVisualStyleBackColor = true;
            this.btnMonterPince.Click += new System.EventHandler(this.btnMonterPince_Click);
            // 
            // btnOuvrirPince
            // 
            this.btnOuvrirPince.Image = global::GoBot.Properties.Resources.FermerPince;
            this.btnOuvrirPince.Location = new System.Drawing.Point(113, 144);
            this.btnOuvrirPince.Name = "btnOuvrirPince";
            this.btnOuvrirPince.Size = new System.Drawing.Size(46, 23);
            this.btnOuvrirPince.TabIndex = 219;
            this.btnOuvrirPince.UseVisualStyleBackColor = true;
            this.btnOuvrirPince.Click += new System.EventHandler(this.btnOuvrirPince_Click);
            // 
            // pictureBoxPinceBalle
            // 
            this.pictureBoxPinceBalle.Image = global::GoBot.Properties.Resources.PinceOuverteBas;
            this.pictureBoxPinceBalle.Location = new System.Drawing.Point(153, 33);
            this.pictureBoxPinceBalle.Name = "pictureBoxPinceBalle";
            this.pictureBoxPinceBalle.Size = new System.Drawing.Size(101, 153);
            this.pictureBoxPinceBalle.TabIndex = 221;
            this.pictureBoxPinceBalle.TabStop = false;
            // 
            // groupBoxPinces
            // 
            this.groupBoxPinces.Controls.Add(this.btnCalibrationAscenseurGauche);
            this.groupBoxPinces.Controls.Add(this.btnCalibrationAscenseurDroit);
            this.groupBoxPinces.Controls.Add(this.imgOrigineDroite);
            this.groupBoxPinces.Controls.Add(this.imgOrigineGauche);
            this.groupBoxPinces.Controls.Add(this.ledBarriereOptiqueGauche);
            this.groupBoxPinces.Controls.Add(this.ledBarriereOptiqueDroite);
            this.groupBoxPinces.Controls.Add(this.ledBrasGaucheSwitchBas);
            this.groupBoxPinces.Controls.Add(this.ledBrasGaucheSwitchHaut);
            this.groupBoxPinces.Controls.Add(this.ledBrasDroitSwitchBas);
            this.groupBoxPinces.Controls.Add(this.ledBrasDroitSwitchHaut);
            this.groupBoxPinces.Controls.Add(this.btnBrasGaucheOuverturePincesBas);
            this.groupBoxPinces.Controls.Add(this.btnBrasGaucheOuverturePincesHaut);
            this.groupBoxPinces.Controls.Add(this.btnBrasDroitOuverturePincesBas);
            this.groupBoxPinces.Controls.Add(this.btnBrasDroitOuverturePincesHaut);
            this.groupBoxPinces.Controls.Add(this.btnHauteurBrasDroit);
            this.groupBoxPinces.Controls.Add(this.btnHauteurBrasGauche);
            this.groupBoxPinces.Controls.Add(this.pictureBoxBrasGauche);
            this.groupBoxPinces.Controls.Add(this.pictureBoxBrasDroit);
            this.groupBoxPinces.Controls.Add(this.btnOuvertureBrasDroitPinceHautDroite);
            this.groupBoxPinces.Controls.Add(this.btnOuvertureBrasGauchePinceHautDroite);
            this.groupBoxPinces.Controls.Add(this.btnOuvertureBrasGauchePinceBasGauche);
            this.groupBoxPinces.Controls.Add(this.btnOuvertureBrasDroitPinceBasGauche);
            this.groupBoxPinces.Controls.Add(this.btnOuvertureBrasGauchePinceHautGauche);
            this.groupBoxPinces.Controls.Add(this.btnOuvertureBrasGauchePinceBasDroite);
            this.groupBoxPinces.Controls.Add(this.btnOuvertureBrasDroitPinceHautGauche);
            this.groupBoxPinces.Controls.Add(this.btnOuvertureBrasDroitPinceBasDroite);
            this.groupBoxPinces.Location = new System.Drawing.Point(6, 59);
            this.groupBoxPinces.Name = "groupBoxPinces";
            this.groupBoxPinces.Size = new System.Drawing.Size(311, 233);
            this.groupBoxPinces.TabIndex = 218;
            this.groupBoxPinces.TabStop = false;
            this.groupBoxPinces.Text = "Pinces pieds";
            // 
            // imgOrigineDroite
            // 
            this.imgOrigineDroite.Image = global::GoBot.Properties.Resources.Recale;
            this.imgOrigineDroite.Location = new System.Drawing.Point(75, 178);
            this.imgOrigineDroite.Name = "imgOrigineDroite";
            this.imgOrigineDroite.Size = new System.Drawing.Size(16, 16);
            this.imgOrigineDroite.TabIndex = 236;
            this.imgOrigineDroite.TabStop = false;
            // 
            // imgOrigineGauche
            // 
            this.imgOrigineGauche.Image = global::GoBot.Properties.Resources.Recale;
            this.imgOrigineGauche.Location = new System.Drawing.Point(223, 178);
            this.imgOrigineGauche.Name = "imgOrigineGauche";
            this.imgOrigineGauche.Size = new System.Drawing.Size(16, 16);
            this.imgOrigineGauche.TabIndex = 219;
            this.imgOrigineGauche.TabStop = false;
            // 
            // ledBarriereOptiqueGauche
            // 
            this.ledBarriereOptiqueGauche.BackColor = System.Drawing.Color.Transparent;
            this.ledBarriereOptiqueGauche.Etat = false;
            this.ledBarriereOptiqueGauche.Image = ((System.Drawing.Image)(resources.GetObject("ledBarriereOptiqueGauche.Image")));
            this.ledBarriereOptiqueGauche.Location = new System.Drawing.Point(223, 160);
            this.ledBarriereOptiqueGauche.Name = "ledBarriereOptiqueGauche";
            this.ledBarriereOptiqueGauche.Size = new System.Drawing.Size(16, 16);
            this.ledBarriereOptiqueGauche.TabIndex = 235;
            this.ledBarriereOptiqueGauche.TabStop = false;
            // 
            // ledBarriereOptiqueDroite
            // 
            this.ledBarriereOptiqueDroite.BackColor = System.Drawing.Color.Transparent;
            this.ledBarriereOptiqueDroite.Etat = false;
            this.ledBarriereOptiqueDroite.Image = ((System.Drawing.Image)(resources.GetObject("ledBarriereOptiqueDroite.Image")));
            this.ledBarriereOptiqueDroite.Location = new System.Drawing.Point(75, 160);
            this.ledBarriereOptiqueDroite.Name = "ledBarriereOptiqueDroite";
            this.ledBarriereOptiqueDroite.Size = new System.Drawing.Size(16, 16);
            this.ledBarriereOptiqueDroite.TabIndex = 234;
            this.ledBarriereOptiqueDroite.TabStop = false;
            // 
            // ledBrasGaucheSwitchBas
            // 
            this.ledBrasGaucheSwitchBas.BackColor = System.Drawing.Color.Transparent;
            this.ledBrasGaucheSwitchBas.Etat = false;
            this.ledBrasGaucheSwitchBas.Image = ((System.Drawing.Image)(resources.GetObject("ledBrasGaucheSwitchBas.Image")));
            this.ledBrasGaucheSwitchBas.Location = new System.Drawing.Point(223, 145);
            this.ledBrasGaucheSwitchBas.Name = "ledBrasGaucheSwitchBas";
            this.ledBrasGaucheSwitchBas.Size = new System.Drawing.Size(16, 16);
            this.ledBrasGaucheSwitchBas.TabIndex = 231;
            this.ledBrasGaucheSwitchBas.TabStop = false;
            // 
            // ledBrasGaucheSwitchHaut
            // 
            this.ledBrasGaucheSwitchHaut.BackColor = System.Drawing.Color.Transparent;
            this.ledBrasGaucheSwitchHaut.Etat = false;
            this.ledBrasGaucheSwitchHaut.Image = ((System.Drawing.Image)(resources.GetObject("ledBrasGaucheSwitchHaut.Image")));
            this.ledBrasGaucheSwitchHaut.Location = new System.Drawing.Point(223, 80);
            this.ledBrasGaucheSwitchHaut.Name = "ledBrasGaucheSwitchHaut";
            this.ledBrasGaucheSwitchHaut.Size = new System.Drawing.Size(16, 16);
            this.ledBrasGaucheSwitchHaut.TabIndex = 230;
            this.ledBrasGaucheSwitchHaut.TabStop = false;
            // 
            // ledBrasDroitSwitchBas
            // 
            this.ledBrasDroitSwitchBas.BackColor = System.Drawing.Color.Transparent;
            this.ledBrasDroitSwitchBas.Etat = false;
            this.ledBrasDroitSwitchBas.Image = ((System.Drawing.Image)(resources.GetObject("ledBrasDroitSwitchBas.Image")));
            this.ledBrasDroitSwitchBas.Location = new System.Drawing.Point(75, 145);
            this.ledBrasDroitSwitchBas.Name = "ledBrasDroitSwitchBas";
            this.ledBrasDroitSwitchBas.Size = new System.Drawing.Size(16, 16);
            this.ledBrasDroitSwitchBas.TabIndex = 229;
            this.ledBrasDroitSwitchBas.TabStop = false;
            // 
            // ledBrasDroitSwitchHaut
            // 
            this.ledBrasDroitSwitchHaut.BackColor = System.Drawing.Color.Transparent;
            this.ledBrasDroitSwitchHaut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ledBrasDroitSwitchHaut.Etat = false;
            this.ledBrasDroitSwitchHaut.Image = ((System.Drawing.Image)(resources.GetObject("ledBrasDroitSwitchHaut.Image")));
            this.ledBrasDroitSwitchHaut.Location = new System.Drawing.Point(75, 80);
            this.ledBrasDroitSwitchHaut.Name = "ledBrasDroitSwitchHaut";
            this.ledBrasDroitSwitchHaut.Size = new System.Drawing.Size(16, 16);
            this.ledBrasDroitSwitchHaut.TabIndex = 228;
            this.ledBrasDroitSwitchHaut.TabStop = false;
            // 
            // btnBrasGaucheOuverturePincesBas
            // 
            this.btnBrasGaucheOuverturePincesBas.Image = global::GoBot.Properties.Resources.FermerPince;
            this.btnBrasGaucheOuverturePincesBas.Location = new System.Drawing.Point(207, 196);
            this.btnBrasGaucheOuverturePincesBas.Name = "btnBrasGaucheOuverturePincesBas";
            this.btnBrasGaucheOuverturePincesBas.Size = new System.Drawing.Size(46, 23);
            this.btnBrasGaucheOuverturePincesBas.TabIndex = 227;
            this.btnBrasGaucheOuverturePincesBas.UseVisualStyleBackColor = true;
            this.btnBrasGaucheOuverturePincesBas.Click += new System.EventHandler(this.btnBrasGaucheOuverturePincesBas_Click);
            // 
            // btnBrasGaucheOuverturePincesHaut
            // 
            this.btnBrasGaucheOuverturePincesHaut.Image = global::GoBot.Properties.Resources.FermerPince;
            this.btnBrasGaucheOuverturePincesHaut.Location = new System.Drawing.Point(207, 45);
            this.btnBrasGaucheOuverturePincesHaut.Name = "btnBrasGaucheOuverturePincesHaut";
            this.btnBrasGaucheOuverturePincesHaut.Size = new System.Drawing.Size(46, 23);
            this.btnBrasGaucheOuverturePincesHaut.TabIndex = 226;
            this.btnBrasGaucheOuverturePincesHaut.UseVisualStyleBackColor = true;
            this.btnBrasGaucheOuverturePincesHaut.Click += new System.EventHandler(this.btnBrasGaucheOuverturePincesHaut_Click);
            // 
            // btnBrasDroitOuverturePincesBas
            // 
            this.btnBrasDroitOuverturePincesBas.Image = global::GoBot.Properties.Resources.FermerPince;
            this.btnBrasDroitOuverturePincesBas.Location = new System.Drawing.Point(61, 196);
            this.btnBrasDroitOuverturePincesBas.Name = "btnBrasDroitOuverturePincesBas";
            this.btnBrasDroitOuverturePincesBas.Size = new System.Drawing.Size(46, 23);
            this.btnBrasDroitOuverturePincesBas.TabIndex = 225;
            this.btnBrasDroitOuverturePincesBas.UseVisualStyleBackColor = true;
            this.btnBrasDroitOuverturePincesBas.Click += new System.EventHandler(this.btnBrasDroitOuverturePincesBas_Click);
            // 
            // btnBrasDroitOuverturePincesHaut
            // 
            this.btnBrasDroitOuverturePincesHaut.Image = global::GoBot.Properties.Resources.FermerPince;
            this.btnBrasDroitOuverturePincesHaut.Location = new System.Drawing.Point(61, 45);
            this.btnBrasDroitOuverturePincesHaut.Name = "btnBrasDroitOuverturePincesHaut";
            this.btnBrasDroitOuverturePincesHaut.Size = new System.Drawing.Size(46, 23);
            this.btnBrasDroitOuverturePincesHaut.TabIndex = 224;
            this.btnBrasDroitOuverturePincesHaut.UseVisualStyleBackColor = true;
            this.btnBrasDroitOuverturePincesHaut.Click += new System.EventHandler(this.btnBrasDroitOuverturePincesHaut_Click);
            // 
            // btnHauteurBrasDroit
            // 
            this.btnHauteurBrasDroit.Image = global::GoBot.Properties.Resources.Avance;
            this.btnHauteurBrasDroit.Location = new System.Drawing.Point(15, 45);
            this.btnHauteurBrasDroit.Name = "btnHauteurBrasDroit";
            this.btnHauteurBrasDroit.Size = new System.Drawing.Size(23, 23);
            this.btnHauteurBrasDroit.TabIndex = 219;
            this.btnHauteurBrasDroit.UseVisualStyleBackColor = true;
            this.btnHauteurBrasDroit.Click += new System.EventHandler(this.btnHauteurBrasDroit_Click);
            // 
            // btnHauteurBrasGauche
            // 
            this.btnHauteurBrasGauche.Image = global::GoBot.Properties.Resources.Avance;
            this.btnHauteurBrasGauche.Location = new System.Drawing.Point(162, 45);
            this.btnHauteurBrasGauche.Name = "btnHauteurBrasGauche";
            this.btnHauteurBrasGauche.Size = new System.Drawing.Size(23, 23);
            this.btnHauteurBrasGauche.TabIndex = 212;
            this.btnHauteurBrasGauche.UseVisualStyleBackColor = true;
            this.btnHauteurBrasGauche.Click += new System.EventHandler(this.btnHauteurBrasGauche_Click);
            // 
            // pictureBoxBrasGauche
            // 
            this.pictureBoxBrasGauche.Image = global::GoBot.Properties.Resources.Rail;
            this.pictureBoxBrasGauche.Location = new System.Drawing.Point(191, 70);
            this.pictureBoxBrasGauche.Name = "pictureBoxBrasGauche";
            this.pictureBoxBrasGauche.Size = new System.Drawing.Size(80, 124);
            this.pictureBoxBrasGauche.TabIndex = 211;
            this.pictureBoxBrasGauche.TabStop = false;
            // 
            // pictureBoxBrasDroit
            // 
            this.pictureBoxBrasDroit.Image = global::GoBot.Properties.Resources.Rail;
            this.pictureBoxBrasDroit.Location = new System.Drawing.Point(44, 70);
            this.pictureBoxBrasDroit.Name = "pictureBoxBrasDroit";
            this.pictureBoxBrasDroit.Size = new System.Drawing.Size(80, 124);
            this.pictureBoxBrasDroit.TabIndex = 218;
            this.pictureBoxBrasDroit.TabStop = false;
            // 
            // btnOuvertureBrasDroitPinceHautDroite
            // 
            this.btnOuvertureBrasDroitPinceHautDroite.Image = global::GoBot.Properties.Resources.VirageArDr;
            this.btnOuvertureBrasDroitPinceHautDroite.Location = new System.Drawing.Point(15, 106);
            this.btnOuvertureBrasDroitPinceHautDroite.Name = "btnOuvertureBrasDroitPinceHautDroite";
            this.btnOuvertureBrasDroitPinceHautDroite.Size = new System.Drawing.Size(23, 23);
            this.btnOuvertureBrasDroitPinceHautDroite.TabIndex = 223;
            this.btnOuvertureBrasDroitPinceHautDroite.UseVisualStyleBackColor = true;
            this.btnOuvertureBrasDroitPinceHautDroite.Click += new System.EventHandler(this.btnOuvertureBrasDroitPinceHautDroite_Click);
            // 
            // btnOuvertureBrasGauchePinceHautDroite
            // 
            this.btnOuvertureBrasGauchePinceHautDroite.Image = global::GoBot.Properties.Resources.VirageArDr;
            this.btnOuvertureBrasGauchePinceHautDroite.Location = new System.Drawing.Point(162, 106);
            this.btnOuvertureBrasGauchePinceHautDroite.Name = "btnOuvertureBrasGauchePinceHautDroite";
            this.btnOuvertureBrasGauchePinceHautDroite.Size = new System.Drawing.Size(23, 23);
            this.btnOuvertureBrasGauchePinceHautDroite.TabIndex = 217;
            this.btnOuvertureBrasGauchePinceHautDroite.UseVisualStyleBackColor = true;
            this.btnOuvertureBrasGauchePinceHautDroite.Click += new System.EventHandler(this.btnOuvertureBrasGauchePinceHautDroite_Click);
            // 
            // btnOuvertureBrasGauchePinceBasGauche
            // 
            this.btnOuvertureBrasGauchePinceBasGauche.Image = global::GoBot.Properties.Resources.VirageArGa;
            this.btnOuvertureBrasGauchePinceBasGauche.Location = new System.Drawing.Point(277, 171);
            this.btnOuvertureBrasGauchePinceBasGauche.Name = "btnOuvertureBrasGauchePinceBasGauche";
            this.btnOuvertureBrasGauchePinceBasGauche.Size = new System.Drawing.Size(23, 23);
            this.btnOuvertureBrasGauchePinceBasGauche.TabIndex = 214;
            this.btnOuvertureBrasGauchePinceBasGauche.UseVisualStyleBackColor = true;
            this.btnOuvertureBrasGauchePinceBasGauche.Click += new System.EventHandler(this.btnOuvertureBrasGauchePinceBasGauche_Click);
            // 
            // btnOuvertureBrasDroitPinceBasGauche
            // 
            this.btnOuvertureBrasDroitPinceBasGauche.Image = global::GoBot.Properties.Resources.VirageArGa;
            this.btnOuvertureBrasDroitPinceBasGauche.Location = new System.Drawing.Point(130, 171);
            this.btnOuvertureBrasDroitPinceBasGauche.Name = "btnOuvertureBrasDroitPinceBasGauche";
            this.btnOuvertureBrasDroitPinceBasGauche.Size = new System.Drawing.Size(23, 23);
            this.btnOuvertureBrasDroitPinceBasGauche.TabIndex = 220;
            this.btnOuvertureBrasDroitPinceBasGauche.UseVisualStyleBackColor = true;
            this.btnOuvertureBrasDroitPinceBasGauche.Click += new System.EventHandler(this.btnOuvertureBrasDroitPinceBasGauche_Click);
            // 
            // btnOuvertureBrasGauchePinceHautGauche
            // 
            this.btnOuvertureBrasGauchePinceHautGauche.Image = global::GoBot.Properties.Resources.VirageArGa;
            this.btnOuvertureBrasGauchePinceHautGauche.Location = new System.Drawing.Point(277, 106);
            this.btnOuvertureBrasGauchePinceHautGauche.Name = "btnOuvertureBrasGauchePinceHautGauche";
            this.btnOuvertureBrasGauchePinceHautGauche.Size = new System.Drawing.Size(23, 23);
            this.btnOuvertureBrasGauchePinceHautGauche.TabIndex = 216;
            this.btnOuvertureBrasGauchePinceHautGauche.UseVisualStyleBackColor = true;
            this.btnOuvertureBrasGauchePinceHautGauche.Click += new System.EventHandler(this.btnOuvertureBrasGauchePinceHautGauche_Click);
            // 
            // btnOuvertureBrasGauchePinceBasDroite
            // 
            this.btnOuvertureBrasGauchePinceBasDroite.Image = global::GoBot.Properties.Resources.VirageArDr;
            this.btnOuvertureBrasGauchePinceBasDroite.Location = new System.Drawing.Point(162, 171);
            this.btnOuvertureBrasGauchePinceBasDroite.Name = "btnOuvertureBrasGauchePinceBasDroite";
            this.btnOuvertureBrasGauchePinceBasDroite.Size = new System.Drawing.Size(23, 23);
            this.btnOuvertureBrasGauchePinceBasDroite.TabIndex = 215;
            this.btnOuvertureBrasGauchePinceBasDroite.UseVisualStyleBackColor = true;
            this.btnOuvertureBrasGauchePinceBasDroite.Click += new System.EventHandler(this.btnOuvertureBrasGauchePinceBasDroite_Click);
            // 
            // btnOuvertureBrasDroitPinceHautGauche
            // 
            this.btnOuvertureBrasDroitPinceHautGauche.Image = global::GoBot.Properties.Resources.VirageArGa;
            this.btnOuvertureBrasDroitPinceHautGauche.Location = new System.Drawing.Point(130, 106);
            this.btnOuvertureBrasDroitPinceHautGauche.Name = "btnOuvertureBrasDroitPinceHautGauche";
            this.btnOuvertureBrasDroitPinceHautGauche.Size = new System.Drawing.Size(23, 23);
            this.btnOuvertureBrasDroitPinceHautGauche.TabIndex = 222;
            this.btnOuvertureBrasDroitPinceHautGauche.UseVisualStyleBackColor = true;
            this.btnOuvertureBrasDroitPinceHautGauche.Click += new System.EventHandler(this.btnOuvertureBrasDroitPinceHautGauche_Click);
            // 
            // btnOuvertureBrasDroitPinceBasDroite
            // 
            this.btnOuvertureBrasDroitPinceBasDroite.Image = global::GoBot.Properties.Resources.VirageArDr;
            this.btnOuvertureBrasDroitPinceBasDroite.Location = new System.Drawing.Point(15, 171);
            this.btnOuvertureBrasDroitPinceBasDroite.Name = "btnOuvertureBrasDroitPinceBasDroite";
            this.btnOuvertureBrasDroitPinceBasDroite.Size = new System.Drawing.Size(23, 23);
            this.btnOuvertureBrasDroitPinceBasDroite.TabIndex = 221;
            this.btnOuvertureBrasDroitPinceBasDroite.UseVisualStyleBackColor = true;
            this.btnOuvertureBrasDroitPinceBasDroite.Click += new System.EventHandler(this.btnOuvertureBrasDroitPinceBasDroite_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 13);
            this.label12.TabIndex = 199;
            this.label12.Text = "Alimentation puissance";
            // 
            // btnDiagnostic
            // 
            this.btnDiagnostic.Location = new System.Drawing.Point(211, 30);
            this.btnDiagnostic.Name = "btnDiagnostic";
            this.btnDiagnostic.Size = new System.Drawing.Size(75, 23);
            this.btnDiagnostic.TabIndex = 201;
            this.btnDiagnostic.Text = "Diagnostic";
            this.btnDiagnostic.UseVisualStyleBackColor = true;
            this.btnDiagnostic.Click += new System.EventHandler(this.btnDiagnostic_Click);
            // 
            // switchBoutonPuissance
            // 
            this.switchBoutonPuissance.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonPuissance.Location = new System.Drawing.Point(145, 36);
            this.switchBoutonPuissance.Name = "switchBoutonPuissance";
            this.switchBoutonPuissance.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonPuissance.Symetrique = false;
            this.switchBoutonPuissance.TabIndex = 200;
            this.switchBoutonPuissance.ChangementEtat += new System.EventHandler(this.switchBoutonPuissance_ChangementEtat);
            // 
            // btnCalibrationAscenseurDroit
            // 
            this.btnCalibrationAscenseurDroit.Image = global::GoBot.Properties.Resources.Recale;
            this.btnCalibrationAscenseurDroit.Location = new System.Drawing.Point(15, 196);
            this.btnCalibrationAscenseurDroit.Name = "btnCalibrationAscenseurDroit";
            this.btnCalibrationAscenseurDroit.Size = new System.Drawing.Size(23, 23);
            this.btnCalibrationAscenseurDroit.TabIndex = 237;
            this.btnCalibrationAscenseurDroit.UseVisualStyleBackColor = true;
            this.btnCalibrationAscenseurDroit.Click += new System.EventHandler(this.btnCalibrationAscenseurDroit_Click);
            // 
            // btnCalibrationAscenseurGauche
            // 
            this.btnCalibrationAscenseurGauche.Image = global::GoBot.Properties.Resources.Recale;
            this.btnCalibrationAscenseurGauche.Location = new System.Drawing.Point(162, 196);
            this.btnCalibrationAscenseurGauche.Name = "btnCalibrationAscenseurGauche";
            this.btnCalibrationAscenseurGauche.Size = new System.Drawing.Size(23, 23);
            this.btnCalibrationAscenseurGauche.TabIndex = 238;
            this.btnCalibrationAscenseurGauche.UseVisualStyleBackColor = true;
            this.btnCalibrationAscenseurGauche.Click += new System.EventHandler(this.btnCalibrationAscenseurGauche_Click);
            // 
            // btnCalibrationAscenseurAmpoule
            // 
            this.btnCalibrationAscenseurAmpoule.Image = global::GoBot.Properties.Resources.Recale;
            this.btnCalibrationAscenseurAmpoule.Location = new System.Drawing.Point(248, 144);
            this.btnCalibrationAscenseurAmpoule.Name = "btnCalibrationAscenseurAmpoule";
            this.btnCalibrationAscenseurAmpoule.Size = new System.Drawing.Size(23, 23);
            this.btnCalibrationAscenseurAmpoule.TabIndex = 239;
            this.btnCalibrationAscenseurAmpoule.UseVisualStyleBackColor = true;
            this.btnCalibrationAscenseurAmpoule.Click += new System.EventHandler(this.btnCalibrationAscenseurAmpoule_Click);
            // 
            // PanelGrosRobotUtilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxUtilisation);
            this.Name = "PanelGrosRobotUtilisation";
            this.Size = new System.Drawing.Size(341, 537);
            this.Load += new System.EventHandler(this.PanelUtilGros_Load);
            this.groupBoxUtilisation.ResumeLayout(false);
            this.groupBoxUtilisation.PerformLayout();
            this.groupBoxAmpoule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPinceBalle)).EndInit();
            this.groupBoxPinces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgOrigineDroite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOrigineGauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBarriereOptiqueGauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBarriereOptiqueDroite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBrasGaucheSwitchBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBrasGaucheSwitchHaut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBrasDroitSwitchBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBrasDroitSwitchHaut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBrasGauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBrasDroit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.SwitchBouton switchBoutonPuissance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnDiagnostic;
        private Composants.GroupBoxRetractable groupBoxUtilisation;
        private System.Windows.Forms.PictureBox pictureBoxBrasGauche;
        private System.Windows.Forms.Button btnHauteurBrasGauche;
        private System.Windows.Forms.Button btnOuvertureBrasGauchePinceBasGauche;
        private System.Windows.Forms.Button btnOuvertureBrasGauchePinceBasDroite;
        private System.Windows.Forms.Button btnOuvertureBrasGauchePinceHautDroite;
        private System.Windows.Forms.Button btnOuvertureBrasGauchePinceHautGauche;
        private System.Windows.Forms.GroupBox groupBoxPinces;
        private System.Windows.Forms.Button btnHauteurBrasDroit;
        private System.Windows.Forms.PictureBox pictureBoxBrasDroit;
        private System.Windows.Forms.Button btnOuvertureBrasDroitPinceHautDroite;
        private System.Windows.Forms.Button btnOuvertureBrasDroitPinceBasGauche;
        private System.Windows.Forms.Button btnOuvertureBrasDroitPinceHautGauche;
        private System.Windows.Forms.Button btnOuvertureBrasDroitPinceBasDroite;
        private System.Windows.Forms.Button btnBrasDroitOuverturePincesHaut;
        private System.Windows.Forms.Button btnBrasDroitOuverturePincesBas;
        private System.Windows.Forms.Button btnBrasGaucheOuverturePincesBas;
        private System.Windows.Forms.Button btnBrasGaucheOuverturePincesHaut;
        private Composants.Led ledBrasDroitSwitchBas;
        private Composants.Led ledBrasDroitSwitchHaut;
        private Composants.Led ledBrasGaucheSwitchHaut;
        private Composants.Led ledBrasGaucheSwitchBas;
        private Composants.Led ledBarriereOptiqueDroite;
        private Composants.Led ledBarriereOptiqueGauche;
        private System.Windows.Forms.PictureBox imgOrigineGauche;
        private System.Windows.Forms.PictureBox imgOrigineDroite;
        private System.Windows.Forms.Button btnMonterPince;
        private System.Windows.Forms.Button btnOuvrirPince;
        private System.Windows.Forms.PictureBox pictureBoxPinceBalle;
        private System.Windows.Forms.GroupBox groupBoxAmpoule;
        private System.Windows.Forms.Button btnCalibrationAscenseurDroit;
        private System.Windows.Forms.Button btnCalibrationAscenseurGauche;
        private System.Windows.Forms.Button btnCalibrationAscenseurAmpoule;
    }
}
