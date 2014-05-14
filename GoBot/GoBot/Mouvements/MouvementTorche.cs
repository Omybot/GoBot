using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.ElementsJeu;
using GoBot.Calculs.Formes;

namespace GoBot.Mouvements
{
    class MouvementTorche : Mouvement
    {
        private int numeroTorche;
        private List<Feu> feux;

        public MouvementTorche(int i)
        {
            numeroTorche = i;
            Position = PositionsMouvements.PositionTorche[i];
            feux = new List<Feu>();

            if (numeroTorche == 0)
            {
                feux.Add(Plateau.Feux[5]);
                feux.Add(Plateau.Feux[4]);
                feux.Add(Plateau.Feux[3]);
            }
            if (numeroTorche == 1)
            {
                feux.Add(Plateau.Feux[12]);
                feux.Add(Plateau.Feux[11]);
                feux.Add(Plateau.Feux[10]);
            }
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début torche " + numeroTorche);

            if (Robots.GrosRobot.GotoXYTeta(Position.Coordonnees.X, Position.Coordonnees.Y, Position.Angle.AngleDegres))
            {
                if (BrasFeux.FeuxStockes.Count < 3 && !feux[0].Charge && !feux[0].Positionne)
                {
                    BrasFeux.MoveAttrapeTorche3();
                    BrasFeux.FeuxStockes.Add(feux[0]);
                    feux[0].Charge = true;

                    Robots.GrosRobot.Historique.Log("Feu haut attrapé");
                }
                if (BrasFeux.FeuxStockes.Count < 3 && !feux[1].Charge && !feux[1].Positionne)
                {
                    BrasFeux.MoveAttrapeTorche2();
                    BrasFeux.FeuxStockes.Add(feux[1]);
                    feux[1].Charge = true;

                    Robots.GrosRobot.Historique.Log("Feu milieu attrapé");
                }
                if (BrasFeux.FeuxStockes.Count < 3 && !feux[2].Charge && !feux[2].Positionne)
                {
                    BrasFeux.MoveAttrapeTorche1();
                    BrasFeux.FeuxStockes.Add(feux[2]);
                    feux[2].Charge = true;

                    Robots.GrosRobot.Historique.Log("Feu bas attrapé");
                    Plateau.ObstaclesFixes.Remove(Plateau.ObstaclesTorches[numeroTorche]);
                }
                Robots.GrosRobot.Historique.Log("Fin torche " + numeroTorche);

                return true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation torche " + numeroTorche);
                return false;
            }
        }

        public override int Score
        {
            get { return 3; }
        }

        public override double ScorePondere
        {
            get 
            {
                int nbFeux = 0;
                foreach(Feu feu in feux)
                    if (!feu.Charge && !feu.Positionne)
                        nbFeux++;

                return nbFeux / 3.0 * (3 - BrasFeux.FeuxStockes.Count) * Score;
            }
        }
    }
}
