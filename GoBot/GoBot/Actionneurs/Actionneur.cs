using GoBot.Devices;
using System;

namespace GoBot.Actionneurs
{
    static class Actionneur
    {
        private static Flags _flags;
        private static FingerLeft _fingerLeft;
        private static FingerRight _fingerRight;
        private static ElevatorRight _elevatorRight;

        public static void Init()
        {
            _flags = new Flags();
            _fingerLeft = new FingerLeft();
            _fingerRight = new FingerRight();
            _elevatorRight = new ElevatorRight();
        }

        public static FingerLeft FingerLeft { get => _fingerLeft; }
        public static FingerRight FingerRight { get => _fingerRight; }
        public static Flags Flags { get => _flags; }
        public static ElevatorRight ElevatorRight { get => _elevatorRight; }
    }
}
