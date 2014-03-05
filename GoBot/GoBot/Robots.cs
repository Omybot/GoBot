﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Calculs;
using GoBot.Communications;
using AStarFolder;

namespace GoBot
{
    [Serializable]
    public enum IDRobot
    {
        PetitRobot,
        GrosRobot
    }

    static class Robots
    {
        public static Dictionary<IDRobot, Robot> DicRobots { get; set; }

        public static Robot GrosRobot { get; set; }
        public static Robot PetitRobot { get; set; }
        public static bool Simulation { get; set; }

        public static void Init()
        {
            Simulation = false;
            CreerRobots();
        }

        private static void CreerRobots()
        {
            Graph graphGros = null;
            if (Robots.GrosRobot != null && Robots.GrosRobot.Graph != null)
                graphGros = Robots.GrosRobot.Graph;
            Graph graphPetit = null;
            if (Robots.PetitRobot != null && Robots.PetitRobot.Graph != null)
                graphPetit = Robots.PetitRobot.Graph;

            if (!Simulation)
            {
                RobotReel grosRobot = new RobotReel(IDRobot.GrosRobot);
                grosRobot.Connexion = Connexions.ConnexionMove;
                GrosRobot = grosRobot;

                RobotReel petitRobot = new RobotReel(IDRobot.PetitRobot);
                petitRobot.Connexion = Connexions.ConnexionPi;
                PetitRobot = petitRobot;
            }
            else
            {
                if (GrosRobot != null)
                    ((RobotReel)GrosRobot).Delete();
                GrosRobot = new RobotSimu(IDRobot.GrosRobot);
                if (PetitRobot != null)
                    ((RobotReel)PetitRobot).Delete();
                PetitRobot = new RobotSimu(IDRobot.PetitRobot);
            }

            DicRobots = new Dictionary<IDRobot, Robot>();
            DicRobots.Add(IDRobot.PetitRobot, PetitRobot);
            DicRobots.Add(IDRobot.GrosRobot, GrosRobot);

            GrosRobot.Largeur = 320;
            GrosRobot.Longueur = 280;
            GrosRobot.Nom = "Rocker";
            GrosRobot.Init();
            if (graphGros != null)
                Robots.GrosRobot.Graph = graphGros;

            PetitRobot.Largeur = 195;
            PetitRobot.Longueur = 100;
            PetitRobot.Nom = "Punk";
            PetitRobot.Init();
            if (graphPetit != null)
                Robots.PetitRobot.Graph = graphPetit;
        }

        public static void Simuler(bool simu)
        {
            if (Simulation == simu)
                return;

            Simulation = simu;

            CreerRobots();
        }
    }
}
