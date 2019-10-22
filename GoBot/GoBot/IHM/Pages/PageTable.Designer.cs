﻿namespace GoBot.IHM
{
    partial class PageTable
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
            this.components = new System.ComponentModel.Container();
            this.boxSourisObstacle = new System.Windows.Forms.CheckBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPosGrosTeta = new System.Windows.Forms.Label();
            this.lblPosGrosY = new System.Windows.Forms.Label();
            this.lblPosGrosX = new System.Windows.Forms.Label();
            this.lblSecondes = new System.Windows.Forms.Label();
            this.lblMilli = new System.Windows.Forms.Label();
            this.btnAleatoire = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStratTest = new System.Windows.Forms.Button();
            this.btnStratNul = new System.Windows.Forms.Button();
            this.groupBoxDeplacements = new System.Windows.Forms.GroupBox();
            this.numNbPoints = new System.Windows.Forms.NumericUpDown();
            this.btnTrajLancer = new System.Windows.Forms.Button();
            this.labelPlus1 = new Composants.LabelPlus();
            this.btnTrajCreer = new System.Windows.Forms.Button();
            this.lblGrosRobotDeplacements = new Composants.LabelPlus();
            this.btnPathRPCentre = new System.Windows.Forms.Button();
            this.btnPathRPFace = new System.Windows.Forms.Button();
            this.btnTeleportRPCentre = new System.Windows.Forms.Button();
            this.btnTeleportRPFace = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxAffichage = new System.Windows.Forms.GroupBox();
            this.btnTestAsser = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAffichage = new System.Windows.Forms.Button();
            this.pictureBoxTable = new System.Windows.Forms.PictureBox();
            this.btnTestScore = new System.Windows.Forms.Button();
            this.btnRestartRecal = new System.Windows.Forms.Button();
            this.btnColorRight = new System.Windows.Forms.Button();
            this.btnColorLeft = new System.Windows.Forms.Button();
            this.grpMatch = new System.Windows.Forms.GroupBox();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.btnCalib = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.groupBoxDeplacements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNbPoints)).BeginInit();
            this.groupBoxAffichage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).BeginInit();
            this.grpMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.SuspendLayout();
            // 
            // boxSourisObstacle
            // 
            this.boxSourisObstacle.AutoSize = true;
            this.boxSourisObstacle.Location = new System.Drawing.Point(3, 578);
            this.boxSourisObstacle.Name = "boxSourisObstacle";
            this.boxSourisObstacle.Size = new System.Drawing.Size(98, 17);
            this.boxSourisObstacle.TabIndex = 9;
            this.boxSourisObstacle.Text = "Souris obstacle";
            this.boxSourisObstacle.UseVisualStyleBackColor = true;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(1164, 521);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(84, 41);
            this.lblScore.TabIndex = 13;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(1168, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Score :";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(9, 31);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(139, 23);
            this.btnGo.TabIndex = 16;
            this.btnGo.Text = "Stratégie";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1159, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Position gros robot";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1176, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "X :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1176, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Y :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1176, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "θ :";
            // 
            // lblPosGrosTeta
            // 
            this.lblPosGrosTeta.AutoSize = true;
            this.lblPosGrosTeta.Location = new System.Drawing.Point(1202, 154);
            this.lblPosGrosTeta.Name = "lblPosGrosTeta";
            this.lblPosGrosTeta.Size = new System.Drawing.Size(17, 13);
            this.lblPosGrosTeta.TabIndex = 25;
            this.lblPosGrosTeta.Text = "0°";
            // 
            // lblPosGrosY
            // 
            this.lblPosGrosY.AutoSize = true;
            this.lblPosGrosY.Location = new System.Drawing.Point(1202, 137);
            this.lblPosGrosY.Name = "lblPosGrosY";
            this.lblPosGrosY.Size = new System.Drawing.Size(13, 13);
            this.lblPosGrosY.TabIndex = 24;
            this.lblPosGrosY.Text = "0";
            // 
            // lblPosGrosX
            // 
            this.lblPosGrosX.AutoSize = true;
            this.lblPosGrosX.Location = new System.Drawing.Point(1202, 120);
            this.lblPosGrosX.Name = "lblPosGrosX";
            this.lblPosGrosX.Size = new System.Drawing.Size(13, 13);
            this.lblPosGrosX.TabIndex = 23;
            this.lblPosGrosX.Text = "0";
            // 
            // lblSecondes
            // 
            this.lblSecondes.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.lblSecondes.Location = new System.Drawing.Point(1152, 375);
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
            this.lblMilli.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblMilli.Location = new System.Drawing.Point(1211, 394);
            this.lblMilli.Name = "lblMilli";
            this.lblMilli.Size = new System.Drawing.Size(32, 17);
            this.lblMilli.TabIndex = 35;
            this.lblMilli.Text = "000";
            // 
            // btnAleatoire
            // 
            this.btnAleatoire.Location = new System.Drawing.Point(9, 60);
            this.btnAleatoire.Name = "btnAleatoire";
            this.btnAleatoire.Size = new System.Drawing.Size(139, 23);
            this.btnAleatoire.TabIndex = 48;
            this.btnAleatoire.Text = "Déplacements aléatoires";
            this.btnAleatoire.UseVisualStyleBackColor = true;
            this.btnAleatoire.Click += new System.EventHandler(this.btnAleatoire_Click);
            // 
            // checkedListBox
            // 
            this.checkedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "Plateau",
            "Elements de jeu",
            "Obstacles",
            "Graph (noeuds)",
            "Graph (arcs)",
            "Coûts mouvements",
            "Calcul path finding",
            "Historique trajectoire"});
            this.checkedListBox.Location = new System.Drawing.Point(3, 19);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(184, 120);
            this.checkedListBox.TabIndex = 63;
            this.checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_ItemCheck);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnStratTest);
            this.groupBox.Controls.Add(this.btnStratNul);
            this.groupBox.Controls.Add(this.btnGo);
            this.groupBox.Controls.Add(this.btnAleatoire);
            this.groupBox.Location = new System.Drawing.Point(0, 328);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(200, 100);
            this.groupBox.TabIndex = 66;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Lancement";
            // 
            // btnStratTest
            // 
            this.btnStratTest.Location = new System.Drawing.Point(151, 31);
            this.btnStratTest.Name = "btnStratTest";
            this.btnStratTest.Size = new System.Drawing.Size(36, 23);
            this.btnStratTest.TabIndex = 50;
            this.btnStratTest.Text = "Test";
            this.btnStratTest.UseVisualStyleBackColor = true;
            this.btnStratTest.Click += new System.EventHandler(this.btnStratTest_Click);
            // 
            // btnStratNul
            // 
            this.btnStratNul.Location = new System.Drawing.Point(151, 60);
            this.btnStratNul.Name = "btnStratNul";
            this.btnStratNul.Size = new System.Drawing.Size(36, 23);
            this.btnStratNul.TabIndex = 49;
            this.btnStratNul.Text = "Nul";
            this.btnStratNul.UseVisualStyleBackColor = true;
            this.btnStratNul.Click += new System.EventHandler(this.btnStratNul_Click);
            // 
            // groupBoxDeplacements
            // 
            this.groupBoxDeplacements.Controls.Add(this.numNbPoints);
            this.groupBoxDeplacements.Controls.Add(this.btnTrajLancer);
            this.groupBoxDeplacements.Controls.Add(this.labelPlus1);
            this.groupBoxDeplacements.Controls.Add(this.btnTrajCreer);
            this.groupBoxDeplacements.Controls.Add(this.lblGrosRobotDeplacements);
            this.groupBoxDeplacements.Controls.Add(this.btnPathRPCentre);
            this.groupBoxDeplacements.Controls.Add(this.btnPathRPFace);
            this.groupBoxDeplacements.Controls.Add(this.btnTeleportRPCentre);
            this.groupBoxDeplacements.Controls.Add(this.btnTeleportRPFace);
            this.groupBoxDeplacements.Location = new System.Drawing.Point(0, 434);
            this.groupBoxDeplacements.Name = "groupBoxDeplacements";
            this.groupBoxDeplacements.Size = new System.Drawing.Size(200, 130);
            this.groupBoxDeplacements.TabIndex = 67;
            this.groupBoxDeplacements.TabStop = false;
            this.groupBoxDeplacements.Text = "Déplacements";
            // 
            // numNbPoints
            // 
            this.numNbPoints.Location = new System.Drawing.Point(41, 89);
            this.numNbPoints.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numNbPoints.Name = "numNbPoints";
            this.numNbPoints.Size = new System.Drawing.Size(120, 20);
            this.numNbPoints.TabIndex = 75;
            this.numNbPoints.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // btnTrajLancer
            // 
            this.btnTrajLancer.Location = new System.Drawing.Point(134, 60);
            this.btnTrajLancer.Name = "btnTrajLancer";
            this.btnTrajLancer.Size = new System.Drawing.Size(59, 23);
            this.btnTrajLancer.TabIndex = 74;
            this.btnTrajLancer.Text = "Lancer";
            this.btnTrajLancer.UseVisualStyleBackColor = true;
            this.btnTrajLancer.Click += new System.EventHandler(this.btnTrajLancer_Click);
            // 
            // labelPlus1
            // 
            this.labelPlus1.AutoSize = true;
            this.labelPlus1.Location = new System.Drawing.Point(6, 65);
            this.labelPlus1.Name = "labelPlus1";
            this.labelPlus1.Size = new System.Drawing.Size(57, 13);
            this.labelPlus1.TabIndex = 73;
            this.labelPlus1.Text = "Trajectoire";
            // 
            // btnTrajCreer
            // 
            this.btnTrajCreer.Location = new System.Drawing.Point(86, 60);
            this.btnTrajCreer.Name = "btnTrajCreer";
            this.btnTrajCreer.Size = new System.Drawing.Size(42, 23);
            this.btnTrajCreer.TabIndex = 72;
            this.btnTrajCreer.Text = "Créer";
            this.btnTrajCreer.UseVisualStyleBackColor = true;
            this.btnTrajCreer.Click += new System.EventHandler(this.btnTrajCreer_Click);
            // 
            // lblGrosRobotDeplacements
            // 
            this.lblGrosRobotDeplacements.AutoSize = true;
            this.lblGrosRobotDeplacements.Location = new System.Drawing.Point(6, 29);
            this.lblGrosRobotDeplacements.Name = "lblGrosRobotDeplacements";
            this.lblGrosRobotDeplacements.Size = new System.Drawing.Size(56, 13);
            this.lblGrosRobotDeplacements.TabIndex = 64;
            this.lblGrosRobotDeplacements.Text = "Gros robot";
            // 
            // btnPathRPCentre
            // 
            this.btnPathRPCentre.Image = global::GoBot.Properties.Resources.PathCenter16;
            this.btnPathRPCentre.Location = new System.Drawing.Point(68, 24);
            this.btnPathRPCentre.Name = "btnPathRPCentre";
            this.btnPathRPCentre.Size = new System.Drawing.Size(27, 23);
            this.btnPathRPCentre.TabIndex = 49;
            this.btnPathRPCentre.UseVisualStyleBackColor = true;
            this.btnPathRPCentre.Click += new System.EventHandler(this.btnPathRPCentre_Click);
            // 
            // btnPathRPFace
            // 
            this.btnPathRPFace.Image = global::GoBot.Properties.Resources.PathFront16;
            this.btnPathRPFace.Location = new System.Drawing.Point(134, 24);
            this.btnPathRPFace.Name = "btnPathRPFace";
            this.btnPathRPFace.Size = new System.Drawing.Size(27, 23);
            this.btnPathRPFace.TabIndex = 50;
            this.btnPathRPFace.UseVisualStyleBackColor = true;
            this.btnPathRPFace.Click += new System.EventHandler(this.btnPathRPFace_Click);
            // 
            // btnTeleportRPCentre
            // 
            this.btnTeleportRPCentre.Image = global::GoBot.Properties.Resources.TeleportCenter16;
            this.btnTeleportRPCentre.Location = new System.Drawing.Point(101, 24);
            this.btnTeleportRPCentre.Name = "btnTeleportRPCentre";
            this.btnTeleportRPCentre.Size = new System.Drawing.Size(27, 23);
            this.btnTeleportRPCentre.TabIndex = 58;
            this.btnTeleportRPCentre.UseVisualStyleBackColor = true;
            this.btnTeleportRPCentre.Click += new System.EventHandler(this.btnTeleportRPCentre_Click);
            // 
            // btnTeleportRPFace
            // 
            this.btnTeleportRPFace.Image = global::GoBot.Properties.Resources.TeleportFront16;
            this.btnTeleportRPFace.Location = new System.Drawing.Point(167, 24);
            this.btnTeleportRPFace.Name = "btnTeleportRPFace";
            this.btnTeleportRPFace.Size = new System.Drawing.Size(27, 23);
            this.btnTeleportRPFace.TabIndex = 59;
            this.btnTeleportRPFace.UseVisualStyleBackColor = true;
            this.btnTeleportRPFace.Click += new System.EventHandler(this.btnTeleportRPFace_Click);
            // 
            // groupBoxAffichage
            // 
            this.groupBoxAffichage.Controls.Add(this.checkedListBox);
            this.groupBoxAffichage.Location = new System.Drawing.Point(0, 71);
            this.groupBoxAffichage.Name = "groupBoxAffichage";
            this.groupBoxAffichage.Size = new System.Drawing.Size(200, 145);
            this.groupBoxAffichage.TabIndex = 68;
            this.groupBoxAffichage.TabStop = false;
            this.groupBoxAffichage.Text = "Affichage";
            // 
            // btnTestAsser
            // 
            this.btnTestAsser.Location = new System.Drawing.Point(107, 601);
            this.btnTestAsser.Name = "btnTestAsser";
            this.btnTestAsser.Size = new System.Drawing.Size(87, 25);
            this.btnTestAsser.TabIndex = 70;
            this.btnTestAsser.Text = "Test asser";
            this.btnTestAsser.UseVisualStyleBackColor = true;
            this.btnTestAsser.Click += new System.EventHandler(this.btnTestAsser_Click);
            // 
            // btnReset
            // 
            this.btnReset.Image = global::GoBot.Properties.Resources.Refresh16;
            this.btnReset.Location = new System.Drawing.Point(3, 601);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(98, 25);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset table";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAffichage
            // 
            this.btnAffichage.Image = global::GoBot.Properties.Resources.Play16;
            this.btnAffichage.Location = new System.Drawing.Point(31, 31);
            this.btnAffichage.Name = "btnAffichage";
            this.btnAffichage.Size = new System.Drawing.Size(130, 25);
            this.btnAffichage.TabIndex = 1;
            this.btnAffichage.Text = "Lancer l\'affichage";
            this.btnAffichage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAffichage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAffichage.UseVisualStyleBackColor = true;
            this.btnAffichage.Click += new System.EventHandler(this.btnAffichage_Click);
            // 
            // pictureBoxTable
            // 
            this.pictureBoxTable.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTable.Image = global::GoBot.Properties.Resources.TablePlan;
            this.pictureBoxTable.Location = new System.Drawing.Point(273, 16);
            this.pictureBoxTable.Name = "pictureBoxTable";
            this.pictureBoxTable.Size = new System.Drawing.Size(876, 650);
            this.pictureBoxTable.TabIndex = 0;
            this.pictureBoxTable.TabStop = false;
            this.pictureBoxTable.Click += new System.EventHandler(this.pictureBoxTable_Click);
            this.pictureBoxTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTable_MouseDown);
            this.pictureBoxTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTable_MouseMove);
            this.pictureBoxTable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTable_MouseUp);
            // 
            // btnTestScore
            // 
            this.btnTestScore.Location = new System.Drawing.Point(107, 632);
            this.btnTestScore.Name = "btnTestScore";
            this.btnTestScore.Size = new System.Drawing.Size(87, 25);
            this.btnTestScore.TabIndex = 75;
            this.btnTestScore.Text = "Test Score ++";
            this.btnTestScore.UseVisualStyleBackColor = true;
            this.btnTestScore.Click += new System.EventHandler(this.btnTestScore_Click);
            // 
            // btnRestartRecal
            // 
            this.btnRestartRecal.Location = new System.Drawing.Point(3, 632);
            this.btnRestartRecal.Name = "btnRestartRecal";
            this.btnRestartRecal.Size = new System.Drawing.Size(98, 25);
            this.btnRestartRecal.TabIndex = 76;
            this.btnRestartRecal.Text = "Retour départ";
            this.btnRestartRecal.UseVisualStyleBackColor = true;
            this.btnRestartRecal.Click += new System.EventHandler(this.btnRestartRecal_Click);
            // 
            // btnColorRight
            // 
            this.btnColorRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorRight.Location = new System.Drawing.Point(154, 21);
            this.btnColorRight.Name = "btnColorRight";
            this.btnColorRight.Size = new System.Drawing.Size(40, 40);
            this.btnColorRight.TabIndex = 77;
            this.btnColorRight.UseVisualStyleBackColor = true;
            this.btnColorRight.Click += new System.EventHandler(this.btnColorRight_Click);
            // 
            // btnColorLeft
            // 
            this.btnColorLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorLeft.ForeColor = System.Drawing.Color.White;
            this.btnColorLeft.Location = new System.Drawing.Point(6, 21);
            this.btnColorLeft.Name = "btnColorLeft";
            this.btnColorLeft.Size = new System.Drawing.Size(40, 40);
            this.btnColorLeft.TabIndex = 78;
            this.btnColorLeft.UseVisualStyleBackColor = true;
            this.btnColorLeft.Click += new System.EventHandler(this.btnColorLeft_Click);
            // 
            // grpMatch
            // 
            this.grpMatch.Controls.Add(this.btnCalib);
            this.grpMatch.Controls.Add(this.picColor);
            this.grpMatch.Controls.Add(this.btnColorLeft);
            this.grpMatch.Controls.Add(this.btnColorRight);
            this.grpMatch.Location = new System.Drawing.Point(0, 222);
            this.grpMatch.Name = "grpMatch";
            this.grpMatch.Size = new System.Drawing.Size(200, 100);
            this.grpMatch.TabIndex = 79;
            this.grpMatch.TabStop = false;
            this.grpMatch.Text = "Match";
            // 
            // picColor
            // 
            this.picColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picColor.Location = new System.Drawing.Point(52, 23);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(96, 36);
            this.picColor.TabIndex = 79;
            this.picColor.TabStop = false;
            // 
            // btnCalib
            // 
            this.btnCalib.Location = new System.Drawing.Point(52, 65);
            this.btnCalib.Name = "btnCalib";
            this.btnCalib.Size = new System.Drawing.Size(96, 23);
            this.btnCalib.TabIndex = 80;
            this.btnCalib.Text = "Recalage";
            this.btnCalib.UseVisualStyleBackColor = true;
            this.btnCalib.Click += new System.EventHandler(this.btnCalib_Click);
            // 
            // lblX
            // 
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(637, 20);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(69, 23);
            this.lblX.TabIndex = 80;
            this.lblX.Text = "1000";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY
            // 
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(716, 20);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(69, 23);
            this.lblY.TabIndex = 81;
            this.lblY.Text = "1000";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(701, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 23);
            this.label7.TabIndex = 82;
            this.label7.Text = ":";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PageTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.grpMatch);
            this.Controls.Add(this.btnRestartRecal);
            this.Controls.Add(this.btnTestScore);
            this.Controls.Add(this.btnTestAsser);
            this.Controls.Add(this.groupBoxAffichage);
            this.Controls.Add(this.groupBoxDeplacements);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.lblMilli);
            this.Controls.Add(this.lblSecondes);
            this.Controls.Add(this.lblPosGrosTeta);
            this.Controls.Add(this.lblPosGrosY);
            this.Controls.Add(this.lblPosGrosX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.boxSourisObstacle);
            this.Controls.Add(this.btnAffichage);
            this.Controls.Add(this.pictureBoxTable);
            this.Name = "PageTable";
            this.Size = new System.Drawing.Size(1273, 669);
            this.Load += new System.EventHandler(this.PanelTable_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBoxDeplacements.ResumeLayout(false);
            this.groupBoxDeplacements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNbPoints)).EndInit();
            this.groupBoxAffichage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).EndInit();
            this.grpMatch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTable;
        private System.Windows.Forms.Button btnAffichage;
        private System.Windows.Forms.CheckBox boxSourisObstacle;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPosGrosTeta;
        private System.Windows.Forms.Label lblPosGrosY;
        private System.Windows.Forms.Label lblPosGrosX;
        private System.Windows.Forms.Label lblSecondes;
        private System.Windows.Forms.Label lblMilli;
        private System.Windows.Forms.Button btnAleatoire;
        private System.Windows.Forms.Button btnPathRPCentre;
        private System.Windows.Forms.Button btnPathRPFace;
        private System.Windows.Forms.Button btnTeleportRPFace;
        private System.Windows.Forms.Button btnTeleportRPCentre;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private Composants.LabelPlus lblGrosRobotDeplacements;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.GroupBox groupBoxDeplacements;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBoxAffichage;
        private System.Windows.Forms.Button btnStratNul;
        private System.Windows.Forms.Button btnStratTest;
        private System.Windows.Forms.Button btnTestAsser;
        private System.Windows.Forms.Button btnTrajLancer;
        private Composants.LabelPlus labelPlus1;
        private System.Windows.Forms.Button btnTrajCreer;
        private System.Windows.Forms.NumericUpDown numNbPoints;
        private System.Windows.Forms.Button btnTestScore;
        private System.Windows.Forms.Button btnRestartRecal;
        private System.Windows.Forms.Button btnColorRight;
        private System.Windows.Forms.Button btnColorLeft;
        private System.Windows.Forms.GroupBox grpMatch;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.Button btnCalib;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label label7;
    }
}
