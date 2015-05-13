﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using System.Drawing;
using GoBot.ElementsJeu;
using GoBot.Calculs.Formes;

namespace GoBot.Mouvements
{
    class MouvementDeposeDepart : Mouvement
    {
        private BrasPieds brasSpot, brasGobelet;

        public MouvementDeposeDepart(ZoneInteret zone)
        {
            Element = zone;

            Robot = Robots.GrosRobot;

            if (zone.Couleur == Plateau.CouleurGaucheJaune)
            {
                Positions.Add(new Position(180, new PointReel(530, 1000)));
                brasSpot = Actionneur.BrasPiedsDroite;
                brasGobelet = Actionneur.BrasPiedsGauche;
                Couleur = zone.Couleur;
            }
            else
            {
                Positions.Add(new Position(0, new PointReel(3000-530, 1000)));
                brasSpot = Actionneur.BrasPiedsGauche;
                brasGobelet = Actionneur.BrasPiedsDroite;
                Couleur = zone.Couleur;
            }
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début pose zone de départ");

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                Robots.GrosRobot.Avancer(250);
                brasGobelet.DeposeGobelet(false);
                brasSpot.DeposeSpot();

                brasSpot.AscenseurMonter();
                brasGobelet.AscenseurMonter();

                Robots.GrosRobot.Reculer(250);

                // Verse les pop corn dans le gobelet
                /*Robots.GrosRobot.Reculer(280);
                Actionneur.BrasAspirateur.Maintenir();
                Robots.GrosRobot.PivotDroite(180);
                Actionneur.BrasAspirateur.PositionDepose();
                Robots.GrosRobot.PivotDroite(60);
                Thread.Sleep(4000);
                Actionneur.BrasAspirateur.Arreter();
                Actionneur.BrasAspirateur.PositionRange();*/

                Robots.GrosRobot.Historique.Log("Fin zone dépose en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                ((ZoneInteret)Element).Interet = false;
                return true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation zone dépose");
                return false;
            }
        }

        public override double Score
        {
            get 
            {
                if (!((ZoneInteret)Element).Interet || !BonneCouleur())
                    return 0;
                else
                {
                    int score = 0;

                    score += Actionneur.BrasPiedsDroite.NbPieds == 4 && Actionneur.BrasPiedsGauche.Gobelet ? 25 : 0;
                    score += Actionneur.BrasPiedsGauche.NbPieds == 4 && Actionneur.BrasPiedsDroite.Gobelet ? 25 : 0;

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
