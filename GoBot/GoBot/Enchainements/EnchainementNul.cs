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
            Mouvement move = new Mouvements.MouvementAmpoulePied(5);
            move.Executer();
        }

        protected override void ThreadPetit()
        {
        }
    }
}
