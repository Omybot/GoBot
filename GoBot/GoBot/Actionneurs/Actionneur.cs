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
        private static Hokuyo _hokuyoGround, _hokuyoAvoid;
        private static ServosCan _servosCan;


        static Actionneur()
        {
            _hokuyoGround = new HokuyoRec(LidarID.Ground);
            _hokuyoAvoid = CreateHokuyo("COM5", LidarID.Avoid); 
            _servosCan = new ServosCan(Board.RecIO);
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

        public static ServosCan ServosCan
        {
            get { return _servosCan; }
            set { _servosCan = value; }
        }
    }
}
