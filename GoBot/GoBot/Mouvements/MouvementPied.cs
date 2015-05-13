using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using GoBot.Calculs.Formes;
using GoBot.ElementsJeu;

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
        private int distanceAttrapage = 150;
        private BrasPieds bras;

        public override double Score
        {
            // Verifie que le pied nous appartient (bonne couleur) et qu'il n'est pas déjà ramassé
            get
            {
                if (Element.Ramasse)
                    return 0;

                if (bras.NbPieds >= 4)
                    return 0;

                if (!BonneCouleur())
                    return 0;

                if (Actionneur.BrasAmpoule.AmpouleChargee)
                    return 0;

                if (Plateau.Pieds[numeroPied].Ampoule)
                    return 20;
                else
                    return 4;
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

            bras = Actionneur.BrasPiedsGauche;

            PointReel point = new PointReel(Plateau.Pieds[i].Position);
            List<Angle> anglesPossibles = new List<Angle>();

            switch (numeroPied)
            {
                case 0:
                    Positions.Add(new Position(270 - 80.25, new PointReel(297, 314)));
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
                    /*Positions.Add(new Position(18, new PointReel(682, 1211)));
                    Positions.Add(new Position(90, new PointReel(948, 1132)));
                    Positions.Add(new Position(234, new PointReel(934, 1581)));
                    Positions.Add(new Position(306, new PointReel(676, 1490)));
                    Positions.Add(new Position(162, new PointReel(1106, 1360)));*/

                    Positions.Add(new Position(25.6, new PointReel(657, 1167)));
                    Positions.Add(new Position(310.26, new PointReel(634, 1513)));
                    Positions.Add(new Position(261.78, new PointReel(832, 1637)));
                    Positions.Add(new Position(196.82, new PointReel(1109, 1509)));
                    Positions.Add(new Position(124.13, new PointReel(1088, 1173)));
                    break;
                case 6:
                    /*Positions.Add(new Position(96.92, new PointReel(1204, 1558)));
                    Positions.Add(new Position(0, new PointReel(877, 1692)));*/

                    Positions.Add(new Position(358.43, new PointReel(843, 1699)));
                    break;
                case 7:
                    /*Positions.Add(new Position(18, new PointReel(1112, 1256)));
                    Positions.Add(new Position(95.86, new PointReel(1400, 1186)));
                    Positions.Add(new Position(234, new PointReel(1368, 1626)));
                    Positions.Add(new Position(306, new PointReel(1106, 1535)));
                    Positions.Add(new Position(162, new PointReel(1536, 1405)));*/

                    Positions.Add(new Position(43.82, new PointReel(1157, 1155)));
                    Positions.Add(new Position(6.84, new PointReel(1038, 1290)));
                    Positions.Add(new Position(209.52, new PointReel(1499, 1602)));
                    Positions.Add(new Position(140.18, new PointReel(1560, 1282)));
                    break;

                // Pieds verts
                case 8:
                    Positions.Add(new Position(180 - 18, new PointReel(3000 - 1112, 1256)));
                    Positions.Add(new Position(180 - 95.86, new PointReel(3000 - 1400, 1186)));
                    Positions.Add(new Position(180 - 234, new PointReel(3000 - 1358, 1626)));
                    Positions.Add(new Position(180 - 306, new PointReel(3000 - 1106, 1535)));
                    Positions.Add(new Position(180 - 162, new PointReel(3000 - 1536, 1405)));
                    break;
                case 9:
                    Positions.Add(new Position(180 - 96.92, new PointReel(3000 - 1204, 1558)));
                    Positions.Add(new Position(180, new PointReel(3000 - 877, 1692)));
                    break;
                case 10:
                    Positions.Add(new Position(180 - 18, new PointReel(3000 - 682, 1211)));
                    Positions.Add(new Position(180 - 90, new PointReel(3000 - 948, 1132)));
                    Positions.Add(new Position(180 - 234, new PointReel(3000 - 934, 1581)));
                    Positions.Add(new Position(180 - 306, new PointReel(3000 - 676, 1490)));
                    Positions.Add(new Position(180 - 162, new PointReel(3000 - 1106, 1360)));
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
                    Positions.Add(new Position(180 - (270 - 80.25), new PointReel(3000 - 297, 314)));
                    break;
            }

            if (numeroPied < 8)
            {
                bras = Actionneur.BrasPiedsDroite;
                Couleur = Plateau.CouleurGaucheJaune;
            }
            else
            {
                bras = Actionneur.BrasPiedsGauche;
                Couleur = Plateau.CouleurDroiteVert;
            }

            foreach (Angle angle in anglesPossibles)
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
                if (bras.NbPieds == 0)
                    bras.AscenseurDescendre();

                Robot.Lent();
                Robot.Avancer(distanceAttrapage);

                Robots.GrosRobot.DemandeValeursAnalogiquesIO();
                if (Robots.GrosRobot.ValeursAnalogiquesIO[bras.PortAnalogiqueCapteur] > 2300)
                {
                    Robots.GrosRobot.DemandeValeursAnalogiquesIO();
                    if (Robots.GrosRobot.ValeursAnalogiquesIO[bras.PortAnalogiqueCapteur] < 3200)
                        Robots.GrosRobot.Avancer(40);
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Annulation pied " + numeroPied);
                    Plateau.Pieds[numeroPied].Ramasse = true;
                    return false;
                }

                Robots.GrosRobot.DemandeValeursAnalogiquesIO();

                if (Robots.GrosRobot.ValeursAnalogiquesIO[bras.PortAnalogiqueCapteur] < 3200)
                {
                    Robots.GrosRobot.Historique.Log("Annulation pied " + numeroPied);
                    Plateau.Pieds[numeroPied].Ramasse = true;
                    return false;
                }

                Robot.Rapide();
                bras.Empiler();

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
