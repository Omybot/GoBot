using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Communications.CAN
{
    class CanSubConnection : Connection
    {
        private CanConnection _baseConnection;
        private CanBoard _board;

        private String _name;

        public CanSubConnection(CanConnection baseConnection, CanBoard board)
        {
            _baseConnection = baseConnection;
            _board = board;
            ConnectionChecker = new ConnectionChecker(this, 500);
            ConnectionChecker.SendConnectionTest += ConnectionChecker_SendConnectionTest;
            _baseConnection.FrameReceived += _baseConnection_FrameReceived;

            _name = board.ToString();
        }

        public override string Name { get => _name; set => _name = value; }

        private void _baseConnection_FrameReceived(Frame frame)
        {
            if ((CanBoard) frame[1] == _board)
                ConnectionChecker.NotifyAlive();
        }

        private void ConnectionChecker_SendConnectionTest(Connection sender)
        {
            _baseConnection.SendMessage(CanFrameFactory.BuildGetPosition(4 * (int)_board - 1));
        }

        public override void Close()
        {
        }

        public override bool SendMessage(Frame message)
        {
            return _baseConnection.SendMessage(new Frame(new byte[] { 0, (byte)_board }.Concat(message.ToBytes())));
        }

        public override void StartReception()
        {

        }
    }
}
