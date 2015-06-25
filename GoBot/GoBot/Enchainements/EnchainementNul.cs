using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
using AStarFolder;
using System.Threading;
using GoBot.Actionneurs;
using GoBot.Mouvements;

namespace GoBot.Enchainements
{
    class EnchainementNul : Enchainement
    {
        protected override void ThreadGros()
        {
            Actionneur.BrasAmpoule.Fermer();
            Thread.Sleep(450);
            Actionneur.BrasAmpoule.Hauteur(Config.CurrentConfig.AscenseurAmpoule.PositionPoseSur2Pied);
            Thread.Sleep(1000);
            Robots.GrosRobot.Avancer(500);

            Actionneur.BrasSpot.OuvrirPinceBas();
            Actionneur.BrasSpot.OuvrirPinceHaut();
            Actionneur.BrasSpot.AscenseurDescendre();

            Actionneur.BrasGobelet.FermerPinceHaut();
            Actionneur.BrasGobelet.FermerPinceBas();
            Actionneur.BrasGobelet.AscenseurMonter();


            Actionneur.BrasSpot.LibererBalle();

            Mouvement move = new Mouvements.MouvementClap(0);
            move.Executer();
            move = new Mouvements.MouvementClap(2);
            move.Executer();
            move = new Mouvements.MouvementClap(4);
            move.Executer();
            /*move = new Mouvements.MouvementDeposeDepart(Plateau.ZoneDepartJaune);
            move.Executer();
            move = new Mouvements.MouvementGobelet(0, Plateau.NotreCouleur);
            move.Executer();
            move = new Mouvements.MouvementPied(1);
            move.Executer();
            move = new Mouvements.MouvementPied(2);
            move.Executer();
            move = new Mouvements.MouvementPied(6);
            move.Executer();
            move = new Mouvements.MouvementPied(7);
            move.Executer();*/
        }

        protected override void ThreadPetit()
        {
        }
    }
}
