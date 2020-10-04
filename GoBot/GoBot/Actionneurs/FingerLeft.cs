using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    class FingerLeft
    {
        public void DoGoInside()
        {
        }

        public void DoGoOutside()
        {
        }

        public void DoLock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.MakeVacuumLeftBack, true);
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.OpenVacuumLeftBack, false);
        }

        public void DoUnlock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.MakeVacuumLeftBack, false);
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.OpenVacuumLeftBack, true);
        }
    }
}
