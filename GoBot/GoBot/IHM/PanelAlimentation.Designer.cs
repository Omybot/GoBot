namespace GoBot.IHM
{
    partial class PanelAlimentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelAlimentation));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTensionPack1 = new System.Windows.Forms.Label();
            this.lblTensionPack2 = new System.Windows.Forms.Label();
            this.lblTensionBalise1 = new System.Windows.Forms.Label();
            this.lblTensionBalise2 = new System.Windows.Forms.Label();
            this.lblTensionBalise3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ledPack1 = new Composants.Led();
            this.ledPack2 = new Composants.Led();
            this.ledBalise1 = new Composants.Led();
            this.ledBalise2 = new Composants.Led();
            this.ledBalise3 = new Composants.Led();
            ((System.ComponentModel.ISupportInitialize)(this.ledPack1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pack 1 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pack 2 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Balise 1 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Balise 2 :";
            // 
            // lblTensionPack1
            // 
            this.lblTensionPack1.AutoSize = true;
            this.lblTensionPack1.Location = new System.Drawing.Point(141, 88);
            this.lblTensionPack1.Name = "lblTensionPack1";
            this.lblTensionPack1.Size = new System.Drawing.Size(23, 13);
            this.lblTensionPack1.TabIndex = 4;
            this.lblTensionPack1.Text = "0 V";
            // 
            // lblTensionPack2
            // 
            this.lblTensionPack2.AutoSize = true;
            this.lblTensionPack2.Location = new System.Drawing.Point(141, 120);
            this.lblTensionPack2.Name = "lblTensionPack2";
            this.lblTensionPack2.Size = new System.Drawing.Size(23, 13);
            this.lblTensionPack2.TabIndex = 5;
            this.lblTensionPack2.Text = "0 V";
            // 
            // lblTensionBalise1
            // 
            this.lblTensionBalise1.AutoSize = true;
            this.lblTensionBalise1.Location = new System.Drawing.Point(141, 199);
            this.lblTensionBalise1.Name = "lblTensionBalise1";
            this.lblTensionBalise1.Size = new System.Drawing.Size(23, 13);
            this.lblTensionBalise1.TabIndex = 6;
            this.lblTensionBalise1.Text = "0 V";
            // 
            // lblTensionBalise2
            // 
            this.lblTensionBalise2.AutoSize = true;
            this.lblTensionBalise2.Location = new System.Drawing.Point(141, 231);
            this.lblTensionBalise2.Name = "lblTensionBalise2";
            this.lblTensionBalise2.Size = new System.Drawing.Size(23, 13);
            this.lblTensionBalise2.TabIndex = 7;
            this.lblTensionBalise2.Text = "0 V";
            // 
            // lblTensionBalise3
            // 
            this.lblTensionBalise3.AutoSize = true;
            this.lblTensionBalise3.Location = new System.Drawing.Point(141, 263);
            this.lblTensionBalise3.Name = "lblTensionBalise3";
            this.lblTensionBalise3.Size = new System.Drawing.Size(23, 13);
            this.lblTensionBalise3.TabIndex = 9;
            this.lblTensionBalise3.Text = "0 V";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(88, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Balise 3 :";
            // 
            // ledPack1
            // 
            this.ledPack1.Etat = false;
            this.ledPack1.Image = ((System.Drawing.Image)(resources.GetObject("ledPack1.Image")));
            this.ledPack1.Location = new System.Drawing.Point(185, 85);
            this.ledPack1.Name = "ledPack1";
            this.ledPack1.Size = new System.Drawing.Size(16, 16);
            this.ledPack1.TabIndex = 10;
            this.ledPack1.TabStop = false;
            // 
            // ledPack2
            // 
            this.ledPack2.Etat = false;
            this.ledPack2.Image = ((System.Drawing.Image)(resources.GetObject("ledPack2.Image")));
            this.ledPack2.Location = new System.Drawing.Point(185, 117);
            this.ledPack2.Name = "ledPack2";
            this.ledPack2.Size = new System.Drawing.Size(16, 16);
            this.ledPack2.TabIndex = 11;
            this.ledPack2.TabStop = false;
            // 
            // ledBalise1
            // 
            this.ledBalise1.Etat = false;
            this.ledBalise1.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise1.Image")));
            this.ledBalise1.Location = new System.Drawing.Point(185, 196);
            this.ledBalise1.Name = "ledBalise1";
            this.ledBalise1.Size = new System.Drawing.Size(16, 16);
            this.ledBalise1.TabIndex = 12;
            this.ledBalise1.TabStop = false;
            // 
            // ledBalise2
            // 
            this.ledBalise2.Etat = false;
            this.ledBalise2.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise2.Image")));
            this.ledBalise2.Location = new System.Drawing.Point(185, 228);
            this.ledBalise2.Name = "ledBalise2";
            this.ledBalise2.Size = new System.Drawing.Size(16, 16);
            this.ledBalise2.TabIndex = 13;
            this.ledBalise2.TabStop = false;
            // 
            // ledBalise3
            // 
            this.ledBalise3.Etat = false;
            this.ledBalise3.Image = ((System.Drawing.Image)(resources.GetObject("ledBalise3.Image")));
            this.ledBalise3.Location = new System.Drawing.Point(185, 260);
            this.ledBalise3.Name = "ledBalise3";
            this.ledBalise3.Size = new System.Drawing.Size(16, 16);
            this.ledBalise3.TabIndex = 14;
            this.ledBalise3.TabStop = false;
            // 
            // PanelAlimentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ledBalise3);
            this.Controls.Add(this.ledBalise2);
            this.Controls.Add(this.ledBalise1);
            this.Controls.Add(this.ledPack2);
            this.Controls.Add(this.ledPack1);
            this.Controls.Add(this.lblTensionBalise3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTensionBalise2);
            this.Controls.Add(this.lblTensionBalise1);
            this.Controls.Add(this.lblTensionPack2);
            this.Controls.Add(this.lblTensionPack1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PanelAlimentation";
            this.Size = new System.Drawing.Size(1025, 501);
            this.Load += new System.EventHandler(this.PanelAlimentation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ledPack1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledPack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBalise3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTensionPack1;
        private System.Windows.Forms.Label lblTensionPack2;
        private System.Windows.Forms.Label lblTensionBalise1;
        private System.Windows.Forms.Label lblTensionBalise2;
        private System.Windows.Forms.Label lblTensionBalise3;
        private System.Windows.Forms.Label label10;
        private Composants.Led ledPack1;
        private Composants.Led ledPack2;
        private Composants.Led ledBalise1;
        private Composants.Led ledBalise2;
        private Composants.Led ledBalise3;

    }
}
