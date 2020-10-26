using GoBot.GameElements;
using GoBot.Threading;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace GoBot.Actionneurs
{
    class FingerLeft : Finger
    {
        public FingerLeft()
        {
            _makeVacuum = ActuatorOnOffID.MakeVacuumLeftBack;
            _openVacuum = ActuatorOnOffID.OpenVacuumLeftBack;
            _pressure = SensorOnOffID.PressureSensorLeftBack;
            _finger = Config.CurrentConfig.ServoFingerLeft;
        }
    }

    class FingerRight : Finger
    {
        public FingerRight()
        {
            _makeVacuum = ActuatorOnOffID.MakeVacuumRightBack;
            _openVacuum = ActuatorOnOffID.OpenVacuumRightBack;
            _pressure = SensorOnOffID.PressureSensorRightBack;
            _finger = Config.CurrentConfig.ServoFingerRight;
        }
    }

    abstract class Finger
    {
        protected ActuatorOnOffID _makeVacuum, _openVacuum;
        protected SensorOnOffID _pressure;
        protected ServoFinger _finger;

        protected Color _load;

        public bool Loaded => _load != Color.Transparent;
        public Color Load => _load;

        public Finger()
        {
            _load = Color.Transparent;
        }

        public void DoDemoGrab(ThreadLink link = null)
        {
            Stopwatch swMain = Stopwatch.StartNew();
            bool ok;

            DoAirLock();

            while (!link.Cancelled && swMain.Elapsed.TotalMinutes < 1)
            {
                ok = false;
                Thread.Sleep(1000);

                if (!HasSomething())
                {
                    DoPositionGrab();

                    Stopwatch sw = Stopwatch.StartNew();

                    while (sw.ElapsedMilliseconds < 1000 && !ok)
                    {
                        Thread.Sleep(50);
                        ok = HasSomething();
                    }

                    if (ok)
                        DoPositionKeep();
                    else
                        DoPositionHide();
                }
            }

            DoPositionHide();
            DoAirUnlock();
        }

        public bool DoGrabGreen()
        {
            bool ok = false;

            DoAirLock();
            DoPositionGrab();

            Stopwatch sw = Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds < 750 && !ok)
            {
                Thread.Sleep(50);
                ok = HasSomething();
            }

            if (ok)
            {
                _load = Buoy.Green;
                DoPositionKeep();
            }
            else
            {
                DoAirUnlock();
                DoPositionHide();
            }

            return ok;
        }

        public bool DoGrabColor(Color c)
        {
            bool ok = false;

            DoAirLock();
            DoPositionGrab();

            Stopwatch sw = Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds < 750 && !ok)
            {
                Thread.Sleep(50);
                ok = HasSomething();
            }

            if (ok)
            {
                _load = c;
                DoPositionKeep();
            }
            else
            {
                DoAirUnlock();
                DoPositionHide();
            }

            return ok;
        }

        public void DoRelease()
        {
            DoAirUnlock();
            DoPositionHide();
            _load = Color.Transparent;
        }

        public void DoAirLock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(_makeVacuum, true);
            Robots.MainRobot.SetActuatorOnOffValue(_openVacuum, false);
        }

        public void DoAirUnlock()
        {
            Robots.MainRobot.SetActuatorOnOffValue(_makeVacuum, false);
            Robots.MainRobot.SetActuatorOnOffValue(_openVacuum, true);
        }

        public void DoPositionHide()
        {
            _finger.SendPosition(_finger.PositionHide);
        }

        public void DoPositionKeep()
        {
            _finger.SendPosition(_finger.PositionKeep);
        }

        public void DoPositionGrab()
        {
            _finger.SendPosition(_finger.PositionGrab);
        }

        public bool HasSomething()
        {
            return Robots.MainRobot.ReadSensorOnOff(_pressure);
        }
    }
}