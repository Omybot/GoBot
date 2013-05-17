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

            for(int i = 0; i < 20; i++)
                ListeMouvementsGros.Add(new MoveGrosBougie(i));
            for (int i = 0; i < 8; i++)
            {
                ListeMouvementsGros.Add(new MoveGrosCadeau(i));
                ListeMouvementsPetit.Add(new MovePetitCadeau(i));
            }
            
            ListeMouvementsPetit.Add(new MovePetitBougie(1));
            ListeMouvementsPetit.Add(new MovePetitBougie(3));
            ListeMouvementsPetit.Add(new MovePetitBougie(5));
            ListeMouvementsPetit.Add(new MovePetitBougie(6));
            ListeMouvementsPetit.Add(new MovePetitBougie(7));
            ListeMouvementsPetit.Add(new MovePetitBougie(9));
            ListeMouvementsPetit.Add(new MovePetitBougie(11));
            ListeMouvementsPetit.Add(new MovePetitBougie(13));
            ListeMouvementsPetit.Add(new MovePetitBougie(15));
            ListeMouvementsPetit.Add(new MovePetitBougie(16));
            ListeMouvementsPetit.Add(new MovePetitBougie(17));
            ListeMouvementsPetit.Add(new MovePetitBougie(19));

            for (int i = 0; i < 10; i++)
            {
                if(i != 0 && i != 4 && i != 5 && i != 9)
                    ListeMouvementsGros.Add(new MoveGrosAccrocheAssiette(i));
                ListeMouvementsGros.Add(new MoveGrosAspireAssiette(i));
            }

            for (int i = 0; i < PositionsMouvements.PositionTirCanon.Count; i++)
            {
                MoveGrosLanceBalles move = new MoveGrosLanceBalles(PositionsMouvements.PositionTirCanon[i]);
                if (i > 1)
                    move.coef = 0.1;
                ListeMouvementsGros.Add(move);
            }
        }

        public void Executer()
        {
            Robots.GrosRobot.Historique.Log("DEBUT DU MATCH", TypeLog.Strat);
            if (Plateau.NotreCouleur == Plateau.CouleurJ1R)
            {
                for (int i = 0; i < 10; i++)
                    Plateau.PoidActions.PoidsGrosBougie[i]++;

                Plateau.PoidActions.PoidsGrosBougie[0] = 200;
            }
            if (Plateau.NotreCouleur == Plateau.CouleurJ2B)
            {
                for (int i = 10; i < 20; i++)
                    Plateau.PoidActions.PoidsGrosBougie[i]++;

                Plateau.PoidActions.PoidsGrosBougie[10] = 200;
            }
            GoBot.IHM.PanelBougies.ContinuerJusquauDebutMatch = false;
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
            timerFinMatch.Stop();
            thGrosRobot.Abort();
            thPetitRobot.Abort();
            Robots.GrosRobot.Stop(StopMode.Freely);
            Thread.Sleep(100);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRAlimentation, false);
            Thread.Sleep(100);
            Robots.GrosRobot.TourneMoteur(MoteurID.GRCanonTMin, 0);
            Thread.Sleep(100);
            Robots.GrosRobot.TourneMoteur(MoteurID.GRTurbineAspirateur, 0);
            Thread.Sleep(100);
            //PetitRobot.Stop(StopMode.Freely);
            Plateau.Balise1.Stop();
            Thread.Sleep(100);
            Plateau.Balise2.Stop();
            Thread.Sleep(100);
            Plateau.Balise3.Stop();
            Thread.Sleep(100);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompe, true);
            Plateau.Score += 12;
            Thread.Sleep(9000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompe, false);
        }

        private void ThreadGros()
        {
            int iMeilleur = 0;

            if (Plateau.Degommage)
            {
                Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasDroit, Config.CurrentConfig.PositionGRBrasDroitSorti);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasGauche, Config.CurrentConfig.PositionGRBrasGaucheSorti);
                Robots.GrosRobot.Avancer(1400);
                if(Plateau.NotreCouleur == Plateau.CouleurJ2B)
                    Robots.GrosRobot.PivotDroite(270);
                else
                    Robots.GrosRobot.PivotGauche(270);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasDroit, Config.CurrentConfig.PositionGRBrasDroitRange);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRBrasGauche, Config.CurrentConfig.PositionGRBrasGaucheRange);
            }

            else
            {
                Robots.GrosRobot.Avancer(600);

            }

            while (ListeMouvementsGros.Count > 0)
            {
                double meilleurCout = double.MaxValue;
                for(int j = 0; j < ListeMouvementsGros.Count; j++)
                {
                    double cout = ListeMouvementsGros[j].Cout;
                    if(meilleurCout > cout)
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
            Robots.PetitRobot.Avancer(150);

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

                if(ListeMouvementsPetit[iMeilleur].Score != 0)
                    ListeMouvementsPetit[iMeilleur].Executer();
            }
        }
    }
}
