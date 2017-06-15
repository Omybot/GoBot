using System;

namespace GoBot
{
    public class Execution
    {
        /// <summary>
        /// Permet de savoir si l'application est mode Design (concepteur graphique) ou en cours d'execution
        /// Le DesignMode de base :
        ///     - Ne fonctionne pas dans les contructeurs
        ///     - Ne fonctionne pas pour les contrôles imbriqués
        /// </summary>
        public static bool DesignMode { get; set; } = true;
        public static bool Shutdown { get; set; } = false;

        public static DateTime DateLancement { get; set; }
        public static String DateLancementString { get { return Execution.DateLancement.ToString("yyyy.MM.dd hh\\hmm\\mss\\s"); } }

    }
}
