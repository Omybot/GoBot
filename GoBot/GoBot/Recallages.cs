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
            
            // TODO faire la procédure de calibration de début de match
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(10);
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Avancer(350);

            Robots.GrosRobot.ArmerJack();
            Robots.GrosRobot.MoteurPosition(MoteurID.Balise, 2000);
        }
    }
}
