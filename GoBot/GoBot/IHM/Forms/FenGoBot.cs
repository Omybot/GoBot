using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GoBot.IHM;
using GoBot.Communications;
using System.IO;
using GoBot.Threading;
using GoBot.Devices;
using GoBot.BoardContext;
using System.Diagnostics;
using Geometry.Shapes;

namespace GoBot
{
    public partial class FenGoBot : Form
    {
        public static FenGoBot Instance { get; private set; }
        private System.Windows.Forms.Timer timerSauvegarde;
        private List<TabPage> _pagesInWindow;

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
                panelGrosRobot.Init();

                if (Screen.PrimaryScreen.Bounds.Width <= pnlMatch.Width)
                {
                    WindowState = FormWindowState.Maximized;
                    FormBorderStyle = FormBorderStyle.None;
                    tabControl.SelectedTab = tabPanda;
                    tabControl.Location = new Point(-12, -34);
                    tabControl.Width += 100;
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                    FormBorderStyle = FormBorderStyle.FixedSingle;
                    btnFenetre.Location = btnClose.Location;
                    btnClose.Visible = false;
                }

                switchBoutonSimu.Value = Robots.Simulation;

                tabPrecedent = new Dictionary<TabPage, TabPage>();
                tabPrecedent.Add(tabControl.TabPages[0], null);
                for (int i = 1; i < tabControl.Controls.Count; i++)
                    tabPrecedent.Add(tabControl.TabPages[i], (tabControl.TabPages[i - 1]));

                List<String> fichiersElog = new List<string>();
                List<String> fichiersTlog = new List<string>();

                foreach (String chaine in args)
                {
                    if (Path.GetExtension(chaine) == ".elog")
                        fichiersElog.Add(chaine);
                    if (Path.GetExtension(chaine) == FramesLog.FileExtension)
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
                        pnlLogFrames.LoadLog(fichier);
                    pnlLogFrames.DisplayLog();

                    tabControl.SelectedTab = tabLogs;
                    tabControlLogs.SelectedTab = tabLogUDP;
                }

                Instance = this;

                GameBoard.MyColor = GameBoard.ColorLeftBlue;
            }

            Connections.StartConnections();

            SplashScreen.SetMessage("Youhou !", Color.Green);
            SplashScreen.CloseSplash();

            pnlPower.StartGraph();

            pnlNumericIO.SetBoard(Board.RecIO);
            pnlNumericMove.SetBoard(Board.RecMove);

            panelTable.StartDisplay();

            _pagesInWindow = new List<TabPage>();

            this.Text = "GoBot 2020 - Beta";
        }

        public void ChargerReplay(String fichier)
        {
            if (Path.GetExtension(fichier) == FramesLog.FileExtension)
            {
                pnlLogFrames.Clear();
                pnlLogFrames.LoadLog(fichier);
                pnlLogFrames.DisplayLog();
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

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Hide();

            if (!ThreadManager.ExitAll())
            {
                Console.WriteLine("Tous les threads ne se sont pas terminés : suicide de l'application.");
                Environment.Exit(0);
            }

            Execution.Shutdown = true;

            Config.Save();
            SauverLogs();

            if (GameBoard.Strategy != null && GameBoard.Strategy.IsRunning)
                GameBoard.Strategy.Stop();

            AllDevices.Close();

            base.OnClosing(e);
        }

        private void SauverLogs()
        {
            DateTime debut = DateTime.Now;

            foreach (Connection conn in Connections.AllConnections)
                conn.Archives.Export(Config.PathData + "/Logs/" + Execution.LaunchStartString + "/" + Connections.GetUDPBoardByConnection(conn).ToString() + FramesLog.FileExtension);

            Robots.MainRobot.Historique.Sauvegarder(Config.PathData + "/Logs/" + Execution.LaunchStartString + "/ActionsGros.elog");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FenGoBot_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void switchBoutonSimu_ValueChanged(object sender, bool value)
        {
            Robots.EnableSimulation(value);
            panelGrosRobot.Init();

            if (value)
                AllDevices.InitSimu();
            else
                AllDevices.Init();

            AllDevices.SetRobotPosition(Robots.MainRobot.Position);
        }

        private void buttonFenetre_Click(object sender, EventArgs e)
        {
            TabControl tab = new TabControl();
            tab.Height = tabControl.Height;
            tab.Width = tabControl.Width;
            _pagesInWindow.Add(tabControl.SelectedTab);
            tab.TabPages.Add(tabControl.SelectedTab);
            Fenetre fen = new Fenetre(tab);
            fen.Show();
            fen.FormClosing += fen_FormClosing;

            EnableTabControl();
        }

        private Dictionary<TabPage, TabPage> tabPrecedent;

        void fen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fenetre fen = (Fenetre)sender;
            TabControl tab = (TabControl)fen.Control;
            TabPage page = tab.TabPages[0];

            _pagesInWindow.Remove(page);

            TabPage tabPrec = tabPrecedent[page];
            bool trouve = false;
            if (tabPrec == null)
                tabControl.TabPages.Insert(0, page);
            else
            {
                while (!trouve && tabPrec != null)
                {
                    for (int i = 0; i < tabControl.TabPages.Count; i++)
                        if (tabControl.TabPages[i] == tabPrec)
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

            EnableTabControl();
        }

        private void tabControlPanda_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableTabControl();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableTabControl();
        }

        private void EnableTabControl()
        {
            bool lidarEnable = false;

            if (tabControl.SelectedTab == tabPanda || _pagesInWindow.Contains(tabPanda))
            {
                if (tabControlPanda.SelectedTab == tabPandaLidar)
                {
                    lidarEnable = true;
                }
            }

            pagePandaLidar.LidarEnable(lidarEnable);
        }
    }
}
