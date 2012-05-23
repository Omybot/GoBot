﻿namespace IhmRobot.IHM.IHMGrosRobot
{
    partial class DeplacementGrosRobot
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
            this.groupDeplacement = new System.Windows.Forms.GroupBox();
            this.lblValeurAccel = new System.Windows.Forms.Label();
            this.lblValeurVitesse = new System.Windows.Forms.Label();
            this.trackBarAccel = new IhmRobot.IHM.Composants.TrackBarPlus();
            this.trackBarVitesse = new IhmRobot.IHM.Composants.TrackBarPlus();
            this.btnTaille = new System.Windows.Forms.Button();
            this.pictureBoxReglageVertical = new System.Windows.Forms.PictureBox();
            this.btnVirageArDr = new System.Windows.Forms.Button();
            this.boxPivot = new System.Windows.Forms.CheckBox();
            this.btnPivotGauche = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnVirageArGa = new System.Windows.Forms.Button();
            this.lblAcceleration = new System.Windows.Forms.Label();
            this.btnPivotDroite = new System.Windows.Forms.Button();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.btnVirageAvGa = new System.Windows.Forms.Button();
            this.btnVirageAvDr = new System.Windows.Forms.Button();
            this.btnRecule = new System.Windows.Forms.Button();
            this.txtAngle = new IhmRobot.IHM.Composants.BetterTextBox();
            this.txtDistance = new IhmRobot.IHM.Composants.BetterTextBox();
            this.btnAvance = new System.Windows.Forms.Button();
            this.groupDeplacement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReglageVertical)).BeginInit();
            this.SuspendLayout();
            // 
            // groupDeplacement
            // 
            this.groupDeplacement.BackColor = System.Drawing.Color.Transparent;
            this.groupDeplacement.Controls.Add(this.lblValeurAccel);
            this.groupDeplacement.Controls.Add(this.lblValeurVitesse);
            this.groupDeplacement.Controls.Add(this.trackBarAccel);
            this.groupDeplacement.Controls.Add(this.trackBarVitesse);
            this.groupDeplacement.Controls.Add(this.btnTaille);
            this.groupDeplacement.Controls.Add(this.pictureBoxReglageVertical);
            this.groupDeplacement.Controls.Add(this.btnVirageArDr);
            this.groupDeplacement.Controls.Add(this.boxPivot);
            this.groupDeplacement.Controls.Add(this.btnPivotGauche);
            this.groupDeplacement.Controls.Add(this.btnStop);
            this.groupDeplacement.Controls.Add(this.btnVirageArGa);
            this.groupDeplacement.Controls.Add(this.lblAcceleration);
            this.groupDeplacement.Controls.Add(this.btnPivotDroite);
            this.groupDeplacement.Controls.Add(this.lblVitesse);
            this.groupDeplacement.Controls.Add(this.btnVirageAvGa);
            this.groupDeplacement.Controls.Add(this.btnVirageAvDr);
            this.groupDeplacement.Controls.Add(this.btnRecule);
            this.groupDeplacement.Controls.Add(this.txtAngle);
            this.groupDeplacement.Controls.Add(this.txtDistance);
            this.groupDeplacement.Controls.Add(this.btnAvance);
            this.groupDeplacement.Location = new System.Drawing.Point(3, 3);
            this.groupDeplacement.Name = "groupDeplacement";
            this.groupDeplacement.Size = new System.Drawing.Size(331, 237);
            this.groupDeplacement.TabIndex = 69;
            this.groupDeplacement.TabStop = false;
            this.groupDeplacement.Text = "Déplacement";
            // 
            // lblValeurAccel
            // 
            this.lblValeurAccel.Location = new System.Drawing.Point(227, 180);
            this.lblValeurAccel.Name = "lblValeurAccel";
            this.lblValeurAccel.Size = new System.Drawing.Size(57, 13);
            this.lblValeurAccel.TabIndex = 90;
            this.lblValeurAccel.Text = "0";
            this.lblValeurAccel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValeurVitesse
            // 
            this.lblValeurVitesse.Location = new System.Drawing.Point(229, 142);
            this.lblValeurVitesse.Name = "lblValeurVitesse";
            this.lblValeurVitesse.Size = new System.Drawing.Size(57, 13);
            this.lblValeurVitesse.TabIndex = 89;
            this.lblValeurVitesse.Text = "0";
            this.lblValeurVitesse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBarAccel
            // 
            this.trackBarAccel.BackColor = System.Drawing.Color.Transparent;
            this.trackBarAccel.Location = new System.Drawing.Point(38, 197);
            this.trackBarAccel.Max = 100D;
            this.trackBarAccel.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarAccel.MiliSecMin = 1;
            this.trackBarAccel.Min = 0D;
            this.trackBarAccel.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarAccel.Name = "trackBarAccel";
            this.trackBarAccel.Reverse = false;
            this.trackBarAccel.Size = new System.Drawing.Size(246, 15);
            this.trackBarAccel.TabIndex = 88;
            this.trackBarAccel.Value = 0D;
            this.trackBarAccel.TickValueChanged += new IhmRobot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarAccel_TickValueChanged);
            this.trackBarAccel.ValueChanged += new IhmRobot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarAccel_ValueChanged);
            // 
            // trackBarVitesse
            // 
            this.trackBarVitesse.BackColor = System.Drawing.Color.Transparent;
            this.trackBarVitesse.Location = new System.Drawing.Point(38, 157);
            this.trackBarVitesse.Max = 100D;
            this.trackBarVitesse.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarVitesse.MiliSecMin = 1;
            this.trackBarVitesse.Min = 0D;
            this.trackBarVitesse.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarVitesse.Name = "trackBarVitesse";
            this.trackBarVitesse.Reverse = false;
            this.trackBarVitesse.Size = new System.Drawing.Size(246, 15);
            this.trackBarVitesse.TabIndex = 87;
            this.trackBarVitesse.Value = 0D;
            this.trackBarVitesse.TickValueChanged += new IhmRobot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarVitesse_TickValueChanged);
            this.trackBarVitesse.ValueChanged += new IhmRobot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarVitesse_ValueChanged);
            // 
            // btnTaille
            // 
            this.btnTaille.Image = global::IhmRobot.Properties.Resources.haut;
            this.btnTaille.Location = new System.Drawing.Point(301, 10);
            this.btnTaille.Name = "btnTaille";
            this.btnTaille.Size = new System.Drawing.Size(24, 23);
            this.btnTaille.TabIndex = 86;
            this.btnTaille.UseVisualStyleBackColor = true;
            this.btnTaille.Click += new System.EventHandler(this.btnTaille_Click);
            // 
            // pictureBoxReglageVertical
            // 
            this.pictureBoxReglageVertical.Image = global::IhmRobot.Properties.Resources.reglagePivot;
            this.pictureBoxReglageVertical.Location = new System.Drawing.Point(6, 157);
            this.pictureBoxReglageVertical.Name = "pictureBoxReglageVertical";
            this.pictureBoxReglageVertical.Size = new System.Drawing.Size(11, 65);
            this.pictureBoxReglageVertical.TabIndex = 75;
            this.pictureBoxReglageVertical.TabStop = false;
            // 
            // btnVirageArDr
            // 
            this.btnVirageArDr.Image = global::IhmRobot.Properties.Resources.virageArDr;
            this.btnVirageArDr.Location = new System.Drawing.Point(254, 100);
            this.btnVirageArDr.Name = "btnVirageArDr";
            this.btnVirageArDr.Size = new System.Drawing.Size(32, 23);
            this.btnVirageArDr.TabIndex = 84;
            this.btnVirageArDr.UseVisualStyleBackColor = true;
            this.btnVirageArDr.Click += new System.EventHandler(this.btnVirageArDr_Click);
            // 
            // boxPivot
            // 
            this.boxPivot.AutoSize = true;
            this.boxPivot.Location = new System.Drawing.Point(5, 139);
            this.boxPivot.Name = "boxPivot";
            this.boxPivot.Size = new System.Drawing.Size(15, 14);
            this.boxPivot.TabIndex = 58;
            this.boxPivot.UseVisualStyleBackColor = true;
            this.boxPivot.CheckedChanged += new System.EventHandler(this.boxPivot_CheckedChanged_1);
            // 
            // btnPivotGauche
            // 
            this.btnPivotGauche.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPivotGauche.Image = global::IhmRobot.Properties.Resources.pivotGauche;
            this.btnPivotGauche.Location = new System.Drawing.Point(143, 48);
            this.btnPivotGauche.Name = "btnPivotGauche";
            this.btnPivotGauche.Size = new System.Drawing.Size(32, 48);
            this.btnPivotGauche.TabIndex = 77;
            this.btnPivotGauche.UseVisualStyleBackColor = true;
            this.btnPivotGauche.Click += new System.EventHandler(this.btnPivotGauche_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Image = global::IhmRobot.Properties.Resources.stop;
            this.btnStop.Location = new System.Drawing.Point(27, 29);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 90);
            this.btnStop.TabIndex = 63;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnVirageArGa
            // 
            this.btnVirageArGa.Image = global::IhmRobot.Properties.Resources.virageArGa;
            this.btnVirageArGa.Location = new System.Drawing.Point(143, 100);
            this.btnVirageArGa.Name = "btnVirageArGa";
            this.btnVirageArGa.Size = new System.Drawing.Size(32, 23);
            this.btnVirageArGa.TabIndex = 83;
            this.btnVirageArGa.UseVisualStyleBackColor = true;
            this.btnVirageArGa.Click += new System.EventHandler(this.btnVirageArGa_Click);
            // 
            // lblAcceleration
            // 
            this.lblAcceleration.Location = new System.Drawing.Point(35, 180);
            this.lblAcceleration.Name = "lblAcceleration";
            this.lblAcceleration.Size = new System.Drawing.Size(250, 13);
            this.lblAcceleration.TabIndex = 70;
            this.lblAcceleration.Text = "Accélération ligne";
            this.lblAcceleration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPivotDroite
            // 
            this.btnPivotDroite.Image = global::IhmRobot.Properties.Resources.pivotDroite;
            this.btnPivotDroite.Location = new System.Drawing.Point(254, 48);
            this.btnPivotDroite.Name = "btnPivotDroite";
            this.btnPivotDroite.Size = new System.Drawing.Size(32, 48);
            this.btnPivotDroite.TabIndex = 80;
            this.btnPivotDroite.UseVisualStyleBackColor = true;
            this.btnPivotDroite.Click += new System.EventHandler(this.btnPivotDroite_Click);
            // 
            // lblVitesse
            // 
            this.lblVitesse.Location = new System.Drawing.Point(35, 142);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(250, 13);
            this.lblVitesse.TabIndex = 69;
            this.lblVitesse.Text = "Vitesse ligne";
            this.lblVitesse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVirageAvGa
            // 
            this.btnVirageAvGa.Image = global::IhmRobot.Properties.Resources.virageAvGa;
            this.btnVirageAvGa.Location = new System.Drawing.Point(143, 21);
            this.btnVirageAvGa.Name = "btnVirageAvGa";
            this.btnVirageAvGa.Size = new System.Drawing.Size(32, 23);
            this.btnVirageAvGa.TabIndex = 81;
            this.btnVirageAvGa.UseVisualStyleBackColor = true;
            this.btnVirageAvGa.Click += new System.EventHandler(this.btnVirageAvGa_Click);
            // 
            // btnVirageAvDr
            // 
            this.btnVirageAvDr.Image = global::IhmRobot.Properties.Resources.virageAvDr;
            this.btnVirageAvDr.Location = new System.Drawing.Point(254, 21);
            this.btnVirageAvDr.Name = "btnVirageAvDr";
            this.btnVirageAvDr.Size = new System.Drawing.Size(32, 23);
            this.btnVirageAvDr.TabIndex = 82;
            this.btnVirageAvDr.UseVisualStyleBackColor = true;
            this.btnVirageAvDr.Click += new System.EventHandler(this.btnVirageAvDr_Click);
            // 
            // btnRecule
            // 
            this.btnRecule.Image = global::IhmRobot.Properties.Resources.recule;
            this.btnRecule.Location = new System.Drawing.Point(181, 100);
            this.btnRecule.Name = "btnRecule";
            this.btnRecule.Size = new System.Drawing.Size(67, 23);
            this.btnRecule.TabIndex = 79;
            this.btnRecule.UseVisualStyleBackColor = true;
            this.btnRecule.Click += new System.EventHandler(this.btnRecule_Click);
            // 
            // txtAngle
            // 
            this.txtAngle.BackColor = System.Drawing.Color.White;
            this.txtAngle.DefaultText = "Angle";
            this.txtAngle.ErrorMode = false;
            this.txtAngle.ForeColor = System.Drawing.Color.LightGray;
            this.txtAngle.Location = new System.Drawing.Point(181, 74);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(67, 20);
            this.txtAngle.TabIndex = 78;
            this.txtAngle.Text = "Angle";
            this.txtAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAngle.TextMode = IhmRobot.IHM.Composants.BetterTextBox.TextModeEnum.Decimal;
            // 
            // txtDistance
            // 
            this.txtDistance.BackColor = System.Drawing.Color.White;
            this.txtDistance.DefaultText = "Distance";
            this.txtDistance.ErrorMode = false;
            this.txtDistance.ForeColor = System.Drawing.Color.LightGray;
            this.txtDistance.Location = new System.Drawing.Point(181, 50);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(67, 20);
            this.txtDistance.TabIndex = 76;
            this.txtDistance.Text = "Distance";
            this.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDistance.TextMode = IhmRobot.IHM.Composants.BetterTextBox.TextModeEnum.Numeric;
            // 
            // btnAvance
            // 
            this.btnAvance.Image = global::IhmRobot.Properties.Resources.avance;
            this.btnAvance.Location = new System.Drawing.Point(181, 21);
            this.btnAvance.Name = "btnAvance";
            this.btnAvance.Size = new System.Drawing.Size(67, 23);
            this.btnAvance.TabIndex = 75;
            this.btnAvance.UseVisualStyleBackColor = true;
            this.btnAvance.Click += new System.EventHandler(this.btnAvance_Click);
            // 
            // DeplacementGrosRobot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupDeplacement);
            this.Name = "DeplacementGrosRobot";
            this.Size = new System.Drawing.Size(340, 266);
            this.groupDeplacement.ResumeLayout(false);
            this.groupDeplacement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReglageVertical)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDeplacement;
        private System.Windows.Forms.Button btnTaille;
        private System.Windows.Forms.PictureBox pictureBoxReglageVertical;
        private System.Windows.Forms.Button btnVirageArDr;
        private System.Windows.Forms.CheckBox boxPivot;
        private System.Windows.Forms.Button btnPivotGauche;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnVirageArGa;
        private System.Windows.Forms.Label lblAcceleration;
        private System.Windows.Forms.Button btnPivotDroite;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.Button btnVirageAvGa;
        private System.Windows.Forms.Button btnVirageAvDr;
        private System.Windows.Forms.Button btnRecule;
        private Composants.BetterTextBox txtAngle;
        private Composants.BetterTextBox txtDistance;
        private System.Windows.Forms.Button btnAvance;
        private Composants.TrackBarPlus trackBarVitesse;
        private Composants.TrackBarPlus trackBarAccel;
        private System.Windows.Forms.Label lblValeurAccel;
        private System.Windows.Forms.Label lblValeurVitesse;
    }
}
