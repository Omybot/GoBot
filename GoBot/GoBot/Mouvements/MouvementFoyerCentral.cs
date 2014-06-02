using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actionneur;
using GoBot.ElementsJeu;
using GoBot.Calculs;
using System.Threading;

namespace GoBot.Mouvements
{
    class MouvementFoyerCentral : Mouvement
    {
        int nbFeuxPoses = 0;
        List<bool> deposeDroite;

        public MouvementFoyerCentral()
        {
            Robot = Robots.GrosRobot;
            deposeDroite = new List<bool>();
            deposeDroite.Add(false);
            deposeDroite.Add(false);
            deposeDroite.Add(false);
            deposeDroite.Add(false);

            Positions.AddRange(PositionsMouvements.PositionsFoyerCentral);
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début dépose central");

            Position position = PositionProche;

            if (Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                while (BrasFeux.FeuxStockes.Count > 0)
                {
                    Feu feuHaut = BrasFeux.FeuxStockes[BrasFeux.FeuxStockes.Count() - 1];
                    if (feuHaut.Couleur == Plateau.NotreCouleur)
                    {
                        Robot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, true);
                        if (BrasFeux.FeuxStockes.Count == 3)
                            BrasFeux.PositionInterne3();
                        else if (BrasFeux.FeuxStockes.Count == 2)
                            BrasFeux.PositionInterne2();
                        else if (BrasFeux.FeuxStockes.Count == 1)
                            BrasFeux.PositionInterne1();
                        else
                            return true;

                        Thread.Sleep(500);

                        BrasFeux.PositionInterne3();
                        Thread.Sleep(400);
                        BrasFeux.PositionTorcheDessus(true);
                        Thread.Sleep(400);
                        BrasFeux.PositionPousseFoyer();
                        Thread.Sleep(400);

                        Robots.GrosRobot.Lent();
                        Robots.GrosRobot.Avancer(120);
                        Robots.GrosRobot.Rapide();
                        Robots.GrosRobot.ActionneurOnOff(ActionneurOnOffID.GRPompeFeu, false);
                        BrasFeux.PositionTorcheDessus();
                        Thread.Sleep(100);
                        BrasFeux.PositionInterne3();
                        Robots.GrosRobot.Reculer(120);

                        feuHaut.Position = new Calculs.Formes.PointReel(1500, 950 + nbFeuxPoses * 50);

                        nbFeuxPoses++;
                        Plateau.Score += 2;
                    }
                    else
                    {
                        Robot.PivotDroite(90);

                        if (BrasFeux.FeuxStockes.Count == 3)
                            BrasFeux.MoveDeposeRetourne3();
                        else if (BrasFeux.FeuxStockes.Count == 2)
                            BrasFeux.MoveDeposeRetourne2();
                        else if (BrasFeux.FeuxStockes.Count == 1)
                            BrasFeux.MoveDeposeRetourne1();
                        else
                            return true;

                        Robot.PivotGauche(90);

                        feuHaut.Position = new Calculs.Formes.PointReel(1700, 950 + nbFeuxPoses * 50);

                        nbFeuxPoses++;
                        Plateau.Score += 2;
                    }

                    feuHaut.Charge = false;
                    feuHaut.Positionne = true;
                    feuHaut.Couleur = Plateau.NotreCouleur;
                    BrasFeux.FeuxStockes.Remove(feuHaut);
                }
            }
            return true;
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
