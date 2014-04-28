using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot
{
    static class BrasFeux
    {
        private static readonly int INIT_COUDE = 0;
        private static readonly int INIT_EPAULE = 0;
        private static readonly int INIT_POIGNET = 0;

        public static void PositionEpaule(double angle)
        {
            int valeur = (int)(angle * 1024 / (300.0)) + INIT_EPAULE;
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
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2750);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 780);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 605);
        }

        public static void PositionDeposeLoinSol()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1200);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 542);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 479);
        }

        public static void PositionTorche1()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1750);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 785);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 370);
        }

        public static void PositionTorche2()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1800);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 730);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 430);
        }

        public static void PositionTorche3()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1750);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 650);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 500);
        }

        public static void PositionTorcheDessus()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1800);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 600);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 550);
        }

        public static void PositionInterne1()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2750);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 920);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 486);
        }

        public static void PositionInterne2()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2800);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 840);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 550);
        }

        public static void PositionInterne3()
        {
            PositionRange();
        }


        public static void MoveAttrapeTorche1()
        {
            PositionRange();
            Thread.Sleep(200);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            PositionTorche1();
            Thread.Sleep(1300);
            PositionTorcheDessus();
            Thread.Sleep(600);
            PositionRange();
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
        }

        public static void MoveAttrapeTorche2()
        {
            PositionRange();
            Thread.Sleep(200);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            PositionTorche2();
            Thread.Sleep(1300);
            PositionTorcheDessus();
            Thread.Sleep(600);
            PositionRange();
            Thread.Sleep(1000);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
        }

        public static void MoveAttrapeTorche3()
        {
            PositionRange();
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            PositionTorche3();
            Thread.Sleep(1300);
            PositionTorcheDessus();
            Thread.Sleep(600);
            PositionRange();
            Thread.Sleep(1000);
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

        public static void PositionRetournement()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2100);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 780);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 605);
        }

        public static void MoveRetourneTout()
        {
            PositionRange();
            Thread.Sleep(500);
            PositionInterne3();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(300);
            PositionRetournement();
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(500);

            PositionRange();
            Thread.Sleep(500);
            PositionInterne2();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(500);
            PositionRange();
            Thread.Sleep(500);
            PositionRetournement();
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(500);

            PositionRange();
            Thread.Sleep(500);
            PositionInterne1();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(500);
            PositionRange();
            Thread.Sleep(500);
            PositionRetournement();
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(500);

            PositionRange();
        }

        public static void PositionSolProche()
        {
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1780);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 900);
            Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 260);
        }
    }
}
