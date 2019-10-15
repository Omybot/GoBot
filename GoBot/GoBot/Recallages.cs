﻿using GoBot.Actionneurs;
using Geometry;
using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Devices;

namespace GoBot
{
    public static class Recallages
    {
        private static Position PositionDepartGauche { get; set; }
        private static Position PositionDepartDroite { get; set; }

        public static Position PositionDepart
        {
            get
            {
                return Plateau.NotreCouleur == Plateau.ColorLeftBlue ? PositionDepartGauche : PositionDepartDroite;
            }
        }

        public static void Init()
        {
            PositionDepartGauche = new Position(0, new RealPoint(Robots.GrosRobot.Longueur / 2, Robots.GrosRobot.Largeur / 2 + 305));
            PositionDepartDroite = new Position(180, new RealPoint(3000 - PositionDepartGauche.Coordinates.X, PositionDepartGauche.Coordinates.Y));
        }
        
        public static void RecallageGrosRobot()
        {
                AllDevices.RecGoBot.SetLed(LedID.DebugB2, Devices.RecGoBot.LedStatus.Rouge);
                Plateau.FreezeColor();

                Robots.GrosRobot.EnvoyerPID(Config.CurrentConfig.GRCoeffP, Config.CurrentConfig.GRCoeffI, Config.CurrentConfig.GRCoeffD);
                Robots.GrosRobot.Stop();

                Robots.GrosRobot.Lent();
                Robots.GrosRobot.Avancer(10);
                Robots.GrosRobot.Recallage(SensAR.Arriere);

                Robots.GrosRobot.Avancer((int)(PositionDepartGauche.Coordinates.Y - Robots.GrosRobot.Longueur / 2));

                if (Plateau.NotreCouleur == Plateau.ColorLeftBlue)
                    Robots.GrosRobot.PivotGauche(90);
                else
                    Robots.GrosRobot.PivotDroite(90);

                Robots.GrosRobot.Recallage(SensAR.Arriere);

                Robots.GrosRobot.ReglerOffsetAsserv(PositionDepart);

                Robots.GrosRobot.ArmerJack();

                Robots.GrosRobot.Rapide();
                AllDevices.RecGoBot.SetLed(LedID.DebugB2, Devices.RecGoBot.LedStatus.Vert);
        }
    }
}
