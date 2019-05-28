using GoBot.Communications;
using GoBot.Communications.UDP;
using GoBot.Devices;
using GoBot.Devices.CAN;
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
        CanServo _servoFingerFront;
        CanServo _servoFingerBack;

        ServoFingerFront _posFingerFront;
        ServoFingerBack _posFingerBack;

        int _atomsCount;

        public AtomStacker()
        {
            _atomsCount = 0;

            _servoFingerFront = AllDevices.CanServos[ServomoteurID.FingerFront];
            _servoFingerBack = AllDevices.CanServos[ServomoteurID.FingerBack];

            _posFingerFront = Config.CurrentConfig.ServoFingerFront;
            _posFingerBack = Config.CurrentConfig.ServoFingerBack;
        }

        public int AtomsCount { get => _atomsCount; set => _atomsCount = value; }

        public void DoFrontOpen()
        {
            _servoFingerFront.SetPosition(_posFingerFront.Maximum);
            ThreadManager.CreateThread(link =>
            {
                link.Name = "Securité doigt avant";
                Thread.Sleep(300);
                _servoFingerFront.SetPosition(_posFingerFront.PositionOpen);
            }).StartThread();
        }

        public void DoFrontClose()
        {
            _servoFingerFront.SetPosition(_posFingerFront.PositionClose);
        }

        public void DoBackOpenForward()
        {
            _servoFingerBack.SetPosition(_posFingerBack.PositionForward);
        }

        public void DoBackOpenBackward()
        {
            _servoFingerBack.SetPosition(_posFingerBack.PositionBackward);
        }

        public void DoBackClose()
        {
            _servoFingerBack.SetPosition(_posFingerBack.PositionVertical);
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

        public void DoFrontStop()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerFront, StopMode.Abrupt));
        }

        public void DoBackStop()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerBack, StopMode.Abrupt));
        }

        public void DoFrontOrigin()
        {
            Robots.GrosRobot.MoteurOrigin(MoteurID.FingerFront, true);
            FingerFrontResetPosition();
        }

        public void DoBackOrigin()
        {
            Robots.GrosRobot.MoteurOrigin(MoteurID.FingerBack, true);
            FingerBackResetPosition();
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
            DoFrontMax();
            DoFrontClose();
            
            DoBackStop();
            DoBackOrigin();
            DoBackOpenForward();

            DoFrontStop();
            DoFrontOrigin();

            DoFrontStop();
            MoveFingerFront(50, false);

            DoBackStop();
            MoveFingerBack(2, false);
            MoveFingerFront(150);

            DoBackOpenForward();
            Thread.Sleep(500);
            MoveFingerBack(110);
            DoBackClose();
            MoveFingerBack(1);
            MoveFingerBack(50, false);

            _servoFingerBack.DisableOutput();
            _servoFingerFront.DisableOutput();
        }

        public void DoFrontMax()
        {
            MoveFingerFront(400);
        }

        public void DoLoop()
        {
            ThreadManager.CreateThread(new ThreadLink.CallBack(link =>
            {
                DoFrontStop();
                Robots.GrosRobot.MoteurPosition(MoteurID.FingerFront, Config.CurrentConfig.MotorFingerFront.Minimum, true);
                DoFrontStop();
                Robots.GrosRobot.MoteurPosition(MoteurID.FingerFront, Config.CurrentConfig.MotorFingerFront.Maximum, true);
                DoBackStop();
                Robots.GrosRobot.MoteurPosition(MoteurID.FingerBack, Config.CurrentConfig.MotorFingerBack.Maximum, true);
                DoBackStop();
                Robots.GrosRobot.MoteurPosition(MoteurID.FingerBack, Config.CurrentConfig.MotorFingerBack.Minimum, true);
            })).StartLoop(new TimeSpan(), 3);
        }

        public void MoveFingerFront(int position, bool wait = true)
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerFront, StopMode.Abrupt));

            Robots.GrosRobot.MoteurPosition(MoteurID.FingerFront, position, wait);
        }

        public void MoveFingerBack(int position, bool wait = true)
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerBack, StopMode.Abrupt));

            Robots.GrosRobot.MoteurPosition(MoteurID.FingerBack, position, wait);
        }

        public void DoBackPosition1()
        {
            Config.CurrentConfig.MotorFingerBack.SendPosition(1);
        }

        public void DoBackPosition2()
        {
            Config.CurrentConfig.MotorFingerBack.SendPosition(30);
        }

        public void DoBackPosition3()
        {
            Config.CurrentConfig.MotorFingerBack.SendPosition(100);
        }

        
    }
}
