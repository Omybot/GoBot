using GoBot.Communications;
using GoBot.Communications.UDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Communications.CAN
{
    /// <summary>
    /// Définit un objet capable d'envoyer des messages CAN
    /// </summary>
    interface iCanSpeakable
    {
        bool SendFrame(Frame frame, bool waitResponse);
        int GetNextFrameID();
    }

    class CanConnection : Connection, iCanSpeakable
    {
        //TODO : CanConnection, héritier de Connection et transfert de la classe dans ../../Communications

        private int _framesCount;

        private Board _board;
        private List<byte> _receivedBuffer;

        private Semaphore _lockAsk;
        private Semaphore _lockWaitResponse;
        
        public CanConnection(Board board)
        {
            _board = board;
            _framesCount = 0;

            _receivedBuffer = new List<byte>();
            _lockAsk = new Semaphore(1, 1);

            if (!Execution.DesignMode)
            {
                Connections.BoardConnection[_board].FrameReceived += board_FrameReceived;
            }
        }

        private void board_FrameReceived(Frame frame)
        {
            if (frame[1] == (byte)UdpFrameFunction.ReponseCAN)
            {
                for (int i = 3; i < frame.Length; i++)
                    _receivedBuffer.Add(frame[i]);
            }

            if (_receivedBuffer.Count >= 10)
            {
                Frame canFrame = new Frame(_receivedBuffer.GetRange(0, 10));
                _receivedBuffer.RemoveRange(0, 10);
                OnFrameReceived(canFrame);
                _lockWaitResponse?.Release();
            }
        }

        bool iCanSpeakable.SendFrame(Frame frame, bool waitResponse)
        {
            return this.SendMessage(frame, waitResponse);
        }

        int iCanSpeakable.GetNextFrameID()
        {
            _framesCount = (_framesCount + 1) % 255;
            return _framesCount;
        }

        public override bool SendMessage(Frame f)
        {
            return SendMessage(f, false);
        }

        public bool SendMessage(Frame f, bool waitResponse)
        {
            bool ok = true;

            if (waitResponse)
            {
                _lockAsk.WaitOne();
                _lockWaitResponse = new Semaphore(0, 1);
            }

            Connections.BoardConnection[_board].SendMessage(UdpFrameFactory.EnvoyerCAN(_board, f));
            OnFrameSend(f);

            _framesCount = (_framesCount + 1) % 255;

            if (waitResponse)
            {
                ok = _lockWaitResponse.WaitOne(1000);
                _lockWaitResponse.Dispose();
                _lockWaitResponse = null;
                _lockAsk.Release();
            }

            return ok;
        }

        public override void StartReception()
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }
    }
}
