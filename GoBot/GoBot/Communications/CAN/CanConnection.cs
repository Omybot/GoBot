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
    public interface iCanSpeakable
    {
        bool SendFrame(Frame frame);
        int GetNextFrameID();
    }

    public class CanConnection : Connection, iCanSpeakable
    {
        //TODO : CanConnection, héritier de Connection et transfert de la classe dans ../../Communications

        private int _framesCount;

        private Board _board;
        private List<byte> _receivedBuffer;

        private String _name;
        
        public CanConnection(Board board)
        {
            _board = board;
            _framesCount = 0;

            _receivedBuffer = new List<byte>();
            _name = board.ToString();
        }

        public override string Name { get => _name; set => _name = value; }

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
            }
        }

        bool iCanSpeakable.SendFrame(Frame frame)
        {
            return this.SendMessage(frame);
        }

        int iCanSpeakable.GetNextFrameID()
        {
            _framesCount = (_framesCount + 1) % 255;
            return _framesCount;
        }

        public override bool SendMessage(Frame f)
        {
            bool ok = true;
            
            Connections.UDPBoardConnection[_board].SendMessage(UdpFrameFactory.EnvoyerCAN(_board, f));
            OnFrameSend(f);

            _framesCount = (_framesCount + 1) % 255;
            
            return ok;
        }

        public override void StartReception()
        {
            Connections.UDPBoardConnection[_board].StartReception();
            Connections.UDPBoardConnection[_board].FrameReceived += board_FrameReceived;
        }

        public override void Close()
        {
            Connections.UDPBoardConnection[_board].FrameReceived -= board_FrameReceived;
        }
    }
}
