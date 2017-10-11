namespace Composants
{
    partial class BinaryGraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BinaryGraph));
            this.graph = new Composants.GraphPanel();
            this.led = new Composants.Led();
            ((System.ComponentModel.ISupportInitialize)(this.led)).BeginInit();
            this.SuspendLayout();
            // 
            // graph
            // 
            this.graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graph.BackColor = System.Drawing.Color.Gainsboro;
            this.graph.MaxLimit = 1.3D;
            this.graph.MinLimit = -0.3D;
            this.graph.Location = new System.Drawing.Point(26, 1);
            this.graph.GraphScale = GraphPanel.ScaleType.Fixed;
            this.graph.LimitsVisible = false;
            this.graph.Name = "graph";
            this.graph.NamesVisible = false;
            this.graph.Size = new System.Drawing.Size(187, 25);
            this.graph.TabIndex = 1;
            // 
            // led
            // 
            this.led.BackColor = System.Drawing.Color.Transparent;
            this.led.Image = ((System.Drawing.Image)(resources.GetObject("led.Image")));
            this.led.Location = new System.Drawing.Point(5, 5);
            this.led.Name = "led";
            this.led.Size = new System.Drawing.Size(16, 16);
            this.led.TabIndex = 0;
            this.led.TabStop = false;
            // 
            // BinaryGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.graph);
            this.Controls.Add(this.led);
            this.Name = "BinaryGraph";
            this.Size = new System.Drawing.Size(214, 27);
            ((System.ComponentModel.ISupportInitialize)(this.led)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Led led;
        private GraphPanel graph;
    }
}
