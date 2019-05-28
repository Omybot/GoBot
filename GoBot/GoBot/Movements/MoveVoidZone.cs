using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GoBot.GameElements;
using Geometry;
using Geometry.Shapes;
using GoBot.Actionneurs;

namespace GoBot.Movements
{
    public class MoveVoidZone : Movement
    {
        VoidZone _zone;

        public MoveVoidZone(VoidZone zone)
        {
            int distance = 350;
            _zone = zone;

            for(int i = 0; i < 360; i += 45)
            {
                double rad = i / 180.0 * Math.PI;
                Positions.Add(new Position(i + 180, new RealPoint(_zone.Position.X + distance * Math.Cos(rad), _zone.Position.Y + distance * Math.Sin(rad))));
            }
        }

        public override bool CanExecute => _zone.IsAvailable && _zone.AtomsCount > 0;

        public override int Score => 0;

        public override double Value => _zone.AtomsCount;

        public override GameElement Element => _zone;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _zone.Owner;

        protected override void MovementBegin()
        {
            // TODO2019 : libérer le champ de vision du LIDAR
        }

        protected override void MovementCore()
        {
            _zone.AtomsCount -= Actionneur.AtomHandler.DoVoidZone();
            _zone.AtomsCount = 0;
        }

        protected override void MovementEnd()
        {
            // TODO2019 : baisse le bras devant le LIDAR
        }
    }
}
