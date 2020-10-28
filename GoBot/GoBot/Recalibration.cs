using Geometry;
using Geometry.Shapes;
using GoBot.Devices;
using GoBot.BoardContext;
using System;

namespace GoBot
{
    public static class Recalibration
    {
        private static Position PositionLeft { get; set; }
        private static Position PositionRight { get; set; }

        public static Position StartPosition
        {
            get
            {
                return GameBoard.MyColor == GameBoard.ColorLeftBlue ? PositionLeft : PositionRight;
            }
        }

        public static void Init()
        {
            if (Config.CurrentConfig.IsMiniRobot)
            {
                PositionLeft = new Position(0, new RealPoint(Robots.MainRobot.LenghtTotal / 2, Robots.MainRobot.Width / 2 + 530 + 10 + 250));
                PositionRight = new Position(180, new RealPoint(3000 - PositionLeft.Coordinates.X, PositionLeft.Coordinates.Y + 250));
            }
            else
            {
                PositionLeft = new Position(0, new RealPoint(250, 690));
                PositionRight = new Position(180, new RealPoint(3000 - PositionLeft.Coordinates.X, PositionLeft.Coordinates.Y));
            }
        }

        public static bool GoToCalibration()
        {
            if (Config.CurrentConfig.IsMiniRobot)
            {
                if (GameBoard.ColorLeftBlue == GameBoard.MyColor)
                    return Robots.MainRobot.GoToPosition(new Position(90, new RealPoint(Robots.MainRobot.Width, Robots.MainRobot.Width)));
                else
                    return Robots.MainRobot.GoToPosition(new Position(90, new RealPoint(3000 - Robots.MainRobot.Width, Robots.MainRobot.Width)));
            }
            else
            {
                if (GameBoard.ColorLeftBlue == GameBoard.MyColor)
                    return Robots.MainRobot.GoToPosition(new Position(90, new RealPoint(Robots.MainRobot.Width, Robots.MainRobot.Width)));
                else
                    return Robots.MainRobot.GoToPosition(new Position(90, new RealPoint(3000 - Robots.MainRobot.Width, Robots.MainRobot.Width)));
            }
        }

        public static void Calibration()
        {
            if (Config.CurrentConfig.IsMiniRobot)
            {
                Robots.MainRobot.SendPID(Config.CurrentConfig.GRCoeffP, Config.CurrentConfig.GRCoeffI, Config.CurrentConfig.GRCoeffD);
                Robots.MainRobot.Stop();

                Robots.MainRobot.SetSpeedVerySlow();
                Robots.MainRobot.MoveForward(10);
                Robots.MainRobot.Recalibration(SensAR.Arriere);
                Robots.MainRobot.SetSpeedFast();
                Robots.MainRobot.SetAsservOffset(new Position(Math.Round(Robots.MainRobot.Position.Angle.InPositiveDegrees / 90) * 90,
                    new RealPoint(Robots.MainRobot.Position.Coordinates.X, Robots.MainRobot.LenghtBack)));

                Robots.MainRobot.MoveForward((int)(StartPosition.Coordinates.Y - Robots.MainRobot.LenghtBack));

                if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
                    Robots.MainRobot.PivotRight(90);
                else
                    Robots.MainRobot.PivotLeft(90);

                Robots.MainRobot.SetSpeedVerySlow();
                Robots.MainRobot.Recalibration(SensAR.Arriere);

                Robots.MainRobot.SetAsservOffset(StartPosition);

                Robots.MainRobot.EnableStartTrigger();

                Robots.MainRobot.SetSpeedFast();
            }
            else
            {
                Robots.MainRobot.SetAsservOffset(new Position(92, new RealPoint(GameBoard.MyColor == GameBoard.ColorLeftBlue ? 500 : 2500, 500)));

                Robots.MainRobot.SendPID(Config.CurrentConfig.GRCoeffP, Config.CurrentConfig.GRCoeffI, Config.CurrentConfig.GRCoeffD);
                Robots.MainRobot.Stop();

                Robots.MainRobot.SetSpeedVerySlow();
                Robots.MainRobot.MoveForward(10);
                Robots.MainRobot.Recalibration(SensAR.Arriere, true, true);

                Robots.MainRobot.SetSpeedSlow();
                Robots.MainRobot.MoveForward((int)(StartPosition.Coordinates.Y - Robots.MainRobot.LenghtBack));

                if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
                    Robots.MainRobot.PivotLeft(90);
                else
                    Robots.MainRobot.PivotRight(90);

                Robots.MainRobot.SetSpeedVerySlow();
                Robots.MainRobot.Recalibration(SensAR.Arriere, true, true);

                if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
                    Robots.MainRobot.Move((int)Math.Abs(StartPosition.Coordinates.X - Robots.MainRobot.LenghtBack));
                else
                    Robots.MainRobot.Move((int)Math.Abs((3000 - StartPosition.Coordinates.X) - Robots.MainRobot.LenghtBack));

                Robots.MainRobot.SetAsservOffset(StartPosition);
                Robots.MainRobot.EnableStartTrigger();
                Robots.MainRobot.SetSpeedFast();
            }
        }
    }
}
