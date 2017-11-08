using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Geometry.Shapes;
using AStarFolder;
using System.Threading;

namespace GoBot.Enchainements
{
    class EnchainementAleatoire : Enchainement
    {
        Random rand = new Random(DateTime.Now.Millisecond);

        protected override void ThreadGros()
        {
            Thread.Sleep(200);
            while (true)
            {
                int next = rand.Next(Robots.GrosRobot.Graph.Nodes.Count);
                if (!((Node)Robots.GrosRobot.Graph.Nodes[next]).Passable)
                    continue;

                RealPoint destination = new RealPoint(((Node)Robots.GrosRobot.Graph.Nodes[next]).X, ((Node)Robots.GrosRobot.Graph.Nodes[next]).Y);

                Robots.GrosRobot.Historique.Log("Nouvelle destination " + destination.X + ":" + destination.Y);
                Robots.GrosRobot.PathFinding(destination.X, destination.Y, rand.Next(360), 0, true);
            }
        }
    }
}
