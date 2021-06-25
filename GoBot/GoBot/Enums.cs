namespace GoBot
{
    public enum SensAR
    {
        Avant = 0,
        Arriere = 1
    }

    public enum SensGD
    {
        Gauche = 2,
        Droite = 3
    }

    public enum StopMode
    {
        Freely = 0x00,
        Smooth = 0x01,
        Abrupt = 0x02
    }

    public enum ServomoteurID
    {
        Unused00 = 0,
        LockerRight = 1,
        LockerLeft = 2,
        Unused03 = 3,

        PushArmRight = 4,
        FlagRight = 5,
        Unused06 = 6,
        Unused07 = 7,

        Clamp1 = 8,
        Clamp2 = 9,
        Tilter = 10,
        Lifter = 11,

        Unused12 = 12,
        Unused13 = 13,
        FlagLeft = 14,
        PushArmLeft = 15,

        Clamp3 = 16,
        Unused17 = 17,
        Clamp4 = 18,
        Clamp5 = 19,

        GrabberLeft = 20,
        FingerRight = 21,
        FingerLeft = 22,
        GrabberRight = 23,

        // Petit robot (astuce no >= 100 = modulo)
        ElevatorRight = 100,
        Unued101 = 101,
        ArmLeft = 102,
        ElevatorLeft = 103,

        ElevatorBack = 104,
        Retractor = 105,
        ArmRight = 106,
        Selector = 107
    }

    public enum MotorID
    {
        ElevatorLeft = 0x00,
        ElevatorRight = 0x01,
        AvailableOnRecIO2 = 0x02,
        AvailableOnRecIO3 = 0x03,

        AvailableOnRecMove11 = 0x11,
        AvailableOnRecMove12 = 0x12
    }

    public enum ActuatorOnOffID
    {
        PowerSensorColorBuoyRight = 0x00,
        PowerSensorColorBuoyLeft = 0x01,
        MakeVacuumRightFront = 0x11,
        MakeVacuumLeftFront = 0x12,
        MakeVacuumRightBack = 0x13,
        MakeVacuumLeftBack = 0x14,
        OpenVacuumRightFront = 0x21,
        OpenVacuumLeftFront = 0x20,
        OpenVacuumRightBack = 0x22,
        OpenVacuumLeftBack = 0x23,

        // Petit robot
        MakeVacuumLeft = 0x24,
        MakeVacuumRight = 0x25,
        MakeVacuumBack = 0x26,
        OpenVacuumLeft = 0x27,
        OpenVacuumRight = 0x28,
        OpenVacuumBack = 0x29
    }

    public enum SensorOnOffID
    {
        StartTrigger = 0x10,
        PressureSensorRightFront = 0x11,
        PressureSensorLeftFront = 0x12,
        PressureSensorRightBack = 0x13,
        PressureSensorLeftBack = 0x14,
        PresenceBuoyRight = 0x20,

        // Petit robot
        PressureSensorLeft = 0x21,
        PressureSensorRight = 0x22,
        PressureSensorBack = 0x23
    }

    public enum SensorColorID
    {
        BuoyRight = 0,
        BuoyLeft = 1
    }

    public enum CodeurID
    {
        Manuel = 1
    }

    public enum BaliseID
    {
        Principale = 0
    }

    public enum LidarID
    {
        Ground = 0,
        Avoid = 1
    }

    public enum Board
    {
        PC = 0xA1,
        RecMove = 0xC1,
        RecIO = 0xC4,
        RecCan = 0xC5
    }

    public enum ServoBaudrate
    {
        b1000000 = 1,
        b500000 = 3,
        b400000 = 4,
        b250000 = 7,
        b200000 = 9,
        b115200 = 16,
        b57600 = 34,
        b19200 = 103,
        b9600 = 207
    }

    public static class EnumExtensions
    {
        public static int Factor(this SensAR sens)
        {
            return sens == SensAR.Avant ? 1 : -1;
        }

        public static int Factor(this SensGD sens)
        {
            return sens == SensGD.Droite ? 1 : -1;
        }
    }
}
