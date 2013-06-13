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
using GoBot.UDP;
using UDP;
using System.Net;
using GoBot.Enchainements;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System.Threading;
using GoBot.Mouvements;
using System.Diagnostics;

namespace GoBot
{
    public partial class FenGoBot : Form
    {
        public FenGoBot()
        {
            InitializeComponent();

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

        void AjouterLigne(Color couleur, String texte)
        {
            this.Invoke(new EventHandler(delegate
                {
                    texte = DateTime.Now.ToLongTimeString() + " > " + texte + Environment.NewLine;
                    txtLogComplet.SuspendLayout();

                    txtLogComplet.SelectionStart = txtLogComplet.TextLength;
                    txtLogComplet.SelectedText = texte;

                    txtLogComplet.SelectionStart = txtLogComplet.TextLength - texte.Length + 1;
                    txtLogComplet.SelectionLength = texte.Length;
                    txtLogComplet.SelectionColor = couleur;

                    txtLogComplet.ResumeLayout();

                    txtLogComplet.Select(txtLogComplet.TextLength, 0);

                    txtLogComplet.SelectionStart = txtLogComplet.TextLength;
                    txtLogComplet.ScrollToCaret();
                }));
        }

        void HistoriqueGR_nouvelleAction(Actions.IAction action)
        {
            AjouterLigne(Color.RoyalBlue, action.ToString());
        }

        void HistoriquePR_nouvelleAction(Actions.IAction action)
        {
            AjouterLigne(Color.Green, action.ToString());
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
            panelTable.Stop();

            /*Plateau.Balise1.writer.Close();
            Plateau.Balise2.writer.Close();
            Plateau.Balise3.writer.Close();*/
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Process.Start("KillGoBot.exe");
        }

        private void btnCouleurBleu_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurJ2B;
        }

        private void btnCouleurRouge_Click(object sender, EventArgs e)
        {
            Plateau.NotreCouleur = Plateau.CouleurJ1R;
        }

        public void CouleurRouge()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurJ1R;
            pictureBoxBalises.Image = Properties.Resources.TableRouge;

            panelBougies.ChangementCouleur();

            panelBalise1.Balise.Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            panelBalise2.Balise.Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            panelBalise3.Balise.Position = new Position(new Angle(0, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));
        }

        public void CouleurBleu()
        {
            pictureBoxCouleur.BackColor = Plateau.CouleurJ2B;
            pictureBoxBalises.Image = Properties.Resources.TableViolet;

            panelBougies.ChangementCouleur();

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

            if(Plateau.NotreCouleur == Plateau.CouleurJ2B)
                Robots.PetitRobot.PivotDroite(90);
            else
                Robots.PetitRobot.PivotGauche(90);

            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Thread.Sleep(1000);

            if (Plateau.NotreCouleur == Plateau.CouleurJ2B)
                Robots.PetitRobot.ReglerOffsetAsserv(Robots.PetitRobot.Longueur / 2, 1750 - Robots.PetitRobot.Longueur / 2, 0);
            else
                Robots.PetitRobot.ReglerOffsetAsserv(3000 - Robots.PetitRobot.Longueur / 2, 1750 - Robots.PetitRobot.Longueur / 2, 0);
        }

        public void RecallagesDebut()
        {
            panelBougies.btnCapture_Click(null, null);
            // Recallage du gros robot

            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurBas);
            Thread.Sleep(400);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRAspirateur, Config.CurrentConfig.PositionGRAspirateurHaut);

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(10);
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Avancer(890);

            if (Plateau.NotreCouleur == Plateau.CouleurJ1R)
                Robots.GrosRobot.PivotGauche(90);
            else
                Robots.GrosRobot.PivotDroite(90);

            Robots.GrosRobot.Reculer(400);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            panelBougies.btnCapture_Click(null, null);
            while (!panelBougies.imageRefresh)
                Thread.Sleep(100);

            Robots.GrosRobot.Avancer(1500 - Robots.GrosRobot.Longueur / 2);

            this.Invoke(new EventHandler(delegate
            {
                ledRecallage.CouleurVert();
            }));
        }

        private void RecallagesFin()
        {
            Robots.GrosRobot.Reculer(1450 - Robots.GrosRobot.Longueur / 2);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);

            Thread.Sleep(1000);

            if (Plateau.NotreCouleur == Plateau.CouleurJ1R)
                Robots.GrosRobot.ReglerOffsetAsserv(3000 - Robots.GrosRobot.Longueur / 2, 1000, 180);
            else
                Robots.GrosRobot.ReglerOffsetAsserv(Robots.GrosRobot.Longueur / 2, 1000, 0);

            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.ArmerJack();

            if (Plateau.NotreCouleur == Plateau.CouleurJ1R)
                Plateau.AssiettesExiste[7] = false;
            else
                Plateau.AssiettesExiste[2] = false;

            PanelBougies.ContinuerJusquauDebutMatch = true;
            panelBougies.btnCapture_Click(null, null);

            this.Invoke(new EventHandler(delegate
            {
                ledBalises.CouleurVert();
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

            AjouterLigneTrame(couleur, texte);
        }

        void AjouterLigneTrame(Color couleur, String texte)
        {
            texte = DateTime.Now.ToLongTimeString() + " > " + texte + Environment.NewLine;
            txtTrames.SuspendLayout();

            txtTrames.SelectionStart = 0;
            txtTrames.SelectedText = texte;

            txtTrames.SelectionStart = 0;
            txtTrames.SelectionLength = texte.Length - 1;
            txtTrames.SelectionColor = couleur;

            /*if (texte.Contains("Io"))
                txtTrames.SelectionAlignment = HorizontalAlignment.Right;
            else
                txtTrames.SelectionAlignment = HorizontalAlignment.Left;*/

            txtTrames.ResumeLayout();

            txtTrames.Select(txtLogComplet.TextLength, 0);
        }

        private void btnSaveReplay_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog open = new SaveFileDialog())
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    replay.Save(open.FileName);
        }

        private void btnChargerReplay_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog open = new OpenFileDialog())
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    replay = new Replay();
                    replay.Load(open.FileName);
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
        }

        void Plateau_NotreCouleurChange(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(delegate
                {
                    if (Plateau.NotreCouleur == Plateau.CouleurJ1R)
                        CouleurRouge();
                    else if (Plateau.NotreCouleur == Plateau.CouleurJ2B)
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

        private void btnDegommage_Click(object sender, EventArgs e)
        {
            Plateau.Degommage = !Plateau.Degommage;

            if (Plateau.Degommage)
                led2.CouleurVert();
            else
                led2.CouleurRouge();
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
