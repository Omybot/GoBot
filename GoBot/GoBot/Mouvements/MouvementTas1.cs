using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using GoBot.Calculs.Formes;
using GoBot.ElementsJeu;
using System.Drawing;
using System.Threading;

namespace GoBot.Mouvements
{
    class MouvementTas1 : Mouvement
    {
        private BrasPieds bras;
        int numeroPied1, numeroPied2;

        public override double Score
        {
            // Verifie que le pied nous appartient (bonne couleur) et qu'il n'est pas déjà ramassé
            get
            {
                if (Plateau.Pieds[numeroPied1].Ramasse || Plateau.Pieds[numeroPied2].Ramasse)
                    return 0;

                if (bras.NbPieds >= 3)
                    return 0;

                if (!BonneCouleur())
                    return 0;

                if (Actionneur.BrasAmpoule.AmpouleChargee)
                    return 0;

                return 6;
            }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }

        public MouvementTas1(Color couleur)
        {
            Couleur = couleur;

            if (couleur == Plateau.CouleurGaucheJaune)
            {
                numeroPied1 = 4;
                numeroPied2 = 3;
                Element = Plateau.Pieds[4];
                Positions.Add(new Position(-90, new PointReel(772, 763)));
                bras = Actionneur.BrasPiedsDroite;
            }
            else
            {
                numeroPied1 = 11;
                numeroPied2 = 12;
                Element = Plateau.Pieds[11];
                Positions.Add(new Position(-90, new PointReel(3000-772, 763)));
                bras = Actionneur.BrasPiedsGauche;
            }

            Robot = Robots.GrosRobot;
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début deux pieds haut piste");

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Robots.GrosRobot.Avancer(400);
                Robots.GrosRobot.Lent();
                Robots.GrosRobot.Avancer(60);
                bras.Empiler();
                Plateau.Pieds[numeroPied1].Ramasse = true;
                Thread.Sleep(200);
                Robots.GrosRobot.Avancer(90);
                bras.Empiler();
                Plateau.Pieds[numeroPied2].Ramasse = true;
                Robots.GrosRobot.Rapide();

                Robots.GrosRobot.Historique.Log("Fin deux pieds haut piste en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation deux pieds haut piste");
                return false;
            }
            return true;
        }
    }
}
