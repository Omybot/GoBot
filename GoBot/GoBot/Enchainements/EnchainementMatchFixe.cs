using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Actionneurs;
using System.Windows.Forms;
using GoBot.ElementsJeu;
using GoBot.Mouvements;

namespace GoBot.Enchainements
{
    class EnchainementMatchFixe : Enchainement
    {
        protected override void ThreadGros()
        {
            int iMeilleur = 0;

            while(true)
            {
                Robots.GrosRobot.GotoXYTeta(2500, 1500, 0);
            }
            // Ajouter ici les actions fixes avant le lancement de l'IA

            /*Actionneur.BrasAmpoule.Fermer();
            Thread.Sleep(450);
            Actionneur.BrasAmpoule.AmpouleChargee = true;

            Actionneur.BrasAmpoule.Hauteur(Config.CurrentConfig.AscenseurAmpoule.PositionPoseSur2Pied);

            Actionneur.BrasSpot.OuvrirPinceBas();
            Actionneur.BrasSpot.OuvrirPinceHaut();
            Actionneur.BrasSpot.AscenseurDescendre();
            Actionneur.BrasSpot.LibererBalle();

            Actionneur.BrasGobelet.OuvrirPinceBas();
            Actionneur.BrasGobelet.AscenseurDescendre();
            Actionneur.BrasGobelet.FermerPinceHaut();

            if(Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
                Robots.GrosRobot.PivotGauche(7.93);
            else
                Robots.GrosRobot.PivotDroite(7.93);

            Robots.GrosRobot.Avancer(520);

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.VitesseDeplacement /= 4;
            Robots.GrosRobot.AttrapageAutomatique = true;
            Robots.GrosRobot.Avancer(50);
            Robots.GrosRobot.Rapide();

            if (!Robots.GrosRobot.AttrapageAutomatique)
            {
                Actionneur.BrasGobelet.FermerPinceBas();
                Thread.Sleep(250);
            }

            Robots.GrosRobot.AttrapageAutomatique = false;

            //Robots.GrosRobot.Avancer(500);
            //Robots.GrosRobot.Lent();
            //Robots.GrosRobot.Avancer(70);

            Actionneur.BrasGobelet.FermerPinceBas();
            Thread.Sleep(200);
            Actionneur.BrasGobelet.Gobelet = true;

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
                Plateau.Gobelets[1].Ramasse = true;
            else
                Plateau.Gobelets[3].Ramasse = true;

            Actionneur.BrasGobelet.AscenseurMonter();
            Thread.Sleep(500);
            if (Actionneur.BrasGobelet.AsserKO)
            {
                Actionneur.BrasGobelet.AsserKO = false;
                Actionneur.BrasGobelet.SouleverLegerement();
            }
            else
            {
                Actionneur.BrasGobelet.OuvrirPinceBas();
                Robots.GrosRobot.Avancer(50);
                Robots.GrosRobot.Reculer(50);
                Actionneur.BrasGobelet.AscenseurMonter();
                Actionneur.BrasGobelet.Gobelet = false;
            }

            Mouvement move = new MouvementTapis(0); move.Executer();
            move = new MouvementTapis(1); move.Executer();
            move = new MouvementAmpoulePied(7); move.Executer();
            move = new MouvementPied(7); move.Executer();
            move = new MouvementPied(4); move.Executer();
            move = new MouvementPied(3); move.Executer();
            move = new MouvementPied(0); move.Executer();
            move = new MouvementDeposeDepart(Plateau.ZoneDepartJaune); move.Executer();
            move = new MouvementPied(5); move.Executer();
            move = new MouvementGobelet(0, Plateau.CouleurGaucheJaune); move.Executer();
            move = new MouvementPied(1); move.Executer();
            move = new MouvementPied(2); move.Executer();
            move = new MouvementClap(0); move.Executer();
            move = new MouvementPied(6); move.Executer();
            move = new MouvementClap(2); move.Executer();
            move = new MouvementDeposeEstrade(Plateau.ZoneDeposeEstradeGauche); move.Executer();

            /*
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
                {
                    if (!ListeMouvementsGros[iMeilleur].Executer())
                        ListeMouvementsGros[iMeilleur].DateMinimum = DateTime.Now + new TimeSpan(0, 0, 1);
                }
                else
                {
                    try
                    {
                        Thread.Sleep(500);
                    }
                    catch(Exception)
                    {

                    }
                }
            }
            */
        }

        protected override void ThreadPetit()
        {
            int iMeilleur = 0;
            return;
            // Ajouter ici les actions fixes avant le lancement de l'IA

        }
    }
}
