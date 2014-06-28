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
            /*Robots.GrosRobot.Avancer(250);

            BrasFeux.PositionTorcheDessus(true);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotDroite(64);
            else
                Robots.GrosRobot.PivotGauche(64);
            */

            DateTime debut = DateTime.Now;

            Robots.GrosRobot.Avancer(20);
            BrasFeux.PositionTorcheDessus(true);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotDroite(19);
            else
                Robots.GrosRobot.PivotGauche(19);

            BrasFeux.PositionTorche2();
            Robots.GrosRobot.Avancer(285);

            //BrasFeux.PositionAspireDroit();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotDroite(45);
            else
                Robots.GrosRobot.PivotGauche(45);

            /*Robots.GrosRobot.AspirationAutomatique = true;
            Robots.GrosRobot.Avancer(487);
            Robots.GrosRobot.AspirationAutomatique = false;*/
            Robots.GrosRobot.Avancer(487);

            BrasFeux.PositionSolProche();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(500);
            BrasFeux.PositionTorcheDessus();
            Thread.Sleep(500);
            BrasFeux.PositionInterne3();
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(50);
            BrasFeux.PositionInterne3();

            BrasFeux.PositionTorcheDessus(true);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotGauche(90);
            else
                Robots.GrosRobot.PivotDroite(90);

            Robots.GrosRobot.Avancer(230);

            // Vidage de la torche
            BrasFeux.MoveAttrapeTorche3();
            BrasFeux.MoveAttrapeTorche2DeposeInverse();
            BrasFeux.MoveAttrapeTorche1();

            Robots.GrosRobot.Reculer(100);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotGauche(69.69);
            else
                Robots.GrosRobot.PivotDroite(69.69);

            Robots.GrosRobot.Reculer(602);
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotGauche(155.4);
            else
                Robots.GrosRobot.PivotDroite(155.4);

            // Dépose 1er feu
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Thread.Sleep(50);
            BrasFeux.PositionTorcheDessus();
            Robots.GrosRobot.Avancer(80);
            BrasFeux.PositionTorche2();
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(200);
            BrasFeux.PositionInterne3();
            Robots.GrosRobot.Reculer(150);

            // Dépose 2eme feu
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            BrasFeux.PositionInterne2();
            Thread.Sleep(300);
            BrasFeux.PositionInterne3();
            Thread.Sleep(100);
            BrasFeux.PositionTorcheDessus(true);
            Thread.Sleep(300);
            BrasFeux.PositionPousseFoyer();
            Thread.Sleep(300);
            Robots.GrosRobot.Avancer(105);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotGauche(14);
            else
                Robots.GrosRobot.PivotDroite(14);

            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(50);
            BrasFeux.PositionTorcheDessus();
            Thread.Sleep(300);
            BrasFeux.PositionInterne3();
            Thread.Sleep(300);

            // Dépose 3eme feu
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            BrasFeux.PositionInterne1();
            Thread.Sleep(300);
            BrasFeux.PositionInterne3();
            Thread.Sleep(300);
            BrasFeux.PositionTorcheDessus();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotDroite(40);
            else
                Robots.GrosRobot.PivotGauche(40);

            Thread.Sleep(300);
            BrasFeux.PositionPousseFoyer();
            Thread.Sleep(500);

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotGauche(14);
            else
                Robots.GrosRobot.PivotDroite(14);

            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(50);
            BrasFeux.PositionTorcheDessus();
            Thread.Sleep(300);
            BrasFeux.PositionInterne3();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
            {
                Plateau.TorchesVidees[0] = true;
            }
            else
            {
                Plateau.TorchesVidees[1] = true;
            }


            Robots.GrosRobot.Reculer(100);
