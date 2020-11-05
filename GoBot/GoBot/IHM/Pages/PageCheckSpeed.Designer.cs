namespace GoBot.IHM.Pages
{
    partial class PageCheckSpeed
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
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.gphPos = new Composants.GraphPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // numDistance
            // 
            this.numDistance.Location = new System.Drawing.Point(73, 65);
            this.numDistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new System.Drawing.Size(63, 20);
            this.numDistance.TabIndex = 0;
            this.numDistance.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Distance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "mm";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(49, 132);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // gphPos
            // 
            this.gphPos.BackColor = System.Drawing.Color.White;
            this.gphPos.BorderColor = System.Drawing.Color.LightGray;
            this.gphPos.BorderVisible = false;
            this.gphPos.LimitsVisible = false;
            this.gphPos.Location = new System.Drawing.Point(208, 3);
            this.gphPos.MaxLimit = 1D;
            this.gphPos.MinLimit = 0D;
            this.gphPos.Name = "gphPos";
            this.gphPos.NamesAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.gphPos.NamesVisible = true;
            this.gphPos.ScaleMode = Composants.GraphPanel.ScaleType.DynamicPerCurve;
            this.gphPos.Size = new System.Drawing.Size(1043, 629);
            this.gphPos.TabIndex = 2;
            // 
            // PageCheckSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gphPos);
            this.Controls.Add(this.numDistance);
            this.Name = "PageCheckSpeed";
            this.Size = new System.Drawing.Size(1254, 635);
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numDistance;
        private Composants.GraphPanel gphPos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTest;
    }
}
