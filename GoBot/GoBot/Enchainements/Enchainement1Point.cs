using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
using AStarFolder;
using System.Threading;

namespace GoBot.Enchainements
{
    class Enchainement1Point : Enchainement
    {
        protected override void ThreadGros()
        {
            Thread.Sleep(200);
            Random rand = new Random(DateTime.Now.Millisecond);

            Robots.GrosRobot.VitesseDeplacement = 800;
            Robots.GrosRobot.AccelerationDeplacement = 800;
            Robots.GrosRobot.VitessePivot = 800;
            Robots.GrosRobot.AccelerationPivot = 800;

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
            {
                Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2750);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 780);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 605);

                Robots.GrosRobot.Avancer(400);
                Robots.GrosRobot.PivotGauche(20);

                Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1750);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 785);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 370);
                Thread.Sleep(500);

                Robots.GrosRobot.Avancer(600);
            }
            else
            {
                Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2750);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 780);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 605);

                Robots.GrosRobot.Avancer(400);
                Robots.GrosRobot.PivotDroite(20);

                Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1750);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 785);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 370);
                Thread.Sleep(500);

                Robots.GrosRobot.Avancer(600);
            }

            Robots.GrosRobot.VitesseDeplacement = 400;
            Robots.GrosRobot.AccelerationDeplacement = 400;
            Robots.GrosRobot.VitessePivot = 400;
            Robots.GrosRobot.AccelerationPivot = 400;
            
            while (true)
            {

                int next = rand.Next(Robots.GrosRobot.Graph.Nodes.Count);
                if (!((Node)Robots.GrosRobot.Graph.Nodes[next]).Passable)
                    continue;

                PointReel destination = new PointReel(((Node)Robots.GrosRobot.Graph.Nodes[next]).X, ((Node)Robots.GrosRobot.Graph.Nodes[next]).Y);

                bool retry = false;

                int i = 0;
                foreach (IForme forme in Plateau.ObstaclesFixes)
                    if (forme.Distance(destination) < 150 + Robots.GrosRobot.Rayon)
                    {
                        retry = true;
                        Console.WriteLine("Retry " + i++);
                    }

                if(!retry)
                    Robots.GrosRobot.PathFinding(destination.X, destination.Y, 0, true);
            }
        }

        protected override void ThreadPetit()
        {
        }
    }
}
