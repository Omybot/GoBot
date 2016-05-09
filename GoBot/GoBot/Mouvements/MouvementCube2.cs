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
    class MouvementCube2 : Mouvement
    {
        private bool ramasse;

        public MouvementCube2()
        {
            ramasse = false;
            Robot = Robots.GrosRobot;
            Element = new ZoneInteret(new PointReel(902, 80), Color.White, 90);
            Positions.Add(new Position(0, new PointReel(3000 - (446 + 1378), 298)));
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début attrape cube 2");

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null)
            {
                Trajectoire traj = PathFinder.ChercheTrajectoire(Robot.Graph, Plateau.ListeObstacles, new Position(Robot.Position), position, Robot.Rayon, 160);

                if (traj != null && Robot.ParcourirTrajectoire(traj))
                {
                    Actionneur.BrasGauche.Ouvrir();
                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Reculer(200);


                    Actionneur.BrasGauche.Deployer();
                    Thread.Sleep(750);

                    Robots.GrosRobot.PivotDroite(1);

                    for (int i = 0; i < 10; i++)
                    {
                        Actionneur.BrasGauche.Fermer();
                        Thread.Sleep(100);
                    }

                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.Avancer(190);
                    Robots.GrosRobot.PivotGauche(90);

                    ramasse = true;
                    Robots.GrosRobot.Historique.Log("Fin attrape cube 2 en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");

                    return true;
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Annulation attrape cube 2, trajectoire échouée");
                    return false;
                }
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation attrape cube 2, trajectoire non trouvée");
                return false;
            }
        }

        public override double Score
        {
            get { return 0; }
            //get { return !ramasse && !Plateau.AvantCharge && !Plateau.ArriereCharge ? 100 : 0; }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
        public override string ToString()
        {
            return "Attrape cube 2";
        }
    }
}
