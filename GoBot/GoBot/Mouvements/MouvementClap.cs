using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.Actionneurs;
using GoBot.Calculs.Formes;
using System.Threading;

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
                Positions.Add(new Position(0, new PointReel(243, 1699)));
            else if (i == 1)
                Positions.Add(new Position(0, new PointReel(543, 1699)));
            else if (i == 2)
                Positions.Add(new Position(0, new PointReel(843, 1699)));
            else if (i == 3)
                Positions.Add(new Position(0, new PointReel(2070, 1699)));
            else if (i == 4)
                Positions.Add(new Position(0, new PointReel(2370, 1699)));
            else if (i == 5)
                Positions.Add(new Position(0, new PointReel(2670, 1699)));

            if (numeroClap % 2 == 0)
                Couleur = Plateau.CouleurGaucheJaune;
            else
                Couleur = Plateau.CouleurDroiteVert;
        }

        public override bool Executer(int timeOut = 0)
        {
            Robots.GrosRobot.Historique.Log("Début pied " + numeroClap);

            DateTime debut = DateTime.Now;

            Position position = PositionProche;

            if (position != null && Robots.GrosRobot.GotoXYTeta(position.Coordonnees.X, position.Coordonnees.Y, position.Angle.AngleDegres))
            {
                if (numeroClap < 3)
                {
                    Config.CurrentConfig.ServoAspirateurCoude.Positionner(Config.CurrentConfig.ServoAspirateurCoude.PositionAspiration);
                    Thread.Sleep(200);
                    Config.CurrentConfig.ServoAspirateurEpaule.Positionner(Config.CurrentConfig.ServoAspirateurEpaule.PositionAspiration);
                    Thread.Sleep(100);
                    Config.CurrentConfig.ServoAspirateurEpaule.Positionner(Config.CurrentConfig.ServoAspirateurEpaule.PositionRange);
                    Thread.Sleep(100);
                    Config.CurrentConfig.ServoAspirateurCoude.Positionner(Config.CurrentConfig.ServoAspirateurCoude.PositionRange);
                }
                else
                {
                    Config.CurrentConfig.ServoAspirateurEpaule.Positionner(509);
                    Thread.Sleep(200);
                    Config.CurrentConfig.ServoAspirateurCoude.Positionner(623);
                    Thread.Sleep(200);
                    Config.CurrentConfig.ServoAspirateurEpaule.Positionner(250);
                    Thread.Sleep(200);
                    Config.CurrentConfig.ServoAspirateurEpaule.Positionner(509);
                    Thread.Sleep(200);
                    Config.CurrentConfig.ServoAspirateurCoude.Positionner(Config.CurrentConfig.ServoAspirateurCoude.PositionRange);
                    Thread.Sleep(200);
                    Config.CurrentConfig.ServoAspirateurEpaule.Positionner(Config.CurrentConfig.ServoAspirateurEpaule.PositionRange);
                }

                Actionneur.BrasAspirateur.PositionRange();
                Robots.GrosRobot.Historique.Log("Fin clap " + numeroClap + " en " + (DateTime.Now - debut).TotalSeconds.ToString("#.#") + "s");
                Plateau.Claps[numeroClap].Active = true;
            }
            else
            {
                Robots.GrosRobot.Historique.Log("Annulation clap " + numeroClap);
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
                    return 1;

                return 5; 
            }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
    }
}
