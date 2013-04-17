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
                    btnClose.Visible = false;
                }

                Plateau.GrosRobot.Historique.nouvelleAction += new Historique.delegateAction(HistoriqueGR_nouvelleAction);
                PetitRobot.Historique.nouvelleAction += new Historique.delegateAction(HistoriquePR_nouvelleAction);

                panelBalise1.Balise = Plateau.Balise1;
                panelBalise2.Balise = Plateau.Balise2;
                panelBalise3.Balise = Plateau.Balise3;

                // Réglage rouge par défaut
                btnCouleurRouge_Click(null, null);

                Connexions.ConnexionMove.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionMoveCheck_ConnexionChange);
                Connexions.ConnexionIo.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionIoCheck_ConnexionChange);

                panelBalise1.Balise.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBunCheck_ConnexionChange);
                panelBalise2.Balise.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBeuCheck_ConnexionChange);
                panelBalise3.Balise.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionBoiCheck_ConnexionChange);
                PetitRobot.ConnexionCheck.ConnexionChange += new ConnexionCheck.ConnexionChangeDelegate(ConnexionPi_ConnexionChange);

                Connexions.ConnexionMove.ConnexionCheck.Start();
                Connexions.ConnexionIo.ConnexionCheck.Start();
                PetitRobot.ConnexionCheck.Start();
                panelBalise1.Balise.ConnexionCheck.Start();
                panelBalise2.Balise.ConnexionCheck.Start();
                panelBalise3.Balise.ConnexionCheck.Start();
            }
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
            this.Invoke(new EventHandler(delegate
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

            Plateau.Balise1.writer.Close();
            Plateau.Balise2.writer.Close();
            Plateau.Balise3.writer.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCouleurViolet_Click(object sender, EventArgs e)
        {
            //Plateau.GrosRobot.Couleur = Color.Purple;
            //Plateau.GrosRobot.Enchainement.Couleur = Color.Purple;
            pictureBoxCouleur.BackColor = Color.Purple;
            pictureBoxBalises.Image = Properties.Resources.tableViolet;

            panelBalise1.Balise.Position = new Position(new Angle(90, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, -Balise.DISTANCE_LASER_TABLE));
            panelBalise2.Balise.Position = new Position(new Angle(270, AnglyeType.Degre), new PointReel(-Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau + Balise.DISTANCE_LASER_TABLE));
            panelBalise3.Balise.Position = new Position(new Angle(180, AnglyeType.Degre), new PointReel(Plateau.LongueurPlateau + Balise.DISTANCE_LASER_TABLE, Plateau.LargeurPlateau / 2));
        }

        private void btnCouleurRouge_Click(object sender, EventArgs e)
        {
            //Plateau.GrosRobot.Couleur = Color.Red;
            //Plateau.GrosRobot.Enchainement.Couleur = Color.Red;
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
            Plateau.GrosRobot.VitesseDeplacement = 150;
            Plateau.GrosRobot.AccelerationDeplacement = 150;
            Plateau.GrosRobot.VitessePivot = 150;
            Plateau.GrosRobot.AccelerationPivot = 150;

            DateTime debut = DateTime.Now;
            Plateau.GrosRobot.Recallage(SensAR.Arriere);

            Plateau.GrosRobot.Avancer(200);
            Plateau.GrosRobot.PivotGauche(90);
            Plateau.GrosRobot.Recallage(SensAR.Arriere);
            ledRecallage.On();
            Plateau.GrosRobot.ReglerOffsetAsserv((int)(3000 - 110), (int)(2000 - 200 - 110), 180);

            /*Plateau.GrosRobot.VitesseDeplacement = 500;
            Plateau.GrosRobot.AccelerationDeplacement = 1000;
            Plateau.GrosRobot.VitessePivot = 500;
            Plateau.GrosRobot.AccelerationPivot = 1000;*/
            Plateau.GrosRobot.Avancer(300);
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
            Connexions.ConnexionIo.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionTrame);
            Connexions.ConnexionMove.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(ReceptionTrame);

            replay = new Replay();
            Connexions.ConnexionIo.NouvelleTrame += new ConnexionUDP.ReceptionDelegate(replay.AjouterTrameEntrante);
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
            /*GrosRobot.Enchainement = new TestEnchainement();
            GrosRobot.Enchainement.Couleur = pictureBoxCouleur.BackColor;
            GrosRobot.DebutMatch();*/
        }

        private void btnPIDGR_Click(object sender, EventArgs e)
        {
            Plateau.GrosRobot.EnvoyerPID((int)numPGR.Value, (int)numIGR.Value, (int)numDGR.Value);
        }

        private void bnStratTotem_Click(object sender, EventArgs e)
        {
        }

        private void bnStratTotem_Click_1(object sender, EventArgs e)
        {
            /*GrosRobot.Enchainement = new LignemEnchainement();
            GrosRobot.Enchainement.Couleur = pictureBoxCouleur.BackColor;
            GrosRobot.DebutMatch();*/
        }

        private void btnPRCoeffAsserv_Click(object sender, EventArgs e)
        {
            PetitRobot.EnvoyerPID((int)numPGR.Value, (int)numIGR.Value, (int)numDGR.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*GrosRobot.Enchainement = new EvitementEnchainement();
            GrosRobot.Enchainement.Couleur = pictureBoxCouleur.BackColor;
            GrosRobot.Enchainement.Executer();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Config.Save();
        }

        private void FenGoBot_Load(object sender, EventArgs e)
        {

        }

        private void switchBoutonSimu_ChangementEtat(bool actif)
        {
            Plateau.Simulation = actif;
        }
    }
}
