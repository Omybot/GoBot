using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using GoBot.Movements;

namespace GoBot.Strategies
{
    class StrategyTest : Strategy
    {
        List<Movement> mouvements;

        protected override void SequenceBegin()
        {
            List<Movement> mouvements = new List<Movement>();

            // Charger ICI les mouvements à tester

        }

        protected override void SequenceCore()
        {
            foreach (Movement move in mouvements)
            {
                for (int i = 0; i < move.Positions.Count; i++)
                {
                    Robots.GrosRobot.ReglerOffsetAsserv(move.Positions[i]);
                    Thread.Sleep(500);
                    move.Execute();
                }
            }
        }
    }
}
