using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GoBot.Calculs;
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
            Config.DesignMode = false;
            Config.DateLancement = DateTime.Now;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreen.ShowSplash();
            Process [] proc = Process.GetProcessesByName("GoBot");
            if (proc.Length > 1)
            {
                SplashScreen.SetMessage("GoBot est déjà lancé...", Color.Red);
                Thread.Sleep(1000);
                return;
            }

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
            catch(Exception)
            {
                derniereVersion = versionCourante;
                SplashScreen.SetMessage("Impossible de mettre\nà jour...", Color.Red);
                Thread.Sleep(1000);
            }

            bool lancement = true;
            if (versionCourante != derniereVersion)
            {
                lancement = false;
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
                }
                catch (Exception)
                {
                    SplashScreen.SetMessage("Erreur !" + Environment.NewLine + " Mise à jour échouée", Color.Red);
                    Thread.Sleep(2000);
                    lancement = true;
                }
            }

            if(lancement)
            {
                SplashScreen.SetMessage("Initialisation...", Color.Black);

                Connexions.Init();
                Config.Load();
                Robots.Init();
                Plateau.Init();


                IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());

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
                {
                    SplashScreen.SetMessage("Attention !\nIP non configurée...", Color.Red);
                    Thread.Sleep(1000);
                }

                Application.Run(new FenGoBot(args));
            }
        }
    }
}
