﻿using Geometry;
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
                PositionLeft = new Position(0, new RealPoint(Robots.MainRobot.Lenght / 2, Robots.MainRobot.Width / 2 + 530 + 10 + 250));
                PositionRight = new Position(180, new RealPoint(3000 - PositionLeft.Coordinates.X, PositionLeft.Coordinates.Y + 250));
            }
            else
            {
                PositionLeft = new Position(0, new RealPoint(Robots.MainRobot.Lenght / 2, Robots.MainRobot.Width / 2 + 530 + 10));
                PositionRight = new Position(180, new RealPoint(3000 - PositionLeft.Coordinates.X, PositionLeft.Coordinates.Y));
            }
        }

        public static void GoToCalibration()
        {
            if (Config.CurrentConfig.IsMiniRobot)
            {
                if (GameBoard.ColorLeftBlue == GameBoard.MyColor)
                    Robots.MainRobot.GoToPosition(new Position(90, new RealPoint(Robots.MainRobot.Width, Robots.MainRobot.Width)));
                else
                    Robots.MainRobot.GoToPosition(new Position(90, new RealPoint(3000 - Robots.MainRobot.Width, Robots.MainRobot.Width)));
            }
            else
            {
                if (GameBoard.ColorLeftBlue == GameBoard.MyColor)
                    Robots.MainRobot.GoToPosition(new Position(90, new RealPoint(Robots.MainRobot.Width, Robots.MainRobot.Width)));
                else
                    Robots.MainRobot.GoToPosition(new Position(90, new RealPoint(3000 - Robots.MainRobot.Width, Robots.MainRobot.Width)));
            }
        }

        public static void Calibration()
        {
            if (Config.CurrentConfig.IsMiniRobot)
            {
                Robots.MainRobot.SendPID(Config.CurrentConfig.GRCoeffP, Config.CurrentConfig.GRCoeffI, Config.CurrentConfig.GRCoeffD);
                Robots.MainRobot.Stop();

                Robots.MainRobot.SetSpeedLow();
                Robots.MainRobot.MoveForward(10);
                Robots.MainRobot.Recalibration(SensAR.Arriere);
                Robots.MainRobot.SetSpeedFast();
                Robots.MainRobot.SetAsservOffset(new Position(Math.Round(Robots.MainRobot.Position.Angle.InPositiveDegrees / 90) * 90,
                    new RealPoint(Robots.MainRobot.Position.Coordinates.X, 2000  - Robots.MainRobot.Lenght / 2)));

                Robots.MainRobot.MoveForward((int)(StartPosition.Coordinates.Y - Robots.MainRobot.Lenght / 2));

                if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
                    Robots.MainRobot.PivotRight(90);
                else
                    Robots.MainRobot.PivotLeft(90);

                Robots.MainRobot.SetSpeedLow();
                Robots.MainRobot.Recalibration(SensAR.Arriere);

                Robots.MainRobot.SetAsservOffset(StartPosition);

                Robots.MainRobot.EnableStartTrigger();

                Robots.MainRobot.SetSpeedFast();
            }
            else
            {
                Robots.MainRobot.SendPID(Config.CurrentConfig.GRCoeffP, Config.CurrentConfig.GRCoeffI, Config.CurrentConfig.GRCoeffD);
                Robots.MainRobot.Stop();

                Robots.MainRobot.SetSpeedLow();
                Robots.MainRobot.MoveForward(10);
                Robots.MainRobot.Recalibration(SensAR.Arriere);
                Robots.MainRobot.SetSpeedFast();
                Robots.MainRobot.SetAsservOffset(new Position(Math.Round(Robots.MainRobot.Position.Angle.InPositiveDegrees / 90) * 90,
                    new RealPoint(Robots.MainRobot.Position.Coordinates.X, Robots.MainRobot.Lenght / 2)));

                Robots.MainRobot.MoveForward((int)(StartPosition.Coordinates.Y - Robots.MainRobot.Lenght / 2));

                if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
                    Robots.MainRobot.PivotLeft(90);
                else
                    Robots.MainRobot.PivotRight(90);

                Robots.MainRobot.SetSpeedLow();
                Robots.MainRobot.Recalibration(SensAR.Arriere);

                Robots.MainRobot.SetAsservOffset(StartPosition);

                Robots.MainRobot.EnableStartTrigger();

                Robots.MainRobot.SetSpeedFast();
            }
        }
    }
}
