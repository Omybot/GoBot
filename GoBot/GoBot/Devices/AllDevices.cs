using GoBot.Communications;
using GoBot.Devices.CAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Devices
{
    static class AllDevices
    {
        private static RecGoBot _recGoBot;
        private static CanServos _canServos;
        private static CanDisplay _canDisplay;
        private static Hokuyo _hokuyoGround, _hokuyoAvoid;

        public static void Init()
        {
            _recGoBot = new RecGoBot(Board.RecGB);
            _canServos = new CanServos(Connections.ConnectionCan);
            _canDisplay = new CanDisplay(Connections.ConnectionCan);
            _hokuyoGround = new HokuyoRec(LidarID.Ground);
            _hokuyoAvoid = CreateHokuyo("COM7", LidarID.Avoid);
        }

        public static RecGoBot RecGoBot
        {
            get
            {
                return _recGoBot;
            }
        }

        public static CanServos CanServos
        {
            get
            {
                return _canServos;
            }
        }

        public static Hokuyo HokuyoGround
        {
            get { return _hokuyoGround; }
            set { _hokuyoGround = value; }
        }

        public static Hokuyo HokuyoAvoid
        {
            get { return _hokuyoAvoid; }
            set { _hokuyoAvoid = value; }
        }

        private static Hokuyo CreateHokuyo(String portCom, LidarID id)
        {
            Hokuyo hok = null;

            try
            {
                hok = new Hokuyo(id, portCom);
            }
            catch (Exception)
            {
            }

            return hok;
        }
    }
}
