using GoBot.Communications;
using GoBot.Devices.CAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class AtomHandler
    {
        private CanServo _servoClampLeft;
        private CanServo _servoClampRight;
        private CanServo _servoElevation;

        private ServoClampLeft _posClampLeft;
        private ServoClampRight _posClampRight;
        private ServoElevation _posElevation;

        public AtomHandler()
        {
            _servoClampLeft = new CanServo((int)Config.CurrentConfig.ServoClampLeft.ID - 200, Connections.ConnectionCan);
            _servoClampRight = new CanServo((int)Config.CurrentConfig.ServoClampRight.ID - 200, Connections.ConnectionCan);
            _servoElevation = new CanServo((int)Config.CurrentConfig.ServoElevation.ID - 200, Connections.ConnectionCan);

            _posClampLeft = Config.CurrentConfig.ServoClampLeft;
            _posClampRight = Config.CurrentConfig.ServoClampRight;
            _posElevation = Config.CurrentConfig.ServoElevation;
        }

        public void DoOpen()
        {
            _servoClampLeft.SetPosition(_posClampLeft.PositionOpen);
            _servoClampRight.SetPosition(_posClampRight.PositionOpen);

            Threading.ThreadManager.CreateThread(link =>
            {
                _servoClampRight.DisableOutput();
                _servoClampLeft.DisableOutput();
            }).StartDelayedThread(500);
        }

        public void DoClose()
        {
            _servoClampLeft.SetPosition(_posClampLeft.Minimum);
            _servoClampRight.SetPosition(_posClampRight.Maximum);
        }

        public void DoCloseAlmost()
        {
            _servoClampLeft.SetPosition(_posClampLeft.PositionAlmostClose);
            _servoClampRight.SetPosition(_posClampRight.PositionAlmostClose);
        }

        public void DoFree()
        {
            _servoClampLeft.SetPosition(_posClampLeft.PositionFree);
            _servoClampRight.SetPosition(_posClampRight.PositionFree);
        }

        public void DoFreeTorque()
        {
            _servoClampLeft.DisableOutput();
            _servoClampRight.DisableOutput();
        }

        public void DoUp()
        {
            _servoElevation.SetPosition(_posElevation.PositionInside);
        }

        public void DoDown()
        {
            _servoElevation.SetPosition(_posElevation.PositionGround);
        }

        public void DoSwallow()
        {
            Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionSwallow);
        }

        public void DoSpit()
        {
            Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionSpit);
        }

        public void DoStop()
        {
            Config.CurrentConfig.MotorGulp.SendPosition(Config.CurrentConfig.MotorGulp.PositionStop);
        }

        public void DoGrab()
        {
            Actionneur.AtomStacker.DoFrontOpen();
            Actionneur.AtomStacker.DoFrontPrepare(false);

            DoSwallow();
            DoClose();
            Thread.Sleep(500);
            Actionneur.AtomStacker.DoFrontPrepare();
            DoUp();
            Thread.Sleep(500);
            DoStop();

            Actionneur.AtomStacker.MoveFingerFront(Config.CurrentConfig.MotorFingerFront.Maximum, true);

            Actionneur.AtomStacker.DoFrontClose();
            Thread.Sleep(200);
            DoFree();
            Thread.Sleep(100);

            Actionneur.AtomStacker.DoFrontStore(false);
            Thread.Sleep(1000);
            DoDown();
            DoFree();
            Actionneur.AtomStacker.DoFrontStore(true);
        }

        public void MoveClampLeft(int position)
        {
            _servoClampLeft.SetPosition(position);
        }

        public void MoveClampRight(int position)
        {
            _servoClampRight.SetPosition(position);
        }

        public void MoveElevation(int position)
        {
            _servoElevation.SetPosition(position);
        }

        public void DoInit()
        {
            _servoClampLeft.SetPosition(_posClampLeft.PositionFree);
            _servoClampLeft.SetPosition(_posClampRight.PositionFree);

            _servoElevation.SetPosition(_posElevation.PositionGround);
            Thread.Sleep(500);

            _servoClampLeft.SetPosition(_posClampLeft.PositionClose);
            Thread.Sleep(500);
            _servoClampLeft.SetPosition(_posClampLeft.PositionFree);
            Thread.Sleep(500);

            _servoClampRight.SetPosition(_posClampRight.PositionClose);
            Thread.Sleep(500);
            _servoClampRight.SetPosition(_posClampRight.PositionFree);
            Thread.Sleep(500);

            _servoElevation.SetPosition(_posElevation.PositionInside);
            Thread.Sleep(500);

            _servoClampRight.DisableOutput();
            _servoClampLeft.DisableOutput();
        }
    }
}
