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
    class MouvementTas2 : Mouvement
    {
        private BrasPieds brasPieds, brasGobelet;
        int numeroPied1, numeroPied2;
        int numeroGobelet;

        public override double Score
        {
            // Verifie que le pied nous appartient (bonne couleur) et qu'il n'est pas déjà ramassé
            get
            {
                if (Plateau.Pieds[numeroPied1].Ramasse || Plateau.Pieds[numeroPied2].Ramasse || Plateau.Gobelets[numeroGobelet].Ramasse)
                    return 0;

                if (brasPieds.NbPieds >= 3 || brasGobelet.Gobelet)
                    return 0;

                if (!BonneCouleur())
                    return 0;

                if (Actionneur.BrasAmpoule.AmpouleChargee)
                    return 0;

                return 7;
            }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }

        public MouvementTas2(Color couleur)
        {
            Couleur = couleur;

            if (couleur == Plateau.CouleurGaucheJaune)
            {
                numeroPied1 = 1;
                numeroPied2 = 2;
                Element = Plateau.Pieds[1];
                numeroGobelet = 0;
                Positions.Add(new Position(138.85, new PointReel(437, 1483)));
                brasPieds = Actionneur.BrasPiedsDroite;
                brasGobelet = Actionneur.BrasPiedsGauche;
            }
            else
            {
                numeroPied1 = 14;
                numeroPied2 = 15;
                Element = Plateau.Pieds[14];
                numeroGobelet = 4;
                Positions.Add(new Position(180-138.85, new PointReel(3000-437, 1483)));
                brasPieds = Actionneur.BrasPiedsGauche;
                brasGobelet = Actionneur.BrasPiedsDroite;
            }

            Robot = Robots.GrosRobot;
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début deux pieds et gobelet bas piste");

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Robots.GrosRobot.Lent();

                Robots.GrosRobot.Avancer(193);
                brasGobelet.FermerPinceBas();
                Thread.Sleep(200);
                brasGobelet.SouleverLegerement();
                brasGobelet.Gobelet = true;
                Plateau.Gobelets[numeroGobelet].Ramasse = true;

                Thread.Sleep(200);

                if(Couleur == Plateau.CouleurDroiteVert)
                    Robots.GrosRobot.PivotDroite(12.17);
                else
                    Robots.GrosRobot.PivotGauche(12.17);

                Robots.GrosRobot.Avancer(109);
                brasPieds.Empiler();
                Plateau.Pieds[numeroPied1].Ramasse = true;

                if (Couleur == Plateau.CouleurDroiteVert)
                    Robots.GrosRobot.PivotDroite(17.34);
                else
                    Robots.GrosRobot.PivotGauche(17.34);

                Robots.GrosRobot.Avancer(66);
                brasPieds.Empiler();
                Plateau.Pieds[numeroPied2].Ramasse = true;

                Robots.GrosRobot.Historique.Log("Fin deux pieds et gobelet bas piste en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation deux pieds et gobelet bas piste");
                return false;
            }
            return true;
        }
    }
}
