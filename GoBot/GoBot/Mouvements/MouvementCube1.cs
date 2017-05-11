﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using GoBot.Actionneurs;
//using System.Threading;
//using GoBot.Calculs;
//using GoBot.Calculs.Formes;
//using GoBot.PathFinding;
//using GoBot.ElementsJeu;
//using System.Drawing;

//namespace GoBot.Mouvements
//{
//    class MouvementCube1 : Mouvement
//    {
//        private bool ramasse;

//        public MouvementCube1()
//        {
//            ramasse = false;
//            Positions.Add(new Position(180, new PointReel(446+1378, 298)));
//        }

//        public override Color Couleur
//        {
//            get { return Color.White; }
//        }

//        public override Robot Robot
//        {
//            get { return Robots.GrosRobot; }
//        }

//        public override ElementJeu Element
//        {
//            get { return Plateau.Elements.ZoneCubeGauche; }
//        }

//        public override bool Executer(int timeOut = 0)
//        {
//            Robots.GrosRobot.Historique.Log("Début attrape cube 1");

//            DateTime debut = DateTime.Now;

//            Position position = PositionProche;

//            if (position != null)
//            {
//                Trajectoire traj = PathFinder.ChercheTrajectoire(Robot.Graph, Plateau.ListeObstacles, new Position(Robot.Position), position, Robot.Rayon, 160);

//                if (traj != null && Robot.ParcourirTrajectoire(traj))
//                {
//                    Actionneur.BrasDroite.Ouvrir();
//                    Robots.GrosRobot.Lent();
//                    Robots.GrosRobot.Reculer(200);


//                    Actionneur.BrasDroite.Deployer();
//                    Thread.Sleep(750);

//                    Robots.GrosRobot.PivotGauche(1);

//                    for (int i = 0; i < 10; i++)
//                    {
//                        Actionneur.BrasDroite.Fermer();
//                        Thread.Sleep(100);
//                    }

//                    Robots.GrosRobot.Lent();
//                    Robots.GrosRobot.Avancer(190);
//                    Robots.GrosRobot.PivotDroite(90);

//                    ramasse = true;
//                    Robots.GrosRobot.Historique.Log("Fin attrape cube 1 en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");

//                    return true;
//                }
//                else
//                {
//                    Robots.GrosRobot.Historique.Log("Annulation attrape cube 1, trajectoire échouée");
//                    return false;
//                }
//            }
//            else
//            {
//                Robots.GrosRobot.Historique.Log("Annulation attrape cube 1, trajectoire non trouvée");
//                return false;
//            }
//        }

//        public override double Score
//        {
//            get { return 0; }
//            //get { return !ramasse && !Plateau.AvantCharge && !Plateau.ArriereCharge ? 100 : 0; }
//        }

//        public override double ValeurAction
//        {
//            get { return Score; }
//        }
//        public override string ToString()
//        {
//            return "Attrape cube 1";
//        }
//    }
//}