using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace GoBot.Enchainements
{   

    class TestEnchainement : Enchainement
    {
        private Thread thr;
        Color couleur;
        private Thread PetitRobo;
        private Thread GrosRobo;

        public TestEnchainement()
         {
            couleur = Color.Red;
        }
        public System.Drawing.Color GetCouleur()
        {
            return couleur;
        }

        public void SetCouleur(Color coulor)
        {
            couleur = coulor;
        }

        public void Executer()
        {
            if (couleur == Color.Red)
                thr = new Thread(ThreadEnchainementRouge);
            else
                thr = new Thread(ThreadEnchainementViolet);
            thr.Start();
        }

        private void ThreadEnchainementViolet()
        {
            PetitRobo = new Thread(PRThreadEnchainementViolet);
            GrosRobo = new Thread(GRThreadEnchainementViolet);
            //PetitRobo.Start();
            GrosRobo.Start();

        }

        private void ThreadEnchainementRouge()
        {
            PetitRobo = new Thread(PRThreadEnchainementViolet);
            GrosRobo = new Thread(GRThreadEnchainementViolet);
            //PetitRobo.Start();
            GrosRobo.Start();
            
        }

        private void PRThreadEnchainementViolet()
        {
            Thread.Sleep(1000);
            PetitRobot.Evitement = true;
            PetitRobot.VitesseDeplacement = 400;
            PetitRobot.VitessePivot = 400;
            PetitRobot.AccelerationDeplacement = 600;
            PetitRobot.AccelerationPivot = 600;

            PetitRobot.Avancer(550);
            PetitRobot.PivotDroite(90);
            PetitRobot.Avancer(640);
            PetitRobot.PivotDroite(90);
            PetitRobot.Avancer(300);
            PetitRobot.PivotDroite(90);
            PetitRobot.Avancer(300);

        }

        private void GRThreadEnchainementViolet()
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
            PetitRobo.Start();
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
        }
    }
}
