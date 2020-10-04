using GoBot.Devices;
using System;

namespace GoBot.Actionneurs
{
    static class Actionneur
    {
        private static Flags _flags;

        public static void Init()
        {
            _flags = new Flags();
        }

        public static Flags Flags
        {
            get { return _flags; }
        }
    }
}
