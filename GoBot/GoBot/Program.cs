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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GrosRobot.Init();
            PetitRobot.Init();
            Config.Load();
            Plateau.Init();
            Application.Run(new FenGoBot());
        }
    }
}
