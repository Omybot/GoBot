using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot
{
    static class Robots
    {
        public static Robot GrosRobot { get; set; }
        public static Robot PetitRobot { get; set; }
        public static bool Simulation { get; set; }

        public static void Init()
        {
            //if (Connexions.ConnexionMove.ConnexionCheck.Connecte)
                Simulation = false;
            //else
              //  Simulation = true;

            CreerRobots();
        }

        private static void CreerRobots()
        {
            if (!Simulation)
                GrosRobot = new GrosRobot();
            else
            {
                ((GrosRobot)GrosRobot).Delete();
                GrosRobot = new RobotSimu();
            }

            GrosRobot.Init();
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
