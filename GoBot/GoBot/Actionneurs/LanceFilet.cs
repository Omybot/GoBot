using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneur
{
    public static class LanceFilet
    {
        public static void Armer()
        {
            Robots.PetitRobot.TourneMoteur(MoteurID.PRLanceFilet, Config.CurrentConfig.PositionPRFiletArme);
        }

        public static void Tirer()
        {
            Robots.PetitRobot.TourneMoteur(MoteurID.PRLanceFilet, Config.CurrentConfig.PositionPRFiletTir);
        }
    }
}
