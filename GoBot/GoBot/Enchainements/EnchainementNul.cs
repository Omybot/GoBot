using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
using AStarFolder;
using System.Threading;
using GoBot.Actionneurs;

namespace GoBot.Enchainements
{
    class EnchainementNul : Enchainement
    {
        protected override void ThreadGros()
        {
            Robots.GrosRobot.Avancer(500);
        }

        protected override void ThreadPetit()
        {
        }
    }
}
