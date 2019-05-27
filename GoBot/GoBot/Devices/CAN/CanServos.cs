using GoBot.Communications;
using GoBot.Communications.CAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoBot.Devices.CAN
{
    /// <summary>
    /// Dictionnaire à servomoteurs en bus CAN
    /// </summary>
    class CanServos
    {
        private Dictionary<int, CanServo> _servos;

        private CanConnection _communication;
        private List<CanBoard> _canBoards;

        public CanServos(CanConnection comm)
        {
            _communication = comm;
            _communication.FrameReceived += _communication_FrameReceived;

            _servos = new Dictionary<int, CanServo>();
            _canBoards = new List<CanBoard> { CanBoard.CanServo1, CanBoard.CanServo2, CanBoard.CanServo3, CanBoard.CanServo4, CanBoard.CanServo5 };
        }

        public CanServo this[int servoGlobalId]
        {
            get
            {
                if (!_servos.ContainsKey(servoGlobalId)) _servos.Add(servoGlobalId, new CanServo(servoGlobalId, _communication));
                return _servos[servoGlobalId];
            }
        }

        public CanServo this[ServomoteurID id]
        {
            get
            {
                return this[(int)id - 200];
            }
        }

        private void _communication_FrameReceived(Frame frame)
        {
            CanBoard idCan = CanFrameFactory.ExtractBoard(frame);

            if (_canBoards.Contains(idCan))
            {
                int servoGlobalId = CanFrameFactory.ExtractServoGlobalId(frame);

                if (!_servos.ContainsKey(servoGlobalId)) _servos.Add(servoGlobalId, new CanServo(servoGlobalId, _communication));

                _servos[servoGlobalId].FrameReceived(frame);
            }
        }
    }
}
