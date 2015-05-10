using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using System.Threading;

namespace GoBot.Mouvements
{
    class MouvementDistributeur : Mouvement
    {
        int numeroDistributeur;

        public MouvementDistributeur(int i)
        {
            numeroDistributeur = i;
            Element = Plateau.DistributeursPopCorn[i];

            if(i == 0)
                Positions.Add(new Calculs.Position(-158, new Calculs.Formes.PointReel(398, 399)));
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début distributeur " + numeroDistributeur);

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Actionneur.BrasAspirateur.Aspirer();
                Thread.Sleep(500);
                Actionneur.BrasAspirateur.PositionAspire();
                Thread.Sleep(2000);
                Actionneur.BrasAspirateur.PositionRange();
                Actionneur.BrasAspirateur.Arreter();
                Plateau.DistributeursPopCorn[numeroDistributeur].Ramasse = true; 
                Robots.GrosRobot.Historique.Log("Fin distributeur " + numeroDistributeur + " en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation distributeur " + numeroDistributeur);
                return false;
            }
            return true;
        }

        public override int Score
        {
            get { return 2; }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
    }
}
