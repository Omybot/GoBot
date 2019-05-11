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
        public void DoOpenFingerFront()
        {
            Config.CurrentConfig.ServoFingerFront.SendPosition(Config.CurrentConfig.ServoFingerFront.PositionOpen);
        }

        public void DoCloseFingerFront()
        {
            Config.CurrentConfig.ServoFingerFront.SendPosition(Config.CurrentConfig.ServoFingerFront.PositionClose);
        }

        public void DoOpenForwardFingerBack()
        {
            Config.CurrentConfig.ServoFingerBack.SendPosition(Config.CurrentConfig.ServoFingerBack.PositionForward);
        }

        public void DoOpenBackwardFingerBack()
        {
            Config.CurrentConfig.ServoFingerBack.SendPosition(Config.CurrentConfig.ServoFingerBack.PositionBackward);
        }

        public void DoCloseFingerBack()
        {
            Config.CurrentConfig.ServoFingerBack.SendPosition(Config.CurrentConfig.ServoFingerBack.PositionVertical);
        }

        public void DoPrepareFingerFront()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerFront, StopMode.Abrupt));
            Config.CurrentConfig.MotorFingerFront.SendPosition(Config.CurrentConfig.MotorFingerFront.PositionPrepare);
            DoOpenFingerFront();
        }

        public void DoStoreFingerFront()
        {
            DoCloseFingerFront();
            Thread.Sleep(700);
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerFront, StopMode.Abrupt));
            Config.CurrentConfig.MotorFingerFront.SendPosition(Config.CurrentConfig.MotorFingerFront.PositionStore);
        }

        public void DoAtomTransfer()
        {
            DoOpenFingerFront();
            MoveFingerFront(200);
            Thread.Sleep(3500 / 3 * 2);

            DoCloseFingerFront();
            Thread.Sleep(200);

            MoveFingerFront(50);
            Thread.Sleep(2800 / 3 * 2);

            DoOpenFingerFront();
            MoveFingerFront(200);
            DoOpenForwardFingerBack();
            MoveFingerBack(150);
            Thread.Sleep(2800 / 3 * 2);

            DoCloseFingerBack();
            Thread.Sleep(200);

            MoveFingerBack(0);
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

        public void DoInitFingers()
        {
            DoCloseFingerFront();
            DoCloseFingerBack();

            FingerBackStop();
            FingerBackOrigin();
            FingerBackResetPosition();

            FingerFrontStop();
            FingerFrontOrigin();
            FingerFrontResetPosition();

            FingerBackStop();
            FingerFrontStop();
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

        public void MoveFingerFront(int position)
        {
            position = Math.Max(Config.CurrentConfig.MotorFingerFront.Minimum, Math.Min(position, Config.CurrentConfig.MotorFingerFront.Maximum));

            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerFront, StopMode.Abrupt));
            Config.CurrentConfig.MotorFingerFront.SendPosition(position);
        }

        public void MoveFingerBack(int position)
        {
            position = Math.Max(Config.CurrentConfig.MotorFingerBack.Minimum, Math.Min(position, Config.CurrentConfig.MotorFingerBack.Maximum));

            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerBack, StopMode.Abrupt));
            Config.CurrentConfig.MotorFingerBack.SendPosition(position);
        }
    }
}
