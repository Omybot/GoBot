namespace GoBot.IHM.Pages
{
    partial class PageServomotors
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
            this.grpServoCan = new System.Windows.Forms.GroupBox();
            this.panelServoCan = new GoBot.IHM.PanelServoCan();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelBoardCanServos6 = new GoBot.IHM.PanelBoardCanServos();
            this.panelBoardCanServos5 = new GoBot.IHM.PanelBoardCanServos();
            this.panelBoardCanServos4 = new GoBot.IHM.PanelBoardCanServos();
            this.panelBoardCanServos3 = new GoBot.IHM.PanelBoardCanServos();
            this.panelBoardCanServos2 = new GoBot.IHM.PanelBoardCanServos();
            this.panelBoardCanServos1 = new GoBot.IHM.PanelBoardCanServos();
            this.grpServoCan.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpServoCan
            // 
            this.grpServoCan.Controls.Add(this.panelServoCan);
            this.grpServoCan.Location = new System.Drawing.Point(3, 158);
            this.grpServoCan.Name = "grpServoCan";
            this.grpServoCan.Size = new System.Drawing.Size(608, 511);
            this.grpServoCan.TabIndex = 13;
            this.grpServoCan.TabStop = false;
            this.grpServoCan.Text = "Pilotage de servomoteur";
            // 
            // panelServoCan
            // 
            this.panelServoCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelServoCan.Location = new System.Drawing.Point(3, 16);
            this.panelServoCan.Name = "panelServoCan";
            this.panelServoCan.Size = new System.Drawing.Size(602, 492);
            this.panelServoCan.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelBoardCanServos6);
            this.groupBox1.Controls.Add(this.panelBoardCanServos5);
            this.groupBox1.Controls.Add(this.panelBoardCanServos4);
            this.groupBox1.Controls.Add(this.panelBoardCanServos3);
            this.groupBox1.Controls.Add(this.panelBoardCanServos2);
            this.groupBox1.Controls.Add(this.panelBoardCanServos1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 148);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Liste des servomoteurs";
            // 
            // panelBoardCanServos6
            // 
            this.panelBoardCanServos6.Location = new System.Drawing.Point(678, 12);
            this.panelBoardCanServos6.Name = "panelBoardCanServos6";
            this.panelBoardCanServos6.Size = new System.Drawing.Size(128, 130);
            this.panelBoardCanServos6.TabIndex = 11;
            this.panelBoardCanServos6.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelCan_ServoClick);
            // 
            // panelBoardCanServos5
            // 
            this.panelBoardCanServos5.Location = new System.Drawing.Point(544, 12);
            this.panelBoardCanServos5.Name = "panelBoardCanServos5";
            this.panelBoardCanServos5.Size = new System.Drawing.Size(128, 130);
            this.panelBoardCanServos5.TabIndex = 10;
            this.panelBoardCanServos5.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelCan_ServoClick);
            // 
            // panelBoardCanServos4
            // 
            this.panelBoardCanServos4.Location = new System.Drawing.Point(410, 12);
            this.panelBoardCanServos4.Name = "panelBoardCanServos4";
            this.panelBoardCanServos4.Size = new System.Drawing.Size(128, 130);
            this.panelBoardCanServos4.TabIndex = 9;
            this.panelBoardCanServos4.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelCan_ServoClick);
            // 
            // panelBoardCanServos3
            // 
            this.panelBoardCanServos3.Location = new System.Drawing.Point(276, 12);
            this.panelBoardCanServos3.Name = "panelBoardCanServos3";
            this.panelBoardCanServos3.Size = new System.Drawing.Size(128, 130);
            this.panelBoardCanServos3.TabIndex = 8;
            this.panelBoardCanServos3.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelCan_ServoClick);
            // 
            // panelBoardCanServos2
            // 
            this.panelBoardCanServos2.Location = new System.Drawing.Point(142, 12);
            this.panelBoardCanServos2.Name = "panelBoardCanServos2";
            this.panelBoardCanServos2.Size = new System.Drawing.Size(128, 130);
            this.panelBoardCanServos2.TabIndex = 7;
            this.panelBoardCanServos2.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelCan_ServoClick);
            // 
            // panelBoardCanServos1
            // 
            this.panelBoardCanServos1.Location = new System.Drawing.Point(8, 12);
            this.panelBoardCanServos1.Name = "panelBoardCanServos1";
            this.panelBoardCanServos1.Size = new System.Drawing.Size(128, 130);
            this.panelBoardCanServos1.TabIndex = 6;
            this.panelBoardCanServos1.ServoClick += new GoBot.IHM.PanelBoardCanServos.ServoClickDelegate(this.panelCan_ServoClick);
            // 
            // PageServomotors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpServoCan);
            this.Name = "PageServomotors";
            this.Size = new System.Drawing.Size(1254, 669);
            this.Load += new System.EventHandler(this.PageServomotors_Load);
            this.grpServoCan.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpServoCan;
        private PanelServoCan panelServoCan;
        private System.Windows.Forms.GroupBox groupBox1;
        private PanelBoardCanServos panelBoardCanServos6;
        private PanelBoardCanServos panelBoardCanServos5;
        private PanelBoardCanServos panelBoardCanServos4;
        private PanelBoardCanServos panelBoardCanServos3;
        private PanelBoardCanServos panelBoardCanServos2;
        private PanelBoardCanServos panelBoardCanServos1;
    }
}