#if true //kudo
            //feu 
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                Robots.GrosRobot.PivotGauche(150);
            else
                Robots.GrosRobot.PivotDroite(150);
            BrasFeux.PositionTorcheDessus();
            Robots.GrosRobot.Avancer(320);
            /*Robots.GrosRobot.Avancer(300);
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(50);*/
            //Robots.GrosRobot.Rapide();
            BrasFeux.PositionTorche2();
            Thread.Sleep(300);
            Robots.GrosRobot.Reculer(200);

            // Ramasse Feu
            Robots.GrosRobot.Lent();
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            Robots.GrosRobot.Avancer(100);

            BrasFeux.PositionSolProche();
            Thread.Sleep(500);
            BrasFeux.PositionTorcheDessus();
            Thread.Sleep(500);
            BrasFeux.PositionInterne3();
            Thread.Sleep(500);
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
            Thread.Sleep(50);
            BrasFeux.PositionInterne3();
            Robots.GrosRobot.Rapide();

            BrasFeux.FeuxStockes.Add(new Feu(new Calculs.Formes.PointReel(0, 0), Plateau.NotreCouleur, false, 0));
            //

            //Thread.Sleep(5000);
            //Thread.Sleep(10000);
#endif
            //FEU BORDURE
            Mouvements.Mouvement moveFeuBordure;
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
            {
                moveFeuBordure = new Mouvements.MouvementFeuBordure(7);
            }
            else
            {
                moveFeuBordure = new Mouvements.MouvementFeuBordure(8);
            }
            moveFeuBordure.Executer();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
            {
                moveFeuBordure = new Mouvements.MouvementFeuBordure(8);
            }
            else
            {
                moveFeuBordure = new Mouvements.MouvementFeuBordure(7);
            }
            moveFeuBordure.Executer();

            //MouVEMENT CENTRALE
            Mouvements.MouvementFoyerCentral moveCentral;
            moveCentral = new Mouvements.MouvementFoyerCentral();
            moveCentral.Executer();

            //ARBRE
            Mouvements.MouvementArbre move;
            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                move = new Mouvements.MouvementArbre(1);
            else
                move = new Mouvements.MouvementArbre(2);

            move.Executer();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                moveFeuBordure = new Mouvements.MouvementFeuBordure(0);
            else
                moveFeuBordure = new Mouvements.MouvementFeuBordure(15);

            moveFeuBordure.Executer();

            Robots.GrosRobot.PivotDroite(90);

            BrasFeux.MoveDeposeRetourne1();

            if (Plateau.NotreCouleur == Plateau.CouleurGaucheRouge)
                move = new Mouvements.MouvementArbre(0);
            else
                move = new Mouvements.MouvementArbre(3);

            move.Executer();

            return;

            while (ListeMouvementsGros.Count > 0)
            {
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

                if (ListeMouvementsGros[iMeilleur].ScorePondere != 0)
                {
                    if (!ListeMouvementsGros[iMeilleur].Executer())
                        ListeMouvementsGros[iMeilleur].DateMinimum = DateTime.Now + new TimeSpan(0, 0, 10);
                }
                else
                    Thread.Sleep(500);
            }
        }

        protected override void ThreadPetit()
        {
            int iMeilleur = 0;
            return;
            // Ajouter ici les actions fixes avant le lancement de l'IA

            Thread.Sleep(1500);
            Robots.PetitRobot.Avancer(400);

            // On arrête de lancer des actions à 87secondes de match
            while (ListeMouvementsPetit.Count > 0 && (DateTime.Now - Plateau.Enchainement.DebutMatch).TotalSeconds < 87)
            {
                double meilleurCout = double.MaxValue;
                for (int j = 0; j < ListeMouvementsPetit.Count; j++)
                {
                    double cout = ListeMouvementsPetit[j].Cout;
                    if (meilleurCout > cout)
                    {
                        meilleurCout = cout;
                        iMeilleur = j;
                    }
                }

                if (ListeMouvementsPetit[iMeilleur].ScorePondere != 0)
                {
                    if (!ListeMouvementsPetit[iMeilleur].Executer())
                        ListeMouvementsPetit[iMeilleur].DateMinimum = DateTime.Now + new TimeSpan(0, 0, 10);
                }
                else
                {
                    Console.WriteLine("Rien à faire");
                    Thread.Sleep(500);
                }
            }
        }
    }
}
