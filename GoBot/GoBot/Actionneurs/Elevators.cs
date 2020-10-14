using GoBot.Threading;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;

namespace GoBot.Actionneurs
{
    class ElevatorRight : Elevator
    {
        public ElevatorRight()
        {
            _servoPush = Config.CurrentConfig.ServoPushArmRight;
            _servoLocker = Config.CurrentConfig.ServoLockerRight;
            _servoGraber = Config.CurrentConfig.ServoGrabberRight;

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
            _servoGraber = Config.CurrentConfig.ServoGrabberLeft;

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
        protected ServoGrabber _servoGraber;
        protected ActuatorOnOffID _makeVacuum, _openVacuum;
        protected SensorOnOffID _pressure;
        protected MotorElevator _elevator;

        protected int _buoysCountInside = 0;
        protected int _buoysCountOutside = 0;

        public void DoGrabOpen()
        {
            _servoGraber.SendPosition(_servoGraber.PositionOpen);
        }
        public void DoGrabRelease()
        {
            _servoGraber.SendPosition(_servoGraber.PositionRelease);
        }
        public void DoGrabClose()
        {
            _servoGraber.SendPosition(_servoGraber.PositionClose);
        }
        public void DoGrabHide()
        {
            _servoGraber.SendPosition(_servoGraber.PositionHide);
        }
        public void DoLockerEngage()
        {
            _servoLocker.SendPosition(_servoLocker.PositionEngage);
        }

        public void DoLockerDisengage()
        {
            _servoLocker.SendPosition(_servoLocker.PositionDisengage);
        }

        public void DoLockerMaintain()
        {
            _servoLocker.SendPosition(_servoLocker.PositionMaintain);
        }

        public void DoPushInside()
        {
            _servoPush.SendPosition(_servoPush.PositionClose);
        }

        public void DoPushOutside()
        {
            _servoPush.SendPosition(_servoPush.PositionOpen);
        }

        public void DoAirLock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(_makeVacuum, true);
            Robots.MainRobot.SetActuatorOnOffValue(_openVacuum, false);
            _servoLocker.SendPosition(_servoLocker.PositionEngage);
        }

        public void DoAirUnlock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(_makeVacuum, false);
            Robots.MainRobot.SetActuatorOnOffValue(_openVacuum, true);
            _servoLocker.SendPosition(_servoLocker.PositionDisengage);
            Thread.Sleep(50);
        }

        public void DoElevatorInit()
        {
            _elevator.OriginInit();
        }

        public bool HasSomething()
        {
            return Robots.MainRobot.ReadSensorOnOff(_pressure);
        }

        public void DoElevatorStop()
        {
            _elevator.Stop(StopMode.Abrupt);
        }

        public void DoElevatorFloor0()
        {
            _elevator.SendPosition(_elevator.PositionFloor0);
        }

        public void DoElevatorFloor1()
        {
            _elevator.SendPosition(_elevator.PositionFloor1);
        }

        public void DoElevatorFloor2()
        {
            _elevator.SendPosition(_elevator.PositionFloor2);
        }

        public void DoElevatorFloor3()
        {
            _elevator.SendPosition(_elevator.PositionFloor3);
        }

        public void DoSequenceOverkill()
        {
            ThreadLink left, right;

            while (_buoysCountOutside < 3)
            {
                Robots.MainRobot.Move(60);
                Actionneur.ElevatorLeft.DoElevatorFloor0();
                Actionneur.ElevatorRight.DoElevatorFloor0();
                left = ThreadManager.CreateThread(link => Actionneur.ElevatorLeft.DoSequenceStore());
                right = ThreadManager.CreateThread(link => Actionneur.ElevatorRight.DoSequenceStore());
                left.StartThread();
                right.StartThread();
                left.WaitEnd();
                right.WaitEnd();
            }
        }

        public void DoSequenceStore()
        {
            DoLockerEngage();
            DoAirLock();
            DoGrabClose();

            if (WaitSomething())
            {
                BuoyAdd();
                DoStoreCurrent();
            }
        }

        private void BuoyAdd()
        {
            if (_servoPush.GetLastPosition() == _servoPush.PositionOpen)
                _buoysCountInside++;
            else
                _buoysCountOutside++;
        }

        private int BuoyCount()
        {
            if (_servoPush.GetLastPosition() == _servoPush.PositionOpen)
                return _buoysCountInside;
            else
                return _buoysCountOutside;
        }

        public void DoStoreCurrent()
        {
            DoGrabRelease();

            if (BuoyCount() == 1)
                DoElevatorFloor3();
            else if (BuoyCount() == 2)
                DoElevatorFloor2();
            else if (BuoyCount() == 3)
                DoElevatorFloor1();

            DoGrabOpen();
            DoAirUnlock();
            Robots.MainRobot.SetMotorAtPosition(_elevator.ID, _elevator.PositionFloor0);
            //DoPositionElevatorFloor0();
        }

        public void DoStorageReset()
        {
            _buoysCountInside = 0;
            _buoysCountOutside = 0;
        }

        public bool WaitSomething(int timeout = 500)
        {
            Stopwatch sw = Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds < 500 && !HasSomething())
                Thread.Sleep(50);

            return HasSomething();
        }
    }
}
