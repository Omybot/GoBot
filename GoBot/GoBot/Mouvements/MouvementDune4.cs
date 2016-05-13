﻿using System;
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
    class MouvementDune4 : Mouvement
    {
        private bool ramasse;

        public MouvementDune4()
        {
            ramasse = false;
            Positions.Add(new Position(-90, new PointReel(1538 - 58*3, 315)));
        }

        public override Color Couleur
        {
            get { return Color.White; }
        }

        public override Robot Robot
        {
            get { return Robots.GrosRobot; }
        }

        public override ElementJeu Element
        {
            get { return Plateau.Elements.ZoneDune4; }
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début attrape dune phase 4");

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
                    Robots.GrosRobot.Historique.Log("Fin attrapage dune phase 4 en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                    
                    return true;
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Annulation attrapage dune phase 4, trajectoire échouée");
                    return false;
                }
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation attrapage dune phase 4, trajectoire non trouvée");
                return false;
            }
        }

        public override double Score
        {
            get { return Plateau.EtapeDune == 4 ? 100000 : 0; }
        }

        public override double ValeurAction
        {
            get { return Score; }
        }
        public override string ToString()
        {
            return "Attrape de la dune phase 4";
        }
    }
}
