using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBot
{
    public static class Recallages
    {
        public static void RecallagePetitRobot()
        {
        }

        public static void RecallageGrosRobot()
        {
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Reculer(10);
            Robots.GrosRobot.Recallage(SensAR.Avant);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Reculer(101);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Robots.GrosRobot.PivotGauche(90);
            else
                Robots.GrosRobot.PivotDroite(90);

            Robots.GrosRobot.Reculer(400);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Avancer(352);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Robots.GrosRobot.PivotGauche(26);
            else
                Robots.GrosRobot.PivotDroite(26);

            Robots.GrosRobot.Reculer(339);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Robots.GrosRobot.ReglerOffsetAsserv(2813, 397, 206);
            else
                Robots.GrosRobot.ReglerOffsetAsserv(187, 397, -26);
        }
    }
}
