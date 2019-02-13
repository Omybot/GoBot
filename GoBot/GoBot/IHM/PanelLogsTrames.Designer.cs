namespace GoBot.IHM
{
    partial class PanelLogsTrames
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
            this.lstRecMoveFunctions = new System.Windows.Forms.CheckedListBox();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.rdoTimeAbsolute = new System.Windows.Forms.RadioButton();
            this.rdoTimeFromStart = new System.Windows.Forms.RadioButton();
            this.rdoTimeFromPrevDisplay = new System.Windows.Forms.RadioButton();
            this.rdoTimeFromPrev = new System.Windows.Forms.RadioButton();
            this.lstRecIOFunctions = new System.Windows.Forms.CheckedListBox();
            this.grpMessages = new System.Windows.Forms.GroupBox();
            this.btnAllUncheck = new System.Windows.Forms.Button();
            this.btnAllCheck = new System.Windows.Forms.Button();
            this.tabFilters = new System.Windows.Forms.TabControl();
            this.tabPageBoards = new System.Windows.Forms.TabPage();
            this.grpSender = new System.Windows.Forms.GroupBox();
            this.lstSender = new System.Windows.Forms.CheckedListBox();
            this.grpReceiver = new System.Windows.Forms.GroupBox();
            this.lstReceiver = new System.Windows.Forms.CheckedListBox();
            this.tabPageMessages = new System.Windows.Forms.TabPage();
            this.tabFunctions = new System.Windows.Forms.TabControl();
            this.tabPageMove = new System.Windows.Forms.TabPage();
            this.tabPageIO = new System.Windows.Forms.TabPage();
            this.tabPageGB = new System.Windows.Forms.TabPage();
            this.lstRecGoBotFunctions = new System.Windows.Forms.CheckedListBox();
            this.tabPageCAN = new System.Windows.Forms.TabPage();
            this.lstRecCANFunctions = new System.Windows.Forms.CheckedListBox();
            this.btnReplayAll = new System.Windows.Forms.Button();
            this.btnReplaySelected = new System.Windows.Forms.Button();
            this.boxScroll = new System.Windows.Forms.CheckBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
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
            this.tabFunctions.SuspendLayout();
            this.tabPageMove.SuspendLayout();
            this.tabPageIO.SuspendLayout();
            this.tabPageGB.SuspendLayout();
            this.tabPageCAN.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLog
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
            this.dgvLog.Name = "dataGridViewLog";
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
            // lstRecMoveFunctions
            // 
            this.lstRecMoveFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRecMoveFunctions.CheckOnClick = true;
            this.lstRecMoveFunctions.ColumnWidth = 155;
            this.lstRecMoveFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRecMoveFunctions.FormattingEnabled = true;
            this.lstRecMoveFunctions.Location = new System.Drawing.Point(3, 3);
            this.lstRecMoveFunctions.Margin = new System.Windows.Forms.Padding(0);
            this.lstRecMoveFunctions.MultiColumn = true;
            this.lstRecMoveFunctions.Name = "lstRecMoveFunctions";
            this.lstRecMoveFunctions.Size = new System.Drawing.Size(355, 298);
            this.lstRecMoveFunctions.Sorted = true;
            this.lstRecMoveFunctions.TabIndex = 15;
            this.lstRecMoveFunctions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstFunctions_ItemCheck);
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
            this.rdoTimeAbsolute.Location = new System.Drawing.Point(13, 67);
            this.rdoTimeAbsolute.Name = "rdoTimeAbsolute";
            this.rdoTimeAbsolute.Size = new System.Drawing.Size(94, 17);
            this.rdoTimeAbsolute.TabIndex = 10;
            this.rdoTimeAbsolute.Text = "Heure absolue";
            this.rdoTimeAbsolute.UseVisualStyleBackColor = true;
            // 
            // rdoTimeFromStart
            // 
            this.rdoTimeFromStart.AutoSize = true;
            this.rdoTimeFromStart.Location = new System.Drawing.Point(13, 90);
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
            // lstRecIOFunctions
            // 
            this.lstRecIOFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRecIOFunctions.CheckOnClick = true;
            this.lstRecIOFunctions.ColumnWidth = 150;
            this.lstRecIOFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRecIOFunctions.FormattingEnabled = true;
            this.lstRecIOFunctions.Location = new System.Drawing.Point(3, 3);
            this.lstRecIOFunctions.MultiColumn = true;
            this.lstRecIOFunctions.Name = "lstRecIOFunctions";
            this.lstRecIOFunctions.Size = new System.Drawing.Size(355, 298);
            this.lstRecIOFunctions.Sorted = true;
            this.lstRecIOFunctions.TabIndex = 17;
            this.lstRecIOFunctions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstFunctions_ItemCheck);
            // 
            // grpMessages
            // 
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
            // btnAllUncheck
            // 
            this.btnAllUncheck.Location = new System.Drawing.Point(311, 12);
            this.btnAllUncheck.Name = "btnAllUncheck";
            this.btnAllUncheck.Size = new System.Drawing.Size(85, 23);
            this.btnAllUncheck.TabIndex = 27;
            this.btnAllUncheck.Text = "Tout décocher";
            this.btnAllUncheck.UseVisualStyleBackColor = true;
            this.btnAllUncheck.Click += new System.EventHandler(this.btnAllUncheck_Click);
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.Location = new System.Drawing.Point(230, 12);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(75, 23);
            this.btnAllCheck.TabIndex = 26;
            this.btnAllCheck.Text = "Tout cocher";
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
            this.tabFilters.Size = new System.Drawing.Size(383, 362);
            this.tabFilters.TabIndex = 26;
            // 
            // tabPageBoards
            // 
            this.tabPageBoards.Controls.Add(this.grpSender);
            this.tabPageBoards.Controls.Add(this.grpReceiver);
            this.tabPageBoards.Location = new System.Drawing.Point(4, 22);
            this.tabPageBoards.Name = "tabPageBoards";
            this.tabPageBoards.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBoards.Size = new System.Drawing.Size(375, 336);
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
            this.grpSender.Size = new System.Drawing.Size(177, 324);
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
            this.lstSender.Size = new System.Drawing.Size(171, 305);
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
            this.grpReceiver.Size = new System.Drawing.Size(177, 324);
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
            this.lstReceiver.Size = new System.Drawing.Size(171, 305);
            this.lstReceiver.Sorted = true;
            this.lstReceiver.TabIndex = 16;
            this.lstReceiver.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstReceiver_ItemCheck);
            // 
            // tabPageMessages
            // 
            this.tabPageMessages.Controls.Add(this.tabFunctions);
            this.tabPageMessages.Location = new System.Drawing.Point(4, 22);
            this.tabPageMessages.Name = "tabPageMessages";
            this.tabPageMessages.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMessages.Size = new System.Drawing.Size(375, 336);
            this.tabPageMessages.TabIndex = 1;
            this.tabPageMessages.Text = "Messages";
            this.tabPageMessages.UseVisualStyleBackColor = true;
            // 
            // tabFunctions
            // 
            this.tabFunctions.Controls.Add(this.tabPageMove);
            this.tabFunctions.Controls.Add(this.tabPageIO);
            this.tabFunctions.Controls.Add(this.tabPageGB);
            this.tabFunctions.Controls.Add(this.tabPageCAN);
            this.tabFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFunctions.Location = new System.Drawing.Point(3, 3);
            this.tabFunctions.Name = "tabFunctions";
            this.tabFunctions.SelectedIndex = 0;
            this.tabFunctions.Size = new System.Drawing.Size(369, 330);
            this.tabFunctions.TabIndex = 0;
            // 
            // tabPageMove
            // 
            this.tabPageMove.Controls.Add(this.lstRecMoveFunctions);
            this.tabPageMove.Location = new System.Drawing.Point(4, 22);
            this.tabPageMove.Name = "tabPageMove";
            this.tabPageMove.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMove.Size = new System.Drawing.Size(361, 304);
            this.tabPageMove.TabIndex = 0;
            this.tabPageMove.Text = "RecMove";
            this.tabPageMove.UseVisualStyleBackColor = true;
            // 
            // tabPageIO
            // 
            this.tabPageIO.Controls.Add(this.lstRecIOFunctions);
            this.tabPageIO.Location = new System.Drawing.Point(4, 22);
            this.tabPageIO.Name = "tabPageIO";
            this.tabPageIO.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIO.Size = new System.Drawing.Size(361, 304);
            this.tabPageIO.TabIndex = 1;
            this.tabPageIO.Text = "RecIO";
            this.tabPageIO.UseVisualStyleBackColor = true;
            // 
            // tabPageGB
            // 
            this.tabPageGB.Controls.Add(this.lstRecGoBotFunctions);
            this.tabPageGB.Location = new System.Drawing.Point(4, 22);
            this.tabPageGB.Name = "tabPageGB";
            this.tabPageGB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGB.Size = new System.Drawing.Size(361, 304);
            this.tabPageGB.TabIndex = 5;
            this.tabPageGB.Text = "RecGoBot";
            this.tabPageGB.UseVisualStyleBackColor = true;
            // 
            // lstRecGoBotFunctions
            // 
            this.lstRecGoBotFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRecGoBotFunctions.CheckOnClick = true;
            this.lstRecGoBotFunctions.ColumnWidth = 150;
            this.lstRecGoBotFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRecGoBotFunctions.FormattingEnabled = true;
            this.lstRecGoBotFunctions.Location = new System.Drawing.Point(3, 3);
            this.lstRecGoBotFunctions.MultiColumn = true;
            this.lstRecGoBotFunctions.Name = "lstRecGoBotFunctions";
            this.lstRecGoBotFunctions.Size = new System.Drawing.Size(355, 298);
            this.lstRecGoBotFunctions.Sorted = true;
            this.lstRecGoBotFunctions.TabIndex = 18;
            this.lstRecGoBotFunctions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstFunctions_ItemCheck);
            // 
            // tabPageCAN
            // 
            this.tabPageCAN.Controls.Add(this.lstRecCANFunctions);
            this.tabPageCAN.Location = new System.Drawing.Point(4, 22);
            this.tabPageCAN.Name = "tabPageCAN";
            this.tabPageCAN.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCAN.Size = new System.Drawing.Size(361, 304);
            this.tabPageCAN.TabIndex = 6;
            this.tabPageCAN.Text = "RecCAN";
            this.tabPageCAN.UseVisualStyleBackColor = true;
            // 
            // lstRecCANFunctions
            // 
            this.lstRecCANFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRecCANFunctions.CheckOnClick = true;
            this.lstRecCANFunctions.ColumnWidth = 150;
            this.lstRecCANFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRecCANFunctions.FormattingEnabled = true;
            this.lstRecCANFunctions.Location = new System.Drawing.Point(3, 3);
            this.lstRecCANFunctions.MultiColumn = true;
            this.lstRecCANFunctions.Name = "lstRecCANFunctions";
            this.lstRecCANFunctions.Size = new System.Drawing.Size(355, 298);
            this.lstRecCANFunctions.Sorted = true;
            this.lstRecCANFunctions.TabIndex = 19;
            this.lstRecCANFunctions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstFunctions_ItemCheck);
            // 
            // btnReplayAll
            // 
            this.btnReplayAll.Location = new System.Drawing.Point(140, 33);
            this.btnReplayAll.Name = "btnReplayAll";
            this.btnReplayAll.Size = new System.Drawing.Size(106, 23);
            this.btnReplayAll.TabIndex = 21;
            this.btnReplayAll.Text = "Rejouer tout";
            this.btnReplayAll.UseVisualStyleBackColor = true;
            this.btnReplayAll.Click += new System.EventHandler(this.btnReplayAll_Click);
            // 
            // btnReplaySelected
            // 
            this.btnReplaySelected.Location = new System.Drawing.Point(140, 63);
            this.btnReplaySelected.Name = "btnReplaySelected";
            this.btnReplaySelected.Size = new System.Drawing.Size(106, 23);
            this.btnReplaySelected.TabIndex = 22;
            this.btnReplaySelected.Text = "Rejouer sélection";
            this.btnReplaySelected.UseVisualStyleBackColor = true;
            this.btnReplaySelected.Click += new System.EventHandler(this.btnReplaySelected_Click);
            // 
            // boxScroll
            // 
            this.boxScroll.AutoSize = true;
            this.boxScroll.Checked = true;
            this.boxScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxScroll.Location = new System.Drawing.Point(278, 67);
            this.boxScroll.Name = "boxScroll";
            this.boxScroll.Size = new System.Drawing.Size(113, 17);
            this.boxScroll.TabIndex = 23;
            this.boxScroll.Text = "Scroll automatique";
            this.boxScroll.UseVisualStyleBackColor = true;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Image = global::GoBot.Properties.Resources.Play16;
            this.btnDisplay.Location = new System.Drawing.Point(270, 33);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(129, 23);
            this.btnDisplay.TabIndex = 20;
            this.btnDisplay.Text = "Afficher temps réel";
            this.btnDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::GoBot.Properties.Resources.Refresh16;
            this.btnRefresh.Location = new System.Drawing.Point(11, 62);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(104, 23);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = global::GoBot.Properties.Resources.Folder16;
            this.btnLoad.Location = new System.Drawing.Point(11, 33);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(104, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Charger un log";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // PanelLogsTrames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.boxScroll);
            this.Controls.Add(this.btnReplaySelected);
            this.Controls.Add(this.btnReplayAll);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.grpMessages);
            this.Controls.Add(this.grpTime);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpColor);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.btnLoad);
            this.Name = "PanelLogsTrames";
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
            this.tabFunctions.ResumeLayout(false);
            this.tabPageMove.ResumeLayout(false);
            this.tabPageIO.ResumeLayout(false);
            this.tabPageGB.ResumeLayout(false);
            this.tabPageCAN.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.GroupBox grpColor;
        private System.Windows.Forms.RadioButton rdoColorByBoard;
        private System.Windows.Forms.RadioButton rdoColorByReceiver;
        private System.Windows.Forms.RadioButton rdoColorBySender;
        private System.Windows.Forms.RadioButton rdoColorNone;
        private System.Windows.Forms.CheckedListBox lstRecMoveFunctions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpTime;
        private System.Windows.Forms.RadioButton rdoTimeFromStart;
        private System.Windows.Forms.RadioButton rdoTimeAbsolute;
        private System.Windows.Forms.RadioButton rdoTimeFromPrevDisplay;
        private System.Windows.Forms.RadioButton rdoTimeFromPrev;
        private System.Windows.Forms.CheckedListBox lstRecIOFunctions;
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
        private System.Windows.Forms.TabControl tabFunctions;
        private System.Windows.Forms.TabPage tabPageMove;
        private System.Windows.Forms.TabPage tabPageIO;
        private System.Windows.Forms.Button btnAllUncheck;
        private System.Windows.Forms.Button btnAllCheck;
        private System.Windows.Forms.TabPage tabPageGB;
        private System.Windows.Forms.CheckedListBox lstRecGoBotFunctions;
        private System.Windows.Forms.TabPage tabPageCAN;
        private System.Windows.Forms.CheckedListBox lstRecCANFunctions;
    }
}
