using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoBot.Movements;
using GoBot.BoardContext;
using Geometry;
using Geometry.Shapes;

namespace GoBot.Strategies
{
    class StrategyMini : Strategy
    {
        public override bool AvoidElements => true;

        protected override void SequenceBegin()
        {
            Robots.MainRobot.UpdateGraph(GameBoard.ObstaclesAll);

            // Sortir de la zonde de départ dès le début sans détection
            Robots.MainRobot.MoveForward(500);

            Position positionCale = new Position(50, new RealPoint(1800, 1800));
            Position positionInit = new Position(0, new RealPoint(500, 500));

            if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
            {
                int tries = 0;
                bool succeed = false;

                do
                {
                    tries++;
                    succeed = Robots.MainRobot.GoToPosition(positionCale);
                } while (!succeed && tries < 3 && Robots.MainRobot.TrajectoryCutOff);// On reessaie, maximum 3 fois si la trajectoire a échoué parce qu'on m'a coupé la route

                if (succeed)
                {
                    // Je suis dans la cale !
                    Robots.MainRobot.PivotLeft(360);
                }
                else
                {
                    // On m'a empeché d'y aller, je vais ailleurs
                    succeed = Robots.MainRobot.GoToPosition(positionInit);
                }
            }
            else
            {
            }
        }

        protected override void SequenceCore()
        {
            // Le petit robot ne fait plus rien après la séquence initiale
            while (IsRunning)
            {
                Robots.MainRobot.Historique.Log("Aucune action à effectuer");
                Thread.Sleep(500);
            }
        }
    }
}
