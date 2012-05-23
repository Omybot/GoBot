namespace GoBot.IHM.IHMPetitRobot
{
    partial class PanelBras
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
            this.groupPinces = new System.Windows.Forms.GroupBox();
            this.btnTaille = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUtilisation = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBarBrasDroiteUtil = new GoBot.IHM.Composants.TrackBarPlus();
            this.trackBarBrasGaucheUtil = new GoBot.IHM.Composants.TrackBarPlus();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.switchBoutonPompeDroite = new GoBot.IHM.Composants.SwitchBouton();
            this.switchBoutonPompeGauche = new GoBot.IHM.Composants.SwitchBouton();
            this.tabReglage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBrasGauche = new System.Windows.Forms.Label();
            this.lblBrasDroite = new System.Windows.Forms.Label();
            this.trackBrasDroite = new GoBot.IHM.Composants.TrackBarPlus();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerCommeRangéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerCommeApprocheLingotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBrasGauche = new GoBot.IHM.Composants.TrackBarPlus();
            this.led = new GoBot.IHM.Composants.Led();
            this.tabSequence = new System.Windows.Forms.TabPage();
            this.btnAttrapeGauche = new System.Windows.Forms.Button();
            this.btnAttrapeDroite = new System.Windows.Forms.Button();
            this.btnRelacheGauche = new System.Windows.Forms.Button();
            this.btnRelacheDroite = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupPinces.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUtilisation.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabReglage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led)).BeginInit();
            this.tabSequence.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPinces
            // 
            this.groupPinces.Controls.Add(this.btnTaille);
            this.groupPinces.Controls.Add(this.tabControl);
            this.groupPinces.Location = new System.Drawing.Point(3, 3);
            this.groupPinces.MaximumSize = new System.Drawing.Size(331, 500);
            this.groupPinces.MinimumSize = new System.Drawing.Size(331, 0);
            this.groupPinces.Name = "groupPinces";
            this.groupPinces.Size = new System.Drawing.Size(331, 260);
            this.groupPinces.TabIndex = 72;
            this.groupPinces.TabStop = false;
            this.groupPinces.Text = "Pinces";
            // 
            // btnTaille
            // 
            this.btnTaille.Image = global::GoBot.Properties.Resources.haut;
            this.btnTaille.Location = new System.Drawing.Point(301, 10);
            this.btnTaille.Name = "btnTaille";
            this.btnTaille.Size = new System.Drawing.Size(24, 23);
            this.btnTaille.TabIndex = 86;
            this.btnTaille.UseVisualStyleBackColor = true;
            this.btnTaille.Click += new System.EventHandler(this.btnTaille_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabUtilisation);
            this.tabControl.Controls.Add(this.tabReglage);
            this.tabControl.Controls.Add(this.tabSequence);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 16);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(325, 241);
            this.tabControl.TabIndex = 7;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabUtilisation
            // 
            this.tabUtilisation.Controls.Add(this.panel1);
            this.tabUtilisation.Location = new System.Drawing.Point(4, 22);
            this.tabUtilisation.Name = "tabUtilisation";
            this.tabUtilisation.Padding = new System.Windows.Forms.Padding(3);
            this.tabUtilisation.Size = new System.Drawing.Size(317, 215);
            this.tabUtilisation.TabIndex = 0;
            this.tabUtilisation.Text = "Utilisation";
            this.tabUtilisation.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trackBarBrasDroiteUtil);
            this.panel1.Controls.Add(this.trackBarBrasGaucheUtil);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.switchBoutonPompeDroite);
            this.panel1.Controls.Add(this.switchBoutonPompeGauche);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 209);
            this.panel1.TabIndex = 70;
            // 
            // trackBarBrasDroiteUtil
            // 
            this.trackBarBrasDroiteUtil.BackColor = System.Drawing.Color.Transparent;
            this.trackBarBrasDroiteUtil.IntervalTimer = 1;
            this.trackBarBrasDroiteUtil.Location = new System.Drawing.Point(115, 69);
            this.trackBarBrasDroiteUtil.Max = 2D;
            this.trackBarBrasDroiteUtil.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarBrasDroiteUtil.Min = 0D;
            this.trackBarBrasDroiteUtil.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarBrasDroiteUtil.Name = "trackBarBrasDroiteUtil";
            this.trackBarBrasDroiteUtil.Reverse = false;
            this.trackBarBrasDroiteUtil.Size = new System.Drawing.Size(150, 15);
            this.trackBarBrasDroiteUtil.TabIndex = 9;
            this.trackBarBrasDroiteUtil.TickValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarBrasDroiteUtil_TickValueChanged);
            // 
            // trackBarBrasGaucheUtil
            // 
            this.trackBarBrasGaucheUtil.BackColor = System.Drawing.Color.Transparent;
            this.trackBarBrasGaucheUtil.IntervalTimer = 1;
            this.trackBarBrasGaucheUtil.Location = new System.Drawing.Point(115, 48);
            this.trackBarBrasGaucheUtil.Max = 2D;
            this.trackBarBrasGaucheUtil.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBarBrasGaucheUtil.Min = 0D;
            this.trackBarBrasGaucheUtil.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBarBrasGaucheUtil.Name = "trackBarBrasGaucheUtil";
            this.trackBarBrasGaucheUtil.Reverse = false;
            this.trackBarBrasGaucheUtil.Size = new System.Drawing.Size(150, 15);
            this.trackBarBrasGaucheUtil.TabIndex = 8;
            this.trackBarBrasGaucheUtil.TickValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBarBrasGaucheUtil_TickValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pompe droite";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bras droite";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pompe gauche";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bras gauche";
            // 
            // switchBoutonPompeDroite
            // 
            this.switchBoutonPompeDroite.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonPompeDroite.Location = new System.Drawing.Point(115, 135);
            this.switchBoutonPompeDroite.Name = "switchBoutonPompeDroite";
            this.switchBoutonPompeDroite.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonPompeDroite.Symetrique = true;
            this.switchBoutonPompeDroite.TabIndex = 3;
            this.switchBoutonPompeDroite.ChangementEtat += new GoBot.IHM.Composants.SwitchBouton.ChangeEtatDelegate(this.switchBoutonPompeDroite_ChangementEtat);
            // 
            // switchBoutonPompeGauche
            // 
            this.switchBoutonPompeGauche.BackColor = System.Drawing.Color.Transparent;
            this.switchBoutonPompeGauche.Location = new System.Drawing.Point(115, 112);
            this.switchBoutonPompeGauche.Name = "switchBoutonPompeGauche";
            this.switchBoutonPompeGauche.Size = new System.Drawing.Size(35, 15);
            this.switchBoutonPompeGauche.Symetrique = true;
            this.switchBoutonPompeGauche.TabIndex = 1;
            this.switchBoutonPompeGauche.ChangementEtat += new GoBot.IHM.Composants.SwitchBouton.ChangeEtatDelegate(this.switchBoutonPompeGauche_ChangementEtat);
            // 
            // tabReglage
            // 
            this.tabReglage.Controls.Add(this.panel2);
            this.tabReglage.Location = new System.Drawing.Point(4, 22);
            this.tabReglage.Name = "tabReglage";
            this.tabReglage.Padding = new System.Windows.Forms.Padding(3);
            this.tabReglage.Size = new System.Drawing.Size(317, 215);
            this.tabReglage.TabIndex = 1;
            this.tabReglage.Text = "Réglage";
            this.tabReglage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblBrasGauche);
            this.panel2.Controls.Add(this.lblBrasDroite);
            this.panel2.Controls.Add(this.trackBrasDroite);
            this.panel2.Controls.Add(this.trackBrasGauche);
            this.panel2.Controls.Add(this.led);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 209);
            this.panel2.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Bras droite";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Bras gauche";
            // 
            // lblBrasGauche
            // 
            this.lblBrasGauche.Location = new System.Drawing.Point(272, 42);
            this.lblBrasGauche.Name = "lblBrasGauche";
            this.lblBrasGauche.Size = new System.Drawing.Size(39, 16);
            this.lblBrasGauche.TabIndex = 31;
            this.lblBrasGauche.Text = "100";
            this.lblBrasGauche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrasDroite
            // 
            this.lblBrasDroite.Location = new System.Drawing.Point(275, 73);
            this.lblBrasDroite.Name = "lblBrasDroite";
            this.lblBrasDroite.Size = new System.Drawing.Size(39, 16);
            this.lblBrasDroite.TabIndex = 29;
            this.lblBrasDroite.Text = "100";
            this.lblBrasDroite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBrasDroite
            // 
            this.trackBrasDroite.BackColor = System.Drawing.Color.Transparent;
            this.trackBrasDroite.ContextMenuStrip = this.contextMenuStrip;
            this.trackBrasDroite.IntervalTimer = 500;
            this.trackBrasDroite.Location = new System.Drawing.Point(73, 73);
            this.trackBrasDroite.Max = 1023D;
            this.trackBrasDroite.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBrasDroite.Min = 0D;
            this.trackBrasDroite.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBrasDroite.Name = "trackBrasDroite";
            this.trackBrasDroite.Reverse = false;
            this.trackBrasDroite.Size = new System.Drawing.Size(193, 15);
            this.trackBrasDroite.TabIndex = 27;
            this.trackBrasDroite.TickValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBrasDroite_TickValueChanged);
            this.trackBrasDroite.ValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBrasDroite_ValueChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enregistrerToolStripMenuItem,
            this.enregistrerCommeRangéToolStripMenuItem,
            this.enregistrerCommeApprocheLingotToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(221, 70);
            // 
            // enregistrerToolStripMenuItem
            // 
            this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
            this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.enregistrerToolStripMenuItem.Text = "Enregistrer comme \"Replié\"";
            this.enregistrerToolStripMenuItem.Click += new System.EventHandler(this.EnregistrerPositionReplie);
            // 
            // enregistrerCommeRangéToolStripMenuItem
            // 
            this.enregistrerCommeRangéToolStripMenuItem.Name = "enregistrerCommeRangéToolStripMenuItem";
            this.enregistrerCommeRangéToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.enregistrerCommeRangéToolStripMenuItem.Text = "Enregistrer comme \"Rangé\"";
            this.enregistrerCommeRangéToolStripMenuItem.Click += new System.EventHandler(this.EnregistrerPositionRange);
            // 
            // enregistrerCommeApprocheLingotToolStripMenuItem
            // 
            this.enregistrerCommeApprocheLingotToolStripMenuItem.Name = "enregistrerCommeApprocheLingotToolStripMenuItem";
            this.enregistrerCommeApprocheLingotToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.enregistrerCommeApprocheLingotToolStripMenuItem.Text = "Enregistrer comme \"Déplié\"";
            this.enregistrerCommeApprocheLingotToolStripMenuItem.Click += new System.EventHandler(this.EnregistrerPositionDeplie);
            // 
            // trackBrasGauche
            // 
            this.trackBrasGauche.BackColor = System.Drawing.Color.Transparent;
            this.trackBrasGauche.ContextMenuStrip = this.contextMenuStrip;
            this.trackBrasGauche.IntervalTimer = 500;
            this.trackBrasGauche.Location = new System.Drawing.Point(73, 44);
            this.trackBrasGauche.Max = 1023D;
            this.trackBrasGauche.MaximumSize = new System.Drawing.Size(3000, 15);
            this.trackBrasGauche.Min = 0D;
            this.trackBrasGauche.MinimumSize = new System.Drawing.Size(0, 15);
            this.trackBrasGauche.Name = "trackBrasGauche";
            this.trackBrasGauche.Reverse = true;
            this.trackBrasGauche.Size = new System.Drawing.Size(193, 15);
            this.trackBrasGauche.TabIndex = 26;
            this.trackBrasGauche.TickValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBrasGauche_TickValueChanged);
            this.trackBrasGauche.ValueChanged += new GoBot.IHM.Composants.TrackBarPlus.delegateValueChanged(this.trackBrasGauche_ValueChanged);
            // 
            // led
            // 
            this.led.Etat = false;
            this.led.Location = new System.Drawing.Point(291, 3);
            this.led.Name = "led";
            this.led.Size = new System.Drawing.Size(16, 16);
            this.led.TabIndex = 19;
            this.led.TabStop = false;
            // 
            // tabSequence
            // 
            this.tabSequence.Controls.Add(this.label8);
            this.tabSequence.Controls.Add(this.label7);
            this.tabSequence.Controls.Add(this.btnRelacheDroite);
            this.tabSequence.Controls.Add(this.btnRelacheGauche);
            this.tabSequence.Controls.Add(this.btnAttrapeDroite);
            this.tabSequence.Controls.Add(this.btnAttrapeGauche);
            this.tabSequence.Location = new System.Drawing.Point(4, 22);
            this.tabSequence.Name = "tabSequence";
            this.tabSequence.Padding = new System.Windows.Forms.Padding(3);
            this.tabSequence.Size = new System.Drawing.Size(317, 215);
            this.tabSequence.TabIndex = 2;
            this.tabSequence.Text = "Séquences";
            this.tabSequence.UseVisualStyleBackColor = true;
            // 
            // btnAttrapeGauche
            // 
            this.btnAttrapeGauche.Location = new System.Drawing.Point(57, 68);
            this.btnAttrapeGauche.Name = "btnAttrapeGauche";
            this.btnAttrapeGauche.Size = new System.Drawing.Size(75, 23);
            this.btnAttrapeGauche.TabIndex = 0;
            this.btnAttrapeGauche.Text = "Attraper";
            this.btnAttrapeGauche.UseVisualStyleBackColor = true;
            this.btnAttrapeGauche.Click += new System.EventHandler(this.btnAttrapeGauche_Click);
            // 
            // btnAttrapeDroite
            // 
            this.btnAttrapeDroite.Location = new System.Drawing.Point(188, 68);
            this.btnAttrapeDroite.Name = "btnAttrapeDroite";
            this.btnAttrapeDroite.Size = new System.Drawing.Size(75, 23);
            this.btnAttrapeDroite.TabIndex = 1;
            this.btnAttrapeDroite.Text = "Attraper";
            this.btnAttrapeDroite.UseVisualStyleBackColor = true;
            this.btnAttrapeDroite.Click += new System.EventHandler(this.btnAttrapeDroite_Click);
            // 
            // btnRelacheGauche
            // 
            this.btnRelacheGauche.Location = new System.Drawing.Point(57, 97);
            this.btnRelacheGauche.Name = "btnRelacheGauche";
            this.btnRelacheGauche.Size = new System.Drawing.Size(75, 23);
            this.btnRelacheGauche.TabIndex = 2;
            this.btnRelacheGauche.Text = "Relâcher";
            this.btnRelacheGauche.UseVisualStyleBackColor = true;
            this.btnRelacheGauche.Click += new System.EventHandler(this.btnRelacheGauche_Click);
            // 
            // btnRelacheDroite
            // 
            this.btnRelacheDroite.Location = new System.Drawing.Point(188, 97);
            this.btnRelacheDroite.Name = "btnRelacheDroite";
            this.btnRelacheDroite.Size = new System.Drawing.Size(75, 23);
            this.btnRelacheDroite.TabIndex = 3;
            this.btnRelacheDroite.Text = "Relâcher";
            this.btnRelacheDroite.UseVisualStyleBackColor = true;
            this.btnRelacheDroite.Click += new System.EventHandler(this.btnRelacheDroite_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Gauche";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Droite";
            // 
            // PanelBras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPinces);
            this.Name = "PanelBras";
            this.Size = new System.Drawing.Size(352, 316);
            this.groupPinces.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabUtilisation.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabReglage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.led)).EndInit();
            this.tabSequence.ResumeLayout(false);
            this.tabSequence.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPinces;
        private System.Windows.Forms.Button btnTaille;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUtilisation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabReglage;
        private System.Windows.Forms.Panel panel2;
        private Composants.Led led;
        private Composants.TrackBarPlus trackBrasDroite;
        private Composants.TrackBarPlus trackBrasGauche;
        private System.Windows.Forms.Label lblBrasGauche;
        private System.Windows.Forms.Label lblBrasDroite;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrerCommeApprocheLingotToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Composants.SwitchBouton switchBoutonPompeDroite;
        private Composants.SwitchBouton switchBoutonPompeGauche;
        private System.Windows.Forms.ToolStripMenuItem enregistrerCommeRangéToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Composants.TrackBarPlus trackBarBrasDroiteUtil;
        private Composants.TrackBarPlus trackBarBrasGaucheUtil;
        private System.Windows.Forms.TabPage tabSequence;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRelacheDroite;
        private System.Windows.Forms.Button btnRelacheGauche;
        private System.Windows.Forms.Button btnAttrapeDroite;
        private System.Windows.Forms.Button btnAttrapeGauche;
    }
}
