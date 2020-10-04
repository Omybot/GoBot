using System;
using GoBot.Actionneurs;

namespace GoBot
{
    public partial class Config
    {
        public MotorGulp MotorGulp { get; set; } = new MotorGulp();
        public MotorFingerBack MotorFingerBack { get; set; } = new MotorFingerBack();
        public MotorFingerFront MotorFingerFront { get; set; } = new MotorFingerFront();

        //2020

        public ServoFlagLeft ServoFlagLeft { get; set; } = new ServoFlagLeft();
        public ServoFlagRight ServoFlagRight { get; set; } = new ServoFlagRight();
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
