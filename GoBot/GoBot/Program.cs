using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GoBot
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Config.DesignMode = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Connexions.Init();
            Robots.Init();
            //Robots.GrosRobot.Init();
            PetitRobot.Init();
            Config.Load();
            Plateau.Init();
            Application.Run(new FenGoBot());
        }
    }
}
