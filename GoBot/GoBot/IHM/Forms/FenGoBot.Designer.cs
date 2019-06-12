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
            this.pnlPower = new GoBot.IHM.PagePower();
            this.tabConnexions = new System.Windows.Forms.TabPage();
            this.panelEnvoiUdp1 = new GoBot.IHM.PageEnvoiUdp();
            this.tabAsser = new System.Windows.Forms.TabPage();
            this.panelChargeCPU1 = new GoBot.IHM.PageDiagnosticMove();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.tabControlLogs = new System.Windows.Forms.TabControl();
            this.tabLogUDP = new System.Windows.Forms.TabPage();
            this.pnlLogFrames = new GoBot.IHM.PageLogUdp();
            this.tabLogsCan = new System.Windows.Forms.TabPage();
            this.pnlLogCan = new GoBot.IHM.PageLogCan();
            this.tabLogEvent = new System.Windows.Forms.TabPage();
            this.panelLogsEvents = new GoBot.IHM.PageLogsEvents();
            this.tabThreads = new System.Windows.Forms.TabPage();
            this.panelLogThreads1 = new GoBot.IHM.PageLogThreads();
            this.tabGestionLog = new System.Windows.Forms.TabPage();
            this.panelGestionLog = new GoBot.IHM.PageGestionLog();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.panelTable = new GoBot.IHM.PageTable();
            this.tabGrosRobot = new System.Windows.Forms.TabPage();
            this.panelGrosRobot = new GoBot.IHM.PageGrosRobot();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCANServos = new System.Windows.Forms.TabPage();
            this.pageServomotors = new GoBot.IHM.Pages.PageServomotors();
            this.tabAsservissement = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabDiagnotic = new System.Windows.Forms.TabPage();
            this.tabPID = new System.Windows.Forms.TabPage();
            this.tabPortsAnalogiques = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIO = new System.Windows.Forms.TabPage();
            this.panelAnalogiqueIO = new GoBot.IHM.PanelAnalogique();
            this.tabMove = new System.Windows.Forms.TabPage();
            this.panelAnalogiqueMove = new GoBot.IHM.PanelAnalogique();
            this.tabGB = new System.Windows.Forms.TabPage();
            this.panelAnalogiqueGB = new GoBot.IHM.PanelAnalogique();
            this.tabPortsNumeriques = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabIONumeric = new System.Windows.Forms.TabPage();
            this.panelBoardNumericIO = new GoBot.IHM.PanelBoardNumeric();
            this.tabMoveNumeric = new System.Windows.Forms.TabPage();
            this.panelBoardNumericMove = new GoBot.IHM.PanelBoardNumeric();
            this.tabGBNumeric = new System.Windows.Forms.TabPage();
            this.panelBoardNumericGB = new GoBot.IHM.PanelBoardNumeric();
            this.tabRecGoBot = new System.Windows.Forms.TabPage();
            this.grpServoCodeur = new System.Windows.Forms.GroupBox();
            this.potarControl1 = new GoBot.IHM.PotarControl();
            this.grpCapteurs = new System.Windows.Forms.GroupBox();
            this.panelCapteurs1 = new GoBot.IHM.PanelCapteurs();
            this.grpRecGB = new System.Windows.Forms.GroupBox();
            this.panelRecGoBot1 = new GoBot.IHM.PanelRecGoBot();
            this.tabActionneurs = new System.Windows.Forms.TabPage();
            this.panelGenerics1 = new GoBot.IHM.PanelGenerics();
            this.tabHokuyo = new System.Windows.Forms.TabPage();
            this.panelHokuyo1 = new GoBot.IHM.PageHokuyo();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFenetre = new System.Windows.Forms.Button();
            this.switchBoutonSimu = new Composants.SwitchButton();
            this.panelConnexions = new GoBot.IHM.PanelConnexions();
            this.panelAlimentation1 = new GoBot.IHM.PagePower();
            this.panelReglageAsserv = new GoBot.IHM.PageReglageAsserv();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pageDiagnosticMove = new GoBot.IHM.PageDiagnosticMove();
            this.pageReglageAsserv = new GoBot.IHM.PageReglageAsserv();
            this.tabAlimentation.SuspendLayout();
            this.tabConnexions.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabControlLogs.SuspendLayout();
            this.tabLogUDP.SuspendLayout();
            this.tabLogsCan.SuspendLayout();
            this.tabLogEvent.SuspendLayout();
            this.tabThreads.SuspendLayout();
            this.tabGestionLog.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tabGrosRobot.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabCANServos.SuspendLayout();
            this.tabAsservissement.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabDiagnotic.SuspendLayout();
            this.tabPID.SuspendLayout();
            this.tabPortsAnalogiques.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabIO.SuspendLayout();
            this.tabMove.SuspendLayout();
            this.tabGB.SuspendLayout();
            this.tabPortsNumeriques.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabIONumeric.SuspendLayout();
            this.tabMoveNumeric.SuspendLayout();
            this.tabGBNumeric.SuspendLayout();
            this.tabRecGoBot.SuspendLayout();
            this.grpServoCodeur.SuspendLayout();
            this.grpCapteurs.SuspendLayout();
            this.grpRecGB.SuspendLayout();
            this.tabActionneurs.SuspendLayout();
            this.tabHokuyo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.tabAlimentation.Controls.Add(this.pnlPower);
            this.tabAlimentation.Location = new System.Drawing.Point(4, 22);
            this.tabAlimentation.Name = "tabAlimentation";
            this.tabAlimentation.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlimentation.Size = new System.Drawing.Size(1300, 712);
            this.tabAlimentation.TabIndex = 21;
            this.tabAlimentation.Text = "Alimentation";
            this.tabAlimentation.UseVisualStyleBackColor = true;
            // 
            // pnlPower
            // 
            this.pnlPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPower.Location = new System.Drawing.Point(3, 3);
            this.pnlPower.Name = "pnlPower";
            this.pnlPower.Size = new System.Drawing.Size(1294, 706);
            this.pnlPower.TabIndex = 0;
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
            // tabAsser
            // 
            this.tabAsser.Location = new System.Drawing.Point(4, 22);
            this.tabAsser.Name = "tabAsser";
            this.tabAsser.Padding = new System.Windows.Forms.Padding(3);
            this.tabAsser.Size = new System.Drawing.Size(1300, 712);
            this.tabAsser.TabIndex = 16;
            this.tabAsser.Text = "Asservissement";
            this.tabAsser.UseVisualStyleBackColor = true;
            // 
            // panelChargeCPU1
            // 
            this.panelChargeCPU1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChargeCPU1.Location = new System.Drawing.Point(3, 3);
            this.panelChargeCPU1.Name = "panelChargeCPU1";
            this.panelChargeCPU1.Size = new System.Drawing.Size(1280, 674);
            this.panelChargeCPU1.TabIndex = 0;
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.tabControlLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(1300, 712);
            this.tabLogs.TabIndex = 22;
            this.tabLogs.Text = "Monitoring";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // tabControlLogs
            // 
            this.tabControlLogs.Controls.Add(this.tabLogUDP);
            this.tabControlLogs.Controls.Add(this.tabLogsCan);
            this.tabControlLogs.Controls.Add(this.tabLogEvent);
            this.tabControlLogs.Controls.Add(this.tabThreads);
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
            this.tabLogUDP.Controls.Add(this.pnlLogFrames);
            this.tabLogUDP.Location = new System.Drawing.Point(4, 22);
            this.tabLogUDP.Name = "tabLogUDP";
            this.tabLogUDP.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogUDP.Size = new System.Drawing.Size(1286, 680);
            this.tabLogUDP.TabIndex = 0;
            this.tabLogUDP.Text = "Logs UDP";
            this.tabLogUDP.UseVisualStyleBackColor = true;
            // 
            // pnlLogFrames
            // 
            this.pnlLogFrames.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogFrames.Location = new System.Drawing.Point(3, 3);
            this.pnlLogFrames.Name = "pnlLogFrames";
            this.pnlLogFrames.Size = new System.Drawing.Size(1280, 674);
            this.pnlLogFrames.TabIndex = 1;
            // 
            // tabLogsCan
            // 
            this.tabLogsCan.Controls.Add(this.pnlLogCan);
            this.tabLogsCan.Location = new System.Drawing.Point(4, 22);
            this.tabLogsCan.Name = "tabLogsCan";
            this.tabLogsCan.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogsCan.Size = new System.Drawing.Size(178, 42);
            this.tabLogsCan.TabIndex = 4;
            this.tabLogsCan.Text = "Logs CAN";
            this.tabLogsCan.UseVisualStyleBackColor = true;
            // 
            // pnlLogCan
            // 
            this.pnlLogCan.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogCan.Location = new System.Drawing.Point(3, 3);
            this.pnlLogCan.Name = "pnlLogCan";
            this.pnlLogCan.Size = new System.Drawing.Size(172, 36);
            this.pnlLogCan.TabIndex = 0;
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
            // tabThreads
            // 
            this.tabThreads.Controls.Add(this.panelLogThreads1);
            this.tabThreads.Location = new System.Drawing.Point(4, 22);
            this.tabThreads.Name = "tabThreads";
            this.tabThreads.Size = new System.Drawing.Size(178, 42);
            this.tabThreads.TabIndex = 3;
            this.tabThreads.Text = "Threading";
            this.tabThreads.UseVisualStyleBackColor = true;
            // 
            // panelLogThreads1
            // 
            this.panelLogThreads1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogThreads1.Location = new System.Drawing.Point(0, 0);
            this.panelLogThreads1.Name = "panelLogThreads1";
            this.panelLogThreads1.Size = new System.Drawing.Size(178, 42);
            this.panelLogThreads1.TabIndex = 0;
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
            this.tabControl.Controls.Add(this.tabLogs);
            this.tabControl.Controls.Add(this.tabCANServos);
            this.tabControl.Controls.Add(this.tabAsservissement);
            this.tabControl.Controls.Add(this.tabConnexions);
            this.tabControl.Controls.Add(this.tabAlimentation);
            this.tabControl.Controls.Add(this.tabPortsAnalogiques);
            this.tabControl.Controls.Add(this.tabPortsNumeriques);
            this.tabControl.Controls.Add(this.tabRecGoBot);
            this.tabControl.Controls.Add(this.tabActionneurs);
            this.tabControl.Controls.Add(this.tabHokuyo);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1308, 738);
            this.tabControl.TabIndex = 25;
            // 
            // tabCANServos
            // 
            this.tabCANServos.Controls.Add(this.pageServomotors);
            this.tabCANServos.Location = new System.Drawing.Point(4, 22);
            this.tabCANServos.Name = "tabCANServos";
            this.tabCANServos.Padding = new System.Windows.Forms.Padding(3);
            this.tabCANServos.Size = new System.Drawing.Size(1300, 712);
            this.tabCANServos.TabIndex = 30;
            this.tabCANServos.Text = "Servos CAN";
            this.tabCANServos.UseVisualStyleBackColor = true;
            // 
            // pageServomotors
            // 
            this.pageServomotors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageServomotors.Location = new System.Drawing.Point(3, 3);
            this.pageServomotors.Name = "pageServomotors";
            this.pageServomotors.Size = new System.Drawing.Size(1294, 706);
            this.pageServomotors.TabIndex = 0;
            // 
            // tabAsservissement
            // 
            this.tabAsservissement.Controls.Add(this.tabControl3);
            this.tabAsservissement.Location = new System.Drawing.Point(4, 22);
            this.tabAsservissement.Name = "tabAsservissement";
            this.tabAsservissement.Padding = new System.Windows.Forms.Padding(3);
            this.tabAsservissement.Size = new System.Drawing.Size(1300, 712);
            this.tabAsservissement.TabIndex = 16;
            this.tabAsservissement.Text = "Asservissement";
            this.tabAsservissement.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabDiagnotic);
            this.tabControl3.Controls.Add(this.tabPID);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(3, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1294, 706);
            this.tabControl3.TabIndex = 1;
            // 
            // tabDiagnotic
            // 
            this.tabDiagnotic.Controls.Add(this.pageDiagnosticMove);
            this.tabDiagnotic.Location = new System.Drawing.Point(4, 22);
            this.tabDiagnotic.Name = "tabDiagnotic";
            this.tabDiagnotic.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiagnotic.Size = new System.Drawing.Size(1286, 680);
            this.tabDiagnotic.TabIndex = 0;
            this.tabDiagnotic.Text = "Diagnotic";
            this.tabDiagnotic.UseVisualStyleBackColor = true;
            // 
            // tabPID
            // 
            this.tabPID.Controls.Add(this.pageReglageAsserv);
            this.tabPID.Location = new System.Drawing.Point(4, 22);
            this.tabPID.Name = "tabPID";
            this.tabPID.Padding = new System.Windows.Forms.Padding(3);
            this.tabPID.Size = new System.Drawing.Size(1286, 680);
            this.tabPID.TabIndex = 1;
            this.tabPID.Text = "Réglage PID";
            this.tabPID.UseVisualStyleBackColor = true;
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
            this.panelAnalogiqueIO.Carte = GoBot.Board.RecIO;
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
            this.panelAnalogiqueMove.Carte = GoBot.Board.RecMove;
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
            this.panelAnalogiqueGB.Carte = GoBot.Board.RecGB;
            this.panelAnalogiqueGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalogiqueGB.Location = new System.Drawing.Point(3, 3);
            this.panelAnalogiqueGB.Name = "panelAnalogiqueGB";
            this.panelAnalogiqueGB.Size = new System.Drawing.Size(1270, 668);
            this.panelAnalogiqueGB.TabIndex = 0;
            // 
            // tabPortsNumeriques
            // 
            this.tabPortsNumeriques.Controls.Add(this.tabControl2);
            this.tabPortsNumeriques.Location = new System.Drawing.Point(4, 22);
            this.tabPortsNumeriques.Name = "tabPortsNumeriques";
            this.tabPortsNumeriques.Size = new System.Drawing.Size(1300, 712);
            this.tabPortsNumeriques.TabIndex = 29;
            this.tabPortsNumeriques.Text = "Ports numériques";
            this.tabPortsNumeriques.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabIONumeric);
            this.tabControl2.Controls.Add(this.tabMoveNumeric);
            this.tabControl2.Controls.Add(this.tabGBNumeric);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1300, 712);
            this.tabControl2.TabIndex = 3;
            // 
            // tabIONumeric
            // 
            this.tabIONumeric.Controls.Add(this.panelBoardNumericIO);
            this.tabIONumeric.Location = new System.Drawing.Point(4, 22);
            this.tabIONumeric.Name = "tabIONumeric";
            this.tabIONumeric.Padding = new System.Windows.Forms.Padding(3);
            this.tabIONumeric.Size = new System.Drawing.Size(1292, 686);
            this.tabIONumeric.TabIndex = 1;
            this.tabIONumeric.Text = "RecIO";
            this.tabIONumeric.UseVisualStyleBackColor = true;
            // 
            // panelBoardNumericIO
            // 
            this.panelBoardNumericIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoardNumericIO.Location = new System.Drawing.Point(3, 3);
            this.panelBoardNumericIO.Name = "panelBoardNumericIO";
            this.panelBoardNumericIO.Size = new System.Drawing.Size(1286, 680);
            this.panelBoardNumericIO.TabIndex = 1;
            // 
            // tabMoveNumeric
            // 
            this.tabMoveNumeric.Controls.Add(this.panelBoardNumericMove);
            this.tabMoveNumeric.Location = new System.Drawing.Point(4, 22);
            this.tabMoveNumeric.Name = "tabMoveNumeric";
            this.tabMoveNumeric.Padding = new System.Windows.Forms.Padding(3);
            this.tabMoveNumeric.Size = new System.Drawing.Size(184, 48);
            this.tabMoveNumeric.TabIndex = 0;
            this.tabMoveNumeric.Text = "RecMove";
            this.tabMoveNumeric.UseVisualStyleBackColor = true;
            // 
            // panelBoardNumericMove
            // 
            this.panelBoardNumericMove.Board = GoBot.Board.RecMove;
            this.panelBoardNumericMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoardNumericMove.Location = new System.Drawing.Point(3, 3);
            this.panelBoardNumericMove.Name = "panelBoardNumericMove";
            this.panelBoardNumericMove.Size = new System.Drawing.Size(178, 42);
            this.panelBoardNumericMove.TabIndex = 1;
            // 
            // tabGBNumeric
            // 
            this.tabGBNumeric.Controls.Add(this.panelBoardNumericGB);
            this.tabGBNumeric.Location = new System.Drawing.Point(4, 22);
            this.tabGBNumeric.Name = "tabGBNumeric";
            this.tabGBNumeric.Padding = new System.Windows.Forms.Padding(3);
            this.tabGBNumeric.Size = new System.Drawing.Size(184, 48);
            this.tabGBNumeric.TabIndex = 2;
            this.tabGBNumeric.Text = "RecGoBot";
            this.tabGBNumeric.UseVisualStyleBackColor = true;
            // 
            // panelBoardNumericGB
            // 
            this.panelBoardNumericGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoardNumericGB.Location = new System.Drawing.Point(3, 3);
            this.panelBoardNumericGB.Name = "panelBoardNumericGB";
            this.panelBoardNumericGB.Size = new System.Drawing.Size(178, 42);
            this.panelBoardNumericGB.TabIndex = 1;
            // 
            // tabRecGoBot
            // 
            this.tabRecGoBot.Controls.Add(this.grpServoCodeur);
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
            // grpServoCodeur
            // 
            this.grpServoCodeur.Controls.Add(this.potarControl1);
            this.grpServoCodeur.Location = new System.Drawing.Point(250, 6);
            this.grpServoCodeur.Name = "grpServoCodeur";
            this.grpServoCodeur.Size = new System.Drawing.Size(400, 122);
            this.grpServoCodeur.TabIndex = 8;
            this.grpServoCodeur.TabStop = false;
            this.grpServoCodeur.Text = "Pilotage de servo avec codeur";
            // 
            // potarControl1
            // 
            this.potarControl1.Location = new System.Drawing.Point(6, 18);
            this.potarControl1.Name = "potarControl1";
            this.potarControl1.Size = new System.Drawing.Size(385, 98);
            this.potarControl1.TabIndex = 5;
            // 
            // grpCapteurs
            // 
            this.grpCapteurs.Controls.Add(this.panelCapteurs1);
            this.grpCapteurs.Location = new System.Drawing.Point(656, 6);
            this.grpCapteurs.Name = "grpCapteurs";
            this.grpCapteurs.Size = new System.Drawing.Size(273, 197);
            this.grpCapteurs.TabIndex = 4;
            this.grpCapteurs.TabStop = false;
            this.grpCapteurs.Text = "Capteurs";
            // 
            // panelCapteurs1
            // 
            this.panelCapteurs1.Location = new System.Drawing.Point(6, 19);
            this.panelCapteurs1.Name = "panelCapteurs1";
            this.panelCapteurs1.Size = new System.Drawing.Size(261, 172);
            this.panelCapteurs1.TabIndex = 1;
            // 
            // grpRecGB
            // 
            this.grpRecGB.Controls.Add(this.panelRecGoBot1);
            this.grpRecGB.Location = new System.Drawing.Point(6, 6);
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
            // tabActionneurs
            // 
            this.tabActionneurs.Controls.Add(this.panelGenerics1);
            this.tabActionneurs.Location = new System.Drawing.Point(4, 22);
            this.tabActionneurs.Name = "tabActionneurs";
            this.tabActionneurs.Padding = new System.Windows.Forms.Padding(3);
            this.tabActionneurs.Size = new System.Drawing.Size(1300, 712);
            this.tabActionneurs.TabIndex = 27;
            this.tabActionneurs.Text = "Actionneurs";
            this.tabActionneurs.UseVisualStyleBackColor = true;
            // 
            // panelGenerics1
            // 
            this.panelGenerics1.AutoSize = true;
            this.panelGenerics1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGenerics1.Location = new System.Drawing.Point(3, 3);
            this.panelGenerics1.Name = "panelGenerics1";
            this.panelGenerics1.Size = new System.Drawing.Size(1294, 706);
            this.panelGenerics1.TabIndex = 0;
            // 
            // tabHokuyo
            // 
            this.tabHokuyo.Controls.Add(this.panelHokuyo1);
            this.tabHokuyo.Location = new System.Drawing.Point(4, 22);
            this.tabHokuyo.Name = "tabHokuyo";
            this.tabHokuyo.Padding = new System.Windows.Forms.Padding(3);
            this.tabHokuyo.Size = new System.Drawing.Size(1300, 712);
            this.tabHokuyo.TabIndex = 28;
            this.tabHokuyo.Text = "Hokuyo";
            this.tabHokuyo.UseVisualStyleBackColor = true;
            // 
            // panelHokuyo1
            // 
            this.panelHokuyo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHokuyo1.Location = new System.Drawing.Point(3, 3);
            this.panelHokuyo1.Name = "panelHokuyo1";
            this.panelHokuyo1.Size = new System.Drawing.Size(1294, 706);
            this.panelHokuyo1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::GoBot.Properties.Resources.Close16;
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
            this.btnFenetre.Image = global::GoBot.Properties.Resources.Windows16;
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
            this.switchBoutonSimu.AutoSize = true;
            this.switchBoutonSimu.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonSimu.Location = new System.Drawing.Point(1208, 742);
            this.switchBoutonSimu.MaximumSize = new System.Drawing.Size(35, 15);
            this.switchBoutonSimu.MinimumSize = new System.Drawing.Size(35, 15);
            this.switchBoutonSimu.Mirrored = true;
            this.switchBoutonSimu.Name = "switchBoutonSimu";
            this.switchBoutonSimu.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonSimu.TabIndex = 73;
            this.switchBoutonSimu.Value = false;
            this.switchBoutonSimu.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.switchBoutonSimu_ValueChanged);
            // 
            // panelConnexions
            // 
            this.panelConnexions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelConnexions.BackColor = System.Drawing.Color.White;
            this.panelConnexions.Location = new System.Drawing.Point(0, 735);
            this.panelConnexions.Name = "panelConnexions";
            this.panelConnexions.Size = new System.Drawing.Size(1202, 27);
            this.panelConnexions.TabIndex = 74;
            // 
            // panelAlimentation1
            // 
            this.panelAlimentation1.Location = new System.Drawing.Point(6, 6);
            this.panelAlimentation1.Name = "panelAlimentation1";
            this.panelAlimentation1.Size = new System.Drawing.Size(1025, 501);
            this.panelAlimentation1.TabIndex = 0;
            // 
            // panelReglageAsserv
            // 
            this.panelReglageAsserv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReglageAsserv.Location = new System.Drawing.Point(3, 3);
            this.panelReglageAsserv.Name = "panelReglageAsserv";
            this.panelReglageAsserv.Size = new System.Drawing.Size(1280, 674);
            this.panelReglageAsserv.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelChargeCPU1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1286, 680);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabDiagnotic";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelReglageAsserv);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1286, 680);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pageDiagnosticMove
            // 
            this.pageDiagnosticMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDiagnosticMove.Location = new System.Drawing.Point(3, 3);
            this.pageDiagnosticMove.Name = "pageDiagnosticMove";
            this.pageDiagnosticMove.Size = new System.Drawing.Size(1280, 674);
            this.pageDiagnosticMove.TabIndex = 0;
            // 
            // pageReglageAsserv
            // 
            this.pageReglageAsserv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageReglageAsserv.Location = new System.Drawing.Point(3, 3);
            this.pageReglageAsserv.Name = "pageReglageAsserv";
            this.pageReglageAsserv.Size = new System.Drawing.Size(1280, 674);
            this.pageReglageAsserv.TabIndex = 0;
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
            this.Load += new System.EventHandler(this.FenGoBot_Load);
            this.tabAlimentation.ResumeLayout(false);
            this.tabConnexions.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabControlLogs.ResumeLayout(false);
            this.tabLogUDP.ResumeLayout(false);
            this.tabLogsCan.ResumeLayout(false);
            this.tabLogEvent.ResumeLayout(false);
            this.tabThreads.ResumeLayout(false);
            this.tabGestionLog.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabGrosRobot.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabCANServos.ResumeLayout(false);
            this.tabAsservissement.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabDiagnotic.ResumeLayout(false);
            this.tabPID.ResumeLayout(false);
            this.tabPortsAnalogiques.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabIO.ResumeLayout(false);
            this.tabMove.ResumeLayout(false);
            this.tabGB.ResumeLayout(false);
            this.tabPortsNumeriques.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabIONumeric.ResumeLayout(false);
            this.tabMoveNumeric.ResumeLayout(false);
            this.tabGBNumeric.ResumeLayout(false);
            this.tabRecGoBot.ResumeLayout(false);
            this.grpServoCodeur.ResumeLayout(false);
            this.grpCapteurs.ResumeLayout(false);
            this.grpRecGB.ResumeLayout(false);
            this.tabActionneurs.ResumeLayout(false);
            this.tabActionneurs.PerformLayout();
            this.tabHokuyo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSimulation;
        private Composants.SwitchButton switchBoutonSimu;
        private PanelConnexions panelConnexions;
        private System.Windows.Forms.Button btnFenetre;
        private System.Windows.Forms.TabPage tabAlimentation;
        private PagePower pnlPower;
        private System.Windows.Forms.TabPage tabConnexions;
        private PageEnvoiUdp panelEnvoiUdp1;
        private System.Windows.Forms.TabPage tabAsser;
        private PageDiagnosticMove panelChargeCPU1;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.TabControl tabControlLogs;
        private System.Windows.Forms.TabPage tabLogUDP;
        private PageLogUdp pnlLogFrames;
        private System.Windows.Forms.TabPage tabLogEvent;
        private PageLogsEvents panelLogsEvents;
        private System.Windows.Forms.TabPage tabGestionLog;
        private PageGestionLog panelGestionLog;
        private System.Windows.Forms.TabPage tabTable;
        private PageTable panelTable;
        private System.Windows.Forms.TabPage tabGrosRobot;
        private PageGrosRobot panelGrosRobot;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPortsAnalogiques;
        private System.Windows.Forms.TabPage tabRecGoBot;
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
        private System.Windows.Forms.TabPage tabActionneurs;
        private PanelGenerics panelGenerics1;
        private PotarControl potarControl1;
        private System.Windows.Forms.TabPage tabHokuyo;
        private PageHokuyo panelHokuyo1;
        private System.Windows.Forms.TabPage tabPortsNumeriques;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabIONumeric;
        private System.Windows.Forms.TabPage tabMoveNumeric;
        private System.Windows.Forms.TabPage tabGBNumeric;
        private PanelBoardNumeric panelBoardNumericMove;
        private PanelBoardNumeric panelBoardNumericGB;
        private PanelBoardNumeric panelBoardNumericIO;
        private System.Windows.Forms.TabPage tabThreads;
        private PageLogThreads panelLogThreads1;
        private System.Windows.Forms.GroupBox grpServoCodeur;
        private System.Windows.Forms.TabPage tabLogsCan;
        private PageLogCan pnlLogCan;
        private System.Windows.Forms.TabPage tabCANServos;
        private PagePower panelAlimentation1;
        private IHM.Pages.PageServomotors pageServomotors;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabDiagnotic;
        private System.Windows.Forms.TabPage tabPID;
        private PageReglageAsserv panelReglageAsserv;
        private System.Windows.Forms.TabPage tabAsservissement;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private PageDiagnosticMove pageDiagnosticMove;
        private PageReglageAsserv pageReglageAsserv;
    }
}

