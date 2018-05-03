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
            TorqueCurrentResponse = 0x11
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

            Connections.BoardConnection[_board].FrameReceived += board_FrameReceived;
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

            int globalId = (idCan - 1) * 4 + idServo;

            ServosCanFunctions function = (ServosCanFunctions)frame[3];

            switch(function)
            {
                case ServosCanFunctions.PositionResponse:
                    if (!_position.ContainsKey(globalId)) _position.Add(globalId, 0);
                    _position[globalId] = frame[5] * 256 + frame[6];
                    _lockWaitResponse.Release();
                    break;
                case ServosCanFunctions.PositionMaxResponse:
                    if (!_positionMax.ContainsKey(globalId)) _positionMax.Add(globalId, 0);
                    _positionMax[globalId] = frame[5] * 256 + frame[6];
                    _lockWaitResponse.Release();
                    break;
                case ServosCanFunctions.PositionMinResponse:
                    if (!_positionMin.ContainsKey(globalId)) _positionMin.Add(globalId, 0);
                    _positionMin[globalId] = frame[5] * 256 + frame[6];
                    _lockWaitResponse.Release();
                    break;
                case ServosCanFunctions.SpeedResponse:
                    if (!_speed.ContainsKey(globalId)) _speed.Add(globalId, 0);
                    _speed[globalId] = frame[5] * 256 + frame[6];
                    _lockWaitResponse.Release();
                    break;
                case ServosCanFunctions.TorqueCurrentResponse:
                    if (!_torqueCurrent.ContainsKey(globalId)) _torqueCurrent.Add(globalId, 0);
                    _torqueCurrent[globalId] = frame[5] * 256 + frame[6];
                    _lockWaitResponse.Release();
                    break;
                case ServosCanFunctions.TorqueMaxResponse:
                    if (!_torqueMax.ContainsKey(globalId)) _torqueMax.Add(globalId, 0);
                    _torqueMax[globalId] = frame[5] * 256 + frame[6];
                    _lockWaitResponse.Release();
                    break;
            }
        }

        public int GetPosition(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.PositionAsk;
            tab[4] = (byte)(id % 4);
            tab[5] = 0;
            tab[6] = 0;
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

            SendFrame(new Frame(tab), true);

            return _position[id];
        }

        public int GetPositionMin(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.PositionMinAsk;
            tab[4] = (byte)(id % 4);
            tab[5] = 0;
            tab[6] = 0;
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

            SendFrame(new Frame(tab), true);

            return _position[id];
        }

        public int GetPositionMax(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.PositionMaxAsk;
            tab[4] = (byte)(id % 4);
            tab[5] = 0;
            tab[6] = 0;
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

            SendFrame(new Frame(tab), true);

            return _position[id];
        }

        public int GetSpeed(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.SpeedAsk;
            tab[4] = (byte)(id % 4);
            tab[5] = 0;
            tab[6] = 0;
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

            SendFrame(new Frame(tab), true);

            return _position[id];
        }

        public int GetTorqueCurrent(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.TorqueCurrentAsk;
            tab[4] = (byte)(id % 4);
            tab[5] = 0;
            tab[6] = 0;
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

            SendFrame(new Frame(tab), true);

            return _position[id];
        }

        public int GetTorqueMax(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.TorqueMaxAsk;
            tab[4] = (byte)(id % 4);
            tab[5] = 0;
            tab[6] = 0;
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

            SendFrame(new Frame(tab), true);

            return _position[id];
        }

        public void SetPosition(int id, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.PositionSet;
            tab[4] = (byte)(id % 4);
            tab[5] = ByteDivide(position, true);
            tab[6] = ByteDivide(position, false);
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

            SendFrame(new Frame(tab));
        }

        public void SetPositionMax(int id, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.PositionMaxSet;
            tab[4] = (byte)(id % 4);
            tab[5] = ByteDivide(position, true);
            tab[6] = ByteDivide(position, false);
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

            SendFrame(new Frame(tab));
        }

        public void SetPositionMin(int id, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.PositionMinSet;
            tab[4] = (byte)(id % 4);
            tab[5] = ByteDivide(position, true);
            tab[6] = ByteDivide(position, false);
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

            SendFrame(new Frame(tab));
        }

        public void SetSpeed(int id, int speed)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.SpeedSet;
            tab[4] = (byte)(id % 4);
            tab[5] = ByteDivide(speed, true);
            tab[6] = ByteDivide(speed, false);
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

            SendFrame(new Frame(tab));
        }

        public void SetTorqueMax(int id, int torque)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(id / 4, true);
            tab[1] = ByteDivide(id / 4, false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.TorqueMaxSet;
            tab[4] = (byte)(id % 4);
            tab[5] = ByteDivide(torque, true);
            tab[6] = ByteDivide(torque, false);
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);

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

        private byte Checksum(IEnumerable<byte> data)
        {
            byte sum = 0;

            foreach (byte b in data)
                sum ^= b;

            return sum;
        }
    }
}
