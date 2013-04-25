using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using GoBot.Mouvements;
using System.Threading;

namespace GoBot.Enchainements
{
    public class Enchainement
    {
        static private System.Timers.Timer timerFinMatch;
        public Color Couleur { get; set; }
        public static int DureeMatch { get; set; }

        public List<Mouvement> ListeMouvementsGros = new List<Mouvement>();
        public List<Mouvement> ListeMouvementsPetit = new List<Mouvement>();

        public Enchainement()
        {
            DureeMatch = 90000;
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
        }

        public void Executer()
        {
            timerFinMatch = new System.Timers.Timer();
            timerFinMatch.Elapsed += new ElapsedEventHandler(timerFinMatch_Elapsed);
            timerFinMatch.Interval = DureeMatch;
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
            Robots.GrosRobot.Stop(StopMode.Freely);
            Robots.GrosRobot.CoupureAlim();
            //PetitRobot.Stop(StopMode.Freely);
            Plateau.Balise1.ReglageVitesse = false;
            Plateau.Balise2.ReglageVitesse = false;
            Plateau.Balise3.ReglageVitesse = false;
            Plateau.Balise1.VitesseRotation(0);
            Plateau.Balise2.VitesseRotation(0);
            Plateau.Balise3.VitesseRotation(0);
            timerFinMatch.Stop();
        }

        private void ThreadGros()
        {
            int iMeilleur = 0;

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

                if (ListeMouvementsGros[iMeilleur].Score != 0)
                    ListeMouvementsGros[iMeilleur].Executer();
            }
        }

        private void ThreadPetit()
        {
            int iMeilleur = 0;

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
