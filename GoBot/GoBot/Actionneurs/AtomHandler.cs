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
        public void DoOpen()
        {
            MoveClampLeft(Config.CurrentConfig.ServoClampLeft.PositionOpen);
            MoveClampRight(Config.CurrentConfig.ServoClampRight.PositionOpen);

            Threading.ThreadManager.CreateThread(link =>
            {
                Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoClampRight.ID].DisableOutput();
                Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoClampLeft.ID].DisableOutput();
            }).StartDelayedThread(500);
        }

        public void DoClose()
        {
            //MoveClampLeft(Config.CurrentConfig.ServoClampLeft.PositionClose);
            //MoveClampRight(Config.CurrentConfig.ServoClampRight.PositionClose);

            MoveClampLeft(Config.CurrentConfig.ServoClampLeft.Minimum);
            MoveClampRight(Config.CurrentConfig.ServoClampRight.Maximum);
        }

        public void DoFree()
        {
            MoveClampLeft(Config.CurrentConfig.ServoClampLeft.PositionFree);
            MoveClampRight(Config.CurrentConfig.ServoClampRight.PositionFree);
        }

        public void DoFreeTorque()
        {
            MoveClampLeft(0);
            MoveClampRight(0);
        }

        public void DoUp()
        {
            MoveElevation(Config.CurrentConfig.ServoElevation.PositionInside);
        }

        public void DoDown()
        {
            MoveElevation(Config.CurrentConfig.ServoElevation.PositionGround);
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
            Thread.Sleep(2000);
            DoStop();
            DoUp();
            Thread.Sleep(2000);

            Actionneur.AtomStacker.MoveFingerFront(Config.CurrentConfig.MotorFingerFront.Maximum, true);

            Actionneur.AtomStacker.DoFrontClose();
            Thread.Sleep(500);
            DoFree();
            Thread.Sleep(100);

            Actionneur.AtomStacker.DoFrontStore();
            Thread.Sleep(400);
            DoDown();
            Thread.Sleep(400);
            DoFree();
        }

        public void MoveClampLeft(int position)
        {
            Config.CurrentConfig.ServoClampLeft.SendPosition(position);
        }

        public void MoveClampRight(int position)
        {
            Config.CurrentConfig.ServoClampRight.SendPosition(position);
        }

        public void MoveElevation(int position)
        {
            Config.CurrentConfig.ServoElevation.SendPosition(position);
        }

        public void DoInit()
        {
            MoveClampLeft(Config.CurrentConfig.ServoClampLeft.PositionClose);
            Thread.Sleep(500);
            MoveClampLeft(Config.CurrentConfig.ServoClampLeft.PositionFree);
            Thread.Sleep(500);

            MoveClampRight(Config.CurrentConfig.ServoClampRight.PositionClose);
            Thread.Sleep(500);
            MoveClampRight(Config.CurrentConfig.ServoClampRight.PositionFree);
            Thread.Sleep(500);

            MoveElevation(Config.CurrentConfig.ServoElevation.PositionGround);
            Thread.Sleep(500);
            MoveElevation(Config.CurrentConfig.ServoElevation.PositionInside);
            Thread.Sleep(500);

            Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoClampRight.ID].DisableOutput();
            Devices.Devices.CanServos[(int)Config.CurrentConfig.ServoClampLeft.ID].DisableOutput();
        }
    }
}
