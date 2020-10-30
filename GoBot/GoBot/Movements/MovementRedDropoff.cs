using Geometry.Shapes;
using GoBot.Actionneurs;
using GoBot.BoardContext;
using GoBot.GameElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.Movements
{
    class MovementRedDropoff : Movement
    {
        private RandomDropOff _randomDropOff;

        public MovementRedDropoff(RandomDropOff dropoff)
        {
            _randomDropOff = dropoff;

            Positions.Add(new Geometry.Position(90, new RealPoint(_randomDropOff.Position.X + (_randomDropOff.Position.X < 1500 ? 50 : -50), 730 + 600 - 30)));
        }

        public override bool CanExecute => !_randomDropOff.HasLoadOnBottom && Actionneur.Lifter.Loaded;

        public override int Score
        {
            get
            {
                if (!_randomDropOff.HasLoadOnTop)
                    return 8;
                else
                    return 22 - 8;
            }
        }

        public override double Value => 2;

        public override GameElement Element => _randomDropOff;

        public override Robot Robot => Robots.MainRobot;

        public override Color Color => _randomDropOff.Owner;

        protected override void MovementBegin()
        {
        }

        protected override bool MovementCore()
        {
            Actionneur.Lifter.DoSequenceDropOff();
            _randomDropOff.SetLoadBottom(Actionneur.Lifter.Load);
            Actionneur.Lifter.Load = null;
            GameBoard.AddObstacle(new Segment(new RealPoint(_randomDropOff.Position.X - 200, 525 + 600 - 30), new RealPoint(_randomDropOff.Position.X + 200, 525 + 600 - 30)));

            if (_randomDropOff.Owner == GameBoard.ColorLeftBlue)
            {
                GameBoard.Elements.FindBuoy(new RealPoint(300, 1200)).IsAvailable = false;
                GameBoard.Elements.FindBuoy(new RealPoint(450, 1100)).IsAvailable = false;
            }
            else
            {
                GameBoard.Elements.FindBuoy(new RealPoint(3000 - 300, 1200)).IsAvailable = false;
                GameBoard.Elements.FindBuoy(new RealPoint(3000 - 450, 1100)).IsAvailable = false;
            }

            return true;
        }

        protected override void MovementEnd()
        {
        }
    }
}
