using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.IHM;
using Composants;
using System.Net;
using GoBot.Enchainements;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System.Threading;
using GoBot.Mouvements;
using System.Diagnostics;
using GoBot.Balises;
using GoBot.Communications;
using System.IO;

namespace GoBot
{
    public partial class FenGoBot : Form
    {
        private System.Windows.Forms.Timer timerSauvegarde;

        public FenGoBot()
        {
            InitializeComponent();
            timerSauvegarde = new System.Windows.Forms.Timer();
            timerSauvegarde.Interval = 10000;
            timerSauvegarde.Tick += timerSauvegarde_Tick;
            timerSauvegarde.Start();

            if (!Config.DesignMode)
            {
                CheckForIllegalCrossThreadCalls = false;
                panelGrosRobot.Init();
                panelPetitRobot.Init();

                if (Screen.PrimaryScreen.Bounds.Width == 1024)
                {
                    WindowState = FormWindowState.Maximized;
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    //btnClose.Visible = false;
                }

                Robots.GrosRobot.Historique.NouvelleAction += new Historique.DelegateAction(HistoriqueGR_nouvelleAction);
                Robots.PetitRobot.Historique.NouvelleAction += new Historique.DelegateAction(HistoriquePR_nouvelleAction);

                panelBalise1.Balise = Plateau.Balise1;
                panelBalise2.Balise = Plateau.Balise2;
                panelBalise3.Balise = Plateau.Balise3;

                panelDiagnosticBalise1.Balise = Plateau.Balise1;
                panelDiagnosticBalise2.Balise = Plateau.Balise2;
                panelDiagnosticBalise3.Balise = Plateau.Balise3;

                // Réglage rouge par défaut
                btnCouleurRouge_Click(null, null);

                Connexions.ConnexionMove.ConnexionCheck.Start();
                Connexions.ConnexionMiwi.ConnexionCheck.Start();
                Connexions.ConnexionPi.ConnexionCheck.Start();

                panelBalise1.Balise.ConnexionCheck.Start();
                panelBalise2.Balise.ConnexionCheck.Start();
                panelBalise3.Balise.ConnexionCheck.Start();

                switchBoutonSimu.SetActif(Robots.Simulation);
            }
        }

        void timerSauvegarde_Tick(object sender, EventArgs e)
        {
            SauverLogs();
        }

