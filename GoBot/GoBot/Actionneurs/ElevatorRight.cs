using GoBot.Communications;
using GoBot.Communications.UDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class ElevatorRight : Elevator
    {
        public override void DoInitElevator()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(Board.RecIO, MotorID.ElevatorRight, StopMode.Abrupt));
            Robots.MainRobot.SetMotorAtOrigin(MotorID.ElevatorRight, true);
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurResetPosition(Board.RecIO, MotorID.ElevatorRight));
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(Board.RecIO, MotorID.ElevatorRight, StopMode.Abrupt));
        }

        public void DoStopElevator()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(Board.RecIO, MotorID.ElevatorRight, StopMode.Abrupt));
        }

        public override void DoPositionPushInside()
        {
            Config.CurrentConfig.ServoPushArmRight.SendPosition(Config.CurrentConfig.ServoPushArmRight.PositionClose);
        }

        public override void DoPositionPushOutside()
        {
            Config.CurrentConfig.ServoPushArmRight.SendPosition(Config.CurrentConfig.ServoPushArmRight.PositionOpen);
        }

        public override void DoPositionElevatorFloor0()
        {
            Robots.MainRobot.SetMotorAtPosition(MotorID.ElevatorRight, Config.CurrentConfig.MotorElevatorRight.PositionFloor0, true);
        }

        public override void DoPositionElevatorFloor1()
        {
            Robots.MainRobot.SetMotorAtPosition(MotorID.ElevatorRight, Config.CurrentConfig.MotorElevatorRight.PositionFloor1, true);
        }

        public override void DoPositionElevatorFloor2()
        {
            Robots.MainRobot.SetMotorAtPosition(MotorID.ElevatorRight, Config.CurrentConfig.MotorElevatorRight.PositionFloor2, true);
        }

        public override void DoPositionElevatorFloor3()
        {
            Robots.MainRobot.SetMotorAtPosition(MotorID.ElevatorRight, Config.CurrentConfig.MotorElevatorRight.PositionFloor3, true);
        }

        public override void DoLockAir()
        {
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.MakeVacuumRightFront, true);
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.OpenVacuumRightFront, false);
            Config.CurrentConfig.ServoLockerRight.SendPosition(Config.CurrentConfig.ServoLockerRight.PositionEngage);
        }

        public override void DoUnlockAir()
        {
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.MakeVacuumRightFront, false);
            Robots.MainRobot.SetActuatorOnOffValue(ActuatorOnOffID.OpenVacuumRightFront, true);
            Config.CurrentConfig.ServoLockerRight.SendPosition(Config.CurrentConfig.ServoLockerRight.PositionDisengage);
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

        public override bool HasSomething()
        {
            return Robots.MainRobot.ReadSensorOnOff(SensorOnOffID.PressureSensorRightFront);
        }
    }
}
