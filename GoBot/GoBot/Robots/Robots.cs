using AStarFolder;
using GoBot.Communications;
using GoBot.Devices;
using System;
using System.Collections.Generic;

namespace GoBot
{
    [Serializable]
    public enum IDRobot
    {
        GrosRobot
    }

    static class Robots
    {
        public static Dictionary<IDRobot, Robot> DicRobots { get; set; }

        public static Robot GrosRobot { get; set; }
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

            Robots.GrosRobot?.Delete();

            if (!Simulation)
            {
                RobotReel grosRobot = new RobotReel(IDRobot.GrosRobot, Board.RecMove);
                grosRobot.PositionChange += GrosRobot_PositionChange;
                grosRobot.Connexion = Connections.ConnectionMove;
                GrosRobot = grosRobot;
            }
            else
            {
                GrosRobot = new RobotSimu(IDRobot.GrosRobot);
                GrosRobot.PositionChange += GrosRobot_PositionChange;
            }

            DicRobots = new Dictionary<IDRobot, Robot>();
            DicRobots.Add(IDRobot.GrosRobot, GrosRobot);

            GrosRobot.Largeur = 320;
            GrosRobot.Longueur = 300;
            GrosRobot.Entraxe = 291.95;
            GrosRobot.Nom = "Gros robot";
            GrosRobot.Init();
            if (graphGros != null)
                Robots.GrosRobot.Graph = graphGros;

            GrosRobot.Rapide();
        }

        private static void GrosRobot_PositionChange(Geometry.Position position)
        {
            if (AllDevices.HokuyoAvoid != null)
                AllDevices.HokuyoAvoid.Position = position;
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
