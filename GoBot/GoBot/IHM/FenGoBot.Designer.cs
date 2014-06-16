﻿using GoBot.IHM;
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
            this.switchBoutonSimu = new Composants.SwitchBouton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFenetre = new System.Windows.Forms.Button();
            this.tabAlimentation = new System.Windows.Forms.TabPage();
            this.tabServomoteurs = new System.Windows.Forms.TabPage();
            this.tabConnexions = new System.Windows.Forms.TabPage();
            this.tabDiagnosticRecMove = new System.Windows.Forms.TabPage();
            this.tabReglagePID = new System.Windows.Forms.TabPage();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.tabControlLogs = new System.Windows.Forms.TabControl();
            this.tabLogUDP = new System.Windows.Forms.TabPage();
            this.tabLogEvent = new System.Windows.Forms.TabPage();
            this.tabGestionLog = new System.Windows.Forms.TabPage();
            this.tabCamera = new System.Windows.Forms.TabPage();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.tabBalises = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPilotage = new System.Windows.Forms.TabPage();
            this.tabInclinaison = new System.Windows.Forms.TabPage();
            this.tabDiagnostic = new System.Windows.Forms.TabPage();
            this.tabLeds = new System.Windows.Forms.TabPage();
            this.tabMatch = new System.Windows.Forms.TabPage();
            this.tabPetitRobot = new System.Windows.Forms.TabPage();
            this.tabGrosRobot = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConstantes = new System.Windows.Forms.TabPage();
            this.panelGrosRobot = new GoBot.IHM.PanelGrosRobot();
            this.panelPetitRobot = new GoBot.IHM.PanelPetitRobot();
            this.panelMatch = new GoBot.IHM.PanelMatch();
            this.panelBalise1 = new GoBot.IHM.PanelBalise();
            this.panelBalise3 = new GoBot.IHM.PanelBalise();
            this.panelBalise2 = new GoBot.IHM.PanelBalise();
            this.panelBaliseInclinaison3 = new GoBot.IHM.PanelBaliseInclinaison();
            this.panelBaliseInclinaison2 = new GoBot.IHM.PanelBaliseInclinaison();
            this.panelBaliseInclinaison1 = new GoBot.IHM.PanelBaliseInclinaison();
            this.panelDiagnosticBalise3 = new GoBot.IHM.PanelBaliseDiagnostic();
            this.panelDiagnosticBalise2 = new GoBot.IHM.PanelBaliseDiagnostic();
            this.panelDiagnosticBalise1 = new GoBot.IHM.PanelBaliseDiagnostic();
            this.panelImagesBalises = new GoBot.IHM.PanelBalisesImages();
            this.panelTable = new GoBot.IHM.PanelTable();
            this.panelCamera = new GoBot.IHM.PanelCamera();
            this.panelLogTrames = new GoBot.IHM.PanelLogsTrames();
            this.panelLogsEvents = new GoBot.IHM.PanelLogsEvents();
            this.panelGestionLog = new GoBot.IHM.PanelGestionLog();
            this.panelReglageAsserv = new GoBot.IHM.PanelReglageAsserv();
            this.panelChargeCPU1 = new GoBot.IHM.PanelDiagnosticMove();
            this.panelEnvoiUdp1 = new GoBot.IHM.PanelEnvoiUdp();
            this.panelTestServos1 = new GoBot.IHM.PanelTestServos();
            this.panelAlimentation1 = new GoBot.IHM.PanelAlimentation();
            this.panelConstantes = new GoBot.IHM.PanelConstantes();
            this.panelConnexions = new GoBot.IHM.PanelConnexions();
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
            this.tabBalises.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPilotage.SuspendLayout();
            this.tabInclinaison.SuspendLayout();
            this.tabDiagnostic.SuspendLayout();
            this.tabLeds.SuspendLayout();
            this.tabMatch.SuspendLayout();
            this.tabPetitRobot.SuspendLayout();
            this.tabGrosRobot.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabConstantes.SuspendLayout();
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
            this.btnFenetre.Click += new System.EventHandler(this.buttonFenetre_Click);
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
            // tabServomoteurs
            // 
            this.tabServomoteurs.Controls.Add(this.panelTestServos1);
            this.tabServomoteurs.Location = new System.Drawing.Point(4, 22);
            this.tabServomoteurs.Name = "tabServomoteurs";
            this.tabServomoteurs.Padding = new System.Windows.Forms.Padding(3);
            this.tabServomoteurs.Size = new System.Drawing.Size(1300, 712);
            this.tabServomoteurs.TabIndex = 20;
            this.tabServomoteurs.Text = "Servomoteurs";
            this.tabServomoteurs.UseVisualStyleBackColor = true;
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
            // tabBalises
            // 
            this.tabBalises.Controls.Add(this.tabControl1);
            this.tabBalises.Location = new System.Drawing.Point(4, 22);
            this.tabBalises.Name = "tabBalises";
            this.tabBalises.Padding = new System.Windows.Forms.Padding(3);
            this.tabBalises.Size = new System.Drawing.Size(1300, 712);
            this.tabBalises.TabIndex = 6;
            this.tabBalises.Text = "Balises";
            this.tabBalises.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPilotage);
            this.tabControl1.Controls.Add(this.tabInclinaison);
            this.tabControl1.Controls.Add(this.tabDiagnostic);
            this.tabControl1.Controls.Add(this.tabLeds);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1294, 706);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPilotage
            // 
            this.tabPilotage.Controls.Add(this.panelBalise1);
            this.tabPilotage.Controls.Add(this.panelBalise3);
            this.tabPilotage.Controls.Add(this.panelBalise2);
            this.tabPilotage.Location = new System.Drawing.Point(4, 22);
            this.tabPilotage.Name = "tabPilotage";
            this.tabPilotage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPilotage.Size = new System.Drawing.Size(1286, 680);
            this.tabPilotage.TabIndex = 0;
            this.tabPilotage.Text = "Pilotage";
            this.tabPilotage.UseVisualStyleBackColor = true;
            // 
            // tabInclinaison
            // 
            this.tabInclinaison.Controls.Add(this.panelBaliseInclinaison3);
            this.tabInclinaison.Controls.Add(this.panelBaliseInclinaison2);
            this.tabInclinaison.Controls.Add(this.panelBaliseInclinaison1);
            this.tabInclinaison.Location = new System.Drawing.Point(4, 22);
            this.tabInclinaison.Name = "tabInclinaison";
            this.tabInclinaison.Size = new System.Drawing.Size(1286, 680);
            this.tabInclinaison.TabIndex = 3;
            this.tabInclinaison.Text = "Inclinaison";
            this.tabInclinaison.UseVisualStyleBackColor = true;
            // 
            // tabDiagnostic
            // 
            this.tabDiagnostic.Controls.Add(this.panelDiagnosticBalise3);
            this.tabDiagnostic.Controls.Add(this.panelDiagnosticBalise2);
            this.tabDiagnostic.Controls.Add(this.panelDiagnosticBalise1);
            this.tabDiagnostic.Location = new System.Drawing.Point(4, 22);
            this.tabDiagnostic.Name = "tabDiagnostic";
            this.tabDiagnostic.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiagnostic.Size = new System.Drawing.Size(1286, 680);
            this.tabDiagnostic.TabIndex = 1;
            this.tabDiagnostic.Text = "Diagnostic";
            this.tabDiagnostic.UseVisualStyleBackColor = true;
            // 
            // tabLeds
            // 
            this.tabLeds.Controls.Add(this.panelImagesBalises);
            this.tabLeds.Location = new System.Drawing.Point(4, 22);
            this.tabLeds.Name = "tabLeds";
            this.tabLeds.Padding = new System.Windows.Forms.Padding(3);
            this.tabLeds.Size = new System.Drawing.Size(1286, 680);
            this.tabLeds.TabIndex = 2;
            this.tabLeds.Text = "Leds";
            this.tabLeds.UseVisualStyleBackColor = true;
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
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabGrosRobot);
            this.tabControl.Controls.Add(this.tabPetitRobot);
            this.tabControl.Controls.Add(this.tabMatch);
            this.tabControl.Controls.Add(this.tabBalises);
            this.tabControl.Controls.Add(this.tabTable);
            this.tabControl.Controls.Add(this.tabCamera);
            this.tabControl.Controls.Add(this.tabLogs);
            this.tabControl.Controls.Add(this.tabReglagePID);
            this.tabControl.Controls.Add(this.tabDiagnosticRecMove);
            this.tabControl.Controls.Add(this.tabConnexions);
            this.tabControl.Controls.Add(this.tabServomoteurs);
            this.tabControl.Controls.Add(this.tabAlimentation);
            this.tabControl.Controls.Add(this.tabConstantes);
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
            // panelPetitRobot
            // 
            this.panelPetitRobot.BackColor = System.Drawing.Color.Transparent;
            this.panelPetitRobot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPetitRobot.Location = new System.Drawing.Point(0, 0);
            this.panelPetitRobot.Name = "panelPetitRobot";
            this.panelPetitRobot.Size = new System.Drawing.Size(1300, 712);
            this.panelPetitRobot.TabIndex = 0;
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
            // panelBalise1
            // 
            this.panelBalise1.BackColor = System.Drawing.Color.Transparent;
            this.panelBalise1.Balise = null;
            this.panelBalise1.Location = new System.Drawing.Point(6, 6);
            this.panelBalise1.Name = "panelBalise1";
            this.panelBalise1.Size = new System.Drawing.Size(333, 604);
            this.panelBalise1.TabIndex = 0;
            // 
            // panelBalise3
            // 
            this.panelBalise3.BackColor = System.Drawing.Color.Transparent;
            this.panelBalise3.Balise = null;
            this.panelBalise3.Location = new System.Drawing.Point(684, 6);
            this.panelBalise3.Name = "panelBalise3";
            this.panelBalise3.Size = new System.Drawing.Size(333, 604);
            this.panelBalise3.TabIndex = 2;
            // 
            // panelBalise2
            // 
            this.panelBalise2.BackColor = System.Drawing.Color.Transparent;
            this.panelBalise2.Balise = null;
            this.panelBalise2.Location = new System.Drawing.Point(345, 6);
            this.panelBalise2.Name = "panelBalise2";
            this.panelBalise2.Size = new System.Drawing.Size(333, 604);
            this.panelBalise2.TabIndex = 1;
            // 
            // panelBaliseInclinaison3
            // 
            this.panelBaliseInclinaison3.BackColor = System.Drawing.Color.Transparent;
            this.panelBaliseInclinaison3.Balise = null;
            this.panelBaliseInclinaison3.Location = new System.Drawing.Point(684, 6);
            this.panelBaliseInclinaison3.Name = "panelBaliseInclinaison3";
            this.panelBaliseInclinaison3.Size = new System.Drawing.Size(333, 604);
            this.panelBaliseInclinaison3.TabIndex = 2;
            // 
            // panelBaliseInclinaison2
            // 
            this.panelBaliseInclinaison2.BackColor = System.Drawing.Color.Transparent;
            this.panelBaliseInclinaison2.Balise = null;
            this.panelBaliseInclinaison2.Location = new System.Drawing.Point(345, 6);
            this.panelBaliseInclinaison2.Name = "panelBaliseInclinaison2";
            this.panelBaliseInclinaison2.Size = new System.Drawing.Size(333, 604);
            this.panelBaliseInclinaison2.TabIndex = 1;
            // 
            // panelBaliseInclinaison1
            // 
            this.panelBaliseInclinaison1.BackColor = System.Drawing.Color.Transparent;
            this.panelBaliseInclinaison1.Balise = null;
            this.panelBaliseInclinaison1.Location = new System.Drawing.Point(6, 6);
            this.panelBaliseInclinaison1.Name = "panelBaliseInclinaison1";
            this.panelBaliseInclinaison1.Size = new System.Drawing.Size(333, 604);
            this.panelBaliseInclinaison1.TabIndex = 0;
            // 
            // panelDiagnosticBalise3
            // 
            this.panelDiagnosticBalise3.BackColor = System.Drawing.Color.Transparent;
            this.panelDiagnosticBalise3.Balise = null;
            this.panelDiagnosticBalise3.Location = new System.Drawing.Point(684, 6);
            this.panelDiagnosticBalise3.Name = "panelDiagnosticBalise3";
            this.panelDiagnosticBalise3.Size = new System.Drawing.Size(333, 604);
            this.panelDiagnosticBalise3.TabIndex = 5;
            // 
            // panelDiagnosticBalise2
            // 
            this.panelDiagnosticBalise2.BackColor = System.Drawing.Color.Transparent;
            this.panelDiagnosticBalise2.Balise = null;
            this.panelDiagnosticBalise2.Location = new System.Drawing.Point(345, 6);
            this.panelDiagnosticBalise2.Name = "panelDiagnosticBalise2";
            this.panelDiagnosticBalise2.Size = new System.Drawing.Size(333, 604);
            this.panelDiagnosticBalise2.TabIndex = 4;
            // 
            // panelDiagnosticBalise1
            // 
            this.panelDiagnosticBalise1.BackColor = System.Drawing.Color.Transparent;
            this.panelDiagnosticBalise1.Balise = null;
            this.panelDiagnosticBalise1.Location = new System.Drawing.Point(6, 6);
            this.panelDiagnosticBalise1.Name = "panelDiagnosticBalise1";
            this.panelDiagnosticBalise1.Size = new System.Drawing.Size(333, 604);
            this.panelDiagnosticBalise1.TabIndex = 3;
            // 
            // panelImagesBalises
            // 
            this.panelImagesBalises.BackColor = System.Drawing.Color.Transparent;
            this.panelImagesBalises.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImagesBalises.Location = new System.Drawing.Point(3, 3);
            this.panelImagesBalises.Name = "panelImagesBalises";
            this.panelImagesBalises.Size = new System.Drawing.Size(1280, 674);
            this.panelImagesBalises.TabIndex = 1;
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
            // panelCamera
            // 
            this.panelCamera.ContinuerCamera = true;
            this.panelCamera.Location = new System.Drawing.Point(3, 3);
            this.panelCamera.Name = "panelCamera";
            this.panelCamera.Size = new System.Drawing.Size(1005, 501);
            this.panelCamera.TabIndex = 0;
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
            // panelLogsEvents
            // 
            this.panelLogsEvents.BackColor = System.Drawing.Color.Transparent;
            this.panelLogsEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogsEvents.Location = new System.Drawing.Point(3, 3);
            this.panelLogsEvents.Name = "panelLogsEvents";
            this.panelLogsEvents.Size = new System.Drawing.Size(1280, 674);
            this.panelLogsEvents.TabIndex = 1;
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
            // panelReglageAsserv
            // 
            this.panelReglageAsserv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReglageAsserv.Location = new System.Drawing.Point(3, 3);
            this.panelReglageAsserv.Name = "panelReglageAsserv";
            this.panelReglageAsserv.Size = new System.Drawing.Size(1294, 706);
            this.panelReglageAsserv.TabIndex = 0;
            // 
            // panelChargeCPU1
            // 
            this.panelChargeCPU1.Location = new System.Drawing.Point(3, 3);
            this.panelChargeCPU1.Name = "panelChargeCPU1";
            this.panelChargeCPU1.Size = new System.Drawing.Size(1133, 615);
            this.panelChargeCPU1.TabIndex = 0;
            // 
            // panelEnvoiUdp1
            // 
            this.panelEnvoiUdp1.BackColor = System.Drawing.Color.White;
            this.panelEnvoiUdp1.Location = new System.Drawing.Point(8, 6);
            this.panelEnvoiUdp1.Name = "panelEnvoiUdp1";
            this.panelEnvoiUdp1.Size = new System.Drawing.Size(850, 509);
            this.panelEnvoiUdp1.TabIndex = 0;
            // 
            // panelTestServos1
            // 
            this.panelTestServos1.Location = new System.Drawing.Point(8, 6);
            this.panelTestServos1.Name = "panelTestServos1";
            this.panelTestServos1.Size = new System.Drawing.Size(1202, 561);
            this.panelTestServos1.TabIndex = 0;
            // 
            // panelAlimentation1
            // 
            this.panelAlimentation1.Location = new System.Drawing.Point(6, 6);
            this.panelAlimentation1.Name = "panelAlimentation1";
            this.panelAlimentation1.Size = new System.Drawing.Size(1025, 501);
            this.panelAlimentation1.TabIndex = 0;
            // 
            // panelConstantes
            // 
            this.panelConstantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConstantes.Location = new System.Drawing.Point(3, 3);
            this.panelConstantes.Name = "panelConstantes";
            this.panelConstantes.Size = new System.Drawing.Size(1294, 706);
            this.panelConstantes.TabIndex = 0;
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
            this.tabBalises.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPilotage.ResumeLayout(false);
            this.tabInclinaison.ResumeLayout(false);
            this.tabDiagnostic.ResumeLayout(false);
            this.tabLeds.ResumeLayout(false);
            this.tabMatch.ResumeLayout(false);
            this.tabPetitRobot.ResumeLayout(false);
            this.tabGrosRobot.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabConstantes.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabBalises;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPilotage;
        private PanelBalise panelBalise1;
        private PanelBalise panelBalise3;
        private PanelBalise panelBalise2;
        private System.Windows.Forms.TabPage tabInclinaison;
        private PanelBaliseInclinaison panelBaliseInclinaison3;
        private PanelBaliseInclinaison panelBaliseInclinaison2;
        private PanelBaliseInclinaison panelBaliseInclinaison1;
        private System.Windows.Forms.TabPage tabDiagnostic;
        private PanelBaliseDiagnostic panelDiagnosticBalise3;
        private PanelBaliseDiagnostic panelDiagnosticBalise2;
        private PanelBaliseDiagnostic panelDiagnosticBalise1;
        private System.Windows.Forms.TabPage tabLeds;
        private PanelBalisesImages panelImagesBalises;
        private System.Windows.Forms.TabPage tabMatch;
        private PanelMatch panelMatch;
        private System.Windows.Forms.TabPage tabPetitRobot;
        private PanelPetitRobot panelPetitRobot;
        private System.Windows.Forms.TabPage tabGrosRobot;
        private PanelGrosRobot panelGrosRobot;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConstantes;
        private PanelConstantes panelConstantes;
    }
}

