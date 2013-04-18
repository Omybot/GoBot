using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace GoBot
{
    public class ConnexionCheck
    {
        private DateTime dernierMessage;
        public bool Connecte { get; private set; }
        private Timer connexionOffTimer;
        private int interval;
        private bool start;

        /// <summary>
        /// Permet de lancer le test de connexion en continu
        /// </summary>
        public ConnexionCheck(int intervalle = 2000)
        {
            dernierMessage = DateTime.Now - new TimeSpan(1, 0, 0);

            start = false;
            interval = intervalle;
            connexionOffTimer = new Timer();
            connexionOffTimer.Interval = 1;
            connexionOffTimer.Elapsed += new ElapsedEventHandler(connexionOffTimer_Elapsed);

            Connecte = false;
        }

        public void Start()
        {
            start = true;
            connexionOffTimer.Start();
        }

        /// <summary>
        /// Fonction appelée à chaque tick du timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connexionOffTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Si on nous a donné une fonction de test de connexion on la réalise pour mettre à jour.
            if (TestConnexion != null)
                TestConnexion();

            MajStatut();
        }

        /// <summary>
        /// Intervalle de vérification de la connexion
        /// </summary>
        public int Intervalle
        {
            get
            {
                return (int)connexionOffTimer.Interval;
            }
            set
            {
                interval = value;
                connexionOffTimer.Interval = value;
            }
        }

        public void MajStatut()
        {
            if (!start)
                return;

            if (Connecte && dernierMessage < DateTime.Now - new TimeSpan(0, 0, 0, 0, (int)(connexionOffTimer.Interval * 1.2)))
            {
                Connecte = false;
                if (ConnexionChange != null)
                    ConnexionChange(false);
            }

            else if (!Connecte && dernierMessage > DateTime.Now - new TimeSpan(0, 0, 0, 0, (int)(connexionOffTimer.Interval * 1.2)))
            {
                Connecte = true;
                if (ConnexionChange != null)
                    ConnexionChange(true);
            }

            connexionOffTimer.Interval = interval;
        }

        /// <summary>
        /// Met à jour la connexion en gardant la date actuelle comme date du dernier message reçu
        /// </summary>
        public void MajConnexion()
        {
            dernierMessage = DateTime.Now;
            MajStatut();
        }

        public delegate void ConnexionChangeDelegate(bool conn);
        public event ConnexionChangeDelegate ConnexionChange;

        public delegate void TestConnexionDelegate();
        /// <summary>
        /// Fonction appelée à chaque tick pour actualiser la connexion. Abonner à cette fonction une fonction qui appelra MajConnexion en cas de retour.
        /// </summary>
        public event TestConnexionDelegate TestConnexion;
    }
}
