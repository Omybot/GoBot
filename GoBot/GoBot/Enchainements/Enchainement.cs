﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using GoBot.Mouvements;
using System.Threading;
using GoBot.Ponderations;
using GoBot.Actionneurs;

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
            //ListeMouvementsGros.Add(new MouvementCube1());

        }

        public void Executer()
        {
            Robots.GrosRobot.Historique.Log("DEBUT DU MATCH", TypeLog.Strat);

            DebutMatch = DateTime.Now;
            timerFinMatch = new System.Timers.Timer();
            timerFinMatch.Elapsed += new ElapsedEventHandler(timerFinMatch_Elapsed);
            timerFinMatch.Interval = DureeMatch.TotalMilliseconds;
            timerFinMatch.Start();

            thGrosRobot = new Thread(ThreadGros);
            thGrosRobot.Start();
        }

        Thread thGrosRobot;

        private void timerFinMatch_Elapsed(object sender, ElapsedEventArgs e)
        {
            Robots.GrosRobot.Historique.Log("FIN DU MATCH", TypeLog.Strat);

            timerFinMatch.Stop();
            thGrosRobot.Abort();
            Robots.GrosRobot.Stop(StopMode.Freely);
            //Robots.PetitRobot.Stop(StopMode.Freely);
            Robots.GrosRobot.MoteurPosition(MoteurID.Balise, 0);
            // TODO eteindre ici les actionneurs du robot
            Thread.Sleep(100);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.Alimentation, false);
            Thread.Sleep(100);

            Thread.Sleep(4000);

            // Todo Couper ici tous les actionneurs à la fin du match et lancer la Funny Action
        }

        protected abstract void ThreadGros();
        
        public void Stop()
        {
            thGrosRobot.Abort();
        }
    }
}
