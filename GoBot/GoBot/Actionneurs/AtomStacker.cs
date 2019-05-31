using GoBot.Communications;
using GoBot.Communications.UDP;
using GoBot.Devices;
using GoBot.Devices.CAN;
using GoBot.GameElements;
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

        MotorFingerFront _posFront;
        MotorFingerBack _posBack;

        int _atomsCount;
        bool _dropPosition;

        public AtomStacker()
        {
            _atomsCount = 0;
            _dropPosition = false;

            _servoFingerFront = AllDevices.CanServos[ServomoteurID.FingerFront];
            _servoFingerBack = AllDevices.CanServos[ServomoteurID.FingerBack];

            _posFingerFront = Config.CurrentConfig.ServoFingerFront;
            _posFingerBack = Config.CurrentConfig.ServoFingerBack;

            _posFront = Config.CurrentConfig.MotorFingerFront;
            _posBack = Config.CurrentConfig.MotorFingerBack;
        }

        public int AtomsCount { get => _atomsCount; set => _atomsCount = value; }
        public int AtomsCountMax => 4;

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

        public bool CanStoreMore
        {
            get
            {
                Accelerator accel = Plateau.NotreCouleur == Plateau.CouleurDroiteViolet ? Plateau.Elements.AcceleratorViolet : Plateau.Elements.AcceleratorYellow;

                return _atomsCount < AtomsCountMax && _atomsCount + accel.AtomsCount < 10;
            }
        }

        public void DoFrontClose()
        {
            _servoFingerFront.SetPosition(_posFingerFront.PositionClose);
        }

        public void DoBackBlock()
        {
            _servoFingerBack.SetPosition(_posFingerBack.PositionBlocking);
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
            MoveFingerFront(_posFront.PositionPrepare);

            DoBackOpenForward();
            Thread.Sleep(500);
            MoveFingerBack(110);
            DoBackClose();
            MoveFingerBack(1);

            DoSubInit();
        }

        public void DoSubInit()
        {
            DoFrontOpen();
            DoBackBlock();
            MoveFrontAndBack(_posFront.PositionPrepare, _posFront.PositionPrepare);

            _servoFingerBack.DisableOutput(1000);
            _servoFingerFront.DisableOutput(1000);
            MoveFingerBackFree();
            MoveFingerFrontFree();
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

        public void MoveFingerFrontFree()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerFront, StopMode.Freely));
        }

        public void MoveFingerBackFree()
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerBack, StopMode.Freely));
        }

        public void MoveFingerBack(int position, bool wait = true)
        {
            Connections.ConnectionIO.SendMessage(UdpFrameFactory.MoteurStop(MoteurID.FingerBack, StopMode.Abrupt));

            Robots.GrosRobot.MoteurPosition(MoteurID.FingerBack, position, wait);
        }

        public void DoStoreAtom()
        {
            if (_atomsCount < 5)
            {
                DoBackBlock();
                DoFrontOpen();
                Thread.Sleep(250);

                if (_atomsCount == 0)
                    MoveFrontAndBack(_posFront.Maximum, _posBack.Maximum);
                else
                    MoveFingerFront(_posFront.Maximum);

                DoFrontClose();
                Thread.Sleep(200);
                Actionneur.AtomHandler.DoFree();

                MoveFingerFront((int)(_posFront.PositionPrepare + 25.4));
                int pos = (int)(_posFront.PositionPrepare - 25.4 * _atomsCount);

                MoveFrontAndBack(_posFront.PositionPrepare, pos);
            }
            else if (_atomsCount == 5)
            {
                DoFrontOpen();
                Thread.Sleep(250);
                MoveFingerFront(_posFront.Maximum);
                DoFrontClose();
                Thread.Sleep(200);
                Actionneur.AtomHandler.DoFree();

                MoveFingerFront((int)(_posFront.PositionPrepare + 25.4));

                _servoFingerBack.SetPosition(_posFingerBack.PositionBlocking - 1500);
                MoveFrontAndBack(_posFront.PositionPrepare, 0);
            }
            else if (_atomsCount == 6)
            {
                DoFrontOpen();
                Thread.Sleep(250);
                MoveFingerFront(_posFront.Maximum);
                DoFrontClose();
                Thread.Sleep(200);
                Actionneur.AtomHandler.DoFree();

                MoveFingerFront((int)(_posFront.PositionPrepare + 25.4));

                _servoFingerBack.SetPosition(_posFingerBack.PositionBlocking - 1600);
            }

            MoveFingerBackFree();
            MoveFingerFrontFree();

            _atomsCount++;
            _dropPosition = false;
        }

        public void DoDropLeft()
        {
            DoDrop(Actionneur.AtomUnloaderLeft);
        }

        public void DoDropRight()
        {
            DoDrop(Actionneur.AtomUnloaderRight);
        }

        public void DoDropRightAll()
        {
            while (Actionneur.AtomStacker.AtomsCount > 0)
                DoDrop(Actionneur.AtomUnloaderRight);
        }

        public void DoDrop(AtomUnloader unloader)
        {
            int posFrontDrop = 78;
            int posBackDrop = 95;

            unloader.DoLauncherOutside();


            if (_atomsCount == 7)
            {
                MoveFrontAndBack((int)(_posFront.PositionPrepare + 25.4 * 2), (int)25.4);
                MoveFingerBack(0);
                MoveFingerBackFree();
                DoBackOpenForward();
                MoveFingerFront((int)(48));
                MoveFingerFront((int)(48 + 5));
            }
            else if (_atomsCount == 6)
            {
                if (!_dropPosition)
                {
                    MoveFrontAndBack((int)(_posFront.PositionPrepare + 25.4 * 2), (int)25.4);
                    MoveFingerBack(0);
                    DoBackOpenForward();
                }

                MoveFingerFront(25);
                MoveFingerFront(25 + 5);
            }
            else if (_atomsCount == 5)
            {
                if (!_dropPosition)
                {
                    MoveFrontAndBack((int)(_posFront.PositionPrepare + 25.4 * 2), (int)25.4);
                    MoveFingerBack(0);
                    DoBackOpenForward();
                }

                MoveFingerFront((int)(2));
                MoveFingerFront((int)(2 + 5));
            }
            else if (_atomsCount > 1)
            {
                if (!_dropPosition)
                {
                    MoveFrontAndBack((int)(20 + (_atomsCount - 1) * 25.4), 20);

                    MoveFingerBack(0, false);
                    Thread.Sleep(200);
                    DoBackOpenForward();
                    MoveFrontAndBack(_posFront.PositionPrepare + 60, (int)(posBackDrop + _atomsCount * 25.4));
                    DoBackClose();
                    Thread.Sleep(500);
                    MoveFingerFront(_posFront.PositionPrepare, false);
                    MoveFingerBack((int)(posBackDrop - (25.4 * (5 - _atomsCount))));
                }
                else
                {
                    MoveFingerBack((int)(posBackDrop - (25.4 * (5 - _atomsCount))));
                }
            }
            else if (_atomsCount == 1)
            {
                if (!_dropPosition)
                {
                    MoveFrontAndBack(20, 20);

                    MoveFingerBack(0, false);
                    Thread.Sleep(200);
                    DoBackOpenForward();
                    MoveFrontAndBack(_posFront.PositionPrepare, (int)(posBackDrop + 52 - _atomsCount * 25.4));
                    DoBackClose();
                    Thread.Sleep(500);
                    MoveFingerBack(50);
                    MoveFingerBack(110);
                    _servoFingerBack.SetPosition(12500);
                    Thread.Sleep(500);
                    MoveFingerBack(50);
                    _servoFingerBack.DisableOutput();
                    MoveFingerBack(40);
                }
                else
                {
                    MoveFingerBack(75);
                    _servoFingerBack.SetPosition(12500);
                    Thread.Sleep(500);
                    MoveFingerBack(50);
                    MoveFingerBack(48);
                    _servoFingerBack.DisableOutput();
                    MoveFingerBackFree();
                }
            }

            unloader.DoLauncherLaunch();

            MoveFingerBackFree();
            MoveFingerFrontFree();

            Thread.Sleep(500);
            unloader.DoLauncherPrepare();
            Thread.Sleep(500);

            _dropPosition = true;
            _atomsCount--;
        }

        public void MoveFrontAndBack(int posFront, int posBack)
        {
            MoveFingerFront(posFront, false);
            MoveFingerBack(posBack);
            MoveFingerFront(posFront);
        }
    }
}
