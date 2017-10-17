using System;

namespace GoBot.Logs
{
    public interface ILog
    {
        /// <summary>
        /// Ecrit un message dans le log
        /// </summary>
        /// <param name="message"></param>
        void Write(String message);

        /// <summary>
        /// Ferme le log
        /// </summary>
        void Close();
    }
}
