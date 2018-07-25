using GoBot.Actionneurs;
using Geometry;
using Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
                return Plateau.NotreCouleur == Plateau.CouleurGaucheVert ? PositionDepartGauche : PositionDepartDroite;
            }
        }

        static Recallages()
        {
            PositionDepartGauche = new Position(0, new RealPoint(Robots.GrosRobot.Longueur / 2, Robots.GrosRobot.Largeur / 2 + 70));
            PositionDepartDroite = new Position(180, new RealPoint(3000 - PositionDepartGauche.Coordinates.X, PositionDepartGauche.Coordinates.Y));
        }
        
        public static void RecallageGrosRobot()
        {
            Devices.Devices.RecGoBot.SetLed(LedID.DebugB2, Devices.RecGoBot.LedStatus.Rouge);
            Plateau.FreezeColor();

            Robots.GrosRobot.EnvoyerPID(40, 0, 400);
            Robots.GrosRobot.Stop();

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(10);
            Robots.GrosRobot.Recallage(SensAR.Arriere);

            Robots.GrosRobot.Avancer((int)(70 + Robots.GrosRobot.Largeur / 2 - Robots.GrosRobot.Longueur / 2)); // 70mm du bord une fois en place

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheVert)
                Robots.GrosRobot.PivotGauche(90);
            else
                Robots.GrosRobot.PivotDroite(90);

            Robots.GrosRobot.Recallage(SensAR.Arriere);
            
            Robots.GrosRobot.ReglerOffsetAsserv(PositionDepart);

            Robots.GrosRobot.ArmerJack();
            Plateau.Balise.VitesseRotation(150);

            Robots.GrosRobot.Rapide();
        }
    }
}
