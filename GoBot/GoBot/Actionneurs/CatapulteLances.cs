using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    public static class CatapulteLances
    {
        public static void Armer()
        {
            Robots.PetitRobot.ActionneurOnOff(ActionneurOnOffID.PRLancesMammouth, true);
        }
        public static void Tirer()
        {
            Robots.PetitRobot.ActionneurOnOff(ActionneurOnOffID.PRLancesMammouth, true);
        }
    }
}
