using System;
using GoBot.Actionneurs;

namespace GoBot
{
    public partial class Config
    {
        public ServoClampLeft ServoClampLeft { get; set; } = new ServoClampLeft();
        public ServoClampRight ServoClampRight { get; set; } = new ServoClampRight();
        public ServoElevation ServoElevation { get; set; } = new ServoElevation();

        public ServoClampGoldLeft ServoClampGoldLeft { get; set; } = new ServoClampGoldLeft();
        public ServoElevationGoldLeft ServoElevationGoldLeft { get; set; } = new ServoElevationGoldLeft();

        public ServoClampGoldRight ServoClampGoldRight { get; set; } = new ServoClampGoldRight();
        public ServoElevationGoldRight ServoElevationGoldRight { get; set; } = new ServoElevationGoldRight();

        public ServoCalibrationLeft ServoCalibrationLeft { get; set; } = new ServoCalibrationLeft();
        public ServoCalibrationRight ServoCalibrationRight { get; set; } = new ServoCalibrationRight();

        public ServoLauncherLeft ServoLauncherLeft { get; set; } = new ServoLauncherLeft();
        public ServoLauncherRight ServoLauncherRight { get; set; } = new ServoLauncherRight();

        public ServoExitLauncherLeft ServoExitLauncherLeft { get; set; } = new ServoExitLauncherLeft();
        public ServoExitLauncherRight ServoExitLauncherRight { get; set; } = new ServoExitLauncherRight();

        public ServoFingerFront ServoFingerFront { get; set; } = new ServoFingerFront();
        public ServoFingerBack ServoFingerBack { get; set; } = new ServoFingerBack();

        public MotorGulp MotorGulp { get; set; } = new MotorGulp();
        public MotorFingerBack MotorFingerBack { get; set; } = new MotorFingerBack();
        public MotorFingerFront MotorFingerFront { get; set; } = new MotorFingerFront();

        public ServoUnloader ServoUnloader { get; set; } = new ServoUnloader();

        //2020

        public ServoFlagLeft ServoFlagLeft { get; set; } = new ServoFlagLeft();
        public ServoFlagRight ServoFlagRight { get; set; } = new ServoFlagRight();
    }
}

namespace GoBot.Actionneurs
{
    #region PositionableServo

    public class ServoElevation : PositionableServo
    {
        public override ServomoteurID ID => ServomoteurID.Elevation;

        public int PositionGround { get; set; }
        public int PositionInside { get; set; }
    }

    public abstract class ServoClamp : PositionableServo
    {
        public int PositionOpen { get; set; }
        public int PositionClose { get; set; }
        public int PositionFree { get; set; }
        public int PositionPush { get; set; }
    }

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

    public abstract class ServoClampAtom : ServoClamp
    {
        public int PositionAlmostClose { get; set; }
    }

    public class ServoClampLeft : ServoClampAtom
    {
        public override ServomoteurID ID => ServomoteurID.ClampLeft;
    }

    public class ServoClampRight : ServoClampAtom
    {
        public override ServomoteurID ID => ServomoteurID.ClampRight;
    }

    public abstract class ServoClampGold : ServoClamp
    {

    }

    public class ServoClampGoldRight : ServoClampGold
    {
        public override ServomoteurID ID => ServomoteurID.GoldClampRight;
    }

    public class ServoClampGoldLeft : ServoClampGold
    {
        public override ServomoteurID ID => ServomoteurID.GoldClampLeft;
    }

    public abstract class ServoElevationGold : PositionableServo
    {
        public int PositionStored { get; set; }
        public int PositionApproach { get; set; }
        public int PositionLocking { get; set; }
        public int PositionPush { get; set; }
    }

    public class ServoElevationGoldLeft : ServoElevationGold
    {
        public override ServomoteurID ID => ServomoteurID.GoldElevationLeft;
    }

    public class ServoElevationGoldRight : ServoElevationGold
    {
        public override ServomoteurID ID => ServomoteurID.GoldElevationRight;
    }

    public abstract class ServoHoldDrop : PositionableServo
    {
        public int PositionStored { get; set; }
        public int PositionHold { get; set; }
    }

    public abstract class ServoCalibration : PositionableServo
    {
        public int PositionStored { get; set; }
        public int PositionCalibration { get; set; }
    }

    public class ServoCalibrationLeft : ServoCalibration
    {
        public override ServomoteurID ID => ServomoteurID.CalibrationLeft;
    }

    public class ServoCalibrationRight : ServoCalibration
    {
        public override ServomoteurID ID => ServomoteurID.CalibrationRight;
    }

    public abstract class ServoLauncher : PositionableServo
    {
        public int PositionStored { get; set; }
        public int PositionLaunch { get; set; }
    }

    public class ServoLauncherLeft : ServoLauncher
    {
        public override ServomoteurID ID => ServomoteurID.LauncherLeft;
    }

    public class ServoLauncherRight : ServoLauncher
    {
        public override ServomoteurID ID => ServomoteurID.LauncherRight;
    }


    public class ServoFingerFront : PositionableServo
    {
        public override ServomoteurID ID => ServomoteurID.FingerFront;
        public int PositionOpen { get; set; }
        public int PositionClose { get; set; }
    }

    public class ServoFingerBack : PositionableServo
    {
        public override ServomoteurID ID => ServomoteurID.FingerBack;
        public int PositionForward { get; set; }
        public int PositionBackward { get; set; }
        public int PositionVertical { get; set; }
        public int PositionBlocking { get; set; }
    }

    public class ServoUnloader : PositionableServo
    {
        public override ServomoteurID ID => ServomoteurID.Unloader;
        public int PositionUnload { get; set; }
        public int PositionStore { get; set; }
        public int PositionDocking { get; set; }
    }

    public abstract class ServoExitLauncher : PositionableServo
    {
        public int PositionInside { get; set; }
        public int PositionOutside { get; set; }
    }

    public class ServoExitLauncherLeft : ServoExitLauncher
    {
        public override ServomoteurID ID => ServomoteurID.ExitLauncherLeft;
    }

    public class ServoExitLauncherRight : ServoExitLauncher
    {
        public override ServomoteurID ID => ServomoteurID.ExitLauncherRight;
    }


    #endregion

    #region PositionableMotorSpeed


    public class MotorGulp : PositionableMotorSpeed
    {
        public override MotorID ID => MotorID.Gulp;
        public int PositionSwallow { get; set; }
        public int PositionStop { get; set; }
        public int PositionSpit { get; set; }
    }

    #endregion

    public class MotorFingerFront : PositionableMotorPosition
    {
        public override MotorID ID => MotorID.FingerFront;
        public int PositionPrepare { get; set; }
        public int PositionStore { get; set; }
    }

    public class MotorFingerBack : PositionableMotorPosition
    {
        public override MotorID ID => MotorID.FingerBack;
    }
}
