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
            // btnClamp5
            // 
            this.btnClamp5.Image = ((System.Drawing.Image)(resources.GetObject("btnClamp5.Image")));
            this.btnClamp5.Location = new System.Drawing.Point(565, 531);
            this.btnClamp5.Name = "btnClamp5";
            this.btnClamp5.Size = new System.Drawing.Size(64, 64);
            this.btnClamp5.TabIndex = 9;
            this.btnClamp5.UseVisualStyleBackColor = true;
            this.btnClamp5.Click += new System.EventHandler(this.btnClamp5_Click);
            // 
            // btnClamp4
            // 
            this.btnClamp4.Image = ((System.Drawing.Image)(resources.GetObject("btnClamp4.Image")));
            this.btnClamp4.Location = new System.Drawing.Point(495, 531);
            this.btnClamp4.Name = "btnClamp4";
            this.btnClamp4.Size = new System.Drawing.Size(64, 64);
            this.btnClamp4.TabIndex = 8;
            this.btnClamp4.UseVisualStyleBackColor = true;
            this.btnClamp4.Click += new System.EventHandler(this.btnClamp4_Click);
            // 
            // btnClamp3
            // 
            this.btnClamp3.Image = ((System.Drawing.Image)(resources.GetObject("btnClamp3.Image")));
            this.btnClamp3.Location = new System.Drawing.Point(425, 531);
            this.btnClamp3.Name = "btnClamp3";
            this.btnClamp3.Size = new System.Drawing.Size(64, 64);
            this.btnClamp3.TabIndex = 7;
            this.btnClamp3.UseVisualStyleBackColor = true;
            this.btnClamp3.Click += new System.EventHandler(this.btnClamp3_Click);
            // 
            // btnClamp2
            // 
            this.btnClamp2.Image = ((System.Drawing.Image)(resources.GetObject("btnClamp2.Image")));
            this.btnClamp2.Location = new System.Drawing.Point(355, 531);
            this.btnClamp2.Name = "btnClamp2";
            this.btnClamp2.Size = new System.Drawing.Size(64, 64);
            this.btnClamp2.TabIndex = 6;
            this.btnClamp2.UseVisualStyleBackColor = true;
            this.btnClamp2.Click += new System.EventHandler(this.btnClamp2_Click);
            // 
            // btnClamp1
            // 
            this.btnClamp1.Image = ((System.Drawing.Image)(resources.GetObject("btnClamp1.Image")));
            this.btnClamp1.Location = new System.Drawing.Point(285, 531);
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
            this.btnFlagRight.Location = new System.Drawing.Point(761, 6);
            this.btnFlagRight.Name = "btnFlagRight";
            this.btnFlagRight.Size = new System.Drawing.Size(150, 150);
            this.btnFlagRight.TabIndex = 2;
            this.btnFlagRight.UseVisualStyleBackColor = true;
            this.btnFlagRight.Click += new System.EventHandler(this.btnFlagRight_Click);
            // 
            // btnFLagLeft
            // 
            this.btnFLagLeft.Image = global::GoBot.Properties.Resources.FlagT;
            this.btnFLagLeft.Location = new System.Drawing.Point(5, 6);
            this.btnFLagLeft.Name = "btnFLagLeft";
            this.btnFLagLeft.Size = new System.Drawing.Size(150, 150);
            this.btnFLagLeft.TabIndex = 1;
            this.btnFLagLeft.UseVisualStyleBackColor = true;
            this.btnFLagLeft.Click += new System.EventHandler(this.btnFlagLeft_Click);
            // 
            // btnFingerLeft
            // 
            this.btnFingerLeft.Image = global::GoBot.Properties.Resources.FingerLeft;
            this.btnFingerLeft.Location = new System.Drawing.Point(5, 445);
            this.btnFingerLeft.Name = "btnFingerLeft";
            this.btnFingerLeft.Size = new System.Drawing.Size(150, 150);
            this.btnFingerLeft.TabIndex = 3;
            this.btnFingerLeft.UseVisualStyleBackColor = true;
            this.btnFingerLeft.Click += new System.EventHandler(this.btnFingerLeft_Click);
            // 
            // btnFingerRight
            // 
            this.btnFingerRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFingerRight.Image = global::GoBot.Properties.Resources.Finger;
            this.btnFingerRight.Location = new System.Drawing.Point(761, 445);
            this.btnFingerRight.Name = "btnFingerRight";
            this.btnFingerRight.Size = new System.Drawing.Size(150, 150);
            this.btnFingerRight.TabIndex = 4;
            this.btnFingerRight.UseVisualStyleBackColor = true;
            this.btnFingerRight.Click += new System.EventHandler(this.btnFingerRight_Click);
            // 
            // PagePandaActuators
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
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
            this.Size = new System.Drawing.Size(916, 600);
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
    }
}
