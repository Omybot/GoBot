using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    class ElevatorRight
    {
        public void DoPositionInside()
        {
            Config.CurrentConfig.ServoPushArmRight.SendPosition(Config.CurrentConfig.ServoPushArmRight.PositionClose);
        }

        public void DoPositionOutside()
        {
            Config.CurrentConfig.ServoPushArmRight.SendPosition(Config.CurrentConfig.ServoPushArmRight.PositionOpen);
        }
    }
}
