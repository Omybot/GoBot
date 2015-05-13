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
                    Positions.Add(new Position(21.53, new PointReel(355, 304)));
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
                    Positions.Add(new Position(241.1, new PointReel(732, 1106)));
                    Positions.Add(new Position(293.73, new PointReel(984, 1095)));
                    Positions.Add(new Position(333.94, new PointReel(1125, 1230)));
                    Positions.Add(new Position(35.59, new PointReel(1101, 1520)));
                    Positions.Add(new Position(118.89, new PointReel(733, 1604)));

                    break;
                case 6:
                    Positions.Add(new Position(186.73, new PointReel(818, 1737)));
                    Positions.Add(new Position(245.75, new PointReel(983, 1511)));
                    Positions.Add(new Position(305.59, new PointReel(1265, 1539)));

                    break;
                case 7:
                    Positions.Add(new Position(202.82, new PointReel(1037, 1290)));
                    Positions.Add(new Position(129.6, new PointReel(1119, 1618)));
                    Positions.Add(new Position(273.47, new PointReel(1317, 1117)));
                    Positions.Add(new Position(6.31, new PointReel(1582, 1431)));

                    break;

                // Pieds verts
                case 8:
                    Positions.Add(new Position(337.18, new PointReel(1963, 1290)));
                    Positions.Add(new Position(50.4, new PointReel(1881, 1618)));
                    Positions.Add(new Position(266.53, new PointReel(1683, 1117)));
                    Positions.Add(new Position(173.69, new PointReel(1418, 1431)));


                    break;
                case 9:
                    Positions.Add(new Position(-6.73, new PointReel(2182, 1737)));
                    Positions.Add(new Position(294.25, new PointReel(2017, 1511)));
                    Positions.Add(new Position(234.41, new PointReel(1735, 1539)));

                    break;
                case 10:
                    Positions.Add(new Position(298.9, new PointReel(2268, 1106)));
                    Positions.Add(new Position(246.27, new PointReel(2016, 1095)));
                    Positions.Add(new Position(206.06, new PointReel(1875, 1230)));
                    Positions.Add(new Position(144.41, new PointReel(1899, 1520)));
                    Positions.Add(new Position(61.11, new PointReel(2267, 1604)));

                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    Positions.Add(new Position(-190.47, new PointReel(2645, 304)));
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

            Actionneur.BrasAmpoule.DescendrePosePied(1);
            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                int diff = (int)(1000 - ((DateTime.Now - debut).TotalMilliseconds));
                if (diff > 0 && diff <= 1000)
                    Thread.Sleep(diff);

                Robot.Lent();
                Robot.Reculer(distanceAttrapage);
                Actionneur.BrasAmpoule.Ouvrir();
                Thread.Sleep(200);
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
