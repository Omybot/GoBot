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
            CreateRobots();
        }

        private static void CreateRobots()
        {
            Graph graphBackup = null;

            if (Robots.MainRobot != null) graphBackup = Robots.MainRobot.Graph;

            Robots.MainRobot?.DeInit();

            if (!Simulation)
                MainRobot = new RobotReel(IDRobot.GrosRobot, Board.RecMove);
            else
                MainRobot = new RobotSimu(IDRobot.GrosRobot);

            if (Config.CurrentConfig.IsMiniRobot)
            {
                MainRobot.SetDimensions(220, 320, 143.8, 346);
            }
            else
            {
                // Position LIDAR : 18.27cm à gauche du centre
                MainRobot.SetDimensions(335, 271, 295, 420);
            }

            MainRobot.PositionChanged += MainRobot_PositionChanged;

            DicRobots = new Dictionary<IDRobot, Robot>();
            DicRobots.Add(IDRobot.GrosRobot, MainRobot);

            MainRobot.Init();
            if (graphBackup != null) Robots.MainRobot.Graph = graphBackup;
            MainRobot.SetSpeedFast();
        }

        private static void MainRobot_PositionChanged(Geometry.Position position)
        {
            AllDevices.SetRobotPosition(position);
        }

        public static void EnableSimulation(bool isSimulation)
        {
            if (Simulation == isSimulation)
                return;

            Simulation = isSimulation;

            CreateRobots();
        }
    }
}
