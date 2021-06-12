using Geometry;
using Geometry.Shapes;
using GoBot.BoardContext;
using GoBot.GameElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoBot.Movements
{
    class MovementRandomPickup : Movement
    {
        private bool _hasBuoys = true;
        private GameElementZone _zone;

        public MovementRandomPickup(GameElementZone zone)
        {
            _zone = zone;

            Positions.Add(new Position(-45, new RealPoint(1050, 400)));
            Positions.Add(new Position(-45 + 180, new RealPoint(1950, 400)));
        }

        public override bool CanExecute => _hasBuoys;

        public override int Score => 0;

        public override double Value => _hasBuoys ? 1 : 0;

        public override GameElement Element => _zone;

        public override Robot Robot => Robots.MainRobot;

        public override Color Color => Color.White;

        protected override void MovementBegin()
        {
        }

        protected override bool MovementCore()
        {
            bool found = true;

            while (found && Actionneurs.Actionneur.ElevatorLeft.CanStoreMore)
                found = Actionneurs.Actionneur.ElevatorLeft.DoSearchBuoy(Buoy.Green, new Circle(_zone.Position, _zone.HoverRadius));

            while (found && Actionneurs.Actionneur.ElevatorRight.CanStoreMore)
                found = Actionneurs.Actionneur.ElevatorRight.DoSearchBuoy(Buoy.Red, new Circle(_zone.Position, _zone.HoverRadius));

            _hasBuoys = false;

            return found;
        }

        protected override void MovementEnd()
        {
            Actionneurs.Actionneur.ElevatorLeft.DoStoreActuators();
            Actionneurs.Actionneur.ElevatorRight.DoStoreActuators();
        }
    }
}
