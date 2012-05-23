using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using GoBot.Calculs.Formes;
using System.Windows.Forms;

namespace GoBot.Enchainements
{
    class Gerome2Enchainement : IEnchainement
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
            /*if (couleur == Color.Red)
                th = new Thread(ThreadEnchainementRouge);
            else*/
                th = new Thread(ThreadEnchainementViolet);

            th.Start();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Reprendre(int reculade)
        {
            throw new NotImplementedException();
        }

        private void ThreadEnchainementRouge()
        {
        }

        private void ThreadEnchainementVioletsave()
        {
            DateTime debut = DateTime.Now;
            if (couleur == Color.Red)
                GrosRobot.Evitement = false;

            GrosRobot.Evitement = false;

            //GrosRobot.Evitement = false;
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

            GrosRobot.Avancer(480);  //LINGO
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(550);
            GrosRobot.PivotGauche(90);
            GrosRobot.Reculer(300);
            GrosRobot.OuvreBrasBasDroite();
            Thread.Sleep(150);
            GrosRobot.OuvreBrasBasGauche();
            GrosRobot.Avancer(300);
            GrosRobot.PivotDroite(90);

            // ATTAQUE BOUTEILLE UNE
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

            bool ennemiGenant = false;
            /*if (couleur == Color.Purple)
            {
                List<PointReel> points = new List<PointReel>();
                points.Add(new PointReel(1775, 1000));
                points.Add(new PointReel(3000, 1000));
                points.Add(new PointReel(3000, 2000));
                points.Add(new PointReel(1775, 2000));
                Polygone zoneGenante = new Polygone(points);

                if (zoneGenante != null && GrosRobot.PositionsEnnemies != null)
                {
                    foreach (PointReel p in GrosRobot.PositionsEnnemies)
                    {
                        if (p != null && zoneGenante.contient(p))
                            ennemiGenant = true;
                    }
                }
            }
            else
                ennemiGenant = true;*/

            if (ennemiGenant)
            {
                // Strat sans 2eme bouteille            

                GrosRobot.Avancer(780);
                GrosRobot.FermeBrasBasGauche();
                Thread.Sleep(150);
                GrosRobot.FermeBrasBasDroite();


                GrosRobot.PivotGauche(90);
                GrosRobot.OuvreBrasBasDroite();
                Thread.Sleep(150);
                GrosRobot.BougeBrasBasGauche(662);
                Thread.Sleep(1000);
                GrosRobot.Avancer(285);
                GrosRobot.PivotGauche(90);
                GrosRobot.Avancer(562);
                GrosRobot.PivotDroite(45);
                GrosRobot.Avancer(600);
            }
            else
            {
                // strat avec 2eme bouteille
                // ATTAQUE DES CD 
                GrosRobot.OuvreBrasBasDroite();
                Thread.Sleep(150);
                GrosRobot.OuvreBrasBasGauche();
                GrosRobot.Avancer(1190);
                GrosRobot.FermeBrasBasGauche();
                Thread.Sleep(150);
                GrosRobot.FermeBrasBasDroite();

                // ATTAQUE BOUTEILLE 2
                GrosRobot.Avancer(64);
                GrosRobot.PivotGauche(90);
                GrosRobot.Reculer(135);

                //FIN BOUTEILLE 2   RETOUR CALE
                GrosRobot.OuvreBrasBasDroite();
                Thread.Sleep(150);
                GrosRobot.BougeBrasBasGauche(662);
                GrosRobot.Avancer(420);

                GrosRobot.BougeBrasBasDroite(400);
                Thread.Sleep(300);
                GrosRobot.PivotGauche(90);
                GrosRobot.OuvreBrasBasDroite();
                Thread.Sleep(300);
                GrosRobot.Avancer(1036);
                GrosRobot.PivotDroite(45);
                GrosRobot.Avancer(600);
            }


            

            // PIECE DANS LA CALE
            GrosRobot.OuvreBrasBasGauche();
            GrosRobot.PivotGauche(45);
            GrosRobot.Reculer(197);
            Thread.Sleep(400);

            //TOTEM PARTIE HAUTE Phase 1
            GrosRobot.OuvreBrasMilieuDroite();
            GrosRobot.OuvreBrasHautDroite();
            GrosRobot.BougeBrasBasDroite(400);
            Thread.Sleep(1000);
            GrosRobot.BougeBrasBasGauche(286);
            GrosRobot.PivotDroite(135);
            GrosRobot.Avancer(258);
            Thread.Sleep(400);
            GrosRobot.AttraperDroite();

            //DEUXIEM PARTIE DU TOTEM
            GrosRobot.Avancer(421);
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(270);
            GrosRobot.AttraperDroite();
            GrosRobot.Avancer(10);
            GrosRobot.FermeBrasBasDroite();
            Thread.Sleep(1000);
            GrosRobot.FermeBrasBasGauche();
            Thread.Sleep(1000);

            // RETOUR TOTEM PARTIE HAUTE
            GrosRobot.Reculer(280);
            GrosRobot.PivotGauche(70);
            GrosRobot.Reculer(712);

            // DEPOSE TOTEM HAUT
            GrosRobot.OuvrirBenne();
            Thread.Sleep(500);
            GrosRobot.Avancer(50);
            GrosRobot.Reculer(50);
            GrosRobot.FermeBenne();


            //TOTEM LE BAS
            GrosRobot.OuvreBrasMilieuGauche();
            GrosRobot.OuvreBrasHautGauche();
            GrosRobot.BougeBrasBasDroite(707);
            Thread.Sleep(1000);
            GrosRobot.BougeBrasBasGauche(600);
            Thread.Sleep(1000);
            GrosRobot.PivotDroite(72);
            GrosRobot.Avancer(512);
            GrosRobot.AttraperGauche();

            //TOTEM BAS PARTIE 2
            GrosRobot.Avancer(413);
            GrosRobot.PivotGauche(90);
            GrosRobot.Avancer(285);
            GrosRobot.AttraperGauche();
            GrosRobot.Avancer(10);
            GrosRobot.FermeBrasBasGauche();
            Thread.Sleep(400);
            GrosRobot.FermeBrasBasDroite();
            Thread.Sleep(1000);

            // RETOUR DU TOTEM PARTIE BAS

            GrosRobot.Reculer(295);
            GrosRobot.PivotDroite(90);
            GrosRobot.Reculer(925);
            GrosRobot.OuvrirBenne();
            Thread.Sleep(500);
            GrosRobot.Avancer(50);
            GrosRobot.Reculer(50);
            Thread.Sleep(500);

            GrosRobot.Avancer(150);
            GrosRobot.PivotDroite(150);
            GrosRobot.Avancer(300);
            GrosRobot.OuvreBrasBasDroite();
            GrosRobot.OuvreBrasBasGauche();
            Thread.Sleep(500);
            //GrosRobot.Reculer(400);

            /*GrosRobot.PivotGauche(92);
            GrosRobot.Avancer(672);
                GrosRobot.PivotDroite(60);
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
                GrosRobot.Avancer(270);
                GrosRobot.FermeBrasBasGauche();
                Thread.Sleep(150);
                GrosRobot.FermeBrasBasDroite();
                Thread.Sleep(1000);
                GrosRobot.Reculer(2045);
            GrosRobot.PivotGauche(90);
            GrosRobot.OuvreBrasBasDroite();
                Thread.Sleep(150);
                GrosRobot.OuvreBrasBasGauche();
            Thread.Sleep(1000);
            GrosRobot.Reculer(100);
            GrosRobot.VitesseDeplacement = 700;
                GrosRobot.AccelerationDeplacement = 700;
                GrosRobot.Reculer(200);*/

            Console.WriteLine((DateTime.Now - debut).TotalSeconds + "s");
        }

