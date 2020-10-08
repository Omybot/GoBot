using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot.Actionneurs
{
    abstract class Elevator
    {
        public abstract void DoInitElevator();
        public abstract void DoPositionPushInside();
        public abstract void DoPositionPushOutside();
        public abstract void DoPositionElevatorFloor0();
        public abstract void DoPositionElevatorFloor1();
        public abstract void DoPositionElevatorFloor2();
        public abstract void DoPositionElevatorFloor3();
        public abstract void DoLockAir();
        public abstract void DoUnlockAir();
        public abstract bool HasSomething();
    }
}
