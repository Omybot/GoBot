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
        public static void RecallagePetitRobot()
        {
            semRecallagePetit = new Semaphore(0, int.MaxValue);

            Robots.PetitRobot.Lent();
            Robots.PetitRobot.Avancer(10);
            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Robots.PetitRobot.Rapide();
            Robots.PetitRobot.Avancer(100);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheViolet)
                Robots.PetitRobot.PivotDroite(90);
            else
                Robots.PetitRobot.PivotGauche(90);

            Robots.PetitRobot.Lent();
            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Robots.PetitRobot.Rapide();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheViolet)
                Robots.PetitRobot.ReglerOffsetAsserv(191, 91, 270);
            else
                Robots.PetitRobot.ReglerOffsetAsserv(3000 - 191, 91, 270);

            semRecallagePetit.Release();
        }

        private static Semaphore semRecallagePetit;

        public static void RecallageGrosRobot(bool attendrePetit)
        {
            Robots.GrosRobot.EnvoyerPID(20, 0, 200);
            Robots.GrosRobot.Stop();

            Actionneur.PinceVerrou.Ranger();
            Actionneur.PinceBasLateralGauche.Ranger();
            Actionneur.PinceBasLateralDroite.Ranger();
            Actionneur.BrasDroite.Ranger();
            Actionneur.BrasGauche.Ranger();
            Actionneur.BrasDroite.Fermer();
            Actionneur.BrasGauche.Fermer();
            Actionneur.PinceBas.Ranger();
            Actionneur.MaintienDune.Ouvrir();

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(10);
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Avancer(2000 - (600 + 5 + Robots.GrosRobot.Longueur / 2 + Robots.GrosRobot.Largeur / 2));

            Actionneur.MaintienDune.Ranger();

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
            Actionneur.BarreDePompes.Maintien();
        }
    }
}
