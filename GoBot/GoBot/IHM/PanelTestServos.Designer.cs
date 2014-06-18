namespace GoBot.IHM
{
    partial class PanelTestServos
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
            this.btnChercher = new System.Windows.Forms.Button();
            this.listBoxServos = new System.Windows.Forms.ListBox();
            this.lblScannId = new System.Windows.Forms.Label();
            this.progressBarBaudrate = new System.Windows.Forms.ProgressBar();
            this.progressBarId = new System.Windows.Forms.ProgressBar();
            this.lblScannBaudrate = new System.Windows.Forms.Label();
            this.checkedListBoxBaudrates = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelServo = new GoBot.IHM.PanelServo();
            this.SuspendLayout();
            // 
            // btnChercher
            // 
            this.btnChercher.Location = new System.Drawing.Point(49, 29);
            this.btnChercher.Name = "btnChercher";
            this.btnChercher.Size = new System.Drawing.Size(134, 23);
            this.btnChercher.TabIndex = 1;
            this.btnChercher.Text = "Chercher servomoteurs";
            this.btnChercher.UseVisualStyleBackColor = true;
            this.btnChercher.Click += new System.EventHandler(this.btnChercher_Click);
            // 
            // listBoxServos
            // 
            this.listBoxServos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxServos.FormattingEnabled = true;
            this.listBoxServos.Location = new System.Drawing.Point(6, 255);
            this.listBoxServos.Name = "listBoxServos";
            this.listBoxServos.Size = new System.Drawing.Size(222, 260);
            this.listBoxServos.TabIndex = 2;
            this.listBoxServos.SelectedValueChanged += new System.EventHandler(this.listBoxServos_SelectedValueChanged);
            // 
            // lblScannId
            // 
            this.lblScannId.AutoSize = true;
            this.lblScannId.Location = new System.Drawing.Point(6, 216);
            this.lblScannId.Name = "lblScannId";
            this.lblScannId.Size = new System.Drawing.Size(30, 13);
            this.lblScannId.TabIndex = 3;
            this.lblScannId.Text = "ID : -";
            // 
            // progressBarBaudrate
            // 
            this.progressBarBaudrate.Location = new System.Drawing.Point(95, 231);
            this.progressBarBaudrate.Maximum = 9;
            this.progressBarBaudrate.Name = "progressBarBaudrate";
            this.progressBarBaudrate.Size = new System.Drawing.Size(133, 11);
            this.progressBarBaudrate.TabIndex = 5;
            // 
            // progressBarId
            // 
            this.progressBarId.Location = new System.Drawing.Point(95, 219);
            this.progressBarId.Maximum = 253;
            this.progressBarId.Name = "progressBarId";
            this.progressBarId.Size = new System.Drawing.Size(133, 11);
            this.progressBarId.TabIndex = 6;
            // 
            // lblScannBaudrate
            // 
            this.lblScannBaudrate.AutoSize = true;
            this.lblScannBaudrate.Location = new System.Drawing.Point(6, 229);
            this.lblScannBaudrate.Name = "lblScannBaudrate";
            this.lblScannBaudrate.Size = new System.Drawing.Size(44, 13);
            this.lblScannBaudrate.TabIndex = 7;
            this.lblScannBaudrate.Text = "Baud : -";
            // 
            // checkedListBoxBaudrates
            // 
            this.checkedListBoxBaudrates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxBaudrates.CheckOnClick = true;
            this.checkedListBoxBaudrates.FormattingEnabled = true;
            this.checkedListBoxBaudrates.Location = new System.Drawing.Point(70, 69);
            this.checkedListBoxBaudrates.Name = "checkedListBoxBaudrates";
            this.checkedListBoxBaudrates.Size = new System.Drawing.Size(158, 135);
            this.checkedListBoxBaudrates.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Baudrates :";
            // 
            // panelServo
            // 
            this.panelServo.BackColor = System.Drawing.Color.Transparent;
            this.panelServo.Location = new System.Drawing.Point(234, 19);
            this.panelServo.Name = "panelServo";
            this.panelServo.Size = new System.Drawing.Size(1040, 518);
            this.panelServo.TabIndex = 0;
            // 
            // PanelTestServos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxBaudrates);
            this.Controls.Add(this.lblScannBaudrate);
            this.Controls.Add(this.progressBarId);
            this.Controls.Add(this.progressBarBaudrate);
            this.Controls.Add(this.lblScannId);
            this.Controls.Add(this.listBoxServos);
            this.Controls.Add(this.btnChercher);
            this.Controls.Add(this.panelServo);
            this.Name = "PanelTestServos";
            this.Size = new System.Drawing.Size(1258, 561);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PanelServo panelServo;
        private System.Windows.Forms.Button btnChercher;
        private System.Windows.Forms.ListBox listBoxServos;
        private System.Windows.Forms.Label lblScannId;
        private System.Windows.Forms.ProgressBar progressBarBaudrate;
        private System.Windows.Forms.ProgressBar progressBarId;
        private System.Windows.Forms.Label lblScannBaudrate;
        private System.Windows.Forms.CheckedListBox checkedListBoxBaudrates;
        private System.Windows.Forms.Label label1;

    }
}
