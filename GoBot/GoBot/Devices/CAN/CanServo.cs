using GoBot.Communications;
using GoBot.Communications.CAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices.CAN
{
    /// <summary>
    /// Représente un servomoteur piloté par liaison CAN
    /// </summary>
    class CanServo
    {
        private int _globalId;

        private int _position;
        private int _positionMin, _positionMax;
        private int _speed;
        private int _torqueCurrent, _torqueMax;

        private iCanSpeakable _communication;

        public CanServo(int globalId, iCanSpeakable communication)
        {
            _globalId = globalId;
            _communication = communication;
        }

        public int ID { get => _globalId; }
        public int LastPosition { get => _position; }
        public int LastPositionMin { get => _positionMin; }
        public int LastPositionMax { get => _positionMax; }
        public int LastSpeed { get => _speed; }
        public int LastTorqueCurrent { get => _torqueCurrent; }
        public int LastTorqueMax { get => _torqueMax; }

        public int ReadPosition()
        {
            bool ok = _communication.SendFrame(CanFrameFactory.BuildGetPosition(_globalId), true);
            return ok ? _position : -1;
        }

        public int ReadPositionMax()
        {
            bool ok = _communication.SendFrame(CanFrameFactory.BuildGetPositionMax(_globalId), true);
            return ok ? _positionMax : -1;
        }

        public int ReadPositionMin()
        {
            bool ok = _communication.SendFrame(CanFrameFactory.BuildGetPositionMin(_globalId), true);
            return ok ? _positionMin : -1;
        }

        public int ReadSpeed()
        {
            bool ok = _communication.SendFrame(CanFrameFactory.BuildGetSpeed(_globalId), true);
            return ok ? _speed : -1;
        }

        public int ReadTorqueCurrent()
        {
            bool ok = _communication.SendFrame(CanFrameFactory.BuildGetTorqueCurrent(_globalId), true);
            return ok ? _torqueCurrent : -1;
        }

        public int ReadTorqueMax()
        {
            bool ok = _communication.SendFrame(CanFrameFactory.BuildGetTorqueMax(_globalId), true);
            return ok ? _torqueMax : -1;
        }

        public void SetPosition(int position)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetPosition(_globalId, position), false);
        }

        public void SetPositionMax(int positionMax)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetPositionMin(_globalId, positionMax), false);
        }

        public void SetPositionMin(int positionMin)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetPositionMin(_globalId, positionMin), false);
        }

        public void SetSpeed(int speed)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetSpeed(_globalId, speed), false);
        }

        public void SetTorqueMax(int torqueMax)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetTorqueMax(_globalId, torqueMax), false);
        }

        public void SetTrajectory(int position, int speed, int accel)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetTrajectory(_globalId, position, speed, accel), false);
        }

        public void FrameReceived(Frame frame)
        {
            CanFrameFunction function = CanFrameFactory.ExtractFunction(frame);

            try
            {
                switch (function)
                {
                    case CanFrameFunction.PositionResponse:
                        _position = CanFrameFactory.ExtractValue(frame);
                        break;
                    case CanFrameFunction.PositionMaxResponse:
                        _positionMax = CanFrameFactory.ExtractValue(frame);
                        break;
                    case CanFrameFunction.PositionMinResponse:
                        _positionMin = CanFrameFactory.ExtractValue(frame);
                        break;
                    case CanFrameFunction.SpeedResponse:
                        _speed = CanFrameFactory.ExtractValue(frame);
                        break;
                    case CanFrameFunction.TorqueCurrentResponse:
                        _torqueCurrent = CanFrameFactory.ExtractValue(frame);
                        break;
                    case CanFrameFunction.TorqueMaxResponse:
                        _torqueMax = CanFrameFactory.ExtractValue(frame);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + ":" + DateTime.Now.Millisecond.ToString("000") + " : Erreur servo CAN : " + e.Message);
            }
        }
    }
}
