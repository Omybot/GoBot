using GoBot.Devices;
using System;

namespace GoBot.Actionneurs
{
    static class Actionneur
    {
        private static Hokuyo _hokuyoGround, _hokuyoAvoid;


        static Actionneur()
        {
            _hokuyoGround = new HokuyoRec(LidarID.Ground);
            _hokuyoAvoid = CreateHokuyo("COM6", LidarID.Avoid); 
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
    }
}
