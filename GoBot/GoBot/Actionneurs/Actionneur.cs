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
        private static Hokuyo hokuyo;
        private static Dumper dumper;
        private static PatternReader patternReader;
        private static ServosCan servosCan;


        static Actionneur()
        {
            hokuyo = CreateHokuyo("COM3", LidarID.ScanSol);
            dumper = new Dumper();
            patternReader = new PatternReader();
            servosCan = new ServosCan(Board.RecIO);
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
            get { return hokuyo; }
            set { hokuyo = value; }
        }

        public static Dumper Dumper
        {
            get { return dumper; }
            set { dumper = value; }
        }

        public static PatternReader PatternReader
        {
            get { return patternReader; }
            set { patternReader = value; }
        }

        public static ServosCan ServosCan
        {
            get { return servosCan; }
            set { servosCan = value; }
        }
    }
}
