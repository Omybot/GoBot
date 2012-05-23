namespace GoBot.IHM.IHMPetitRobot
{
    partial class PanelDeplacementPR
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
            this.groupDeplacement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReglageVertical)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVirageArDr
            // 
            this.btnVirageArDr.Click += new System.EventHandler(this.btnVirageArDr_Click);
            // 
            // btnPivotGauche
            // 
            this.btnPivotGauche.Click += new System.EventHandler(this.btnPivotGauche_Click);
            // 
            // btnStop
            // 
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnVirageArGa
            // 
            this.btnVirageArGa.Click += new System.EventHandler(this.btnVirageArGa_Click);
            // 
            // btnPivotDroite
            // 
            this.btnPivotDroite.Click += new System.EventHandler(this.btnPivotDroite_Click);
            // 
            // btnVirageAvGa
            // 
            this.btnVirageAvGa.Click += new System.EventHandler(this.btnVirageAvGa_Click);
            // 
            // btnVirageAvDr
            // 
            this.btnVirageAvDr.Click += new System.EventHandler(this.btnVirageAvDr_Click);
            // 
            // btnRecule
            // 
            this.btnRecule.Click += new System.EventHandler(this.btnRecule_Click);
            // 
            // btnAvance
            // 
            this.btnAvance.Click += new System.EventHandler(this.btnAvance_Click);
            // 
            // trackBarVitesse
            // 
            this.trackBarVitesse.TickValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarVitesse_TickValueChanged);
            // 
            // trackBarAccel
            // 
            this.trackBarAccel.TickValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarAccel_TickValueChanged);
            // 
            // PanelDeplacementPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "PanelDeplacementPR";
            this.Size = new System.Drawing.Size(337, 262);
            this.groupDeplacement.ResumeLayout(false);
            this.groupDeplacement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReglageVertical)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
