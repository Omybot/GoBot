using System;
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

        public bool Started { get; private set; }

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
            Started = false;
            Plateau.PoidActions = new PoidsTest();
            Couleur = Color.Purple;

            // Todo Charger dans les listes ListeMouvementsGros et ListeMouvementsPetit les mouvements possibles

            for (int i = 0; i < Plateau.Elements.Fusees.Count; i++)
                ListeMouvementsGros.Add(new MouvementFusee(i));

            for (int i = 0; i < Plateau.Elements.Modules.Count; i++)
            {
                if (PositionsMouvements.PositionsApprocheModuleFace[i] != null)
                    ListeMouvementsGros.Add(new MouvementModuleAvant(i));
                //if (PositionsMouvements.PositionsApprocheModuleGauche[i] != null)
                //    ListeMouvementsGros.Add(new MouvementModuleGauche(i));
                //if (PositionsMouvements.PositionsApprocheModuleDroite[i] != null)
                //    ListeMouvementsGros.Add(new MouvementModuleDroite(i));
            }

            for (int i = 0; i < Plateau.Elements.ZonesDepose.Count; i++)
                ListeMouvementsGros.Add(new MouvementDeposeModules(i));
        }

        public void Executer()
        {
            Started = true;

            Robots.GrosRobot.Historique.Log("DEBUT DU MATCH", TypeLog.Strat);

            DebutMatch = DateTime.Now;
            timerFinMatch = new System.Timers.Timer();
            timerFinMatch.Elapsed += new ElapsedEventHandler(timerFinMatch_Elapsed);
//#if DEBUG
//           timerFinMatch.Interval = DureeMatch.TotalMilliseconds * 100;
//#else
            timerFinMatch.Interval = DureeMatch.TotalMilliseconds;
//#endif
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
            Plateau.Balise.VitesseRotation(0);
            Actionneur.Convoyeur.Arreter();
            Actionneur.Ejecteur.TournerStop();
            Actionneur.BrasLunaire.Ouvrir();
            Actionneur.BrasLunaireDroite.Ouvrir();
            Actionneur.BrasLunaireGauche.Ouvrir();
            Actionneur.Stockeur.RelacheBas();
            Actionneur.Stockeur.RelacheHaut();
            Actionneur.Ejecteur.CouperEjecteur();
            // TODO eteindre ici les actionneurs du robot

            Thread.Sleep(2500);

            Actionneur.Fusee.LancerLaFusee();
            // Todo Couper ici tous les actionneurs à la fin du match et lancer la Funny Action
        }

        protected abstract void ThreadGros();
        
        public void Stop()
        {
            thGrosRobot.Abort();
        }
    }
}
