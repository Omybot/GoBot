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
    }
}
