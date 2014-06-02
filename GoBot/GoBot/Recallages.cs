using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Actionneur;

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

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.PetitRobot.PivotDroite(90);
            else
                Robots.PetitRobot.PivotGauche(90);

            Robots.PetitRobot.Lent();
            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Robots.PetitRobot.Rapide();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.PetitRobot.ReglerOffsetAsserv(191, 91, 270);
            else
                Robots.PetitRobot.ReglerOffsetAsserv(3000 - 191, 91, 270);

            semRecallagePetit.Release();
        }

        private static Semaphore semRecallagePetit;

        public static void RecallageGrosRobot(bool attendrePetit)
        {
            BrasFruits.PositionRange();
            BrasFeux.PositionInterne3();
            BrasFruits.FermerPinceBas();
            BrasFruits.FermerPinceHaut();

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

            if (attendrePetit && semRecallagePetit != null)
            {
                semRecallagePetit.WaitOne();
                semRecallagePetit = null;
            }

            Robots.GrosRobot.Reculer(339);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Robots.GrosRobot.ReglerOffsetAsserv(2813, 397, 206);
            else
                Robots.GrosRobot.ReglerOffsetAsserv(187, 397, -26);

            Robots.GrosRobot.ArmerJack();
        }
    }
}
