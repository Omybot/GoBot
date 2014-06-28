using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    public static class LanceFilet
    {
        public static int FiletLance { get; set; }

        public static void Armer()
        {
            Robots.PetitRobot.MoteurPosition(MoteurID.PRLanceFilet, Config.CurrentConfig.PositionPRFiletArme);
        }

        public static void Tirer()
        {
            Robots.PetitRobot.MoteurPosition(MoteurID.PRLanceFilet, Config.CurrentConfig.PositionPRFiletTir);
        }
    }
}
