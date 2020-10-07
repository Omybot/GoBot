namespace GoBot.Actionneurs
{
    class FingerLeft : Finger
    {
        public override void DoAirLock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.MakeVacuumLeftBack, true);
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.OpenVacuumLeftBack, false);
        }

        public override void DoAirUnlock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.MakeVacuumLeftBack, false);
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.OpenVacuumLeftBack, true);
        }

        public override void DoPositionHide()
        {
            Config.CurrentConfig.ServoFingerLeft.SendPosition(Config.CurrentConfig.ServoFingerLeft.PositionHide);
        }

        public override void DoPositionKeep()
        {
            Config.CurrentConfig.ServoFingerLeft.SendPosition(Config.CurrentConfig.ServoFingerLeft.PositionKeep);
        }

        public override void DoPositionGrab()
        {
            Config.CurrentConfig.ServoFingerLeft.SendPosition(Config.CurrentConfig.ServoFingerLeft.PositionGrab);
        }

        public override bool HasSomething()
        {
            return Robots.MainRobot.ReadSensorOnOff(SensorOnOffID.PressureSensorLeftBack);
        }
    }
}
