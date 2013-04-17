namespace GoBot.IHM
{
    partial class PanelTable
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
            this.pictureBoxTable = new System.Windows.Forms.PictureBox();
            this.btnAffichage = new System.Windows.Forms.Button();
            this.boxDroites = new System.Windows.Forms.CheckBox();
            this.boxTable = new System.Windows.Forms.CheckBox();
            this.boxObstacles = new System.Windows.Forms.CheckBox();
            this.btnSaveGraph = new System.Windows.Forms.Button();
            this.boxGraph = new System.Windows.Forms.CheckBox();
            this.boxArretes = new System.Windows.Forms.CheckBox();
            this.btnAllerA = new System.Windows.Forms.Button();
            this.boxSourisObstacle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTable
            // 
            this.pictureBoxTable.Image = global::GoBot.Properties.Resources.table;
            this.pictureBoxTable.Location = new System.Drawing.Point(126, 3);
            this.pictureBoxTable.Name = "pictureBoxTable";
            this.pictureBoxTable.Size = new System.Drawing.Size(750, 500);
            this.pictureBoxTable.TabIndex = 0;
            this.pictureBoxTable.TabStop = false;
            this.pictureBoxTable.Click += new System.EventHandler(this.pictureBoxTable_Click);
            this.pictureBoxTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTable_MouseMove);
            // 
            // btnAffichage
            // 
            this.btnAffichage.Location = new System.Drawing.Point(9, 32);
            this.btnAffichage.Name = "btnAffichage";
            this.btnAffichage.Size = new System.Drawing.Size(111, 25);
            this.btnAffichage.TabIndex = 1;
            this.btnAffichage.Text = "Lancer affichage";
            this.btnAffichage.UseVisualStyleBackColor = true;
            this.btnAffichage.Click += new System.EventHandler(this.btnAffichage_Click);
            // 
            // boxDroites
            // 
            this.boxDroites.AutoSize = true;
            this.boxDroites.Location = new System.Drawing.Point(19, 118);
            this.boxDroites.Name = "boxDroites";
            this.boxDroites.Size = new System.Drawing.Size(83, 17);
            this.boxDroites.TabIndex = 2;
            this.boxDroites.Text = "Afficher tout";
            this.boxDroites.UseVisualStyleBackColor = true;
            // 
            // boxTable
            // 
            this.boxTable.AutoSize = true;
            this.boxTable.Checked = true;
            this.boxTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxTable.Location = new System.Drawing.Point(19, 141);
            this.boxTable.Name = "boxTable";
            this.boxTable.Size = new System.Drawing.Size(99, 17);
            this.boxTable.TabIndex = 3;
            this.boxTable.Text = "Afficher la table";
            this.boxTable.UseVisualStyleBackColor = true;
            // 
            // boxObstacles
            // 
            this.boxObstacles.AutoSize = true;
            this.boxObstacles.Location = new System.Drawing.Point(19, 176);
            this.boxObstacles.Name = "boxObstacles";
            this.boxObstacles.Size = new System.Drawing.Size(73, 17);
            this.boxObstacles.TabIndex = 4;
            this.boxObstacles.Text = "Obstacles";
            this.boxObstacles.UseVisualStyleBackColor = true;
            // 
            // btnSaveGraph
            // 
            this.btnSaveGraph.Location = new System.Drawing.Point(17, 289);
            this.btnSaveGraph.Name = "btnSaveGraph";
            this.btnSaveGraph.Size = new System.Drawing.Size(75, 23);
            this.btnSaveGraph.TabIndex = 5;
            this.btnSaveGraph.Text = "SauverGraph";
            this.btnSaveGraph.UseVisualStyleBackColor = true;
            this.btnSaveGraph.Click += new System.EventHandler(this.btnSaveGraph_Click);
            // 
            // boxGraph
            // 
            this.boxGraph.AutoSize = true;
            this.boxGraph.Location = new System.Drawing.Point(19, 212);
            this.boxGraph.Name = "boxGraph";
            this.boxGraph.Size = new System.Drawing.Size(55, 17);
            this.boxGraph.TabIndex = 6;
            this.boxGraph.Text = "Graph";
            this.boxGraph.UseVisualStyleBackColor = true;
            // 
            // boxArretes
            // 
            this.boxArretes.AutoSize = true;
            this.boxArretes.Location = new System.Drawing.Point(37, 235);
            this.boxArretes.Name = "boxArretes";
            this.boxArretes.Size = new System.Drawing.Size(59, 17);
            this.boxArretes.TabIndex = 7;
            this.boxArretes.Text = "Arrêtes";
            this.boxArretes.UseVisualStyleBackColor = true;
            // 
            // btnAllerA
            // 
            this.btnAllerA.Location = new System.Drawing.Point(17, 342);
            this.btnAllerA.Name = "btnAllerA";
            this.btnAllerA.Size = new System.Drawing.Size(75, 23);
            this.btnAllerA.TabIndex = 8;
            this.btnAllerA.Text = "Aller à";
            this.btnAllerA.UseVisualStyleBackColor = true;
            this.btnAllerA.Click += new System.EventHandler(this.btnAllerA_Click);
            // 
            // boxSourisObstacle
            // 
            this.boxSourisObstacle.AutoSize = true;
            this.boxSourisObstacle.Location = new System.Drawing.Point(19, 266);
            this.boxSourisObstacle.Name = "boxSourisObstacle";
            this.boxSourisObstacle.Size = new System.Drawing.Size(98, 17);
            this.boxSourisObstacle.TabIndex = 9;
            this.boxSourisObstacle.Text = "Souris obstacle";
            this.boxSourisObstacle.UseVisualStyleBackColor = true;
            // 
            // PanelTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.boxSourisObstacle);
            this.Controls.Add(this.btnAllerA);
            this.Controls.Add(this.boxArretes);
            this.Controls.Add(this.boxGraph);
            this.Controls.Add(this.btnSaveGraph);
            this.Controls.Add(this.boxObstacles);
            this.Controls.Add(this.boxTable);
            this.Controls.Add(this.boxDroites);
            this.Controls.Add(this.btnAffichage);
            this.Controls.Add(this.pictureBoxTable);
            this.Name = "PanelTable";
            this.Size = new System.Drawing.Size(879, 526);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTable;
        private System.Windows.Forms.Button btnAffichage;
        private System.Windows.Forms.CheckBox boxDroites;
        private System.Windows.Forms.CheckBox boxTable;
        private System.Windows.Forms.CheckBox boxObstacles;
        private System.Windows.Forms.Button btnSaveGraph;
        private System.Windows.Forms.CheckBox boxGraph;
        private System.Windows.Forms.CheckBox boxArretes;
        private System.Windows.Forms.Button btnAllerA;
        private System.Windows.Forms.CheckBox boxSourisObstacle;
    }
}
