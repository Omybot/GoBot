using System.Threading;

namespace GoBot.Actionneurs
{
    class ElevatorRight : Elevator
    {
        public ElevatorRight()
        {
            _servoPush = Config.CurrentConfig.ServoPushArmRight;
            _servoLocker = Config.CurrentConfig.ServoLockerRight;

            _makeVacuum = ActuatorOnOffID.MakeVacuumRightFront;
            _openVacuum = ActuatorOnOffID.OpenVacuumRightFront;

            _pressure = SensorOnOffID.PressureSensorRightFront;

            _elevator = Config.CurrentConfig.MotorElevatorRight;
        }
    }
    class ElevatorLeft : Elevator
    {
        public ElevatorLeft()
        {
            _servoPush = Config.CurrentConfig.ServoPushArmLeft;
            _servoLocker = Config.CurrentConfig.ServoLockerLeft;

            _makeVacuum = ActuatorOnOffID.MakeVacuumLeftFront;
            _openVacuum = ActuatorOnOffID.OpenVacuumLeftFront;

            _pressure = SensorOnOffID.PressureSensorLeftFront;

            _elevator = Config.CurrentConfig.MotorElevatorLeft;
        }
    }

    abstract class Elevator
    {
        protected ServoPushArm _servoPush;
        protected ServoLocker _servoLocker;
        protected ActuatorOnOffID _makeVacuum, _openVacuum;
        protected SensorOnOffID _pressure;
        protected MotorElevator _elevator;

        public void DoPositionPushInside()
        {
            _servoPush.SendPosition(_servoPush.PositionClose);
        }

        public void DoPositionPushOutside()
        {
            _servoPush.SendPosition(_servoPush.PositionOpen);
        }

        public void DoLockAir()
        {
            Robots.MainRobot.SetActuatorOnOffValue(_makeVacuum, true);
            Robots.MainRobot.SetActuatorOnOffValue(_openVacuum, false);
            _servoLocker.SendPosition(_servoLocker.PositionEngage);
        }

        public void DoUnlockAir()
        {
            Robots.MainRobot.SetActuatorOnOffValue(_makeVacuum, false);
            Robots.MainRobot.SetActuatorOnOffValue(_openVacuum, true);
            _servoLocker.SendPosition(_servoLocker.PositionDisengage);
        }

        public void DoSequence()
        {
            DoPositionElevatorFloor0();
            DoLockAir();
            Thread.Sleep(250);
            DoPositionElevatorFloor3();
            DoUnlockAir();
            Thread.Sleep(250);

            DoPositionElevatorFloor0();
            DoLockAir();
            Thread.Sleep(250);
            DoPositionElevatorFloor2();
            DoUnlockAir();
            Thread.Sleep(250);

            DoPositionElevatorFloor0();
            DoLockAir();
            Thread.Sleep(250);
            DoPositionElevatorFloor1();
            DoUnlockAir();
            Thread.Sleep(250);

            DoPositionElevatorFloor0();
        }

        public void DoInitElevator()
        {
            _elevator.OriginInit();
        }

        public bool HasSomething()
        {
            return Robots.MainRobot.ReadSensorOnOff(_pressure);
        }

        public void DoStopElevator()
        {
            _elevator.Stop(StopMode.Abrupt);
        }

        public void DoPositionElevatorFloor0()
        {
            _elevator.SendPosition(_elevator.PositionFloor0);
        }

        public void DoPositionElevatorFloor1()
        {
            _elevator.SendPosition(_elevator.PositionFloor1);
        }

        public void DoPositionElevatorFloor2()
        {
            _elevator.SendPosition(_elevator.PositionFloor2);
        }

        public void DoPositionElevatorFloor3()
        {
            _elevator.SendPosition(_elevator.PositionFloor3);
        }
    }
}
