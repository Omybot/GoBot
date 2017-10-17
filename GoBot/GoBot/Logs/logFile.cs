using System;
using System.IO;

namespace GoBot.Logs
{
    public class LogFile : ILog
    {
        private String FileName { get; set; }
        private StreamWriter Writer { get; set; }

        public LogFile(String fileName)
        {
            FileName = fileName;
            Writer = new StreamWriter(FileName);
            Writer.AutoFlush = true;
        }

        public void Write(String message)
        {
            Writer.WriteLine(DateTime.Now.ToString("dd:MM:yyyy hh:mm:ss:ffff\t") + message);
        }

        public void Close()
        {
            Writer.Close();
        }
    }
}
