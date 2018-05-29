using GoBot.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoBot.Devices
{
    class ServosCan
    {
        private int _framesCount;

        private Dictionary<int, int> _position;
        private Dictionary<int, int> _positionMin;
        private Dictionary<int, int> _positionMax;
        private Dictionary<int, int> _speed;
        private Dictionary<int, int> _torqueCurrent;
        private Dictionary<int, int> _torqueMax;

        private Board _board;
        private List<byte> _receivedBuffer;

        private Semaphore _lockAsk;
        private Semaphore _lockWaitResponse;

        private enum ServosCanFunctions
        {
            PositionAsk = 0x01,
            PositionResponse = 0x02,
            PositionSet = 0x03,
            PositionMinAsk = 0x04,
            PositionMinResponse = 0x05,
            PositionMinSet = 0x06,
            PositionMaxAsk = 0x07,
            PositionMaxResponse = 0x08,
            PositionMaxSet = 0x09,
            SpeedAsk = 0x0A,
            SpeedResponse = 0x0B,
            SpeedSet = 0x0C,
            TorqueMaxAsk = 0x0D,
            TorqueMaxResponse = 0x0E,
            TorqueMaxSet = 0x0F,
            TorqueCurrentAsk = 0x10,
            TorqueCurrentResponse = 0x11,
            AccelerationAsk = 0x12,
            AccelerationResponse = 0x13,
            AccelerationSet = 0x14,
            TargetSet = 0x15,
            TrajectorySet = 0x16,

            SetScore = 0xA0
        }

        public ServosCan(Board board)
        {
            _board = board;
            _framesCount = 0;

            _position = new Dictionary<int, int>();
            _positionMin = new Dictionary<int, int>();
            _positionMax = new Dictionary<int, int>();
            _speed = new Dictionary<int, int>();
            _torqueCurrent = new Dictionary<int, int>();
            _torqueMax = new Dictionary<int, int>();

            _receivedBuffer = new List<byte>();
            _lockAsk = new Semaphore(1, 1);

            if (!Execution.DesignMode)
            {
                Connections.BoardConnection[_board].FrameReceived += board_FrameReceived;

                Plateau.ScoreChange += Plateau_ScoreChange;
            }
        }

        private void Plateau_ScoreChange(object sender, EventArgs e)
        {
            SetScore(Plateau.Score);
        }

        private void board_FrameReceived(Frame frame)
        {
            if (frame[1] == (byte)FrameFunction.RetourUart2)
            {
                for (int i = 3; i < frame.Length; i++)
                    _receivedBuffer.Add(frame[i]);
            }

            if (_receivedBuffer.Count >= 10)
            {
                Frame canFrame = new Frame(_receivedBuffer.GetRange(0, 10));
                CanFrameReception(canFrame);
                _receivedBuffer.RemoveRange(0, 10);
            }
        }

        private void CanFrameReception(Frame frame)
        {
            int idCan = frame[0] * 256 + frame[1];
            int idServo = frame[4];

            try
            {
                int globalId = idCan * 4 + idServo;

                ServosCanFunctions function = (ServosCanFunctions)frame[3];

                switch (function)
                {
                    case ServosCanFunctions.PositionResponse:
                        if (!_position.ContainsKey(globalId)) _position.Add(globalId, 0);
                        _position[globalId] = frame[5] * 256 + frame[6];
                        _lockWaitResponse?.Release();
                        break;
                    case ServosCanFunctions.PositionMaxResponse:
                        if (!_positionMax.ContainsKey(globalId)) _positionMax.Add(globalId, 0);
                        _positionMax[globalId] = frame[5] * 256 + frame[6];
                        _lockWaitResponse?.Release();
                        break;
                    case ServosCanFunctions.PositionMinResponse:
                        if (!_positionMin.ContainsKey(globalId)) _positionMin.Add(globalId, 0);
                        _positionMin[globalId] = frame[5] * 256 + frame[6];
                        _lockWaitResponse?.Release();
                        break;
                    case ServosCanFunctions.SpeedResponse:
                        if (!_speed.ContainsKey(globalId)) _speed.Add(globalId, 0);
                        _speed[globalId] = frame[5] * 256 + frame[6];
                        _lockWaitResponse?.Release();
                        break;
                    case ServosCanFunctions.TorqueCurrentResponse:
                        if (!_torqueCurrent.ContainsKey(globalId)) _torqueCurrent.Add(globalId, 0);
                        _torqueCurrent[globalId] = frame[5] * 256 + frame[6];
                        _lockWaitResponse?.Release();
                        break;
                    case ServosCanFunctions.TorqueMaxResponse:
                        if (!_torqueMax.ContainsKey(globalId)) _torqueMax.Add(globalId, 0);
                        _torqueMax[globalId] = frame[5] * 256 + frame[6];
                        _lockWaitResponse?.Release();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + ":" + DateTime.Now.Millisecond.ToString("000") + " : Erreur servo CAN : " + e.Message);
            }
        }

        public int GetPosition(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.PositionAsk;
            tab[3] = (byte)(id % 4);

            SendFrame(new Frame(tab), true);

            return _position.ContainsKey(id) ? _position[id] : 0;
        }

        public int GetPositionMin(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.PositionMinAsk;
            tab[3] = (byte)(id % 4);

            SendFrame(new Frame(tab), true);

            return _positionMin.ContainsKey(id) ? _positionMin[id] : 0;
        }

        public int GetPositionMax(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.PositionMaxAsk;
            tab[3] = (byte)(id % 4);

            SendFrame(new Frame(tab), true);

            return _positionMax.ContainsKey(id) ? _positionMax[id] : 0;
        }

        public int GetSpeed(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.SpeedAsk;
            tab[3] = (byte)(id % 4);

            SendFrame(new Frame(tab), true);

            return _speed.ContainsKey(id) ? _speed[id] : 0;
        }

        public int GetTorqueCurrent(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.TorqueCurrentAsk;
            tab[3] = (byte)(id % 4);

            SendFrame(new Frame(tab), true);

            return _torqueCurrent.ContainsKey(id) ? _torqueCurrent[id] : 0;
        }

        public int GetTorqueMax(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.TorqueMaxAsk;
            tab[3] = (byte)(id % 4);

            SendFrame(new Frame(tab), true);

            return _torqueMax.ContainsKey(id) ? _torqueMax[id] : 0;
        }

        public void SetPosition(int id, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.PositionSet;
            tab[3] = (byte)(id % 4);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            SendFrame(new Frame(tab));
        }

        public void SetPositionMax(int id, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.PositionMaxSet;
            tab[3] = (byte)(id % 4);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            SendFrame(new Frame(tab));
        }

        public void SetPositionMin(int id, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.PositionMinSet;
            tab[3] = (byte)(id % 4);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            SendFrame(new Frame(tab));
        }

        public void SetSpeed(int id, int speed)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.SpeedSet;
            tab[3] = (byte)(id % 4);
            tab[4] = ByteDivide(speed, true);
            tab[5] = ByteDivide(speed, false);

            SendFrame(new Frame(tab));
        }

        public void SetTorqueMax(int id, int torque)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.TorqueMaxSet;
            tab[3] = (byte)(id % 4);
            tab[4] = ByteDivide(torque, true);
            tab[5] = ByteDivide(torque, false);

            SendFrame(new Frame(tab));
        }

        public void SetTrajectory(int id, int position, int speed, int accel)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)ServosCanFunctions.TrajectorySet;
            tab[3] = (byte)(id % 4);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            tab[6] = ByteDivide(speed, true);
            tab[7] = ByteDivide(speed, false);
            tab[8] = ByteDivide(accel, true);
            tab[9] = ByteDivide(accel, false);

            SendFrame(new Frame(tab));
        }

        public void SetScore(int score)
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = 0x04;
            tab[2] = (byte)ServosCanFunctions.SetScore;
            tab[3] = 0x00;
            tab[4] = ByteDivide(score, true);
            tab[5] = ByteDivide(score, false);

            SendFrame(new Frame(tab));
        }

        private void SendFrame(Frame f, bool waitResponse = false)
        {
            if (waitResponse)
            {
                _lockAsk.WaitOne();
                _lockWaitResponse = new Semaphore(0, 1);
            }

            Connections.BoardConnection[_board].SendMessage(FrameFactory.EnvoyerUart2(_board, f));
            _framesCount = (_framesCount + 1) % 255;

            if (waitResponse)
            {
                _lockWaitResponse.WaitOne(1000);
                _lockAsk.Release();
            }
        }

        private static byte ByteDivide(int valeur, bool mostSignifiantBit)
        {
            byte b;
            if (mostSignifiantBit)
                b = (byte)(valeur >> 8);
            else
                b = (byte)(valeur & 0x00FF);
            return b;
        }
    }
}
