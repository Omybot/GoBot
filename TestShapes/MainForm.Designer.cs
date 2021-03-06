﻿namespace TestShapes
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnContained = new Composants.SwitchButton();
            this.btnCrossingPoints = new Composants.SwitchButton();
            this.btnCrossing = new Composants.SwitchButton();
            this.btnBarycenter = new Composants.SwitchButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGrid = new Composants.SwitchButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEmpty = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpDrawTools = new System.Windows.Forms.GroupBox();
            this.btnRectangle = new System.Windows.Forms.RadioButton();
            this.btnLine = new System.Windows.Forms.RadioButton();
            this.btnCircle = new System.Windows.Forms.RadioButton();
            this.btnSegment = new System.Windows.Forms.RadioButton();
            this.btnCircleFromCenter = new System.Windows.Forms.RadioButton();
            this.grpDisplay = new System.Windows.Forms.GroupBox();
            this.btnAxes = new Composants.SwitchButton();
            this.lblAxes = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnZoom = new System.Windows.Forms.RadioButton();
            this.btnZoomMinus = new System.Windows.Forms.Button();
            this.btnZoomPlus = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnErase = new System.Windows.Forms.Button();
            this.picWorld = new System.Windows.Forms.PictureBox();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnOrigin = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.grpDrawTools.SuspendLayout();
            this.grpDisplay.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Barycentres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Formes croisées";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Points de croisement";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Formes contenues";
            // 
            // btnContained
            // 
            this.btnContained.AutoSize = true;
            this.btnContained.BackColor = System.Drawing.Color.Transparent;
            this.btnContained.Location = new System.Drawing.Point(6, 143);
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
            this.btnCrossingPoints.Location = new System.Drawing.Point(6, 118);
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
            this.btnCrossing.Location = new System.Drawing.Point(6, 93);
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
            this.btnBarycenter.Location = new System.Drawing.Point(6, 68);
            this.btnBarycenter.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnBarycenter.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnBarycenter.Mirrored = false;
            this.btnBarycenter.Name = "btnBarycenter";
            this.btnBarycenter.Size = new System.Drawing.Size(35, 15);
            this.btnBarycenter.TabIndex = 1;
            this.btnBarycenter.Value = true;
            this.btnBarycenter.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnBarycenter_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Grille";
            // 
            // btnGrid
            // 
            this.btnGrid.AutoSize = true;
            this.btnGrid.BackColor = System.Drawing.Color.Transparent;
            this.btnGrid.Location = new System.Drawing.Point(6, 19);
            this.btnGrid.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnGrid.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnGrid.Mirrored = false;
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(35, 15);
            this.btnGrid.TabIndex = 0;
            this.btnGrid.Value = true;
            this.btnGrid.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnGrid_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblItem,
            this.lblEmpty,
            this.lblPosition});
            this.statusStrip1.Location = new System.Drawing.Point(0, 661);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblItem
            // 
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(0, 17);
            // 
            // lblEmpty
            // 
            this.lblEmpty.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(587, 17);
            this.lblEmpty.Spring = true;
            // 
            // lblPosition
            // 
            this.lblPosition.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(133, 17);
            this.lblPosition.Text = "X =    0: Y =    0";
            // 
            // grpDrawTools
            // 
            this.grpDrawTools.Controls.Add(this.btnRectangle);
            this.grpDrawTools.Controls.Add(this.btnLine);
            this.grpDrawTools.Controls.Add(this.btnCircle);
            this.grpDrawTools.Controls.Add(this.btnSegment);
            this.grpDrawTools.Controls.Add(this.btnCircleFromCenter);
            this.grpDrawTools.Location = new System.Drawing.Point(3, 190);
            this.grpDrawTools.Name = "grpDrawTools";
            this.grpDrawTools.Size = new System.Drawing.Size(160, 114);
            this.grpDrawTools.TabIndex = 28;
            this.grpDrawTools.TabStop = false;
            this.grpDrawTools.Text = "Tracés";
            // 
            // btnRectangle
            // 
            this.btnRectangle.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnRectangle.Checked = true;
            this.btnRectangle.Image = global::TestShapes.Properties.Resources.Rectangle;
            this.btnRectangle.Location = new System.Drawing.Point(14, 19);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(40, 40);
            this.btnRectangle.TabIndex = 23;
            this.btnRectangle.TabStop = true;
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.CheckedChanged += new System.EventHandler(this.btnRectangle_CheckedChanged);
            // 
            // btnLine
            // 
            this.btnLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnLine.Image = global::TestShapes.Properties.Resources.Line;
            this.btnLine.Location = new System.Drawing.Point(106, 19);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(40, 40);
            this.btnLine.TabIndex = 27;
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.CheckedChanged += new System.EventHandler(this.btnLine_CheckedChanged);
            // 
            // btnCircle
            // 
            this.btnCircle.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnCircle.Image = global::TestShapes.Properties.Resources.Circle1;
            this.btnCircle.Location = new System.Drawing.Point(14, 65);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(40, 40);
            this.btnCircle.TabIndex = 24;
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.CheckedChanged += new System.EventHandler(this.btnCircle_CheckedChanged);
            // 
            // btnSegment
            // 
            this.btnSegment.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnSegment.Image = global::TestShapes.Properties.Resources.Segment;
            this.btnSegment.Location = new System.Drawing.Point(60, 19);
            this.btnSegment.Name = "btnSegment";
            this.btnSegment.Size = new System.Drawing.Size(40, 40);
            this.btnSegment.TabIndex = 26;
            this.btnSegment.UseVisualStyleBackColor = true;
            this.btnSegment.CheckedChanged += new System.EventHandler(this.btnSegment_CheckedChanged);
            // 
            // btnCircleFromCenter
            // 
            this.btnCircleFromCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnCircleFromCenter.Image = global::TestShapes.Properties.Resources.Circle2;
            this.btnCircleFromCenter.Location = new System.Drawing.Point(60, 65);
            this.btnCircleFromCenter.Name = "btnCircleFromCenter";
            this.btnCircleFromCenter.Size = new System.Drawing.Size(40, 40);
            this.btnCircleFromCenter.TabIndex = 25;
            this.btnCircleFromCenter.UseVisualStyleBackColor = true;
            this.btnCircleFromCenter.CheckedChanged += new System.EventHandler(this.btnCircleFromCenter_CheckedChanged);
            // 
            // grpDisplay
            // 
            this.grpDisplay.Controls.Add(this.btnAxes);
            this.grpDisplay.Controls.Add(this.lblAxes);
            this.grpDisplay.Controls.Add(this.btnGrid);
            this.grpDisplay.Controls.Add(this.btnBarycenter);
            this.grpDisplay.Controls.Add(this.btnCrossing);
            this.grpDisplay.Controls.Add(this.label5);
            this.grpDisplay.Controls.Add(this.btnCrossingPoints);
            this.grpDisplay.Controls.Add(this.btnContained);
            this.grpDisplay.Controls.Add(this.label4);
            this.grpDisplay.Controls.Add(this.label1);
            this.grpDisplay.Controls.Add(this.label3);
            this.grpDisplay.Controls.Add(this.label2);
            this.grpDisplay.Location = new System.Drawing.Point(3, 12);
            this.grpDisplay.Name = "grpDisplay";
            this.grpDisplay.Size = new System.Drawing.Size(160, 172);
            this.grpDisplay.TabIndex = 29;
            this.grpDisplay.TabStop = false;
            this.grpDisplay.Text = "Affichage";
            // 
            // btnAxes
            // 
            this.btnAxes.AutoSize = true;
            this.btnAxes.BackColor = System.Drawing.Color.Transparent;
            this.btnAxes.Location = new System.Drawing.Point(6, 43);
            this.btnAxes.MaximumSize = new System.Drawing.Size(35, 15);
            this.btnAxes.MinimumSize = new System.Drawing.Size(35, 15);
            this.btnAxes.Mirrored = false;
            this.btnAxes.Name = "btnAxes";
            this.btnAxes.Size = new System.Drawing.Size(35, 15);
            this.btnAxes.TabIndex = 13;
            this.btnAxes.Value = false;
            this.btnAxes.ValueChanged += new Composants.SwitchButton.ValueChangedDelegate(this.btnAxes_ValueChanged);
            // 
            // lblAxes
            // 
            this.lblAxes.AutoSize = true;
            this.lblAxes.Location = new System.Drawing.Point(47, 43);
            this.lblAxes.Name = "lblAxes";
            this.lblAxes.Size = new System.Drawing.Size(42, 13);
            this.lblAxes.TabIndex = 14;
            this.lblAxes.Text = "Repère";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnZoom);
            this.groupBox1.Controls.Add(this.btnZoomMinus);
            this.groupBox1.Controls.Add(this.btnZoomPlus);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnErase);
            this.groupBox1.Location = new System.Drawing.Point(3, 310);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 160);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outils";
            // 
            // btnZoom
            // 
            this.btnZoom.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnZoom.Image = global::TestShapes.Properties.Resources.Rectangle;
            this.btnZoom.Location = new System.Drawing.Point(60, 114);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(40, 40);
            this.btnZoom.TabIndex = 28;
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.CheckedChanged += new System.EventHandler(this.btnZoom_CheckedChanged);
            // 
            // btnZoomMinus
            // 
            this.btnZoomMinus.Location = new System.Drawing.Point(83, 85);
            this.btnZoomMinus.Name = "btnZoomMinus";
            this.btnZoomMinus.Size = new System.Drawing.Size(63, 23);
            this.btnZoomMinus.TabIndex = 32;
            this.btnZoomMinus.Text = "Zoom -";
            this.btnZoomMinus.UseVisualStyleBackColor = true;
            this.btnZoomMinus.Click += new System.EventHandler(this.btnZoomMinus_Click);
            // 
            // btnZoomPlus
            // 
            this.btnZoomPlus.Location = new System.Drawing.Point(14, 85);
            this.btnZoomPlus.Name = "btnZoomPlus";
            this.btnZoomPlus.Size = new System.Drawing.Size(63, 23);
            this.btnZoomPlus.TabIndex = 31;
            this.btnZoomPlus.Text = "Zoom +";
            this.btnZoomPlus.UseVisualStyleBackColor = true;
            this.btnZoomPlus.Click += new System.EventHandler(this.btnZoomPlus_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::TestShapes.Properties.Resources.Cancel;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(14, 55);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 24);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Supprimer une forme";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnErase
            // 
            this.btnErase.Image = global::TestShapes.Properties.Resources.FileNew;
            this.btnErase.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnErase.Location = new System.Drawing.Point(14, 25);
            this.btnErase.Name = "btnErase";
            this.btnErase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnErase.Size = new System.Drawing.Size(134, 24);
            this.btnErase.TabIndex = 0;
            this.btnErase.Text = "Page vierge";
            this.btnErase.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnErase.UseVisualStyleBackColor = true;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // picWorld
            // 
            this.picWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picWorld.BackColor = System.Drawing.Color.White;
            this.picWorld.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picWorld.Location = new System.Drawing.Point(169, 0);
            this.picWorld.Name = "picWorld";
            this.picWorld.Size = new System.Drawing.Size(566, 684);
            this.picWorld.TabIndex = 1;
            this.picWorld.TabStop = false;
            this.picWorld.SizeChanged += new System.EventHandler(this.picWorld_SizeChanged);
            this.picWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.picWorld_Paint);
            this.picWorld.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picWorld_MouseDown);
            this.picWorld.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picWorld_MouseMove);
            this.picWorld.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picWorld_MouseUp);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(90, 503);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(23, 23);
            this.btnRight.TabIndex = 31;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(44, 503);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(23, 23);
            this.btnLeft.TabIndex = 32;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(69, 476);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(23, 23);
            this.btnUp.TabIndex = 33;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(69, 532);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(23, 23);
            this.btnDown.TabIndex = 34;
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnOrigin
            // 
            this.btnOrigin.Location = new System.Drawing.Point(69, 505);
            this.btnOrigin.Name = "btnOrigin";
            this.btnOrigin.Size = new System.Drawing.Size(23, 23);
            this.btnOrigin.TabIndex = 35;
            this.btnOrigin.Text = "x";
            this.btnOrigin.UseVisualStyleBackColor = true;
            this.btnOrigin.Click += new System.EventHandler(this.btnOrigin_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 683);
            this.Controls.Add(this.btnOrigin);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDisplay);
            this.Controls.Add(this.grpDrawTools);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.picWorld);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Geometry Tester";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpDrawTools.ResumeLayout(false);
            this.grpDisplay.ResumeLayout(false);
            this.grpDisplay.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Label label5;
        private Composants.SwitchButton btnGrid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblPosition;
        private System.Windows.Forms.ToolStripStatusLabel lblEmpty;
        private System.Windows.Forms.ToolStripStatusLabel lblItem;
        private System.Windows.Forms.RadioButton btnRectangle;
        private System.Windows.Forms.RadioButton btnCircle;
        private System.Windows.Forms.RadioButton btnCircleFromCenter;
        private System.Windows.Forms.RadioButton btnSegment;
        private System.Windows.Forms.RadioButton btnLine;
        private System.Windows.Forms.GroupBox grpDrawTools;
        private System.Windows.Forms.GroupBox grpDisplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.Button btnDelete;
        private Composants.SwitchButton btnAxes;
        private System.Windows.Forms.Label lblAxes;
        private System.Windows.Forms.Button btnZoomMinus;
        private System.Windows.Forms.Button btnZoomPlus;
        private System.Windows.Forms.RadioButton btnZoom;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnOrigin;
    }
}

