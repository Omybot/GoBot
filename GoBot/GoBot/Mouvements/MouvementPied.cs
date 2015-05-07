using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using GoBot.Calculs.Formes;

namespace GoBot.Mouvements
{
    class MouvementPied : Mouvement
    {
        private const int DIFF_X_BRAS_DROIT = 78;
        private const int DIFF_Y_BRAS_DROIT = 123;
        private const int DIFF_X_BRAS_GAUCHE = 78;
        private const int DIFF_Y_BRAS_GAUCHE = 123;

        /*                  a     b
         *                <---> <--->
         *                    ___                             Avec le robot dans ce sens de lecture
         *            |\  1  /   \  2  / |
         *         ^  | \___/     \___/  |  ^                 1 = Point central pince gauche
         *       c |  |                  |  | d               2 = Point central pince droite
         *         v  |        3         |  v                 3 = Point central du robot
         *            |                  |
         *            |                  |                    DIFF_X_BRAS_DROIT = a
         *            |__________________|                    DIFF_Y_BRAS_DROIT = c
         *                                                    DIFF_X_BRAS_GAUCHE = b                  
         *                                                    DIFF_Y_BRAS_GAUCHE = d
         * */

        private int numeroPied;
        private bool brasGauche = true;
        private int distanceAttrapage = 100;

        public override int Score
        {
            // Verifie que le pied nous appartient (bonne couleur) et qu'il n'est pas déjà ramassé
            get 
            { return    ((   (numeroPied < 8 && 
                             Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
                        ||
                            (numeroPied >= 8 &&
                             Plateau.NotreCouleur == Plateau.CouleurDroiteVert)
                        ) && !Plateau.Pieds[numeroPied].Ramasse) ? 1 : 0;
            }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }

        public MouvementPied(int i)
        {
            numeroPied = i;
            Element = Plateau.Pieds[i];

            PointReel point = new PointReel(Plateau.Pieds[i].Position);
            List<Angle> anglesPossibles = new List<Angle>();
            // TODO Samedi : Déterminer les angles d'attaque possibles / bras à utiliser pour chaque pied 

            switch(numeroPied)
            {
                case 0:
                    brasGauche = false;
                    Positions.Add(new Position(270-80.25, new PointReel(297, 314)));
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    distanceAttrapage = 94;
                    brasGauche = false;
                    Positions.Add(new Position(45, new PointReel(772, 1147)));
                    break;
                case 6:
                    brasGauche = false;
                    Positions.Add(new Position(96.92, new PointReel(1204, 1558)));
                    Positions.Add(new Position(0, new PointReel(877, 1692)));
                    break;
                case 7:
                    brasGauche = false;
                    Positions.Add(new Position(33.1, new PointReel(1156, 1213)));
                    break;
                
                // Pieds verts
                case 8:
                    brasGauche = true;
                    Positions.Add(new Position(180-33.1, new PointReel(3000-1156, 1213)));
                    break;
                case 9:
                    brasGauche = true;
                    Positions.Add(new Position(180 - 96.92, new PointReel(3000-1204, 1558)));
                    Positions.Add(new Position(180, new PointReel(3000-877, 1692)));
                    break;
                case 10:
                    brasGauche = true;
                    Positions.Add(new Position(180-45, new PointReel(3000-772, 1147)));
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    brasGauche = false;
                    Positions.Add(new Position(180 - (270 - 80.25), new PointReel(3000-297, 314)));
                    break;
            }

            foreach(Angle angle in anglesPossibles)
            {
                // Calcul de la position à atteindre en fonction du décallage prévu
                Positions.Add(new Position(angle, point));
            }

            Robot = Robots.GrosRobot;
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début pied " + numeroPied);

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Robot.Lent();
                Robot.Avancer(distanceAttrapage);
                Robot.Rapide();

                if(brasGauche)
                    Actionneur.BrasPiedsGauche.Empiler();
                else
                    Actionneur.BrasPiedsDroite.Empiler();

                Robots.GrosRobot.Historique.Log("Fin pied " + numeroPied + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                Plateau.Pieds[numeroPied].Ramasse = true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation pied " + numeroPied);
                return false;
            }
            return true;
        }
    }
}
