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
            this.btnTrap = new System.Windows.Forms.Button();
            this.btnLidarGround = new System.Windows.Forms.Button();
            this.btnLidarAvoid = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnEnableBoard = new System.Windows.Forms.Button();
            this.btnPoints = new System.Windows.Forms.Button();
            this.btnZoomReset = new System.Windows.Forms.Button();
            this.btnZoomMinus = new System.Windows.Forms.Button();
            this.btnZoomPlus = new System.Windows.Forms.Button();
            this.picWorld = new GoBot.IHM.WorldPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTrap
            // 
            this.btnTrap.Location = new System.Drawing.Point(-25, -25);
            this.btnTrap.Name = "btnTrap";
            this.btnTrap.Size = new System.Drawing.Size(23, 23);
            this.btnTrap.TabIndex = 0;
            this.btnTrap.UseVisualStyleBackColor = true;
            // 
            // btnLidarGround
            // 
            this.btnLidarGround.Image = global::GoBot.Properties.Resources.Down64;
            this.btnLidarGround.Location = new System.Drawing.Point(19, 59);
            this.btnLidarGround.Name = "btnLidarGround";
            this.btnLidarGround.Size = new System.Drawing.Size(75, 45);
            this.btnLidarGround.TabIndex = 20;
            this.btnLidarGround.UseVisualStyleBackColor = true;
            this.btnLidarGround.Click += new System.EventHandler(this.btnLidarGround_Click);
            // 
            // btnLidarAvoid
            // 
            this.btnLidarAvoid.Image = global::GoBot.Properties.Resources.Up64;
            this.btnLidarAvoid.Location = new System.Drawing.Point(19, 8);
            this.btnLidarAvoid.Name = "btnLidarAvoid";
            this.btnLidarAvoid.Size = new System.Drawing.Size(75, 45);
            this.btnLidarAvoid.TabIndex = 19;
            this.btnLidarAvoid.UseVisualStyleBackColor = true;
            this.btnLidarAvoid.Click += new System.EventHandler(this.btnLidarAvoid_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.BackColor = System.Drawing.Color.Transparent;
            this.btnGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnGroup.Image = global::GoBot.Properties.Resources.LidarGroupDisable;
            this.btnGroup.Location = new System.Drawing.Point(19, 272);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(75, 75);
            this.btnGroup.TabIndex = 3;
            this.btnGroup.UseVisualStyleBackColor = false;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnEnableBoard
            // 
            this.btnEnableBoard.BackColor = System.Drawing.Color.Transparent;
            this.btnEnableBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnEnableBoard.Image = global::GoBot.Properties.Resources.LidarBoardOn;
            this.btnEnableBoard.Location = new System.Drawing.Point(19, 110);
            this.btnEnableBoard.Name = "btnEnableBoard";
            this.btnEnableBoard.Size = new System.Drawing.Size(75, 75);
            this.btnEnableBoard.TabIndex = 1;
            this.btnEnableBoard.UseVisualStyleBackColor = false;
            this.btnEnableBoard.Click += new System.EventHandler(this.btnEnableBoard_Click);
            // 
            // btnPoints
            // 
            this.btnPoints.BackColor = System.Drawing.Color.Transparent;
            this.btnPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnPoints.Image = global::GoBot.Properties.Resources.LidarPoints;
            this.btnPoints.Location = new System.Drawing.Point(19, 191);
            this.btnPoints.Name = "btnPoints";
            this.btnPoints.Size = new System.Drawing.Size(75, 75);
            this.btnPoints.TabIndex = 2;
            this.btnPoints.UseVisualStyleBackColor = false;
            this.btnPoints.Click += new System.EventHandler(this.btnPoints_Click);
            // 
            // btnZoomReset
            // 
            this.btnZoomReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnZoomReset.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomReset.Image")));
            this.btnZoomReset.Location = new System.Drawing.Point(19, 515);
            this.btnZoomReset.Name = "btnZoomReset";
            this.btnZoomReset.Size = new System.Drawing.Size(75, 75);
            this.btnZoomReset.TabIndex = 6;
            this.btnZoomReset.UseVisualStyleBackColor = true;
            this.btnZoomReset.Click += new System.EventHandler(this.btnZoomReset_Click);
            // 
            // btnZoomMinus
            // 
            this.btnZoomMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnZoomMinus.Image = global::GoBot.Properties.Resources.ZoomMinus;
            this.btnZoomMinus.Location = new System.Drawing.Point(19, 434);
            this.btnZoomMinus.Name = "btnZoomMinus";
            this.btnZoomMinus.Size = new System.Drawing.Size(75, 75);
            this.btnZoomMinus.TabIndex = 5;
            this.btnZoomMinus.UseVisualStyleBackColor = true;
            this.btnZoomMinus.Click += new System.EventHandler(this.btnZoomMinus_Click);
            // 
            // btnZoomPlus
            // 
            this.btnZoomPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.btnZoomPlus.Image = global::GoBot.Properties.Resources.ZoomPlus;
            this.btnZoomPlus.Location = new System.Drawing.Point(19, 353);
            this.btnZoomPlus.Name = "btnZoomPlus";
            this.btnZoomPlus.Size = new System.Drawing.Size(75, 75);
            this.btnZoomPlus.TabIndex = 4;
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
            this.picWorld.Size = new System.Drawing.Size(792, 568);
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
            this.Controls.Add(this.btnLidarGround);
            this.Controls.Add(this.btnLidarAvoid);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.btnEnableBoard);
            this.Controls.Add(this.btnTrap);
            this.Controls.Add(this.btnPoints);
            this.Controls.Add(this.btnZoomReset);
            this.Controls.Add(this.btnZoomMinus);
            this.Controls.Add(this.btnZoomPlus);
            this.Controls.Add(this.picWorld);
            this.Name = "PagePandaLidar";
            this.Size = new System.Drawing.Size(916, 600);
            this.Load += new System.EventHandler(this.PanelLidar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private WorldPanel picWorld;
        private System.Windows.Forms.Button btnZoomPlus;
        private System.Windows.Forms.Button btnZoomMinus;
        private System.Windows.Forms.Button btnZoomReset;
        private System.Windows.Forms.Button btnPoints;
        private System.Windows.Forms.Button btnTrap;
        private System.Windows.Forms.Button btnEnableBoard;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnLidarAvoid;
        private System.Windows.Forms.Button btnLidarGround;
    }
}
