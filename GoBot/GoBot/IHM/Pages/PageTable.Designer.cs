namespace GoBot.IHM.Pages
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
            this.btnGo = new System.Windows.Forms.Button();
            this.lblSecondes = new System.Windows.Forms.Label();
            this.btnAleatoire = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lblScoreTxt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStratTest = new System.Windows.Forms.Button();
            this.btnStratNul = new System.Windows.Forms.Button();
            this.groupBoxDeplacements = new System.Windows.Forms.GroupBox();
            this.lblPosTheta = new System.Windows.Forms.Label();
            this.lblPosY = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTestAsser = new System.Windows.Forms.Button();
            this.lblPositionTxt = new Composants.LabelPlus();
            this.labelPlus3 = new Composants.LabelPlus();
            this.labelPlus2 = new Composants.LabelPlus();
            this.numNbPoints = new System.Windows.Forms.NumericUpDown();
            this.btnTrajLancer = new System.Windows.Forms.Button();
            this.labelPlus1 = new Composants.LabelPlus();
            this.btnTrajCreer = new System.Windows.Forms.Button();
            this.lblPathfinding = new Composants.LabelPlus();
            this.btnPathRPCentre = new System.Windows.Forms.Button();
            this.btnPathRPFace = new System.Windows.Forms.Button();
            this.btnTeleportRPCentre = new System.Windows.Forms.Button();
            this.btnTeleportRPFace = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAffichage = new System.Windows.Forms.Button();
            this.pictureBoxTable = new System.Windows.Forms.PictureBox();
            this.btnTestScore = new System.Windows.Forms.Button();
            this.btnRestartRecal = new System.Windows.Forms.Button();
            this.btnColorRight = new System.Windows.Forms.Button();
            this.btnColorLeft = new System.Windows.Forms.Button();
            this.grpPrepare = new System.Windows.Forms.GroupBox();
            this.btnCalib = new System.Windows.Forms.Button();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpDisplay = new System.Windows.Forms.GroupBox();
            this.groupBox.SuspendLayout();
            this.groupBoxDeplacements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNbPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).BeginInit();
            this.grpPrepare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.grpDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxSourisObstacle
            // 
            this.boxSourisObstacle.AutoSize = true;
            this.boxSourisObstacle.Location = new System.Drawing.Point(1118, 212);
            this.boxSourisObstacle.Name = "boxSourisObstacle";
            this.boxSourisObstacle.Size = new System.Drawing.Size(98, 17);
            this.boxSourisObstacle.TabIndex = 9;
            this.boxSourisObstacle.Text = "Souris obstacle";
            this.boxSourisObstacle.UseVisualStyleBackColor = true;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(92, 123);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(88, 38);
            this.lblScore.TabIndex = 13;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(9, 22);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(89, 23);
            this.btnGo.TabIndex = 16;
            this.btnGo.Text = "Stratégie";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblSecondes
            // 
            this.lblSecondes.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.lblSecondes.Location = new System.Drawing.Point(92, 84);
            this.lblSecondes.Margin = new System.Windows.Forms.Padding(0);
            this.lblSecondes.Name = "lblSecondes";
            this.lblSecondes.Size = new System.Drawing.Size(88, 38);
            this.lblSecondes.TabIndex = 34;
            this.lblSecondes.Text = "90";
            this.lblSecondes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAleatoire
            // 
            this.btnAleatoire.Location = new System.Drawing.Point(9, 51);
            this.btnAleatoire.Name = "btnAleatoire";
            this.btnAleatoire.Size = new System.Drawing.Size(89, 23);
            this.btnAleatoire.TabIndex = 48;
            this.btnAleatoire.Text = "Random";
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
            this.checkedListBox.Location = new System.Drawing.Point(24, 50);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(134, 120);
            this.checkedListBox.TabIndex = 63;
            this.checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_ItemCheck);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lblScoreTxt);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.btnStratTest);
            this.groupBox.Controls.Add(this.btnStratNul);
            this.groupBox.Controls.Add(this.btnGo);
            this.groupBox.Controls.Add(this.btnAleatoire);
            this.groupBox.Controls.Add(this.lblSecondes);
            this.groupBox.Controls.Add(this.lblScore);
            this.groupBox.Location = new System.Drawing.Point(3, 151);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(200, 175);
            this.groupBox.TabIndex = 66;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Match";
            // 
            // lblScoreTxt
            // 
            this.lblScoreTxt.AutoSize = true;
            this.lblScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblScoreTxt.Location = new System.Drawing.Point(6, 129);
            this.lblScoreTxt.Name = "lblScoreTxt";
            this.lblScoreTxt.Size = new System.Drawing.Size(100, 31);
            this.lblScoreTxt.TabIndex = 52;
            this.lblScoreTxt.Text = "Score :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(6, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 31);
            this.label1.TabIndex = 51;
            this.label1.Text = "Timer :";
            // 
            // btnStratTest
            // 
            this.btnStratTest.Location = new System.Drawing.Point(104, 22);
            this.btnStratTest.Name = "btnStratTest";
            this.btnStratTest.Size = new System.Drawing.Size(89, 23);
            this.btnStratTest.TabIndex = 50;
            this.btnStratTest.Text = "Aller retours";
            this.btnStratTest.UseVisualStyleBackColor = true;
            this.btnStratTest.Click += new System.EventHandler(this.btnStratTest_Click);
            // 
            // btnStratNul
            // 
            this.btnStratNul.Location = new System.Drawing.Point(104, 51);
            this.btnStratNul.Name = "btnStratNul";
            this.btnStratNul.Size = new System.Drawing.Size(89, 23);
            this.btnStratNul.TabIndex = 49;
            this.btnStratNul.Text = "Vide";
            this.btnStratNul.UseVisualStyleBackColor = true;
            this.btnStratNul.Click += new System.EventHandler(this.btnStratNul_Click);
            // 
            // groupBoxDeplacements
            // 
            this.groupBoxDeplacements.Controls.Add(this.lblPosTheta);
            this.groupBoxDeplacements.Controls.Add(this.lblPosY);
            this.groupBoxDeplacements.Controls.Add(this.lblPosX);
            this.groupBoxDeplacements.Controls.Add(this.label4);
            this.groupBoxDeplacements.Controls.Add(this.label3);
            this.groupBoxDeplacements.Controls.Add(this.label2);
            this.groupBoxDeplacements.Controls.Add(this.btnTestAsser);
            this.groupBoxDeplacements.Controls.Add(this.lblPositionTxt);
            this.groupBoxDeplacements.Controls.Add(this.labelPlus3);
            this.groupBoxDeplacements.Controls.Add(this.labelPlus2);
            this.groupBoxDeplacements.Controls.Add(this.numNbPoints);
            this.groupBoxDeplacements.Controls.Add(this.btnTrajLancer);
            this.groupBoxDeplacements.Controls.Add(this.labelPlus1);
            this.groupBoxDeplacements.Controls.Add(this.btnTrajCreer);
            this.groupBoxDeplacements.Controls.Add(this.lblPathfinding);
            this.groupBoxDeplacements.Controls.Add(this.btnPathRPCentre);
            this.groupBoxDeplacements.Controls.Add(this.btnPathRPFace);
            this.groupBoxDeplacements.Controls.Add(this.btnTeleportRPCentre);
            this.groupBoxDeplacements.Controls.Add(this.btnTeleportRPFace);
            this.groupBoxDeplacements.Location = new System.Drawing.Point(3, 332);
            this.groupBoxDeplacements.Name = "groupBoxDeplacements";
            this.groupBoxDeplacements.Size = new System.Drawing.Size(200, 259);
            this.groupBoxDeplacements.TabIndex = 67;
            this.groupBoxDeplacements.TabStop = false;
            this.groupBoxDeplacements.Text = "Déplacements";
            // 
            // lblPosTheta
            // 
            this.lblPosTheta.Location = new System.Drawing.Point(108, 53);
            this.lblPosTheta.Name = "lblPosTheta";
            this.lblPosTheta.Size = new System.Drawing.Size(54, 13);
            this.lblPosTheta.TabIndex = 84;
            this.lblPosTheta.Text = "90.00°";
            this.lblPosTheta.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPosY
            // 
            this.lblPosY.Location = new System.Drawing.Point(104, 40);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(54, 13);
            this.lblPosY.TabIndex = 83;
            this.lblPosY.Text = "1000.00";
            this.lblPosY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPosX
            // 
            this.lblPosX.Location = new System.Drawing.Point(104, 27);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(54, 13);
            this.lblPosX.TabIndex = 82;
            this.lblPosX.Text = "1000.00";
            this.lblPosX.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "θ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "X";
            // 
            // btnTestAsser
            // 
            this.btnTestAsser.Location = new System.Drawing.Point(50, 228);
            this.btnTestAsser.Name = "btnTestAsser";
            this.btnTestAsser.Size = new System.Drawing.Size(98, 25);
            this.btnTestAsser.TabIndex = 70;
            this.btnTestAsser.Text = "Test asser";
            this.btnTestAsser.UseVisualStyleBackColor = true;
            this.btnTestAsser.Click += new System.EventHandler(this.btnTestAsser_Click);
            // 
            // lblPositionTxt
            // 
            this.lblPositionTxt.AutoSize = true;
            this.lblPositionTxt.Location = new System.Drawing.Point(9, 27);
            this.lblPositionTxt.Name = "lblPositionTxt";
            this.lblPositionTxt.Size = new System.Drawing.Size(44, 13);
            this.lblPositionTxt.TabIndex = 78;
            this.lblPositionTxt.Text = "Position";
            // 
            // labelPlus3
            // 
            this.labelPlus3.AutoSize = true;
            this.labelPlus3.Location = new System.Drawing.Point(150, 144);
            this.labelPlus3.Name = "labelPlus3";
            this.labelPlus3.Size = new System.Drawing.Size(35, 13);
            this.labelPlus3.TabIndex = 77;
            this.labelPlus3.Text = "points";
            // 
            // labelPlus2
            // 
            this.labelPlus2.AutoSize = true;
            this.labelPlus2.Location = new System.Drawing.Point(9, 113);
            this.labelPlus2.Name = "labelPlus2";
            this.labelPlus2.Size = new System.Drawing.Size(69, 13);
            this.labelPlus2.TabIndex = 76;
            this.labelPlus2.Text = "Téléportation";
            // 
            // numNbPoints
            // 
            this.numNbPoints.Location = new System.Drawing.Point(90, 142);
            this.numNbPoints.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numNbPoints.Name = "numNbPoints";
            this.numNbPoints.Size = new System.Drawing.Size(60, 20);
            this.numNbPoints.TabIndex = 75;
            this.numNbPoints.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // btnTrajLancer
            // 
            this.btnTrajLancer.Location = new System.Drawing.Point(90, 190);
            this.btnTrajLancer.Name = "btnTrajLancer";
            this.btnTrajLancer.Size = new System.Drawing.Size(92, 23);
            this.btnTrajLancer.TabIndex = 74;
            this.btnTrajLancer.Text = "Lancer";
            this.btnTrajLancer.UseVisualStyleBackColor = true;
            this.btnTrajLancer.Click += new System.EventHandler(this.btnTrajLancer_Click);
            // 
            // labelPlus1
            // 
            this.labelPlus1.AutoSize = true;
            this.labelPlus1.Location = new System.Drawing.Point(9, 144);
            this.labelPlus1.Name = "labelPlus1";
            this.labelPlus1.Size = new System.Drawing.Size(61, 13);
            this.labelPlus1.TabIndex = 73;
            this.labelPlus1.Text = "Suivi points";
            // 
            // btnTrajCreer
            // 
            this.btnTrajCreer.Location = new System.Drawing.Point(90, 165);
            this.btnTrajCreer.Name = "btnTrajCreer";
            this.btnTrajCreer.Size = new System.Drawing.Size(92, 23);
            this.btnTrajCreer.TabIndex = 72;
            this.btnTrajCreer.Text = "Créer";
            this.btnTrajCreer.UseVisualStyleBackColor = true;
            this.btnTrajCreer.Click += new System.EventHandler(this.btnTrajCreer_Click);
            // 
            // lblPathfinding
            // 
            this.lblPathfinding.AutoSize = true;
            this.lblPathfinding.Location = new System.Drawing.Point(9, 84);
            this.lblPathfinding.Name = "lblPathfinding";
            this.lblPathfinding.Size = new System.Drawing.Size(57, 13);
            this.lblPathfinding.TabIndex = 64;
            this.lblPathfinding.Text = "Trajectoire";
            // 
            // btnPathRPCentre
            // 
            this.btnPathRPCentre.Image = global::GoBot.Properties.Resources.PathCenter16;
            this.btnPathRPCentre.Location = new System.Drawing.Point(90, 79);
            this.btnPathRPCentre.Name = "btnPathRPCentre";
            this.btnPathRPCentre.Size = new System.Drawing.Size(27, 23);
            this.btnPathRPCentre.TabIndex = 49;
            this.btnPathRPCentre.UseVisualStyleBackColor = true;
            this.btnPathRPCentre.Click += new System.EventHandler(this.btnPathRPCentre_Click);
            // 
            // btnPathRPFace
            // 
            this.btnPathRPFace.Image = global::GoBot.Properties.Resources.PathFront16;
            this.btnPathRPFace.Location = new System.Drawing.Point(123, 79);
            this.btnPathRPFace.Name = "btnPathRPFace";
            this.btnPathRPFace.Size = new System.Drawing.Size(27, 23);
            this.btnPathRPFace.TabIndex = 50;
            this.btnPathRPFace.UseVisualStyleBackColor = true;
            this.btnPathRPFace.Click += new System.EventHandler(this.btnPathRPFace_Click);
            // 
            // btnTeleportRPCentre
            // 
            this.btnTeleportRPCentre.Image = global::GoBot.Properties.Resources.TeleportCenter16;
            this.btnTeleportRPCentre.Location = new System.Drawing.Point(90, 108);
            this.btnTeleportRPCentre.Name = "btnTeleportRPCentre";
            this.btnTeleportRPCentre.Size = new System.Drawing.Size(27, 23);
            this.btnTeleportRPCentre.TabIndex = 58;
            this.btnTeleportRPCentre.UseVisualStyleBackColor = true;
            this.btnTeleportRPCentre.Click += new System.EventHandler(this.btnTeleportRPCentre_Click);
            // 
            // btnTeleportRPFace
            // 
            this.btnTeleportRPFace.Image = global::GoBot.Properties.Resources.TeleportFront16;
            this.btnTeleportRPFace.Location = new System.Drawing.Point(123, 108);
            this.btnTeleportRPFace.Name = "btnTeleportRPFace";
            this.btnTeleportRPFace.Size = new System.Drawing.Size(27, 23);
            this.btnTeleportRPFace.TabIndex = 59;
            this.btnTeleportRPFace.UseVisualStyleBackColor = true;
            this.btnTeleportRPFace.Click += new System.EventHandler(this.btnTeleportRPFace_Click);
            // 
            // btnReset
            // 
            this.btnReset.Image = global::GoBot.Properties.Resources.Refresh16;
            this.btnReset.Location = new System.Drawing.Point(1118, 235);
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
            this.btnAffichage.Location = new System.Drawing.Point(24, 19);
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
            this.pictureBoxTable.Location = new System.Drawing.Point(209, 16);
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
            this.btnTestScore.Location = new System.Drawing.Point(1118, 266);
            this.btnTestScore.Name = "btnTestScore";
            this.btnTestScore.Size = new System.Drawing.Size(98, 25);
            this.btnTestScore.TabIndex = 75;
            this.btnTestScore.Text = "Test Score ++";
            this.btnTestScore.UseVisualStyleBackColor = true;
            this.btnTestScore.Click += new System.EventHandler(this.btnTestScore_Click);
            // 
            // btnRestartRecal
            // 
            this.btnRestartRecal.Location = new System.Drawing.Point(52, 94);
            this.btnRestartRecal.Name = "btnRestartRecal";
            this.btnRestartRecal.Size = new System.Drawing.Size(96, 25);
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
            // grpPrepare
            // 
            this.grpPrepare.Controls.Add(this.btnCalib);
            this.grpPrepare.Controls.Add(this.picColor);
            this.grpPrepare.Controls.Add(this.btnColorLeft);
            this.grpPrepare.Controls.Add(this.btnColorRight);
            this.grpPrepare.Controls.Add(this.btnRestartRecal);
            this.grpPrepare.Location = new System.Drawing.Point(3, 16);
            this.grpPrepare.Name = "grpPrepare";
            this.grpPrepare.Size = new System.Drawing.Size(200, 132);
            this.grpPrepare.TabIndex = 79;
            this.grpPrepare.TabStop = false;
            this.grpPrepare.Text = "Préparation";
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
            // picColor
            // 
            this.picColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picColor.Location = new System.Drawing.Point(52, 23);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(96, 36);
            this.picColor.TabIndex = 79;
            this.picColor.TabStop = false;
            // 
            // lblX
            // 
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(573, 20);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(69, 23);
            this.lblX.TabIndex = 80;
            this.lblX.Text = "1000";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY
            // 
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(652, 20);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(69, 23);
            this.lblY.TabIndex = 81;
            this.lblY.Text = "1000";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(637, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 23);
            this.label7.TabIndex = 82;
            this.label7.Text = ":";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpDisplay
            // 
            this.grpDisplay.Controls.Add(this.checkedListBox);
            this.grpDisplay.Controls.Add(this.btnAffichage);
            this.grpDisplay.Location = new System.Drawing.Point(1094, 16);
            this.grpDisplay.Name = "grpDisplay";
            this.grpDisplay.Size = new System.Drawing.Size(179, 180);
            this.grpDisplay.TabIndex = 83;
            this.grpDisplay.TabStop = false;
            this.grpDisplay.Text = "Affichage";
            // 
            // PageTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpDisplay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.grpPrepare);
            this.Controls.Add(this.btnTestScore);
            this.Controls.Add(this.groupBoxDeplacements);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.boxSourisObstacle);
            this.Controls.Add(this.pictureBoxTable);
            this.Name = "PageTable";
            this.Size = new System.Drawing.Size(1273, 669);
            this.Load += new System.EventHandler(this.PanelTable_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBoxDeplacements.ResumeLayout(false);
            this.groupBoxDeplacements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNbPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTable)).EndInit();
            this.grpPrepare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.grpDisplay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTable;
        private System.Windows.Forms.Button btnAffichage;
        private System.Windows.Forms.CheckBox boxSourisObstacle;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblSecondes;
        private System.Windows.Forms.Button btnAleatoire;
        private System.Windows.Forms.Button btnPathRPCentre;
        private System.Windows.Forms.Button btnPathRPFace;
        private System.Windows.Forms.Button btnTeleportRPFace;
        private System.Windows.Forms.Button btnTeleportRPCentre;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private Composants.LabelPlus lblPathfinding;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.GroupBox groupBoxDeplacements;
        private System.Windows.Forms.ToolTip toolTip;
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
        private System.Windows.Forms.GroupBox grpPrepare;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.Button btnCalib;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpDisplay;
        private System.Windows.Forms.Label lblScoreTxt;
        private System.Windows.Forms.Label label1;
        private Composants.LabelPlus labelPlus3;
        private Composants.LabelPlus labelPlus2;
        private Composants.LabelPlus lblPositionTxt;
        private System.Windows.Forms.Label lblPosTheta;
        private System.Windows.Forms.Label lblPosY;
        private System.Windows.Forms.Label lblPosX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
