using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using System.Drawing;
using GoBot.ElementsJeu;
using System.Threading;

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
                Positions.Add(new Position(180 - 139.12, new Calculs.Formes.PointReel(3000 - 1898, 1700)));
                brasSpot = Actionneur.BrasPiedsDroite;
                Couleur = Plateau.CouleurGaucheJaune;
            }
            else
            {
                Positions.Add(new Position(139.12, new Calculs.Formes.PointReel(1898, 1700)));
                brasSpot = Actionneur.BrasPiedsGauche;
                Couleur = Plateau.CouleurDroiteVert;
            }
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début pose zone estrade");

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                if (brasSpot.NbPieds == 4)
                {
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
                brasSpot.AscenseurHauteur(brasSpot.PositionHauteurApprocheEstrade);
                Thread.Sleep(500);
                brasSpot.FermerPinceHaut();

                Robot.VitesseDeplacement = 200;
                Robot.Avancer(100);
                brasSpot.AscenseurHauteur(brasSpot.PositionHauteurDeposeEstrade);
                brasSpot.DeposeSpot(true);
                Robot.Reculer(100);
                brasSpot.FermerPinceBas();
                brasSpot.AscenseurHauteur(brasSpot.PositionHauteurPousseEstrade);
                Robot.VitesseDeplacement = 50;
                Robot.AccelerationFinDeplacement /= 2;
                Robot.Avancer(100);
                Robot.AccelerationFinDeplacement *= 2;
                Robot.Reculer(10);
                brasSpot.AscenseurMonter();
                Robot.Rapide();
                Robot.Reculer(100);

                Robots.GrosRobot.Historique.Log("Fin zone dépose estrade en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                ((ZoneInteret)Element).Interet = false;
                return true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation zone dépose estrade");
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
    }
}
