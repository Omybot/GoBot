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
            this.panelServo = new GoBot.IHM.PanelServo();
            this.btnChercher = new System.Windows.Forms.Button();
            this.listBoxServos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // panelServo1
            // 
            this.panelServo.BackColor = System.Drawing.Color.Transparent;
            this.panelServo.Location = new System.Drawing.Point(273, 44);
            this.panelServo.Name = "panelServo1";
            this.panelServo.Size = new System.Drawing.Size(814, 467);
            this.panelServo.TabIndex = 0;
            // 
            // btnChercher
            // 
            this.btnChercher.Location = new System.Drawing.Point(24, 44);
            this.btnChercher.Name = "btnChercher";
            this.btnChercher.Size = new System.Drawing.Size(134, 23);
            this.btnChercher.TabIndex = 1;
            this.btnChercher.Text = "Chercher servomoteurs";
            this.btnChercher.UseVisualStyleBackColor = true;
            this.btnChercher.Click += new System.EventHandler(this.btnChercher_Click);
            // 
            // listBoxServos
            // 
            this.listBoxServos.FormattingEnabled = true;
            this.listBoxServos.Location = new System.Drawing.Point(24, 87);
            this.listBoxServos.Name = "listBoxServos";
            this.listBoxServos.Size = new System.Drawing.Size(134, 186);
            this.listBoxServos.TabIndex = 2;
            this.listBoxServos.SelectedValueChanged += new System.EventHandler(this.listBoxServos_SelectedValueChanged);
            // 
            // PanelTestServos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxServos);
            this.Controls.Add(this.btnChercher);
            this.Controls.Add(this.panelServo);
            this.Name = "PanelTestServos";
            this.Size = new System.Drawing.Size(1202, 561);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelServo panelServo;
        private System.Windows.Forms.Button btnChercher;
        private System.Windows.Forms.ListBox listBoxServos;

    }
}
