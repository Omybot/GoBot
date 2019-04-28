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

        public ServoHoldDropLeft ServoHoldDropLeft { get; set; } = new ServoHoldDropLeft();
        public ServoHoldDropRight ServoHoldDropRight { get; set; } = new ServoHoldDropRight();

        public ServoLauncherLeft ServoLauncherLeft { get; set; } = new ServoLauncherLeft();
        public ServoLauncherRight ServoLauncherRight { get; set; } = new ServoLauncherRight();

        public ServoFingerFront ServoFingerFront { get; set; } = new ServoFingerFront();
        public ServoFingerBack ServoFingerBack { get; set; } = new ServoFingerBack();

        public MotorGulp MotorGulp { get; set; } = new MotorGulp();
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

    public class ServoHoldDropLeft : ServoHoldDrop
    {
        public override ServomoteurID ID => ServomoteurID.HoldDropLeft;
    }

    public class ServoHoldDropRight : ServoHoldDrop
    {
        public override ServomoteurID ID => ServomoteurID.HoldDropRight;
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
    }

    public class ServoFingerBack : PositionableServo
    {
        public override ServomoteurID ID => ServomoteurID.FingerBack;
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
}
