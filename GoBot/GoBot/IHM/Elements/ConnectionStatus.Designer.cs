namespace GoBot.IHM
{
    partial class ConnectionStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionStatus));
            this._conIndicator = new Composants.Led();
            this._lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._conIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // _conIndicator
            // 
            this._conIndicator.BackColor = System.Drawing.Color.Transparent;
            this._conIndicator.Color = System.Drawing.Color.Red;
            this._conIndicator.Image = ((System.Drawing.Image)(resources.GetObject("_conIndicator.Image")));
            this._conIndicator.Location = new System.Drawing.Point(3, 1);
            this._conIndicator.Name = "_conIndicator";
            this._conIndicator.Size = new System.Drawing.Size(16, 16);
            this._conIndicator.TabIndex = 0;
            this._conIndicator.TabStop = false;
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(21, 3);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(10, 13);
            this._lblName.TabIndex = 1;
            this._lblName.Text = "-";
            // 
            // ConnectionStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._conIndicator);
            this.Name = "ConnectionStatus";
            this.Size = new System.Drawing.Size(90, 21);
            ((System.ComponentModel.ISupportInitialize)(this._conIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Composants.Led _conIndicator;
        private System.Windows.Forms.Label _lblName;
    }
}
