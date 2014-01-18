using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
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
                int next = rand.Next(Plateau.GraphGros.Nodes.Count);
                if (!((Node)Plateau.GraphGros.Nodes[next]).Passable)
                    continue;

                PointReel destination = new PointReel(((Node)Plateau.GraphGros.Nodes[next]).X, ((Node)Plateau.GraphGros.Nodes[next]).Y);

                Robots.GrosRobot.PathFinding(destination.X, destination.Y, 0, true);
            }
        }

        protected override void ThreadPetit()
        {
            while (true)
            {
                int next = rand.Next(Plateau.GraphPetit.Nodes.Count);
                if (!((Node)Plateau.GraphPetit.Nodes[next]).Passable)
                    continue;

                PointReel destination = new PointReel(((Node)Plateau.GraphPetit.Nodes[next]).X, ((Node)Plateau.GraphPetit.Nodes[next]).Y);

                Robots.PetitRobot.PathFinding(destination.X, destination.Y, 0, true);
            }
        }
    }
}
