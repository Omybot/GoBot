﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using GoBot.Calculs.Formes;
using GoBot.ElementsJeu;
using GoBot.PathFinding;

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

        public override double Score
        {
            // Verifie que le pied nous appartient (bonne couleur) et qu'il n'est pas déjà ramassé
            get
            {
                if (Element.Ramasse)
                    return 0;

                if (Actionneur.BrasSpot.NbPieds >= 4)
                    return 0;

                if (!BonneCouleur())
                    return 0;

                if (Actionneur.BrasAmpoule.AmpouleChargee)
                    return 0;

                if (numeroPied == 3 && !Plateau.Pieds[4].Ramasse)
                    return 0;

                if (numeroPied == 12 && !Plateau.Pieds[11].Ramasse)
                    return 0;

                if (numeroPied == 1 && !Plateau.Gobelets[0].Ramasse)
                    return 0;

                if (numeroPied == 14 && !Plateau.Gobelets[4].Ramasse)
                    return 0;

                if (numeroPied == 2 && (!Plateau.Pieds[1].Ramasse || !Plateau.Gobelets[0].Ramasse))
                    return 0;

                if (numeroPied == 13 && (!Plateau.Pieds[14].Ramasse || !Plateau.Gobelets[4].Ramasse))
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
            Couleur = ((Pied)Element).Couleur;

            PointReel point = new PointReel(Plateau.Pieds[i].Position);

            switch (numeroPied)
            {
                case 0:
                    Positions.Add(new Position(185.53, new PointReel(355, 304)));
                    distanceAttrapage = 160;
                    break;

                case 1:
                    Positions.Add(new Position(117.27, new PointReel(252, 1606)));
                    distanceAttrapage = 85;
                    break;

                case 2:
                    Positions.Add(new Position(103.54, new PointReel(209, 1689)));
                    distanceAttrapage = 70;
                    break;

                case 3:
                    Positions.Add(new Position(270, new PointReel(772, 323)));
                    distanceAttrapage = 100;
                    break;

                case 4:
                    Positions.Add(new Position(270, new PointReel(772, 473)));
                    break;

                case 5:
                    Positions.Add(new Position(45.1, new PointReel(732, 1106)));
                    Positions.Add(new Position(97.73, new PointReel(984, 1095)));
                    Positions.Add(new Position(137.94, new PointReel(1125, 1230)));
                    Positions.Add(new Position(199.59, new PointReel(1101, 1520)));
                    Positions.Add(new Position(282.89, new PointReel(733, 1604)));
                    break;

                case 6:
                    Positions.Add(new Position(350.73, new PointReel(818, 1737)));
                    Positions.Add(new Position(49.75, new PointReel(983, 1511)));
                    Positions.Add(new Position(109.59, new PointReel(1265, 1539)));
                    break;

                case 7:
                    Positions.Add(new Position(6.82, new PointReel(1037, 1290)));
                    Positions.Add(new Position(293.6, new PointReel(1119, 1618)));
                    Positions.Add(new Position(77.47, new PointReel(1317, 1117)));
                    Positions.Add(new Position(170.31, new PointReel(1582, 1431)));
                    break;

                // Pieds verts
                case 8:
                    Positions.Add(new Position(173.18, new PointReel(1963, 1290)));
                    Positions.Add(new Position(-113.6, new PointReel(1881, 1616)));
                    Positions.Add(new Position(102.53, new PointReel(1683, 1117)));
                    Positions.Add(new Position(9.69, new PointReel(1418, 1431)));
                    break;

                case 9:
                    Positions.Add(new Position(-170.73, new PointReel(2182, 1737)));
                    Positions.Add(new Position(130.25, new PointReel(2017, 1511)));
                    Positions.Add(new Position(70.41, new PointReel(1735, 1539)));
                    break;

                case 10:
                    Positions.Add(new Position(134.9, new PointReel(2268, 1106)));
                    Positions.Add(new Position(82.27, new PointReel(2016, 1095)));
                    Positions.Add(new Position(42.06, new PointReel(1875, 1230)));
                    Positions.Add(new Position(-19.59, new PointReel(1899, 1520)));
                    Positions.Add(new Position(-102.89, new PointReel(2267, 1604)));
                    break;

                case 11:
                    Positions.Add(new Position(270, new PointReel(3000 - 772, 473)));
                    break;

                case 12:
                    Positions.Add(new Position(270, new PointReel(3000 - 772, 323)));
                    distanceAttrapage = 100;
                    break;

                case 13:
                    Positions.Add(new Position(180 - 103.54, new PointReel(3000 - 209, 1689)));
                    distanceAttrapage = 70;
                    break;

                case 14:
                    Positions.Add(new Position(180 - 117.27, new PointReel(3000 - 252, 1606)));
                    distanceAttrapage = 85;
                    break;

                case 15:
                    Positions.Add(new Position(180 - 185.53, new PointReel(3000 - 355, 304)));
                    distanceAttrapage = 160;
                    break;
            }

            Robot = Robots.GrosRobot;
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début pied " + numeroPied);

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null)
            {
                Trajectoire traj = PathFinder.ChercheTrajectoire(Robot.Graph, Plateau.ListeObstacles, new Position(Robot.Position), position, Robot.Rayon, 160);

                if (traj != null && Robot.ParcourirTrajectoire(traj))
                {
                    if (Actionneur.BrasSpot.NbPieds == 0)
                        Actionneur.BrasSpot.AscenseurDescendre();

                    Robots.GrosRobot.VitesseAdaptableEnnemi = false;
                    Robot.Lent();
                    Robot.Avancer(distanceAttrapage + 10);

                    bool clicNecessaire = false;

                    Robots.GrosRobot.DemandeValeursAnalogiquesIO();
                    if (Robots.GrosRobot.ValeursAnalogiquesIO[Actionneur.BrasSpot.PortAnalogiqueCapteur] > 2000)
                    {
                        if (Robots.GrosRobot.ValeursAnalogiquesIO[Actionneur.BrasSpot.PortAnalogiqueCapteur] < 3200)
                        {
                            clicNecessaire = true;
                        }
                    }
                    else
                    {
                        Robot.Rapide();
                        Robots.GrosRobot.Historique.Log("Annulation pied " + numeroPied + " par capteur négatif");
                        Plateau.Pieds[numeroPied].Ramasse = true;
                        return false;
                    }

                    Robot.Rapide();
                    Robots.GrosRobot.VitesseAdaptableEnnemi = true;
                    Actionneur.BrasSpot.Empiler(clicNecessaire);

                    Robots.GrosRobot.Historique.Log("Fin pied " + numeroPied + " en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");

                    Plateau.Pieds[numeroPied].Ramasse = true;
                    if (Plateau.Pieds[numeroPied].Ampoule)
                        Actionneur.BrasSpot.AmpouleSurSpot = true;

                    if (numeroPied == 0 || numeroPied == 13 || numeroPied == 2 || numeroPied == 15)
                        Robot.Reculer(distanceAttrapage + 15);
                    return true;
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Annulation pied " + numeroPied + ", trajectoire échouée");
                    return false;
                }
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation pied " + numeroPied + ", trajectoire non trouvée");
                return false;
            }
        }

        public override string ToString()
        {
            return "Pied " + numeroPied;
        }
    }
}
