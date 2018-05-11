using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoBot.GameElements;
using System.Threading;

namespace GoBot.Movements
{
    class MovementDomoticBoard : Movement
    {
        private DomoticBoard _board;

        public MovementDomoticBoard(DomoticBoard board)
        {
            _board = board;

            Positions.Add(new Geometry.Position(-90, new Geometry.Shapes.RealPoint(_board.Color == Plateau.CouleurGaucheVert ? 1130 : 1870, 400)));
        }

        public override bool CanExecute => _board.IsAvailable;

        public override int Score => 25;

        public override double Value => 25;

        public override GameElement Element => _board;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _board.Color;

        protected override void MovementBegin()
        {
            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionCentre);
        }

        protected override void MovementCore()
        {
            Config.CurrentConfig.ServoCoudeGauche.SendPosition(Config.CurrentConfig.ServoCoudeGauche.Minimum);
            Thread.Sleep(200);
            Config.CurrentConfig.ServoLateralGauche.SendPosition(Config.CurrentConfig.ServoLateralGauche.PositionCentre);
            Config.CurrentConfig.ServoPoignetGauche.SendPosition(25700);
            Robots.GrosRobot.Avancer(100);

            Robots.GrosRobot.Lent();
            Robots.GrosRobot.Avancer(30);

            // Pousser l'interrupteur

            Plateau.Score += Score;
            _board.IsAvailable = false;

            //Config.CurrentConfig.ServoPoignetGauche.SendPosition(Config.CurrentConfig.ServoPoignetGauche.PositionPrise);
            //Thread.Sleep(250);

            Robots.GrosRobot.Rapide();
            Robots.GrosRobot.Reculer(115);

            Threading.ThreadManager.CreateThread(link => Actionneurs.Actionneur.Harvester.DoInitArms()).StartThread();
        }
    }
}
