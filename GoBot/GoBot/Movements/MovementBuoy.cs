using Geometry;
using GoBot.Actionneurs;
using GoBot.GameElements;
using GoBot.Threading;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.Movements
{
    class MovementBuoy : Movement
    {
        private Buoy _buoy;
        private Elevator _elevator;

        public MovementBuoy(Buoy buoy)
        {
            _buoy = buoy;
            _elevator = Actionneur.FindElevator(_buoy.Color);

            double delta = _elevator == Actionneur.ElevatorLeft ? 30 : -30;
            //for (int i = 0; i < 360; i += 60)
            //{
            //    Positions.Add(new Geometry.Position(i + delta + 180, new Geometry.Shapes.RealPoint(_buoy.Position.X + 200* new AnglePosition(delta + i).Cos, _buoy.Position.Y + 200 * new AnglePosition(delta + i).Sin)));
            //}

            for (int i = 0; i < 360; i += 60)
            {
                Positions.Add(new Geometry.Position(i + 180 + delta, new Geometry.Shapes.RealPoint(_buoy.Position.X + 250 * new AnglePosition(i).Cos, _buoy.Position.Y + 250 * new AnglePosition(i).Sin)));

            }

            //AnglePosition a = 0;
            //Positions.Add(new Geometry.Position(a + 180 + delta, new Geometry.Shapes.RealPoint(_buoy.Position.X + 250 * new AnglePosition(a).Cos, _buoy.Position.Y + 250 * new AnglePosition(a).Sin)));
            //a = 180;
            //Positions.Add(new Geometry.Position(a + 180 + delta, new Geometry.Shapes.RealPoint(_buoy.Position.X + 250 * new AnglePosition(a).Cos, _buoy.Position.Y + 250 * new AnglePosition(a).Sin)));

        }

        public override bool CanExecute => _buoy.IsAvailable && _elevator.CountTotal < Elevator.MaxLoad - 1;

        public override int Score => 0;

        public override double Value => 0.5;

        public override GameElement Element => _buoy;

        public override Robot Robot => Robots.MainRobot;

        public override Color Color => Color.White;

        protected override void MovementBegin()
        {
        }

        protected override bool MovementCore()
        {
            _elevator.DoGrabOpen();
            Robot.SetSpeedSlow();
            Robot.MoveForward(150);
            _elevator.DoSequencePickupColorThread(_buoy.Color);
            _buoy.IsAvailable = false;

            return true;
        }

        protected override void MovementEnd()
        {
        }
    }
}
