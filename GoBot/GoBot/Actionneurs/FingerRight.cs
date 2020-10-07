namespace GoBot.Actionneurs
{
    class FingerRight : Finger
    {
        public override void DoAirLock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.MakeVacuumRightBack, true);
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.OpenVacuumRightBack, false);
        }

        public override void DoAirUnlock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.MakeVacuumRightBack, false);
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.OpenVacuumRightBack, true);
        }

        public override void DoPositionHide()
        {
            Config.CurrentConfig.ServoFingerRight.SendPosition(Config.CurrentConfig.ServoFingerRight.PositionHide);
        }

        public override void DoPositionKeep()
        {
            Config.CurrentConfig.ServoFingerRight.SendPosition(Config.CurrentConfig.ServoFingerRight.PositionKeep);
        }

        public override void DoPositionGrab()
        {
            Config.CurrentConfig.ServoFingerRight.SendPosition(Config.CurrentConfig.ServoFingerRight.PositionGrab);
        }

        public override bool HasSomething()
        {
            return Robots.MainRobot.ReadSensorOnOff(SensorOnOffID.PressureSensorRightBack);
        }
    }
}
