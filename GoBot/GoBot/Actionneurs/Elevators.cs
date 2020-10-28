using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;

using Geometry;
using Geometry.Shapes;

using GoBot.Devices;
using GoBot.GameElements;
using GoBot.Threading;

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

        protected List<Color> _buoysSecond; // 0 = en haut...1...2 = étages inférieurs
        protected List<Color> _buoysFirst; // 0 = en haut...1...2...3 = En bas, non monté

        private List<Tuple<PositionLoad, PositionFloor>> _pickupOrder;
        private List<Tuple<PositionLoad, PositionFloor>> _dropoffOrder;

        private bool _grabberOpened;

        private enum PositionLoad
        {
            First,
            Second
        }
        private enum PositionFloor
        {
            Floor3 = 0,
            Floor2,
            Floor1,
            Ground
        }

        public Elevator()
        {
            _isInitialized = false;
            _grabberOpened = false;

            _buoysSecond = Enumerable.Repeat(Color.Transparent, 3).ToList();
            _buoysFirst = Enumerable.Repeat(Color.Transparent, 4).ToList();

            _pickupOrder = new List<Tuple<PositionLoad, PositionFloor>>();
            _pickupOrder.Add(Tuple.Create(PositionLoad.First, PositionFloor.Floor3));
            _pickupOrder.Add(Tuple.Create(PositionLoad.First, PositionFloor.Floor2));
            _pickupOrder.Add(Tuple.Create(PositionLoad.First, PositionFloor.Floor1));
            _pickupOrder.Add(Tuple.Create(PositionLoad.Second, PositionFloor.Floor3));
            _pickupOrder.Add(Tuple.Create(PositionLoad.Second, PositionFloor.Floor2));
            _pickupOrder.Add(Tuple.Create(PositionLoad.Second, PositionFloor.Floor1));
            _pickupOrder.Add(Tuple.Create(PositionLoad.First, PositionFloor.Ground));

            _dropoffOrder = new List<Tuple<PositionLoad, PositionFloor>>();
            _dropoffOrder.Add(Tuple.Create(PositionLoad.First, PositionFloor.Ground));
            _dropoffOrder.Add(Tuple.Create(PositionLoad.First, PositionFloor.Floor1));
            _dropoffOrder.Add(Tuple.Create(PositionLoad.First, PositionFloor.Floor2));
            _dropoffOrder.Add(Tuple.Create(PositionLoad.First, PositionFloor.Floor3));
            _dropoffOrder.Add(Tuple.Create(PositionLoad.Second, PositionFloor.Floor1));
            _dropoffOrder.Add(Tuple.Create(PositionLoad.Second, PositionFloor.Floor2));
            _dropoffOrder.Add(Tuple.Create(PositionLoad.Second, PositionFloor.Floor3));
        }

        public List<Color> LoadFirst => _buoysFirst;
        public List<Color> LoadSecond => _buoysSecond;
        public bool GrabberOpened => _grabberOpened;

        public void FillWith(Color c)
        {
            _buoysFirst[(int)PositionFloor.Floor3] = c;
            _buoysFirst[(int)PositionFloor.Floor2] = c;
            _buoysFirst[(int)PositionFloor.Floor1] = c;
            _buoysFirst[(int)PositionFloor.Ground] = c;

            _buoysSecond[(int)PositionFloor.Floor3] = c;
            _buoysSecond[(int)PositionFloor.Floor2] = c;
            _buoysSecond[(int)PositionFloor.Floor1] = c;
        }

        public int CountTotal => _buoysSecond.Concat(_buoysFirst).Where(b => b != Color.Transparent).Count();
        public int CountSecond => _buoysSecond.Where(b => b != Color.Transparent).Count();
        public int CountFirst => _buoysFirst.Where(b => b != Color.Transparent).Count();
        public int CountRed => _buoysFirst.Where(b => b == Buoy.Red).Count();
        public int CountGreen => _buoysFirst.Where(b => b == Buoy.Green).Count();

        public void DoGrabOpen()
        {
            _servoGraber.SendPosition(_servoGraber.PositionOpen);
            _grabberOpened = true;
        }

        public void DoGrabRelease()
        {
            _servoGraber.SendPosition(_servoGraber.PositionRelease);
            _grabberOpened = false;
        }

        public void DoGrabClose()
        {
            _servoGraber.SendPosition(_servoGraber.PositionClose);
            _grabberOpened = false;
        }

        public void DoGrabHide()
        {
            _servoGraber.SendPosition(_servoGraber.PositionHide);
            _grabberOpened = false;
        }
        public void DoLockerEngage()
        {
            _servoLocker.SendPosition(_servoLocker.PositionEngage);
        }

        public void DoStoreActuators()
        {
            DoLockerEngage();
            DoElevatorInit();
            DoElevatorGround();
            DoLockerDisengage();
            DoPushInside();
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
            Thread.Sleep(750); // TODO régler la tempo
        }

        public void DoPushInsideFast()
        {
            _servoPush.SendPosition(_servoPush.PositionClose);
        }

        public void DoPushOutside()
        {
            _servoPush.SendPosition(_servoPush.PositionOpen);
            Thread.Sleep(750); // TODO régler la tempo
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

        public void DoElevatorFree()
        {
            _elevator.Stop(StopMode.Freely);
        }

        public void DoElevatorGround()
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

        public void DoDemoLoad3()
        {
            ThreadLink left, right;

            Robots.MainRobot.SetSpeedSlow();

            while (CountFirst < 3)
            {
                Robots.MainRobot.Move(85);
                Actionneur.ElevatorLeft.DoElevatorGround();
                Actionneur.ElevatorRight.DoElevatorGround();
                left = ThreadManager.CreateThread(link => Actionneur.ElevatorLeft.DoSequencePickup());
                right = ThreadManager.CreateThread(link => Actionneur.ElevatorRight.DoSequencePickup());
                left.StartThread();
                right.StartThread();
                left.WaitEnd();
                right.WaitEnd();
            }

            Robots.MainRobot.SetSpeedFast();
        }

        public void DoSequencePickupColor(Color c)
        {
            DoAirLock();
            DoGrabClose();

            if (WaitSomething())
            {
                DoStoreColor(c);
                DoGrabClose();
            }
            else
            {
                DoAirUnlock();
            }
        }

        public void DoSequencePickup()
        {
            DoAirLock();
            DoGrabClose();

            if (WaitSomething())
            {
                DoStoreColor(Buoy.Red); // TODO détecter la couleur avec le capteur de couleur
            }
            else
            {
                DoAirUnlock();
            }

            DoGrabClose();
        }

        private void BuoySet(Tuple<PositionLoad, PositionFloor> place, Color c)
        {
            if (place.Item1 == PositionLoad.First)
                _buoysFirst[(int)place.Item2] = c;
            else
                _buoysSecond[(int)place.Item2] = c;
        }

        private void BuoyRemove(Tuple<PositionLoad, PositionFloor> place)
        {
            if (place.Item1 == PositionLoad.First)
                _buoysFirst[(int)place.Item2] = Color.Transparent;
            else
                _buoysSecond[(int)place.Item2] = Color.Transparent;
        }

        private bool IsPositionLoadSecond()
        {
            return _servoPush.GetLastPosition() == _servoPush.PositionOpen;
        }

        public void DoStoreColor(Color c)
        {
            DoElevatorStop();
            DoGrabRelease();

            Tuple<PositionLoad, PositionFloor> place = PlaceToPickup();

            DoPlaceLoad(place.Item1, true);
            DoPlaceFloor(place.Item2);

            DoAirUnlock();
            BuoySet(place, c);

            Robots.MainRobot.SetMotorAtPosition(_elevator.ID, _elevator.PositionFloor0);
        }

        public void DoStorageReset()
        {
            _buoysSecond = Enumerable.Repeat(Color.Transparent, 3).ToList();
            _buoysFirst = Enumerable.Repeat(Color.Transparent, 4).ToList();
        }

        public bool WaitSomething(int timeout = 500)
        {
            Stopwatch sw = Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds < timeout && !HasSomething())
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

                DoSequencePickupColor(Buoy.Red); // TODO Détecter la couleur au lidar ?
                //DoSequencePickup();// ... ou pas...

                DoGrabClose();
                Robots.MainRobot.Move(-dist);

                //DoSearchBuoy();
            }
        }

        protected abstract RealPoint GetEntryFrontPoint();
        protected abstract RealPoint GetEntryBackPoint();

        public Color DoSequenceDropOff()
        {
            DoElevatorStop();
            DoGrabRelease();

            Tuple<PositionLoad, PositionFloor> place = PlaceToDropoff();
            Color c = GetColor(place);

            DoPlaceLoad(place.Item1, true);
            DoPlaceFloor(place.Item2);

            if (place.Item2 != PositionFloor.Ground)
            {
                DoAirLock();
                Thread.Sleep(100);
                Robots.MainRobot.SetMotorAtPosition(_elevator.ID, _elevator.PositionFloor0, true);
            }

            DoAirUnlock();
            BuoyRemove(place);

            return c;
        }

        private void DoPlaceLoad(PositionLoad load, bool wait)
        {
            if (IsPositionLoadSecond())
            {
                if (load == PositionLoad.First)
                {
                    DoElevatorGround();
                    DoPushInside();
                    if (wait) Thread.Sleep(750); // TODO régler la tempo
                }
            }
            else
            {
                if (load == PositionLoad.Second)
                {
                    DoElevatorGround();
                    DoPushOutside();
                    if (wait) Thread.Sleep(750); // TODO régler la tempo
                }
            }
        }

        private void DoPlaceFloor(PositionFloor floor)
        {
            switch (floor)
            {
                case PositionFloor.Ground:
                    DoElevatorGround();
                    break;
                case PositionFloor.Floor1:
                    DoElevatorFloor1();
                    break;
                case PositionFloor.Floor2:
                    DoElevatorFloor2();
                    break;
                case PositionFloor.Floor3:
                    DoElevatorFloor3();
                    break;
            }
        }

        public void DoSequenceDropOff3()
        {
            Robots.MainRobot.SetSpeedSlow();
            DoSequenceDropOff();
            Robots.MainRobot.Move(-85, false);
            DoSequenceDropOff();
            Robots.MainRobot.Move(-85, false);
            DoSequenceDropOff();
            Robots.MainRobot.Move(-85, false);
            Robots.MainRobot.SetSpeedFast();
        }

        private Tuple<PositionLoad, PositionFloor> PlaceToPickup()
        {
            return _pickupOrder.Find(o => (o.Item1 == PositionLoad.First ? _buoysFirst[(int)o.Item2] : _buoysSecond[(int)o.Item2]) == Color.Transparent);
        }

        private Tuple<PositionLoad, PositionFloor> PlaceToDropoff()
        {
            return _dropoffOrder.Find(o => (o.Item1 == PositionLoad.First ? _buoysFirst[(int)o.Item2] : _buoysSecond[(int)o.Item2]) != Color.Transparent);
        }

        private Color GetColor(Tuple<PositionLoad, PositionFloor> place)
        {
            if (place.Item1 == PositionLoad.First)
                return _buoysFirst[(int)place.Item2];
            else
                return _buoysSecond[(int)place.Item2];
        }
    }
}
