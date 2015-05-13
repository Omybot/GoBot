using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using GoBot.Calculs.Formes;
using GoBot.ElementsJeu;
using System.Threading;

namespace GoBot.Mouvements
{
    class MouvementAmpoulePied : Mouvement
    {
        private int numeroPied;
        private int distanceAttrapage = 78;
        private BrasPieds bras;

        public override double Score
        {
            // Verifie que le pied nous appartient (bonne couleur) et qu'il n'est pas déjà ramassé
            get
            {
                if (!Actionneur.BrasAmpoule.AmpouleChargee)
                    return 0;

                if (Element.Ramasse)
                    return 0;

                if (bras.NbPieds >= 4)
                    return 0;

                return (((Pied)Element).Couleur == Plateau.NotreCouleur) ? 3 : 0;
            }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }

        public MouvementAmpoulePied(int i)
        {
            numeroPied = i;
            Element = Plateau.Pieds[i];

            bras = Actionneur.BrasPiedsGauche;

            PointReel point = new PointReel(Plateau.Pieds[i].Position);
            List<Angle> anglesPossibles = new List<Angle>();

            switch (numeroPied)
            {
                case 0:
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
                    /*Positions.Add(new Position(217.45, new PointReel(682, 1211)));
                    Positions.Add(new Position(289.28, new PointReel(948, 1132)));
                    Positions.Add(new Position(74.19, new PointReel(934, 1581)));
                    Positions.Add(new Position(145.17, new PointReel(676, 1490)));
                    Positions.Add(new Position(1.21, new PointReel(1106, 1360)));*/

                    Positions.Add(new Position(221.54, new PointReel(657, 1167)));
                    Positions.Add(new Position(146.22, new PointReel(634, 1513)));
                    Positions.Add(new Position(97.73, new PointReel(832, 1637)));
                    Positions.Add(new Position(32.80, new PointReel(1109, 1509)));
                    Positions.Add(new Position(320.07, new PointReel(1088, 1173)));
                    break;
                case 6:
                    /*Positions.Add(new Position(296.13, new PointReel(1204, 1558)));
                    Positions.Add(new Position(199.28, new PointReel(877, 1692)));*/

                    Positions.Add(new Position(195.44, new PointReel(873, 1707)));
                    break;
                case 7:
                    /*Positions.Add(new Position(217.45, new PointReel(1112, 1256)));
                    Positions.Add(new Position(295.05, new PointReel(1400, 1186)));
                    Positions.Add(new Position(73.25, new PointReel(1368, 1626)));
                    Positions.Add(new Position(145.17, new PointReel(1106, 1535)));
                    Positions.Add(new Position(1.21, new PointReel(1536, 1405)));*/

                    Positions.Add(new Position(239.77, new PointReel(1157, 1155)));
                    Positions.Add(new Position(202.79, new PointReel(1038, 1290)));
                    Positions.Add(new Position(45.46, new PointReel(1499, 1602)));
                    Positions.Add(new Position(336.12, new PointReel(1560, 1282)));
                    break;

                // Pieds verts
                case 8:
                    break;
                case 9:
                    break;
                case 10:
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
                    break;
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
            Robots.GrosRobot.Historique.Log("Début dépose ampoule sur pied " + numeroPied);

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Actionneur.BrasAmpoule.DescendrePosePied(2);
                Robot.Lent();
                Robot.Reculer(distanceAttrapage);
                Actionneur.BrasAmpoule.DescendrePosePied(1);
                Thread.Sleep(3000);
                Actionneur.BrasAmpoule.Ouvrir();
                Thread.Sleep(250);
                Robot.Avancer(distanceAttrapage);
                Robot.Rapide();
                Plateau.Pieds[numeroPied].Ampoule = true;
                Actionneur.BrasAmpoule.AmpouleChargee = false;

                Robots.GrosRobot.Historique.Log("Fin dépose ampoule sur pied " + numeroPied + " en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation  dépose ampoule sur pied " + numeroPied);
                return false;
            }
            return true;
        }
    }
}
