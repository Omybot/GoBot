using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GoBot.Calculs;
using GoBot.Communications;

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
            Connexions.Init();
            Config.Load();
            Robots.Init();
            Plateau.Init();
            Application.Run(new FenGoBot(args));
        }
    }
}
