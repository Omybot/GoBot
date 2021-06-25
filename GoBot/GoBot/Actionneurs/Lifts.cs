using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    public abstract class Lift
    {
        protected SmallElevator _elevator;
        protected ActuatorOnOffID _makeVacuum, _openVacuum;
        protected SensorOnOffID _pressure;

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

        public bool HasSomething()
        {
            return Robots.MainRobot.ReadSensorOnOff(_pressure);
        }

        public void DoPositionBottom()
        {
            _elevator.SendPosition(_elevator.PositionBottom);
        }

        public void DoPositionMiddle()
        {
            _elevator.SendPosition(_elevator.PositionMiddle);
        }

        public void DoPositionTop()
        {
            _elevator.SendPosition(_elevator.PositionTop);
        }

        public void DoPositionGrab()
        {
            _elevator.SendPosition(_elevator.PositionGrab);
        }

        public void DoTest()
        {
            for (int i = 0; i < 3; i++)
            {
                DoPositionBottom();
                Thread.Sleep(500);
                DoAirLock();

                Thread.Sleep(500);
                if (HasSomething())
                {
                    DoPositionTop();
                }
                else
                {
                    DoPositionMiddle();
                }

                Thread.Sleep(1000);
                DoAirUnlock();
            }
        }
    }

    public class LiftLeft : Lift
    {
        public LiftLeft()
        {
            _elevator = Config.CurrentConfig.SmallElevatorLeft;
            _makeVacuum = ActuatorOnOffID.MakeVacuumLeft;
            _openVacuum = ActuatorOnOffID.OpenVacuumLeft;
            _pressure = SensorOnOffID.PressureSensorLeft;
        }
    }

    public class LiftRight : Lift
    {
        public LiftRight()
        {
            _elevator = Config.CurrentConfig.SmallElevatorRight;
            _makeVacuum = ActuatorOnOffID.MakeVacuumRight;
            _openVacuum = ActuatorOnOffID.OpenVacuumRight;
            _pressure = SensorOnOffID.PressureSensorRight;
        }
    }

    public class LiftBack : Lift
    {
        protected Selector _selector;
        protected Retractor _retractor;

        public LiftBack()
        {
            _elevator = Config.CurrentConfig.SmallElevatorBack;
            _makeVacuum = ActuatorOnOffID.MakeVacuumBack;
            _openVacuum = ActuatorOnOffID.OpenVacuumBack;
            _pressure = SensorOnOffID.PressureSensorBack;

            _selector = Config.CurrentConfig.Selector;
        }

        public void DoPositionSelectorRight()
        {
            _selector.SendPosition(_selector.PositionRight);
        }

        public void DoPositionSelectorMiddle()
        {
            _selector.SendPosition(_selector.PositionMiddle);
        }

        public void DoPositionSelectorLeft()
        {
            _selector.SendPosition(_selector.PositionLeft);
        }

        public void DoEngage()
        {
            _retractor.SendPosition(_retractor.PositionEngage);
        }

        public void DoDisengage()
        {
            _retractor.SendPosition(_retractor.PositionDisengage);
        }

        public void DoTestBack()
        {
            DoEngage();
            Thread.Sleep(500);
            DoDisengage();
            Thread.Sleep(500);
            DoPositionSelectorRight();
            Thread.Sleep(500);
            DoPositionSelectorMiddle();
            Thread.Sleep(500);
            DoPositionSelectorLeft();
        }
    }
}
