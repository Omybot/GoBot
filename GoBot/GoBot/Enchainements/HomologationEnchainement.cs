using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using GoBot.Actions;

namespace GoBot.Enchainements
{
    class HomologationEnchainement : Enchainement
    {
        private Thread th;
        Color couleur;

        public HomologationEnchainement()
        {
            couleur = Color.Red;
        }

        public Color GetCouleur()
        {
            return couleur;
        }

        public void SetCouleur(Color color)
        {
            couleur = color;
        }

        public void Executer()
        {
            if (couleur == Color.Red)
                th = new Thread(ThreadEnchainementRouge);
            else
                th = new Thread(ThreadEnchainementViolet);

            th.Start();
        }


        private void ThreadEnchainementViolet()
        {
            DateTime debut = DateTime.Now;

            GrosRobot.Evitement = true;
            GrosRobot.VitesseDeplacement = 800;
            GrosRobot.VitessePivot = 900;
            GrosRobot.AccelerationDeplacement = 1300;
            GrosRobot.AccelerationPivot = 1400;

            GrosRobot.FermeBrasHautGauche();
            GrosRobot.FermeBrasMilieuGauche();
            GrosRobot.FermeBrasBasGauche();

            GrosRobot.FermeBrasHautDroite();
            GrosRobot.FermeBrasMilieuDroite();
            GrosRobot.FermeBrasBasDroite();

            GrosRobot.Avancer(480);
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(550);
            GrosRobot.PivotGauche(90);
            GrosRobot.Reculer(300);
            GrosRobot.OuvreBrasBasDroite();
            Thread.Sleep(150);
            GrosRobot.OuvreBrasBasGauche();
            GrosRobot.Avancer(300);
            GrosRobot.PivotDroite(90);

            GrosRobot.Avancer(400);
            GrosRobot.BougeBrasBasGauche(662);
            GrosRobot.Avancer(400);
            GrosRobot.FermeBrasBasGauche();
            Thread.Sleep(150);
            GrosRobot.FermeBrasBasDroite();
            Thread.Sleep(1000);
            GrosRobot.PivotGauche(180);
            GrosRobot.Reculer(205);
            GrosRobot.Avancer(135);
            GrosRobot.PivotDroite(90);
            GrosRobot.OuvreBrasBasDroite();
            Thread.Sleep(150);
            GrosRobot.OuvreBrasBasGauche();
            GrosRobot.Avancer(1190);
            GrosRobot.FermeBrasBasGauche();
            Thread.Sleep(150);
            GrosRobot.FermeBrasBasDroite();
            GrosRobot.Avancer(100);
            GrosRobot.PivotGauche(90);
            GrosRobot.VitesseDeplacement = 500;
            GrosRobot.AccelerationDeplacement = 500;
            GrosRobot.Reculer(125);
            GrosRobot.VitesseDeplacement = 800;
            GrosRobot.AccelerationDeplacement = 1300;
            GrosRobot.Avancer(420);
            GrosRobot.PivotGauche(90);
            GrosRobot.OuvreBrasBasDroite();
            Thread.Sleep(150);
            GrosRobot.BougeBrasBasGauche(662);
            Thread.Sleep(1000);
            GrosRobot.Avancer(1100);
            GrosRobot.PivotDroite(45);
            GrosRobot.Avancer(600);
            GrosRobot.OuvreBrasBasGauche();
            GrosRobot.PivotGauche(45);
            GrosRobot.Reculer(228);
            Thread.Sleep(400);
            GrosRobot.OuvreBrasMilieuDroite();
            GrosRobot.OuvreBrasHautDroite();
            GrosRobot.BougeBrasBasDroite(600);
            GrosRobot.BougeBrasBasGauche(600);
            GrosRobot.PivotDroite(135);
            GrosRobot.Avancer(257);
            GrosRobot.FermeBrasMilieuDroite();
            GrosRobot.FermeBrasHautDroite();
            Thread.Sleep(400);
            GrosRobot.OuvreBrasMilieuDroite();
            GrosRobot.OuvreBrasHautDroite();
            GrosRobot.FermeBrasBasDroite();
            GrosRobot.FermeBrasHautDroite();
            GrosRobot.Avancer(421);
            GrosRobot.PivotDroite(100);
            GrosRobot.Avancer(376);
            GrosRobot.FermeBrasMilieuDroite();
            GrosRobot.FermeBrasHautDroite();
            GrosRobot.Reculer(376);
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(797);
            GrosRobot.PivotDroite(180);
            GrosRobot.OuvrirBenne();
            Thread.Sleep(500);
            GrosRobot.Avancer(50);
            GrosRobot.Reculer(50);
            GrosRobot.FermeBenne();
            GrosRobot.Avancer(144);

            /*
        // Go chez l'adversaire
        GrosRobot.PivotDroite(90);
        GrosRobot.Avancer(630);
        GrosRobot.PivotDroite(100);
        GrosRobot.VitesseDeplacement = 1500;
        GrosRobot.AccelerationDeplacement = 1400;
        GrosRobot.OuvreBrasBasDroite();
        Thread.Sleep(150);
        GrosRobot.OuvreBrasBasGauche();
        Thread.Sleep(500);
        DateTime debut2 = DateTime.Now;
        GrosRobot.Avancer(1580);
        GrosRobot.OuvreBrasBasDroite();
        Thread.Sleep(150);
        GrosRobot.BougeBrasBasGauche(481);
        Thread.Sleep(700);
        GrosRobot.Avancer(450);
        GrosRobot.FermeBrasBasGauche();
        Thread.Sleep(150);
        GrosRobot.FermeBrasBasDroite();
        Thread.Sleep(1000);
        GrosRobot.Reculer(2150);
        GrosRobot.PivotDroite(170);
        GrosRobot.Avancer(300);
        GrosRobot.OuvreBrasBasDroite();
        Thread.Sleep(150);
        GrosRobot.OuvreBrasBasGauche();
        Thread.Sleep(1000);
        GrosRobot.VitesseDeplacement = 700;
        GrosRobot.AccelerationDeplacement = 700;
        GrosRobot.Reculer(200);
            */

            Console.WriteLine((DateTime.Now - debut).TotalSeconds + "s");
        }

        private void ThreadEnchainementRouge()
        {

        }
    }
}
