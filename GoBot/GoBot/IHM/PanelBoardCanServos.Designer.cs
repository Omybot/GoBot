namespace GoBot.IHM
{
    partial class PanelBoardCanServos
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblServo1 = new System.Windows.Forms.Label();
            this.lblServo2 = new System.Windows.Forms.Label();
            this.lblServo3 = new System.Windows.Forms.Label();
            this.lblServo4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(125, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CAN Servos X";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblServo1
            // 
            this.lblServo1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblServo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServo1.Location = new System.Drawing.Point(3, 35);
            this.lblServo1.Name = "lblServo1";
            this.lblServo1.Size = new System.Drawing.Size(122, 13);
            this.lblServo1.TabIndex = 1;
            this.lblServo1.Text = "Servo 1";
            this.lblServo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblServo1.Click += new System.EventHandler(this.lblServo1_Click);
            // 
            // lblServo2
            // 
            this.lblServo2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblServo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServo2.Location = new System.Drawing.Point(3, 59);
            this.lblServo2.Name = "lblServo2";
            this.lblServo2.Size = new System.Drawing.Size(122, 13);
            this.lblServo2.TabIndex = 2;
            this.lblServo2.Text = "Servo 2";
            this.lblServo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblServo2.Click += new System.EventHandler(this.lblServo2_Click);
            // 
            // lblServo3
            // 
            this.lblServo3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblServo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServo3.Location = new System.Drawing.Point(3, 83);
            this.lblServo3.Name = "lblServo3";
            this.lblServo3.Size = new System.Drawing.Size(122, 13);
            this.lblServo3.TabIndex = 3;
            this.lblServo3.Text = "Servo 3";
            this.lblServo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblServo3.Click += new System.EventHandler(this.lblServo3_Click);
            // 
            // lblServo4
            // 
            this.lblServo4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblServo4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServo4.Location = new System.Drawing.Point(3, 107);
            this.lblServo4.Name = "lblServo4";
            this.lblServo4.Size = new System.Drawing.Size(122, 13);
            this.lblServo4.TabIndex = 4;
            this.lblServo4.Text = "Servo 4";
            this.lblServo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblServo4.Click += new System.EventHandler(this.lblServo4_Click);
            // 
            // PanelBoardCanServos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblServo4);
            this.Controls.Add(this.lblServo3);
            this.Controls.Add(this.lblServo2);
            this.Controls.Add(this.lblServo1);
            this.Controls.Add(this.lblTitle);
            this.Name = "PanelBoardCanServos";
            this.Size = new System.Drawing.Size(128, 137);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblServo1;
        private System.Windows.Forms.Label lblServo2;
        private System.Windows.Forms.Label lblServo3;
        private System.Windows.Forms.Label lblServo4;
    }
}
