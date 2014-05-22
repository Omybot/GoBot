﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace GoBot.Communications
{
    public class ConnexionCheck
    {
        private DateTime derniereReception;
        private DateTime dernierTest;
        public bool Connecte { get; private set; }
        private Timer connexionOffTimer;
        private int interval;
        private bool start;

        /// <summary>
        /// Permet de lancer le test de connexion en continu
        /// </summary>
        public ConnexionCheck(int intervalle = 2000)
        {
            derniereReception = DateTime.Now - new TimeSpan(0, 1, 0);
            dernierTest = DateTime.Now;

            start = false;
            interval = intervalle;
            connexionOffTimer = new Timer();
            connexionOffTimer.Interval = intervalle;
            connexionOffTimer.Elapsed += new ElapsedEventHandler(connexionOffTimer_Elapsed);

            Connecte = false;
        }

        public void Start()
        {
            start = true;
            connexionOffTimer_Elapsed(null, null);
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

            TimeSpan intervalleAutorise = new TimeSpan(0, 0, 0, 0, (int)(connexionOffTimer.Interval * 0.5));
            TimeSpan intervalleEcoule = dernierTest - derniereReception;

            if (Connecte && intervalleEcoule > intervalleAutorise)
            {
                Connecte = false;
                if (ConnexionChange != null)
                    ConnexionChange(false);
            }

            else if (!Connecte && intervalleEcoule < intervalleAutorise)
            {
                Console.WriteLine("Connection");
                Connecte = true;
                if (ConnexionChange != null)
                    ConnexionChange(true);
            }

            dernierTest = DateTime.Now;
        }

        /// <summary>
        /// Met à jour la connexion en gardant la date actuelle comme date du dernier message reçu
        /// </summary>
        public void MajConnexion()
        {
            derniereReception = DateTime.Now;
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
