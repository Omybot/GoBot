using GoBot.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Geometry.Shapes;

namespace GoBot.Actionneurs
{
    static class Actionneur
    {
        private static Hokuyo _hokuyo;
        private static Dumper _dumper;
        private static PatternReader _patternReader;
        private static ServosCan _servosCan;
        private static Harvester _harvester;


        static Actionneur()
        {
            _hokuyo = CreateHokuyo("COM3", LidarID.ScanSol);
            _dumper = new Dumper();
            _patternReader = new PatternReader();
            _servosCan = new ServosCan(Board.RecIO);
            _harvester = new Harvester();
        }

        public static Hokuyo CreateHokuyo(String portCom, LidarID id)
        {
            bool forceUart = false;
            bool forceUsb = false;

            if (forceUart)
                return new HokuyoUart(id);
            else if (forceUsb)
                return new HokuyoUsb(portCom, id);

            Hokuyo hok;

            try
            {
                hok = new HokuyoUsb(portCom, id);
                return hok;
            }
            catch (Exception)
            {
                hok = new HokuyoUart(id);
                return hok;
            }
        }

        public static Hokuyo Hokuyo
        {
            get { return _hokuyo; }
            set { _hokuyo = value; }
        }

        public static Dumper Dumper
        {
            get { return _dumper; }
            set { _dumper = value; }
        }

        public static PatternReader PatternReader
        {
            get { return _patternReader; }
            set { _patternReader = value; }
        }

        public static ServosCan ServosCan
        {
            get { return _servosCan; }
            set { _servosCan = value; }
        }

        public static Harvester Harvester
        {
            get { return _harvester; }
            set { _harvester = value; }
        }
    }
}
