using System;
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
    public class Enchainement
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
        }

        public void Executer()
        {
            Robots.GrosRobot.Historique.Log("DEBUT DU MATCH", TypeLog.Strat);
            if (Plateau.NotreCouleur == Plateau.CouleurJ1Rouge)
            {
                for (int i = 0; i < 10; i++)
                    if (Plateau.PoidActions.PoidsGrosBougie[i] != 0)
                        Plateau.PoidActions.PoidsGrosBougie[i]++;

                Plateau.PoidActions.PoidsGrosBougie[0] = 200;
            }
            if (Plateau.NotreCouleur == Plateau.CouleurJ2Jaune)
            {
                for (int i = 10; i < 20; i++)
                    if (Plateau.PoidActions.PoidsGrosBougie[i] != 0)
                        Plateau.PoidActions.PoidsGrosBougie[i]++;

                Plateau.PoidActions.PoidsGrosBougie[10] = 200;
            }

            DebutMatch = DateTime.Now;
            timerFinMatch = new System.Timers.Timer();
            timerFinMatch.Elapsed += new ElapsedEventHandler(timerFinMatch_Elapsed);
            timerFinMatch.Interval = DureeMatch.TotalMilliseconds;
            timerFinMatch.Start();

            thGrosRobot = new Thread(ThreadGros);
            thGrosRobot.Start();

            /*thPetitRobot = new Thread(ThreadPetit);
            thPetitRobot.Start();*/
        }

        Thread thGrosRobot;
        Thread thPetitRobot;

        private void timerFinMatch_Elapsed(object sender, ElapsedEventArgs e)
        {
            Robots.GrosRobot.Historique.Log("FIN DU MATCH", TypeLog.Strat);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompe, true);
            timerFinMatch.Stop();
            thGrosRobot.Abort();
            //thPetitRobot.Abort();
            Robots.GrosRobot.Stop(StopMode.Freely);
            Thread.Sleep(100);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRAlimentation, false);
            Thread.Sleep(100);

            // Todo Couper ici tous les actionneurs à la fin du match et lancer la Funny Action
        }

        private void ThreadGros()
        {
            int iMeilleur = 0;

            // Todo Ajouter ici les actions fixes avant le lancement de l'IA
            // Exemple : Robots.GrosRobot.Avancer(600);

            while (ListeMouvementsGros.Count > 0)
            {
                double meilleurCout = double.MaxValue;
                for (int j = 0; j < ListeMouvementsGros.Count; j++)
                {
                    double cout = ListeMouvementsGros[j].Cout;
                    if (meilleurCout > cout)
                    {
                        meilleurCout = cout;
                        iMeilleur = j;
                    }
                }

                if (ListeMouvementsGros[iMeilleur].ScorePondere != 0)
                    ListeMouvementsGros[iMeilleur].Executer();
            }
        }

        private void ThreadPetit()
        {
            int iMeilleur = 0;

            // Todo Ajouter ici les actions fixes avant le lancement de l'IA
            // Exemple : Robots.PetitRobot.Avancer(600);

            while (ListeMouvementsPetit.Count > 0)
            {
                double meilleurCout = double.MaxValue;
                for (int j = 0; j < ListeMouvementsPetit.Count; j++)
                {
                    double cout = ListeMouvementsPetit[j].Cout;
                    if (meilleurCout > cout)
                    {
                        meilleurCout = cout;
                        iMeilleur = j;
                    }
                }

                if (ListeMouvementsPetit[iMeilleur].Score != 0)
                    ListeMouvementsPetit[iMeilleur].Executer();
            }
        }
    }
}
