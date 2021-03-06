﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Geometry;
using Geometry.Shapes;
using AStarFolder;

namespace GoBot.Strategies
{
    /// <summary>
    /// Stratégie qui consiste à se déplacer alétoirement sur la piste
    /// </summary>
    class StrategyRandomMoves : Strategy
    {
        Random rand = new Random();

        public override bool AvoidElements => false;

        protected override void SequenceBegin()
        {
            Robots.MainRobot.SpeedConfig.SetParams(500, 2000, 2000, 800, 2000, 2000);
            
            // Sortir ICI de la zone de départ pour commencer
        }

        protected override void SequenceCore()
        {
            while (IsRunning)
            {
                int next = rand.Next(Robots.MainRobot.Graph.Nodes.Count);
                if (!((Node)Robots.MainRobot.Graph.Nodes[next]).Passable)
                    continue;

                Position destination = new Position(rand.Next(360), ((Node)Robots.MainRobot.Graph.Nodes[next]).Position);

                Robots.MainRobot.Historique.Log("Nouvelle destination " + destination.ToString());
                Robots.MainRobot.GoToPosition(destination);
            }
        }
    }
}
