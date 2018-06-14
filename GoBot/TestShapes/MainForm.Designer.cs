namespace TestShapes
{
    partial class MainForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.picWorld = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnContained = new Composants.SwitchButton();
            this.btnCrossingPoints = new Composants.SwitchButton();
            this.btnCrossing = new Composants.SwitchButton();
            this.btnBarycenter = new Composants.SwitchButton();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGrid = new Composants.SwitchButton();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnSegment = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCircleFromCenter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // picWorld
            // 
            this.picWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picWorld.BackColor = System.Drawing.Color.White;
            this.picWorld.Location = new System.Drawing.Point(169, 0);
            this.picWorld.Name = "picWorld";
            this.picWorld.Size = new System.Drawing.Size(566, 684);
            this.picWorld.TabIndex = 1;
            this.picWorld.TabStop = false;
            this.picWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.picWorld_Paint);
            this.picWorld.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picWorld_MouseDown);
            this.picWorld.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picWorld_MouseMove);
            this.picWorld.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picWorld_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Barycentres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Formes croisées";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Points de croisement";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Formes contenues";
            // 
            // btnContained
            // 
            this.btnContained.AutoSize = true;
            this.btnContained.BackColor = System.Drawing.Color.Transparent;
            this.btnContained.Location = new System.Drawing.Point(10, 134);
            this.btnContained.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnContained.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnContained.Mirrored = false;
            this.btnContained.Name = "btnContained";
            this.btnContained.Size = new System.Drawing.Size(35, 15);
            this.btnContained.TabIndex = 4;
            this.btnContained.Value = true;
            this.btnContained.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnContained_ValueChanged);
            // 
            // btnCrossingPoints
            // 
            this.btnCrossingPoints.AutoSize = true;
            this.btnCrossingPoints.BackColor = System.Drawing.Color.Transparent;
            this.btnCrossingPoints.Location = new System.Drawing.Point(10, 109);
            this.btnCrossingPoints.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnCrossingPoints.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnCrossingPoints.Mirrored = false;
            this.btnCrossingPoints.Name = "btnCrossingPoints";
            this.btnCrossingPoints.Size = new System.Drawing.Size(35, 15);
            this.btnCrossingPoints.TabIndex = 3;
            this.btnCrossingPoints.Value = true;
            this.btnCrossingPoints.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnCrossingPoints_ValueChanged);
            // 
            // btnCrossing
            // 
            this.btnCrossing.AutoSize = true;
            this.btnCrossing.BackColor = System.Drawing.Color.Transparent;
            this.btnCrossing.Location = new System.Drawing.Point(10, 84);
            this.btnCrossing.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnCrossing.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnCrossing.Mirrored = false;
            this.btnCrossing.Name = "btnCrossing";
            this.btnCrossing.Size = new System.Drawing.Size(35, 15);
            this.btnCrossing.TabIndex = 2;
            this.btnCrossing.Value = true;
            this.btnCrossing.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnCrossing_ValueChanged);
            // 
            // btnBarycenter
            // 
            this.btnBarycenter.AutoSize = true;
            this.btnBarycenter.BackColor = System.Drawing.Color.Transparent;
            this.btnBarycenter.Location = new System.Drawing.Point(10, 59);
            this.btnBarycenter.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnBarycenter.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnBarycenter.Mirrored = false;
            this.btnBarycenter.Name = "btnBarycenter";
            this.btnBarycenter.Size = new System.Drawing.Size(35, 15);
            this.btnBarycenter.TabIndex = 1;
            this.btnBarycenter.Value = true;
            this.btnBarycenter.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnBarycenter_ValueChanged);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Image = global::TestShapes.Properties.Resources.Rectangle;
            this.btnRectangle.Location = new System.Drawing.Point(12, 198);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(40, 40);
            this.btnRectangle.TabIndex = 10;
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Grille";
            // 
            // btnGrid
            // 
            this.btnGrid.AutoSize = true;
            this.btnGrid.BackColor = System.Drawing.Color.Transparent;
            this.btnGrid.Location = new System.Drawing.Point(10, 33);
            this.btnGrid.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnGrid.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnGrid.Mirrored = false;
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(35, 15);
            this.btnGrid.TabIndex = 0;
            this.btnGrid.Value = true;
            this.btnGrid.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnGrid_ValueChanged);
            // 
            // btnCircle
            // 
            this.btnCircle.Image = global::TestShapes.Properties.Resources.Circle1;
            this.btnCircle.Location = new System.Drawing.Point(12, 244);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(40, 40);
            this.btnCircle.TabIndex = 13;
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnSegment
            // 
            this.btnSegment.Image = global::TestShapes.Properties.Resources.Segment;
            this.btnSegment.Location = new System.Drawing.Point(12, 290);
            this.btnSegment.Name = "btnSegment";
            this.btnSegment.Size = new System.Drawing.Size(40, 40);
            this.btnSegment.TabIndex = 14;
            this.btnSegment.UseVisualStyleBackColor = true;
            this.btnSegment.Click += new System.EventHandler(this.btnSegment_Click);
            // 
            // button3
            // 
            this.button3.Image = global::TestShapes.Properties.Resources.Line;
            this.button3.Location = new System.Drawing.Point(12, 336);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 15;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnCircleFromCenter
            // 
            this.btnCircleFromCenter.Image = global::TestShapes.Properties.Resources.Circle2;
            this.btnCircleFromCenter.Location = new System.Drawing.Point(58, 244);
            this.btnCircleFromCenter.Name = "btnCircleFromCenter";
            this.btnCircleFromCenter.Size = new System.Drawing.Size(40, 40);
            this.btnCircleFromCenter.TabIndex = 16;
            this.btnCircleFromCenter.UseVisualStyleBackColor = true;
            this.btnCircleFromCenter.Click += new System.EventHandler(this.btnCircleFromCenter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 683);
            this.Controls.Add(this.btnCircleFromCenter);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnSegment);
            this.Controls.Add(this.btnCircle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGrid);
            this.Controls.Add(this.btnRectangle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnContained);
            this.Controls.Add(this.btnCrossingPoints);
            this.Controls.Add(this.btnCrossing);
            this.Controls.Add(this.btnBarycenter);
            this.Controls.Add(this.picWorld);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Geometry Tester";
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picWorld;
        private Composants.SwitchButton btnBarycenter;
        private Composants.SwitchButton btnCrossing;
        private Composants.SwitchButton btnCrossingPoints;
        private Composants.SwitchButton btnContained;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Label label5;
        private Composants.SwitchButton btnGrid;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnSegment;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCircleFromCenter;
    }
}

