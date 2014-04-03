namespace GoBot.IHM
{
    partial class PanelGestionLog
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
            this.groupBoxEfface = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boxActiverSuppression = new System.Windows.Forms.CheckBox();
            this.numJoursSuppr = new System.Windows.Forms.NumericUpDown();
            this.lblTxtJours = new System.Windows.Forms.Label();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewHistoLog = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewFichiersLog = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxEfface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJoursSuppr)).BeginInit();
            this.groupBoxStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFichiersLog)).BeginInit();
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
            // numJoursSuppr
            // 
            this.numJoursSuppr.Location = new System.Drawing.Point(182, 71);
            this.numJoursSuppr.Name = "numJoursSuppr";
            this.numJoursSuppr.Size = new System.Drawing.Size(49, 20);
            this.numJoursSuppr.TabIndex = 1;
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
            // groupBoxStats
            // 
            this.groupBoxStats.Controls.Add(this.label5);
            this.groupBoxStats.Controls.Add(this.label4);
            this.groupBoxStats.Controls.Add(this.label3);
            this.groupBoxStats.Controls.Add(this.label2);
            this.groupBoxStats.Location = new System.Drawing.Point(3, 127);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(288, 190);
            this.groupBoxStats.TabIndex = 1;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Statistiques";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre logs :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombre logs supprimés :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre logs archivés :";
            // 
            // dataGridViewHistoLog
            // 
            this.dataGridViewHistoLog.AllowUserToAddRows = false;
            this.dataGridViewHistoLog.AllowUserToDeleteRows = false;
            this.dataGridViewHistoLog.AllowUserToOrderColumns = true;
            this.dataGridViewHistoLog.AllowUserToResizeRows = false;
            this.dataGridViewHistoLog.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewHistoLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewHistoLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistoLog.Location = new System.Drawing.Point(297, 32);
            this.dataGridViewHistoLog.Name = "dataGridViewHistoLog";
            this.dataGridViewHistoLog.ReadOnly = true;
            this.dataGridViewHistoLog.RowHeadersVisible = false;
            this.dataGridViewHistoLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistoLog.Size = new System.Drawing.Size(628, 628);
            this.dataGridViewHistoLog.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(931, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ouvrir le dossier";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(931, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Supprimer";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(931, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Archivage";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFichiersLog
            // 
            this.dataGridViewFichiersLog.AllowUserToAddRows = false;
            this.dataGridViewFichiersLog.AllowUserToDeleteRows = false;
            this.dataGridViewFichiersLog.AllowUserToOrderColumns = true;
            this.dataGridViewFichiersLog.AllowUserToResizeRows = false;
            this.dataGridViewFichiersLog.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFichiersLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewFichiersLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFichiersLog.Location = new System.Drawing.Point(931, 126);
            this.dataGridViewFichiersLog.Name = "dataGridViewFichiersLog";
            this.dataGridViewFichiersLog.ReadOnly = true;
            this.dataGridViewFichiersLog.RowHeadersVisible = false;
            this.dataGridViewFichiersLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFichiersLog.Size = new System.Drawing.Size(113, 117);
            this.dataGridViewFichiersLog.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(940, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Fichiers logs :";
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
            // PanelGestionLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewFichiersLog);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewHistoLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridViewFichiersLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

    }
}
