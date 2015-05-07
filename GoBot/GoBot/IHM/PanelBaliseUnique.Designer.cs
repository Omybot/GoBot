namespace GoBot.IHM
{
    partial class PanelBaliseUnique
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
            this.trackBarVitesse = new Composants.TrackBarPlus();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.boxAffichage = new System.Windows.Forms.CheckBox();
            this.pictureBoxAngle = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblToursSecondesActuel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarVitesse
            // 
            this.trackBarVitesse.BackColor = System.Drawing.Color.Transparent;
            this.trackBarVitesse.IntervalTimer = 1;
            this.trackBarVitesse.Location = new System.Drawing.Point(76, 76);
            this.trackBarVitesse.Max = 4000D;
            this.trackBarVitesse.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarVitesse.Min = 0D;
            this.trackBarVitesse.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarVitesse.Name = "trackBarVitesse";
            this.trackBarVitesse.NombreDecimales = 0;
            this.trackBarVitesse.Reverse = false;
            this.trackBarVitesse.Size = new System.Drawing.Size(270, 15);
            this.trackBarVitesse.TabIndex = 0;
            this.trackBarVitesse.Vertical = false;
            this.trackBarVitesse.TickValueChanged += new System.EventHandler(this.trackBarVitesse_TickValueChanged);
            // 
            // lblVitesse
            // 
            this.lblVitesse.AutoSize = true;
            this.lblVitesse.Location = new System.Drawing.Point(352, 78);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(13, 13);
            this.lblVitesse.TabIndex = 1;
            this.lblVitesse.Text = "0";
            // 
            // boxAffichage
            // 
            this.boxAffichage.Location = new System.Drawing.Point(395, 76);
            this.boxAffichage.Name = "boxAffichage";
            this.boxAffichage.Size = new System.Drawing.Size(94, 31);
            this.boxAffichage.TabIndex = 7;
            this.boxAffichage.Text = "Afficher les données";
            this.boxAffichage.UseVisualStyleBackColor = true;
            // 
            // pictureBoxAngle
            // 
            this.pictureBoxAngle.Location = new System.Drawing.Point(495, 24);
            this.pictureBoxAngle.Name = "pictureBoxAngle";
            this.pictureBoxAngle.Size = new System.Drawing.Size(205, 379);
            this.pictureBoxAngle.TabIndex = 6;
            this.pictureBoxAngle.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "tours / s";
            // 
            // lblToursSecondesActuel
            // 
            this.lblToursSecondesActuel.AutoSize = true;
            this.lblToursSecondesActuel.Location = new System.Drawing.Point(176, 110);
            this.lblToursSecondesActuel.Name = "lblToursSecondesActuel";
            this.lblToursSecondesActuel.Size = new System.Drawing.Size(13, 13);
            this.lblToursSecondesActuel.TabIndex = 13;
            this.lblToursSecondesActuel.Text = "0";
            // 
            // PanelBaliseUnique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblToursSecondesActuel);
            this.Controls.Add(this.boxAffichage);
            this.Controls.Add(this.pictureBoxAngle);
            this.Controls.Add(this.lblVitesse);
            this.Controls.Add(this.trackBarVitesse);
            this.Name = "PanelBaliseUnique";
            this.Size = new System.Drawing.Size(741, 424);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Composants.TrackBarPlus trackBarVitesse;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.CheckBox boxAffichage;
        private System.Windows.Forms.PictureBox pictureBoxAngle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblToursSecondesActuel;
    }
}
