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

        public static Robot MainRobot { get; set; }
        public static bool Simulation { get; set; }

        public static void Init()
        {
            Simulation = false;
            CreerRobots();
        }

        private static void CreerRobots()
        {
            Graph graphGros = null;
            if (Robots.MainRobot != null && Robots.MainRobot.Graph != null)
                graphGros = Robots.MainRobot.Graph;

            Robots.MainRobot?.DeInit();

            if (!Simulation)
            {
                RobotReel grosRobot = new RobotReel(IDRobot.GrosRobot, Board.RecMove, 335, 271, 295, 390);
                grosRobot.PositionChanged += GrosRobot_PositionChanged;
                grosRobot.ConnectionAsser = Connections.ConnectionMove;
                MainRobot = grosRobot;
            }
            else
            {
                MainRobot = new RobotSimu(IDRobot.GrosRobot, 335, 271, 295, 390);
                MainRobot.PositionChanged += GrosRobot_PositionChanged;
            }

            DicRobots = new Dictionary<IDRobot, Robot>();
            DicRobots.Add(IDRobot.GrosRobot, MainRobot);

            MainRobot.Name = "Gros robot";
            MainRobot.Init();
            if (graphGros != null)
                Robots.MainRobot.Graph = graphGros;

            MainRobot.SetSpeedFast();
        }

        private static void GrosRobot_PositionChanged(Geometry.Position position)
        {
            if (AllDevices.LidarAvoid != null)
                AllDevices.LidarAvoid.Position = position;
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
