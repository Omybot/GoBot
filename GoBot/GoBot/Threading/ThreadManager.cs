using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace GoBot.Threading
{
    /// <summary>
    /// Gestion de threads supervisés
    /// </summary>
    static class ThreadManager
    {
        #region Fields

        private static List<ThreadLink> _threadsLink;
        private static ThreadLink _linkCleanDeads;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient une copie de la liste des threads actuellements suivis.
        /// </summary>
        public static ReadOnlyCollection<ThreadLink> ThreadsLink
        {
            get
            {
                return new List<ThreadLink>(_threadsLink).AsReadOnly();
            }
        }

        #endregion

        #region Constructors
        
        public static void Init()
        {
            _threadsLink = new List<ThreadLink>();

            _linkCleanDeads = CreateThread(link => CleanDeads());
            _linkCleanDeads.Name = "Nettoyage des threads terminés";
            _linkCleanDeads.StartInfiniteLoop(new TimeSpan(0, 0, 1));
        }

        #endregion

        #region Public methods
        
        /// <summary>
        /// Crée un thread et retourne le lien.
        /// </summary>
        /// <param name="call">Appel à executer par le thread.</param>
        /// <returns>Lien vers le thread créé.</returns>
        public static ThreadLink CreateThread(ThreadLink.CallBack call)
        {
            ThreadLink link = new ThreadLink(call);
            _threadsLink.Add(link);

            return link;
        }

        ///// <summary>
        ///// Lance un thread sur un appel unique.
        ///// </summary>
        ///// <param name="call">Appel à executer.</param>
        ///// <returns>Lien vers le thread d'execution.</returns>
        //public static ThreadLink StartThread(ThreadLink.CallBack call)
        //{
        //    ThreadLink link = new ThreadLink(call);
        //    _threadsLink.Add(link);
        //    link.StartThread();

        //    return link;
        //}

        ///// <summary>
        ///// Lance un thread sur un nombre déterminé d'appels en boucle.
        ///// </summary>
        ///// <param name="call">Appel à executer.</param>
        ///// <param name="interval">Intervalle passif entre chaque appel.</param>
        ///// <param name="executions">Nombre d'executions à effectuer.</param>
        ///// <returns>Lien vers le thread d'execution.</returns>
        //public static ThreadLink StartLoop(ThreadLink.CallBack call, TimeSpan interval, int executions)
        //{
        //    ThreadLink link = new ThreadLink(call);
        //    _threadsLink.Add(link);
        //    link.StartLoop(interval, executions);

        //    return link;
        //}

        ///// <summary>
        ///// Lance un thread sur un nombre indéterminé d'appels en boucle.
        ///// </summary>
        ///// <param name="call">Appel à executer.</param>
        ///// <param name="interval">Intervalle passif entre chaque appel.</param>
        ///// <returns>Lien vers le thread d'execution.</returns>
        //public static ThreadLink StartInfiniteLoop(ThreadLink.CallBack call, TimeSpan interval)
        //{
        //    ThreadLink link = new ThreadLink(call);
        //    _threadsLink.Add(link);
        //    link.StartInfiniteLoop(interval);

        //    return link;
        //}


        /// <summary>
        /// Demande à chaque thread de se couper. L'extinction doit être réalisée par la méthode appellée en testant si le lien vers le thread a été annulé.
        /// Patiente jusqu'à la fin d'execution de tous les threads pendant un certain temps.
        /// Cette durée représente la durée totale d'attente et donc représente la cumul d'attente de fin de chaque thread.
        /// </summary>
        /// <param name="timeout">Nombre de millisecondes maximum à attendre.</param>
        /// <returns>Retourne vrai si tous les threads ont correctement été terminés avant le timeout.</returns>
        public static bool ExitAll(int timeout = 5000)
        {
            _threadsLink.ForEach(t => t.Cancel());

            // Le timeout est global, donc tout le monde doit avoir terminé avant la fin
            Stopwatch sw = Stopwatch.StartNew();
            bool ended = true;

            _threadsLink.ForEach(t => ended = ended && t.WaitEnd((int)Math.Max(0, timeout - sw.ElapsedMilliseconds)));

            return ended;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Permet de supprimer les liens vers les threads terminés depuis un certain temps.
        /// </summary>
        private static void CleanDeads()
        {
            _threadsLink.RemoveAll(t => t.Ended && t.EndDate < (DateTime.Now - new TimeSpan(0, 1, 0)));
        }

        private static void PrintThreads()
        {
            Console.WriteLine("--------------------------------------------");

            foreach (ThreadLink l in ThreadManager.ThreadsLink)
            {
                Console.WriteLine(l.ToString());
            }
        }

        #endregion
    }
}