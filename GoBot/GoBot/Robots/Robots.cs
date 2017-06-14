using AStarFolder;
using GoBot.Communications;
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

            if (!Simulation)
            {
                RobotReel grosRobot = new RobotReel(IDRobot.GrosRobot, Board.RecMove);
                grosRobot.Connexion = Connections.ConnectionMove;
                GrosRobot = grosRobot;
            }
            else
            {
                if (GrosRobot != null)
                    ((RobotReel)GrosRobot).Delete();
                GrosRobot = new RobotSimu(IDRobot.GrosRobot);
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

            GrosRobot.SpeedConfig.SetParams(Config.CurrentConfig.GRVitesseLigneRapide,
                Config.CurrentConfig.GRAccelerationLigneRapide,
                Config.CurrentConfig.GRAccelerationFinLigneRapide,
                Config.CurrentConfig.GRVitessePivotRapide,
                Config.CurrentConfig.GRAccelerationPivotRapide,
                Config.CurrentConfig.GRAccelerationPivotRapide);
        }

        public static void Simuler(bool simu)
        {
            if (Simulation == simu)
                return;

            Simulation = simu;

            CreerRobots();
        }

        public static void Delete()
        {
            if (!Simulation)
            {
                if (GrosRobot != null)
                    ((RobotReel)GrosRobot).Delete();
            }
        }
    }
}
