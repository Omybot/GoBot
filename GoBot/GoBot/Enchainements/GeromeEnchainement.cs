using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using GoBot.Calculs.Formes;

namespace GoBot.Enchainements
{
    class GeromeEnchainement : IEnchainement
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
        }

        private void ThreadEnchainementViolet()
        {
            DateTime debut = DateTime.Now;

            GrosRobot.Evitement = false;
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

            // ATTAQUE DES CD 
            GrosRobot.OuvreBrasBasDroite();
            Thread.Sleep(150);
            GrosRobot.OuvreBrasBasGauche();



            bool ennemiGenant = false;
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
            ennemiGenant = true;

            if (ennemiGenant)
            {
                // Strat sans 2eme bouteille            
                
                GrosRobot.Avancer(950);
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
                GrosRobot.Avancer(732);
            }
            else
            {
                // strat avec 2eme bouteille
                GrosRobot.Avancer(1190);
                GrosRobot.FermeBrasBasGauche();
                Thread.Sleep(150);
                GrosRobot.FermeBrasBasDroite();

                // ATTAQUE BOUTEILLE 2
                GrosRobot.Avancer(64);
                GrosRobot.PivotGauche(90);
                GrosRobot.Reculer(135);

                //FIN BOUTEILLE 2   RETOUR CALE
                GrosRobot.Avancer(420);
                GrosRobot.PivotGauche(90);
                GrosRobot.OuvreBrasBasDroite();
                Thread.Sleep(150);
                GrosRobot.BougeBrasBasGauche(662);
                Thread.Sleep(1000);
                GrosRobot.Avancer(1036);
            }

            // Partie Avec 2eme bouteille


            // FIn propre bouteille 2


            GrosRobot.PivotDroite(45);
            GrosRobot.Avancer(600);

            // PIECE DANS LA CALE
            GrosRobot.OuvreBrasBasGauche();
            GrosRobot.PivotGauche(45);
            GrosRobot.Reculer(228);
            Thread.Sleep(400);

            //TOTEM PARTIE HAUTE Phase 1
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

            //DEUXIEM PARTIE DU TOTEM
            GrosRobot.Avancer(378);
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(269);
            GrosRobot.FermeBrasMilieuDroite();
            GrosRobot.FermeBrasHautDroite();
            GrosRobot.FermeBrasBasDroite();
            GrosRobot.FermeBrasBasGauche();

            // RETOUR TOTEM PARTIE HAUTE
            GrosRobot.Reculer(269);
            GrosRobot.PivotGauche(80);
            GrosRobot.Reculer(783);

            // DEPOSE TOTEM HAUT
            GrosRobot.OuvrirBenne();
            Thread.Sleep(500);
            GrosRobot.Avancer(50);
            GrosRobot.Reculer(50);
            GrosRobot.FermeBenne();


            //TOTEM LE BAS
            GrosRobot.OuvreBrasMilieuGauche();
            GrosRobot.OuvreBrasHautGauche();
            GrosRobot.BougeBrasBasDroite(600);
            GrosRobot.BougeBrasBasGauche(600);
            GrosRobot.PivotDroite(35);
            GrosRobot.Avancer(192);
            GrosRobot.PivotDroite(48);
            GrosRobot.Avancer(269);
            GrosRobot.FermeBrasMilieuGauche();
            GrosRobot.FermeBrasHautGauche();
            Thread.Sleep(400);
            GrosRobot.OuvreBrasMilieuGauche();
            GrosRobot.OuvreBrasHautGauche();

            //
            GrosRobot.Avancer(364);
            GrosRobot.PivotGauche(90);
            GrosRobot.Avancer(291);
            GrosRobot.FermeBrasMilieuGauche();
            GrosRobot.FermeBrasHautGauche();
            GrosRobot.FermeBrasBasGauche();
            GrosRobot.FermeBrasBasDroite();

            // RETOUR DU TOTEM PARTIE BAS

            GrosRobot.Reculer(291);
            GrosRobot.PivotDroite(90);
            GrosRobot.Reculer(884);
            GrosRobot.OuvrirBenne();
            GrosRobot.FermeBenne();
            Thread.Sleep(500);
            GrosRobot.Avancer(150);
            GrosRobot.PivotGauche(180);
            GrosRobot.BougeBrasBasDroite(600);
            GrosRobot.BougeBrasBasGauche(600);

            GrosRobot.Avancer(100);
            GrosRobot.Reculer(70);

            //  ATTAQUE DU HAUT
            GrosRobot.PivotGauche(105);
            GrosRobot.Avancer(700);
            GrosRobot.PivotDroite(90);
            GrosRobot.Avancer(539);
            GrosRobot.FermeBrasBasDroite();
            GrosRobot.FermeBrasBasGauche();
            GrosRobot.PivotDroite(147);
            GrosRobot.BougeBrasBasDroite(600);
            GrosRobot.BougeBrasBasGauche(600);
            GrosRobot.Avancer(643);
            GrosRobot.PivotGauche(40);
            GrosRobot.Avancer(200);
            GrosRobot.Reculer(200);
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
