using GoBot.Communications;
using GoBot.Devices.CAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GoBot.Devices
{
    static class AllDevices
    {
        private static RecGoBot _recGoBot;
        private static CanServos _canServos;
        private static CanDisplay _canDisplay;
        private static Lidar _lidarGround, _lidarAvoid;

        public static void Init()
        {
            _recGoBot = new RecGoBot(Board.RecGB);
            _canServos = new CanServos(Connections.ConnectionCan);
            _canDisplay = new CanDisplay(Connections.ConnectionCan);
            _lidarGround = new HokuyoRec(LidarID.Ground);
            _lidarAvoid = new Pepperl(IPAddress.Parse("10.1.0.50"));
            ((Pepperl)_lidarAvoid).SetFrequency(PepperlFreq.Hz20);
            ((Pepperl)_lidarAvoid).SetFilter(PepperlFilter.Average, 3);
        }

        public static void Close()
        {
            _lidarAvoid.StopLoopMeasure();
            _lidarGround.StopLoopMeasure();
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

        public static Lidar LidarGround
        {
            get { return _lidarGround; }
            set { _lidarGround = value; }
        }

        public static Lidar LidarAvoid
        {
            get { return _lidarAvoid; }
            set { _lidarAvoid = value; }
        }

        public static CanDisplay CanDisplay
        {
            get { return _canDisplay; }
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