        private void ThreadEnchainementViolet()
        {
            DateTime debut = DateTime.Now;
            if (couleur == Color.Red)
                GrosRobot.Evitement = false;

            //GrosRobot.Evitement = false;

            //GrosRobot.Evitement = false;
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

            GrosRobot.Avancer(480);  //LINGO
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(550);
            GrosRobot.PivotGauche(90);
            GrosRobot.Reculer(300);
            GrosRobot.OuvreBrasBasDroite();
            Thread.Sleep(150);
            GrosRobot.OuvreBrasBasGauche();
            GrosRobot.Avancer(300);
            GrosRobot.PivotDroite(90);

            // ATTAQUE BOUTEILLE UNE
            GrosRobot.Avancer(400);
            GrosRobot.DroitBrasBasGauche();

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

            bool ennemiGenant = false;
            if (GrosRobot.Evitement && couleur == Color.Purple)
            {
                List<PointReel> points = new List<PointReel>();
                points.Add(new PointReel(1775, 1000));
                points.Add(new PointReel(3000, 1000));
                points.Add(new PointReel(3000, 2000));
                points.Add(new PointReel(1775, 2000));
                Polygone zoneGenante = new Polygone(points);

                if (zoneGenante != null && GrosRobot.PositionsEnnemies != null)
                {
                    foreach (PointReel p in GrosRobot.PositionsEnnemies)
                    {
                        if (p != null && zoneGenante.contient(p))
                            ennemiGenant = true;
                    }
                }
            }
            else
                ennemiGenant = true;

            if (ennemiGenant)
            {
                // Strat sans 2eme bouteille            

                GrosRobot.Avancer(780);
                GrosRobot.FermeBrasBasGauche();
                Thread.Sleep(150);
                GrosRobot.FermeBrasBasDroite();


                GrosRobot.PivotGauche(90);
                GrosRobot.OuvreBrasBasDroite();
                Thread.Sleep(150);
                GrosRobot.BougeBrasBasGauche(662);
                Thread.Sleep(1000);
                GrosRobot.Avancer(285);
                GrosRobot.PivotGauche(90);
                GrosRobot.Avancer(562);
                GrosRobot.PivotDroite(45);
                GrosRobot.Avancer(600);
            }
            else
            {
                // strat avec 2eme bouteille
                // ATTAQUE DES CD 
                GrosRobot.OuvreBrasBasDroite();
                Thread.Sleep(150);
                GrosRobot.OuvreBrasBasGauche();
                GrosRobot.Avancer(1190);
                GrosRobot.FermeBrasBasGauche();
                Thread.Sleep(150);
                GrosRobot.FermeBrasBasDroite();

                // ATTAQUE BOUTEILLE 2
                GrosRobot.Avancer(64);
                GrosRobot.PivotGauche(90);
                GrosRobot.Reculer(135);

                //FIN BOUTEILLE 2   RETOUR CALE
                GrosRobot.OuvreBrasBasDroite();
                GrosRobot.DroitBrasBasGauche();

                GrosRobot.Avancer(420);

                GrosRobot.DroitBrasBasGauche();

                Thread.Sleep(300);
                GrosRobot.PivotGauche(90);
                GrosRobot.OuvreBrasBasDroite();
                Thread.Sleep(300);
                GrosRobot.Avancer(1036);
                GrosRobot.PivotDroite(45);
                GrosRobot.Avancer(600);
            }




            // PIECE DANS LA CALE
            GrosRobot.OuvreBrasBasGauche();
            GrosRobot.PivotGauche(45);
            GrosRobot.Reculer(197);
            Thread.Sleep(400);

            //TOTEM PARTIE HAUTE Phase 1
            GrosRobot.OuvreBrasMilieuDroite();
            GrosRobot.OuvreBrasHautDroite();
            if (couleur == Color.Purple)
                GrosRobot.BougeBrasBasDroite(450);
            else
                GrosRobot.BougeBrasBasGauche(662);

            Thread.Sleep(1000);
            GrosRobot.BougeBrasBasGauche(286);
            GrosRobot.PivotDroite(135);
            GrosRobot.Avancer(258);
            Thread.Sleep(400);
            GrosRobot.AttraperDroite();

            //DEUXIEM PARTIE DU TOTEM
            GrosRobot.Avancer(421);
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(270);
            GrosRobot.AttraperDroite();
            GrosRobot.Avancer(10);
            GrosRobot.FermeBrasBasDroite();
            Thread.Sleep(1000);
            GrosRobot.FermeBrasBasGauche();
            Thread.Sleep(1000);

            // RETOUR TOTEM PARTIE HAUTE
            GrosRobot.Reculer(280);
            GrosRobot.PivotGauche(70);
            GrosRobot.Reculer(712);

            // DEPOSE TOTEM HAUT
            GrosRobot.OuvrirBenne();
            Thread.Sleep(500);
            GrosRobot.Avancer(50);
            GrosRobot.Reculer(50);
            GrosRobot.FermeBenne();


            //TOTEM LE BAS
            GrosRobot.OuvreBrasMilieuGauche();
            GrosRobot.OuvreBrasHautGauche();
            GrosRobot.BougeBrasBasDroite(707);
            Thread.Sleep(1000);
            GrosRobot.BougeBrasBasGauche(600);
            Thread.Sleep(1000);
            GrosRobot.PivotDroite(72);
            GrosRobot.Avancer(512);
            GrosRobot.AttraperGauche();

            //TOTEM BAS PARTIE 2
            GrosRobot.Avancer(413);
            GrosRobot.PivotGauche(90);
            GrosRobot.Avancer(285);
            GrosRobot.AttraperGauche();
            GrosRobot.Avancer(10);
            GrosRobot.FermeBrasBasGauche();
            Thread.Sleep(400);
            GrosRobot.FermeBrasBasDroite();
            Thread.Sleep(1000);

            // RETOUR DU TOTEM PARTIE BAS

            GrosRobot.Reculer(295);
            GrosRobot.PivotDroite(90);
            GrosRobot.Reculer(925);
            GrosRobot.OuvrirBenne();
            Thread.Sleep(500);
            GrosRobot.Avancer(50);
            GrosRobot.Reculer(50);
            Thread.Sleep(500);

            GrosRobot.Avancer(150);
            GrosRobot.PivotDroite(150);
            GrosRobot.Avancer(300);
            GrosRobot.OuvreBrasBasDroite();
            GrosRobot.OuvreBrasBasGauche();
            Thread.Sleep(500);
            //GrosRobot.Reculer(400);

            /*GrosRobot.PivotGauche(92);
            GrosRobot.Avancer(672);
                GrosRobot.PivotDroite(60);
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
                GrosRobot.Avancer(270);
                GrosRobot.FermeBrasBasGauche();
                Thread.Sleep(150);
                GrosRobot.FermeBrasBasDroite();
                Thread.Sleep(1000);
                GrosRobot.Reculer(2045);
            GrosRobot.PivotGauche(90);
            GrosRobot.OuvreBrasBasDroite();
                Thread.Sleep(150);
                GrosRobot.OuvreBrasBasGauche();
            Thread.Sleep(1000);
            GrosRobot.Reculer(100);
            GrosRobot.VitesseDeplacement = 700;
                GrosRobot.AccelerationDeplacement = 700;
                GrosRobot.Reculer(200);*/





            Console.WriteLine((DateTime.Now - debut).TotalSeconds + "s");
        }
    }
}
