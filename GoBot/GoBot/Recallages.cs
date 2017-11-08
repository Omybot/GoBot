using GoBot.Actionneurs;
using GoBot.Geometry;
using GoBot.Geometry.Shapes;
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
                return Plateau.NotreCouleur == Plateau.CouleurGaucheBleu ? PositionDepartGauche : PositionDepartDroite;
            }
        }

        static Recallages()
        {
            PositionDepartGauche = new Position(90 + 90 + 90, new RealPoint(902, 200));
            PositionDepartDroite = new Position(180 - PositionDepartGauche.Angle, new RealPoint(3000 - PositionDepartGauche.Coordinates.X, PositionDepartGauche.Coordinates.Y));
        }
        
        public static void RecallageGrosRobot()
        {
            Robots.GrosRobot.EnvoyerPID(40, 0, 600);
            Robots.GrosRobot.Stop();
            Robots.GrosRobot.RangerActionneurs();

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(10);
            Robots.GrosRobot.Recallage(SensAR.Arriere);

            Robots.GrosRobot.Avancer(898-160); // 160 = taille calle

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                Robots.GrosRobot.PivotDroite(90-6-7);
            else
                Robots.GrosRobot.PivotGauche(90-6-7);

            Robots.GrosRobot.Reculer(540);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                Robots.GrosRobot.PivotDroite(6);
            else
                Robots.GrosRobot.PivotGauche(6);

            Robots.GrosRobot.Reculer(150);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                Robots.GrosRobot.PivotDroite(7);
            else
                Robots.GrosRobot.PivotGauche(7);

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);

            Robots.GrosRobot.Avancer(50);

            Robots.GrosRobot.ReglerOffsetAsserv(PositionDepart);

            Robots.GrosRobot.ArmerJack();
            Plateau.Balise.VitesseRotation(150);

            Robots.GrosRobot.Rapide();
        }
    }
}
