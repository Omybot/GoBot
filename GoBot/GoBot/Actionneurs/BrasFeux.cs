using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.ElementsJeu;

namespace GoBot.Actionneur
{
    public static class BrasFeux
    {
        private static readonly int INIT_COUDE = 764;
        private static readonly int INIT_EPAULE = 2250; // 1600 = 45°
        private static readonly int INIT_POIGNET = 466;

        public static List<Feu> FeuxStockes { get; private set; }

        static BrasFeux()
        {
            FeuxStockes = new List<Feu>();
        }

        public static void PositionEpaule(double angle)
        {
            int valeur = (int)(angle * 5200 / (360.0)) + INIT_EPAULE;
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, valeur);
        }

        public static void PositionCoude(double angle)
        {
            int valeur = (int)(angle * 1024 / (300.0)) + INIT_COUDE;
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, valeur);
        }

        public static void PositionPoignet(double angle)
        {
            int valeur = (int)(angle * 1024 / (300.0)) + INIT_POIGNET;
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, valeur);
        }

        public static void PositionRange()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2750);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 770);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 600);
            PositionEpaule(34.62);
            PositionCoude(1.76);
            PositionPoignet(39.26);
        }

        public static void PositionDeposeLoinSol()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1200);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 512);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 479);
            PositionEpaule(-72.69);
            PositionPoignet(3.81);
            PositionCoude(-73.83);
        }

        public static void PositionPousseFoyer()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1770);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 750);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 360);
            PositionEpaule(-33.23);
            PositionCoude(-4.10);
            PositionPoignet(-31.05);
        }

        public static void PositionTorche1()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1750);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 755);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 370);
            PositionEpaule(-34.62);
            PositionCoude(-2.64);
            PositionPoignet(-28.125);
        }

        public static void PositionTorche2()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1800);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 720);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 430);
            PositionEpaule(-31.15);
            PositionCoude(-12.89);
            PositionPoignet(-10.55);
        }

        public static void PositionTorche3()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1750);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 650);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 500);
            PositionEpaule(-34.62);
            PositionCoude(-33.40);
            PositionPoignet(9.96);
        }

        public static void PositionTorcheDessus()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1800);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 570);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 550);
            PositionEpaule(-31.15);
            PositionCoude(-56.84);
            PositionPoignet(24.61);
        }

        public static void PositionInterne1()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2750);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 905);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 480);
            PositionEpaule(34.62);
            PositionCoude(41.31);
            PositionPoignet(4.10);
        }

        public static void PositionInterne2()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2800);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 840);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 550);
            PositionEpaule(38.08);
            PositionCoude(22.27);
            PositionPoignet(24.61);
        }

        public static void PositionInterne3()
        {
            PositionRange();
        }

        public static void PositionContreMur()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1900);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 840);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 20);
            PositionEpaule(-24.23);
            PositionCoude(22.27);
            PositionPoignet(-130.66);
        }


        public static void MoveAttrapeTorche1()
        {
            PositionRange();
            Thread.Sleep(200);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            PositionTorche3();
            Thread.Sleep(500);
            PositionTorche1();
            Thread.Sleep(400);
            PositionTorcheDessus();
            Thread.Sleep(300);
            PositionRange();
            Thread.Sleep(600);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
        }

        public static void MoveAttrapeTorche2()
        {
            PositionRange();
            Thread.Sleep(200);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            PositionTorche2();
            Thread.Sleep(800);
            PositionTorcheDessus();
            Thread.Sleep(300);
            PositionRange();
            Thread.Sleep(600);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
        }

        public static void MoveAttrapeTorche3()
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            PositionTorche3();
            Thread.Sleep(800);
            PositionTorcheDessus();
            Thread.Sleep(300);
            PositionRange();
            Thread.Sleep(600);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
        }

        public static void MoveAttrapeTorcheTout()
        {
            MoveAttrapeTorche3();
            MoveAttrapeTorche2();
            MoveAttrapeTorche1();
        }

        public static void MoveDeposeLoin1()
        {
            PositionInterne1();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(1000);
            PositionRange();
            Thread.Sleep(1000);
            PositionDeposeLoinSol();
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(200);
            PositionRange();
        }

        public static void MoveDeposeLoin2()
        {
            PositionInterne2();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(1000);
            PositionRange();
            Thread.Sleep(1000);
            PositionDeposeLoinSol();
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(200);
            PositionRange();
        }

        public static void MoveDeposeLoin3()
        {
            PositionInterne3();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(1000);
            PositionDeposeLoinSol();
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(200);
            PositionRange();
        }

        public static void MoveDeposeProche1()
        {
            PositionInterne1();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(300);
            PositionRange();
            Thread.Sleep(300);
            PositionTorcheDessus();
            Thread.Sleep(300);
            PositionSolProche();
            Thread.Sleep(250);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(200);
            PositionRange();
            Thread.Sleep(500);
        }

        public static void MoveDeposeProche2()
        {
            PositionInterne2();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(200);
            PositionRange();
            Thread.Sleep(250);
            PositionTorcheDessus();
            Thread.Sleep(250);
            PositionSolProche();
            Thread.Sleep(250);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(200);
            PositionRange();
            Thread.Sleep(500);
        }

        public static void MoveDeposeProche3()
        {
            PositionInterne3();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(100);
            PositionTorcheDessus();
            Thread.Sleep(250);
            PositionSolProche();
            Thread.Sleep(250);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(200);
            PositionRange();
            Thread.Sleep(500);
        }

        public static void PositionRetournement()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2100);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 750);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 605);
        }

        public static void MoveDeposeRetourne1()
        {
            PositionInterne1();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(300);
            PositionRange();
            Thread.Sleep(300);
            PositionRetournement();
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(500);
            PositionRange();
        }

        public static void MoveDeposeRetourne2()
        {
            PositionInterne2();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(300);
            PositionRange();
            Thread.Sleep(300);
            PositionRetournement();
            Thread.Sleep(300);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(250);
            PositionRange();
        }

        public static void MoveDeposeRetourne3()
        {
            PositionInterne3();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(300);
            PositionRetournement();
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(500);
            PositionRange();
        }

        public static void MoveRetourneTout()
        {
            MoveDeposeRetourne3();
            Thread.Sleep(200);
            MoveDeposeRetourne2();
            Thread.Sleep(200);
            MoveDeposeRetourne1();
        }

        public static void PositionSolProche()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1850);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 820);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 260);
        }

        public static void MoveAttrapeContreMur()
        {
            // Le robot doit être à 175mm du bord
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            PositionTorcheDessus();
            Thread.Sleep(200);
            PositionContreMur();
            Thread.Sleep(500);
            BrasFeux.PositionTorcheDessus();
            Thread.Sleep(400);
            BrasFeux.PositionRange();
            Thread.Sleep(400);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
        }
    }
}
