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

        /// <summary>
        /// Anti scintillement
        /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}

        public FenGoBot(string[] args)
        {
            InitializeComponent();
            timerSauvegarde = new System.Windows.Forms.Timer();
            timerSauvegarde.Interval = 10000;
            timerSauvegarde.Tick += timerSauvegarde_Tick;
            timerSauvegarde.Start();

            if (!Execution.DesignMode)
            {
                CheckForIllegalCrossThreadCalls = false;
                panelGrosRobot.Init();

                if (Screen.PrimaryScreen.Bounds.Width == 1024)
                {
                    WindowState = FormWindowState.Maximized;
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    btnFenetre.Location = btnClose.Location;
                    btnClose.Visible = false;
                }

                switchBoutonSimu.Value = Robots.Simulation;

                tabPrecedent = new Dictionary<TabPage, TabPage>();
                tabPrecedent.Add(tabControl.TabPages[0], null);
                for(int i = 1; i < tabControl.Controls.Count; i++)
                    tabPrecedent.Add(tabControl.TabPages[i], (tabControl.TabPages[i - 1]));

                List<String> fichiersElog = new List<string>();
                List<String> fichiersTlog = new List<string>();

                foreach (String chaine in args)
                {
                    if (Path.GetExtension(chaine) == ".elog")
                        fichiersElog.Add(chaine);
                    if (Path.GetExtension(chaine) == ConnectionReplay.FileExtension)
                        fichiersTlog.Add(chaine);
                }

                if (fichiersElog.Count > 0)
                {
                    foreach (String fichier in fichiersElog)
                        panelLogsEvents.ChargerLog(fichier);
                    panelLogsEvents.Afficher();

                    if (fichiersTlog.Count == 0)
                    {
                        tabControl.SelectedTab = tabLogs;
                        tabControlLogs.SelectedTab = tabLogEvent;
                    }
                }

                if (fichiersTlog.Count > 0)
                {
                    foreach (String fichier in fichiersTlog)
                        panelLogTrames.ChargerLog(fichier);
                    panelLogTrames.Afficher();

                    tabControl.SelectedTab = tabLogs;
                    tabControlLogs.SelectedTab = tabLogUDP;
                }

                Instance = this;

                Plateau.NotreCouleur = Plateau.CouleurGaucheBleu;
                
                Connections.ConnectionIO.SendMessage(FrameFactory.DemandeCouleurEquipe());

                panelBalise.Balise = Plateau.Balise;
                panelBaliseDiagnostic.Balise = Plateau.Balise;
            }

            SplashScreen.CloseSplash();

#if DEBUG
            TestCode.VerificationEnums();
#endif
        }

        public void ChargerReplay(String fichier)
        {
            if (Path.GetExtension(fichier) == ConnectionReplay.FileExtension)
            {
                panelLogTrames.Clear();
                panelLogTrames.ChargerLog(fichier);
                panelLogTrames.Afficher();
                tabControl.SelectedTab = tabLogs;
                tabControlLogs.SelectedTab = tabLogUDP;
            }
            else if (Path.GetExtension(fichier) == ".elog")
            {
                panelLogsEvents.Clear();
                panelLogsEvents.ChargerLog(fichier);
                panelLogsEvents.Afficher();
                tabControl.SelectedTab = tabLogs;
                tabControlLogs.SelectedTab = tabLogEvent;
            }
        }

        void timerSauvegarde_Tick(object sender, EventArgs e)
        {
            SauverLogs();
        }

        private void FenGoBot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Plateau.Balise.Stop();
            panelCamera.ContinuerCamera = false;
            Config.Save();
            SauverLogs();

            Robots.Delete();
            Execution.Shutdown = true;

            if(Plateau.Enchainement != null)
                Plateau.Enchainement.Stop();

            Process[] proc = Process.GetProcessesByName("GoBot");
            foreach(Process p in proc)
                p.Kill();
        }

        private void SauverLogs()
        {
            DateTime debut = DateTime.Now;

            foreach (Connection conn in Connections.AllConnections)
                conn.Archives.Export(Config.PathData + "/Logs/" + Execution.DateLancementString + "/" + Connections.GetBoardByConnection(conn).ToString() + ConnectionReplay.FileExtension);
            
            Robots.GrosRobot.Historique.Sauvegarder(Config.PathData + "/Logs/" + Execution.DateLancementString + "/ActionsGros.elog");
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
                if (!Directory.Exists(Config.PathData + "/Configs/"))
                    Directory.CreateDirectory(Config.PathData + "/Configs/");
                if (!Directory.Exists(Config.PathData + "/LogsTraces/"))
                    Directory.CreateDirectory(Config.PathData + "/LogsTraces/");

                Directory.CreateDirectory(Config.PathData + "/Logs/" + Execution.DateLancementString);

                panelAnalogiqueMove.Carte = Board.RecMove;
                panelAnalogiqueIO.Carte = Board.RecIO;
                panelAnalogiqueGB.Carte = Board.RecGB;

            }
            catch(Exception)
            {
                MessageBox.Show("Problème lors de la création des dossiers de log.\nVérifiez si le dossier n'est pas protégé en écriture.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void switchBoutonSimu_ValueChanged(object sender, bool value)
        {
            Robots.Simuler(value);
            panelGrosRobot.Init();
            // todo
            //Robots.GrosRobot.Historique.NouvelleAction += new Historique.DelegateAction(HistoriqueGR_nouvelleAction);
            //Robots.PetitRobot.Historique.NouvelleAction += new Historique.DelegateAction(HistoriquePR_nouvelleAction);
        }

        private void buttonFenetre_Click(object sender, EventArgs e)
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
