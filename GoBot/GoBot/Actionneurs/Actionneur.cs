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
        private static ElevatorLeft _elevatorLeft;
        private static Lifter _lifter;

        public static void Init()
        {
            _flags = new Flags();
            _fingerLeft = new FingerLeft();
            _fingerRight = new FingerRight();
            _elevatorRight = new ElevatorRight();
            _elevatorLeft = new ElevatorLeft();
            _lifter = new Lifter();
        }

        public static FingerLeft FingerLeft { get => _fingerLeft; }
        public static FingerRight FingerRight { get => _fingerRight; }
        public static Flags Flags { get => _flags; }
        public static ElevatorRight ElevatorRight { get => _elevatorRight; }
        public static ElevatorLeft ElevatorLeft { get => _elevatorLeft; }
        public static Lifter Lifter { get => _lifter; }
    }
}
