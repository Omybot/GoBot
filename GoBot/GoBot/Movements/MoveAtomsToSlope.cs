using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GoBot.GameElements;
using GoBot.Actionneurs;

namespace GoBot.Movements
{
    public class MoveAtomsToSlope : Movement
    {
        private Slope _slope;

        public MoveAtomsToSlope(Slope slope)
        {
            _slope = slope;
        }

        public override bool CanExecute => !_slope.HasAtoms;

        public override int Score => 0;

        public override double Value => 1;

        public override GameElement Element => _slope;

        public override Robot Robot => Robots.GrosRobot;

        public override Color Color => _slope.Owner;

        protected override void MovementBegin()
        {
        }

        protected override void MovementCore()
        {
            Actionneur.GoldGrabberLeft.DoCalibEject();
        }

        protected override void MovementEnd()
        {
        }
    }
}
