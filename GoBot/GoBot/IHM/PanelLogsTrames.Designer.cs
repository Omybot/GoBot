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
            this.dataGridViewLog = new System.Windows.Forms.DataGridView();
            this.contextMenuStripRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copierLaTrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nePlusAfficherTousCesMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoAucun = new System.Windows.Forms.RadioButton();
            this.rdoDest = new System.Windows.Forms.RadioButton();
            this.rdoCarte = new System.Windows.Forms.RadioButton();
            this.rdoExp = new System.Windows.Forms.RadioButton();
            this.checkedListBoxMove = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoHeure = new System.Windows.Forms.RadioButton();
            this.rdoTempsDebut = new System.Windows.Forms.RadioButton();
            this.rdoTempsPrecAff = new System.Windows.Forms.RadioButton();
            this.rdoTempsPrec = new System.Windows.Forms.RadioButton();
            this.checkedListBoxIO = new System.Windows.Forms.CheckedListBox();
            this.groupBoxMessages = new System.Windows.Forms.GroupBox();
            this.btnDecocher = new System.Windows.Forms.Button();
            this.btnCocher = new System.Windows.Forms.Button();
            this.tabControlGestion = new System.Windows.Forms.TabControl();
            this.tabPageCartes = new System.Windows.Forms.TabPage();
            this.groupBoxExpediteur = new System.Windows.Forms.GroupBox();
            this.checkedListBoxExpediteur = new System.Windows.Forms.CheckedListBox();
            this.groupBoxDestinataire = new System.Windows.Forms.GroupBox();
            this.checkedListBoxDestinataire = new System.Windows.Forms.CheckedListBox();
            this.tabPageMessages = new System.Windows.Forms.TabPage();
            this.tabControlMessages = new System.Windows.Forms.TabControl();
            this.tabPageMove = new System.Windows.Forms.TabPage();
            this.tabPageIO = new System.Windows.Forms.TabPage();
            this.btnRejouerTout = new System.Windows.Forms.Button();
            this.btnRejouerSelection = new System.Windows.Forms.Button();
            this.boxScroll = new System.Windows.Forms.CheckBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCharger = new System.Windows.Forms.Button();
            this.tabGB = new System.Windows.Forms.TabPage();
            this.checkedListBoxGB = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).BeginInit();
            this.contextMenuStripRow.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxMessages.SuspendLayout();
            this.tabControlGestion.SuspendLayout();
            this.tabPageCartes.SuspendLayout();
            this.groupBoxExpediteur.SuspendLayout();
            this.groupBoxDestinataire.SuspendLayout();
            this.tabPageMessages.SuspendLayout();
            this.tabControlMessages.SuspendLayout();
            this.tabPageMove.SuspendLayout();
            this.tabPageIO.SuspendLayout();
            this.tabGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLog
            // 
            this.dataGridViewLog.AllowUserToAddRows = false;
            this.dataGridViewLog.AllowUserToDeleteRows = false;
            this.dataGridViewLog.AllowUserToOrderColumns = true;
            this.dataGridViewLog.AllowUserToResizeRows = false;
            this.dataGridViewLog.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLog.ContextMenuStrip = this.contextMenuStripRow;
            this.dataGridViewLog.Location = new System.Drawing.Point(416, 9);
            this.dataGridViewLog.Name = "dataGridViewLog";
            this.dataGridViewLog.ReadOnly = true;
            this.dataGridViewLog.RowHeadersVisible = false;
            this.dataGridViewLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLog.Size = new System.Drawing.Size(835, 624);
            this.dataGridViewLog.TabIndex = 1;
            this.dataGridViewLog.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLog_CellMouseDown);
            // 
            // contextMenuStripRow
            // 
            this.contextMenuStripRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copierLaTrameToolStripMenuItem,
            this.nePlusAfficherTousCesMessagesToolStripMenuItem,
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem,
            this.nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem,
            this.nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem,
            this.nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem});
            this.contextMenuStripRow.Name = "contextMenuStripRow";
            this.contextMenuStripRow.Size = new System.Drawing.Size(368, 136);
            // 
            // copierLaTrameToolStripMenuItem
            // 
            this.copierLaTrameToolStripMenuItem.Name = "copierLaTrameToolStripMenuItem";
            this.copierLaTrameToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.copierLaTrameToolStripMenuItem.Text = "Copier la trame";
            this.copierLaTrameToolStripMenuItem.Click += new System.EventHandler(this.copierLaTrameToolStripMenuItem_Click);
            // 
            // nePlusAfficherTousCesMessagesToolStripMenuItem
            // 
            this.nePlusAfficherTousCesMessagesToolStripMenuItem.Name = "nePlusAfficherTousCesMessagesToolStripMenuItem";
            this.nePlusAfficherTousCesMessagesToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.nePlusAfficherTousCesMessagesToolStripMenuItem.Text = "Ne plus afficher tous ces messages";
            this.nePlusAfficherTousCesMessagesToolStripMenuItem.Click += new System.EventHandler(this.nePlusAfficherTousCesMessagesToolStripMenuItem_Click);
            // 
            // nePlusAfficherCeTypeDeMessagesToolStripMenuItem
            // 
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem.Name = "nePlusAfficherCeTypeDeMessagesToolStripMenuItem";
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem.Text = "Ne plus afficher ce type de messages";
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem.Click += new System.EventHandler(this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem_Click);
            // 
            // nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem
            // 
            this.nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem.Name = "nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem";
            this.nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem.Text = "Ne plus afficher de messages avec le même expéditeur";
            this.nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem.Click += new System.EventHandler(this.nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem_Click);
            // 
            // nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem
            // 
            this.nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem.Name = "nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem";
            this.nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem.Text = "Ne plus afficher de messages avec le même destinataire";
            this.nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem.Click += new System.EventHandler(this.nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem_Click);
            // 
            // nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem
            // 
            this.nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem.Name = "nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem";
            this.nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem.Text = "Ne plus afficher de messages de cette carte";
            this.nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem.Click += new System.EventHandler(this.nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoAucun);
            this.groupBox2.Controls.Add(this.rdoDest);
            this.groupBox2.Controls.Add(this.rdoCarte);
            this.groupBox2.Controls.Add(this.rdoExp);
            this.groupBox2.Location = new System.Drawing.Point(293, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 120);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colorer par";
            // 
            // rdoAucun
            // 
            this.rdoAucun.AutoSize = true;
            this.rdoAucun.Location = new System.Drawing.Point(13, 90);
            this.rdoAucun.Name = "rdoAucun";
            this.rdoAucun.Size = new System.Drawing.Size(56, 17);
            this.rdoAucun.TabIndex = 13;
            this.rdoAucun.Text = "Aucun";
            this.rdoAucun.UseVisualStyleBackColor = true;
            // 
            // rdoDest
            // 
            this.rdoDest.AutoSize = true;
            this.rdoDest.Location = new System.Drawing.Point(13, 44);
            this.rdoDest.Name = "rdoDest";
            this.rdoDest.Size = new System.Drawing.Size(81, 17);
            this.rdoDest.TabIndex = 12;
            this.rdoDest.Text = "Destinataire";
            this.rdoDest.UseVisualStyleBackColor = true;
            // 
            // rdoCarte
            // 
            this.rdoCarte.AutoSize = true;
            this.rdoCarte.Location = new System.Drawing.Point(13, 67);
            this.rdoCarte.Name = "rdoCarte";
            this.rdoCarte.Size = new System.Drawing.Size(104, 17);
            this.rdoCarte.TabIndex = 10;
            this.rdoCarte.Text = "Carte concernée";
            this.rdoCarte.UseVisualStyleBackColor = true;
            // 
            // rdoExp
            // 
            this.rdoExp.AutoSize = true;
            this.rdoExp.Checked = true;
            this.rdoExp.Location = new System.Drawing.Point(13, 21);
            this.rdoExp.Name = "rdoExp";
            this.rdoExp.Size = new System.Drawing.Size(75, 17);
            this.rdoExp.TabIndex = 11;
            this.rdoExp.TabStop = true;
            this.rdoExp.Text = "Expéditeur";
            this.rdoExp.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxMove
            // 
            this.checkedListBoxMove.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxMove.CheckOnClick = true;
            this.checkedListBoxMove.ColumnWidth = 155;
            this.checkedListBoxMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxMove.FormattingEnabled = true;
            this.checkedListBoxMove.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxMove.Margin = new System.Windows.Forms.Padding(0);
            this.checkedListBoxMove.MultiColumn = true;
            this.checkedListBoxMove.Name = "checkedListBoxMove";
            this.checkedListBoxMove.Size = new System.Drawing.Size(355, 298);
            this.checkedListBoxMove.Sorted = true;
            this.checkedListBoxMove.TabIndex = 15;
            this.checkedListBoxMove.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxGros_ItemCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoHeure);
            this.groupBox1.Controls.Add(this.rdoTempsDebut);
            this.groupBox1.Controls.Add(this.rdoTempsPrecAff);
            this.groupBox1.Controls.Add(this.rdoTempsPrec);
            this.groupBox1.Location = new System.Drawing.Point(3, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 120);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Affichage heure";
            // 
            // rdoHeure
            // 
            this.rdoHeure.AutoSize = true;
            this.rdoHeure.Location = new System.Drawing.Point(13, 67);
            this.rdoHeure.Name = "rdoHeure";
            this.rdoHeure.Size = new System.Drawing.Size(94, 17);
            this.rdoHeure.TabIndex = 10;
            this.rdoHeure.Text = "Heure absolue";
            this.rdoHeure.UseVisualStyleBackColor = true;
            // 
            // rdoTempsDebut
            // 
            this.rdoTempsDebut.AutoSize = true;
            this.rdoTempsDebut.Location = new System.Drawing.Point(13, 90);
            this.rdoTempsDebut.Name = "rdoTempsDebut";
            this.rdoTempsDebut.Size = new System.Drawing.Size(167, 17);
            this.rdoTempsDebut.TabIndex = 13;
            this.rdoTempsDebut.Text = "Temps écoulé depuis le début";
            this.rdoTempsDebut.UseVisualStyleBackColor = true;
            // 
            // rdoTempsPrecAff
            // 
            this.rdoTempsPrecAff.AutoSize = true;
            this.rdoTempsPrecAff.Checked = true;
            this.rdoTempsPrecAff.Location = new System.Drawing.Point(13, 21);
            this.rdoTempsPrecAff.Name = "rdoTempsPrecAff";
            this.rdoTempsPrecAff.Size = new System.Drawing.Size(268, 17);
            this.rdoTempsPrecAff.TabIndex = 12;
            this.rdoTempsPrecAff.TabStop = true;
            this.rdoTempsPrecAff.Text = "Temps écoulé depuis le message affiché précédent";
            this.rdoTempsPrecAff.UseVisualStyleBackColor = true;
            // 
            // rdoTempsPrec
            // 
            this.rdoTempsPrec.AutoSize = true;
            this.rdoTempsPrec.Location = new System.Drawing.Point(13, 44);
            this.rdoTempsPrec.Name = "rdoTempsPrec";
            this.rdoTempsPrec.Size = new System.Drawing.Size(233, 17);
            this.rdoTempsPrec.TabIndex = 11;
            this.rdoTempsPrec.Text = "Temps écoulé depuis le message précédent";
            this.rdoTempsPrec.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxIO
            // 
            this.checkedListBoxIO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxIO.CheckOnClick = true;
            this.checkedListBoxIO.ColumnWidth = 150;
            this.checkedListBoxIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxIO.FormattingEnabled = true;
            this.checkedListBoxIO.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxIO.MultiColumn = true;
            this.checkedListBoxIO.Name = "checkedListBoxIO";
            this.checkedListBoxIO.Size = new System.Drawing.Size(355, 298);
            this.checkedListBoxIO.Sorted = true;
            this.checkedListBoxIO.TabIndex = 17;
            this.checkedListBoxIO.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxIO_ItemCheck);
            // 
            // groupBoxMessages
            // 
            this.groupBoxMessages.Controls.Add(this.btnDecocher);
            this.groupBoxMessages.Controls.Add(this.btnCocher);
            this.groupBoxMessages.Controls.Add(this.tabControlGestion);
            this.groupBoxMessages.Location = new System.Drawing.Point(3, 240);
            this.groupBoxMessages.Name = "groupBoxMessages";
            this.groupBoxMessages.Size = new System.Drawing.Size(407, 393);
            this.groupBoxMessages.TabIndex = 19;
            this.groupBoxMessages.TabStop = false;
            this.groupBoxMessages.Text = "Filtres sur les messages";
            // 
            // btnDecocher
            // 
            this.btnDecocher.Location = new System.Drawing.Point(311, 12);
            this.btnDecocher.Name = "btnDecocher";
            this.btnDecocher.Size = new System.Drawing.Size(85, 23);
            this.btnDecocher.TabIndex = 27;
            this.btnDecocher.Text = "Tout décocher";
            this.btnDecocher.UseVisualStyleBackColor = true;
            this.btnDecocher.Click += new System.EventHandler(this.btnDecocher_Click);
            // 
            // btnCocher
            // 
            this.btnCocher.Location = new System.Drawing.Point(230, 12);
            this.btnCocher.Name = "btnCocher";
            this.btnCocher.Size = new System.Drawing.Size(75, 23);
            this.btnCocher.TabIndex = 26;
            this.btnCocher.Text = "Tout cocher";
            this.btnCocher.UseVisualStyleBackColor = true;
            this.btnCocher.Click += new System.EventHandler(this.btnCocher_Click);
            // 
            // tabControlGestion
            // 
            this.tabControlGestion.Controls.Add(this.tabPageCartes);
            this.tabControlGestion.Controls.Add(this.tabPageMessages);
            this.tabControlGestion.Location = new System.Drawing.Point(13, 19);
            this.tabControlGestion.Name = "tabControlGestion";
            this.tabControlGestion.SelectedIndex = 0;
            this.tabControlGestion.Size = new System.Drawing.Size(383, 362);
            this.tabControlGestion.TabIndex = 26;
            // 
            // tabPageCartes
            // 
            this.tabPageCartes.Controls.Add(this.groupBoxExpediteur);
            this.tabPageCartes.Controls.Add(this.groupBoxDestinataire);
            this.tabPageCartes.Location = new System.Drawing.Point(4, 22);
            this.tabPageCartes.Name = "tabPageCartes";
            this.tabPageCartes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCartes.Size = new System.Drawing.Size(375, 336);
            this.tabPageCartes.TabIndex = 0;
            this.tabPageCartes.Text = "Cartes";
            this.tabPageCartes.UseVisualStyleBackColor = true;
            // 
            // groupBoxExpediteur
            // 
            this.groupBoxExpediteur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxExpediteur.Controls.Add(this.checkedListBoxExpediteur);
            this.groupBoxExpediteur.Location = new System.Drawing.Point(6, 6);
            this.groupBoxExpediteur.Name = "groupBoxExpediteur";
            this.groupBoxExpediteur.Size = new System.Drawing.Size(177, 324);
            this.groupBoxExpediteur.TabIndex = 24;
            this.groupBoxExpediteur.TabStop = false;
            this.groupBoxExpediteur.Text = "Expediteur";
            // 
            // checkedListBoxExpediteur
            // 
            this.checkedListBoxExpediteur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxExpediteur.CheckOnClick = true;
            this.checkedListBoxExpediteur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxExpediteur.FormattingEnabled = true;
            this.checkedListBoxExpediteur.Location = new System.Drawing.Point(3, 16);
            this.checkedListBoxExpediteur.Name = "checkedListBoxExpediteur";
            this.checkedListBoxExpediteur.Size = new System.Drawing.Size(171, 305);
            this.checkedListBoxExpediteur.Sorted = true;
            this.checkedListBoxExpediteur.TabIndex = 16;
            this.checkedListBoxExpediteur.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxExpediteur_ItemCheck);
            // 
            // groupBoxDestinataire
            // 
            this.groupBoxDestinataire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDestinataire.Controls.Add(this.checkedListBoxDestinataire);
            this.groupBoxDestinataire.Location = new System.Drawing.Point(192, 6);
            this.groupBoxDestinataire.Name = "groupBoxDestinataire";
            this.groupBoxDestinataire.Size = new System.Drawing.Size(177, 324);
            this.groupBoxDestinataire.TabIndex = 25;
            this.groupBoxDestinataire.TabStop = false;
            this.groupBoxDestinataire.Text = "Destinataire";
            // 
            // checkedListBoxDestinataire
            // 
            this.checkedListBoxDestinataire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxDestinataire.CheckOnClick = true;
            this.checkedListBoxDestinataire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxDestinataire.FormattingEnabled = true;
            this.checkedListBoxDestinataire.Location = new System.Drawing.Point(3, 16);
            this.checkedListBoxDestinataire.Name = "checkedListBoxDestinataire";
            this.checkedListBoxDestinataire.Size = new System.Drawing.Size(171, 305);
            this.checkedListBoxDestinataire.Sorted = true;
            this.checkedListBoxDestinataire.TabIndex = 16;
            this.checkedListBoxDestinataire.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxDestinataire_ItemCheck);
            // 
            // tabPageMessages
            // 
            this.tabPageMessages.Controls.Add(this.tabControlMessages);
            this.tabPageMessages.Location = new System.Drawing.Point(4, 22);
            this.tabPageMessages.Name = "tabPageMessages";
            this.tabPageMessages.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMessages.Size = new System.Drawing.Size(375, 336);
            this.tabPageMessages.TabIndex = 1;
            this.tabPageMessages.Text = "Messages";
            this.tabPageMessages.UseVisualStyleBackColor = true;
            // 
            // tabControlMessages
            // 
            this.tabControlMessages.Controls.Add(this.tabPageMove);
            this.tabControlMessages.Controls.Add(this.tabPageIO);
            this.tabControlMessages.Controls.Add(this.tabGB);
            this.tabControlMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMessages.Location = new System.Drawing.Point(3, 3);
            this.tabControlMessages.Name = "tabControlMessages";
            this.tabControlMessages.SelectedIndex = 0;
            this.tabControlMessages.Size = new System.Drawing.Size(369, 330);
            this.tabControlMessages.TabIndex = 0;
            // 
            // tabPageMove
            // 
            this.tabPageMove.Controls.Add(this.checkedListBoxMove);
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
            this.tabPageIO.Controls.Add(this.checkedListBoxIO);
            this.tabPageIO.Location = new System.Drawing.Point(4, 22);
            this.tabPageIO.Name = "tabPageIO";
            this.tabPageIO.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIO.Size = new System.Drawing.Size(361, 304);
            this.tabPageIO.TabIndex = 1;
            this.tabPageIO.Text = "RecIO";
            this.tabPageIO.UseVisualStyleBackColor = true;
            // 
            // btnRejouerTout
            // 
            this.btnRejouerTout.Location = new System.Drawing.Point(140, 33);
            this.btnRejouerTout.Name = "btnRejouerTout";
            this.btnRejouerTout.Size = new System.Drawing.Size(106, 23);
            this.btnRejouerTout.TabIndex = 21;
            this.btnRejouerTout.Text = "Rejouer tout";
            this.btnRejouerTout.UseVisualStyleBackColor = true;
            this.btnRejouerTout.Click += new System.EventHandler(this.btnRejouerTout_Click);
            // 
            // btnRejouerSelection
            // 
            this.btnRejouerSelection.Location = new System.Drawing.Point(140, 63);
            this.btnRejouerSelection.Name = "btnRejouerSelection";
            this.btnRejouerSelection.Size = new System.Drawing.Size(106, 23);
            this.btnRejouerSelection.TabIndex = 22;
            this.btnRejouerSelection.Text = "Rejouer sélection";
            this.btnRejouerSelection.UseVisualStyleBackColor = true;
            this.btnRejouerSelection.Click += new System.EventHandler(this.btnRejouerSelection_Click);
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
            // btnAfficher
            // 
            this.btnAfficher.Image = global::GoBot.Properties.Resources.Play16;
            this.btnAfficher.Location = new System.Drawing.Point(270, 33);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(129, 23);
            this.btnAfficher.TabIndex = 20;
            this.btnAfficher.Text = "Afficher temps réel";
            this.btnAfficher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAfficher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAfficher.UseVisualStyleBackColor = true;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
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
            // btnCharger
            // 
            this.btnCharger.Image = global::GoBot.Properties.Resources.Folder16;
            this.btnCharger.Location = new System.Drawing.Point(11, 33);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(104, 23);
            this.btnCharger.TabIndex = 0;
            this.btnCharger.Text = "Charger un log";
            this.btnCharger.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCharger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCharger.UseVisualStyleBackColor = true;
            this.btnCharger.Click += new System.EventHandler(this.btnCharger_Click);
            // 
            // tabGB
            // 
            this.tabGB.Controls.Add(this.checkedListBoxGB);
            this.tabGB.Location = new System.Drawing.Point(4, 22);
            this.tabGB.Name = "tabGB";
            this.tabGB.Padding = new System.Windows.Forms.Padding(3);
            this.tabGB.Size = new System.Drawing.Size(361, 304);
            this.tabGB.TabIndex = 5;
            this.tabGB.Text = "RecGoBot";
            this.tabGB.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxGB
            // 
            this.checkedListBoxGB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxGB.CheckOnClick = true;
            this.checkedListBoxGB.ColumnWidth = 150;
            this.checkedListBoxGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxGB.FormattingEnabled = true;
            this.checkedListBoxGB.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxGB.MultiColumn = true;
            this.checkedListBoxGB.Name = "checkedListBoxGB";
            this.checkedListBoxGB.Size = new System.Drawing.Size(355, 298);
            this.checkedListBoxGB.Sorted = true;
            this.checkedListBoxGB.TabIndex = 18;
            this.checkedListBoxGB.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxGB_ItemCheck);
            // 
            // PanelLogsTrames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.boxScroll);
            this.Controls.Add(this.btnRejouerSelection);
            this.Controls.Add(this.btnRejouerTout);
            this.Controls.Add(this.btnAfficher);
            this.Controls.Add(this.groupBoxMessages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewLog);
            this.Controls.Add(this.btnCharger);
            this.Name = "PanelLogsTrames";
            this.Size = new System.Drawing.Size(1254, 669);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).EndInit();
            this.contextMenuStripRow.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxMessages.ResumeLayout(false);
            this.tabControlGestion.ResumeLayout(false);
            this.tabPageCartes.ResumeLayout(false);
            this.groupBoxExpediteur.ResumeLayout(false);
            this.groupBoxDestinataire.ResumeLayout(false);
            this.tabPageMessages.ResumeLayout(false);
            this.tabControlMessages.ResumeLayout(false);
            this.tabPageMove.ResumeLayout(false);
            this.tabPageIO.ResumeLayout(false);
            this.tabGB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCharger;
        private System.Windows.Forms.DataGridView dataGridViewLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoCarte;
        private System.Windows.Forms.RadioButton rdoDest;
        private System.Windows.Forms.RadioButton rdoExp;
        private System.Windows.Forms.RadioButton rdoAucun;
        private System.Windows.Forms.CheckedListBox checkedListBoxMove;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoTempsDebut;
        private System.Windows.Forms.RadioButton rdoHeure;
        private System.Windows.Forms.RadioButton rdoTempsPrecAff;
        private System.Windows.Forms.RadioButton rdoTempsPrec;
        private System.Windows.Forms.CheckedListBox checkedListBoxIO;
        private System.Windows.Forms.GroupBox groupBoxMessages;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRow;
        private System.Windows.Forms.ToolStripMenuItem nePlusAfficherCeTypeDeMessagesToolStripMenuItem;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.Button btnRejouerTout;
        private System.Windows.Forms.Button btnRejouerSelection;
        private System.Windows.Forms.CheckBox boxScroll;
        private System.Windows.Forms.GroupBox groupBoxExpediteur;
        private System.Windows.Forms.CheckedListBox checkedListBoxExpediteur;
        private System.Windows.Forms.CheckedListBox checkedListBoxDestinataire;
        private System.Windows.Forms.GroupBox groupBoxDestinataire;
        private System.Windows.Forms.ToolStripMenuItem nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nePlusAfficherTousCesMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copierLaTrameToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlGestion;
        private System.Windows.Forms.TabPage tabPageCartes;
        private System.Windows.Forms.TabPage tabPageMessages;
        private System.Windows.Forms.TabControl tabControlMessages;
        private System.Windows.Forms.TabPage tabPageMove;
        private System.Windows.Forms.TabPage tabPageIO;
        private System.Windows.Forms.Button btnDecocher;
        private System.Windows.Forms.Button btnCocher;
        private System.Windows.Forms.TabPage tabGB;
        private System.Windows.Forms.CheckedListBox checkedListBoxGB;

    }
}
