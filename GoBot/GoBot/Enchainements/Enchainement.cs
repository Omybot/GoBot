﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using GoBot.Mouvements;
using System.Threading;
using GoBot.Ponderations;

namespace GoBot.Enchainements
{
    public abstract class Enchainement
    {
        static private System.Timers.Timer timerFinMatch;
        public Color Couleur { get; set; }
        public static TimeSpan DureeMatch { get; set; }

        public DateTime DebutMatch { get; set; }
        public TimeSpan TempsRestant
        {
            get
            {
                return (DebutMatch + DureeMatch) - DateTime.Now;
            }
        }

        public List<Mouvement> ListeMouvementsGros = new List<Mouvement>();
        public List<Mouvement> ListeMouvementsPetit = new List<Mouvement>();

        static Enchainement()
        {
            DureeMatch = new TimeSpan(0, 0, 90);
        }

        public Enchainement()
        {
            Plateau.PoidActions = new PoidsTest();
            Couleur = Color.Purple;

            // Todo Charger dans les listes ListeMouvementsGros et ListeMouvementsPetit les mouvements possibles

            // Attrapage feux en bordure
            ListeMouvementsGros.Add(new MouvementFeuBordure(15));
            ListeMouvementsGros.Add(new MouvementFeuBordure(8));
            ListeMouvementsGros.Add(new MouvementFeuBordure(7));
            ListeMouvementsGros.Add(new MouvementFeuBordure(0));

            // Vidage des torches
            ListeMouvementsGros.Add(new MouvementTorche(0));
            ListeMouvementsGros.Add(new MouvementTorche(1));

            // Arbres
            ListeMouvementsGros.Add(new MouvementArbre(1));

            // Foyers coins
            ListeMouvementsGros.Add(new MouvementDeposeFoyerCoin(0));
            ListeMouvementsGros.Add(new MouvementDeposeFoyerCoin(1));

            // Lances mammouth
            ListeMouvementsPetit.Add(new MouvementLances(1));
            ListeMouvementsPetit.Add(new MouvementLances(2));
        }

        public void Executer()
        {
            Robots.GrosRobot.Historique.Log("DEBUT DU MATCH", TypeLog.Strat);
            Robots.PetitRobot.Historique.Log("DEBUT DU MATCH", TypeLog.Strat);

            DebutMatch = DateTime.Now;
            timerFinMatch = new System.Timers.Timer();
            timerFinMatch.Elapsed += new ElapsedEventHandler(timerFinMatch_Elapsed);
            timerFinMatch.Interval = DureeMatch.TotalMilliseconds;
            timerFinMatch.Start();

            thGrosRobot = new Thread(ThreadGros);
            thGrosRobot.Start();

            thPetitRobot = new Thread(ThreadPetit);
            thPetitRobot.Start();
        }

        Thread thGrosRobot;
        Thread thPetitRobot;

        private void timerFinMatch_Elapsed(object sender, ElapsedEventArgs e)
        {
            Robots.GrosRobot.Historique.Log("FIN DU MATCH", TypeLog.Strat);
            Robots.PetitRobot.Historique.Log("FIN DU MATCH", TypeLog.Strat);

            timerFinMatch.Stop();
            thGrosRobot.Abort();
            thPetitRobot.Abort();
            Robots.GrosRobot.Stop(StopMode.Freely);
            Robots.PetitRobot.Stop(StopMode.Freely);

            Thread.Sleep(100);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRAlimentation, false);
            Thread.Sleep(100);

            // Todo Couper ici tous les actionneurs à la fin du match et lancer la Funny Action
        }

        protected abstract void ThreadGros();

        protected abstract void ThreadPetit();

        public void Stop()
        {
            thGrosRobot.Abort();
            thPetitRobot.Abort();
        }
    }
}
