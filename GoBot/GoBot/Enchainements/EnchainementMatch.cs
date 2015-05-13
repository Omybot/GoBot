using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GoBot.Actionneurs;
using System.Windows.Forms;
using GoBot.ElementsJeu;

namespace GoBot.Enchainements
{
    class EnchainementMatch : Enchainement
    {
        protected override void ThreadGros()
        {
            int iMeilleur = 0;

            // Ajouter ici les actions fixes avant le lancement de l'IA

            Actionneur.BrasAmpoule.Fermer();
            Thread.Sleep(350);
            Actionneur.BrasAmpoule.Hauteur(Config.CurrentConfig.AscenseurAmpoule.PositionPoseSur2Pied);

            Actionneur.BrasPiedsDroite.OuvrirPinceBas();
            Actionneur.BrasPiedsGauche.OuvrirPinceBas();
            Actionneur.BrasPiedsDroite.OuvrirPinceHaut();
            Actionneur.BrasPiedsGauche.OuvrirPinceHaut();
            Actionneur.BrasPiedsDroite.AscenseurDescendre();
            Actionneur.BrasPiedsGauche.AscenseurDescendre();

            Robots.GrosRobot.PivotGauche(7.93);

            Robots.GrosRobot.AccelerationFinDeplacement /= 3;
            Robots.GrosRobot.Avancer(570);

            //Robots.GrosRobot.Avancer(500);
            //Robots.GrosRobot.Lent();
            //Robots.GrosRobot.Avancer(70);

            Robots.GrosRobot.Rapide();
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
            {
                Actionneur.BrasPiedsGauche.FermerPinceBas();
                Thread.Sleep(200);
                Actionneur.BrasPiedsGauche.SouleverLegerement();
                Thread.Sleep(50);
                Actionneur.BrasPiedsGauche.Gobelet = true;
                Plateau.Gobelets[1].Ramasse = true;
                Actionneur.BrasPiedsDroite.Deverrouiller();
            }
            else
            {
                Actionneur.BrasPiedsDroite.FermerPinceBas();
                Thread.Sleep(200);
                Actionneur.BrasPiedsDroite.SouleverLegerement();
                Thread.Sleep(50);
                Actionneur.BrasPiedsDroite.Gobelet = true;
                Plateau.Gobelets[3].Ramasse = true;
                Actionneur.BrasPiedsGauche.Deverrouiller();
            }

            while (ListeMouvementsGros.Count > 0)
            {

                DateTime debut = DateTime.Now;

                double meilleurCout = double.MaxValue;
                for (int j = 0; j < ListeMouvementsGros.Count; j++)
                {
                    double cout = ListeMouvementsGros[j].Cout;
                    if (meilleurCout > cout)
                    {
                        meilleurCout = cout;
                        iMeilleur = j;
                    }
                }

                Console.WriteLine((DateTime.Now - debut).TotalMilliseconds + " ms de temps de décision");

                if (ListeMouvementsGros[iMeilleur].ScorePondere != 0)
                {
                    if (!ListeMouvementsGros[iMeilleur].Executer())
                        ListeMouvementsGros[iMeilleur].DateMinimum = DateTime.Now + new TimeSpan(0, 0, 10);
                }
                else
                {
                    try
                    {
                        Thread.Sleep(500);
                    }
                    catch(Exception)
                    {

                    }
                }
            }
            
        }

        protected override void ThreadPetit()
        {
            int iMeilleur = 0;
            return;
            // Ajouter ici les actions fixes avant le lancement de l'IA

        }
    }
}
