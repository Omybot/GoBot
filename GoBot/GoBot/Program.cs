using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GoBot.Geometry;
using GoBot.Communications;
using GoBot.IHM;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace GoBot
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Execution.DesignMode = false;
            Execution.LaunchStart = DateTime.Now;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreen.ShowSplash();

            CheckAlreadyLaunched();
            Update();
            CheckIP();

            SplashScreen.SetMessage("Initialisation :\nConnexions...", Color.Black);
            Connections.Init();

            SplashScreen.SetMessage("Initialisation :\nConfig...", Color.Black);
            Config.Load();

            SplashScreen.SetMessage("Initialisation :\nDevices...", Color.Black);
            Devices.Devices.Init();

            SplashScreen.SetMessage("Initialisation :\nRobot...", Color.Black);
            Robots.Init();

            SplashScreen.SetMessage("Initialisation :\nPlateau...", Color.Black);
            Plateau.Init();

            SplashScreen.SetMessage("Initialisation :\nLogs...", Color.Black);
            Logs.Logs.Init();

            SplashScreen.SetMessage("Initialisation :\nInterface...", Color.Black);

            Application.Run(new FenGoBot(args));
        }

        static void CheckIP()
        {
            if(!Dns.GetHostAddresses(Dns.GetHostName()).ToList().Exists(ip => ip.ToString().StartsWith("10.1.0.")))
            {
                SplashScreen.SetMessage("Attention !\nIP non configurée...", Color.Red);
                Thread.Sleep(1000);
            }
        }

        static void CheckAlreadyLaunched()
        {
            Process[] proc = Process.GetProcessesByName("GoBot");
            if (proc.Length > 1)
            {
                // On attend pour vérifier qu'il s'en va pas l'autre
                Thread.Sleep(1000);
                proc = Process.GetProcessesByName("GoBot");

                if (proc.Length > 1)
                {
                    SplashScreen.SetMessage("GoBot est déjà lancé...", Color.Red);
                    Thread.Sleep(1000);
                    return;
                }
            }
        }

        static void Update()
        {
            // Pas d'update automatique si on est dans l'IDE ou si le fichier NoUpdate existe à coté de l'exe
            if (!Debugger.IsAttached)
            {
                String noUpdateFile = Application.StartupPath + "\\NoUpdate";
                if (!File.Exists(noUpdateFile))
                {
                    SplashScreen.SetMessage("GoBot recherche\ndes mises à jour...", Color.Black);
                    String versionCourante = Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf('.'));
                    String derniereVersion;

                    try
                    {
                        HttpWebRequest r = (HttpWebRequest)WebRequest.Create("http://www.omybot.com/GoBot/version.txt");
                        HttpWebResponse rep = (HttpWebResponse)r.GetResponse();
                        StreamReader sr = new StreamReader(rep.GetResponseStream());
                        derniereVersion = sr.ReadLine();
                        sr.Close();
                    }
                    catch (Exception)
                    {
                        derniereVersion = versionCourante;
                        SplashScreen.SetMessage("Impossible de mettre\nà jour...", Color.Red);
                        Thread.Sleep(1000);
                    }

                    if (versionCourante != derniereVersion)
                    {
                        SplashScreen.SetMessage("Une nouvelle version\n est disponible.", Color.Green);
                        Thread.Sleep(1000);
                        SplashScreen.SetMessage("Téléchargement de la\n dernière version...", Color.FromArgb(50, 50, 50));

                        WebClient wc = new WebClient();
                        String setup = System.IO.Path.GetTempPath() + "SetupGoBot.exe";

                        try
                        {
                            wc.DownloadFile("http://www.omybot.com/GoBot/SetupGoBot.exe", System.IO.Path.GetTempPath() + "SetupGoBot.exe");

                            SplashScreen.SetMessage("GoBot va se relancer...", Color.FromArgb(50, 50, 50));
                            Thread.Sleep(1000);
                            System.Diagnostics.ProcessStartInfo myInfo = new System.Diagnostics.ProcessStartInfo();
                            myInfo.FileName = setup;
                            myInfo.Arguments = "/SP- /VERYSILENT";
                            System.Diagnostics.Process.Start(myInfo);
                            Application.Exit();
                        }
                        catch (Exception)
                        {
                            SplashScreen.SetMessage("Erreur !" + Environment.NewLine + " Mise à jour échouée", Color.Red);
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
        }
    }
}
