using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GoBot.Actionneurs
{
    class Flags
    {
        public void DoCloseRight()
        {
            Config.CurrentConfig.ServoFlagRight.SendPosition(Config.CurrentConfig.ServoFlagRight.PositionClose);
        }
        public void DoOpenRight()
        {
            Config.CurrentConfig.ServoFlagRight.SendPosition(Config.CurrentConfig.ServoFlagRight.PositionOpen);
        }
        public void DoCloseLeft()
        {
            Config.CurrentConfig.ServoFlagLeft.SendPosition(Config.CurrentConfig.ServoFlagLeft.PositionClose);
        }
        public void DoOpenLeft()
        {
            Config.CurrentConfig.ServoFlagLeft.SendPosition(Config.CurrentConfig.ServoFlagLeft.PositionOpen);
        }
    }
}
