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
            this.btnCharger = new System.Windows.Forms.Button();
            this.dataGridViewLog = new System.Windows.Forms.DataGridView();
            this.contextMenuStripRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoAucun = new System.Windows.Forms.RadioButton();
            this.rdoDest = new System.Windows.Forms.RadioButton();
            this.rdoCarte = new System.Windows.Forms.RadioButton();
            this.rdoExp = new System.Windows.Forms.RadioButton();
            this.checkedListBoxGros = new System.Windows.Forms.CheckedListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoHeure = new System.Windows.Forms.RadioButton();
            this.rdoTempsDebut = new System.Windows.Forms.RadioButton();
            this.rdoTempsPrecAff = new System.Windows.Forms.RadioButton();
            this.rdoTempsPrec = new System.Windows.Forms.RadioButton();
            this.checkedListBoxPetit = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxBalise = new System.Windows.Forms.CheckedListBox();
            this.groupBoxMessages = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGrosRobot = new System.Windows.Forms.Label();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnRejouerTout = new System.Windows.Forms.Button();
            this.btnRejouerSelection = new System.Windows.Forms.Button();
            this.boxScroll = new System.Windows.Forms.CheckBox();
            this.groupBoxExpediteur = new System.Windows.Forms.GroupBox();
            this.checkedListBoxExpediteur = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxDestinataire = new System.Windows.Forms.CheckedListBox();
            this.groupBoxDestinataire = new System.Windows.Forms.GroupBox();
            this.nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).BeginInit();
            this.contextMenuStripRow.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxMessages.SuspendLayout();
            this.groupBoxExpediteur.SuspendLayout();
            this.groupBoxDestinataire.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCharger
            // 
            this.btnCharger.Location = new System.Drawing.Point(30, 33);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(104, 23);
            this.btnCharger.TabIndex = 0;
            this.btnCharger.Text = "Charger un log";
            this.btnCharger.UseVisualStyleBackColor = true;
            this.btnCharger.Click += new System.EventHandler(this.btnCharger_Click);
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
            this.dataGridViewLog.Size = new System.Drawing.Size(854, 657);
            this.dataGridViewLog.TabIndex = 1;
            this.dataGridViewLog.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLog_CellMouseDown);
            // 
            // contextMenuStripRow
            // 
            this.contextMenuStripRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem,
            this.nePlusAfficherDeMessagesDeCetExpéditeurToolStripMenuItem,
            this.nePlusAfficherDeMessagesAvecCeDestinataireToolStripMenuItem,
            this.nePlusAfficherDeMessagesDeCetteCarteToolStripMenuItem});
            this.contextMenuStripRow.Name = "contextMenuStripRow";
            this.contextMenuStripRow.Size = new System.Drawing.Size(368, 114);
            // 
            // nePlusAfficherCeTypeDeMessagesToolStripMenuItem
            // 
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem.Name = "nePlusAfficherCeTypeDeMessagesToolStripMenuItem";
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem.Text = "Ne plus afficher ce type de messages";
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem.Click += new System.EventHandler(this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoAucun);
            this.groupBox2.Controls.Add(this.rdoDest);
            this.groupBox2.Controls.Add(this.rdoCarte);
            this.groupBox2.Controls.Add(this.rdoExp);
            this.groupBox2.Location = new System.Drawing.Point(293, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 119);
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
            // checkedListBoxGros
            // 
            this.checkedListBoxGros.CheckOnClick = true;
            this.checkedListBoxGros.FormattingEnabled = true;
            this.checkedListBoxGros.Location = new System.Drawing.Point(98, 21);
            this.checkedListBoxGros.Name = "checkedListBoxGros";
            this.checkedListBoxGros.Size = new System.Drawing.Size(177, 124);
            this.checkedListBoxGros.Sorted = true;
            this.checkedListBoxGros.TabIndex = 15;
            this.checkedListBoxGros.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxGros_ItemCheck);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(30, 62);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(104, 23);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoHeure);
            this.groupBox1.Controls.Add(this.rdoTempsDebut);
            this.groupBox1.Controls.Add(this.rdoTempsPrecAff);
            this.groupBox1.Controls.Add(this.rdoTempsPrec);
            this.groupBox1.Location = new System.Drawing.Point(3, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 120);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Heure";
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
            // checkedListBoxPetit
            // 
            this.checkedListBoxPetit.CheckOnClick = true;
            this.checkedListBoxPetit.FormattingEnabled = true;
            this.checkedListBoxPetit.Location = new System.Drawing.Point(98, 151);
            this.checkedListBoxPetit.Name = "checkedListBoxPetit";
            this.checkedListBoxPetit.Size = new System.Drawing.Size(177, 124);
            this.checkedListBoxPetit.Sorted = true;
            this.checkedListBoxPetit.TabIndex = 17;
            this.checkedListBoxPetit.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxPetit_ItemCheck);
            // 
            // checkedListBoxBalise
            // 
            this.checkedListBoxBalise.CheckOnClick = true;
            this.checkedListBoxBalise.FormattingEnabled = true;
            this.checkedListBoxBalise.Location = new System.Drawing.Point(98, 281);
            this.checkedListBoxBalise.Name = "checkedListBoxBalise";
            this.checkedListBoxBalise.Size = new System.Drawing.Size(177, 124);
            this.checkedListBoxBalise.Sorted = true;
            this.checkedListBoxBalise.TabIndex = 18;
            this.checkedListBoxBalise.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxBalise_ItemCheck);
            // 
            // groupBoxMessages
            // 
            this.groupBoxMessages.Controls.Add(this.label2);
            this.groupBoxMessages.Controls.Add(this.label1);
            this.groupBoxMessages.Controls.Add(this.lblGrosRobot);
            this.groupBoxMessages.Controls.Add(this.checkedListBoxGros);
            this.groupBoxMessages.Controls.Add(this.checkedListBoxBalise);
            this.groupBoxMessages.Controls.Add(this.checkedListBoxPetit);
            this.groupBoxMessages.Location = new System.Drawing.Point(3, 254);
            this.groupBoxMessages.Name = "groupBoxMessages";
            this.groupBoxMessages.Size = new System.Drawing.Size(281, 412);
            this.groupBoxMessages.TabIndex = 19;
            this.groupBoxMessages.TabStop = false;
            this.groupBoxMessages.Text = "Afficher les messages suivants";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Balises";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Petit robot";
            // 
            // lblGrosRobot
            // 
            this.lblGrosRobot.AutoSize = true;
            this.lblGrosRobot.Location = new System.Drawing.Point(23, 77);
            this.lblGrosRobot.Name = "lblGrosRobot";
            this.lblGrosRobot.Size = new System.Drawing.Size(56, 13);
            this.lblGrosRobot.TabIndex = 19;
            this.lblGrosRobot.Text = "Gros robot";
            // 
            // btnAfficher
            // 
            this.btnAfficher.Location = new System.Drawing.Point(293, 33);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(106, 23);
            this.btnAfficher.TabIndex = 20;
            this.btnAfficher.Text = "Afficher temps réel";
            this.btnAfficher.UseVisualStyleBackColor = true;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            // 
            // btnRejouerTout
            // 
            this.btnRejouerTout.Location = new System.Drawing.Point(159, 33);
            this.btnRejouerTout.Name = "btnRejouerTout";
            this.btnRejouerTout.Size = new System.Drawing.Size(106, 23);
            this.btnRejouerTout.TabIndex = 21;
            this.btnRejouerTout.Text = "Rejouer tout";
            this.btnRejouerTout.UseVisualStyleBackColor = true;
            this.btnRejouerTout.Click += new System.EventHandler(this.btnRejouerTout_Click);
            // 
            // btnRejouerSelection
            // 
            this.btnRejouerSelection.Location = new System.Drawing.Point(159, 63);
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
            this.boxScroll.Location = new System.Drawing.Point(306, 66);
            this.boxScroll.Name = "boxScroll";
            this.boxScroll.Size = new System.Drawing.Size(76, 17);
            this.boxScroll.TabIndex = 23;
            this.boxScroll.Text = "Scroll auto";
            this.boxScroll.UseVisualStyleBackColor = true;
            // 
            // groupBoxExpediteur
            // 
            this.groupBoxExpediteur.Controls.Add(this.checkedListBoxExpediteur);
            this.groupBoxExpediteur.Location = new System.Drawing.Point(293, 254);
            this.groupBoxExpediteur.Name = "groupBoxExpediteur";
            this.groupBoxExpediteur.Size = new System.Drawing.Size(117, 152);
            this.groupBoxExpediteur.TabIndex = 24;
            this.groupBoxExpediteur.TabStop = false;
            this.groupBoxExpediteur.Text = "Expediteur";
            // 
            // checkedListBoxExpediteur
            // 
            this.checkedListBoxExpediteur.CheckOnClick = true;
            this.checkedListBoxExpediteur.FormattingEnabled = true;
            this.checkedListBoxExpediteur.Location = new System.Drawing.Point(6, 18);
            this.checkedListBoxExpediteur.Name = "checkedListBoxExpediteur";
            this.checkedListBoxExpediteur.Size = new System.Drawing.Size(105, 124);
            this.checkedListBoxExpediteur.Sorted = true;
            this.checkedListBoxExpediteur.TabIndex = 16;
            this.checkedListBoxExpediteur.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxExpediteur_ItemCheck);
            // 
            // checkedListBoxDestinataire
            // 
            this.checkedListBoxDestinataire.CheckOnClick = true;
            this.checkedListBoxDestinataire.FormattingEnabled = true;
            this.checkedListBoxDestinataire.Location = new System.Drawing.Point(6, 18);
            this.checkedListBoxDestinataire.Name = "checkedListBoxDestinataire";
            this.checkedListBoxDestinataire.Size = new System.Drawing.Size(105, 124);
            this.checkedListBoxDestinataire.Sorted = true;
            this.checkedListBoxDestinataire.TabIndex = 16;
            this.checkedListBoxDestinataire.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxDestinataire_ItemCheck);
            // 
            // groupBoxDestinataire
            // 
            this.groupBoxDestinataire.Controls.Add(this.checkedListBoxDestinataire);
            this.groupBoxDestinataire.Location = new System.Drawing.Point(293, 412);
            this.groupBoxDestinataire.Name = "groupBoxDestinataire";
            this.groupBoxDestinataire.Size = new System.Drawing.Size(117, 152);
            this.groupBoxDestinataire.TabIndex = 25;
            this.groupBoxDestinataire.TabStop = false;
            this.groupBoxDestinataire.Text = "Destinataire";
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
            // PanelLogsTrames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxDestinataire);
            this.Controls.Add(this.groupBoxExpediteur);
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
            this.Size = new System.Drawing.Size(1273, 669);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).EndInit();
            this.contextMenuStripRow.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxMessages.ResumeLayout(false);
            this.groupBoxMessages.PerformLayout();
            this.groupBoxExpediteur.ResumeLayout(false);
            this.groupBoxDestinataire.ResumeLayout(false);
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
        private System.Windows.Forms.CheckedListBox checkedListBoxGros;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoTempsDebut;
        private System.Windows.Forms.RadioButton rdoHeure;
        private System.Windows.Forms.RadioButton rdoTempsPrecAff;
        private System.Windows.Forms.RadioButton rdoTempsPrec;
        private System.Windows.Forms.CheckedListBox checkedListBoxPetit;
        private System.Windows.Forms.CheckedListBox checkedListBoxBalise;
        private System.Windows.Forms.GroupBox groupBoxMessages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGrosRobot;
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

    }
}
