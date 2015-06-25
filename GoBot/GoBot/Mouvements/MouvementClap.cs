using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using GoBot.Calculs.Formes;
using System.Threading;
using GoBot.PathFinding;

namespace GoBot.Mouvements
{
    class MouvementClap : Mouvement
    {
        int numeroClap;

        public MouvementClap(int i)
        {
            numeroClap = i;
            Element = Plateau.Claps[i];
            Robot = Robots.GrosRobot;

            if(i == 0)
                Positions.Add(new Position(0, new PointReel(747 - 300 - 230, 1757)));
            else if (i == 1)
                Positions.Add(new Position(0, new PointReel(747-230, 1757)));
            else if (i == 2)
                Positions.Add(new Position(0, new PointReel(747 + 300 - 230, 1757)));
            else if (i == 3)
                Positions.Add(new Position(-90, new PointReel(2700-600, 1790)));
            else if (i == 4)
                Positions.Add(new Position(-90, new PointReel(2700 - 300, 1790)));
            else if (i == 5)
                Positions.Add(new Position(-90, new PointReel(2700, 1790)));

            if (numeroClap % 2 == 0)
                Couleur = Plateau.CouleurGaucheJaune;
            else
                Couleur = Plateau.CouleurDroiteVert;
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début clap " + numeroClap);

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle))
            {
                    if (numeroClap < 3)
                    {
                        Config.CurrentConfig.ServoAspirateurEpaule.Positionner(Config.CurrentConfig.ServoAspirateurEpaule.PositionDepose);
                        Robots.GrosRobot.Lent();
                        Robots.GrosRobot.Avancer(120);
                        Robots.GrosRobot.Rapide();
                        Config.CurrentConfig.ServoAspirateurEpaule.Positionner(Config.CurrentConfig.ServoAspirateurEpaule.PositionRange);
                    }
                    else
                    {
                        Config.CurrentConfig.ServoAspirateurEpaule.Positionner(Config.CurrentConfig.ServoAspirateurEpaule.PositionDepose);
                        //Thread.Sleep(200);
                        Robots.GrosRobot.Lent();
                        Robots.GrosRobot.PivotDroite(35 + 50);
                        Robots.GrosRobot.Rapide();
                        Config.CurrentConfig.ServoAspirateurEpaule.Positionner(Config.CurrentConfig.ServoAspirateurEpaule.PositionRange);
                    }

                    Actionneur.BrasAspirateur.PositionRange();
                    Robots.GrosRobot.Historique.Log("Fin clap " + numeroClap + " en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                    Plateau.Claps[numeroClap].Active = true;
            }
            else
            {
                Robot.Historique.Log("Annulation clap " + numeroClap);
                return false;
            }
            return true;
        }

        public override double Score
        {
            get
            {
                if (numeroClap == 0 && (!Plateau.Pieds[1].Ramasse || !Plateau.Pieds[2].Ramasse || !Plateau.Gobelets[0].Ramasse) && Plateau.Enchainement.TempsRestant.TotalSeconds > 10)
                    return 0;

                if (numeroClap == 5 && (!Plateau.Pieds[15].Ramasse || !Plateau.Pieds[14].Ramasse || !Plateau.Gobelets[4].Ramasse) && Plateau.Enchainement.TempsRestant.TotalSeconds > 10)
                    return 0;

                if (Plateau.Claps[numeroClap].Active)
                    return 0;

                if (!BonneCouleur())
                    return 0;

                // Claps coté adverse
                if (numeroClap == 1 || numeroClap == 4)
                    return 0.1;

                return 5; 
            }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }

        public override string ToString()
        {
            return "Clap " + numeroClap;
        }
    }
}
