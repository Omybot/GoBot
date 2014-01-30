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

        // Robots.GrosRobot.Historique.NouvelleAction += new Historique.DelegateAction(HistoriqueGR_nouvelleAction);
        // Robots.PetitRobot.Historique.NouvelleAction += new Historique.DelegateAction(HistoriquePR_nouvelleAction);

        /*void HistoriqueGR_nouvelleAction(Actions.IAction action)
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
        }*/


        private void FenGoBot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Save();
            panelBalise1.Balise.VitesseRotation(0);
            panelBalise2.Balise.VitesseRotation(0);
            panelBalise3.Balise.VitesseRotation(0);

            SauverLogs();
        }

        private void SauverLogs()
        {
            Connexions.ConnexionMiwi.Sauvegarde.Sauvegarder("./Logs/ConnexionMiwi.tlog");
            Connexions.ConnexionMove.Sauvegarde.Sauvegarder("./Logs/ConnexionMove.tlog");
            Connexions.ConnexionPi.Sauvegarde.Sauvegarder("./Logs/ConnexionPi.tlog");

            Robots.GrosRobot.Historique.Sauvegarder("./Logs/ActionsGros.hlog");
            Robots.PetitRobot.Historique.Sauvegarder("./Logs/ActionsPetit.hlog");
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

        private void FenGoBot_Load(object sender, EventArgs e)
        {
            Plateau.NotreCouleurChange += new EventHandler(Plateau_NotreCouleurChange);

            btnCouleurBleu_Click(null, null);
            Connexions.ConnexionMove.SendMessage(TrameFactory.DemandeCouleurEquipe());


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
            // todo
            //Robots.GrosRobot.Historique.NouvelleAction += new Historique.DelegateAction(HistoriqueGR_nouvelleAction);
            //Robots.PetitRobot.Historique.NouvelleAction += new Historique.DelegateAction(HistoriquePR_nouvelleAction);
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
    }
}
