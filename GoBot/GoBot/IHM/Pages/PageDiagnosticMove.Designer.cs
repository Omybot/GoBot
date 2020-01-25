namespace GoBot.IHM.Pages
{
    partial class PageDiagnosticMove
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
            this.btnLaunch = new System.Windows.Forms.Button();
            this.lblCpuLoad = new System.Windows.Forms.Label();
            this.picVumetre = new System.Windows.Forms.PictureBox();
            this.gphPwmLeft = new Composants.GraphPanel();
            this.gphPwmRight = new Composants.GraphPanel();
            this.gphCpu = new Composants.GraphPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picVumetre)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.Image = global::GoBot.Properties.Resources.Play16;
            this.btnLaunch.Location = new System.Drawing.Point(8, 197);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(85, 35);
            this.btnLaunch.TabIndex = 124;
            this.btnLaunch.Text = "Lancer";
            this.btnLaunch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLaunch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // lblCpuLoad
            // 
            this.lblCpuLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpuLoad.Location = new System.Drawing.Point(9, 529);
            this.lblCpuLoad.Name = "lblCpuLoad";
            this.lblCpuLoad.Size = new System.Drawing.Size(59, 25);
            this.lblCpuLoad.TabIndex = 127;
            this.lblCpuLoad.Text = "0%";
            this.lblCpuLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picVumetre
            // 
            this.picVumetre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picVumetre.Location = new System.Drawing.Point(74, 462);
            this.picVumetre.Name = "picVumetre";
            this.picVumetre.Size = new System.Drawing.Size(19, 170);
            this.picVumetre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVumetre.TabIndex = 128;
            this.picVumetre.TabStop = false;
            // 
            // gphPwmLeft
            // 
            this.gphPwmLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gphPwmLeft.Location = new System.Drawing.Point(99, 221);
            this.gphPwmLeft.Name = "gphPwmLeft";
            this.gphPwmLeft.Size = new System.Drawing.Size(1152, 202);
            this.gphPwmLeft.TabIndex = 126;
            // 
            // gphPwmRight
            // 
            this.gphPwmRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gphPwmRight.Location = new System.Drawing.Point(99, 13);
            this.gphPwmRight.Name = "gphPwmRight";
            this.gphPwmRight.Size = new System.Drawing.Size(1152, 202);
            this.gphPwmRight.TabIndex = 125;
            // 
            // gphCpu
            // 
            this.gphCpu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gphCpu.Location = new System.Drawing.Point(99, 462);
            this.gphCpu.Name = "gphCpu";
            this.gphCpu.Size = new System.Drawing.Size(1152, 170);
            this.gphCpu.TabIndex = 123;
            // 
            // PanelDiagnosticMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picVumetre);
            this.Controls.Add(this.lblCpuLoad);
            this.Controls.Add(this.gphPwmLeft);
            this.Controls.Add(this.gphPwmRight);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.gphCpu);
            this.Name = "PanelDiagnosticMove";
            this.Size = new System.Drawing.Size(1254, 635);
            this.Load += new System.EventHandler(this.PanelDiagnosticMove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVumetre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.GraphPanel gphCpu;
        private System.Windows.Forms.Button btnLaunch;
        private Composants.GraphPanel gphPwmRight;
        private Composants.GraphPanel gphPwmLeft;
        private System.Windows.Forms.Label lblCpuLoad;
        private System.Windows.Forms.PictureBox picVumetre;
    }
}
