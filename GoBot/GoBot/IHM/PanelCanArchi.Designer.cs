namespace GoBot.IHM
{
    partial class PanelCanArchi
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
            this.panelBoardCanServos1 = new GoBot.IHM.PanelBoardCanServos();
            this.panelBoardCanServos2 = new GoBot.IHM.PanelBoardCanServos();
            this.panelBoardCanServos3 = new GoBot.IHM.PanelBoardCanServos();
            this.panelBoardCanServos4 = new GoBot.IHM.PanelBoardCanServos();
            this.panelBoardCanServos5 = new GoBot.IHM.PanelBoardCanServos();
            this.SuspendLayout();
            // 
            // panelBoardCanServos1
            // 
            this.panelBoardCanServos1.BoardID = 1;
            this.panelBoardCanServos1.Location = new System.Drawing.Point(3, 3);
            this.panelBoardCanServos1.Name = "panelBoardCanServos1";
            this.panelBoardCanServos1.Size = new System.Drawing.Size(128, 137);
            this.panelBoardCanServos1.TabIndex = 0;
            this.panelBoardCanServos1.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelBoardCanServos_ServoClick);
            // 
            // panelBoardCanServos2
            // 
            this.panelBoardCanServos2.BoardID = 2;
            this.panelBoardCanServos2.Location = new System.Drawing.Point(137, 3);
            this.panelBoardCanServos2.Name = "panelBoardCanServos2";
            this.panelBoardCanServos2.Size = new System.Drawing.Size(128, 137);
            this.panelBoardCanServos2.TabIndex = 1;
            this.panelBoardCanServos2.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelBoardCanServos_ServoClick);
            // 
            // panelBoardCanServos3
            // 
            this.panelBoardCanServos3.BoardID = 3;
            this.panelBoardCanServos3.Location = new System.Drawing.Point(271, 3);
            this.panelBoardCanServos3.Name = "panelBoardCanServos3";
            this.panelBoardCanServos3.Size = new System.Drawing.Size(128, 137);
            this.panelBoardCanServos3.TabIndex = 2;
            this.panelBoardCanServos3.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelBoardCanServos_ServoClick);
            // 
            // panelBoardCanServos4
            // 
            this.panelBoardCanServos4.BoardID = 4;
            this.panelBoardCanServos4.Location = new System.Drawing.Point(405, 3);
            this.panelBoardCanServos4.Name = "panelBoardCanServos4";
            this.panelBoardCanServos4.Size = new System.Drawing.Size(128, 137);
            this.panelBoardCanServos4.TabIndex = 3;
            this.panelBoardCanServos4.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelBoardCanServos_ServoClick);
            // 
            // panelBoardCanServos5
            // 
            this.panelBoardCanServos5.BoardID = 5;
            this.panelBoardCanServos5.Location = new System.Drawing.Point(539, 3);
            this.panelBoardCanServos5.Name = "panelBoardCanServos5";
            this.panelBoardCanServos5.Size = new System.Drawing.Size(128, 137);
            this.panelBoardCanServos5.TabIndex = 4;
            this.panelBoardCanServos5.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelBoardCanServos_ServoClick);
            // 
            // PanelCanArchi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBoardCanServos5);
            this.Controls.Add(this.panelBoardCanServos4);
            this.Controls.Add(this.panelBoardCanServos3);
            this.Controls.Add(this.panelBoardCanServos2);
            this.Controls.Add(this.panelBoardCanServos1);
            this.Name = "PanelCanArchi";
            this.Size = new System.Drawing.Size(672, 143);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelBoardCanServos panelBoardCanServos1;
        private PanelBoardCanServos panelBoardCanServos2;
        private PanelBoardCanServos panelBoardCanServos3;
        private PanelBoardCanServos panelBoardCanServos4;
        private PanelBoardCanServos panelBoardCanServos5;
    }
}
