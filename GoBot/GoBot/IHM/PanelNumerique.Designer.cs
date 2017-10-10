namespace GoBot.IHM
{
    partial class PanelNumerique
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
            this.lblEnable = new System.Windows.Forms.Label();
            this.switchOnOff = new Composants.SwitchBouton();
            this.graph1 = new Composants.ByteBinaryGraph();
            this.graph2 = new Composants.ByteBinaryGraph();
            this.SuspendLayout();
            // 
            // lblEnable
            // 
            this.lblEnable.AutoSize = true;
            this.lblEnable.Location = new System.Drawing.Point(118, 36);
            this.lblEnable.Name = "lblEnable";
            this.lblEnable.Size = new System.Drawing.Size(28, 13);
            this.lblEnable.TabIndex = 49;
            this.lblEnable.Text = "Actif";
            // 
            // switchOnOff
            // 
            this.switchOnOff.BackColor = System.Drawing.Color.Transparent;
            this.switchOnOff.Location = new System.Drawing.Point(162, 36);
            this.switchOnOff.Name = "switchOnOff";
            this.switchOnOff.Size = new System.Drawing.Size(35, 15);
            this.switchOnOff.Symetrique = true;
            this.switchOnOff.TabIndex = 35;
            this.switchOnOff.ChangementEtat += new System.EventHandler(this.switchBouton_ChangementEtat);
            // 
            // graph1
            // 
            this.graph1.BackColor = System.Drawing.Color.Transparent;
            this.graph1.Location = new System.Drawing.Point(26, 82);
            this.graph1.Name = "graph1";
            this.graph1.Size = new System.Drawing.Size(259, 208);
            this.graph1.TabIndex = 50;
            // 
            // graph2
            // 
            this.graph2.BackColor = System.Drawing.Color.Transparent;
            this.graph2.Location = new System.Drawing.Point(26, 290);
            this.graph2.Name = "graph2";
            this.graph2.Size = new System.Drawing.Size(259, 208);
            this.graph2.TabIndex = 51;
            // 
            // PanelNumerique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.graph2);
            this.Controls.Add(this.graph1);
            this.Controls.Add(this.lblEnable);
            this.Controls.Add(this.switchOnOff);
            this.Name = "PanelNumerique";
            this.Size = new System.Drawing.Size(327, 533);
            this.Load += new System.EventHandler(this.PanelNumerique_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Composants.SwitchBouton switchOnOff;
        private System.Windows.Forms.Label lblEnable;
        private Composants.ByteBinaryGraph graph1;
        private Composants.ByteBinaryGraph graph2;
    }
}
