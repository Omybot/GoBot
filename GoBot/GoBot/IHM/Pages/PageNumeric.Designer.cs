namespace GoBot.IHM.Pages
{
    partial class PanelBoardNumeric
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
            this.lblPortA = new System.Windows.Forms.Label();
            this.pnlPortA = new System.Windows.Forms.Panel();
            this.switchButtonPortA = new Composants.SwitchButton();
            this.byteBinaryGraphA2 = new Composants.ByteBinaryGraph();
            this.byteBinaryGraphA1 = new Composants.ByteBinaryGraph();
            this.pnlPortB = new System.Windows.Forms.Panel();
            this.switchButtonPortB = new Composants.SwitchButton();
            this.byteBinaryGraphB2 = new Composants.ByteBinaryGraph();
            this.byteBinaryGraphB1 = new Composants.ByteBinaryGraph();
            this.lblPortB = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.switchButtonPortC = new Composants.SwitchButton();
            this.byteBinaryGraphC2 = new Composants.ByteBinaryGraph();
            this.byteBinaryGraphC1 = new Composants.ByteBinaryGraph();
            this.lblPortC = new System.Windows.Forms.Label();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPortA.SuspendLayout();
            this.pnlPortB.SuspendLayout();
            this.panel1.SuspendLayout();
            this.layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPortA
            // 
            this.lblPortA.AutoSize = true;
            this.lblPortA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortA.Location = new System.Drawing.Point(120, 9);
            this.lblPortA.Name = "lblPortA";
            this.lblPortA.Size = new System.Drawing.Size(71, 25);
            this.lblPortA.TabIndex = 9;
            this.lblPortA.Text = "Port A";
            // 
            // pnlPortA
            // 
            this.pnlPortA.Controls.Add(this.switchButtonPortA);
            this.pnlPortA.Controls.Add(this.byteBinaryGraphA2);
            this.pnlPortA.Controls.Add(this.byteBinaryGraphA1);
            this.pnlPortA.Controls.Add(this.lblPortA);
            this.pnlPortA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPortA.Location = new System.Drawing.Point(3, 3);
            this.pnlPortA.Name = "pnlPortA";
            this.pnlPortA.Size = new System.Drawing.Size(381, 472);
            this.pnlPortA.TabIndex = 12;
            // 
            // switchButtonPortA
            // 
            this.switchButtonPortA.AutoSize = true;
            this.switchButtonPortA.BackColor = System.Drawing.Color.Transparent;
            this.switchButtonPortA.Location = new System.Drawing.Point(197, 15);
            this.switchButtonPortA.MaximumSize = new System.Drawing.Size(35, 15);
            this.switchButtonPortA.MinimumSize = new System.Drawing.Size(35, 15);
            this.switchButtonPortA.Mirrored = false;
            this.switchButtonPortA.Name = "switchButtonPortA";
            this.switchButtonPortA.Size = new System.Drawing.Size(35, 15);
            this.switchButtonPortA.TabIndex = 6;
            this.switchButtonPortA.Value = false;
            this.switchButtonPortA.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.switchButtonPort_ValueChanged);
            // 
            // byteBinaryGraphA2
            // 
            this.byteBinaryGraphA2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.byteBinaryGraphA2.BackColor = System.Drawing.Color.Transparent;
            this.byteBinaryGraphA2.Location = new System.Drawing.Point(13, 253);
            this.byteBinaryGraphA2.Name = "byteBinaryGraphA2";
            this.byteBinaryGraphA2.Size = new System.Drawing.Size(360, 208);
            this.byteBinaryGraphA2.TabIndex = 0;
            // 
            // byteBinaryGraphA1
            // 
            this.byteBinaryGraphA1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.byteBinaryGraphA1.BackColor = System.Drawing.Color.Transparent;
            this.byteBinaryGraphA1.Location = new System.Drawing.Point(13, 45);
            this.byteBinaryGraphA1.Name = "byteBinaryGraphA1";
            this.byteBinaryGraphA1.Size = new System.Drawing.Size(360, 208);
            this.byteBinaryGraphA1.TabIndex = 1;
            // 
            // pnlPortB
            // 
            this.pnlPortB.Controls.Add(this.switchButtonPortB);
            this.pnlPortB.Controls.Add(this.byteBinaryGraphB2);
            this.pnlPortB.Controls.Add(this.byteBinaryGraphB1);
            this.pnlPortB.Controls.Add(this.lblPortB);
            this.pnlPortB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPortB.Location = new System.Drawing.Point(390, 3);
            this.pnlPortB.Name = "pnlPortB";
            this.pnlPortB.Size = new System.Drawing.Size(381, 472);
            this.pnlPortB.TabIndex = 13;
            // 
            // switchButtonPortB
            // 
            this.switchButtonPortB.AutoSize = true;
            this.switchButtonPortB.BackColor = System.Drawing.Color.Transparent;
            this.switchButtonPortB.Location = new System.Drawing.Point(197, 15);
            this.switchButtonPortB.MaximumSize = new System.Drawing.Size(35, 15);
            this.switchButtonPortB.MinimumSize = new System.Drawing.Size(35, 15);
            this.switchButtonPortB.Mirrored = false;
            this.switchButtonPortB.Name = "switchButtonPortB";
            this.switchButtonPortB.Size = new System.Drawing.Size(35, 15);
            this.switchButtonPortB.TabIndex = 6;
            this.switchButtonPortB.Value = false;
            this.switchButtonPortB.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.switchButtonPort_ValueChanged);
            // 
            // byteBinaryGraphB2
            // 
            this.byteBinaryGraphB2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.byteBinaryGraphB2.BackColor = System.Drawing.Color.Transparent;
            this.byteBinaryGraphB2.Location = new System.Drawing.Point(13, 253);
            this.byteBinaryGraphB2.Name = "byteBinaryGraphB2";
            this.byteBinaryGraphB2.Size = new System.Drawing.Size(360, 208);
            this.byteBinaryGraphB2.TabIndex = 0;
            // 
            // byteBinaryGraphB1
            // 
            this.byteBinaryGraphB1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.byteBinaryGraphB1.BackColor = System.Drawing.Color.Transparent;
            this.byteBinaryGraphB1.Location = new System.Drawing.Point(13, 45);
            this.byteBinaryGraphB1.Name = "byteBinaryGraphB1";
            this.byteBinaryGraphB1.Size = new System.Drawing.Size(360, 208);
            this.byteBinaryGraphB1.TabIndex = 1;
            // 
            // lblPortB
            // 
            this.lblPortB.AutoSize = true;
            this.lblPortB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortB.Location = new System.Drawing.Point(120, 9);
            this.lblPortB.Name = "lblPortB";
            this.lblPortB.Size = new System.Drawing.Size(71, 25);
            this.lblPortB.TabIndex = 9;
            this.lblPortB.Text = "Port B";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.switchButtonPortC);
            this.panel1.Controls.Add(this.byteBinaryGraphC2);
            this.panel1.Controls.Add(this.byteBinaryGraphC1);
            this.panel1.Controls.Add(this.lblPortC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(777, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 472);
            this.panel1.TabIndex = 14;
            // 
            // switchButtonPortC
            // 
            this.switchButtonPortC.AutoSize = true;
            this.switchButtonPortC.BackColor = System.Drawing.Color.Transparent;
            this.switchButtonPortC.Location = new System.Drawing.Point(197, 15);
            this.switchButtonPortC.MaximumSize = new System.Drawing.Size(35, 15);
            this.switchButtonPortC.MinimumSize = new System.Drawing.Size(35, 15);
            this.switchButtonPortC.Mirrored = false;
            this.switchButtonPortC.Name = "switchButtonPortC";
            this.switchButtonPortC.Size = new System.Drawing.Size(35, 15);
            this.switchButtonPortC.TabIndex = 6;
            this.switchButtonPortC.Value = false;
            this.switchButtonPortC.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.switchButtonPort_ValueChanged);
            // 
            // byteBinaryGraphC2
            // 
            this.byteBinaryGraphC2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.byteBinaryGraphC2.BackColor = System.Drawing.Color.Transparent;
            this.byteBinaryGraphC2.Location = new System.Drawing.Point(13, 253);
            this.byteBinaryGraphC2.Name = "byteBinaryGraphC2";
            this.byteBinaryGraphC2.Size = new System.Drawing.Size(362, 208);
            this.byteBinaryGraphC2.TabIndex = 0;
            // 
            // byteBinaryGraphC1
            // 
            this.byteBinaryGraphC1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.byteBinaryGraphC1.BackColor = System.Drawing.Color.Transparent;
            this.byteBinaryGraphC1.Location = new System.Drawing.Point(13, 45);
            this.byteBinaryGraphC1.Name = "byteBinaryGraphC1";
            this.byteBinaryGraphC1.Size = new System.Drawing.Size(362, 208);
            this.byteBinaryGraphC1.TabIndex = 1;
            // 
            // lblPortC
            // 
            this.lblPortC.AutoSize = true;
            this.lblPortC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortC.Location = new System.Drawing.Point(120, 9);
            this.lblPortC.Name = "lblPortC";
            this.lblPortC.Size = new System.Drawing.Size(72, 25);
            this.lblPortC.TabIndex = 9;
            this.lblPortC.Text = "Port C";
            // 
            // layout
            // 
            this.layout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layout.ColumnCount = 3;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout.Controls.Add(this.pnlPortA, 0, 0);
            this.layout.Controls.Add(this.panel1, 2, 0);
            this.layout.Controls.Add(this.pnlPortB, 1, 0);
            this.layout.Location = new System.Drawing.Point(3, 45);
            this.layout.Name = "layout";
            this.layout.RowCount = 1;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Size = new System.Drawing.Size(1163, 478);
            this.layout.TabIndex = 15;
            // 
            // PanelBoardNumeric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layout);
            this.Name = "PanelBoardNumeric";
            this.Size = new System.Drawing.Size(1182, 591);
            this.pnlPortA.ResumeLayout(false);
            this.pnlPortA.PerformLayout();
            this.pnlPortB.ResumeLayout(false);
            this.pnlPortB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Composants.ByteBinaryGraph byteBinaryGraphA2;
        private Composants.ByteBinaryGraph byteBinaryGraphA1;
        private Composants.SwitchButton switchButtonPortA;
        private System.Windows.Forms.Label lblPortA;
        private System.Windows.Forms.Panel pnlPortA;
        private System.Windows.Forms.Panel pnlPortB;
        private Composants.SwitchButton switchButtonPortB;
        private Composants.ByteBinaryGraph byteBinaryGraphB2;
        private Composants.ByteBinaryGraph byteBinaryGraphB1;
        private System.Windows.Forms.Label lblPortB;
        private System.Windows.Forms.Panel panel1;
        private Composants.SwitchButton switchButtonPortC;
        private Composants.ByteBinaryGraph byteBinaryGraphC2;
        private Composants.ByteBinaryGraph byteBinaryGraphC1;
        private System.Windows.Forms.Label lblPortC;
        private System.Windows.Forms.TableLayoutPanel layout;
    }
}
