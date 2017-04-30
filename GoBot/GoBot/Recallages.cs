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
            Robots.GrosRobot.EnvoyerPID(20, 0, 200);
            Robots.GrosRobot.Stop();

            Actionneur.BrasLunaire.Rentrer();
            Actionneur.BrasLunaire.Fermer();
            Actionneur.BrasLunaire.Monter();

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(10);
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Avancer(2000 - (600 + 5 + Robots.GrosRobot.Longueur / 2 + Robots.GrosRobot.Largeur / 2));

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheViolet)
                Robots.GrosRobot.PivotDroite(90);
            else
                Robots.GrosRobot.PivotGauche(90);

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheViolet)
                Robots.GrosRobot.ReglerOffsetAsserv(Robots.GrosRobot.Longueur / 2, 600 + 5 + Robots.GrosRobot.Largeur / 2, 0);
            else
                Robots.GrosRobot.ReglerOffsetAsserv(3000 - Robots.GrosRobot.Longueur / 2, 600 + 5 + Robots.GrosRobot.Largeur / 2, 180);

            Robots.GrosRobot.ArmerJack();
            Robots.GrosRobot.MoteurPosition(MoteurID.Balise, 3000);
        }
    }
}
