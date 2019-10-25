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
        private Dictionary<ServomoteurID, CanServo> _servos;

        private CanConnection _communication;
        private List<CanBoard> _canBoards;

        public CanServos(CanConnection comm)
        {
            _communication = comm;
            _communication.FrameReceived += _communication_FrameReceived;

            _servos = new Dictionary<ServomoteurID, CanServo>();
            _canBoards = new List<CanBoard> { CanBoard.CanServo1, CanBoard.CanServo2, CanBoard.CanServo3, CanBoard.CanServo4, CanBoard.CanServo5, CanBoard.CanServo6 };
        }

        public CanServo this[ServomoteurID servoGlobalId]
        {
            get
            {
                if (!_servos.ContainsKey(servoGlobalId)) _servos.Add(servoGlobalId, new CanServo(servoGlobalId, _communication));
                return _servos[servoGlobalId];
            }
        }

        private void _communication_FrameReceived(Frame frame)
        {
            try
            {
                CanBoard idCan = CanFrameFactory.ExtractBoard(frame);

                if (_canBoards.Contains(idCan))
                {
                    ServomoteurID servoGlobalId = CanFrameFactory.ExtractServomoteurID(frame);

                    if (!_servos.ContainsKey(servoGlobalId)) _servos.Add(servoGlobalId, new CanServo(servoGlobalId, _communication));

                    _servos[servoGlobalId].FrameReceived(frame);
                }
            }
            catch (Exception e)
            {

            }
        }

        public void DisableAll()
        {
            _servos.Values.ToList().ForEach(o => o.DisableOutput());
        }
    }
}
