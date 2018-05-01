using GoBot.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoBot.Actionneurs
{
    class ServosCan
    {
        private int _framesCount;

        private Dictionary<int, int> _canIdFromServoId;
        private Dictionary<int, int> _positions;

        private Board _board;
        private List<byte> _receivedBuffer;

        private Semaphore _lockAsk;
        private Semaphore _lockWaitResponse;

        private enum ServosCanFunctions
        {
            SetPosition = 0,
            GetPosition = 1
        }

        public ServosCan(Board board)
        {
            _board = board;
            _framesCount = 0;

            _canIdFromServoId = new Dictionary<int, int>();
            _positions = new Dictionary<int, int>();

            AddServo(0, 1);

            _receivedBuffer = new List<byte>();
            _lockAsk = new Semaphore(1, 1);

            Connections.BoardConnection[_board].FrameReceived += board_FrameReceived;
        }

        private void AddServo(int idServo, int idCan)
        {
            _positions.Add(idServo, 0);
            _canIdFromServoId.Add(idServo, idCan);
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
            int id = frame[4];
            ServosCanFunctions function = (ServosCanFunctions)frame[3];

            switch(function)
            {
                case ServosCanFunctions.GetPosition:
                    _positions[id] = frame[5] * 256 + frame[6];
                    _lockWaitResponse.Release();
                    Console.WriteLine("Release " + id.ToString() + " at " + _positions[id]);
                    break;
            }
        }

        public int GetPosition(int id)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(_canIdFromServoId[id], true);
            tab[1] = ByteDivide(_canIdFromServoId[id], false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.GetPosition;
            tab[4] = (byte)id;
            tab[5] = 0;
            tab[6] = 0;
            tab[7] = 0;
            tab[8] = 0;
            tab[9] = Checksum(tab);
            
            SendFrame(new Frame(tab), true);
            
            return _positions[id];
        }

        public void SetPosition(int id, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(_canIdFromServoId[id], true);
            tab[1] = ByteDivide(_canIdFromServoId[id], false);
            tab[2] = (byte)_framesCount;
            tab[3] = (byte)ServosCanFunctions.SetPosition;
            tab[4] = (byte)id;
            tab[5] = ByteDivide(position, true);
            tab[6] = ByteDivide(position, false);
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
