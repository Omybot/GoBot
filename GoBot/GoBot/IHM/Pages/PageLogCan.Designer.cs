namespace GoBot.IHM
{
    partial class PanelLogCan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelLogCan));
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.ctxMnuFrames = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFrameCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHideAllFrames = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHideSameTypeFrames = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHideSameSenderFrames = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHideSameReceiverFrames = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHideSameBoardFrames = new System.Windows.Forms.ToolStripMenuItem();
            this.grpColor = new System.Windows.Forms.GroupBox();
            this.rdoColorNone = new System.Windows.Forms.RadioButton();
            this.rdoColorByReceiver = new System.Windows.Forms.RadioButton();
            this.rdoColorByBoard = new System.Windows.Forms.RadioButton();
            this.rdoColorBySender = new System.Windows.Forms.RadioButton();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.rdoTimeAbsolute = new System.Windows.Forms.RadioButton();
            this.rdoTimeFromStart = new System.Windows.Forms.RadioButton();
            this.rdoTimeFromPrevDisplay = new System.Windows.Forms.RadioButton();
            this.rdoTimeFromPrev = new System.Windows.Forms.RadioButton();
            this.grpMessages = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAllUncheck = new System.Windows.Forms.Button();
            this.btnAllCheck = new System.Windows.Forms.Button();
            this.tabFilters = new System.Windows.Forms.TabControl();
            this.tabPageBoards = new System.Windows.Forms.TabPage();
            this.grpSender = new System.Windows.Forms.GroupBox();
            this.lstSender = new System.Windows.Forms.CheckedListBox();
            this.grpReceiver = new System.Windows.Forms.GroupBox();
            this.lstReceiver = new System.Windows.Forms.CheckedListBox();
            this.tabPageMessages = new System.Windows.Forms.TabPage();
            this.boxScroll = new System.Windows.Forms.CheckBox();
            this.grpReplay = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnReplayAll = new System.Windows.Forms.Button();
            this.btnReplaySelected = new System.Windows.Forms.Button();
            this.grpMonitoring = new System.Windows.Forms.GroupBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.lstFunctions = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.ctxMnuFrames.SuspendLayout();
            this.grpColor.SuspendLayout();
            this.grpTime.SuspendLayout();
            this.grpMessages.SuspendLayout();
            this.tabFilters.SuspendLayout();
            this.tabPageBoards.SuspendLayout();
            this.grpSender.SuspendLayout();
            this.grpReceiver.SuspendLayout();
            this.tabPageMessages.SuspendLayout();
            this.grpReplay.SuspendLayout();
            this.grpMonitoring.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToOrderColumns = true;
            this.dgvLog.AllowUserToResizeRows = false;
            this.dgvLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.ContextMenuStrip = this.ctxMnuFrames;
            this.dgvLog.Location = new System.Drawing.Point(416, 9);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(835, 624);
            this.dgvLog.TabIndex = 1;
            this.dgvLog.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLog_CellMouseDown);
            // 
            // ctxMnuFrames
            // 
            this.ctxMnuFrames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFrameCopy,
            this.mnuHideAllFrames,
            this.mnuHideSameTypeFrames,
            this.mnuHideSameSenderFrames,
            this.mnuHideSameReceiverFrames,
            this.mnuHideSameBoardFrames});
            this.ctxMnuFrames.Name = "contextMenuStripRow";
            this.ctxMnuFrames.Size = new System.Drawing.Size(368, 136);
            // 
            // mnuFrameCopy
            // 
            this.mnuFrameCopy.Name = "mnuFrameCopy";
            this.mnuFrameCopy.Size = new System.Drawing.Size(367, 22);
            this.mnuFrameCopy.Text = "Copier la trame";
            this.mnuFrameCopy.Click += new System.EventHandler(this.mnuFrameCopy_Click);
            // 
            // mnuHideAllFrames
            // 
            this.mnuHideAllFrames.Name = "mnuHideAllFrames";
            this.mnuHideAllFrames.Size = new System.Drawing.Size(367, 22);
            this.mnuHideAllFrames.Text = "Ne plus afficher tous ces messages";
            this.mnuHideAllFrames.Click += new System.EventHandler(this.mnuHideAllFrames_Click);
            // 
            // mnuHideSameTypeFrames
            // 
            this.mnuHideSameTypeFrames.Name = "mnuHideSameTypeFrames";
            this.mnuHideSameTypeFrames.Size = new System.Drawing.Size(367, 22);
            this.mnuHideSameTypeFrames.Text = "Ne plus afficher ce type de messages";
            this.mnuHideSameTypeFrames.Click += new System.EventHandler(this.mnuHideSameTypeFrames_Click);
            // 
            // mnuHideSameSenderFrames
            // 
            this.mnuHideSameSenderFrames.Name = "mnuHideSameSenderFrames";
            this.mnuHideSameSenderFrames.Size = new System.Drawing.Size(367, 22);
            this.mnuHideSameSenderFrames.Text = "Ne plus afficher de messages avec le même expéditeur";
            this.mnuHideSameSenderFrames.Click += new System.EventHandler(this.mnuHideSameSenderFrames_Click);
            // 
            // mnuHideSameReceiverFrames
            // 
            this.mnuHideSameReceiverFrames.Name = "mnuHideSameReceiverFrames";
            this.mnuHideSameReceiverFrames.Size = new System.Drawing.Size(367, 22);
            this.mnuHideSameReceiverFrames.Text = "Ne plus afficher de messages avec le même destinataire";
            this.mnuHideSameReceiverFrames.Click += new System.EventHandler(this.mnuHideSameReceiverFrames_Click);
            // 
            // mnuHideSameBoardFrames
            // 
            this.mnuHideSameBoardFrames.Name = "mnuHideSameBoardFrames";
            this.mnuHideSameBoardFrames.Size = new System.Drawing.Size(367, 22);
            this.mnuHideSameBoardFrames.Text = "Ne plus afficher de messages de cette carte";
            this.mnuHideSameBoardFrames.Click += new System.EventHandler(this.mnuHideSameBoardFrames_Click);
            // 
            // grpColor
            // 
            this.grpColor.Controls.Add(this.rdoColorNone);
            this.grpColor.Controls.Add(this.rdoColorByReceiver);
            this.grpColor.Controls.Add(this.rdoColorByBoard);
            this.grpColor.Controls.Add(this.rdoColorBySender);
            this.grpColor.Location = new System.Drawing.Point(293, 114);
            this.grpColor.Name = "grpColor";
            this.grpColor.Size = new System.Drawing.Size(117, 120);
            this.grpColor.TabIndex = 14;
            this.grpColor.TabStop = false;
            this.grpColor.Text = "Colorer par";
            // 
            // rdoColorNone
            // 
            this.rdoColorNone.AutoSize = true;
            this.rdoColorNone.Location = new System.Drawing.Point(13, 90);
            this.rdoColorNone.Name = "rdoColorNone";
            this.rdoColorNone.Size = new System.Drawing.Size(56, 17);
            this.rdoColorNone.TabIndex = 13;
            this.rdoColorNone.Text = "Aucun";
            this.rdoColorNone.UseVisualStyleBackColor = true;
            // 
            // rdoColorByReceiver
            // 
            this.rdoColorByReceiver.AutoSize = true;
            this.rdoColorByReceiver.Location = new System.Drawing.Point(13, 44);
            this.rdoColorByReceiver.Name = "rdoColorByReceiver";
            this.rdoColorByReceiver.Size = new System.Drawing.Size(81, 17);
            this.rdoColorByReceiver.TabIndex = 12;
            this.rdoColorByReceiver.Text = "Destinataire";
            this.rdoColorByReceiver.UseVisualStyleBackColor = true;
            // 
            // rdoColorByBoard
            // 
            this.rdoColorByBoard.AutoSize = true;
            this.rdoColorByBoard.Location = new System.Drawing.Point(13, 67);
            this.rdoColorByBoard.Name = "rdoColorByBoard";
            this.rdoColorByBoard.Size = new System.Drawing.Size(104, 17);
            this.rdoColorByBoard.TabIndex = 10;
            this.rdoColorByBoard.Text = "Carte concernée";
            this.rdoColorByBoard.UseVisualStyleBackColor = true;
            // 
            // rdoColorBySender
            // 
            this.rdoColorBySender.AutoSize = true;
            this.rdoColorBySender.Checked = true;
            this.rdoColorBySender.Location = new System.Drawing.Point(13, 21);
            this.rdoColorBySender.Name = "rdoColorBySender";
            this.rdoColorBySender.Size = new System.Drawing.Size(75, 17);
            this.rdoColorBySender.TabIndex = 11;
            this.rdoColorBySender.TabStop = true;
            this.rdoColorBySender.Text = "Expéditeur";
            this.rdoColorBySender.UseVisualStyleBackColor = true;
            // 
            // grpTime
            // 
            this.grpTime.Controls.Add(this.rdoTimeAbsolute);
            this.grpTime.Controls.Add(this.rdoTimeFromStart);
            this.grpTime.Controls.Add(this.rdoTimeFromPrevDisplay);
            this.grpTime.Controls.Add(this.rdoTimeFromPrev);
            this.grpTime.Location = new System.Drawing.Point(3, 114);
            this.grpTime.Name = "grpTime";
            this.grpTime.Size = new System.Drawing.Size(284, 120);
            this.grpTime.TabIndex = 15;
            this.grpTime.TabStop = false;
            this.grpTime.Text = "Affichage heure";
            // 
            // rdoTimeAbsolute
            // 
            this.rdoTimeAbsolute.AutoSize = true;
            this.rdoTimeAbsolute.Location = new System.Drawing.Point(13, 90);
            this.rdoTimeAbsolute.Name = "rdoTimeAbsolute";
            this.rdoTimeAbsolute.Size = new System.Drawing.Size(94, 17);
            this.rdoTimeAbsolute.TabIndex = 10;
            this.rdoTimeAbsolute.Text = "Heure absolue";
            this.rdoTimeAbsolute.UseVisualStyleBackColor = true;
            // 
            // rdoTimeFromStart
            // 
            this.rdoTimeFromStart.AutoSize = true;
            this.rdoTimeFromStart.Location = new System.Drawing.Point(13, 67);
            this.rdoTimeFromStart.Name = "rdoTimeFromStart";
            this.rdoTimeFromStart.Size = new System.Drawing.Size(167, 17);
            this.rdoTimeFromStart.TabIndex = 13;
            this.rdoTimeFromStart.Text = "Temps écoulé depuis le début";
            this.rdoTimeFromStart.UseVisualStyleBackColor = true;
            // 
            // rdoTimeFromPrevDisplay
            // 
            this.rdoTimeFromPrevDisplay.AutoSize = true;
            this.rdoTimeFromPrevDisplay.Checked = true;
            this.rdoTimeFromPrevDisplay.Location = new System.Drawing.Point(13, 21);
            this.rdoTimeFromPrevDisplay.Name = "rdoTimeFromPrevDisplay";
            this.rdoTimeFromPrevDisplay.Size = new System.Drawing.Size(268, 17);
            this.rdoTimeFromPrevDisplay.TabIndex = 12;
            this.rdoTimeFromPrevDisplay.TabStop = true;
            this.rdoTimeFromPrevDisplay.Text = "Temps écoulé depuis le message affiché précédent";
            this.rdoTimeFromPrevDisplay.UseVisualStyleBackColor = true;
            // 
            // rdoTimeFromPrev
            // 
            this.rdoTimeFromPrev.AutoSize = true;
            this.rdoTimeFromPrev.Location = new System.Drawing.Point(13, 44);
            this.rdoTimeFromPrev.Name = "rdoTimeFromPrev";
            this.rdoTimeFromPrev.Size = new System.Drawing.Size(233, 17);
            this.rdoTimeFromPrev.TabIndex = 11;
            this.rdoTimeFromPrev.Text = "Temps écoulé depuis le message précédent";
            this.rdoTimeFromPrev.UseVisualStyleBackColor = true;
            // 
            // grpMessages
            // 
            this.grpMessages.Controls.Add(this.btnRefresh);
            this.grpMessages.Controls.Add(this.btnAllUncheck);
            this.grpMessages.Controls.Add(this.btnAllCheck);
            this.grpMessages.Controls.Add(this.tabFilters);
            this.grpMessages.Location = new System.Drawing.Point(3, 240);
            this.grpMessages.Name = "grpMessages";
            this.grpMessages.Size = new System.Drawing.Size(407, 393);
            this.grpMessages.TabIndex = 19;
            this.grpMessages.TabStop = false;
            this.grpMessages.Text = "Filtres sur les messages";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::GoBot.Properties.Resources.Refresh16;
            this.btnRefresh.Location = new System.Drawing.Point(266, 359);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 23);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Actualiser";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAllUncheck
            // 
            this.btnAllUncheck.Image = global::GoBot.Properties.Resources.UncheckAll16;
            this.btnAllUncheck.Location = new System.Drawing.Point(20, 359);
            this.btnAllUncheck.Name = "btnAllUncheck";
            this.btnAllUncheck.Size = new System.Drawing.Size(117, 23);
            this.btnAllUncheck.TabIndex = 27;
            this.btnAllUncheck.Text = "Tout décocher";
            this.btnAllUncheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAllUncheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllUncheck.UseVisualStyleBackColor = true;
            this.btnAllUncheck.Click += new System.EventHandler(this.btnAllUncheck_Click);
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.Image = global::GoBot.Properties.Resources.CheckAll16;
            this.btnAllCheck.Location = new System.Drawing.Point(143, 359);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(117, 23);
            this.btnAllCheck.TabIndex = 26;
            this.btnAllCheck.Text = "Tout cocher";
            this.btnAllCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllCheck.UseVisualStyleBackColor = true;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // tabFilters
            // 
            this.tabFilters.Controls.Add(this.tabPageBoards);
            this.tabFilters.Controls.Add(this.tabPageMessages);
            this.tabFilters.Location = new System.Drawing.Point(13, 19);
            this.tabFilters.Name = "tabFilters";
            this.tabFilters.SelectedIndex = 0;
            this.tabFilters.Size = new System.Drawing.Size(383, 338);
            this.tabFilters.TabIndex = 26;
            // 
            // tabPageBoards
            // 
            this.tabPageBoards.Controls.Add(this.grpSender);
            this.tabPageBoards.Controls.Add(this.grpReceiver);
            this.tabPageBoards.Location = new System.Drawing.Point(4, 22);
            this.tabPageBoards.Name = "tabPageBoards";
            this.tabPageBoards.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBoards.Size = new System.Drawing.Size(375, 312);
            this.tabPageBoards.TabIndex = 0;
            this.tabPageBoards.Text = "Cartes";
            this.tabPageBoards.UseVisualStyleBackColor = true;
            // 
            // grpSender
            // 
            this.grpSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpSender.Controls.Add(this.lstSender);
            this.grpSender.Location = new System.Drawing.Point(6, 6);
            this.grpSender.Name = "grpSender";
            this.grpSender.Size = new System.Drawing.Size(177, 300);
            this.grpSender.TabIndex = 24;
            this.grpSender.TabStop = false;
            this.grpSender.Text = "Expediteur";
            // 
            // lstSender
            // 
            this.lstSender.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSender.CheckOnClick = true;
            this.lstSender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSender.FormattingEnabled = true;
            this.lstSender.Location = new System.Drawing.Point(3, 16);
            this.lstSender.Name = "lstSender";
            this.lstSender.Size = new System.Drawing.Size(171, 281);
            this.lstSender.Sorted = true;
            this.lstSender.TabIndex = 16;
            this.lstSender.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstSender_ItemCheck);
            // 
            // grpReceiver
            // 
            this.grpReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpReceiver.Controls.Add(this.lstReceiver);
            this.grpReceiver.Location = new System.Drawing.Point(192, 6);
            this.grpReceiver.Name = "grpReceiver";
            this.grpReceiver.Size = new System.Drawing.Size(177, 300);
            this.grpReceiver.TabIndex = 25;
            this.grpReceiver.TabStop = false;
            this.grpReceiver.Text = "Destinataire";
            // 
            // lstReceiver
            // 
            this.lstReceiver.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstReceiver.CheckOnClick = true;
            this.lstReceiver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstReceiver.FormattingEnabled = true;
            this.lstReceiver.Location = new System.Drawing.Point(3, 16);
            this.lstReceiver.Name = "lstReceiver";
            this.lstReceiver.Size = new System.Drawing.Size(171, 281);
            this.lstReceiver.Sorted = true;
            this.lstReceiver.TabIndex = 16;
            this.lstReceiver.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstReceiver_ItemCheck);
            // 
            // tabPageMessages
            // 
            this.tabPageMessages.Controls.Add(this.lstFunctions);
            this.tabPageMessages.Location = new System.Drawing.Point(4, 22);
            this.tabPageMessages.Name = "tabPageMessages";
            this.tabPageMessages.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMessages.Size = new System.Drawing.Size(375, 312);
            this.tabPageMessages.TabIndex = 1;
            this.tabPageMessages.Text = "Messages";
            this.tabPageMessages.UseVisualStyleBackColor = true;
            // 
            // boxScroll
            // 
            this.boxScroll.AutoSize = true;
            this.boxScroll.Checked = true;
            this.boxScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxScroll.Location = new System.Drawing.Point(45, 77);
            this.boxScroll.Name = "boxScroll";
            this.boxScroll.Size = new System.Drawing.Size(113, 17);
            this.boxScroll.TabIndex = 23;
            this.boxScroll.Text = "Scroll automatique";
            this.boxScroll.UseVisualStyleBackColor = true;
            // 
            // grpReplay
            // 
            this.grpReplay.Controls.Add(this.btnLoad);
            this.grpReplay.Controls.Add(this.btnReplayAll);
            this.grpReplay.Controls.Add(this.btnReplaySelected);
            this.grpReplay.Location = new System.Drawing.Point(209, 9);
            this.grpReplay.Name = "grpReplay";
            this.grpReplay.Size = new System.Drawing.Size(201, 100);
            this.grpReplay.TabIndex = 24;
            this.grpReplay.TabStop = false;
            this.grpReplay.Text = "Logs";
            // 
            // btnLoad
            // 
            this.btnLoad.Image = global::GoBot.Properties.Resources.Folder16;
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.Location = new System.Drawing.Point(44, 18);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(128, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Charger un log";
            this.btnLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnReplayAll
            // 
            this.btnReplayAll.Image = ((System.Drawing.Image)(resources.GetObject("btnReplayAll.Image")));
            this.btnReplayAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReplayAll.Location = new System.Drawing.Point(44, 44);
            this.btnReplayAll.Name = "btnReplayAll";
            this.btnReplayAll.Size = new System.Drawing.Size(128, 23);
            this.btnReplayAll.TabIndex = 21;
            this.btnReplayAll.Text = "Rejouer tout";
            this.btnReplayAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReplayAll.UseVisualStyleBackColor = true;
            this.btnReplayAll.Click += new System.EventHandler(this.btnReplayAll_Click);
            // 
            // btnReplaySelected
            // 
            this.btnReplaySelected.Image = ((System.Drawing.Image)(resources.GetObject("btnReplaySelected.Image")));
            this.btnReplaySelected.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReplaySelected.Location = new System.Drawing.Point(44, 70);
            this.btnReplaySelected.Name = "btnReplaySelected";
            this.btnReplaySelected.Size = new System.Drawing.Size(128, 23);
            this.btnReplaySelected.TabIndex = 22;
            this.btnReplaySelected.Text = "Rejouer sélection";
            this.btnReplaySelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReplaySelected.UseVisualStyleBackColor = true;
            this.btnReplaySelected.Click += new System.EventHandler(this.btnReplaySelected_Click);
            // 
            // grpMonitoring
            // 
            this.grpMonitoring.Controls.Add(this.btnDisplay);
            this.grpMonitoring.Controls.Add(this.boxScroll);
            this.grpMonitoring.Location = new System.Drawing.Point(3, 9);
            this.grpMonitoring.Name = "grpMonitoring";
            this.grpMonitoring.Size = new System.Drawing.Size(200, 100);
            this.grpMonitoring.TabIndex = 25;
            this.grpMonitoring.TabStop = false;
            this.grpMonitoring.Text = "Surveillance";
            // 
            // btnDisplay
            // 
            this.btnDisplay.Image = global::GoBot.Properties.Resources.GlassStart48;
            this.btnDisplay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisplay.Location = new System.Drawing.Point(13, 18);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(175, 56);
            this.btnDisplay.TabIndex = 20;
            this.btnDisplay.Text = "Lancer la surveillance";
            this.btnDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // lstFunctions
            // 
            this.lstFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFunctions.CheckOnClick = true;
            this.lstFunctions.ColumnWidth = 155;
            this.lstFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFunctions.FormattingEnabled = true;
            this.lstFunctions.Location = new System.Drawing.Point(3, 3);
            this.lstFunctions.Margin = new System.Windows.Forms.Padding(0);
            this.lstFunctions.MultiColumn = true;
            this.lstFunctions.Name = "lstFunctions";
            this.lstFunctions.Size = new System.Drawing.Size(369, 306);
            this.lstFunctions.Sorted = true;
            this.lstFunctions.TabIndex = 16;
            // 
            // PanelLogCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpMonitoring);
            this.Controls.Add(this.grpReplay);
            this.Controls.Add(this.grpMessages);
            this.Controls.Add(this.grpTime);
            this.Controls.Add(this.grpColor);
            this.Controls.Add(this.dgvLog);
            this.Name = "PanelLogCan";
            this.Size = new System.Drawing.Size(1254, 669);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ctxMnuFrames.ResumeLayout(false);
            this.grpColor.ResumeLayout(false);
            this.grpColor.PerformLayout();
            this.grpTime.ResumeLayout(false);
            this.grpTime.PerformLayout();
            this.grpMessages.ResumeLayout(false);
            this.tabFilters.ResumeLayout(false);
            this.tabPageBoards.ResumeLayout(false);
            this.grpSender.ResumeLayout(false);
            this.grpReceiver.ResumeLayout(false);
            this.tabPageMessages.ResumeLayout(false);
            this.grpReplay.ResumeLayout(false);
            this.grpMonitoring.ResumeLayout(false);
            this.grpMonitoring.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.GroupBox grpColor;
        private System.Windows.Forms.RadioButton rdoColorByBoard;
        private System.Windows.Forms.RadioButton rdoColorByReceiver;
        private System.Windows.Forms.RadioButton rdoColorBySender;
        private System.Windows.Forms.RadioButton rdoColorNone;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpTime;
        private System.Windows.Forms.RadioButton rdoTimeFromStart;
        private System.Windows.Forms.RadioButton rdoTimeAbsolute;
        private System.Windows.Forms.RadioButton rdoTimeFromPrevDisplay;
        private System.Windows.Forms.RadioButton rdoTimeFromPrev;
        private System.Windows.Forms.GroupBox grpMessages;
        private System.Windows.Forms.ContextMenuStrip ctxMnuFrames;
        private System.Windows.Forms.ToolStripMenuItem mnuHideSameTypeFrames;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnReplayAll;
        private System.Windows.Forms.Button btnReplaySelected;
        private System.Windows.Forms.CheckBox boxScroll;
        private System.Windows.Forms.GroupBox grpSender;
        private System.Windows.Forms.CheckedListBox lstSender;
        private System.Windows.Forms.CheckedListBox lstReceiver;
        private System.Windows.Forms.GroupBox grpReceiver;
        private System.Windows.Forms.ToolStripMenuItem mnuHideSameSenderFrames;
        private System.Windows.Forms.ToolStripMenuItem mnuHideSameReceiverFrames;
        private System.Windows.Forms.ToolStripMenuItem mnuHideSameBoardFrames;
        private System.Windows.Forms.ToolStripMenuItem mnuHideAllFrames;
        private System.Windows.Forms.ToolStripMenuItem mnuFrameCopy;
        private System.Windows.Forms.TabControl tabFilters;
        private System.Windows.Forms.TabPage tabPageBoards;
        private System.Windows.Forms.TabPage tabPageMessages;
        private System.Windows.Forms.Button btnAllUncheck;
        private System.Windows.Forms.Button btnAllCheck;
        private System.Windows.Forms.GroupBox grpReplay;
        private System.Windows.Forms.GroupBox grpMonitoring;
        private System.Windows.Forms.CheckedListBox lstFunctions;
    }
}
