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
    class MouvementDune1 : Mouvement
    {
        private bool ramasse;

        public MouvementDune1()
        {
            ramasse = false;
            Robot = Robots.GrosRobot;
            Element = new ZoneInteret(new PointReel(1500, 160), Color.White, 200);
            Positions.Add(new Position(90, new PointReel(1500, 400)));
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début attrape dune phase 1");

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null)
            {
                Trajectoire traj = PathFinder.ChercheTrajectoire(Robot.Graph, Plateau.ListeObstacles, new Position(Robot.Position), position, Robot.Rayon, 160);

                if (traj != null && Robot.ParcourirTrajectoire(traj))
                {
                    Robots.GrosRobot.VitesseAdaptableEnnemi = false;
                    Actionneur.BrasDroite.Fermer();
                    Actionneur.BrasGauche.Fermer();
                    Actionneur.PinceBas.Ouvrir();

                    Thread.Sleep(300);

                    Robots.GrosRobot.Lent();

                    if (Robots.Simulation)
                        Robots.GrosRobot.Reculer(195);
                    else
                        Robots.GrosRobot.Recallage(SensAR.Arriere);

                    Thread.Sleep(200);
                    Actionneur.PinceBas.Fermer();
                    Thread.Sleep(1000);

                    Robots.GrosRobot.Avancer(60);
                    Actionneur.MaintienDune.Fermer();
                    Thread.Sleep(500);

                    Plateau.ArriereCharge = true;
                    Plateau.EtapeDune++;

                    ramasse = true;
                    Robots.GrosRobot.Historique.Log("Fin attrapage dune phase 1 en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                    
                    return true;
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Annulation attrapage dune phase 1, trajectoire échouée");
                    return false;
                }
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation attrapage dune phase 1, trajectoire non trouvée");
                return false;
            }
        }

        public override double Score
        {
            get { return Plateau.EtapeDune == 0 ? 100000 : 0; }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
        public override string ToString()
        {
            return "Attrape de la dune phase 1";
        }
    }
}
