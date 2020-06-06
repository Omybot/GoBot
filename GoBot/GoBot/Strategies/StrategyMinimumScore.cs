using System.Collections.Generic;
using Geometry;
using Geometry.Shapes;
using GoBot.Movements;
using GoBot.BoardContext;

namespace GoBot.Strategies
{
    /// <summary>
    /// Stratégie qui consiste à marquer juste quelques points (pour homologuation de capacité à marquer des points par exemple)
    /// </summary>
    class StrategyMinimumScore : Strategy
    {
        private bool _avoidElements = true;

        public override bool AvoidElements => _avoidElements;

        List<Movement> mouvements = new List<Movement>();

        protected override void SequenceBegin()
        {
            // Sortir ICI de la zonde de départ

            Robots.MainRobot.UpdateGraph(GameBoard.ObstaclesAll);
            //Robots.MainRobot.MoveForward(500);
            
            if (GameBoard.MyColor == GameBoard.ColorLeftBlue)
            {
                //*mouvements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorYellow));
            }
            else
            {
                //*mouvements.Add(new MoveAccelerator(Plateau.Elements.AcceleratorViolet));
            }
        }
        
        protected override void SequenceCore()
        {
            // TODOYEACHYEAR Ajouter ICI l'ordre de la strat fixe avant détection d'adversaire

            _avoidElements = true;

            foreach (Movement move in mouvements)
            {
                bool ok = false;
                while (!ok)
                {
                    ok = move.Execute();
                }
            }
            
            while (IsRunning)
            {
                while (!Robots.MainRobot.GoToPosition(new Position(0, new RealPoint(700, 1250)))) ;
                while (!Robots.MainRobot.GoToPosition(new Position(180, new RealPoint(3000 - 700, 1250)))) ;
            }
        }
    }
}
