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
            PositionLeft = new Position(0, new RealPoint(Robots.GrosRobot.Longueur / 2, Robots.GrosRobot.Largeur / 2 + 530 + 10));
            PositionRight = new Position(180, new RealPoint(3000 - PositionLeft.Coordinates.X, PositionLeft.Coordinates.Y));
        }

        public static void GoToCalibration()
        {
            if (GameBoard.ColorLeftBlue == GameBoard.MyColor)
                Robots.GrosRobot.GotoXYTeta(new Position(90, new RealPoint(Robots.GrosRobot.Largeur, Robots.GrosRobot.Largeur)));
            else
                Robots.GrosRobot.GotoXYTeta(new Position(90, new RealPoint(3000 - Robots.GrosRobot.Largeur, Robots.GrosRobot.Largeur)));
        }

        public static void Calibration()
        {
            AllDevices.RecGoBot.SetLed(LedID.DebugB2, Devices.RecGoBot.LedStatus.Rouge);

            Robots.GrosRobot.EnvoyerPID(Config.CurrentConfig.GRCoeffP, Config.CurrentConfig.GRCoeffI, Config.CurrentConfig.GRCoeffD);
            Robots.GrosRobot.Stop();

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(10);
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.ReglerOffsetAsserv(new Position(Math.Round(Robots.GrosRobot.Position.Angle.InPositiveDegrees / 90) * 90, 
                new RealPoint(Robots.GrosRobot.Position.Coordinates.X, Robots.GrosRobot.Longueur/2)));

            Robots.GrosRobot.Avancer((int)(StartPosition.Coordinates.Y - Robots.GrosRobot.Longueur / 2));

            if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
                Robots.GrosRobot.PivotGauche(90);
            else
                Robots.GrosRobot.PivotDroite(90);

            Robots.GrosRobot.Recallage(SensAR.Arriere);

            Robots.GrosRobot.ReglerOffsetAsserv(StartPosition);

            Robots.GrosRobot.ArmerJack();

            Robots.GrosRobot.Rapide();
            AllDevices.RecGoBot.SetLed(LedID.DebugB2, Devices.RecGoBot.LedStatus.Vert);
        }
    }
}
