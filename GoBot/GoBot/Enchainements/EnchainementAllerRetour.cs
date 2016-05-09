using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
using AStarFolder;
using System.Threading;

namespace GoBot.Enchainements
{
    class EnchainementAllerRetour : Enchainement
    {
        protected override void ThreadGros()
        {
            Robots.GrosRobot.VitesseDeplacement = 500;
            Robots.GrosRobot.AccelerationDebutDeplacement = 2000;
            Robots.GrosRobot.AccelerationFinDeplacement = 2000;

            Robots.GrosRobot.Avancer(300);

            Thread.Sleep(200);
            while (true)
            {
                Robots.GrosRobot.PathFinding(300, 1000, 0, 0, true);
                Robots.GrosRobot.PathFinding(2700, 1000, 18, 0, true);
            }
        }

        protected override void ThreadPetit()
        {
        }
    }
}
