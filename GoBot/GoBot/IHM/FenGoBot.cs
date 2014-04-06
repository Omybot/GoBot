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
        public static FenGoBot Instance { get; private set; }
        private System.Windows.Forms.Timer timerSauvegarde;

        public FenGoBot(string[] args)
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

                Connexions.ConnexionMove.ConnexionCheck.Start();
                Connexions.ConnexionMiwi.ConnexionCheck.Start();
                Connexions.ConnexionPi.ConnexionCheck.Start();
                
                Connexions.ConnexionMoveCheck_TestConnexion();
                Connexions.ConnexionMiwiCheck_TestConnexion();
                Connexions.ConnexionPiCheck_TestConnexion();

                Plateau.Balise1.ConnexionCheck.Start();
                Plateau.Balise2.ConnexionCheck.Start();
                Plateau.Balise3.ConnexionCheck.Start();

                switchBoutonSimu.SetActif(Robots.Simulation);

                tabPrecedent = new Dictionary<TabPage, TabPage>();
                tabPrecedent.Add(tabControl.TabPages[0], null);
                for(int i = 1; i < tabControl.Controls.Count; i++)
                    tabPrecedent.Add(tabControl.TabPages[i], (tabControl.TabPages[i - 1]));

                IPAddress[] adresses =  Dns.GetHostAddresses(Dns.GetHostName());

                bool ipTrouvee = false;
                foreach (IPAddress ip in adresses)
                {
                    if (ip.ToString().Length > 7)
                    {
                        String ipString = ip.ToString().Substring(0, 7);
                        if (ipString == "10.1.0.")
                            ipTrouvee = true;
                    }
                }

                if (!ipTrouvee)
                    MessageBox.Show("Aucune carte réseau n'est configurée pour se connecter au robot avec la bonne adresse IP (10.1.0.X)", "Configuration IP", MessageBoxButtons.OK, MessageBoxIcon.Information);

                List<String> fichiersElog = new List<string>();
                List<String> fichiersTlog = new List<string>();

                foreach (String chaine in args)
                {
                    if (Path.GetExtension(chaine) == ".elog")
                        fichiersElog.Add(chaine);
                    if (Path.GetExtension(chaine) == ".tlog")
                        fichiersTlog.Add(chaine);
                }

                if (fichiersElog.Count > 0)
                {
                    foreach (String fichier in fichiersElog)
                        panelLogsEvents.ChargerLog(fichier);
                    panelLogsEvents.Afficher();

                    if (fichiersTlog.Count == 0)
                        tabControl.SelectedTab = tabLogsEvent;
                }

                if (fichiersTlog.Count > 0)
                {
                    foreach (String fichier in fichiersTlog)
                        panelLogTrames.ChargerLog(fichier);
                    panelLogTrames.Afficher();

                    tabControl.SelectedTab = tabLogsUdp;
                }

                Instance = this;
            }
        }

        public void ChargerReplay(String fichier)
        {
            if (Path.GetExtension(fichier) == ".tlog")
            {
                panelLogTrames.Clear();
                panelLogTrames.ChargerLog(fichier);
                panelLogTrames.Afficher();
                tabControl.SelectedTab = tabLogsUdp;
            }
            else if (Path.GetExtension(fichier) == ".elog")
            {
                panelLogsEvents.Clear();
                panelLogsEvents.ChargerLog(fichier);
                panelLogsEvents.Afficher();
                tabControl.SelectedTab = tabLogsEvent;
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
            Balise.GetBalise(Carte.RecBun).VitesseRotation(0);
            Balise.GetBalise(Carte.RecBeu).VitesseRotation(0);
            Balise.GetBalise(Carte.RecBoi).VitesseRotation(0);

            Config.Save();
            SauverLogs();

            Robots.Delete();
            Config.Shutdown = true;

            if(Plateau.Enchainement != null)
                Plateau.Enchainement.Stop();
        }

        private void SauverLogs()
        {
            DateTime debut = DateTime.Now;

            Connexions.ConnexionMiwi.Sauvegarde.Sauvegarder(Config.PathData + "/Logs/" + Config.DateLancementString + "/ConnexionMiwi.tlog");
            Connexions.ConnexionMove.Sauvegarde.Sauvegarder(Config.PathData + "/Logs/" + Config.DateLancementString + "/ConnexionMove.tlog");
            Connexions.ConnexionPi.Sauvegarde.Sauvegarder(Config.PathData + "/Logs/" + Config.DateLancementString + "/ConnexionPi.tlog");

            Robots.GrosRobot.Historique.Sauvegarder(Config.PathData + "/Logs/" + Config.DateLancementString + "/ActionsGros.elog");
            Robots.PetitRobot.Historique.Sauvegarder(Config.PathData + "/Logs/" + Config.DateLancementString + "/ActionsPetit.elog");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FenGoBot_FormClosing(null, null);
            Process.Start(Config.PathData + "/KillGoBot.exe");
        }

        private void FenGoBot_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Config.PathData + "/Logs/"))
                    Directory.CreateDirectory(Config.PathData + "/Logs/");

                Directory.CreateDirectory(Config.PathData + "/Logs/" + Config.DateLancementString);
            }
            catch(Exception)
            {
                MessageBox.Show("Problème lors de la création des dossiers de log.\nVérifiez si le dossier n'est pas protégé en écriture.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnPiloteGros_Click(object sender, EventArgs e)
        {
            PanelDeplacement panel = new PanelDeplacement();
            panel.Robot = Robots.GrosRobot;
            Fenetre fen = new Fenetre(panel);
            fen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabControl tab = new TabControl();
            tab.Height = tabControl.Height;
            tab.Width = tabControl.Width;
            tab.TabPages.Add(tabControl.SelectedTab);
            Fenetre fen = new Fenetre(tab);
            fen.Show();
            fen.FormClosing += fen_FormClosing;
        }

        private Dictionary<TabPage, TabPage> tabPrecedent;

        void fen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fenetre fen = (Fenetre)sender;
            TabControl tab = (TabControl)fen.Control;
            TabPage page = tab.TabPages[0];

            TabPage tabPrec = tabPrecedent[page];
            bool trouve = false;
            if(tabPrec == null)
                tabControl.TabPages.Insert(0, page);
            else
            {
                while(!trouve && tabPrec != null)
                {
                    for(int i = 0; i < tabControl.TabPages.Count; i++)
                        if(tabControl.TabPages[i] == tabPrec)
                        {
                            trouve = true;
                            tabControl.TabPages.Insert(i + 1, page);
                            break;
                        }

                    if (!trouve)
                        tabPrec = tabPrecedent[tabPrec];

                    if (tabPrec == null)
                        tabControl.TabPages.Insert(0, page);
                }
            }
        }
    }
}
