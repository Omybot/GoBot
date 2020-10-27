using Geometry;
using Geometry.Shapes;
using GoBot.Actionneurs;
using GoBot.GameElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoBot.Movements
{
    class MovementGroundedZone : Movement
    {
        GroundedZone _zone;

        public override bool CanExecute => !Actionneur.Lifter.Loaded && Element.IsAvailable;

        public override int Score => 0;

        public override double Value => 1;

        public override GameElement Element => _zone;

        public override Robot Robot => Robots.MainRobot;

        public override Color Color => Element.Owner;

        public MovementGroundedZone(GroundedZone zone) : base()
        {
            _zone = zone;

            Positions.Add(new Position(180, new RealPoint(_zone.Position.X - 70 - 225, zone.Position.Y)));
            Positions.Add(new Position(0, new RealPoint(_zone.Position.X + 70 + 225, zone.Position.Y)));
            Positions.Add(new Position(90, new RealPoint(_zone.Position.X, zone.Position.Y + 70 + 225)));
        }

        protected override void MovementBegin()
        {
            // rien
        }

        protected override bool MovementCore()
        {
            Actionneur.Lifter.DoSequencePickup();
            Actionneur.Lifter.Load = _zone.Buoys.Select(b => b.Color).ToList();
            _zone.IsAvailable = false;
            _zone.Buoys.ForEach(b => b.IsAvailable = false);
            Robots.MainRobot.MoveForward(100);

            return true;
        }

        protected override void MovementEnd()
        {
            // rien
        }
    }
}
