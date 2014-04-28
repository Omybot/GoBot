namespace GoBot.IHM
{
    partial class PanelBaliseInclinaison
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
            this.groupBalise = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAutocalibTout = new System.Windows.Forms.Button();
            this.btnAutocalibProfil = new System.Windows.Forms.Button();
            this.btnAutocalibFace = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numPasProfil = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCourseProfil = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numPasFace = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCourseFace = new System.Windows.Forms.Button();
            this.lblTxtInclinaisonProfil = new System.Windows.Forms.Label();
            this.lblInclinaisonProfil = new System.Windows.Forms.Label();
            this.trackBarInclinaisonProfil = new Composants.TrackBarPlus();
            this.lblTxtInclinaisonFace = new System.Windows.Forms.Label();
            this.lblInclinaisonFace = new System.Windows.Forms.Label();
            this.trackBarInclinaisonFace = new Composants.TrackBarPlus();
            this.ctrlGraphique = new Composants.CtrlGraphique();
            this.groupBalise.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPasProfil)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPasFace)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBalise
            // 
            this.groupBalise.Controls.Add(this.groupBox4);
            this.groupBalise.Controls.Add(this.groupBox3);
            this.groupBalise.Controls.Add(this.groupBox2);
            this.groupBalise.Controls.Add(this.groupBox1);
            this.groupBalise.Controls.Add(this.lblTxtInclinaisonProfil);
            this.groupBalise.Controls.Add(this.lblInclinaisonProfil);
            this.groupBalise.Controls.Add(this.trackBarInclinaisonProfil);
            this.groupBalise.Controls.Add(this.lblTxtInclinaisonFace);
            this.groupBalise.Controls.Add(this.lblInclinaisonFace);
            this.groupBalise.Controls.Add(this.trackBarInclinaisonFace);
            this.groupBalise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBalise.Location = new System.Drawing.Point(0, 0);
            this.groupBalise.Name = "groupBalise";
            this.groupBalise.Size = new System.Drawing.Size(333, 604);
            this.groupBalise.TabIndex = 0;
            this.groupBalise.TabStop = false;
            this.groupBalise.Text = "Balise";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAutocalibTout);
            this.groupBox4.Controls.Add(this.btnAutocalibProfil);
            this.groupBox4.Controls.Add(this.btnAutocalibFace);
            this.groupBox4.Location = new System.Drawing.Point(6, 453);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(305, 59);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Autocalibration";
            // 
            // btnAutocalibTout
            // 
            this.btnAutocalibTout.Location = new System.Drawing.Point(213, 21);
            this.btnAutocalibTout.Name = "btnAutocalibTout";
            this.btnAutocalibTout.Size = new System.Drawing.Size(75, 23);
            this.btnAutocalibTout.TabIndex = 2;
            this.btnAutocalibTout.Text = "Tout";
            this.btnAutocalibTout.UseVisualStyleBackColor = true;
            // 
            // btnAutocalibProfil
            // 
            this.btnAutocalibProfil.Location = new System.Drawing.Point(112, 21);
            this.btnAutocalibProfil.Name = "btnAutocalibProfil";
            this.btnAutocalibProfil.Size = new System.Drawing.Size(75, 23);
            this.btnAutocalibProfil.TabIndex = 1;
            this.btnAutocalibProfil.Text = "Profil";
            this.btnAutocalibProfil.UseVisualStyleBackColor = true;
            // 
            // btnAutocalibFace
            // 
            this.btnAutocalibFace.Location = new System.Drawing.Point(11, 22);
            this.btnAutocalibFace.Name = "btnAutocalibFace";
            this.btnAutocalibFace.Size = new System.Drawing.Size(75, 23);
            this.btnAutocalibFace.TabIndex = 0;
            this.btnAutocalibFace.Text = "Face";
            this.btnAutocalibFace.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ctrlGraphique);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 190);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Retour signal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Dernier :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Premier :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numPasProfil);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnCourseProfil);
            this.groupBox2.Location = new System.Drawing.Point(6, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 64);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Course automatique profil";
            // 
            // numPasProfil
            // 
            this.numPasProfil.Location = new System.Drawing.Point(95, 28);
            this.numPasProfil.Name = "numPasProfil";
            this.numPasProfil.Size = new System.Drawing.Size(64, 20);
            this.numPasProfil.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Pas :";
            // 
            // btnCourseProfil
            // 
            this.btnCourseProfil.Location = new System.Drawing.Point(176, 26);
            this.btnCourseProfil.Name = "btnCourseProfil";
            this.btnCourseProfil.Size = new System.Drawing.Size(38, 23);
            this.btnCourseProfil.TabIndex = 11;
            this.btnCourseProfil.Text = "Go";
            this.btnCourseProfil.UseVisualStyleBackColor = true;
            this.btnCourseProfil.Click += new System.EventHandler(this.btnCourseProfil_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numPasFace);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCourseFace);
            this.groupBox1.Location = new System.Drawing.Point(6, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 64);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Course automatique face";
            // 
            // numPasFace
            // 
            this.numPasFace.Location = new System.Drawing.Point(95, 28);
            this.numPasFace.Name = "numPasFace";
            this.numPasFace.Size = new System.Drawing.Size(64, 20);
            this.numPasFace.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Pas :";
            // 
            // btnCourseFace
            // 
            this.btnCourseFace.Location = new System.Drawing.Point(176, 26);
            this.btnCourseFace.Name = "btnCourseFace";
            this.btnCourseFace.Size = new System.Drawing.Size(38, 23);
            this.btnCourseFace.TabIndex = 11;
            this.btnCourseFace.Text = "Go";
            this.btnCourseFace.UseVisualStyleBackColor = true;
            this.btnCourseFace.Click += new System.EventHandler(this.btnCourseFace_Click);
            // 
            // lblTxtInclinaisonProfil
            // 
            this.lblTxtInclinaisonProfil.AutoSize = true;
            this.lblTxtInclinaisonProfil.Location = new System.Drawing.Point(62, 63);
            this.lblTxtInclinaisonProfil.Name = "lblTxtInclinaisonProfil";
            this.lblTxtInclinaisonProfil.Size = new System.Drawing.Size(82, 13);
            this.lblTxtInclinaisonProfil.TabIndex = 10;
            this.lblTxtInclinaisonProfil.Text = "Inclinaison profil";
            // 
            // lblInclinaisonProfil
            // 
            this.lblInclinaisonProfil.AutoSize = true;
            this.lblInclinaisonProfil.Location = new System.Drawing.Point(20, 81);
            this.lblInclinaisonProfil.Name = "lblInclinaisonProfil";
            this.lblInclinaisonProfil.Size = new System.Drawing.Size(13, 13);
            this.lblInclinaisonProfil.TabIndex = 9;
            this.lblInclinaisonProfil.Text = "0";
            // 
            // trackBarInclinaisonProfil
            // 
            this.trackBarInclinaisonProfil.BackColor = System.Drawing.Color.Transparent;
            this.trackBarInclinaisonProfil.IntervalTimer = 500;
            this.trackBarInclinaisonProfil.Location = new System.Drawing.Point(65, 79);
            this.trackBarInclinaisonProfil.Max = 1000D;
            this.trackBarInclinaisonProfil.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarInclinaisonProfil.Min = 0D;
            this.trackBarInclinaisonProfil.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarInclinaisonProfil.Name = "trackBarInclinaisonProfil";
            this.trackBarInclinaisonProfil.NombreDecimales = 0;
            this.trackBarInclinaisonProfil.Reverse = false;
            this.trackBarInclinaisonProfil.Size = new System.Drawing.Size(246, 15);
            this.trackBarInclinaisonProfil.TabIndex = 8;
            this.trackBarInclinaisonProfil.Vertical = false;
            this.trackBarInclinaisonProfil.TickValueChanged += new System.EventHandler(this.trackBarInclinaisonProfil_TickValueChanged);
            this.trackBarInclinaisonProfil.ValueChanged += new System.EventHandler(this.trackBarInclinaisonProfil_ValueChanged);
            // 
            // lblTxtInclinaisonFace
            // 
            this.lblTxtInclinaisonFace.AutoSize = true;
            this.lblTxtInclinaisonFace.Location = new System.Drawing.Point(62, 21);
            this.lblTxtInclinaisonFace.Name = "lblTxtInclinaisonFace";
            this.lblTxtInclinaisonFace.Size = new System.Drawing.Size(81, 13);
            this.lblTxtInclinaisonFace.TabIndex = 7;
            this.lblTxtInclinaisonFace.Text = "Inclinaison face";
            // 
            // lblInclinaisonFace
            // 
            this.lblInclinaisonFace.AutoSize = true;
            this.lblInclinaisonFace.Location = new System.Drawing.Point(20, 39);
            this.lblInclinaisonFace.Name = "lblInclinaisonFace";
            this.lblInclinaisonFace.Size = new System.Drawing.Size(13, 13);
            this.lblInclinaisonFace.TabIndex = 3;
            this.lblInclinaisonFace.Text = "0";
            // 
            // trackBarInclinaisonFace
            // 
            this.trackBarInclinaisonFace.BackColor = System.Drawing.Color.Transparent;
            this.trackBarInclinaisonFace.IntervalTimer = 500;
            this.trackBarInclinaisonFace.Location = new System.Drawing.Point(65, 37);
            this.trackBarInclinaisonFace.Max = 1000D;
            this.trackBarInclinaisonFace.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarInclinaisonFace.Min = 0D;
            this.trackBarInclinaisonFace.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarInclinaisonFace.Name = "trackBarInclinaisonFace";
            this.trackBarInclinaisonFace.NombreDecimales = 0;
            this.trackBarInclinaisonFace.Reverse = false;
            this.trackBarInclinaisonFace.Size = new System.Drawing.Size(246, 15);
            this.trackBarInclinaisonFace.TabIndex = 2;
            this.trackBarInclinaisonFace.Vertical = false;
            this.trackBarInclinaisonFace.TickValueChanged += new System.EventHandler(this.trackBarInclinaisonFace_TickValueChanged);
            this.trackBarInclinaisonFace.ValueChanged += new System.EventHandler(this.trackBarInclinaisonFace_ValueChanged);
            // 
            // ctrlGraphique
            // 
            this.ctrlGraphique.BackColor = System.Drawing.Color.White;
            this.ctrlGraphique.EchelleCommune = true;
            this.ctrlGraphique.EchelleFixe = false;
            this.ctrlGraphique.EchelleMax = 1D;
            this.ctrlGraphique.EchelleMin = 0D;
            this.ctrlGraphique.Location = new System.Drawing.Point(6, 44);
            this.ctrlGraphique.Name = "ctrlGraphique";
            this.ctrlGraphique.Size = new System.Drawing.Size(293, 140);
            this.ctrlGraphique.TabIndex = 4;
            // 
            // PanelBaliseInclinaison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBalise);
            this.Name = "PanelBaliseInclinaison";
            this.Size = new System.Drawing.Size(333, 604);
            this.groupBalise.ResumeLayout(false);
            this.groupBalise.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPasProfil)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPasFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBalise;
        private Composants.TrackBarPlus trackBarInclinaisonFace;
        private System.Windows.Forms.Label lblInclinaisonFace;
        private System.Windows.Forms.Label lblTxtInclinaisonProfil;
        private System.Windows.Forms.Label lblInclinaisonProfil;
        private Composants.TrackBarPlus trackBarInclinaisonProfil;
        private System.Windows.Forms.Label lblTxtInclinaisonFace;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAutocalibProfil;
        private System.Windows.Forms.Button btnAutocalibFace;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numPasProfil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCourseProfil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numPasFace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCourseFace;
        private System.Windows.Forms.Button btnAutocalibTout;
        private Composants.CtrlGraphique ctrlGraphique;
    }
}
