using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Logs
{
    public static class Logs
    {
        public static Log LogDebug { get; private set; }
        static Logs()
        {
            LogDebug = new Log(Config.PathData + "/LogsTraces/LogDebug.txt");
        }
    }
}
