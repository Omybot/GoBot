namespace GoBot.IHM
{
    partial class ConnectionDetails
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
            this._grpConnection = new System.Windows.Forms.GroupBox();
            this._lblOutputPort = new System.Windows.Forms.Label();
            this._lblInputPort = new System.Windows.Forms.Label();
            this._lblIP = new System.Windows.Forms.Label();
            this._lblOutputPortTxt = new System.Windows.Forms.Label();
            this._lblInputPortTxt = new System.Windows.Forms.Label();
            this._lblIPTxt = new System.Windows.Forms.Label();
            this._grpConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpConnection
            // 
            this._grpConnection.Controls.Add(this._lblOutputPort);
            this._grpConnection.Controls.Add(this._lblInputPort);
            this._grpConnection.Controls.Add(this._lblIP);
            this._grpConnection.Controls.Add(this._lblOutputPortTxt);
            this._grpConnection.Controls.Add(this._lblInputPortTxt);
            this._grpConnection.Controls.Add(this._lblIPTxt);
            this._grpConnection.Location = new System.Drawing.Point(3, 3);
            this._grpConnection.Name = "_grpConnection";
            this._grpConnection.Size = new System.Drawing.Size(200, 102);
            this._grpConnection.TabIndex = 8;
            this._grpConnection.TabStop = false;
            this._grpConnection.Text = "Nom";
            // 
            // _lblOutputPort
            // 
            this._lblOutputPort.AutoSize = true;
            this._lblOutputPort.Location = new System.Drawing.Point(88, 73);
            this._lblOutputPort.Name = "_lblOutputPort";
            this._lblOutputPort.Size = new System.Drawing.Size(10, 13);
            this._lblOutputPort.TabIndex = 13;
            this._lblOutputPort.Text = "-";
            // 
            // _lblInputPort
            // 
            this._lblInputPort.AutoSize = true;
            this._lblInputPort.Location = new System.Drawing.Point(88, 49);
            this._lblInputPort.Name = "_lblInputPort";
            this._lblInputPort.Size = new System.Drawing.Size(10, 13);
            this._lblInputPort.TabIndex = 12;
            this._lblInputPort.Text = "-";
            // 
            // _lblIP
            // 
            this._lblIP.AutoSize = true;
            this._lblIP.Location = new System.Drawing.Point(88, 25);
            this._lblIP.Name = "_lblIP";
            this._lblIP.Size = new System.Drawing.Size(10, 13);
            this._lblIP.TabIndex = 11;
            this._lblIP.Text = "-";
            // 
            // _lblOutputPortTxt
            // 
            this._lblOutputPortTxt.AutoSize = true;
            this._lblOutputPortTxt.Location = new System.Drawing.Point(15, 73);
            this._lblOutputPortTxt.Name = "_lblOutputPortTxt";
            this._lblOutputPortTxt.Size = new System.Drawing.Size(60, 13);
            this._lblOutputPortTxt.TabIndex = 10;
            this._lblOutputPortTxt.Text = "Port sortie :";
            // 
            // _lblInputPortTxt
            // 
            this._lblInputPortTxt.AutoSize = true;
            this._lblInputPortTxt.Location = new System.Drawing.Point(15, 49);
            this._lblInputPortTxt.Name = "_lblInputPortTxt";
            this._lblInputPortTxt.Size = new System.Drawing.Size(65, 13);
            this._lblInputPortTxt.TabIndex = 9;
            this._lblInputPortTxt.Text = "Port entrée :";
            // 
            // _lblIPTxt
            // 
            this._lblIPTxt.AutoSize = true;
            this._lblIPTxt.Location = new System.Drawing.Point(15, 25);
            this._lblIPTxt.Name = "_lblIPTxt";
            this._lblIPTxt.Size = new System.Drawing.Size(50, 13);
            this._lblIPTxt.TabIndex = 8;
            this._lblIPTxt.Text = "IP carte :";
            // 
            // ConnectionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._grpConnection);
            this.Name = "ConnectionDetails";
            this.Size = new System.Drawing.Size(211, 111);
            this._grpConnection.ResumeLayout(false);
            this._grpConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpConnection;
        private System.Windows.Forms.Label _lblOutputPort;
        private System.Windows.Forms.Label _lblInputPort;
        private System.Windows.Forms.Label _lblIP;
        private System.Windows.Forms.Label _lblOutputPortTxt;
        private System.Windows.Forms.Label _lblInputPortTxt;
        private System.Windows.Forms.Label _lblIPTxt;
    }
}
