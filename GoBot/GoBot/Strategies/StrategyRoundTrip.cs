using Geometry;
using Geometry.Shapes;
using GoBot.BoardContext;

namespace GoBot.Strategies
{
    /// <summary>
    /// Stratégie qui consiste à faire des aller-retours sur la piste (pour homologuation d'évitement par exemple)
    /// </summary>
    class StrategyRoundTrip : Strategy
    {
        public override bool AvoidElements => false;

        protected override void SequenceBegin()
        {
            Robots.GrosRobot.MajGraphFranchissable(GameBoard.ObstaclesAll);

            //Plateau.Balise.VitesseRotation(250);

            // Sortir ICI de la zone de départ pour commencer

            Robots.GrosRobot.Avancer(200);
        }

        protected override void SequenceCore()
        {
            while (IsRunning)
            {
                while (!Robots.GrosRobot.GotoXYTeta(new Position(0, new RealPoint(700, 1250)))) ;
                while (!Robots.GrosRobot.GotoXYTeta(new Position(180, new RealPoint(3000 - 700, 1250)))) ;
            }
        }
    }
}
