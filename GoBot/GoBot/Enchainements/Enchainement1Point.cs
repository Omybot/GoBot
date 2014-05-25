using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs.Formes;
using AStarFolder;
using System.Threading;
using GoBot.Actionneur;

namespace GoBot.Enchainements
{
    class Enchainement1Point : Enchainement
    {
        protected override void ThreadGros()
        {
            Thread.Sleep(200);
            Random rand = new Random(DateTime.Now.Millisecond);

            Robots.GrosRobot.VitesseDeplacement = 800;
            Robots.GrosRobot.AccelerationDeplacement = 800;
            Robots.GrosRobot.VitessePivot = 800;
            Robots.GrosRobot.AccelerationPivot = 800;

            BrasFeux.PositionTorche1();

            Robots.GrosRobot.Avancer(800);

            BrasFeux.PositionRange();

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Robots.GrosRobot.PivotGauche(64);
            else
                Robots.GrosRobot.PivotDroite(64);

            Robots.GrosRobot.Avancer(111);

            BrasFeux.MoveAttrapeTorcheTout();
            Robots.GrosRobot.Reculer(40);

            if (Plateau.NotreCouleur == Plateau.CouleurDroiteJaune)
                Robots.GrosRobot.PivotDroite(70);
            else
                Robots.GrosRobot.PivotGauche(70);

            Robots.GrosRobot.Avancer(300);
            BrasFeux.MoveDeposeProche3();
            Robots.GrosRobot.Reculer(120);
            Robots.GrosRobot.PivotDroite(60);
            BrasFeux.MoveDeposeRetourne2();
            Thread.Sleep(500);
            Robots.GrosRobot.PivotGauche(60);


            BrasFeux.PositionInterne1();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(300);
            BrasFeux.PositionRange();
            Thread.Sleep(300);
            BrasFeux.PositionTorcheDessus();
            Thread.Sleep(300);
            BrasFeux.PositionTorche1();
            Thread.Sleep(400);
            Robots.GrosRobot.VitesseDeplacement = 400;
            Robots.GrosRobot.Avancer(120);
            Thread.Sleep(200);
            //Robots.GrosRobot.Reculer(150);
            //BrasFeux.MoveDeposeProche1();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            BrasFeux.PositionTorcheDessus();
            Thread.Sleep(500);
            BrasFeux.PositionRange();
            Thread.Sleep(500);
            Robots.GrosRobot.VitesseDeplacement = 800;
            Robots.GrosRobot.Reculer(150);



        }

        protected override void ThreadPetit()
        {
        }
    }
}
