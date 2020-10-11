namespace GoBot.IHM.Forms
{
    partial class FormConfirm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnStay = new System.Windows.Forms.Button();
            this.btnTrap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Eras Demi ITC", 36F);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(12, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(984, 284);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Voulez vous quitter GoBot ?";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnQuit.Font = new System.Drawing.Font("Eras Demi ITC", 36F);
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.Image = global::GoBot.Properties.Resources.Exit96;
            this.btnQuit.Location = new System.Drawing.Point(519, 275);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(400, 200);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quitter";
            this.btnQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnStay
            // 
            this.btnStay.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStay.Font = new System.Drawing.Font("Eras Demi ITC", 36F);
            this.btnStay.ForeColor = System.Drawing.Color.White;
            this.btnStay.Image = global::GoBot.Properties.Resources.Stay96;
            this.btnStay.Location = new System.Drawing.Point(96, 275);
            this.btnStay.Name = "btnStay";
            this.btnStay.Size = new System.Drawing.Size(400, 200);
            this.btnStay.TabIndex = 1;
            this.btnStay.Text = "Rester";
            this.btnStay.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnStay.UseVisualStyleBackColor = false;
            this.btnStay.Click += new System.EventHandler(this.btnStay_Click);
            // 
            // btnTrap
            // 
            this.btnTrap.Location = new System.Drawing.Point(-25, -25);
            this.btnTrap.Name = "btnTrap";
            this.btnTrap.Size = new System.Drawing.Size(23, 23);
            this.btnTrap.TabIndex = 3;
            this.btnTrap.UseVisualStyleBackColor = true;
            // 
            // FormConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.btnTrap);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStay);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConfirm";
            this.Text = "FormConfirm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormConfirm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnStay;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnTrap;
    }
}