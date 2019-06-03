namespace GoBot.IHM
{
    partial class PanelLogsEvents
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
            this.rdoRobot = new System.Windows.Forms.RadioButton();
            this.rdoType = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoHeure = new System.Windows.Forms.RadioButton();
            this.rdoTempsDebut = new System.Windows.Forms.RadioButton();
            this.rdoTempsPrecAff = new System.Windows.Forms.RadioButton();
            this.rdoTempsPrec = new System.Windows.Forms.RadioButton();
            this.groupBoxMessages = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGrosRobot = new System.Windows.Forms.Label();
            this.checkedListBoxRobots = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxEvents = new System.Windows.Forms.CheckedListBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.boxScroll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).BeginInit();
            this.contextMenuStripRow.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxMessages.SuspendLayout();
            this.SuspendLayout();
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
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem});
            this.contextMenuStripRow.Name = "contextMenuStripRow";
            this.contextMenuStripRow.Size = new System.Drawing.Size(68, 26);
            // 
            // nePlusAfficherCeTypeDeMessagesToolStripMenuItem
            // 
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem.Name = "nePlusAfficherCeTypeDeMessagesToolStripMenuItem";
            this.nePlusAfficherCeTypeDeMessagesToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoAucun);
            this.groupBox2.Controls.Add(this.rdoRobot);
            this.groupBox2.Controls.Add(this.rdoType);
            this.groupBox2.Location = new System.Drawing.Point(293, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 119);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colorer par";
            // 
            // rdoAucun
            // 
            this.rdoAucun.AutoSize = true;
            this.rdoAucun.Location = new System.Drawing.Point(13, 82);
            this.rdoAucun.Name = "rdoAucun";
            this.rdoAucun.Size = new System.Drawing.Size(56, 17);
            this.rdoAucun.TabIndex = 13;
            this.rdoAucun.Text = "Aucun";
            this.rdoAucun.UseVisualStyleBackColor = true;
            // 
            // rdoRobot
            // 
            this.rdoRobot.AutoSize = true;
            this.rdoRobot.Location = new System.Drawing.Point(13, 28);
            this.rdoRobot.Name = "rdoRobot";
            this.rdoRobot.Size = new System.Drawing.Size(54, 17);
            this.rdoRobot.TabIndex = 10;
            this.rdoRobot.Text = "Robot";
            this.rdoRobot.UseVisualStyleBackColor = true;
            // 
            // rdoType
            // 
            this.rdoType.AutoSize = true;
            this.rdoType.Checked = true;
            this.rdoType.Location = new System.Drawing.Point(13, 55);
            this.rdoType.Name = "rdoType";
            this.rdoType.Size = new System.Drawing.Size(49, 17);
            this.rdoType.TabIndex = 11;
            this.rdoType.TabStop = true;
            this.rdoType.Text = "Type";
            this.rdoType.UseVisualStyleBackColor = true;
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
            // groupBoxMessages
            // 
            this.groupBoxMessages.Controls.Add(this.label1);
            this.groupBoxMessages.Controls.Add(this.lblGrosRobot);
            this.groupBoxMessages.Controls.Add(this.checkedListBoxRobots);
            this.groupBoxMessages.Controls.Add(this.checkedListBoxEvents);
            this.groupBoxMessages.Location = new System.Drawing.Point(3, 240);
            this.groupBoxMessages.Name = "groupBoxMessages";
            this.groupBoxMessages.Size = new System.Drawing.Size(407, 167);
            this.groupBoxMessages.TabIndex = 19;
            this.groupBoxMessages.TabStop = false;
            this.groupBoxMessages.Text = "Filtre sur les messages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Type event";
            // 
            // lblGrosRobot
            // 
            this.lblGrosRobot.AutoSize = true;
            this.lblGrosRobot.Location = new System.Drawing.Point(43, 49);
            this.lblGrosRobot.Name = "lblGrosRobot";
            this.lblGrosRobot.Size = new System.Drawing.Size(71, 13);
            this.lblGrosRobot.TabIndex = 19;
            this.lblGrosRobot.Text = "Robot source";
            // 
            // checkedListBoxRobots
            // 
            this.checkedListBoxRobots.CheckOnClick = true;
            this.checkedListBoxRobots.FormattingEnabled = true;
            this.checkedListBoxRobots.Location = new System.Drawing.Point(127, 31);
            this.checkedListBoxRobots.Name = "checkedListBoxRobots";
            this.checkedListBoxRobots.Size = new System.Drawing.Size(177, 49);
            this.checkedListBoxRobots.Sorted = true;
            this.checkedListBoxRobots.TabIndex = 15;
            this.checkedListBoxRobots.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxRobots_ItemCheck);
            // 
            // checkedListBoxEvents
            // 
            this.checkedListBoxEvents.CheckOnClick = true;
            this.checkedListBoxEvents.FormattingEnabled = true;
            this.checkedListBoxEvents.Location = new System.Drawing.Point(127, 86);
            this.checkedListBoxEvents.Name = "checkedListBoxEvents";
            this.checkedListBoxEvents.Size = new System.Drawing.Size(177, 64);
            this.checkedListBoxEvents.Sorted = true;
            this.checkedListBoxEvents.TabIndex = 17;
            this.checkedListBoxEvents.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxEvents_ItemCheck);
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
            // PanelLogsEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.boxScroll);
            this.Controls.Add(this.btnAfficher);
            this.Controls.Add(this.groupBoxMessages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewLog);
            this.Controls.Add(this.btnCharger);
            this.Name = "PanelLogsEvents";
            this.Size = new System.Drawing.Size(1273, 669);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLog)).EndInit();
            this.contextMenuStripRow.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxMessages.ResumeLayout(false);
            this.groupBoxMessages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCharger;
        private System.Windows.Forms.DataGridView dataGridViewLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoRobot;
        private System.Windows.Forms.RadioButton rdoType;
        private System.Windows.Forms.RadioButton rdoAucun;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoTempsDebut;
        private System.Windows.Forms.RadioButton rdoHeure;
        private System.Windows.Forms.RadioButton rdoTempsPrecAff;
        private System.Windows.Forms.RadioButton rdoTempsPrec;
        private System.Windows.Forms.GroupBox groupBoxMessages;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRow;
        private System.Windows.Forms.ToolStripMenuItem nePlusAfficherCeTypeDeMessagesToolStripMenuItem;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.CheckBox boxScroll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGrosRobot;
        private System.Windows.Forms.CheckedListBox checkedListBoxRobots;
        private System.Windows.Forms.CheckedListBox checkedListBoxEvents;

    }
}
