namespace GoBot.IHM.Pages
{
    partial class PagePanda
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagePanda));
            this.tabControlPanda = new System.Windows.Forms.TabControl();
            this.tabPandaMatch = new System.Windows.Forms.TabPage();
            this.pnlMatch = new GoBot.IHM.Pages.PagePandaMatch();
            this.tabPandaMove = new System.Windows.Forms.TabPage();
            this.pnlPandaMove = new GoBot.IHM.Pages.PagePandaMove();
            this.tabPandaActuators = new System.Windows.Forms.TabPage();
            this.pagePandaActuators = new GoBot.IHM.Pages.PagePandaActuators();
            this.tabPandaLidar = new System.Windows.Forms.TabPage();
            this.pagePandaLidar = new GoBot.IHM.Pages.PagePandaLidar();
            this.picWorld = new GoBot.IHM.WorldPanel(this.components);
            this.pnlControls = new System.Windows.Forms.Panel();
            this.picServo5 = new System.Windows.Forms.PictureBox();
            this.lblBattery = new System.Windows.Forms.Label();
            this.picServo3 = new System.Windows.Forms.PictureBox();
            this.picBattery = new System.Windows.Forms.PictureBox();
            this.picServo1 = new System.Windows.Forms.PictureBox();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.picIO = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.picLidar = new System.Windows.Forms.PictureBox();
            this.picLimit = new System.Windows.Forms.PictureBox();
            this.picServo6 = new System.Windows.Forms.PictureBox();
            this.picMove = new System.Windows.Forms.PictureBox();
            this.picServo4 = new System.Windows.Forms.PictureBox();
            this.picCAN = new System.Windows.Forms.PictureBox();
            this.picServo2 = new System.Windows.Forms.PictureBox();
            this.tabControlPanda.SuspendLayout();
            this.tabPandaMatch.SuspendLayout();
            this.tabPandaMove.SuspendLayout();
            this.tabPandaActuators.SuspendLayout();
            this.tabPandaLidar.SuspendLayout();
            this.pagePandaLidar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).BeginInit();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServo5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBattery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLidar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServo6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServo4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServo2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlPanda
            // 
            this.tabControlPanda.Controls.Add(this.tabPandaMatch);
            this.tabControlPanda.Controls.Add(this.tabPandaMove);
            this.tabControlPanda.Controls.Add(this.tabPandaActuators);
            this.tabControlPanda.Controls.Add(this.tabPandaLidar);
            this.tabControlPanda.Location = new System.Drawing.Point(0, 0);
            this.tabControlPanda.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlPanda.Name = "tabControlPanda";
            this.tabControlPanda.SelectedIndex = 0;
            this.tabControlPanda.Size = new System.Drawing.Size(1042, 637);
            this.tabControlPanda.TabIndex = 2;
            this.tabControlPanda.SelectedIndexChanged += new System.EventHandler(this.tabControlPanda_SelectedIndexChanged);
            // 
            // tabPandaMatch
            // 
            this.tabPandaMatch.Controls.Add(this.pnlMatch);
            this.tabPandaMatch.Location = new System.Drawing.Point(4, 22);
            this.tabPandaMatch.Name = "tabPandaMatch";
            this.tabPandaMatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPandaMatch.Size = new System.Drawing.Size(1034, 611);
            this.tabPandaMatch.TabIndex = 0;
            this.tabPandaMatch.Text = "Match";
            // 
            // pnlMatch
            // 
            this.pnlMatch.BackColor = System.Drawing.Color.Black;
            this.pnlMatch.Location = new System.Drawing.Point(6, 6);
            this.pnlMatch.Name = "pnlMatch";
            this.pnlMatch.Size = new System.Drawing.Size(920, 600);
            this.pnlMatch.TabIndex = 0;
            // 
            // tabPandaMove
            // 
            this.tabPandaMove.Controls.Add(this.pnlPandaMove);
            this.tabPandaMove.Location = new System.Drawing.Point(4, 22);
            this.tabPandaMove.Name = "tabPandaMove";
            this.tabPandaMove.Padding = new System.Windows.Forms.Padding(3);
            this.tabPandaMove.Size = new System.Drawing.Size(1034, 611);
            this.tabPandaMove.TabIndex = 2;
            this.tabPandaMove.Text = "Déplacement";
            // 
            // pnlPandaMove
            // 
            this.pnlPandaMove.BackColor = System.Drawing.Color.Black;
            this.pnlPandaMove.Location = new System.Drawing.Point(6, 6);
            this.pnlPandaMove.Name = "pnlPandaMove";
            this.pnlPandaMove.Size = new System.Drawing.Size(920, 600);
            this.pnlPandaMove.TabIndex = 0;
            // 
            // tabPandaActuators
            // 
            this.tabPandaActuators.Controls.Add(this.pagePandaActuators);
            this.tabPandaActuators.Location = new System.Drawing.Point(4, 22);
            this.tabPandaActuators.Name = "tabPandaActuators";
            this.tabPandaActuators.Padding = new System.Windows.Forms.Padding(3);
            this.tabPandaActuators.Size = new System.Drawing.Size(1034, 611);
            this.tabPandaActuators.TabIndex = 3;
            this.tabPandaActuators.Text = "Actionneurs";
            // 
            // pagePandaActuators
            // 
            this.pagePandaActuators.BackColor = System.Drawing.Color.Black;
            this.pagePandaActuators.Location = new System.Drawing.Point(6, 6);
            this.pagePandaActuators.Name = "pagePandaActuators";
            this.pagePandaActuators.Size = new System.Drawing.Size(920, 600);
            this.pagePandaActuators.TabIndex = 0;
            // 
            // tabPandaLidar
            // 
            this.tabPandaLidar.Controls.Add(this.pagePandaLidar);
            this.tabPandaLidar.Location = new System.Drawing.Point(4, 22);
            this.tabPandaLidar.Name = "tabPandaLidar";
            this.tabPandaLidar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPandaLidar.Size = new System.Drawing.Size(1034, 611);
            this.tabPandaLidar.TabIndex = 1;
            this.tabPandaLidar.Text = "Lidar";
            // 
            // pagePandaLidar
            // 
            this.pagePandaLidar.BackColor = System.Drawing.Color.Black;
            this.pagePandaLidar.Controls.Add(this.picWorld);
            this.pagePandaLidar.Location = new System.Drawing.Point(6, 6);
            this.pagePandaLidar.Name = "pagePandaLidar";
            this.pagePandaLidar.Size = new System.Drawing.Size(920, 600);
            this.pagePandaLidar.TabIndex = 0;
            // 
            // picWorld
            // 
            this.picWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picWorld.Location = new System.Drawing.Point(110, 16);
            this.picWorld.Name = "picWorld";
            this.picWorld.Size = new System.Drawing.Size(796, 568);
            this.picWorld.TabIndex = 11;
            this.picWorld.TabStop = false;
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.Black;
            this.pnlControls.Controls.Add(this.picServo5);
            this.pnlControls.Controls.Add(this.lblBattery);
            this.pnlControls.Controls.Add(this.picServo3);
            this.pnlControls.Controls.Add(this.picBattery);
            this.pnlControls.Controls.Add(this.picServo1);
            this.pnlControls.Controls.Add(this.btnNextPage);
            this.pnlControls.Controls.Add(this.picIO);
            this.pnlControls.Controls.Add(this.btnClose);
            this.pnlControls.Controls.Add(this.picLidar);
            this.pnlControls.Controls.Add(this.picLimit);
            this.pnlControls.Controls.Add(this.picServo6);
            this.pnlControls.Controls.Add(this.picMove);
            this.pnlControls.Controls.Add(this.picServo4);
            this.pnlControls.Controls.Add(this.picCAN);
            this.pnlControls.Controls.Add(this.picServo2);
            this.pnlControls.Location = new System.Drawing.Point(930, 28);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(108, 600);
            this.pnlControls.TabIndex = 3;
            // 
            // picServo5
            // 
            this.picServo5.Image = ((System.Drawing.Image)(resources.GetObject("picServo5.Image")));
            this.picServo5.Location = new System.Drawing.Point(6, 436);
            this.picServo5.Name = "picServo5";
            this.picServo5.Size = new System.Drawing.Size(48, 48);
            this.picServo5.TabIndex = 10;
            this.picServo5.TabStop = false;
            // 
            // lblBattery
            // 
            this.lblBattery.Font = new System.Drawing.Font("Monospac821 BT", 14F, System.Drawing.FontStyle.Bold);
            this.lblBattery.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblBattery.Location = new System.Drawing.Point(6, 212);
            this.lblBattery.Name = "lblBattery";
            this.lblBattery.Size = new System.Drawing.Size(98, 23);
            this.lblBattery.TabIndex = 4;
            this.lblBattery.Text = "25.00V";
            this.lblBattery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picServo3
            // 
            this.picServo3.Image = ((System.Drawing.Image)(resources.GetObject("picServo3.Image")));
            this.picServo3.Location = new System.Drawing.Point(6, 389);
            this.picServo3.Name = "picServo3";
            this.picServo3.Size = new System.Drawing.Size(48, 48);
            this.picServo3.TabIndex = 9;
            this.picServo3.TabStop = false;
            // 
            // picBattery
            // 
            this.picBattery.Image = global::GoBot.Properties.Resources.BatteryFull96;
            this.picBattery.Location = new System.Drawing.Point(6, 113);
            this.picBattery.Name = "picBattery";
            this.picBattery.Size = new System.Drawing.Size(96, 96);
            this.picBattery.TabIndex = 3;
            this.picBattery.TabStop = false;
            // 
            // picServo1
            // 
            this.picServo1.Image = ((System.Drawing.Image)(resources.GetObject("picServo1.Image")));
            this.picServo1.Location = new System.Drawing.Point(6, 342);
            this.picServo1.Name = "picServo1";
            this.picServo1.Size = new System.Drawing.Size(48, 48);
            this.picServo1.TabIndex = 8;
            this.picServo1.TabStop = false;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNextPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Image = global::GoBot.Properties.Resources.NextPage96;
            this.btnNextPage.Location = new System.Drawing.Point(6, 499);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(96, 96);
            this.btnNextPage.TabIndex = 2;
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            this.btnNextPage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnNextPage_MouseDown);
            this.btnNextPage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnNextPage_MouseUp);
            // 
            // picIO
            // 
            this.picIO.Image = ((System.Drawing.Image)(resources.GetObject("picIO.Image")));
            this.picIO.Location = new System.Drawing.Point(6, 295);
            this.picIO.Name = "picIO";
            this.picIO.Size = new System.Drawing.Size(48, 48);
            this.picIO.TabIndex = 7;
            this.picIO.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::GoBot.Properties.Resources.Close96;
            this.btnClose.Location = new System.Drawing.Point(6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 96);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // picLidar
            // 
            this.picLidar.Image = ((System.Drawing.Image)(resources.GetObject("picLidar.Image")));
            this.picLidar.Location = new System.Drawing.Point(6, 248);
            this.picLidar.Name = "picLidar";
            this.picLidar.Size = new System.Drawing.Size(48, 48);
            this.picLidar.TabIndex = 6;
            this.picLidar.TabStop = false;
            // 
            // picLimit
            // 
            this.picLimit.BackColor = System.Drawing.Color.Silver;
            this.picLimit.Location = new System.Drawing.Point(0, 0);
            this.picLimit.Name = "picLimit";
            this.picLimit.Size = new System.Drawing.Size(1, 600);
            this.picLimit.TabIndex = 0;
            this.picLimit.TabStop = false;
            // 
            // picServo6
            // 
            this.picServo6.Image = ((System.Drawing.Image)(resources.GetObject("picServo6.Image")));
            this.picServo6.Location = new System.Drawing.Point(53, 436);
            this.picServo6.Name = "picServo6";
            this.picServo6.Size = new System.Drawing.Size(48, 48);
            this.picServo6.TabIndex = 5;
            this.picServo6.TabStop = false;
            // 
            // picMove
            // 
            this.picMove.Image = ((System.Drawing.Image)(resources.GetObject("picMove.Image")));
            this.picMove.Location = new System.Drawing.Point(53, 248);
            this.picMove.Name = "picMove";
            this.picMove.Size = new System.Drawing.Size(48, 48);
            this.picMove.TabIndex = 1;
            this.picMove.TabStop = false;
            // 
            // picServo4
            // 
            this.picServo4.Image = ((System.Drawing.Image)(resources.GetObject("picServo4.Image")));
            this.picServo4.Location = new System.Drawing.Point(53, 389);
            this.picServo4.Name = "picServo4";
            this.picServo4.Size = new System.Drawing.Size(48, 48);
            this.picServo4.TabIndex = 4;
            this.picServo4.TabStop = false;
            // 
            // picCAN
            // 
            this.picCAN.Image = ((System.Drawing.Image)(resources.GetObject("picCAN.Image")));
            this.picCAN.Location = new System.Drawing.Point(53, 295);
            this.picCAN.Name = "picCAN";
            this.picCAN.Size = new System.Drawing.Size(48, 48);
            this.picCAN.TabIndex = 2;
            this.picCAN.TabStop = false;
            // 
            // picServo2
            // 
            this.picServo2.Image = ((System.Drawing.Image)(resources.GetObject("picServo2.Image")));
            this.picServo2.Location = new System.Drawing.Point(53, 342);
            this.picServo2.Name = "picServo2";
            this.picServo2.Size = new System.Drawing.Size(48, 48);
            this.picServo2.TabIndex = 3;
            this.picServo2.TabStop = false;
            // 
            // PagePanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.tabControlPanda);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PagePanda";
            this.Size = new System.Drawing.Size(1050, 645);
            this.Load += new System.EventHandler(this.PagePanda_Load);
            this.tabControlPanda.ResumeLayout(false);
            this.tabPandaMatch.ResumeLayout(false);
            this.tabPandaMove.ResumeLayout(false);
            this.tabPandaActuators.ResumeLayout(false);
            this.tabPandaLidar.ResumeLayout(false);
            this.pagePandaLidar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).EndInit();
            this.pnlControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picServo5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBattery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLidar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServo6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServo4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picServo2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPanda;
        private System.Windows.Forms.TabPage tabPandaMatch;
        private PagePandaMatch pnlMatch;
        private System.Windows.Forms.TabPage tabPandaLidar;
        private System.Windows.Forms.TabPage tabPandaMove;
        private PagePandaMove pnlPandaMove;
        private System.Windows.Forms.TabPage tabPandaActuators;
        private PagePandaActuators pagePandaActuators;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.PictureBox picLimit;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox picBattery;
        private System.Windows.Forms.Label lblBattery;
        private System.Windows.Forms.PictureBox picServo5;
        private System.Windows.Forms.PictureBox picServo3;
        private System.Windows.Forms.PictureBox picServo1;
        private System.Windows.Forms.PictureBox picIO;
        private System.Windows.Forms.PictureBox picLidar;
        private System.Windows.Forms.PictureBox picServo6;
        private System.Windows.Forms.PictureBox picMove;
        private System.Windows.Forms.PictureBox picServo4;
        private System.Windows.Forms.PictureBox picCAN;
        private System.Windows.Forms.PictureBox picServo2;
        private PagePandaLidar pagePandaLidar;
        private WorldPanel picWorld;
    }
}
