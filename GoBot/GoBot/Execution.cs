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

        /// <summary>
        /// Obtient ou défini si l'application est en train de se couper
        /// </summary>
        public static bool Shutdown { get; set; } = false;

        /// <summary>
        /// Date de lancement de l'application
        /// </summary>
        public static DateTime LaunchStart { get; set; }

        /// <summary>
        /// Date de lancement de l'application sous format texte triable alphabétiquement
        /// </summary>
        public static String LaunchStartString { get { return Execution.LaunchStart.ToString("yyyy.MM.dd HH\\hmm\\mss\\s"); } }

    }
}
