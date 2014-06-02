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
        private static readonly int INIT_COUDE = 792;
        private static readonly int INIT_EPAULE = 2207; // 1600 = 45°
        private static readonly int INIT_POIGNET = 460;

        public static bool PresenceFeu1 { get; set; }
        public static bool PresenceFeu2 { get; set; }
        public static bool PresenceFeu3 { get; set; }

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
            PositionEpaule(-29.23);
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

        public static void PositionTorcheDessus(bool tempo =false)
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 1800);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 570);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 550);
            PositionEpaule(-31.15);
            if (tempo)
                Thread.Sleep(50);
            PositionCoude(-56.84);
            PositionPoignet(24.61);
        }

        public static void PositionInterne1()
        {
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2750);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxCoude, 905);
            //Robots.GrosRobot.BougeServo(ServomoteurID.GRFeuxPoignet, 480);
            PositionEpaule(34.62);
            PositionCoude(50.3);
            PositionPoignet(9);
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


        public static void MoveAttrapeTorche1(bool tempo = false)
        {
            PositionRange();
            Thread.Sleep(200);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            PositionTorche1();
            Thread.Sleep(450);
            PositionTorcheDessus();
            Thread.Sleep(250);
            PositionRange();
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(50);
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
            Thread.Sleep(50);
        }

        public static void MoveAttrapeTorche2DeposeInverse()
        {
            //PositionRange();
            //Thread.Sleep(200);
            PositionTorche2();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(500);
            PositionTorcheDessus();
            Thread.Sleep(300);
            PositionRetournement();

            Robots.GrosRobot.Reculer(30);

            if(Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotGauche(30);
            else
                Robots.GrosRobot.PivotDroite(30);

            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotDroite(30);
            else
                Robots.GrosRobot.PivotGauche(30);

            PositionTorcheDessus();

            Robots.GrosRobot.Avancer(50);
        }

        public static void MoveAttrapeTorche3()
        {
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            PositionTorche3();
            Thread.Sleep(550);
            PositionTorcheDessus();
            Thread.Sleep(200);
            PositionRange();
            Thread.Sleep(500);
            PositionInterne1();
            Thread.Sleep(100);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            PositionInterne3();
            Thread.Sleep(100);
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
            //Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2100);
            Robots.GrosRobot.TourneMoteur(MoteurID.GREpauleFeu, 2150);
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
            //PositionCoude(35);
            //PositionEpaule(-35);
            //PositionPoignet(-50);


            PositionCoude(35);
            PositionEpaule(-35);
            //PositionPoignet(-60);
            PositionPoignet(-70);
        }

        public static Feu FeuProche()
        {
            double distance = double.MaxValue;
            Feu feuProche = null;

            foreach (Feu feu in Plateau.Feux)
            {
                if (feu.Charge == false && feu.Positionne == false && feu.Position.Distance(Robots.GrosRobot.Position.Coordonnees) < distance)
                {
                    feuProche = feu;
                    distance = feu.Position.Distance(Robots.GrosRobot.Position.Coordonnees);
                }
            }

            return feuProche;
        }

        public static void RangerFeu()
        {
            if (FeuxStockes.Count < 3)
            {
                PositionTorcheDessus();
                Thread.Sleep(500);
                PositionInterne3();
                Thread.Sleep(500);
                /*if (FeuxStockes.Count < 1)
                {
                    //PositionInterne1();
                    Thread.Sleep(200);
                    PositionInterne3();
                }*/
                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
                Thread.Sleep(100);
                /*
                Thread.Sleep(250);
                Thread.Sleep(100);
                if (FeuxStockes.Count < 2)
                {
                    PositionInterne3();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);
                Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
                Feu proche = FeuProche();

                int i;
                for (i = 0; i < Plateau.Feux.Length; i++)
                    if (Plateau.Feux[i] == proche)
                        break;

                if ((i == 1 && Robots.GrosRobot.Position.Coordonnees.Y < proche.Position.Y) ||
                    (i == 14 && Robots.GrosRobot.Position.Coordonnees.Y > proche.Position.Y) ||
                    ((i == 6 || i == 13) && Robots.GrosRobot.Position.Coordonnees.X > proche.Position.X))
                    proche.Couleur = Plateau.CouleurGaucheRouge;
                else
                    proche.Couleur = Plateau.CouleurDroiteJaune;

                proche.Charge = true;
                FeuxStockes.Add(proche);

                BrasFeux.PositionTorcheDessus(true);
                Thread.Sleep(200);
                BrasFeux.PositionAspireDroit();*/
            }
            else
            {
                PositionMaintienAspire();
            }
        }

        public static void PositionMaintienAspire()
        {
            PositionPoignet(-73);
            PositionCoude(0);
            PositionEpaule(30);
        }

        public static void PositionAspireDroit()
        {
            PositionPoignet(-150);
            Thread.Sleep(250);
            PositionCoude(50);
            PositionEpaule(-10);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
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
