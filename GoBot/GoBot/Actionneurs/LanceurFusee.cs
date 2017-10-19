using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    class LanceurFusee
    {
        public bool Armed { get; protected set; }

        public void Armer()
        {
            Config.CurrentConfig.ServoFusee.SendPosition(Config.CurrentConfig.ServoFusee.PositionArme);
            Armed = true;
        }

        public void LancerLaFusee()
        {
            Config.CurrentConfig.ServoFusee.SendPosition(Config.CurrentConfig.ServoFusee.PositionFeu);
            Armed = false;
        }
    }
}
