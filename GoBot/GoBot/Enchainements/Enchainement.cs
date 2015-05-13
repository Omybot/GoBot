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

            for (int iPied = 0; iPied < Plateau.Pieds.Count; iPied++)
                ListeMouvementsGros.Add(new MouvementPied(iPied));
            for (int iPied = 0; iPied < Plateau.Pieds.Count; iPied++)
                ListeMouvementsGros.Add(new MouvementAmpoulePied(iPied));
            for (int iTapis = 0; iTapis < Plateau.ListeTapis.Count; iTapis++)
                ListeMouvementsGros.Add(new MouvementTapis(iTapis));
            for (int iClap = 0; iClap < 6; iClap++)
                ListeMouvementsGros.Add(new MouvementClap(iClap));
            for (int iGobelet = 0; iGobelet < Plateau.Gobelets.Count; iGobelet++)
                ListeMouvementsGros.Add(new MouvementGobelet(iGobelet, Actionneur.BrasPiedsDroite));
            for (int iGobelet = 0; iGobelet < Plateau.Gobelets.Count; iGobelet++)
                ListeMouvementsGros.Add(new MouvementGobelet(iGobelet, Actionneur.BrasPiedsGauche));

            ListeMouvementsGros.Add(new MouvementDeposeDepart(Plateau.ZoneDepartJaune));
            ListeMouvementsGros.Add(new MouvementDeposeDepart(Plateau.ZoneDepartVert));

            ListeMouvementsGros.Add(new MouvementDeposeEstrade(Plateau.ZoneDeposeEstradeDroite));
            ListeMouvementsGros.Add(new MouvementDeposeEstrade(Plateau.ZoneDeposeEstradeGauche));

            ListeMouvementsGros.Add(new MouvementTas1(Plateau.CouleurGaucheJaune));
            ListeMouvementsGros.Add(new MouvementTas1(Plateau.CouleurDroiteVert));

            ListeMouvementsGros.Add(new MouvementTas2(Plateau.CouleurGaucheJaune));
            ListeMouvementsGros.Add(new MouvementTas2(Plateau.CouleurDroiteVert));
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
            //Robots.PetitRobot.Stop(StopMode.Freely);
            Robots.GrosRobot.MoteurPosition(MoteurID.Balise, 0);
            Actionneur.BrasAspirateur.Arreter();
            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            Actionneur.BrasPiedsDroite.AscenseurHauteur(0);
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceHaut();
            Actionneur.BrasPiedsGauche.AscenseurHauteur(0);
            Actionneur.BrasTapis.LacherTapisDroit();
            Actionneur.BrasTapis.LacherTapisGauche();

            Config.CurrentConfig.ServoAscenseurDroitBasDroit.Positionner(0);
            Config.CurrentConfig.ServoAscenseurDroitBasGauche.Positionner(0);
            Config.CurrentConfig.ServoAscenseurGaucheBasDroit.Positionner(0);
            Config.CurrentConfig.ServoAscenseurDroitBasGauche.Positionner(0);

            Config.CurrentConfig.ServoAscenseurDroitHautDroit.Positionner(0);
            Config.CurrentConfig.ServoAscenseurDroitHautGauche.Positionner(0);
            Config.CurrentConfig.ServoAscenseurGaucheHautDroit.Positionner(0);
            Config.CurrentConfig.ServoAscenseurDroitHautGauche.Positionner(0);

            Config.CurrentConfig.ServoBalleVerrouillageDroit.Positionner(0);
            Config.CurrentConfig.ServoBalleVerrouillageGauche.Positionner(0);

            Thread.Sleep(100);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.Alimentation, false);
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
