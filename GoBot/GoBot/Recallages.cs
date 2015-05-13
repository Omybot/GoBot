﻿using GoBot.Actionneurs;
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

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
                Robots.PetitRobot.PivotDroite(90);
            else
                Robots.PetitRobot.PivotGauche(90);

            Robots.PetitRobot.Lent();
            Robots.PetitRobot.Recallage(SensAR.Arriere);
            Robots.PetitRobot.Rapide();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
                Robots.PetitRobot.ReglerOffsetAsserv(191, 91, 270);
            else
                Robots.PetitRobot.ReglerOffsetAsserv(3000 - 191, 91, 270);

            semRecallagePetit.Release();
        }

        private static Semaphore semRecallagePetit;

        public static void RecallageGrosRobot(bool attendrePetit)
        {
            Robots.GrosRobot.Stop();
            Actionneur.BrasAmpoule.AscenseurCalibration();
            Thread.Sleep(4000);
            Actionneur.BrasAmpoule.Monter();
            Thread.Sleep(1000);

            Actionneur.BrasAspirateur.PositionRange();
            Actionneur.BrasPiedsDroite.AscenseurDescendre();
            Actionneur.BrasPiedsGauche.AscenseurDescendre();
            Actionneur.BrasPiedsDroite.Verrouiller();
            Actionneur.BrasPiedsGauche.Verrouiller();
            Actionneur.BrasPiedsDroite.FermerPinceBas();
            Actionneur.BrasPiedsGauche.FermerPinceBas();
            Actionneur.BrasPiedsDroite.FermerPinceHaut();
            Actionneur.BrasPiedsGauche.FermerPinceHaut();
            Actionneur.BrasTapis.Monter();

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(10);
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Avancer(350);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteVert)
                Robots.GrosRobot.PivotGauche(90);
            else
                Robots.GrosRobot.PivotDroite(90);

            Robots.GrosRobot.Reculer(300);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Recallage(SensAR.Arriere);
            Robots.GrosRobot.Rapide();

            Actionneur.BrasAmpoule.Descendre();
            Robots.GrosRobot.Avancer(450);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteVert)
                Robots.GrosRobot.PivotDroite(90);
            else
                Robots.GrosRobot.PivotGauche(90);

            if (attendrePetit && semRecallagePetit != null)
            {
                semRecallagePetit.WaitOne();
                semRecallagePetit = null;
            }

            Robots.GrosRobot.Avancer(650 - Robots.GrosRobot.Longueur / 2);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteVert)
                Robots.GrosRobot.PivotGauche(90);
            else
                Robots.GrosRobot.PivotDroite(90);

            Actionneur.BrasAmpoule.Ouvrir();
            Robots.GrosRobot.Reculer(345);
            Actionneur.BrasTapis.LacherTapisGauche();
            Actionneur.BrasTapis.LacherTapisDroit();

            Thread.Sleep(5000);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteVert)
            {
                Robots.GrosRobot.ReglerOffsetAsserv(3000 - 255, 1000, 180);
                Actionneur.BrasPiedsGauche.AscenseurMonter();
            }
            else
            {
                Robots.GrosRobot.ReglerOffsetAsserv(255, 1000, 0);
                Actionneur.BrasPiedsDroite.AscenseurMonter();
            }

            Robots.GrosRobot.ArmerJack();
            Robots.GrosRobot.MoteurPosition(MoteurID.Balise, 2000);

            Actionneur.BrasTapis.SerrerTapisDroit();
            Actionneur.BrasTapis.SerrerTapisGauche();
        }
    }
}
