using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    public static class BrasFresque
    {
        public static int FresquesCollees { get; set; }

        public static void Baisser()
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRFresque, 79);
        }

        public static void Lever()
        {
            Robots.PetitRobot.BougeServo(ServomoteurID.PRFresque, 274);
        }
    }
}
