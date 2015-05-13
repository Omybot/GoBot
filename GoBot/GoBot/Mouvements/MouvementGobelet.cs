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
    class MouvementGobelet : Mouvement
    {
        private int numeroGobelet;
        private int distanceAttrapage = 150;

        public override double Score
        {
            // Verifie que le pied nous appartient (bonne couleur) et qu'il n'est pas déjà ramassé
            get
            {
                if (!BonneCouleur())
                    return 0;

                // On ne veut pas attraper avec le bras réservé aux spots
                if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune && Actionneur.BrasGobelet == Actionneur.BrasPiedsDroite)
                    return 0;

                if (Plateau.NotreCouleur == Plateau.CouleurDroiteVert && Actionneur.BrasGobelet == Actionneur.BrasPiedsGauche)
                    return 0;

                if (Element.Ramasse)
                    return 0;

                if (Actionneur.BrasGobelet.NbPieds > 0)
                    return 0;

                if (Actionneur.BrasGobelet.Gobelet)
                    return 0;
                
                return 2;
            }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }

        public MouvementGobelet(int i, Color couleur)
        {
            numeroGobelet = i;
            Element = Plateau.Gobelets[i];

            PointReel point = new PointReel(Plateau.Gobelets[i].Position);
            List<Angle> anglesPossibles = new List<Angle>();

            switch(numeroGobelet)
            {
                case 0:
                    if (couleur == Plateau.CouleurDroiteVert)
                    {

                    }
                    else
                    {

                    }
                    break;
                case 1:
                    if (couleur == Plateau.CouleurDroiteVert)
                    {
                        Positions.Add(new Position(180-11.69, new PointReel(3000-1807, 851)));
                        Positions.Add(new Position(180-314.64, new PointReel(3000-1954, 1079)));
                        Couleur = Plateau.CouleurDroiteVert;
                    }
                    else
                    {
                        Positions.Add(new Position(339.16, new PointReel(682, 1000)));
                        Positions.Add(new Position(236.16, new PointReel(1125, 1016)));
                        Positions.Add(new Position(200, new PointReel(1193, 850)));
                        Positions.Add(new Position(48.14, new PointReel(670, 679)));
                        Couleur = Plateau.CouleurGaucheJaune;
                    }
                    break;
                case 2:
                    if (couleur == Plateau.CouleurDroiteVert)
                    {
                        Positions.Add(new Position(180-29.97, new PointReel(3000-1224, 1581)));
                        Positions.Add(new Position(180 - 133.19, new PointReel(3000 - 1629, 1397)));
                        Couleur = Plateau.CouleurDroiteVert;
                    }
                    else
                    {
                        Positions.Add(new Position(29.97, new PointReel(1224, 1581)));
                        Positions.Add(new Position(133.19, new PointReel(1629, 1397)));
                        Couleur = Plateau.CouleurGaucheJaune;
                    }
                    break;
                case 3:
                    if (couleur == Plateau.CouleurDroiteVert)
                    {
                        Positions.Add(new Position(180-339.16, new PointReel(3000-682, 1000)));
                        Positions.Add(new Position(180 - 236.16, new PointReel(3000 - 1125, 1016)));
                        Positions.Add(new Position(180 - 200, new PointReel(3000 - 1193, 850)));
                        Positions.Add(new Position(180 - 48.14, new PointReel(3000 - 670, 679)));
                        Couleur = Plateau.CouleurDroiteVert;
                    }
                    else
                    {
                        Positions.Add(new Position(11.69, new PointReel(1807, 851)));
                        Positions.Add(new Position(314.64, new PointReel(1954, 1079)));
                        Couleur = Plateau.CouleurGaucheJaune;
                    }
                    break;
                case 4:
                    if (couleur == Plateau.CouleurDroiteVert)
                    {

                    }
                    else
                    {

                    }
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
            Robots.GrosRobot.Historique.Log("Début gobelet " + numeroGobelet);

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Actionneur.BrasGobelet.AscenseurDescendre();

                Robot.Lent();
                Robot.Avancer(distanceAttrapage);
                Robot.Rapide();

                Actionneur.BrasGobelet.FermerPinceBas();
                Thread.Sleep(250);
                Actionneur.BrasGobelet.SouleverLegerement();
                Thread.Sleep(500);

                Robots.GrosRobot.Historique.Log("Fin gobelet " + numeroGobelet + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                Plateau.Gobelets[numeroGobelet].Ramasse = true;
                Actionneur.BrasGobelet.Gobelet = true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation gobelet " + numeroGobelet);
                return false;
            }
            return true;
        }
    }
}
