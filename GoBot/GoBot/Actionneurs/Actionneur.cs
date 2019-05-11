﻿using GoBot.Devices;
using System;

namespace GoBot.Actionneurs
{
    static class Actionneur
    {
        private static Hokuyo _hokuyoGround, _hokuyoAvoid;
        private static AtomHandler _atomHandler;
        private static AtomStacker _atomStacker;


        static Actionneur()
        {
            _hokuyoGround = new HokuyoRec(LidarID.Ground);
            _hokuyoAvoid = CreateHokuyo("COM6", LidarID.Avoid);
            _atomHandler = new AtomHandler();
            _atomStacker = new AtomStacker();
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

        public static AtomHandler AtomHandler
        {
            get { return _atomHandler; }
            set { _atomHandler = value; }
        }

        public static AtomStacker AtomStacker
        {
            get { return _atomStacker; }
            set { _atomStacker= value; }
        }
    }
}
