using System;
using System.IO;

namespace GoBot.Logs
{
    public class LogConsole : ILog
    {
        public LogConsole()
        {
            Console.WriteLine("Begin of log");
        }

        public void Write(String message)
        {
            Console.WriteLine(DateTime.Now.ToString("dd:MM:yyyy hh:mm:ss:ffff\t") + message);
        }

        public void Close()
        {
            Console.WriteLine("End of log");
        }
    }
}
