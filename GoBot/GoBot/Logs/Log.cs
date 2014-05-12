using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GoBot.Logs
{
    public class Log
    {
        private String nomFichier;
        private StreamWriter writer;

        public Log(String _nomFichier)
        {
            nomFichier = _nomFichier;
            writer = new StreamWriter(nomFichier);
            writer.AutoFlush = true;
        }

        public void Ecrire(String message)
        {
            writer.WriteLine(DateTime.Now.ToString("dd:MM:yyyy hh:mm:ss:ffff\t") + message);
        }

        public void Fermer()
        {
            writer.Close();
        }
    }
}
