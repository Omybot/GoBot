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
            this.pnlPower = new GoBot.IHM.Pages.PagePower();
            this.tabConnexions = new System.Windows.Forms.TabPage();
            this.panelEnvoiUdp1 = new GoBot.IHM.Pages.PageEnvoiUdp();
            this.tabAsser = new System.Windows.Forms.TabPage();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.tabControlLogs = new System.Windows.Forms.TabControl();
            this.tabLogUDP = new System.Windows.Forms.TabPage();
            this.pnlLogFrames = new GoBot.IHM.Pages.PageLogUdp();
            this.tabLogsCan = new System.Windows.Forms.TabPage();
            this.pnlLogCan = new GoBot.IHM.Pages.PageLogCan();
            this.tabLogEvent = new System.Windows.Forms.TabPage();
            this.panelLogsEvents = new GoBot.IHM.Pages.PageLogsEvents();
            this.tabThreads = new System.Windows.Forms.TabPage();
            this.panelLogThreads1 = new GoBot.IHM.Pages.PageLogThreads();
            this.tabGestionLog = new System.Windows.Forms.TabPage();
            this.panelGestionLog = new GoBot.IHM.Pages.PageGestionLog();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.panelTable = new GoBot.IHM.Pages.PageTable();
            this.tabRobot = new System.Windows.Forms.TabPage();
            this.panelGrosRobot = new GoBot.IHM.Pages.PageRobot();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCANServos = new System.Windows.Forms.TabPage();
            this.pageServomotors = new GoBot.IHM.Pages.PageServomotors();
            this.tabAsservissement = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabDiagnotic = new System.Windows.Forms.TabPage();
            this.pageDiagnosticMove = new GoBot.IHM.Pages.PageDiagnosticMove();
            this.tabPID = new System.Windows.Forms.TabPage();
            this.pageReglageAsserv = new GoBot.IHM.Pages.PageReglageAsserv();
            this.tabPics = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIO = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabAnalog = new System.Windows.Forms.TabPage();
            this.panelAnalogiqueIO = new GoBot.IHM.PanelAnalogique();
            this.tabNumeric = new System.Windows.Forms.TabPage();
            this.pnlNumericIO = new GoBot.IHM.Pages.PanelBoardNumeric();
            this.tabMove = new System.Windows.Forms.TabPage();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panelAnalogiqueMove = new GoBot.IHM.PanelAnalogique();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.pnlNumericMove = new GoBot.IHM.Pages.PanelBoardNumeric();
            this.tabActionneurs = new System.Windows.Forms.TabPage();
            this.panelGenerics1 = new GoBot.IHM.PanelGenerics();
            this.tabLidar = new System.Windows.Forms.TabPage();
            this.pageLidar = new GoBot.IHM.Pages.PageLidar();
            this.tabPepperl = new System.Windows.Forms.TabPage();
            this.pagePepperl1 = new GoBot.IHM.Pages.PagePepperl();
            this.tabPageStorage = new System.Windows.Forms.TabPage();
            this.pageStorage1 = new GoBot.IHM.Pages.PageStorage();
            this.tabPanda = new System.Windows.Forms.TabPage();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.tabControlPanda = new System.Windows.Forms.TabControl();
            this.tabPandaMatch = new System.Windows.Forms.TabPage();
            this.pnlMatch = new GoBot.IHM.Pages.PagePandaMatch();
            this.tabPandaLidar = new System.Windows.Forms.TabPage();
            this.pagePandaLidar = new GoBot.IHM.Pages.PagePandaLidar();
            this.tabPandaMove = new System.Windows.Forms.TabPage();
            this.pnlPandaMove = new GoBot.IHM.Pages.PagePandaMove();
            this.tabPandaActuators = new System.Windows.Forms.TabPage();
            this.pagePandaActuators1 = new GoBot.IHM.Pages.PagePandaActuators();
            this.tabControl6 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelChargeCPU1 = new GoBot.IHM.Pages.PageDiagnosticMove();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelReglageAsserv = new GoBot.IHM.Pages.PageReglageAsserv();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFenetre = new System.Windows.Forms.Button();
            this.switchBoutonSimu = new Composants.SwitchButton();
            this.panelConnexions = new GoBot.IHM.PanelConnexions();
            this.potarControl1 = new GoBot.IHM.PotarControl();
            this.panelAlimentation1 = new GoBot.IHM.Pages.PagePower();
            this.btnDebug = new System.Windows.Forms.Button();
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
            this.tabRobot.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabCANServos.SuspendLayout();
            this.tabAsservissement.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabDiagnotic.SuspendLayout();
            this.tabPID.SuspendLayout();
            this.tabPics.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabIO.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabAnalog.SuspendLayout();
            this.tabNumeric.SuspendLayout();
            this.tabMove.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabActionneurs.SuspendLayout();
            this.tabLidar.SuspendLayout();
            this.tabPepperl.SuspendLayout();
            this.tabPageStorage.SuspendLayout();
            this.tabPanda.SuspendLayout();
            this.tabControlPanda.SuspendLayout();
            this.tabPandaMatch.SuspendLayout();
            this.tabPandaLidar.SuspendLayout();
            this.tabPandaMove.SuspendLayout();
            this.tabPandaActuators.SuspendLayout();
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
            this.tabLogsCan.Size = new System.Drawing.Size(1286, 680);
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
            this.pnlLogCan.Size = new System.Drawing.Size(1280, 674);
            this.pnlLogCan.TabIndex = 0;
            // 
            // tabLogEvent
            // 
            this.tabLogEvent.Controls.Add(this.panelLogsEvents);
            this.tabLogEvent.Location = new System.Drawing.Point(4, 22);
            this.tabLogEvent.Name = "tabLogEvent";
            this.tabLogEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogEvent.Size = new System.Drawing.Size(1286, 680);
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
            this.panelLogsEvents.Size = new System.Drawing.Size(1280, 674);
            this.panelLogsEvents.TabIndex = 1;
            // 
            // tabThreads
            // 
            this.tabThreads.Controls.Add(this.panelLogThreads1);
            this.tabThreads.Location = new System.Drawing.Point(4, 22);
            this.tabThreads.Name = "tabThreads";
            this.tabThreads.Size = new System.Drawing.Size(1286, 680);
            this.tabThreads.TabIndex = 3;
            this.tabThreads.Text = "Threading";
            this.tabThreads.UseVisualStyleBackColor = true;
            // 
            // panelLogThreads1
            // 
            this.panelLogThreads1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogThreads1.Location = new System.Drawing.Point(0, 0);
            this.panelLogThreads1.Name = "panelLogThreads1";
            this.panelLogThreads1.Size = new System.Drawing.Size(1286, 680);
            this.panelLogThreads1.TabIndex = 0;
            // 
            // tabGestionLog
            // 
            this.tabGestionLog.Controls.Add(this.panelGestionLog);
            this.tabGestionLog.Location = new System.Drawing.Point(4, 22);
            this.tabGestionLog.Name = "tabGestionLog";
            this.tabGestionLog.Size = new System.Drawing.Size(1286, 680);
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
            this.panelGestionLog.Size = new System.Drawing.Size(1286, 680);
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
            // tabRobot
            // 
            this.tabRobot.Controls.Add(this.panelGrosRobot);
            this.tabRobot.Location = new System.Drawing.Point(4, 22);
            this.tabRobot.Name = "tabRobot";
            this.tabRobot.Padding = new System.Windows.Forms.Padding(3);
            this.tabRobot.Size = new System.Drawing.Size(1300, 712);
            this.tabRobot.TabIndex = 0;
            this.tabRobot.Text = "Robot";
            this.tabRobot.UseVisualStyleBackColor = true;
            // 
            // panelGrosRobot
            // 
            this.panelGrosRobot.BackColor = System.Drawing.Color.White;
            this.panelGrosRobot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrosRobot.Location = new System.Drawing.Point(3, 3);
            this.panelGrosRobot.Name = "panelGrosRobot";
            this.panelGrosRobot.Size = new System.Drawing.Size(1294, 706);
            this.panelGrosRobot.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabTable);
            this.tabControl.Controls.Add(this.tabRobot);
            this.tabControl.Controls.Add(this.tabLogs);
            this.tabControl.Controls.Add(this.tabCANServos);
            this.tabControl.Controls.Add(this.tabAsservissement);
            this.tabControl.Controls.Add(this.tabConnexions);
            this.tabControl.Controls.Add(this.tabAlimentation);
            this.tabControl.Controls.Add(this.tabPics);
            this.tabControl.Controls.Add(this.tabActionneurs);
            this.tabControl.Controls.Add(this.tabLidar);
            this.tabControl.Controls.Add(this.tabPepperl);
            this.tabControl.Controls.Add(this.tabPageStorage);
            this.tabControl.Controls.Add(this.tabPanda);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1308, 738);
            this.tabControl.TabIndex = 25;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
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
            // pageDiagnosticMove
            // 
            this.pageDiagnosticMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDiagnosticMove.Location = new System.Drawing.Point(3, 3);
            this.pageDiagnosticMove.Name = "pageDiagnosticMove";
            this.pageDiagnosticMove.Size = new System.Drawing.Size(1280, 674);
            this.pageDiagnosticMove.TabIndex = 0;
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
            // pageReglageAsserv
            // 
            this.pageReglageAsserv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageReglageAsserv.Location = new System.Drawing.Point(3, 3);
            this.pageReglageAsserv.Name = "pageReglageAsserv";
            this.pageReglageAsserv.Size = new System.Drawing.Size(1280, 674);
            this.pageReglageAsserv.TabIndex = 0;
            // 
            // tabPics
            // 
            this.tabPics.Controls.Add(this.tabControl1);
            this.tabPics.Location = new System.Drawing.Point(4, 22);
            this.tabPics.Name = "tabPics";
            this.tabPics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPics.Size = new System.Drawing.Size(1300, 712);
            this.tabPics.TabIndex = 24;
            this.tabPics.Text = "Microcontrôleurs";
            this.tabPics.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabIO);
            this.tabControl1.Controls.Add(this.tabMove);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1294, 706);
            this.tabControl1.TabIndex = 1;
            // 
            // tabIO
            // 
            this.tabIO.Controls.Add(this.tabControl4);
            this.tabIO.Location = new System.Drawing.Point(4, 22);
            this.tabIO.Name = "tabIO";
            this.tabIO.Padding = new System.Windows.Forms.Padding(3);
            this.tabIO.Size = new System.Drawing.Size(1286, 680);
            this.tabIO.TabIndex = 0;
            this.tabIO.Text = "RecIO";
            this.tabIO.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabAnalog);
            this.tabControl4.Controls.Add(this.tabNumeric);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(3, 3);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(1280, 674);
            this.tabControl4.TabIndex = 1;
            // 
            // tabAnalog
            // 
            this.tabAnalog.Controls.Add(this.panelAnalogiqueIO);
            this.tabAnalog.Location = new System.Drawing.Point(4, 22);
            this.tabAnalog.Name = "tabAnalog";
            this.tabAnalog.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalog.Size = new System.Drawing.Size(1272, 648);
            this.tabAnalog.TabIndex = 0;
            this.tabAnalog.Text = "Ports analogiques";
            this.tabAnalog.UseVisualStyleBackColor = true;
            // 
            // panelAnalogiqueIO
            // 
            this.panelAnalogiqueIO.Carte = GoBot.Board.RecIO;
            this.panelAnalogiqueIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalogiqueIO.Location = new System.Drawing.Point(3, 3);
            this.panelAnalogiqueIO.Name = "panelAnalogiqueIO";
            this.panelAnalogiqueIO.Size = new System.Drawing.Size(1266, 642);
            this.panelAnalogiqueIO.TabIndex = 0;
            // 
            // tabNumeric
            // 
            this.tabNumeric.Controls.Add(this.pnlNumericIO);
            this.tabNumeric.Location = new System.Drawing.Point(4, 22);
            this.tabNumeric.Name = "tabNumeric";
            this.tabNumeric.Padding = new System.Windows.Forms.Padding(3);
            this.tabNumeric.Size = new System.Drawing.Size(1272, 648);
            this.tabNumeric.TabIndex = 1;
            this.tabNumeric.Text = "Ports numériques";
            this.tabNumeric.UseVisualStyleBackColor = true;
            // 
            // pnlNumericIO
            // 
            this.pnlNumericIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNumericIO.Location = new System.Drawing.Point(3, 3);
            this.pnlNumericIO.Name = "pnlNumericIO";
            this.pnlNumericIO.Size = new System.Drawing.Size(1266, 642);
            this.pnlNumericIO.TabIndex = 1;
            // 
            // tabMove
            // 
            this.tabMove.Controls.Add(this.tabControl5);
            this.tabMove.Location = new System.Drawing.Point(4, 22);
            this.tabMove.Name = "tabMove";
            this.tabMove.Padding = new System.Windows.Forms.Padding(3);
            this.tabMove.Size = new System.Drawing.Size(1286, 680);
            this.tabMove.TabIndex = 1;
            this.tabMove.Text = "RecMove";
            this.tabMove.UseVisualStyleBackColor = true;
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage6);
            this.tabControl5.Controls.Add(this.tabPage7);
            this.tabControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl5.Location = new System.Drawing.Point(3, 3);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(1280, 674);
            this.tabControl5.TabIndex = 2;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panelAnalogiqueMove);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1272, 648);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Ports analogiques";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panelAnalogiqueMove
            // 
            this.panelAnalogiqueMove.Carte = GoBot.Board.RecMove;
            this.panelAnalogiqueMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalogiqueMove.Location = new System.Drawing.Point(3, 3);
            this.panelAnalogiqueMove.Name = "panelAnalogiqueMove";
            this.panelAnalogiqueMove.Size = new System.Drawing.Size(1266, 642);
            this.panelAnalogiqueMove.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.pnlNumericMove);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1272, 648);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Ports numériques";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // pnlNumericMove
            // 
            this.pnlNumericMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNumericMove.Location = new System.Drawing.Point(3, 3);
            this.pnlNumericMove.Name = "pnlNumericMove";
            this.pnlNumericMove.Size = new System.Drawing.Size(1266, 642);
            this.pnlNumericMove.TabIndex = 1;
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
            // tabLidar
            // 
            this.tabLidar.Controls.Add(this.btnDebug);
            this.tabLidar.Controls.Add(this.pageLidar);
            this.tabLidar.Location = new System.Drawing.Point(4, 22);
            this.tabLidar.Name = "tabLidar";
            this.tabLidar.Padding = new System.Windows.Forms.Padding(3);
            this.tabLidar.Size = new System.Drawing.Size(1300, 712);
            this.tabLidar.TabIndex = 28;
            this.tabLidar.Text = "Lidar";
            this.tabLidar.UseVisualStyleBackColor = true;
            // 
            // pageLidar
            // 
            this.pageLidar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageLidar.Location = new System.Drawing.Point(3, 3);
            this.pageLidar.Name = "pageLidar";
            this.pageLidar.Size = new System.Drawing.Size(1294, 706);
            this.pageLidar.TabIndex = 0;
            // 
            // tabPepperl
            // 
            this.tabPepperl.Controls.Add(this.pagePepperl1);
            this.tabPepperl.Location = new System.Drawing.Point(4, 22);
            this.tabPepperl.Name = "tabPepperl";
            this.tabPepperl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPepperl.Size = new System.Drawing.Size(1300, 712);
            this.tabPepperl.TabIndex = 31;
            this.tabPepperl.Text = "R2000";
            this.tabPepperl.UseVisualStyleBackColor = true;
            // 
            // pagePepperl1
            // 
            this.pagePepperl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePepperl1.Location = new System.Drawing.Point(3, 3);
            this.pagePepperl1.Name = "pagePepperl1";
            this.pagePepperl1.Size = new System.Drawing.Size(1294, 706);
            this.pagePepperl1.TabIndex = 0;
            // 
            // tabPageStorage
            // 
            this.tabPageStorage.Controls.Add(this.pageStorage1);
            this.tabPageStorage.Location = new System.Drawing.Point(4, 22);
            this.tabPageStorage.Name = "tabPageStorage";
            this.tabPageStorage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStorage.Size = new System.Drawing.Size(1300, 712);
            this.tabPageStorage.TabIndex = 33;
            this.tabPageStorage.Text = "Stockage";
            this.tabPageStorage.UseVisualStyleBackColor = true;
            // 
            // pageStorage1
            // 
            this.pageStorage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageStorage1.Location = new System.Drawing.Point(8, 6);
            this.pageStorage1.Name = "pageStorage1";
            this.pageStorage1.Size = new System.Drawing.Size(1022, 598);
            this.pageStorage1.TabIndex = 0;
            // 
            // tabPanda
            // 
            this.tabPanda.Controls.Add(this.btnNextPage);
            this.tabPanda.Controls.Add(this.tabControlPanda);
            this.tabPanda.Location = new System.Drawing.Point(4, 22);
            this.tabPanda.Name = "tabPanda";
            this.tabPanda.Size = new System.Drawing.Size(1300, 712);
            this.tabPanda.TabIndex = 32;
            this.tabPanda.Text = "LattePanda";
            this.tabPanda.UseVisualStyleBackColor = true;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Image = global::GoBot.Properties.Resources.NextPage48;
            this.btnNextPage.Location = new System.Drawing.Point(953, 29);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(80, 80);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // tabControlPanda
            // 
            this.tabControlPanda.Controls.Add(this.tabPandaMatch);
            this.tabControlPanda.Controls.Add(this.tabPandaLidar);
            this.tabControlPanda.Controls.Add(this.tabPandaMove);
            this.tabControlPanda.Controls.Add(this.tabPandaActuators);
            this.tabControlPanda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanda.Location = new System.Drawing.Point(0, 0);
            this.tabControlPanda.Name = "tabControlPanda";
            this.tabControlPanda.SelectedIndex = 0;
            this.tabControlPanda.Size = new System.Drawing.Size(1300, 712);
            this.tabControlPanda.TabIndex = 1;
            this.tabControlPanda.SelectedIndexChanged += new System.EventHandler(this.tabControlPanda_SelectedIndexChanged);
            // 
            // tabPandaMatch
            // 
            this.tabPandaMatch.BackColor = System.Drawing.Color.Transparent;
            this.tabPandaMatch.Controls.Add(this.pnlMatch);
            this.tabPandaMatch.Location = new System.Drawing.Point(4, 22);
            this.tabPandaMatch.Name = "tabPandaMatch";
            this.tabPandaMatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPandaMatch.Size = new System.Drawing.Size(1292, 686);
            this.tabPandaMatch.TabIndex = 0;
            this.tabPandaMatch.Text = "Match";
            // 
            // pnlMatch
            // 
            this.pnlMatch.BackColor = System.Drawing.Color.Black;
            this.pnlMatch.Location = new System.Drawing.Point(6, 6);
            this.pnlMatch.Name = "pnlMatch";
            this.pnlMatch.Size = new System.Drawing.Size(1024, 600);
            this.pnlMatch.TabIndex = 0;
            // 
            // tabPandaLidar
            // 
            this.tabPandaLidar.Controls.Add(this.pagePandaLidar);
            this.tabPandaLidar.Location = new System.Drawing.Point(4, 22);
            this.tabPandaLidar.Name = "tabPandaLidar";
            this.tabPandaLidar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPandaLidar.Size = new System.Drawing.Size(1292, 686);
            this.tabPandaLidar.TabIndex = 1;
            this.tabPandaLidar.Text = "Lidar";
            this.tabPandaLidar.UseVisualStyleBackColor = true;
            // 
            // pagePandaLidar
            // 
            this.pagePandaLidar.BackColor = System.Drawing.Color.Black;
            this.pagePandaLidar.Location = new System.Drawing.Point(6, 6);
            this.pagePandaLidar.Name = "pagePandaLidar";
            this.pagePandaLidar.Size = new System.Drawing.Size(1024, 600);
            this.pagePandaLidar.TabIndex = 0;
            // 
            // tabPandaMove
            // 
            this.tabPandaMove.Controls.Add(this.pnlPandaMove);
            this.tabPandaMove.Location = new System.Drawing.Point(4, 22);
            this.tabPandaMove.Name = "tabPandaMove";
            this.tabPandaMove.Padding = new System.Windows.Forms.Padding(3);
            this.tabPandaMove.Size = new System.Drawing.Size(1292, 686);
            this.tabPandaMove.TabIndex = 2;
            this.tabPandaMove.Text = "Déplacement";
            this.tabPandaMove.UseVisualStyleBackColor = true;
            // 
            // pnlPandaMove
            // 
            this.pnlPandaMove.BackColor = System.Drawing.Color.Black;
            this.pnlPandaMove.Location = new System.Drawing.Point(6, 6);
            this.pnlPandaMove.Name = "pnlPandaMove";
            this.pnlPandaMove.Size = new System.Drawing.Size(1024, 600);
            this.pnlPandaMove.TabIndex = 0;
            // 
            // tabPandaActuators
            // 
            this.tabPandaActuators.Controls.Add(this.pagePandaActuators1);
            this.tabPandaActuators.Location = new System.Drawing.Point(4, 22);
            this.tabPandaActuators.Name = "tabPandaActuators";
            this.tabPandaActuators.Padding = new System.Windows.Forms.Padding(3);
            this.tabPandaActuators.Size = new System.Drawing.Size(1292, 686);
            this.tabPandaActuators.TabIndex = 3;
            this.tabPandaActuators.Text = "Actionneurs";
            this.tabPandaActuators.UseVisualStyleBackColor = true;
            // 
            // pagePandaActuators1
            // 
            this.pagePandaActuators1.BackColor = System.Drawing.Color.Black;
            this.pagePandaActuators1.Location = new System.Drawing.Point(6, 6);
            this.pagePandaActuators1.Name = "pagePandaActuators1";
            this.pagePandaActuators1.Size = new System.Drawing.Size(1024, 600);
            this.pagePandaActuators1.TabIndex = 0;
            // 
            // tabControl6
            // 
            this.tabControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl6.Location = new System.Drawing.Point(3, 3);
            this.tabControl6.Name = "tabControl6";
            this.tabControl6.SelectedIndex = 0;
            this.tabControl6.Size = new System.Drawing.Size(1280, 674);
            this.tabControl6.TabIndex = 3;
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
            // panelChargeCPU1
            // 
            this.panelChargeCPU1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChargeCPU1.Location = new System.Drawing.Point(3, 3);
            this.panelChargeCPU1.Name = "panelChargeCPU1";
            this.panelChargeCPU1.Size = new System.Drawing.Size(1280, 674);
            this.panelChargeCPU1.TabIndex = 0;
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
            // panelReglageAsserv
            // 
            this.panelReglageAsserv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReglageAsserv.Location = new System.Drawing.Point(3, 3);
            this.panelReglageAsserv.Name = "panelReglageAsserv";
            this.panelReglageAsserv.Size = new System.Drawing.Size(1280, 674);
            this.panelReglageAsserv.TabIndex = 1;
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
            // potarControl1
            // 
            this.potarControl1.Location = new System.Drawing.Point(6, 18);
            this.potarControl1.Name = "potarControl1";
            this.potarControl1.Size = new System.Drawing.Size(385, 98);
            this.potarControl1.TabIndex = 5;
            // 
            // panelAlimentation1
            // 
            this.panelAlimentation1.Location = new System.Drawing.Point(6, 6);
            this.panelAlimentation1.Name = "panelAlimentation1";
            this.panelAlimentation1.Size = new System.Drawing.Size(1025, 501);
            this.panelAlimentation1.TabIndex = 0;
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(8, 260);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(95, 23);
            this.btnDebug.TabIndex = 2;
            this.btnDebug.Text = "Debug LIDAR";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
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
            this.MaximizeBox = false;
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
            this.tabRobot.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabCANServos.ResumeLayout(false);
            this.tabAsservissement.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabDiagnotic.ResumeLayout(false);
            this.tabPID.ResumeLayout(false);
            this.tabPics.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabIO.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabAnalog.ResumeLayout(false);
            this.tabNumeric.ResumeLayout(false);
            this.tabMove.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabActionneurs.ResumeLayout(false);
            this.tabActionneurs.PerformLayout();
            this.tabLidar.ResumeLayout(false);
            this.tabPepperl.ResumeLayout(false);
            this.tabPageStorage.ResumeLayout(false);
            this.tabPanda.ResumeLayout(false);
            this.tabControlPanda.ResumeLayout(false);
            this.tabPandaMatch.ResumeLayout(false);
            this.tabPandaLidar.ResumeLayout(false);
            this.tabPandaMove.ResumeLayout(false);
            this.tabPandaActuators.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabConnexions;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.TabPage tabLogUDP;
        private System.Windows.Forms.TabPage tabLogEvent;
        private System.Windows.Forms.TabPage tabGestionLog;
        private System.Windows.Forms.TabPage tabTable;
        private System.Windows.Forms.TabPage tabRobot;
        private System.Windows.Forms.TabPage tabPics;
        private System.Windows.Forms.TabPage tabIO;
        private System.Windows.Forms.TabPage tabMove;
        private System.Windows.Forms.TabPage tabActionneurs;
        private System.Windows.Forms.TabPage tabLidar;
        private System.Windows.Forms.TabPage tabThreads;
        private System.Windows.Forms.TabPage tabLogsCan;
        private System.Windows.Forms.TabPage tabDiagnotic;
        private System.Windows.Forms.TabPage tabPID;
        private System.Windows.Forms.TabPage tabAsservissement;
        private System.Windows.Forms.TabPage tabCANServos;
        private System.Windows.Forms.TabPage tabAnalog;
        private System.Windows.Forms.TabPage tabNumeric;
        private System.Windows.Forms.TabPage tabPepperl;
        private System.Windows.Forms.TabPage tabPanda;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private IHM.Pages.PageEnvoiUdp panelEnvoiUdp1;
        private System.Windows.Forms.TabPage tabAsser;
        private IHM.Pages.PageDiagnosticMove panelChargeCPU1;
        private System.Windows.Forms.TabControl tabControlLogs;
        private IHM.Pages.PageLogUdp pnlLogFrames;
        private IHM.Pages.PageLogsEvents panelLogsEvents;
        private IHM.Pages.PageGestionLog panelGestionLog;
        private IHM.Pages.PageTable panelTable;
        private IHM.Pages.PageRobot panelGrosRobot;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabControl tabControl6;
        private PanelAnalogique panelAnalogiqueIO;
        private PanelAnalogique panelAnalogiqueMove;
        private PanelGenerics panelGenerics1;
        private PotarControl potarControl1;
        private IHM.Pages.PageLidar pageLidar;
        private IHM.Pages.PageLogThreads panelLogThreads1;
        private IHM.Pages.PageLogCan pnlLogCan;
        private IHM.Pages.PagePower panelAlimentation1;
        private IHM.Pages.PageServomotors pageServomotors;
        private IHM.Pages.PagePower pnlPower;
        private IHM.Pages.PageReglageAsserv panelReglageAsserv;
        private IHM.Pages.PageDiagnosticMove pageDiagnosticMove;
        private IHM.Pages.PageReglageAsserv pageReglageAsserv;
        private IHM.Pages.PanelBoardNumeric pnlNumericIO;
        private IHM.Pages.PanelBoardNumeric pnlNumericMove;
        private IHM.Pages.PagePepperl pagePepperl1;
        private IHM.Pages.PagePandaMatch pnlMatch;
        private IHM.Pages.PagePandaMove pnlPandaMove;
        private System.Windows.Forms.TabPage tabPageStorage;
        private IHM.Pages.PageStorage pageStorage1;
        private System.Windows.Forms.TabControl tabControlPanda;
        private System.Windows.Forms.TabPage tabPandaMatch;
        private System.Windows.Forms.TabPage tabPandaLidar;
        private IHM.Pages.PagePandaLidar pagePandaLidar;
        private System.Windows.Forms.TabPage tabPandaMove;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.TabPage tabPandaActuators;
        private IHM.Pages.PagePandaActuators pagePandaActuators1;
        private System.Windows.Forms.Button btnDebug;
    }
}

