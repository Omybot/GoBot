namespace GoBot.IHM
{
    partial class PanelHokuyo
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
            this.components = new System.ComponentModel.Container();
            this.switchBouton1 = new Composants.SwitchBouton();
            this.rdoOutline = new System.Windows.Forms.RadioButton();
            this.rdoRays = new System.Windows.Forms.RadioButton();
            this.rdoShadows = new System.Windows.Forms.RadioButton();
            this.trackZoom = new Composants.TrackBarPlus();
            this.boxScale = new System.Windows.Forms.CheckBox();
            this.rdoObjects = new System.Windows.Forms.RadioButton();
            this.boxGroup = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.picWorld = new GoBot.IHM.WorldPanel(this.components);
            this.lblMousePosition = new System.Windows.Forms.Label();
            this.lblMousePositionTxt = new System.Windows.Forms.Label();
            this.lblMeasuresPerSecond = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // switchBouton1
            // 
            this.switchBouton1.BackColor = System.Drawing.Color.Transparent;
            this.switchBouton1.Location = new System.Drawing.Point(29, 16);
            this.switchBouton1.Name = "switchBouton1";
            this.switchBouton1.Size = new System.Drawing.Size(35, 15);
            this.switchBouton1.Symetrique = true;
            this.switchBouton1.TabIndex = 2;
            this.switchBouton1.ChangementEtat += new System.EventHandler(this.switchEnable_ChangementEtat);
            // 
            // rdoOutline
            // 
            this.rdoOutline.AutoSize = true;
            this.rdoOutline.Location = new System.Drawing.Point(19, 86);
            this.rdoOutline.Name = "rdoOutline";
            this.rdoOutline.Size = new System.Drawing.Size(62, 17);
            this.rdoOutline.TabIndex = 3;
            this.rdoOutline.Text = "Contour";
            this.rdoOutline.UseVisualStyleBackColor = true;
            // 
            // rdoRays
            // 
            this.rdoRays.AutoSize = true;
            this.rdoRays.Location = new System.Drawing.Point(19, 109);
            this.rdoRays.Name = "rdoRays";
            this.rdoRays.Size = new System.Drawing.Size(61, 17);
            this.rdoRays.TabIndex = 4;
            this.rdoRays.Text = "Rayons";
            this.rdoRays.UseVisualStyleBackColor = true;
            // 
            // rdoShadows
            // 
            this.rdoShadows.AutoSize = true;
            this.rdoShadows.Location = new System.Drawing.Point(19, 132);
            this.rdoShadows.Name = "rdoShadows";
            this.rdoShadows.Size = new System.Drawing.Size(61, 17);
            this.rdoShadows.TabIndex = 5;
            this.rdoShadows.Text = "Ombres";
            this.rdoShadows.UseVisualStyleBackColor = true;
            // 
            // trackZoom
            // 
            this.trackZoom.BackColor = System.Drawing.Color.Transparent;
            this.trackZoom.IntervalTimer = 1;
            this.trackZoom.Location = new System.Drawing.Point(3, 180);
            this.trackZoom.Max = 10D;
            this.trackZoom.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackZoom.Min = 0.1D;
            this.trackZoom.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.DecimalPlaces = 1;
            this.trackZoom.Reverse = false;
            this.trackZoom.Size = new System.Drawing.Size(90, 15);
            this.trackZoom.TabIndex = 6;
            this.trackZoom.Vertical = false;
            this.trackZoom.ValueChanged += new Composants.TrackBarPlus.ValueChangedDelegate(this.trackZoom_ValueChanged);
            // 
            // boxScale
            // 
            this.boxScale.AutoSize = true;
            this.boxScale.Checked = true;
            this.boxScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxScale.Location = new System.Drawing.Point(13, 233);
            this.boxScale.Name = "boxScale";
            this.boxScale.Size = new System.Drawing.Size(61, 17);
            this.boxScale.TabIndex = 7;
            this.boxScale.Text = "Echelle";
            this.boxScale.UseVisualStyleBackColor = true;
            // 
            // rdoObjects
            // 
            this.rdoObjects.AutoSize = true;
            this.rdoObjects.Checked = true;
            this.rdoObjects.Location = new System.Drawing.Point(19, 63);
            this.rdoObjects.Name = "rdoObjects";
            this.rdoObjects.Size = new System.Drawing.Size(55, 17);
            this.rdoObjects.TabIndex = 8;
            this.rdoObjects.TabStop = true;
            this.rdoObjects.Text = "Objets";
            this.rdoObjects.UseVisualStyleBackColor = true;
            // 
            // boxGroup
            // 
            this.boxGroup.AutoSize = true;
            this.boxGroup.Location = new System.Drawing.Point(13, 256);
            this.boxGroup.Name = "boxGroup";
            this.boxGroup.Size = new System.Drawing.Size(64, 17);
            this.boxGroup.TabIndex = 9;
            this.boxGroup.Text = "Grouper";
            this.boxGroup.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(6, 314);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Va chercher";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // picWorld
            // 
            this.picWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picWorld.Location = new System.Drawing.Point(110, 16);
            this.picWorld.Name = "picWorld";
            this.picWorld.Size = new System.Drawing.Size(727, 429);
            this.picWorld.TabIndex = 11;
            this.picWorld.TabStop = false;
            this.picWorld.WorldChange += new GoBot.IHM.WorldPanel.WorldChangeDelegate(this.picWorld_WorldChange);
            this.picWorld.Paint += new System.Windows.Forms.PaintEventHandler(this.picWorld_Paint);
            this.picWorld.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picWorld_MouseMove);
            // 
            // lblMousePosition
            // 
            this.lblMousePosition.Location = new System.Drawing.Point(0, 381);
            this.lblMousePosition.Name = "lblMousePosition";
            this.lblMousePosition.Size = new System.Drawing.Size(100, 23);
            this.lblMousePosition.TabIndex = 12;
            this.lblMousePosition.Text = "-";
            this.lblMousePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMousePositionTxt
            // 
            this.lblMousePositionTxt.AutoSize = true;
            this.lblMousePositionTxt.Location = new System.Drawing.Point(10, 368);
            this.lblMousePositionTxt.Name = "lblMousePositionTxt";
            this.lblMousePositionTxt.Size = new System.Drawing.Size(74, 13);
            this.lblMousePositionTxt.TabIndex = 13;
            this.lblMousePositionTxt.Text = "Position souris";
            // 
            // lblMeasuresPerSecond
            // 
            this.lblMeasuresPerSecond.Location = new System.Drawing.Point(0, 404);
            this.lblMeasuresPerSecond.Name = "lblMeasuresPerSecond";
            this.lblMeasuresPerSecond.Size = new System.Drawing.Size(100, 23);
            this.lblMeasuresPerSecond.TabIndex = 14;
            this.lblMeasuresPerSecond.Text = "-";
            this.lblMeasuresPerSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelHokuyo
            // 
            this.Controls.Add(this.lblMeasuresPerSecond);
            this.Controls.Add(this.lblMousePositionTxt);
            this.Controls.Add(this.lblMousePosition);
            this.Controls.Add(this.picWorld);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.boxGroup);
            this.Controls.Add(this.rdoObjects);
            this.Controls.Add(this.boxScale);
            this.Controls.Add(this.trackZoom);
            this.Controls.Add(this.rdoShadows);
            this.Controls.Add(this.rdoRays);
            this.Controls.Add(this.rdoOutline);
            this.Controls.Add(this.switchBouton1);
            this.Name = "PanelHokuyo";
            this.Size = new System.Drawing.Size(851, 461);
            this.Load += new System.EventHandler(this.PanelHokuyo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Composants.SwitchBouton switchBouton1;
        private System.Windows.Forms.RadioButton rdoOutline;
        private System.Windows.Forms.RadioButton rdoRays;
        private System.Windows.Forms.RadioButton rdoShadows;
        private Composants.TrackBarPlus trackZoom;
        private System.Windows.Forms.CheckBox boxScale;
        private System.Windows.Forms.RadioButton rdoObjects;
        private System.Windows.Forms.CheckBox boxGroup;
        private System.Windows.Forms.Button btnGo;
        private WorldPanel picWorld;
        private System.Windows.Forms.Label lblMousePosition;
        private System.Windows.Forms.Label lblMousePositionTxt;
        private System.Windows.Forms.Label lblMeasuresPerSecond;
    }
}
