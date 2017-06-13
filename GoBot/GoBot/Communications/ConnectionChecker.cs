using System;
using System.Timers;

namespace GoBot.Communications
{
    public class ConnectionChecker
    {
        /// <summary>
        /// Date de la dernière notification de connexion établie
        /// </summary>
        protected DateTime LastAliveDate { get; set; }
        /// <summary>
        /// Date du dernier envoi de test de connexion
        /// </summary>
        protected DateTime LastTestDate { get; set; }
        /// <summary>
        /// Timer qui envoie les tests de connexion et vérifie l'état de la connexion
        /// </summary>
        protected Timer CheckTimer { get; set; }

        /// <summary>
        /// Vrai si le timer de vérification est lancé
        /// </summary>
        public bool Started { get; protected set; }
        /// <summary>
        /// Connexion surveillée
        /// </summary>
        public Connection AttachedConnection { get; protected set; }
        /// <summary>
        /// Vrai si la connexion est actuellement établie
        /// </summary>
        public bool Connected { get; protected set; }

        /// <summary>
        /// Intervalle de vérification de la connexion
        /// </summary>
        public int Interval
        {
            get { return (int)CheckTimer.Interval; }
            set { CheckTimer.Interval = value; }
        }

        public delegate void ConnectionChangeDelegate(Connection sender, bool connected);
        /// <summary>
        /// Event appelé quand la connexion est trouvée ou perdue.
        /// </summary>
        public event ConnectionChangeDelegate ConnectionStatusChange;

        public delegate void SendConnectionTestDelegate(Connection sender);
        /// <summary>
        /// Event appelé à chaque tick pour actualiser la connexion. Abonner à cet event une fonction qui aura pour conséquence un appel à NotifyAlive si la connexion est établie.
        /// </summary>
        public event SendConnectionTestDelegate SendConnectionTest;
        
        /// <summary>
        /// Crée un ConnectionChecker en spécifiant la connexion surveillée et l'intervalle entre chaque vérification.
        /// </summary>
        public ConnectionChecker(Connection conn, int interval = 2000)
        {
            AttachedConnection = conn;
            LastAliveDate = DateTime.Now - new TimeSpan(0, 1, 0);
            LastTestDate = DateTime.Now;

            Started = false;

            CheckTimer = new Timer();
            CheckTimer.Interval = interval;
            CheckTimer.Elapsed += new ElapsedEventHandler(CheckTimer_Elapsed);

            Connected = false;
        }

        /// <summary>
        /// Démarre la surveillance.
        /// </summary>
        public void Start()
        {
            Started = true;
            CheckConnection();
            CheckTimer.Start();
        }

        /// <summary>
        /// Permet d'effectuer une vérification de la connexion en mettant à jour par rapport au dernier test de connexion puis en en envoyant un nouveau.
        /// Cette fonction est appelée périodiquement par le timer et peut également être appelée manuellement.
        /// </summary>
        public void CheckConnection()
        {
            UpdateStatus();
            SendConnectionTest?.Invoke(AttachedConnection);
        }

        /// <summary>
        /// Mets à jour l'état de la connexion en fonction du dernier test effectué et de la dernière notification de retour reçue.
        /// </summary>
        public void UpdateStatus()
        {
            TimeSpan authorizedDelay = new TimeSpan(0, 0, 0, 0, (int)(CheckTimer.Interval * 0.5));
            TimeSpan effectiveDelay = LastTestDate - LastAliveDate;

            if (Connected && effectiveDelay > authorizedDelay)
            {
                Connected = false;
                ConnectionStatusChange?.Invoke(AttachedConnection, Connected);
            }

            else if (!Connected && effectiveDelay < authorizedDelay)
            {
                Connected = true;
                ConnectionStatusChange?.Invoke(AttachedConnection, Connected);
            }

            LastTestDate = DateTime.Now;
        }

        /// <summary>
        /// Spécifie que la connexion est bien établie à la date actuelle.
        /// </summary>
        public void NotifyAlive()
        {
            LastAliveDate = DateTime.Now;
            UpdateStatus();
        }

        /// <summary>
        /// Fonction appelée à chaque tick du timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckConnection();
        }
    }
}
