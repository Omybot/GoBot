using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using GoBot.Calculs.Formes;

namespace GoBot.Enchainements
{
    class EvitementPRMerdique : IEnchainement
    {
        private Thread th;
        Color couleur;

        public System.Drawing.Color GetCouleur()
        {
            return couleur;
        }

        public void SetCouleur(System.Drawing.Color couleur)
        {
            this.couleur = couleur;
        }

        public void Executer()
        {
            if (couleur == Color.Red)
                th = new Thread(ThreadEnchainementRouge);
            else
                th = new Thread(ThreadEnchainementViolet);

            th.Start();
        }

        private void ThreadEnchainementRouge()
        {
            PetitRobot.VitesseDeplacement = 500;
            PetitRobot.AccelerationDeplacement = 400;
            while (PetitRobot.Position.Coordonnees.X < 380)
            {
                PetitRobot.Avancer(50);
                bool ennemi = true;
                while (ennemi)
                {
                    ennemi = false;

                    foreach (PointReel p in GrosRobot.PositionsEnnemies)
                    {
                        if (p.X < 1000)
                        {
                            ennemi = true;
                            Thread.Sleep(1000);
                        }
                    }
                }
            }

            PetitRobot.PivotGauche(90);

            while (PetitRobot.Position.Coordonnees.Y < 1570)
            {
                PetitRobot.Avancer(50);
                bool ennemi = true;
                while (ennemi)
                {
                    ennemi = false;

                    foreach (PointReel p in GrosRobot.PositionsEnnemies)
                    {
                        if (p.X < 1000)
                        {
                            ennemi = true;
                            Thread.Sleep(1000);
                        }
                    }
                }
            }

            PetitRobot.Stop(StopMode.Freely);
        }

        private void ThreadEnchainementViolet()
        {
            PetitRobot.VitesseDeplacement = 500;
            PetitRobot.AccelerationDeplacement = 400;
            while (PetitRobot.Position.Coordonnees.X < 230)
            {
                PetitRobot.Avancer(50);
                bool ennemi = true;
                while (ennemi)
                {
                    ennemi = false;

                    foreach (PointReel p in GrosRobot.PositionsEnnemies)
                    {
                        if (p.X < 1000)
                        {
                            ennemi = true;
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
            PetitRobot.PivotGauche(90);

            while (PetitRobot.Position.Coordonnees.Y < 1570)
            {
                PetitRobot.Avancer(50);
                bool ennemi = true;
                while (ennemi)
                {
                    ennemi = false;

                    foreach (PointReel p in GrosRobot.PositionsEnnemies)
                    {
                        if (p.X < 1000)
                        {
                            ennemi = true;
                            Thread.Sleep(1000);
                        }
                    }
                }
            }

            PetitRobot.Stop(StopMode.Freely);
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Reprendre(int reculade)
        {
            throw new NotImplementedException();
        }
    }
}
