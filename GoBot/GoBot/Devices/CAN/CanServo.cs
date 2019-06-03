using GoBot.Communications;
using GoBot.Communications.CAN;
using GoBot.Threading;
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
        private ServomoteurID _id;

        private int _position;
        private int _positionMin, _positionMax;
        private int _acceleration;
        private int _speedMax;
        private int _torqueCurrent, _torqueMax;
        private bool _enableAutoCut;

        private Semaphore _lockResponse;

        private iCanSpeakable _communication;

        private ThreadLink _nextDisable;
        
        public delegate void TorqueAlertDelegate();
        public event TorqueAlertDelegate TorqueAlert;

        public CanServo(ServomoteurID id, iCanSpeakable communication)
        {
            _id = id;
            _communication = communication;
            _lockResponse = new Semaphore(0, int.MaxValue);
            _enableAutoCut = false;
            _nextDisable = null;
        }

        public ServomoteurID ID { get => _id; }
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
            _communication.SendFrame(CanFrameFactory.BuildGetPosition(_id));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _position : -1;
        }

        public int ReadPositionMax()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetPositionMax(_id));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _positionMax : -1;
        }

        public int ReadPositionMin()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetPositionMin(_id));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _positionMin : -1;
        }

        public int ReadSpeedMax()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetSpeedMax(_id));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _speedMax : -1;
        }

        public int ReadAcceleration()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetAcceleration(_id));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _acceleration : -1;
        }

        public int ReadTorqueCurrent()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetTorqueCurrent(_id));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _torqueCurrent : -1;
        }

        public int ReadTorqueMax()
        {
            _communication.SendFrame(CanFrameFactory.BuildGetTorqueMax(_id));
            bool ok = _lockResponse.WaitOne(200);
            return ok ? _torqueMax : -1;
        }

        public void SetAcceleration(int acceleration)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetAcceleration(_id, acceleration));
        }

        public void SetPosition(int position)
        {
            CancelDisable();
            _communication.SendFrame(CanFrameFactory.BuildSetPosition(_id, position));
        }

        public void SetPositionMax(int positionMax)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetPositionMax(_id, positionMax));
        }

        public void SetPositionMin(int positionMin)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetPositionMin(_id, positionMin));
        }

        public void SetSpeedMax(int speedMax)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetSpeedMax(_id, speedMax));
        }

        public void SetTorqueMax(int torqueMax)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetTorqueMax(_id, torqueMax));
        }

        public void SetTrajectory(int position, int speed, int accel)
        {
            _communication.SendFrame(CanFrameFactory.BuildSetTrajectory(_id, position, speed, accel));
        }

        public void DisableOutput(int delayMs = 0)
        {
            if(delayMs > 0)
            {
                CancelDisable();

                ThreadManager.CreateThread(link =>
                {
                    _nextDisable = link;
                    if(!link.Cancelled)
                        _communication.SendFrame(CanFrameFactory.BuildDisableOutput(_id));
                }).StartDelayedThread(delayMs);
            }
            else
            {
                _communication.SendFrame(CanFrameFactory.BuildDisableOutput(_id));
            }
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
                        AllDevices.RecGoBot.Buzz(".-.");
                        if (_enableAutoCut)
                            _communication.SendFrame(CanFrameFactory.BuildDisableOutput(_id));
                        TorqueAlert?.Invoke();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + ":" + DateTime.Now.Millisecond.ToString("000") + " : Erreur servo CAN : " + e.Message);
            }
        }

        private void CancelDisable()
        {
            if(_nextDisable != null)
            {
                _nextDisable.Cancel();
                _nextDisable = null;
            }
        }
    }
}
