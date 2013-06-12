using GoBot.IHM;
namespace GoBot
{
    partial class FenGoBot
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FenGoBot));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGrosRobot = new System.Windows.Forms.TabPage();
            this.panelGrosRobot = new GoBot.IHM.PanelGrosRobot();
            this.tabPetitRobot = new System.Windows.Forms.TabPage();
            this.panelPetitRobot = new GoBot.IHM.PanelPetitRobot();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.btnRejouerReplay = new System.Windows.Forms.Button();
            this.btnChargerReplay = new System.Windows.Forms.Button();
            this.btnResetTrames = new System.Windows.Forms.Button();
            this.btnAfficherTrame = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTrames = new System.Windows.Forms.RichTextBox();
            this.btnSaveReplay = new System.Windows.Forms.Button();
            this.txtLogComplet = new System.Windows.Forms.RichTextBox();
            this.tabMatch = new System.Windows.Forms.TabPage();
            this.led2 = new GoBot.IHM.Composants.Led();
            this.btnDegommage = new System.Windows.Forms.Button();
            this.btnArmerJack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPwmBalise3 = new System.Windows.Forms.Label();
            this.lblPwmBalise2 = new System.Windows.Forms.Label();
            this.lblPwmBalise1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBalises = new System.Windows.Forms.Button();
            this.btnRecallage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBaliseNon = new System.Windows.Forms.RadioButton();
            this.radioBaliseOui = new System.Windows.Forms.RadioButton();
            this.pictureBoxBalises = new System.Windows.Forms.PictureBox();
            this.pictureBoxCouleur = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCouleurBleu = new System.Windows.Forms.Button();
            this.led1 = new GoBot.IHM.Composants.Led();
            this.ledBalises = new GoBot.IHM.Composants.Led();
            this.ledRecallage = new GoBot.IHM.Composants.Led();
            this.tabBalises = new System.Windows.Forms.TabPage();
            this.panelBalise3 = new GoBot.IHM.PanelBalise();
            this.panelBalise2 = new GoBot.IHM.PanelBalise();
            this.panelBalise1 = new GoBot.IHM.PanelBalise();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.btnPiloteGros = new System.Windows.Forms.Button();
            this.panelTable = new GoBot.IHM.PanelTable();
            this.tabBougies = new System.Windows.Forms.TabPage();
            this.panelBougies = new GoBot.IHM.PanelBougies();
            this.tabReglagePID = new System.Windows.Forms.TabPage();
            this.panelReglageAsserv = new GoBot.IHM.PanelReglageAsserv();
            this.lblRecMove = new System.Windows.Forms.Label();
            this.lblRecIo = new System.Windows.Forms.Label();
            this.lblRecPi = new System.Windows.Forms.Label();
            this.lblRecBeu = new System.Windows.Forms.Label();
            this.lblRecBun = new System.Windows.Forms.Label();
            this.lblRecBoi = new System.Windows.Forms.Label();
            this.lblSimulation = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.switchBoutonSimu = new GoBot.IHM.Composants.SwitchBouton();
            this.ledRecBoi = new GoBot.IHM.Composants.Led();
            this.ledRecBeu = new GoBot.IHM.Composants.Led();
            this.ledRecBun = new GoBot.IHM.Composants.Led();
            this.ledRecPi = new GoBot.IHM.Composants.Led();
            this.ledRecMiwi = new GoBot.IHM.Composants.Led();
            this.ledRecMove = new GoBot.IHM.Composants.Led();
            this.tabLedsBalises = new System.Windows.Forms.TabPage();
            this.panelImagesBalises = new GoBot.IHM.PanelImagesBalises();
            this.tabControl.SuspendLayout();
            this.tabGrosRobot.SuspendLayout();
            this.tabPetitRobot.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBalises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecallage)).BeginInit();
            this.tabBalises.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tabBougies.SuspendLayout();
            this.tabReglagePID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecPi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecMiwi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecMove)).BeginInit();
            this.tabLedsBalises.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabGrosRobot);
            this.tabControl.Controls.Add(this.tabPetitRobot);
            this.tabControl.Controls.Add(this.tabLog);
            this.tabControl.Controls.Add(this.tabMatch);
            this.tabControl.Controls.Add(this.tabBalises);
            this.tabControl.Controls.Add(this.tabLedsBalises);
            this.tabControl.Controls.Add(this.tabTable);
            this.tabControl.Controls.Add(this.tabBougies);
            this.tabControl.Controls.Add(this.tabReglagePID);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1024, 574);
            this.tabControl.TabIndex = 25;
            // 
            // tabGrosRobot
            // 
            this.tabGrosRobot.Controls.Add(this.panelGrosRobot);
            this.tabGrosRobot.Location = new System.Drawing.Point(4, 22);
            this.tabGrosRobot.Name = "tabGrosRobot";
            this.tabGrosRobot.Size = new System.Drawing.Size(1016, 548);
            this.tabGrosRobot.TabIndex = 0;
            this.tabGrosRobot.Text = "Gros Robot";
            this.tabGrosRobot.UseVisualStyleBackColor = true;
            // 
            // panelGrosRobot
            // 
            this.panelGrosRobot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrosRobot.BackColor = System.Drawing.Color.White;
            this.panelGrosRobot.Location = new System.Drawing.Point(0, 0);
            this.panelGrosRobot.Name = "panelGrosRobot";
            this.panelGrosRobot.Size = new System.Drawing.Size(1016, 548);
            this.panelGrosRobot.TabIndex = 0;
            // 
            // tabPetitRobot
            // 
            this.tabPetitRobot.Controls.Add(this.panelPetitRobot);
            this.tabPetitRobot.Location = new System.Drawing.Point(4, 22);
            this.tabPetitRobot.Name = "tabPetitRobot";
            this.tabPetitRobot.Size = new System.Drawing.Size(1016, 548);
            this.tabPetitRobot.TabIndex = 2;
            this.tabPetitRobot.Text = "Petit Robot";
            this.tabPetitRobot.UseVisualStyleBackColor = true;
            // 
            // panelPetitRobot
            // 
            this.panelPetitRobot.BackColor = System.Drawing.Color.Transparent;
            this.panelPetitRobot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPetitRobot.Location = new System.Drawing.Point(0, 0);
            this.panelPetitRobot.Name = "panelPetitRobot";
            this.panelPetitRobot.Size = new System.Drawing.Size(192, 74);
            this.panelPetitRobot.TabIndex = 0;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.btnRejouerReplay);
            this.tabLog.Controls.Add(this.btnChargerReplay);
            this.tabLog.Controls.Add(this.btnResetTrames);
            this.tabLog.Controls.Add(this.btnAfficherTrame);
            this.tabLog.Controls.Add(this.label7);
            this.tabLog.Controls.Add(this.label6);
            this.tabLog.Controls.Add(this.txtTrames);
            this.tabLog.Controls.Add(this.btnSaveReplay);
            this.tabLog.Controls.Add(this.txtLogComplet);
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(1016, 548);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Logs";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // btnRejouerReplay
            // 
            this.btnRejouerReplay.Location = new System.Drawing.Point(111, 151);
            this.btnRejouerReplay.Name = "btnRejouerReplay";
            this.btnRejouerReplay.Size = new System.Drawing.Size(75, 23);
            this.btnRejouerReplay.TabIndex = 8;
            this.btnRejouerReplay.Text = "Rejouer";
            this.btnRejouerReplay.UseVisualStyleBackColor = true;
            this.btnRejouerReplay.Click += new System.EventHandler(this.btnRejouerReplay_Click);
            // 
            // btnChargerReplay
            // 
            this.btnChargerReplay.Location = new System.Drawing.Point(6, 151);
            this.btnChargerReplay.Name = "btnChargerReplay";
            this.btnChargerReplay.Size = new System.Drawing.Size(99, 23);
            this.btnChargerReplay.TabIndex = 7;
            this.btnChargerReplay.Text = "Charger un replay";
            this.btnChargerReplay.UseVisualStyleBackColor = true;
            this.btnChargerReplay.Click += new System.EventHandler(this.btnChargerReplay_Click);
            // 
            // btnResetTrames
            // 
            this.btnResetTrames.Location = new System.Drawing.Point(124, 32);
            this.btnResetTrames.Name = "btnResetTrames";
            this.btnResetTrames.Size = new System.Drawing.Size(52, 23);
            this.btnResetTrames.TabIndex = 6;
            this.btnResetTrames.Text = "Reset";
            this.btnResetTrames.UseVisualStyleBackColor = true;
            // 
            // btnAfficherTrame
            // 
            this.btnAfficherTrame.Location = new System.Drawing.Point(6, 32);
            this.btnAfficherTrame.Name = "btnAfficherTrame";
            this.btnAfficherTrame.Size = new System.Drawing.Size(112, 23);
            this.btnAfficherTrame.TabIndex = 5;
            this.btnAfficherTrame.Text = "Afficher les trames";
            this.btnAfficherTrame.UseVisualStyleBackColor = true;
            this.btnAfficherTrame.Click += new System.EventHandler(this.btnAfficherTrame_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Trames :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Actions :";
            // 
            // txtTrames
            // 
            this.txtTrames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTrames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrames.Location = new System.Drawing.Point(198, 6);
            this.txtTrames.Name = "txtTrames";
            this.txtTrames.Size = new System.Drawing.Size(380, 0);
            this.txtTrames.TabIndex = 2;
            this.txtTrames.Text = "";
            // 
            // btnSaveReplay
            // 
            this.btnSaveReplay.Location = new System.Drawing.Point(6, 95);
            this.btnSaveReplay.Name = "btnSaveReplay";
            this.btnSaveReplay.Size = new System.Drawing.Size(113, 23);
            this.btnSaveReplay.TabIndex = 1;
            this.btnSaveReplay.Text = "Enregistrer le replay";
            this.btnSaveReplay.UseVisualStyleBackColor = true;
            this.btnSaveReplay.Click += new System.EventHandler(this.btnSaveReplay_Click);
            // 
            // txtLogComplet
            // 
            this.txtLogComplet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLogComplet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogComplet.Location = new System.Drawing.Point(638, 6);
            this.txtLogComplet.Name = "txtLogComplet";
            this.txtLogComplet.Size = new System.Drawing.Size(352, 0);
            this.txtLogComplet.TabIndex = 0;
            this.txtLogComplet.Text = "";
            // 
            // tabMatch
            // 
            this.tabMatch.Controls.Add(this.led2);
            this.tabMatch.Controls.Add(this.btnDegommage);
            this.tabMatch.Controls.Add(this.btnArmerJack);
            this.tabMatch.Controls.Add(this.label5);
            this.tabMatch.Controls.Add(this.lblPwmBalise3);
            this.tabMatch.Controls.Add(this.lblPwmBalise2);
            this.tabMatch.Controls.Add(this.lblPwmBalise1);
            this.tabMatch.Controls.Add(this.label4);
            this.tabMatch.Controls.Add(this.label3);
            this.tabMatch.Controls.Add(this.label2);
            this.tabMatch.Controls.Add(this.label1);
            this.tabMatch.Controls.Add(this.btnBalises);
            this.tabMatch.Controls.Add(this.btnRecallage);
            this.tabMatch.Controls.Add(this.groupBox1);
            this.tabMatch.Controls.Add(this.pictureBoxBalises);
            this.tabMatch.Controls.Add(this.pictureBoxCouleur);
            this.tabMatch.Controls.Add(this.button2);
            this.tabMatch.Controls.Add(this.btnCouleurBleu);
            this.tabMatch.Controls.Add(this.led1);
            this.tabMatch.Controls.Add(this.ledBalises);
            this.tabMatch.Controls.Add(this.ledRecallage);
            this.tabMatch.Location = new System.Drawing.Point(4, 22);
            this.tabMatch.Name = "tabMatch";
            this.tabMatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatch.Size = new System.Drawing.Size(1016, 548);
            this.tabMatch.TabIndex = 3;
            this.tabMatch.Text = "Match";
            this.tabMatch.UseVisualStyleBackColor = true;
            // 
            // led2
            // 
            this.led2.Etat = false;
            this.led2.Image = global::GoBot.Properties.Resources.LedVert;
            this.led2.Location = new System.Drawing.Point(828, 343);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(16, 16);
            this.led2.TabIndex = 20;
            this.led2.TabStop = false;
            // 
            // btnDegommage
            // 
            this.btnDegommage.Location = new System.Drawing.Point(731, 339);
            this.btnDegommage.Name = "btnDegommage";
            this.btnDegommage.Size = new System.Drawing.Size(91, 23);
            this.btnDegommage.TabIndex = 19;
            this.btnDegommage.Text = "Dégommage";
            this.btnDegommage.UseVisualStyleBackColor = true;
            this.btnDegommage.Click += new System.EventHandler(this.btnDegommage_Click);
            // 
            // btnArmerJack
            // 
            this.btnArmerJack.Location = new System.Drawing.Point(731, 368);
            this.btnArmerJack.Name = "btnArmerJack";
            this.btnArmerJack.Size = new System.Drawing.Size(91, 23);
            this.btnArmerJack.TabIndex = 18;
            this.btnArmerJack.Text = "Armer le jack";
            this.btnArmerJack.UseVisualStyleBackColor = true;
            this.btnArmerJack.Click += new System.EventHandler(this.btnRecallageGR_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Jack branché";
            // 
            // lblPwmBalise3
            // 
            this.lblPwmBalise3.AutoSize = true;
            this.lblPwmBalise3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwmBalise3.ForeColor = System.Drawing.Color.Red;
            this.lblPwmBalise3.Location = new System.Drawing.Point(594, 482);
            this.lblPwmBalise3.Name = "lblPwmBalise3";
            this.lblPwmBalise3.Size = new System.Drawing.Size(35, 13);
            this.lblPwmBalise3.TabIndex = 13;
            this.lblPwmBalise3.Text = "2354";
            this.lblPwmBalise3.Visible = false;
            // 
            // lblPwmBalise2
            // 
            this.lblPwmBalise2.AutoSize = true;
            this.lblPwmBalise2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPwmBalise2.Location = new System.Drawing.Point(594, 458);
            this.lblPwmBalise2.Name = "lblPwmBalise2";
            this.lblPwmBalise2.Size = new System.Drawing.Size(31, 13);
            this.lblPwmBalise2.TabIndex = 12;
            this.lblPwmBalise2.Text = "1654";
            this.lblPwmBalise2.Visible = false;
            // 
            // lblPwmBalise1
            // 
            this.lblPwmBalise1.AutoSize = true;
            this.lblPwmBalise1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPwmBalise1.Location = new System.Drawing.Point(594, 434);
            this.lblPwmBalise1.Name = "lblPwmBalise1";
            this.lblPwmBalise1.Size = new System.Drawing.Size(31, 13);
            this.lblPwmBalise1.TabIndex = 11;
            this.lblPwmBalise1.Text = "1500";
            this.lblPwmBalise1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 482);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "RecBoi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "RecBeu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "RecBun";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pwm à 4 tours / seconde :";
            // 
            // btnBalises
            // 
            this.btnBalises.Location = new System.Drawing.Point(391, 397);
            this.btnBalises.Name = "btnBalises";
            this.btnBalises.Size = new System.Drawing.Size(227, 23);
            this.btnBalises.TabIndex = 6;
            this.btnBalises.Text = "Lancement des balises";
            this.btnBalises.UseVisualStyleBackColor = true;
            this.btnBalises.Click += new System.EventHandler(this.btnBalises_Click);
            // 
            // btnRecallage
            // 
            this.btnRecallage.Location = new System.Drawing.Point(391, 368);
            this.btnRecallage.Name = "btnRecallage";
            this.btnRecallage.Size = new System.Drawing.Size(227, 23);
            this.btnRecallage.TabIndex = 5;
            this.btnRecallage.Text = "Recallage des robots";
            this.btnRecallage.UseVisualStyleBackColor = true;
            this.btnRecallage.Click += new System.EventHandler(this.btnRecallage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBaliseNon);
            this.groupBox1.Controls.Add(this.radioBaliseOui);
            this.groupBox1.Location = new System.Drawing.Point(391, 299);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balise réfléchissante sur nos robots ?";
            // 
            // radioBaliseNon
            // 
            this.radioBaliseNon.AutoSize = true;
            this.radioBaliseNon.Location = new System.Drawing.Point(116, 23);
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
            this.radioBaliseOui.Location = new System.Drawing.Point(47, 23);
            this.radioBaliseOui.Name = "radioBaliseOui";
            this.radioBaliseOui.Size = new System.Drawing.Size(41, 17);
            this.radioBaliseOui.TabIndex = 0;
            this.radioBaliseOui.TabStop = true;
            this.radioBaliseOui.Text = "Oui";
            this.radioBaliseOui.UseVisualStyleBackColor = true;
            this.radioBaliseOui.CheckedChanged += new System.EventHandler(this.radioBaliseOui_CheckedChanged);
            // 
            // pictureBoxBalises
            // 
            this.pictureBoxBalises.Image = global::GoBot.Properties.Resources.TableRouge;
            this.pictureBoxBalises.Location = new System.Drawing.Point(391, 91);
            this.pictureBoxBalises.Name = "pictureBoxBalises";
            this.pictureBoxBalises.Size = new System.Drawing.Size(250, 167);
            this.pictureBoxBalises.TabIndex = 3;
            this.pictureBoxBalises.TabStop = false;
            // 
            // pictureBoxCouleur
            // 
            this.pictureBoxCouleur.Location = new System.Drawing.Point(485, 18);
            this.pictureBoxCouleur.Name = "pictureBoxCouleur";
            this.pictureBoxCouleur.Size = new System.Drawing.Size(156, 50);
            this.pictureBoxCouleur.TabIndex = 2;
            this.pictureBoxCouleur.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(32)))), ((int)(((byte)(25)))));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(391, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Rouge";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnCouleurRouge_Click);
            // 
            // btnCouleurBleu
            // 
            this.btnCouleurBleu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(113)))));
            this.btnCouleurBleu.ForeColor = System.Drawing.Color.White;
            this.btnCouleurBleu.Location = new System.Drawing.Point(391, 18);
            this.btnCouleurBleu.Name = "btnCouleurBleu";
            this.btnCouleurBleu.Size = new System.Drawing.Size(75, 23);
            this.btnCouleurBleu.TabIndex = 0;
            this.btnCouleurBleu.Text = "Bleu";
            this.btnCouleurBleu.UseVisualStyleBackColor = false;
            this.btnCouleurBleu.Click += new System.EventHandler(this.btnCouleurBleu_Click);
            // 
            // led1
            // 
            this.led1.Etat = false;
            this.led1.Image = global::GoBot.Properties.Resources.LedRouge;
            this.led1.Location = new System.Drawing.Point(547, 272);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(16, 16);
            this.led1.TabIndex = 17;
            this.led1.TabStop = false;
            // 
            // ledBalises
            // 
            this.ledBalises.Etat = false;
            this.ledBalises.Image = global::GoBot.Properties.Resources.LedRouge;
            this.ledBalises.Location = new System.Drawing.Point(624, 404);
            this.ledBalises.Name = "ledBalises";
            this.ledBalises.Size = new System.Drawing.Size(16, 16);
            this.ledBalises.TabIndex = 15;
            this.ledBalises.TabStop = false;
            // 
            // ledRecallage
            // 
            this.ledRecallage.Etat = false;
            this.ledRecallage.Image = global::GoBot.Properties.Resources.LedRouge;
            this.ledRecallage.Location = new System.Drawing.Point(624, 371);
            this.ledRecallage.Name = "ledRecallage";
            this.ledRecallage.Size = new System.Drawing.Size(16, 16);
            this.ledRecallage.TabIndex = 14;
            this.ledRecallage.TabStop = false;
            // 
            // tabBalises
            // 
            this.tabBalises.Controls.Add(this.panelBalise3);
            this.tabBalises.Controls.Add(this.panelBalise2);
            this.tabBalises.Controls.Add(this.panelBalise1);
            this.tabBalises.Location = new System.Drawing.Point(4, 22);
            this.tabBalises.Name = "tabBalises";
            this.tabBalises.Padding = new System.Windows.Forms.Padding(3);
            this.tabBalises.Size = new System.Drawing.Size(1016, 548);
            this.tabBalises.TabIndex = 6;
            this.tabBalises.Text = "Balises";
            this.tabBalises.UseVisualStyleBackColor = true;
            // 
            // panelBalise3
            // 
            this.panelBalise3.BackColor = System.Drawing.Color.Transparent;
            this.panelBalise3.Balise = null;
            this.panelBalise3.Location = new System.Drawing.Point(675, 6);
            this.panelBalise3.Name = "panelBalise3";
            this.panelBalise3.Size = new System.Drawing.Size(333, 496);
            this.panelBalise3.TabIndex = 2;
            // 
            // panelBalise2
            // 
            this.panelBalise2.BackColor = System.Drawing.Color.Transparent;
            this.panelBalise2.Balise = null;
            this.panelBalise2.Location = new System.Drawing.Point(339, 6);
            this.panelBalise2.Name = "panelBalise2";
            this.panelBalise2.Size = new System.Drawing.Size(333, 496);
            this.panelBalise2.TabIndex = 1;
            // 
            // panelBalise1
            // 
            this.panelBalise1.BackColor = System.Drawing.Color.Transparent;
            this.panelBalise1.Balise = null;
            this.panelBalise1.Location = new System.Drawing.Point(3, 6);
            this.panelBalise1.Name = "panelBalise1";
            this.panelBalise1.Size = new System.Drawing.Size(333, 496);
            this.panelBalise1.TabIndex = 0;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.btnPiloteGros);
            this.tabTable.Controls.Add(this.panelTable);
            this.tabTable.Location = new System.Drawing.Point(4, 22);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTable.Size = new System.Drawing.Size(1016, 548);
            this.tabTable.TabIndex = 7;
            this.tabTable.Text = "Table";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // btnPiloteGros
            // 
            this.btnPiloteGros.Location = new System.Drawing.Point(30, 509);
            this.btnPiloteGros.Name = "btnPiloteGros";
            this.btnPiloteGros.Size = new System.Drawing.Size(75, 23);
            this.btnPiloteGros.TabIndex = 1;
            this.btnPiloteGros.Text = "Pilote gros";
            this.btnPiloteGros.UseVisualStyleBackColor = true;
            this.btnPiloteGros.Click += new System.EventHandler(this.btnPiloteGros_Click);
            // 
            // panelTable
            // 
            this.panelTable.BackColor = System.Drawing.Color.Transparent;
            this.panelTable.Location = new System.Drawing.Point(12, 6);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(983, 526);
            this.panelTable.TabIndex = 0;
            // 
            // tabBougies
            // 
            this.tabBougies.Controls.Add(this.panelBougies);
            this.tabBougies.Location = new System.Drawing.Point(4, 22);
            this.tabBougies.Name = "tabBougies";
            this.tabBougies.Size = new System.Drawing.Size(1016, 548);
            this.tabBougies.TabIndex = 10;
            this.tabBougies.Text = "Bougies";
            this.tabBougies.UseVisualStyleBackColor = true;
            // 
            // panelBougies
            // 
            this.panelBougies.Location = new System.Drawing.Point(3, 3);
            this.panelBougies.Name = "panelBougies";
            this.panelBougies.Size = new System.Drawing.Size(1005, 501);
            this.panelBougies.TabIndex = 0;
            // 
            // tabReglagePID
            // 
            this.tabReglagePID.Controls.Add(this.panelReglageAsserv);
            this.tabReglagePID.Location = new System.Drawing.Point(4, 22);
            this.tabReglagePID.Name = "tabReglagePID";
            this.tabReglagePID.Padding = new System.Windows.Forms.Padding(3);
            this.tabReglagePID.Size = new System.Drawing.Size(1016, 548);
            this.tabReglagePID.TabIndex = 11;
            this.tabReglagePID.Text = "Réglage PID";
            this.tabReglagePID.UseVisualStyleBackColor = true;
            // 
            // panelReglageAsserv
            // 
            this.panelReglageAsserv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReglageAsserv.Location = new System.Drawing.Point(3, 3);
            this.panelReglageAsserv.Name = "panelReglageAsserv";
            this.panelReglageAsserv.Size = new System.Drawing.Size(1010, 542);
            this.panelReglageAsserv.TabIndex = 0;
            // 
            // lblRecMove
            // 
            this.lblRecMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecMove.AutoSize = true;
            this.lblRecMove.Location = new System.Drawing.Point(38, 578);
            this.lblRecMove.Name = "lblRecMove";
            this.lblRecMove.Size = new System.Drawing.Size(54, 13);
            this.lblRecMove.TabIndex = 27;
            this.lblRecMove.Text = "RecMove";
            // 
            // lblRecIo
            // 
            this.lblRecIo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecIo.AutoSize = true;
            this.lblRecIo.Location = new System.Drawing.Point(204, 578);
            this.lblRecIo.Name = "lblRecIo";
            this.lblRecIo.Size = new System.Drawing.Size(48, 13);
            this.lblRecIo.TabIndex = 29;
            this.lblRecIo.Text = "RecMiwi";
            // 
            // lblRecPi
            // 
            this.lblRecPi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecPi.AutoSize = true;
            this.lblRecPi.Location = new System.Drawing.Point(352, 578);
            this.lblRecPi.Name = "lblRecPi";
            this.lblRecPi.Size = new System.Drawing.Size(36, 13);
            this.lblRecPi.TabIndex = 33;
            this.lblRecPi.Text = "RecPi";
            // 
            // lblRecBeu
            // 
            this.lblRecBeu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecBeu.AutoSize = true;
            this.lblRecBeu.Location = new System.Drawing.Point(658, 578);
            this.lblRecBeu.Name = "lblRecBeu";
            this.lblRecBeu.Size = new System.Drawing.Size(46, 13);
            this.lblRecBeu.TabIndex = 39;
            this.lblRecBeu.Text = "RecBeu";
            // 
            // lblRecBun
            // 
            this.lblRecBun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecBun.AutoSize = true;
            this.lblRecBun.Location = new System.Drawing.Point(500, 578);
            this.lblRecBun.Name = "lblRecBun";
            this.lblRecBun.Size = new System.Drawing.Size(46, 13);
            this.lblRecBun.TabIndex = 37;
            this.lblRecBun.Text = "RecBun";
            // 
            // lblRecBoi
            // 
            this.lblRecBoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecBoi.AutoSize = true;
            this.lblRecBoi.Location = new System.Drawing.Point(816, 578);
            this.lblRecBoi.Name = "lblRecBoi";
            this.lblRecBoi.Size = new System.Drawing.Size(42, 13);
            this.lblRecBoi.TabIndex = 43;
            this.lblRecBoi.Text = "RecBoi";
            // 
            // lblSimulation
            // 
            this.lblSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSimulation.AutoSize = true;
            this.lblSimulation.Location = new System.Drawing.Point(965, 578);
            this.lblSimulation.Name = "lblSimulation";
            this.lblSimulation.Size = new System.Drawing.Size(55, 13);
            this.lblSimulation.TabIndex = 72;
            this.lblSimulation.Text = "Simulation";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::GoBot.Properties.Resources.Close;
            this.btnClose.Location = new System.Drawing.Point(1002, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 71;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // switchBoutonSimu
            // 
            this.switchBoutonSimu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.switchBoutonSimu.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonSimu.Location = new System.Drawing.Point(924, 578);
            this.switchBoutonSimu.Name = "switchBoutonSimu";
            this.switchBoutonSimu.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonSimu.Symetrique = true;
            this.switchBoutonSimu.TabIndex = 73;
            this.switchBoutonSimu.ChangementEtat += new System.EventHandler(this.switchBoutonSimu_ChangementEtat);
            // 
            // ledRecBoi
            // 
            this.ledRecBoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecBoi.Etat = false;
            this.ledRecBoi.Image = ((System.Drawing.Image)(resources.GetObject("ledRecBoi.Image")));
            this.ledRecBoi.Location = new System.Drawing.Point(794, 577);
            this.ledRecBoi.Name = "ledRecBoi";
            this.ledRecBoi.Size = new System.Drawing.Size(16, 16);
            this.ledRecBoi.TabIndex = 42;
            this.ledRecBoi.TabStop = false;
            // 
            // ledRecBeu
            // 
            this.ledRecBeu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecBeu.Etat = false;
            this.ledRecBeu.Image = ((System.Drawing.Image)(resources.GetObject("ledRecBeu.Image")));
            this.ledRecBeu.Location = new System.Drawing.Point(636, 577);
            this.ledRecBeu.Name = "ledRecBeu";
            this.ledRecBeu.Size = new System.Drawing.Size(16, 16);
            this.ledRecBeu.TabIndex = 38;
            this.ledRecBeu.TabStop = false;
            // 
            // ledRecBun
            // 
            this.ledRecBun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecBun.Etat = false;
            this.ledRecBun.Image = ((System.Drawing.Image)(resources.GetObject("ledRecBun.Image")));
            this.ledRecBun.Location = new System.Drawing.Point(478, 577);
            this.ledRecBun.Name = "ledRecBun";
            this.ledRecBun.Size = new System.Drawing.Size(16, 16);
            this.ledRecBun.TabIndex = 36;
            this.ledRecBun.TabStop = false;
            // 
            // ledRecPi
            // 
            this.ledRecPi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecPi.Etat = false;
            this.ledRecPi.Image = ((System.Drawing.Image)(resources.GetObject("ledRecPi.Image")));
            this.ledRecPi.Location = new System.Drawing.Point(330, 577);
            this.ledRecPi.Name = "ledRecPi";
            this.ledRecPi.Size = new System.Drawing.Size(16, 16);
            this.ledRecPi.TabIndex = 32;
            this.ledRecPi.TabStop = false;
            // 
            // ledRecMiwi
            // 
            this.ledRecMiwi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecMiwi.Etat = false;
            this.ledRecMiwi.Image = ((System.Drawing.Image)(resources.GetObject("ledRecMiwi.Image")));
            this.ledRecMiwi.Location = new System.Drawing.Point(182, 577);
            this.ledRecMiwi.Name = "ledRecMiwi";
            this.ledRecMiwi.Size = new System.Drawing.Size(16, 16);
            this.ledRecMiwi.TabIndex = 28;
            this.ledRecMiwi.TabStop = false;
            // 
            // ledRecMove
            // 
            this.ledRecMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ledRecMove.Etat = false;
            this.ledRecMove.Image = global::GoBot.Properties.Resources.LedRouge;
            this.ledRecMove.Location = new System.Drawing.Point(16, 577);
            this.ledRecMove.Name = "ledRecMove";
            this.ledRecMove.Size = new System.Drawing.Size(16, 16);
            this.ledRecMove.TabIndex = 26;
            this.ledRecMove.TabStop = false;
            // 
            // tabLedsBalises
            // 
            this.tabLedsBalises.Controls.Add(this.panelImagesBalises);
            this.tabLedsBalises.Location = new System.Drawing.Point(4, 22);
            this.tabLedsBalises.Name = "tabLedsBalises";
            this.tabLedsBalises.Size = new System.Drawing.Size(1016, 548);
            this.tabLedsBalises.TabIndex = 12;
            this.tabLedsBalises.Text = "Leds Balises";
            this.tabLedsBalises.UseVisualStyleBackColor = true;
            // 
            // panelImagesBalises
            // 
            this.panelImagesBalises.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImagesBalises.Location = new System.Drawing.Point(0, 0);
            this.panelImagesBalises.Name = "panelImagesBalises";
            this.panelImagesBalises.Size = new System.Drawing.Size(1016, 548);
            this.panelImagesBalises.TabIndex = 0;
            // 
            // FenGoBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.switchBoutonSimu);
            this.Controls.Add(this.lblSimulation);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecBoi);
            this.Controls.Add(this.ledRecBoi);
            this.Controls.Add(this.lblRecBeu);
            this.Controls.Add(this.ledRecBeu);
            this.Controls.Add(this.lblRecBun);
            this.Controls.Add(this.ledRecBun);
            this.Controls.Add(this.lblRecPi);
            this.Controls.Add(this.ledRecPi);
            this.Controls.Add(this.lblRecIo);
            this.Controls.Add(this.ledRecMiwi);
            this.Controls.Add(this.lblRecMove);
            this.Controls.Add(this.ledRecMove);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "FenGoBot";
            this.Text = "GoBot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FenGoBot_FormClosing);
            this.Load += new System.EventHandler(this.FenGoBot_Load);
            this.tabControl.ResumeLayout(false);
            this.tabGrosRobot.ResumeLayout(false);
            this.tabPetitRobot.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.tabMatch.ResumeLayout(false);
            this.tabMatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBalises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecallage)).EndInit();
            this.tabBalises.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabBougies.ResumeLayout(false);
            this.tabReglagePID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecBun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecPi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecMiwi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRecMove)).EndInit();
            this.tabLedsBalises.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPetitRobot;
        private System.Windows.Forms.TabPage tabLog;
        private IHM.Composants.Led ledRecMove;
        private System.Windows.Forms.Label lblRecMove;
        private System.Windows.Forms.Label lblRecIo;
        private IHM.Composants.Led ledRecMiwi;
        private System.Windows.Forms.Label lblRecPi;
        private IHM.Composants.Led ledRecPi;
        private System.Windows.Forms.Label lblRecBeu;
        private IHM.Composants.Led ledRecBeu;
        private System.Windows.Forms.Label lblRecBun;
        private IHM.Composants.Led ledRecBun;
        private System.Windows.Forms.Label lblRecBoi;
        private IHM.Composants.Led ledRecBoi;
        private System.Windows.Forms.TabPage tabGrosRobot;
        private IHM.PanelGrosRobot panelGrosRobot;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox txtLogComplet;
        private System.Windows.Forms.TabPage tabMatch;
        private System.Windows.Forms.TabPage tabBalises;
        private PanelBalise panelBalise3;
        private PanelBalise panelBalise2;
        private PanelBalise panelBalise1;
        private System.Windows.Forms.PictureBox pictureBoxCouleur;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCouleurBleu;
        private System.Windows.Forms.TabPage tabTable;
        private PanelTable panelTable;
        private System.Windows.Forms.PictureBox pictureBoxBalises;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBaliseNon;
        private System.Windows.Forms.RadioButton radioBaliseOui;
        private System.Windows.Forms.Label lblPwmBalise3;
        private System.Windows.Forms.Label lblPwmBalise2;
        private System.Windows.Forms.Label lblPwmBalise1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBalises;
        private System.Windows.Forms.Button btnRecallage;
        private IHM.Composants.Led ledBalises;
        private IHM.Composants.Led ledRecallage;
        private IHM.Composants.Led led1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtTrames;
        private System.Windows.Forms.Button btnSaveReplay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAfficherTrame;
        private System.Windows.Forms.Button btnResetTrames;
        private System.Windows.Forms.Button btnChargerReplay;
        private System.Windows.Forms.Button btnRejouerReplay;
        private System.Windows.Forms.Label lblSimulation;
        private IHM.Composants.SwitchBouton switchBoutonSimu;
        private System.Windows.Forms.TabPage tabBougies;
        private PanelBougies panelBougies;
        private PanelPetitRobot panelPetitRobot;
        private System.Windows.Forms.Button btnArmerJack;
        private System.Windows.Forms.Button btnDegommage;
        private IHM.Composants.Led led2;
        private System.Windows.Forms.TabPage tabReglagePID;
        private PanelReglageAsserv panelReglageAsserv;
        private System.Windows.Forms.Button btnPiloteGros;
        private System.Windows.Forms.TabPage tabLedsBalises;
        private PanelImagesBalises panelImagesBalises;
    }
}

