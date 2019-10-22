namespace GoBot.IHM.Pages
{
    partial class PagePepperl
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
            this.cboFreq = new System.Windows.Forms.ComboBox();
            this.btnText = new System.Windows.Forms.Button();
            this.txtText2 = new System.Windows.Forms.TextBox();
            this.txtText1 = new System.Windows.Forms.TextBox();
            this.btnReboot = new System.Windows.Forms.Button();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.numFilter = new System.Windows.Forms.NumericUpDown();
            this.lblFreq = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblFilterPoints = new System.Windows.Forms.Label();
            this.lblText1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPointsTxt = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblResolutionTxt = new System.Windows.Forms.Label();
            this.lblResolution = new System.Windows.Forms.Label();
            this.lblDistPoints = new System.Windows.Forms.Label();
            this.lblDistPointsTxt = new System.Windows.Forms.Label();
            this.grpText = new System.Windows.Forms.GroupBox();
            this.grpDetection = new System.Windows.Forms.GroupBox();
            this.grpInfos = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numFilter)).BeginInit();
            this.grpText.SuspendLayout();
            this.grpDetection.SuspendLayout();
            this.grpInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboFreq
            // 
            this.cboFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFreq.FormattingEnabled = true;
            this.cboFreq.Location = new System.Drawing.Point(76, 25);
            this.cboFreq.Name = "cboFreq";
            this.cboFreq.Size = new System.Drawing.Size(92, 21);
            this.cboFreq.TabIndex = 2;
            this.cboFreq.SelectedValueChanged += new System.EventHandler(this.cboFreq_SelectedValueChanged);
            // 
            // btnText
            // 
            this.btnText.Location = new System.Drawing.Point(116, 71);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(100, 23);
            this.btnText.TabIndex = 8;
            this.btnText.Text = "Afficher";
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // txtText2
            // 
            this.txtText2.Location = new System.Drawing.Point(84, 45);
            this.txtText2.Name = "txtText2";
            this.txtText2.Size = new System.Drawing.Size(165, 20);
            this.txtText2.TabIndex = 7;
            this.txtText2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtText1
            // 
            this.txtText1.Location = new System.Drawing.Point(84, 19);
            this.txtText1.Name = "txtText1";
            this.txtText1.Size = new System.Drawing.Size(165, 20);
            this.txtText1.TabIndex = 6;
            this.txtText1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReboot
            // 
            this.btnReboot.Location = new System.Drawing.Point(89, 22);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(75, 23);
            this.btnReboot.TabIndex = 9;
            this.btnReboot.Text = "Reboot";
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.btnReboot_Click);
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(76, 56);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(92, 21);
            this.cboFilter.TabIndex = 10;
            this.cboFilter.SelectedValueChanged += new System.EventHandler(this.cboFilter_SelectedValueChanged);
            // 
            // numFilter
            // 
            this.numFilter.Location = new System.Drawing.Point(174, 56);
            this.numFilter.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numFilter.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numFilter.Name = "numFilter";
            this.numFilter.Size = new System.Drawing.Size(33, 20);
            this.numFilter.TabIndex = 11;
            this.numFilter.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numFilter.Visible = false;
            this.numFilter.ValueChanged += new System.EventHandler(this.numFilter_ValueChanged);
            // 
            // lblFreq
            // 
            this.lblFreq.AutoSize = true;
            this.lblFreq.Location = new System.Drawing.Point(6, 28);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(64, 13);
            this.lblFreq.TabIndex = 12;
            this.lblFreq.Text = "Fréquence :";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(6, 59);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(35, 13);
            this.lblFilter.TabIndex = 13;
            this.lblFilter.Text = "Filtre :";
            // 
            // lblFilterPoints
            // 
            this.lblFilterPoints.AutoSize = true;
            this.lblFilterPoints.Location = new System.Drawing.Point(213, 59);
            this.lblFilterPoints.Name = "lblFilterPoints";
            this.lblFilterPoints.Size = new System.Drawing.Size(36, 13);
            this.lblFilterPoints.TabIndex = 14;
            this.lblFilterPoints.Text = "Points";
            this.lblFilterPoints.Visible = false;
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Location = new System.Drawing.Point(15, 22);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(63, 13);
            this.lblText1.TabIndex = 16;
            this.lblText1.Text = "Ligne haut :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ligne bas :";
            // 
            // lblPointsTxt
            // 
            this.lblPointsTxt.AutoSize = true;
            this.lblPointsTxt.Location = new System.Drawing.Point(6, 89);
            this.lblPointsTxt.Name = "lblPointsTxt";
            this.lblPointsTxt.Size = new System.Drawing.Size(135, 13);
            this.lblPointsTxt.TabIndex = 18;
            this.lblPointsTxt.Text = "Nombre de points par tour :";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(147, 89);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(10, 13);
            this.lblPoints.TabIndex = 19;
            this.lblPoints.Text = "-";
            // 
            // lblResolutionTxt
            // 
            this.lblResolutionTxt.AutoSize = true;
            this.lblResolutionTxt.Location = new System.Drawing.Point(6, 107);
            this.lblResolutionTxt.Name = "lblResolutionTxt";
            this.lblResolutionTxt.Size = new System.Drawing.Size(63, 13);
            this.lblResolutionTxt.TabIndex = 20;
            this.lblResolutionTxt.Text = "Résolution :";
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(147, 107);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(10, 13);
            this.lblResolution.TabIndex = 21;
            this.lblResolution.Text = "-";
            // 
            // lblDistPoints
            // 
            this.lblDistPoints.AutoSize = true;
            this.lblDistPoints.Location = new System.Drawing.Point(147, 126);
            this.lblDistPoints.Name = "lblDistPoints";
            this.lblDistPoints.Size = new System.Drawing.Size(10, 13);
            this.lblDistPoints.TabIndex = 23;
            this.lblDistPoints.Text = "-";
            // 
            // lblDistPointsTxt
            // 
            this.lblDistPointsTxt.AutoSize = true;
            this.lblDistPointsTxt.Location = new System.Drawing.Point(6, 126);
            this.lblDistPointsTxt.Name = "lblDistPointsTxt";
            this.lblDistPointsTxt.Size = new System.Drawing.Size(135, 13);
            this.lblDistPointsTxt.TabIndex = 22;
            this.lblDistPointsTxt.Text = "Distance inter-points à 3m :";
            // 
            // grpText
            // 
            this.grpText.Controls.Add(this.txtText1);
            this.grpText.Controls.Add(this.txtText2);
            this.grpText.Controls.Add(this.btnText);
            this.grpText.Controls.Add(this.lblText1);
            this.grpText.Controls.Add(this.label1);
            this.grpText.Location = new System.Drawing.Point(25, 23);
            this.grpText.Name = "grpText";
            this.grpText.Size = new System.Drawing.Size(256, 105);
            this.grpText.TabIndex = 24;
            this.grpText.TabStop = false;
            this.grpText.Text = "Affichage texte";
            // 
            // grpDetection
            // 
            this.grpDetection.Controls.Add(this.lblFreq);
            this.grpDetection.Controls.Add(this.cboFreq);
            this.grpDetection.Controls.Add(this.lblDistPoints);
            this.grpDetection.Controls.Add(this.cboFilter);
            this.grpDetection.Controls.Add(this.lblDistPointsTxt);
            this.grpDetection.Controls.Add(this.numFilter);
            this.grpDetection.Controls.Add(this.lblResolution);
            this.grpDetection.Controls.Add(this.lblFilter);
            this.grpDetection.Controls.Add(this.lblResolutionTxt);
            this.grpDetection.Controls.Add(this.lblFilterPoints);
            this.grpDetection.Controls.Add(this.lblPoints);
            this.grpDetection.Controls.Add(this.lblPointsTxt);
            this.grpDetection.Location = new System.Drawing.Point(25, 134);
            this.grpDetection.Name = "grpDetection";
            this.grpDetection.Size = new System.Drawing.Size(256, 169);
            this.grpDetection.TabIndex = 25;
            this.grpDetection.TabStop = false;
            this.grpDetection.Text = "Détection";
            // 
            // grpInfos
            // 
            this.grpInfos.Controls.Add(this.btnReboot);
            this.grpInfos.Location = new System.Drawing.Point(287, 23);
            this.grpInfos.Name = "grpInfos";
            this.grpInfos.Size = new System.Drawing.Size(259, 280);
            this.grpInfos.TabIndex = 26;
            this.grpInfos.TabStop = false;
            this.grpInfos.Text = "Informations";
            // 
            // PagePepperl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpInfos);
            this.Controls.Add(this.grpDetection);
            this.Controls.Add(this.grpText);
            this.Name = "PagePepperl";
            this.Size = new System.Drawing.Size(820, 572);
            this.Load += new System.EventHandler(this.PagePepperl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFilter)).EndInit();
            this.grpText.ResumeLayout(false);
            this.grpText.PerformLayout();
            this.grpDetection.ResumeLayout(false);
            this.grpDetection.PerformLayout();
            this.grpInfos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFreq;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.TextBox txtText2;
        private System.Windows.Forms.TextBox txtText1;
        private System.Windows.Forms.Button btnReboot;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.NumericUpDown numFilter;
        private System.Windows.Forms.Label lblFreq;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblFilterPoints;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPointsTxt;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblResolutionTxt;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Label lblDistPoints;
        private System.Windows.Forms.Label lblDistPointsTxt;
        private System.Windows.Forms.GroupBox grpText;
        private System.Windows.Forms.GroupBox grpDetection;
        private System.Windows.Forms.GroupBox grpInfos;
    }
}
