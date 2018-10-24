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
        private static ServosCan _servosCan;


        static Actionneur()
        {
            _hokuyo = CreateHokuyo("COM6", LidarID.Detection);
            _servosCan = new ServosCan(Board.RecIO);
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
        
        public static ServosCan ServosCan
        {
            get { return _servosCan; }
            set { _servosCan = value; }
        }
    }
}
