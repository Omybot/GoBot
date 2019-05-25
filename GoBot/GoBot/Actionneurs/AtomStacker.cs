using GoBot.Communications;
using GoBot.Communications.UDP;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Actionneurs
{
    class AtomStacker
    {
        public void DoFrontOpen()
        {
            Config.CurrentConfig.ServoFingerFront.SendPosition(Config.CurrentConfig.ServoFingerFront.PositionOpen);
        }

        public void DoFrontClose()
        {
            Config.CurrentConfig.ServoFingerFront.SendPosition(Config.CurrentConfig.ServoFingerFront.PositionClose);
        }

        public void DoBackOpenForward()
        {
            Config.CurrentConfig.ServoFingerBack.SendPosition(Config.CurrentConfig.ServoFingerBack.PositionForward);
        }

        public void DoBackOpenBackward()
        {
            Config.CurrentConfig.ServoFingerBack.SendPosition(Config.CurrentConfig.ServoFingerBack.PositionBackward);
        }

        public void DoBackClose()
        {
            Config.CurrentConfig.ServoFingerBack.SendPosition(Config.CurrentConfig.ServoFingerBack.PositionVertical);
        }

        public void DoFrontPrepare(bool wait = true)
        {
            MoveFingerFront(Config.CurrentConfig.MotorFingerFront.PositionPrepare, wait);
        }

        public void DoFrontStore(bool wait = true)
        {
            MoveFingerFront(Config.CurrentConfig.MotorFingerFront.PositionStore, wait);
        }

        public void DoAtomTransfer()
        {
            DoFrontOpen();
            MoveFingerFront(200, true);

            DoFrontClose();
            Thread.Sleep(200);

            MoveFingerFront(50, true);

            DoFrontOpen();
            MoveFingerFront(200, false);
            DoBackOpenForward();
            MoveFingerBack(150, true);

            DoBackClose();
            Thread.Sleep(200);

            MoveFingerBack(0, false);
        }

        public void FingerFrontStop()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerFront, StopMode.Abrupt));
        }

        public void FingerBackStop()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerBack, StopMode.Abrupt));
        }

        public void FingerFrontOrigin()
        {
            Robots.GrosRobot.MoteurOrigin(MoteurID.FingerFront, true);
        }

        public void FingerBackOrigin()
        {
            Robots.GrosRobot.MoteurOrigin(MoteurID.FingerBack, true);
        }

        public void FingerFrontResetPosition()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurResetPosition(MoteurID.FingerFront));
        }

        public void FingerBackResetPosition()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurResetPosition(MoteurID.FingerBack));
        }

        public void DoInit()
        {
            DoFrontOpen();
            Thread.Sleep(500);
            DoFrontClose();
            Thread.Sleep(500);

            DoBackOpenBackward();
            Thread.Sleep(500);
            DoBackClose();

            FingerBackStop();
            FingerBackOrigin();
            FingerBackResetPosition();

            FingerFrontStop();
            FingerFrontOrigin();
            FingerFrontResetPosition();

            FingerBackStop();
            FingerFrontStop();

            MoveFingerFront(150);
            MoveFingerBack(100);

            FingerBackStop();
            FingerFrontStop();

            Thread.Sleep(500);
        }

        public void DoLoop()
        {
            ThreadManager.CreateThread(new ThreadLink.CallBack(link =>
            {
                FingerFrontStop();
                Robots.GrosRobot.MoteurPosition(MoteurID.FingerFront, Config.CurrentConfig.MotorFingerFront.Minimum, true);
                FingerFrontStop();
                Robots.GrosRobot.MoteurPosition(MoteurID.FingerFront, Config.CurrentConfig.MotorFingerFront.Maximum, true);
                FingerBackStop();
                Robots.GrosRobot.MoteurPosition(MoteurID.FingerBack, Config.CurrentConfig.MotorFingerBack.Maximum, true);
                FingerBackStop();
                Robots.GrosRobot.MoteurPosition(MoteurID.FingerBack, Config.CurrentConfig.MotorFingerBack.Minimum, true);
            })).StartLoop(new TimeSpan(), 3);
        }

        public void MoveFingerFront(int position, bool wait = true)
        {
            position = Math.Max(Config.CurrentConfig.MotorFingerFront.Minimum, Math.Min(position, Config.CurrentConfig.MotorFingerFront.Maximum));

            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerFront, StopMode.Abrupt));

            Robots.GrosRobot.MoteurPosition(MoteurID.FingerBack, position, wait);
        }

        public void MoveFingerBack(int position, bool wait = true)
        {
            position = Math.Max(Config.CurrentConfig.MotorFingerBack.Minimum, Math.Min(position, Config.CurrentConfig.MotorFingerBack.Maximum));

            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerBack, StopMode.Abrupt));

            Robots.GrosRobot.MoteurPosition(MoteurID.FingerBack, position, wait);
        }

        public void DoFingerBackPosition1()
        {
            Config.CurrentConfig.MotorFingerBack.SendPosition(0);
        }

        public void DoFingerBackPosition2()
        {
            Config.CurrentConfig.MotorFingerBack.SendPosition(30);
        }

        public void DoFingerBackPosition3()
        {
            Config.CurrentConfig.MotorFingerBack.SendPosition(100);
        }

        
    }
}
