using GoBot.BoardContext;
using GoBot.Devices;
using GoBot.GameElements;
using System;
using System.Collections.Generic;
using System.Drawing;

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

            //_elevatorLeft.FillWith(Buoy.Red);
            //_elevatorRight.FillWith(Buoy.Green);

            //_lifter.Load = new List<Color>(){ Buoy.Red, Buoy.Green, Buoy.Red, Buoy.Green, Buoy.Red};
        }

        public static FingerLeft FingerLeft { get => _fingerLeft; }
        public static FingerRight FingerRight { get => _fingerRight; }
        public static Flags Flags { get => _flags; }
        public static ElevatorRight ElevatorRight { get => _elevatorRight; }
        public static ElevatorLeft ElevatorLeft { get => _elevatorLeft; }
        public static Lifter Lifter { get => _lifter; }

        public static Elevator FindElevator(Color color)
        {
            if (color == Buoy.Red)
                return _elevatorLeft;
            else
                return _elevatorRight;
        }

    }
}
