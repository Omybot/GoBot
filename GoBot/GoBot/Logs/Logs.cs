using System;
using System.IO;
using System.Windows.Forms;

namespace GoBot.Logs
{
    public static class Logs
    {
        public static ILog LogDebug { get; private set; }
        public static ILog LogConsole { get; private set; }

        static Logs()
        {
            LogDebug = new LogFile(Config.PathData + "/LogsTraces/LogDebug" + Execution.LaunchStartString + ".txt");
            LogConsole = new LogConsole();
        }

        public static void Init()
        {
            try
            {
                if (!Directory.Exists(Config.PathData + "/Logs/"))
                    Directory.CreateDirectory(Config.PathData + "/Logs/");
                if (!Directory.Exists(Config.PathData + "/Configs/"))
                    Directory.CreateDirectory(Config.PathData + "/Configs/");
                if (!Directory.Exists(Config.PathData + "/LogsTraces/"))
                    Directory.CreateDirectory(Config.PathData + "/LogsTraces/");

                Directory.CreateDirectory(Config.PathData + "/Logs/" + Execution.LaunchStartString);
            }
            catch (Exception)
            {
                MessageBox.Show("Problème lors de la création des dossiers de log.\nVérifiez si le dossier n'est pas protégé en écriture.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
