using GoBot.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry.Shapes;

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
            _hokuyo = CreateHokuyo("COM5", LidarID.Detection);
            _dumper = new Dumper();
            _patternReader = new PatternReader();
            _servosCan = new ServosCan(Board.RecIO);
            _harvester = new Harvester();
        }

        public static Hokuyo CreateHokuyo(String portCom, LidarID id)
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
