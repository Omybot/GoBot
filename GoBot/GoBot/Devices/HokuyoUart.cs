using GoBot.Calculs;
using GoBot.Calculs.Formes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GoBot.Communications;

namespace GoBot.Devices
{
    class HokuyoUart : Hokuyo
    {
        public HokuyoUart(LidarID id) : base(id)
        {
        }

        protected override String GetResultat(int timeout = 5000)
        {
            return Robots.GrosRobot.GetMesureLidar(lidar, timeout);
        }
    }
}
