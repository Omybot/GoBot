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
            this.tabMatch = new System.Windows.Forms.TabPage();
            this.panelMatch = new GoBot.IHM.PanelMatch();
            this.tabBalises = new System.Windows.Forms.TabPage();
            this.panelBalise3 = new GoBot.IHM.PanelBalise();
            this.panelBalise2 = new GoBot.IHM.PanelBalise();
            this.panelBalise1 = new GoBot.IHM.PanelBalise();
            this.tabLedsBalises = new System.Windows.Forms.TabPage();
            this.panelImagesBalises = new GoBot.IHM.PanelImagesBalises();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.btnPiloteGros = new System.Windows.Forms.Button();
            this.panelTable = new GoBot.IHM.PanelTable();
            this.tabCamera = new System.Windows.Forms.TabPage();
            this.panelCamera = new GoBot.IHM.PanelCamera();
            this.tabReglagePID = new System.Windows.Forms.TabPage();
            this.panelReglageAsserv = new GoBot.IHM.PanelReglageAsserv();
            this.tabLogsUdp = new System.Windows.Forms.TabPage();
            this.panelLogTrames = new GoBot.IHM.PanelLogsTrames();
            this.tabLogsEvent = new System.Windows.Forms.TabPage();
            this.panelLogsEvents = new GoBot.IHM.PanelLogsEvents();
            this.tabDiagnosticBalises = new System.Windows.Forms.TabPage();
            this.panelDiagnosticBalise3 = new GoBot.IHM.PanelDiagnosticBalise();
            this.panelDiagnosticBalise2 = new GoBot.IHM.PanelDiagnosticBalise();
            this.panelDiagnosticBalise1 = new GoBot.IHM.PanelDiagnosticBalise();
            this.tabDiagnosticRecMove = new System.Windows.Forms.TabPage();
            this.panelChargeCPU1 = new GoBot.IHM.PanelDiagnosticMove();
            this.tabTestLiaisons = new System.Windows.Forms.TabPage();
            this.panelTestLiaisons1 = new GoBot.IHM.PanelTestLiaisons();
            this.tabConnexions = new System.Windows.Forms.TabPage();
            this.panelEnvoiUdp1 = new GoBot.IHM.PanelEnvoiUdp();
            this.tabGestionLogs = new System.Windows.Forms.TabPage();
            this.panelGestionLog = new GoBot.IHM.PanelGestionLog();
            this.lblSimulation = new System.Windows.Forms.Label();
            this.switchBoutonSimu = new Composants.SwitchBouton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFenetre = new System.Windows.Forms.Button();
            this.panelConnexions = new GoBot.IHM.PanelConnexions();
            this.tabServomoteurs = new System.Windows.Forms.TabPage();
            this.panelServo1 = new GoBot.IHM.PanelServo();
            this.tabControl.SuspendLayout();
            this.tabGrosRobot.SuspendLayout();
            this.tabPetitRobot.SuspendLayout();
            this.tabMatch.SuspendLayout();
            this.tabBalises.SuspendLayout();
            this.tabLedsBalises.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tabCamera.SuspendLayout();
            this.tabReglagePID.SuspendLayout();
            this.tabLogsUdp.SuspendLayout();
            this.tabLogsEvent.SuspendLayout();
            this.tabDiagnosticBalises.SuspendLayout();
            this.tabDiagnosticRecMove.SuspendLayout();
            this.tabTestLiaisons.SuspendLayout();
            this.tabConnexions.SuspendLayout();
            this.tabGestionLogs.SuspendLayout();
            this.tabServomoteurs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabGrosRobot);
            this.tabControl.Controls.Add(this.tabPetitRobot);
            this.tabControl.Controls.Add(this.tabMatch);
            this.tabControl.Controls.Add(this.tabBalises);
            this.tabControl.Controls.Add(this.tabLedsBalises);
            this.tabControl.Controls.Add(this.tabTable);
            this.tabControl.Controls.Add(this.tabCamera);
            this.tabControl.Controls.Add(this.tabReglagePID);
            this.tabControl.Controls.Add(this.tabLogsUdp);
            this.tabControl.Controls.Add(this.tabLogsEvent);
            this.tabControl.Controls.Add(this.tabDiagnosticBalises);
            this.tabControl.Controls.Add(this.tabDiagnosticRecMove);
            this.tabControl.Controls.Add(this.tabTestLiaisons);
            this.tabControl.Controls.Add(this.tabConnexions);
            this.tabControl.Controls.Add(this.tabGestionLogs);
            this.tabControl.Controls.Add(this.tabServomoteurs);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1308, 738);
            this.tabControl.TabIndex = 25;
            // 
            // tabGrosRobot
            // 
            this.tabGrosRobot.Controls.Add(this.panelGrosRobot);
            this.tabGrosRobot.Location = new System.Drawing.Point(4, 22);
            this.tabGrosRobot.Name = "tabGrosRobot";
            this.tabGrosRobot.Size = new System.Drawing.Size(1300, 712);
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
            this.panelGrosRobot.Size = new System.Drawing.Size(1300, 712);
            this.panelGrosRobot.TabIndex = 0;
            // 
            // tabPetitRobot
            // 
            this.tabPetitRobot.Controls.Add(this.panelPetitRobot);
            this.tabPetitRobot.Location = new System.Drawing.Point(4, 22);
            this.tabPetitRobot.Name = "tabPetitRobot";
            this.tabPetitRobot.Size = new System.Drawing.Size(1300, 712);
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
            // tabMatch
            // 
            this.tabMatch.Controls.Add(this.panelMatch);
            this.tabMatch.Location = new System.Drawing.Point(4, 22);
            this.tabMatch.Name = "tabMatch";
            this.tabMatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatch.Size = new System.Drawing.Size(1300, 712);
            this.tabMatch.TabIndex = 3;
            this.tabMatch.Text = "Match";
            this.tabMatch.UseVisualStyleBackColor = true;
            // 
            // panelMatch
            // 
            this.panelMatch.BackColor = System.Drawing.Color.White;
            this.panelMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMatch.Location = new System.Drawing.Point(3, 3);
            this.panelMatch.Name = "panelMatch";
            this.panelMatch.Size = new System.Drawing.Size(186, 68);
            this.panelMatch.TabIndex = 0;
            // 
            // tabBalises
            // 
            this.tabBalises.Controls.Add(this.panelBalise3);
            this.tabBalises.Controls.Add(this.panelBalise2);
            this.tabBalises.Controls.Add(this.panelBalise1);
            this.tabBalises.Location = new System.Drawing.Point(4, 22);
            this.tabBalises.Name = "tabBalises";
            this.tabBalises.Padding = new System.Windows.Forms.Padding(3);
            this.tabBalises.Size = new System.Drawing.Size(1300, 712);
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
            this.panelBalise3.Size = new System.Drawing.Size(333, 700);
            this.panelBalise3.TabIndex = 2;
            // 
            // panelBalise2
            // 
            this.panelBalise2.BackColor = System.Drawing.Color.Transparent;
            this.panelBalise2.Balise = null;
            this.panelBalise2.Location = new System.Drawing.Point(339, 6);
            this.panelBalise2.Name = "panelBalise2";
            this.panelBalise2.Size = new System.Drawing.Size(333, 700);
            this.panelBalise2.TabIndex = 1;
            // 
            // panelBalise1
            // 
            this.panelBalise1.BackColor = System.Drawing.Color.Transparent;
            this.panelBalise1.Balise = null;
            this.panelBalise1.Location = new System.Drawing.Point(3, 6);
            this.panelBalise1.Name = "panelBalise1";
            this.panelBalise1.Size = new System.Drawing.Size(333, 700);
            this.panelBalise1.TabIndex = 0;
            // 
            // tabLedsBalises
            // 
            this.tabLedsBalises.Controls.Add(this.panelImagesBalises);
            this.tabLedsBalises.Location = new System.Drawing.Point(4, 22);
            this.tabLedsBalises.Name = "tabLedsBalises";
            this.tabLedsBalises.Size = new System.Drawing.Size(1300, 712);
            this.tabLedsBalises.TabIndex = 12;
            this.tabLedsBalises.Text = "Leds Balises";
            this.tabLedsBalises.UseVisualStyleBackColor = true;
            // 
            // panelImagesBalises
            // 
            this.panelImagesBalises.BackColor = System.Drawing.Color.Transparent;
            this.panelImagesBalises.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImagesBalises.Location = new System.Drawing.Point(0, 0);
            this.panelImagesBalises.Name = "panelImagesBalises";
            this.panelImagesBalises.Size = new System.Drawing.Size(192, 74);
            this.panelImagesBalises.TabIndex = 0;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.btnPiloteGros);
            this.tabTable.Controls.Add(this.panelTable);
            this.tabTable.Location = new System.Drawing.Point(4, 22);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTable.Size = new System.Drawing.Size(1300, 712);
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
            this.panelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTable.Location = new System.Drawing.Point(3, 3);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(186, 68);
            this.panelTable.TabIndex = 0;
            // 
            // tabCamera
            // 
            this.tabCamera.Controls.Add(this.panelCamera);
            this.tabCamera.Location = new System.Drawing.Point(4, 22);
            this.tabCamera.Name = "tabCamera";
            this.tabCamera.Size = new System.Drawing.Size(1300, 712);
            this.tabCamera.TabIndex = 10;
            this.tabCamera.Text = "Bougies";
            this.tabCamera.UseVisualStyleBackColor = true;
            // 
            // panelCamera
            // 
            this.panelCamera.Location = new System.Drawing.Point(3, 3);
            this.panelCamera.Name = "panelCamera";
            this.panelCamera.Size = new System.Drawing.Size(1005, 501);
            this.panelCamera.TabIndex = 0;
            // 
            // tabReglagePID
            // 
            this.tabReglagePID.Controls.Add(this.panelReglageAsserv);
            this.tabReglagePID.Location = new System.Drawing.Point(4, 22);
            this.tabReglagePID.Name = "tabReglagePID";
            this.tabReglagePID.Padding = new System.Windows.Forms.Padding(3);
            this.tabReglagePID.Size = new System.Drawing.Size(1300, 712);
            this.tabReglagePID.TabIndex = 11;
            this.tabReglagePID.Text = "Réglage PID";
            this.tabReglagePID.UseVisualStyleBackColor = true;
            // 
            // panelReglageAsserv
            // 
            this.panelReglageAsserv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReglageAsserv.Location = new System.Drawing.Point(3, 3);
            this.panelReglageAsserv.Name = "panelReglageAsserv";
            this.panelReglageAsserv.Size = new System.Drawing.Size(186, 68);
            this.panelReglageAsserv.TabIndex = 0;
            // 
            // tabLogsUdp
            // 
            this.tabLogsUdp.Controls.Add(this.panelLogTrames);
            this.tabLogsUdp.Location = new System.Drawing.Point(4, 22);
            this.tabLogsUdp.Name = "tabLogsUdp";
            this.tabLogsUdp.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogsUdp.Size = new System.Drawing.Size(1300, 712);
            this.tabLogsUdp.TabIndex = 14;
            this.tabLogsUdp.Text = "Logs UDP";
            this.tabLogsUdp.UseVisualStyleBackColor = true;
            // 
            // panelLogTrames
            // 
            this.panelLogTrames.BackColor = System.Drawing.Color.Transparent;
            this.panelLogTrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogTrames.Location = new System.Drawing.Point(3, 3);
            this.panelLogTrames.Name = "panelLogTrames";
            this.panelLogTrames.Size = new System.Drawing.Size(186, 68);
            this.panelLogTrames.TabIndex = 0;
            // 
            // tabLogsEvent
            // 
            this.tabLogsEvent.Controls.Add(this.panelLogsEvents);
            this.tabLogsEvent.Location = new System.Drawing.Point(4, 22);
            this.tabLogsEvent.Name = "tabLogsEvent";
            this.tabLogsEvent.Size = new System.Drawing.Size(1300, 712);
            this.tabLogsEvent.TabIndex = 15;
            this.tabLogsEvent.Text = "Logs events";
            this.tabLogsEvent.UseVisualStyleBackColor = true;
            // 
            // panelLogsEvents
            // 
            this.panelLogsEvents.BackColor = System.Drawing.Color.Transparent;
            this.panelLogsEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogsEvents.Location = new System.Drawing.Point(0, 0);
            this.panelLogsEvents.Name = "panelLogsEvents";
            this.panelLogsEvents.Size = new System.Drawing.Size(192, 74);
            this.panelLogsEvents.TabIndex = 0;
            // 
            // tabDiagnosticBalises
            // 
            this.tabDiagnosticBalises.Controls.Add(this.panelDiagnosticBalise3);
            this.tabDiagnosticBalises.Controls.Add(this.panelDiagnosticBalise2);
            this.tabDiagnosticBalises.Controls.Add(this.panelDiagnosticBalise1);
            this.tabDiagnosticBalises.Location = new System.Drawing.Point(4, 22);
            this.tabDiagnosticBalises.Name = "tabDiagnosticBalises";
            this.tabDiagnosticBalises.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiagnosticBalises.Size = new System.Drawing.Size(1300, 712);
            this.tabDiagnosticBalises.TabIndex = 13;
            this.tabDiagnosticBalises.Text = "Diagnostic Balises";
            this.tabDiagnosticBalises.UseVisualStyleBackColor = true;
            // 
            // panelDiagnosticBalise3
            // 
            this.panelDiagnosticBalise3.BackColor = System.Drawing.Color.Transparent;
            this.panelDiagnosticBalise3.Balise = null;
            this.panelDiagnosticBalise3.Location = new System.Drawing.Point(809, 6);
            this.panelDiagnosticBalise3.Name = "panelDiagnosticBalise3";
            this.panelDiagnosticBalise3.Size = new System.Drawing.Size(397, 700);
            this.panelDiagnosticBalise3.TabIndex = 2;
            // 
            // panelDiagnosticBalise2
            // 
            this.panelDiagnosticBalise2.BackColor = System.Drawing.Color.Transparent;
            this.panelDiagnosticBalise2.Balise = null;
            this.panelDiagnosticBalise2.Location = new System.Drawing.Point(406, 6);
            this.panelDiagnosticBalise2.Name = "panelDiagnosticBalise2";
            this.panelDiagnosticBalise2.Size = new System.Drawing.Size(397, 700);
            this.panelDiagnosticBalise2.TabIndex = 1;
            // 
            // panelDiagnosticBalise1
            // 
            this.panelDiagnosticBalise1.BackColor = System.Drawing.Color.Transparent;
            this.panelDiagnosticBalise1.Balise = null;
            this.panelDiagnosticBalise1.Location = new System.Drawing.Point(3, 6);
            this.panelDiagnosticBalise1.Name = "panelDiagnosticBalise1";
            this.panelDiagnosticBalise1.Size = new System.Drawing.Size(397, 700);
            this.panelDiagnosticBalise1.TabIndex = 0;
            // 
            // tabDiagnosticRecMove
            // 
            this.tabDiagnosticRecMove.Controls.Add(this.panelChargeCPU1);
            this.tabDiagnosticRecMove.Location = new System.Drawing.Point(4, 22);
            this.tabDiagnosticRecMove.Name = "tabDiagnosticRecMove";
            this.tabDiagnosticRecMove.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiagnosticRecMove.Size = new System.Drawing.Size(1300, 712);
            this.tabDiagnosticRecMove.TabIndex = 16;
            this.tabDiagnosticRecMove.Text = "Diagnostic RecMove";
            this.tabDiagnosticRecMove.UseVisualStyleBackColor = true;
            // 
            // panelChargeCPU1
            // 
            this.panelChargeCPU1.Location = new System.Drawing.Point(3, 3);
            this.panelChargeCPU1.Name = "panelChargeCPU1";
            this.panelChargeCPU1.Size = new System.Drawing.Size(1133, 615);
            this.panelChargeCPU1.TabIndex = 0;
            // 
            // tabTestLiaisons
            // 
            this.tabTestLiaisons.Controls.Add(this.panelTestLiaisons1);
            this.tabTestLiaisons.Location = new System.Drawing.Point(4, 22);
            this.tabTestLiaisons.Name = "tabTestLiaisons";
            this.tabTestLiaisons.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestLiaisons.Size = new System.Drawing.Size(1300, 712);
            this.tabTestLiaisons.TabIndex = 17;
            this.tabTestLiaisons.Text = "Test liaisons";
            this.tabTestLiaisons.UseVisualStyleBackColor = true;
            // 
            // panelTestLiaisons1
            // 
            this.panelTestLiaisons1.Location = new System.Drawing.Point(8, 6);
            this.panelTestLiaisons1.Name = "panelTestLiaisons1";
            this.panelTestLiaisons1.Size = new System.Drawing.Size(1260, 570);
            this.panelTestLiaisons1.TabIndex = 0;
            // 
            // tabConnexions
            // 
            this.tabConnexions.Controls.Add(this.panelEnvoiUdp1);
            this.tabConnexions.Location = new System.Drawing.Point(4, 22);
            this.tabConnexions.Name = "tabConnexions";
            this.tabConnexions.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnexions.Size = new System.Drawing.Size(1300, 712);
            this.tabConnexions.TabIndex = 18;
            this.tabConnexions.Text = "Connexions UDP";
            this.tabConnexions.UseVisualStyleBackColor = true;
            // 
            // panelEnvoiUdp1
            // 
            this.panelEnvoiUdp1.BackColor = System.Drawing.Color.White;
            this.panelEnvoiUdp1.Location = new System.Drawing.Point(8, 6);
            this.panelEnvoiUdp1.Name = "panelEnvoiUdp1";
            this.panelEnvoiUdp1.Size = new System.Drawing.Size(850, 509);
            this.panelEnvoiUdp1.TabIndex = 0;
            // 
            // tabGestionLogs
            // 
            this.tabGestionLogs.Controls.Add(this.panelGestionLog);
            this.tabGestionLogs.Location = new System.Drawing.Point(4, 22);
            this.tabGestionLogs.Name = "tabGestionLogs";
            this.tabGestionLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabGestionLogs.Size = new System.Drawing.Size(1300, 712);
            this.tabGestionLogs.TabIndex = 19;
            this.tabGestionLogs.Text = "Gestion logs";
            this.tabGestionLogs.UseVisualStyleBackColor = true;
            // 
            // panelGestionLog
            // 
            this.panelGestionLog.BackColor = System.Drawing.Color.White;
            this.panelGestionLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGestionLog.Location = new System.Drawing.Point(3, 3);
            this.panelGestionLog.Name = "panelGestionLog";
            this.panelGestionLog.Size = new System.Drawing.Size(186, 68);
            this.panelGestionLog.TabIndex = 0;
            // 
            // lblSimulation
            // 
            this.lblSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSimulation.AutoSize = true;
            this.lblSimulation.Location = new System.Drawing.Point(1249, 742);
            this.lblSimulation.Name = "lblSimulation";
            this.lblSimulation.Size = new System.Drawing.Size(55, 13);
            this.lblSimulation.TabIndex = 72;
            this.lblSimulation.Text = "Simulation";
            // 
            // switchBoutonSimu
            // 
            this.switchBoutonSimu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.switchBoutonSimu.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonSimu.Location = new System.Drawing.Point(1208, 742);
            this.switchBoutonSimu.Name = "switchBoutonSimu";
            this.switchBoutonSimu.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonSimu.Symetrique = true;
            this.switchBoutonSimu.TabIndex = 73;
            this.switchBoutonSimu.ChangementEtat += new System.EventHandler(this.switchBoutonSimu_ChangementEtat);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::GoBot.Properties.Resources.Close;
            this.btnClose.Location = new System.Drawing.Point(1286, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 71;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFenetre
            // 
            this.btnFenetre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFenetre.Image = global::GoBot.Properties.Resources.Fenetre;
            this.btnFenetre.Location = new System.Drawing.Point(1262, 0);
            this.btnFenetre.Name = "btnFenetre";
            this.btnFenetre.Size = new System.Drawing.Size(20, 20);
            this.btnFenetre.TabIndex = 75;
            this.btnFenetre.UseVisualStyleBackColor = true;
            this.btnFenetre.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelConnexions
            // 
            this.panelConnexions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelConnexions.BackColor = System.Drawing.Color.White;
            this.panelConnexions.Location = new System.Drawing.Point(0, 735);
            this.panelConnexions.Name = "panelConnexions";
            this.panelConnexions.Size = new System.Drawing.Size(849, 27);
            this.panelConnexions.TabIndex = 74;
            // 
            // tabServomoteurs
            // 
            this.tabServomoteurs.Controls.Add(this.panelServo1);
            this.tabServomoteurs.Location = new System.Drawing.Point(4, 22);
            this.tabServomoteurs.Name = "tabServomoteurs";
            this.tabServomoteurs.Padding = new System.Windows.Forms.Padding(3);
            this.tabServomoteurs.Size = new System.Drawing.Size(1300, 712);
            this.tabServomoteurs.TabIndex = 20;
            this.tabServomoteurs.Text = "Servomoteurs";
            this.tabServomoteurs.UseVisualStyleBackColor = true;
            // 
            // panelServo1
            // 
            this.panelServo1.BackColor = System.Drawing.Color.Transparent;
            this.panelServo1.Location = new System.Drawing.Point(333, 92);
            this.panelServo1.Name = "panelServo1";
            this.panelServo1.Size = new System.Drawing.Size(843, 497);
            this.panelServo1.TabIndex = 41;
            // 
            // FenGoBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1308, 764);
            this.Controls.Add(this.switchBoutonSimu);
            this.Controls.Add(this.lblSimulation);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFenetre);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelConnexions);
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
            this.tabMatch.ResumeLayout(false);
            this.tabBalises.ResumeLayout(false);
            this.tabLedsBalises.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabCamera.ResumeLayout(false);
            this.tabReglagePID.ResumeLayout(false);
            this.tabLogsUdp.ResumeLayout(false);
            this.tabLogsEvent.ResumeLayout(false);
            this.tabDiagnosticBalises.ResumeLayout(false);
            this.tabDiagnosticRecMove.ResumeLayout(false);
            this.tabTestLiaisons.ResumeLayout(false);
            this.tabConnexions.ResumeLayout(false);
            this.tabGestionLogs.ResumeLayout(false);
            this.tabServomoteurs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPetitRobot;
        private System.Windows.Forms.TabPage tabGrosRobot;
        private IHM.PanelGrosRobot panelGrosRobot;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tabMatch;
        private System.Windows.Forms.TabPage tabBalises;
        private PanelBalise panelBalise3;
        private PanelBalise panelBalise2;
        private PanelBalise panelBalise1;
        private System.Windows.Forms.TabPage tabTable;
        private PanelTable panelTable;
        private System.Windows.Forms.Label lblSimulation;
        private Composants.SwitchBouton switchBoutonSimu;
        private System.Windows.Forms.TabPage tabCamera;
        private PanelCamera panelCamera;
        private PanelPetitRobot panelPetitRobot;
        private System.Windows.Forms.TabPage tabReglagePID;
        private PanelReglageAsserv panelReglageAsserv;
        private System.Windows.Forms.Button btnPiloteGros;
        private System.Windows.Forms.TabPage tabLedsBalises;
        private PanelImagesBalises panelImagesBalises;
        private System.Windows.Forms.TabPage tabDiagnosticBalises;
        private PanelDiagnosticBalise panelDiagnosticBalise3;
        private PanelDiagnosticBalise panelDiagnosticBalise2;
        private PanelDiagnosticBalise panelDiagnosticBalise1;
        private System.Windows.Forms.TabPage tabLogsUdp;
        private PanelLogsTrames panelLogTrames;
        private System.Windows.Forms.TabPage tabLogsEvent;
        private PanelConnexions panelConnexions;
        private PanelMatch panelMatch;
        private System.Windows.Forms.TabPage tabDiagnosticRecMove;
        private PanelDiagnosticMove panelChargeCPU1;
        private System.Windows.Forms.TabPage tabTestLiaisons;
        private PanelTestLiaisons panelTestLiaisons1;
        private PanelLogsEvents panelLogsEvents;
        private System.Windows.Forms.TabPage tabConnexions;
        private PanelEnvoiUdp panelEnvoiUdp1;
        private System.Windows.Forms.Button btnFenetre;
        private System.Windows.Forms.TabPage tabGestionLogs;
        private PanelGestionLog panelGestionLog;
        private System.Windows.Forms.TabPage tabServomoteurs;
        private PanelServo panelServo1;
    }
}