        void ConnexionBunCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecBun, conn);
        }

        void ConnexionBeuCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecBeu, conn);
        }

        void ConnexionBoiCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecBoi, conn);
        }

        void ConnexionMoveCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecMove, conn);
        }

        void ConnexionPiCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecPi, conn);
        }

        void ConnexionMiwiCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecMiwi, conn);
        }

        void HistoriqueGR_nouvelleAction(Actions.IAction action)
        {
            this.Invoke(new EventHandler(delegate
            {
                txtLogComplet.AjouterLigne(action.ToString(), Color.RoyalBlue, true);
            }));
        }

        void HistoriquePR_nouvelleAction(Actions.IAction action)
        {
            this.Invoke(new EventHandler(delegate
            {
                txtLogComplet.AjouterLigne(action.ToString(), Color.Green, true);
            }));
        }

        void Robot_ConnexionChange(Carte carte, bool connecte)
        {
            Led selectLed = null;
            switch (carte)
            {
                case Carte.RecMove:
                    selectLed = ledRecMove;
                    break;
                case Carte.RecBun:
                    selectLed = ledRecBun;
                    break;
                case Carte.RecBeu:
                    selectLed = ledRecBeu;
                    break;
                case Carte.RecBoi:
                    selectLed = ledRecBoi;
                    break;
                case Carte.RecPi:
                    selectLed = ledRecPi;
                    break;
                case Carte.RecMiwi:
                    selectLed = ledRecMiwi;
                    break;
            }

            this.Invoke(new EventHandler(delegate
            {
                SetLed(selectLed, connecte);
            }));
        }

        private void SetLed(Led led, bool on)
        {
            if (on)
                led.CouleurVert(true);
            else
                led.CouleurRouge(true);
        }

        private void FenGoBot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Save();
            panelBalise1.Balise.VitesseRotation(0);
            panelBalise2.Balise.VitesseRotation(0);
            panelBalise3.Balise.VitesseRotation(0);

            SauverLogs();
            /*Plateau.Balise1.writer.Close();
            Plateau.Balise2.writer.Close();
            Plateau.Balise3.writer.Close();*/
        }

        private void SauverLogs()
        {
            Connexions.ConnexionMiwi.Sauvegarde.Sauvegarder("./Logs/ConnexionMiwi.tlog");
            Connexions.ConnexionMove.Sauvegarde.Sauvegarder("./Logs/ConnexionMove.tlog");
            Connexions.ConnexionPi.Sauvegarde.Sauvegarder("./Logs/ConnexionPi.tlog");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FenGoBot_FormClosing(null, null);
            Process.Start("KillGoBot.exe");
        }

        private void btnCouleurBleu_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurJ2Jaune;
        }

        private void btnCouleurRouge_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurJ1Rouge;
        }

        public void CouleurRouge()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurJ1Rouge;
            pictureBoxBalises.Image = Properties.Resources.TableRouge;

            panelBalise1.Balise.Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            panelBalise2.Balise.Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            panelBalise3.Balise.Position = new Position(new Angle(0, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));
        }

        public void CouleurBleu()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurJ2Jaune;
            pictureBoxBalises.Image = Properties.Resources.TableViolet;

            panelBalise1.Balise.Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            panelBalise2.Balise.Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            panelBalise3.Balise.Position = new Position(new Angle(180, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));

        }

        Thread thRecallage;
        private void btnRecallage_Click(object sender, EventArgs e)
        {
            if (!Robots.GrosRobot.GetJack(false))
            {
                MessageBox.Show("Tu lances un recallages et tu branches pas le jack ? C'est comme si t'es Omybot t'as pas de robot quoi...", "Non mais allô quoi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnRecallage.Enabled = false;
            if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
            {
                thRecallage = new Thread(RecallagesDebut);
                thRecallage.Start();
            }
            if (Connexions.ConnexionPi.ConnexionCheck.Connecte)
            {
                thRecallagePetit = new Thread(RecallagePetit);
                thRecallagePetit.Start();
            }
        }

        Thread thRecallagePetit;
        private void RecallagePetit()
        {
            Robots.PetitRobot.Lent();
            Robots.PetitRobot.Avancer(10);
            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Robots.PetitRobot.Avancer(250);

            if(Plateau.NotreCouleur == Plateau.CouleurJ2Jaune)
                Robots.PetitRobot.PivotDroite(90);
            else
                Robots.PetitRobot.PivotGauche(90);

            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Thread.Sleep(1000);

            if (Plateau.NotreCouleur == Plateau.CouleurJ2Jaune)
                Robots.PetitRobot.ReglerOffsetAsserv(Robots.PetitRobot.Longueur / 2, 1750 - Robots.PetitRobot.Longueur / 2, 0);
            else
                Robots.PetitRobot.ReglerOffsetAsserv(3000 - Robots.PetitRobot.Longueur / 2, 1750 - Robots.PetitRobot.Longueur / 2, 0);
        }

        /// <summary>
        /// Première partie du recallage : Le robot doit terminer dans une position connue pour la calibration des balises
        /// </summary>
        public void RecallagesDebut()
        {
            panelCamera.btnCapture_Click(null, null);
            // Recallage du gros robot

            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
            Thread.Sleep(400);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(10);
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Avancer(890);

            if (Plateau.NotreCouleur == Plateau.CouleurJ1Rouge)
                Robots.GrosRobot.PivotGauche(90);
            else
                Robots.GrosRobot.PivotDroite(90);

            Robots.GrosRobot.Reculer(400);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();

            Robots.GrosRobot.Avancer(1500 - Robots.GrosRobot.Longueur / 2);

            this.Invoke(new EventHandler(delegate
            {
                ledRecallage.CouleurOrange();
            }));
        }

        /// <summary>
        /// Deuxième partie du recallage : le robot doit partir de la position de recallage des balises et arriver à son point de départ du match
        /// </summary>
        private void RecallagesFin()
        {
            Robots.GrosRobot.Reculer(1450 - Robots.GrosRobot.Longueur / 2);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);

            Thread.Sleep(1000);

            // Envoyer la position actuelle au robot afin qu'il recalle ses offsets
            if (Plateau.NotreCouleur == Plateau.CouleurJ1Rouge)
                Robots.GrosRobot.ReglerOffsetAsserv(3000 - Robots.GrosRobot.Longueur / 2, 1000, 180);
            else
                Robots.GrosRobot.ReglerOffsetAsserv(Robots.GrosRobot.Longueur / 2, 1000, 0);

            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.ArmerJack();

            PanelCamera.ContinuerCamera = true;
            panelCamera.btnCapture_Click(null, null);

            this.Invoke(new EventHandler(delegate
            {
                ledRecallage.CouleurVert();
            }));
        }

        private void btnBalises_Click(object sender, EventArgs e)
        {
            thRecallage = new Thread(RecallagesFin);
            thRecallage.Start();
        }

        private void btnAfficherTrame_Click(object sender, EventArgs e)
        {
            Connexions.ConnexionMiwi.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionTrame);
            Connexions.ConnexionMove.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionTrame);

            replay = new Replay();
            Connexions.ConnexionMiwi.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
            Connexions.ConnexionMove.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
        }

        Replay replay;
        private void ReceptionTrame(Trame t)
        {
            if (t.Length < 1)
                return;

            Color couleur = Color.Black;
            String texte = t.ToString();

            switch (t[0])
            {
                case (Byte)Carte.RecMove:
                    texte = "Move\t" + texte;
                    couleur = Color.FromArgb(218, 37, 37);
                    break;
                /*case (Byte)Carte.RecIo:
                    texte = "Io\t" + texte;
                    couleur = Color.FromArgb(238, 111, 17);
                    break;
                case (Byte)Carte.RecPi:
                    texte = "Pi\t" + texte;
                    couleur = Color.FromArgb(5, 173, 10);
                    break;*/
                case (Byte)Carte.RecBun:
                    texte = "Bun\t" + texte;
                    couleur = Color.FromArgb(81, 101, 238);
                    break;
                case (Byte)Carte.RecBeu:
                    texte = "Beu\t" + texte;
                    couleur = Color.FromArgb(20, 44, 205);
                    break;
                case (Byte)Carte.RecBoi:
                    texte = "Boi\t" + texte;
                    couleur = Color.FromArgb(11, 24, 117);
                    break;
            }

            if (InvokeRequired)
                this.Invoke(new EventHandler(delegate
                {
                    txtTrames.AjouterLigne(texte, couleur);
                }));
            else
                txtTrames.AjouterLigne(texte, couleur);
        }

        private void btnSaveReplay_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog open = new SaveFileDialog())
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    replay.Sauvegarder(open.FileName);
        }

        private void btnChargerReplay_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog open = new OpenFileDialog())
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    replay = new Replay();
                    replay.Charger(open.FileName);
                }
        }

        Thread threadReplay;
        private void btnRejouerReplay_Click(object sender, EventArgs e)
        {
            threadReplay = new Thread(replay.Rejouer);
            threadReplay.Start();
        }

        private void FenGoBot_Load(object sender, EventArgs e)
        {
            Plateau.NotreCouleurChange += new EventHandler(Plateau_NotreCouleurChange);

            btnCouleurBleu_Click(null, null);
            Connexions.ConnexionMove.SendMessage(TrameFactory.DemandeCouleurEquipe());

            Connexions.ConnexionMove.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMoveCheck_ConnexionChange);
            Connexions.ConnexionMiwi.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMiwiCheck_ConnexionChange);
            Connexions.ConnexionPi.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionPiCheck_ConnexionChange);

            panelBalise1.Balise.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBunCheck_ConnexionChange);
            panelBalise2.Balise.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBeuCheck_ConnexionChange);
            panelBalise3.Balise.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBoiCheck_ConnexionChange);

            if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
                SetLed(ledRecMove, true);
            if (Connexions.ConnexionMiwi.ConnexionCheck.Connecte)
                SetLed(ledRecMiwi, true);
            if (Connexions.ConnexionPi.ConnexionCheck.Connecte)
                SetLed(ledRecPi, true);
            if (panelBalise1.Balise.ConnexionCheck.Connecte)
                SetLed(ledRecBun, true);
            if (panelBalise2.Balise.ConnexionCheck.Connecte)
                SetLed(ledRecBeu, true);
            if (panelBalise3.Balise.ConnexionCheck.Connecte)
                SetLed(ledRecBoi, true);

            try
            {
                if (Directory.Exists("./Logs"))
                {
                    if (Directory.Exists("./LogsPrec"))
                        Directory.Delete("./LogsPrec", true);
                    Directory.Move("./Logs", "./LogsPrec");
                }

                Directory.CreateDirectory("./Logs");
            }
            catch(Exception)
            {
                MessageBox.Show("Problème lors de la création des dossiers de log.\nVérifiez si le dossier n'est pas protégé en écriture.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Plateau_NotreCouleurChange(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(delegate
                {
                    if (Plateau.NotreCouleur == Plateau.CouleurJ1Rouge)
                        CouleurRouge();
                    else if (Plateau.NotreCouleur == Plateau.CouleurJ2Jaune)
                        CouleurBleu();
                }));
        }

        private void switchBoutonSimu_ChangementEtat(object sender, EventArgs e)
        {
            Robots.Simuler(switchBoutonSimu.Actif);
            panelGrosRobot.Init();
            panelPetitRobot.Init();
            Robots.GrosRobot.Historique.NouvelleAction += new Historique.DelegateAction(HistoriqueGR_nouvelleAction);
            Robots.PetitRobot.Historique.NouvelleAction += new Historique.DelegateAction(HistoriquePR_nouvelleAction);
        }

        private void btnRecallageGR_Click(object sender, EventArgs e)
        {
            Robots.GrosRobot.ArmerJack();
        }

        private void radioBaliseOui_CheckedChanged(object sender, EventArgs e)
        {
            Plateau.ReflecteursNosRobots = radioBaliseOui.Checked;
        }

        Fenetre fen;
        private void btnPiloteGros_Click(object sender, EventArgs e)
        {
            PanelDeplacement panel = new PanelDeplacement();
            panel.Robot = Robots.GrosRobot;
            fen = new Fenetre(panel);
            fen.TopMost = true;
            fen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fenetre fen = new Fenetre(new PanelLogs());
            fen.Show();
        }
    }
}
