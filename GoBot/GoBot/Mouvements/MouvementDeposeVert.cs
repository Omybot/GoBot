using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Actionneurs;
using System.Threading;
using GoBot.Calculs;
using GoBot.Calculs.Formes;
using GoBot.PathFinding;
using GoBot.ElementsJeu;
using System.Drawing;

namespace GoBot.Mouvements
{
    class MouvementDeposeVert : Mouvement
    {
        private bool ramasse;

        public MouvementDeposeVert()
        {
            ramasse = false;
            Positions.Add(new Position(90, new PointReel(3000 - 300, 700)));
        }

        public override Color Couleur
        {
            get { return Plateau.CouleurDroiteVert; }
        }

        public override Robot Robot
        {
            get { return Robots.GrosRobot; }
        }

        public override ElementJeu Element
        {
            get { return Plateau.Elements.ZoneDeposeVert1; }
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début dépose vert");

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null)
            {
                Trajectoire traj = PathFinder.ChercheTrajectoire(Robot.Graph, Plateau.ListeObstacles, new Position(Robot.Position), position, Robot.Rayon, 160);

                if (traj != null && Robot.ParcourirTrajectoire(traj))
                {
                    Robots.GrosRobot.Avancer(270);
                    Robots.GrosRobot.PivotDroite(90);
                    Robots.GrosRobot.Avancer(800);

                    Actionneur.BarreDePompes.Stop();
                    Actionneur.PinceVerrou.Ranger();

                    Plateau.AvantCharge = false;
                    Thread.Sleep(800);

                    Robots.GrosRobot.Reculer(320);
                    Robots.GrosRobot.PivotDroite(180);
                    Robots.GrosRobot.Reculer(260);

                    Actionneur.PinceBas.Ouvrir();
                    Actionneur.MaintienDune.Ranger();
                    Thread.Sleep(300);
                    Plateau.ArriereCharge = false;
                    Robots.GrosRobot.Rapide();

                    Robots.GrosRobot.Avancer(300);
                    Actionneur.PinceBas.Fermer();
                    Plateau.EtapeDune++;

                    ramasse = true;
                    Robots.GrosRobot.Historique.Log("Fin dépose vert en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");

                    return true;
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Annulation dépose vert, trajectoire échouée");
                    return false;
                }
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation dépose vert, trajectoire non trouvée");
                return false;
            }
        }

        public override double Score
        {
            get { return BonneCouleur() && Plateau.EtapeDune == 2 ? 100000 : 0; }
        }

        public override double ValeurAction
        {
            get { return Score; }
        }

        public override string ToString()
        {
            return "Dépose violet";
        }
    }
}
