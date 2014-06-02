using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.ElementsJeu;
using System.Threading;
using GoBot.Actionneur;

namespace GoBot.Mouvements
{
    class MouvementDeposeFoyerCoin : Mouvement
    {
        int numeroFoyer;
        int nbFeuxPoses = 0;
        bool deposeDroite = false;

        public MouvementDeposeFoyerCoin(int i)
        {
            numeroFoyer = i;
            Positions.Add(PositionsMouvements.PositionFoyersCoins[i]);
            Robot = Robots.GrosRobot;
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début dépose coin " + numeroFoyer);

            Position position = PositionProche;

            if (Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                while (BrasFeux.FeuxStockes.Count > 0)
                {
                    Feu feuHaut = BrasFeux.FeuxStockes[BrasFeux.FeuxStockes.Count() - 1];
                    if (feuHaut.Couleur == Plateau.NotreCouleur)
                    {
                        // Le feu est dans le bon sens
                        if (nbFeuxPoses == 0)
                        {
                            Robots.GrosRobot.Historique.Log("Dépose coin " + BrasFeux.FeuxStockes.Count + " proche");
                            if (BrasFeux.FeuxStockes.Count == 3)
                                BrasFeux.MoveDeposeProche3();
                            else if (BrasFeux.FeuxStockes.Count == 2)
                                BrasFeux.MoveDeposeProche2();
                            else if (BrasFeux.FeuxStockes.Count == 1)
                                BrasFeux.MoveDeposeProche1();
                            else
                                return true;

                            /*Robots.GrosRobot.Lent();
                            Robots.GrosRobot.Avancer(50);
                            Robots.GrosRobot.Reculer(50);
                            Robots.GrosRobot.Rapide();*/

                            if (numeroFoyer == 0)
                                feuHaut.Position = new Calculs.Formes.PointReel(132, 1852);
                            else
                                feuHaut.Position = new Calculs.Formes.PointReel(2852, 1859);

                            nbFeuxPoses++;
                            Plateau.Score += 2;
                        }
                        else if (nbFeuxPoses == 1)
                        {
                            Robots.GrosRobot.Historique.Log("Dépose coin " + BrasFeux.FeuxStockes.Count + " en poussant le premier");
                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);

                            if (BrasFeux.FeuxStockes.Count == 3)
                                BrasFeux.PositionInterne3();
                            else if (BrasFeux.FeuxStockes.Count == 2)
                                BrasFeux.PositionInterne2();
                            else if (BrasFeux.FeuxStockes.Count == 1)
                                BrasFeux.PositionInterne1();
                            else
                                return true;

                            Robots.GrosRobot.Reculer(120);

                            BrasFeux.PositionInterne3();
                            Thread.Sleep(500);
                            BrasFeux.PositionTorcheDessus();
                            Thread.Sleep(500);
                            BrasFeux.PositionPousseFoyer();
                            Thread.Sleep(500);

                            Robots.GrosRobot.Lent();
                            Robots.GrosRobot.Avancer(120);
                            Robots.GrosRobot.Rapide();

                            Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
                            Thread.Sleep(500);
                            BrasFeux.PositionTorcheDessus();
                            Thread.Sleep(500);
                            BrasFeux.PositionInterne3();

                            if (numeroFoyer == 0)
                                feuHaut.Position = new Calculs.Formes.PointReel(66, 1922);
                            else
                                feuHaut.Position = new Calculs.Formes.PointReel(2918, 1922);

                            nbFeuxPoses++;
                            Plateau.Score += 2;
                        }
                        else
                        {
                            Robots.GrosRobot.Historique.Log("Dépose coin " + BrasFeux.FeuxStockes.Count + " pivoté");

                            Robots.GrosRobot.Reculer(60);

                            if(!deposeDroite)
                                Robots.GrosRobot.PivotDroite(90);
                            else
                                Robots.GrosRobot.PivotGauche(90);

                            if (BrasFeux.FeuxStockes.Count == 3)
                                BrasFeux.MoveDeposeProche3();
                            else if (BrasFeux.FeuxStockes.Count == 2)
                                BrasFeux.MoveDeposeProche2();
                            else if (BrasFeux.FeuxStockes.Count == 1)
                                BrasFeux.MoveDeposeProche1();
                            else
                                return true;

                            // Si il reste encore des feux à décharger
                            if (BrasFeux.FeuxStockes.Count > 1)
                            {
                                if (!deposeDroite)
                                    Robots.GrosRobot.PivotGauche(90);
                                else
                                    Robots.GrosRobot.PivotDroite(90);

                                Robots.GrosRobot.Avancer(60);
                            }

                            if (numeroFoyer == 0 && !deposeDroite)
                                feuHaut.Position = new Calculs.Formes.PointReel(154, 1568);
                            else if (numeroFoyer == 0 && deposeDroite)
                                feuHaut.Position = new Calculs.Formes.PointReel(409, 1822);
                            else if (numeroFoyer == 1 && deposeDroite)
                                feuHaut.Position = new Calculs.Formes.PointReel(2848, 1586);
                            else if (numeroFoyer == 1 && !deposeDroite)
                                feuHaut.Position = new Calculs.Formes.PointReel(2520, 1830);

                            deposeDroite = true;
                            Plateau.Score += 1;
                        }
                    }
                    else
                    {
                        Robots.GrosRobot.Historique.Log("Dépose coin " + BrasFeux.FeuxStockes.Count + " pivoté inversé");
                        Robots.GrosRobot.Reculer(60);
                        // Feu dans le mauvais sens
                        if (!deposeDroite)
                            Robots.GrosRobot.PivotDroite(90);
                        else
                            Robots.GrosRobot.PivotGauche(90);

                        if (BrasFeux.FeuxStockes.Count == 3)
                            BrasFeux.MoveDeposeRetourne3();
                        else if (BrasFeux.FeuxStockes.Count == 2)
                            BrasFeux.MoveDeposeRetourne2();
                        else if (BrasFeux.FeuxStockes.Count == 1)
                            BrasFeux.MoveDeposeRetourne1();
                        else
                            return true;
                        
                        // Si il reste encore des feux à décharger
                        if (BrasFeux.FeuxStockes.Count > 1)
                        {
                            if (!deposeDroite)
                                Robots.GrosRobot.PivotGauche(90);
                            else
                                Robots.GrosRobot.PivotDroite(90);
                            Robots.GrosRobot.Avancer(60);
                        }

                        if (numeroFoyer == 0 && !deposeDroite)
                            feuHaut.Position = new Calculs.Formes.PointReel(154, 1568);
                        else if (numeroFoyer == 0 && deposeDroite)
                            feuHaut.Position = new Calculs.Formes.PointReel(409, 1822);
                        else if (numeroFoyer == 1 && deposeDroite)
                            feuHaut.Position = new Calculs.Formes.PointReel(2848, 1586);
                        else if (numeroFoyer == 1 && !deposeDroite)
                            feuHaut.Position = new Calculs.Formes.PointReel(2520, 1830);

                        deposeDroite = true;

                        Plateau.Score += 1;
                    }

                    feuHaut.Charge = false;
                    feuHaut.Positionne = true;
                    feuHaut.Couleur = Plateau.NotreCouleur;
                    BrasFeux.FeuxStockes.Remove(feuHaut);
                }
                
                Robots.GrosRobot.Historique.Log("Fin dépose coin");
                return true;
            }
            else
                return false;
        }

        public override int Score
        {
            get 
            {
                int feuxSensOk = 0;

                foreach (Feu feu in BrasFeux.FeuxStockes)
                    if (feu.Couleur == Plateau.NotreCouleur)
                        feuxSensOk++;

                return 2 * feuxSensOk * (2 - nbFeuxPoses); 
            }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
    }
}
