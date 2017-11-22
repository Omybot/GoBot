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


        static Actionneur()
        {
            hokuyo = CreateHokuyo("COM3", LidarID.ScanSol);
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
    }
}
