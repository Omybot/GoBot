using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoBot.Calculs;
using GoBot.IHM;
using System.Threading;
using GoBot.Calculs.Formes;

namespace GoBot.Mouvements
{
    class MoveGrosAspireAssiette : Mouvement
    {
        public override Position Position 
        { 
            get; protected set; 
        }

        private int numeroAssiette;

        public MoveGrosAspireAssiette(int iAssiette)
        {
            numeroAssiette = iAssiette;
            //Position = PositionsMouvements.PositionGrosCadeau[iCadeau];
        }

        public override bool Executer(int timeOut = 0)
        {
            Plateau.AssiettesVidees[numeroAssiette] = true;
            if (Robots.GrosRobot.PathFinding(Position.Coordonnees.X, Position.Coordonnees.Y, timeOut, true))
            {
                Angle angle180 = Position.Angle - Robots.GrosRobot.Position.Angle;

                Robots.GrosRobot.PositionerAngle(Position.Angle, 1);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasBas);
                Thread.Sleep(200);
                Robots.GrosRobot.BougeServo(ServomoteurID.GRGrandBras, Config.CurrentConfig.PositionGRGrandBrasRange);

                Plateau.Score += Score;
                return true;
            }
            else
            {
                Plateau.CadeauxActives[numeroAssiette] = false;
                return false;
            }
        }

        public override double Cout
        {
            get
            {
                if (Score <= 0)
                    return double.MaxValue;

                double distance = Robots.GrosRobot.Position.Coordonnees.Distance(Position.Coordonnees) / 10;
                double cout = distance * distance / ScorePondere;

                Plateau.SemaphoreGraph.WaitOne();
                foreach (Cercle c in Plateau.ObstaclesTemporaires)
                {
                    double distanceAdv = Position.Coordonnees.Distance(c.Centre) / 10;
                    if (distanceAdv < 45)
                        cout = double.PositiveInfinity;
                    else
                        cout /= (distanceAdv * distanceAdv * distanceAdv);
                }
                Plateau.SemaphoreGraph.Release();

                return cout * 10000;
            }
        }

        public override int Score
        {
            get
            {
                return 0;
            }
        }

        public override double ScorePondere
        {
            get
            {
                return 1 + Score * Plateau.PoidActions.PoidGlobalGrosCadeau * Plateau.PoidActions.PoidsGrosAssiette[numeroAssiette];
            }
        }
    }
}
