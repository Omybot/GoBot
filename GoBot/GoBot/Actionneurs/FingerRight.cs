using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GoBot.Actionneurs
{
    class FingerRight
    {
        public void DoGoInside()
        {
        }

        public void DoGoOutside()
        {
        }

        public void DoLock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.MakeVacuumRightBack, true);
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.OpenVacuumRightBack, false);
        }

        public void DoUnlock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.MakeVacuumRightBack, false);
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.OpenVacuumRightBack, true);
        }
    }
}
