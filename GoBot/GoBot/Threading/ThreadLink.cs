using System;
using System.Diagnostics;
using System.Threading;

namespace GoBot.Threading
{
    /// <summary>
    /// Lien vers un thread d'execution supervisé. Permet de suivre l'état de son execution et de demander son extinction.
    /// </summary>
    public class ThreadLink
    {
        #region Delegates

        public delegate void CallBack(ThreadLink link);

        #endregion

        #region Fields

        private static int _idCounter = 0;

        private int _id;
        private String _name;
        private DateTime _startDate;
        private DateTime _endDate;

        private bool _started;
        private bool _cancelled;
        private bool _ended;

        private bool _loopPaused;
        private int _loopsCount;
        private int _loopsTarget;

        private Thread _innerThread;
        private CallBack _innerCallback;

        private Semaphore _loopLock;

        #endregion

        #region Properties

        /// <summary>
        /// Numéro d'identification.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Nom de la fonction executée ou appelante.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Retourne vrai si le trhead a été lancé.
        /// </summary>
        public bool Started
        {
            get
            {
                return _started;
            }

            private set
            {
                _started = value;
            }
        }

        /// <summary>
        /// Retourne la date de lancement du thread.
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }

            private set
            {
                _startDate = value;
            }
        }

        /// <summary>
        /// Retourne vrai si le thread a terminé son execution.
        /// </summary>
        public bool Ended
        {
            get
            {
                return _ended;
            }

            private set
            {
                _ended = value;
            }
        }

        /// <summary>
        /// Retourne la date de fin d'execution.
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }

            private set
            {
                _endDate = value;
            }
        }

        /// <summary>
        /// Retourne la durée d'execution jusqu'à la date actuelle, ou la date de fin si le thread est déjà terminé.
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                TimeSpan output;

                if (!Started)
                    output = new TimeSpan();
                else if (!Ended)
                    output = DateTime.Now - StartDate;
                else
                    output = EndDate - StartDate;

                return output;
            }
        }

        /// <summary>
        /// Retourne vrai si le thread est lancé et non terminé.
        /// </summary>
        public bool Running
        {
            get
            {
                return Started && !Cancelled && !Ended;
            }
        }

        /// <summary>
        /// Retourne vrai si l'annulation du thread a été demandée.
        /// </summary>
        public bool Cancelled
        {
            get
            {
                return _cancelled;
            }

            private set
            {
                _cancelled = value;
            }
        }

        /// <summary>
        /// Retourne vrai si la boucle d'execution est en pause.
        /// </summary>
        public bool LoopPaused
        {
            get
            {
                return _loopPaused;
            }

            private set
            {
                _loopPaused = value;
            }
        }

        /// <summary>
        /// Obtient ou définit le nombre d'execution de la boucle de thread qui ont déjà été effectuées.
        /// </summary>
        public int LoopsCount
        {
            get
            {
                return _loopsCount;
            }

            set
            {
                _loopsCount = value;
            }
        }

        /// <summary>
        /// Obtient le nombre d'executions attendues de la boucle (0 si pas de limite)
        /// </summary>
        public int LoopsTarget
        {
            get
            {
                return _loopsTarget;
            }

            private set
            {
                _loopsTarget = value;
            }
        }

        #endregion

        #region Constructors
        
        public ThreadLink(CallBack call)
        {
            _innerCallback = call;
            _id = _idCounter++;
            _name = "Started by " + GetCaller(2);
            
            _cancelled = false;
            _started = false;
            _ended = false;

            _loopLock = null;
            _loopPaused = false;
            _loopsCount = 0;
            _loopsTarget = 0;
            
            _loopLock = null;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Lance le thread sur une execution unique.
        /// </summary>
        public void StartThread()
        {
            _innerThread = new Thread(f => ThreadCall(_innerCallback));
            _innerThread.IsBackground = true;
            _innerThread.Start();
        }

        /// <summary>
        /// Lance le thread sur une execution à intervalle régulier pour un certain nombre de fois.
        /// </summary>
        /// <param name="interval">Intervalle entre les executions. (De la fin d'une execution au début de la suivante)</param>
        /// <param name="executions">Nombre total d'executions attendues.</param>
        public void StartLoop(TimeSpan interval, int executions)
        {
            _loopsTarget = executions;
            _innerThread = new Thread(f => ThreadLoop(interval, executions));
            _innerThread.IsBackground = true;
            _innerThread.Start();
        }

        /// <summary>
        /// Lance le thread sur une execution à intervalle régulier pour un nombre illimité de fois.
        /// </summary>
        /// <param name="interval">Intervalle entre les executions. (De la fin d'une execution au début de la suivante)</param>
        public void StartInfiniteLoop(TimeSpan interval)
        {
            _innerThread = new Thread(f => ThreadInfiniteLoop(interval));
            _innerThread.IsBackground = true;
            _innerThread.Start();
        }

        /// <summary>
        /// Demande l'annulation de l'execution du thread. La fonction appellée doit tester la propriété Cancelled pour interrompre volontairement son execution.
        /// </summary>
        public void Cancel()
        {
            _cancelled = true;
        }

        /// <summary>
        /// Enregistre la classe et le nom de la fonction appellante comme nom du thread.
        /// </summary>
        public void RegisterName()
        {
            _name = GetCaller();
        }

        /// <summary>
        /// Met en pause la boucle d'execution du thread à la fin de l'itératino actuelle.
        /// </summary>
        public void PauseLoop()
        {
            _loopPaused = true;
            _loopLock = new Semaphore(0, int.MaxValue);
        }

        /// <summary>
        /// Reprends l'execution de la boucle après sa mise en pause.
        /// </summary>
        public void ResumeLoop()
        {
            _loopPaused = false;
            _loopLock?.Release();
        }

        /// <summary>
        /// Attend la fin de l'execution du thread sans bloquer le thread principal.
        /// </summary>
        /// <param name="timeout">Nombre de millisecondes avant l'abandon de l'attente de fin.</param>
        /// <returns>Retourne vrai si le thread s'est terminé avant le timeout.</returns>
        public bool WaitEnd(int timeout = 2000)
        {
            Stopwatch sw = Stopwatch.StartNew();

            // Si jamais la boucle était en pause il faut la libérer pour qu'elle puisse se terminer.
            _loopLock?.Release();

            // Pompage des messages windows parce que si on attend sur le thread principal une invocation du thread principal c'est un deadlock...
            while (sw.ElapsedMilliseconds < timeout && !_innerThread.Join(10))
                System.Windows.Forms.Application.DoEvents();

            return sw.ElapsedMilliseconds < timeout;
        }

        /// <summary>
        /// Tente de tuer le thread immédiatement sans précautions. Les appels à Kill doivent être évités au maximum et l'utilisation de Cancel avec gestion de l'annulation doit être privilégiée.
        /// </summary>
        public void Kill()
        {
            this.Cancel();
            _innerThread.Abort();
        }

        #endregion

        #region Private methods

        private void ThreadCall(CallBack call)
        {
            _startDate = DateTime.Now;
            _started = true;

            call.Invoke(this);

            _ended = true;
            _endDate = DateTime.Now;
        }


        private void ThreadLoop(TimeSpan interval, int executions)
        {
            _startDate = DateTime.Now;
            _started = true;

            while (!_cancelled && _loopsCount < executions)
            {
                _loopLock?.WaitOne();
                _loopLock = null;

                _loopsCount++;
                _innerCallback.Invoke(this);
                Thread.Sleep(interval);
            }

            _ended = true;
            _endDate = DateTime.Now;
        }

        private void ThreadInfiniteLoop(TimeSpan interval)
        {
            _startDate = DateTime.Now;
            _started = true;

            while (!this.Cancelled)
            {
                _loopLock?.WaitOne();
                _loopLock = null;

                _loopsCount++;
                _innerCallback.Invoke(this);

                if(interval.TotalMilliseconds > 15)
                    Thread.Sleep(interval);
                else
                {
                    Stopwatch chrono = Stopwatch.StartNew();
                    while (chrono.Elapsed < interval) ;
                }
            }

            _ended = true;
            _endDate = DateTime.Now;
        }

        private static String GetCaller(int floors = 1)
        {
            StackFrame stack = new StackTrace().GetFrame(1 + floors);

            return stack.GetMethod().DeclaringType.Name + "." + stack.GetMethod().Name;
        }

        #endregion

        #region Type modifications

        public override string ToString()
        {
            String output = "Thread " + _id.ToString() + " \"" + _name + "\"";

            if (Started)
            {
                output += ", started at " + _startDate.ToLongTimeString();
                if (_cancelled)
                    output += ", cancelled";
                else if (_ended)
                    output += ", ended at " + _endDate.ToLongTimeString();

                if (_loopsCount > 0)
                    output += ", " + _loopsCount.ToString() + " loops";

                output += " (" + Duration.ToString(@"hh\:mm\:ss") + ")";
            }
            else
                output += ", not started.";

            return output;
        }

        #endregion
    }
}
