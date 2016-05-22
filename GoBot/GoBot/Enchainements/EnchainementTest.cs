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
    class EnchainementTest : Enchainement
    {
        protected override void ThreadGros()
        {
            List<Mouvement> mouvements = new List<Mouvement>();
            // Charger les mouvements à tester


            foreach (Mouvement move in mouvements)
            {
                for (int i = 0; i < move.Positions.Count; i++)
                {
                    Robots.GrosRobot.ReglerOffsetAsserv((int)move.Positions[i].Coordonnees.X, (int)move.Positions[i].Coordonnees.Y, move.Positions[i].Angle);
                    Thread.Sleep(500);
                    move.Executer();
                }
            }
        }
    }
}
