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
    class Gerome4Enchainement : IEnchainement
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

        private void ThreadEnchainementViolet()
        {
            DateTime debut = DateTime.Now;
            if (couleur == Color.Red)
                GrosRobot.Evitement = false;

            //GrosRobot.Evitement = false;

            Thread.Sleep(1000);

            //GrosRobot.Evitement = false;
            GrosRobot.VitesseDeplacement = 950;
            GrosRobot.VitessePivot = 900;
            GrosRobot.AccelerationDeplacement = 1400;
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
            /*if (GrosRobot.Evitement && couleur == Color.Purple)
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
                GrosRobot.DroitBrasBasGauche();//662 avant
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
                Thread.Sleep(300);
                GrosRobot.PivotGauche(90);
                GrosRobot.Reculer(135);

                //FIN BOUTEILLE 2   RETOUR CALE
                //GrosRobot.DroitBrasBasDroite();//modif
                GrosRobot.OuvreBrasBasDroite();
                GrosRobot.OuvreBrasBasGauche();
                Thread.Sleep(400);
                GrosRobot.Avancer(420);

                GrosRobot.FermeBrasBasDroite(); // ne pas ouvrir
                GrosRobot.FermeBrasBasGauche(); // ne pas ouvrir

                Thread.Sleep(300);
                GrosRobot.PivotGauche(90);
                GrosRobot.OuvreBrasBasDroite(); // ouvre à gauche
                GrosRobot.DroitBrasBasGauche(); // ouvre à gauche
                Thread.Sleep(1500);
                GrosRobot.Avancer(1036);
                GrosRobot.PivotDroite(45);
                GrosRobot.Avancer(600);
            }




            // PIECE DANS LA CALE
            GrosRobot.PivotGauche(45);
            GrosRobot.OuvreBrasBasGauche();
            GrosRobot.DroitBrasBasGauche();
            GrosRobot.DroitBrasBasDroite();

            GrosRobot.Reculer(328);
            GrosRobot.FermeBrasBasDroite();
            GrosRobot.FermeBrasBasGauche();

            GrosRobot.PivotDroite(115);
            GrosRobot.Avancer(722);
            GrosRobot.PivotDroite(80);

            // ATtaque en face

            GrosRobot.DroitBrasBasDroite();
            GrosRobot.DroitBrasBasGauche();
            Thread.Sleep(500);

            GrosRobot.Avancer(1340);
            GrosRobot.OuvreBrasBasDroite();
            GrosRobot.OuvreBrasBasGauche();
            Thread.Sleep(700);
            GrosRobot.Avancer(260);
            GrosRobot.FermeBrasBasGauche();
            GrosRobot.FermeBrasBasDroite();
            Thread.Sleep(1000);
            GrosRobot.Reculer(1850);
            GrosRobot.PivotDroite(110);
            GrosRobot.DroitBrasBasDroite();
            GrosRobot.DroitBrasBasGauche();
            Thread.Sleep(1000);

            
            GrosRobot.Avancer(780);
            GrosRobot.Reculer(332);

            GrosRobot.PivotGauche(35);
            GrosRobot.Avancer(346);


            GrosRobot.PivotGauche(135);  //LAAAAAA

            //TOTEM PARTIE HAUTE Phase 1
            GrosRobot.OuvreBrasMilieuDroite();
            GrosRobot.OuvreBrasHautDroite();
            Thread.Sleep(600);
            //GrosRobot.BougeBrasBasGauche(286);
            GrosRobot.Avancer(244);
            Thread.Sleep(200);
            GrosRobot.AttraperDroite();

            //DEUXIEME PARTIE DU TOTEM
            GrosRobot.Avancer(431);
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(270);
            GrosRobot.AttraperDroite();
            GrosRobot.Avancer(10);
            GrosRobot.FermeBrasBasDroite();
            GrosRobot.FermeBrasBasGauche();
            Thread.Sleep(1000);

            // RETOUR TOTEM PARTIE HAUTE
            GrosRobot.Reculer(290);
            GrosRobot.PivotGauche(70);
            GrosRobot.Reculer(712);

            // DEPOSE TOTEM HAUT
            GrosRobot.OuvrirBenne();
            Thread.Sleep(500);
            GrosRobot.Avancer(50);
            GrosRobot.Reculer(50);
            GrosRobot.FermeBenne();
            GrosRobot.Avancer(300);
            GrosRobot.PivotGauche(180);
            GrosRobot.Avancer(300);    //LA
            GrosRobot.DroitBrasBasGauche();
            GrosRobot.DroitBrasBasDroite();
            Thread.Sleep(400);
            GrosRobot.Reculer(300);
            GrosRobot.PivotGauche(65);
            GrosRobot.Avancer(401);
            GrosRobot.PivotGauche(45);
            //GrosRobot.FermeBrasBasGauche();
            //GrosRobot.FermeBrasBasDroite();

            //TOTEM LE BAS
            GrosRobot.OuvreBrasMilieuGauche();
            GrosRobot.OuvreBrasHautGauche();
            //GrosRobot.BougeBrasBasDroite(707);
            //Thread.Sleep(1000);
            //GrosRobot.BougeBrasBasGauche(600);
            //Thread.Sleep(1000);
            //GrosRobot.PivotGauche(108);// CHANGEMENT DU E
            GrosRobot.Avancer(98);
            GrosRobot.AttraperGauche();

            //TOTEM BAS PARTIE 2
            GrosRobot.Avancer(428);
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
            GrosRobot.Reculer(840);
            GrosRobot.OuvrirBenne();
            Thread.Sleep(500);
            GrosRobot.Avancer(50);
            GrosRobot.Reculer(50);
            Thread.Sleep(500);

            GrosRobot.Avancer(150);
            GrosRobot.PivotDroite(150);
            GrosRobot.OuvreBrasBasDroite();
            GrosRobot.OuvreBrasBasGauche();

            /*
            GrosRobot.Avancer(200);
            GrosRobot.DroitBrasBasDroite();
            GrosRobot.DroitBrasBasGauche();

            GrosRobot.PivotGauche(16);
            GrosRobot.FermeBrasBasDroite();
            GrosRobot.FermeBrasBasGauche();

            GrosRobot.Reculer(300);
            GrosRobot.PivotGauche(90);
            GrosRobot.Reculer(414);
            GrosRobot.PivotGauche(90);
            GrosRobot.Reculer(632);*/

            Console.WriteLine((DateTime.Now - debut).TotalMilliseconds / 1000.0 + "s");
        }
    }
}
