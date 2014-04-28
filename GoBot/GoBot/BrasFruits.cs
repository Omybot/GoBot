using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot
{
    class BrasFruits
    {
        private static readonly int INIT_COUDE = 603;
        private static readonly int INIT_EPAULE = 411;

        public static void PositionEpaule(double angle)
        {
            int valeur = 1024 - (int)(angle * 1024 / (300.0)) + INIT_EPAULE;
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsEpaule, valeur);
        }

        public static void PositionCoude(double angle)
        {
            int valeur = (int)(angle * 1024 / (300.0)) + INIT_COUDE;
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFruitsCoude, valeur);
        }
    }
}
