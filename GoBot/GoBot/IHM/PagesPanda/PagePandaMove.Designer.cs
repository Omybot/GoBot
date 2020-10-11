namespace GoBot.IHM.Pages
{
    partial class PagePandaMove
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
            this.btnTrap = new System.Windows.Forms.Button();
            this.btnCalibration = new System.Windows.Forms.Button();
            this.btnAsserv = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
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
            // btnCalibration
            // 
            this.btnCalibration.Image = global::GoBot.Properties.Resources.Calibration124;
            this.btnCalibration.Location = new System.Drawing.Point(161, 445);
            this.btnCalibration.Name = "btnCalibration";
            this.btnCalibration.Size = new System.Drawing.Size(150, 150);
            this.btnCalibration.TabIndex = 6;
            this.btnCalibration.UseVisualStyleBackColor = true;
            this.btnCalibration.Click += new System.EventHandler(this.btnCalibration_Click);
            // 
            // btnAsserv
            // 
            this.btnAsserv.Image = global::GoBot.Properties.Resources.GearsOn124;
            this.btnAsserv.Location = new System.Drawing.Point(5, 445);
            this.btnAsserv.Name = "btnAsserv";
            this.btnAsserv.Size = new System.Drawing.Size(150, 150);
            this.btnAsserv.TabIndex = 5;
            this.btnAsserv.UseVisualStyleBackColor = true;
            this.btnAsserv.Click += new System.EventHandler(this.btnAsserv_Click);
            // 
            // btnRight
            // 
            this.btnRight.Image = global::GoBot.Properties.Resources.TurnRight124;
            this.btnRight.Location = new System.Drawing.Point(333, 211);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(150, 150);
            this.btnRight.TabIndex = 4;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Image = global::GoBot.Properties.Resources.TurnLeft124;
            this.btnLeft.Location = new System.Drawing.Point(646, 211);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(150, 150);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::GoBot.Properties.Resources.Down124;
            this.btnDown.Location = new System.Drawing.Point(490, 371);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(150, 150);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::GoBot.Properties.Resources.Up124;
            this.btnUp.Location = new System.Drawing.Point(490, 53);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(150, 150);
            this.btnUp.TabIndex = 1;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // PagePandaMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnCalibration);
            this.Controls.Add(this.btnAsserv);
            this.Controls.Add(this.btnTrap);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.DoubleBuffered = true;
            this.Name = "PagePandaMove";
            this.Size = new System.Drawing.Size(916, 600);
            this.Load += new System.EventHandler(this.PagePandaMove_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnTrap;
        private System.Windows.Forms.Button btnAsserv;
        private System.Windows.Forms.Button btnCalibration;
    }
}
