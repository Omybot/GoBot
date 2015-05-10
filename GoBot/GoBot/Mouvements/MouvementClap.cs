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
            // TODO Samedi : Déterminer les angles d'attaque possibles / bras à utiliser pour chaque pied 
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

        public override int Score
        {
            get { return (Plateau.NotreCouleur == Plateau.CouleurGaucheJaune && numeroClap % 2 == 0) ? 5 : 0; }
        }

        public override double ScorePondere
        {
            get { return Score; }
        }
    }
}
