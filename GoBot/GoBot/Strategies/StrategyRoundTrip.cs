using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GoBot.Geometry.Shapes;
using GoBot.Geometry;

namespace GoBot.Strategies
{
    /// <summary>
    /// Stratégie qui consiste à faire des aller-retours sur la piste (pour homologuation d'évitement par exemple)
    /// </summary>
    class StrategyRoundTrip : Strategy
    {
        protected override void SequenceBegin()
        {
            Robots.GrosRobot.SpeedConfig.SetParams(500, 2000, 2000, 800, 2000, 2000);

            Plateau.Balise.VitesseRotation(150);

            // Sortir ICI de la zone de départ pour commencer
        }

        protected override void SequenceCore()
        {
            while (IsRunning)
            {
                Robots.GrosRobot.GotoXYTeta(new Position(180, new RealPoint(350, 950)));
                Robots.GrosRobot.GotoXYTeta(new Position(0, new RealPoint(3000 - 350, 950)));
            }
        }
    }
}
