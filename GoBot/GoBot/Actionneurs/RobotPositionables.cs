using System;
using GoBot.Actionneurs;

namespace GoBot
{
    public partial class Config
    {
        public ServoClampLeft ServoClampLeft { get; set; } = new ServoClampLeft();
        public ServoClampRight ServoClampRight { get; set; } = new ServoClampRight();
        public ServoElevation ServoElevation { get; set; } = new ServoElevation();

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
