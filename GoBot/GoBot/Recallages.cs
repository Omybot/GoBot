using GoBot.Actionneurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot
{
    public static class Recallages
    {
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

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheBleu)
                Robots.GrosRobot.ReglerOffsetAsserv(902,200,90+90+90);
            else
                Robots.GrosRobot.ReglerOffsetAsserv(3000 - 902, 200, 180+90);

            Robots.GrosRobot.ArmerJack();
            Plateau.Balise.VitesseRotation(150);

            Robots.GrosRobot.Rapide();
        }
    }
}
