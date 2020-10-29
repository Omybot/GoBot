using System;
using GoBot.Actionneurs;

namespace GoBot
{
    public partial class Config
    {
        public ServoFlagLeft ServoFlagLeft { get; set; } = new ServoFlagLeft();
        public ServoFlagRight ServoFlagRight { get; set; } = new ServoFlagRight();

        public ServoPushArmRight ServoPushArmRight { get; set; } = new ServoPushArmRight();
        public ServoPushArmLeft ServoPushArmLeft { get; set; } = new ServoPushArmLeft();

        public ServoGrabberRight ServoGrabberRight { get; set; } = new ServoGrabberRight();
        public ServoGrabberLeft ServoGrabberLeft { get; set; } = new ServoGrabberLeft();

        public ServoFingerRight ServoFingerRight { get; set; } = new ServoFingerRight();
        public ServoFingerLeft ServoFingerLeft { get; set; } = new ServoFingerLeft();

        public ServoLockerRight ServoLockerRight { get; set; } = new ServoLockerRight();
        public ServoLockerLeft ServoLockerLeft { get; set; } = new ServoLockerLeft();

        public MotorElevatorRight MotorElevatorRight { get; set; } = new MotorElevatorRight();
        public MotorElevatorLeft MotorElevatorLeft { get; set; } = new MotorElevatorLeft();

        public ServoClamp1 ServoClamp1 { get; set; } = new ServoClamp1();
        public ServoClamp2 ServoClamp2 { get; set; } = new ServoClamp2();
        public ServoClamp3 ServoClamp3 { get; set; } = new ServoClamp3();
        public ServoClamp4 ServoClamp4 { get; set; } = new ServoClamp4();
        public ServoClamp5 ServoClamp5 { get; set; } = new ServoClamp5();

        public ServoLifter ServoLifter { get; set; } = new ServoLifter();
        public ServoTilter ServoTilter { get; set; } = new ServoTilter();
    }
}

namespace GoBot.Actionneurs
{
    #region PositionableServo

    public abstract class ServoFlag : PositionableServo
    {
        public int PositionOpen { get; set; }
        public int PositionClose { get; set; }
    }

    public class ServoFlagLeft : ServoFlag
    {
        public override ServomoteurID ID => ServomoteurID.FlagLeft;
    }

    public class ServoFlagRight : ServoFlag
    {
        public override ServomoteurID ID => ServomoteurID.FlagRight;
    }

    public abstract class ServoPushArm : PositionableServo
    {
        public int PositionOpen { get; set; }
        public int PositionClose { get; set; }
        public int PositionLight { get; set; }
    }

    public class ServoPushArmLeft : ServoPushArm
    {
        public override ServomoteurID ID => ServomoteurID.PushArmLeft;
    }

    public class ServoPushArmRight : ServoPushArm
    {
        public override ServomoteurID ID => ServomoteurID.PushArmRight;
    }

    public abstract class ServoFinger : PositionableServo
    {
        public int PositionHide { get; set; }
        public int PositionKeep { get; set; }
        public int PositionGrab { get; set; }
    }

    public class ServoFingerLeft : ServoFinger
    {
        public override ServomoteurID ID => ServomoteurID.FingerLeft;
    }

    public class ServoFingerRight : ServoFinger
    {
        public override ServomoteurID ID => ServomoteurID.FingerRight;
    }

    public abstract class ServoGrabber : PositionableServo
    {
        public int PositionOpen { get; set; }
        public int PositionClose { get; set; }
        public int PositionHide { get; set; }
        public int PositionRelease { get; set; }
    }

    public class ServoGrabberRight : ServoGrabber
    {
        public override ServomoteurID ID => ServomoteurID.GrabberRight;
    }

    public class ServoGrabberLeft : ServoGrabber
    {
        public override ServomoteurID ID => ServomoteurID.GrabberLeft;
    }

    public abstract class ServoLocker : PositionableServo
    {
        public int PositionEngage { get; set; }
        public int PositionDisengage { get; set; }
        public int PositionMaintain { get; set; }
    }

    public class ServoLockerRight : ServoLocker
    {
        public override ServomoteurID ID => ServomoteurID.LockerRight;
    }

    public class ServoLockerLeft : ServoLocker
    {
        public override ServomoteurID ID => ServomoteurID.LockerLeft;
    }

    public abstract class ServoClamp : PositionableServo
    {
        public int PositionOpen { get; set; }
        public int PositionMaintain { get; set; }
        public int PositionClose { get; set; }
        public int PositionStore { get; set; }
    }

    public class ServoClamp1 : ServoClamp
    {
        public override ServomoteurID ID => ServomoteurID.Clamp1;
    }

    public class ServoClamp2 : ServoClamp
    {
        public override ServomoteurID ID => ServomoteurID.Clamp2;
    }

    public class ServoClamp3 : ServoClamp
    {
        public override ServomoteurID ID => ServomoteurID.Clamp3;
    }

    public class ServoClamp4 : ServoClamp
    {
        public override ServomoteurID ID => ServomoteurID.Clamp4;
    }

    public class ServoClamp5 : ServoClamp
    {
        public override ServomoteurID ID => ServomoteurID.Clamp5;
    }

    public class ServoLifter : PositionableServo
    {
        public override ServomoteurID ID => ServomoteurID.Lifter;

        public int PositionStore { get; set; }
        public int PositionExtract { get; set; }
    }

    public class ServoTilter : PositionableServo
    {
        public override ServomoteurID ID => ServomoteurID.Tilter;

        public int PositionStore { get; set; }
        public int PositionPickup { get; set; }
        public int PositionExtract { get; set; }
        public int PositionDropoff { get; set; }
    }

    #endregion

    #region PositionableMotorSpeed

    #endregion

    #region PositionableMotorPosition

    public abstract class MotorElevator : PositionableMotorPosition
    {
        public int PositionFloor0 { get; set; }
        public int PositionFloor1 { get; set; }
        public int PositionFloor2 { get; set; }
        public int PositionFloor3 { get; set; }
    }

    public class MotorElevatorRight : MotorElevator
    {
        public override MotorID ID => MotorID.ElevatorRight;
    }

    public class MotorElevatorLeft : MotorElevator
    {
        public override MotorID ID => MotorID.ElevatorLeft;
    }

    #endregion
}
