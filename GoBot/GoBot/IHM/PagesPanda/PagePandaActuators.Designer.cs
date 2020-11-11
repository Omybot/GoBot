namespace GoBot.IHM.Pages
{
    partial class PagePandaActuators
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagePandaActuators));
            this.btnTrap = new System.Windows.Forms.Button();
            this.btnGrabberRight = new System.Windows.Forms.Button();
            this.btnGrabberLeft = new System.Windows.Forms.Button();
            this.btnSearchRed = new System.Windows.Forms.Button();
            this.btnSearchGreen = new System.Windows.Forms.Button();
            this.btnRightDropoff = new System.Windows.Forms.Button();
            this.btnRightPickup = new System.Windows.Forms.Button();
            this.btnLeftDropoff = new System.Windows.Forms.Button();
            this.btnLeftPickup = new System.Windows.Forms.Button();
            this.btnClamp5 = new System.Windows.Forms.Button();
            this.btnClamp4 = new System.Windows.Forms.Button();
            this.btnClamp3 = new System.Windows.Forms.Button();
            this.btnClamp2 = new System.Windows.Forms.Button();
            this.btnClamp1 = new System.Windows.Forms.Button();
            this.btnFlagRight = new System.Windows.Forms.Button();
            this.btnFLagLeft = new System.Windows.Forms.Button();
            this.btnFingerLeft = new System.Windows.Forms.Button();
            this.btnFingerRight = new System.Windows.Forms.Button();
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
            // btnGrabberRight
            // 
            this.btnGrabberRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabberRight.Image = global::GoBot.Properties.Resources.GrabberRightOpened;
            this.btnGrabberRight.Location = new System.Drawing.Point(625, 154);
            this.btnGrabberRight.Name = "btnGrabberRight";
            this.btnGrabberRight.Size = new System.Drawing.Size(142, 142);
            this.btnGrabberRight.TabIndex = 17;
            this.btnGrabberRight.UseVisualStyleBackColor = true;
            this.btnGrabberRight.Click += new System.EventHandler(this.btnGrabberRight_Click);
            // 
            // btnGrabberLeft
            // 
            this.btnGrabberLeft.Image = global::GoBot.Properties.Resources.GrabberLeftOpened;
            this.btnGrabberLeft.Location = new System.Drawing.Point(153, 154);
            this.btnGrabberLeft.Name = "btnGrabberLeft";
            this.btnGrabberLeft.Size = new System.Drawing.Size(142, 142);
            this.btnGrabberLeft.TabIndex = 16;
            this.btnGrabberLeft.UseVisualStyleBackColor = true;
            this.btnGrabberLeft.Click += new System.EventHandler(this.btnGrabberLeft_Click);
            // 
            // btnSearchRed
            // 
            this.btnSearchRed.Image = global::GoBot.Properties.Resources.SearchBuoyRed;
            this.btnSearchRed.Location = new System.Drawing.Point(153, 302);
            this.btnSearchRed.Name = "btnSearchRed";
            this.btnSearchRed.Size = new System.Drawing.Size(142, 142);
            this.btnSearchRed.TabIndex = 15;
            this.btnSearchRed.UseVisualStyleBackColor = true;
            this.btnSearchRed.Click += new System.EventHandler(this.btnSearchRed_Click);
            // 
            // btnSearchGreen
            // 
            this.btnSearchGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchGreen.Image = global::GoBot.Properties.Resources.SearchBuoyGreen;
            this.btnSearchGreen.Location = new System.Drawing.Point(625, 302);
            this.btnSearchGreen.Name = "btnSearchGreen";
            this.btnSearchGreen.Size = new System.Drawing.Size(142, 142);
            this.btnSearchGreen.TabIndex = 14;
            this.btnSearchGreen.UseVisualStyleBackColor = true;
            this.btnSearchGreen.Click += new System.EventHandler(this.btnSearchGreen_Click);
            // 
            // btnRightDropoff
            // 
            this.btnRightDropoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRightDropoff.Image = ((System.Drawing.Image)(resources.GetObject("btnRightDropoff.Image")));
            this.btnRightDropoff.Location = new System.Drawing.Point(773, 302);
            this.btnRightDropoff.Name = "btnRightDropoff";
            this.btnRightDropoff.Size = new System.Drawing.Size(142, 142);
            this.btnRightDropoff.TabIndex = 13;
            this.btnRightDropoff.UseVisualStyleBackColor = true;
            this.btnRightDropoff.Click += new System.EventHandler(this.btnRightDropoff_Click);
            // 
            // btnRightPickup
            // 
            this.btnRightPickup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRightPickup.Image = global::GoBot.Properties.Resources.BigArrowUp;
            this.btnRightPickup.Location = new System.Drawing.Point(773, 154);
            this.btnRightPickup.Name = "btnRightPickup";
            this.btnRightPickup.Size = new System.Drawing.Size(142, 142);
            this.btnRightPickup.TabIndex = 12;
            this.btnRightPickup.UseVisualStyleBackColor = true;
            this.btnRightPickup.Click += new System.EventHandler(this.btnRightPickup_Click);
            // 
            // btnLeftDropoff
            // 
            this.btnLeftDropoff.Image = ((System.Drawing.Image)(resources.GetObject("btnLeftDropoff.Image")));
            this.btnLeftDropoff.Location = new System.Drawing.Point(5, 302);
            this.btnLeftDropoff.Name = "btnLeftDropoff";
            this.btnLeftDropoff.Size = new System.Drawing.Size(142, 142);
            this.btnLeftDropoff.TabIndex = 11;
            this.btnLeftDropoff.UseVisualStyleBackColor = true;
            this.btnLeftDropoff.Click += new System.EventHandler(this.btnLeftDropoff_Click);
            // 
            // btnLeftPickup
            // 
            this.btnLeftPickup.Image = global::GoBot.Properties.Resources.BigArrowUp;
            this.btnLeftPickup.Location = new System.Drawing.Point(5, 154);
            this.btnLeftPickup.Name = "btnLeftPickup";
            this.btnLeftPickup.Size = new System.Drawing.Size(142, 142);
            this.btnLeftPickup.TabIndex = 10;
            this.btnLeftPickup.UseVisualStyleBackColor = true;
            this.btnLeftPickup.Click += new System.EventHandler(this.btnLeftPickup_Click);
            // 
            // btnClamp5
            // 
            this.btnClamp5.Image = ((System.Drawing.Image)(resources.GetObject("btnClamp5.Image")));
            this.btnClamp5.Location = new System.Drawing.Point(567, 531);
            this.btnClamp5.Name = "btnClamp5";
            this.btnClamp5.Size = new System.Drawing.Size(64, 64);
            this.btnClamp5.TabIndex = 9;
            this.btnClamp5.UseVisualStyleBackColor = true;
            this.btnClamp5.Click += new System.EventHandler(this.btnClamp5_Click);
            // 
            // btnClamp4
            // 
            this.btnClamp4.Image = ((System.Drawing.Image)(resources.GetObject("btnClamp4.Image")));
            this.btnClamp4.Location = new System.Drawing.Point(497, 531);
            this.btnClamp4.Name = "btnClamp4";
            this.btnClamp4.Size = new System.Drawing.Size(64, 64);
            this.btnClamp4.TabIndex = 8;
            this.btnClamp4.UseVisualStyleBackColor = true;
            this.btnClamp4.Click += new System.EventHandler(this.btnClamp4_Click);
            // 
            // btnClamp3
            // 
            this.btnClamp3.Image = ((System.Drawing.Image)(resources.GetObject("btnClamp3.Image")));
            this.btnClamp3.Location = new System.Drawing.Point(427, 531);
            this.btnClamp3.Name = "btnClamp3";
            this.btnClamp3.Size = new System.Drawing.Size(64, 64);
            this.btnClamp3.TabIndex = 7;
            this.btnClamp3.UseVisualStyleBackColor = true;
            this.btnClamp3.Click += new System.EventHandler(this.btnClamp3_Click);
            // 
            // btnClamp2
            // 
            this.btnClamp2.Image = ((System.Drawing.Image)(resources.GetObject("btnClamp2.Image")));
            this.btnClamp2.Location = new System.Drawing.Point(357, 531);
            this.btnClamp2.Name = "btnClamp2";
            this.btnClamp2.Size = new System.Drawing.Size(64, 64);
            this.btnClamp2.TabIndex = 6;
            this.btnClamp2.UseVisualStyleBackColor = true;
            this.btnClamp2.Click += new System.EventHandler(this.btnClamp2_Click);
            // 
            // btnClamp1
            // 
            this.btnClamp1.Image = ((System.Drawing.Image)(resources.GetObject("btnClamp1.Image")));
            this.btnClamp1.Location = new System.Drawing.Point(287, 531);
            this.btnClamp1.Name = "btnClamp1";
            this.btnClamp1.Size = new System.Drawing.Size(64, 64);
            this.btnClamp1.TabIndex = 5;
            this.btnClamp1.UseVisualStyleBackColor = true;
            this.btnClamp1.Click += new System.EventHandler(this.btnClamp1_Click);
            // 
            // btnFlagRight
            // 
            this.btnFlagRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFlagRight.Image = global::GoBot.Properties.Resources.FlagO;
            this.btnFlagRight.Location = new System.Drawing.Point(773, 6);
            this.btnFlagRight.Name = "btnFlagRight";
            this.btnFlagRight.Size = new System.Drawing.Size(142, 142);
            this.btnFlagRight.TabIndex = 2;
            this.btnFlagRight.UseVisualStyleBackColor = true;
            this.btnFlagRight.Click += new System.EventHandler(this.btnFlagRight_Click);
            // 
            // btnFLagLeft
            // 
            this.btnFLagLeft.Image = global::GoBot.Properties.Resources.FlagT;
            this.btnFLagLeft.Location = new System.Drawing.Point(5, 6);
            this.btnFLagLeft.Name = "btnFLagLeft";
            this.btnFLagLeft.Size = new System.Drawing.Size(142, 142);
            this.btnFLagLeft.TabIndex = 1;
            this.btnFLagLeft.UseVisualStyleBackColor = true;
            this.btnFLagLeft.Click += new System.EventHandler(this.btnFlagLeft_Click);
            // 
            // btnFingerLeft
            // 
            this.btnFingerLeft.Image = global::GoBot.Properties.Resources.FingerLeft;
            this.btnFingerLeft.Location = new System.Drawing.Point(5, 450);
            this.btnFingerLeft.Name = "btnFingerLeft";
            this.btnFingerLeft.Size = new System.Drawing.Size(142, 142);
            this.btnFingerLeft.TabIndex = 3;
            this.btnFingerLeft.UseVisualStyleBackColor = true;
            this.btnFingerLeft.Click += new System.EventHandler(this.btnFingerLeft_Click);
            // 
            // btnFingerRight
            // 
            this.btnFingerRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFingerRight.Image = global::GoBot.Properties.Resources.Finger;
            this.btnFingerRight.Location = new System.Drawing.Point(773, 450);
            this.btnFingerRight.Name = "btnFingerRight";
            this.btnFingerRight.Size = new System.Drawing.Size(142, 142);
            this.btnFingerRight.TabIndex = 4;
            this.btnFingerRight.UseVisualStyleBackColor = true;
            this.btnFingerRight.Click += new System.EventHandler(this.btnFingerRight_Click);
            // 
            // PagePandaActuators
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnGrabberRight);
            this.Controls.Add(this.btnGrabberLeft);
            this.Controls.Add(this.btnSearchRed);
            this.Controls.Add(this.btnSearchGreen);
            this.Controls.Add(this.btnRightDropoff);
            this.Controls.Add(this.btnRightPickup);
            this.Controls.Add(this.btnLeftDropoff);
            this.Controls.Add(this.btnLeftPickup);
            this.Controls.Add(this.btnClamp5);
            this.Controls.Add(this.btnClamp4);
            this.Controls.Add(this.btnClamp3);
            this.Controls.Add(this.btnClamp2);
            this.Controls.Add(this.btnClamp1);
            this.Controls.Add(this.btnFlagRight);
            this.Controls.Add(this.btnFLagLeft);
            this.Controls.Add(this.btnTrap);
            this.Controls.Add(this.btnFingerLeft);
            this.Controls.Add(this.btnFingerRight);
            this.DoubleBuffered = true;
            this.Name = "PagePandaActuators";
            this.Size = new System.Drawing.Size(920, 600);
            this.Load += new System.EventHandler(this.PagePandaActuators_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnFingerRight;
        private System.Windows.Forms.Button btnFingerLeft;
        private System.Windows.Forms.Button btnTrap;
        private System.Windows.Forms.Button btnFLagLeft;
        private System.Windows.Forms.Button btnFlagRight;
        private System.Windows.Forms.Button btnClamp1;
        private System.Windows.Forms.Button btnClamp2;
        private System.Windows.Forms.Button btnClamp3;
        private System.Windows.Forms.Button btnClamp4;
        private System.Windows.Forms.Button btnClamp5;
        private System.Windows.Forms.Button btnLeftPickup;
        private System.Windows.Forms.Button btnLeftDropoff;
        private System.Windows.Forms.Button btnRightDropoff;
        private System.Windows.Forms.Button btnRightPickup;
        private System.Windows.Forms.Button btnSearchGreen;
        private System.Windows.Forms.Button btnSearchRed;
        private System.Windows.Forms.Button btnGrabberLeft;
        private System.Windows.Forms.Button btnGrabberRight;
    }
}
