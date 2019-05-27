using GoBot.Communications;
using GoBot.Communications.CAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Devices.CAN
{
    /// <summary>
    /// Représente un servomoteur piloté par liaison CAN
    /// </summary>
    public class CanServo
    {
        private int _globalId;

        private int _position;
        private int _positionMin, _positionMax;
        private int _acceleration;
        private int _speedMax;
        private int _torqueCurrent, _torqueMax;
        private bool _enableAutoCut;

        private Semaphore _lockResponse;

        private iCanSpeakable _communication;

        public CanServo(int globalId, iCanSpeakable communication)
        {
            _globalId = globalId;
            _communication = communication;
            _lockResponse = new Semaphore(0, int.MaxValue);
            _enableAutoCut = false;
        }

        public int ID { get => _globalId; }
        public int LastPosition { get => _position; }
        public int LastPositionMin { get => _positionMin; }
        public int LastPositionMax { get => _positionMax; }
        public int LastSpeedMax { get => _speedMax; }
        public int LastTorqueCurrent { get => _torqueCurrent; }
        public int LastTorqueMax { get => _torqueMax; }
        public int LastAcceleration { get => _acceleration; }
        public bool AutoCut { get => _enableAutoCut; set => _enableAutoCut = value; }

        public int ReadPosition()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetPosition(_globalId));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _position : -1;
        }

        public int ReadPositionMax()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetPositionMax(_globalId));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _positionMax : -1;
        }

        public int ReadPositionMin()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetPositionMin(_globalId));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _positionMin : -1;
        }

        public int ReadSpeedMax()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetSpeedMax(_globalId));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _speedMax : -1;
        }

        public int ReadAcceleration()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetAcceleration(_globalId));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _acceleration : -1;
        }

        public int ReadTorqueCurrent()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetTorqueCurrent(_globalId));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _torqueCurrent : -1;
        }

        public int ReadTorqueMax()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetTorqueMax(_globalId));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _torqueMax : -1;
        }

        public void SetAcceleration(int acceleration)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetAcceleration(_globalId, acceleration));
        }

        public void SetPosition(int position)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetPosition(_globalId, position));
        }

        public void SetPositionMax(int positionMax)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetPositionMax(_globalId, positionMax));
        }

        public void SetPositionMin(int positionMin)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetPositionMin(_globalId, positionMin));
        }

        public void SetSpeedMax(int speedMax)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetSpeedMax(_globalId, speedMax));
        }

        public void SetTorqueMax(int torqueMax)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetTorqueMax(_globalId, torqueMax));
        }

        public void SetTrajectory(int position, int speed, int accel)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetTrajectory(_globalId, position, speed, accel));
        }

        public void DisableOutput()
        {
            _communication.SendFrame(CanFrameFactory.BuildDisableOutput(_globalId));
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
                        _lockResponse.Release();
                        break;
                    case CanFrameFunction.PositionMaxResponse:
                        _positionMax = CanFrameFactory.ExtractValue(frame);
                        _lockResponse.Release();
                        break;
                    case CanFrameFunction.PositionMinResponse:
                        _positionMin = CanFrameFactory.ExtractValue(frame);
                        _lockResponse.Release();
                        break;
                    case CanFrameFunction.SpeedMaxResponse:
                        _speedMax = CanFrameFactory.ExtractValue(frame);
                        _lockResponse.Release();
                        break;
                    case CanFrameFunction.TorqueCurrentResponse:
                        _torqueCurrent = CanFrameFactory.ExtractValue(frame);
                        _lockResponse.Release();
                        break;
                    case CanFrameFunction.TorqueMaxResponse:
                        _torqueMax = CanFrameFactory.ExtractValue(frame);
                        _lockResponse.Release();
                        break;
                    case CanFrameFunction.AccelerationResponse:
                        _acceleration = CanFrameFactory.ExtractValue(frame);
                        _lockResponse.Release();
                        break;
                    case CanFrameFunction.TorqueAlert:
                        Devices.RecGoBot.Buzz(".-.");
                        if (_enableAutoCut)
                            _communication.SendFrame(CanFrameFactory.BuildDisableOutput(_globalId));
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
