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
            //ListeMouvementsGros.Add(new MouvementArbre(1));

            // Foyers coins
            //ListeMouvementsGros.Add(new MouvementDeposeFoyerCoin(0));
            //ListeMouvementsGros.Add(new MouvementDeposeFoyerCoin(1));

            // Lances mammouth
            ListeMouvementsPetit.Add(new MouvementLances());

            // Fresques
            ListeMouvementsPetit.Add(new MouvementFresque());

            // Filet
            ListeMouvementsPetit.Add(new MouvementFilet());

            // Foyer central
            ListeMouvementsGros.Add(new MouvementFoyerCentral());
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
            Robots.GrosRobot.Stop(StopMode.Freely);
            Robots.PetitRobot.Stop(StopMode.Freely);

            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceDroiteBas, 0);
            Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceDroiteHaut, 0);
            Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceGaucheBas, 0);
            Robots.GrosRobot.MoteurPosition(MoteurID.GRPinceGaucheHaut, 0);
            Robots.GrosRobot.MoteurPosition(MoteurID.GRPousseBouchon, 0);
            Robots.GrosRobot.MoteurPosition(MoteurID.GREpauleFeu, 0);
            Servomoteur servo = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRCanonInclinaison, 0);
            servo.CoupleActive = false; 
            servo = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRCanonInclinaison, 0);
            servo.CoupleActive = false; 
            servo = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFeuxCoude, 0);
            servo.CoupleActive = false; 
            servo = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFeuxPoignet, 0);
            servo.CoupleActive = false; 
            servo = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFruitsCoude, 0);
            servo.CoupleActive = false; 
            servo = new Servomoteur(Carte.RecIO, (int)ServomoteurID.GRFruitsEpaule, 0);
            servo.CoupleActive = false;
            servo = new Servomoteur(Carte.RecPi, (int)ServomoteurID.PRBacBouchons, 0);
            servo.CoupleActive = false;
            servo = new Servomoteur(Carte.RecPi, (int)ServomoteurID.PRFresque, 0);
            servo.CoupleActive = false;

            Thread.Sleep(100);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRAlimentation, false);
            Thread.Sleep(100);

            Thread.Sleep(4000);
            thPetitRobot.Abort();

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
