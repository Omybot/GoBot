using GoBot.Devices;
using System;

namespace GoBot.Actionneurs
{
    static class Actionneur
    {
        private static AtomHandler _atomHandler;
        private static AtomStacker _atomStacker;
        private static AtomUnloader _atomUnloaderLeft, _atomUnloaderRight;
        private static GoldGrabber _goldGrabberLeft, _goldGrabberRight;

        static Actionneur()
        {
            _atomHandler = new AtomHandler();
            _atomStacker = new AtomStacker();
            _atomUnloaderLeft = new AtomUnloaderLeft();
            _atomUnloaderRight = new AtomUnloaderRight();
            _goldGrabberLeft = new GoldGrabberLeft();
            _goldGrabberRight = new GoldGrabberRight();
        }

        public static AtomHandler AtomHandler
        {
            get { return _atomHandler; }
            set { _atomHandler = value; }
        }

        public static AtomStacker AtomStacker
        {
            get { return _atomStacker; }
            set { _atomStacker = value; }
        }

        public static AtomUnloader AtomUnloaderLeft
        {
            get { return _atomUnloaderLeft; }
            set { _atomUnloaderLeft = value; }
        }

        public static AtomUnloader AtomUnloaderRight
        {
            get { return _atomUnloaderRight; }
            set { _atomUnloaderRight = value; }
        }

        public static GoldGrabber GoldGrabberLeft
        {
            get { return _goldGrabberLeft; }
            set { _goldGrabberLeft = value; }
        }

        public static GoldGrabber GoldGrabberRight
        {
            get { return _goldGrabberRight; }
            set { _goldGrabberRight = value; }
        }
    }
}
