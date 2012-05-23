using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoBot.IHM;
using GoBot.IHM.Composants;
using GoBot.UDP;
using UDP;
using System.Net;
using GoBot.Enchainements;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System.Threading;

namespace GoBot
{
    public partial class FenGoBot : Form
    {
        public FenGoBot()
        {

            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
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
                btnClose.Visible = false;
            }

            GrosRobot.Historique.nouvelleAction += new Historique.delegateAction(HistoriqueGR_nouvelleAction);
            PetitRobot.Historique.nouvelleAction += new Historique.delegateAction(HistoriquePR_nouvelleAction);

            panelBalise1.Balise = Plateau.Balise1;
            panelBalise2.Balise = Plateau.Balise2;
            panelBalise3.Balise = Plateau.Balise3;

            // Réglage rouge par défaut
            btnCouleurRouge_Click(null, null);

            GrosRobot.connexionMove.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMoveCheck_ConnexionChange);
            GrosRobot.connexionIo.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionIoCheck_ConnexionChange);

            panelBalise1.Balise.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBunCheck_ConnexionChange);
            panelBalise2.Balise.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBeuCheck_ConnexionChange);
            panelBalise3.Balise.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBoiCheck_ConnexionChange);
            PetitRobot.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionPi_ConnexionChange);

            GrosRobot.connexionMove.ConnexionCheck.Start();
            GrosRobot.connexionIo.ConnexionCheck.Start();
            PetitRobot.ConnexionCheck.Start();
            panelBalise1.Balise.ConnexionCheck.Start();
            panelBalise2.Balise.ConnexionCheck.Start();
            panelBalise3.Balise.ConnexionCheck.Start();

        }

        void ConnexionPi_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecPi, conn);
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

        void ConnexionIoCheck_ConnexionChange(bool conn)
        {
            Robot_ConnexionChange(Carte.RecIo, conn);
        }

        void AjouterLigne(Color couleur, String texte)
        {
            texte = DateTime.Now.ToLongTimeString() + " > " + texte + Environment.NewLine;
            txtLogComplet.SuspendLayout();

            txtLogComplet.SelectionStart = 0;
            txtLogComplet.SelectedText = texte;

            txtLogComplet.SelectionStart = 0;
            txtLogComplet.SelectionLength = texte.Length;
            txtLogComplet.SelectionColor = couleur;

            txtLogComplet.ResumeLayout();

            txtLogComplet.Select(txtLogComplet.TextLength, 0);
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
                case Carte.RecIo:
                    selectLed = ledRecIo;
                    break;
                case Carte.RecMove:
                    selectLed = ledRecMove;
                    break;
                case Carte.RecPi:
                    selectLed = ledRecPi;
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
            }

            this.Invoke(new EventHandler(delegate
            {
                SetLed(selectLed, connecte);
            }));
        }

        private void SetLed(Led led, bool on)
        {
            if (on)
                led.On(true);
            else
                led.Off(true);
        }

        private void FenGoBot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Save();
            panelBalise1.Balise.VitesseRotation(0);
            panelBalise2.Balise.VitesseRotation(0);
            panelBalise3.Balise.VitesseRotation(0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCouleurViolet_Click(object sender, EventArgs e)
        {
            GrosRobot.Couleur = Color.Purple;
            GrosRobot.Enchainement.SetCouleur(Color.Purple);
            pictureBoxCouleur.BackColor = Color.Purple;
            pictureBoxBalises.Image = Properties.Resources.tableViolet;

            panelBalise1.Balise.Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            panelBalise2.Balise.Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            panelBalise3.Balise.Position = new Position(new Angle(180, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));
        }

        private void btnCouleurRouge_Click(object sender, EventArgs e)
        {
            GrosRobot.Couleur = Color.Red;
            GrosRobot.Enchainement.SetCouleur(Color.Red);
            pictureBoxCouleur.BackColor = Color.Red;
            pictureBoxBalises.Image = Properties.Resources.tableRouge;

            panelBalise1.Balise.Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            panelBalise2.Balise.Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            panelBalise3.Balise.Position = new Position(new Angle(0, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));
        }

        Thread thRecallage;
        private void btnRecallage_Click(object sender, EventArgs e)
        {
            thRecallage = new Thread(Recallages);
            thRecallage.Start();
        }

        public void Recallages()
        {
            /*
            if (pictureBoxCouleur.BackColor == Color.Red)
            {
                GrosRobot.Evitement = false;
                PetitRobot.Evitement = false;

                int vitesse = GrosRobot.VitesseDeplacement;
                int accel = GrosRobot.AccelerationDeplacement;
                GrosRobot.VitesseDeplacement = 150;
                GrosRobot.AccelerationDeplacement = 150;

                PetitRobot.VitesseDeplacement = 150;
                PetitRobot.AccelerationDeplacement = 150;

                PetitRobot.Avancer(10, false);
                GrosRobot.Avancer(10);

                PetitRobot.Recallage(SensAR.Arriere, false);
                GrosRobot.Recallage(SensAR.Arriere);

                PetitRobot.Avancer(480, false);
                GrosRobot.Avancer(530);

                PetitRobot.PivotDroite(90, false);
                GrosRobot.PivotDroite(90);

                PetitRobot.mutexDeplacement.WaitOne();
                PetitRobot.Recallage(SensAR.Arriere);
                PetitRobot.Avancer(186);
                PetitRobot.PivotGauche(90);
                PetitRobot.Recallage(SensAR.Arriere, false);

                GrosRobot.Recallage(SensAR.Arriere);
                GrosRobot.Avancer(132);
                GrosRobot.PivotGauche(90);
                GrosRobot.Reculer(325);
                GrosRobot.Evitement = true;
                PetitRobot.Evitement = true;
            }
            else
            {
                GrosRobot.Evitement = false;
                PetitRobot.Evitement = false;

                int vitesse = GrosRobot.VitesseDeplacement;
                int accel = GrosRobot.AccelerationDeplacement;
                GrosRobot.VitesseDeplacement = 150;
                GrosRobot.AccelerationDeplacement = 150;

                PetitRobot.VitesseDeplacement = 150;
                PetitRobot.AccelerationDeplacement = 150;

                PetitRobot.Avancer(10, false);
                GrosRobot.Avancer(10);

                PetitRobot.Recallage(SensAR.Arriere, false);
                GrosRobot.Recallage(SensAR.Arriere);

                PetitRobot.Avancer(480, false);
                GrosRobot.Avancer(530);

                PetitRobot.PivotGauche(90, false);
                GrosRobot.PivotGauche(90);

                PetitRobot.mutexDeplacement.WaitOne();
                PetitRobot.Recallage(SensAR.Arriere);
                PetitRobot.Avancer(186);
                PetitRobot.PivotDroite(90);
                PetitRobot.Recallage(SensAR.Arriere, false);

                GrosRobot.Recallage(SensAR.Arriere);
                GrosRobot.Avancer(132);
                GrosRobot.PivotDroite(90);
                GrosRobot.Reculer(325);
                GrosRobot.Evitement = true;
                PetitRobot.Evitement = true;
            }*/

            GrosRobot.FermeBenne();
            GrosRobot.FermeBrasBasDroite();
            GrosRobot.FermeBrasBasGauche();
            GrosRobot.FermeBrasHautDroite();
            GrosRobot.FermeBrasHautGauche();
            GrosRobot.FermeBrasMilieuDroite();
            GrosRobot.FermeBrasMilieuGauche();
            GrosRobot.VitesseDeplacement = 150;
            GrosRobot.AccelerationDeplacement = 150;
            DateTime debut = DateTime.Now;
            GrosRobot.Recallage(SensAR.Arriere);

            GrosRobot.Avancer(129);
            GrosRobot.PivotGauche(90);
            GrosRobot.Recallage(SensAR.Arriere);
            ledRecallage.On();
            GrosRobot.ReglerOffsetAsserv(150, 150 + 129, 0);

            GrosRobot.connexionMove.SendMessage(TrameFactory.ResetRecMove());
            GrosRobot.Evitement = true;
             
        }

        private void btnBalises_Click(object sender, EventArgs e)
        {
            ledBalises.On();

            lblPwmBalise1.Visible = true;
            lblPwmBalise2.Visible = true;
            lblPwmBalise3.Visible = true;
        }

        private void btnAfficherTrame_Click(object sender, EventArgs e)
        {
            GrosRobot.connexionIo.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionTrame);
            GrosRobot.connexionMove.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionTrame);

            replay = new Replay();
            GrosRobot.connexionIo.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
            GrosRobot.connexionMove.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
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
                case (Byte)Carte.RecIo:
                    texte = "Io\t" + texte;
                    couleur = Color.FromArgb(238, 111, 17);
                    break;
                case (Byte)Carte.RecPi:
                    texte = "Pi\t" + texte;
                    couleur = Color.FromArgb(5, 173, 10);
                    break;
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
            txtTrames.SelectionLength = texte.Length-1;
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
            SaveFileDialog open = new SaveFileDialog();
            if(open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                replay.Save(open.FileName);
        }

        private void btnChargerReplay_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
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

        private void btnHomolog_Click(object sender, EventArgs e)
        {
            //GrosRobot.Enchainement = new HomologationEnchainement();
            GrosRobot.Enchainement = new TestEnchainement();
            GrosRobot.Enchainement.SetCouleur(pictureBoxCouleur.BackColor);
            GrosRobot.DebutMatch();
        }

        private void btnPIDGR_Click(object sender, EventArgs e)
        {
            GrosRobot.EnvoyerPID((int)numPGR.Value, (int)numIGR.Value, (int)numDGR.Value);
        }

        private void bnStratTotem_Click(object sender, EventArgs e)
        {
        }

        private void bnStratTotem_Click_1(object sender, EventArgs e)
        {
            GrosRobot.Enchainement = new LignemEnchainement();
            GrosRobot.Enchainement.SetCouleur(pictureBoxCouleur.BackColor);
            GrosRobot.DebutMatch();
        }

        private void btnPRCoeffAsserv_Click(object sender, EventArgs e)
        {
            PetitRobot.EnvoyerPID((int)numPGR.Value, (int)numIGR.Value, (int)numDGR.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GrosRobot.Enchainement = new EvitementEnchainement();
            GrosRobot.Enchainement.SetCouleur(pictureBoxCouleur.BackColor);
            GrosRobot.Enchainement.Executer();
        }

        private void btnHautGauche_Click(object sender, EventArgs e)
        {
            GrosRobot.FermeBrasHautGauche();
            Thread.Sleep(600);
            GrosRobot.OuvreBrasHautGauche();
        }

        private void btnMilieuGauche_Click(object sender, EventArgs e)
        {

            GrosRobot.FermeBrasMilieuGauche();
            Thread.Sleep(500);
            GrosRobot.OuvreBrasMilieuGauche();
        }

        private void btnHautDroite_Click(object sender, EventArgs e)
        {

            GrosRobot.FermeBrasHautDroite();
            Thread.Sleep(600);
            GrosRobot.OuvreBrasHautDroite();
        }

        private void btnMilieuDroite_Click(object sender, EventArgs e)
        {

            GrosRobot.FermeBrasMilieuDroite();
            Thread.Sleep(500);
            GrosRobot.OuvreBrasMilieuDroite();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Config.Save();
        }
    }
}
