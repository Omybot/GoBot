﻿namespace GoBot.IHM
{
    partial class PanelBaliseDiagnostic
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
            this.groupBalise = new System.Windows.Forms.GroupBox();
            this.ctrlGraphiqueAngle2 = new Composants.GraphPanel();
            this.ctrlGraphiqueDistance2 = new Composants.GraphPanel();
            this.ctrlGraphiqueDistance1 = new Composants.GraphPanel();
            this.ctrlGraphiqueAngle1 = new Composants.GraphPanel();
            this.lblStabiliteDistance2 = new System.Windows.Forms.Label();
            this.lblStabiliteAngle2 = new System.Windows.Forms.Label();
            this.ctrlGraphiquePWM = new Composants.GraphPanel();
            this.lblNbTrames = new System.Windows.Forms.Label();
            this.btnLancer = new System.Windows.Forms.Button();
            this.lblStabiliteDistance1 = new System.Windows.Forms.Label();
            this.lblStabiliteAngle1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.ctrlGraphiqueTemps = new Composants.GraphPanel();
            this.groupBalise.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBalise
            // 
            this.groupBalise.BackColor = System.Drawing.Color.Transparent;
            this.groupBalise.Controls.Add(this.ctrlGraphiqueAngle2);
            this.groupBalise.Controls.Add(this.ctrlGraphiqueDistance2);
            this.groupBalise.Controls.Add(this.ctrlGraphiqueDistance1);
            this.groupBalise.Controls.Add(this.ctrlGraphiqueAngle1);
            this.groupBalise.Controls.Add(this.lblStabiliteDistance2);
            this.groupBalise.Controls.Add(this.lblStabiliteAngle2);
            this.groupBalise.Controls.Add(this.ctrlGraphiquePWM);
            this.groupBalise.Controls.Add(this.lblNbTrames);
            this.groupBalise.Controls.Add(this.btnLancer);
            this.groupBalise.Controls.Add(this.lblStabiliteDistance1);
            this.groupBalise.Controls.Add(this.lblStabiliteAngle1);
            this.groupBalise.Controls.Add(this.label5);
            this.groupBalise.Controls.Add(this.label4);
            this.groupBalise.Controls.Add(this.btnReset);
            this.groupBalise.Controls.Add(this.ctrlGraphiqueTemps);
            this.groupBalise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBalise.Location = new System.Drawing.Point(0, 0);
            this.groupBalise.Name = "groupBalise";
            this.groupBalise.Size = new System.Drawing.Size(333, 604);
            this.groupBalise.TabIndex = 0;
            this.groupBalise.TabStop = false;
            this.groupBalise.Text = "Balise";
            // 
            // ctrlGraphiqueAngle2
            // 
            this.ctrlGraphiqueAngle2.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueAngle2.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphiqueAngle2.MaxLimit = 1D;
            this.ctrlGraphiqueAngle2.MinLimit = 0D;
            this.ctrlGraphiqueAngle2.Location = new System.Drawing.Point(167, 270);
            this.ctrlGraphiqueAngle2.Name = "ctrlGraphiqueAngle2";
            this.ctrlGraphiqueAngle2.Size = new System.Drawing.Size(160, 120);
            this.ctrlGraphiqueAngle2.TabIndex = 23;
            // 
            // ctrlGraphiqueDistance2
            // 
            this.ctrlGraphiqueDistance2.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueDistance2.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphiqueDistance2.MaxLimit = 1D;
            this.ctrlGraphiqueDistance2.MinLimit = 0D;
            this.ctrlGraphiqueDistance2.Location = new System.Drawing.Point(167, 396);
            this.ctrlGraphiqueDistance2.Name = "ctrlGraphiqueDistance2";
            this.ctrlGraphiqueDistance2.Size = new System.Drawing.Size(160, 120);
            this.ctrlGraphiqueDistance2.TabIndex = 22;
            // 
            // ctrlGraphiqueDistance1
            // 
            this.ctrlGraphiqueDistance1.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueDistance1.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphiqueDistance1.MaxLimit = 1D;
            this.ctrlGraphiqueDistance1.MinLimit = 0D;
            this.ctrlGraphiqueDistance1.Location = new System.Drawing.Point(3, 396);
            this.ctrlGraphiqueDistance1.Name = "ctrlGraphiqueDistance1";
            this.ctrlGraphiqueDistance1.Size = new System.Drawing.Size(160, 120);
            this.ctrlGraphiqueDistance1.TabIndex = 21;
            // 
            // ctrlGraphiqueAngle1
            // 
            this.ctrlGraphiqueAngle1.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueAngle1.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphiqueAngle1.MaxLimit = 1D;
            this.ctrlGraphiqueAngle1.MinLimit = 0D;
            this.ctrlGraphiqueAngle1.Location = new System.Drawing.Point(3, 270);
            this.ctrlGraphiqueAngle1.Name = "ctrlGraphiqueAngle1";
            this.ctrlGraphiqueAngle1.Size = new System.Drawing.Size(160, 120);
            this.ctrlGraphiqueAngle1.TabIndex = 20;
            // 
            // lblStabiliteDistance2
            // 
            this.lblStabiliteDistance2.AutoSize = true;
            this.lblStabiliteDistance2.Location = new System.Drawing.Point(206, 549);
            this.lblStabiliteDistance2.Name = "lblStabiliteDistance2";
            this.lblStabiliteDistance2.Size = new System.Drawing.Size(10, 13);
            this.lblStabiliteDistance2.TabIndex = 17;
            this.lblStabiliteDistance2.Text = "-";
            // 
            // lblStabiliteAngle2
            // 
            this.lblStabiliteAngle2.AutoSize = true;
            this.lblStabiliteAngle2.Location = new System.Drawing.Point(206, 527);
            this.lblStabiliteAngle2.Name = "lblStabiliteAngle2";
            this.lblStabiliteAngle2.Size = new System.Drawing.Size(10, 13);
            this.lblStabiliteAngle2.TabIndex = 16;
            this.lblStabiliteAngle2.Text = "-";
            // 
            // ctrlGraphiquePWM
            // 
            this.ctrlGraphiquePWM.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiquePWM.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphiquePWM.MaxLimit = 1D;
            this.ctrlGraphiquePWM.MinLimit = 0D;
            this.ctrlGraphiquePWM.Location = new System.Drawing.Point(3, 144);
            this.ctrlGraphiquePWM.Name = "ctrlGraphiquePWM";
            this.ctrlGraphiquePWM.Size = new System.Drawing.Size(324, 120);
            this.ctrlGraphiquePWM.TabIndex = 15;
            // 
            // lblNbTrames
            // 
            this.lblNbTrames.AutoSize = true;
            this.lblNbTrames.Location = new System.Drawing.Point(193, 577);
            this.lblNbTrames.Name = "lblNbTrames";
            this.lblNbTrames.Size = new System.Drawing.Size(63, 13);
            this.lblNbTrames.TabIndex = 14;
            this.lblNbTrames.Text = "0 messages";
            // 
            // btnLancer
            // 
            this.btnLancer.Location = new System.Drawing.Point(61, 572);
            this.btnLancer.Name = "btnLancer";
            this.btnLancer.Size = new System.Drawing.Size(60, 23);
            this.btnLancer.TabIndex = 13;
            this.btnLancer.Text = "Lancer";
            this.btnLancer.UseVisualStyleBackColor = true;
            this.btnLancer.Click += new System.EventHandler(this.btnLancer_Click);
            // 
            // lblStabiliteDistance1
            // 
            this.lblStabiliteDistance1.AutoSize = true;
            this.lblStabiliteDistance1.Location = new System.Drawing.Point(122, 549);
            this.lblStabiliteDistance1.Name = "lblStabiliteDistance1";
            this.lblStabiliteDistance1.Size = new System.Drawing.Size(10, 13);
            this.lblStabiliteDistance1.TabIndex = 11;
            this.lblStabiliteDistance1.Text = "-";
            // 
            // lblStabiliteAngle1
            // 
            this.lblStabiliteAngle1.AutoSize = true;
            this.lblStabiliteAngle1.Location = new System.Drawing.Point(122, 527);
            this.lblStabiliteAngle1.Name = "lblStabiliteAngle1";
            this.lblStabiliteAngle1.Size = new System.Drawing.Size(10, 13);
            this.lblStabiliteAngle1.TabIndex = 10;
            this.lblStabiliteAngle1.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 549);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stabilité distance :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 527);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stabilité angle :";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(127, 572);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(60, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ctrlGraphiqueTemps
            // 
            this.ctrlGraphiqueTemps.BackColor = System.Drawing.Color.White;
            this.ctrlGraphiqueTemps.GraphScale = Composants.GraphPanel.ScaleType.DynamicGlobal;
            this.ctrlGraphiqueTemps.MaxLimit = 1D;
            this.ctrlGraphiqueTemps.MinLimit = 0D;
            this.ctrlGraphiqueTemps.Location = new System.Drawing.Point(6, 18);
            this.ctrlGraphiqueTemps.Name = "ctrlGraphiqueTemps";
            this.ctrlGraphiqueTemps.Size = new System.Drawing.Size(321, 120);
            this.ctrlGraphiqueTemps.TabIndex = 4;
            // 
            // PanelDiagnosticBalise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBalise);
            this.Name = "PanelDiagnosticBalise";
            this.Size = new System.Drawing.Size(333, 604);
            this.groupBalise.ResumeLayout(false);
            this.groupBalise.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBalise;
        private System.Windows.Forms.Label lblStabiliteDistance1;
        private System.Windows.Forms.Label lblStabiliteAngle1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private Composants.GraphPanel ctrlGraphiqueTemps;
        private System.Windows.Forms.Button btnLancer;
        private System.Windows.Forms.Label lblNbTrames;
        private Composants.GraphPanel ctrlGraphiquePWM;
        private System.Windows.Forms.Label lblStabiliteDistance2;
        private System.Windows.Forms.Label lblStabiliteAngle2;
        private Composants.GraphPanel ctrlGraphiqueAngle2;
        private Composants.GraphPanel ctrlGraphiqueDistance2;
        private Composants.GraphPanel ctrlGraphiqueDistance1;
        private Composants.GraphPanel ctrlGraphiqueAngle1;
    }
}
