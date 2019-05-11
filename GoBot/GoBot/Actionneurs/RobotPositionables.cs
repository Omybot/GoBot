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

        public ServoFingerFront ServoFingerFront { get; set; } = new ServoFingerFront();
        public ServoFingerBack ServoFingerBack { get; set; } = new ServoFingerBack();

        public MotorGulp MotorGulp { get; set; } = new MotorGulp();
        public MotorFingerBack MotorFingerBack { get; set; } = new MotorFingerBack();
        public MotorFingerFront MotorFingerFront { get; set; } = new MotorFingerFront();
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
    }

    public class ServoClampLeft : ServoClamp
    {
        public override ServomoteurID ID => ServomoteurID.ClampLeft;
    }

    public class ServoClampRight : ServoClamp
    {
        public override ServomoteurID ID => ServomoteurID.ClampRight;
    }

    public class ServoClampGoldRight : ServoClamp
    {
        public override ServomoteurID ID => ServomoteurID.GoldClampRight;
    }

    public class ServoClampGoldLeft : ServoClamp
    {
        public override ServomoteurID ID => ServomoteurID.GoldClampRight;
    }

    public abstract class ServoElevationGold : PositionableServo
    {
        public int PositionStored { get; set; }
        public int PositionApproach { get; set; }
        public int PositionLocking { get; set; }
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
    }



    #endregion

    #region PositionableMotorSpeed


    public class MotorGulp : PositionableMotorSpeed
    {
        public override MoteurID ID => MoteurID.Gulp;
        public int PositionSwallow { get; set; }
        public int PositionStop { get; set; }
        public int PositionSpit { get; set; }
    }

    #endregion

    public class MotorFingerFront : PositionableMotorPosition
    {
        public override MoteurID ID => MoteurID.FingerFront;
        public int PositionPrepare { get; set; }
        public int PositionStore { get; set; }
    }

    public class MotorFingerBack : PositionableMotorPosition
    {
        public override MoteurID ID => MoteurID.FingerBack;
    }
}
