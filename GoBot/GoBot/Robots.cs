using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Calculs;

namespace GoBot
{
    static class Robots
    {
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
            if (!Simulation)
            {
                RobotReel grosRobot = new RobotReel();
                grosRobot.Connexion = Connexions.ConnexionMove;
                GrosRobot = grosRobot;

                RobotReel petitRobot = new RobotReel();
                petitRobot.Connexion = Connexions.ConnexionPi;
                PetitRobot = petitRobot;
            }
            else
            {
                if (GrosRobot != null)
                    ((RobotReel)GrosRobot).Delete();
                GrosRobot = new RobotSimu();
                if (PetitRobot != null)
                    ((RobotReel)PetitRobot).Delete();
                PetitRobot = new RobotSimu();
            }

            GrosRobot.Largeur = 270;
            GrosRobot.Longueur = 220;
            if(Plateau.NotreCouleur == Plateau.CouleurJ1R)
                GrosRobot.Position = new Position(new Angle(180, AnglyeType.Degre), new Calculs.Formes.PointReel(3000 - Robots.GrosRobot.Longueur / 2, 1000));
            else
                GrosRobot.Position = new Position(new Angle(0, AnglyeType.Degre), new Calculs.Formes.PointReel(Robots.GrosRobot.Longueur / 2, 1000));
            GrosRobot.Nom = "Rocker";
            GrosRobot.Init();

            PetitRobot.Largeur = 195;
            PetitRobot.Longueur = 100;
            PetitRobot.Position = new Position(new Angle(270, AnglyeType.Degre), new Calculs.Formes.PointReel(2500, 1000));
            PetitRobot.Nom = "Punk";
            PetitRobot.Init();
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
