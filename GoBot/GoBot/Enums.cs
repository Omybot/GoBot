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

        Unused08 = 8,
        Unused09 = 9,
        Unused10 = 10,
        Unused11 = 11,

        Unused12 = 12,
        Unused13 = 13,
        FlagLeft = 14,
        PushArmLeft = 15,

        Unused16 = 16,
        Unused17 = 17,
        Unused18 = 18,
        Unused19 = 19,

        GrabberLeft = 20,
        FingerRight = 21,
        FingerLeft = 22,
        GrabberRight = 23,
    }

    public enum MotorID
    {
        FingerFront = 0x00, // RecIO
        FingerBack = 0x01, // RecIO
        AvailableOnRecIO2 = 0x02, // RecIO
        AvailableOnRecIO3 = 0x03, // RecIO

        Gulp = 0x11, // RecMove
        AvailableOnRecMove12 = 0x12 // RecMove
    }

    public enum ActuatorOnOffID
    {
        PowerSensorColorBuoyLeft = 0x00,
        PowerSensorColorBuoyRight = 0x01,
        MakeVacuumRightFront = 0x11,
        MakeVacuumLeftFront = 0x12,
        MakeVacuumRightBack = 0x13,
        MakeVacuumLeftBack = 0x14,
        OpenVacuumRightFront = 0x20,
        OpenVacuumLeftFront = 0x21,
        OpenVacuumRightBack = 0x22,
        OpenVacuumLeftBack = 0x23
    }

    public enum SensorOnOffID
    {
        StartTrigger = 0x10,
        PressureSensorRightFront = 0x11,
        PressureSensorLeftFront = 0x12,
        PressureSensorRightBack = 0x13,
        PressureSensorLeftBack = 0x14
    }

    public enum SensorColorID
    {
        BuoyLeft = 0,
        BuoyRight = 1
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
