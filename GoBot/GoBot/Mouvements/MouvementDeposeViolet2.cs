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
    class MouvementDeposeViolet2 : Mouvement
    {
        private bool ramasse;

        public MouvementDeposeViolet2()
        {
            ramasse = false;
            Robot = Robots.GrosRobot;
            Element = new ZoneInteret(new PointReel(1300, 1050), Plateau.CouleurGaucheViolet, 90);
            Couleur = Plateau.CouleurGaucheViolet;
            Positions.Add(new Position(90, new PointReel(500, 700)));
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début dépose violet");

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null)
            {
                Trajectoire traj = PathFinder.ChercheTrajectoire(Robot.Graph, Plateau.ListeObstacles, new Position(Robot.Position), position, Robot.Rayon, 160);

                if (traj != null && Robot.ParcourirTrajectoire(traj))
                {
                    Robots.GrosRobot.Avancer(270);
                    Robots.GrosRobot.PivotGauche(90);
                    Robots.GrosRobot.Avancer(400);

                    Actionneur.BarreDePompes.Stop();
                    Actionneur.PinceVerrou.Ranger();

                    Plateau.AvantCharge = false;
                    Thread.Sleep(800);

                    Robots.GrosRobot.Reculer(320);
                    Robots.GrosRobot.PivotGauche(180);
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
                    Robots.GrosRobot.Historique.Log("Fin dépose violet en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");

                    return true;
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Annulation dépose violet, trajectoire échouée");
                    return false;
                }
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation dépose violet, trajectoire non trouvée");
                return false;
            }
        }

        public override double Score
        {
            get { return BonneCouleur() && Plateau.EtapeDune == 5 ? 100000 : 0; }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }

        public override string ToString()
        {
            return "Dépose violet";
        }
    }
}
