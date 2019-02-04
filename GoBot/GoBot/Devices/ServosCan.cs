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

        private void Plateau_ScoreChange(object sender, EventArgs e)    // On renomme le fichier ServoCAN ? ou bien un autre fichier pour l'affichage ? classe noeud CAN et ServosCan + AffichageCAN qui héritent ?
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
            int idCan = frame[0] * 256 + frame[1];                                      // Récupération Id de la trame CAN
            ServosCanFunctions function = (ServosCanFunctions)frame[2];                 // Récupération de la commande de la trame CAN
            int idServo = frame[3];                                                     // Récupération du numéro de servo de la carte

            int globalServoId = (idCan-1) * 4 + idServo;                                // Reconstruction du numéro global du servo (un Id CAN par carte servo != 0 et 4 servos par carte N°0 à 3)

            try
            {
                switch (function)
                {
                    case ServosCanFunctions.PositionResponse:
                        if (!_position.ContainsKey(globalServoId)) _position.Add(globalServoId, 0);
                        _position[globalServoId] = frame[4] * 256 + frame[5];
                        _lockWaitResponse?.Release();
                        break;
                    case ServosCanFunctions.PositionMaxResponse:
                        if (!_positionMax.ContainsKey(globalServoId)) _positionMax.Add(globalServoId, 0);
                        _positionMax[globalServoId] = frame[4] * 256 + frame[5];
                        _lockWaitResponse?.Release();
                        break;
                    case ServosCanFunctions.PositionMinResponse:
                        if (!_positionMin.ContainsKey(globalServoId)) _positionMin.Add(globalServoId, 0);
                        _positionMin[globalServoId] = frame[4] * 256 + frame[5];
                        _lockWaitResponse?.Release();
                        break;
                    case ServosCanFunctions.SpeedResponse:
                        if (!_speed.ContainsKey(globalServoId)) _speed.Add(globalServoId, 0);
                        _speed[globalServoId] = frame[4] * 256 + frame[5];
                        _lockWaitResponse?.Release();
                        break;
                    case ServosCanFunctions.TorqueCurrentResponse:
                        if (!_torqueCurrent.ContainsKey(globalServoId)) _torqueCurrent.Add(globalServoId, 0);
                        _torqueCurrent[globalServoId] = frame[4] * 256 + frame[5];
                        _lockWaitResponse?.Release();
                        break;
                    case ServosCanFunctions.TorqueMaxResponse:
                        if (!_torqueMax.ContainsKey(globalServoId)) _torqueMax.Add(globalServoId, 0);
                        _torqueMax[globalServoId] = frame[4] * 256 + frame[5];
                        _lockWaitResponse?.Release();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + ":" + DateTime.Now.Millisecond.ToString("000") + " : Erreur servo CAN : " + e.Message);
            }
        }

        public int GetPosition(int globalServoId)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.PositionAsk;
            tab[3] = (byte)(globalServoId % 4);

            bool ok = SendFrame(new Frame(tab), true);

            return ok ? (_position.ContainsKey(globalServoId) ? _position[globalServoId] : 0) : -1;
        }

        public int GetPositionMin(int globalServoId)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.PositionMinAsk;
            tab[3] = (byte)(globalServoId % 4);

            bool ok = SendFrame(new Frame(tab), true);

            return ok ? (_positionMin.ContainsKey(globalServoId) ? _positionMin[globalServoId] : 0) : -1;
        }

        public int GetPositionMax(int globalServoId)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.PositionMaxAsk;
            tab[3] = (byte)(globalServoId % 4);

            bool ok = SendFrame(new Frame(tab), true);

            return ok ? (_positionMax.ContainsKey(globalServoId) ? _positionMax[globalServoId] : 0) : -1;
        }

        public int GetSpeed(int globalServoId)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.SpeedAsk;
            tab[3] = (byte)(globalServoId % 4);

            bool ok = SendFrame(new Frame(tab), true);

            return ok ? (_speed.ContainsKey(globalServoId) ? _speed[globalServoId] : 0) : -1;
        }

        public int GetTorqueCurrent(int globalServoId)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.TorqueCurrentAsk;
            tab[3] = (byte)(globalServoId % 4);

            bool ok = SendFrame(new Frame(tab), true);

            return ok ? (_torqueCurrent.ContainsKey(globalServoId) ? _torqueCurrent[globalServoId] : 0) : -1;
        }

        public int GetTorqueMax(int globalServoId)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.TorqueMaxAsk;
            tab[3] = (byte)(globalServoId % 4);

            bool ok = SendFrame(new Frame(tab), true);

            return ok ? (_torqueMax.ContainsKey(globalServoId) ? _torqueMax[globalServoId] : 0) : -1;
        }

        public void SetPosition(int globalServoId, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.PositionSet;
            tab[3] = (byte)(globalServoId % 4);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            SendFrame(new Frame(tab));
        }

        public void SetPositionMax(int globalServoId, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.PositionMaxSet;
            tab[3] = (byte)(globalServoId % 4);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            SendFrame(new Frame(tab));
        }

        public void SetPositionMin(int globalServoId, int position)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.PositionMinSet;
            tab[3] = (byte)(globalServoId % 4);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);

            SendFrame(new Frame(tab));
        }

        public void SetSpeed(int globalServoId, int speed)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.SpeedSet;
            tab[3] = (byte)(globalServoId % 4);
            tab[4] = ByteDivide(speed, true);
            tab[5] = ByteDivide(speed, false);

            SendFrame(new Frame(tab));
        }

        public void SetTorqueMax(int globalServoId, int torque)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.TorqueMaxSet;
            tab[3] = (byte)(globalServoId % 4);
            tab[4] = ByteDivide(torque, true);
            tab[5] = ByteDivide(torque, false);

            SendFrame(new Frame(tab));
        }

        public void SetTrajectory(int globalServoId, int position, int speed, int accel)
        {
            byte[] tab = new byte[10];

            tab[0] = ByteDivide(globalServoId / 4 + 1, true);
            tab[1] = ByteDivide(globalServoId / 4 + 1, false);
            tab[2] = (byte)ServosCanFunctions.TrajectorySet;
            tab[3] = (byte)(globalServoId % 4);
            tab[4] = ByteDivide(position, true);
            tab[5] = ByteDivide(position, false);
            tab[6] = ByteDivide(speed, true);
            tab[7] = ByteDivide(speed, false);
            tab[8] = ByteDivide(accel, true);
            tab[9] = ByteDivide(accel, false);

            SendFrame(new Frame(tab));
        }

        public void SetScore(int score)                         // (Même remarque^^) On renomme le fichier ServoCAN ? ou bien un autre fichier pour l'affichage ? classe noeud CAN et ServosCan + AffichageCAN qui héritent ?
        {
            byte[] tab = new byte[10];

            tab[0] = 0x00;
            tab[1] = 0x04;                                      // Id de la carte qui affiche le score ...
            tab[2] = (byte)ServosCanFunctions.SetScore;
            tab[3] = 0x00;
            tab[4] = ByteDivide(score, true);
            tab[5] = ByteDivide(score, false);

            SendFrame(new Frame(tab));
        }

        private bool SendFrame(Frame f, bool waitResponse = false)
        {
            bool ok = true;

            if (waitResponse)
            {
                _lockAsk.WaitOne();
                _lockWaitResponse = new Semaphore(0, 1);
            }

            Connections.BoardConnection[_board].SendMessage(FrameFactory.EnvoyerUart2(_board, f));
            _framesCount = (_framesCount + 1) % 255;

            if (waitResponse)
            {
                ok = _lockWaitResponse.WaitOne(1000);
                _lockAsk.Release();
            }

            return ok;
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
