using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot
{
    class BrasFruits
    {
        private static readonly int INIT_COUDE = 300;
        private static readonly int INIT_EPAULE = 410;

        public static void PositionEpaule(double angle)
        {
            int valeur = (int)(angle * 1024 / (300.0)) + INIT_EPAULE;
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsEpaule, valeur);
        }

        public static void PositionCoude(double angle)
        {
            int valeur = (int)(angle * 1024 / (300.0)) + INIT_COUDE;
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsCoude, valeur);
        }

        public static void PositionDeposeBouchon2()
        {
            PositionEpaule(70);
            PositionCoude(154);
        }

        public static void PositionDeposeBouchon1()
        {
            PositionEpaule(70);
            PositionCoude(164);
        }

        public static void PositionRange()
        {
            PositionEpaule(0);
            PositionCoude(180);
        }
    }
}
