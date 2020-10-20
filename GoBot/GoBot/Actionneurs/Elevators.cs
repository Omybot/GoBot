using Geometry;
using Geometry.Shapes;
using GoBot.Devices;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        protected override RealPoint GetEntryFrontPoint()
        {
            return new RealPoint(Robots.MainRobot.Position.Coordinates.X + 100, Robots.MainRobot.Position.Coordinates.Y + 90).Rotation(new AngleDelta(Robots.MainRobot.Position.Angle), Robots.MainRobot.Position.Coordinates);
        }

        protected override RealPoint GetEntryBackPoint()
        {
            return new RealPoint(Robots.MainRobot.Position.Coordinates.X - 100, Robots.MainRobot.Position.Coordinates.Y + 90).Rotation(new AngleDelta(Robots.MainRobot.Position.Angle), Robots.MainRobot.Position.Coordinates);
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

        protected override RealPoint GetEntryFrontPoint()
        {
            return new RealPoint(Robots.MainRobot.Position.Coordinates.X + 100, Robots.MainRobot.Position.Coordinates.Y - 90).Rotation(new AngleDelta(Robots.MainRobot.Position.Angle), Robots.MainRobot.Position.Coordinates);
        }

        protected override RealPoint GetEntryBackPoint()
        {
            return new RealPoint(Robots.MainRobot.Position.Coordinates.X - 100, Robots.MainRobot.Position.Coordinates.Y - 90).Rotation(new AngleDelta(Robots.MainRobot.Position.Angle), Robots.MainRobot.Position.Coordinates);
        }
    }

    abstract class Elevator
    {
        protected bool _isInitialized;

        protected ServoPushArm _servoPush;
        protected ServoLocker _servoLocker;
        protected ServoGrabber _servoGraber;
        protected ActuatorOnOffID _makeVacuum, _openVacuum;
        protected SensorOnOffID _pressure;
        protected MotorElevator _elevator;

        protected int _buoysCountInside = 0;
        protected int _buoysCountOutside = 0;

        public Elevator()
        {
            _isInitialized = false;
        }

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
            _isInitialized = true;
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
            if (!_isInitialized) DoElevatorInit();
            _elevator.SendPosition(_elevator.PositionFloor0);
        }

        public void DoElevatorFloor1()
        {
            if (!_isInitialized) DoElevatorInit();
            _elevator.SendPosition(_elevator.PositionFloor1);
        }

        public void DoElevatorFloor2()
        {
            if (!_isInitialized) DoElevatorInit();
            _elevator.SendPosition(_elevator.PositionFloor2);
        }

        public void DoElevatorFloor3()
        {
            if (!_isInitialized) DoElevatorInit();
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
            else
            {
                DoAirUnlock();
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

        public void DoSearchBuoy()
        {
            List<RealPoint> pts = ((Hokuyo)(AllDevices.LidarGround)).GetPoints();

            List<List<RealPoint>> groups = pts.GroupByDistance(80, -1);
            List<Circle> circles = new List<Circle>();
            
            //for (int i = 0; i < groups.Count; i++)
            //{
            //    Circle circle = groups[i].FitCircle();
            //    if (circle.Radius < 100 && groups[i].Count > 4)
            //    {
            //        circles.Add(circle);
            //    }
            //}

            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i].Count > 4)
                {
                    RealPoint center = groups[i].GetBarycenter();
                    double var = groups[i].Average(p => p.Distance(center) * p.Distance(center));
                    circles.Add(new Circle(center, var));
                }
            }

            if (circles.Count > 0)
            {
                Circle nearest = circles.OrderBy(c => c.Distance(Robots.MainRobot.Position.Coordinates)).First();

                Console.WriteLine(nearest.Center);

                RealPoint entryFrontPoint = GetEntryFrontPoint();
                RealPoint entryBackPoint = GetEntryBackPoint();

                AngleDelta bestAngle = 0;
                double bestError = int.MaxValue;

                for (AngleDelta i = 0; i < 360; i++)
                {
                    Segment inter = new Segment(entryBackPoint.Rotation(i, Robots.MainRobot.Position.Coordinates), nearest.Center);
                    double error = inter.Distance(entryFrontPoint.Rotation(i, Robots.MainRobot.Position.Coordinates));
                    if (error < bestError)
                    {
                        bestError = error;
                        bestAngle = i;
                    }
                }

                bestAngle = -bestAngle.Modulo();

                if (bestAngle < 0)
                    Robots.MainRobot.PivotRight(-bestAngle);
                else
                    Robots.MainRobot.PivotLeft(bestAngle);

                DoGrabOpen();

                int dist = (int)GetEntryFrontPoint().Distance(nearest.Center) + 50;
                Robots.MainRobot.Move(dist);

                DoSequenceStore();

                DoGrabClose();
                Robots.MainRobot.Move(-dist);

                //DoSearchBuoy();
            }
        }

        protected abstract RealPoint GetEntryFrontPoint();
        protected abstract RealPoint GetEntryBackPoint();
    }
}
