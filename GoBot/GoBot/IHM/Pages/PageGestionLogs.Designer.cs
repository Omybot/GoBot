namespace GoBot.IHM.Pages
{
    partial class PageGestionLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxEfface = new System.Windows.Forms.GroupBox();
            this.lblTxtJours = new System.Windows.Forms.Label();
            this.numJoursSuppr = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.boxActiverSuppression = new System.Windows.Forms.CheckBox();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.lblTailleTotale = new System.Windows.Forms.Label();
            this.lblNombreLogs = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDatePlusVieux = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewHistoLog = new System.Windows.Forms.DataGridView();
            this.btnOuvrirDossier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.dataGridViewFichiersLog = new System.Windows.Forms.DataGridView();
            this.Fichier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chemin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFichiers = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnArchivage = new System.Windows.Forms.Button();
            this.dataGridViewArchives = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxEfface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJoursSuppr)).BeginInit();
            this.groupBoxStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFichiersLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchives)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxEfface
            // 
            this.groupBoxEfface.Controls.Add(this.lblTxtJours);
            this.groupBoxEfface.Controls.Add(this.numJoursSuppr);
            this.groupBoxEfface.Controls.Add(this.label1);
            this.groupBoxEfface.Controls.Add(this.boxActiverSuppression);
            this.groupBoxEfface.Location = new System.Drawing.Point(3, 3);
            this.groupBoxEfface.Name = "groupBoxEfface";
            this.groupBoxEfface.Size = new System.Drawing.Size(288, 118);
            this.groupBoxEfface.TabIndex = 0;
            this.groupBoxEfface.TabStop = false;
            this.groupBoxEfface.Text = "Suppression automatique";
            // 
            // lblTxtJours
            // 
            this.lblTxtJours.AutoSize = true;
            this.lblTxtJours.Location = new System.Drawing.Point(237, 73);
            this.lblTxtJours.Name = "lblTxtJours";
            this.lblTxtJours.Size = new System.Drawing.Size(29, 13);
            this.lblTxtJours.TabIndex = 1;
            this.lblTxtJours.Text = "jours";
            // 
            // numJoursSuppr
            // 
            this.numJoursSuppr.Location = new System.Drawing.Point(182, 71);
            this.numJoursSuppr.Name = "numJoursSuppr";
            this.numJoursSuppr.Size = new System.Drawing.Size(49, 20);
            this.numJoursSuppr.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supprimer les logs agés de plus de";
            // 
            // boxActiverSuppression
            // 
            this.boxActiverSuppression.AutoSize = true;
            this.boxActiverSuppression.Location = new System.Drawing.Point(20, 34);
            this.boxActiverSuppression.Name = "boxActiverSuppression";
            this.boxActiverSuppression.Size = new System.Drawing.Size(190, 17);
            this.boxActiverSuppression.TabIndex = 1;
            this.boxActiverSuppression.Text = "Activer la suppression automatique";
            this.boxActiverSuppression.UseVisualStyleBackColor = true;
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Controls.Add(this.lblTailleTotale);
            this.groupBoxStats.Controls.Add(this.lblNombreLogs);
            this.groupBoxStats.Controls.Add(this.label4);
            this.groupBoxStats.Controls.Add(this.lblDatePlusVieux);
            this.groupBoxStats.Controls.Add(this.label3);
            this.groupBoxStats.Controls.Add(this.label2);
            this.groupBoxStats.Location = new System.Drawing.Point(3, 127);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(288, 136);
            this.groupBoxStats.TabIndex = 1;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Statistiques";
            // 
            // lblTailleTotale
            // 
            this.lblTailleTotale.AutoSize = true;
            this.lblTailleTotale.Location = new System.Drawing.Point(151, 103);
            this.lblTailleTotale.Name = "lblTailleTotale";
            this.lblTailleTotale.Size = new System.Drawing.Size(10, 13);
            this.lblTailleTotale.TabIndex = 13;
            this.lblTailleTotale.Text = "-";
            // 
            // lblNombreLogs
            // 
            this.lblNombreLogs.AutoSize = true;
            this.lblNombreLogs.Location = new System.Drawing.Point(151, 67);
            this.lblNombreLogs.Name = "lblNombreLogs";
            this.lblNombreLogs.Size = new System.Drawing.Size(10, 13);
            this.lblNombreLogs.TabIndex = 12;
            this.lblNombreLogs.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Taille totale :";
            // 
            // lblDatePlusVieux
            // 
            this.lblDatePlusVieux.AutoSize = true;
            this.lblDatePlusVieux.Location = new System.Drawing.Point(151, 33);
            this.lblDatePlusVieux.Name = "lblDatePlusVieux";
            this.lblDatePlusVieux.Size = new System.Drawing.Size(10, 13);
            this.lblDatePlusVieux.TabIndex = 10;
            this.lblDatePlusVieux.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre logs :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plus vieux log :";
            // 
            // dataGridViewHistoLog
            // 
            this.dataGridViewHistoLog.AllowUserToAddRows = false;
            this.dataGridViewHistoLog.AllowUserToDeleteRows = false;
            this.dataGridViewHistoLog.AllowUserToOrderColumns = true;
            this.dataGridViewHistoLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dataGridViewHistoLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHistoLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewHistoLog.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewHistoLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewHistoLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistoLog.Location = new System.Drawing.Point(297, 29);
            this.dataGridViewHistoLog.Name = "dataGridViewHistoLog";
            this.dataGridViewHistoLog.ReadOnly = true;
            this.dataGridViewHistoLog.RowHeadersVisible = false;
            this.dataGridViewHistoLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistoLog.Size = new System.Drawing.Size(628, 416);
            this.dataGridViewHistoLog.TabIndex = 2;
            this.dataGridViewHistoLog.SelectionChanged += new System.EventHandler(this.dataGridViewHistoLog_SelectionChanged);
            // 
            // btnOuvrirDossier
            // 
            this.btnOuvrirDossier.Location = new System.Drawing.Point(951, 37);
            this.btnOuvrirDossier.Name = "btnOuvrirDossier";
            this.btnOuvrirDossier.Size = new System.Drawing.Size(113, 23);
            this.btnOuvrirDossier.TabIndex = 3;
            this.btnOuvrirDossier.Text = "Ouvrir le dossier";
            this.btnOuvrirDossier.UseVisualStyleBackColor = true;
            this.btnOuvrirDossier.Click += new System.EventHandler(this.btnOuvrirDossier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(951, 66);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(113, 23);
            this.btnSupprimer.TabIndex = 4;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // dataGridViewFichiersLog
            // 
            this.dataGridViewFichiersLog.AllowUserToAddRows = false;
            this.dataGridViewFichiersLog.AllowUserToDeleteRows = false;
            this.dataGridViewFichiersLog.AllowUserToOrderColumns = true;
            this.dataGridViewFichiersLog.AllowUserToResizeRows = false;
            this.dataGridViewFichiersLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewFichiersLog.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFichiersLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewFichiersLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFichiersLog.ColumnHeadersVisible = false;
            this.dataGridViewFichiersLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fichier,
            this.Chemin});
            this.dataGridViewFichiersLog.Location = new System.Drawing.Point(951, 194);
            this.dataGridViewFichiersLog.Name = "dataGridViewFichiersLog";
            this.dataGridViewFichiersLog.ReadOnly = true;
            this.dataGridViewFichiersLog.RowHeadersVisible = false;
            this.dataGridViewFichiersLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFichiersLog.Size = new System.Drawing.Size(155, 206);
            this.dataGridViewFichiersLog.TabIndex = 6;
            this.dataGridViewFichiersLog.DoubleClick += new System.EventHandler(this.dataGridViewFichiersLog_DoubleClick);
            // 
            // Fichier
            // 
            this.Fichier.HeaderText = "Fichier";
            this.Fichier.Name = "Fichier";
            this.Fichier.ReadOnly = true;
            this.Fichier.Width = 5;
            // 
            // Chemin
            // 
            this.Chemin.HeaderText = "Chemin";
            this.Chemin.Name = "Chemin";
            this.Chemin.ReadOnly = true;
            this.Chemin.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Historique logs :";
            // 
            // lblFichiers
            // 
            this.lblFichiers.AutoSize = true;
            this.lblFichiers.Location = new System.Drawing.Point(931, 166);
            this.lblFichiers.Name = "lblFichiers";
            this.lblFichiers.Size = new System.Drawing.Size(49, 13);
            this.lblFichiers.TabIndex = 9;
            this.lblFichiers.Text = "Fichiers :";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 269);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(291, 23);
            this.progressBar.TabIndex = 10;
            // 
            // btnArchivage
            // 
            this.btnArchivage.Location = new System.Drawing.Point(951, 98);
            this.btnArchivage.Name = "btnArchivage";
            this.btnArchivage.Size = new System.Drawing.Size(113, 23);
            this.btnArchivage.TabIndex = 11;
            this.btnArchivage.Text = "Archiver";
            this.btnArchivage.UseVisualStyleBackColor = true;
            this.btnArchivage.Click += new System.EventHandler(this.btnArchivage_Click);
            // 
            // dataGridViewArchives
            // 
            this.dataGridViewArchives.AllowUserToAddRows = false;
            this.dataGridViewArchives.AllowUserToDeleteRows = false;
            this.dataGridViewArchives.AllowUserToOrderColumns = true;
            this.dataGridViewArchives.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dataGridViewArchives.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewArchives.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewArchives.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewArchives.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewArchives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArchives.Location = new System.Drawing.Point(297, 482);
            this.dataGridViewArchives.Name = "dataGridViewArchives";
            this.dataGridViewArchives.ReadOnly = true;
            this.dataGridViewArchives.RowHeadersVisible = false;
            this.dataGridViewArchives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArchives.Size = new System.Drawing.Size(745, 211);
            this.dataGridViewArchives.TabIndex = 12;
            this.dataGridViewArchives.SelectionChanged += new System.EventHandler(this.dataGridViewArchives_SelectionChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Archives :";
            // 
            // PanelGestionLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewArchives);
            this.Controls.Add(this.btnArchivage);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblFichiers);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridViewFichiersLog);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnOuvrirDossier);
            this.Controls.Add(this.dataGridViewHistoLog);
            this.Controls.Add(this.groupBoxStats);
            this.Controls.Add(this.groupBoxEfface);
            this.Name = "PanelGestionLog";
            this.Size = new System.Drawing.Size(1109, 577);
            this.Load += new System.EventHandler(this.PanelGestionLog_Load);
            this.groupBoxEfface.ResumeLayout(false);
            this.groupBoxEfface.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJoursSuppr)).EndInit();
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFichiersLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchives)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEfface;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox boxActiverSuppression;
        private System.Windows.Forms.Label lblTxtJours;
        private System.Windows.Forms.NumericUpDown numJoursSuppr;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewHistoLog;
        private System.Windows.Forms.Button btnOuvrirDossier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.DataGridView dataGridViewFichiersLog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fichier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chemin;
        private System.Windows.Forms.Label lblFichiers;
        private System.Windows.Forms.Label lblTailleTotale;
        private System.Windows.Forms.Label lblNombreLogs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDatePlusVieux;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnArchivage;
        private System.Windows.Forms.DataGridView dataGridViewArchives;
        private System.Windows.Forms.Label label5;

    }
}
