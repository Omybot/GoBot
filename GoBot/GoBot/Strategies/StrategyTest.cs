using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using GoBot.Mouvements;

namespace GoBot.Strategies
{
    class StrategyTest : Strategy
    {
        List<Mouvement> mouvements;

        protected override void SequenceBegin()
        {
            List<Mouvement> mouvements = new List<Mouvement>();

            // Charger ICI les mouvements à tester

        }

        protected override void SequenceCore()
        {
            foreach (Mouvement move in mouvements)
            {
                for (int i = 0; i < move.Positions.Count; i++)
                {
                    Robots.GrosRobot.ReglerOffsetAsserv(move.Positions[i]);
                    Thread.Sleep(500);
                    move.Executer();
                }
            }
        }
    }
}
