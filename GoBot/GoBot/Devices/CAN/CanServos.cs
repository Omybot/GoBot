using GoBot.Communications;
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

        private CanCommunication _communication;
        private List<CanBoard> _canBoards;

        public CanServos(CanCommunication comm)
        {
            _communication = comm;
            _communication.FrameReceived += _communication_FrameReceived;

            _servos = new Dictionary<int, CanServo>();
            _canBoards = new List<CanBoard> { CanBoard.Servo1, CanBoard.Servo2, CanBoard.Servo3 };
        }

        public CanServo this[int servoGlobalId]
        {
            get
            {
                if (!_servos.ContainsKey(servoGlobalId)) _servos.Add(servoGlobalId, new CanServo(servoGlobalId, _communication));
                return _servos[servoGlobalId];
            }
        }

        private void _communication_FrameReceived(Frame frame)
        {
            CanBoard idCan = CanFrameFactory.ExtractCanBoard(frame);

            if (_canBoards.Contains(idCan))
            {
                int servoGlobalId = CanFrameFactory.ExtractServoGlobalId(frame);

                if (!_servos.ContainsKey(servoGlobalId)) _servos.Add(servoGlobalId, new CanServo(servoGlobalId, _communication));

                _servos[servoGlobalId].FrameReceived(frame);
            }
        }
    }
}
