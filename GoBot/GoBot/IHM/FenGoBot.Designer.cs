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
            this.lblSimulation = new System.Windows.Forms.Label();
            this.tabAlimentation = new System.Windows.Forms.TabPage();
            this.panelAlimentation1 = new GoBot.IHM.PanelAlimentation();
            this.tabServomoteurs = new System.Windows.Forms.TabPage();
            this.panelPololu1 = new GoBot.IHM.PanelPololu();
            this.panelTestServos1 = new GoBot.IHM.PanelTestServos();
            this.tabConnexions = new System.Windows.Forms.TabPage();
            this.panelEnvoiUdp1 = new GoBot.IHM.PanelEnvoiUdp();
            this.tabDiagnosticRecMove = new System.Windows.Forms.TabPage();
            this.panelChargeCPU1 = new GoBot.IHM.PanelDiagnosticMove();
            this.tabReglagePID = new System.Windows.Forms.TabPage();
            this.panelReglageAsserv = new GoBot.IHM.PanelReglageAsserv();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.tabControlLogs = new System.Windows.Forms.TabControl();
            this.tabLogUDP = new System.Windows.Forms.TabPage();
            this.panelLogTrames = new GoBot.IHM.PanelLogsTrames();
            this.tabLogEvent = new System.Windows.Forms.TabPage();
            this.panelLogsEvents = new GoBot.IHM.PanelLogsEvents();
            this.tabGestionLog = new System.Windows.Forms.TabPage();
            this.panelGestionLog = new GoBot.IHM.PanelGestionLog();
            this.tabCamera = new System.Windows.Forms.TabPage();
            this.panelCamera = new GoBot.IHM.PanelCamera();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.panelTable = new GoBot.IHM.PanelTable();
            this.tabMatch = new System.Windows.Forms.TabPage();
            this.panelMatch = new GoBot.IHM.PanelMatch();
            this.tabGrosRobot = new System.Windows.Forms.TabPage();
            this.panelGrosRobot = new GoBot.IHM.PanelGrosRobot();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConstantes = new System.Windows.Forms.TabPage();
            this.panelConstantes = new GoBot.IHM.PanelConstantes();
            this.tabPortsAnalogiques = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIO = new System.Windows.Forms.TabPage();
            this.panelAnalogiqueIO = new GoBot.IHM.PanelAnalogique();
            this.tabMove = new System.Windows.Forms.TabPage();
            this.panelAnalogiqueMove = new GoBot.IHM.PanelAnalogique();
            this.tabGB = new System.Windows.Forms.TabPage();
            this.panelAnalogiqueGB = new GoBot.IHM.PanelAnalogique();
            this.tabBaliseUnique = new System.Windows.Forms.TabPage();
            this.panelBaliseDiagnostic = new GoBot.IHM.PanelBaliseDiagnostic();
            this.panelBalise = new GoBot.IHM.PanelBalise();
            this.tabRecGoBot = new System.Windows.Forms.TabPage();
            this.grpCapteurs = new System.Windows.Forms.GroupBox();
            this.grpRecGB = new System.Windows.Forms.GroupBox();
            this.panelRecGoBot1 = new GoBot.IHM.PanelRecGoBot();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFenetre = new System.Windows.Forms.Button();
            this.switchBoutonSimu = new Composants.SwitchBouton();
            this.panelConnexions = new GoBot.IHM.PanelConnexions();
            this.panelCapteurs1 = new GoBot.IHM.PanelCapteurs();
            this.tabAlimentation.SuspendLayout();
            this.tabServomoteurs.SuspendLayout();
            this.tabConnexions.SuspendLayout();
            this.tabDiagnosticRecMove.SuspendLayout();
            this.tabReglagePID.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabControlLogs.SuspendLayout();
            this.tabLogUDP.SuspendLayout();
            this.tabLogEvent.SuspendLayout();
            this.tabGestionLog.SuspendLayout();
            this.tabCamera.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tabMatch.SuspendLayout();
            this.tabGrosRobot.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabConstantes.SuspendLayout();
            this.tabPortsAnalogiques.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabIO.SuspendLayout();
            this.tabMove.SuspendLayout();
            this.tabGB.SuspendLayout();
            this.tabBaliseUnique.SuspendLayout();
            this.tabRecGoBot.SuspendLayout();
            this.grpCapteurs.SuspendLayout();
            this.grpRecGB.SuspendLayout();
            this.SuspendLayout();
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
            // tabAlimentation
            // 
            this.tabAlimentation.Controls.Add(this.panelAlimentation1);
            this.tabAlimentation.Location = new System.Drawing.Point(4, 22);
            this.tabAlimentation.Name = "tabAlimentation";
            this.tabAlimentation.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlimentation.Size = new System.Drawing.Size(1300, 712);
            this.tabAlimentation.TabIndex = 21;
            this.tabAlimentation.Text = "Alimentation";
            this.tabAlimentation.UseVisualStyleBackColor = true;
            // 
            // panelAlimentation1
            // 
            this.panelAlimentation1.Location = new System.Drawing.Point(6, 6);
            this.panelAlimentation1.Name = "panelAlimentation1";
            this.panelAlimentation1.Size = new System.Drawing.Size(1025, 501);
            this.panelAlimentation1.TabIndex = 0;
            // 
            // tabServomoteurs
            // 
            this.tabServomoteurs.Controls.Add(this.panelPololu1);
            this.tabServomoteurs.Controls.Add(this.panelTestServos1);
            this.tabServomoteurs.Location = new System.Drawing.Point(4, 22);
            this.tabServomoteurs.Name = "tabServomoteurs";
            this.tabServomoteurs.Padding = new System.Windows.Forms.Padding(3);
            this.tabServomoteurs.Size = new System.Drawing.Size(1300, 712);
            this.tabServomoteurs.TabIndex = 20;
            this.tabServomoteurs.Text = "Servomoteurs";
            this.tabServomoteurs.UseVisualStyleBackColor = true;
            // 
            // panelPololu1
            // 
            this.panelPololu1.Location = new System.Drawing.Point(243, 552);
            this.panelPololu1.Name = "panelPololu1";
            this.panelPololu1.Size = new System.Drawing.Size(620, 137);
            this.panelPololu1.TabIndex = 1;
            // 
            // panelTestServos1
            // 
            this.panelTestServos1.Location = new System.Drawing.Point(8, 6);
            this.panelTestServos1.Name = "panelTestServos1";
            this.panelTestServos1.Size = new System.Drawing.Size(1289, 540);
            this.panelTestServos1.TabIndex = 0;
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
            this.panelReglageAsserv.Size = new System.Drawing.Size(1294, 706);
            this.panelReglageAsserv.TabIndex = 0;
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.tabControlLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(1300, 712);
            this.tabLogs.TabIndex = 22;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // tabControlLogs
            // 
            this.tabControlLogs.Controls.Add(this.tabLogUDP);
            this.tabControlLogs.Controls.Add(this.tabLogEvent);
            this.tabControlLogs.Controls.Add(this.tabGestionLog);
            this.tabControlLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLogs.Location = new System.Drawing.Point(3, 3);
            this.tabControlLogs.Name = "tabControlLogs";
            this.tabControlLogs.SelectedIndex = 0;
            this.tabControlLogs.Size = new System.Drawing.Size(1294, 706);
            this.tabControlLogs.TabIndex = 0;
            // 
            // tabLogUDP
            // 
            this.tabLogUDP.Controls.Add(this.panelLogTrames);
            this.tabLogUDP.Location = new System.Drawing.Point(4, 22);
            this.tabLogUDP.Name = "tabLogUDP";
            this.tabLogUDP.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogUDP.Size = new System.Drawing.Size(1286, 680);
            this.tabLogUDP.TabIndex = 0;
            this.tabLogUDP.Text = "Logs UDP";
            this.tabLogUDP.UseVisualStyleBackColor = true;
            // 
            // panelLogTrames
            // 
            this.panelLogTrames.BackColor = System.Drawing.Color.Transparent;
            this.panelLogTrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogTrames.Location = new System.Drawing.Point(3, 3);
            this.panelLogTrames.Name = "panelLogTrames";
            this.panelLogTrames.Size = new System.Drawing.Size(1280, 674);
            this.panelLogTrames.TabIndex = 1;
            // 
            // tabLogEvent
            // 
            this.tabLogEvent.Controls.Add(this.panelLogsEvents);
            this.tabLogEvent.Location = new System.Drawing.Point(4, 22);
            this.tabLogEvent.Name = "tabLogEvent";
            this.tabLogEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogEvent.Size = new System.Drawing.Size(178, 42);
            this.tabLogEvent.TabIndex = 1;
            this.tabLogEvent.Text = "Logs events";
            this.tabLogEvent.UseVisualStyleBackColor = true;
            // 
            // panelLogsEvents
            // 
            this.panelLogsEvents.BackColor = System.Drawing.Color.Transparent;
            this.panelLogsEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogsEvents.Location = new System.Drawing.Point(3, 3);
            this.panelLogsEvents.Name = "panelLogsEvents";
            this.panelLogsEvents.Size = new System.Drawing.Size(172, 36);
            this.panelLogsEvents.TabIndex = 1;
            // 
            // tabGestionLog
            // 
            this.tabGestionLog.Controls.Add(this.panelGestionLog);
            this.tabGestionLog.Location = new System.Drawing.Point(4, 22);
            this.tabGestionLog.Name = "tabGestionLog";
            this.tabGestionLog.Size = new System.Drawing.Size(178, 42);
            this.tabGestionLog.TabIndex = 2;
            this.tabGestionLog.Text = "Gestion logs";
            this.tabGestionLog.UseVisualStyleBackColor = true;
            // 
            // panelGestionLog
            // 
            this.panelGestionLog.BackColor = System.Drawing.Color.White;
            this.panelGestionLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGestionLog.Location = new System.Drawing.Point(0, 0);
            this.panelGestionLog.Name = "panelGestionLog";
            this.panelGestionLog.Size = new System.Drawing.Size(178, 42);
            this.panelGestionLog.TabIndex = 1;
            // 
            // tabCamera
            // 
            this.tabCamera.Controls.Add(this.panelCamera);
            this.tabCamera.Location = new System.Drawing.Point(4, 22);
            this.tabCamera.Name = "tabCamera";
            this.tabCamera.Size = new System.Drawing.Size(1300, 712);
            this.tabCamera.TabIndex = 10;
            this.tabCamera.Text = "Caméra";
            this.tabCamera.UseVisualStyleBackColor = true;
            // 
            // panelCamera
            // 
            this.panelCamera.ContinuerCamera = true;
            this.panelCamera.Location = new System.Drawing.Point(3, 3);
            this.panelCamera.Name = "panelCamera";
            this.panelCamera.Size = new System.Drawing.Size(1005, 501);
            this.panelCamera.TabIndex = 0;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.panelTable);
            this.tabTable.Location = new System.Drawing.Point(4, 22);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTable.Size = new System.Drawing.Size(1300, 712);
            this.tabTable.TabIndex = 7;
            this.tabTable.Text = "Table";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // panelTable
            // 
            this.panelTable.BackColor = System.Drawing.Color.Transparent;
            this.panelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTable.Location = new System.Drawing.Point(3, 3);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(1294, 706);
            this.panelTable.TabIndex = 0;
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
            this.panelMatch.Size = new System.Drawing.Size(1294, 706);
            this.panelMatch.TabIndex = 0;
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
            this.panelGrosRobot.BackColor = System.Drawing.Color.White;
            this.panelGrosRobot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrosRobot.Location = new System.Drawing.Point(0, 0);
            this.panelGrosRobot.Name = "panelGrosRobot";
            this.panelGrosRobot.Size = new System.Drawing.Size(1300, 712);
            this.panelGrosRobot.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabTable);
            this.tabControl.Controls.Add(this.tabGrosRobot);
            this.tabControl.Controls.Add(this.tabMatch);
            this.tabControl.Controls.Add(this.tabCamera);
            this.tabControl.Controls.Add(this.tabLogs);
            this.tabControl.Controls.Add(this.tabReglagePID);
            this.tabControl.Controls.Add(this.tabDiagnosticRecMove);
            this.tabControl.Controls.Add(this.tabConnexions);
            this.tabControl.Controls.Add(this.tabServomoteurs);
            this.tabControl.Controls.Add(this.tabAlimentation);
            this.tabControl.Controls.Add(this.tabConstantes);
            this.tabControl.Controls.Add(this.tabPortsAnalogiques);
            this.tabControl.Controls.Add(this.tabBaliseUnique);
            this.tabControl.Controls.Add(this.tabRecGoBot);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1308, 738);
            this.tabControl.TabIndex = 25;
            // 
            // tabConstantes
            // 
            this.tabConstantes.Controls.Add(this.panelConstantes);
            this.tabConstantes.Location = new System.Drawing.Point(4, 22);
            this.tabConstantes.Name = "tabConstantes";
            this.tabConstantes.Padding = new System.Windows.Forms.Padding(3);
            this.tabConstantes.Size = new System.Drawing.Size(1300, 712);
            this.tabConstantes.TabIndex = 23;
            this.tabConstantes.Text = "Constantes";
            this.tabConstantes.UseVisualStyleBackColor = true;
            // 
            // panelConstantes
            // 
            this.panelConstantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConstantes.Location = new System.Drawing.Point(3, 3);
            this.panelConstantes.Name = "panelConstantes";
            this.panelConstantes.Size = new System.Drawing.Size(1294, 706);
            this.panelConstantes.TabIndex = 0;
            // 
            // tabPortsAnalogiques
            // 
            this.tabPortsAnalogiques.Controls.Add(this.tabControl1);
            this.tabPortsAnalogiques.Location = new System.Drawing.Point(4, 22);
            this.tabPortsAnalogiques.Name = "tabPortsAnalogiques";
            this.tabPortsAnalogiques.Padding = new System.Windows.Forms.Padding(3);
            this.tabPortsAnalogiques.Size = new System.Drawing.Size(1300, 712);
            this.tabPortsAnalogiques.TabIndex = 24;
            this.tabPortsAnalogiques.Text = "Ports analogiques";
            this.tabPortsAnalogiques.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabIO);
            this.tabControl1.Controls.Add(this.tabMove);
            this.tabControl1.Controls.Add(this.tabGB);
            this.tabControl1.Location = new System.Drawing.Point(8, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1284, 700);
            this.tabControl1.TabIndex = 1;
            // 
            // tabIO
            // 
            this.tabIO.Controls.Add(this.panelAnalogiqueIO);
            this.tabIO.Location = new System.Drawing.Point(4, 22);
            this.tabIO.Name = "tabIO";
            this.tabIO.Padding = new System.Windows.Forms.Padding(3);
            this.tabIO.Size = new System.Drawing.Size(1276, 674);
            this.tabIO.TabIndex = 0;
            this.tabIO.Text = "RecIO";
            this.tabIO.UseVisualStyleBackColor = true;
            // 
            // panelAnalogiqueIO
            // 
            this.panelAnalogiqueIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalogiqueIO.Location = new System.Drawing.Point(3, 3);
            this.panelAnalogiqueIO.Name = "panelAnalogiqueIO";
            this.panelAnalogiqueIO.Size = new System.Drawing.Size(1270, 668);
            this.panelAnalogiqueIO.TabIndex = 0;
            // 
            // tabMove
            // 
            this.tabMove.Controls.Add(this.panelAnalogiqueMove);
            this.tabMove.Location = new System.Drawing.Point(4, 22);
            this.tabMove.Name = "tabMove";
            this.tabMove.Padding = new System.Windows.Forms.Padding(3);
            this.tabMove.Size = new System.Drawing.Size(1276, 674);
            this.tabMove.TabIndex = 1;
            this.tabMove.Text = "RecMove";
            this.tabMove.UseVisualStyleBackColor = true;
            // 
            // panelAnalogiqueMove
            // 
            this.panelAnalogiqueMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalogiqueMove.Location = new System.Drawing.Point(3, 3);
            this.panelAnalogiqueMove.Name = "panelAnalogiqueMove";
            this.panelAnalogiqueMove.Size = new System.Drawing.Size(1270, 668);
            this.panelAnalogiqueMove.TabIndex = 0;
            // 
            // tabGB
            // 
            this.tabGB.Controls.Add(this.panelAnalogiqueGB);
            this.tabGB.Location = new System.Drawing.Point(4, 22);
            this.tabGB.Name = "tabGB";
            this.tabGB.Padding = new System.Windows.Forms.Padding(3);
            this.tabGB.Size = new System.Drawing.Size(1276, 674);
            this.tabGB.TabIndex = 2;
            this.tabGB.Text = "RecGoBot";
            this.tabGB.UseVisualStyleBackColor = true;
            // 
            // panelAnalogiqueGB
            // 
            this.panelAnalogiqueGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalogiqueGB.Location = new System.Drawing.Point(3, 3);
            this.panelAnalogiqueGB.Name = "panelAnalogiqueGB";
            this.panelAnalogiqueGB.Size = new System.Drawing.Size(1270, 668);
            this.panelAnalogiqueGB.TabIndex = 0;
            // 
            // tabBaliseUnique
            // 
            this.tabBaliseUnique.Controls.Add(this.panelBaliseDiagnostic);
            this.tabBaliseUnique.Controls.Add(this.panelBalise);
            this.tabBaliseUnique.Location = new System.Drawing.Point(4, 22);
            this.tabBaliseUnique.Name = "tabBaliseUnique";
            this.tabBaliseUnique.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaliseUnique.Size = new System.Drawing.Size(1300, 712);
            this.tabBaliseUnique.TabIndex = 25;
            this.tabBaliseUnique.Text = "Balise unique";
            this.tabBaliseUnique.UseVisualStyleBackColor = true;
            // 
            // panelBaliseDiagnostic
            // 
            this.panelBaliseDiagnostic.BackColor = System.Drawing.Color.Transparent;
            this.panelBaliseDiagnostic.Balise = null;
            this.panelBaliseDiagnostic.Location = new System.Drawing.Point(347, 6);
            this.panelBaliseDiagnostic.Name = "panelBaliseDiagnostic";
            this.panelBaliseDiagnostic.Size = new System.Drawing.Size(333, 604);
            this.panelBaliseDiagnostic.TabIndex = 1;
            // 
            // panelBalise
            // 
            this.panelBalise.BackColor = System.Drawing.Color.Transparent;
            this.panelBalise.Balise = null;
            this.panelBalise.Location = new System.Drawing.Point(8, 6);
            this.panelBalise.Name = "panelBalise";
            this.panelBalise.Size = new System.Drawing.Size(333, 604);
            this.panelBalise.TabIndex = 0;
            // 
            // tabRecGoBot
            // 
            this.tabRecGoBot.Controls.Add(this.grpCapteurs);
            this.tabRecGoBot.Controls.Add(this.grpRecGB);
            this.tabRecGoBot.Location = new System.Drawing.Point(4, 22);
            this.tabRecGoBot.Name = "tabRecGoBot";
            this.tabRecGoBot.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecGoBot.Size = new System.Drawing.Size(1300, 712);
            this.tabRecGoBot.TabIndex = 26;
            this.tabRecGoBot.Text = "RecGoBot";
            this.tabRecGoBot.UseVisualStyleBackColor = true;
            // 
            // grpCapteurs
            // 
            this.grpCapteurs.Controls.Add(this.panelCapteurs1);
            this.grpCapteurs.Location = new System.Drawing.Point(292, 54);
            this.grpCapteurs.Name = "grpCapteurs";
            this.grpCapteurs.Size = new System.Drawing.Size(273, 197);
            this.grpCapteurs.TabIndex = 4;
            this.grpCapteurs.TabStop = false;
            this.grpCapteurs.Text = "Capteurs";
            // 
            // grpRecGB
            // 
            this.grpRecGB.Controls.Add(this.panelRecGoBot1);
            this.grpRecGB.Location = new System.Drawing.Point(48, 54);
            this.grpRecGB.Name = "grpRecGB";
            this.grpRecGB.Size = new System.Drawing.Size(238, 360);
            this.grpRecGB.TabIndex = 3;
            this.grpRecGB.TabStop = false;
            this.grpRecGB.Text = "RecGoBot";
            // 
            // panelRecGoBot1
            // 
            this.panelRecGoBot1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelRecGoBot1.Location = new System.Drawing.Point(11, 19);
            this.panelRecGoBot1.Name = "panelRecGoBot1";
            this.panelRecGoBot1.Size = new System.Drawing.Size(221, 332);
            this.panelRecGoBot1.TabIndex = 2;
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
            this.btnFenetre.Click += new System.EventHandler(this.buttonFenetre_Click);
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
            // panelConnexions
            // 
            this.panelConnexions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelConnexions.BackColor = System.Drawing.Color.White;
            this.panelConnexions.Location = new System.Drawing.Point(0, 735);
            this.panelConnexions.Name = "panelConnexions";
            this.panelConnexions.Size = new System.Drawing.Size(980, 27);
            this.panelConnexions.TabIndex = 74;
            // 
            // panelCapteurs1
            // 
            this.panelCapteurs1.Location = new System.Drawing.Point(6, 19);
            this.panelCapteurs1.Name = "panelCapteurs1";
            this.panelCapteurs1.Size = new System.Drawing.Size(261, 172);
            this.panelCapteurs1.TabIndex = 1;
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
            this.tabAlimentation.ResumeLayout(false);
            this.tabServomoteurs.ResumeLayout(false);
            this.tabConnexions.ResumeLayout(false);
            this.tabDiagnosticRecMove.ResumeLayout(false);
            this.tabReglagePID.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabControlLogs.ResumeLayout(false);
            this.tabLogUDP.ResumeLayout(false);
            this.tabLogEvent.ResumeLayout(false);
            this.tabGestionLog.ResumeLayout(false);
            this.tabCamera.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabMatch.ResumeLayout(false);
            this.tabGrosRobot.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabConstantes.ResumeLayout(false);
            this.tabPortsAnalogiques.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabIO.ResumeLayout(false);
            this.tabMove.ResumeLayout(false);
            this.tabGB.ResumeLayout(false);
            this.tabBaliseUnique.ResumeLayout(false);
            this.tabRecGoBot.ResumeLayout(false);
            this.grpCapteurs.ResumeLayout(false);
            this.grpRecGB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSimulation;
        private Composants.SwitchBouton switchBoutonSimu;
        private PanelConnexions panelConnexions;
        private System.Windows.Forms.Button btnFenetre;
        private System.Windows.Forms.TabPage tabAlimentation;
        private PanelAlimentation panelAlimentation1;
        private System.Windows.Forms.TabPage tabServomoteurs;
        private PanelTestServos panelTestServos1;
        private System.Windows.Forms.TabPage tabConnexions;
        private PanelEnvoiUdp panelEnvoiUdp1;
        private System.Windows.Forms.TabPage tabDiagnosticRecMove;
        private PanelDiagnosticMove panelChargeCPU1;
        private System.Windows.Forms.TabPage tabReglagePID;
        private PanelReglageAsserv panelReglageAsserv;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.TabControl tabControlLogs;
        private System.Windows.Forms.TabPage tabLogUDP;
        private PanelLogsTrames panelLogTrames;
        private System.Windows.Forms.TabPage tabLogEvent;
        private PanelLogsEvents panelLogsEvents;
        private System.Windows.Forms.TabPage tabGestionLog;
        private PanelGestionLog panelGestionLog;
        private System.Windows.Forms.TabPage tabCamera;
        private PanelCamera panelCamera;
        private System.Windows.Forms.TabPage tabTable;
        private PanelTable panelTable;
        private System.Windows.Forms.TabPage tabMatch;
        private PanelMatch panelMatch;
        private System.Windows.Forms.TabPage tabGrosRobot;
        private PanelGrosRobot panelGrosRobot;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConstantes;
        private PanelConstantes panelConstantes;
        private System.Windows.Forms.TabPage tabPortsAnalogiques;
        private System.Windows.Forms.TabPage tabBaliseUnique;
        private PanelBaliseDiagnostic panelBaliseDiagnostic;
        private PanelBalise panelBalise;
        private System.Windows.Forms.TabPage tabRecGoBot;
        private PanelPololu panelPololu1;
        private System.Windows.Forms.GroupBox grpCapteurs;
        private System.Windows.Forms.GroupBox grpRecGB;
        private PanelRecGoBot panelRecGoBot1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabIO;
        private System.Windows.Forms.TabPage tabMove;
        private System.Windows.Forms.TabPage tabGB;
        private PanelAnalogique panelAnalogiqueIO;
        private PanelAnalogique panelAnalogiqueMove;
        private PanelAnalogique panelAnalogiqueGB;
        private PanelCapteurs panelCapteurs1;
    }
}

