namespace GoBot.IHM.Pages
{
    partial class PagePandaLidar
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagePandaLidar));
            this.boxGroup = new System.Windows.Forms.CheckBox();
            this.cboLidar = new System.Windows.Forms.ComboBox();
            this.btnTrap = new System.Windows.Forms.Button();
            this.btnEnableBoard = new System.Windows.Forms.Button();
            this.btnPoints = new System.Windows.Forms.Button();
            this.btnZoomReset = new System.Windows.Forms.Button();
            this.btnZoomMinus = new System.Windows.Forms.Button();
            this.btnZoomPlus = new System.Windows.Forms.Button();
            this.picWorld = new GoBot.IHM.WorldPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // boxGroup
            // 
            this.boxGroup.AutoSize = true;
            this.boxGroup.Location = new System.Drawing.Point(16, 51);
            this.boxGroup.Name = "boxGroup";
            this.boxGroup.Size = new System.Drawing.Size(64, 17);
            this.boxGroup.TabIndex = 9;
            this.boxGroup.Text = "Grouper";
            this.boxGroup.UseVisualStyleBackColor = true;
            // 
            // cboLidar
            // 
            this.cboLidar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLidar.FormattingEnabled = true;
            this.cboLidar.Location = new System.Drawing.Point(5, 3);
            this.cboLidar.Name = "cboLidar";
            this.cboLidar.Size = new System.Drawing.Size(96, 21);
            this.cboLidar.TabIndex = 18;
            this.cboLidar.SelectedIndexChanged += new System.EventHandler(this.cboLidar_SelectedIndexChanged);
            // 
            // btnTrap
            // 
            this.btnTrap.Location = new System.Drawing.Point(0, -29);
            this.btnTrap.Name = "btnTrap";
            this.btnTrap.Size = new System.Drawing.Size(23, 23);
            this.btnTrap.TabIndex = 24;
            this.btnTrap.UseVisualStyleBackColor = true;
            // 
            // btnEnableBoard
            // 
            this.btnEnableBoard.BackColor = System.Drawing.Color.Transparent;
            this.btnEnableBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnEnableBoard.Image = global::GoBot.Properties.Resources.LidarBoardOn;
            this.btnEnableBoard.Location = new System.Drawing.Point(19, 78);
            this.btnEnableBoard.Name = "btnEnableBoard";
            this.btnEnableBoard.Size = new System.Drawing.Size(75, 75);
            this.btnEnableBoard.TabIndex = 25;
            this.btnEnableBoard.UseVisualStyleBackColor = false;
            this.btnEnableBoard.Click += new System.EventHandler(this.btnEnableBoard_Click);
            // 
            // btnPoints
            // 
            this.btnPoints.BackColor = System.Drawing.Color.Transparent;
            this.btnPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnPoints.Image = global::GoBot.Properties.Resources.LidarPointsOn;
            this.btnPoints.Location = new System.Drawing.Point(19, 159);
            this.btnPoints.Name = "btnPoints";
            this.btnPoints.Size = new System.Drawing.Size(75, 75);
            this.btnPoints.TabIndex = 23;
            this.btnPoints.UseVisualStyleBackColor = false;
            this.btnPoints.Click += new System.EventHandler(this.btnPoints_Click);
            // 
            // btnZoomReset
            // 
            this.btnZoomReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnZoomReset.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomReset.Image")));
            this.btnZoomReset.Location = new System.Drawing.Point(19, 507);
            this.btnZoomReset.Name = "btnZoomReset";
            this.btnZoomReset.Size = new System.Drawing.Size(75, 75);
            this.btnZoomReset.TabIndex = 21;
            this.btnZoomReset.UseVisualStyleBackColor = true;
            this.btnZoomReset.Click += new System.EventHandler(this.btnZoomReset_Click);
            // 
            // btnZoomMinus
            // 
            this.btnZoomMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnZoomMinus.Image = global::GoBot.Properties.Resources.ZoomMinus;
            this.btnZoomMinus.Location = new System.Drawing.Point(19, 426);
            this.btnZoomMinus.Name = "btnZoomMinus";
            this.btnZoomMinus.Size = new System.Drawing.Size(75, 75);
            this.btnZoomMinus.TabIndex = 20;
            this.btnZoomMinus.UseVisualStyleBackColor = true;
            this.btnZoomMinus.Click += new System.EventHandler(this.btnZoomMinus_Click);
            // 
            // btnZoomPlus
            // 
            this.btnZoomPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnZoomPlus.Image = global::GoBot.Properties.Resources.ZoomPlus;
            this.btnZoomPlus.Location = new System.Drawing.Point(19, 345);
            this.btnZoomPlus.Name = "btnZoomPlus";
            this.btnZoomPlus.Size = new System.Drawing.Size(75, 75);
            this.btnZoomPlus.TabIndex = 19;
            this.btnZoomPlus.UseVisualStyleBackColor = true;
            this.btnZoomPlus.Click += new System.EventHandler(this.btnZoomPlus_Click);
            // 
            // picWorld
            // 
            this.picWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picWorld.Location = new System.Drawing.Point(110, 16);
            this.picWorld.Name = "picWorld";
            this.picWorld.Size = new System.Drawing.Size(900, 568);
            this.picWorld.TabIndex = 11;
            this.picWorld.TabStop = false;
            this.picWorld.WorldChange += new GoBot.IHM.WorldPanel.WorldChangeDelegate(this.picWorld_WorldChange);
            this.picWorld.StartMove += new GoBot.IHM.WorldPanel.StartMoveDelegate(this.picWorld_StartMove);
            this.picWorld.StopMove += new GoBot.IHM.WorldPanel.StopMoveDelegate(this.picWorld_StopMove);
            this.picWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.picWorld_Paint);
            // 
            // PagePandaLidar
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnEnableBoard);
            this.Controls.Add(this.btnTrap);
            this.Controls.Add(this.btnPoints);
            this.Controls.Add(this.btnZoomReset);
            this.Controls.Add(this.btnZoomMinus);
            this.Controls.Add(this.btnZoomPlus);
            this.Controls.Add(this.picWorld);
            this.Controls.Add(this.cboLidar);
            this.Controls.Add(this.boxGroup);
            this.Name = "PagePandaLidar";
            this.Size = new System.Drawing.Size(1024, 600);
            this.Load += new System.EventHandler(this.PanelLidar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox boxGroup;
        private WorldPanel picWorld;
        private System.Windows.Forms.ComboBox cboLidar;
        private System.Windows.Forms.Button btnZoomPlus;
        private System.Windows.Forms.Button btnZoomMinus;
        private System.Windows.Forms.Button btnZoomReset;
        private System.Windows.Forms.Button btnPoints;
        private System.Windows.Forms.Button btnTrap;
        private System.Windows.Forms.Button btnEnableBoard;
    }
}
