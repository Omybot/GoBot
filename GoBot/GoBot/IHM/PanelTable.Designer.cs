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
            this.btnAffichage = new System.Windows.Forms.Button();
            this.boxDroites = new System.Windows.Forms.CheckBox();
            this.boxTable = new System.Windows.Forms.CheckBox();
            this.boxObstacles = new System.Windows.Forms.CheckBox();
            this.btnSaveGraph = new System.Windows.Forms.Button();
            this.boxGraph = new System.Windows.Forms.CheckBox();
            this.boxArretes = new System.Windows.Forms.CheckBox();
            this.btnAllerA = new System.Windows.Forms.Button();
            this.boxSourisObstacle = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.pictureBoxTable = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPos = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.boxCoutGros = new System.Windows.Forms.CheckBox();
            this.boxCoutPetit = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPosGrosTeta = new System.Windows.Forms.Label();
            this.lblPosGrosY = new System.Windows.Forms.Label();
            this.lblPosGrosX = new System.Windows.Forms.Label();
            this.lblPosPetitTeta = new System.Windows.Forms.Label();
            this.lblPosPetitY = new System.Windows.Forms.Label();
            this.lblPosPetitX = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSecondes = new System.Windows.Forms.Label();
            this.lblMilli = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAngleEnnemi1 = new System.Windows.Forms.Label();
            this.lblYEnnemi1 = new System.Windows.Forms.Label();
            this.lblXEnnemi1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblVitesseEnnemi1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).BeginInit();
            this.SuspendLayout();
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
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(17, 371);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(77, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset table";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pictureBoxTable
            // 
            this.pictureBoxTable.Image = global::GoBot.Properties.Resources.table;
            this.pictureBoxTable.Location = new System.Drawing.Point(126, 3);
            this.pictureBoxTable.Name = "pictureBoxTable";
            this.pictureBoxTable.Size = new System.Drawing.Size(750, 500);
            this.pictureBoxTable.TabIndex = 0;
            this.pictureBoxTable.TabStop = false;
            this.pictureBoxTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTable_MouseClick);
            this.pictureBoxTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTable_MouseMove);
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(894, 435);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(84, 41);
            this.lblScore.TabIndex = 13;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.label1.Location = new System.Drawing.Point(898, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Score :";
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Location = new System.Drawing.Point(23, 10);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(28, 13);
            this.lblPos.TabIndex = 15;
            this.lblPos.Text = "0 : 0";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(17, 464);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 16;
            this.btnGo.Text = "Go !!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // boxCoutGros
            // 
            this.boxCoutGros.AutoSize = true;
            this.boxCoutGros.Location = new System.Drawing.Point(9, 400);
            this.boxCoutGros.Name = "boxCoutGros";
            this.boxCoutGros.Size = new System.Drawing.Size(103, 17);
            this.boxCoutGros.TabIndex = 17;
            this.boxCoutGros.Text = "Coûts gros robot";
            this.boxCoutGros.UseVisualStyleBackColor = true;
            // 
            // boxCoutPetit
            // 
            this.boxCoutPetit.AutoSize = true;
            this.boxCoutPetit.Location = new System.Drawing.Point(9, 423);
            this.boxCoutPetit.Name = "boxCoutPetit";
            this.boxCoutPetit.Size = new System.Drawing.Size(103, 17);
            this.boxCoutPetit.TabIndex = 18;
            this.boxCoutPetit.Text = "Coûts petit robot";
            this.boxCoutPetit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(889, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Position gros robot";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(906, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "X :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(906, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Y :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(906, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "θ :";
            // 
            // lblPosGrosTeta
            // 
            this.lblPosGrosTeta.AutoSize = true;
            this.lblPosGrosTeta.Location = new System.Drawing.Point(932, 68);
            this.lblPosGrosTeta.Name = "lblPosGrosTeta";
            this.lblPosGrosTeta.Size = new System.Drawing.Size(17, 13);
            this.lblPosGrosTeta.TabIndex = 25;
            this.lblPosGrosTeta.Text = "0°";
            // 
            // lblPosGrosY
            // 
            this.lblPosGrosY.AutoSize = true;
            this.lblPosGrosY.Location = new System.Drawing.Point(932, 51);
            this.lblPosGrosY.Name = "lblPosGrosY";
            this.lblPosGrosY.Size = new System.Drawing.Size(13, 13);
            this.lblPosGrosY.TabIndex = 24;
            this.lblPosGrosY.Text = "0";
            // 
            // lblPosGrosX
            // 
            this.lblPosGrosX.AutoSize = true;
            this.lblPosGrosX.Location = new System.Drawing.Point(932, 34);
            this.lblPosGrosX.Name = "lblPosGrosX";
            this.lblPosGrosX.Size = new System.Drawing.Size(13, 13);
            this.lblPosGrosX.TabIndex = 23;
            this.lblPosGrosX.Text = "0";
            // 
            // lblPosPetitTeta
            // 
            this.lblPosPetitTeta.AutoSize = true;
            this.lblPosPetitTeta.Location = new System.Drawing.Point(932, 152);
            this.lblPosPetitTeta.Name = "lblPosPetitTeta";
            this.lblPosPetitTeta.Size = new System.Drawing.Size(17, 13);
            this.lblPosPetitTeta.TabIndex = 32;
            this.lblPosPetitTeta.Text = "0°";
            // 
            // lblPosPetitY
            // 
            this.lblPosPetitY.AutoSize = true;
            this.lblPosPetitY.Location = new System.Drawing.Point(932, 135);
            this.lblPosPetitY.Name = "lblPosPetitY";
            this.lblPosPetitY.Size = new System.Drawing.Size(13, 13);
            this.lblPosPetitY.TabIndex = 31;
            this.lblPosPetitY.Text = "0";
            // 
            // lblPosPetitX
            // 
            this.lblPosPetitX.AutoSize = true;
            this.lblPosPetitX.Location = new System.Drawing.Point(932, 118);
            this.lblPosPetitX.Name = "lblPosPetitX";
            this.lblPosPetitX.Size = new System.Drawing.Size(13, 13);
            this.lblPosPetitX.TabIndex = 30;
            this.lblPosPetitX.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(906, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "θ :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(906, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Y :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(906, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "X :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(889, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Position petit robot";
            // 
            // lblSecondes
            // 
            this.lblSecondes.Font = new System.Drawing.Font("Century Gothic", 26.25F);
            this.lblSecondes.Location = new System.Drawing.Point(882, 289);
            this.lblSecondes.Margin = new System.Windows.Forms.Padding(0);
            this.lblSecondes.Name = "lblSecondes";
            this.lblSecondes.Size = new System.Drawing.Size(67, 38);
            this.lblSecondes.TabIndex = 34;
            this.lblSecondes.Text = "90";
            this.lblSecondes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMilli
            // 
            this.lblMilli.AutoSize = true;
            this.lblMilli.Font = new System.Drawing.Font("Century Gothic", 10.25F);
            this.lblMilli.Location = new System.Drawing.Point(941, 308);
            this.lblMilli.Name = "lblMilli";
            this.lblMilli.Size = new System.Drawing.Size(33, 19);
            this.lblMilli.TabIndex = 35;
            this.lblMilli.Text = "000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(889, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Position ennemi 1";
            // 
            // lblAngleEnnemi1
            // 
            this.lblAngleEnnemi1.AutoSize = true;
            this.lblAngleEnnemi1.Location = new System.Drawing.Point(931, 250);
            this.lblAngleEnnemi1.Name = "lblAngleEnnemi1";
            this.lblAngleEnnemi1.Size = new System.Drawing.Size(17, 13);
            this.lblAngleEnnemi1.TabIndex = 42;
            this.lblAngleEnnemi1.Text = "0°";
            // 
            // lblYEnnemi1
            // 
            this.lblYEnnemi1.AutoSize = true;
            this.lblYEnnemi1.Location = new System.Drawing.Point(931, 233);
            this.lblYEnnemi1.Name = "lblYEnnemi1";
            this.lblYEnnemi1.Size = new System.Drawing.Size(13, 13);
            this.lblYEnnemi1.TabIndex = 41;
            this.lblYEnnemi1.Text = "0";
            // 
            // lblXEnnemi1
            // 
            this.lblXEnnemi1.AutoSize = true;
            this.lblXEnnemi1.Location = new System.Drawing.Point(931, 216);
            this.lblXEnnemi1.Name = "lblXEnnemi1";
            this.lblXEnnemi1.Size = new System.Drawing.Size(13, 13);
            this.lblXEnnemi1.TabIndex = 40;
            this.lblXEnnemi1.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(905, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "θ :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(905, 233);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Y :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(905, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "X :";
            // 
            // lblVitesseEnnemi1
            // 
            this.lblVitesseEnnemi1.AutoSize = true;
            this.lblVitesseEnnemi1.Location = new System.Drawing.Point(931, 270);
            this.lblVitesseEnnemi1.Name = "lblVitesseEnnemi1";
            this.lblVitesseEnnemi1.Size = new System.Drawing.Size(42, 13);
            this.lblVitesseEnnemi1.TabIndex = 44;
            this.lblVitesseEnnemi1.Text = "0 mm/s";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(899, 270);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 13);
            this.label18.TabIndex = 43;
            this.label18.Text = "Vit :";
            // 
            // PanelTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblVitesseEnnemi1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblAngleEnnemi1);
            this.Controls.Add(this.lblYEnnemi1);
            this.Controls.Add(this.lblXEnnemi1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMilli);
            this.Controls.Add(this.lblSecondes);
            this.Controls.Add(this.lblPosPetitTeta);
            this.Controls.Add(this.lblPosPetitY);
            this.Controls.Add(this.lblPosPetitX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblPosGrosTeta);
            this.Controls.Add(this.lblPosGrosY);
            this.Controls.Add(this.lblPosGrosX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boxCoutPetit);
            this.Controls.Add(this.boxCoutGros);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblPos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnReset);
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
            this.Size = new System.Drawing.Size(998, 526);
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
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.CheckBox boxCoutGros;
        private System.Windows.Forms.CheckBox boxCoutPetit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPosGrosTeta;
        private System.Windows.Forms.Label lblPosGrosY;
        private System.Windows.Forms.Label lblPosGrosX;
        private System.Windows.Forms.Label lblPosPetitTeta;
        private System.Windows.Forms.Label lblPosPetitY;
        private System.Windows.Forms.Label lblPosPetitX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSecondes;
        private System.Windows.Forms.Label lblMilli;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAngleEnnemi1;
        private System.Windows.Forms.Label lblYEnnemi1;
        private System.Windows.Forms.Label lblXEnnemi1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblVitesseEnnemi1;
        private System.Windows.Forms.Label label18;
    }
}
