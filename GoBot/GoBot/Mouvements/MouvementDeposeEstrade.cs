using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using System.Drawing;
using GoBot.ElementsJeu;
using System.Threading;
using GoBot.Calculs.Formes;
using GoBot.PathFinding;

namespace GoBot.Mouvements
{
    class MouvementDeposeEstrade : Mouvement
    {
        private BrasPieds brasSpot;

        public MouvementDeposeEstrade(ZoneInteret zone)
        {
            Element = zone;

            Robot = Robots.GrosRobot;

            if (zone.Couleur == Plateau.CouleurGaucheJaune)
            {
                Positions.Add(new Position(45, new Calculs.Formes.PointReel(1099, 1689)));
                brasSpot = Actionneur.BrasPiedsDroite;
                Couleur = Plateau.CouleurGaucheJaune;
            }
            else
            {
                Positions.Add(new Position(180 - 45, new Calculs.Formes.PointReel(3000 - 1099, 1689)));
                brasSpot = Actionneur.BrasPiedsGauche;
                Couleur = Plateau.CouleurDroiteVert;
            }
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début pose zone estrade");

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null)
            {
                Trajectoire traj = PathFinder.ChercheTrajectoire(Robot.Graph, Plateau.ListeObstacles, new Position(Robot.Position), position, Robot.Rayon, 160);

                if (traj != null && Robot.ParcourirTrajectoire(traj))
                {
                    if (!Actionneur.BrasSpot.AmpouleSurSpot && Actionneur.BrasGobelet.AmpoulePrechargee)
                        BrasPieds.TransfererBalle();

                    if (Plateau.Enchainement.TempsRestant.TotalSeconds < 20)
                    {
                        brasSpot.OuvrirPinceHaut();
                        brasSpot.Deverrouiller();
                        brasSpot.NbPieds = 0;
                        brasSpot.AmpouleSurSpot = false;
                        Thread.Sleep(300);
                        Actionneur.BrasSpot.AscenseurDescendre();
                        Thread.Sleep(500);
                        brasSpot.OuvrirPinceBas();
                        Thread.Sleep(1000);
                        Robots.GrosRobot.Reculer(250);

                        if (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune)
                            Plateau.ObstaclesCrees.Add(new Cercle(new PointReel(1250, 1950), 200));
                        else
                            Plateau.ObstaclesCrees.Add(new Cercle(new PointReel(1750, 1950), 200));
                    }

                    else
                    {
                        if (brasSpot.NbPieds == 4)
                        {
                            // Si on a 4 pieds, on reprend la tour depuis la base
                            brasSpot.OuvrirPinceBas();
                            Thread.Sleep(200);
                            brasSpot.AscenseurDescendre();
                            brasSpot.LibererBalle();
                            Thread.Sleep(500);
                            brasSpot.FermerPinceBas();
                            Thread.Sleep(200);
                        }

                        brasSpot.OuvrirPinceHaut();
                        Thread.Sleep(300);
                        brasSpot.AscenseurMonter();
                        Thread.Sleep(500);
                        brasSpot.FermerPinceHaut();

                        Robots.GrosRobot.VitesseAdaptableEnnemi = false;
                        Robot.VitesseDeplacement = 200;
                        Robot.Avancer(120);
                        Robot.VitesseDeplacement = 100;
                        brasSpot.AscenseurHauteur(brasSpot.PositionHauteurDeposeEstrade);
                        brasSpot.DeposeSpot(true);
                        Robot.Reculer(70);
                        brasSpot.FermerPinceBas();
                        brasSpot.AscenseurHauteur(brasSpot.PositionHauteurPousseEstrade);
                        Robot.VitesseDeplacement = 50;
                        Robot.Avancer(50);
                        Robot.Reculer(10);
                        Robot.Reculer(50);
                        brasSpot.AscenseurMonter();
                        Robot.Rapide();
                        Robots.GrosRobot.VitesseAdaptableEnnemi = true;
                    }

                    Robots.GrosRobot.Historique.Log("Fin zone dépose estrade en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                    ((ZoneInteret)Element).Interet = false;
                    return true;
                }
                else
                {
                    Robots.GrosRobot.Historique.Log("Annulation zone estrade, trajectoire échouée");
                    return false;
                }
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation zone estrade, trajectoire non trouvée");
                return false;
            }
        }

        public override double Score
        {
            get
            {
                if (!((ZoneInteret)Element).Interet || Plateau.NotreCouleur != ((ZoneInteret)Element).Couleur)
                    return 0;
                else
                {
                    double score = 0;
                    if (Actionneur.BrasPiedsDroite.NbPieds > 0)
                        score += 0.0001;

                    score += Actionneur.BrasPiedsDroite.NbPieds == 4 ? 20 : 0;
                    score += Actionneur.BrasPiedsGauche.NbPieds == 4 ? 20 : 0;

                    // Triple l'importance de déposer dans les 20 dernières secondes
                    if (Plateau.Enchainement.TempsRestant.TotalSeconds < 20)
                        score += Actionneur.BrasPiedsDroite.NbPieds * 5;

                    return score;
                }
            }
        }

        public override double ScorePondere
        {
            get
            {
                return Score;
            }
        }

        public override string ToString()
        {
            return "Dépose sur estrade";
        }
    }
}
