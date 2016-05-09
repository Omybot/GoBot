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
    class MouvementDune2 : Mouvement
    {
        private bool ramasse;

        public MouvementDune2()
        {
            ramasse = false;
            Robot = Robots.GrosRobot;
            Element = new ZoneInteret(new PointReel(1500, 40), Color.White, 200);
            Positions.Add(new Position(-90, new PointReel(1538, 315)));
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début attrape dune phase 2");

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null)
            {
                Trajectoire traj = PathFinder.ChercheTrajectoire(Robot.Graph, Plateau.ListeObstacles, new Position(Robot.Position), position, Robot.Rayon, 160);

                if (traj != null && Robot.ParcourirTrajectoire(traj))
                {
                    Robots.GrosRobot.VitesseAdaptableEnnemi = false;

                    Actionneur.BarreDePompes.Aspirer();

                    Robots.GrosRobot.Lent();
                    Robots.GrosRobot.VitesseDeplacement = 50;

                    if (Robots.Simulation)
                        Robots.GrosRobot.Avancer(100);
                    else
                        Robots.GrosRobot.Recallage(SensAR.Avant);

                    Thread.Sleep(200);
                    Robots.GrosRobot.AccelerationDebutDeplacement = 50;
                    Robots.GrosRobot.AccelerationFinDeplacement = 50;

                    Robots.GrosRobot.Reculer(100);
                    Robots.GrosRobot.Lent();
                    Actionneur.PinceVerrou.FermerAvecEtape();
                    Actionneur.BarreDePompes.Maintien();
                    Thread.Sleep(800);
                    Plateau.AvantCharge = true;
                    Plateau.EtapeDune++;

                    ramasse = true;
                    Robots.GrosRobot.Historique.Log("Fin attrapage dune phase 2 en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                    
                    return true;
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Annulation attrapage dune phase 2, trajectoire échouée");
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
            get { return Plateau.EtapeDune == 1 ? 100000 : 0; }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
        public override string ToString()
        {
            return "Attrape de la dune phase 2";
        }
    }
}
